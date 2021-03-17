

Public Class frm_Inputbox
    Private chkfrmop As String
    Private Res As String


    Public Function Inputtxt(ByVal chkfrm As String, ByVal textstring As String, Optional ByVal HeadString As String = "Input", Optional ByVal passwordchr As String = "") As String
        Inputtxt = ""
        chkfrmop = chkfrm
        TextBox1.Text = ""
        TextBox1.PasswordChar = passwordchr
        Label1.Text = textstring
        Me.Text = HeadString
        TextBox1.Focus()
        Me.ShowDialog()

        TextBox1.Focus()
        Return TextBox1.Text



    End Function

    Private Sub frm_Inputbox_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Focus()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        TextBox1.Text = ""

        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class