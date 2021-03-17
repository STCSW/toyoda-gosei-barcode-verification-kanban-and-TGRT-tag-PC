Imports System.Text
Imports MetroFramework

Public Class frmBarcodeVerification
    Dim _ClassName As String = "frmBarcodeVerification"
    Private Countup_Item As Integer = 0
    Private TGRT_code_Before As String = String.Empty
    Private TGRT_code_Acture As String = String.Empty


    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtScan1.TextChanged

    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtScan1.KeyDown
        If e.KeyCode.Equals(Keys.Enter) Then
            If Trim(txtScan1.Text) <> String.Empty Then
                Call Scan_QR1()
            Else
                '  flag_check_QR = False
                txtScan1.Focus()
            End If
        End If
    End Sub
    Private Sub txtScan2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtScan2.KeyDown
        If e.KeyCode.Equals(Keys.Enter) Then
            If Trim(txtScan2.Text) <> String.Empty Then
                Call Scan_QR2()
            Else
                '  flag_check_QR = False
                txtScan2.Focus()
            End If
        End If
    End Sub

    Private Sub Scan_QR1()

        Dim _FunctionName As String = "Scan_QR1"
        Try
            Dim Dummy_qr As String = txtScan1.Text.Trim
            Dim arr_QR() As String
            Dim tmp_Qr As String
            Dim StrSQL As New StringBuilder()


            'tmp_Qr = txtQRcode.Text.Trim
            PictureBox3.Image = Nothing


            tmp_Qr = Dummy_qr
            tmp_Qr = tmp_Qr.ToUpper
            txtScan1.Text = String.Empty

            Dim tmp_tb As New DataTable

            StrSQL.Append("SELECT * From [View_ALL_PRODUCT_MAS]")
            StrSQL.Append(" WHERE [TGRT Barcode]='" & tmp_Qr & "'")

            tmp_tb = DatabaseConnection.SQLConnect.SQL.Read(StrSQL.ToString, cs)

            If tmp_tb Is Nothing Then
                Dim strMessage As String = "'" & tmp_Qr & "' not found in master product!!"
                MetroMessageBox.Show(Me, strMessage, "Error data", MessageBoxButtons.OK, MessageBoxIcon.Error)
                lblStatusOK.Visible = False
                lblStatusNG.Visible = False
                lblStatusWait.Visible = False
                Countup_Item = 0
                lblCountUp.Text = Countup_Item
                Panel3.BackColor = Color.White

                Call Clear_Default()
                TGRT_code_Before = String.Empty

                PictureBox3.Image = Nothing

                My.Computer.Audio.Play(My.Resources.SoundError, AudioPlayMode.Background)


                Application.DoEvents()


                ' Mdl_Core.LockScreen(Me.Width, "red", strMessage)

                Return

            End If

            If tmp_tb.Rows.Count <= 0 Then
                Dim strMessage As String = "'" & tmp_Qr & "' not found in master product!!"
                MetroMessageBox.Show(Me, strMessage, "Error data", MessageBoxButtons.OK, MessageBoxIcon.Error)
                '   Exit Sub
                lblStatusOK.Visible = False
                lblStatusNG.Visible = False
                lblStatusWait.Visible = False
                Countup_Item = 0
                lblCountUp.Text = Countup_Item

                Panel3.BackColor = Color.White

                Call Clear_Default()
                TGRT_code_Before = String.Empty
                PictureBox3.Image = Nothing
                My.Computer.Audio.Play(My.Resources.SoundError, AudioPlayMode.Background)

                Application.DoEvents()

                '   Mdl_Core.LockScreen(Me.Width, "red", strMessage)

                Return
            End If

            Call Clear_Default()
            lblStatusOK.Visible = False
            lblStatusNG.Visible = False
            lblStatusWait.Visible = True
            Panel3.BackColor = Color.Orange


            lblScan1.Text = Dummy_qr
            lblTGRT_Code.Text = tmp_tb.Rows(0).Item(0).ToString
            lblBarcode.Text = tmp_tb.Rows(0).Item(1).ToString

            If tmp_tb.Rows(0).Item(2).ToString.Length > CInt(tmp_tb.Rows(0).Item("Cut Digit Length").ToString) Then
                lblCusBarcode.Text = tmp_tb.Rows(0).Item(2).ToString.Substring(0, tmp_tb.Rows(0).Item("Cut Digit Length").ToString)
            Else
                lblCusBarcode.Text = tmp_tb.Rows(0).Item(2).ToString
            End If

            lblPartName.Text = tmp_tb.Rows(0).Item(3).ToString
            lblPartNo.Text = tmp_tb.Rows(0).Item(4).ToString
            lblLocation.Text = tmp_tb.Rows(0).Item(5).ToString

            TGRT_code_Acture = lblTGRT_Code.Text


            txtScan2.MaxLength = tmp_tb.Rows(0).Item("Cut Digit Length").ToString


            If TGRT_code_Acture = TGRT_code_Before Then
                Countup_Item = Countup_Item
                lblCountUp.Text = Countup_Item

            Else
                Countup_Item = 0
                lblCountUp.Text = Countup_Item
                '   Call Get_Picture(lblTGRT_Code.Text, CbZoom.Checked)

            End If


            txtScan2.Focus()
            txtScan2.SelectAll()
        Catch ex As Exception

            MessageBox.Show(ex.ToString, "error")

            C_Error_Log.WriteErrorLog(_ClassName, _FunctionName, ex.Message)

        End Try
    End Sub

    Private Sub Scan_QR2()

        Dim _FunctionName As String = "Scan_QR2"
        Try
            Dim Dummy_qr As String = txtScan2.Text.Trim
            Dim arr_QR() As String
            Dim tmp_Qr As String
            Dim StrSQL As New StringBuilder()


            'tmp_Qr = txtQRcode.Text.Trim
            tmp_Qr = Dummy_qr
            tmp_Qr = tmp_Qr.ToUpper

            txtScan2.Text = String.Empty




            lblScan2.Text = Dummy_qr
            If lblCusBarcode.Text.ToLower.Trim <> lblScan2.Text.ToLower.Trim Then

                Dim strMessage As String = "Barcode scan ('" & Dummy_qr & "') not match with ('" & lblCusBarcode.Text & "')"
                ' MetroMessageBox.Show(Me, strMessage, "Error data", MessageBoxButtons.OK, MessageBoxIcon.Error)
                '  Call Clear_Default()
                Keep_Log_Scan("NG")
                lblStatusOK.Visible = False
                lblStatusNG.Visible = True
                lblStatusWait.Visible = False
                Countup_Item = 0
                Panel3.BackColor = Color.Red

                ' TGRT_code_Before = String.Empty
                My.Computer.Audio.Play(My.Resources.SoundError, AudioPlayMode.Background)

                Application.DoEvents()
                Mdl_Core.LockScreen(Me.Width, "red", strMessage)

                txtScan1.Focus()
                txtScan1.SelectAll()

                Return

            Else
                Keep_Log_Scan("OK")
                lblStatusOK.Visible = True
                lblStatusNG.Visible = False
                lblStatusWait.Visible = False
                TGRT_code_Before = lblTGRT_Code.Text
                Countup_Item = CInt(Countup_Item) + 1
                lblCountUp.Text = Countup_Item
                Panel3.BackColor = Color.MediumSpringGreen

                Call Get_Picture(lblTGRT_Code.Text, CbZoom.Checked)
                txtScan1.Focus()
                txtScan1.SelectAll()


            End If



        Catch ex As Exception

            MessageBox.Show(ex.ToString, "error")

            C_Error_Log.WriteErrorLog(_ClassName, _FunctionName, ex.Message)

        End Try


    End Sub

    Private Sub Clear_Default()
        lblScan1.Text = String.Empty
        lblScan2.Text = String.Empty

        lblTGRT_Code.Text = String.Empty
        lblBarcode.Text = String.Empty
        lblCusBarcode.Text = String.Empty
        lblPartName.Text = String.Empty
        lblPartNo.Text = String.Empty
        lblLocation.Text = String.Empty
        ' PictureBox3.Image = Nothing
    End Sub

    Private Sub Keep_Log_Scan(ByVal pStatus As String)
        Dim _FunctionName As String = "Keep_Log_Scan"

        Dim StrSQL As New StringBuilder()
        Try
            StrSQL.Append(" INSERT INTO [dbo].[tbl_Transaction]")
            StrSQL.Append(" ([f_TGRT_Code]")
            StrSQL.Append(" ,[f_TGRT_Barcode]")
            StrSQL.Append(" ,[f_Customer_Barcode]")
            StrSQL.Append(" ,[f_Part_Name]")
            StrSQL.Append(" ,[f_Part_No]")
            StrSQL.Append(" ,[f_Location]")
            StrSQL.Append(" ,[f_User_Scan]")
            StrSQL.Append(" ,[f_Scan_TimeStamp]")
            StrSQL.Append(", [f_Transaction_Status])")
            StrSQL.Append(" VALUES ")
            StrSQL.Append("( ")

            StrSQL.Append(" N'" & lblTGRT_Code.Text & "'")
            StrSQL.Append(" ,N'" & lblScan1.Text & "'")
            StrSQL.Append(" ,N'" & lblScan2.Text & "'")
            StrSQL.Append(" ,N'" & lblPartName.Text & "'")
            StrSQL.Append(" ,N'" & lblPartNo.Text & "'")
            StrSQL.Append(" ,N'" & lblLocation.Text & "'")
            StrSQL.Append(" ,N'" & C_Variable.USER_LOGIN & "'")
            StrSQL.Append(" ,getdate()")
            StrSQL.Append(" ,N'" & pStatus & "'")
            StrSQL.Append(") ")
            DatabaseConnection.SQLConnect.SQL.Execute(StrSQL.ToString, cs)

        Catch ex As Exception

            MessageBox.Show(ex.ToString, "error")

            C_Error_Log.WriteErrorLog(_ClassName, _FunctionName, ex.Message)

        End Try

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        '  Keep_Log_Scan("NG")
        Call Clear_Default()
        PictureBox3.Image = Nothing
        Countup_Item = 0
        lblCountUp.Text = Countup_Item
        lblStatusOK.Visible = False
        lblStatusNG.Visible = False
        lblStatusWait.Visible = False
        Panel3.BackColor = Color.White
        txtScan1.Focus()
        txtScan1.SelectAll()
        'Call Clear_Default()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Keep_Log_Scan("OK")
        lblStatusOK.Visible = True
        lblStatusNG.Visible = False
        lblStatusWait.Visible = False
        Panel3.BackColor = Color.MediumSpringGreen
    End Sub

    Private Sub txt_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtScan1.GotFocus, txtScan2.GotFocus

        Dim objTxt As TextBox = CType(sender, TextBox)
        objTxt.BackColor = Color.MediumSpringGreen

    End Sub

    Private Sub txt_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtScan1.LostFocus, txtScan2.LostFocus

        Dim objTxt As TextBox = CType(sender, TextBox)
        objTxt.BackColor = SystemColors.Window

    End Sub

    Private Sub frmBarcodeVerification_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblCountUp.Text = Countup_Item
        txtScan2.MaxLength = My.Settings.Count_CutDigit

    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Call Get_Picture(lblTGRT_Code.Text, CbZoom.Checked)
        '    Call Get_Picture2(TextBox1.Text, CbZoom.Checked)
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CbZoom.CheckedChanged
        Call Get_Picture(lblTGRT_Code.Text, CbZoom.Checked)
        '  Call Get_Picture2(TextBox1.Text, CbZoom.Checked)
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
            '  PictureBox3.ImageLocation = fd.FileName
            'Dim img As Image = Image.FromFile(PictureBox3.ImageLocation)
            ' PictureBox3.Image = img
            ' PictureBox3.SizeMode = PictureBoxSizeMode.Zoom


            Me.PictureBox3.Image = Image.FromFile(fd.FileName)

            '  End If


        Catch ex As Exception
            PictureBox3.Image = Nothing

            '    C_Error_Log.WriteErrorLog(_ClassName, _FunctionName, ex.Message)

        End Try
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtScan2_TextChanged(sender As Object, e As EventArgs) Handles txtScan2.TextChanged

    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click

    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click

    End Sub

    Private Sub frmBarcodeVerification_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode.Equals(Keys.PageUp) Or e.KeyCode.Equals(Keys.PageDown) Then
            If CbZoom.Checked Then
                CbZoom.Checked = False
            Else
                CbZoom.Checked = True

            End If
        End If
    End Sub
End Class