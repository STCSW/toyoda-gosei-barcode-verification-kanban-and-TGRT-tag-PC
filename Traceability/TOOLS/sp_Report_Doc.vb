Imports System.Text

Public Class sp_Report_Doc
    Dim DATA_DT As DataTable


    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        'Dim StrSQL As New StringBuilder()
        'StrSQL.Append(" SELECT  [Shipment_no]")
        'StrSQL.Append(" ,[Material]")
        'StrSQL.Append(" ,[Description]")
        'StrSQL.Append(" ,[QTY]")
        'StrSQL.Append("  FROM [dbGoodYear_AviationTire].[dbo].[View_Get_All_Pickinglist_NEW_TIRE]")
        ''StrSQL.Append(" where Shipment_no in (" & TextBox2.Text & ")")

        'DATA_DT = New DataTable
        'DATA_DT = DatabaseConnection.SQLConnect.SQL.Read(StrSQL.ToString, cs)
        'Dim rpt As New rptShipment_NEWTire
        ''đỗ dataser vào report
        'rpt.DataSource = DATA_DT
        'rpt.DataMember = DATA_DT.TableName
        ''Hiện thì report lên ocumentViewer
        'DocumentViewer1.PrintingSystem = rpt.PrintingSystem
        'rpt.CreateDocument(True)
    End Sub
End Class