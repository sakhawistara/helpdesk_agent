Imports System.Web
Imports System.Web.UI
Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class dashboard
    Inherits System.Web.UI.Page

    Dim sqlcon_Ticket As New SqlConnection(ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString)
    Dim Sqlcon_Sosmed As New SqlConnection(ConfigurationManager.ConnectionStrings("SosmedConnection").ConnectionString)
    Dim sqlcom, coms As SqlCommand
    Dim sqldr, dr As SqlDataReader
    Dim strSql, email, twitter, facebook, sms, Ticket_Open, strSql1 As String
    Dim strOpen, strClose, strPending, strProgress, valOpen, valClose, valPending, valProgress As String
    Dim MyConn As SqlConnection
    Dim cmd As SqlCommand
    Dim sql As String
    Private Shared Function TicConn() As String
        Dim conn As String = System.Configuration.ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
        Return conn
    End Function
    Private Shared Function SosConn() As String
        Dim conn As String = System.Configuration.ConfigurationManager.ConnectionStrings("SosmedConnection").ConnectionString
        Return conn
    End Function
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        channel_popup()
        ticket_popup()
        sql_karyawan.SelectCommand = "select * from mKaryawan"
        lbl_user_dashboard.Text = "Welcome To " & Session("NameKaryawan")
    End Sub

    Sub channel_count()
        strSql = "select COUNT (IVC_ID) As Count_Email from IVC_EMAIL_IN_TM where Reading='0'"
        sqlcom = New SqlCommand(strSql, sqlcon_Ticket)
        sqlcon_Ticket.Open()
        sqldr = sqlcom.ExecuteReader()
        If sqldr.HasRows Then
            sqldr.Read()
            lbl_email.Text = sqldr("Count_Email").ToString
        End If
        sqldr.Close()
        sqlcon_Ticket.Close()
    End Sub

    Private Sub UpdatePanel1_Load(sender As Object, e As EventArgs) Handles UpdatePanel1.Load
        channel_count()
    End Sub

    Sub channel_popup()
        If modal_email.Visible = True Then
            Dim conn As String = TicConn()
            MyConn = New SqlConnection(conn)
            MyConn.Open()
            sql = "select top 5 * from IVC_EMAIL_IN_TM"
            cmd = New SqlCommand(Sql, MyConn)
            sqldr = cmd.ExecuteReader()
            While sqldr.Read()
                email &= "<tr>" & _
                              "<td><span class='not-starred'><a class='nonelink' href='utama.aspx?channel=email&id=" & sqldr("IVC_ID") & "&account=" & sqldr("EFROM") & "' target='_blank'>Replay</a></span></td>" & _
                              "<td><span class='not-starred'><i><a class='nonelink' href='utama.aspx?channel=email&id=" & sqldr("IVC_ID") & "&account=" & sqldr("EFROM") & "' target='_blank'>" & sqldr("EFROM") & "</i></span></td>" & _
                              "<td>" & sqldr("ESUBJECT").ToString & "</td>" & _
                              "<td>" & sqldr("Email_Date").ToString & "</td>" & _
                              "</tr>"
                '"<td><label class='label-checkbox'><input type='checkbox' class='chk-row'>" & _
                '"<span class='custom-checkbox'></span></label></td>" & _
            End While
            sqldr.Close()
            MyConn.Close()
            ltr_email.Text = email
            If Session("LoginTypeSbg") = "Admin" Then
                div_email_assign.Visible = True
            Else
                div_email_assign.Visible = False
            End If
        Else
            ltr_email.Text = ""
        End If

        If modal_twitter.Visible = True Then
            Dim conn As String = SosConn()
            MyConn = New SqlConnection(conn)
            MyConn.Open()
            sql = "select top 5 * from tw_tMention"
            cmd = New SqlCommand(sql, MyConn)
            sqldr = cmd.ExecuteReader()
            While sqldr.Read()
                twitter &= "<tr>" & _
                             "<td><span class='not-starred'><i><a class='nonelink' href='utama.aspx?channel=twitter&id=" & sqldr("id_Twitter") & "&account=" & sqldr("screen_Name") & "' target='_blank'>" & sqldr("screen_Name") & "</i></span></td>" & _
                              "<td>" & sqldr("tText").ToString & "</td>" & _
                              "<td>" & sqldr("created_at").ToString & "</td>" & _
                              "</tr>"
            End While
            sqldr.Close()
            MyConn.Close()
            ltr_twitter.Text = twitter
            If Session("LoginTypeSbg") = "Admin" Then
                div_twitter_assign.Visible = True
            Else
                div_twitter_assign.Visible = False
            End If
        Else
            ltr_twitter.Text = ""
        End If


        If modal_facebook.Visible = True Then
            Dim conn As String = SosConn()
            MyConn = New SqlConnection(conn)
            MyConn.Open()
            sql = "select top 5 * from fb_tGet_Header"
            cmd = New SqlCommand(sql, MyConn)
            sqldr = cmd.ExecuteReader()
            While sqldr.Read()
                facebook &= "<tr>" & _
                            "<td><span class='not-starred'><i><a class='nonelink' href='utama.aspx?channel=facebook&id=" & sqldr("facebook_ID") & "&account=" & sqldr("facebook_Name") & "' target='_blank'>" & sqldr("facebook_Name") & "</i></span></td>" & _
                            "<td>" & sqldr("facebook_Message").ToString & "</td>" & _
                            "<td>" & sqldr("ddate").ToString & "</td>" & _
                            "</tr>"
            End While
            sqldr.Close()
            MyConn.Close()
            ltr_facebook.Text = facebook
            If Session("LoginTypeSbg") = "Admin" Then
                div_facebook_assign.Visible = True
            Else
                div_facebook_assign.Visible = False
            End If
        Else
            ltr_facebook.Text = ""
        End If

    End Sub
   
    Sub ticket_popup()
        If modal_ticket_open.Visible = True Then
            Dim conn As String = TicConn()
            MyConn = New SqlConnection(conn)
            MyConn.Open()
            sql = "select TicketNumber, NIK, DetailComplaint, DateCreate from tticket where status='Open'"
            cmd = New SqlCommand(sql, MyConn)
            sqldr = cmd.ExecuteReader()
            While sqldr.Read()
                valOpen &= "<tr>" & _
                              "<td><span class='not-starred'><a class='nonelink' href='utama.aspx?channel=email&id=" & sqldr("TicketNumber") & "&account=" & sqldr("NIK") & "' target='_blank'>" & sqldr("TicketNumber") & "</a></span></td>" & _
                              "<td><span class='not-starred'><i><a class='nonelink' href='utama.aspx?channel=email&id=" & sqldr("TicketNumber") & "&account=" & sqldr("NIK") & "' target='_blank'>" & sqldr("NIK") & "</i></span></td>" & _
                              "<td>" & sqldr("DetailComplaint").ToString & "</td>" & _
                              "<td>" & sqldr("DateCreate").ToString & "</td>" & _
                              "</tr>"
            End While
            sqldr.Close()
            MyConn.Close()
            ltr_ticket_open.Text = valOpen
            If Session("leveluser") = "Admin" Then
                div_email_assign.Visible = True
            Else
                div_email_assign.Visible = False
            End If
        Else
            ltr_ticket_open.Text = ""
        End If
        If modal_ticket_close.Visible = True Then
            Dim conn As String = TicConn()
            MyConn = New SqlConnection(conn)
            MyConn.Open()
            sql = "select TicketNumber, NIK, DetailComplaint, DateCreate from tticket where status='Closed'"
            cmd = New SqlCommand(sql, MyConn)
            sqldr = cmd.ExecuteReader()
            While sqldr.Read()
                valClose &= "<tr>" & _
                              "<td><span class='not-starred'><a class='nonelink' href='utama.aspx?channel=email&id=" & sqldr("TicketNumber") & "&account=" & sqldr("NIK") & "' target='_blank'>" & sqldr("TicketNumber") & "</a></span></td>" & _
                              "<td><span class='not-starred'><i><a class='nonelink' href='utama.aspx?channel=email&id=" & sqldr("TicketNumber") & "&account=" & sqldr("NIK") & "' target='_blank'>" & sqldr("NIK") & "</i></span></td>" & _
                              "<td>" & sqldr("DetailComplaint").ToString & "</td>" & _
                              "<td>" & sqldr("DateCreate").ToString & "</td>" & _
                              "</tr>"
            End While
            sqldr.Close()
            MyConn.Close()
            ltr_ticket_close.Text = valClose
            If Session("leveluser") = "Admin" Then
                div_email_assign.Visible = True
            Else
                div_email_assign.Visible = False
            End If
        Else
            ltr_ticket_close.Text = ""
        End If
        If modal_ticket_pending.Visible = True Then
            Dim conn As String = TicConn()
            MyConn = New SqlConnection(conn)
            MyConn.Open()
            sql = "select TicketNumber, NIK, DetailComplaint, DateCreate from tticket where status='Pending'"
            cmd = New SqlCommand(sql, MyConn)
            sqldr = cmd.ExecuteReader()
            While sqldr.Read()
                valPending &= "<tr>" & _
                              "<td><span class='not-starred'><a class='nonelink' href='utama.aspx?channel=email&id=" & sqldr("TicketNumber") & "&account=" & sqldr("NIK") & "' target='_blank'>" & sqldr("TicketNumber") & "</a></span></td>" & _
                              "<td><span class='not-starred'><i><a class='nonelink' href='utama.aspx?channel=email&id=" & sqldr("TicketNumber") & "&account=" & sqldr("NIK") & "' target='_blank'>" & sqldr("NIK") & "</i></span></td>" & _
                              "<td>" & sqldr("DetailComplaint").ToString & "</td>" & _
                              "<td>" & sqldr("DateCreate").ToString & "</td>" & _
                              "</tr>"
            End While
            sqldr.Close()
            MyConn.Close()
            ltr_ticket_pending.Text = valPending
            If Session("leveluser") = "Admin" Then
                div_email_assign.Visible = True
            Else
                div_email_assign.Visible = False
            End If
        Else
            ltr_ticket_pending.Text = ""
        End If
        If modal_ticket_progress.Visible = True Then
            Dim conn As String = TicConn()
            MyConn = New SqlConnection(conn)
            MyConn.Open()
            sql = "select TicketNumber, NIK, DetailComplaint, DateCreate from tticket where status='Progress'"
            cmd = New SqlCommand(sql, MyConn)
            sqldr = cmd.ExecuteReader()
            While sqldr.Read()
                valProgress &= "<tr>" & _
                              "<td><span class='not-starred'><a class='nonelink' href='utama.aspx?channel=email&id=" & sqldr("TicketNumber") & "&account=" & sqldr("NIK") & "' target='_blank'>" & sqldr("TicketNumber") & "</a></span></td>" & _
                              "<td><span class='not-starred'><i><a class='nonelink' href='utama.aspx?channel=email&id=" & sqldr("TicketNumber") & "&account=" & sqldr("NIK") & "' target='_blank'>" & sqldr("NIK") & "</i></span></td>" & _
                              "<td>" & sqldr("DetailComplaint").ToString & "</td>" & _
                              "<td>" & sqldr("DateCreate").ToString & "</td>" & _
                              "</tr>"
            End While
            sqldr.Close()
            MyConn.Close()
            ltr_ticket_progress.Text = valProgress
            If Session("leveluser") = "Admin" Then
                div_email_assign.Visible = True
            Else
                div_email_assign.Visible = False
            End If
        Else
            ltr_ticket_progress.Text = ""
        End If
    End Sub

    Private Sub UpdatePanel2_Load(sender As Object, e As EventArgs) Handles UpdatePanel2.Load
        ticket_count()
    End Sub

    Sub ticket_count()
        strSql = "select COUNT (id) As count_open from tticket where status='Open'"
        sqlcom = New SqlCommand(strSql, sqlcon_Ticket)
        sqlcon_Ticket.Open()
        sqldr = sqlcom.ExecuteReader()
        If sqldr.HasRows Then
            sqldr.Read()
            lbl_open.Text = sqldr("count_open").ToString
            End If
        sqldr.Close()
        sqlcon_Ticket.Close()
        strSql = "select COUNT (id) As count_close from tticket where status='Closed'"
        sqlcom = New SqlCommand(strSql, sqlcon_Ticket)
        sqlcon_Ticket.Open()
        sqldr = sqlcom.ExecuteReader()
        If sqldr.HasRows Then
            sqldr.Read()
            lbl_close.Text = sqldr("count_close").ToString
        End If
        sqldr.Close()
        sqlcon_Ticket.Close()
        strSql = "select COUNT (id) As count_pending from tticket where status='Pending'"
        sqlcom = New SqlCommand(strSql, sqlcon_Ticket)
        sqlcon_Ticket.Open()
        sqldr = sqlcom.ExecuteReader()
        If sqldr.HasRows Then
            sqldr.Read()
            lbl_pending.Text = sqldr("count_pending").ToString
            If lbl_pending.Text = "" Then
                lbl_pending.Text = 0
            Else
            End If
        End If
        sqldr.Close()
        sqlcon_Ticket.Close()
        strSql = "select COUNT (id) As count_progress from tticket where status='progress'"
        sqlcom = New SqlCommand(strSql, sqlcon_Ticket)
        sqlcon_Ticket.Open()
        sqldr = sqlcom.ExecuteReader()
        If sqldr.HasRows Then
            sqldr.Read()
            lbl_on_progress.Text = sqldr("count_progress").ToString
            If lbl_on_progress.Text = "" Then
                lbl_on_progress.Text = 0
            Else
            End If
        End If
        sqldr.Close()
        sqlcon_Ticket.Close()
    End Sub
End Class