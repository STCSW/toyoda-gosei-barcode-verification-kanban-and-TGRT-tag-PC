Imports System.Data.SqlClient
Imports DevExpress.XtraCharts
Imports System.Text
Imports DevExpress.Utils

Public Class Uc_Report_PrintLabel
    Private str_msg As String


    Private Sub GridView_CustomDrawRowIndicator2(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs)


        If e.RowHandle + 1 > 0 Then e.Info.DisplayText = e.RowHandle + 1

    End Sub

    Private Sub GridView2_ShowFilterPopupListBox(ByVal sender As Object, ByVal e As _
 DevExpress.XtraGrid.Views.Grid.FilterPopupListBoxEventArgs)


        e.ComboBox.AppearanceDropDown.Font = New Font("Tahoma", 10)
        'e.ComboBox.AppearanceDropDown.ForeColor = Color.Blue
    End Sub
    Private Sub uc_ProductionPlan_Load(sender As Object, e As EventArgs) Handles Me.Load
        DateEdit1.EditValue = Now.AddMonths(-1)
        DateEdit2.EditValue = Now
    End Sub



    Private Function getdata() As Boolean
        Try


            Dim query_parameters(1) As SqlParameter
            query_parameters(0) = New SqlParameter("@StartDate", SqlDbType.NVarChar)
            query_parameters(0).Value = CDate(DateEdit1.EditValue).ToString("yyyy-MM-dd")
            query_parameters(1) = New SqlParameter("@EndDate", SqlDbType.NVarChar)
            query_parameters(1).Value = CDate(DateEdit2.EditValue).AddDays(1).ToString("yyyy-MM-dd")

            Dim DT As DataTable = DatabaseConnection.SQLConnect.SQL.ReadSP("sp_GET_REPORT_LOG_PRINT", cs, query_parameters)

            DGW.DataSource = DT
            dgv.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
            dgv.OptionsSelection.MultiSelect = True
            'Call get_CHART()
            If DT IsNot Nothing Then

                'DGV2.Columns("PlanQty").DisplayFormat.FormatType = FormatType.Numeric
                'DGV2.Columns("PlanQty").DisplayFormat.FormatString = "#,##0"
                'DGV2.Columns("ScanQty").DisplayFormat.FormatType = FormatType.Numeric
                'DGV2.Columns("ScanQty").DisplayFormat.FormatString = "#,##0"
                'DGV2.Columns("Remain").DisplayFormat.FormatType = FormatType.Numeric
                'DGV2.Columns("Remain").DisplayFormat.FormatString = "#,##0"

                'If DT.Rows.Count > 0 Then
                '    getdataPlanDetail(DT.Rows(0).Item("Plan No").ToString)
                'End If

                'DGV2.ClearGrouping()
                'DGV2.Columns(8).GroupIndex = 0
                'DGV2.OptionsSelection.ShowCheckBoxSelectorInGroupRow = DefaultBoolean.True

                For i = 0 To DT.Columns.Count - 1
                    ' MessageBox.Show(DGV.Columns(i).ColumnType.ToString)

                    Dim str_Contains As String = dgv.Columns(i).FieldName

                    If (dgv.Columns(i).ColumnType.ToString) = "System.DateTime" Or str_Contains.Contains("date") = True Or str_Contains = "Time" Then
                        dgv.Columns(i).DisplayFormat.FormatType = FormatType.DateTime
                        dgv.Columns(i).DisplayFormat.FormatString = "dd-MMM-yyyy HH:mm:ss"
                    End If


                Next i
                dgv.BestFitColumns()

                Return True

            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try

    End Function

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Call getdata()

    End Sub

    Private Sub DateEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles DateEdit1.EditValueChanged
        Call getdata()

    End Sub

    Private Sub DateEdit2_EditValueChanged(sender As Object, e As EventArgs) Handles DateEdit2.EditValueChanged
        Call getdata()

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Try
            'dgv2.ExportToXls("Export.xls")
            'Process.Start("Export.xls")
            dgv.ExportToXls("Export.xls")
            Process.Start("Export.xls")
        Catch ex As Exception

        End Try
    End Sub


    Function getdata_CHART() As DataTable
        Dim Str_commad As New StringBuilder()
        'Str_commad.Append("select ")
        'Str_commad.Append("[f_Product_Code] as 'Product Code' ")

        '' Str_commad.Append(",SUM(f_Qty_Per_Box) as 'QTY PRODUCTION' ")
        'Str_commad.Append(",100 as 'QTY PRODUCTION' ")

        ''    FROM [dbTraceability].[dbo].[tbl_Sticker_Serial_Log]

        'Str_commad.Append("FROM [dbo].[tbl_Sticker_Serial_Log] ")
        'Str_commad.Append("	where [f_Product_Code] ='840233'")
        'Str_commad.Append(" group by [f_Product_Code] ")

        'Str_commad.Append("SELECT *,T1.[QTY PRODUCTION]*100.0 /T1.[TOTAL PRODUCTION] AS'PERCENT' FROM (")
        'Str_commad.Append("select ")
        'Str_commad.Append("[f_Product_Code] as 'Product Code'")
        'Str_commad.Append(",SUM(f_Qty_Per_Box) as 'QTY PRODUCTION'")
        'Str_commad.Append(",(select TOP 1 SUM(f_Qty_Per_Box)  FROM [tbl_Sticker_Serial_Log] WHERE f_Scan_IN_timestamp >= '2018-10-14 00:00:00'")
        'Str_commad.Append(" AND f_Scan_IN_timestamp <= '2018-10-16 00:00:00') AS 'TOTAL PRODUCTION'")
        'Str_commad.Append("    FROM [dbTraceability].[dbo].[tbl_Sticker_Serial_Log]")

        'Str_commad.Append("WHERE f_Scan_IN_timestamp >= '2018-10-14 00:00:00'")
        'Str_commad.Append(" AND f_Scan_IN_timestamp <= '2018-10-16 00:00:00'")
        'Str_commad.Append("	  group by [f_Product_Code]")
        'Str_commad.Append("	  ) T1")
        '    Dim DT As DataTable = DatabaseConnection.SQLConnect.SQL.ReadSP("sp_GET_REPORT_IN_DAILY", cs, query_parameters)

        Dim query_parameters(1) As SqlParameter
        query_parameters(0) = New SqlParameter("@StartDate", SqlDbType.NVarChar)
        query_parameters(0).Value = CDate(DateEdit1.EditValue).ToString("yyyy-MM-dd")
        query_parameters(1) = New SqlParameter("@EndDate", SqlDbType.NVarChar)
        query_parameters(1).Value = CDate(DateEdit2.EditValue).AddDays(1).ToString("yyyy-MM-dd")

        Dim DT As DataTable = DatabaseConnection.SQLConnect.SQL.ReadSP("sp_GET_REPORT_LOG_PRINT", cs, query_parameters)

        Return DT




    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click

    End Sub

    Private Sub get_CHART()
        Panel1.Controls.Clear()
        Dim dt As New DataTable
        dt = getdata_CHART()
        '   GridControl1.DataSource = dt
        Dim pieChart As New ChartControl()
        Dim series1 As New Series("PART PRODUCTION ", ViewType.Pie)
        For Each dr As DataRow In dt.Rows
            series1.Points.Add(New SeriesPoint(dr("Product Code"), dr("PERCENT"), dr("QTY PRODUCTION")))
        Next

        pieChart.Series.Add(series1)
        series1.Label.TextPattern = "{A}: {VP:p3}"


        CType(series1.Label, PieSeriesLabel).Position = PieSeriesLabelPosition.TwoColumns
        CType(series1.Label, PieSeriesLabel).ResolveOverlappingMode = ResolveOverlappingMode.Default
        Dim myView As PieSeriesView = CType(series1.View, PieSeriesView)
        myView.Titles.Add(New SeriesTitle())
        myView.Titles(0).Text = series1.Name
        myView.ExplodeMode = PieExplodeMode.UseFilters
        myView.ExplodedDistancePercentage = 30
        myView.RuntimeExploding = True
        myView.HeightToWidthRatio = 0.75
        pieChart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True
        pieChart.Legend.AlignmentVertical = LegendAlignmentVertical.Center
        pieChart.Dock = DockStyle.Fill
        Panel1.Controls.Add(pieChart)
        pieChart.AnimationStartMode = ChartAnimationMode.OnLoad

    End Sub
End Class
