Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.UI
Partial Class karyawan
    Inherits System.Web.UI.Page

    Protected Sub Kategori_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SqlDataSource1.SelectCommand = "Select ID,NIK,Name,Handphone,Email,JenisKelamin,SUBSTRING(TanggalLahir,1,10) as TanggalLahir,Address,Divisi from mKaryawan "
        SqlDataSource1.InsertCommand = "insert into mKaryawan(NIK,Name,Handphone,Email,JenisKelamin,TanggalLahir,Address,Divisi) values (@NIK,@Name,@Handphone,@Email,@JenisKelamin,@TanggalLahir,@Address,@Divisi)"
        SqlDataSource1.UpdateCommand = "update mKaryawan set NIK=@NIK,Name=@Name,Handphone=@Handphone,Email=@Email,JenisKelamin=@JenisKelamin,TanggalLahir=@TanggalLahir,Address=@Address,Divisi=@Divisi where ID=@ID"
        SqlDataSource1.DeleteCommand = "delete from mKaryawan where ID=@ID"
    End Sub
End Class