Imports MySql.Data.MySqlClient

Public Class Form1
    Private tilkobling As MySqlConnection
    Private serverName As String = "mysql.stud.iie.ntnu.no"
    Private dbName As String = "sondg"
    Private userID As String = "sondg"
    Private userPWD As String = "7ppasexr"

    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        tilkobling.Close()
        tilkobling.Dispose()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tilkobling = New MySqlConnection(String.Format("Server={0};Database={1};Uid={2};Pwd={3};", serverName, dbName, userID, userPWD))
        tilkobling.Open()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sql As New MySqlCommand("select * from Brukere where brukernavn=@brukernavn and passord=@passord", tilkobling)
        sql.Parameters.AddWithValue("@brukernavn", TextBox1.Text)
        sql.Parameters.AddWithValue("@passord", TextBox2.Text)
        Console.WriteLine("SQL-spørringen er: " & sql.CommandText)

        Dim da As New MySqlDataAdapter
        Dim interTabell As New DataTable
        da.SelectCommand = sql
        da.Fill(interTabell)

        If interTabell.Rows.Count > 0 Then
            MsgBox("Logget på")
        Else
            MsgBox("Feil brukernavn eller passord")
        End If
    End Sub
End Class
