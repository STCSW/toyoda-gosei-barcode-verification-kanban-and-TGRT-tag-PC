
Imports System.Data.SqlClient
Imports DevExpress.XtraCharts
Imports System.Text
Imports DevExpress.Utils
Imports DevExpress.XtraGrid.Views.Grid

Public Class Uc_Report_BarcodeVerification
    Private str_msg As String


    Private Sub GridView_CustomDrawRowIndicator2(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs)

        If e.RowHandle + 1 > 0 Then e.Info.DisplayText = e.RowHandle + 1

    End Sub

    Private Sub GridView2_ShowFilterPopupListBox(ByVal sender As Object, ByVal e As _
 DevExpress.XtraGrid.Views.Grid.FilterPopupListBoxEventArgs)

        e.ComboBox.AppearanceDropDown.Font = New Font("Tahoma", 10)
    End Sub
    Private Sub uc_ProductionPlan_Load(sender As Object, e As EventArgs) Handles Me.Load
        DateEdit1.EditValue = Now.AddMonths(-1)
        DateEdit2.EditValue = Now
    End Sub



    Private Function getdata() As Boolean
        Try

            Dim sb As New StringBuilder
            sb.Append("Select")
            sb.Append(" [f_Scan_TimeStamp] as [Scan TimeStamp]")
            sb.Append(" ,[f_TGRT_Barcode] as [TGRT_Barcode]")
            sb.Append(" ,[f_Customer_Barcode] as [Customer Barcode]")
            sb.Append(" ,[f_Transaction_Status] as [Transaction Status]")
            sb.Append(" ,[f_TGRT_Code] as [TGRT Code]")
            sb.Append(" ,[f_Part_Name] as [Part Name]")
            sb.Append(" ,[f_Part_No] as [Part No]")
            sb.Append(" ,[f_User_Scan] as [User Scan]")
            sb.Append(" From tbl_Transaction")
            sb.Append(" Where [f_Scan_TimeStamp] >= #" & CDate(DateEdit1.EditValue).ToString("dd-MM-yyyy") & " 00:00:00" & "#")
            sb.Append(" and [f_Scan_TimeStamp] <= #" & CDate(DateEdit2.EditValue).ToString("dd-MM-yyyy") & " 23:59:59" & "#")
            sb.Append(" Order by [f_Scan_TimeStamp] desc")

            Dim DT As DataTable = DatabaseConnection.OleDBConnect.Access.Read(sb.ToString(), css, True)

            DGW.DataSource = DT
            dgv.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
            dgv.OptionsSelection.MultiSelect = True

            If DT IsNot Nothing Then

                For i = 0 To DT.Columns.Count - 1

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
            dgv.ExportToXls("Export.xls")
            Process.Start("Export.xls")
        Catch ex As Exception

        End Try
    End Sub


    Function getdata_CHART() As DataTable
        Dim Str_commad As New StringBuilder()

        Dim query_parameters(1) As SqlParameter
        query_parameters(0) = New SqlParameter("@StartDate", SqlDbType.NVarChar)
        query_parameters(0).Value = CDate(DateEdit1.EditValue).ToString("yyyy-MM-dd")
        query_parameters(1) = New SqlParameter("@EndDate", SqlDbType.NVarChar)
        query_parameters(1).Value = CDate(DateEdit2.EditValue).AddDays(1).ToString("yyyy-MM-dd")

        Dim DT As DataTable = DatabaseConnection.SQLConnect.SQL.ReadSP("sp_GET_REPORT_LOG_SCAN", cs, query_parameters)

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



    Private Sub DGW_Click(sender As Object, e As EventArgs) Handles DGW.Click

    End Sub

    Private Sub dgv_RowCellStyle(sender As Object, e As RowCellStyleEventArgs) Handles dgv.RowCellStyle
        Dim View As GridView = sender
        If e.Column.FieldName = "Status" Then

            Dim category As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Status"))
            e.Appearance.ForeColor = Color.Black
            Select Case category

                Case "NG"
                    e.Appearance.BackColor = Color.Red

                Case "OK"
                    e.Appearance.BackColor = Color.MediumSpringGreen

            End Select
        End If
    End Sub
End Class
