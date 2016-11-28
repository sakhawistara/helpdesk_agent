Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.UI
Partial Class popupKaryawan
    Inherits System.Web.UI.Page
    Dim ConnectionTest As New SqlConnection(ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString)
    Dim myInsert, mySelect, myUpdate, sqlcom As SqlCommand
    Dim sqlDr As SqlDataReader
    Dim penggunaAplikasi As String
    Dim valGroup, tableMaster As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim namDiv As String = Request.QueryString("div")
        'Response.Write(namDiv)
        'penggunaAplikasi = "Select ROW_NUMBER() OVER (ORDER BY name ASC) AS No, * from mKaryawan  WHERE Name LIKE '%" & Request.QueryString("kode") & "%'"
        'select ID, CustomerID, NamePIC, JenisKelamin, NomorHpPIC,NamaPerusahaan,Telepon,Email,Alamat FROM mCustomer
        penggunaAplikasi = "Select top 100 ROW_NUMBER() OVER (ORDER BY NamaPerusahaan ASC) AS No, * from mCustomer  WHERE NamaPerusahaan LIKE '" & Request.QueryString("kode") & "%' or CustomerID LIKE '" & Request.QueryString("kode") & "%'"
        sqlcom = New SqlCommand(penggunaAplikasi, ConnectionTest)
        ConnectionTest.Open()
        sqlDr = sqlcom.ExecuteReader()
        tableMaster = "<table cellspacing=1 width=100% style='background-color:#F5F5F5; color:#ffffff;' >"
        tableMaster &= "<tr style='background-color:#F37021;'>"
        tableMaster &= "<th style='width:100px;'>No</th>"
        tableMaster &= "<th style='width:150px;'>Customer ID</th>"
        tableMaster &= "<th>Customer Name</th>"
        'tableMaster &= " <th>Tanggal Lahir</th>"

        tableMaster &= "</tr>"
        While sqlDr.Read()

            tableMaster &= "<tr>"
            tableMaster &= "<th style='color:black;'>" & sqlDr("No").ToString & "</th>"
            'tableMaster &= "<th><a href=javascript:document.getElementById('MainContent_CallbackNik_TxtNik_I').value='" & sqlDr("CustomerID").ToString & "';javascript:toggleBox('" & namDiv & "',0) >" & sqlDr("CustomerID").ToString & "</a></th>"
            tableMaster &= "<th><a href=javascript:document.getElementById('MainContent_CallbackNik_ASPxPageControl1_TxtNik_I').value='" & sqlDr("CustomerID").ToString & "';javascript:toggleBox('" & namDiv & "',0) >" & sqlDr("CustomerID").ToString & "</a></th>"
            tableMaster &= "<th style='color:black;'>" & sqlDr("NamaPerusahaan").ToString & "</th>"
            'tableMaster &= "<th style='color:black;'>" & sqlDr("TanggalLahir").ToString & "</th>"
            tableMaster &= "</tr>"

        End While
        tableMaster &= "</table>"
        sqlDr.Close()
        ConnectionTest.Close()
        litQuery.Text = tableMaster
    End Sub
End Class
