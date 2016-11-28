Imports System.Data.SqlClient
Public Class inbox_sms
    Inherits System.Web.UI.Page

    Dim Proses As New ClsSos
    Dim sqldr As SqlDataReader
    Dim sql As String
    Dim valSms As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        sql = "select * from tw_tMention"
        sqldr = Proses.ExecuteReader(sql)
        Try
            While sqldr.Read()
                valSms &= "<tr>" & _
                            "<td><span class='not-starred'><i><a class='nonelink' href='utama.aspx?channel=twitter&id=" & sqldr("id_Twitter") & "&account=" & sqldr("screen_Name") & "' target='_blank'>" & sqldr("screen_Name") & "</i></span></td>" & _
                              "<td>" & sqldr("tText").ToString & "</td>" & _
                              "<td>" & sqldr("created_at").ToString & "</td>" & _
                              "</tr>"
            End While
            sqldr.Close()
            ltr_twitter.Text = valSms
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub
End Class