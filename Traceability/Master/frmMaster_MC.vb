Imports MetroFramework
Imports System.Text
Imports System.IO
Imports System.Data.SqlClient

Public Class frmMaster_MC
    Dim int As Integer = 0
    Private DT As New DataTable
    Private Sub GridView_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles DGV.CustomDrawRowIndicator

        If e.RowHandle + 1 > 0 Then e.Info.DisplayText = e.RowHandle + 1

    End Sub
    Sub New()


        InitializeComponent()
        Getdata()


    End Sub



    Public Sub Getdata()
        Try
            Dim StrSQL As New StringBuilder()

            StrSQL.Append("select *")

            StrSQL.Append(" from [View_MASTER_MC]")


            DT = SQLConnect._SQL.Read(StrSQL.ToString)
            dgw1.DataSource = DT

            If DGV.RowCount <= 5000 Then DGV.BestFitColumns()
            '  lblCountItem.Text = "Item Count : " & Format(CInt(DGV.RowCount), "#,##0")

            DGV.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
            DGV.OptionsSelection.MultiSelect = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub




    Private Sub GetDatatoUpdate(ByVal pForm As frmMaster_MC_EDIT)
        If DGV.RowCount <= 0 Then Exit Sub


        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = dgw1.FocusedView
        Dim row As DataRowView = view.GetRow(view.FocusedRowHandle)


        With pForm
            .data(0) = row.Item(0)
            .data(1) = row.Item(1)
            .data(2) = row.Item(2)
            .data(3) = row.Item(3)
            .data(4) = row.Item(4)
            .data(5) = row.Item(5)
            .data(6) = row.Item(6)

        End With

     



    End Sub





    Private Sub dgw1_DoubleClick(sender As Object, e As EventArgs)

        Call Edit_show()

    End Sub

    Private Sub DeleteData(ByVal pDATA As String)
        Try

            Dim StrSQL As New StringBuilder()




            StrSQL.Append("delete from [tbl_Master_MC] where [f_MC_Code]='" & pDATA & "'")
            SQLConnect._SQL.Execute(StrSQL.ToString)



            MessageBox.Show("Successfully, f_MC_Code : " & pDATA & " deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try


    End Sub


    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs)

        If e.KeyCode = Keys.Enter Then
            Getdata()
        End If


    End Sub



    Private Sub dgw1_DoubleClick1(sender As Object, e As EventArgs)

        Call Edit_show()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs)
        Call Getdata()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs)
        Call Getdata()
    End Sub


   





 


    'Private Sub AddBT_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles AddBT.ItemClick

    '    Call Create_show()
    'End Sub

    'Private Sub EditBT_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles EditBT.ItemClick

    '    Call Edit_show()
    'End Sub

    'Private Sub DelBT_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles DelBT.ItemClick
    '    Call Delete_Item()

    'End Sub

    

    Private Sub BarButtonItem5_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem5.ItemClick
        If DGV.SelectedRowsCount = 0 Then Exit Sub
        If DGV.SelectedRowsCount > 1 Then
            CLS_ALERT_UI.AlertInformation("Warning : You Can select one item for Delete", Color.DarkOrange, Color.White, Me.Width, 200, True, Me.Height / 2)
            Exit Sub
        End If

        Try
            Dim SB As New StringBuilder
            Dim view As DevExpress.XtraGrid.Views.Grid.GridView = dgw1.FocusedView
            Dim row As DataRowView = view.GetRow(view.FocusedRowHandle)
            'If zUserID = C_Variable.USER_LOGIN Then
            '    CLS_ALERT_UI.AlertInformation("Warning : Can not be delete current account", Color.DarkOrange, Color.White, Me.Width, 200, True, Me.Height / 2)
            '    Exit Sub
            'End If
            If MessageBox.Show(Me, "Do you confirm to Delete " & row.Item(0).ToString & " ?", "Comfirm to Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                SB.Remove(0, SB.Length)
                SB.Append(" DELETE FROM [tbl_Master_MC] ")
                SB.Append(" WHERE [f_MC_Code] ='" & row.Item(0).ToString & "' ")

                DatabaseConnection.SQLConnect.SQL.Execute(SB.ToString, cs, False)
                CLS_ALERT_UI.AlertInformation("Delete Complete", Color.Green, Color.White, Me.Width, 200, True, Me.Height / 2)
            End If
            Call Getdata()
        Catch ex As Exception
            CLS_ALERT_UI.AlertInformation("Error : " & ex.Message & " ", Color.Red, Color.White, Me.Width, 200, True, Me.Height / 2)
        End Try
    End Sub

    'Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
    '    Call Delete_Item()
    'End Sub

    Private Sub Delete_Item()

        If MessageBox.Show("Do you want to delete your selected ?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then


            Dim view1 As DevExpress.XtraGrid.Views.Grid.GridView = dgw1.FocusedView
            Dim Str_commad As New StringBuilder()
            For I = 0 To DGV.SelectedRowsCount() - 1
                Dim row1 As DataRowView = view1.GetRow(DGV.GetSelectedRows(I))
                DeleteData(row1.Item(0).ToString)
            Next
            Getdata()
        End If
    End Sub

    'Private Sub BarButtonItem13_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem13.ItemClick

    'End Sub

    'Private Sub BarButtonItem14_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem14.ItemClick
    '    Call Getdata()
    'End Sub

    Private Sub Edit_show()
        Dim frm As New frmMaster_MC_EDIT
        frm.Reset()
        GetDatatoUpdate(frm)
        frm.CheckCreate = False
        frm.ShowDialog()
        Getdata()
    End Sub

    Private Sub Create_show()
        Dim frm As New frmMaster_MC_EDIT
        frm.Reset()
        frm.ShowDialog()
        Getdata()
    End Sub

    Private Sub dgw1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles dgw1.MouseDoubleClick


        Dim con As New SqlConnection(cs)
        Dim cb As String


        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = dgw1.FocusedView
        Dim row As DataRowView = view.GetRow(view.FocusedRowHandle)

        If view.FocusedColumn.Name = "colPhoto1" Then
            Try
                cb = "SELECT [Photo1] " & _
              " FROM [View_All_Carrier] " & _
              " WHERE [Carrier Part No] = '" & row.Item("Carrier Part No") & "'"


                Dim dt2 As DataTable = SQLConnect._SQL.Read(cb)

                If dt2 IsNot Nothing Then

                    Dim imgData As Byte() = CType(dt2.Rows(0).Item("Photo1"), Byte())
                    Dim ms As New MemoryStream(imgData)
                    Dim img As Image = Image.FromStream(ms)

                    frm_ShowPic.SHOWFULLPIC(img)

                End If




            Catch ex As Exception

            End Try
        End If
    End Sub





    Private Sub BarButtonItem3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        Call Create_show()
    End Sub

    Private Sub BarButtonItem4_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem4.ItemClick
        If DGV.SelectedRowsCount = 0 Then Exit Sub
        If DGV.SelectedRowsCount > 1 Then
            CLS_ALERT_UI.AlertInformation("Warning : You Can select one item for Edit", Color.DarkOrange, Color.White, Me.Width, 200, True, Me.Height / 2)
            Exit Sub
        End If

        If MessageBox.Show(Me, "Do you confirm to edit your selected ", "Confirm to Edit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.No Then
            Exit Sub
        End If
        'Dim zfrm As New frm_Edit_User

        'With zfrm
        '    .Getdata_LIST_TYPE_NAME()
        '    .txtEmployeeName.Text = zName
        '    .txtUserName.Text = zUserID
        '    .txtPassword.Text = zPassword
        '    .cboUserType.Text = zUserType
        '    .cmbLine.Text = zUserLine
        '    .ShowDialog()
        'End With
        Call Edit_show()
    End Sub

    Private Sub BarButtonItem6_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem6.ItemClick
        Try
            dgw1.ExportToCsv("export.csv")
            Process.Start("export.csv")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Me.Close()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub BarButtonItem7_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem7.ItemClick
        Call Getdata()
    End Sub
End Class