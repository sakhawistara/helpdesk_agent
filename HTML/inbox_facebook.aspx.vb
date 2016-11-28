Imports System.Data.SqlClient
Public Class inbox_facebook
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.QueryString("account") = "" Then
            sql_inbox_facebook.SelectCommand = "select * from fb_tGet_Header"
        Else
            sql_inbox_facebook.SelectCommand = "select * from fb_tGet_Header where facebook_Name='" & Request.QueryString("account") & "'"
        End If     
    End Sub
End Class