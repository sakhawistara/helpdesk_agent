Imports System.Data
Imports System.Data.SqlClient
Public Class email_address
    Inherits System.Web.UI.Page

    Dim Proses As New ClsConn
    Dim sqldr As SqlDataReader
    Dim sql As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        sql_email_address.SelectCommand = "Select * from mEmail_address"
    End Sub
    Protected Sub GRmCategori_CellEditorInitialize(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridView.ASPxGridViewEditorEventArgs) Handles GRmEmailSuzuki.CellEditorInitialize
        If GRmEmailSuzuki.IsNewRowEditing Then
            If e.Column.FieldName = "NA" Then
                e.Editor.Value = "Y"
            End If
        Else
            Dim val1, val2, val3 As String
            val1 = ""
            val2 = ""
            val3 = ""
            sql = "select * from mEmail_address where EmailAddress='" & GRmEmailSuzuki.GetRowValues(e.VisibleIndex, "EmailAddress") & "'"
            sqldr = Proses.ExecuteReader(sql)
            If sqldr.HasRows Then
                sqldr.Read()
                val1 = sqldr("NA")
            End If
            sqldr.Close()

            If e.Column.FieldName = "NA" Then
                e.Editor.Value = val1
            End If
        End If
    End Sub

    Protected Sub GRmEmailSuzuki_RowInserting(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataInsertingEventArgs) Handles GRmEmailSuzuki.RowInserting
        '====Untuk cek Jenis Transaksi sudah ada atau belum
        Dim cekEmailAddress As String
        cekEmailAddress = e.NewValues("EmailAddress").ToString()

        Dim cekTypeLevel As String
        cekTypeLevel = e.NewValues("TypeLevel").ToString()

        Dim SourceJenisTransaksi As String
        sql = "Select COUNT (EmailAddress) as CekTransaksi from mEmail_address where EmailAddress='" & cekEmailAddress & "' And TypeLevel='" & cekTypeLevel & "'"
        sqldr = Proses.ExecuteReader(sql)
        If sqldr.HasRows() Then
            sqldr.Read()
            SourceJenisTransaksi = sqldr("CekTransaksi")
        End If
        sqldr.Read()

        If SourceJenisTransaksi > 0 Then
            e.Cancel = True
            Throw New Exception(cekEmailAddress & " already exists")
        Else
            e.Cancel = False
        End If

        Dim sIDCategori As String
        sql = "select  NoID = Right(1000001 + COUNT(ID) + 0, 3)  from mEmail_address"
        sqldr = Proses.ExecuteReader(sql)
        If sqldr.HasRows() Then
            sqldr.Read()
            sIDCategori = sqldr("NoID")
        End If
        sqldr.Close()
        Dim Name As String = "EMA"
        Dim IdGenerate As String = Name & "-" & sIDCategori
        sql_email_address.InsertCommand = "INSERT INTO mEmail_address(EmailID, EmailAddress, TypeLevel, NA) values('" & IdGenerate & "', @EmailAddress, @TypeLevel,@NA) "
    End Sub

    Protected Sub GRmEmailSuzuki_RowUpdating(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs) Handles GRmEmailSuzuki.RowUpdating
        sql_email_address.UpdateCommand = "UPDATE mEmail_address SET EmailAddress=@EmailAddress, TypeLevel=@TypeLevel, NA=@NA where ID=@ID"
    End Sub

End Class