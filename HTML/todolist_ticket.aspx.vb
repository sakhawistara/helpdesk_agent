Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.UI
Imports System.Threading
Imports DevExpress.Web.ASPxGridView
Partial Class todolist_ticket
    Inherits System.Web.UI.Page

    Dim Connection As New SqlConnection(ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString)
    Dim SeTicket, SqlCom As SqlCommand
    Dim sqlDr, Dr As SqlDataReader
    Dim SelTicket1 As String
    Dim Waktu As String
    Dim Ceknull, urutanNO As String
    Dim SelTicket As String
    Dim datLastDay As Date
    Dim DS As New DataTable
    Dim aDR1 As DataRow
    Dim Proses As New ClsConn
    Dim sql As String
    Dim value As String

    Public Function GetLastDayOfMonth(ByVal intMonth As String, ByVal intYear As String) As Date
        GetLastDayOfMonth = DateSerial(intYear, intMonth + 1, 0)
    End Function
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Waktu = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss ")
        Dim NikValue As String = Request.QueryString("Nik")
        SourceTicket.SelectCommandType = SqlDataSourceCommandType.Text
        SourceTicket.SelectCommand = "spExec_ToDoListCUdanPIC " & Session("LoginTypeAngka") & "," & Session("divisi") & "," & Session("UserName") & ""

        SelTicket = "spExec_ToDoListCUdanPIC " & Session("LoginTypeAngka") & "," & Session("divisi") & "," & Session("UserName") & ""
        SeTicket = New SqlCommand(SelTicket, Connection)
        Connection.Open()
        sqlDr = SeTicket.ExecuteReader()
        sqlDr.Read()
        sqlDr.Close()
        Connection.Close()
        SqlDataSource1.SelectCommand = "select ResponseComplaint,DateCreate from tInteraction where TicketNumber='dd'"
    End Sub

    Dim posisiTicket As String
    Public Function cekPosisiTicket(ByVal PosisiUserName As String) As String
        Dim getPositionUser As String
        getPositionUser = "select (SUBSTRING(b.LevelUserSbg,6,3)) as TicketPosisiNya from msUser a left outer join msUserTrustee b on a.LevelUser=b.LevelUser  where a.NIK='" & PosisiUserName & "'"
        SqlCom = New SqlCommand(getPositionUser, Connection)
        Connection.Open()
        sqlDr = SqlCom.ExecuteReader()
        If sqlDr.Read() Then
            posisiTicket = sqlDr("TicketPosisiNya").ToString
        End If
        sqlDr.Close()
        Connection.Close()
    End Function

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Waktu = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss ")
        SourceTicket.SelectCommandType = SqlDataSourceCommandType.Text
        SourceTicket.SelectCommand = "spExec_ToDoListCUdanPIC " & Session("LoginTypeAngka") & "," & Session("divisi") & "," & Session("UserName") & ""
        SqlDataSource1.SelectCommand = "select AgentCreate,ResponseComplaint,DateCreate from tInteraction where TicketNumber='dd'"

        SelTicket = "spExec_ToDoListCUdanPIC " & Session("LoginTypeAngka") & "," & Session("divisi") & "," & Session("UserName") & ""
        SqlCom = New SqlCommand(SelTicket, Connection)
        Connection.Open()
        sqlDr = SqlCom.ExecuteReader()

        Dim aDR1 As DataRow
        DS.Columns.Add(New DataColumn("NoUrut", System.Type.GetType("System.Int32")))
        DS.Columns.Add(New DataColumn("NumberRow", System.Type.GetType("System.Int32")))
        DS.Columns.Add(New DataColumn("NIK", System.Type.GetType("System.String")))
        DS.Columns.Add(New DataColumn("NamePIC", System.Type.GetType("System.String")))
        DS.Columns.Add(New DataColumn("TicketNumber", System.Type.GetType("System.String")))
        DS.Columns.Add(New DataColumn("Status", System.Type.GetType("System.String")))
        DS.Columns.Add(New DataColumn("SLA", System.Type.GetType("System.String")))
        DS.Columns.Add(New DataColumn("Range", System.Type.GetType("System.String")))
        DS.Columns.Add(New DataColumn("DetailComplaint", System.Type.GetType("System.String")))
        DS.Columns.Add(New DataColumn("DateCreate", System.Type.GetType("System.String")))
        DS.Columns.Add(New DataColumn("UserCreate", System.Type.GetType("System.String")))
        DS.Columns.Add(New DataColumn("StatusIndikator", System.Type.GetType("System.String")))
        DS.Columns.Add(New DataColumn("RangeResponse", System.Type.GetType("System.String")))
        While sqlDr.Read
            aDR1 = DS.NewRow
            aDR1("NoUrut") = sqlDr("NoUrut")
            aDR1("NumberRow") = sqlDr("NumberRow")
            aDR1("NIK") = sqlDr("NIK")
            aDR1("NamePIC") = sqlDr("NamePIC")
            aDR1("TicketNumber") = sqlDr("TicketNumber")
            aDR1("Status") = sqlDr("Status")
            aDR1("SLA") = sqlDr("SLA")
            aDR1("DetailComplaint") = sqlDr("DetailComplaint")
            aDR1("DateCreate") = sqlDr("DateCreate")
            aDR1("UserCreate") = sqlDr("UserCreate")
            aDR1("Range") = sqlDr("Range")
            aDR1("RangeResponse") = sqlDr("RangeResponse")
            ' Format color By Image
            Dim Create As Integer = sqlDr("Range")
            Dim Status As String = sqlDr("Status").ToString
            Dim SLA As String = sqlDr("SLA").ToString
            Dim Range_Response As String = sqlDr("RangeResponse").ToString
            If Status = "Closed" Then
                If SLA = Create Then
                    aDR1("StatusIndikator") = ResolveUrl("img/icon/ledgreen.png")
                ElseIf SLA > Create Then
                    aDR1("StatusIndikator") = ResolveUrl("img/icon/ledred.png")
                ElseIf SLA < Create Then
                    aDR1("StatusIndikator") = ResolveUrl("img/icon/ledyellow.png")
                End If
            Else
                If Create > 0 Then
                    aDR1("StatusIndikator") = ResolveUrl("img/icon/ledred.png")
                ElseIf Create = 0 Then
                    aDR1("StatusIndikator") = ResolveUrl("img/icon/ledgreen.png")
                ElseIf Create < SLA Then
                    aDR1("StatusIndikator") = ResolveUrl("img/icon/ledyellow.png")
                End If
                If Range_Response > 0 Then
                    aDR1("RangeResponse") = ResolveUrl("img/icon/ledred.png")
                ElseIf Range_Response = 0 Then
                    aDR1("RangeResponse") = ResolveUrl("img/icon/ledgreen.png")
                ElseIf Range_Response < SLA Then
                    aDR1("RangeResponse") = ResolveUrl("img/icon/ledyellow.png")
                End If
            End If
            DS.Rows.Add(aDR1)
        End While

        grid.DataSource = DS
        grid.KeyFieldName = "NIK"
        grid.DataBind()
        Connection.Close()
    End Sub


    
End Class
