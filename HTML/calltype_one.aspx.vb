Imports System.Data
Imports System.Data.SqlClient
Public Class calltype_one
    Inherits System.Web.UI.Page

    Dim Proses As New ClsConn
    Dim Sqldr As SqlDataReader
    Dim sql As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        sql_calltype_one.SelectCommand = "select mSubCategoryLv1.SubCategory1ID, mSubCategoryLv1.CategoryID, mCategory.Name, mSubCategoryLv1.SubName, mSubCategoryLv1.NA from mSubCategoryLv1 left outer join mCategory on mSubCategoryLv1.CategoryID = mCategory.CategoryID"
        sql_transaction_type.SelectCommand = "select * from mCategory"
    End Sub

    Private Sub gv_transaction_type_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs) Handles gv_transaction_type.RowDeleting
        sql_calltype_one.DeleteCommand = "delete from mSubCategoryLv1 where SubCategory1ID=@SubCategory1ID"
    End Sub

    Private Sub gv_transaction_type_RowInserting(sender As Object, e As DevExpress.Web.Data.ASPxDataInsertingEventArgs) Handles gv_transaction_type.RowInserting
        Dim Number, NLast, GenerateNoID As String
        sql = "select SUBSTRING(SubCategory1ID,5,5) as nourutAkhir from mSubCategoryLv1 order by ID desc"
        Sqldr = Proses.ExecuteReader(sql)
        If Sqldr.Read() Then
            Number = Sqldr("nourutAkhir").ToString
        End If
        Sqldr.Close()

        If Number = "" Then
            sql = "select  NLast = Right(10001 + COUNT(ID) + 0, 5)  from mSubCategoryLv1"
        Else
            sql = "select  NLast = Right(100" & Number & " + 1 + 0, 5)  from mSubCategoryLv1"
        End If
        Sqldr = Proses.ExecuteReader(sql)
        If Sqldr.Read() Then
            NLast = Sqldr("NLast").ToString
        End If
        Sqldr.Close()
        GenerateNoID = "CT1-" & NLast & ""
        sql_calltype_one.InsertCommand = "insert into mSubCategoryLv1 (CategoryID, SubCategory1ID, SubName, UserCreate) values(@CategoryID, '" & GenerateNoID & "', @SubName, '" & Session("UserName") & "')"
    End Sub
End Class