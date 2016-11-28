Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Timers
Imports System.Data.OleDb
Public Class allpostMP
    Inherits System.Web.UI.Page
    Dim Con As New SqlConnection(ConfigurationManager.ConnectionStrings("SosmedConnection").ConnectionString)
    Dim Com As SqlCommand
    Dim Dr As SqlDataReader

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub btnfacebook_Click(sender As Object, e As EventArgs) Handles btnfacebook.Click
      
        Try
            Dim actagent As String = "insert into mslog (Username, Flag, Data, datetime) values ('" & Session("username") & "', 'Facebook Post', '" & txtfacebook.Value & "', GETDATE())"
            Com = New SqlCommand(actagent, Con)
            Con.Open()
            Com.ExecuteNonQuery()
            Con.Close()

            Dim InsertFB As String = "insert into fb_tPost_Message (Message, Agent) values ('" & txtfacebook.Value & "', '" & Session("username") & "')"
            Com = New SqlCommand(InsertFB, Con)
            Con.Open()
            Com.ExecuteNonQuery()
            Con.Close()
            ' MsgBox("your post has been sent", MsgBoxStyle.Information)
            If cbpantau.Checked Then
                Dim pantau As String = ""
            End If
            txtfacebook.Value = ""
        Catch ex As Exception
            Response.Write(DirectCast("", String))
        End Try
       
        txtfacebook.Value = ""
    End Sub

    Private Sub btntwitter_Click(sender As Object, e As EventArgs) Handles btntwitter.Click
        Try
            Dim actagent As String = "insert into mslog (Username, Flag, Data, datetime) values ('" & Session("username") & "', 'Twitter Post', '" & txttwittter.Value & "', GETDATE())"
            Com = New SqlCommand(actagent, Con)
            Con.Open()
            Com.ExecuteNonQuery()
            Con.Close()

            Dim insertTW As String = "insert into tw_tPost_Message (Message, Agent) VALUES ('" & txttwittter.Value & "', '" & Session("username") & "')"
            Com = New SqlCommand(insertTW, Con)
            Con.Open()
            Com.ExecuteNonQuery()
            Con.Close()
            'MsgBox("your tweet has been sent", MsgBoxStyle.Information)
            txttwittter.Value = ""
        Catch ex As Exception
            Response.Write(DirectCast("", String))
        End Try

    End Sub
End Class