Imports System.Data.SqlClient
Imports System.Text
Imports System.Drawing.Printing
Imports NiceLabel.SDK
Imports System.IO

Public Class frmPrintLabel

    Dim _ClassName As String = "frmPrintLabel"
    Dim _label As ILabel


    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtQRcode.TextChanged

    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtQRcode.KeyDown
        If e.KeyCode.Equals(Keys.Enter) Then
            If Trim(txtQRcode.Text) <> String.Empty Then
                Call Scan_QR()
            Else
                '  flag_check_QR = False
                txtQRcode.Focus()
            End If
        End If
    End Sub

    Private Sub Scan_QR()
        Dim _FunctionName As String = "Scan_QR"

        Try

            Dim Dummy_qr As String = txtQRcode.Text.Trim
            Dim arr_QR() As String
            Dim tmp_Qr As String
            Dim StrSQL As New StringBuilder()

            '       lblTGRT_Code.Text = txtQRcode.Text
            'tmp_Qr = txtQRcode.Text.Trim
            tmp_Qr = Dummy_qr
            txtQRcode.Text = String.Empty

            Dim tmp_tb As New DataTable

            StrSQL.Append("SELECT * From [View_ALL_PRODUCT_MAS]")
            StrSQL.Append(" WHERE [TGRT Code]='" & tmp_Qr & "'")

            tmp_tb = DatabaseConnection.SQLConnect.SQL.Read(StrSQL.ToString, cs)

            If tmp_tb Is Nothing Then
                MessageBox.Show("'" & tmp_Qr & "' not found in master product!!")
                Call Clear_Default()
                Return

            End If

            If tmp_tb.Rows.Count <= 0 Then
                MessageBox.Show("'" & tmp_Qr & "' not found in master product!!")
                Call Clear_Default()

                Return
            End If


            lblTGRT_Code.Text = tmp_tb.Rows(0).Item(0).ToString
            lblBarcode.Text = tmp_tb.Rows(0).Item(1).ToString
            lblCusBarcode.Text = tmp_tb.Rows(0).Item(2).ToString

            lblPartName.Text = tmp_tb.Rows(0).Item(3).ToString
            lblPartNo.Text = tmp_tb.Rows(0).Item(4).ToString
            lblLocation.Text = tmp_tb.Rows(0).Item(5).ToString


            Call Get_Picture(lblTGRT_Code.Text, CbZoom.Checked)
            Call Get_Picture2(lblTGRT_Code.Text, CbZoom.Checked)
            Call GetPreviewImageToPictureBox()

            btnPrint.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "error")
            C_Error_Log.WriteErrorLog(_ClassName, _FunctionName, ex.Message)

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Call Clear_Default()

    End Sub

    Private Sub Clear_Default()
        pbPreview.Image = Nothing
        lblTGRT_Code.Text = String.Empty
        lblBarcode.Text = String.Empty
        lblCusBarcode.Text = String.Empty

        lblPartName.Text = String.Empty
        lblPartNo.Text = String.Empty
        lblLocation.Text = String.Empty

        PictureBox2.Image = Nothing
        PictureBox3.Image = Nothing
        txtQRcode.Focus()
        txtQRcode.SelectAll()

    End Sub

    Private Sub frmPrintLabel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.InitializePrintEngine("")
        Call getPrinterName()




        Call Clear_Default()

        createTextBoxAutoComplete(txtQRcode)
    End Sub

    Private Sub InitializePrintEngine(ByVal pSDKFilePath As String)

        Try

            If Directory.Exists(pSDKFilePath) Then
                PrintEngineFactory.SDKFilesPath = pSDKFilePath
            End If

            PrintEngineFactory.PrintEngine.Initialize()

        Catch ex As Exception

            'Throw New Exception("Initialization of the NiceLabel SDK failed." & Environment.NewLine & Environment.NewLine & ex.ToString)
            MessageBox.Show("Initialization of the NiceLabel SDK failed." & Environment.NewLine & Environment.NewLine & ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

        End Try

    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Dim _FunctionName As String = "btn_Print"

        Try
            Dim tmpSerial As String = get_sticker_serial()
            If lblTGRT_Code.Text.Trim = String.Empty Then
                MessageBox.Show("Please enter data before print!")
                Call Clear_Default()

                Return

            End If

            'MessageBox.Show("Print  " & txtQtyPrint.Text & "  PCS.")
            Dim strprompt As String = "Print  " & txtQtyPrint.Text & "  PCS."

            If MsgBox(strprompt, MsgBoxStyle.Question + MsgBoxStyle.YesNo) =
                MsgBoxResult.No Then
                Exit Sub


            End If


            Call PrintLabel()
            Keep_Log_Print(tmpSerial, txtQtyPrint.Text, lblTGRT_Code.Text, C_Variable.USER_LOGIN)
            txtQRcode.Focus()
            txtQRcode.SelectAll()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "error")
            C_Error_Log.WriteErrorLog(_ClassName, _FunctionName, ex.Message)

        End Try
    End Sub

    Private Sub Keep_Log_Print(ByVal pRunning As String, ByVal pQtyPrint As String, ByVal pTGRT_CODE As String, ByVal pUser As String)
        Dim StrSQL As New StringBuilder()
        Dim _FunctionName As String = "Keep_Log_Print"

        Try
            StrSQL.Append(" insert into tbl_Sticker_Serial_Log ([f_TGRT_Code]")
            StrSQL.Append(" ,[f_TGRT_Barcode]")
            StrSQL.Append(" ,[f_Customer_Barcode]")
            StrSQL.Append(" ,[f_Part_Name]")
            StrSQL.Append(" ,[f_Part_No]")
            StrSQL.Append(" ,[f_Location]")
            StrSQL.Append(" ,[f_User_Print]")
            StrSQL.Append(" ,[f_Print_TimeStamp]")
            StrSQL.Append(" , [f_Running]")
            StrSQL.Append(" ,[f_Qty_Print])")
            StrSQL.Append(" Select  [f_TGRT_Code]")
            StrSQL.Append(" ,[f_TGRT_Barcode]")
            StrSQL.Append(" ,[f_Customer_Barcode]")
            StrSQL.Append(" ,[f_Part_Name]")
            StrSQL.Append(" ,[f_Part_No]")
            StrSQL.Append(" ,[f_Location]")
            StrSQL.Append(" ,'" & pUser & "' as [f_User_Print]")
            StrSQL.Append(" ,getdate() as [f_Print_TimeStamp]")
            StrSQL.Append(" ,'" & pRunning & "' as [f_Running]")
            StrSQL.Append(" ,'" & pQtyPrint & "' as [f_Qty_Print]")
            StrSQL.Append(" From [tbl_Master_Product]")
            StrSQL.Append(" Where [f_tgrt_Code] ='" & pTGRT_CODE & "'")
            DatabaseConnection.SQLConnect.SQL.Execute(StrSQL.ToString, cs)

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "error")
            C_Error_Log.WriteErrorLog(_ClassName, _FunctionName, ex.Message)

        End Try
    End Sub


    Private Function get_sticker_serial() As String
        Dim _FunctionName As String = "sp_GET_NEW_STICKER_SERIAL"
        Try


            Dim tmp_dt As New DataTable
            Dim query_parameters(2) As SqlParameter
            'msg_str = ""

            'query_parameters(0) = New SqlParameter("@SERIAL_NO", SqlDbType.NVarChar)
            'query_parameters(0).Value = zSERIAL_NO
            'query_parameters(1) = New SqlParameter("@PLANNO", SqlDbType.NVarChar)
            'query_parameters(1).Value = zPLANNO '_Model_Code
            'query_parameters(2) = New SqlParameter("@Operator", SqlDbType.NVarChar)
            'query_parameters(2).Value = zOperator '_Model_Name

            tmp_dt = DatabaseConnection.SQLConnect.SQL.ReadSP("sp_GET_NEW_STICKER_SERIAL", cs, query_parameters)

            If Not tmp_dt Is Nothing Then
                If tmp_dt.Rows.Count > 0 Then

                    Return tmp_dt.Rows(0).Item(0).ToString
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "error")
            C_Error_Log.WriteErrorLog(_ClassName, _FunctionName, ex.Message)

        End Try

    End Function

    Private Sub txt_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQRcode.GotFocus

        Dim objTxt As TextBox = CType(sender, TextBox)
        objTxt.BackColor = Color.MediumSpringGreen

    End Sub

    Private Sub txt_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQRcode.LostFocus

        Dim objTxt As TextBox = CType(sender, TextBox)
        objTxt.BackColor = SystemColors.Window

    End Sub

    Private Sub Get_Picture(ByVal pTGRT As String, ByVal pZoom As Boolean)
        Dim _FunctionName As String = "Get_Picture"
        pTGRT = pTGRT.Replace("\", "_").Replace("/", "_").Replace(":", "_").Replace("*", "_").Replace("?", "_").Replace("""", "_").Replace("<", "_").Replace(">", "_").Replace("|", "_")
        Dim fd As OpenFileDialog = New OpenFileDialog()
        Dim PathImportPIC As String
        Try

            fd.Title = "Select your Image."
            fd.InitialDirectory = "C:\"
            fd.Filter = "All Files|*.*|Bitmaps|*.bmp|JPEGs|*.jpg"
            fd.RestoreDirectory = False

            ' If fd.ShowDialog() = DialogResult.OK Then
            'fd.FileName = "D:\_Work\__Current_DW\Toyoda Gosei_Label printing and Barcode verify Service part system\Picture1\" & pTGRT & ".jpg"
            If pZoom Then
                fd.FileName = My.Settings.PATH_FOLDER_PIC1_ZOOM & pTGRT & ".jpg"

            Else
                fd.FileName = My.Settings.PATH_FOLDER_PIC1 & pTGRT & ".jpg"

            End If

            PathImportPIC = fd.FileName
            'txtPathImportPIC.Text = fd.FileName
            ' PictureBox2.ImageLocation = fd.FileName
            '   Dim img As Image = Image.FromFile(PictureBox2.ImageLocation)
            '   PictureBox2.Image = img
            'PictureBox2.SizeMode = PictureBoxSizeMode.Zoom
            Me.PictureBox2.Image = Image.FromFile(fd.FileName)

            '  End If


        Catch ex As Exception
            PictureBox2.Image = Nothing

            '     C_Error_Log.WriteErrorLog(_ClassName, _FunctionName, ex.Message)

        End Try
    End Sub

    Private Sub Get_Picture2(ByVal pTGRT As String, ByVal pZoom As Boolean)
        Dim _FunctionName As String = "Get_Picture2"
        pTGRT = pTGRT.Replace("\", "_").Replace("/", "_").Replace(":", "_").Replace("*", "_").Replace("?", "_").Replace("""", "_").Replace("<", "_").Replace(">", "_").Replace("|", "_")

        Dim fd As OpenFileDialog = New OpenFileDialog()
        Dim PathImportPIC As String
        Try

            fd.Title = "Select your Image."
            fd.InitialDirectory = "C:\"
            fd.Filter = "All Files|*.*|Bitmaps|*.bmp|JPEGs|*.jpg"
            fd.RestoreDirectory = False

            ' If fd.ShowDialog() = DialogResult.OK Then
            'fd.FileName = "D:\_Work\__Current_DW\Toyoda Gosei_Label printing and Barcode verify Service part system\Picture2\" & pTGRT & ".jpg"
            If pZoom Then
                fd.FileName = My.Settings.PATH_FOLDER_PIC2_ZOOM & pTGRT & ".jpg"

            Else
                fd.FileName = My.Settings.PATH_FOLDER_PIC2 & pTGRT & ".jpg"

            End If

            PathImportPIC = fd.FileName
            'txtPathImportPIC.Text = fd.FileName
            ' PictureBox3.ImageLocation = fd.FileName
            ' Dim img As Image = Image.FromFile(PictureBox3.ImageLocation)
            'PictureBox3.Image = img
            'PictureBox3.SizeMode = PictureBoxSizeMode.Zoom
            Me.PictureBox3.Image = Image.FromFile(fd.FileName)

            '  End If

        Catch ex As Exception
            PictureBox3.Image = Nothing

            '  C_Error_Log.WriteErrorLog(_ClassName, _FunctionName, ex.Message)

        End Try

    End Sub

    Private Sub getPrinterName()
        Dim pkInstalledPrinters As String

        ' Find all printers installed
        For Each pkInstalledPrinters In
            PrinterSettings.InstalledPrinters
            cmbPrinterName.Items.Add(pkInstalledPrinters)
        Next pkInstalledPrinters

        ' Set the combo to the first printer in the list
        ' cmbPrinterName.SelectedIndex = 0

        cmbPrinterName.Text = My.Settings.PrinterName
    End Sub

    Private Sub cmbPrinterName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPrinterName.SelectedIndexChanged
        My.Settings.PrinterName = cmbPrinterName.Text
        My.Settings.Save()
        txtQRcode.Focus()
        txtQRcode.SelectAll()
    End Sub


    Private Sub PrintLabel()

        '  pbPreview.Image = Nothing


        Me._label = PrintEngineFactory.PrintEngine.OpenLabel(C_Variable._label_path_Label)
        'Me._label = PrintEngineFactory.PrintEngine.OpenLabel("D:\_Work\__Current_DW\Toyoda Gosei_Label printing and Barcode verify Service part system\Label\Label.nlbl")
        Me._label.PrintSettings.PrinterName = cmbPrinterName.Text

        ' Me._label.PrintSettings.SetParameter("HorizontalOffset", NumericUpDown1.Value.ToString)
        ' Me._label.PrintSettings.SetParameter("VerticalOffset", NumericUpDown2.Value.ToString)

        '  MessageBox.Show(_label.LabelSettings.PageLayout.HorizontalOffset)
        '  MessageBox.Show(_label.LabelSettings.PageLayout.VerticalOffset)

        Try



            Me._label.Variables("varLocation").SetValue(lblLocation.Text)
            Me._label.Variables("varPart_Name").SetValue(lblPartName.Text)
            Me._label.Variables("varPartNo").SetValue(lblPartNo.Text)
            Me._label.Variables("varPrint_TimeStamp").SetValue(Now.ToString("yyyy-MM-dd"))
            Me._label.Variables("varTGRT_Barcode").SetValue(lblBarcode.Text)
            Me._label.Variables("varTGRT_Code").SetValue(lblTGRT_Code.Text)
            Me._label.Variables("varUser_Print").SetValue(C_Variable.USER_Name)



            '   If CheckBox1.Checked Then
            '    Me._label.Variables("xBorder_Visible").SetValue("1")
            '   Else
            '    Me._label.Variables("xBorder_Visible").SetValue("0")
            '    End If


        Catch ex As Exception
            MessageBox.Show("Failed to set variable " & Environment.NewLine & ex.Message)
        End Try


        Me._label.Print(txtQtyPrint.Text)


    End Sub
    Private Sub GetPreviewImageToPictureBox()

        pbPreview.Image = Nothing
        '  Me._label = PrintEngineFactory.PrintEngine.OpenLabel("Test.nlbl")
        Me._label = PrintEngineFactory.PrintEngine.OpenLabel(C_Variable._label_path_Label)
        Me._label.PrintSettings.PrinterName = cmbPrinterName.Text
        Try
            Me._label.Variables("varLocation").SetValue(lblLocation.Text)
            Me._label.Variables("varPart_Name").SetValue(lblPartName.Text)
            Me._label.Variables("varPartNo").SetValue(lblPartNo.Text)
            Me._label.Variables("varPrint_TimeStamp").SetValue(Now.ToString("yyyy-MM-dd"))
            Me._label.Variables("varTGRT_Barcode").SetValue(lblBarcode.Text)
            Me._label.Variables("varTGRT_Code").SetValue(lblTGRT_Code.Text)
            Me._label.Variables("varUser_Print").SetValue(C_Variable.USER_Name)

        Catch ex As Exception
            MessageBox.Show("Failed to set variable " & Environment.NewLine & ex.Message)
        End Try
        'Set up LabelPreviewSettings to be passed to the GetLabelPreview method.
        Dim labelPreviewSettings As New LabelPreviewSettings()
        labelPreviewSettings.PreviewToFile = False                      ' if true, result will be the file name, if false, result will be a byte array.
        labelPreviewSettings.ImageFormat = "PNG"                        'file format of graphics.  Valid formats: JPG, PNG, BMP.
        labelPreviewSettings.Width = pbPreview.Width             'Width of image to generate
        labelPreviewSettings.Height = pbPreview.Height           'Height of image to generate
        labelPreviewSettings.Destination = ""                           'If PrintToFile is true, this is the name of the file that will be generated.
        labelPreviewSettings.FormatPreviewSide = FormatPreviewSide.FrontSide              'Which label side(s) to generate the image for.  
        'Generate Preview File
        Dim imageObj = Me._label.GetLabelPreview(labelPreviewSettings)
        'Display image in UI
        If TypeOf imageObj Is Byte() Then
            'When PrintToFiles = false
            'Convert byte[] to Bitmap and set as image source for PictureBox control
            pbPreview.Image = Me.ByteToImage(imageObj)
            Application.DoEvents()
        Else

            pbPreview.Image = Nothing
            Application.DoEvents()

        End If

    End Sub


    Private Function ByteToImage(ByVal bytes As Byte()) As Bitmap

        Dim memoryStream As MemoryStream = New MemoryStream()
        memoryStream.Write(bytes, 0, Convert.ToInt32(bytes.Length))
        Dim bm As Bitmap = New Bitmap(memoryStream, False)
        memoryStream.Dispose()
        Return bm

    End Function




    Private Sub txtQtyPrint_EditValueChanged(sender As Object, e As EventArgs) Handles txtQtyPrint.EditValueChanged

    End Sub

    Private Sub txtQtyPrint_KeyDown(sender As Object, e As KeyEventArgs) Handles txtQtyPrint.KeyDown
        If e.KeyCode.Equals(Keys.Enter) Then
            If Trim(txtQRcode.Text) <> String.Empty Then
                btnPrint.Focus()

            End If
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles pbPreview.Click

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        GetPreviewImageToPictureBox()
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox2_EditValueChanged(sender As Object, e As EventArgs) Handles PictureBox2.EditValueChanged

    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        lblTGRT_Code.Text = TextBox1.Text
        Call Get_Picture(lblTGRT_Code.Text, CbZoom.Checked)
        Call Get_Picture2(lblTGRT_Code.Text, CbZoom.Checked)
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CbZoom.CheckedChanged
        Call Get_Picture(lblTGRT_Code.Text, CbZoom.Checked)
        Call Get_Picture2(lblTGRT_Code.Text, CbZoom.Checked)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        PictureBox2.Size = New Size(Me.Width / 2, PictureBox2.Size.Height)

    End Sub

    Private Sub frmPrintLabel_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode.Equals(Keys.PageUp) Or e.KeyCode.Equals(Keys.PageDown) Then
            If CbZoom.Checked Then
                CbZoom.Checked = False
            Else
                CbZoom.Checked = True

            End If
        End If
    End Sub
End Class