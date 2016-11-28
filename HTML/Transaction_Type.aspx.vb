Imports System.Data
Imports System.Data.SqlClient
Public Class Transaction_Type
    Inherits System.Web.UI.Page

    Dim Proses As New ClsConn
    Dim sqldr As SqlDataReader
    Dim sql As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        sql_transaction_type.SelectCommand = "SELECT * FROM MCATEGORY"
    End Sub

    Private Sub gv_transaction_type_RowInserting(sender As Object, e As DevExpress.Web.Data.ASPxDataInsertingEventArgs) Handles gv_transaction_type.RowInserting
        Dim cekJenisTransaksi As String
        cekJenisTransaksi = e.NewValues("Name").ToString()

        Dim jTransaksi As String
        sql = "Select COUNT (Name) as CekTransaksi from mCategory where Name='" & cekJenisTransaksi & "'"
        sqldr = Proses.ExecuteReader(sql)
        If sqldr.Read Then
            jTransaksi = sqldr("CekTransaksi")
        End If
        sqldr.Close()
        If jTransaksi > 0 Then
            e.Cancel = True
            Throw New Exception(cekJenisTransaksi & " already exists")
        Else
            e.Cancel = False
        End If

        Dim NoUrut, Angka, GenerateNoID As String
        sql = "select SUBSTRING(CategoryID,5,5) as NoUrut from mCategory order by ID desc"
        sqldr = Proses.ExecuteReader(sql)
        If sqldr.Read Then
            NoUrut = sqldr("NoUrut").ToString
        End If
        sqldr.Close()

        If NoUrut = "" Then
            sql = "select  Angka = Right(10001 + COUNT(ID) + 0, 5)  from mCategory"
        Else
            sql = "select  Angka = Right(100" & NoUrut & " + 1 + 0, 5)  from mCategory "
        End If
        sqldr = Proses.ExecuteReader(sql)
        If sqldr.Read Then
            Angka = sqldr("Angka").ToString
        End If
        sqldr.Close()

        GenerateNoID = "CAT-" & Angka & ""

        Dim Name As String
        Name = e.NewValues("Name").ToString()
        sql_transaction_type.InsertCommand = "INSERT INTO mCategory(CategoryID, Name, UserCreate, DateCreate) values('" & GenerateNoID & "', @Name, '" & Session("UserName") & "', GETDATE()) "
    End Sub
End Class