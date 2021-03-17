Imports System.Net.Sockets
Imports System.Text 

Public Class FrmCheck_Status_Printer

    Dim WithEvents Sync As Synchronization
    Public Reply_Message As String = String.Empty
    Private xReply As String = String.Empty
    Private xStatus As String = String.Empty
    Private xIp, xPort As String
    Private xMobile_On As Boolean
    Private xCL408e_On As Boolean

    Sub New(ByVal zIp As String, ByVal zPort As String)

        ' This call is required by the Windows Form Designer.
        xIp = zIp
        xPort = zPort
        'xMobile_On = zMobile_On
        'xCL408e_On = zCL408e_On
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        xReply = ""
        Sync.CloseConnection()
    End Sub

    Private Sub btnQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuery.Click
        If txtIP.Text = "" Or txtPort.Text = "" Then
            MsgBox("Please enter IP Address and Port No.")
        Else
            Send2()
        End If
    End Sub

    Private Sub FrmCheck_Status_Printer_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        Timer1.Enabled = False
    End Sub

    Private Sub FrmCheck_Status_Printer_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Timer1.Enabled = False
    End Sub

    Private Sub frmDemo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Sync = New Synchronization(Me)
        xReply = ""
        Send2()

    End Sub

    Sub Send2()

        xReply = ""
        Reply_Message = String.Empty
        If Sync.SendENQ(xIp, xPort) = False Then
            Me.Close()
        End If
        'ดัก error ห้ามส่งชนกัน
        Timer1.Enabled = True
    End Sub

    Private Sub HandleReceivedDate(ByVal msg As String)
    End Sub


    Delegate Sub MyDelegate(ByVal msg As String)

    Public Sub ShowReply(ByVal s As String)
        Dim parameters(0) As Object
        parameters(0) = s
        Me.Invoke(New MyDelegate(AddressOf showMessage), New Object() {s})

    End Sub

    Private Sub showMessage(ByVal msg As String)
        Threading.Thread.Sleep(250)
        xReply = msg

        If xMobile_On = True Then
            ' xStatus = "Status : " & msg.Substring(3, 1)
            xStatus = msg.Substring(3, 1)
        Else
            '   MsgBox(xStatus)
            If xCL408e_On = True Then
                xStatus = msg.Substring(12, 1)
            Else
                xStatus = msg.Substring(8, 1)
            End If

        End If
        C_Variable.var_Status_Printer = xStatus
        Application.DoEvents()
        Me.Close()

    End Sub

    Private Sub showMessageEvent(ByVal msg As String) Handles Sync.StatusReceived

        If msg.Trim.Length = 0 Then
            Exit Sub
        End If

        '   If xMobile_On = True Then
        ' xStatus = "Status : " & msg.Substring(3, 1)
        xStatus = msg.Substring(3, 1)
        '  Else
        '   MsgBox(xStatus)
        xStatus = msg.Substring(8, 1)
        ' End If

        C_Variable.var_Status_Printer = xStatus
        Application.DoEvents()
        Me.Close()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Close()
    End Sub

   
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        'เอามาแก้ปัญหาเรื่องการส่งไฟล์ชนกัน  โปรแกรมไม่ได้บัค
        xStatus = "A"
        C_Variable.var_Status_Printer = xStatus
        Application.DoEvents()
        Me.Close()
    End Sub
End Class
