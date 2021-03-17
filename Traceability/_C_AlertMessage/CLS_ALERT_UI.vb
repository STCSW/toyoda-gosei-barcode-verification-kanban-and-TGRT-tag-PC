Public Class CLS_ALERT_UI

    Private Shared ReadOnly _Screen_Name As String = String.Empty
    Private Shared ReadOnly _Class_Name As String = "CLS_ALERT_UI"


    Public Shared Sub AlertInformation(ByVal pMessage As String, ByVal pBack_Color As Color, ByVal pFont_Color As Color, _
                                       ByVal pForm_Width As Integer, ByVal pForm_Height As Integer, ByVal pShow_btnOk As Boolean, ByVal pPosition_Y As Integer)

        Dim frm As New frmAlertInfo_Small

        'frm.Size = New Size(pForm_Width, 178)
        frm.Size = New Size(pForm_Width, pForm_Height)
        'frm.txtMessage.Size = New Size(pForm_Width, 84)
        frm.txtMessage.Size = New Size(pForm_Width - 20, (pForm_Height * 0.5))

        If pShow_btnOk = True Then
            frm.btnBack.Enabled = True
            frm.btnBack.Visible = True

        Else
            frm.btnBack.Enabled = False
            frm.btnBack.Visible = False
        End If

        Dim tmpH As Integer = 0
        Dim tmpV As Integer = 0

        Try
            tmpV = CInt((pForm_Height - 178) / 2.2)
        Catch ex As Exception

        End Try

        ' frm.Location = New Point(tmpH, tmpV)

        frm.BackColor = pBack_Color
        frm.ForeColor = pFont_Color
        frm.txtMessage.ForeColor = pFont_Color
        frm.txtMessage.BackColor = pBack_Color

        frm.information_message = pMessage


        frm.ShowDialog()

    End Sub

    


End Class
