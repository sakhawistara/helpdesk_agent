Imports System.Data.SqlClient
Public Class inbox_email
    Inherits System.Web.UI.Page

    Dim clsEmail As New cls_globe
    Dim tbldata As DataTable
    Dim Strsql, TmpData As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session("dbName") = "email"
        Session("NamaForm") = IO.Path.GetFileName(Request.Path)

        Dashboard_email.Visible = True
        dashboard()
        cariData()

        If Not Page.IsPostBack Then
            clsEmail.LogSys(Session("LoginID"), "Open Menu", "Email Inbox", "", Session("dbName"))
            clsEmail.writedata(Session("LoginID"), "Open Menu", "Email Inbox", "", Session("dbName"))
        End If
        If Session("Error") <> Nothing Then
            lblError.Visible = True
            lbl_Error.Text = Session("Error")
            Session("Error") = Nothing
        End If
    End Sub

    Private Sub dashboard()
        Session("Error") = Nothing
        Try
            Strsql = "select count(ivc_id)Tnew from ICC_EMAIL_IN where reading is null"
            tbldata = clsEmail.ExecuteQuery(Strsql)
            lbl_open.Text = tbldata.Rows(0).Item("Tnew")
            If lbl_open.Text <> 0 Then
                lit_TNew.Text = "<span class='badge badge-success pull-right'>" & lbl_open.Text & "</span>"
            End If

            Strsql = "select count(ivc_id)Tnew from ICC_EMAIL_IN"
            tbldata = clsEmail.ExecuteQuery(Strsql)
            lbl_inboxEmail.Text = tbldata.Rows(0).Item("Tnew")

            Strsql = "select count(ivc_id)tid from ICC_EMAIL_OUT where direction='out'"
            tbldata = clsEmail.ExecuteQuery(Strsql)
            lbl_sendEmail.Text = tbldata.Rows(0).Item("tid")
        Catch ex As Exception
            lblError.Visible = True
            Session("Error") = ex.Message
        End Try
    End Sub
    Private Sub cariData()
        Session("Error") = Nothing
        Email_table.Visible = True
        Try
            If Request.QueryString("status") = "inbox" Then
                Strsql = "select * from v_emailIN order by Email_date desc"
                lit_miniMenuEmail.Text = "<li title='Email Inbox'><i class='fa fa-inbox'></i> Inbox</li>"
                Dashboard_email.Visible = False
                Email_Compose.Visible = False
            ElseIf Request.QueryString("status") = "open" Then
                Strsql = "select * from v_emailIN where reading is null order by Email_date desc"
                lit_miniMenuEmail.Text = "<li title='Email Inbox'><i class='fa fa-inbox'></i> Inbox</li>"
                Dashboard_email.Visible = False
                Email_Compose.Visible = False
            ElseIf Request.QueryString("status") = "send" Then
                Strsql = "select * from v_emailOUT order by email_date desc"
                lit_miniMenuEmail.Text = "<li title='Email Send'><i class='fa fa-send'></i> Send</li>"
                Dashboard_email.Visible = False
                Email_Compose.Visible = False
                GoTo EmailOUT
            ElseIf Request.QueryString("action") = "detail" Then
                Strsql = "select * from v_emailin where IVC_ID='" & Request.QueryString("id") & "'"
                Dashboard_email.Visible = False
                Email_Compose.Visible = False
                Email_table.Visible = False
                GoTo EmailDetail
            Else
                Strsql = "select * from v_emailIN order by Email_date desc"
                lit_miniMenuEmail.Text = "<li title='Email Inbox'><i class='fa fa-inbox'></i> Inbox</li>"
            End If
            tbldata = clsEmail.ExecuteQuery(Strsql)
            If tbldata.Rows.Count > 0 Then
                For i As Integer = 0 To tbldata.Rows.Count - 1
                    TmpData += "<tr>"
                    TmpData += "<td>" & _
                        "<a href='?action=detail&id=" & tbldata.Rows(i).Item("IVC_ID") & "' title='view detail'><img src='img/icon/Apps-text-editor-icon22.png'/></a>&nbsp;" & _
                                "<a href='?action=replay&id=" & tbldata.Rows(i).Item("IVC_ID") & "' title='Replay Email'><i class='fa fa-reply fa-lg'></i></a>&nbsp;" & _
                                "<a href='?action=ticket&id=" & tbldata.Rows(i).Item("IVC_ID") & "' title='Ticket Email'><i class='fa fa-ticket fa-lg'></i></a>" & _
                    "</td>"
                    TmpData += "<td>" & tbldata.Rows(i).Item("EFROM") & "</td>"
                    TmpData += "<td>" & tbldata.Rows(i).Item("ESUBJECT") & "</td>"
                    TmpData += "<td>" & tbldata.Rows(i).Item("dra") & "</td>"
                    TmpData += "</tr>"
                Next
                lit_dataEmailIN.Text = TmpData
            End If
            Exit Sub

EmailOUT:
            tbldata = clsEmail.ExecuteQuery(Strsql)
            If tbldata.Rows.Count > 0 Then
                For i As Integer = 0 To tbldata.Rows.Count - 1
                    TmpData += "<tr>"
                    TmpData += "<td>" & _
                        "<a href='?action=detail&id=" & tbldata.Rows(i).Item("IVC_ID") & "' title='view detail'><img src='img/icon/Apps-text-editor-icon22.png'/></a>&nbsp;" & _
                                "<a href='?action=replay&id=" & tbldata.Rows(i).Item("IVC_ID") & "' title='Replay Email'><i class='fa fa-reply fa-lg'></i></a>&nbsp;" & _
                                "<a href='?action=ticket&id=" & tbldata.Rows(i).Item("IVC_ID") & "' title='Ticket Email'><i class='fa fa-ticket fa-lg'></i></a>" & _
                    "</td>"
                    TmpData += "<td>" & tbldata.Rows(i).Item("ETO") & "</td>"
                    TmpData += "<td>" & tbldata.Rows(i).Item("ESUBJECT") & "</td>"
                    TmpData += "<td>" & tbldata.Rows(i).Item("dra") & "</td>"
                    TmpData += "</tr>"
                Next
                lit_dataEmailIN.Text = TmpData
            End If
            Exit Sub

EmailDetail:
            Email_Compose.Visible = True
            tbldata = clsEmail.ExecuteQuery(Strsql)
            txt_to.Text = tbldata.Rows(0).Item("EFROM")
            txt_cc.Text = tbldata.Rows(0).Item("EMAIL_ID")
            txt_subject.Text = tbldata.Rows(0).Item("ESUBJECT")
            html_editor_Body.Html = tbldata.Rows(0).Item("EBODY")
        Catch ex As Exception
            lblError.Visible = True
            Session("Error") = ex.Message
        End Try
    End Sub
    Private Sub btn_compose_Click(sender As Object, e As EventArgs) Handles btn_compose.Click
        lit_miniMenuEmail.Text = "<li title='Email Compose'><i class='fa fa-edit'></i> Compose</li>"
        Email_table.Visible = False
        Email_Compose.Visible = True
    End Sub

    Private Sub btn_cancelCompose_ServerClick(sender As Object, e As EventArgs) Handles btn_cancelCompose.ServerClick
        Email_table.Visible = True
        Email_Compose.Visible = False
    End Sub

    Private Sub btn_send_ServerClick(sender As Object, e As EventArgs) Handles btn_send.ServerClick
        'belom
    End Sub
End Class