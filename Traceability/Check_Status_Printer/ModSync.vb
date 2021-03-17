Option Strict Off
Option Explicit On

Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.DataRow
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Net
Imports System.Net.Sockets
Imports System.IO
Imports System.Threading

Module ModSync

    Public Const DATA_SIZE As Integer = 32
    Public G_data(DATA_SIZE) As Byte


    Public Class Synchronization
        ' Const PortNo As Integer = 9100
        ' Const DATA_SIZE As Integer = 1024
        ' Const DATA_SIZE As Integer = 2048
        'Const DATA_SIZE As Integer = 4096

        Public Event StatusReceived(ByVal pTxt As String)


        ' Used for receiving data

        Dim Server As Socket
        'Dim Server As New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
        Dim RemoteAdd As IPAddress
        Dim EndPoint As IPEndPoint
        Dim DataToSend As Byte()
        Dim StrFromMB200i As String

        Dim response As String

        '' ManualResetEvent instances signal completion.
        Private Shared connectDone As New ManualResetEvent(False)
        Private Shared sendDone As New ManualResetEvent(False)
        Private Shared receiveDone As New ManualResetEvent(False)
        Private Shared DisconnectDone As New ManualResetEvent(False)


        Dim _frm As FrmCheck_Status_Printer


        Public Sub New(ByVal frm As FrmCheck_Status_Printer)
            _frm = frm
        End Sub

        Public Function SendENQ(ByVal IP_Addr, ByVal TCP_Port) As Boolean


            Dim Ar As IAsyncResult
            Dim Bytes(DATA_SIZE - 1) As Byte
            Dim TxtData = Chr(5)
            Try
                'If Server Is Nothing Then
                'Connect to the server

                'Dim IP_Addr = "10.65.14.124"
                'Dim TCP_Port = 9100
                RemoteAdd = System.Net.IPAddress.Parse(IP_Addr)
                EndPoint = New IPEndPoint(RemoteAdd, TCP_Port)
                Server = New Socket(EndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp)
                Server.Connect(EndPoint)
                'End If
                ' Send data to the server
                DataToSend = System.Text.Encoding.ASCII.GetBytes(TxtData)
                Server.Send(DataToSend)
                ' Read incoming data from the server
                'Ar = server.BeginReceive(G_data, 0, DATA_SIZE, SocketFlags.None, ReceiveMessage, null))

                Ar = Server.BeginReceive(G_data, 0, DATA_SIZE, SocketFlags.None, AddressOf ReceiveMessage, Bytes)

                Return True

            Catch ex As Exception
                '  MessageBox.Show(ex.Message.ToString)
                Return False
            Finally

            End Try
        End Function

        ' Receiving message from the server
        Public Sub ReceiveMessage(ByVal Ar As IAsyncResult)

            Threading.Thread.Sleep(200)

            ' Read from server
            Dim BytesRead As Integer
            Dim MessageReceived As String
            Dim Bytes(DATA_SIZE - 1) As Byte

            Try
                BytesRead = Server.EndReceive(Ar)
                ' Server has disconnected
                If (BytesRead < 1) Then
                    _frm.ShowReply("No reply from the printer")
                    Exit Sub
                Else
                    'Get the message sent by the server
                    'MessageReceived = Encoding.ASCII.GetString(G_data, 0, BytesRead)
                    MessageReceived = Encoding.ASCII.GetString(G_data, 0, G_data.Length)

                    Dim strlines As New StringBuilder()
                    For i As Integer = 0 To G_data.Length - 1
                        Dim str As String = ""
                        str = Chr(G_data(i)) 'CChar(Conversion.HexToInt(G_data(i)))
                        strlines.Append(str.Replace(ControlChars.NullChar, "."c))
                    Next


                    _frm.Reply_Message = strlines.ToString
                    _frm.ShowReply(strlines.ToString)
                    'MessageBox.Show(strlines.ToString)
                    'RaiseEvent StatusReceived(strlines.ToString)
                End If
                ' Continue reading from server
                'Server.BeginReceive(G_data, 0, DATA_SIZE, SocketFlags.None, AddressOf ReceiveMessage, Bytes)
                Me.CloseConnection()
            Catch ex As Exception
                ' MessageBox.Show(ex.Message)
            End Try
        End Sub

        Public Sub EndReceiveMessage(ByVal Ar As IAsyncResult)

        End Sub

        Private Sub Receive(ByVal client As Socket)

            ' Create the state object.
            Dim state As New StateObject
            state.workSocket = client

            Do While Not client.Connected
                'wait
            Loop
            ' Begin receiving the data from the remote device.
            client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, New AsyncCallback(AddressOf ReceiveCallback), state)
        End Sub 'Receive


        Public Function SckConnect(ByVal IP_Addr As String, ByVal TCP_Port As Integer) As Boolean
            'Dim Ar As IAsyncResult
            Dim Bytes(DATA_SIZE - 1) As Byte

            Try
                'If Server Is Nothing Then
                'Connect to the server
                RemoteAdd = System.Net.IPAddress.Parse(IP_Addr)
                EndPoint = New IPEndPoint(RemoteAdd, TCP_Port)
                Server.BeginConnect(EndPoint, New AsyncCallback(AddressOf ConnectCallback), Server)

                ' Wait for connect.
                connectDone.WaitOne()
                Try
                    If Server.Poll(1, SelectMode.SelectWrite) Then
                        'Set socket in Receive mode
                        Receive(Server)
                        MsgBox("Connected!")
                    End If
                Catch ex As Exception
                    'Server is not responding
                    MsgBox("Server not responding")
                End Try
                Return True

            Catch ex As Exception
                MsgBox(ex.Message)
                C_Variable.var_Status_Printer = ""
                _frm.Close()
                Return False
            Finally

            End Try
        End Function

        Private Sub ReceiveCallback(ByVal ar As IAsyncResult)

            ' Retrieve the state object and the client socket 
            ' from the asynchronous state object.
            Dim state As StateObject = CType(ar.AsyncState, StateObject)
            Dim client As Socket = state.workSocket

            If Not client.Connected Then
                receiveDone.Set()
                'Dim dlg As New DisconnectResponseDataDelegate(AddressOf DisconnectResponse)
                'Me.Invoke(dlg)
                Exit Sub
            End If

            ' Read data from the remote device.
            Dim bytesRead As Integer = client.EndReceive(ar)

            If bytesRead > 0 Then
                'Store the data received so far.
                state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead))

                'Put it in  a response.
                If state.sb.Length > 1 Then
                    response = state.sb.ToString()
                End If

            Else
                'Server Has disconnected
                client.Close()
                receiveDone.Set()
                'Dim dlg As New DisconnectResponseDataDelegate(AddressOf DisconnectResponse)
                'Me.Invoke(dlg)
                Exit Sub
            End If

            If response.IndexOf("<EOF>") > -1 Then
                'Send message to Server thread
                'Dim dlg As New ShowReceiveDataDelegate(AddressOf ShowReceiveData)
                'Me.Invoke(dlg, response)
                'StrFromMB200i = response
                MsgBox(response)
                'Clear the buffer and response
                response = Nothing
                Array.Clear(state.buffer, 0, bytesRead)
                state.sb.Remove(0, bytesRead)
                'Get the next of the message
                client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, New AsyncCallback(AddressOf ReceiveCallback), state)
            Else
                'Get the rest of the message
                client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, New AsyncCallback(AddressOf ReceiveCallback), state)
            End If

            ' Signal that all bytes have been received.
            receiveDone.Set()

        End Sub 'ReceiveCallback

        Private Shared Sub ConnectCallback(ByVal ar As IAsyncResult)
            ' Retrieve the socket from the state object.
            Dim sckclient As Socket = CType(ar.AsyncState, Socket)

            Try
                ' Complete the connection.
                sckclient.EndConnect(ar)
            Catch
                sckclient.Close()
            End Try

            ' Signal that the connection has been made.
            connectDone.Set()
        End Sub 'ConnectCallback

        Public Sub CloseConnection()
            If Not (Server Is Nothing) Then
                Server.Close()
            End If
        End Sub
    End Class

    ' State object for receiving data from remote device.
#Region "State Object Calss"

    Public Class StateObject
        ' Client socket.
        Public workSocket As Socket = Nothing
        ' Size of receive buffer.
        Public Const BufferSize As Integer = 256
        ' Receive buffer.
        Public buffer(BufferSize) As Byte
        ' Received data string.
        Public sb As New StringBuilder
    End Class 'StateObject

#End Region
End Module
