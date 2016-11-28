Imports System
Imports System.Data.SqlClient
Imports System.Data
Imports Microsoft.SqlServer.Management.Smo
Imports Microsoft.SqlServer.Management.Common
Public Class app
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        
    End Sub

    Protected Sub CreateTable(sender As Object, e As EventArgs)
        
    End Sub

    Private Sub btn_test_Click(sender As Object, e As EventArgs) Handles btn_test.Click
        Dim query As String = "IF OBJECT_ID('dbo.show_invision', 'U') IS NULL "
        query += "BEGIN "
        query += "CREATE TABLE [dbo].[CustomersTest]("
        query += "[CustomerId] INT IDENTITY(1,1) NOT NULL CONSTRAINT pkCustomerId PRIMARY KEY,"
        query += "[Name] VARCHAR(100) NOT NULL,"
        query += "[Country] VARCHAR(50) NOT NULL"
        query += ")"
        query += " END"
        Dim constr As String = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand(query)
                cmd.Connection = con
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End Using
        End Using
    End Sub
End Class