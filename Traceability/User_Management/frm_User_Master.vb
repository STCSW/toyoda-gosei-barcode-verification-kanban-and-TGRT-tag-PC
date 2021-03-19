Imports DatabaseConnection.SQLConnect.SQL
Imports CommonComponent.Software
Imports DevXClass.ClassDevX
Imports DevXClass.ClassExcel
Imports System.Text
Imports System.Data.SqlClient
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Columns
Imports SATOLib.Database.OLE


Public Class frm_User_Master
    Private RESULTSTR As String
    Private sql As String
#Region "DevXGrid"

    Private Sub COPY_CELL(sender As Object, e As System.Windows.Forms.KeyEventArgs) _
                                                       Handles dgw.KeyDown
        Try
            If e.Control AndAlso e.KeyCode = Keys.C Then
                Clipboard.SetText(DGV.GetFocusedDisplayText())
                e.Handled = True
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub GridView_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) _
        Handles DGV.CustomDrawRowIndicator, DGV.CustomDrawRowIndicator

        If e.RowHandle + 1 > 0 Then e.Info.DisplayText = e.RowHandle + 1

    End Sub

    Private Sub gridView1_PopupMenuShowing(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) _
        Handles DGV.PopupMenuShowing, DGV.PopupMenuShowing
        If e.MenuType = DevExpress.XtraGrid.Views.Grid.GridMenuType.Column Then
            For I As Integer = e.Menu.Items.Count - 1 To 0 Step -1

                If e.Menu.Items(I).Caption = "Column Chooser" Or _
                    e.Menu.Items(I).Caption = "Remove This Column" Or _
                     e.Menu.Items(I).Caption = "Show Group By Box" Or _
                      e.Menu.Items(I).Caption = "Group By This Column" Then
                    e.Menu.Items.Remove(e.Menu.Items(I))
                End If

                'If (e.Menu.Items(I).Caption = GridLocalizer.Active.GetLocalizedString(GridStringId.MenuColumnColumnCustomization)) OrElse
                '  (e.Menu.Items(I).Caption = GridLocalizer.Active.GetLocalizedString(GridStringId.MenuColumnRemoveColumn)) OrElse
                '  (e.Menu.Items(I).Caption = GridLocalizer.Active.GetLocalizedString(GridStringId.MenuGroupPanelHide)) OrElse
                '  (e.Menu.Items(I).Caption = GridLocalizer.Active.GetLocalizedString(GridStringId.MenuColumnGroup)) Then

                'End If

            Next I
        End If
    End Sub

    Private Sub GridView1_ShowFilterPopupListBox(ByVal sender As Object, ByVal e As  _
  DevExpress.XtraGrid.Views.Grid.FilterPopupListBoxEventArgs) _
    Handles DGV.ShowFilterPopupListBox, DGV.ShowFilterPopupListBox

        e.ComboBox.AppearanceDropDown.Font = New Font("Tahoma", 12)
        'e.ComboBox.AppearanceDropDown.ForeColor = Color.Blue
    End Sub

