Friend Class abcLockSystemParameters
    Public NewDesktop As IntPtr
    Public Background As Bitmap
    Public Sub New(ByVal newDesktop As IntPtr, ByVal background As Bitmap)
        Me.NewDesktop = newDesktop
        Me.Background = background
    End Sub
End Class
