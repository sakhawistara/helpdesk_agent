Imports System.Collections.Generic
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Timers
Imports System.Data.OleDb
Public Class todolist_sosmed
    Inherits System.Web.UI.Page
    Dim Con As New SqlConnection(ConfigurationManager.ConnectionStrings("SosmedConnection").ConnectionString)
    Dim Com As SqlCommand
    Dim Dr As SqlDataReader
    Dim Con1 As New SqlConnection(ConfigurationManager.ConnectionStrings("SosmedConnection").ConnectionString)
    Dim Com1 As SqlCommand
    Dim Dr1 As SqlDataReader

    'ini function untuk highlight text
    Function highlightText(ByVal textNya As String)
        Dim aa, outputNya As String
        Dim s As String = textNya.ToString()
        Dim coutn As String() = s.ToString().Split(" ")
        Dim k As Integer = coutn.Length

        Dim selectTable As String
        For q As Integer = 0 To k - 1
            aa = Regex.Replace(coutn(q), "[^0-9a-zA-Z]+", "")
            'selectTable = "select Text_Keywords from mKeyword union select Text_SubKeywords from mSubkeyword where Text_Keywords like'%" & aa & "%'"
            selectTable = "select * from( " & _
                            "select Text_Keywords from mKeyword  " & _
                            "union " & _
                            "select Text_SubKeywords from mSubkeyword " & _
                            ") as a " & _
                            "where a.Text_Keywords = '" & aa & "' "

            Com1 = New SqlCommand(selectTable, Con1)
            Con1.Open()
            Dr1 = Com1.ExecuteReader()
            If Dr1.Read() Then
                outputNya += "<span class='bl'>" & aa & "</span> &nbsp"
            Else
                outputNya += aa & "&nbsp"
            End If
            Dr1.Close()
            Con1.Close()

            If aa = "" Then

            End If
        Next

        Return outputNya

    End Function



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'ini code untuk load data dan show data di grid tapi masih di lepas belum pake where agent handle agent handle

        Dim tampungan As String
        Try
            Dim selectdata As String = "Select ROW_NUMBER() over(order by ddate Desc)as No, idTbl,  Name, TextNya, ddate, dSource, flagread, agent_handle From ( " & _
                                        "Select P_ddate as ddate, P_ID_Post as idTbl, P_User_Name as Name, P_Message as TextNya, P_flagread as flagread ,dSource, P_agent_handle as agent_handle from GetSosmed_One " & _
                                        "UNION " & _
                                        "Select C_ddate as ddate, C_ID_Post as idTbl, C_User_Name as Name, C_Message as TextNya, C_flagread as flagread, dSource, C_agent_handle as agent_handle from GetSosmed_Two " & _
                                        "UNION " & _
                                        "Select R_ddate as ddate, R_ID_Post as idTbl, R_User_name as Name, R_Message as TextNya, R_flagread as flagread, dSource, R_agent_handle as agent_handle from GetSosmed_Three " & _
                                        "UNION " & _
                                        "select tTime as ddate, id_Chat as idTbl, tfrom as Name, tMessage as TextNya, flag_Read as flagread, 'inbox' as dSource, agent_handle from GetSosmed_Inbox ) " & _
                                        "as a " & _
                                        "WHERE flagread = '0' and Name <> 'Invision POC' " & _
                                        "order by  ddate desc"
            Com = New SqlCommand(selectdata, Con)
            Con.Open()
            Dr = Com.ExecuteReader()
            While Dr.Read
                tampungan &= "<tr class='odd gradeX'>" & _
                       "<td align='center' style='width:100px'><a href='detilsosmed.aspx?id=" & Dr("idTbl").ToString & "&Name=" & Dr("Name") & "&ket=" & Dr("dSource") & "'>Reply</a></td>" & _
                       "<td style='width:200px'>" & Dr("Name").ToString & "</td>" & _
                       "<td style='word-wrap: break-word;min-width: 250px;max-width: 250px;white-space:normal; overflow: hidden;'>" & highlightText(Dr("TextNya").ToString) & "</td>" & _
                            "<td style='width:200px' >" & Dr("ddate").ToString & "</td>" & _
                       "<td style='width:150px'>" & Dr("dSource").ToString & "</td>" & _
                    "</tr>"
                'Dim selectwarna As String = " select * from GetSosmed_Filter where K_Primary ='" & Dr("idTbl").ToString & "' "
                'Com1 = New SqlCommand(selectwarna, Con1)
                'Con1.Open()
                'Dr1 = Com1.ExecuteReader()
                'While Dr1.Read
                '    If Dr1.HasRows Then
                '        tampungan &= "<td BGCOLOR='RED' >" & Dr("TextNya").ToString & "</td>" & _
                '            "<td style='width:200px' >" & Dr("ddate").ToString & "</td>" & _
                '       "<td style='width:150px'>" & Dr("dSource").ToString & "</td>" & _
                '    "</tr>"
                '    Else
                '        tampungan &= "<td>" & Dr("TextNya").ToString & "</td>" & _
                '            "<td style='width:200px' >" & Dr("ddate").ToString & "</td>" & _
                '       "<td style='width:150px'>" & Dr("dSource").ToString & "</td>" & _
                '    "</tr>"
                '    End If
                'End While
                'Dr1.Close()
                'Con1.Close()
            End While
            Dr.Close()
            Con.Close()

        Catch ex As Exception

        End Try
        ltr_email.Text = tampungan

    End Sub

End Class