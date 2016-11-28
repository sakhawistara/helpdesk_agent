Imports System.Data
Imports System.Data.SqlClient
Public Class grouptype
    Inherits System.Web.UI.Page

    Dim Proses As New ClsConn
    Dim Sqldr As SqlDataReader
    Dim sql As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        sql_group_type.SelectCommand = "select * from mGroupType"
    End Sub
End Class