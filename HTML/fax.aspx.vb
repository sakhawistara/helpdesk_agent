Public Class fax
    Inherits System.Web.UI.Page
    Dim clsfax As New cls_globe
    Dim strsql, tmpdata As String
    Dim tbldata As DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session("dbName") = "fax"
        Dashboard()
        CariData()
        Resend()

        If Not Page.IsPostBack Then
            clsfax.LogSys(Session("LoginID"), "Open Menu", "Fax Inbox", "", Session("dbName"))
            clsfax.writedata(Session("LoginID"), "Open Menu", "Fax Inbox", "", Session("dbName"))
        End If
        If Session("Error") <> Nothing Then
            lblError.Visible = True
            lbl_Error.Text = Session("Error")
            Session("Error") = Nothing
        End If
    End Sub
    Private Sub B_notError_ServerClick(sender As Object, e As EventArgs) Handles B_notError.ServerClick
        lblError.Visible = False
        lbl_Error.Text = Nothing
    End Sub
    Private Sub DownloadFax_ServerClick(sender As Object, e As EventArgs) Handles DownloadFax.ServerClick
        Session("Error") = Nothing
        strsql = "select * from v_txfaxin1 where id='" & Request.QueryString("id") & "'"
        tbldata = clsfax.ExecuteQuery(strsql)

        strsql = clsfax.InFileFAX + tbldata.Rows(0).Item("FileName")
        If System.IO.File.Exists(Server.MapPath(strsql)) = False Then
            lblError.Visible = True
            Session("Error") = "Error file " & tbldata.Rows(0).Item("FileName") & " not found..."
            clsfax.writedata(Session("LoginID"), "Error Read Fax IN File", tbldata.Rows(0).Item("FileName"), strsql, Session("dbName"))
            clsfax.LogSys(Session("LoginID"), "Error Read Fax IN File", tbldata.Rows(0).Item("FileName"), strsql, Session("dbName"))
            Exit Sub
        End If
        If tbldata.Rows(0).Item("ReadWeb").ToString = Nothing Then
            clsfax.ExecuteNonQuery("update txfaxin set ReadWeb='" & Session("LoginID") & "' where ID='" & Request.QueryString("id") & "'")
        End If
        clsfax.writedata(Session("LoginID"), "Read Fax IN File", tbldata.Rows(0).Item("FileName"), strsql, Session("dbName"))
        clsfax.LogSys(Session("LoginID"), "Read Fax IN File", tbldata.Rows(0).Item("FileName"), strsql, Session("dbName"))
        lblError.Visible = False
        Response.Redirect(strsql)
    End Sub
    Private Sub CariData()
        Session("Error") = Nothing
        Try
            If Request.QueryString("status") = "open" Then
                strsql = "select * from v_txfaxin1 where ReadWeb is null order by datetime desc"
                lit_miniMenuFax.Text = "<li title='Fax Inbox'><i class='fa fa-inbox'></i> Inbox</li>"
                Session("resend") = Nothing
            ElseIf Request.QueryString("action") = "detail" Then
                strsql = "select * from v_txfaxin1 where ID='" & Request.QueryString("id") & "'"
                fax_TableSend.Visible = False
                fax_detail.Visible = True
                lit_miniMenuFax.Text = "<li title='Fax detail'><i class='fa fa-server'></i> Fax detail</li>"
                Session("resend") = Nothing
            ElseIf Request.QueryString("status") = "all" Then
                strsql = "select * from v_txfaxin1 order by datetime desc"
                lit_miniMenuFax.Text = "<li title='Fax Inbox'><i class='fa fa-inbox'></i> Inbox</li>"
                Session("resend") = Nothing
            ElseIf Request.QueryString("status") = "send" Then
                Session("resend") = Nothing
                GoTo FaxSend
            ElseIf Request.QueryString("action") = "resend" Then
                GoTo FaxSend
            Else
                strsql = "select * from v_txfaxin1 order by datetime desc"
                lit_miniMenuFax.Text = "<li title='Fax Inbox'><i class='fa fa-inbox'></i> Inbox</li>"
                Session("resend") = Nothing
            End If
            If Session("resend") = 1 Then
                GoTo FaxSend
            End If
            Fax_table.Visible = True
            Fax_send.Visible = False
            tbldata = clsfax.ExecuteQuery(strsql)
            If tbldata.Rows.Count > 0 Then
                lbl_pic_customer.Text = tbldata.Rows(0).Item("AnyNumber")
                lbl_customer.Text = tbldata.Rows(0).Item("FileName")
                lbl_date.Text = tbldata.Rows(0).Item("dra")
                tmpdata = Nothing
                For i As Integer = 0 To tbldata.Rows.Count - 1
                    tmpdata += "<tr>"
                    tmpdata += "<td><a href='?action=detail&id=" & tbldata.Rows(i).Item("ID") & "' title='view detail'><img src='img/icon/Apps-text-editor-icon22.png'/></a></td>"
                    tmpdata += "<td>" & tbldata.Rows(i).Item("FileName") & "</td>"
                    tmpdata += "<td>" & tbldata.Rows(i).Item("AnyNumber") & "</td>"
                    tmpdata += "<td>" & tbldata.Rows(i).Item("Fto") & "</td>"
                    tmpdata += "<td>" & tbldata.Rows(i).Item("dra") & "</td>"
                    tmpdata += "<td>" & tbldata.Rows(i).Item("ReadWeb1") & "</td>"
                    tmpdata += "</tr>"
                Next
                lit_dataFaxInbox.Text = tmpdata
            End If
            Exit Sub
