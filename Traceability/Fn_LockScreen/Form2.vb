Imports System.IO
''' <summary>
''' Sample Login screen page
''' </summary>
''' <remarks>by, Akhilesh B Chandran
''' akhileshbc @ VBForums</remarks>
Public Class Form2
    Dim bolExit As Boolean = False  '~~~ Used to detect whether the form is being closed only after entering the correct password and not by pressing "Alt" + "F4"

    Sub New(ByVal zSizeY As Integer, ByVal zColor As String, ByVal zMessage As String)

        ' This call is required by the designer.
        InitializeComponent()
        Me.Size = New Size(zSizeY, Me.Height)
        If zColor = "red" Then
            Me.BackColor = Color.Red
        ElseIf zColor = "yellow" Then
            Me.BackColor = Color.Yellow

        ElseIf zColor = "green" Then
            Me.BackColor = Color.Green

        ElseIf zColor = "white" Then
            Me.BackColor = Color.White

        End If
        lblMessage.Text = zMessage
        ' Me.BackColor = zBackgroundColor

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        '   If txtPwd.Text.Trim.ToLower = "0310" Then        '~~~ Check if the password is correct

        txtPwd.Text = Trim(txtPwd.Text)
        If txtPwd.Text = String.Empty Then
            ' MessageBox.Show("Please enter Password.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            MessageBox.Show("Nah!... You are not supposed to continue using this PC..!, ติดต่อผู้ดูแลระบบ", "Wrong Password !!! ")

            txtPwd.Focus()
            Return
        End If

        If Check_Password_INI(txtPwd.Text.Trim.ToLower) Then
            bolExit = True

            '~~~ If so, we got the green signal to close the form :-)
            MessageBox.Show("Unlock success !!!", "Success")
            txtPwd.Text = String.Empty
            Me.Close()                              '~~~ Close it
        ElseIf txtPwd.Text.Trim.ToLower = My.Settings.PASSWORD_LOCK_SCREEN Then
            bolExit = True
            '~~~ If so, we got the green signal to close the form :-)
            MessageBox.Show("Unlock success !!!", "Success")
            txtPwd.Text = String.Empty
            Me.Close()                              '~~~ Close it
        Else                                            '~~~ Otherwise, display a message
            MessageBox.Show("Nah!... You are not supposed to continue using this PC..!, ติดต่อผู้ดูแลระบบ", "Wrong Password !!! ")
            txtPwd.Text = String.Empty
            txtPwd.Focus()
        End If
    End Sub

    Private Sub Form2_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

    End Sub
    Private Function Check_Password_INI(ByVal zPassword As String) As Boolean

        Try
            If zPassword = "0310" Or zPassword = "toyodagosei" Then
                Return True
            End If

            Dim zFileName As String
            zFileName = Application.StartupPath & "\PASSWORD_ini"
            If Not Directory.Exists(zFileName) Then
                Directory.CreateDirectory(zFileName)
            End If

            If Not File.Exists(Application.StartupPath & "\PASSWORD_ini\PASSWORD.ini") Then
                File.Create(Application.StartupPath & "\PASSWORD_ini\PASSWORD.ini").Dispose()
                Return False
            End If


            If File.Exists(Application.StartupPath & "\PASSWORD_ini\PASSWORD.ini") Then
                Using objReader As New StreamReader(Application.StartupPath & "\PASSWORD_ini\PASSWORD.ini")
                    Dim tmpRead_data As String = objReader.ReadToEnd()
                    If tmpRead_data.Trim.Length > 0 Then

                        Dim Arr_Passoword As String() = tmpRead_data.Split(New String() {Environment.NewLine},
                        StringSplitOptions.None)


                        For i = 0 To Arr_Passoword.Length - 1
                            If Arr_Passoword(i) = zPassword Then

                                Return True
                            End If

                        Next i
                        Return False

                    ElseIf tmpRead_data.Trim.Length = 0 Then
                        Return False

                    Else
                        Return False
                    End If




                End Using
            End If


        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Sub Form2_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If bolExit = False Then     '~~~ When closing the form, checks whether it is being closed by "Alt" + "F4" or by entering the correct password.
            e.Cancel = True         '~~~ If the closing is done without entering the correct password, then prevent the form from being closed
        End If
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtPwd.Focus()
    End Sub

    Private Sub txtPwd_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPwd.KeyDown

        If e.KeyCode.Equals(Keys.Enter) Then
            If Trim(txtPwd.Text) <> String.Empty Then
                Button1_Click(sender, e)

            Else
                txtPwd.Focus()
            End If


        End If


    End Sub

    Private Sub txtPwd_TextChanged(sender As Object, e As EventArgs) Handles txtPwd.TextChanged

    End Sub
End Class