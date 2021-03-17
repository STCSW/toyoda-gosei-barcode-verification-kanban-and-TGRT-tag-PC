Imports System.IO
Imports System.Text

Module C_Error_Log
    Public Sub WriteErrorLog(ByVal zClass As String, ByVal zFunction As String, ByVal zError As String)

        Dim zFileName As String
        zFileName = GetPathErrorEvent()

        If Not Directory.Exists(zFileName) Then
            Directory.CreateDirectory(zFileName)
        End If
        zFileName += "\ERROR_" & DateTime.Now.ToString("yyyy.MM.dd") & ".txt"

        Dim SB As New StringBuilder
        SB.Remove(0, SB.Length)
        SB.Append(vbCrLf)
        SB.Append(StrDup(100, "=") & vbCrLf)
        SB.Append("Event Date/Time: " & DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss") & vbCrLf)
        SB.Append("Class: " & Trim(zClass) & vbCrLf)
        SB.Append("Function: " & Trim(zFunction) & vbCrLf)
        SB.Append("Description: " & Trim(zError))

        Using zStream As New StreamWriter(zFileName, True)
            zStream.WriteLine(SB.ToString)
        End Using

    End Sub

    Public Function GetPathErrorEvent() As String
        Dim zPath As String
        'zPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.GetName.CodeBase)
        zPath = My.Application.Info.DirectoryPath
        zPath += "\ErrorEvent"
        Return zPath
    End Function
End Module
