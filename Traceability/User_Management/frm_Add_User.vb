Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Text

Public Class frm_Add_User

#Region "Variable"
    Dim cmd As New SqlCommand
    Dim dr As SqlDataReader
    Dim SB As New StringBuilder
    Dim ID As Integer
    Dim intNumRows As Integer

#End Region

#Region "Sub"

    Private Sub Set_Default()
        txtEmployeeName.Text = String.Empty
        txtEmployeeName.Focus()
        cboUserType.SelectedIndex = 0
        txtUserName.Text = String.Empty
        txtPassword.Text = String.Empty
        txtEmployeeName.Select()

    End Sub

    Private Sub Save()
        Try
            If txtEmployeeName.TextLength = 0 Then
                txtEmployeeName.Select()
                CLS_ALERT_UI.AlertInformation("Warning : Data not complete, Please complete your data then save again. ", Color.DarkOrange, Color.White, Me.Width, 200, True, Me.Height / 2)
                Exit Sub
            End If

            If cboUserType.Text = String.Empty Then
                cboUserType.SelectedIndex = 0
                CLS_ALERT_UI.AlertInformation("Warning : Data not complete, Please complete your data then save again. ", Color.DarkOrange, Color.White, Me.Width, 200, True, Me.Height / 2)
                Exit Sub
            End If

            If txtUserName.TextLength = 0 Then
                txtUserName.Select()
                CLS_ALERT_UI.AlertInformation("Warning : Data not complete, Please complete your data then save again. ", Color.DarkOrange, Color.White, Me.Width, 200, True, Me.Height / 2)
                Exit Sub
            End If

            If txtPassword.TextLength = 0 Then
                txtPassword.Select()
                CLS_ALERT_UI.AlertInformation("Warning : Data not complete, Please complete your data then save again. ", Color.DarkOrange, Color.White, Me.Width, 200, True, Me.Height / 2)
                Exit Sub
            End If
            If cmbLine.Text = String.Empty Then
                cmbLine.SelectedIndex = 0
                CLS_ALERT_UI.AlertInformation("Warning : Data not complete, Please complete your data then save again. ", Color.DarkOrange, Color.White, Me.Width, 200, True, Me.Height / 2)
                Exit Sub
            End If

            Dim TB As New DataTable
            SB.Remove(0, SB.Length)
            SB.Append(" Execute s_SELECT_DUPLICATE_USERS @UserID = '" & txtUserName.Text & "'  ")
            TB = DatabaseConnection.SQLConnect.SQL.Read(SB.ToString, cs, False)

            If CInt(TB.Rows(0).Item("COUNTT")) > 0 Then
                CLS_ALERT_UI.AlertInformation("Warning : This UserName already exists, Please enter new information ", Color.DarkOrange, Color.White, Me.Width, 200, True, Me.Height / 2)
                Exit Sub
            End If

            SB.Remove(0, SB.Length)
            SB.Append(" INSERT INTO tb_User (")
            SB.Append(" [UserID],[UserType],[Password],[Name],[Line_Operattion],[RegisteredDate]) ")
            SB.Append(" VALUES (")
            SB.Append(" '" & Trim(txtUserName.Text) & "',")
            SB.Append(" '" & Trim(cboUserType.Text) & "',")
            SB.Append(" '" & Trim(txtPassword.Text) & "',")
            SB.Append(" '" & Trim(txtEmployeeName.Text) & "',")
            SB.Append(" '" & Trim(cmbLine.Text) & "',")
            SB.Append(" '" & DateTime.Now & "')")

            DatabaseConnection.SQLConnect.SQL.Execute(SB.ToString, cs, False)
            CLS_ALERT_UI.AlertInformation("Save Complete", Color.Green, Color.White, Me.Width, 200, True, Me.Height / 2)
            Call Set_Default()
        Catch ex As Exception
            CLS_ALERT_UI.AlertInformation("Error : " & ex.Message & " ", Color.Red, Color.White, Me.Width, 200, True, Me.Height / 2)
        End Try
    End Sub

#End Region

    Private Sub frm_Add_User_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Getdata_LIST_TYPE_NAME()
        Me.CenterToScreen()
        Call Set_Default()
        lblDate.Text = Now.ToString("dd-MMM-yyyy")

    End Sub

    Private Sub txtEmployeeName_GotFocus(sender As Object, e As EventArgs) Handles txtEmployeeName.GotFocus
        txtEmployeeName.BackColor = Color.Aquamarine
    End Sub

    Private Sub txtEmployeeName_LostFocus(sender As Object, e As EventArgs) Handles txtEmployeeName.LostFocus
        txtEmployeeName.BackColor = Color.White
    End Sub

    Private Sub txtUserName_GotFocus(sender As Object, e As EventArgs) Handles txtUserName.GotFocus
        txtUserName.BackColor = Color.Aquamarine
    End Sub
    Private Sub txtUserName_LostFocus(sender As Object, e As EventArgs) Handles txtUserName.LostFocus

        txtUserName.BackColor = Color.White
    End Sub
    Private Sub txtPassword_GotFocus(sender As Object, e As EventArgs) Handles txtPassword.GotFocus
        txtPassword.BackColor = Color.Aquamarine
    End Sub
    Private Sub txtPassword_LostFocus(sender As Object, e As EventArgs) Handles txtPassword.LostFocus
        txtPassword.BackColor = Color.White
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            txtPassword.UseSystemPasswordChar = False
        ElseIf CheckBox1.Checked = False Then
            txtPassword.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub txtEmployeeName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEmployeeName.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub

    Private Sub txtUserName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUserName.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub

    Private Sub txtPassword_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPassword.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub

    Private Sub cboUserType_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboUserType.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub

    Private Sub frm_Add_User_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub


    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Call Save()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Call Set_Default()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Dim frm As New _frmAddTypeUser
        'frm.Reset()
        frm.ShowDialog()
        Call Getdata_LIST_TYPE_NAME()
    End Sub
    Public Sub Getdata_LIST_TYPE_NAME()
        Try
            Dim StrSQL As New StringBuilder()
            Dim tmp_DT As New DataTable
            ' StrSQL.Append("select *")

            'StrSQL.Append(" from [tb_User]")
            StrSQL.Append(" SELECT  [TYPE NAME] ")
            StrSQL.Append(" FROM [View_TYPEUSER]")
            StrSQL.Append(" GROUP BY [TYPE NAME]")


            tmp_DT = SQLConnect._SQL.Read(StrSQL.ToString)
            cboUserType.Items.Clear()
            For i = 0 To tmp_DT.Rows.Count - 1
                cboUserType.Items.Add(tmp_DT.Rows(i).Item("TYPE NAME"))
            Next i



        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class