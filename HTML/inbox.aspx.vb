Imports System.Collections.Generic
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Timers
Imports System.Data.OleDb
Imports System.Threading
Imports DevExpress.Web.ASPxGridView
Public Class inbox
    Inherits System.Web.UI.Page

    Dim sqlDr, sqlDtr As SqlDataReader
    Dim Proses As New ClsSos
    Dim Execute As New ClsConn
    Dim sql As String
    Dim VInbox, VTodolist As String
    Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString)
    Dim sqlCon As New SqlConnection(ConfigurationManager.ConnectionStrings("SosmedConnection").ConnectionString)
    Dim com As New SqlCommand
    Dim str, AppTicket As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Count_Ticket()
        If Request.QueryString("status") = "" Then
            div_inbox.Visible = True
            div_todolist.Visible = False
            Dim tampungan As String
            Try
                str = "SELECT * FROM DUMMY"
                sqlDr = Execute.ExecuteReader(str)
                While sqlDr.Read
                    tampungan &= "<tr class='odd gradeX'>" & _
                                   "<td align='center' style='width:100px'><a href='detilsosmed.aspx?id=" & sqlDr("CHANNELID").ToString & "&Name=" & sqlDr("ACCOUNT") & "&ket=" & sqlDr("TYPE") & "&idref=" & sqlDr("IDREF") & "'>Reply</a></td>" & _
                                   "<td style='width:200px'><a href='detilsosmed.aspx?id=" & sqlDr("CHANNELID").ToString & "&Name=" & sqlDr("ACCOUNT") & "&ket=" & sqlDr("TYPE") & "&idref=" & sqlDr("IDREF") & "'>" & sqlDr("ACCOUNT").ToString & "</a></td>" & _
                                   "<td style='word-wrap: break-word;min-width: 250px;max-width: 250px;white-space:normal; overflow: hidden;'><a href='detilsosmed.aspx?id=" & sqlDr("CHANNELID").ToString & "&Name=" & sqlDr("ACCOUNT") & "&ket=" & sqlDr("TYPE") & "&idref=" & sqlDr("IDREF") & "'>" & highlightText(sqlDr("MESSAGE").ToString) & "</a></td>" & _
                                   "<td style='width:200px' ><a href='detilsosmed.aspx?id=" & sqlDr("CHANNELID").ToString & "&Name=" & sqlDr("ACCOUNT") & "&ket=" & sqlDr("TYPE") & "&idref=" & sqlDr("IDREF") & "'>" & sqlDr("DATECREATE").ToString & "</a></td>" & _
                                   "<td style='width:150px'><a href='detilsosmed.aspx?id=" & sqlDr("CHANNELID").ToString & "&Name=" & sqlDr("ACCOUNT") & "&ket=" & sqlDr("TYPE") & "&idref=" & sqlDr("IDREF") & "'>" & sqlDr("TYPE").ToString & "</a></td>" & _
                                   "</tr>"
                End While
                sqlDr.Close()
            Catch ex As Exception

            End Try
            ltr_inbox.Text = tampungan
        Else
            ''Setting Applikasi
            sql = "Select * from mApplikasi"
            sqlDr = Execute.ExecuteReader(sql)
            If sqlDr.HasRows Then
                sqlDr.Read()
                AppTicket = sqlDr("Ticket").ToString
            End If
            sqlDr.Close()
            If AppTicket = "TRUE" Then
                Ticket_Todo()
                div_inbox.Visible = False
                div_todolist.Visible = True
            Else
                div_inbox.Visible = True
                div_todolist.Visible = False
            End If
        End If
    End Sub

    Sub Ticket_Todo()
        If Request.QueryString("status") = "Open" Then
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
                    VTodolist &= "<tr>" & _
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
                ltr_todolist.Text = VTodolist
            Catch ex As Exception
                Response.Write(ex.Message)
            End Try
        ElseIf Request.QueryString("Status") = "progress" Then
            str = "SP_Progress " & Session("LoginTypeAngka") & "," & Session("divisi") & "," & Session("UserName") & "," & Request.QueryString("status") & ""
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
                    VTodolist &= "<tr>" & _
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
                ltr_todolist.Text = VTodolist
            Catch ex As Exception
                Response.Write(ex.Message)
            End Try
        End If
    End Sub

    Function highlightText(ByVal textNya As String)
        Dim aa, outputNya As String
        Dim s As String = textNya.ToString()
        Dim coutn As String() = s.ToString().Split(" ")
        Dim k As Integer = coutn.Length
        Dim selectTable As String
        For q As Integer = 0 To k - 1
            aa = Regex.Replace(coutn(q), "[^0-9a-zA-Z]+", "")
            selectTable = "select * from( " & _
                            "select Text_Keywords from mKeyword  " & _
                            "union " & _
                            "select Text_SubKeywords from mSubkeyword " & _
                            ") as a " & _
                            "where a.Text_Keywords = '" & aa & "' "

            com = New SqlCommand(selectTable, sqlCon)
            sqlCon.Open()
            sqlDtr = com.ExecuteReader()
            If sqlDtr.Read() Then
                outputNya += "<span class='bl'>" & aa & "</span> &nbsp"
            Else
                outputNya += aa & "&nbsp"
            End If
            sqlDtr.Close()
            sqlCon.Close()

            If aa = "" Then

            End If
        Next

        Return outputNya
    End Function

    Private Sub Count_Ticket()
        Dim SOpen As String = ""
        If Session("LoginTypeAngka") = 1 Then
            SOpen = "select count(ID) as Data From tTicket where UserCreate='" & Session("UserName") & "' and TicketPosition='" & Session("LoginTypeAngka") & "' and (Status='Open' or Status='progress')"
        ElseIf Session("LoginTypeAngka") = 2 Then
            SOpen = "select count(ID) as Data From tTicket where (UserCreate='" & Session("UserName") & "' OR dispatch_user='" & Session("UserName") & "' OR Divisi='" & Session("Divisi") & "') and TicketPosition='" & Session("LoginTypeAngka") & "' and Status='progress'"
        ElseIf Session("LoginTypeAngka") = 3 Then
            SOpen = "select count(ID) as Data From tTicket where (UserCreate='" & Session("UserName") & "' OR dispatch_user='" & Session("UserName") & "' OR Divisi='" & Session("Divisi") & "') and TicketPosition='" & Session("LoginTypeAngka") & "' and Status='progress'"
        ElseIf Session("LoginTypeAngka") = 4 Then
            SOpen = "select count(ID) as Data From tTicket where (Status='Open' or Status='progress')"
        ElseIf Session("LoginTypeAngka") = 5 Then
            SOpen = "select count(ID) as Data From tTicket where (Status='Open' or Status='progress')"
        End If
        com = New SqlCommand(SOpen, con)
        Try
            con.Open()
            sqlDr = com.ExecuteReader
            If sqlDr.HasRows Then
                sqlDr.Read()
                If sqlDr("Data") = 0 Then
                    lbl_open.Text = 0
                Else
                    lbl_open.Text = sqlDr("Data").ToString
                End If
            Else
            End If
            sqlDr.Close()
            con.Close()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
        Dim SClose As String = "select count(ID) as Data From tTicket where (UserCreate='" & Session("UserName") & "' OR dispatch_user='" & Session("UserName") & "' OR Divisi='" & Session("Divisi") & "') and Status='Closed'"
        com = New SqlCommand(SClose, con)
        Try
            con.Open()
            sqlDr = com.ExecuteReader
            If sqlDr.HasRows Then
                sqlDr.Read()
                If sqlDr("Data") = 0 Then
                    lbl_close.Text = 0
                Else
                    lbl_close.Text = sqlDr("Data").ToString
                End If
            Else
            End If
            sqlDr.Close()
            con.Close()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
        Dim SPending As String = "select count(ID) as Data From tTicket where (UserCreate='" & Session("UserName") & "' OR dispatch_user='" & Session("UserName") & "' OR Divisi='" & Session("Divisi") & "') and Status='Pending'"
        com = New SqlCommand(SPending, con)
        Try
            con.Open()
            sqlDr = com.ExecuteReader
            If sqlDr.HasRows Then
                sqlDr.Read()
                If sqlDr("Data") = 0 Then
                    lbl_pending.Text = 0
                Else
                    lbl_pending.Text = sqlDr("Data").ToString
                End If
            Else
            End If
            sqlDr.Close()
            con.Close()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
        Dim SProgress As String
        If Session("LoginTypeAngka") = 1 Then
            SProgress = "select count(ID) as Data From tTicket where UserCreate='" & Session("UserName") & "' and TicketPosition='2' and Status='progress'"
        ElseIf Session("LoginTypeAngka") = 2 Then
            SProgress = "select count(ID) as Data From tTicket where dispatch_user='" & Session("UserName") & "' and (TicketPosition='3' or TicketPosition='1') and Status='progress'"
        ElseIf Session("LoginTypeAngka") = 3 Then
            SProgress = "select count(ID) as Data From tTicket where TicketPosition='2' and Divisi='" & Session("Divisi") & "' and Status='progress'"
        ElseIf Session("LoginTypeAngka") = 4 Then
            SProgress = "select count(ID) as Data From tTicket where TicketPosition='2' and (Status='Open' or Status='progress')"
        ElseIf Session("LoginTypeAngka") = 5 Then
            SProgress = "select count(ID) as Data From tTicket where TicketPosition='2' and (Status='Open' or Status='progress')"
        End If
        com = New SqlCommand(SProgress, con)
        Try
            con.Open()
            sqlDr = com.ExecuteReader
            If sqlDr.HasRows Then
                sqlDr.Read()
                If sqlDr("Data") = 0 Then
                    lbl_on_progress.Text = 0
                Else
                    lbl_on_progress.Text = sqlDr("Data").ToString
                End If
            Else
            End If
            sqlDr.Close()
            con.Close()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub
End Class