Imports System.Threading
''' <summary>
''' I got this piece of code spread on another tutorial, that I found on interent. So, I collected and joined together for my use.
''' </summary>
''' <remarks>I have removed some unwanted piece of information. But it requires more updation to use it effectively.</remarks>
Public NotInheritable Class abcLockScreen
    Private myForm As Form  '~~~ Will hold the form which you want to display. In this example, I'll display a Login screen
#Region " System Locking Methods "

    Public Function LockSystemAndShow(ByVal myDForm As Form) As Boolean
        myForm = myDForm

        'Dim owner As Control = TryCast(Form1.Button1, Control)
        Dim scr As Screen
        'If owner Is Nothing Then
        scr = Screen.PrimaryScreen
        'Else
        'scr = Screen.FromControl(owner)
        'End If
        Dim background As Bitmap = New Bitmap(scr.Bounds.Width, scr.Bounds.Height)
        Using g As Graphics = Graphics.FromImage(background)

            g.CopyFromScreen(0, 0, 0, 0, scr.Bounds.Size)
            Using br As Brush = New SolidBrush(Color.FromArgb(192, Color.Black))
                g.FillRectangle(br, scr.Bounds)
            End Using

            'If owner IsNot Nothing Then
            ' Dim form As Form = owner.FindForm()
            ' g.CopyFromScreen(form.Location, form.Location, form.Size)
            ' Using br As Brush = New SolidBrush(Color.FromArgb(128, Color.Black))
            ' g.FillRectangle(br, New Rectangle(Form.Location, Form.Size))
            'End Using
            'End If

        End Using

        Dim originalThread As IntPtr
        Dim originalInput As IntPtr
        Dim newDesktop As IntPtr

        originalThread = GetThreadDesktop(Thread.CurrentThread.ManagedThreadId)
        originalInput = OpenInputDesktop(0, False, DESKTOP_SWITCHDESKTOP)

        newDesktop = CreateDesktop("Desktop" & Guid.NewGuid().ToString(), Nothing, Nothing, 0, GENERIC_ALL, Nothing)
        SetThreadDesktop(newDesktop)
        SwitchDesktop(newDesktop)

        Dim newThread As Thread = New Thread(AddressOf NewThreadMethod)
        newThread.CurrentCulture = Thread.CurrentThread.CurrentCulture
        newThread.CurrentUICulture = Thread.CurrentThread.CurrentUICulture
        newThread.Start(New abcLockSystemParameters(newDesktop, background))
        newThread.Join()

        SwitchDesktop(originalInput)
        SetThreadDesktop(originalThread)

        CloseDesktop(newDesktop)
        CloseDesktop(originalInput)

        Return True 'Result

    End Function

    Private Sub NewThreadMethod(ByVal params As Object)
        Dim v As abcLockSystemParameters = DirectCast(params, abcLockSystemParameters)
        SetThreadDesktop(v.NewDesktop)
        Using f As Form = New BackgroundForm(v.Background)
            f.Show()
            myForm.ShowDialog()  '~~~~ Show the login screen here
            f.BackgroundImage = Nothing
            Application.DoEvents()
            Thread.Sleep(250)
        End Using
    End Sub

#End Region
End Class
