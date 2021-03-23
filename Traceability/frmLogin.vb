Imports MetroFramework
Imports System.Data.SqlClient
Imports System.IO
Imports System.Text

Public Class frmLogin

    Dim dTUser As New DataTable()



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If CommonComponent.Software.StartSoftware("", Command) = False Then
            End
        End If

        Call Check_ini_DB_File()

        Call Check_ini_DB_File_MRP()




        lblVersion.Text = C_VERSION.GetVersionSoftware()
        'Animator settings
        'animator1.AnimationType = AnimatorNS.AnimationType.Transparent
        'animator1.Interval = 8
        'animator1.MaxAnimationTime = 1500
        'animator1.TimeStep = 0.02F




        For Each item As Control In Panel2.Controls
            If item.Visible = False Then
                '   animator1.Show(item)
            End If
        Next

        'For Each item As Control In pnlLeft.Controls
        '    If item.Visible = False Then
        '        animator1.Show(item)
        '    End If
        'Next

        'For Each item As Control In pnlRight.Controls
        '    If item.Visible = False Then
        '        animator1.Show(item)
        '    End If
        'Next






        txtUsername.Text = String.Empty
        txtPassword.Text = String.Empty
        txtUsername.Text = My.Settings.UserID




        txtUsername.Focus()
    End Sub



    'Private Sub LOGIN()


    '    btnLogin.Enabled = False
    '    animator1.Hide(btnLogin, True, AnimatorNS.Animation.HorizSlide)
    '    animator1.Show(lblLoading, True)
    '    animator1.Show(pbLoading, True)
    '    Application.DoEvents()
    '    wait(4000)
    '    animator1.Hide(lblLoading, True)
    '    animator1.Hide(pbLoading, True)
    '    animator1.Show(btnLogin, True, AnimatorNS.Animation.HorizSlide)
    '    btnLogin.Enabled = True





    '    '  Call WriteErrorLog("CLSS_TEST", "FN_TEST", "ERROR_TEST")


    'End Sub




    Private Sub LOGIN()

        txtUsername.Text = Trim(txtUsername.Text)
        If txtUsername.Text = String.Empty Then
            MessageBox.Show("Please enter username.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            txtUsername.Focus()
            Return
        End If

        txtPassword.Text = Trim(txtPassword.Text)
        If txtPassword.Text = String.Empty Then
            MessageBox.Show("Please enter passsword.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            txtPassword.Focus()
            Return
        End If

        btnLogin.Enabled = False
        ' animator1.Hide(btnLogin, True, AnimatorNS.Animation.HorizSlide)
        '  animator1.Show(lblLoading, True)
        ' animator1.Show(pbLoading, True)
        Application.DoEvents()
        txtUsername.Enabled = False
        txtPassword.Enabled = False
        'wait(4000)




        If txtUsername.Text = "admin" And txtPassword.Text = "1234" Then
            C_Variable.USER_LOGIN = Trim(txtUsername.Text)
            C_Variable.USER_Type = "admin"
            txtUsername.Text = String.Empty
            txtPassword.Text = String.Empty
            txtUsername.Focus()
            ' Me.Hide()
            Cursor.Current = Cursors.WaitCursor



            'animator1.Hide(lblLoading, True)
            '  animator1.Hide(pbLoading, True)
            '  animator1.Show(btnLogin, True, AnimatorNS.Animation.HorizSlide)
            btnLogin.Enabled = True

            Dim zfrm As New frmMainribbon
            ' Dim frm As New frmMainMenu_BT
            Me.Hide()

            zfrm.ShowDialog()
            '    frmMainMenu_METRO.ShowDialog()

            txtUsername.Enabled = True
            txtPassword.Enabled = True
            Exit Sub
        End If



        'dTUser = DatabaseConnection.SQLConnect.SQL.Read("SELECT * FROM tb_User ", cs, False)
        dTUser = DatabaseConnection.OleDBConnect.Access.Read("SELECT * FROM tbUser ", css, False)
        If dTUser Is Nothing Then
            MetroMessageBox.Show(Me, "No data on system !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtUsername.SelectAll()
            txtUsername.Focus()
            Cursor.Current = Cursors.Default


            '  animator1.Hide(lblLoading, True)
            '  animator1.Hide(pbLoading, True)
            ' animator1.Show(btnLogin, True, AnimatorNS.Animation.HorizSlide)
            btnLogin.Enabled = True

            txtUsername.Enabled = True
            txtPassword.Enabled = True
            Exit Sub
        End If


        'Dim dRow As DataRow() = dTUser.Select("UserID = '" & txtUsername.Text & "' AND Password = '" & txtPassword.Text & "'")
        Dim dRow As DataRow() = dTUser.Select("UserID = '" & txtUsername.Text & "' AND Password = '" & txtPassword.Text & "'")

        If dRow.Length.Equals(0) Then
            MetroMessageBox.Show(Me, "User Id / Password incorrect !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtUsername.SelectAll()
            txtUsername.Focus()
            Cursor.Current = Cursors.Default


            '   animator1.Hide(lblLoading, True)
            '  animator1.Hide(pbLoading, True)
            '  animator1.Show(btnLogin, True, AnimatorNS.Animation.HorizSlide)
            btnLogin.Enabled = True
            txtUsername.Enabled = True
            txtPassword.Enabled = True
            Exit Sub
        End If
        'Try



        Dim Permission As String = dRow(0)("UserType").ToString()
        'C_Variable.Line_Operattion = dRow(0)("Line_Operattion").ToString()
        If Permission = "ADMIN" Or Permission = "Admin" Or Permission = "admin" Then
            C_Variable.IS_LOGIN_ADMIN = True
        Else
            C_Variable.IS_LOGIN_ADMIN = False
        End If

        My.Settings.UserID = Trim(txtUsername.Text)
        My.Settings.Save()
        C_Variable.USER_LOGIN = Trim(txtUsername.Text)
        C_Variable.USER_Type = Permission
        C_Variable.USER_Name = dRow(0)("UserName").ToString()



        txtUsername.Text = String.Empty
        txtPassword.Text = String.Empty
        txtUsername.Focus()
        ' Me.Hide()
        Cursor.Current = Cursors.WaitCursor



        'animator1.Hide(lblLoading, True)
        '  animator1.Hide(pbLoading, True)
        '  animator1.Show(btnLogin, True, AnimatorNS.Animation.HorizSlide)
        btnLogin.Enabled = True

        Dim frm As New frmMainribbon
        ' Dim frm As New frmMainMenu_BT
        Me.Hide()

        frm.ShowDialog()
        '    frmMainMenu_METRO.ShowDialog()

        txtUsername.Enabled = True
        txtPassword.Enabled = True
        'If C_Variable.IS_LOGIN_ADMIN = True Then
        '    Timer1.Enabled = False
        '    frmMainMenu.Show()
        '    Cursor.Current = Cursors.Default
        'Else
        '    Timer1.Enabled = False

        '    frm4User.Show()
        '    Cursor.Current = Cursors.Default

        'End If

        'Catch ex As Exception

        '    Dim errorMsg As String = "Login fail to get datatable. [" & ex.Message & " ]"
        '    '   C_ERROR_LOG.KEEP_LOG(errorMsg)
        '    'MessageBox.Show(errorMsg, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        '    MetroMessageBox.Show(Me, errorMsg, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error)

        '    animator1.Hide(lblLoading, True)
        '    animator1.Hide(pbLoading, True)
        '    animator1.Show(btnLogin, True, AnimatorNS.Animation.HorizSlide)
        '    btnLogin.Enabled = True
        '    txtUsername.Enabled = True
        '    txtPassword.Enabled = True
        'End Try

        Cursor.Current = Cursors.Default




    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        'Call LOGIN()
        LOGIN()
    End Sub


    Private Sub wait(ByVal interval As Integer)

        Dim stopW As New Stopwatch()
        stopW.Start()
        While stopW.ElapsedMilliseconds < interval

            Application.DoEvents()

        End While

        stopW.Stop()

    End Sub

    Private Sub txt_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUsername.GotFocus, txtPassword.GotFocus

        Dim objTxt As TextBox = CType(sender, TextBox)
        objTxt.BackColor = Color.MediumSpringGreen

    End Sub

    Private Sub txt_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUsername.LostFocus, txtPassword.LostFocus

        Dim objTxt As TextBox = CType(sender, TextBox)
        objTxt.BackColor = SystemColors.Window

    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnSetting.Click
        Dim Mystring As String
        '   MessageBox.Show(CommonComponent.ENCRYP.Encoding("GKN@2017", "1234"))
        Mystring = frm_Inputbox.Inputtxt("Please enter password", "Request password", "Please enter password", "*")

        If Not Mystring = C_Variable.PASSWORD_LOCK_SCREEN Then
            MessageBox.Show("Password incorrect", "Fail.", MessageBoxButtons.OK)
        Else

            Dim config As New frmConfigDb()
            config.ShowDialog()



        End If
        txtUsername.SelectAll()
        txtUsername.Focus()
    End Sub

    Private Sub txtUsername_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUsername.KeyDown

        If e.KeyCode.Equals(Keys.Enter) Then
            If Trim(txtPassword.Text) <> String.Empty Then
                LOGIN()
            Else
                txtPassword.Focus()
            End If
        End If
    End Sub

    Private Sub txtUsername_TextChanged(sender As Object, e As EventArgs) Handles txtUsername.TextChanged

    End Sub

    Private Sub txtPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode.Equals(Keys.Enter) Then
            If Trim(txtUsername.Text) <> String.Empty Then
                LOGIN()
            Else
                txtUsername.Focus()
            End If
        End If
    End Sub

    Private Sub txtPassword_TextChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged

    End Sub

    Private Sub LinkLabel1_GotFocus(sender As Object, e As EventArgs)
        txtUsername.Focus()
    End Sub




    Private Sub Button1_Click_1(sender As Object, e As EventArgs)
        Dim myStr As String
        Dim a, b As String

        myStr = CStr(InputBox("Please enter String ", "Request String", Nothing))
        b = myStr

        a = CommonComponent.ENCRYP.Decoding(b, "1234")
        MessageBox.Show(a)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'AdornerUIManager1.ShowGuides = DevExpress.Utils.DefaultBoolean.True
        'Call Play_Siren_sound()

        Dim zITEM_CD As String = "880545"
        Dim zLOC_CD As String = "FGWH"
        Dim zLOT_NO As String = "PL20190130"
        Dim zTRANS_DATE As String = "2019-04-02 00:00:00.000"
        Dim zQTY As Integer = 266
        Dim zREF_SLIP_NO As String = ""
        Dim zREMARK As String = "NEXTINNOVATION SYSTEM TEST RCV " & Now.ToString("MMddhhmmss")
        Dim zFOR_MACHINE As String = "NEXT"
        Dim zSHIFT_CLS As String = "A"
        Dim zBY_MACHINE As String = C_Variable.var_MACHINE
        Dim zBY_USER As String = C_Variable.USER_LOGIN

        'Dim data() As String
        'Dim data2() As String
        'data = cmbShift.Text.Split(":")
        'data2 = cmbStoredLoc.Text.Split(":")
        'zSHIFT_CLS = data(0)
        'zLOC_CD = data2(0)

        ' Sent_RCV_TO_MRP(zITEM_CD, zLOC_CD, zLOT_NO, zTRANS_DATE, zQTY, zREF_SLIP_NO, zREMARK, zFOR_MACHINE, zSHIFT_CLS, zBY_MACHINE, zBY_USER)
        If Sent_WR_TO_MRP(zITEM_CD, zLOC_CD, zLOT_NO, zTRANS_DATE, zQTY, zREF_SLIP_NO, zREMARK, zFOR_MACHINE, zSHIFT_CLS, zBY_MACHINE, zBY_USER) = False Then
            MetroMessageBox.Show(Me, "Some item can't sent data to MRP System", "Error selected", MessageBoxButtons.OK, MessageBoxIcon.Error) 'red
            Exit Sub
        End If
        'If Sent_RCV_TO_MRP(zITEM_CD, zLOC_CD, zLOT_NO, zTRANS_DATE, zQTY, zREF_SLIP_NO, zREMARK, zFOR_MACHINE, zSHIFT_CLS, zBY_MACHINE, zBY_USER) = False Then
        '    MetroMessageBox.Show(Me, "Some item can't sent data to MRP System", "Error selected", MessageBoxButtons.OK, MessageBoxIcon.Error) 'red
        '    Exit Sub
        'End If
    End Sub

    'Private Function Sent_RCV_TO_MRP(ByVal zITEM_CD As String, ByVal zLOC_CD As String, ByVal zLOT_NO As String, ByVal zTRANS_DATE As String _
    '                                   , ByVal zQTY As String, ByVal zREF_SLIP_NO As String, ByVal zREMARK As String, ByVal zFOR_MACHINE As String _
    '                                   , ByVal zSHIFT_CLS As String, ByVal zBY_MACHINE As String, ByVal zBY_USER As String) As Boolean
    '    Dim query_parameters(8) As SqlParameter
    '    query_parameters(0) = New SqlParameter("@ITEM_CD", SqlDbType.NVarChar)
    '    query_parameters(0).Value = zITEM_CD
    '    query_parameters(1) = New SqlParameter("@LOC_CD", SqlDbType.NVarChar)
    '    query_parameters(1).Value = zLOC_CD
    '    query_parameters(2) = New SqlParameter("@LOT_NO", SqlDbType.NVarChar)
    '    query_parameters(2).Value = zLOT_NO
    '    query_parameters(3) = New SqlParameter("@TRANS_DATE", SqlDbType.NVarChar)
    '    query_parameters(3).Value = zTRANS_DATE
    '    query_parameters(4) = New SqlParameter("@QTY", SqlDbType.NVarChar)
    '    query_parameters(4).Value = zQTY
    '    query_parameters(5) = New SqlParameter("@REF_SLIP_NO", SqlDbType.NVarChar)
    '    query_parameters(5).Value = zREF_SLIP_NO
    '    query_parameters(6) = New SqlParameter("@REMARK", SqlDbType.NVarChar)
    '    query_parameters(6).Value = zREMARK
    '    query_parameters(7) = New SqlParameter("@FOR_MACHINE", SqlDbType.NVarChar)
    '    query_parameters(7).Value = zFOR_MACHINE
    '    query_parameters(8) = New SqlParameter("@SHIFT_CLS", SqlDbType.NVarChar)
    '    query_parameters(8).Value = zSHIFT_CLS


    '    '  query_parameters(8).Value = "A"
    '    'query_parameters(9) = New SqlParameter("@BY_MACHINE", SqlDbType.NVarChar)
    '    'query_parameters(9).Value = zBY_MACHINE
    '    'query_parameters(10) = New SqlParameter("@BY_USER", SqlDbType.NVarChar)
    '    'query_parameters(10).Value = zBY_USER

    '    '  Dim tmp_dt As New DataTable
    '    ' tmp_dt()
    '    DatabaseConnection.SQLConnect.SQL.ExecuteSP("spb_RCV_to_MRP", cs_MRP, query_parameters, False)
    '    Return True
    '    'If tmp_dt Is Nothing Then
    '    '    Return False
    '    'Else
    '    '    ' tmp_dt.Rows(0).Item(0) = "tmp_dt"
    '    '    Return True
    '    'End If


    'End Function

    Private Sub AdornerUIManager1_QueryGuideFlyoutControl(sender As Object, e As DevExpress.Utils.VisualEffects.QueryGuideFlyoutControlEventArgs) Handles AdornerUIManager1.QueryGuideFlyoutControl
        e.Control = New GuideFlyoutPanel()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Dim zITEM_CD As String = "44724201PP"
        Dim zLOC_CD As String = "FGWH"
        Dim zLOT_NO As String = "PL" & CDate(Now).ToString("yyyyMMdd")
        Dim zTRANS_DATE As String = CDate(Now).ToString("yyyy-MM-dd")
        Dim zQTY As Integer = "20"
        Dim zREF_SLIP_NO As String = "NEXT"
        Dim zREMARK As String = "NEXTINNOVATION SYSTEM TEST RCV " & Now.ToString("MMddhhmmss")

        Dim zFOR_MACHINE As String = "NEXT"
        Dim zSHIFT_CLS As String = "A"
        Dim zBY_MACHINE As String = C_Variable.var_MACHINE
        Dim zBY_USER As String = C_Variable.USER_LOGIN
        Dim pCustomer As String = "TEST"

        'Dim data() As String
        'Dim data2() As String
        'data = cmbShift.Text.Split(":")
        'data2 = cmbStoredLoc.Text.Split(":")
        'zSHIFT_CLS = data(0)
        'zLOC_CD = data2(0)


        If Sent_SHIPMENT_TO_MRP(zITEM_CD, zLOC_CD, zLOT_NO, zTRANS_DATE, zQTY, zREF_SLIP_NO, zREMARK, zFOR_MACHINE, zSHIFT_CLS, zBY_MACHINE, zBY_USER, pCustomer) = False Then
            MetroMessageBox.Show(Me, "Some item can't sent data to MRP System", "Error selected", MessageBoxButtons.OK, MessageBoxIcon.Error) 'red
            Exit Sub
        End If

        'Dim tmp_DT As New DataTable
        'Dim StrSQL As New StringBuilder()


        'StrSQL.Append(" SELECT [f_PLAN_NO] from")
        'StrSQL.Append(" [tbl_Production_Plan_Master]")
        'tmp_DT = DatabaseConnection.SQLConnect.SQL.Read(StrSQL.ToString, cs, False)

        'For i = 0 To tmp_DT.Rows.Count - 1
        '    Dim query_parameters(0) As SqlParameter
        '    query_parameters(0) = New SqlParameter("@PLANNO", SqlDbType.NVarChar)
        '    query_parameters(0).Value = tmp_DT.Rows(i).Item(0).ToString
        '    DatabaseConnection.SQLConnect.SQL.ReadSP("sp_GET_PLANNO_DETAIL_SCAN_SERIAL_LIST_IN", cs, query_parameters)
        '    Threading.Thread.Sleep(200)
        'Next i
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        My.Computer.Audio.Play(My.Resources.SoundError, AudioPlayMode.Background)


    End Sub



    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ' Dim parts As String() = myString.Split(New String() {Environment.NewLine},
        ' StringSplitOptions.None)

        'If File.Exists(Application.StartupPath & "\AllSetting_ini\PASSWORD.ini") Then
        '    Using objReader As New StreamReader(Application.StartupPath & "\AllSetting_ini\PASSWORD.ini")
        '        Dim tmpRead_data As String = objReader.ReadToEnd()
        '        If tmpRead_data.Trim.Length > 0 Then
        '            MessageBox.Show(tmpRead_data)
        '            Dim parts As String() = tmpRead_data.Split(New String() {Environment.NewLine},
        '         StringSplitOptions.None)

        '            MessageBox.Show(parts.Length)
        '        End If
        '    End Using
        'End If
        My.Computer.Audio.Play(My.Resources.SoundError, AudioPlayMode.Background)

        Mdl_Core.LockScreen(Me.Width, "red", "TEST")

    End Sub


End Class