#End Region

    Private Sub frm_User_Master_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Getdata_LIST_TYPE_NAME()
        Call getdata()
    End Sub


    Private Sub getdata()
        Dim tmp_DT As New DataTable
        Dim StrSQL As New StringBuilder
        Try
            Cursor.Current = Cursors.WaitCursor
            StrSQL.Remove(0, StrSQL.Length)

            StrSQL.Append(" SELECT ")
            StrSQL.Append(" [UserName] ")
            StrSQL.Append(",[UserType] ")
            StrSQL.Append(",[UserID] ")
            StrSQL.Append(",[Password] ")
            StrSQL.Append(",[RegisterDate] ")
            StrSQL.Append(",[Status] ")
            StrSQL.Append(" FROM")
            StrSQL.Append(" tbUser")
            StrSQL.Append(" ORDER BY [RegisterDate] DESC")
            tmp_DT = DatabaseConnection.OleDBConnect.Access.Read(StrSQL.ToString, css, True)
            If tmp_DT Is Nothing Then
                dgw.DataSource = Nothing
                Exit Sub
            End If
            dgw.DataSource = tmp_DT


            If DGV.RowCount <= 5000 Then DGV.BestFitColumns()
            Cursor.Current = Cursors.Default
        Catch ex As SqlException
            CLS_ALERT_UI.AlertInformation("Error : " & ex.Message & " ", Color.Red, Color.White, Me.Width, 200, True, Me.Height / 2)
            Cursor.Current = Cursors.Default
        Catch ex As Exception
            CLS_ALERT_UI.AlertInformation("Error : " & ex.Message & " ", Color.Red, Color.White, Me.Width, 200, True, Me.Height / 2)
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub dgv_CustomColumnDisplayText(ByVal sender As Object, ByVal e As CustomColumnDisplayTextEventArgs) Handles DGV.CustomColumnDisplayText


        Dim view As ColumnView = TryCast(sender, ColumnView)
        If e.Column.FieldName = "Password" AndAlso e.ListSourceRowIndex <> DevExpress.XtraGrid.GridControl.InvalidRowHandle Then
            e.DisplayText = String.Format("**********")
        End If

        Dim column_1 As GridColumn = view.Columns("RegisterDate")
        If column_1.ColumnType Is GetType(DateTime) Then
            column_1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            column_1.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
        End If

    End Sub

    Private Sub dgw_Click(sender As Object, e As EventArgs) Handles dgw.Click
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = dgw.FocusedView
        Dim row As DataRowView = view.GetRow(view.FocusedRowHandle)

        Try
     
            If row.Item("UserID").ToString <> "" Then

                txtName.Text = row.Item("UserName").ToString
                txtUserID.Text = row.Item("UserID").ToString
                txtPassword.Text = row.Item("Password").ToString
                cbUserType.Text = row.Item("UserType").ToString
                If Convert.ToBoolean(row.Item("Status")) = True Then
                    ToggleSwitch1.IsOn = True
                Else
                    ToggleSwitch1.IsOn = False
                End If

                txtUserID.Properties.ReadOnly = True

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BarButtonItem5_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem5.ItemClick
        Call getdata()
    End Sub

    Private Sub SaveBT_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles SaveBT.ItemClick
        Call Update_data()
    End Sub


    Private Sub Update_data()
        Try
            Dim StrSQL As New StringBuilder
            If txtName.Text.Length = 0 Then
                txtName.Select()
                CLS_ALERT_UI.AlertInformation("Warning : Data not complete, Please complete your data then save again. ", Color.DarkOrange, Color.White, Me.Width, 200, True, Me.Height / 2)
                Exit Sub
            End If

            If cbUserType.Text = String.Empty Then
                cbUserType.SelectedIndex = 0
                CLS_ALERT_UI.AlertInformation("Warning : Data not complete, Please complete your data then save again. ", Color.DarkOrange, Color.White, Me.Width, 200, True, Me.Height / 2)
                Exit Sub
            End If

            If txtUserID.Text.Length = 0 Then
                txtUserID.Select()
                CLS_ALERT_UI.AlertInformation("Warning : Data not complete, Please complete your data then save again. ", Color.DarkOrange, Color.White, Me.Width, 200, True, Me.Height / 2)
                Exit Sub
            End If

            If txtPassword.Text.Length = 0 Then
                txtPassword.Select()
                CLS_ALERT_UI.AlertInformation("Warning : Data not complete, Please complete your data then save again. ", Color.DarkOrange, Color.White, Me.Width, 200, True, Me.Height / 2)
                Exit Sub
            End If

            Dim LockVal As Integer = 0
            If ToggleSwitch1.EditValue = True Then
                LockVal = 1
            Else
                LockVal = 0

            End If
            If MessageBox.Show(Me, "Do you confirm to Save ?", "Comfirm to Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                StrSQL.Remove(0, StrSQL.Length)
                StrSQL.Append(" UPDATE tbUser SET ")
                StrSQL.Append(" [UserType] = '" & cbUserType.Text & "',  ")
                StrSQL.Append(" [Password] = '" & txtPassword.Text & "', ")
                StrSQL.Append(" [UserName] = '" & txtName.Text & "', ")
                StrSQL.Append(" [Status] ='" & LockVal & "' ")
                StrSQL.Append(" WHERE [UserID] = '" & txtUserID.Text & "' ")

                Dim res As Boolean = DatabaseConnection.OleDBConnect.Access.Execute(StrSQL.ToString, css, True)
                If res = True Then
                    CLS_ALERT_UI.AlertInformation("Save Complete", Color.Green, Color.White, Me.Width, 200, True, Me.Height / 2)
                Else
                    CLS_ALERT_UI.AlertInformation("Cannot edit user", Color.Red, Color.White, Me.Width, 200, True, Me.Height / 2)
                End If

                Call getdata()
            End If

        Catch ex As Exception
            CLS_ALERT_UI.AlertInformation("Error : " & ex.Message & " ", Color.Red, Color.White, Me.Width, 200, True, Me.Height / 2)
        End Try
    End Sub
    Private Sub ADD_NEW()
        Try

            Dim StrSQL As New StringBuilder
            If txtName.Text.Length = 0 Then
                txtName.Select()
                CLS_ALERT_UI.AlertInformation("Warning : Data not complete, Please complete your data then save again. ", Color.DarkOrange, Color.White, Me.Width, 200, True, Me.Height / 2)
                Exit Sub
            End If

            If cbUserType.Text = String.Empty Then
                cbUserType.SelectedIndex = 0
                CLS_ALERT_UI.AlertInformation("Warning : Data not complete, Please complete your data then save again. ", Color.DarkOrange, Color.White, Me.Width, 200, True, Me.Height / 2)
                Exit Sub
            End If

            If txtUserID.Text.Length = 0 Then
                txtUserID.Select()
                CLS_ALERT_UI.AlertInformation("Warning : Data not complete, Please complete your data then save again. ", Color.DarkOrange, Color.White, Me.Width, 200, True, Me.Height / 2)
                Exit Sub
            End If

            If txtPassword.Text.Length = 0 Then
                txtPassword.Select()
                CLS_ALERT_UI.AlertInformation("Warning : Data not complete, Please complete your data then save again. ", Color.DarkOrange, Color.White, Me.Width, 200, True, Me.Height / 2)
                Exit Sub
            End If

            Dim LockVal As Integer = 0
            If ToggleSwitch1.EditValue = True Then
                LockVal = 1
            Else
                LockVal = 0

            End If

            Dim TB As New DataTable
            StrSQL.Remove(0, StrSQL.Length)
            StrSQL.Append(" SELECT * FROM tbUser WHERE [UserID] = '" & txtUserID.Text & "'  ")
            TB = DatabaseConnection.OleDBConnect.Access.Read(StrSQL.ToString, css, False)

            If TB Is Nothing = False Then
                If TB.Rows.Count > 0 Then
                    CLS_ALERT_UI.AlertInformation("Warning : This UserName already exists, Please enter new information ", Color.DarkOrange, Color.White, Me.Width, 200, True, Me.Height / 2)
                    Exit Sub
                End If
            End If

            StrSQL.Remove(0, StrSQL.Length)
            StrSQL.Append(" INSERT INTO tbUser")
            StrSQL.Append(" ([UserID],[UserType],[Password],[UserName],[RegisterDate],[Status]) ")
            StrSQL.Append(" VALUES (")
            StrSQL.Append(" '" & Trim(txtUserID.Text) & "',")
            StrSQL.Append(" '" & Trim(cbUserType.Text) & "',")
            StrSQL.Append(" '" & Trim(txtPassword.Text) & "',")
            StrSQL.Append(" '" & Trim(txtName.Text) & "',")
            StrSQL.Append(" Now(),")
            StrSQL.Append(" '" & ToggleSwitch1.IsOn & "')")

            Dim i As Boolean = DatabaseConnection.OleDBConnect.Access.Execute(StrSQL.ToString, css, False)

            If i = True Then
                CLS_ALERT_UI.AlertInformation("Save Complete", Color.Green, Color.White, Me.Width, 200, True, Me.Height / 2)
            Else
                CLS_ALERT_UI.AlertInformation("Cannot add user", Color.Red, Color.White, Me.Width, 200, True, Me.Height / 2)
            End If

            Call getdata()
        Catch ex As Exception
            CLS_ALERT_UI.AlertInformation("Error : " & ex.Message & " ", Color.Red, Color.White, Me.Width, 200, True, Me.Height / 2)
        End Try
    End Sub


    Private Sub cbDepartment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbDepartment.SelectedIndexChanged

    End Sub

    Private Sub NewBT_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles NewBT.ItemClick
        Call ADD_NEW()

    End Sub

    Private Sub DelBT_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles DelBT.ItemClick
        If txtUserID.Text.Length = 0 Then Exit Sub

        Try
            If txtUserID.Text = C_Variable.USER_LOGIN Then
                CLS_ALERT_UI.AlertInformation("Warning : Can not be delete current account", Color.DarkOrange, Color.White, Me.Width, 200, True, Me.Height / 2)
                Exit Sub
            End If
            If MessageBox.Show(Me, "Do you confirm to Delete " & txtUserID.Text & " ?", "Comfirm to Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Dim StrSQL As New StringBuilder
                StrSQL.Remove(0, StrSQL.Length)
                StrSQL.Append(" DELETE FROM tbUser ")
                StrSQL.Append(" WHERE UserID ='" & txtUserID.Text & "' ")

                Dim res As Boolean = DatabaseConnection.OleDBConnect.Access.Execute(StrSQL.ToString, css, False)

                If res = True Then
                    CLS_ALERT_UI.AlertInformation("Delete Complete", Color.Green, Color.White, Me.Width, 200, True, Me.Height / 2)
                Else
                    CLS_ALERT_UI.AlertInformation("Cannot delete user", Color.Red, Color.White, Me.Width, 200, True, Me.Height / 2)
                End If

            End If
            Call getdata()
        Catch ex As Exception
            CLS_ALERT_UI.AlertInformation("Error : " & ex.Message & " ", Color.Red, Color.White, Me.Width, 200, True, Me.Height / 2)
        End Try
    End Sub

    Private Sub bt_exExcel_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bt_exExcel.ItemClick
        Try
            'dgv2.ExportToXls("Export.xls")
            'Process.Start("Export.xls")
            DGV.ExportToXls("Export.xls")
            Process.Start("Export.xls")
        Catch ex As Exception

        End Try

    End Sub

    Private Sub BarButtonItem4_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem4.ItemClick
        Dim frm As New _frmAddTypeUser
        'frm.Reset()
        frm.ShowDialog()
        Call Getdata_LIST_TYPE_NAME()
    End Sub
    

    Private Sub Getdata_LIST_TYPE_NAME()
        Dim StrSQL As New StringBuilder()
        Dim tmp_DT As New DataTable
        cbUserType.Properties.Items.Clear()


        StrSQL.Append(" SELECT [TYPE_NAME] FROM Tbl_USETYP")

        tmp_DT = DatabaseConnection.OleDBConnect.Access.Read(StrSQL.ToString, css, True)

        If tmp_DT IsNot Nothing Then
            For i = 0 To tmp_DT.Rows.Count - 1
                cbUserType.Properties.Items.Add(tmp_DT.Rows(i).Item(0).ToString.Trim)

            Next

        End If
        cbUserType.Text = ""
        cbUserType.EditValue = ""


    End Sub

    Private Sub txtUserID_EditValueChanged(sender As Object, e As EventArgs) Handles txtUserID.EditValueChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        txtUserID.Text = String.Empty
        txtPassword.Text = String.Empty
        txtName.Text = String.Empty
        txtUserID.Properties.ReadOnly = False
    End Sub
End Class