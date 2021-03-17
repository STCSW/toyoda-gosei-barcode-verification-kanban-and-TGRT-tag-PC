Imports CommonComponent.Software
Imports CommonComponent.C_Excel
Imports DatabaseConnection.SQLConnect.SQL
Imports System.IO
Imports System.Text
Imports System.Data.SqlClient



Public Class frmImport1
    Public pImport_Type As String = "PDT"

    Private Sub frmImport1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub


    Private Sub Import_file_PDT()
        Dim DT As DataTable
        Cursor.Current = Cursors.WaitCursor


        Try

            ' Dim dig1 As OpenFileDialog
            'dig1.FileName = "import_Production*"
            'dig1.Filter = "CSV Files|*.csv"
            Dim FilesPath As String = OpenFileDialog("Csv")
            '  Dim FilesPath As String = dig1.ShowDialog

            If FilesPath.Trim = "" Then
                Cursor.Current = Cursors.Arrow
                Exit Sub
            End If

            Dim data() As String

            If File.Exists(FilesPath) Then
                Using objReader As New StreamReader(FilesPath)

                    Dim i As Integer = 0
                    While objReader.Peek() >= 0
                        Dim r As String = objReader.ReadLine()
                        ReDim Preserve data(i)
                        data(i) = r
                        i = i + 1
                    End While


                    'Dim tmpRead_data As String = objReader.ReadLine()
                    'If tmpRead_data.Trim.Length > 0 Then
                    '    'MessageBox.Show(tmpRead_data)
                    '    data_array = tmpRead_data.Split("|")
                    'End If
                End Using
            End If



            Dim Table1 As DataTable
            Table1 = New DataTable("TableName")
            Dim column1 As DataColumn = New DataColumn("Customer Code")
            Dim column2 As DataColumn = New DataColumn("PO NO.")
            Dim column3 As DataColumn = New DataColumn("Part No")
            Dim column4 As DataColumn = New DataColumn("Job No")
            Dim column5 As DataColumn = New DataColumn("Product Lot")
            Dim column6 As DataColumn = New DataColumn("Qty Order")
            Dim column7 As DataColumn = New DataColumn("Qty box of Order")
            Dim column8 As DataColumn = New DataColumn("Qty per box")
            Dim column9 As DataColumn = New DataColumn("First No box")
            Dim column10 As DataColumn = New DataColumn("Last No box")
            Dim column11 As DataColumn = New DataColumn("Satetystock(%)")
            Dim column12 As DataColumn = New DataColumn("Machine size(ton)")
            Dim column13 As DataColumn = New DataColumn("Material Code")
            Dim column14 As DataColumn = New DataColumn("Mat'l mix(%)")


            column1.DataType = System.Type.GetType("System.String")
            column2.DataType = System.Type.GetType("System.String")
            column3.DataType = System.Type.GetType("System.String")
            column4.DataType = System.Type.GetType("System.String")
            column5.DataType = System.Type.GetType("System.String")
            column6.DataType = System.Type.GetType("System.String")
            column7.DataType = System.Type.GetType("System.String")
            column8.DataType = System.Type.GetType("System.String")
            column9.DataType = System.Type.GetType("System.String")
            column10.DataType = System.Type.GetType("System.String")
            column11.DataType = System.Type.GetType("System.String")
            column12.DataType = System.Type.GetType("System.String")
            column13.DataType = System.Type.GetType("System.String")
            column14.DataType = System.Type.GetType("System.String")

            Table1.Columns.Add(column1)
            Table1.Columns.Add(column2)
            Table1.Columns.Add(column3)
            Table1.Columns.Add(column4)
            Table1.Columns.Add(column5)
            Table1.Columns.Add(column6)
            Table1.Columns.Add(column7)
            Table1.Columns.Add(column8)
            Table1.Columns.Add(column9)
            Table1.Columns.Add(column10)
            Table1.Columns.Add(column11)
            Table1.Columns.Add(column12)
            Table1.Columns.Add(column13)
            Table1.Columns.Add(column14)

            For j = 0 To data.Length - 1
                Dim data_array() As String
                data_array = data(j).Split("|")
                If data_array.Length <> "14" Then
                    Continue For
                    ' MessageBox.Show("Inccorect format Please check your file!!!.")
                    ' Return
                End If
                Dim Row1 As DataRow
                Row1 = Table1.NewRow()
                For i = 0 To 13
                    Row1.Item(i) = data_array(i)
                Next

                Table1.Rows.Add(Row1)
            Next j



            DT = Table1
            ' DT = Import_xls_To_Datatable(FilesPath)
            DT.Columns.Add("ImportStatus")
            'DT.Columns.Add("ExRemark")
            GridControl1.DataSource = DT

            '   DGV.Appearance.Row.FRONT = GridFRONT()
            '  DGV.Appearance.HeaderPanel.FRONT = GridHeaderFRONT()
            If DGV.RowCount <= 5000 Then DGV.BestFitColumns()
            SimpleButton4.Enabled = True
        Catch ex As Exception
            ' Msg("Can not Open file:" & ex.Message.ToString.Trim, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Cursor.Current = Cursors.Arrow
        End Try
        Cursor.Current = Cursors.Arrow
    End Sub

    Private Sub Import_file_PDMS()
        Dim DT As DataTable
        Cursor.Current = Cursors.WaitCursor

        Try
            Dim FilesPath As String = OpenFileDialog("*.xlsx;*.xls;*.xlsm", , , My.Settings.stLastFilePath)

            If FilesPath.Trim = "" Then
                Cursor.Current = Cursors.Arrow
                Exit Sub
            End If
            Dim directoryPath As String = Path.GetDirectoryName(FilesPath)
            My.Settings.stLastFilePath = directoryPath
            My.Settings.Save()
            Dim data_array() As String

            DT = Import_xls_To_Datatable(FilesPath)
            DT.Columns.Add("ImportStatus")
            GridControl1.DataSource = DT

            If DGV.RowCount <= 5000 Then DGV.BestFitColumns()
            SimpleButton4.Enabled = True

        Catch ex As Exception
            Cursor.Current = Cursors.Arrow
        End Try
        Cursor.Current = Cursors.Arrow
    End Sub
    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click

        Call Import_file_PDMS()

    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        Cursor.Current = Cursors.WaitCursor
        GridControl1.Enabled = False
        SimpleButton3.Enabled = False
        SimpleButton4.Enabled = False


        ' If pImport_Type = "PDT" Then
        ' Call ImportPDTMaster()
        ' ElseIf pImport_Type = "PDMS" Then
        Call ImportProductMaster()
        ' End If

        GridControl1.Enabled = True
        SimpleButton3.Enabled = True
        SimpleButton4.Enabled = True

        Cursor.Current = Cursors.Arrow
    End Sub

    Private Function SP_New_PLANNO(Optional ByVal zDate As String = "") As DataTable
        If zDate = String.Empty Then
            zDate = GetDate_now("yyyyMMdd")
        End If

        Dim query_parameters(0) As SqlParameter

        query_parameters(0) = New SqlParameter("@ScanDate", SqlDbType.NVarChar)
        query_parameters(0).Value = zDate

        Return DatabaseConnection.SQLConnect.SQL.ReadSP("sp_GET_NEW_PLAN", cs, query_parameters)


    End Function

    Private Function Check_Duplicate_JOB_NO_AND_PRODUCTION_LOT(ByVal pJOBNO As String, ByVal pPRODUCTION_LOT As String) As Boolean
        Dim StrSQL As New StringBuilder()
        Dim dt As New DataTable

        StrSQL.Append("select [f_Job_No],[f_Production_Lot]")
        StrSQL.Append(" from [tbl_Production_Plan_Master]")
        '     StrSQL.Append(" WHERE   [f_Job_No] = '" & pJOBNO & "'")
        StrSQL.Append(" WHERE   [f_Production_Lot] = '" & pPRODUCTION_LOT & "'")
        dt = SQLConnect._SQL.Read(StrSQL.ToString)
        If Not dt Is Nothing Then
            If dt.Rows.Count > 0 Then
                ' MessageBox.Show("UserID Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])

                Return True
            End If
        End If
        Return False
    End Function


    Private Function Check_DATA_PARTCODE_Product_MS(ByVal pProductCode As String) As Boolean
        Dim StrSQL As New StringBuilder()
        Dim dt As New DataTable

        StrSQL.Append("select [f_Product_Code]")
        StrSQL.Append(" from [tbl_Master_Product]")
        '     StrSQL.Append(" WHERE   [f_Job_No] = '" & pJOBNO & "'")
        StrSQL.Append(" WHERE   [f_Product_Code] = '" & pProductCode & "'")
        dt = SQLConnect._SQL.Read(StrSQL.ToString)
        If Not dt Is Nothing Then
            If dt.Rows.Count > 0 Then
                ' MessageBox.Show("UserID Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])

                Return True
            End If
        End If
        Return False
    End Function

    Private Function Check_DATA_QTY_Product_MS(ByVal pProductCode As String, ByVal pQtyperBox As Integer) As Boolean
        Dim StrSQL As New StringBuilder()
        Dim dt As New DataTable

        StrSQL.Append("select [f_Product_Code]")
        StrSQL.Append(" from [tbl_Master_Product]")
        '     StrSQL.Append(" WHERE   [f_Job_No] = '" & pJOBNO & "'")
        StrSQL.Append(" WHERE   [f_Product_Code] = '" & pProductCode & "'")
        StrSQL.Append(" and    [f_Qty_per_Box] = '" & pQtyperBox & "'")

        dt = SQLConnect._SQL.Read(StrSQL.ToString)
        If Not dt Is Nothing Then
            If dt.Rows.Count > 0 Then
                ' MessageBox.Show("UserID Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])

                Return True
            End If
        End If
        Return False
    End Function

    Private Function Check_Duplicate_Product_MS(ByVal pProductCode As String) As Boolean
        Dim StrSQL As New StringBuilder()
        Dim dt As New DataTable

        StrSQL.Append("select [f_TGRT_Code]")
        StrSQL.Append(" from [tbl_Master_Product]")
        '     StrSQL.Append(" WHERE   [f_Job_No] = '" & pJOBNO & "'")
        StrSQL.Append(" WHERE   [f_TGRT_Code] = '" & pProductCode & "'")
        dt = SQLConnect._SQL.Read(StrSQL.ToString)
        If Not dt Is Nothing Then
            If dt.Rows.Count > 0 Then
                ' MessageBox.Show("UserID Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])

                Return True
            End If
        End If
        Return False
    End Function
    Private Function ImportProductMaster() As Boolean

        Dim Errcount As Integer = 0

        If DGV.RowCount > 0 Then


            Dim tr As New DatabaseConnection.SQLConnect.Trans(cs)
            Dim Str_commad As New StringBuilder()
            PGB1.Properties.Maximum = DGV.RowCount

            Dim Arr_Duplicate_Count() As Integer
            ReDim Arr_Duplicate_Count(DGV.RowCount - 1)

            For i = 0 To DGV.RowCount - 1
                Dim view As DevExpress.XtraGrid.Views.Grid.GridView = GridControl1.FocusedView
                Dim row As DataRowView = view.GetRow(i)
                Dim Imp_Status As String

                If Imp_Status <> "OK" Then

                    Dim tmp_ProductCode As String = (row.Item(1).ToString.Trim)

                    If Check_Duplicate_Product_MS(tmp_ProductCode) = True Then

                        row.Item("ImportStatus") = "Update data"
                        Imp_Status = "Update data"

                    End If

                End If

            Next i

            For i = 0 To DGV.RowCount - 1
                Dim view As DevExpress.XtraGrid.Views.Grid.GridView = GridControl1.FocusedView
                Dim row As DataRowView = view.GetRow(i)
                PGB1.EditValue = i + 1
                Application.DoEvents()
                Dim PartType As String = ""

                Dim Imp_Status As String

                Try
                    Imp_Status = row.Item("ImportStatus").ToString.Trim
                Catch ex As Exception
                    Imp_Status = ""
                End Try

                Dim msg As String = String.Empty

                If Imp_Status = "OK" Then

                ElseIf Imp_Status = "Duplicate Data [JOB NO]" Then

                ElseIf Imp_Status = "Not sorted datetime" Then

                ElseIf Imp_Status = ", QTY OVER 10" Then

                ElseIf Imp_Status = "Update data" Then
                    Try
                        With Str_commad
                            Dim j As Integer = 2
                            'Case 1, 4, 5

                            Str_commad.Remove(0, Str_commad.Length)
                            .Append("UPDATE [dbo].[tbl_Master_Product] ")
                            .Append(" set")
                            '.Append("[f_TGRT_Code]='" & IIf(IsDBNull(row.Item(j).ToString.Trim()), "", row.Item(j).ToString.Trim) & "'")
                            ' j = j + 1
                            .Append("[f_TGRT_Barcode]=N'" & IIf(IsDBNull(row.Item(j).ToString.Trim().Replace("*", "")), "", row.Item(j).ToString.Trim.Replace("*", "")) & "'")
                            j = j + 1
                            .Append(",[f_Customer_Barcode]=N'" & IIf(IsDBNull(row.Item(j).ToString.Trim().Replace("*", "")), "", row.Item(j).ToString.Trim.Replace("*", "")) & "'")
                            j = j + 1
                            .Append(",[f_Part_Name]=N'" & IIf(IsDBNull(row.Item(j).ToString.Trim()), "", row.Item(j).ToString.Trim) & "'")
                            j = j + 1
                            .Append(",[f_Part_No]=N'" & IIf(IsDBNull(row.Item(j).ToString.Trim()), "", row.Item(j).ToString.Trim) & "'")
                            j = j + 1
                            .Append(",[f_Location]=N'" & IIf(IsDBNull(row.Item(j).ToString.Trim()), "", row.Item(j).ToString.Trim) & "'")
                            j = j + 1
                            .Append(",[f_Cut_Digit_Length]=N'" & IIf(IsDBNull(row.Item(j).ToString.Trim()), "10", row.Item(j).ToString.Trim) & "'")
                            j = j + 1

                            .Append(",[f_User_Import]=N'" & C_Variable.USER_LOGIN & "'")
                            .Append(",[f_User_Edit]=N'" & C_Variable.USER_LOGIN & "'")
                            .Append(",[f_Import_TimeStamp]=getdate()")
                            .Append(",[f_Edit_TimeStamp]=getdate()")


                            .Append(" where  [f_TGRT_Code] ='" & row.Item(1).ToString & "'")

                            row.Item("ImportStatus") = "OK"
                        End With



                        msg = tr.ExcuteTranMsg(Str_commad.ToString)
                        If msg <> "" Then
                            'If msg = String.Empty Then
                            row.Item("ImportStatus") = "Error: " & msg


                            Errcount = Errcount + 1
                        Else
                            row.Item("ImportStatus") = "OK"
                        End If

                    Catch ex As Exception

                        MessageBox.Show("Incorrect Import format " & ex.Message.ToString, "", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        tr.Rollback()
                        Cursor.Current = Cursors.Arrow
                        Return False

                    End Try
                Else
                    Try
                        With Str_commad

                            Str_commad.Remove(0, Str_commad.Length)
                            .Append("INSERT INTO [dbo].[tbl_Master_Product]")
                            .Append("(")
                            .Append("[f_TGRT_Code]")
                            .Append(",[f_TGRT_Barcode]")
                            .Append(",[f_Customer_Barcode]")
                            .Append(",[f_Part_Name]")

                            .Append(",[f_Part_No]")
                            .Append(",[f_Location]")
                            .Append(",[f_Cut_Digit_Length]")

                            .Append(",[f_User_Import]")
                            .Append(",[f_User_Edit]")
                            .Append(",[f_Import_TimeStamp]")
                            .Append(",[f_Edit_TimeStamp]")

                            .Append(" ) VALUES (")
                            'Edit เพิ่ม molder เปลี่ยน 59 >>>60 2018-07-06
                            'Edit เพิ่ม injection เปลี่ยน 60 >>>61 2018-11-15
                            For j = 1 To 7

                                Select Case j

                                    Case 0
                                        Continue For
                                    Case 1
                                        .Append(" N'" & IIf(IsDBNull(row.Item(j).ToString.Trim().Replace("\", "_").Replace("/", "_").Replace(":", "_").Replace("*", "_").Replace("?", "_").Replace("""", "_").Replace("<", "_").Replace(">", "_").Replace("|", "_")), "", row.Item(j).ToString.Trim.Replace("\", "_").Replace("/", "_").Replace(":", "_").Replace("*", "_").Replace("?", "_").Replace("""", "_").Replace("<", "_").Replace(">", "_").Replace("|", "_")) & "'")


                                    Case 2

                                        .Append(",")
                                        .Append(" N'" & IIf(IsDBNull(row.Item(j).ToString.Trim().Replace("*", "")), "", row.Item(j).ToString.Trim.Replace("*", "")) & "'")
                                    Case 3
                                        .Append(",")
                                        .Append(" N'" & IIf(IsDBNull(row.Item(j).ToString.Trim().Replace("*", "")), "", row.Item(j).ToString.Trim.Replace("*", "")) & "'")

                                    Case Else
                                        If j <> 1 Then
                                            .Append(",")
                                        End If

                                        .Append(" N'" & IIf(IsDBNull(row.Item(j).ToString.Trim()), "", row.Item(j).ToString.Trim) & "'")
                                End Select

                            Next j


                            .Append(", '" & C_Variable.USER_LOGIN & "'")
                            .Append(", '" & C_Variable.USER_LOGIN & "'")
                            .Append(", getdate()")
                            .Append(", getdate()")
                            .Append(")")
                            row.Item("ImportStatus") = "OK"
                        End With

                        msg = tr.ExcuteTranMsg(Str_commad.ToString)
                        If msg <> "" Then
                            'If msg = String.Empty Then
                            row.Item("ImportStatus") = "Error: " & msg


                            Errcount = Errcount + 1
                        Else
                            row.Item("ImportStatus") = "OK"
                        End If

                    Catch ex As Exception

                        MessageBox.Show("Incorrect Import format " & ex.Message.ToString, "", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        tr.Rollback()
                        Cursor.Current = Cursors.Arrow
                        Return False

                    End Try

                End If

            Next

            If Errcount > 0 Then

                Try

                    MessageBox.Show(Me, "Import Error, Some data can't import", "Fail.", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    'tr.Rollback()
                    tr.CommitTran(True)
                    Cursor.Current = Cursors.Arrow
                    Return False

                Catch ex As Exception

                End Try
            Else

                tr.CommitTran(True)

                MessageBox.Show(Me, "Import Success", "Success.", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

            SimpleButton4.Enabled = False
        End If
    End Function


    Private Function ImportPDTMaster() As Boolean

        Dim Errcount As Integer = 0

        If DGV.RowCount > 0 Then



            Dim tr As New DatabaseConnection.SQLConnect.Trans(cs)

            Dim Str_commad As New StringBuilder()
            PGB1.Properties.Maximum = DGV.RowCount



            'Str_commad.Append("delete from [Tbl_Plan_" & pPlan & "] where [f_Status1]='1'")
            'tr.ExcuteTran(Str_commad.ToString, False)
            'Str_commad.Append("delete from [tbl_Status_Part__" & pPlan & "_DHL] where [f_Carrier_Part_Status]+[f_DiffCase_Part_Status]+[f_Gear_Part_Status]='111'")
            'tr.ExcuteTran(Str_commad.ToString, False)
            Dim Arr_Duplicate_Count() As Integer
            ReDim Arr_Duplicate_Count(DGV.RowCount - 1)
            For i = 0 To DGV.RowCount - 1
                Dim view As DevExpress.XtraGrid.Views.Grid.GridView = GridControl1.FocusedView
                Dim row As DataRowView = view.GetRow(i)
                Dim Imp_Status As String
                If Imp_Status <> "OK" Then
                    'Dim aa As DateTime = CDate(row.Item(0).ToString.Trim()).ToString("yyyy/MM/dd ") & CDate(Format(row.Item(1).ToString.Trim("HH:mm:ss")))
                    Dim tmp_JOB_NO As String = (row.Item(3).ToString.Trim)
                    Dim tmp_PDT_LOT As String = (row.Item(4).ToString.Trim)
                    Dim tmp_PartCode As String = (row.Item(2).ToString.Trim)
                    Dim tmp_Qty_per_box As Integer = (row.Item(7).ToString.Trim)
                    'Dim cc As DateTime
                    'Dim dd As Integer


                    'For j = 0 To DGV.RowCount - 1
                    '    Dim row2 As DataRowView = view.GetRow(j)
                    '    cc = CDate(row2.Item(0).ToString.Trim()).ToString("yyyy/MM/dd ") & CDate(Format(row2.Item(1).ToString.Trim("HH:mm:ss")))
                    '    dd = CInt(row2.Item(2).ToString.Trim)

                    '    If Check_Duplicate_Internal(aa, bb, cc, dd) = True Then

                    '        Arr_Duplicate_Count(j) = Val(Arr_Duplicate_Count(j)) + 1

                    '    End If
                    'Next j

                    If Check_Duplicate_JOB_NO_AND_PRODUCTION_LOT(tmp_JOB_NO, tmp_PDT_LOT) = True Then
                        row.Item("ImportStatus") = "Duplicate Data [JOB NO],[PDT LOT]"
                        Imp_Status = "Duplicate Data [JOB NO],[PDT LOT]"
                        Errcount = Errcount + 1
                    End If

                    If Check_DATA_PARTCODE_Product_MS(tmp_PartCode) = False Then
                        row.Item("ImportStatus") = "PART CODE :" & tmp_PartCode & " NOT FOUND IN MASTER PRODUCT!!!!!!"
                        Imp_Status = "PART CODE NOT FOUND IN MASTER PRODUCT!!!"
                        Errcount = Errcount + 1
                    End If
                    If Check_DATA_QTY_Product_MS(tmp_PartCode, tmp_Qty_per_box) = False Then
                        row.Item("ImportStatus") = "QTY PER BOX :(" & tmp_Qty_per_box & ") NOT MATCH IN MASTER PRODUCT!!!!"
                        Imp_Status = "QTY PER BOX NOT MATCH IN MASTER PRODUCT!!!"


                        Errcount = Errcount + 1
                    End If




                End If

            Next i

            'For i = 0 To DGV.RowCount - 1
            '    Dim view As DevExpress.XtraGrid.Views.Grid.GridView = GridControl1.FocusedView
            '    Dim row As DataRowView = view.GetRow(i)
            '    Dim row_2 As DataRowView = view.GetRow(i + 1)
            '    Dim Imp_Status As String


            '    Dim aa As DateTime = CDate(row.Item(0).ToString.Trim()).ToString("yyyy/MM/dd ") & CDate(Format(row.Item(1).ToString.Trim("HH:mm:ss")))
            '    Dim bb As DateTime = CDate(row_2.Item(0).ToString.Trim()).ToString("yyyy/MM/dd ") & CDate(Format(row_2.Item(1).ToString.Trim("HH:mm:ss")))

            '    Dim tmp_Qty As Integer = row.Item("quantity").ToString


            '    If aa > bb Then
            '        row.Item("ImportStatus") = "Not sorted datetime"
            '        Imp_Status = "Not sorted datetime"

            '    End If

            '    If tmp_Qty > 10 Then
            '        row.Item("ImportStatus") = row.Item("ImportStatus") & ", QTY OVER 10"
            '        Imp_Status = Imp_Status & ", QTY OVER 10"
            '    End If
            '    If Imp_Status <> "" Then
            '        Errcount = Errcount + 1
            '    End If


            'Next i




            'For i = 0 To DGV.RowCount - 1
            '    If Arr_Duplicate_Count(i) > 1 Then
            '        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = GridControl1.FocusedView
            '        Dim row As DataRowView = view.GetRow(i)
            '        row.Item("ImportStatus") = "Duplicate Data [JOB NO],[PDT LOT]"
            '        Errcount = Errcount + 1
            '    End If
            'Next


            For i = 0 To DGV.RowCount - 1
                Dim view As DevExpress.XtraGrid.Views.Grid.GridView = GridControl1.FocusedView
                Dim row As DataRowView = view.GetRow(i)
                Dim dt As DataTable = SP_New_PLANNO()
                Dim pPlanNO_NEW As String = dt.Rows(0).Item(0)

                PGB1.EditValue = i + 1
                Application.DoEvents()
                Dim PartType As String = ""

                'If ComboBox1.Text = "FinishedGoods" Then
                '    PartType = "FG"
                'ElseIf ComboBox1.Text = "RawMaterial" Then
                '    PartType = "RM"
                'Else
                '    PartType = ""
                'End If


                Dim Imp_Status As String




                Try
                    Imp_Status = row.Item("ImportStatus").ToString.Trim
                Catch ex As Exception
                    Imp_Status = ""
                End Try






                If Imp_Status = "OK" Then

                ElseIf Imp_Status = "Duplicate Data [JOB NO]" Then

                ElseIf Imp_Status = "QTY PER BOX NOT MATCH IN MASTER PRODUCT!!!" Then

                ElseIf Imp_Status = "PART CODE NOT FOUND IN MASTER PRODUCT!!!" Then

                Else


                    Try


                        With Str_commad

                            Str_commad.Remove(0, Str_commad.Length)
                            .Append("INSERT INTO [dbo].[tbl_Production_Plan_Master]")
                            .Append("([f_PLAN_NO]")
                            .Append(",[f_IMPORT_DATE]")
                            .Append(",[f_Plan_Date]")
                            .Append(",[f_Customer_Code]")
                            .Append(",[f_Part_No]")
                            .Append(",[f_Job_No]")
                            .Append(",[f_Production_Lot]")
                            .Append(",[f_Material_Code]")
                            .Append(",[f_Qty_Order]")
                            .Append(",[f_Qty_box_of_order]")
                            .Append(",[f_Qty_per_Box]")
                            .Append(",[f_Po_No]")
                            .Append(",[f_SafetyStock]")
                            .Append(",[f_Machine_size]")
                            .Append(",[f_Material_Mix]")
                            .Append(",[f_Qty_Scan_Real]")
                            .Append(",[f_First_No_Box]")
                            .Append(",[f_Last_No_Box]")
                            .Append(",[f_User_Import]")
                            .Append(",[f_User_Edit]")
                            .Append(" ) VALUES (")
                            'f_PLAN_NO
                            .Append("  '" & pPlanNO_NEW & "'")
                            'f_IMPORT_DATE
                            .Append(" ,getdate()")
                            'f_Plan_Date
                            .Append(" ,getdate()")

                            'Dim column1 As DataColumn = New DataColumn("Customer Code")
                            'Dim column2 As DataColumn = New DataColumn("PO NO.")
                            'Dim column3 As DataColumn = New DataColumn("Part No")
                            'Dim column4 As DataColumn = New DataColumn("Job No")
                            'Dim column5 As DataColumn = New DataColumn("Product Lot")
                            'Dim column6 As DataColumn = New DataColumn("Qty Order")
                            'Dim column7 As DataColumn = New DataColumn("Qty box of Order")
                            'Dim column8 As DataColumn = New DataColumn("First No box")
                            'Dim column9 As DataColumn = New DataColumn("Last No box")
                            'Dim column10 As DataColumn = New DataColumn("Satetystock(%)")
                            'Dim column11 As DataColumn = New DataColumn("Machine size(ton)")
                            'Dim column12 As DataColumn = New DataColumn("Material Code")
                            'Dim column13 As DataColumn = New DataColumn("Mat'l mix(%)")
                            'f_Customer_Code
                            .Append(", N'" & IIf(IsDBNull(row.Item(0).ToString.Trim()), "", row.Item(0).ToString.Trim) & "'")
                            'f_Part_No
                            .Append(", N'" & IIf(IsDBNull(row.Item(2).ToString.Trim()), "", row.Item(2).ToString.Trim) & "'")
                            'f_Job_No()
                            .Append(", N'" & IIf(IsDBNull(row.Item(3).ToString.Trim()), "", row.Item(3).ToString.Trim) & "'")
                            'f_Production_Lot
                            .Append(", N'" & IIf(IsDBNull(row.Item(4).ToString.Trim()), "", row.Item(4).ToString.Trim) & "'")
                            'f_Material_Code
                            .Append(", N'" & IIf(IsDBNull(row.Item(12).ToString.Trim()), "", row.Item(12).ToString.Trim) & "'")
                            'f_Qty_Order
                            .Append(", N'" & IIf(IsDBNull(row.Item(5).ToString.Trim()), "", row.Item(5).ToString.Trim) & "'")
                            'f_Qty_box_of_order
                            .Append(", N'" & IIf(IsDBNull(row.Item(6).ToString.Trim()), "", row.Item(6).ToString.Trim) & "'")
                            'f_Qty_per_Box
                            .Append(", N'" & IIf(IsDBNull(row.Item(7).ToString.Trim()), "", row.Item(7).ToString.Trim) & "'")


                            'f_Po_No]")
                            .Append(", N'" & IIf(IsDBNull(row.Item(1).ToString.Trim()), "", row.Item(1).ToString.Trim) & "'")
                            'f_SafetyStock]")
                            .Append(", N'" & IIf(IsDBNull(row.Item(10).ToString.Trim()), "", row.Item(10).ToString.Trim) & "'")
                            'f_Machine_size]")
                            .Append(", N'" & IIf(IsDBNull(row.Item(11).ToString.Trim()), "", row.Item(11).ToString.Trim) & "'")
                            '[f_Material_Mix]")
                            .Append(", N'" & IIf(IsDBNull(row.Item(13).ToString.Trim()), "", row.Item(13).ToString.Trim) & "'")
                            '[f_Qty_Scan_Real]")
                            .Append(", '0'")
                            'f_First_box]")
                            .Append(", N'" & IIf(IsDBNull(row.Item(8).ToString.Trim()), "", row.Item(8).ToString.Trim) & "'")
                            '[f_Last_box]")
                            .Append(", N'" & IIf(IsDBNull(row.Item(9).ToString.Trim()), "", row.Item(9).ToString.Trim) & "'")

                            '[f_User_Import]")
                            .Append(", '" & C_Variable.USER_LOGIN & "'")
                            '[f_User_Edit]")
                            .Append(", NULL")
                            '.Append("' , '" & IIf(IsDBNull(row.Item(1).ToString.Trim), "", CDate(Format(row.Item(1).ToString.Trim("hh:mm:ss")))))
                            '.Append("' , N'" & IIf(IsDBNull(row.Item(2).ToString.Trim), "", CInt(row.Item(2).ToString.Trim)))
                            '.Append("' , N'" & seq_Target + i)
                            ''.Append("' , N'" & IIf(IsDBNull(row.Item(2).ToString.Trim), "", CInt(row.Item(2).ToString.Trim)))
                            '.Append("' , N'" & IIf(IsDBNull(row.Item(3).ToString.Trim()), "", row.Item(3).ToString.Trim))
                            '.Append("' , N'" & IIf(IsDBNull(row.Item(4).ToString.Trim()), "", row.Item(4).ToString.Trim))
                            ''.Append("' , N'" & IIf(IsDBNull(row.Item(5).ToString.Trim()), "", row.Item(5).ToString.Trim))
                            '.Append("' , N'" & IIf(IsDBNull(row.Item(6).ToString.Trim), "", CInt(row.Item(6).ToString.Trim)))
                            ' ''.Append("' , N'" & IIf(IsDBNull(row.Item(7).ToString.Trim), "", row.Item(7).ToString.Trim))
                            ''.Append("' , N'" & IIf(IsDBNull(row.Item(8).ToString.Trim), "", row.Item(8).ToString.Trim))
                            ''.Append("' , N'" & IIf(IsDBNull(row.Item(9).ToString.Trim), "", row.Item(9).ToString.Trim))
                            ''.Append("' , N'" & IIf(IsDBNull(row.Item(10).ToString.Trim()), "", row.Item(10).ToString.Trim))
                            ''.Append("' , N'" & IIf(IsDBNull(row.Item(11).ToString.Trim()), "", row.Item(11).ToString.Trim))
                            ''.Append("' , N'" & IIf(IsDBNull(row.Item(12).ToString.Trim()), "", row.Item(12).ToString.Trim))

                            '.Append("' , N'" & IIf(IsDBNull(row.Item(13).ToString.Trim()), "", Mid(row.Item(13).ToString.Trim, 1, 20)))
                            '.Append("' , '" & IIf(IsDBNull(row.Item(14).ToString.Trim()), "", CDate(row.Item(14).ToString.Trim).ToString("yyyy/MM/dd hh:mm:ss")))
                            '.Append("' , N'" & IIf(IsDBNull(row.Item(15).ToString.Trim()), "", CInt(row.Item(15).ToString.Trim)))
                            '.Append("' , N'" & IIf(IsDBNull(row.Item(16).ToString.Trim()), "", row.Item(16).ToString.Trim))
                            '' .Append("' , N'" & IIf(IsDBNull(row.Item(17).ToString.Trim()), "", row.Item(17).ToString.Trim))
                            '.Append("' , N'1'")
                            '.Append(" , N'1'")
                            ''.Append("' , N'" & IIf(IsDBNull(row.Item(18).ToString.Trim()), "", row.Item(18).ToString.Trim))
                            ''.Append("' , N'" & "0")
                            '.Append(" , N'" & "0")
                            '.Append("' , N'" & "0")
                            '.Append("' , N'" & "0")
                            '' .Append("' , N'" & DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"))
                            '' .Append("' , N'" & "TEST_ADMIN")

                            '.Append("' , N'" & DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"))
                            '.Append("' , N'" & "TEST_ADMIN")
                            '.Append("' , N'" & "TEST_ADMIN")
                            .Append(")")
                            row.Item("ImportStatus") = "OK"
                        End With




                        If DatabaseConnection.SQLConnect.SQL.Execute(Str_commad.ToString, cs, False) = False Then
                            '  If tr.ExcuteTran(Str_commad.ToString, False) = False Then

                            row.Item("ImportStatus") = "Error"

                            Errcount = Errcount + 1

                        Else
                            row.Item("ImportStatus") = "OK"


                        End If



                    Catch ex As Exception

                        MessageBox.Show("Incorrect Import format " & ex.Message.ToString, "", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        ' tr.Rollback()
                        Cursor.Current = Cursors.Arrow
                        Return False

                    End Try




                End If

            Next


            If Errcount > 0 Then


                MessageBox.Show(Me, "Import Error, Some data can't import", "Fail.", MessageBoxButtons.OK, MessageBoxIcon.Error)

                '    tr.Rollback()
                Cursor.Current = Cursors.Arrow
                Return False

            Else

                tr.CommitTran(True)


                MessageBox.Show(Me, "Import Success", "Success.", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

            SimpleButton4.Enabled = False
            ' GridControl1.DataSource = Nothing


        End If


    End Function
End Class