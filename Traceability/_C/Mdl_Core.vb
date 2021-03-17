Imports System.IO
Imports System.Text
Imports System.Data.SqlClient

Module Mdl_Core
    Private zClassName As String = "Mdl_Core"
    Private zFunctionName As String
    Public Function GetDate_now(ByVal pFormat As String) As String
        Dim zDateStr As String
        zDateStr = Now.ToString(pFormat)
        Return zDateStr
    End Function

    Public Sub WriteVarRow(ByVal zFunction As String, ByVal zRowcount As String)

        Dim zFileName As String
        zFileName = GetPathVarRowEvent()

        If Not Directory.Exists(zFileName) Then
            Directory.CreateDirectory(zFileName)
        End If
        zFileName += "\VarRow_" & zFunction & ".txt"

        Dim SB As New StringBuilder
        SB.Remove(0, SB.Length)

        SB.Append(zRowcount)


        Using zStream As New StreamWriter(zFileName, False)
            zStream.WriteLine(SB.ToString)
        End Using

    End Sub

  
    Public Function GetPathSoundSiren() As String
        Dim zPath As String
        'zPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.GetName.CodeBase)
        zPath = My.Application.Info.DirectoryPath
        zPath += "\siren.wav"
        Return zPath
    End Function

    Public Function GetPathVarRowEvent() As String
        Dim zPath As String
        'zPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.GetName.CodeBase)
        zPath = My.Application.Info.DirectoryPath
        zPath += "\VarRow"
        Return zPath
    End Function

  



    Public Function GetPathAllSettingEvent() As String
        Dim zPath As String
        zPath = Application.StartupPath
        zPath += "\AllSetting_ini"
        Return zPath
    End Function


    Public Sub UpdateConfig_Ini()
        Dim file_Setting As String = C_Variable._file_path_setting_DB

        If Not IO.File.Exists(file_Setting) Then

            Using strm_Data As StreamWriter = New StreamWriter(file_Setting, False)
                Dim Encoding_password As String
                Encoding_password = CommonComponent.ENCRYP.Encoding(My.Settings.Password_DB, "1234")

                strm_Data.Write(My.Settings.Server & ";")
                strm_Data.Write(My.Settings.Database & ";")
                strm_Data.Write(My.Settings.Username_DB & ";")
                '  strm_Data.Write(My.Settings.Password_DB & ";")
                strm_Data.Write(Encoding_password & ";")
                strm_Data.Write(My.Settings.Timeout & ";")
                'strm_Data.WriteLine(My.Settings.Server & ";")
                'strm_Data.WriteLine(My.Settings.Database & ";")
                'strm_Data.WriteLine(My.Settings.Username_DB & ";")
                'strm_Data.WriteLine(My.Settings.Password_DB & ";")
                'strm_Data.WriteLine(My.Settings.Timeout & ";")
            End Using
        Else
            File.Delete(file_Setting)
            Using strm_Data As StreamWriter = New StreamWriter(file_Setting, False)
                Dim Encoding_password As String
                Encoding_password = CommonComponent.ENCRYP.Encoding(My.Settings.Password_DB, "1234")
                strm_Data.Write(My.Settings.Server & ";")
                strm_Data.Write(My.Settings.Database & ";")
                strm_Data.Write(My.Settings.Username_DB & ";")
                ' strm_Data.Write(My.Settings.Password_DB & ";")
                strm_Data.Write(Encoding_password & ";")
                strm_Data.Write(My.Settings.Timeout & ";")
            End Using
        End If
    End Sub

    Public Sub UpdateConfig_Ini_folder_Picture1()
        Dim file_Setting As String = C_Variable._file_path_setting_Folder_Picture1

        If Not IO.File.Exists(file_Setting) Then

            Using strm_Data As StreamWriter = New StreamWriter(file_Setting, False)

                strm_Data.Write(Application.StartupPath & "\Picture1\")

            End Using
        Else
            File.Delete(file_Setting)
            Using strm_Data As StreamWriter = New StreamWriter(file_Setting, False)

                strm_Data.Write(My.Settings.PATH_FOLDER_PIC1)

            End Using
        End If
    End Sub

    Public Sub UpdateConfig_Ini_folder_Picture2()
        Dim file_Setting As String = C_Variable._file_path_setting_Folder_Picture2

        If Not IO.File.Exists(file_Setting) Then

            Using strm_Data As StreamWriter = New StreamWriter(file_Setting, False)

                strm_Data.Write(Application.StartupPath & "\Picture2\")

            End Using
        Else
            File.Delete(file_Setting)
            Using strm_Data As StreamWriter = New StreamWriter(file_Setting, False)

                strm_Data.Write(My.Settings.PATH_FOLDER_PIC2)

            End Using
        End If
    End Sub

    Public Sub UpdateConfig_Ini_folder_Picture1_zoom()
        Dim file_Setting As String = C_Variable._file_path_setting_Folder_Picture1_Zoom

        If Not IO.File.Exists(file_Setting) Then

            Using strm_Data As StreamWriter = New StreamWriter(file_Setting, False)

                strm_Data.Write(Application.StartupPath & "\Picture1_Zoom\")

            End Using
        Else
            File.Delete(file_Setting)
            Using strm_Data As StreamWriter = New StreamWriter(file_Setting, False)

                strm_Data.Write(My.Settings.PATH_FOLDER_PIC1_ZOOM)

            End Using
        End If
    End Sub

    Public Sub UpdateConfig_Ini_folder_Picture2_zoom()
        Dim file_Setting As String = C_Variable._file_path_setting_Folder_Picture2_Zoom

        If Not IO.File.Exists(file_Setting) Then

            Using strm_Data As StreamWriter = New StreamWriter(file_Setting, False)

                strm_Data.Write(Application.StartupPath & "\Picture2_Zoom\")

            End Using
        Else
            File.Delete(file_Setting)
            Using strm_Data As StreamWriter = New StreamWriter(file_Setting, False)

                strm_Data.Write(My.Settings.PATH_FOLDER_PIC2_ZOOM)

            End Using
        End If
    End Sub

    Public Sub UpdateConfig_Ini_Count_CutDigit()
        Dim file_Setting As String = C_Variable._file_path_setting_Count_CutDigit

        If Not IO.File.Exists(file_Setting) Then

            Using strm_Data As StreamWriter = New StreamWriter(file_Setting, False)

                strm_Data.Write(10)

            End Using
        Else
            File.Delete(file_Setting)
            Using strm_Data As StreamWriter = New StreamWriter(file_Setting, False)

                strm_Data.Write(My.Settings.Count_CutDigit)

            End Using
        End If
    End Sub

    Public Sub UpdateConfig_Ini_MRP()
        Dim file_Setting As String = C_Variable._file_path_setting_DB_MRP

        If Not IO.File.Exists(file_Setting) Then

            Using strm_Data As StreamWriter = New StreamWriter(file_Setting, False)
                Dim Encoding_password As String
                Encoding_password = CommonComponent.ENCRYP.Encoding(My.Settings.Password_DB_MRP, "1234")

                strm_Data.Write(My.Settings.Server_MRP & ";")
                strm_Data.Write(My.Settings.Database_MRP & ";")
                strm_Data.Write(My.Settings.Username_DB_MRP & ";")
                '  strm_Data.Write(My.Settings.Password_DB & ";")
                strm_Data.Write(Encoding_password & ";")
                strm_Data.Write(My.Settings.Timeout_MRP & ";")
                'strm_Data.WriteLine(My.Settings.Server & ";")
                'strm_Data.WriteLine(My.Settings.Database & ";")
                'strm_Data.WriteLine(My.Settings.Username_DB & ";")
                'strm_Data.WriteLine(My.Settings.Password_DB & ";")
                'strm_Data.WriteLine(My.Settings.Timeout & ";")
            End Using
        Else
            File.Delete(file_Setting)
            Using strm_Data As StreamWriter = New StreamWriter(file_Setting, False)
                Dim Encoding_password As String
                Encoding_password = CommonComponent.ENCRYP.Encoding(My.Settings.Password_DB_MRP, "1234")
                strm_Data.Write(My.Settings.Server_MRP & ";")
                strm_Data.Write(My.Settings.Database_MRP & ";")
                strm_Data.Write(My.Settings.Username_DB_MRP & ";")
                ' strm_Data.Write(My.Settings.Password_DB & ";")
                strm_Data.Write(Encoding_password & ";")
                strm_Data.Write(My.Settings.Timeout_MRP & ";")
            End Using
        End If
    End Sub

    Public Sub Check_ini_DB_File()
        Dim zFileName As String
        zFileName = GetPathAllSettingEvent()
        If Not Directory.Exists(zFileName) Then
            Directory.CreateDirectory(zFileName)
        End If

        If Not File.Exists(C_Variable._file_path_setting_DB) Then
            File.Create(C_Variable._file_path_setting_DB).Dispose()
            Call UpdateConfig_Ini()
        End If

        If Not File.Exists(C_Variable._file_path_setting_Folder_Picture1) Then
            '  File.Create(C_Variable._file_path_setting_Folder_Picture1).Dispose()
            Call UpdateConfig_Ini_folder_Picture1()
        End If

        If Not File.Exists(C_Variable._file_path_setting_Folder_Picture1_Zoom) Then
            ' File.Create(C_Variable._file_path_setting_Folder_Picture1_Zoom).Dispose()
            Call UpdateConfig_Ini_folder_Picture1_zoom()
        End If

        If Not File.Exists(C_Variable._file_path_setting_Folder_Picture2) Then
            ' File.Create(C_Variable._file_path_setting_Folder_Picture2).Dispose()
            Call UpdateConfig_Ini_folder_Picture2()
        End If

        If Not File.Exists(C_Variable._file_path_setting_Folder_Picture2_Zoom) Then
            '   File.Create(C_Variable._file_path_setting_Folder_Picture2_Zoom).Dispose()
            Call UpdateConfig_Ini_folder_Picture2_zoom()
        End If

        If Not File.Exists(C_Variable._file_path_setting_Count_CutDigit) Then
            File.Create(C_Variable._file_path_setting_Count_CutDigit).Dispose()
            Call UpdateConfig_Ini_Count_CutDigit()
        End If

        If File.Exists(C_Variable._file_path_setting_DB) Then
            Using objReader As New StreamReader(C_Variable._file_path_setting_DB)
                Dim tmpRead_data As String = objReader.ReadLine()
                If tmpRead_data.Trim.Length > 0 Then
                    Dim tmp_Arr() As String
                    tmp_Arr = tmpRead_data.Split(";")
                    My.Settings.Server = tmp_Arr(0)
                    My.Settings.Database = tmp_Arr(1)
                    My.Settings.Username_DB = tmp_Arr(2)
                    '  My.Settings.Password_DB = tmp_Arr(3)
                    My.Settings.Password_DB = CommonComponent.ENCRYP.Decoding(tmp_Arr(3), "1234")
                    My.Settings.Timeout = tmp_Arr(4)
                    My.Settings.Save()

                End If
            End Using
        End If
        If File.Exists(C_Variable._file_path_setting_Folder_Picture1) Then
            Using objReader As New StreamReader(C_Variable._file_path_setting_Folder_Picture1)
                Dim tmpRead_data As String = objReader.ReadLine()
                If tmpRead_data.Trim.Length > 0 Then
                    Dim tmp_Arr() As String
                    tmp_Arr = tmpRead_data.Split(";")
                    My.Settings.PATH_FOLDER_PIC1 = tmp_Arr(0)
                    My.Settings.Save()

                End If
            End Using
        End If

        If File.Exists(C_Variable._file_path_setting_Folder_Picture1_Zoom) Then
            Using objReader As New StreamReader(C_Variable._file_path_setting_Folder_Picture1_Zoom)
                Dim tmpRead_data As String = objReader.ReadLine()
                If tmpRead_data.Trim.Length > 0 Then
                    Dim tmp_Arr() As String
                    tmp_Arr = tmpRead_data.Split(";")
                    My.Settings.PATH_FOLDER_PIC1_ZOOM = tmp_Arr(0)
                    My.Settings.Save()

                End If
            End Using
        End If

        If File.Exists(C_Variable._file_path_setting_Folder_Picture2_Zoom) Then
            Using objReader As New StreamReader(C_Variable._file_path_setting_Folder_Picture2_Zoom)
                Dim tmpRead_data As String = objReader.ReadLine()
                If tmpRead_data.Trim.Length > 0 Then
                    Dim tmp_Arr() As String
                    tmp_Arr = tmpRead_data.Split(";")
                    My.Settings.PATH_FOLDER_PIC2_ZOOM = tmp_Arr(0)
                    My.Settings.Save()

                End If
            End Using
        End If

        If File.Exists(C_Variable._file_path_setting_Folder_Picture2) Then
            Using objReader As New StreamReader(C_Variable._file_path_setting_Folder_Picture2)
                Dim tmpRead_data As String = objReader.ReadLine()
                If tmpRead_data.Trim.Length > 0 Then
                    Dim tmp_Arr() As String
                    tmp_Arr = tmpRead_data.Split(";")
                    My.Settings.PATH_FOLDER_PIC2 = tmp_Arr(0)
                    My.Settings.Save()

                End If
            End Using
        End If
        If File.Exists(C_Variable._file_path_setting_Count_CutDigit) Then
            Using objReader As New StreamReader(C_Variable._file_path_setting_Count_CutDigit)
                Dim tmpRead_data As String = objReader.ReadLine()
                If tmpRead_data.Trim.Length > 0 Then
                    Dim tmp_Arr() As String
                    tmp_Arr = tmpRead_data.Split(";")
                    My.Settings.Count_CutDigit = tmp_Arr(0)
                    My.Settings.Save()

                End If
            End Using
        End If





    End Sub

    Public Sub Check_ini_DB_File_MRP()
        Dim zFileName As String
        zFileName = GetPathAllSettingEvent()
        If Not Directory.Exists(zFileName) Then
            Directory.CreateDirectory(zFileName)
        End If

        If Not File.Exists(C_Variable._file_path_setting_DB_MRP) Then
            File.Create(C_Variable._file_path_setting_DB_MRP).Dispose()
            Call UpdateConfig_Ini_MRP()
        End If

        If File.Exists(C_Variable._file_path_setting_DB_MRP) Then
            Using objReader As New StreamReader(C_Variable._file_path_setting_DB_MRP)
                Dim tmpRead_data As String = objReader.ReadLine()
                If tmpRead_data.Trim.Length > 0 Then
                    Dim tmp_Arr() As String
                    tmp_Arr = tmpRead_data.Split(";")
                    My.Settings.Server_MRP = tmp_Arr(0)
                    My.Settings.Database_MRP = tmp_Arr(1)
                    My.Settings.Username_DB_MRP = tmp_Arr(2)
                    '  My.Settings.Password_DB = tmp_Arr(3)
                    My.Settings.Password_DB_MRP = CommonComponent.ENCRYP.Decoding(tmp_Arr(3), "1234")
                    My.Settings.Timeout_MRP = tmp_Arr(4)
                    My.Settings.Save()


                End If
            End Using
        End If



    End Sub




    Public Function Get_Prefix_ProductionLot() As String
        Return "CXF"
    End Function

    Public Function Get_Month_Current_2_digit() As String
        Dim tmp_Str As String
        tmp_Str = Now.ToString("MM")
        Return tmp_Str
    End Function

    Public Function Get_Year_Current_1_digit() As String
        Dim tmp_Str As String
        tmp_Str = Now.ToString("yyyy")
        tmp_Str = Mid(tmp_Str, 4, 1)
        Return tmp_Str
    End Function


    Public Function WriteTextWithDataTable_ForPrint(ByVal zDatatable As DataTable, ByVal pType As Integer) As Boolean
        Try
            Dim zFileName, xCsvFileName As String
            Dim FTP_TYPE As Boolean = False
            '   Dim DT As DataTable = GetSetting()
            Dim Path_Target_Files As String




            zFileName = GetPathPrintEvent()
            If Not Directory.Exists(zFileName) Then
                Directory.CreateDirectory(zFileName)
            End If
            Select Case pType
                Case 1 'Final_serial_type
                    '  xCsvFileName = "\Genpinhyo_STOCK_" & DateTime.Now.ToString("yyyyMMddhhmmss") & ".csv"
                    zFileName += "\Final_" & zDatatable.Rows(0).Item("f_code") & "_" & zDatatable.Rows(0).Item("Model_Name") & "_" & DateTime.Now.ToString("yyyyMMdd_HHmmssfff") & ".csv"
                Case 2 'PD_CARD
                    'zFileName += "\PD_" & zDatatable.Rows(0).Item("f_code") & "_" & zDatatable.Rows(0).Item("Model_Name") & "_" & DateTime.Now.ToString("yyyyMMdd_HHmmssfff") & ".csv"
                    zFileName += "\PD__" & DateTime.Now.ToString("yyyyMMdd_HHmmssfff") & ".csv"

            End Select






            zFileName += xCsvFileName


            Dim SB As New StringBuilder


            For Each row As DataRow In zDatatable.Rows
                Dim array() As Object = row.ItemArray
                SB.Remove(0, SB.Length)
                For i = 0 To array.Length - 1
                    SB.Append("""" & array(i).ToString() & """" & ",")
                Next
                'SB.Append("""" & Printer_Name & """")
                'SB.Append(",")
                'SB.Append("""" & pTotalPrint & """")
                Using zStream As New StreamWriter(zFileName, True)
                    zStream.WriteLine(SB.ToString)
                End Using

            Next



            'If C_Transfer_File.Move_File(Path_Target_Files, xCsvFileName, GetPathPrintEvent()) = False Then
            '    Return False
            'End If

            Return True

        Catch ex As Exception

            Call WriteErrorLog("Mdl_Core", "WriteTextWithDataTable", ex.Message)

        End Try
    End Function

    Public Function GetPathPrintEvent() As String
        Dim zPath As String
        ' zPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.GetName.CodeBase)

        zPath = My.Application.Info.DirectoryPath
        zPath += "\PathPrintEvent"
        Return zPath
    End Function


    Public Function Check_Status_Printer(ByVal pIp As String, ByVal pPort As String) As String
        Return "," & "True"
        Try
            zFunctionName = "Check_Status_Printer"
            Dim Printer_Name As String
            Dim msg_result As String
            'Dim data(2) As String
            'data(0) = ""  'printer name
            'data(1) = ""  'printer ip
            'data(2) = ""  'printer port



            Cursor.Current = Cursors.WaitCursor
            C_Variable.var_Status_Printer = String.Empty
            Dim zfrm As New FrmCheck_Status_Printer(pIp, pPort)
            ' Dim zfrm As New FrmCheck_Status_Printer(data(1), data(2))
            zfrm.ShowDialog()
            Cursor.Current = Cursors.Default


            Select Case C_Variable.var_Status_Printer 'CL4NX
                ',"G","H","I","J","%","&","'","(","M","N","O","P",")","*","+",
                'Case "M"
                '    msg_result = "Printer is not ready, Please Detach Sticker.(" & C_Variable.var_Status_Printer & ")".ToString
                '    Return (msg_result & "," & "False")

                Case "M", "A", "B", "C", "D", "!", """", "#", "$", "G", "H", "I", "J", "%", "&", "'", "(", "N", "O", "P", ")", "*", "+", ",", "S", "T", "U", "V", "-", ".", "/", "@"

                    Return (msg_result & "," & "True")
                    ' Return True
                Case "0", "1", "2", "3", "5", "6", "7", "8"
                    'CLS_ALERT_UI.AlertInformation("Printer offline.(" & C_Variable.var_Status_Printer & ")".ToString, Color.Red, Color.Black, 240, 400, True)
                    msg_result = "Printer offline.(" & C_Variable.var_Status_Printer & ")".ToString
                    Return (msg_result & "," & "False")
                    'Case "h"
                    '    CLS_ALERT_UI.AlertInformation("printer cutter is open.".ToString, Color.Red, Color.Black, 240, 400, True)
                    '    Return False
                    'Case "b"
                    '    CLS_ALERT_UI.AlertInformation("printer head is open.".ToString, Color.Red, Color.Black, 240, 400, True)
                    '    Return False
                Case "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "o", "p", "q"
                    '  CLS_ALERT_UI.AlertInformation("printer is error.(" & C_Variable.var_Status_Printer & ")".ToString, Color.Red, Color.Black, 240, 400, True)
                    msg_result = "printer is error.(" & C_Variable.var_Status_Printer & ")".ToString
                    Return (msg_result & "," & "False")
                    'Return False

                Case ""
                    '  CLS_ALERT_UI.AlertInformation("can't connect to Printerer.(" & C_Variable.var_Status_Printer & ")".ToString, Color.Red, Color.Black, 240, 400, True)
                    msg_result = "can't connect to Printerer.(" & C_Variable.var_Status_Printer & ")".ToString
                    Return (msg_result & "," & "False")
                    ' Return False
                Case Else
                    'CLS_ALERT_UI.AlertInformation("Printer not ready to use.(" & C_Variable.var_Status_Printer & ")".ToString, Color.Red, Color.Black, 240, 400, True)
                    msg_result = "Printer not ready to use.(" & C_Variable.var_Status_Printer & ")".ToString
                    Return (msg_result & "," & "False")
                    ' Return False

            End Select



            ' End If
            '  MsgBox("Status Printer :" & C_SHARE_VAR.var_Status_Printer)
        Catch ex As Exception

            Call WriteErrorLog(zClassName, zFunctionName, ex.Message)
            ' Call WriteErrorLog("Mdl_Core", "WriteTextWithDataTable", ex.Message)
            Cursor.Current = Cursors.Default
            Return ("" & "," & "False")
            '  Return False
        End Try

    End Function

    Public Function Sent_WR_TO_MRP(ByVal zITEM_CD As String, ByVal zLOC_CD As String, ByVal zLOT_NO As String, ByVal zTRANS_DATE As String _
                                        , ByVal zQTY As String, ByVal zREF_SLIP_NO As String, ByVal zREMARK As String, ByVal zFOR_MACHINE As String _
                                        , ByVal zSHIFT_CLS As String, ByVal zBY_MACHINE As String, ByVal zBY_USER As String) As Boolean
        Dim query_parameters(10) As SqlParameter
        query_parameters(0) = New SqlParameter("@ITEM_CD", SqlDbType.NVarChar)
        query_parameters(0).Value = zITEM_CD
        query_parameters(1) = New SqlParameter("@LOC_CD", SqlDbType.NVarChar)
        query_parameters(1).Value = zLOC_CD
        query_parameters(2) = New SqlParameter("@LOT_NO", SqlDbType.NVarChar)
        query_parameters(2).Value = zLOT_NO
        query_parameters(3) = New SqlParameter("@TRANS_DATE", SqlDbType.NVarChar)
        query_parameters(3).Value = zTRANS_DATE
        query_parameters(4) = New SqlParameter("@QTY", SqlDbType.NVarChar)
        query_parameters(4).Value = zQTY
        query_parameters(5) = New SqlParameter("@REF_SLIP_NO", SqlDbType.NVarChar)
        query_parameters(5).Value = zREF_SLIP_NO
        query_parameters(6) = New SqlParameter("@REMARK", SqlDbType.NVarChar)
        query_parameters(6).Value = zREMARK
        query_parameters(7) = New SqlParameter("@FOR_MACHINE", SqlDbType.NVarChar)
        query_parameters(7).Value = zFOR_MACHINE
        query_parameters(8) = New SqlParameter("@SHIFT_CLS", SqlDbType.NVarChar)
        query_parameters(8).Value = zSHIFT_CLS
        '  query_parameters(8).Value = "A"
        'query_parameters(9) = New SqlParameter("@BY_MACHINE", SqlDbType.NVarChar)
        'query_parameters(9).Value = zBY_MACHINE
        'query_parameters(10) = New SqlParameter("@BY_USER", SqlDbType.NVarChar)
        'query_parameters(10).Value = zBY_USER

        '     Dim tmp_dt As New DataTable
        ' tmp_dt()
        ' tmp_dt = DatabaseConnection.SQLConnect.SQL.ReadSP("spb_WR_to_MRP", cs_MRP, query_parameters, False)
        DatabaseConnection.SQLConnect.SQL.ExecuteSP("spb_RCV_to_MRP", cs_MRP, query_parameters, True)
        Return True
        'If tmp_dt Is Nothing Then
        '    Return False
        'Else
        '    ' tmp_dt.Rows(0).Item(0) = "tmp_dt"
        '    Return True
        'End If


    End Function

    Public Function Sent_SHIPMENT_TO_MRP(ByVal zITEM_CD As String, ByVal zLOC_CD As String, ByVal zLOT_NO As String, ByVal zTRANS_DATE As String _
                                       , ByVal zQTY As String, ByVal zREF_SLIP_NO As String, ByVal zREMARK As String, ByVal zFOR_MACHINE As String _
                                       , ByVal zSHIFT_CLS As String, ByVal zBY_MACHINE As String, ByVal zBY_USER As String _
                                       , ByVal zFor_CUSTOMER As String) As Boolean
        Dim query_parameters(11) As SqlParameter
        query_parameters(0) = New SqlParameter("@ITEM_CD", SqlDbType.NVarChar)
        query_parameters(0).Value = zITEM_CD
        query_parameters(1) = New SqlParameter("@LOC_CD", SqlDbType.NVarChar)
        query_parameters(1).Value = zLOC_CD
        query_parameters(2) = New SqlParameter("@LOT_NO", SqlDbType.NVarChar)
        query_parameters(2).Value = zLOT_NO
        query_parameters(3) = New SqlParameter("@TRANS_DATE", SqlDbType.NVarChar)
        query_parameters(3).Value = zTRANS_DATE
        query_parameters(4) = New SqlParameter("@QTY", SqlDbType.NVarChar)
        query_parameters(4).Value = zQTY
        query_parameters(5) = New SqlParameter("@REF_SLIP_NO", SqlDbType.NVarChar)
        query_parameters(5).Value = zREF_SLIP_NO
        query_parameters(6) = New SqlParameter("@REMARK", SqlDbType.NVarChar)
        query_parameters(6).Value = zREMARK
        query_parameters(7) = New SqlParameter("@FOR_MACHINE", SqlDbType.NVarChar)
        query_parameters(7).Value = zFOR_MACHINE
        query_parameters(8) = New SqlParameter("@SHIFT_CLS", SqlDbType.NVarChar)
        query_parameters(8).Value = zSHIFT_CLS

        query_parameters(9) = New SqlParameter("@FOR_CUSTOMER", SqlDbType.NVarChar)
        query_parameters(9).Value = zFor_CUSTOMER


        '  query_parameters(8).Value = "A"
        query_parameters(10) = New SqlParameter("@BY_MACHINE", SqlDbType.NVarChar)
        query_parameters(10).Value = zBY_MACHINE
        query_parameters(11) = New SqlParameter("@BY_USER", SqlDbType.NVarChar)
        query_parameters(11).Value = zBY_USER

        '  Dim tmp_dt As New DataTable
        ' tmp_dt()
        ' Return DatabaseConnection.SQLConnect.SQL.ExecuteSP("spb_SHIPMENT_to_MRP", cs_MRP, query_parameters, True)
        Dim tmp_dt As New DataTable
        ' tmp_dt()
        tmp_dt = DatabaseConnection.SQLConnect.SQL.ReadSP("spb_SHIPMENT_to_MRP", cs_MRP, query_parameters, False)

        If tmp_dt Is Nothing Then
            Return False
        Else
            ' tmp_dt.Rows(0).Item(0) = "tmp_dt"
            Return True
        End If


    End Function

    Public Function Sent_RCV_TO_MRP(ByVal zITEM_CD As String, ByVal zLOC_CD As String, ByVal zLOT_NO As String, ByVal zTRANS_DATE As String _
                                     , ByVal zQTY As String, ByVal zREF_SLIP_NO As String, ByVal zREMARK As String, ByVal zFOR_MACHINE As String _
                                     , ByVal zSHIFT_CLS As String, ByVal zBY_MACHINE As String, ByVal zBY_USER As String) As Boolean
        Dim query_parameters(10) As SqlParameter
        query_parameters(0) = New SqlParameter("@ITEM_CD", SqlDbType.NVarChar)
        query_parameters(0).Value = zITEM_CD
        query_parameters(1) = New SqlParameter("@LOC_CD", SqlDbType.NVarChar)
        query_parameters(1).Value = zLOC_CD
        query_parameters(2) = New SqlParameter("@LOT_NO", SqlDbType.NVarChar)
        query_parameters(2).Value = zLOT_NO
        query_parameters(3) = New SqlParameter("@TRANS_DATE", SqlDbType.NVarChar)
        query_parameters(3).Value = zTRANS_DATE
        query_parameters(4) = New SqlParameter("@QTY", SqlDbType.NVarChar)
        query_parameters(4).Value = zQTY
        query_parameters(5) = New SqlParameter("@REF_SLIP_NO", SqlDbType.NVarChar)
        query_parameters(5).Value = zREF_SLIP_NO
        query_parameters(6) = New SqlParameter("@REMARK", SqlDbType.NVarChar)
        query_parameters(6).Value = zREMARK
        query_parameters(7) = New SqlParameter("@FOR_MACHINE", SqlDbType.NVarChar)
        query_parameters(7).Value = zFOR_MACHINE
        query_parameters(8) = New SqlParameter("@SHIFT_CLS", SqlDbType.NVarChar)
        query_parameters(8).Value = zSHIFT_CLS


        '  query_parameters(8).Value = "A"
        'query_parameters(9) = New SqlParameter("@BY_MACHINE", SqlDbType.NVarChar)
        'query_parameters(9).Value = zBY_MACHINE
        'query_parameters(10) = New SqlParameter("@BY_USER", SqlDbType.NVarChar)
        'query_parameters(10).Value = zBY_USER

        '  Dim tmp_dt As New DataTable
        ' tmp_dt()
        Return DatabaseConnection.SQLConnect.SQL.ExecuteSP("spb_RCV_to_MRP", cs_MRP, query_parameters, True)

        'If tmp_dt Is Nothing Then
        '    Return False
        'Else
        '    ' tmp_dt.Rows(0).Item(0) = "tmp_dt"
        '    Return True
        'End If


    End Function

    Public Function GetAll_TGRT() As AutoCompleteStringCollection
        Dim tmp_dt As New DataTable
        Dim TGRT_List As New AutoCompleteStringCollection
        Dim StrSQL As New StringBuilder()


        StrSQL.Append("SELECT [TGRT Code] From [View_ALL_PRODUCT_MAS]")

        tmp_dt = DatabaseConnection.SQLConnect.SQL.Read(StrSQL.ToString, cs)

        If tmp_dt Is Nothing Then
            Return TGRT_List
        Else
            For i = 0 To tmp_dt.Rows().Count - 1
                TGRT_List.Add(tmp_dt.Rows(i).Item(0).ToString)
            Next
        End If

        Return TGRT_List

    End Function

    Public Sub Play_Siren_sound()

        'My.Computer.Audio.Play(GetPathSoundSiren)
    End Sub

    Public Sub createTextBoxAutoComplete(ByVal txt As TextBox)
        With txt
            .AutoCompleteMode = AutoCompleteMode.SuggestAppend
            .AutoCompleteSource = AutoCompleteSource.CustomSource
            .AutoCompleteCustomSource = GetAll_TGRT()

        End With

    End Sub

    Public Sub LockScreen(ByVal zWide As Integer, ByVal zColor As String, ByVal zMessage As String)
        Dim myObj As abcLockScreen = New abcLockScreen
        Dim zBackgroundColor As Color
        ' My.Computer.Audio.Play(My.Resources.Sound, AudioPlayMode.Background)



        Dim zfrm As New Form2(zWide, zColor, zMessage)
        myObj.LockSystemAndShow(zfrm)
        ' frmLogin.Show()
        'frm4User.Close()
        '  Me.Close()
    End Sub
End Module
