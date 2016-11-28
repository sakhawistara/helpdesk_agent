Imports System.Collections.Generic
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Timers
Imports System.Data.OleDb
Public Class inputsentimenMP
    Inherits System.Web.UI.Page
    Dim Con As New SqlConnection(ConfigurationManager.ConnectionStrings("SosmedConnection").ConnectionString)
    Dim Com As SqlCommand
    Dim Dr As SqlDataReader

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        btnupdatekey.Visible = False
        If Request.QueryString("id") = "" Then
            Dim baskom As String
            Dim selectdata As String = "select * from mSentimen order by mSentimenID Asc"
            Com = New SqlCommand(selectdata, Con)
            Con.Open()
            Dr = Com.ExecuteReader()
            While Dr.Read
                baskom &= "<tr>" & _
                        "<td>" & Dr("mSentimenID").ToString & "</td>" & _
                        "<td>" & Dr("Name").ToString & "</td>" & _
                        "<td>" & Dr("Description").ToString & "</td>" & _
                        "<td style='width:150px'>" & _
                        "<a href='inputsentimenMP.aspx?id=" & Dr("mSentimenID").ToString & "&status=edit' class='btn btn-info btn-xs' id=''>update</a> &nbsp;" & _
                        "<a href='inputsentimenMP.aspx?id=" & Dr("mSentimenID").ToString & "&status=delete'  class='btn btn-danger btn-xs'>Delete</a>" & _
                        "</td>" & _
                      "</tr> "
            End While
            Dr.Close()
            Con.Close()
            show.Text = baskom
        ElseIf Request.QueryString("id") <> "" Then
            If Request.QueryString("status") = "edit" Then
                btnsubmitkey.Visible = False
                btnupdatekey.Visible = True
                'btnupdate.Enabled = True
                ' Dim tampungtextbox As String
                Dim selectupdate As String = "select * from mSentimen where mSentimenID ='" & Request.QueryString("id").ToString & "'"
                Com = New SqlCommand(selectupdate, Con)
                Con.Open()
                Dr = Com.ExecuteReader()
                Dr.Read()
                txtsentimen.Text = Dr("Name").ToString
                txtdesc.Text = Dr("Description").ToString
                Session("id") = Request.QueryString("id").ToString
                Dr.Close()
                Con.Close()
            ElseIf Request.QueryString("status") = "delete" Then
                'If MsgBox("Would you like to remove this item?" & "informations you have", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Try
                    Dim insertlog As String = "insert into mslog (Username, Flag, Data, datetime) VALUES ('" & Session("username") & "', 'Delete Sentimen', '" & txtsentimen.Text & "', GETDATE())"
                    Com = New SqlCommand(insertlog, Con)
                    Con.Open()
                    Com.ExecuteNonQuery()
                    Con.Close()
                Catch ex As Exception
                    Response.Write(DirectCast("", String))
                Finally
                End Try
                Try
                    Dim querydelete As String = "delete from mSentimen where mSentimenID ='" & Request.QueryString("id").ToString & "'"
                    Com = New SqlCommand(querydelete, Con)
                    Con.Open()
                    Com.ExecuteNonQuery()
                    Con.Close()
                Catch ex As Exception
                    Response.Write(DirectCast("", String))
                Finally
                End Try
                Session("HapusRequest") = 1
                Response.Redirect("inputsentimenMP.aspx")
            End If
            'Request.QueryString.Clear()
        End If
    End Sub

    Private Sub btnsubmitkey_Click(sender As Object, e As EventArgs) Handles btnsubmitkey.Click
        Try
            Dim insertlog As String = "insert into mslog (Username, Flag, Data, datetime) VALUES ('" & Session("username") & "', 'Insert Sentimen', '" & txtsentimen.Text & "', GETDATE())"
            Com = New SqlCommand(insertlog, Con)
            Con.Open()
            Com.ExecuteNonQuery()
            Con.Close()
        Catch ex As Exception
            Response.Write(DirectCast("", String))
        Finally
        End Try

        Try
            Dim insertdata As String = "insert into mSentimen (Name, Description, Active, DateCreate, UserCreate) values ('" & txtsentimen.Text & "', '" & txtdesc.Text & "', '1', GETDATE(), '" & Session("username") & "' )"
            Com = New SqlCommand(insertdata, Con)
            Con.Open()
            Com.ExecuteNonQuery()
            Con.Close()
            'Response.Write(DirectCast(Replace(Name, """", ""), String))
        Catch ex As Exception
            Response.Write(DirectCast("", String))
        Finally
        End Try
        txtdesc.Text = ""
        txtsentimen.Text = ""
        Response.Redirect("inputsentimenMP.aspx")
    End Sub

    Private Sub btnupdatekey_Click(sender As Object, e As EventArgs) Handles btnupdatekey.Click
        Try
            Dim insertlog As String = "insert into mslog (Username, Flag, Data, datetime) VALUES ('" & Session("username") & "', 'Update Sentimen', '" & txtsentimen.Text & "', GETDATE())"
            Com = New SqlCommand(insertlog, Con)
            Con.Open()
            Com.ExecuteNonQuery()
            Con.Close()
        Catch ex As Exception
            Response.Write(DirectCast("", String))
        Finally
        End Try

        Try
            Dim insertdata As String = "Update mSentimen set Name = '" & txtsentimen.Text & "', Description = '" & txtdesc.Text & "', DateUpdate = GETDATE(), UserUpdate='" & Session("username") & "' where mSentimenID = '" & Session("id") & "'"
            Com = New SqlCommand(insertdata, Con)
            Con.Open()
            Com.ExecuteNonQuery()
            Con.Close()
            'Response.Write(DirectCast(Replace(Name, """", ""), String))
        Catch ex As Exception
            Response.Write(DirectCast("", String))
        Finally
        End Try
        txtdesc.Text = ""
        txtsentimen.Text = ""
        Response.Redirect("inputsentimenMP.aspx")
    End Sub
End Class