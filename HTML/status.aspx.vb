Imports System.Data
Imports System.Data.SqlClient
Public Class status
    Inherits System.Web.UI.Page

    Dim Proses As New ClsConn
    Dim Sqldr As SqlDataReader
    Dim sql As String
    Dim value As String
    Dim status As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        sql_status.SelectCommand = "select * from mStatus"
    End Sub
End Class