Public Class frm_ShowPic 

    Public Sub SHOWFULLPIC(ByVal img As Image)
        PictureEdit1.Image = img
        Me.ShowDialog()
        'Me.Focus()
    End Sub

    Private Sub frm_ShowPic_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class