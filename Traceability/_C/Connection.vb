

Imports System.Data
Imports System.Configuration
Imports System.Data.OleDb
Imports System.Data.SqlClient
'Imports System.Data.SqlServerCe

Namespace SQLConnect

    Public Class _SQL
        Public Shared Event ConnectionStat_Fail(ByVal ex As Exception)
        Public Shared Function ConnectionInitial(ByVal conStr As SqlConnectionStringBuilder) As Boolean
            Try
                Using da = New SqlDataAdapter("SELECT getdate()", New SqlConnection(cs))
                    'Using da = New SqlDataAdapter("SELECT getdate()", New SqlConnection(myConStr))
                    Using ds = New DataSet
                        da.Fill(ds)
                        Return True
                    End Using
                End Using
            Catch ex As Exception
                RaiseEvent ConnectionStat_Fail(ex)
                Return False
            End Try
        End Function
        Public Shared Function Read(ByVal sql As String) As DataTable 'Read sql data



            Read = Nothing
            Try
                Using da = New SqlDataAdapter(sql, New SqlConnection(cs))
                    'Using da = New SqlDataAdapter(sql, New SqlConnection(myConStr))
                    Using ds = New DataSet
                        da.Fill(ds)
                        If (ds.Tables(0).Rows.Count <> 0) Then
                            Return ds.Tables(0)
                        Else
                            Return Nothing
                        End If
                    End Using
                End Using



            Catch ex As Exception
                RaiseEvent ConnectionStat_Fail(ex)


                MessageBox.Show(ex.Message & vbCrLf & sql, "Message 00001", MessageBoxButtons.OK, MessageBoxIcon.Error)

                'MessageBox.Show(ex.Message & vbCrLf, "Message 00001", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try
        End Function


        Public Shared Function Execute(ByVal sql As String) As Boolean  'Run Exceute data
            Execute = False
            Try
                Using com = New SqlDataAdapter(sql, New SqlConnection(cs))
                    com.Fill(New DataSet)
                    Return True
                End Using


                'Using com As New SqlCommand(sql, New SqlConnection(My.Settings.ConnString))
                '    com.CommandTimeout = 200
                '    com.ExecuteNonQuery()
                '    Return True
                'End Using
            Catch ex As Exception
                RaiseEvent ConnectionStat_Fail(ex)
                '  MessageBox.Show(ex.Message)
                'If ShowERRMsg = True Then
                '    MessageBox.Show(ex.Message & vbCrLf & sql, "Message 00002", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'Else
                '    'MessageBox.Show(ex.Message & vbCrLf, "Message 00002", MessageBoxButtons.OK, MessageBoxIcon.Error)

                'End If


            End Try
        End Function


        Public Shared Function ReadSP(ByVal CommandString As String, Optional ByVal pParameter() As SqlParameter = Nothing) As DataTable
            ReadSP = Nothing

            Dim obj_sql_con As New SqlConnection(cs)
            Dim obj_sql_cmd As New SqlCommand(CommandString, obj_sql_con)

            obj_sql_cmd.CommandType = CommandType.StoredProcedure

            If pParameter IsNot Nothing Then
                For Each p As SqlParameter In pParameter
                    obj_sql_cmd.Parameters.Add(p)
                Next
            End If


            Dim obj_sql_adt As New SqlDataAdapter(obj_sql_cmd)
            Dim DT As New DataTable


            Try
                obj_sql_con.Open()

                obj_sql_adt.Fill(DT)
                obj_sql_adt.Dispose()
                obj_sql_adt = Nothing

                obj_sql_con.Close()

                Return DT
            Catch ex As Exception
                RaiseEvent ConnectionStat_Fail(ex)

                '  MessageBox.Show(ex.Message & vbCrLf, "Message 00002", MessageBoxButtons.OK)




            End Try
        End Function


        Public Shared Function ExcuteSP(ByVal CommandString As String, ByVal pParameter() As SqlParameter) As Boolean
            Dim obj_sql_con As New SqlConnection(cs)
            Dim obj_sql_cmd As New SqlCommand(CommandString, obj_sql_con)

            obj_sql_cmd.CommandType = CommandType.StoredProcedure

            For Each p As SqlParameter In pParameter
                obj_sql_cmd.Parameters.Add(p)
            Next

            Dim return_result As Boolean = False
            Try
                obj_sql_con.Open()

                obj_sql_cmd.ExecuteNonQuery()
                return_result = True

                obj_sql_con.Close()

                Return return_result
            Catch exp As Exception
                If obj_sql_con.State = ConnectionState.Open Then
                    obj_sql_con.Close()
                End If

                Throw New Exception("Failed to execute command. " & exp.Message & " Query : " & CommandString)
            End Try
        End Function


    End Class



End Namespace