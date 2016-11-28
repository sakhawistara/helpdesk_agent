Imports System.Collections.Generic
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Timers
Imports System.Data.OleDb
Public Class allfb
    Inherits System.Web.UI.Page
    Dim Con As New SqlConnection(ConfigurationManager.ConnectionStrings("SosmedConnection").ConnectionString)
    Dim Com As SqlCommand
    Dim Dr As SqlDataReader
    Dim Con1 As New SqlConnection(ConfigurationManager.ConnectionStrings("SosmedConnection").ConnectionString)
    Dim Com1 As SqlCommand
    Dim Dr1 As SqlDataReader

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim tampungan As String
        If Request.QueryString("id") = "" Then
            Dim selectdata As String = "Select ROW_NUMBER() over(order by ddate Desc)as No, idTbl,  Name, TextNya, ddate, dSource, flagread, agent_handle From ( " & _
                                    "Select P_ddate as ddate, P_ID_Post as idTbl, P_User_Name as Name, P_Message as TextNya, P_flagread as flagread ,dSource, P_agent_handle as agent_handle from GetSosmed_One " & _
                                    "UNION " & _
                                    "Select C_ddate as ddate, C_ID_Post as idTbl, C_User_Name as Name, C_Message as TextNya, C_flagread as flagread, dSource, C_agent_handle as agent_handle from GetSosmed_Two " & _
                                    "UNION " & _
                                    "Select R_ddate as ddate, R_ID_Post as idTbl, R_User_name as Name, R_Message as TextNya, R_flagread as flagread, dSource, R_agent_handle as agent_handle from GetSosmed_Three " & _
                                    "UNION " & _
                                    "select tTime as ddate, id_Chat as idTbl, tfrom as Name, tMessage as TextNya, flag_Read as flagread, 'inbox' as dSource, agent_handle from GetSosmed_Inbox ) " & _
                                    "as a " & _
                                    "WHERE flagread = '1' and Name <> 'Invision POC' and (dSource = 'fb_Post' or dSource = 'fb_comment' or dSource = 'fb_reply' or dSource = 'inbox') " & _
                                    "order by  ddate desc"
            Com = New SqlCommand(selectdata, Con)
            Con.Open()
            Dr = Com.ExecuteReader()
            While Dr.Read
                tampungan &= "<tr>" & _
                           "<td><a href='allfb.aspx?id=" & Dr("idTbl").ToString & "&Name=" & Dr("Name") & "&ket=" & Dr("dSource") & "'>" & _
                           "Show Conversation</a></td>" & _
                            "<td>" & Dr("dSource").ToString & "</td>" & _
                            "<td>" & Dr("Name").ToString & "</td>" & _
                           "</tr>"
            End While
            Dr.Close()
            Con.Close()
            ltr_email.Text = tampungan

        Else
            Dim selectdata As String = "Select ROW_NUMBER() over(order by ddate Desc)as No, idTbl,  Name, TextNya, ddate, dSource, flagread, agent_handle From ( " & _
                                   "Select P_ddate as ddate, P_ID_Post as idTbl, P_User_Name as Name, P_Message as TextNya, P_flagread as flagread ,dSource, P_agent_handle as agent_handle from GetSosmed_One " & _
                                   "UNION " & _
                                   "Select C_ddate as ddate, C_ID_Post as idTbl, C_User_Name as Name, C_Message as TextNya, C_flagread as flagread, dSource, C_agent_handle as agent_handle from GetSosmed_Two " & _
                                   "UNION " & _
                                   "Select R_ddate as ddate, R_ID_Post as idTbl, R_User_name as Name, R_Message as TextNya, R_flagread as flagread, dSource, R_agent_handle as agent_handle from GetSosmed_Three " & _
                                   "UNION " & _
                                   "select tTime as ddate, id_Chat as idTbl, tfrom as Name, tMessage as TextNya, flag_Read as flagread, 'inbox' as dSource, agent_handle from GetSosmed_Inbox ) " & _
                                   "as a " & _
                                   "WHERE flagread = '1' and Name <> 'Invision POC' and (dSource = 'fb_Post' or dSource = 'fb_comment' or dSource = 'fb_reply' or dSource = 'inbox') " & _
                                   "order by  ddate desc"
            Com = New SqlCommand(selectdata, Con)
            Con.Open()
            Dr = Com.ExecuteReader()
            While Dr.Read
                tampungan &= "<tr>" & _
                           "<td style='width:50px'><a href='allfb.aspx?id=" & Dr("idTbl").ToString & "&Name=" & Dr("Name") & "&ket=" & Dr("dSource") & "'>Show Detil</a></td>" & _
                            "<td style='width:100px'>" & Dr("dSource").ToString & "</td>" & _
                            "<td style='width:100px'>" & Dr("Name").ToString & "</td>" & _
                           "</tr>"
            End While
            Dr.Close()
            Con.Close()
            ltr_email.Text = tampungan

            'conversation
            Dim detiltampung As String
            Dim selectdetil As String = "Select ROW_NUMBER() over(order by ddate Desc)as No, idTbl,  Name, TextNya, ddate, dSource, flagread, agent_handle From ( " & _
                                   "Select P_ddate as ddate, P_ID_Post as idTbl, P_User_Name as Name, P_Message as TextNya, P_flagread as flagread ,dSource, P_agent_handle as agent_handle from GetSosmed_One " & _
                                   "UNION " & _
                                   "Select C_ddate as ddate, C_ID_Post as idTbl, C_User_Name as Name, C_Message as TextNya, C_flagread as flagread, dSource, C_agent_handle as agent_handle from GetSosmed_Two " & _
                                   "UNION " & _
                                   "Select R_ddate as ddate, R_ID_Post as idTbl, R_User_name as Name, R_Message as TextNya, R_flagread as flagread, dSource, R_agent_handle as agent_handle from GetSosmed_Three " & _
                                   "UNION " & _
                                   "select tTime as ddate, id_Chat as idTbl, tfrom as Name, tMessage as TextNya, flag_Read as flagread, 'inbox' as dSource, agent_handle from GetSosmed_Inbox ) " & _
                                   "as a " & _
                                   "WHERE flagread = '1' and Name <> 'Invision POC' and (dSource = 'fb_Post' or dSource = 'fb_comment' or dSource = 'fb_reply' or dSource = 'inbox') " & _
                                   "order by  ddate desc"
            Com = New SqlCommand(selectdetil, Con)
            Con.Open()
            Dr = Com.ExecuteReader()
            While Dr.Read
                detiltampung &= "<li class='left clearfix'> " & _
                                        "<span class='chat-img pull-left'> " & _
                                            "<img src='img/user.jpg' alt=User Avatar'> " & _
                                        "</span> " & _
                                        "<div class='chat-body clearfix'>" & _
                                            "<div class='header'>" & _
                                                "<strong class='primary-font'>" & Dr("Name").ToString & "</strong>" & _
                                                "<small class='pull-right text-muted'><i class='fa fa-clock-o'></i>" & Dr("ddate").ToString & "</small>" & _
                                            "</div>" & _
                                            "<p> " & Dr("TextNya").ToString & " </p>" & _
                                        "</div>" & _
                                    "</li>"
                Try
                    Dim history As String = "select * from sosmed_post where ID_Post = '" & Dr("idTbl").ToString & "' and tName = '" & Dr("Name").ToString & "'"
                    Com1 = New SqlCommand(history, Con1)
                    Con1.Open()
                    Dr1 = Com1.ExecuteReader()
                    While Dr1.Read()
                        detiltampung &= "<li class='right clearfix'> " & _
                                        "<span class='chat-img pull-right'> " & _
                                            "<img src='img/user.jpg' alt=User Avatar'> " & _
                                        "</span> " & _
                                        "<div class='chat-body clearfix'>" & _
                                            "<div class='header'>" & _
                                                "<strong class='primary-font'>" & Dr1("agent_handle").ToString & "</strong>" & _
                                                "<small class='pull-right text-muted'><i class='fa fa-clock-o'></i>" & Dr1("ddate").ToString & "</small>" & _
                                            "</div>" & _
                                            "<p> " & Dr1("tMessage").ToString & " </p>" & _
                                        "</div>" & _
                                    "</li>"
                    End While
                    Dr1.Close()
                    Con1.Close()
                Catch ex As Exception
                    Response.Write(ex.Message)
                End Try
            End While
            Dr.Close()
            Con.Close()
            ltr_detil.Text = detiltampung
        End If



    End Sub

End Class