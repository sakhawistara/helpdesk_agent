Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.UI
Imports System.Threading
Imports DevExpress.Web.ASPxGridView
Public Class todolist
    Inherits System.Web.UI.Page

    Dim sqlDr As SqlDataReader
    Dim Proses As New ClsConn
    Dim sql As String
    Dim value As String
    Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString)
    Dim com As New SqlCommand
    Dim str As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        str = "spExec_ToDoListCUdanPIC " & Session("LoginTypeAngka") & "," & Session("divisi") & "," & Session("UserName") & ""
        com = New SqlCommand(str, con)
        Try
            con.Open()
            sqlDr = com.ExecuteReader()
            While sqlDr.Read()
                Dim range As Integer = sqlDr("Range").ToString
                Dim SLA As String = sqlDr("SLA").ToString
                Dim Warna As String
                If range > 0 Then
                    Warna = "<div class='progress progress-striped active' style='height:8px; margin:5px 0 0 0;'>" & _
                                "<div class='progress-bar progress-bar-danger' style='width: 100%'>" & _
                                "<span class='sr-only'>45% Complete</span> " & _
                                "</div>" & _
                                "</div></td>"
                ElseIf range = 0 Then
                    Warna = "<div class='progress progress-striped active' style='height:8px; margin:5px 0 0 0;'>" & _
                                "<div class='progress-bar progress-bar-success' style='width: 100%'>" & _
                                "<span class='sr-only'>45% Complete</span> " & _
                                "</div>" & _
                                "</div></td>"
                ElseIf range < SLA Then
                    Warna = "<div class='progress progress-striped active' style='height:8px; margin:5px 0 0 0;'>" & _
                                "<div class='progress-bar progress-bar-warning' style='width: 100%'>" & _
                                "<span class='sr-only'>45% Complete</span> " & _
                                "</div>" & _
                                "</div></td>"
                End If
                value &= "<tr>" & _
                        "<td>" & sqlDr("NumberRow").ToString & "</td>" & _
                        "<td><span class='not-starred'><i><a class='nonelink' href='utama.aspx?tid=" & sqlDr("TicketNumber") & "&layer=" & Session("LoginType") & "&NIK=" & sqlDr("NIK") & "&datecreate=" & sqlDr("DateCreate") & "'>" & sqlDr("TicketNumber") & "</i></span></td>" & _
                        "<td>" & sqlDr("NamePIC").ToString & "</td>" & _
                        "<td>" & sqlDr("DetailComplaint").ToString & "</td>" & _
                        "<td>" & sqlDr("Status").ToString & "</td>" & _
                        "<td>" & Warna & "</td>" & _
                        "<td>" & _
                        "</tr>"
            End While
            sqlDr.Close()
            con.Close()
            ltr_todolist.Text = value
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub
End Class