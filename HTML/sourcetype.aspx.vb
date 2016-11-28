Imports System
Imports System.Data.SqlClient
Public Class sourcetype
    Inherits System.Web.UI.Page

    Dim Proses As New ClsConn
    Dim Sqldr As SqlDataReader
    Dim sql As String
    Dim value As String
    Dim status As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        sql_source_type.SelectCommand = "select * from mSourceType"
        sql_source_type.InsertCommand = "insert into mSourceType (Name,TicketIDCode,NA,UserCreate,DateCreate) values (@Name, @TicketIDCode, @NA, 'UserCreate', getdate())"
        sql_source_type.UpdateCommand = "update mSourceType set Name=@Name, NA=@NA, UserUpdate='UserUpdate', DateUpdate=getdate() where TypeID=@TypeID"
    End Sub
End Class