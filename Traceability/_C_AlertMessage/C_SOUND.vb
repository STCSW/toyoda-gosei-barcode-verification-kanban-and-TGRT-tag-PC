Imports System.IO

Public Class C_SOUND

    Dim xPath As String = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)

    Private Shared ReadOnly _Screen_Name As String = String.Empty
    Private Shared ReadOnly _Class_Name As String = "C_SOUND"

    Private Shared confirmSoundPath As String = Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) & "\Sound\", "Confirm.wav")
    Private Shared infoSoundPath As String = Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) & "\Sound\", "Error.wav")
    Private Shared errorSoundPath As String = Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) & "\Sound\", "Error.wav")
    Private Shared defaultSoundPath As String = Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) & "\Sound\", "Error.wav")


    'Play wave files using winm.dll
    'Public Declare Function PlaySound Lib "winmm.dll" Alias "PlaySound" (ByVal lpszName As String, ByVal hModule As Integer, ByVal dwFlags As Integer) As Boolean
    'Declare Function PlaySound Lib "coredll.dll" (ByVal szSound As Char(), ByVal hMod As IntPtr, ByVal flags As PlaySoundFlags) As Integer
    Private Declare Function PlaySound Lib "coredll.dll" (ByVal szSound As Char(), ByVal hMod As IntPtr) As Integer

    Private Shared Sub play(ByVal pFilePath As String)

        Dim fileStr As String = pFilePath
        'PlaySound(file, IntPtr.Zero, PlaySoundFlags.SND_FILENAME Or PlaySoundFlags.SND_SYNC)
        PlaySound(CType(fileStr, Char()), IntPtr.Zero)

    End Sub

    Public Shared Sub playConfirmSound()
        play(confirmSoundPath)
    End Sub

    Public Shared Sub playErrorSound()
        play(errorSoundPath)
    End Sub

    Public Shared Sub PlayInfoSound()
        play(infoSoundPath)
    End Sub

    Public Shared Sub playDefaultSound()
        play(defaultSoundPath)
    End Sub


End Class
