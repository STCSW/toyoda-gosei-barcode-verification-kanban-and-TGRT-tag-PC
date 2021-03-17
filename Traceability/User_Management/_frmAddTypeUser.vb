Imports System.Text

Public Class _frmAddTypeUser
    Private DT As New DataTable

    Private Sub _frmAddTypeUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call SET_DGW_ChECK_BOX()
        Call Getdata_LIST_TYPE_NAME()
        Call Getdata()
    End Sub


    Private Sub SET_DGW_ChECK_BOX()
        Dim ckbCol1 As DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()



        dgw1.Columns.Add(ckbCol1)



        With ckbCol1
            .DataPropertyName = "Allow"  ''//if u want to bind it to a table or something
            .HeaderText = "Allow"
            .Name = "Allow"
            '//Now the important stuff follows!
            .FalseValue = "0"
            .TrueValue = "1"
        End With


    End Sub

    Public Sub Getdata()
        Try
            Dim Select_TYPE_NAME As String = ""

            For i As Integer = 0 To ListBox1.SelectedItems.Count - 1

                Select_TYPE_NAME = ListBox1.SelectedItems(i).ToString()

            Next i

            If Select_TYPE_NAME = "" Then
                Select_TYPE_NAME = "Admin"
            End If

            Dim StrSQL As New StringBuilder()

            StrSQL.Append(" SELECT * FROM [Tbl_USETYP] where [TYPE_NAME] = '" & Select_TYPE_NAME & "'")

            Dim dataTable As New DataTable
            dataTable = DatabaseConnection.OleDBConnect.Access.Read(StrSQL.ToString, css, False)

            DT = New DataTable

            DT.Columns.Add("NO", GetType(Int32))
            DT.Columns.Add("TYPE NAME", GetType(String))
            DT.Columns.Add("Permission", GetType(String))
            DT.Columns.Add("Allow", GetType(Int32))

            For col = 1 To dataTable.Columns.Count - 1

                Dim typeName As String = dataTable.Rows(0)("TYPE_NAME").ToString()
                Dim columnName As String = dataTable.Columns(col).ColumnName.ToString()
                Dim status As Int32 = Convert.ToInt32(dataTable.Rows(0)(col))

                DT.Rows.Add(col, typeName, columnName, status)

            Next

            dgw1.DataSource = DT
            dgw1.Columns("Allow").DisplayIndex = dgw1.ColumnCount - 1
            dgw1.Columns("Allow").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Public Sub Getdata_LIST_TYPE_NAME()
        Try
            Dim StrSQL As New StringBuilder()

            StrSQL.Append(" SELECT TYPE_NAME ")
            StrSQL.Append(" FROM Tbl_USETYP")

            DT = DatabaseConnection.OleDBConnect.Access.Read(StrSQL.ToString, css, False)

            ListBox1.Items.Clear()
            For i = 0 To DT.Rows.Count - 1
                ListBox1.Items.Add(DT.Rows(i).Item("TYPE_NAME"))
            Next i

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

   
    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        Call Getdata()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Call Save_Type()
        Me.Close()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Call Save_Type()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Call Add_Type()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Call Remove_Type()
    End Sub

    Private Sub Save_Type()
        Dim StrSQL As New StringBuilder()
        With StrSQL
            .Remove(0, .Length)
            .Append("UPDATE [Tbl_USETYP] SET ")
            For i = 0 To DT.Rows.Count - 1
                If i <> 0 Then
                    .Append(",")
                End If
                .Append(DT.Rows(i).Item("Permission").ToString & " = " & DT.Rows(i).Item("Allow"))
            Next i
            .Append(" WHERE [TYPE_NAME] ='" & DT.Rows(0).Item("TYPE NAME").ToString & "'")

            DatabaseConnection.OleDBConnect.Access.Execute(StrSQL.ToString, css, True)

        End With

        MessageBox.Show("Save Complete", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub
    Private Sub Add_Type()
        Dim Mystring As String
        Mystring = InputBox("Please enter New Type User", "Request Type User", Nothing)
        If Mystring.Trim = "" Then
            MessageBox.Show("Please enter New Type User", "Fail.", MessageBoxButtons.OK)
            Exit Sub

        End If

        Dim StrSQL As New StringBuilder()
        Dim DT_tmp As New DataTable
        With StrSQL
            .Remove(0, .Length)
            StrSQL.Append(" SELECT  [TYPE_NAME] ")
            StrSQL.Append(" FROM [Tbl_USETYP]")
            StrSQL.Append(" where [TYPE_NAME] ='" & Mystring & "'")

            DT_tmp = DatabaseConnection.OleDBConnect.Access.Read(StrSQL.ToString, css, True)

            If Not DT_tmp Is Nothing Then
                If DT_tmp.Rows.Count > 0 Then
                    MessageBox.Show(" Type user Already use.")
                    Exit Sub
                End If
            End If

            .Remove(0, .Length)
            .Append("INSERT INTO [Tbl_USETYP] ")
            .Append("([TYPE_NAME],[User_Management],[Master_Product],[Import_Product],[Barcode_Verify],[Report_Barcode_Verify])")
            .Append(" VALUES ")
            .Append("('" & Mystring & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "')")

            DatabaseConnection.OleDBConnect.Access.Execute(StrSQL.ToString, css, True)

        End With

        Call Getdata_LIST_TYPE_NAME()
        ListBox1.SelectedItem = Mystring.Trim

        MessageBox.Show("Add type user : " & ListBox1.SelectedItem.ToString & " compleate.")
    End Sub
    Private Sub Remove_Type()
        Dim Mystring As String

        Dim StrSQL As New StringBuilder()
        Dim DT_tmp As New DataTable
        With StrSQL
            .Remove(0, .Length)
            StrSQL.Append(" SELECT  [UserType] ")
            StrSQL.Append(" FROM [tbUser]")
            StrSQL.Append(" where [UserType] ='" & ListBox1.SelectedItem.ToString & "'")

            DT_tmp = DatabaseConnection.OleDBConnect.Access.Read(StrSQL.ToString, css, True)
            If Not DT_tmp Is Nothing Then
                If DT_tmp.Rows.Count > 0 Then
                    MessageBox.Show(" Can't delete User type Because Have user use this user type.")
                    Exit Sub
                End If
            End If

            .Remove(0, .Length)
            .Append("DELETE FROM [Tbl_USETYP] ")
            .Append("where [TYPE_NAME]='" & ListBox1.SelectedItem.ToString & "'")

            DatabaseConnection.OleDBConnect.Access.Execute(StrSQL.ToString, css, True)

        End With

        MessageBox.Show("Delete type user : " & ListBox1.SelectedItem.ToString & " compleate.")
        ListBox1.Items.RemoveAt(ListBox1.SelectedIndex)
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Close()
    End Sub
End Class