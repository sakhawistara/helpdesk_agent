Imports System
Imports System.Web.UI
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Public Class login
    Inherits System.Web.UI.Page
    Public ConLDAP As String = ConfigurationManager.AppSettings.Item("LDAP")

    Dim Proses As New ClsConn
    Dim sqldr As SqlDataReader
    Dim sql As String
    Dim valuesatu As Integer = 1
    Dim valuedua As Integer = 2
    Dim valuetiga As Integer = 3
    Dim ValueEmpat As Integer = 4
    Dim valueLima As Integer = 5
    Dim leveluser As String
    Dim value As String
    Dim Type As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session.RemoveAll()
        FormsAuthentication.SignOut()
    End Sub

    Private Sub Btn_Simpan_ServerClick(sender As Object, e As EventArgs) Handles Btn_Simpan.ServerClick
        sql = "select Login_Type from mApplikasi"
        Try
            sqldr = Proses.ExecuteReader(sql)
            If sqldr.Read() Then
                Type = sqldr("Login_Type").ToString
            End If
            sqldr.Close()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
        If Type = "LDAP" Then
            If LoginLDAP(ConLDAP, txt_username.Text, txt_password.Text) = True Then
                query()
            Else
                lblError.Visible = True
            End If

        Else
            query()
        End If
    End Sub

    Private Function LoginLDAP(LDAP As String, Username As String, Password As String) As Boolean
        If LDAP = "" Then Exit Function
        Dim Entry As New DirectoryServices.DirectoryEntry("LDAP://" & LDAP, Username, Password)
        Dim Searcher As New System.DirectoryServices.DirectorySearcher(Entry)
        Searcher.Filter = "(sAMAccountName=" & Username & ")"
        Try
            Dim Results As System.DirectoryServices.SearchResultCollection = Searcher.FindAll
            Session("NamaLengkap") = Results(0).GetDirectoryEntry.Properties("displayname").Value
            Session("email") = Results(0).GetDirectoryEntry.Properties("mail").Value
            Session("LoginID") = Results(0).GetDirectoryEntry.Properties("sAMAccountName").Value
            Session("NIK") = Results(0).GetDirectoryEntry.Properties("sAMAccountName").Value
            If Session("NIK") = "" Then
                Session("NIK") = Results(0).GetDirectoryEntry.Properties("displayname").Value
            End If
            Session("Jabatan") = Results(0).GetDirectoryEntry.Properties("description").Value
            Session("Department") = Results(0).GetDirectoryEntry.Properties("department").Value
            Session("LoginID") = Results(0).GetDirectoryEntry.Properties("sAMAccountName").Value
            Session("passAsli") = Password
            Return True
        Catch ex As Exception
            'lbl_Alert.Visible = True
            'lbl_Alert.Text = "User ID And Password Are Incorrect!"
        End Try
    End Function

    Private Sub query()
        sql = "Select COUNT (UserID) as userID from msUser where UserName='" & txt_username.Text & "' and Password='" & txt_password.Text & "'"
        sqldr = Proses.ExecuteReader(sql)
        Try
            If sqldr.HasRows Then
                sqldr.Read()
                value = sqldr("UserID")
            End If
            sqldr.Close()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
        If value > 0 Then
            sql = "Select * from msUser where UserName='" & txt_username.Text & "' and Password='" & txt_password.Text & "'"
            Try
                sqldr = Proses.ExecuteReader(sql)
                If sqldr.HasRows Then
                    sqldr.Read()
                    leveluser = sqldr("LevelUser").ToString
                    Session("UserName") = sqldr("NIK").ToString
                    Session("lblUserName") = sqldr("UserName").ToString
                    Session("UnitKerja") = sqldr("UnitKerja").ToString
                End If
                sqldr.Close()
            Catch ex As Exception
                Response.Write(ex.Message)
            End Try
          
            'ini digunakan jika config applikasi sudah selesai
            sql = "Select * from mKaryawan where NIK='" & Session("UserName") & "'"
            Try
                sqldr = Proses.ExecuteReader(sql)
                If sqldr.HasRows Then
                    sqldr.Read()
                    Session("NameKaryawan") = sqldr("Name").ToString
                    Session("divisi") = sqldr("Divisi").ToString
                End If
                sqldr.Close()
            Catch ex As Exception
                Response.Write(ex.Message)
            End Try
           
            'sql = "Select * from msUserTrustee where LevelUser='" & leveluser & "'"
            sql = "Select mLevelUser.Name from msUser left outer join mLevelUser  on msUser.LevelUser = mLevelUser.Description where msUser.UserName = '" & Session("UserName") & "'"
            Try
                sqldr = Proses.ExecuteReader(sql)
                If sqldr.HasRows Then
                    sqldr.Read()
                    Session("LoginType") = sqldr("Name")
                End If
                sqldr.Close()
            Catch ex As Exception
                Response.Write(ex.Message)
            End Try
           
            Session("LoginTypeAngka") = value
            Session("LoginTypeSbg") = leveluser

            If Session("LoginType") = "" Then

            ElseIf Session("LoginType") = "layer1" Then
                Session("LoginTypeAngka") = valuesatu
            ElseIf Session("LoginType") = "layer2" Then
                Session("LoginTypeAngka") = valuedua
            ElseIf Session("LoginType") = "layer3" Then
                Session("LoginTypeAngka") = valuetiga
                'ElseIf Session("LoginType") = "Admin" Then
                '    Session("LoginTypeAngka") = ValueEmpat
                'ElseIf Session("LoginType") = "Supervisor" Then
                '    Session("LoginTypeAngka") = valueLima
            End If
            Response.Redirect("HTML/dashboard.aspx")
        Else
            lblError.Visible = True
        End If
    End Sub
End Class