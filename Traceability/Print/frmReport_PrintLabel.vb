Public Class frmReport_PrintLabel
    Private _frm_Report1 As New Uc_Report_PrintLabel
    Private Sub frmReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim ct As New Uc_Report_Daily_IN
        Panel1.Controls.Clear()
        'ORDER_FORM_TYPE = trv_Master.SelectedNode.Text.Trim.Replace("Order ", "")
        ' ct.UcCaption.Caption = e.Link.Caption
        Panel1.Controls.Add(_frm_Report1)
        _frm_Report1.Dock = DockStyle.Fill
    End Sub
End Class