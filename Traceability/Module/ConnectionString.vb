Module ConnectionString

    Public cs As String = "Server = " & My.Settings.Server & ";Database = " & My.Settings.Database & ";User Id = " & My.Settings.Username_DB & ";Password = " & My.Settings.Password_DB & ";" & "Connection Timeout=" & My.Settings.Timeout & ";"
    Public cs_MRP As String = "Server = " & My.Settings.Server_MRP & ";Database = " & My.Settings.Database_MRP & ";User Id = " & My.Settings.Username_DB_MRP & ";Password = " & My.Settings.Password_DB_MRP & ";" & "Connection Timeout=" & My.Settings.Timeout_MRP & ";"
    Public css As String = "Provider=Microsoft.ACE.Oledb.12.0; Data Source=" + My.Settings.dbAccessPaht + ";"

End Module
