Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.Utils.VisualEffects
Imports DevExpress.Utils


Partial Public Class GuideFlyoutPanel


    Private Sub skipButton_Click(sender As Object, e As EventArgs) Handles skipButton.Click

        frmLogin.AdornerUIManager1.ShowGuides = DefaultBoolean.Default
        frmLogin.Guide2.Visible = True

    End Sub

    Private Sub backButton_Click(sender As Object, e As EventArgs) Handles backButton.Click

        ' frmLogin.Guide2.TargetElement = frmLogin.txtUsername
        label.Text = "User"
        Application.DoEvents()
    End Sub

    Private Sub nextButton_Click(sender As Object, e As EventArgs) Handles nextButton.Click

        frmLogin.Guide2.TargetElement = frmLogin.txtPassword
        label.Text = "Password"
        Application.DoEvents()
    End Sub
End Class
