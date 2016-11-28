Imports System.Data.SqlClient
Public Class facebook_history
    Inherits System.Web.UI.Page

    Dim Proses As New ClsConn
    Dim sqldr As SqlDataReader
    Dim sql As String
    Dim valTwitHst As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        sql = "select top 5 * from IVC_EMAIL_IN_TM"
        sqldr = Proses.ExecuteReader(sql)
        Try
            While sqldr.Read()
                valTwitHst &= "<tr>" & _
                              "<td><span class='not-starred'><a class='nonelink' href='twitter_history.aspx?detail=" & sqldr("IVC_ID") & "&account=" & sqldr("EFROM") & "' target='_blank'>" & sqldr("EFROM") & "</a></span></td>" & _
                              "</tr>"
                '"<td><span class='not-starred'><i><a class='nonelink' href='utama.aspx?channel=facebook&id=" & sqldr("IVC_ID") & "&account=" & sqldr("EFROM") & "' target='_blank'>" & sqldr("EFROM") & "</i></span></td>" & _
                '"<td><span class='not-starred'><i><a class='nonelink' href='utama.aspx?channel=facebook&id=" & sqldr("IVC_ID") & "&account=" & sqldr("EFROM") & "' target='_blank'>" & sqldr("EFROM") & "</i></span></td>" & _

            End While
            sqldr.Close()
            ltr_email.Text = valTwitHst
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub

End Class