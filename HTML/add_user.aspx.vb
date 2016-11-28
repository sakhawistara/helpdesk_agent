Imports System
Imports System.Data.SqlClient
Public Class add_user
    Inherits System.Web.UI.Page

    Dim conn As New SqlConnection(ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString)
    Dim Prosess As New ClsConn
    Dim sqlDr As SqlDataReader
    Dim sql As String
    Protected Sub ASPxGridView1_RowInserting(sender As Object, e As DevExpress.Web.Data.ASPxDataInsertingEventArgs) Handles ASPxGridView1.RowInserting
        Dim cekUserNameID, cekPassword, cekCroName, cekLevelUser, cekNikUser As String
        cekLevelUser = ""
        cekCroName = ""
        cekUserNameID = e.NewValues("UserName").ToString()
        cekPassword = e.NewValues("Password").ToString()
        cekLevelUser = e.NewValues("LevelUser").ToString()
        cekNikUser = e.NewValues("NIK").ToString()
        If cekLevelUser <> "" And cekNikUser <> "" Then
            Dim CroID As String
            sql = "Select COUNT (UserID) as AdaApaGak from msUser where UserName='" & cekUserNameID & "' and LevelUser='" & cekLevelUser & "'"
            Try
                sqlDr = Prosess.ExecuteReader(sql)
                If sqlDr.Read Then
                    CroID = sqlDr("AdaApaGak")
                End If
                sqlDr.Close()
                conn.Close()
                If CroID > 0 Then
                    e.Cancel = True
                    Throw New Exception(cekUserNameID & " Sudah Ada")
                Else
                    e.Cancel = False
                End If
            Catch ex As Exception
                Response.Write(ex.Message)
            End Try
          
        Else
            e.Cancel = False

        End If
        sql_add_user.InsertCommand = "insert into msUSer (UserName, Password, LevelUser, NIK, UnitKerja) values (@UserName, @Password, @LevelUser, @NIK, @UnitKerja)"
    End Sub
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        sql_add_user.SelectCommand = "select a.NIK, a.UserName, a.Password, a.LevelUser as LevelUser , a.UserId, a.UnitKerja, a.INBOUND, a.OUTBOUND, a.FAX, a.SMS, a.CHAT from msUser a left outer join msleveluser b on a.LevelUser=b.Name order by a.UserName Asc"
        sql_add_user.UpdateCommand = "update msUser set UserName=@UserName, Password=@Password,LevelUser=@LevelUser, NIK=@NIK,UnitKerja=@UnitKerja where UserID=@UserId"
        sql_add_user.DeleteCommand = "Delete msUser where UserID=@UserId"
        sql_level_user.SelectCommand = "select DISTINCT(LevelUser) as Name from [msUserTrustee]"
        sql_unit_kerja.SelectCommand = "select DISTINCT(Divisi), Divisi  from mKaryawan"
        sql_user_sbg.SelectCommand = "Select * from msLevelUser"
        sql_nik.SelectCommand = "SELECT NIK,Name FROM mKaryawan"
    End Sub
End Class