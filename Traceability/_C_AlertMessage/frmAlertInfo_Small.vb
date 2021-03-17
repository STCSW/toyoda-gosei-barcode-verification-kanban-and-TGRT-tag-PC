Public Class frmAlertInfo_Small

    Public information_message As String = String.Empty

    Private Sub frmAlertInfo_Small_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

    End Sub

    Private Sub frmAlertInfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnBack.Top = (Me.ClientSize.Height / 1.3)
        btnBack.Left = (Me.ClientSize.Width / 2.2)
        btnBack.BackColor = Color.White

        txtMessage.Text = information_message
        TextBox1.Focus()

    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click

        Me.Close()

    End Sub

    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown

    End Sub

    'Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
    '    'If e.KeyChar = Convert.ToChar(13) Then
    '    '    If TextBox1.Text = "123" Then
    '    '        Me.Close()
    '    '        frmTakingScan.txtScanProduct.Enabled = True
    '    '        frmTakingScan.txtScanProduct.SelectAll()
    '    '        frmTakingScan.txtScanProduct.Focus()

    '    '        'displayScannedData(txtScanTripNo.Text)
    '    '    Else
    '    '        C_SOUND.playConfirmSound()
    '    '        TextBox1.Text = ""
    '    '        TextBox1.Focus()
    '    '    End If
    '    'End If
    'End Sub



    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Label1_Click(sender As System.Object, e As System.EventArgs) Handles Label1.Click

    End Sub

End Class