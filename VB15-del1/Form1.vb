Imports MySql.Data.MySqlClient

Public Class Form1
    Private tilkobling As MySqlConnection

    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        tilkobling.Close()
        tilkobling.Dispose()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tilkobling = New MySqlConnection("Server=mysql.stud.iie.ntnu.no;Database=sondg;Uid=sondg;Pwd=7ppasexr")
        tilkobling.Open()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sqlSporring = "select * from Brukere where brukernavn='" & TextBox1.Text & "' and passord='" & TextBox2.Text & "'"
        Dim sql As New MySqlCommand(sqlSporring, tilkobling)
        MsgBox("SQL-spørringen er: " & sqlSporring)

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
