
Imports System.Data.SqlClient
Imports System.Text
Imports System.IO
Public Class frmMaster_Product_EDIT
    Public data(8) As String
    Public CheckCreate As Boolean = True
    Private PathImportPIC As String
    Sub New()

        InitializeComponent()


    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If CheckCreate = True Then
            InsertData()

        Else
            UpdateData()
        End If
    End Sub


    Private Sub Start_form()
        Threading.Thread.Sleep(200)
        If Not CheckCreate = True Then
            readyToUpdate(data)
            Enable_txt(True)
            '   get_picture()
            txtTGRT_Code.Focus()
        Else
            Enable_txt(True)
            txtTGRT_Code.Focus()
        End If
    End Sub

    Private Sub frmADD_Master_Edit_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call Start_form()

    End Sub


    Private Sub txt_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTGRT_Code.GotFocus,
        txtTGRT_Barcode.GotFocus, txtLocation.GotFocus, txtPartNo.GotFocus, txtCustomer_Barcode.GotFocus, txtPartname.GotFocus

        Dim objTxt As TextBox = CType(sender, TextBox)
        objTxt.BackColor = Color.MediumSpringGreen

    End Sub

    Private Sub txt_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTGRT_Code.LostFocus,
      txtTGRT_Barcode.LostFocus, txtLocation.LostFocus, txtPartNo.LostFocus, txtCustomer_Barcode.LostFocus, txtPartname.LostFocus

        Dim objTxt As TextBox = CType(sender, TextBox)
        objTxt.BackColor = SystemColors.Window

    End Sub

    Private Sub readyToUpdate(ByVal str() As String)

        txtTGRT_Code.Text = str(0)
        txtTGRT_Barcode.Text = str(1)
        txtCustomer_Barcode.Text = str(2)
        txtPartname.Text = str(3)
        txtPartNo.Text = str(4)
        txtLocation.Text = str(5)
        txtCutDigit.Text = str(6)






    End Sub

    Sub Reset()

        txtTGRT_Code.Text = String.Empty
        txtTGRT_Barcode.Text = String.Empty
        txtCustomer_Barcode.Text = String.Empty
        txtPartname.Text = String.Empty
        txtPartNo.Text = String.Empty
        txtLocation.Text = String.Empty
        txtCutDigit.Text = String.Empty

        'PART_PIC.Image = Nothing
        CheckCreate = True
    End Sub

    Private Function Enable_txt(ByVal pOpen As Boolean)

        If pOpen Then
            If Not CheckCreate = True Then
                txtTGRT_Code.Enabled = False
                txtTGRT_Barcode.Focus()
            Else

                txtTGRT_Code.Enabled = True
                txtTGRT_Code.Focus()
            End If
            txtTGRT_Barcode.Enabled = True
            txtPartNo.Enabled = True
            txtLocation.Enabled = True
            txtCustomer_Barcode.Enabled = True
            txtPartname.Enabled = True
            txtCutDigit.Enabled = True



        Else
            txtTGRT_Code.Enabled = False
            txtTGRT_Barcode.Enabled = False


            txtPartNo.Enabled = False
            txtLocation.Enabled = False
            txtCustomer_Barcode.Enabled = False

            txtPartname.Enabled = False
            txtCutDigit.Enabled = False





        End If


    End Function




    Private Sub InsertData()
        Dim dt As New DataTable


        Try
            Dim StrSQL As New StringBuilder()


            StrSQL.Append("select  [f_TGRT_Code]")

            StrSQL.Append(" from [tbl_Master_Product]")
            StrSQL.Append(" WHERE [f_TGRT_Code]='" & txtTGRT_Code.Text & "'")
            dt = SQLConnect._SQL.Read(StrSQL.ToString)
            If Not dt Is Nothing Then
                If dt.Rows.Count > 0 Then
                    MessageBox.Show("TGRT Code Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                    txtTGRT_Code.Text = ""
                    txtTGRT_Code.Focus()
                    Exit Sub
                End If
            End If

            StrSQL.Remove(0, StrSQL.Length)
            StrSQL.Append("insert into [tbl_Master_PRODUCT]([f_TGRT_Code]" &
                      " ,[f_TGRT_Barcode]" &
                     " ,[f_Customer_Barcode]" &
                      " ,[f_Part_Name]" &
                       " ,[f_Part_No]" &
                      " ,[f_Location]" &
                      ",[f_Cut_Digit_Length]" &
                      " ,[f_User_Edit]" &
                     " ,[f_Edit_TimeStamp]" &
                     " )")
            StrSQL.Append(" VALUES('" & txtTGRT_Code.Text & "'" &
                      ",'" & txtTGRT_Barcode.Text & "'" &
                     " ,'" & txtCustomer_Barcode.Text & "'" &
                      " ,'" & txtPartname.Text & "'" &
                        " ,'" & txtPartNo.Text & "'" &
                      " ,'" & txtLocation.Text & "'" &
                      " ,'" & txtCutDigit.Text & "'" &
                         " ,'" & C_Variable.USER_LOGIN & "'" &
                     " ,getdate())")
            SQLConnect._SQL.Execute(StrSQL.ToString)


            'StrSQL.Remove(0, StrSQL.Length)
            'If PathImportPIC <> String.Empty And Not PART_PIC.Image Is Nothing Then
            '    StrSQL.Append("INSERT INTO [dbo].[Tbl_Carrier_Join]([Photo1]) VALUES (@img)")
            'Else
            '    StrSQL.Append("INSERT INTO [dbo].[Tbl_Carrier_Join]([Photo1]) VALUES (null)")
            'End If


            'con = New SqlConnection(cs)
            'con.Open()
            'cmd = New SqlCommand(StrSQL.ToString)
            'cmd.Connection = con

            'If PathImportPIC <> String.Empty And Not PART_PIC.Image Is Nothing Then

            '    Dim fsImage As Byte()
            '    Dim b() As Byte
            '    Dim mem As New IO.MemoryStream
            '    PART_PIC.Image.Save(mem, Imaging.ImageFormat.Jpeg)
            '    b = mem.GetBuffer

            '    fsImage = b
            '    '  img.Value = fsImage
            '    'cmd.Parameters.AddWithValue("@Img", fsImage)

            '    Dim Imgs As New SqlParameter("@Img", SqlDbType.Image)
            '    Imgs.Value = fsImage
            '    cmd.Parameters.Add(Imgs)

            'End If


            'cmd.ExecuteReader()
            'con.Close()




            MessageBox.Show("Successfully Registered", "Machine code", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Reset()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try

    End Sub

    Private Sub UpdateData()
        Try

            Dim StrSQL As New StringBuilder()


            StrSQL.Append("update [tbl_Master_PRODUCT] set [f_TGRT_Code]=N'" & txtTGRT_Code.Text & "'" &
                     " ,[f_TGRT_Barcode]=N'" & txtTGRT_Barcode.Text & "'" &
                    " ,[f_Customer_Barcode]=N'" & txtCustomer_Barcode.Text & "'" &
                     " ,[f_Part_No]=N'" & txtPartNo.Text & "'" &
                    " ,[f_Location]=N'" & txtLocation.Text & "'" &
                      ",f_Cut_Digit_Length=N'" & txtCutDigit.Text & "'" &
                      " ,[f_User_Edit]=N'" & C_Variable.USER_LOGIN & "'" &
                     " ,[f_Edit_TimeStamp]=getdate()")

            StrSQL.Append(" Where [f_TGRT_Code]='" & txtTGRT_Code.Text & "'")

            SQLConnect._SQL.Execute(StrSQL.ToString)

            'StrSQL.Remove(0, StrSQL.Length)
            'If PathImportPIC <> String.Empty And Not PART_PIC.Image Is Nothing Then
            '    StrSQL.Append("update [dbo].[Tbl_Carrier_Join] set [Photo1]=@img ")
            '    StrSQL.Append(" Where [ID]='" & txtPhotoID.Text & "'")
            'End If


            'con = New SqlConnection(cs)
            'con.Open()
            'cmd = New SqlCommand(StrSQL.ToString)
            'cmd.Connection = con

            'If PathImportPIC <> String.Empty And Not PART_PIC.Image Is Nothing Then

            '    Dim fsImage As Byte()
            '    Dim b() As Byte
            '    Dim mem As New IO.MemoryStream
            '    PART_PIC.Image.Save(mem, Imaging.ImageFormat.Jpeg)
            '    b = mem.GetBuffer

            '    fsImage = b
            '    '  img.Value = fsImage
            '    'cmd.Parameters.AddWithValue("@Img", fsImage)

            '    Dim Imgs As New SqlParameter("@Img", SqlDbType.Image)
            '    Imgs.Value = fsImage
            '    cmd.Parameters.Add(Imgs)
            '    cmd.ExecuteReader()
            '    con.Close()
            'End If






            Reset()
            MessageBox.Show("Successfully updated", "PRODUCT Info", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Call Enable_txt(False)
            btnSave.Enabled = False

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try

    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click

        Call Enable_txt(True)

        btnSave.Enabled = True
        Me.Close()
    End Sub

    Private Sub btnAddPic_Click(sender As Object, e As EventArgs)

        Dim fd As OpenFileDialog = New OpenFileDialog()
        fd.Title = "Select your Image."
        fd.InitialDirectory = "C:\"
        fd.Filter = "All Files|*.*|Bitmaps|*.bmp|JPEGs|*.jpg"
        fd.RestoreDirectory = False

        If fd.ShowDialog() = DialogResult.OK Then
            PathImportPIC = fd.FileName
            'txtPathImportPIC.Text = fd.FileName
            '  PART_PIC.ImageLocation = fd.FileName
            '   Dim img As Image = Image.FromFile(PART_PIC.ImageLocation)
            '   PART_PIC.Image = img
            '   PART_PIC.SizeMode = PictureBoxSizeMode.Zoom

        End If
    End Sub

    Private Sub get_picture()
        Dim con As New SqlConnection(cs)
        Dim cb As String
        cb = "select [Photo ID],[Photo1] from [View_All_Carrier] where [Carrier Part No] ='" & txtTGRT_Code.Text & "'"



        Dim dt2 As DataTable = SQLConnect._SQL.Read(cb)
        If dt2 IsNot Nothing Then

            txtCustomer_Barcode.Text = dt2.Rows(0).Item("Photo ID").ToString.Trim()

            If dt2.Rows(0).Item("Photo1").ToString.Trim <> "" Then
                Dim imgData As Byte() = CType(dt2.Rows(0).Item("Photo1"), Byte())
                Dim ms As New MemoryStream(imgData)
                Dim img As Image = Image.FromStream(ms)
                'PART_PIC.Image = img
                ' PART_PIC.SizeMode = PictureBoxSizeMode.Zoom

            End If

        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub
End Class