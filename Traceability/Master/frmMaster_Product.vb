
Imports MetroFramework
Imports System.Text
Imports System.IO
Imports System.Data.SqlClient
Public Class frmMaster_Product
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

            StrSQL.Append("select ")
            StrSQL.Append(" [f_TGRT_Code] as [TGRT Code]")
            StrSQL.Append(",[f_TGRT_Barcode] as [TGRT Barcode]")
            StrSQL.Append(",[f_Customer_Barcode] as [Customer Barcode]")
            StrSQL.Append(",[f_Part_Name] as [Part Name]")
            StrSQL.Append(",[f_Part_No] as [Part No]")
            StrSQL.Append(",[f_User_Import] as [User Import]")
            StrSQL.Append(",[f_User_Edit] as [User Edit]")
            StrSQL.Append(",Format([f_Import_TimeStamp],'dd-MM-yyyy HH:mm:ss') as [Import TimeStamp]")
            StrSQL.Append(",Format([f_Edit_TimeStamp],'dd-MM-yyyy HH:mm:ss') as [Edit TimeStamp]")
            StrSQL.Append(" From Tbl_Master_Product")
            StrSQL.Append(" Order by ID asc")

            DT = DatabaseConnection.OleDBConnect.Access.Read(StrSQL.ToString, css, False)
            dgw1.DataSource = DT

            If DGV.RowCount <= 10000 Then DGV.BestFitColumns()

            DGV.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
            DGV.OptionsSelection.MultiSelect = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GetDatatoUpdate(ByVal pForm As frmMaster_Product_EDIT)
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
            .data(7) = row.Item(7)
        End With

    End Sub

    Private Sub dgw1_DoubleClick(sender As Object, e As EventArgs)

        Call Edit_show()

    End Sub

    Private Sub DeleteData(ByVal pDATA As String)
        Try
            Dim StrSQL As New StringBuilder()

            StrSQL.Append("delete from [tbl_Master_PRODUCT] where [f_TGRT_Code]='" & pDATA & "'")
            SQLConnect._SQL.Execute(StrSQL.ToString)

            MessageBox.Show("Successfully, f_PRODUCT_Code : " & pDATA & " deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)

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

    Private Sub BarButtonItem5_ItePRODUCTlick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem5.ItemClick
        If DGV.SelectedRowsCount = 0 Then Exit Sub

        If MetroMessageBox.Show(Me, "Do you want to delete your selected ", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.No Then 'yellow
            Exit Sub
        End If

        Dim Mystring As String
        Dim xFlag_special_Delte As Boolean = False
        Dim resExecute As Boolean

        Try
            Dim view1 As DevExpress.XtraGrid.Views.Grid.GridView = dgw1.FocusedView
            Dim SB As New StringBuilder()
            Cursor = Cursors.WaitCursor
            For I = 0 To DGV.SelectedRowsCount() - 1
                Dim row As DataRowView = view1.GetRow(DGV.GetSelectedRows(I))
                SB.Remove(0, SB.Length)
                SB.Append(" DELETE FROM [tbl_Master_PRODUCT] ")
                SB.Append(" WHERE [f_TGRT_Code] ='" & row.Item(0).ToString & "' ")

                resExecute = DatabaseConnection.OleDBConnect.Access.Execute(SB.ToString, css, False)
            Next
            Cursor = Cursors.Default
            If resExecute = True Then
                CLS_ALERT_UI.AlertInformation("Delete Complete", Color.Green, Color.White, Me.Width, 200, True, Me.Height / 2)
            Else
                CLS_ALERT_UI.AlertInformation("Cannot delete product", Color.Red, Color.White, Me.Width, 200, True, Me.Height / 2)
            End If

            Call Getdata()
        Catch ex As Exception
            CLS_ALERT_UI.AlertInformation("Error : " & ex.Message & " ", Color.Red, Color.White, Me.Width, 200, True, Me.Height / 2)
        End Try
    End Sub

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

    Private Sub Edit_show()
        Dim frm As New frmMaster_PRODUCT_EDIT
        frm.Reset()
        GetDatatoUpdate(frm)
        frm.CheckCreate = False
        frm.ShowDialog()
        Getdata()
    End Sub

    Private Sub Create_show()
        Dim frm As New frmMaster_PRODUCT_EDIT
        frm.Reset()
        frm.ShowDialog()
        Getdata()
    End Sub

    Private Sub BarButtonItem3_ItePRODUCTlick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        Call Create_show()
    End Sub

    Private Sub BarButtonItem4_ItePRODUCTlick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem4.ItemClick
        If DGV.SelectedRowsCount = 0 Then Exit Sub
        If DGV.SelectedRowsCount > 1 Then
            CLS_ALERT_UI.AlertInformation("Warning : You Can select one item for Edit", Color.DarkOrange, Color.White, Me.Width, 200, True, Me.Height / 2)
            Exit Sub
        End If

        'If MessageBox.Show(Me, "Do you confirm to edit your selected ", "Confirm to Edit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.No Then
        '    Exit Sub
        'End If

        Call Edit_show()
    End Sub

    Private Sub BarButtonItem6_ItePRODUCTlick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem6.ItemClick
        Try
            dgw1.ExportToCsv("export.csv")
            Process.Start("export.csv")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Me.Close()
    End Sub

    Private Sub BarButtonItem7_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem7.ItemClick
        Dim frm As New frmImport1

        frm.pImport_Type = "PDMS"

        frm.ShowDialog()
    End Sub

    Private Sub BarButtonItem8_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem8.ItemClick
        Call Getdata()
    End Sub

    Private Sub frmMaster_Product_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class