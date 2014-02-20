'' MySQL_Connection Class
''
'' Purpose:
''      To facilitate easy access to a MySQL database in VB.net
''
''
'' Usage:
''
'' '' create an instance of the MySQL_Connection class
'' Dim sqlConn As New MySQL_Connection
''
'' '' you can set the properties and call openConnection()...
'' sqlConn.server = srv
'' sqlConn.username = user
'' sqlConn.password = pw
'' sqlConn.database = db
'' If (sqlConn.openConnection()) Then
''
'' '' or instead you can use the overloaded method and just pass the parameters
'' If (sqlConn.openConnection(srv, user, pw, db)) Then
''
''
'' '' openConnection() methods return a boolean (true = connection was opened successfully)
''
''
'' Queries:
''
'' '' SELECT for a single value (a string containing the data from one record, one column)
'' '' (returns a string, query is a string representing the MySQL query)
'' selectQueryForSingleValue(query)
''
'' '' SELECT for multiple values (multiple records and/or multiple columns)
'' '' (returns a List(Of Dictionary(Of String, String)) where each Dictionary() represents one record
'' '' and contains key/value pairs (strings) for each column/data; query is a string representing MySQL query)
'' selectQuery(query)
''
''
'' '' SELECT with parameterized values to protect against SQL injection
'' '' (returns the same way as a regular multiple value selectQuery() but takes a second parameter,
'' '' a Dictionary(Of String, String) containing key/value pairs to substitute into the query String
''
'' '' Usage example:
''
''    '' create query string
''    Dim query As String = "SELECT * FROM envelope WHERE church=@ID AND title=@TITLE"
''    
''    '' create dictionary of parameters
''    Dim params As New Dictionary(Of String, String)

''    '' here you programattically or manually add the key/value dictionaries to the params() array
''    params.Add("ID", "0105")
''    params.Add("TITLE", "WEEKLY")

''    '' now call your select query
''    Dim results As New List(Of Dictionary(Of String, String))
''    results = selectQuery(query, params)

''    '' if there are records returned
''    If (results.Count > 0) Then
''        MessageBox.Show("Returned " & results.Count.ToString & " results")
''    Else
''        MessageBox.Show("No results returned.")
''    End If
''
''
''
''
'' '' INSERT, UPDATE, DELETE
'' '' (return an integer representing the number of rows affected, query is a string representing the MySQL query)
'' insertQuery(query)
'' updateQuery(query)
'' deleteQuery(query)
''
''
'' Working with data returned from SELECT selectQuery(query)
''
'' '' display key/value pairs of all records returned
'' Dim query As String = "select * from envelopes where church='a0101'"
'' Dim results As New List(Of Dictionary(Of String, String))
'' results = sqlConn.selectQuery(query)
'' '' if there are results
'' If (results.Count > 0) Then
''      '' for each record returned from the SELECT query...
''      For Each record As Dictionary(Of String, String) In results
''          '' loop through all fields in the record (for demonstration)
''          For Each pair As KeyValuePair(Of String, String) In record
''              MessageBox.Show("heading: " & pair.Key & " data: " & pair.Value)
''          Next
''      Next




Imports MySql.Data.MySqlClient
Imports MySql.Data

Public Class MySQL_Connection
    'Public query As String
    'Public sqlCommand As MySqlCommand
    'Public sqlDataReader As MySqlDataReader

    Private srv As String = ""
    Private user As String = ""
    Private pw As String = ""
    Private db As String = ""
    Private dboptions As String = ""
    Private conn As MySqlConnection
    Private comm As MySqlCommand
    Private data As MySqlDataAdapter

    'Public Sub test()
    '    '' '' create query string
    '    Dim query As String = "SELECT * FROM envelope WHERE church=@ID AND title=@TITLE"
    '    ''
    '    '' create dictionary of parameters
    '    Dim params As New Dictionary(Of String, String)

    '    '' here you programattically or manually add the key/value dictionaries to the params() array
    '    params.Add("ID", "0105")
    '    params.Add("TITLE", "WEEKLY")

    '    '' now call your select query
    '    Dim results As New List(Of Dictionary(Of String, String))
    '    results = selectQuery(query, params)

    '    '' if there are records returned
    '    If (results.Count > 0) Then
    '        MessageBox.Show("Returned " & results.Count.ToString & " results")
    '    Else
    '        MessageBox.Show("No results returned.")
    '    End If

    'End Sub

    'Public dbConnection As New MySqlConnection("Data Source=" & server & "; user id=" & userID & "; password=" & password & "; database=" & database)

    Property database() As String
        Get
            Return db
        End Get

        Set(value As String)
            db = value
        End Set
    End Property

    Property server() As String
        Get
            Return srv
        End Get

        Set(value As String)
            srv = value
        End Set
    End Property

    Property username() As String
        Get
            Return user
        End Get

        Set(value As String)
            user = value
        End Set
    End Property

    Property password() As String
        Get
            Return pw
        End Get

        Set(value As String)
            pw = value
        End Set
    End Property

    Property options() As String
        Get
            Return dboptions
        End Get

        Set(value As String)
            dboptions = value
        End Set
    End Property

    ReadOnly Property connection As MySqlConnection
        Get
            Return conn
        End Get
    End Property


    '' open a connection based on the properties that have been set manually prior to this being called
    Public Overloads Function openConnection() As Boolean
        If ((srv <> "") And (user <> "") And (pw <> "") And (db <> "")) Then
            Try
                Dim str As String = "Data Source=" & srv & "; user id=" & user & "; password=" & pw & "; database=" & db
                If (dboptions <> "") Then
                    str = str & "; " & dboptions
                End If

                conn = New MySqlConnection(str)
                conn.Open()
                Return True
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
                Return False
            End Try

        Else
            MessageBox.Show("Error: one of the connection parameters is empty")
            Return False
        End If
    End Function

    '' opens a connection based on the parameters that are sent to this function
    Public Overloads Function openConnection(ByVal serverAddress As String, ByVal userName As String, ByVal password As String, ByVal database As String, Optional ByVal options As String = "") As Boolean
        'If ((serverAddress <> "") And (userName <> "") And (password <> "") And (database <> "")) Then
        '    Try
        '        Dim str As String = "Data Source=" & serverAddress & "; user id=" & userName & "; password=" & password & "; database=" & database
        '        conn = New MySqlConnection(str)
        '        conn.Open()
        '        Return True
        '    Catch ex As Exception
        '        MessageBox.Show("Error: " & ex.Message)
        '        Return False
        '    End Try

        'Else
        '    MessageBox.Show("Error: one of the connection parameters is empty")
        '    Return False
        'End If

        '' set the properties, then run the non-overloaded method
        srv = serverAddress
        user = userName
        pw = password
        db = database
        If (options <> "") Then
            dboptions = options
        End If

        Return openConnection()
    End Function


    Public Sub closeConnection()
        conn.Close()
    End Sub

    '' a select query where you expect only one string returned (one column of one record)
    Public Function selectQueryForSingleValue(ByVal query As String) As String
        comm = New MySqlCommand(query, conn)
        Return Convert.ToString(comm.ExecuteScalar())
    End Function


    '' a select query where you expect (the possibility of) multiple columns and/or multiple records
    '' returns a List(Of Dictionary(Of String, String)) of all the records
    '' where each List.item is a record
    '' and each Dictionary is (key, value) representing each column in the record
    Public Overloads Function selectQuery(ByVal query As String) As List(Of Dictionary(Of String, String))
        comm = New MySqlCommand(query, conn)
        Dim allRecords As New List(Of Dictionary(Of String, String))
        Dim record As Dictionary(Of String, String)

        Dim reader As MySqlDataReader = comm.ExecuteReader()

        '' if there are results
        If reader.HasRows Then

            '' while there are still rows
            While reader.Read()
                '' create a new dictionary for the record
                record = New Dictionary(Of String, String)
                '' add each column and value to the dictionary
                For i As Integer = 0 To (reader.FieldCount - 1)
                    record.Add(reader.GetName(i), reader(i).ToString)
                Next

                '' add the dictionary to the List
                allRecords.Add(record)

            End While

        End If

        reader.Close()

        Return allRecords
    End Function

    '' performs a SELECT query after first parameterizing values to protect against SQL injection
    '' takes two parameters:
    '' query As String is the SQL-syntax query, with values replaced by @ aliases, e.g. "SELECT * FROM table WHERE id=@ID"
    '' valuesToParameterize() As Array of Dictionary(Of String, String) where
    '' each (String, String) is a key/value pair for the substitution, e.g. ("@ID", "1234")
    '' returns a List(Of Dictionary(Of String, String)) containing the results of the query
    Public Overloads Function selectQuery(ByVal query As String, valuesToParameterize As Dictionary(Of String, String)) As List(Of Dictionary(Of String, String))
        comm = New MySqlCommand(query, conn)
        comm.CommandText = query

        '' loop through the array of substitutions
        For Each pair In valuesToParameterize
            '' and turn each into a parameter on the MySqlCommand
            comm.Parameters.AddWithValue(pair.Key, pair.Value)
        Next

        '' perform the same SQL SELECT as the original method
        Dim allRecords As New List(Of Dictionary(Of String, String))
        Dim record As Dictionary(Of String, String)

        Dim reader As MySqlDataReader = comm.ExecuteReader()

        '' if there are results
        If reader.HasRows Then

            '' while there are still rows
            While reader.Read()
                '' create a new dictionary for the record
                record = New Dictionary(Of String, String)
                '' add each column and value to the dictionary
                For i As Integer = 0 To (reader.FieldCount - 1)
                    record.Add(reader.GetName(i), reader(i).ToString)
                Next

                '' add the dictionary to the List
                allRecords.Add(record)

            End While

        End If

        reader.Close()

        Return allRecords
    End Function

    '' an insert query, returns the number of rows affected
    Public Function insertQuery(ByVal query As String) As Integer
        comm = New MySqlCommand(query, conn)
        Return comm.ExecuteNonQuery()
    End Function

    '' updating is essentially the same as inserting
    '' returns the number of rows affected
    Public Function updateQuery(ByVal query As String) As Integer
        Return insertQuery(query)
    End Function

    '' deleting is essentially the same as inserting
    '' returns the number of rows affected
    Public Function deleteQuery(ByVal query As String) As Integer
        Return insertQuery(query)
    End Function


End Class
