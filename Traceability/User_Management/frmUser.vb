Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Text
Imports DevExpress.Utils
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns

Public Class frmUser

    Dim SB As New StringBuilder
    Dim zUserID As String
    Dim zName As String
    Dim zUserType As String
    Dim zPassword As String
    Dim zUserLine As String
    Dim int As Integer = 0

    Private Sub frmUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call FillTable()
        dgv.OptionsMenu.EnableColumnMenu = False
        dgv.OptionsMenu.EnableFooterMenu = False
        dgv.OptionsMenu.EnableGroupPanelMenu = False
        dgv.OptionsView.ShowGroupPanel = False
        dgv.OptionsCustomization.AllowColumnMoving = False
        dgv.OptionsBehavior.Editable = False

        dgv.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        dgv.OptionsSelection.MultiSelect = True

        '  DGV.OptionsView.ShowFooter = True
        ''DGV.Columns(4).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        'DGV.Columns(4).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        'DGV.Columns(4).SummaryItem.DisplayFormat = "Total {0} Users"

        BarButtonItem4.Enabled = False
        BarButtonItem5.Enabled = False
    End Sub


    Private Sub FillTable()
        Dim dt As New DataTable
        Try
            Cursor.Current = Cursors.WaitCursor
            SB.Remove(0, SB.Length)
            SB.Append(" Execute s_SELECT_USER ")
            Dim da As New SqlDataAdapter(SB.ToString, cs)
            Dim ds As New DataSet
            da.Fill(ds, "User")
            dgw1.DataSource = ds.Tables(0)
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

    Private Sub DGV_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles DGV.CellValueChanged
       
    End Sub

    Private Sub DGV_Click(sender As Object, e As EventArgs) Handles DGV.Click

    End Sub

    Private Sub DGV_ColumnChanged(sender As Object, e As EventArgs) Handles DGV.ColumnChanged
      
    End Sub

    Private Sub dgv_CustomColumnDisplayText(ByVal sender As Object, ByVal e As CustomColumnDisplayTextEventArgs) Handles DGV.CustomColumnDisplayText


        Dim view As ColumnView = TryCast(sender, ColumnView)
        If e.Column.FieldName = "Password" AndAlso e.ListSourceRowIndex <> DevExpress.XtraGrid.GridControl.InvalidRowHandle Then
            e.DisplayText = String.Format("**********")
        End If

        Dim column_1 As GridColumn = view.Columns("RegisteredDate")
        If column_1.ColumnType Is GetType(DateTime) Then
            column_1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            column_1.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
        End If

    End Sub

    Private Sub dgv_RowCellDefaultAlignment(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowCellAlignmentEventArgs) Handles DGV.RowCellDefaultAlignment
        e.HorzAlignment = DevExpress.Utils.HorzAlignment.Center
    End Sub

    Private Sub frmUser_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        Call FillTable()

        If dgv.SelectedRowsCount = 0 Then
            BarButtonItem4.Enabled = False
            BarButtonItem5.Enabled = False
        ElseIf dgv.SelectedRowsCount = 1 Then
            BarButtonItem4.Enabled = True
            BarButtonItem5.Enabled = True
        ElseIf dgv.SelectedRowsCount > 1 Then
            BarButtonItem4.Enabled = False
            BarButtonItem5.Enabled = False
        End If
    End Sub

    Private Sub dgv_SelectionChanged(sender As Object, e As DevExpress.Data.SelectionChangedEventArgs) Handles DGV.SelectionChanged
        If DGV.SelectedRowsCount = 0 Then
            BarButtonItem4.Enabled = False
            BarButtonItem5.Enabled = False
        ElseIf DGV.SelectedRowsCount = 1 Then
            BarButtonItem4.Enabled = True
            BarButtonItem5.Enabled = True
        ElseIf DGV.SelectedRowsCount > 1 Then
            BarButtonItem4.Enabled = False
            BarButtonItem5.Enabled = False
        End If

        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim value_Name As Object = view.GetRowCellValue(view.FocusedRowHandle, view.Columns(0))
        Dim value_UserType As Object = view.GetRowCellValue(view.FocusedRowHandle, view.Columns(1))
        Dim value_UserID As Object = view.GetRowCellValue(view.FocusedRowHandle, view.Columns(2))
        Dim value_Password As Object = view.GetRowCellValue(view.FocusedRowHandle, view.Columns(3))

        zUserID = value_UserID.ToString
        zName = value_Name.ToString
        zUserType = value_UserType.ToString
        zPassword = value_Password.ToString

    End Sub

    Private Sub BarButtonItem3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        frm_Add_User.ShowDialog()
    End Sub

    Private Sub BarButtonItem4_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem4.ItemClick
        If dgv.SelectedRowsCount = 0 Then Exit Sub
        If dgv.SelectedRowsCount > 1 Then
            CLS_ALERT_UI.AlertInformation("Warning : You Can select one item for Edit", Color.DarkOrange, Color.White, Me.Width, 200, True, Me.Height / 2)
            Exit Sub
        End If

        If MessageBox.Show(Me, "Do you confirm to edit your selected ", "Confirm to Edit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.No Then
            Exit Sub
        End If
        Dim zfrm As New frm_Edit_User

        With zfrm
            .Getdata_LIST_TYPE_NAME()
            .txtEmployeeName.Text = zName
            .txtUserName.Text = zUserID
            .txtPassword.Text = zPassword
            .cboUserType.Text = zUserType
            .cmbLine.Text = zUserLine
            .ShowDialog()
        End With
    End Sub

    Private Sub BarButtonItem5_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem5.ItemClick
        If dgv.SelectedRowsCount = 0 Then Exit Sub
        If dgv.SelectedRowsCount > 1 Then
            CLS_ALERT_UI.AlertInformation("Warning : You Can select one item for Delete", Color.DarkOrange, Color.White, Me.Width, 200, True, Me.Height / 2)
            Exit Sub
        End If

        Try
            If zUserID = C_Variable.USER_LOGIN Then
                CLS_ALERT_UI.AlertInformation("Warning : Can not be delete current account", Color.DarkOrange, Color.White, Me.Width, 200, True, Me.Height / 2)
                Exit Sub
            End If
            If MessageBox.Show(Me, "Do you confirm to Delete " & zName & " ?", "Comfirm to Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                SB.Remove(0, SB.Length)
                SB.Append(" DELETE FROM tb_User ")
                SB.Append(" WHERE UserID ='" & zUserID & "' ")

                DatabaseConnection.SQLConnect.SQL.Execute(SB.ToString, cs, False)
                CLS_ALERT_UI.AlertInformation("Delete Complete", Color.Green, Color.White, Me.Width, 200, True, Me.Height / 2)
            End If
            Call FillTable()
        Catch ex As Exception
            CLS_ALERT_UI.AlertInformation("Error : " & ex.Message & " ", Color.Red, Color.White, Me.Width, 200, True, Me.Height / 2)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Me.Close()
    End Sub

    Private Sub dgw1_Click(sender As Object, e As EventArgs) Handles dgw1.Click

    End Sub
End Class