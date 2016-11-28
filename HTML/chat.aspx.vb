Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports ICC.ClsConn
Public Class chat
    Inherits System.Web.UI.Page

    Dim Proses As New ClsConn
    Dim sqldr, sqldra, dr, reader As SqlDataReader
    Dim sql As String
    Dim valTwitHst As String
    Dim weberConnection As New SqlConnection(ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString)
    Dim sqlcom, com, scom, Comm, Cmd As SqlCommand
    Dim listchat As String = ""
    Dim sqlcon As New SqlConnection(ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString)
    Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString)
    Dim sqlConection As New SqlConnection(ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString)
    Dim commentID, replyID, messageID, dmID As String
    Dim Con1 As New SqlConnection(ConfigurationManager.ConnectionStrings("SosmedConnection").ConnectionString)
    Dim sqlconn As New SqlConnection(ConfigurationManager.ConnectionStrings("SosmedConnection").ConnectionString)
    Dim Com1 As SqlCommand
    Dim Dr1 As SqlDataReader
    Dim conn As SqlConnection
    Dim connection As New ClsConn
    Dim connectionString As String = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
    Dim TicketNo As String = ""
    Dim Createlog As New ClsConn
    Dim NotEmailSend As New ClsConn
    Dim Sosmed As New ClsSos
    Dim waktu As String = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt ")
    Dim tanggalCreateSetelahDiCek As System.DateTime
    Dim tanggalCloseSetelahDiCek As System.DateTime
    Dim JamCreateTicket As String = Date.Now.ToString("HH:mm")
    Dim JamBatasanTicket As String = "17:00"
    Dim JamSekarang As String = DateTime.Now.ToString("HH:mm:ss")
    Dim VYear, VMonth, VDay, VHours, VMinnute, VDetik As String
    Dim ValueDateCloseTicket As String
    Dim DateNow As String = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt")
    Dim ParamCustomer As String
    Dim EmailCustomer As String = ""
    Dim EmailForm As String = ConfigurationManager.AppSettings("EmailFrom")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        sql_Source_Master()
        cmb_source_type.Value = "Chat"
        If Request.QueryString("id") <> "" Then
            detail_chat()
            list_Chat()
            UserId.Value = Request.QueryString("id")
            Dim Div As String = "<li><a href='chat.aspx?id=" & UserId.Value & "'><i class='fa fa-refresh'></i> Refresh</a></li>"
            ltr_refresh.Text = Div
            history()
        Else
            list_Chat()
        End If
    End Sub

    Private Sub list_Chat()
        Dim myIPs As String = Request.ServerVariables("REMOTE_ADDR")
        Dim emailCust As String = Request.QueryString("ema")
        Dim BelumDiLihat, BelumDiLihatNew, UserIDChat As String
        Dim q_ChatCust As String
        If Request.QueryString("leveluser") = "admin" Then
            q_ChatCust = "select UserID, Nama, FlagTo,  from tChat where Flagend = 'N'"
        Else
            q_ChatCust = "select UserID, Nama, FlagTo from tChat where Nama='" & Session("UserName") & "'"
        End If
        sqlcom = New SqlCommand(q_ChatCust, weberConnection)
        Try
            weberConnection.Open()
            sqldr = sqlcom.ExecuteReader()
            While sqldr.Read()
                UserIDChat &= sqldr("UserID") & ",".ToString
            End While
            sqldr.Close()
        Catch ex As Exception
            Response.Write(ex.Message())
        Finally
            weberConnection.Close()
        End Try

        Dim strFunction As String
        Dim strArr() As String
        Dim count As Integer
        Dim whereTambahanDept As String = ""

        If UserIDChat <> "" Then
            strFunction = UserIDChat
            strArr = strFunction.Split(",")
            For count = 0 To strArr.Length - 1
                If count = 0 Then
                    whereTambahanDept &= "UserID = '" & strArr(count) & "' "
                ElseIf count < strArr.Length - 1 Then
                    whereTambahanDept &= "OR UserID = '" & strArr(count) & "' "
                Else
                    'whereTambahanDept &= "OR UserID = '" & strArr(count) & "' "
                End If
            Next
        Else
            whereTambahanDept = "UserID ='" & UserIDChat & "'"
        End If
        Dim VWaktu As DateTime = Date.Now.ToString("yyyy-MM-dd")
        Dim waktu_year As String = VWaktu.Year.ToString
        Dim waktu_month As String = VWaktu.Month.ToString
        Dim waktu_day As String = VWaktu.Day.ToString
        Dim start As String = waktu_year & "-" & waktu_month & "-" & waktu_day & " 00:01 AM"
        Dim akhir As String = waktu_year & "-" & waktu_month & "-" & waktu_day & " 11:59 PM"
        Dim VAgent As String = "Select UserID, Nama from tChat where  (" & whereTambahanDept & ") and FlagTo='Cust' and DateCreate > '" & start & "' and DateCreate < '" & akhir & "'  group by UserID, Nama, FlagTo order by UserID Desc"
        sqlcom = New SqlCommand(VAgent, weberConnection)
        Try
            weberConnection.Open()
            sqldr = sqlcom.ExecuteReader()
            While sqldr.Read()
                'count chat yg belum dilihat oleh agent
                If Request.QueryString("leveluser") = "admin" Then
                    Dim count_wait As String = "select count(UserID) As Data from tChat where UserID='" & sqldr("UserID") & "' and StatusChat='WaitingAgent'"
                    com = New SqlCommand(count_wait, sqlcon)
                    sqlcon.Open()
                    sqldra = com.ExecuteReader()
                    If sqldra.Read Then
                        BelumDiLihat = sqldra("Data").ToString
                    End If
                    sqldra.Close()
                    sqlcon.Close()

                    Dim count_new As String = "select count(UserID) As Data from tChat where UserID='" & sqldr("UserID") & "' and BlinkChat='New'"
                    com = New SqlCommand(count_new, sqlcon)
                    sqlcon.Open()
                    sqldra = com.ExecuteReader()
                    If sqldra.Read Then
                        BelumDiLihatNew = sqldra("Data").ToString
                    End If
                    sqldra.Close()
                    sqlcon.Close()
                Else
                    Dim count_wait As String = "select count(UserID) As Data from tChat where UserID='" & sqldr("UserID") & "' and StatusChat='WaitingAgent'"
                    com = New SqlCommand(count_wait, sqlcon)
                    sqlcon.Open()
                    sqldra = com.ExecuteReader()
                    If sqldra.Read Then
                        BelumDiLihat = sqldra("Data")
                    End If
                    sqldra.Close()
                    sqlcon.Close()

                    Dim count_new As String = "select count(UserID) As Data from tChat where UserID='" & sqldr("UserID") & "' and BlinkChat='New'"
                    com = New SqlCommand(count_new, sqlcon)
                    sqlcon.Open()
                    sqldra = com.ExecuteReader()
                    If sqldra.Read Then
                        BelumDiLihatNew = sqldra("Data")
                    End If
                    sqldra.Close()
                    sqlcon.Close()
                End If
                If BelumDiLihatNew = 0 Then
                    listchat &= "<tr>" & _
                                "<td><a href='chat.aspx?id=" & sqldr("UserID") & "&account=" & sqldr("Nama") & "'>" & sqldr("Nama") & "</a></td>" & _
                                "<td><a href='chat.aspx?id=" & sqldr("UserID") & "&account=" & sqldr("Nama") & "'><small class='chat-alert text-muted'><i class='fa fa-check'></i></small></a></td>" & _
                                "</tr>"
                Else
                    listchat &= "<tr>" & _
                                "<td><a href='chat.aspx?id=" & sqldr("UserID") & "&account=" & sqldr("Nama") & "'>" & sqldr("Nama") & "</a></span></td>" & _
                                "<td><a href='chat.aspx?id=" & sqldr("UserID") & "&account=" & sqldr("Nama") & "'><small class='chat-alert badge badge-danger'>" & BelumDiLihat & "</small></a></td>" & _
                                "</tr>"
                End If
            End While
            sqldr.Close()
        Catch ex As Exception
            Response.Write(ex.Message())
        Finally
            weberConnection.Close()
        End Try
        showhistory.Text = listchat
    End Sub

    Private Sub detail_chat()
        Dim UChat As String = "Update tChat set StatusChat='OpenChat', BlinkChat='Read' Where UserID='" & Request.QueryString("id") & "'"
        com = New SqlCommand(UChat, con)
        con.Open()
        com.ExecuteNonQuery()
        con.Close()

        Dim tampungan, cssSpan, fix As String
        Dim chat_detail As String = "Select * from tchat where UserID='" & Request.QueryString("id") & "' order by TrxChatID asc"
        com = New SqlCommand(chat_detail, con)
        con.Open()
        dr = com.ExecuteReader()
        While dr.Read()
            If dr("FlagTo").ToString = "Agent" Then
                cssSpan = "<span class='chat-img pull-left'> " & _
                                            "<img src='img/nana.jpg' alt=User Avatar'> " & _
                           "</span> "
                fix = "left clearfix"
            Else
                cssSpan = "<span class='chat-img pull-right'> " & _
                                            "<img src='img/fahri.jpg' alt=User Avatar'> " & _
                          "</span> "
                fix = "right clearfix"
            End If
            tampungan &= "<li class='" & fix & "'> " & _
                                        "" & cssSpan & "" & _
                                        "<div class='chat-body clearfix'>" & _
                                            "<div class='header'>" & _
                                                "<strong class='primary-font'>" & dr("Nama").ToString & "</strong>" & _
                                                "<small class='pull-right text-muted'><i class='fa fa-clock-o'></i>" & dr("DateCreate").ToString & "</small>" & _
                                            "</div>" & _
                                            "<p> " & dr("Pesan").ToString & " </p>" & _
                                        "</div>" & _
                                    "</li>"
        End While
        dr.Close()
        con.Close()
        ltr_chat.Text = tampungan
    End Sub

    Private Sub btnchat_ServerClick(sender As Object, e As EventArgs) Handles btnchat.ServerClick
        Dim email As String = ""
        Dim sql As String = "Select * from tChat where UserID='" & Request.QueryString("id") & "'"
        com = New SqlCommand(sql, con)
        con.Open()
        sqldr = com.ExecuteReader
        If sqldr.Read Then
            email = sqldr("Email").ToString
        End If
        sqldr.Close()
        con.Close()
        Dim IChat As String = "Insert Into tChat (UserID, Nama, FlagTo, Pesan, DateCreate, StatusChat, Email) Values ('" & Request.QueryString("id") & "','" & Session("UserName") & "','Agent','" & textchat.Value & "', getdate(),'WaitingAgent','" & email & "')"
        com = New SqlCommand(IChat, con)
        con.Open()
        com.ExecuteNonQuery()
        con.Close()
        detail_chat()
    End Sub

    Private Sub callbackPanelX_Callback(sender As Object, e As DevExpress.Web.ASPxClasses.CallbackEventArgsBase) Handles callbackPanelX.Callback
        div_properties.Visible = True
        div_sla.Visible = True
        Dim Response_agent As String
        If mCatID.Value = "Refresh" Then
            Category.Value = ""
            SubCategoryI.Value = ""
            SubCategoryII.Value = ""
            SubCategoryIII.Value = ""
        Else
            If SubCategoryIII.Text <> "" Then
                Dim erroCode, ExCat, Categori, Cat1, Sub1, Sub2, SubCategory1, SubCategory2, PriorityValue, SeverityValue, ValueSLA, SubCategory3 As String
                ExCat = " SELECT dbo.mCategory.*, dbo.mSubCategoryLv1.*,dbo.mSubCategoryLv1.SubName AS SubName1, dbo.mSubCategoryLv2.SubName AS SubName2, dbo.mSubCategoryLv3.* " & _
                        " FROM dbo.mCategory INNER JOIN " & _
                        " dbo.mSubCategoryLv1 ON dbo.mCategory.CategoryID = dbo.mSubCategoryLv1.CategoryID INNER JOIN " & _
                        " dbo.mSubCategoryLv2 ON dbo.mSubCategoryLv1.SubCategory1ID = dbo.mSubCategoryLv2.SubCategory1ID INNER JOIN " & _
                        " dbo.mSubCategoryLv3 ON dbo.mSubCategoryLv2.SubCategory2ID = dbo.mSubCategoryLv3.SubCategory2ID " & _
                        " where dbo.mSubCategoryLv3.SubCategory3ID = '" & mCatID.Value & "'"
                com = New SqlCommand(ExCat, sqlConection)
                sqlConection.Open()
                dr = com.ExecuteReader()
                dr.Read()
                Categori = dr("Name").ToString
                SubCategory1 = dr("SubName1").ToString
                SubCategory2 = dr("SubName2").ToString
                SubCategory3 = dr("SubName").ToString
                cmb_priority.Text = dr("Priority").ToString
                cmb_severity.Text = dr("Severity").ToString
                Cat1 = dr("CategoryID").ToString
                Sub1 = dr("SubCategory1ID").ToString
                Sub2 = dr("SubCategory2ID").ToString
                ValueSLA = dr("SLA").ToString
                Response_agent = dr("Response_Agent").ToString
                erroCode = dr("IDKamus").ToString
                dr.Close()
                sqlConection.Close()

                Category.Value = Categori
                SubCategoryI.Value = SubCategory1
                SubCatI.Value = Sub1
                SubCatII.Value = Sub2
                CategoryHidden.Value = Cat1
                SubCategoryII.Value = SubCategory2
                hd_sla.Value = ValueSLA.ToString
                lbl_sla.Text = hd_sla.Value
                IDKamus.Value = erroCode.ToString
            ElseIf Category.Text <> "" Then
                Dim ExCat, Categori As String
                ExCat = "Select  * from mcategory where CategoryID ='" & mCatID.Value & "' and NA = 'Y'"
                com = New SqlCommand(ExCat, sqlConection)
                sqlConection.Open()
                dr = com.ExecuteReader()
                dr.Read()
                Categori = dr("CategoryID")
                dr.Close()
                sqlConection.Close()
                SourceCategoriIII.SelectCommand = "Select  * from mSubCategoryLv3 where CategoryID ='" & Categori & "' and NA = 'Y'"
            End If
        End If
    End Sub

    Sub sql_Source_Master()
        sql_source_type.SelectCommand = "select * from mSourceType where Name='Chat'"
        sql_group_type.SelectCommand = "select * from mGroupType where NA='Y'"
        SourceCategori.SelectCommand = "select * from mCategory where NA='Y'"
        sql_priority.SelectCommand = "select * from mpriority"
        sql_severity.SelectCommand = "select * from mseverity"
        sql_status.SelectCommand = "select * from mstatus"
        cmb_status.Value = "Open"
    End Sub

    Private Sub btnsent_ServerClick(sender As Object, e As EventArgs) Handles btnsent.ServerClick
        Save()
    End Sub

    Private Sub Save()
        RequiredFieldValidator1.Visible = True
        btnsent.Visible = False
        Dim YearID As System.DateTime
        Dim CariDate, value2 As String
        Dim today As System.DateTime
        Dim batasanWaktu As System.DateTime
        Dim JamCreateTicket As String = Date.Now.ToString("HH:mm")
        Dim flagUntukLewatBatasanJam As String
        If JamCreateTicket > JamBatasanTicket Then
            today = System.DateTime.Now
            batasanWaktu = today.AddDays(1)
            Dim DateNowCreate As String
            DateNowCreate = batasanWaktu.ToString("dd - MMMM - yyyy")
            CreateTicketHoliday(DateNowCreate & " 08:00:00 AM", 1)
            DateNow = tanggalCreateSetelahDiCek
            YearID = tanggalCreateSetelahDiCek
            flagUntukLewatBatasanJam = "Y"
        Else
            DateNow = DateNow
            YearID = DateNow
            flagUntukLewatBatasanJam = "N"
        End If

        'ini buat insert ke table ticket closed
        Try
            Holiday(DateNow, hd_sla.Value)
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
        VYear = tanggalCloseSetelahDiCek.Year.ToString()
        VMonth = tanggalCloseSetelahDiCek.Month.ToString()
        VDay = tanggalCloseSetelahDiCek.Day.ToString()
        VHours = tanggalCloseSetelahDiCek.Hour.ToString()
        VMinnute = tanggalCloseSetelahDiCek.Minute.ToString()
        VDetik = tanggalCloseSetelahDiCek.Second.ToString()
        ValueDateCloseTicket = VMonth & "-" & VDay & "-" & VYear & " " & VHours & ":" & VMinnute & ":" & VDetik & ""

        If cmb_status.Value = "Closed" Then

            Dim Time As String = DateTime.Now.ToString("yyyyMMddhhmmss")
            Dim FilePath As String = ConfigurationManager.AppSettings("FilePath").ToString()
            Dim FileFullPath As String = ConfigurationManager.AppSettings("FileFullPath").ToString()
            Dim blSucces As Boolean = False
            Dim filename As String = String.Empty
            'To check whether file is selected or not to uplaod
            
            Dim NIK, Email_Customer As String
            Dim SCustomer As String = "select CustomerID, Email from mCustomer Where ID='" & Request.QueryString("id") & "'"
            com = New SqlCommand(SCustomer, sqlcon)
            Try
                sqlcon.Open()
                sqldr = com.ExecuteReader
                If sqldr.Read() Then
                    NIK = sqldr("CustomerID").ToString
                    Email_Customer = sqldr("Email").ToString
                End If
                sqldr.Close()
                sqlcon.Close()
            Catch ex As Exception
                Response.Write(ex.Message)
            End Try

            Dim Attch As String
            If filename <> "" Then
                Attch = FileFullPath & filename
            Else
                Attch = "Attchment Kosong"
            End If

            Dim count As Integer
            conn = New SqlConnection(connectionString)
            Comm = New SqlCommand()
            Comm.Connection = conn
            Comm.CommandType = CommandType.StoredProcedure
            Comm.CommandText = "GENERATE_TICKET"
            If hd_nik.Value <> "" Then
                Comm.Parameters.Add("@nik", Data.SqlDbType.VarChar).Value = NIK
                ParamCustomer = NIK
            Else
                Comm.Parameters.Add("@nik", Data.SqlDbType.VarChar).Value = NIK
                ParamCustomer = NIK
            End If
            Comm.Parameters.Add("@idkamus", Data.SqlDbType.VarChar).Value = IDKamus.Value
            Comm.Parameters.Add("@ticketSource", Data.SqlDbType.VarChar).Value = cmb_source_type.Value
            Comm.Parameters.Add("@sourcetypeName", Data.SqlDbType.VarChar).Value = cmb_source_type.Text
            Comm.Parameters.Add("@complaintLevel", Data.SqlDbType.VarChar).Value = cmb_priority.Value
            Comm.Parameters.Add("@grouptype", Data.SqlDbType.VarChar).Value = cmb_group_type.Value
            Comm.Parameters.Add("@grouptypeName", Data.SqlDbType.VarChar).Value = cmb_group_type.Text
            Comm.Parameters.Add("@categoryID", Data.SqlDbType.VarChar).Value = CategoryHidden.Value
            Comm.Parameters.Add("@categoryName", Data.SqlDbType.VarChar).Value = Category.Text
            Comm.Parameters.Add("@subCategory1ID", Data.SqlDbType.VarChar).Value = SubCatI.Value
            Comm.Parameters.Add("@SubCategory1Name", Data.SqlDbType.VarChar).Value = SubCategoryI.Text
            Comm.Parameters.Add("@subCategory2ID", Data.SqlDbType.VarChar).Value = SubCatII.Value
            Comm.Parameters.Add("@SubCategory2Name", Data.SqlDbType.VarChar).Value = SubCategoryII.Text
            Comm.Parameters.Add("@subCategory3ID", Data.SqlDbType.VarChar).Value = SubCategoryIII.Value
            Comm.Parameters.Add("@SubCategory3Name", Data.SqlDbType.VarChar).Value = SubCategoryIII.Text
            Comm.Parameters.Add("@detailComplaint", Data.SqlDbType.VarChar).Value = textchat.Value
            Comm.Parameters.Add("@responseComplaint", Data.SqlDbType.VarChar).Value = textchat.Value
            Comm.Parameters.Add("@dateAgentResponse", Data.SqlDbType.DateTime).Value = waktu
            Comm.Parameters.Add("@sla", Data.SqlDbType.VarChar).Value = hd_sla.Value
            Comm.Parameters.Add("@status", Data.SqlDbType.VarChar).Value = cmb_status.Value
            Comm.Parameters.Add("@severity", Data.SqlDbType.VarChar).Value = cmb_severity.Value
            Comm.Parameters.Add("@userCreate", Data.SqlDbType.VarChar).Value = Session("UserName")
            Comm.Parameters.Add("@userClose", Data.SqlDbType.VarChar).Value = Session("UserName")
            Comm.Parameters.Add("@closedBy", Data.SqlDbType.VarChar).Value = "1"
            Comm.Parameters.Add("@kirimEmail", Data.SqlDbType.VarChar).Value = "YES"
            Comm.Parameters.Add("@count", Data.SqlDbType.Int).Value = count
            Comm.Parameters.Add("@agentCreate", Data.SqlDbType.VarChar).Value = Session("UserName")
            Comm.Parameters.Add("@dateCloseActual", Data.SqlDbType.VarChar).Value = ValueDateCloseTicket
            Comm.Parameters.Add("@atasjamkerja", Data.SqlDbType.DateTime).Value = DateNow
            Comm.Parameters.Add("@attch", Data.SqlDbType.VarChar).Value = FileFullPath & filename
            Try
                conn.Open()
                reader = Comm.ExecuteReader()
                reader.Read()
                TicketNo = reader(0)
                reader.Close()
                conn.Close()
                Update_Chat(TicketNo, NIK, Email_Customer)

            Catch ex As Exception
                Response.Write(ex.Message)
            End Try

            lbl_ticket.Text = TicketNo
            lblError.Visible = True

            Dim strArrClosed
            strArrClosed = selectTable("mCustomer", "CustomerID,Email", "CustomerID='" & ParamCustomer & "'")

            If countTable("tCloseTicket", "Count(TicketNumber)", "TicketNumber='" & TicketNo & "'") > 0 Then
                Createlog.LogCreateTicket("--START--")
                Createlog.LogCreateTicket("--" & Date.Now & "--")
                Createlog.LogCreateTicket("TicketNumber " & TicketNo & "Sudah Ada di tCloseTicket")
            Else

            End If

            Dim SEmailCreate As String = ""
            Dim VEmailCreate As String = ""
            SEmailCreate = "select * from tManejemEmail where ToolEmail='EmailClosed'"
            Try
                Com = New SqlCommand(SEmailCreate, Con)
                Con.Open()
                Dr = Com.ExecuteReader()
                If Dr.HasRows Then
                    Dr.Read()
                    VEmailCreate = Dr("Status").ToString
                End If
                Dr.Close()
                Con.Close()
            Catch ex As Exception
                Response.Write(ex.Message)
            End Try

            If VEmailCreate = True Then
                '========== Template Email =========
                Dim sDetailCustomer, CustomerID, CustomerName, CustomerTelp, CustomerAlamat, CustomerHP As String
                sDetailCustomer = "Sp_DetailCustomer '" & ParamCustomer & "'"
                Try
                    Com = New SqlCommand(sDetailCustomer, Con)
                    Con.Open()
                    Dr = Com.ExecuteReader()
                    If Dr.Read() Then
                        CustomerID = Dr("CustomerID").ToString
                        CustomerName = Dr("NamePIC").ToString
                        CustomerTelp = Dr("Telepon").ToString
                        CustomerAlamat = Dr("Alamat").ToString
                        EmailCustomer = Dr("Email").ToString
                    End If
                    Dr.Close()
                    Con.Close()
                Catch ex As Exception
                    Response.Write(ex.Message)
                End Try

                Dim VUser, VUserAddress, VNikSupervisor As String
                sql = "select EmailAddress from mEmailSuzuki where TypeLevel='CloseTicket' And NA='Y'"
                Try
                    sqldr = Proses.ExecuteReader(sql)
                    While sqldr.Read()
                        If sqldr.HasRows Then
                            sqldr.Read()
                            VUserAddress &= Dr("EmailAddress").ToString & ","
                        End If
                    End While
                    sqldr.Close()
                Catch ex As Exception
                    Response.Write(ex.Message)
                End Try

                Dim SubjectEmail As String = Category.Text & " - " & SubCategoryIII.Text & " - " & TicketNo
                Dim TableTemplate As String
                TableTemplate = "<table width=960 style=background-color:#F5F5F5; font-family: Arial,Helvetica,sans-serif; color: black;>" & _
                            "<tr><td width=200 style=font-weight:bold>Nomor Ticket</td><td>:</td><td>" & TicketNo & "</td></tr>" & _
                            "<tr><td style=font-weight:bold>Customer ID</td><td>:</td><td>" & CustomerID & "</td></tr>" & _
                            "<tr><td style=font-weight:bold>Customer Name</td><td>:</td><td>" & CustomerName & "</td></tr>" & _
                            "<tr><td style=font-weight:bold>Address</td><td>:</td><td>" & CustomerAlamat & "</td></tr>" & _
                            "<tr><td style=font-weight:bold>Phone Number</td><td>:</td><td>" & CustomerTelp & "</td></tr>" & _
                            "<tr><td style=font-weight:bold>Source Type</td><td>:</td><td>" & cmb_source_type.Text & "</td></tr>" & _
                            "<tr><td style=font-weight:bold>Group Type</td><td>:</td><td>" & cmb_group_type.Text & "</td></tr>" & _
                            "<tr><td style=font-weight:bold>Category</td><td>:</td><td>" & Category.Text & "</td></tr>" & _
                            "<tr><td style=font-weight:bold>Call Type 1</td><td>:</td><td>" & SubCategoryI.Text & "</td></tr>" & _
                            "<tr><td style=font-weight:bold>Call Type 2</td><td>:</td><td>" & SubCategoryII.Text & "</td></tr>" & _
                            "<tr><td style=font-weight:bold>Call Type 3</td><td>:</td><td>" & SubCategoryIII.Text & "</td></tr>" & _
                            "<tr><td style=font-weight:bold>Detail Complaint</td><td>:</td><td>" & textchat.Value & "</td></tr>" & _
                            "<tr><td style=font-weight:bold>Response</td><td>:</td><td>" & textchat.Value & "</td></tr>" & _
                            "<tr><td style=font-weight:bold>Ticket Status</td><td>:</td><td>" & cmb_status.Value & "</td></tr>" & _
                            "</table>"

                sql = "Insert Into IVC_EMAIL_IN_TM (DIRECTION,EFROM,ETO,TICKET_NUMBER,ESUBJECT,EBODY,ecc, Email_Date, JENIS_EMAIL) " & _
                           "Values ('out','" & EmailForm & "','" & strArrClosed(1) & "','" & TicketNo & "','" & SubjectEmail & "','" & TableTemplate & "','" & VUserAddress & "',GETDATE(),'CreateTicket')"
                Try
                    Com = New SqlCommand(sql, sqlCon)
                    sqlCon.Open()
                    Com.ExecuteNonQuery()
                    updateFlagEmail(TicketNo)
                    sqlCon.Close()
                Catch ex As Exception
                    Response.Write(ex.Message)
                End Try

            Else
                ' Create Log jika Ticket tidak dikirimkan email
                NotEmailSend.LogNotSendEmail("--Send Email Ticket No Aktif--")
                NotEmailSend.LogNotSendEmail("Date Create   :" & Date.Now & "")
                NotEmailSend.LogNotSendEmail("Ticket Number :" & TicketNo & " Berhasil di insert")
                NotEmailSend.LogNotSendEmail("Customer Id   :" & hd_nik.Value & "")
            End If
            btnsent.Visible = False
            lbl_sla.Text = hd_sla.Value
        Else

            Dim Time As String = DateTime.Now.ToString("yyyyMMddhhmmss")
            Dim FilePath As String = ConfigurationManager.AppSettings("FilePath").ToString()
            Dim FileFullPath As String = ConfigurationManager.AppSettings("FileFullPath").ToString()
            Dim blSucces As Boolean = False
            Dim filename As String = String.Empty

            Dim NIK, Email_Customer As String
            Dim SCustomer As String = "select CustomerID, Email from mCustomer Where ID='" & Request.QueryString("id") & "'"
            com = New SqlCommand(SCustomer, sqlcon)
            Try
                sqlcon.Open()
                sqldr = com.ExecuteReader
                If sqldr.Read() Then
                    NIK = sqldr("CustomerID").ToString
                    Email_Customer = sqldr("Email").ToString
                End If
                sqldr.Close()
                sqlcon.Close()
            Catch ex As Exception
                Response.Write(ex.Message)
            End Try

            Dim Attch As String
            If filename <> "" Then
                Attch = FileFullPath & filename
            Else
                Attch = "Attchment Kosong"
            End If
            Dim count As Integer
            conn = New SqlConnection(connectionString)
            Comm = New SqlCommand()
            Comm.Connection = conn
            Comm.CommandType = CommandType.StoredProcedure
            Comm.CommandText = "GENERATE_TICKET"
            If hd_nik.Value <> "" Then
                Comm.Parameters.Add("@nik", Data.SqlDbType.VarChar).Value = NIK
                ParamCustomer = NIK
            Else
                Comm.Parameters.Add("@nik", Data.SqlDbType.VarChar).Value = NIK
                ParamCustomer = NIK
            End If
            Comm.Parameters.Add("@idkamus", Data.SqlDbType.VarChar).Value = IDKamus.Value
            Comm.Parameters.Add("@ticketSource", Data.SqlDbType.VarChar).Value = cmb_source_type.Value
            Comm.Parameters.Add("@sourcetypeName", Data.SqlDbType.VarChar).Value = cmb_source_type.Text
            Comm.Parameters.Add("@complaintLevel", Data.SqlDbType.VarChar).Value = cmb_priority.Value
            Comm.Parameters.Add("@grouptype", Data.SqlDbType.VarChar).Value = cmb_group_type.Value
            Comm.Parameters.Add("@grouptypeName", Data.SqlDbType.VarChar).Value = cmb_group_type.Text
            Comm.Parameters.Add("@categoryID", Data.SqlDbType.VarChar).Value = CategoryHidden.Value
            Comm.Parameters.Add("@categoryName", Data.SqlDbType.VarChar).Value = Category.Text
            Comm.Parameters.Add("@subCategory1ID", Data.SqlDbType.VarChar).Value = SubCatI.Value
            Comm.Parameters.Add("@SubCategory1Name", Data.SqlDbType.VarChar).Value = SubCategoryI.Text
            Comm.Parameters.Add("@subCategory2ID", Data.SqlDbType.VarChar).Value = SubCatII.Value
            Comm.Parameters.Add("@SubCategory2Name", Data.SqlDbType.VarChar).Value = SubCategoryII.Text
            Comm.Parameters.Add("@subCategory3ID", Data.SqlDbType.VarChar).Value = SubCategoryIII.Value
            Comm.Parameters.Add("@SubCategory3Name", Data.SqlDbType.VarChar).Value = SubCategoryIII.Text
            Comm.Parameters.Add("@detailComplaint", Data.SqlDbType.VarChar).Value = textchat.Value
            Comm.Parameters.Add("@responseComplaint", Data.SqlDbType.VarChar).Value = textchat.Value
            Comm.Parameters.Add("@dateAgentResponse", Data.SqlDbType.DateTime).Value = waktu
            Comm.Parameters.Add("@sla", Data.SqlDbType.VarChar).Value = hd_sla.Value
            Comm.Parameters.Add("@status", Data.SqlDbType.VarChar).Value = cmb_status.Text
            Comm.Parameters.Add("@severity", Data.SqlDbType.VarChar).Value = cmb_severity.Value
            Comm.Parameters.Add("@userCreate", Data.SqlDbType.VarChar).Value = Session("UserName")
            Comm.Parameters.Add("@userClose", Data.SqlDbType.VarChar).Value = Session("UserName")
            Comm.Parameters.Add("@closedBy", Data.SqlDbType.VarChar).Value = "1"
            Comm.Parameters.Add("@kirimEmail", Data.SqlDbType.VarChar).Value = "YES"
            Comm.Parameters.Add("@count", Data.SqlDbType.Int).Value = count
            Comm.Parameters.Add("@agentCreate", Data.SqlDbType.VarChar).Value = Session("UserName")
            Comm.Parameters.Add("@dateCloseActual", Data.SqlDbType.VarChar).Value = ValueDateCloseTicket
            Comm.Parameters.Add("@atasjamkerja", Data.SqlDbType.DateTime).Value = DateNow
            Comm.Parameters.Add("@attch", Data.SqlDbType.VarChar).Value = FileFullPath & filename
            Try
                conn.Open()
                reader = Comm.ExecuteReader()
                reader.Read()
                TicketNo = reader(0)
                reader.Close()
                conn.Close()
                Update_Chat(TicketNo, NIK, Email_Customer)
            Catch ex As Exception
                Response.Write(ex.Message)
            End Try

            'Dim exec As String = "INSERT INTO tTicket " & _
            '"(TicketNumber, NIK, TicketSource, TicketSourceName, TicketGroup, " & _
            '"TicketGroupName, ComplaintLevel, CategoryID, CategoryName, " & _
            '"SubCategory1ID, SubCategory1Name, SubCategory2ID, SubCategory2Name, " & _
            '"SubCategory3ID, SubCategory3Name, DetailComplaint, ResponComplaint, " & _
            '"DateAgentResponse, SLA, Severity, Status, UserCreate, DateCreate, " & _
            '"UserClose, ClosedBy, DateCreateReal, Attch)" & _
            '"VALUES(" & _
            '"'', 'Nik', 'ticketsource', 'sourcetypeName', 'grouptype', " & _
            '"'', '', '', ''," & _
            '"'', '', '', '', " & _
            '"'', '', '', ''," & _
            '"'" & DateNow & "', '', '', '', '10', '" & ValueDateCloseTicket & "', " & _
            '"'0','0', GETDATE(), '" & FileFullPath & filename & "')	"
            'sqlcom = New SqlCommand(exec, sqlcon)
            'sqlcon.Open()
            'sqlcom.ExecuteNonQuery()
            'sqlcon.Close()

            lbl_ticket.Text = TicketNo
            lblError.Visible = True

            Dim strArrOpen
            strArrOpen = selectTable("mCustomer", "CustomerID,Email", "CustomerID='" & ParamCustomer & "'")

            If countTable("tCloseTicket", "Count(TicketNumber)", "TicketNumber='" & TicketNo & "'") > 0 Then
                Createlog.LogCreateTicket("--START--")
                Createlog.LogCreateTicket("--" & Date.Now & "--")
                Createlog.LogCreateTicket("TicketNumber " & TicketNo & "Sudah Ada di tCloseTicket")
            Else

            End If

            Dim VEmailCreate As String = ""
            sql = "select * from tManejemEmail where ToolEmail='EmailCreate'"
            Try
                sqldr = Proses.ExecuteReader(sql)
                If sqldr.HasRows Then
                    sqldr.Read()
                    VEmailCreate = sqldr("Status").ToString
                End If
                sqldr.Close()
            Catch ex As Exception
                Response.Write(ex.Message)
            End Try


            ' Kondisi Jika Ticket ingin dikirimkan juga by email
            If VEmailCreate = True Then
                '========== Template Email =========
                Dim sDetailCustomer, CustomerID, CustomerName, CustomerTelp, CustomerAlamat, CustomerNoPolisi, CustomerNoRangka, CustomerHP, CustomerKM As String
                Dim CustomerTransmisi, CustomerModel As String
                sDetailCustomer = "Sp_DetailCustomer '" & ParamCustomer & "'"

                Try
                    Com = New SqlCommand(sDetailCustomer, Con)
                    Con.Open()
                    Dr = Com.ExecuteReader()
                    If Dr.Read() Then
                        CustomerID = Dr("CustomerID").ToString
                        CustomerName = Dr("NamePIC").ToString
                        CustomerTelp = Dr("Telepon").ToString
                        CustomerAlamat = Dr("Alamat").ToString
                        EmailCustomer = Dr("Email").ToString
                    End If
                    Dr.Close()
                    Con.Close()
                Catch ex As Exception
                    Response.Write(ex.Message)
                End Try


                Dim VUser, VUserAddress, VNikSupervisor As String
                sql = "select EmailAddress from mEmailSuzuki where TypeLevel='CreateTicket' And NA='Y'"
                Try
                    sqldr = Proses.ExecuteReader(sql)
                    While sqldr.Read()
                        If sqldr.HasRows Then
                            sqldr.Read()
                            VUserAddress &= Dr("EmailAddress").ToString & ","
                        End If
                    End While
                    sqldr.Close()
                Catch ex As Exception
                    Response.Write(ex.Message)
                End Try

                'Dim EmailTujuan As String = RemoveLastCharacter(EmailCustomer)

                Dim SubjectEmail As String = Category.Text & " - " & SubCategoryIII.Text & " - " & TicketNo
                Dim TableTemplate As String
                TableTemplate = "<table width=960 style=background-color:#F5F5F5; font-family: Arial,Helvetica,sans-serif; color: black;>" & _
                        "<tr><td width=200 style=font-weight:bold>Nomor Ticket</td><td>:</td><td>" & TicketNo & "</td></tr>" & _
                        "<tr><td style=font-weight:bold>Customer ID</td><td>:</td><td>" & CustomerID & "</td></tr>" & _
                        "<tr><td style=font-weight:bold>Customer Name</td><td>:</td><td>" & CustomerName & "</td></tr>" & _
                        "<tr><td style=font-weight:bold>Address</td><td>:</td><td>" & CustomerAlamat & "</td></tr>" & _
                        "<tr><td style=font-weight:bold>Phone Number</td><td>:</td><td>" & CustomerTelp & "</td></tr>" & _
                        "<tr><td style=font-weight:bold>Source Type</td><td>:</td><td>" & cmb_source_type.Text & "</td></tr>" & _
                        "<tr><td style=font-weight:bold>Group Type</td><td>:</td><td>" & cmb_group_type.Text & "</td></tr>" & _
                        "<tr><td style=font-weight:bold>Category</td><td>:</td><td>" & Category.Text & "</td></tr>" & _
                        "<tr><td style=font-weight:bold>Call Type 1</td><td>:</td><td>" & SubCategoryI.Text & "</td></tr>" & _
                        "<tr><td style=font-weight:bold>Call Type 2</td><td>:</td><td>" & SubCategoryII.Text & "</td></tr>" & _
                        "<tr><td style=font-weight:bold>Call Type 3</td><td>:</td><td>" & SubCategoryIII.Text & "</td></tr>" & _
                        "<tr><td style=font-weight:bold>Detail Complaint</td><td>:</td><td>" & textchat.Value & "</td></tr>" & _
                        "<tr><td style=font-weight:bold>Response</td><td>:</td><td>" & textchat.Value & "</td></tr>" & _
                        "<tr><td style=font-weight:bold>Ticket Status</td><td>:</td><td>" & cmb_status.Value & "</td></tr>" & _
                        "</table>"

                Dim i_email As String = "Insert Into IVC_EMAIL_IN_TM (DIRECTION,EFROM,ETO,TICKET_NUMBER,ESUBJECT,EBODY, ecc, Email_Date, JENIS_EMAIL) " & _
                            "Values ('out','" & EmailForm & "','" & strArrOpen(1) & "','" & TicketNo & "','" & SubjectEmail & "','" & TableTemplate & "','" & VUserAddress & "',GETDATE(),'CreateTicket')"
                Try
                    Com = New SqlCommand(i_email, sqlCon)
                    sqlCon.Open()
                    Com.ExecuteNonQuery()
                    updateFlagEmail(TicketNo)
                    sqlCon.Close()
                Catch ex As Exception
                    Response.Write(ex.Message)
                End Try
            Else
                ' Create Log jika Ticket tidak dikirimkan By email
                NotEmailSend.LogNotSendEmail("--Send Email Ticket No Aktif--")
                NotEmailSend.LogNotSendEmail("Date Create   :" & Date.Now & "")
                NotEmailSend.LogNotSendEmail("Ticket Number :" & TicketNo & " Berhasil di insert")
                NotEmailSend.LogNotSendEmail("Customer Id   :" & NIK & "")
            End If
            btnsent.Visible = False
            lbl_sla.Text = hd_sla.Value
        End If
    End Sub

    Public Function CreateTicketHoliday(ByVal tanggalCreate As DateTime, ByVal Sla As Integer) As String
        Dim todayOptima As System.DateTime = System.DateTime.Now
        Dim batasanWaktuOptima As System.DateTime = System.DateTime.Now

        todayOptima = tanggalCreate
        Dim DateNowCreateOptima As System.DateTime = System.DateTime.Now
        Dim DateNowCreateTicket As System.DateTime = System.DateTime.Now
        Dim SelectData, SelectData1 As String
        Dim val1 As Integer = 0
        Dim val2 As Integer = 0
        Dim valsuk As Integer = 0
        For i = 1 To Sla
            If Sla = 1 Then
                batasanWaktuOptima = todayOptima.AddDays(0)
            Else
                batasanWaktuOptima = todayOptima.AddDays(i)
            End If
            DateNowCreateOptima = batasanWaktuOptima.ToString("yyyy-MM-dd")

            sql = "select DATEDIFF(day,start_date,end_date) + 1 as totalLibur,NAME, START_DATE,END_DATE from libur where START_DATE='" & batasanWaktuOptima.ToString("yyyy-MM-dd") & "'"
            sqldr = connection.ExecuteReader(sql)
            If sqldr.HasRows Then
                sqldr.Read()
                val1 += sqldr("totalLibur").ToString
            End If
            sqldr.Close()

            'Response.Write(SelectData & "<br>")
            If val1 <> 0 Then
                sql = "SELECT DATENAME(weekday,'" & DateNowCreateOptima & "') as hariTanggal where DATENAME(weekday,'" & DateNowCreateOptima & "')='Friday' "
                sqldr = connection.ExecuteReader(sql)
                Try
                    If sqldr.HasRows Then
                        sqldr.Read()
                        If sqldr("hariTanggal").ToString <> "" Then
                            val2 = 2
                        Else
                            val2 = 0
                        End If
                    End If
                    sqldr.Close()
                Catch ex As Exception
                    Response.Write(ex.Message())
                Finally
                End Try
            Else
                sql = "SELECT DATENAME(weekday,'" & DateNowCreateOptima & "') as hariTanggal where DATENAME(weekday,'" & DateNowCreateOptima & "')='Saturday' or DATENAME(weekday,'" & DateNowCreateOptima & "')='Sunday' "
                sqldr = connection.ExecuteReader(sql)
                Try
                    If sqldr.HasRows Then
                        sqldr.Read()
                        If sqldr("hariTanggal").ToString <> "" Then
                            val2 = 2
                        Else
                            val2 = 0
                        End If
                    End If
                    sqldr.Close()
                Catch ex As Exception
                    Response.Write(ex.Message())
                Finally
                End Try
            End If
        Next
        Dim hasilHariYgDitambahkanOptima As Integer
        Dim hasilHariYgDitambahkanOptimaX As Integer
        Dim val3 As Integer
        hasilHariYgDitambahkanOptima = val1 + val2

        If Sla = 1 Then
            hasilHariYgDitambahkanOptimaX = hasilHariYgDitambahkanOptima
            tanggalCreateSetelahDiCek = batasanWaktuOptima.AddDays(hasilHariYgDitambahkanOptimaX).ToString("dd-MMMM-yyyy 08:00:00")
            Dim x As Integer
            For x = 0 To 5
                DateNowCreateTicket = tanggalCreateSetelahDiCek.AddDays(x)
                sql = "select DATEDIFF(day,start_date,end_date) + 1 as totalLibur,NAME, START_DATE,END_DATE from libur where START_DATE='" & DateNowCreateTicket.ToString("yyyy-MM-dd") & "'"
                sqldr = connection.ExecuteReader(sql)
                If sqldr.HasRows Then
                    sqldr.Read()
                    valsuk += sqldr("totalLibur").ToString
                Else
                    x = 7
                End If
                sqldr.Close()
            Next
            tanggalCreateSetelahDiCek = batasanWaktuOptima.AddDays(hasilHariYgDitambahkanOptimaX + valsuk).ToString("dd-MMMM-yyyy 08:00:00")
        Else
            hasilHariYgDitambahkanOptimaX = hasilHariYgDitambahkanOptima
            tanggalCreateSetelahDiCek = batasanWaktuOptima.AddDays(hasilHariYgDitambahkanOptimaX).ToString("dd-MMMM-yyyy 08:00:00")
        End If
    End Function

    Public Function Holiday(ByVal tanggalCreate As DateTime, ByVal Sla As Integer) As String
        Dim todayOptima As System.DateTime
        Dim batasanWaktuOptima As System.DateTime
        todayOptima = tanggalCreate
        Dim TimeNow As System.DateTime = Date.Now.ToString("HH:mm")

        Dim DateNowCreateOptima As String
        Dim SelectData, SelectData1 As String
        Dim val1 As Integer = 0
        Dim val2 As Integer = 0
        Dim ParSLA As Integer = 24
        Dim ValueSLA As Integer
        If Sla < 24 Then
            ValueSLA = 1
        Else
            ValueSLA = Sla / ParSLA
        End If
        For i = 1 To ValueSLA
            If ValueSLA = 1 Then
                batasanWaktuOptima = todayOptima.AddDays(0)
            Else
                batasanWaktuOptima = todayOptima.AddDays(i)
            End If
            DateNowCreateOptima = batasanWaktuOptima.ToString("yyyy-MM-dd")
        Next
        Dim hasilHariYgDitambahkanOptima As Integer
        Dim hasilHariYgDitambahkanOptimaX As Integer
        hasilHariYgDitambahkanOptima = val1 + val2

        Dim XX As String
        If ValueSLA = 1 Then
            hasilHariYgDitambahkanOptimaX = hasilHariYgDitambahkanOptima
            Dim s_hour As String
            sql = "select DATEDIFF(hour, '" & TimeNow & "', '" & TimeNow.AddHours(Sla).ToString("H:mm:ss") & "') as Hours"
            sqldr = connection.ExecuteReader(sql)
            If sqldr.HasRows Then
                sqldr.Read()
                s_hour = dr("Hours").ToString
            End If
            sqldr.Close()
            If s_hour = Sla Then
                tanggalCloseSetelahDiCek = batasanWaktuOptima.AddDays(hasilHariYgDitambahkanOptimaX).ToString("MMMM-dd-yyyy " & TimeNow.AddHours(Sla).ToString("H:mm:ss") & "")
            ElseIf s_hour < Sla Then
                tanggalCloseSetelahDiCek = batasanWaktuOptima.AddDays(1).ToString("MMMM-dd-yyyy " & TimeNow.AddHours(Sla).ToString("H:mm:ss") & "")
            End If
        Else
            hasilHariYgDitambahkanOptimaX = hasilHariYgDitambahkanOptima
            tanggalCloseSetelahDiCek = batasanWaktuOptima.AddDays(hasilHariYgDitambahkanOptimaX).ToString("MMMM-dd-yyyy H:mm:ss")
        End If
        Exit Function
    End Function

    Public Function updateFlagEmail(ByVal NoTicket As String) As String
        Dim UpdateCekMailKirim As String
        UpdateCekMailKirim = "UPDATE tTicket set KirimEmail='YES' where TicketNumber='" & NoTicket & "'"
        com = New SqlCommand(UpdateCekMailKirim, sqlcon)
        sqlcon.Open()
        com.ExecuteNonQuery()
        sqlcon.Close()
    End Function

    Function Update_Chat(ByVal TicketID As String, ByVal Nik As String, ByVal EmailCus As String)
        Dim strUpdate, strInsert As String
        strUpdate = "UPDATE tChat Set TicketNumber='" & TicketID & "', FlagEnd='Y' Where UserID='" & Request.QueryString("id") & "' And FlagEnd='N'"
        com = New SqlCommand(strUpdate, con)
        Try
            con.Open()
            com.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
        strInsert = "INSERT INTO tChat (UserID, TicketNumber, CustomerID, Nama, FlagTo, Pesan, DateCreate, StatusChat, RoomID, Email, FlagEnd, BlinkChat)" & _
                    "VALUES ('" & Request.QueryString("id") & "','" & TicketID & "','" & Nik & "','" & Session("UserName") & "','Agent','Ticket Anda : " & TicketID & "',getdate(),'OpenChat','01','" & EmailCus & "','Y','Read')"
        com = New SqlCommand(strInsert, con)
        Try
            con.Open()
            com.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Function

    Private Sub history()
        Dim View As String = ""
        Dim CustomerID As String = ""
        sql = "select * from mCustomer Where ID='" & Request.QueryString("id") & "'"
        sqldr = Proses.ExecuteReader(sql)
        If sqldr.Read Then
            CustomerID = sqldr("CustomerID").ToString
        End If
        sqldr.Close()
        sql = "Select top 5 ID, TicketNumber, DateCreate from tTicket Where NIK='" & CustomerID & "'"
        sqlcom = New SqlCommand(sql, sqlcon)
        sqlcon.Open()
        sqldr = sqlcom.ExecuteReader()
        View &= "<tr>"
        While sqldr.Read
            View &= "<td> " & sqldr("TicketNumber") & " </td><td> " & sqldr("DateCreate") & " </td>"
        End While
            sqldr.Close()
        sqlcon.Close()
        View &= "</tr>"
        ltr_history_ticket.Text = View
    End Sub
End Class