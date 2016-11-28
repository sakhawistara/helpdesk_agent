Imports System.Data.SqlClient
Public Class inbox_todolist
    Inherits System.Web.UI.Page

    Dim Proses As New ClsConn
    Dim sqldr As SqlDataReader
    Dim sql As String
    Dim valEmail As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.QueryString("reply") = "" Then
            sql = "select TicketNumber, NIK, DetailComplaint, DateCreate from tticket"
            sqldr = Proses.ExecuteReader(Sql)
            Try
                While sqldr.Read()
                    valEmail &= "<tr>" & _
                                  "<td><span class='not-starred'><a class='nonelink' href='utama.aspx?tid=" & sqldr("TicketNumber") & "&account=" & sqldr("NIK") & "' target='_blank'>" & sqldr("TicketNumber") & "</a></span></td>" & _
                                  "<td><span class='not-starred'><i>" & sqldr("NIK") & "</i></span></td>" & _
                                  "<td>" & sqldr("DetailComplaint").ToString & "</td>" & _
                                  "<td>" & sqldr("DateCreate").ToString & "</td>" & _
                                  "</tr>"
                End While
                sqldr.Close()
                ltr_email.Text = valEmail
                div_compose.Visible = False
            Catch ex As Exception
                Response.Write(ex.Message)
            End Try
            count_todolist()
        Else
            div_table.Visible = False
            div_compose.Visible = True
            txt_to.Text = Request.QueryString("account")
        End If

    End Sub
    Sub count_todolist()
        sql = "select  COUNT(id) as count_value  from tTicket where (UserCreate='" & Session("username") & "' or dispatch_user='" & Session("username") & "') and Status='Open'"
        sqldr = Proses.ExecuteReader(sql)
        If sqldr.HasRows Then
            sqldr.Read()
            lbl_jumlah_todolist.Text = sqldr("count_value").ToString & " Ticket"
        End If
        sqldr.Close()
    End Sub
End Class