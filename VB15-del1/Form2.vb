Imports System.ComponentModel

Public Class Form2
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Dispose()
    End Sub

    Private Sub Form2_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Me.Dispose() 'mostly incase I for some ungodly reason decide to write something actually useful
    End Sub

    Public Sub upd(brukernavn As String, vits As String)
        Me.Text = brukernavn
        Me.Label1.Text = vits
    End Sub
End Class