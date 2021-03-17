Imports System.IO
Imports System.Net.Sockets
Imports System.Data

Public Class C_Transfer_File
  
    Public Shared Function Move_File(ByVal xPath_destination As String, ByVal file_name As String, ByVal xPath_Folder As String) As Boolean

        Dim startUpPath As String = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName.CodeBase)
        ' Dim fileCopyPath As String = Path.Combine(startUpPath & "\TransferEvent", file_name)
        Dim fileCopyPath As String = Path.Combine(xPath_Folder, file_name)
        Dim fileDestinationPath As String = Path.Combine(xPath_destination, file_name)

        Try
            File.Copy(fileCopyPath, fileDestinationPath, True)
            'File.Copy(xPath_File, xPath_destination)
            File.Delete(fileCopyPath)

            'MessageBox.Show("Move completed" & Environment.NewLine & xPath_destination)
            Return True
        Catch ex As Exception
            'MessageBox.Show("Error : " & ex.Message)
            WriteErrorLog("C_Transfer_File", "Move_File", "Error : " & ex.Message)
            Return False
        End Try

    End Function

    '    Public Shared Function Move_File_FTP(ByVal xPath_destination As String, ByVal file_name As String, ByVal xPath_Folder As String) As Boolean
    '        Try
    '            Dim zClassName As String = "C_Transfer_File"
    '            Dim zFunctionName As String = "Move_File_FTP"

    '            Dim startUpPath As String = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName.CodeBase)
    '            ' Dim fileCopyPath As String = Path.Combine(startUpPath & "\TransferEvent", file_name)
    '            Dim fileCopyPath As String = Path.Combine(xPath_Folder, file_name)
    '            Dim fileDestinationPath As String = Path.Combine(xPath_destination, file_name)


    '            Dim DT As DataTable = GetSetting()
    '            Dim FTP_Path_destination As String
    '            Dim FTP_ip As String
    '            Dim FTP_port As String
    '            Dim FTP_User As String
    '            Dim FTP_Password As String


    '            FTP_Path_destination = DT.Rows(0).Item("FTP_PATH")
    '            FTP_ip = DT.Rows(0).Item("FTP_IP")
    '            FTP_port = DT.Rows(0).Item("FTP_PORT")
    '            FTP_User = DT.Rows(0).Item("FTP_USER")
    '            FTP_Password = DT.Rows(0).Item("FTP_PASSWORD")

    '            Dim CLS_FTP As New cls_SmartFTPClient.PublicClass(xPath_Folder.Trim, FTP_ip.Trim, FTP_port.Trim, FTP_Path_destination.Trim, FTP_User.Trim, FTP_Password.Trim)
    '            Dim str As String = CLS_FTP.ShowFTP()
    '            ' Me.BringToFront()
    '            If str = String.Empty Then
    '                '   CLS_ALERT_UI.AlertInformation("Complete".ToString, Color.Green, Color.Black, 240, 400, True)
    '                ' File.Delete(fileCopyPath)
    '                Return True
    '            Else
    '                ' MsgBox(str)
    '                '  Me.BringToFront()
    '                ' CLS_ALERT_UI.AlertInformation(str.ToString, Color.Red, Color.Black, 240, 400, True)
    '                '  MessageBox.Show("Error : " & str)
    '                Call WriteErrorLog(zClassName, zFunctionName, str)
    '                Return False
    '            End If

    '        Catch ex As Exception
    '            MessageBox.Show("Error : " & ex.Message)
    '            Return False
    '        End Try


    '    End Function


    '    Public Shared Function Delete_File_FTP(ByVal xPath_destination As String, ByVal file_name As String, ByVal xPath_Folder As String) As Boolean
    '        Try
    '            Dim zClassName As String = "C_Transfer_File"
    '            Dim zFunctionName As String = "Delete_File_FTP"

    '            Dim startUpPath As String = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName.CodeBase)
    '            ' Dim fileCopyPath As String = Path.Combine(startUpPath & "\TransferEvent", file_name)
    '            Dim fileCopyPath As String = Path.Combine(xPath_Folder, file_name)
    '            Dim fileDestinationPath As String = Path.Combine(xPath_destination, file_name)


    '            Dim DT As DataTable = GetSetting()
    '            Dim FTP_Path_destination As String
    '            Dim FTP_ip As String
    '            Dim FTP_port As String
    '            Dim FTP_User As String
    '            Dim FTP_Password As String


    '            FTP_Path_destination = DT.Rows(0).Item("FTP_PATH")
    '            FTP_ip = DT.Rows(0).Item("FTP_IP")
    '            FTP_port = DT.Rows(0).Item("FTP_PORT")
    '            FTP_User = DT.Rows(0).Item("FTP_USER")
    '            FTP_Password = DT.Rows(0).Item("FTP_PASSWORD")

    '            Dim CLS_FTP_DELETE As New cls_SmartFTPClient_DELETE.PublicClass(xPath_Folder.Trim, FTP_ip.Trim, FTP_port.Trim, FTP_Path_destination.Trim, FTP_User.Trim, FTP_Password.Trim, file_name)
    '            Dim str As String = CLS_FTP_DELETE.ShowFTP()
    '            ' Me.BringToFront()
    '            If str = String.Empty Then
    '                '   CLS_ALERT_UI.AlertInformation("Complete".ToString, Color.Green, Color.Black, 240, 400, True)
    '                ' File.Delete(fileCopyPath)
    '                Return True
    '            Else
    '                ' MsgBox(str)
    '                '  Me.BringToFront()
    '                ' CLS_ALERT_UI.AlertInformation(str.ToString, Color.Red, Color.Black, 240, 400, True)
    '                '  MessageBox.Show("Error : " & str)
    '                Call WriteErrorLog(zClassName, zFunctionName, str)
    '                Return False
    '            End If

    '        Catch ex As Exception
    '            MessageBox.Show("Error : " & ex.Message)
    '            Return False
    '        End Try


    '    End Function

End Class



'Public Class FTP


'    Protected nStream As NetworkStream = null


'    Protected rdStrm As StreamReader = null
'    Protected wrStrm As StreamWriter = null
'    Protected filesToSend As FileInfo() = null
'    Protected ftpProg As FtpProgress = null
'    Protected storSendTo As FtpPassiveConnection = null
'    Protected fileBytes As Byte() = null
'    ' //protected String ftpServerAddress = "ftp.yourserver.com";
'    Protected ftpServerAddress As String = "192.168.0.44"

'    Protected ftpServerPort As Int32 = 21
'        protected  ftpCWDFolder As String = @"/xxx/" // @"/home/"
'        protected event Action<FtpProgress> FtpCurrentProgressEvent;

'End Class
