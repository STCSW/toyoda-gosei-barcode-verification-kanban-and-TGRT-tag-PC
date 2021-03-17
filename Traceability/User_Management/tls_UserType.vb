Imports DatabaseConnection.SQLConnect.SQL
Imports CommonComponent.Software



Public Class tls_UserType

    Private Type_Table As DataTable
    Private sql As String



#Region "Function"

    Private Sub SET_LIST()
        ListView1.View = View.Details
        ListView1.CheckBoxes = True

        ListView1.Columns.Add("Allow", 50, HorizontalAlignment.Center)          'Add column 1
        ListView1.Columns.Add("No", 30, HorizontalAlignment.Left)
        ListView1.Columns.Add("Permission", 300, HorizontalAlignment.Left) 'Add column 2
        ' ListView1.Columns.Add("Name", 0, HorizontalAlignment.Left) 'Add column 3

        'Use this to set the first column to be displayed as the last column
        ListView1.Columns(0).DisplayIndex = ListView1.Columns.Count - 1
    End Sub

    Private Sub SET_LIST_DATA()

        If Type_Table IsNot Nothing Then


            For i = 1 To Type_Table.Columns.Count - 1

                Dim lvi As New ListViewItem

                'lvi.Text = Type_Table.Columns(i).Caption
                lvi.SubItems.Add(i)
                lvi.SubItems.Add(Type_Table.Columns(i).Caption)
                'lvi.SubItems.Add("True")

                ListView1.Items.Add(lvi)

            Next


          


            For i = 0 To Type_Table.Rows.Count - 1
                ListBoxControl1.Items.Add(Type_Table.Rows(i).Item("TYPE_NAME").ToString)
            Next
            ListView1.Focus()
            ListView1.Items(0).Selected = True

        End If

        'Type_Table = ReadSP("M_ALL_USER_TYPE", cs)

    End Sub

    Private Sub Clear_list()

        ListBoxControl1.Items.Clear()
        'For i = 0 To ListBoxControl1.Items.Count - 1
        '    ListBoxControl1.Items.Remove(i)
        'Next

        ListView1.Clear()


    End Sub

    Private Sub UPDATE_VALUE()

        If ListBoxControl1.SelectedValue = "" Then Exit Sub

        For i = 0 To ListView1.Items.Count - 1
            Dim Val As Integer = 0
            If ListView1.Items(i).Checked = True Then
                Val = 1
            End If

            sql = "Update M_USER_TYPE_MASTER SET " & _
                "[" & ListView1.Items(i).SubItems(2).Text.ToString & "] = " & Val & " where TYPE_NAME = '" & ListBoxControl1.SelectedValue.ToString.Trim & "'"

            Execute(sql, cs)

            ' MessageBox.ShowBox(ListView1.Items(i).SubItems(2).Text.ToString)
            'MessageBox.ShowBox(ListView1.Name.SubItems(0).Name)
            ' ListView1.Items(i).Checked = True
        Next


        Type_Table = ReadSP("M_ALL_USER_TYPE", cs)







    End Sub

    Private Sub Selected_Type()
        Try

            Dim result() As DataRow = Type_Table.Select("TYPE_NAME = '" & ListBoxControl1.SelectedValue & "'")

            For i = 0 To ListView1.Items.Count - 1
                Try
                    If result(0)(i + 1) = 1 Then
                        ListView1.Items(i).Checked = True
                    Else
                        ListView1.Items(i).Checked = False
                    End If
                Catch ex As Exception

                End Try


            Next

        Catch ex As Exception

        End Try
    End Sub



    Private Sub ListView1_ColumnWidthChanging(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnWidthChangingEventArgs) Handles ListView1.ColumnWidthChanging
        If Me.ListView1.Columns(e.ColumnIndex).Width = 0 Then
            e.Cancel = True
            e.NewWidth = Me.ListView1.Columns(e.ColumnIndex).Width
        End If

    End Sub

    Dim preWidth As Integer = 1

    Private Sub ListView1_ColumnWidthChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnWidthChangedEventArgs) Handles ListView1.ColumnWidthChanged


        If preWidth = 0 Then ListView1.Columns(0).Width = 0

        preWidth = ListView1.Columns(0).Width


    End Sub
#End Region





    Private Sub tls_UserType_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Type_Table = ReadSP("M_ALL_USER_TYPE", cs)
        SET_LIST()
        SET_LIST_DATA()
        Selected_Type()

    End Sub

    Private Sub ListBoxControl1_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles ListBoxControl1.MouseClick
        Selected_Type()

        'ListView1.Items(0).Checked = True



        'For Each itm As ListViewItem In ListView1.Items




        '    If Type_Table.Columns(i) Then

        '    End If


        '    itm.Checked = True
        '    'If itm.Checked Then
        '    '    MessageBox.ShowBox("item checked: " & itm.Text)
        '    'Else
        '    '    MessageBox.ShowBox("item NOT checked: " & itm.Text)
        '    'End If
        'Next


        ' Loop and display.
        'For Each row As DataRow In result
        '    Console.WriteLine("TYPE_NAME", row(0), row(1))
        'Next
    End Sub

    Private Sub ListBoxControl1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListBoxControl1.SelectedIndexChanged
        Selected_Type()







    End Sub

    Private Sub SimpleButton4_Click(sender As System.Object, e As System.EventArgs) Handles SimpleButton4.Click
        Me.Close()
    End Sub

    Private Sub SimpleButton1_Click(sender As System.Object, e As System.EventArgs) Handles SimpleButton1.Click

        Dim PASS As String = InputBox("Please Input User Type Name ", "Add new User Type", "", "")

        If PASS.Trim = "" Then Exit Sub


        sql = "insert into M_USETYP(TYPE_NAME) Values('" & PASS.Trim & "')"
        If Execute(sql, cs, True) = False Then
            Exit Sub
        End If


        Type_Table = ReadSP("M_ALL_USER_TYPE", cs)
        Clear_list()
        SET_LIST()
        SET_LIST_DATA()

    End Sub

    Private Sub SimpleButton3_Click(sender As System.Object, e As System.EventArgs) Handles SimpleButton3.Click
        UPDATE_VALUE()
        Me.Close()
    End Sub

    Private Sub SimpleButton5_Click(sender As System.Object, e As System.EventArgs) Handles SimpleButton5.Click
        UPDATE_VALUE()



    End Sub

    Private Sub SimpleButton2_Click(sender As System.Object, e As System.EventArgs) Handles SimpleButton2.Click
        If ListBoxControl1.SelectedValue = "" Then Exit Sub

        sql = "Select * from M_USER_MASTER_ALL where UserGroup = '" & ListBoxControl1.SelectedValue & "'"
        Dim dt As DataTable = Read(sql, cs)

        If dt IsNot Nothing Then
            MessageBox.Show("Can not remove " & ListBoxControl1.SelectedValue & ".this type is in use. Please change user type to another type before.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If



        If MessageBox.Show("Do you want to remove : " & ListBoxControl1.SelectedValue & " ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> Windows.Forms.DialogResult.Yes Then Exit Sub



        sql = "Delete FROM M_USETYP WHERE TYPE_NAME ='" & ListBoxControl1.SelectedValue.ToString.Trim & "'"
        Execute(sql, cs)
        Type_Table = ReadSP("M_ALL_USER_TYPE", cs)
        Clear_list()
        SET_LIST()
        SET_LIST_DATA()


    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub
End Class