FaxSend:
            strsql = "select * from v_txfaxsend order by DDate desc"
            Fax_table.Visible = False
            Fax_send.Visible = True
            lit_miniMenuFax.Text = "<li title='Fax Send'><i class='fa fa-send'></i> Send</li>"
            tbldata = clsfax.ExecuteQuery(strsql)
            If tbldata.Rows.Count > 0 Then
                tmpdata = Nothing
                For i As Integer = 0 To tbldata.Rows.Count - 1
                    tmpdata += "<tr>"
                    'tmpdata += "<td><a href='?action=resend&id=" & tbldata.Rows(i).Item("ID") & "' " & _
                    '    "onclick=""return confirm('Are you sure, to Re-send " & tbldata.Rows(i).Item("DialNumber") & "');return false;""><img src='img/Fax-Send.png' height='20px'/></a></td>"
                    tmpdata += "<td><a href='#ButtonConfirm' class='main-link ButtonConfirm_open' ><img src='img/Fax-Send.png' height='20px'/></a></td>"
                    tmpdata += "<td>" & tbldata.Rows(i).Item("IdUser") & "</td>"
                    tmpdata += "<td>" & tbldata.Rows(i).Item("DialNumber") & "</td>"
                    tmpdata += "<td>" & tbldata.Rows(i).Item("OriFileName") & "</td>"
                    tmpdata += "<td>" & tbldata.Rows(i).Item("dra") & "</td>"
                    tmpdata += "<td>" & tbldata.Rows(i).Item("Status") & "</td>"
                    tmpdata += "<td>" & tbldata.Rows(i).Item("Reason") & "</td>"
                    tmpdata += "</tr>"
                Next
                lit_dataFaxSend.Text = tmpdata
            End If
        Catch ex As Exception
            clsfax.LogSys(Session("LoginID"), "Error Cari Data", "Fax Inbox", strsql, Session("dbName"))
            clsfax.writedata(Session("LoginID"), "Error Cari Data", "Fax Inbox", strsql, Session("dbName"))
            lblError.Visible = True
            Session("Error") = ex.Message
        End Try
    End Sub
    Private Sub Dashboard()
        Session("Error") = Nothing
        Try
            strsql = "select count(fto)Tnew from TXFaxIN where ReadWeb is null"
            tbldata = clsfax.ExecuteQuery(strsql)
            lbl_open.Text = tbldata.Rows(0).Item("Tnew")
            If lbl_open.Text <> 0 Then
                lit_Tnew.Text = "<span class='badge badge-success pull-right'>" & lbl_open.Text & "</span>"
            End If
            strsql = "select count(fto)Tnew from TXFaxIN"
            tbldata = clsfax.ExecuteQuery(strsql)
            lbl_inboxFax.Text = tbldata.Rows(0).Item("Tnew")
            strsql = "select count(id)tid from txfaxsend"
            tbldata = clsfax.ExecuteQuery(strsql)
            lbl_sendFax.Text = tbldata.Rows(0).Item("tid")
        Catch ex As Exception
            lblError.Visible = True
            Session("Error") = ex.Message
        End Try
    End Sub
    Private Sub Resend()
        Session("Error") = Nothing
        Try
            If Request.QueryString("action") = "resend" And Session("resend") = Nothing Then
                If Request.QueryString("id") <> Nothing Then
                    strsql = "update TXFaxSend set Status='Ready',Try=0 where ID='" & Request.QueryString("id") & "'"
                    clsfax.ExecuteNonQuery(strsql)
                    clsfax.writedata(Session("LoginID"), "Re-send", "Fax Send", strsql, Session("dbName"))
                    clsfax.LogSys(Session("LoginID"), "Re-send", "Fax Send", strsql, Session("dbName"))
                    Session("resend") = 1
                End If
            End If
            CariData()
        Catch ex As Exception
            clsfax.LogSys(Session("LoginID"), "Error Re-send", "Fax Send", strsql, Session("dbName"))
            clsfax.writedata(Session("LoginID"), "Error Re-send", "Fax Send", strsql, Session("dbName"))
            lblError.Visible = True
            Session("Error") = ex.Message
        End Try
    End Sub

    Private Sub btn_compose_Click(sender As Object, e As EventArgs) Handles btn_compose.Click
        Fax_table.Visible = False
        Fax_send.Visible = False
        Fax_Compose.Visible = True
        txt_to.Text = Nothing
        txt_cc.Text = Nothing
        txt_subject.Text = Nothing
    End Sub
End Class