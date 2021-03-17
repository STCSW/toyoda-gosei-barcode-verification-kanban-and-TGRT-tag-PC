
Imports System.Data.SqlClient
Imports System.Text
Imports System.IO
Public Class frmMaster_MC_EDIT
    Public data(6) As String
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
            txtMC_CODE.Focus()
        Else
            Enable_txt(True)
            txtMC_CODE.Focus()
        End If
    End Sub

    Private Sub frmADD_Master_Edit_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call Start_form()

    End Sub


    Private Sub txt_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMC_CODE.GotFocus, _
        txtMC_MODEL.GotFocus, txtMC_UNIT.GotFocus, txtMC_NAME.GotFocus, txtMC_line.GotFocus, txtMC_Remark.GotFocus, txtMC_type.GotFocus

        Dim objTxt As TextBox = CType(sender, TextBox)
        objTxt.BackColor = Color.MediumSpringGreen

    End Sub

    Private Sub txt_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMC_CODE.LostFocus, _
      txtMC_MODEL.LostFocus, txtMC_UNIT.LostFocus, txtMC_NAME.LostFocus, txtMC_line.LostFocus, txtMC_Remark.LostFocus, txtMC_type.LostFocus

        Dim objTxt As TextBox = CType(sender, TextBox)
        objTxt.BackColor = SystemColors.Window

    End Sub

    Private Sub readyToUpdate(ByVal str() As String)

        txtMC_CODE.Text = str(0)
        txtMC_NAME.Text = str(1)
        txtMC_MODEL.Text = str(2)
        txtMC_UNIT.Text = str(3)
        txtMC_type.Text = str(4)
        txtMC_line.Text = str(5)
        txtMC_Remark.Text = str(6)

      
    End Sub

    Sub Reset()
        txtMC_CODE.Text = String.Empty
        txtMC_MODEL.Text = String.Empty
        txtMC_NAME.Text = String.Empty
        txtMC_UNIT.Text = String.Empty
        txtMC_type.Text = String.Empty
        txtMC_line.Text = String.Empty
        txtMC_Remark.Text = String.Empty

        PART_PIC.Image = Nothing
        CheckCreate = True
    End Sub

    Private Function Enable_txt(ByVal pOpen As Boolean)

        If pOpen Then
            If Not CheckCreate = True Then
                txtMC_CODE.Enabled = False
                txtMC_MODEL.Focus()
            Else

                txtMC_CODE.Enabled = True
                txtMC_CODE.Focus()
            End If
            txtMC_MODEL.Enabled = True
            txtMC_NAME.Enabled = True
            txtMC_UNIT.Enabled = True
            txtMC_type.Enabled = True
            txtMC_line.Enabled = True
            txtMC_Remark.Enabled = True

        Else
            txtMC_CODE.Enabled = False
            txtMC_MODEL.Enabled = False


            txtMC_NAME.Enabled = False
            txtMC_UNIT.Enabled = False
            txtMC_type.Enabled = False
            txtMC_line.Enabled = False
            txtMC_Remark.Enabled = False




        End If


    End Function




    Private Sub InsertData()
        Dim dt As New DataTable


        Try
            Dim StrSQL As New StringBuilder()


            StrSQL.Append("select  [f_MC_Code]" & _
                 " ,[f_MC_Name]" & _
                 " ,[f_MC_Model]" & _
                 " ,[f_MC_Unit]" & _
                 " ,[f_MC_type]" & _
                 " ,[f_MC_Line]" & _
                 " ,[f_Remark]")
            StrSQL.Append(" from [tbl_Master_MC]")
            StrSQL.Append(" WHERE [f_MC_Code]='" & txtMC_CODE.Text & "'")
            dt = SQLConnect._SQL.Read(StrSQL.ToString)
            If Not dt Is Nothing Then
                If dt.Rows.Count > 0 Then
                    MessageBox.Show("Machine Code Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                    txtMC_CODE.Text = ""
                    txtMC_CODE.Focus()
                    Exit Sub
                End If
            End If

            StrSQL.Remove(0, StrSQL.Length)
            StrSQL.Append("insert into [tbl_Master_MC]([f_MC_Code]" & _
                      " ,[f_MC_Name]" & _
                     " ,[f_MC_Model]" & _
                      " ,[f_MC_Unit]" & _
                       " ,[f_MC_type]" & _
                      " ,[f_MC_Line]" & _
                     " ,[f_Remark])")
            StrSQL.Append(" VALUES('" & txtMC_CODE.Text & "'" & _
                      ",'" & txtMC_NAME.Text & "'" & _
                     " ,'" & txtMC_MODEL.Text & "'" & _
                      " ,'" & txtMC_UNIT.Text & "'" & _
                        " ,'" & txtMC_type.Text & "'" & _
                      " ,'" & txtMC_line.Text & "'" & _
                     " ,'" & txtMC_Remark.Text & "'" & ")")
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
      

            StrSQL.Append("update [tbl_Master_MC] set [f_MC_Code]='" & txtMC_CODE.Text & "'" & _
                     " ,[f_MC_Name]='" & txtMC_NAME.Text & "'" & _
                    " ,[f_MC_Model]='" & txtMC_MODEL.Text & "'" & _
                     " ,[f_MC_Unit]='" & txtMC_UNIT.Text & "'" & _
                    " ,[f_MC_type]='" & txtMC_type.Text & "'" & _
                      " ,[f_MC_Line]='" & txtMC_line.Text & "'" & _
                     " ,[f_Remark]='" & txtMC_Remark.Text & "'")

            StrSQL.Append(" Where [f_MC_Code]='" & txtMC_CODE.Text & "'")
           
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
            MessageBox.Show("Successfully updated", "MACHINE Info", MessageBoxButtons.OK, MessageBoxIcon.Information)

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

    Private Sub btnAddPic_Click(sender As Object, e As EventArgs) Handles btnAddPic.Click

        Dim fd As OpenFileDialog = New OpenFileDialog()
        fd.Title = "Select your Image."
        fd.InitialDirectory = "C:\"
        fd.Filter = "All Files|*.*|Bitmaps|*.bmp|JPEGs|*.jpg"
        fd.RestoreDirectory = False

        If fd.ShowDialog() = DialogResult.OK Then
            PathImportPIC = fd.FileName
            'txtPathImportPIC.Text = fd.FileName
            PART_PIC.ImageLocation = fd.FileName
            Dim img As Image = Image.FromFile(PART_PIC.ImageLocation)
            PART_PIC.Image = img
            PART_PIC.SizeMode = PictureBoxSizeMode.Zoom

        End If
    End Sub

    Private Sub get_picture()
        Dim con As New SqlConnection(cs)
        Dim cb As String
        cb = "select [Photo ID],[Photo1] from [View_All_Carrier] where [Carrier Part No] ='" & txtMC_CODE.Text & "'"



        Dim dt2 As DataTable = SQLConnect._SQL.Read(cb)
        If dt2 IsNot Nothing Then

            txtMC_type.Text = dt2.Rows(0).Item("Photo ID").ToString.Trim()

            If dt2.Rows(0).Item("Photo1").ToString.Trim <> "" Then
                Dim imgData As Byte() = CType(dt2.Rows(0).Item("Photo1"), Byte())
                Dim ms As New MemoryStream(imgData)
                Dim img As Image = Image.FromStream(ms)
                PART_PIC.Image = img
                PART_PIC.SizeMode = PictureBoxSizeMode.Zoom

            End If

        End If
    End Sub
End Class