Imports System.Data.SqlClient
Public Class inbox_email
    Inherits System.Web.UI.Page

    Dim Proses As New ClsConn
    Dim sqldr As SqlDataReader
    Dim sql As String
    Dim valEmail As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.QueryString("reply") = "" Then
            sql_inbox_email.SelectCommand = "select top 10 * from IVC_EMAIL_IN_TM"
            div_compose.Visible = False
        Else
            div_table.Visible = False
            div_compose.Visible = True
            txt_to.Text = Request.QueryString("account")
        End If
    End Sub

    Private Sub btn_compose_Click(sender As Object, e As EventArgs) Handles btn_compose.Click
        If Request.QueryString("reply") = "" Then
            div_table.Visible = False
            div_compose.Visible = True
        Else
            txt_to.Text = ""
            div_table.Visible = False
            div_compose.Visible = True
        End If
    End Sub
End Class