Imports System.Data
Imports System.Data.SqlClient
Public Class customer
    Inherits System.Web.UI.Page

    Dim Proses As New ClsConn
    Dim sqldr As SqlDataReader
    Dim sql As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
       
    End Sub
    Private Sub gv_customer_CommandButtonInitialize(sender As Object, e As DevExpress.Web.ASPxGridView.ASPxGridViewCommandButtonEventArgs) Handles gv_customer.CommandButtonInitialize
        If Session("LoginType") = "Admin" Then
            e.Visible = True
        Else
            e.Visible = True
        End If
    End Sub
    Protected Sub gv_customer_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles gv_customer.Init
        sql_customer.SelectCommand = "select top 10000 ID, CustomerID, NamaPerusahaan, NamePIC, Birth, JenisKelamin, NomorHpPIC,Telepon,Email,CusStatus,City,Region,Alamat,Facebook,Twitter FROM mCustomer "
    End Sub

    Protected Sub gv_customer_RowUpdating(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs) Handles gv_customer.RowUpdating
        sql_customer.UpdateCommand = "UPDATE mCustomer Set NamePIC=@NamePIC, NamaPerusahaan=@NamaPerusahaan, Birth=@Birth, JenisKelamin=@JenisKelamin , NomorHpPIC=@NomorHpPIC, Telepon=@Telepon, Email=@Email, CusStatus=@CusStatus, City=@City, Region=@Region, Alamat=@Alamat, Facebook=@Facebook, Twitter=@Twitter where ID=@ID"
    End Sub

    Protected Sub gv_customer_RowDeleting(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataDeletingEventArgs) Handles gv_customer.RowDeleting
        sql_customer.DeleteCommand = "DELETE FROM mCustomer where ID=@ID"
    End Sub

    Protected Sub gv_customer_RowInserting(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataInsertingEventArgs) Handles gv_customer.RowInserting
        Dim IDTgl As String = Date.Now.ToString("MMyy")
        Dim GetID As String = ""
        Dim IDMerk As String = ""
        sql = " select  AngkaTerakhir = Right(1000001 + COUNT(ID) + 0, 4)  from mCustomer "
        sqldr = Proses.ExecuteReader(sql)
        If sqldr.HasRows Then
            sqldr.Read()
            IDMerk = sqldr("AngkaTerakhir").ToString
        End If
        sqldr.Close()
        Dim IDGenerate As String = IDMerk & IDTgl
        sql_customer.InsertCommand = "INSERT INTO mCustomer(CustomerID, NamaPerusahaan, NamePIC, Birth, JenisKelamin, NomorHpPIC, Telepon, City, Region, Email, CusStatus, Alamat, Facebook, Twitter ) values('" & IDGenerate & "', @NamaPerusahaan, @NamePIC, @Birth, @JenisKelamin, @NomorHpPIC, @Telepon, @City,@Region, @Email, @CusStatus, @Alamat, @Facebook, @Twitter) "
    End Sub

    Protected Sub DsRegion_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles sql_region.Init
        sql_region.SelectCommand = "Select * from MRegion Where RegionStatus='Y'"
    End Sub
End Class