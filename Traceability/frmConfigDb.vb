Imports System.Data.SqlClient
Imports System.Text

Public Class frmConfigDb

    Private Sub frmConfigDb_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtPass.UseSystemPasswordChar = True

        txtServerName.Text = My.Settings.Server
        txtDatabaseName.Text = My.Settings.Database
        txtUserId.Text = My.Settings.Username_DB
        txtPass.Text = My.Settings.Password_DB
        ' C_PRINTER_SETTING.getPrinterList(cmbPrinter, "")
        ' cmbPrinter.Text = My.Settings.PrinterName
        txtTimeout.Text = My.Settings.Timeout

        txtPicture_folder1.Text = My.Settings.PATH_FOLDER_PIC1
        txtPicture_folder1_zoom.Text = My.Settings.PATH_FOLDER_PIC1_ZOOM

        txtPicture_folder2.Text = My.Settings.PATH_FOLDER_PIC2
        txtPicture_folder2_zoom.Text = My.Settings.PATH_FOLDER_PIC2_ZOOM

        txtCutdigit.Text = My.Settings.Count_CutDigit

        txtPahtFile.Text = My.Settings.dbAccessPaht

    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Call SaveSitting()
    End Sub

    Private Sub SaveSitting()
        My.Settings.Server = txtServerName.Text
        My.Settings.Database = txtDatabaseName.Text
        My.Settings.Username_DB = txtUserId.Text
        My.Settings.Password_DB = txtPass.Text
        My.Settings.Timeout = txtTimeout.Text
        My.Settings.dbAccessPaht = txtPahtFile.Text.Trim()
        My.Settings.Save()
        Call UpdateConfig_Ini()
        MessageBox.Show("Save setting success. ", "Success.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)

        'cs = "Server = " & My.Settings.Server & ";Database = " & My.Settings.Database & ";User Id = " & My.Settings.Username_DB & ";Password = " & My.Settings.Password_DB & ";" & "Connection Timeout=" & My.Settings.Timeout & ";"
        css = "Provider=Microsoft.ACE.Oledb.12.0; Data Source=" + My.Settings.dbAccessPaht + ";"


    End Sub

    Private Sub BtnConnTest_Click(sender As Object, e As EventArgs) Handles BtnConnTest.Click
        If TEST_CONNECTION() Then


            MessageBox.Show("Connect to server success. ", "Success.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)


        End If
    End Sub


    Public Function TEST_CONNECTION() As Boolean


        'Cursor.Current = Cursors.WaitCursor
        'Dim pcConnector As New SqlConnection()
        'Dim cs_TEST As String = String.Empty


        'cs_TEST = "Server = " & txtServerName.Text.Trim & ";"
        'cs_TEST &= "Database  = " & txtDatabaseName.Text.Trim & ";"
        'cs_TEST &= "User Id = " & txtUserId.Text.Trim & ";"
        'cs_TEST &= "Password = " & txtPass.Text.Trim & ";"



        'Try

        '    pcConnector.ConnectionString = cs_TEST
        '    pcConnector.Open()
        '    If pcConnector.State = ConnectionState.Open Then
        '        pcConnector.Close()
        '    End If

        '    Cursor.Current = Cursors.Default
        '    Return True

        'Catch sqlExp As SqlException
        '    Cursor.Current = Cursors.Default
        '    Dim errorMsg As String = "The connection fail to database " & txtServerName.Text & " [" & sqlExp.Message & " ]"
        '    '  C_ERROR_LOG.KEEP_LOG(errorMsg)

        '    '  MessageBox.Show(errorMsg, "Connection fail.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

        '    'MsgBox(errorMsg, "Connection fail.", MessageBoxButtons.OK)

        '    MessageBox.Show(errorMsg, "Connection fail.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

        '    Return False

        'Catch InvalidEx As InvalidExpressionException
        '    Cursor.Current = Cursors.Default
        '    Dim errorMsg As String = "The connection fail to database " & txtServerName.Text & " [" & InvalidEx.Message & " ]"
        '    '  C_ERROR_LOG.KEEP_LOG(errorMsg)
        '    '  MessageBox.Show(errorMsg, "Connection fail.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)


        '    ' MsgBox(errorMsg, "Connection fail.", MessageBoxButtons.OK)
        '    MessageBox.Show(errorMsg, "Connection fail.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

        '    Return False

        'End Try

    End Function
    'Public Function TEST_CONNECTION2() As Boolean
    '    Cursor.Current = Cursors.WaitCursor
    '    Dim pcConnector As New SqlConnection()
    '    Dim cs_TEST As String = String.Empty


    '    cs_TEST = "Server = " & txtPicture_folder1.Text.Trim & ";"
    '    cs_TEST &= "Database  = " & txtPicture_folder2.Text.Trim & ";"
    '    cs_TEST &= "User Id = " & txtUserId_MRP.Text.Trim & ";"
    '    cs_TEST &= "Password = " & txtPass_MRP.Text.Trim & ";"



    '    Try

    '        pcConnector.ConnectionString = cs_TEST
    '        pcConnector.Open()
    '        If pcConnector.State = ConnectionState.Open Then
    '            pcConnector.Close()
    '        End If

    '        Cursor.Current = Cursors.Default
    '        Return True

    '    Catch sqlExp As SqlException
    '        Cursor.Current = Cursors.Default
    '        Dim errorMsg As String = "The connection fail to database " & txtServerName.Text & " [" & sqlExp.Message & " ]"
    '        '  C_ERROR_LOG.KEEP_LOG(errorMsg)

    '        '  MessageBox.Show(errorMsg, "Connection fail.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

    '        'MsgBox(errorMsg, "Connection fail.", MessageBoxButtons.OK)

    '        MessageBox.Show(errorMsg, "Connection fail.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

    '        Return False

    '    Catch InvalidEx As InvalidExpressionException
    '        Cursor.Current = Cursors.Default
    '        Dim errorMsg As String = "The connection fail to database " & txtServerName.Text & " [" & InvalidEx.Message & " ]"
    '        '  C_ERROR_LOG.KEEP_LOG(errorMsg)
    '        '  MessageBox.Show(errorMsg, "Connection fail.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)


    '        ' MsgBox(errorMsg, "Connection fail.", MessageBoxButtons.OK)
    '        MessageBox.Show(errorMsg, "Connection fail.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

    '        Return False

    '    End Try

    'End Function
    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Sub ChkShowPassword_CheckedChanged(sender As Object, e As EventArgs) Handles ChkShowPassword.CheckedChanged
        txtPass.UseSystemPasswordChar = IIf(ChkShowPassword.CheckState = CheckState.Checked, False, True)

    End Sub
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs)
        ' txtPass_MRP.UseSystemPasswordChar = IIf(CheckBox1.CheckState = CheckState.Checked, False, True)
    End Sub
    Private Sub txtDis_Front_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtDis_Front_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub





    Private Sub Button3_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub


    Private Sub btnRefreshQAD_Click(sender As Object, e As EventArgs)

        If Not TEST_CONNECTION() Then
            Exit Sub
        End If



    End Sub







    Private Sub Button5_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs)
        'Dim sb_query As New StringBuilder


        'sb_query.Append(TextBox1.Text)

        'DatabaseConnection.SQLConnect.SQL.Execute(sb_query.ToString, cs, True)

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Call SaveSitting_MRP()
    End Sub

    Private Sub SaveSitting_MRP()
        My.Settings.PATH_FOLDER_PIC1 = txtPicture_folder1.Text
        My.Settings.PATH_FOLDER_PIC2 = txtPicture_folder2.Text

        My.Settings.PATH_FOLDER_PIC1_ZOOM = txtPicture_folder1_zoom.Text
        My.Settings.PATH_FOLDER_PIC2_ZOOM = txtPicture_folder2_zoom.Text

        My.Settings.Count_CutDigit = CInt(txtCutdigit.Text)


        My.Settings.Save()
        Call UpdateConfig_Ini_folder_Picture1()
        Call UpdateConfig_Ini_folder_Picture1_zoom()

        Call UpdateConfig_Ini_folder_Picture2()
        Call UpdateConfig_Ini_folder_Picture2_zoom()


        Call UpdateConfig_Ini_Count_CutDigit()


        MessageBox.Show("Save setting success. ", "Success.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)

        '  cs_MRP = "Server = " & My.Settings.Server & ";Database = " & My.Settings.Database & ";User Id = " & My.Settings.Username_DB & ";Password = " & My.Settings.Password_DB & ";" & "Connection Timeout=" & My.Settings.Timeout & ";"


    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If TEST_CONNECTION() Then


            MessageBox.Show("Connect to server MRP success. ", "Success.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)


        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Close()
    End Sub

    Private Sub txtServerName_TextChanged(sender As Object, e As EventArgs) Handles txtServerName.TextChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            txtPahtFile.Text = OpenFileDialog1.FileName

            'My.Settings.dbAccessPaht = OpenFileDialog1.FileName
            'My.Settings.Save()
        End If
    End Sub

    Private Sub Button1_Click_2(sender As Object, e As EventArgs) Handles Button1.Click
        If FolderBrowserDialog1.ShowDialog = DialogResult.OK Then
            txtPicture_folder1.Text = FolderBrowserDialog1.SelectedPath & "\"

            'My.Settings.dbAccessPaht = OpenFileDialog1.FileName
            'My.Settings.Save()
        End If
    End Sub
End Class