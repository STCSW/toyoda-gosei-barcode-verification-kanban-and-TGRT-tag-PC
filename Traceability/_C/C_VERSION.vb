Imports System.Reflection
Imports System.Threading
Imports System.Windows.Forms

Public Class C_VERSION

    Public Shared Function GetSoftwareName() As String

        Return "BARCODE VERIFICATION SYSTEM"
        Application.DoEvents()

    End Function
    Public Shared Function GetAboutSoftware() As String

        Dim strSW As New System.Text.StringBuilder()

        Dim assembly As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()
        Dim fileInfo As New System.IO.FileInfo(assembly.Location)
        Dim lastModified As DateTime = fileInfo.LastWriteTime

        strSW.Append("Software Name  : " & String.Concat(C_VERSION.GetSoftwareName, Space(3), C_VERSION.GetVersionSoftware) & Environment.NewLine)
        strSW.Append("Development Software  :  VB.Net 2013 (.Net Framwork 4.5)" & Environment.NewLine)
        strSW.Append("Database : MS SQL Server 2012  " & Environment.NewLine)
        strSW.Append("Service Hotline       :  +662 736 4460" & Environment.NewLine)
        strSW.Append("Email :  software.stc@sato-global.com" & Environment.NewLine)
        strSW.Append("Installation Date :  Feb 03, 2016" & Environment.NewLine)
        strSW.Append("Last Update       :  " & lastModified.ToString("MMM dd,yyyy") & Environment.NewLine)
        strSW.Append("Remark : This system is specially developed to operate in Windows OS, single-user environment only.")

        Return strSW.ToString()

    End Function

    Public Shared Function GetVersionSoftware() As String

        Dim Major As String = Assembly.GetExecutingAssembly().GetName().Version().Major.ToString()
        Dim Minor As String = Assembly.GetExecutingAssembly().GetName().Version().Minor.ToString()
        Dim Build As String = Assembly.GetExecutingAssembly().GetName().Version().Build.ToString()
        Dim Revision As String = Assembly.GetExecutingAssembly().GetName().Version().Revision.ToString()

        Dim Version As String = "[ Ver. " & Major & "." & Minor.PadLeft(2, "0") & "." & Build.PadLeft(2, "0") & "." & Revision.PadLeft(2, "0") & " ]"

        Return Version

        '--------------------------------------------------------------------------------------------------------
        '### DETIALS OF SOFTWARE ###
        '--------------------------------------------------------------------------------------------------------


    End Function


End Class
