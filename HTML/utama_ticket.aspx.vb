Imports Microsoft.VisualBasic
Imports System
Imports System.Threading
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Data
Imports System.Data.SqlClient
Imports DevExpress.Web.Data
Imports DevExpress.Web.ASPxCallbackPanel
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxEditors.ASPxComboBox
Imports DevExpress.Web.ASPxGridView
Imports System.Xml
Imports System.Web.Configuration
Imports System.Net.Mail
Imports System.Linq
Imports System.IO
Imports ICC.ClsConn
Imports DevExpress.Web.ASPxGridLookup


Public Class utama_ticket
    Inherits System.Web.UI.Page

    Dim conn As SqlConnection
    Dim connectionString As String = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
    Dim sqlcon As New SqlConnection(ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString)
    Dim Sqlcon_Sosmed As New SqlConnection(ConfigurationManager.ConnectionStrings("SosmedConnection").ConnectionString)
    Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString)
    Dim sqlcom, com, comm, comInsert, comUpdate As SqlCommand
    Dim sqldr, sqldra, dr, reader As SqlDataReader
    Dim strSql, strSqlString As String
    Dim tampungan As String = ""
    Dim connection As New ClsConn
    Dim ParamCustomer As String
    Dim sql, statusTicket As String
    Dim tanggalCreateSetelahDiCek As System.DateTime
    Dim tanggalCloseSetelahDiCek As System.DateTime
    Dim JamCreateTicket As String = Date.Now.ToString("HH:mm")
    Dim JamBatasanTicket As String = "17:00"
    Dim JamSekarang As String = DateTime.Now.ToString("HH:mm:ss")
    Dim VYear, VMonth, VDay, VHours, VMinnute, VDetik As String
    Dim ValueDateCloseTicket As String
    Dim TicketNo As String
    Dim Createlog As New ClsConn
    Dim NotEmailSend As New ClsConn
    Dim Proses As New ClsConn
    Dim Sosmed As New ClsSos
    Dim EmailCustomer As String = ""
    Dim EmailForm As String = ConfigurationManager.AppSettings("EmailFrom")
    Dim GetWaktu As String = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt ")
    Dim DateNow As String = Date.Now.ToString("yyyy-MM-dd H:mm:ss tt")
    Dim log As New ClsConn
    Dim strInsert, strUpdate, strDelete, Posisi As String
    Dim value As String
    Dim DapatHasilCekInteraction As String = ""
    Dim Waktu As String = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt ")
    Dim AppTicket, AppTwitter, AppFacebook, AppAll As String
    Dim str As String

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        sql_customer.SelectCommand = "select * from mcustomer"
        Btn_Assign.Visible = False
        sql_Source_Master()
        html_solution.Settings.AllowHtmlView = False
        If Request.QueryString("new") = "1" Then
            function_SCustomer_Voice(Request.QueryString("id"))
            sql_Source_Master()
            Btn_Simpan.Visible = True
            Btn_Assign.Visible = False
            lbl_red.Visible = False
        Else
            ''Setting Applikasi
            sql = "Select * from mApplikasi"
            sqldr = Proses.ExecuteReader(sql)
            If sqldr.HasRows Then
                sqldr.Read()
                AppTicket = sqldr("Ticket").ToString
                AppTwitter = sqldr("Twitter").ToString
                AppFacebook = sqldr("Facebook").ToString
            End If
            sqldr.Close()
            If AppTicket = "TRUE" Then
                div_ticket.Visible = True
            Else
                div_ticket.Visible = False
            End If
        End If
        div_properties.Visible = True
        modal_dispatch_satu.Visible = False
        Btn_Update.Visible = False
        modal_dispatch_dua.Visible = False
        history_ticket()

        cmb_status.Value = "Open"
        If Session("LoginType") = "layer3" Then
            Btn_Simpan.Visible = False
            cmb_status.Enabled = False
        ElseIf Session("LoginType") = "layer2" Then
            Btn_Simpan.Visible = False
            cmb_status.Enabled = False
        ElseIf Session("LoginType") = "Admin" Then
            Btn_Simpan.Visible = False
        ElseIf Session("LoginType") = "Supervisor" Then
            Btn_Simpan.Visible = False
        Else
        End If
        Response.Cache.SetNoStore()
        HD_Posisi.Value = Request.QueryString("layer")

        Dim DateNow As String
        DateNow = Date.Now.ToString("yyyy-MM-dd H:mm:ss tt")

        Dim SelectEmail, AlamatEmail As String
        SelectEmail = "Select * from mEmailAddress where Status = 'Y'"
        com = New SqlCommand(SelectEmail, con)
        con.Open()
        dr = com.ExecuteReader()
        dr.Read()
        AlamatEmail = dr("EmailAddress").ToString
        dr.Close()
        con.Close()

        'panelTes.Visible = True
        If Request.QueryString("tid") <> "" And Request.QueryString("layer") = "layer1" Then
            layer1()
            interaction()
        ElseIf Request.QueryString("tid") <> "" And Request.QueryString("layer") = "layer2" Then
            layer2()
            sql_user_dispatch_source()
            interaction()
        ElseIf Request.QueryString("tid") <> "" And Request.QueryString("layer") = "layer3" Then
            layer3()
            interaction()
        ElseIf Request.QueryString("tid") <> "" And Request.QueryString("layer") = "Admin" Then
            admin()
            interaction()
        ElseIf Request.QueryString("tid") <> "" Then
            kosong()
            interaction()
        Else

        End If
        modal_dispatch_satu.Visible = False
    End Sub

    Sub sql_Source_Master()
        sql_source_type.SelectCommand = "select * from mSourceType where NA='Y' order by name asc"
        sql_group_type.SelectCommand = "select * from mGroupType where NA='Y'"
        SourceCategori.SelectCommand = "select * from mCategory where NA='Y'"
        sql_priority.SelectCommand = "select * from mpriority"
        sql_severity.SelectCommand = "select * from mseverity"
        sql_status.SelectCommand = "select * from mstatus"
    End Sub

    Function function_SCustomer_Voice(ByVal id As String)
        sql = "select * from mcustomer where CustomerID='" & id & "'"
        sqldr = connection.ExecuteReader(sql)
        Try
            If sqldr.HasRows() Then
                sqldr.Read()
            Else
            End If
            sqldr.Close()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
        cmb_source_type.Value = Request.QueryString("channel")
        sql = "select * from mcustomer where customerid='" & id & "'"
        sqldr = Proses.ExecuteReader(sql)
        If sqldr.HasRows Then
            sqldr.Read()
            txt_customer_name.Text = sqldr("NamaPerusahaan").ToString
            txt_customer_name.Enabled = False
        End If
        hprlink.Visible = True
        hprlink.NavigateUrl = "todolist.aspx"
        lbl_link.Text = "Todolist"
    End Function

    Private Sub callbackPanelX_Callback(sender As Object, e As DevExpress.Web.ASPxClasses.CallbackEventArgsBase) Handles callbackPanelX.Callback
        div_properties.Visible = True
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
                com = New SqlCommand(ExCat, sqlcon)
                sqlcon.Open()
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
                sqlcon.Close()
                Category.Value = Categori
                SubCategoryI.Value = SubCategory1
                SubCatI.Value = Sub1
                SubCatII.Value = Sub2
                CategoryHidden.Value = Cat1
                SubCategoryII.Value = SubCategory2
                hd_sla.Value = ValueSLA.ToString
                lbl_sla.Text = hd_sla.Value
                IDKamus.Value = erroCode.ToString
                Btn_Update.Visible = False
                btn_dispatch.Visible = False
            ElseIf Category.Text <> "" Then
                Dim ExCat, Categori As String
                ExCat = "Select  * from mcategory where CategoryID ='" & mCatID.Value & "' and NA = 'Y'"
                com = New SqlCommand(ExCat, con)
                con.Open()
                dr = com.ExecuteReader()
                dr.Read()
                Categori = dr("CategoryID")
                dr.Close()
                con.Close()
                '  SourceCategoriI.SelectCommand = "Select  * from mSubCategoryLv1 where CategoryID ='" & Categori & "'"
                SourceCategoriIII.SelectCommand = "Select  * from mSubCategoryLv3 where CategoryID ='" & Categori & "' and NA = 'Y'"
            End If
        End If
    End Sub

    Private Sub Btn_Simpan_Click(sender As Object, e As EventArgs) Handles Btn_Simpan.ServerClick
        RequiredFieldValidator1.Visible = True
        Btn_Simpan.Visible = False
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
            If ASPxUploadControl1.HasFile Then
                Try
                    Dim allowdFile As String() = {".jpg", ".xls", ".pdf", ".doc", ".docx", ".xlsx", ".flv", ".mkv", ".avi", ".mp4", ".mp3", ".png", ".951"}
                    'Here we are allowing only pdf file so verifying selected file pdf or not
                    Dim FileExt As String = System.IO.Path.GetExtension(ASPxUploadControl1.PostedFile.FileName)
                    Dim isValidFile As Boolean = allowdFile.Contains(FileExt)
                    If Not isValidFile Then
                        'ASPxLabel2.ForeColor = System.Drawing.Color.Red
                        'ASPxLabel2.Text = "Please upload only jpg "
                    Else
                        ' Get size of uploaded file, here restricting size of file
                        Dim FileSize As Integer = ASPxUploadControl1.PostedFile.ContentLength
                        If FileSize <= 1073741824 Then
                            '1048576 byte = 1MB
                            'Get file name of selected file
                            filename = Path.GetFileName(String.Format("{0}_{1}", Time, ASPxUploadControl1.FileName))
                            'Save selected file into specified location
                            ASPxUploadControl1.SaveAs(Server.MapPath(FilePath) & filename)
                            'ASPxLabel2.Text = "File upload successfully!"
                            blSucces = True
                        Else
                            'ASPxLabel2.Text = "Attachment file size should not be greater then 1 G!"
                        End If
                    End If
                Catch ex As Exception
                    'ASPxLabel2.Text = "Error occurred while uploading a file: " + ex.Message
                End Try
            Else
                'ASPxLabel2.Text = "Please select a file to upload."
            End If

            Dim count As Integer
            conn = New SqlConnection(connectionString)
            comm = New SqlCommand()
            comm.Connection = conn
            comm.CommandType = CommandType.StoredProcedure
            comm.CommandText = "GENERATE_TICKET"
            If hd_nik.Value <> "" Then
                comm.Parameters.Add("@nik", Data.SqlDbType.VarChar).Value = gl_cari.Text
                ParamCustomer = gl_cari.Text
            Else
                comm.Parameters.Add("@nik", Data.SqlDbType.VarChar).Value = gl_cari.Text
                ParamCustomer = gl_cari.Text
            End If
            comm.Parameters.Add("@idkamus", Data.SqlDbType.VarChar).Value = IDKamus.Value
            comm.Parameters.Add("@ticketSource", Data.SqlDbType.VarChar).Value = cmb_source_type.Value
            comm.Parameters.Add("@sourcetypeName", Data.SqlDbType.VarChar).Value = cmb_source_type.Text
            comm.Parameters.Add("@complaintLevel", Data.SqlDbType.VarChar).Value = cmb_priority.Value
            comm.Parameters.Add("@grouptype", Data.SqlDbType.VarChar).Value = cmb_group_type.Value
            comm.Parameters.Add("@grouptypeName", Data.SqlDbType.VarChar).Value = cmb_group_type.Text
            comm.Parameters.Add("@categoryID", Data.SqlDbType.VarChar).Value = CategoryHidden.Value
            comm.Parameters.Add("@categoryName", Data.SqlDbType.VarChar).Value = Category.Text
            comm.Parameters.Add("@subCategory1ID", Data.SqlDbType.VarChar).Value = SubCatI.Value
            comm.Parameters.Add("@SubCategory1Name", Data.SqlDbType.VarChar).Value = SubCategoryI.Text
            comm.Parameters.Add("@subCategory2ID", Data.SqlDbType.VarChar).Value = SubCatII.Value
            comm.Parameters.Add("@SubCategory2Name", Data.SqlDbType.VarChar).Value = SubCategoryII.Text
            comm.Parameters.Add("@subCategory3ID", Data.SqlDbType.VarChar).Value = SubCategoryIII.Value
            comm.Parameters.Add("@SubCategory3Name", Data.SqlDbType.VarChar).Value = SubCategoryIII.Text
            comm.Parameters.Add("@detailComplaint", Data.SqlDbType.VarChar).Value = ReplaceSpecialLetter(txt_message.Text)
            comm.Parameters.Add("@responseComplaint", Data.SqlDbType.VarChar).Value = ReplaceSpecialLetter(html_solution.Html)
            comm.Parameters.Add("@dateAgentResponse", Data.SqlDbType.DateTime).Value = Waktu
            comm.Parameters.Add("@sla", Data.SqlDbType.VarChar).Value = hd_sla.Value
            comm.Parameters.Add("@status", Data.SqlDbType.VarChar).Value = cmb_status.Value
            comm.Parameters.Add("@severity", Data.SqlDbType.VarChar).Value = cmb_severity.Value
            comm.Parameters.Add("@userCreate", Data.SqlDbType.VarChar).Value = Session("UserName")
            comm.Parameters.Add("@userClose", Data.SqlDbType.VarChar).Value = Session("UserName")
            comm.Parameters.Add("@closedBy", Data.SqlDbType.VarChar).Value = "1"
            comm.Parameters.Add("@kirimEmail", Data.SqlDbType.VarChar).Value = "YES"
            comm.Parameters.Add("@count", Data.SqlDbType.Int).Value = count
            comm.Parameters.Add("@agentCreate", Data.SqlDbType.VarChar).Value = Session("UserName")
            comm.Parameters.Add("@dateCloseActual", Data.SqlDbType.VarChar).Value = ValueDateCloseTicket
            comm.Parameters.Add("@atasjamkerja", Data.SqlDbType.DateTime).Value = DateNow
            comm.Parameters.Add("@attch", Data.SqlDbType.VarChar).Value = FileFullPath & filename
            Try
                conn.Open()
                reader = comm.ExecuteReader()
                reader.Read()
                TicketNo = reader(0)
                reader.Close()
                conn.Close()
            Catch ex As Exception
                Response.Write(ex.Message)
            End Try


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
                com = New SqlCommand(SEmailCreate, con)
                con.Open()
                dr = com.ExecuteReader()
                If dr.HasRows Then
                    dr.Read()
                    VEmailCreate = dr("Status").ToString
                End If
                dr.Close()
                con.Close()
            Catch ex As Exception
                Response.Write(ex.Message)
            End Try


            If VEmailCreate = True Then
                '========== Template Email =========
                Dim sDetailCustomer, CustomerID, CustomerName, CustomerTelp, CustomerAlamat, CustomerHP As String
                sDetailCustomer = "Sp_DetailCustomer '" & ParamCustomer & "'"
                Try
                    com = New SqlCommand(sDetailCustomer, con)
                    con.Open()
                    dr = com.ExecuteReader()
                    If dr.Read() Then
                        CustomerID = dr("CustomerID").ToString
                        CustomerName = dr("NamePIC").ToString
                        CustomerTelp = dr("Telepon").ToString
                        CustomerAlamat = dr("Alamat").ToString
                        EmailCustomer = dr("Email").ToString
                    End If
                    dr.Close()
                    con.Close()
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
                            VUserAddress &= dr("EmailAddress").ToString & ","
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
                            "<tr><td style=font-weight:bold>Detail Complaint</td><td>:</td><td>" & txt_message.Text & "</td></tr>" & _
                            "<tr><td style=font-weight:bold>Response</td><td>:</td><td>" & html_solution.Html & "</td></tr>" & _
                            "<tr><td style=font-weight:bold>Ticket Status</td><td>:</td><td>" & cmb_status.Value & "</td></tr>" & _
                            "</table>"

                sql = "Insert Into IVC_EMAIL_IN_TM (DIRECTION,EFROM,ETO,TICKET_NUMBER,ESUBJECT,EBODY,ecc, Email_Date, JENIS_EMAIL) " & _
                           "Values ('out','" & EmailForm & "','" & strArrClosed(1) & "','" & TicketNo & "','" & SubjectEmail & "','" & TableTemplate & "','" & VUserAddress & "',GETDATE(),'CreateTicket')"
                Try
                    com = New SqlCommand(sql, sqlcon)
                    sqlcon.Open()
                    com.ExecuteNonQuery()
                    updateFlagEmail(TicketNo)
                    sqlcon.Close()
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
            Btn_Simpan.Visible = False
            modal_dispatch_satu.Visible = True
            lbl_message.Text = txt_message.Text
            txt_message.Visible = False
            lbl_sla.Text = hd_sla.Value
        Else

            Dim Time As String = DateTime.Now.ToString("yyyyMMddhhmmss")
            Dim FilePath As String = ConfigurationManager.AppSettings("FilePath").ToString()
            Dim FileFullPath As String = ConfigurationManager.AppSettings("FileFullPath").ToString()
            Dim blSucces As Boolean = False
            Dim filename As String = String.Empty
            'To check whether file is selected or not to uplaod
            If ASPxUploadControl1.HasFile Then
                Try
                    Dim allowdFile As String() = {".jpg", ".xls", ".pdf", ".doc", ".docx", ".xlsx", ".flv", ".mkv", ".avi", ".mp4", ".mp3", ".png", ".951"}
                    'Here we are allowing only pdf file so verifying selected file pdf or not
                    Dim FileExt As String = System.IO.Path.GetExtension(ASPxUploadControl1.PostedFile.FileName)
                    Dim isValidFile As Boolean = allowdFile.Contains(FileExt)
                    If Not isValidFile Then
                        'ASPxLabel2.ForeColor = System.Drawing.Color.Red
                        'ASPxLabel2.Text = "Please upload only jpg "
                    Else
                        ' Get size of uploaded file, here restricting size of file
                        Dim FileSize As Integer = ASPxUploadControl1.PostedFile.ContentLength
                        If FileSize <= 1073741824 Then
                            '1048576 byte = 1MB
                            'Get file name of selected file
                            filename = Path.GetFileName(String.Format("{0}_{1}", Time, ASPxUploadControl1.FileName))
                            'Save selected file into specified location
                            ASPxUploadControl1.SaveAs(Server.MapPath(FilePath) & filename)
                            'ASPxLabel2.Text = "File upload successfully!"
                            blSucces = True
                        Else
                            'ASPxLabel2.Text = "Attachment file size should not be greater then 1 G!"
                        End If
                    End If
                Catch ex As Exception
                    Response.Write(ex.Message)
                End Try
            Else
                'ASPxLabel2.Text = "Please select a file to upload."
            End If


            Dim count As Integer
            conn = New SqlConnection(connectionString)
            comm = New SqlCommand()
            comm.Connection = conn
            comm.CommandType = CommandType.StoredProcedure
            comm.CommandText = "GENERATE_TICKET"
            If hd_nik.Value <> "" Then
                comm.Parameters.Add("@nik", Data.SqlDbType.VarChar).Value = gl_cari.Text
                ParamCustomer = gl_cari.Text
            Else
                comm.Parameters.Add("@nik", Data.SqlDbType.VarChar).Value = gl_cari.Text
                ParamCustomer = gl_cari.Text
            End If
            comm.Parameters.Add("@idkamus", Data.SqlDbType.VarChar).Value = IDKamus.Value
            comm.Parameters.Add("@ticketSource", Data.SqlDbType.VarChar).Value = cmb_source_type.Value
            comm.Parameters.Add("@sourcetypeName", Data.SqlDbType.VarChar).Value = cmb_source_type.Text
            comm.Parameters.Add("@complaintLevel", Data.SqlDbType.VarChar).Value = cmb_priority.Value
            comm.Parameters.Add("@grouptype", Data.SqlDbType.VarChar).Value = cmb_group_type.Value
            comm.Parameters.Add("@grouptypeName", Data.SqlDbType.VarChar).Value = cmb_group_type.Text
            comm.Parameters.Add("@categoryID", Data.SqlDbType.VarChar).Value = CategoryHidden.Value
            comm.Parameters.Add("@categoryName", Data.SqlDbType.VarChar).Value = Category.Text
            comm.Parameters.Add("@subCategory1ID", Data.SqlDbType.VarChar).Value = SubCatI.Value
            comm.Parameters.Add("@SubCategory1Name", Data.SqlDbType.VarChar).Value = SubCategoryI.Text
            comm.Parameters.Add("@subCategory2ID", Data.SqlDbType.VarChar).Value = SubCatII.Value
            comm.Parameters.Add("@SubCategory2Name", Data.SqlDbType.VarChar).Value = SubCategoryII.Text
            comm.Parameters.Add("@subCategory3ID", Data.SqlDbType.VarChar).Value = SubCategoryIII.Value
            comm.Parameters.Add("@SubCategory3Name", Data.SqlDbType.VarChar).Value = SubCategoryIII.Text
            comm.Parameters.Add("@detailComplaint", Data.SqlDbType.VarChar).Value = ReplaceSpecialLetter(txt_message.Text)
            comm.Parameters.Add("@responseComplaint", Data.SqlDbType.VarChar).Value = ReplaceSpecialLetter(html_solution.Html)
            comm.Parameters.Add("@dateAgentResponse", Data.SqlDbType.DateTime).Value = Waktu
            comm.Parameters.Add("@sla", Data.SqlDbType.VarChar).Value = hd_sla.Value
            comm.Parameters.Add("@status", Data.SqlDbType.VarChar).Value = cmb_status.Value
            comm.Parameters.Add("@severity", Data.SqlDbType.VarChar).Value = cmb_severity.Value
            comm.Parameters.Add("@userCreate", Data.SqlDbType.VarChar).Value = Session("UserName")
            comm.Parameters.Add("@userClose", Data.SqlDbType.VarChar).Value = Session("UserName")
            comm.Parameters.Add("@closedBy", Data.SqlDbType.VarChar).Value = "1"
            comm.Parameters.Add("@kirimEmail", Data.SqlDbType.VarChar).Value = "YES"
            comm.Parameters.Add("@count", Data.SqlDbType.Int).Value = count
            comm.Parameters.Add("@agentCreate", Data.SqlDbType.VarChar).Value = Session("UserName")
            comm.Parameters.Add("@dateCloseActual", Data.SqlDbType.VarChar).Value = ValueDateCloseTicket
            comm.Parameters.Add("@atasjamkerja", Data.SqlDbType.DateTime).Value = DateNow
            comm.Parameters.Add("@attch", Data.SqlDbType.VarChar).Value = FileFullPath & filename
            Try
                conn.Open()
                reader = comm.ExecuteReader()
                reader.Read()
                TicketNo = reader(0)
                reader.Close()
                conn.Close()
            Catch ex As Exception
                Response.Write(ex.Message)
            End Try


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
                    com = New SqlCommand(sDetailCustomer, con)
                    con.Open()
                    dr = com.ExecuteReader()
                    If dr.Read() Then
                        CustomerID = dr("CustomerID").ToString
                        CustomerName = dr("NamePIC").ToString
                        CustomerTelp = dr("Telepon").ToString
                        CustomerAlamat = dr("Alamat").ToString
                        EmailCustomer = dr("Email").ToString
                    End If
                    dr.Close()
                    con.Close()
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
                            VUserAddress &= dr("EmailAddress").ToString & ","
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
                        "<tr><td style=font-weight:bold>Detail Complaint</td><td>:</td><td>" & txt_message.Text & "</td></tr>" & _
                        "<tr><td style=font-weight:bold>Response</td><td>:</td><td>" & html_solution.Html & "</td></tr>" & _
                        "<tr><td style=font-weight:bold>Ticket Status</td><td>:</td><td>" & cmb_status.Value & "</td></tr>" & _
                        "</table>"

                Dim i_email As String = "Insert Into IVC_EMAIL_IN_TM (DIRECTION,EFROM,ETO,TICKET_NUMBER,ESUBJECT,EBODY, ecc, Email_Date, JENIS_EMAIL) " & _
                            "Values ('out','" & EmailForm & "','" & strArrOpen(1) & "','" & TicketNo & "','" & SubjectEmail & "','" & TableTemplate & "','" & VUserAddress & "',GETDATE(),'CreateTicket')"
                Try
                    com = New SqlCommand(i_email, sqlcon)
                    sqlcon.Open()
                    com.ExecuteNonQuery()
                    updateFlagEmail(TicketNo)
                    sqlcon.Close()
                Catch ex As Exception
                    Response.Write(ex.Message)
                End Try
            Else
                ' Create Log jika Ticket tidak dikirimkan By email
                NotEmailSend.LogNotSendEmail("--Send Email Ticket No Aktif--")
                NotEmailSend.LogNotSendEmail("Date Create   :" & Date.Now & "")
                NotEmailSend.LogNotSendEmail("Ticket Number :" & TicketNo & " Berhasil di insert")
                NotEmailSend.LogNotSendEmail("Customer Id   :" & hd_nik.Value & "")
            End If
            Btn_Simpan.Visible = False
            modal_dispatch_satu.Visible = True
            lbl_message.Text = txt_message.Text
            txt_message.Visible = False
            lbl_sla.Text = hd_sla.Value
            lbl_ticket_number.Text = TicketNo
        End If
        sql_user_dispatch_source()
        lbl_red.Visible = True
    End Sub

    '=============== FUNCTION =================

    Public Function cekLiburOptima(ByVal tanggalCreate As DateTime, ByVal Sla As Integer) As String
        Dim todayOptima As System.DateTime
        Dim batasanWaktuOptima As System.DateTime
        todayOptima = tanggalCreate
        Dim DateNowCreateOptima As String
        Dim val1 As Integer = 0
        Dim val2 As Integer = 0
        For i = 1 To Sla
            batasanWaktuOptima = todayOptima.AddDays(i)
            DateNowCreateOptima = batasanWaktuOptima.ToString("dd-MMM-yy")

            sql = "select DATEDIFF(day,start_date,end_date) + 1 as totalLibur,NAME, START_DATE,END_DATE from libur where START_DATE='" & DateNowCreateOptima & "'"
            sqldr = connection.ExecuteReader(sql)
            If sqldr.HasRows() Then
                sqldr.Read()
                val1 = sqldr("totalLibur").ToString
            End If
            sqldr.Close()

            sql = "SELECT DATENAME(weekday,'" & DateNowCreateOptima & "') as hariTanggal where DATENAME(weekday,'" & DateNowCreateOptima & "')='Saturday'"
            sqldr = connection.ExecuteReader(sql)
            If sqldr.HasRows() Then
                sqldr.Read()
                If sqldr("hariTanggal").ToString = "Saturday" Then
                    val2 = 2
                Else
                    val2 = 0
                End If
            End If
            sqldr.Close()

        Next
        Dim hasilHariYgDitambahkanOptima As Integer
        Dim hasilHariYgDitambahkanOptimaX As Integer
        hasilHariYgDitambahkanOptima = val1 + val2

        sql = "SELECT DATENAME(weekday,'" & batasanWaktuOptima.AddDays(hasilHariYgDitambahkanOptima).ToString("dd-MMM-yy") & "') as hariTanggal where DATENAME(weekday,'" & batasanWaktuOptima.AddDays(hasilHariYgDitambahkanOptima).ToString("dd-MMM-yy") & "')='Saturday' or DATENAME(weekday,'" & batasanWaktuOptima.AddDays(hasilHariYgDitambahkanOptima).ToString("dd-MMM-yy") & "')='Sunday'"
        sqldr = connection.ExecuteReader(sql)
        Dim val3 As Integer
        If sqldr.HasRows() Then
            sqldr.Read()
            If sqldr("hariTanggal").ToString = "Saturday" Or sqldr("hariTanggal").ToString = "Sunday" Then
                val3 = 2
            Else
                val3 = 0
            End If
        End If
        sqldr.Close()

        If Sla = 1 Then
            hasilHariYgDitambahkanOptimaX = hasilHariYgDitambahkanOptima + val3 - 1
            tanggalCloseSetelahDiCek = batasanWaktuOptima.AddDays(hasilHariYgDitambahkanOptimaX).ToString("dd-MMMM-yyyy 17:00:00")
        Else
            hasilHariYgDitambahkanOptimaX = hasilHariYgDitambahkanOptima + val3 - 1
            tanggalCloseSetelahDiCek = batasanWaktuOptima.AddDays(hasilHariYgDitambahkanOptimaX).ToString("dd-MMMM-yyyy H:mm:ss")
        End If
    End Function

    Public Function ReplaceSpecialLetter(ByVal str)
        Dim TmpStr As String
        TmpStr = str
        TmpStr = Replace(TmpStr, "'", " ")
        TmpStr = Replace(TmpStr, """", " ")
        TmpStr = Replace(TmpStr, """""", " ")
        TmpStr = Replace(TmpStr, """""""""", " ")
        TmpStr = Replace(TmpStr, """""""""""""""""", " ")
        TmpStr = Replace(TmpStr, "/", " ")
        TmpStr = Replace(TmpStr, "\", " ")
        TmpStr = Replace(TmpStr, "!", " ")
        ' TmpStr = Replace(TmpStr, "&", " ")
        TmpStr = Replace(TmpStr, ":", " ")
        TmpStr = Replace(TmpStr, ";", " ")
        TmpStr = Replace(TmpStr, ".", " ")
        TmpStr = Replace(TmpStr, ">", " ")
        TmpStr = Replace(TmpStr, "<", " ")
        TmpStr = Replace(TmpStr, "*", " ")
        ReplaceSpecialLetter = TmpStr
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

    Public Function updateFlagEmail(ByVal NoTicket As String) As String
        Dim UpdateCekMailKirim As String
        UpdateCekMailKirim = "UPDATE tTicket set KirimEmail='YES' where TicketNumber='" & NoTicket & "'"
        com = New SqlCommand(UpdateCekMailKirim, sqlcon)
        sqlcon.Open()
        com.ExecuteNonQuery()
        sqlcon.Close()
    End Function

    Sub sql_user_dispatch_source()
        sql = "select * from tticket where TicketNumber='" & lbl_ticket_number.Text & "'"
        sqldr = Proses.ExecuteReader(sql)
        If sqldr.HasRows Then
            sqldr.Read()
            HD_Posisi.Value = sqldr("TicketPosition").ToString
        End If
        sqldr.Close()
        sql_cmb_Personal_Support.SelectCommand = "select distinct msUser.NIK, mKaryawan.Name from msUser inner join mKaryawan on msUser.NIK = mKaryawan.NIK where msUser.LevelUser = 'Caseunit'"
        sql_cmb_unit_support.SelectCommand = "select distinct msUser.UnitKerja from msUser"
    End Sub

    Sub DataKaryawan()
        Dim NamaPIC As String = ""
        Dim NamaPerusahaan As String = ""
        Dim IDCustomer As String = ""
        Dim TanggalLahir As String = Date.Now.ToString("dd - MMMM - yyyy")
        Dim NomorHP As String = ""
        Dim Perusahaan As String = ""
        Dim Tlp As String = ""
        Dim Gender As String = ""
        Dim EmailPerusahaan As String = ""
        Dim Address As String = ""
        Dim Region As String = ""
        Dim BirthDay As String = Date.Now.ToString("yyyy-MM-dd").ToString
        Dim VCity As String = ""
        Dim fcb As String = ""
        Dim Twitt As String = ""
        Dim kask As String = ""
        Dim Oth As String = ""
        Dim VNoRangka, VEngineNumber, IDTable, VModelType, VariantType, VColor, VProductionDate, VTransmission, VRegistrasionDate, VOdometer, VNoPolisi, VDealerPurchase, VFreeNamaDealer, VFreeNamaSA,
        VFreeJenisPekerjaan, VPeriodNamaDealer, VPeriodNamaSA, VPeriodJenisPekerjaan As String
        Dim SelKaryawan As String = "select  * from mCustomer where (CustomerID ='" & lbl_customer.Text & "' or Telepon ='" & lbl_customer.Text & "' or Email ='" & lbl_customer.Text & "' or NomorHpPIC ='" & lbl_customer.Text & "' or NamePIC='" & lbl_customer.Text & "' )"
        com = New SqlCommand(SelKaryawan, con)
        Try
            con.Open()
            dr = com.ExecuteReader()
            If dr.Read() Then
                IDTable = dr("ID").ToString
                lbl_customer.Text = dr("CustomerID").ToString
                lbl_pic_customer.Text = dr("NamePIC").ToString
                NomorHP = dr("NomorHpPIC").ToString
                'BtnSave.Visible = True
                If Session("LoginType") = "layer3" Then
                    Btn_Simpan.Visible = False
                ElseIf Session("LoginType") = "layer2" Then
                    Btn_Simpan.Visible = False
                ElseIf Session("LoginType") = "Admin" Then
                    Btn_Simpan.Visible = False
                    Btn_Update.Visible = False
                    modal_dispatch_satu.Visible = False
                ElseIf Session("LoginType") = "Supervisor" Then
                    Btn_Simpan.Visible = False
                    Btn_Update.Visible = False
                    modal_dispatch_satu.Visible = False
                End If

                If Session("LoginType") = "layer1" And Request.QueryString("tid") = "" Then
                    Btn_Simpan.Visible = True
                Else
                    Btn_Simpan.Visible = False
                End If
            Else
                Btn_Simpan.Visible = False
            End If
        Catch ex As Exception
            Response.Write("Data Not Complete : " & ex.Message())
        Finally
            'Menimbulkan Bug error, karena kurang script dibawah ini
            ' jadi dia menganggap con belum closed (Masih gantung koneksinya)
            dr.Close()
        End Try
        con.Close()
    End Sub

    Sub layer1()
        Dim TicketIDNumber As String = Request.QueryString("tid")
        Dim NIKToDoList As String = Request.QueryString("NIK")
        Dim PertanyaanToDolist As String = Request.QueryString("Pertanyaan")
        Dim DateToDolist As String = Request.QueryString("DateCreate")
        DSCustHistory.SelectCommand = "select top 5 * from tTicket where NIK='" & NIKToDoList & "' order by id desc"
        html_solution.Visible = True
        Dim SearchKary, NIK, Ticket, Cat, DealerIDName, ClosedOleh, DealerName, SubCategory1ID, SubCategory2ID, SubCategory3ID, SLA, Detail, Response1, RbTicketing,
        Priority, Severity, Status, SourceType, GroupType, DateCreate, DateClose, UserCreate, TicketNumber, responAllAgent, JenisTransaksi, UnitKerja, Subject, KategoriName As String
        sql = "SELECT dbo.tTicket.*, dbo.mSubCategoryLv1.*,dbo.mCategory.Name AS CatName,dbo.mSubCategoryLv1.SubName AS SubName1, dbo.mSubCategoryLv2.SubName AS SubName2, dbo.mSubCategoryLv3.SubName AS SubName3, mCustomer.NamaPerusahaan, " & _
        " mCustomer.Alamat, mCustomer.Email, mCustomer.Telepon, mCustomer.NamePIC, " & _
        " dbo.mCategory.*, dbo.mSubCategoryLv2.*,dbo.mSubCategoryLv3.* FROM dbo.mCategory INNER JOIN dbo.mSubCategoryLv1 ON dbo.mCategory.CategoryID = dbo.mSubCategoryLv1.CategoryID INNER JOIN " & _
        " dbo.mSubCategoryLv2 ON dbo.mSubCategoryLv1.SubCategory1ID = dbo.mSubCategoryLv2.SubCategory1ID INNER JOIN dbo.mSubCategoryLv3 ON dbo.mSubCategoryLv2.SubCategory2ID = dbo.mSubCategoryLv3.SubCategory2ID INNER JOIN" & _
        " dbo.tTicket ON dbo.mSubCategoryLv3.SubCategory3ID = dbo.tTicket.SubCategory3ID inner join mcustomer on tTicket.NIK = mCustomer.CustomerID where dbo.tTicket.TicketNumber ='" & Request.QueryString("tid") & "' or dbo.tTicket.NIK ='" & Request.QueryString("tid") & "'"
        Try
            dr = Proses.ExecuteReader(sql)
            If dr.HasRows Then
                dr.Read()
                NIK = dr("NIK").ToString
                gl_cari.Text = dr("NamaPerusahaan").ToString
                lbl_customer.Text = dr("NamaPerusahaan").ToString
                lbl_pic_customer.Text = dr("NamePIC").ToString
                lbl_ticket_number.Text = dr("TicketNumber").ToString
                Cat = dr("CategoryID").ToString
                SubCategory1ID = dr("SubCategory1ID").ToString
                SubCategory2ID = dr("SubCategory2ID").ToString
                SubCategory3ID = dr("SubCategory3ID").ToString
                lbl_sla.Text = dr("SLA").ToString
                lbl_message.Text = dr("DetailComplaint").ToString
                Response1 = dr("ResponComplaint").ToString
                RbTicketing = dr("Status").ToString
                cmb_priority.Value = dr("ComplaintLevel").ToString
                cmb_severity.Value = dr("Severity").ToString
                cmb_source_type.Value = dr("TicketSource").ToString
                cmb_group_type.Value = dr("TicketGroupName").ToString
                GroupType = dr("TicketGroup").ToString
                lbl_date.Text = dr("DateCreate").ToString
                DateClose = dr("DateClose").ToString
                UserCreate = dr("UserCreate").ToString
                TicketNumber = dr("TicketNumber").ToString
                Category.Text = dr("CatName").ToString
                SubCategoryI.Text = dr("SubName1").ToString
                SubCategoryII.Text = dr("SubName2").ToString
                SubCategoryIII.Text = dr("SubName3").ToString
                cmb_status.Value = dr("Status").ToString
                ClosedOleh = dr("ClosedBy").ToString
                If dr("Attch").ToString = "" Then
                    ASPxUploadControl1.Visible = True
                Else
                    ASPxUploadControl1.Visible = False
                End If
            Else
                ''Agar tidak error karena datanya tidak ada
                Response.Redirect("utama.aspx?")
            End If
            dr.Close()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try

        Dim dataResponTerakhir As String
        dataResponTerakhir = ""
        sql = "select TOP 1 * from tInteraction where TicketNumber='" & TicketNumber & "' order by DateCreate Desc"
        Try
            sqldr = Proses.ExecuteReader(sql)
            If sqldr.HasRows Then
                sqldr.Read()
                dataResponTerakhir = sqldr("ResponseComplaint").ToString
            End If
            sqldr.Close()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try

        If dataResponTerakhir = "" Then
            Response1 = Response1
        Else
            Response1 = dataResponTerakhir
        End If
        txt_message.Visible = False
        Btn_Simpan.Visible = False
        Btn_Update.Visible = True
        Btn_Assign.Visible = False
        lbl_red.Visible = True
        DSHistoryAgent.SelectCommand = "select b.Name, * from tInteraction a left outer join mKaryawan b on a.AgentCreate = b.NIK  where (a.TicketNumber='" & Request.QueryString("tid") & "' or a.TicketNumber='" & Ticket & "') order by DateCreate Desc"
        html_solution.Visible = True
        modal_dispatch_satu.Visible = False
        sql_status.SelectCommand = "select * from mstatus"
        sql = "select * from mcustomer where customerid='" & gl_cari.Text & "'"
        sqldr = Proses.ExecuteReader(sql)
        If sqldr.HasRows Then
            sqldr.Read()
            txt_customer_name.Text = sqldr("NamaPerusahaan").ToString
            txt_address_1.Text = sqldr("Alamat").ToString
            txt_email.Text = sqldr("email").ToString
            txt_phone1.Text = sqldr("Office").ToString
            txt_phone2.Text = sqldr("NomorHPPIC").ToString
            txt_customer_name.Enabled = False
        End If
        hprlink.Visible = True
        hprlink.NavigateUrl = "inbox.aspx"
        lbl_link.Text = "Todolist"
    End Sub

    Sub layer2()
        Dim NameAdd As String = ""
        Dim RelasiAdd As String = ""
        Dim PhoneAdd As String = ""
        Dim AddresAdd As String = ""
        Dim TicketNumber As String = ""
        Dim SearchKary As String = ""
        Dim Status As String = ""
        Dim NIK As String = ""
        Dim Ticket As String = ""
        Dim Response2 As String = ""
        Dim SubCategory1ID As String = ""
        Dim SubCategory2ID As String = ""
        Dim SubCategory3ID As String = ""
        Dim SLA As String = ""
        Dim Detail As String = ""
        Dim Cat As String = ""
        Dim RbTicketing, Priority, Severity, DealerIDName, DealerName, SourceType, GroupType, DateCreate, DateClose, UserCreate, ClosedOleh, responAllAgent, JenisTransaksi, UnitKerja, Subject, KategoriName As String
        sql = "SELECT dbo.tTicket.*, dbo.mSubCategoryLv1.*,dbo.mCategory.Name AS CatName,dbo.mSubCategoryLv1.SubName AS SubName1, dbo.mSubCategoryLv2.SubName AS SubName2, dbo.mSubCategoryLv3.SubName AS SubName3, mCustomer.NamaPerusahaan, " & _
                     " mCustomer.Alamat, mCustomer.Email, mCustomer.Telepon, mCustomer.NamePIC, " & _
                     " dbo.mCategory.*, dbo.mSubCategoryLv2.*,dbo.mSubCategoryLv3.* FROM dbo.mCategory INNER JOIN dbo.mSubCategoryLv1 ON dbo.mCategory.CategoryID = dbo.mSubCategoryLv1.CategoryID INNER JOIN " & _
                     " dbo.mSubCategoryLv2 ON dbo.mSubCategoryLv1.SubCategory1ID = dbo.mSubCategoryLv2.SubCategory1ID INNER JOIN dbo.mSubCategoryLv3 ON dbo.mSubCategoryLv2.SubCategory2ID = dbo.mSubCategoryLv3.SubCategory2ID INNER JOIN" & _
                     " dbo.tTicket ON dbo.mSubCategoryLv3.SubCategory3ID = dbo.tTicket.SubCategory3ID INNER JOIN mcustomer on tTicket.NIK = mCustomer.CustomerID where dbo.tTicket.TicketNumber ='" & Request.QueryString("tid") & "' or dbo.tTicket.NIK ='" & Request.QueryString("tid") & "'"
        Try
            dr = Proses.ExecuteReader(sql)
            If dr.HasRows Then
                dr.Read()
                NIK = dr("NIK").ToString
                lbl_customer.Text = dr("NamaPerusahaan").ToString
                lbl_pic_customer.Text = dr("NamePIC").ToString
                lbl_ticket_number.Text = dr("TicketNumber").ToString
                Cat = dr("CategoryID").ToString
                SubCategory1ID = dr("SubCategory1ID").ToString
                SubCategory2ID = dr("SubCategory2ID").ToString
                SubCategory3ID = dr("SubCategory3ID").ToString
                lbl_sla.Text = dr("SLA").ToString
                lbl_message.Text = dr("DetailComplaint").ToString
                Response2 = dr("ResponComplaint").ToString
                RbTicketing = dr("Status").ToString
                cmb_priority.Value = dr("ComplaintLevel").ToString
                cmb_severity.Value = dr("Severity").ToString
                cmb_source_type.Value = dr("TicketSource").ToString
                cmb_group_type.Value = dr("TicketGroupName").ToString
                GroupType = dr("TicketGroup").ToString
                lbl_date.Text = dr("DateCreate").ToString
                DateClose = dr("DateClose").ToString
                UserCreate = dr("UserCreate").ToString
                TicketNumber = dr("TicketNumber").ToString
                Category.Text = dr("CatName").ToString
                SubCategoryI.Text = dr("SubName1").ToString
                SubCategoryII.Text = dr("SubName2").ToString
                SubCategoryIII.Text = dr("SubName3").ToString
                cmb_status.Value = dr("Status").ToString
                ClosedOleh = dr("ClosedBy").ToString
                If dr("Attch").ToString = "" Then
                    ASPxUploadControl1.Visible = True
                Else
                    ASPxUploadControl1.Visible = False
                End If
            Else
                ''Agar tidak error karena datanya tidak ada
                Response.Redirect("utama.aspx?")
            End If
            dr.Close()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try

        Dim dataResponTerakhir As String = ""
        sql = "select TOP 1 * from tInteraction where TicketNumber='" & TicketNumber & "' order by DateCreate Desc"
        Try
            dr = Proses.ExecuteReader(sql)
            If dr.HasRows Then
                dr.Read()
                dataResponTerakhir = dr("ResponseComplaint").ToString
            End If
            dr.Close()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try

        If dataResponTerakhir = "" Then
            Response2 = Response2
        Else
            Response2 = dataResponTerakhir
        End If
        txt_message.Visible = False
        Btn_Simpan.Visible = False
        Btn_Update.Visible = True
        Btn_Assign.Visible = False
        lbl_red.Visible = True
        DSHistoryAgent.SelectCommand = "select b.Name, * from tInteraction a left outer join mKaryawan b on a.AgentCreate = b.NIK  where (a.TicketNumber='" & Request.QueryString("tid") & "' or a.TicketNumber='" & Ticket & "') order by DateCreate Desc"
        html_solution.Visible = True
        modal_dispatch_satu.Visible = False
        sql = "select * from mcustomer where customerid='" & gl_cari.Text & "'"
        sqldr = Proses.ExecuteReader(sql)
        If sqldr.HasRows Then
            sqldr.Read()
            txt_customer_name.Text = sqldr("NamaPerusahaan").ToString
            txt_address_1.Text = sqldr("Alamat").ToString
            txt_email.Text = sqldr("email").ToString
            txt_phone1.Text = sqldr("Office").ToString
            txt_phone2.Text = sqldr("NomorHPPIC").ToString
            txt_customer_name.Enabled = False
        End If
    End Sub

    Sub layer3()
        cmb_status.ReadOnly = True
        Dim NameAdd, RelasiAdd, PhoneAdd, AddresAdd As String
        Dim SearchKary, Status, NIK, Ticket, DealerIDName, Cat, SubCategory1ID, DealerName, SubCategory2ID, SubCategory3ID, SLA, Detail, Response2, RbTicketing,
        Priority, Severity, SourceType, GroupType, DateCreate, DateClose, UserCreate, TicketNumber, responAllAgent, JenisTransaksi, UnitKerja, Subject, KategoriName As String
        sql = "SELECT dbo.tTicket.*, dbo.mSubCategoryLv1.*,dbo.mCategory.Name AS CatName,dbo.mSubCategoryLv1.SubName AS SubName1, dbo.mSubCategoryLv2.SubName AS SubName2, dbo.mSubCategoryLv3.SubName AS SubName3, mCustomer.NamaPerusahaan, " & _
               " mCustomer.Alamat, mCustomer.Email, mCustomer.Telepon, mCustomer.NamePIC, " & _
               " dbo.mCategory.*, dbo.mSubCategoryLv2.*,dbo.mSubCategoryLv3.* FROM dbo.mCategory INNER JOIN dbo.mSubCategoryLv1 ON dbo.mCategory.CategoryID = dbo.mSubCategoryLv1.CategoryID INNER JOIN " & _
               " dbo.mSubCategoryLv2 ON dbo.mSubCategoryLv1.SubCategory1ID = dbo.mSubCategoryLv2.SubCategory1ID INNER JOIN dbo.mSubCategoryLv3 ON dbo.mSubCategoryLv2.SubCategory2ID = dbo.mSubCategoryLv3.SubCategory2ID INNER JOIN" & _
               " dbo.tTicket ON dbo.mSubCategoryLv3.SubCategory3ID = dbo.tTicket.SubCategory3ID INNER JOIN mcustomer on tTicket.NIK = mCustomer.CustomerID where dbo.tTicket.TicketNumber ='" & Request.QueryString("tid") & "' or dbo.tTicket.NIK ='" & Request.QueryString("tid") & "'"
        Try
            dr = Proses.ExecuteReader(sql)
            If dr.HasRows Then
                dr.Read()
                NIK = dr("NIK").ToString
                lbl_customer.Text = dr("NamaPerusahaan").ToString
                lbl_pic_customer.Text = dr("NamePIC").ToString
                lbl_ticket_number.Text = dr("TicketNumber").ToString
                Cat = dr("CategoryID").ToString
                SubCategory1ID = dr("SubCategory1ID").ToString
                SubCategory2ID = dr("SubCategory2ID").ToString
                SubCategory3ID = dr("SubCategory3ID").ToString
                lbl_sla.Text = dr("SLA").ToString
                lbl_message.Text = dr("DetailComplaint").ToString
                Response2 = dr("ResponComplaint").ToString
                RbTicketing = dr("Status").ToString
                cmb_priority.Value = dr("ComplaintLevel").ToString
                cmb_severity.Value = dr("Severity").ToString
                cmb_source_type.Value = dr("TicketSource").ToString
                cmb_group_type.Value = dr("TicketGroupName").ToString
                GroupType = dr("TicketGroup").ToString
                lbl_date.Text = dr("DateCreate").ToString
                DateClose = dr("DateClose").ToString
                UserCreate = dr("UserCreate").ToString
                TicketNumber = dr("TicketNumber").ToString
                Category.Text = dr("CatName").ToString
                SubCategoryI.Text = dr("SubName1").ToString
                SubCategoryII.Text = dr("SubName2").ToString
                SubCategoryIII.Text = dr("SubName3").ToString
                cmb_status.Value = dr("Status").ToString
                If dr("Attch").ToString = "" Then
                    ASPxUploadControl1.Visible = True
                Else
                    ASPxUploadControl1.Visible = False
                End If
            Else
                ''Agar tidak error karena datanya tidak ada
                Response.Redirect("utama.aspx?")
            End If
            dr.Close()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
        DSCustHistory.SelectCommand = "select top 5 * from tTicket where NIK='" & Request.QueryString("NIK") & "' order by id desc"

        Dim DTLast As String = ""
        sql = "select TOP 1 * from tInteraction where TicketNumber='" & TicketNumber & "' order by DateCreate Desc"
        Try
            dr = Proses.ExecuteReader(sql)
            If dr.HasRows Then
                dr.Read()
                DTLast = dr("ResponseComplaint").ToString
            End If
            dr.Close()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try

        If DTLast = "" Then
            Response2 = Response2
        Else
            Response2 = DTLast
        End If
        txt_message.Visible = False
        Btn_Simpan.Visible = False
        Btn_Update.Visible = True
        Btn_Assign.Visible = False
        lbl_red.Visible = True
        DSHistoryAgent.SelectCommand = "select b.Name, * from tInteraction a left outer join mKaryawan b on a.AgentCreate = b.NIK  where (a.TicketNumber='" & Request.QueryString("tid") & "' or a.TicketNumber='" & Ticket & "') order by DateCreate Desc"
        html_solution.Visible = True
        modal_dispatch_satu.Visible = False
    End Sub

    Sub admin()
        cmb_status.ReadOnly = True
        Dim NameAdd, RelasiAdd, PhoneAdd, AddresAdd As String
        Dim SearchKary, Status, NIK, Ticket, Cat, DealerName, DealerIDName, SubCategory1ID, SubCategory2ID, SubCategory3ID, SLA, Detail, Response2, RbTicketing,
        Priority, Severity, SourceType, GroupType, DateCreate, DateClose, UserCreate, TicketNumber, responAllAgent, JenisTransaksi, UnitKerja, Subject, KategoriName As String
        sql = "SELECT dbo.tTicket.*, dbo.mSubCategoryLv1.*,dbo.mCategory.Name AS CatName,dbo.mSubCategoryLv1.SubName AS SubName1, dbo.mSubCategoryLv2.SubName AS SubName2, dbo.mSubCategoryLv3.SubName AS SubName3, mCustomer.NamaPerusahaan, " & _
                     " mCustomer.Alamat, mCustomer.Email, mCustomer.Telepon, mCustomer.NamePIC, " & _
                     " dbo.mCategory.*, dbo.mSubCategoryLv2.*,dbo.mSubCategoryLv3.* FROM dbo.mCategory INNER JOIN dbo.mSubCategoryLv1 ON dbo.mCategory.CategoryID = dbo.mSubCategoryLv1.CategoryID INNER JOIN " & _
                     " dbo.mSubCategoryLv2 ON dbo.mSubCategoryLv1.SubCategory1ID = dbo.mSubCategoryLv2.SubCategory1ID INNER JOIN dbo.mSubCategoryLv3 ON dbo.mSubCategoryLv2.SubCategory2ID = dbo.mSubCategoryLv3.SubCategory2ID INNER JOIN" & _
                     " dbo.tTicket ON dbo.mSubCategoryLv3.SubCategory3ID = dbo.tTicket.SubCategory3ID INNER JOIN mcustomer on tTicket.NIK = mCustomer.CustomerID where dbo.tTicket.TicketNumber ='" & Request.QueryString("tid") & "' or dbo.tTicket.NIK ='" & Request.QueryString("tid") & "'"
        Try
            dr = Proses.ExecuteReader(sql)
            If dr.HasRows Then
                dr.Read()
                NIK = dr("NIK").ToString
                lbl_customer.Text = dr("NamaPerusahaan").ToString
                lbl_pic_customer.Text = dr("NamePIC").ToString
                lbl_ticket_number.Text = dr("TicketNumber").ToString
                Cat = dr("CategoryID").ToString
                SubCategory1ID = dr("SubCategory1ID").ToString
                SubCategory2ID = dr("SubCategory2ID").ToString
                SubCategory3ID = dr("SubCategory3ID").ToString
                lbl_sla.Text = dr("SLA").ToString
                lbl_message.Text = dr("DetailComplaint").ToString
                Response2 = dr("ResponComplaint").ToString
                RbTicketing = dr("Status").ToString
                cmb_priority.Value = dr("ComplaintLevel").ToString
                cmb_severity.Value = dr("Severity").ToString
                cmb_source_type.Value = dr("TicketSource").ToString
                cmb_group_type.Value = dr("TicketGroupName").ToString
                GroupType = dr("TicketGroup").ToString
                lbl_date.Text = dr("DateCreate").ToString
                DateClose = dr("DateClose").ToString
                UserCreate = dr("UserCreate").ToString
                TicketNumber = dr("TicketNumber").ToString
                Category.Text = dr("CatName").ToString
                SubCategoryI.Text = dr("SubName1").ToString
                SubCategoryII.Text = dr("SubName2").ToString
                SubCategoryIII.Text = dr("SubName3").ToString
                cmb_status.Value = dr("Status").ToString
                If dr("Attch").ToString = "" Then
                    ASPxUploadControl1.Visible = True
                Else
                    ASPxUploadControl1.Visible = False
                End If
            Else
                ''Agar tidak error karena datanya tidak ada
                Response.Redirect("utama.aspx?")
            End If
            dr.Close()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try

        Dim DTLast As String = ""
        sql = "select TOP 1 * from tInteraction where TicketNumber='" & TicketNumber & "' order by DateCreate Desc"
        Try
            dr = Proses.ExecuteReader(sql)
            If dr.HasRows Then
                dr.Read()
                DTLast = dr("ResponseComplaint").ToString
            End If
            dr.Close()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
        If DTLast = "" Then
            Response2 = Response2
        Else
            Response2 = DTLast
        End If
        txt_message.Visible = False
        Btn_Simpan.Visible = False
        Btn_Update.Visible = False
        Btn_Assign.Visible = False
        lbl_red.Visible = True
        DSHistoryAgent.SelectCommand = "select b.Name, * from tInteraction a left outer join mKaryawan b on a.AgentCreate = b.NIK  where (a.TicketNumber='" & Request.QueryString("tid") & "' or a.TicketNumber='" & Ticket & "') order by DateCreate Desc"
        html_solution.Visible = True
        modal_dispatch_satu.Visible = False
    End Sub

    Sub kosong()
        Dim SearchKary, NIK, Ticket, Cat, DealerName, DealerIDName, SubCategory1ID, SubCategory2ID, SubCategory3, SLA, Detail, ResponseSol, RbTicketing,
        Priority, Severity, SourceType, DateCreate, DateClose, UserCreate, TicketNumber, responAllAgent, Status As String
        sql = "select * from tTicket where  TicketNumber ='" & Request.QueryString("tid") & "' ORDER BY ID DESC "
        Try
            dr = Proses.ExecuteReader(sql)
            If dr.HasRows Then
                dr.Read()
                NIK = dr("NIK").ToString
                Ticket = dr("TicketNumber").ToString
                Cat = dr("CategoryID").ToString
                SubCategory1ID = dr("SubCategory1ID").ToString
                SubCategory2ID = dr("SubCategory2ID").ToString
                SubCategory3 = dr("SubCategory3ID").ToString
                SLA = dr("SLA").ToString
                Detail = dr("DetailComplaint").ToString
                ResponseSol = dr("ResponComplaint").ToString
                RbTicketing = dr("Status").ToString
                Priority = dr("ComplaintLevel").ToString
                Severity = dr("Severity").ToString
                SourceType = dr("TicketSource").ToString
                DateCreate = dr("DateCreate").ToString
                DateClose = dr("DateClose").ToString
                UserCreate = dr("UserCreate").ToString
                TicketNumber = dr("TicketNumber").ToString
                Status = dr("Status").ToString
                If dr("Attch").ToString = "" Then
                    ASPxUploadControl1.Visible = True
                Else
                    ASPxUploadControl1.Visible = False
                End If
            End If
            dr.Close()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try


        Dim DTlast As String = ""
        sql = "select TOP 1 * from tInteraction where TicketNumber='" & TicketNumber & "' order by DateCreate Desc"
        Try
            dr = Proses.ExecuteReader(sql)
            If dr.HasRows Then
                dr.Read()
                DTlast = dr("ResponseComplaint").ToString
            End If
            dr.Close()
        Catch ex As Exception

        End Try

        If DTlast = "" Then
            ResponseSol = ResponseSol
        Else
            ResponseSol = DTlast
        End If
        lbl_customer.Text = NIK
        Category.Text = Cat
        SubCategoryI.Text = SubCategory1ID
        SubCategoryII.Text = SubCategory2ID
        SubCategoryIII.Text = SubCategory3
        lbl_sla.Text = SLA
        lbl_message.Text = Detail
        cmb_status.Value = Status
        cmb_priority.Value = Priority
        cmb_severity.Value = Severity
        cmb_source_type.Value = SourceType
        lbl_ticket_number.Text = TicketNumber
        html_solution.Html = DTlast
        Btn_Simpan.Visible = False
        Btn_Update.Visible = True
        Btn_Assign.Visible = False
        DSHistoryAgent.SelectCommand = "select b.Name, * from tInteraction a left outer join mKaryawan b on a.AgentCreate = b.NIK  where (a.TicketNumber='" & Request.QueryString("tid") & "') order by DateCreate Desc"
    End Sub

    Sub history_ticket()
        sql = "select top 5 ROW_NUMBER() OVER(ORDER BY id DESC) AS Row,  TicketNumber, TicketSource, NIK, CONVERT(VARCHAR(10),DateCreate,110) as Dates, DateCreate  from tTicket where NIK='" & Request.QueryString("NIK") & "' order by id desc"
        sqldr = Proses.ExecuteReader(sql)
        While sqldr.Read
            value &= "<tr>" & _
                       "<td>" & sqldr("Row").ToString & "</td>" & _
                       "<td><span class='not-starred'><i><a class='nonelink' href='utama.aspx?tid=" & sqldr("TicketNumber") & "&layer=" & Session("LoginType") & "&NIK=" & sqldr("NIK") & "&datecreate=" & sqldr("DateCreate") & "' target='_blank'>" & sqldr("TicketNumber") & "</i></span></td>" & _
                       "<td>" & sqldr("dates").ToString & "</td>" & _
                       "</tr>"
        End While
        sqldr.Close()
        ltr_history_ticket.Text = value
    End Sub

    Private Sub Btn_Update_Click(sender As Object, e As EventArgs) Handles Btn_Update.ServerClick
        Dim SaveResponseComplaint, UpdateResponseComplaintTableTticket, UpdateResponseComplaintTableTdispatch, ClosedTicketBy As String
        If Request.QueryString("tid") <> "" And Request.QueryString("layer") = "" Then
            If cmb_status.Value = "Closed" Then
                ClosedTicketBy = "2"
                UpdateResponseComplaintTableTticket = "update tTicket set UserClose='" & Session("UserName") & "',Status='" & cmb_status.Value & "',DateClose=GETDATE(),ClosedBy='" & ClosedTicketBy & "' where TicketNumber='" & Request.QueryString("tid") & "'"
            Else
                UpdateResponseComplaintTableTticket = "update tTicket set Status='" & cmb_status.Value & "' where TicketNumber='" & Request.QueryString("tid") & "'"
            End If

            com = New SqlCommand(UpdateResponseComplaintTableTticket, con)
            con.Open()
            com.ExecuteNonQuery()
            con.Close()

            UpdateResponseComplaintTableTdispatch = "update tDispatch set StatusDispatch='" & cmb_status.Value & "' where TicketNumber='" & Request.QueryString("tid") & "'"
            com = New SqlCommand(UpdateResponseComplaintTableTdispatch, con)
            con.Open()
            com.ExecuteNonQuery()
            con.Close()
        End If

        Dim jikaClosed, query As String
        query = "select COUNT(tDispatchID) as cekData from tDispatch where TicketNumber ='" & lbl_ticket_number.Text & "'"
        com = New SqlCommand(query, con)
        con.Open()
        dr = com.ExecuteReader()
        If dr.Read() Then
            If dr("cekData").ToString <> 0 And Request.QueryString("tid") = "" Then
                'panelInformasiDiDispatch.Visible = True
            Else

                CekInteraction(Session("UserName"), lbl_ticket_number.Text)

                SaveResponseComplaint = "INSERT INTO tInteraction(TicketNumber,ResponseComplaint,AgentCreate,DateCreate,FirstCreate) values ('" & lbl_ticket_number.Text & "','" & html_solution.Html & "','" & Session("UserName") & "',GETDATE(),'" & DapatHasilCekInteraction & "')"
                com = New SqlCommand(SaveResponseComplaint, sqlcon)
                sqlcon.Open()
                com.ExecuteNonQuery()
                sqlcon.Close()

                Dim responComplaint, diClosedOlehVal, diClosedOleh, userYgMengClosed As String
                If Session("LoginType") = "layer2" Then
                    diClosedOlehVal = "2"
                ElseIf Session("LoginType") = "layer1" Then
                    diClosedOlehVal = "1"
                End If
                If cmb_status.Value = "Closed" Then
                    jikaClosed = " , DateClose='" & Waktu & "'"
                    responComplaint = ", ResponComplaint='" & ReplaceSpecialLetter(html_solution.Html) & "'"
                    diClosedOleh = ", ClosedBy='" & diClosedOlehVal & "'"
                    userYgMengClosed = ", UserClose='" & Session("UserName") & "'"
                Else
                    jikaClosed = ""
                    responComplaint = ""
                    diClosedOleh = ""
                End If

                UpdateResponseComplaintTableTticket = "update tTicket set Status='" & cmb_status.Value & "',  ResponComplaint='" & html_solution.Html & "' " & jikaClosed & " " & diClosedOleh & " " & userYgMengClosed & " where TicketNumber='" & lbl_ticket_number.Text & "'"
                com = New SqlCommand(UpdateResponseComplaintTableTticket, sqlcon)
                sqlcon.Open()
                com.ExecuteNonQuery()
                sqlcon.Close()

                Dim UpdateTDispath As String
                UpdateTDispath = "update tDispatch set StatusDispatch='" & cmb_status.Value & "' where TicketNumber='" & lbl_ticket_number.Text & "'"
                com = New SqlCommand(UpdateTDispath, sqlcon)
                sqlcon.Open()
                com.ExecuteNonQuery()
                sqlcon.Close()

                ' Jika Ticket sudah di closed maka secara otomatis informasi closed tersebut akan dikirim by email jika yang mengajukan by email
                Dim insertKeTableCloseTicket As String = ""
                If cmb_status.Value = "Closed" Or cmb_status.Value = "In Progress" Then
                    If cmb_status.Value = "Closed" Then
                        insertKeTableCloseTicket = "UPDATE tCloseTicket SET DateClose=GETDATE() WHERE TicketNumber='" & lbl_ticket_number.Text & "'"
                        com = New SqlCommand(insertKeTableCloseTicket, sqlcon)
                        sqlcon.Open()
                        com.ExecuteNonQuery()
                        sqlcon.Close()
                    Else

                    End If

                    Dim subjectTicket As String
                    If cmb_status.Value = "Closed" Then
                        subjectTicket = "Closed"
                    ElseIf cmb_status.Value = "In Progress" Then
                        subjectTicket = "In Progress"
                    End If

                    Dim SelectAcountEmail, NikGet, NumberTicket, IDDealer, NamaDealer, CallType2, CustGroupTypeName, TransaksiJenis, CustSourceTypeName, CustDealerName, VRegion, UnitKerja, Subject, KategoriName, DetailComp, DateCreateTicket As String
                    SelectAcountEmail = "SELECT dbo.tTicket.*, dbo.mSubCategoryLv1.*,dbo.mCategory.Name AS CatName,dbo.mSubCategoryLv1.SubName AS SubName1, dbo.mSubCategoryLv2.SubName AS SubName2, dbo.mSubCategoryLv3.SubName AS SubName3, " & _
                                        " dbo.mCategory.*, dbo.mSubCategoryLv2.*,dbo.mSubCategoryLv3.* FROM dbo.mCategory INNER JOIN dbo.mSubCategoryLv1 ON dbo.mCategory.CategoryID = dbo.mSubCategoryLv1.CategoryID INNER JOIN " & _
                                        " dbo.mSubCategoryLv2 ON dbo.mSubCategoryLv1.SubCategory1ID = dbo.mSubCategoryLv2.SubCategory1ID INNER JOIN dbo.mSubCategoryLv3 ON dbo.mSubCategoryLv2.SubCategory2ID = dbo.mSubCategoryLv3.SubCategory2ID INNER JOIN" & _
                                        " dbo.tTicket ON dbo.mSubCategoryLv3.SubCategory3ID = dbo.tTicket.SubCategory3ID where dbo.tTicket.TicketNumber ='" & lbl_ticket_number.Text & "'"
                    com = New SqlCommand(SelectAcountEmail, sqlcon)
                    sqlcon.Open()
                    dr = com.ExecuteReader()
                    If dr.Read() Then
                        NikGet = dr("NIK").ToString
                        NumberTicket = dr("TicketNumber").ToString
                        TransaksiJenis = dr("CatName").ToString
                        UnitKerja = dr("SubName1").ToString
                        Subject = dr("SubName2").ToString
                        KategoriName = dr("SubName3").ToString
                        DetailComp = dr("DetailComplaint").ToString
                        DateCreateTicket = dr("DateCreate").ToString
                        VRegion = dr("Region").ToString
                        CustGroupTypeName = dr("TicketGroupName").ToString
                        CustSourceTypeName = dr("TicketSourceName").ToString
                        CustDealerName = dr("DealerName").ToString
                        IDDealer = dr("DealerID").ToString
                        NamaDealer = dr("DealerName").ToString
                        CallType2 = dr("SubCategory1Name").ToString
                    End If
                    dr.Close()
                    sqlcon.Close()
                    'Event Kirim Email
                    'SendEmail

                    Dim strArr
                    strArr = selectTable("mCustomer", "CustomerID,Email", "CustomerID='" & NikGet & "'")

                    Dim SEmailCreate As String = ""
                    Dim VEmailCreate As String = ""
                    sql = "select * from tManejemEmail where ToolEmail='EmailClosed'"
                    sqldr = Proses.ExecuteReader(sql)
                    If sqldr.Read() Then
                        VEmailCreate = sqldr("Status").ToString
                    End If
                    sqldr.Close()
                    If VEmailCreate = True Then
                        '========== Template Email =========
                        Dim sDetailCustomer, CustomerID, CustomerName, CustomerTelp, CustomerAlamat, CustomerHP As String
                        Dim CustomerTransmisi, CustomerModel As String
                        sDetailCustomer = "Sp_DetailCustomer '" & hd_nik.Value & "'"
                        com = New SqlCommand(sDetailCustomer, con)
                        con.Open()
                        dr = com.ExecuteReader()
                        If dr.Read() Then
                            CustomerID = dr("CustomerID").ToString
                            CustomerName = dr("NamePIC").ToString
                            CustomerTelp = dr("Telepon").ToString
                            CustomerAlamat = dr("Alamat").ToString
                            EmailCustomer = dr("Email").ToString
                        End If
                        dr.Close()
                        con.Close()

                        Dim VUser, VUserAddress, VNikSupervisor As String
                        sql = "select EmailAddress from mEmailSuzuki where TypeLevel='CloseTicket' And NA='Y'"
                        sqldr = Proses.ExecuteReader(sql)
                        While sqldr.Read()
                            VUserAddress &= sqldr("EmailAddress").ToString & ","
                        End While
                        sqldr.Close()
                        Dim EmailTujuan As String = RemoveLastCharacter(EmailCustomer)

                        Dim SubjectEmail As String = Category.Text & " - " & SubCategoryIII.Text & " - " & NumberTicket
                        Dim TableTemplate As String
                        TableTemplate = "<table width=960 style=background-color:#F5F5F5; font-family: Arial,Helvetica,sans-serif; color: black;>" & _
                                "<tr><td width=200 style=font-weight:bold>Nomor Ticket</td><td>:</td><td>" & NumberTicket & "</td></tr>" & _
                                "<tr><td style=font-weight:bold>Customer ID</td><td>:</td><td>" & CustomerID & "</td></tr>" & _
                                "<tr><td style=font-weight:bold>Customer Name</td><td>:</td><td>" & CustomerName & "</td></tr>" & _
                                "<tr><td style=font-weight:bold>Address</td><td>:</td><td>" & CustomerAlamat & "</td></tr>" & _
                                "<tr><td style=font-weight:bold>Phone Number</td><td>:</td><td>" & CustomerTelp & "</td></tr>" & _
                                "<tr><td style=font-weight:bold>Source Type</td><td>:</td><td>" & CustSourceTypeName & "</td></tr>" & _
                                "<tr><td style=font-weight:bold>Group Type</td><td>:</td><td>" & CustGroupTypeName & "</td></tr>" & _
                                "<tr><td style=font-weight:bold>Category</td><td>:</td><td>" & Category.Text & "</td></tr>" & _
                                "<tr><td style=font-weight:bold>Call Type 1</td><td>:</td><td>" & SubCategoryI.Text & "</td></tr>" & _
                                "<tr><td style=font-weight:bold>Call Type 2</td><td>:</td><td>" & SubCategoryII.Text & "</td></tr>" & _
                                "<tr><td style=font-weight:bold>Call Type 3</td><td>:</td><td>" & SubCategoryIII.Text & "</td></tr>" & _
                                "<tr><td style=font-weight:bold>Detail Complaint</td><td>:</td><td>" & txt_message.Text & "</td></tr>" & _
                                "<tr><td style=font-weight:bold>Response</td><td>:</td><td>" & html_solution.Html & "</td></tr>" & _
                                "<tr><td style=font-weight:bold>Ticket Status</td><td>:</td><td>" & cmb_status.Value & "</td></tr>" & _
                                "</table>"

                        Dim i_email As String = "Insert Into IVC_EMAIL_IN_TM (DIRECTION,EFROM,ETO,TICKET_NUMBER,ESUBJECT,EBODY, ecc, Email_Date, JENIS_EMAIL) " & _
                           "Values ('out','" & EmailForm & "','" & strArr(1) & "','" & NumberTicket & "','" & SubjectEmail & "','" & TableTemplate & "','" & VUserAddress & "',GETDATE(),'CloseTicket')"
                        Try
                            com = New SqlCommand(i_email, sqlcon)
                            sqlcon.Open()
                            com.ExecuteNonQuery()
                            updateFlagEmail(NumberTicket)
                            sqlcon.Close()
                        Catch ex As Exception

                        End Try

                    Else
                        ' Create Log jika Ticket tidak dikirimkan email
                        NotEmailSend.LogNotSendEmail("--START--")
                        NotEmailSend.LogNotSendEmail("Date Create   :" & Date.Now & "")
                        NotEmailSend.LogNotSendEmail("Ticket Number :" & NumberTicket & " Berhasil di insert")
                        NotEmailSend.LogNotSendEmail("Customer Id   :" & hd_nik.Value & "")
                        NotEmailSend.LogNotSendEmail("--END--")
                    End If
                End If
            End If
        End If
        dr.Close()
        con.Close()
        Btn_Update.Visible = True
        If Request.QueryString("layer") = "layer3" Then
            ' BtnReAssign.Visible = True
            Btn_Update.Visible = False
            btn_dispatch.Visible = False
            Btn_Assign.Visible = True
        ElseIf Request.QueryString("layer") = "layer2" Then
            Btn_Update.Visible = False
            modal_dispatch_dua.Visible = True
            Dim VData As String
            sql = "select COUNT(tDispatchID) as Data from tDispatch where TicketNumber='" & Request.QueryString("tid") & "' and ReAssign='YES'"
            sqldr = Proses.ExecuteReader(sql)
            If sqldr.HasRows Then
                sqldr.Read()
                VData = sqldr("Data").ToString
            End If
            If VData > 0 Then
                Btn_Assign.Visible = True
            Else
                Btn_Assign.Visible = False
            End If
        Else
            Btn_Assign.Visible = False
        End If

        SubCategoryIII.ReadOnly = True
        Dim SelectBuatKondisiButton, StatusTicketNya As String
        StatusTicketNya = ""
        SelectBuatKondisiButton = "Select Status from tTicket where TicketNumber = '" & lbl_ticket_number.Text & "'"
        com = New SqlCommand(SelectBuatKondisiButton, con)
        con.Open()
        dr = com.ExecuteReader()
        If dr.Read() Then
            StatusTicketNya = dr("Status").ToString
        End If
        dr.Close()
        con.Close()
        If StatusTicketNya = "Closed" Then
            Btn_Update.Visible = False
            btn_dispatch.Visible = False
        End If

    End Sub

    Public Function CekInteraction(ByVal AgentCreateNya As String, ByVal TicketIDNya As String) As String
        sql = "select COUNT(ID) as Jumlah from tinteraction where AgentCreate='" & AgentCreateNya & "' and TicketNumber='" & TicketIDNya & "'select COUNT(ID) as Jumlah from tinteraction where AgentCreate='" & AgentCreateNya & "' and TicketNumber='" & TicketIDNya & "'"
        sqldr = Proses.ExecuteReader(sql)
        If sqldr.HasRows Then
            sqldr.Read()
            If sqldr("Jumlah").ToString > 0 Then
                DapatHasilCekInteraction = "No"
            Else
                DapatHasilCekInteraction = "Yes"
            End If
        End If
        sqldr.Close()
    End Function

    Private Sub btn_dispatch_Click(sender As Object, e As EventArgs) Handles btn_dispatch.ServerClick
        ' log gagal insert dispatch
        log.writedata("--Start--")
        log.writedata("UserName/Date : " & Session("UserName") & "/" & DateTime.Now)
        log.writedata("Ticket Number: " & lbl_ticket_number.Text)

        sql = "select * from tTicket where TicketNumber='" & lbl_ticket_number.Text & "'"
        Try
            sqldr = Proses.ExecuteReader(sql)
            If sqldr.HasRows Then
                sqldr.Read()
                statusTicket = dr("Status").ToString
            End If
            sqldr.Close()
        Catch ex As Exception
            log.writedata(DateTime.Now() & "-Error Select tTicket Get Status: " & ex.Message())
        Finally
            log.writedata("Status Ticket: " & statusTicket & "-" & DateTime.Now())
        End Try

        'untuk memberikan kondisi jika ticket di create diatas jam kerja
        Dim today As System.DateTime
        Dim batasanWaktu As System.DateTime
        Dim JamCreateTicket As String = Date.Now.ToString("HH:mm")
        Dim JamBatasanTicket As String = "17:00"
        Dim simpanDateDispatch As String
        If JamCreateTicket > JamBatasanTicket Then
            today = System.DateTime.Now
            batasanWaktu = today.AddDays(1)
            Dim DateNowCreate As String
            DateNowCreate = batasanWaktu.ToString("dd - MMMM - yyyy")
            'Dim NextDay As Date = DateAdd(DateInterval.Day, 1, dateValue).ToString("yyyy-mm-dd")
            simpanDateDispatch = DateNowCreate & " 08:00:00 AM"
        Else
            simpanDateDispatch = Format(Date.Now, "yyyy-MM-dd hh:mm:ss")
        End If


        strInsert = "insert into tDispatch(TicketNumber,DateDispatch,UserDispatch,StatusDispatch,AlasanDispatch) values('" & lbl_ticket_number.Text & "','" & simpanDateDispatch & "','" & Session("UserName") & "','" & statusTicket & "','" & txt_keterangan_dispatch.Text & "')"
        comInsert = New SqlCommand(strInsert, sqlcon)
        Try
            sqlcon.Open()
            comInsert.ExecuteNonQuery()
        Catch ex As Exception
            log.writedata(DateTime.Now() & "-Error Insert tDIspatch Agent ke CU: " & ex.Message())
        Finally
            sqlcon.Close()
            log.writedata("Ticket berhasil di dispatch untuk pertama kalinya" & DateTime.Now())
        End Try

        Dim posisiTiketTerakhir, layer As String
        If HD_Posisi.Value = "3" Then
            posisiTiketTerakhir = "2"
            log.writedata("Ticket berada pada layer 3 dan akan di Re-Assign")

        ElseIf HD_Posisi.Value = "2" Or HD_Posisi.Value = "layer2" Then
            posisiTiketTerakhir = "3"
            log.writedata("Ticket berada pada layer 2 dan akan di Dispatch ke layer 3")

        ElseIf HD_Posisi.Value = "" Or HD_Posisi.Value = "layer1" Then
            posisiTiketTerakhir = "2"
            log.writedata("Ticket berada pada layer 1 dan akan di Dispatch ke layer 2")

        ElseIf HD_Posisi.Value = "1" Or HD_Posisi.Value = "layer1" Then
            posisiTiketTerakhir = "2"
            log.writedata("Ticket berada pada layer 1 dan akan di Dispatch ke layer 2")

        End If

        If Session("LoginType") = "layer1" Then
            strUpdate = "update tTicket set TicketPosition='" & posisiTiketTerakhir & "', dispatch_user='" & cmb_Personal_Support.Value & "', Status='On Progress' where TicketNumber ='" & lbl_ticket_number.Text & "'"
            'send_email(cmb_user_dispatch.Value, lbl_ticket_number.Text)

        ElseIf Session("LoginType") = "layer2" Then
            strUpdate = "update tTicket set TicketPosition='" & posisiTiketTerakhir & "', Divisi='" & cmb_unit_support.Value & "' where TicketNumber ='" & lbl_ticket_number.Text & "'"
            'send_email_group(cmb_group.Value, lbl_ticket_number.Text)

        End If
        comUpdate = New SqlCommand(strUpdate, sqlcon)
        Try
            sqlcon.Open()
            comUpdate.ExecuteNonQuery()
        Catch ex As Exception
            log.writedata(DateTime.Now() & "-Error Update : " & ex.Message())
        Finally
            sqlcon.Close()
            log.writedata("Ticket berhasil di dispatch/reassign dari" & HD_Posisi.Value & " menuju :" & posisiTiketTerakhir)
            log.writedata("--end--")
        End Try

        Response.Redirect("inbox.aspx")
    End Sub

    Private Sub btn_dispatch_unit_Click(sender As Object, e As EventArgs) Handles btn_dispatch_unit.ServerClick
        log.writedata("--Start--")
        log.writedata("UserName/Date : " & Session("UserName") & "/" & DateTime.Now)
        log.writedata("Ticket Number: " & lbl_ticket_number.Text)

        sql = "select * from tTicket where TicketNumber='" & lbl_ticket_number.Text & "'"
        Try
            sqldr = Proses.ExecuteReader(sql)
            If sqldr.HasRows Then
                sqldr.Read()
                statusTicket = dr("Status").ToString
            End If
            sqldr.Close()
        Catch ex As Exception
            log.writedata(DateTime.Now() & "-Error Select tTicket Get Status: " & ex.Message())
        Finally
            log.writedata("Status Ticket: " & statusTicket & "-" & DateTime.Now())
        End Try

        Dim queryDispatch As String
        sql = "select * from tDispatch where TicketNumber ='" & lbl_ticket_number.Text & "'"
        sqldr = Proses.ExecuteReader(sql)
        Try
            If sqldr.HasRows Then
                sqldr.Read()
                log.writedata("Ticket sudah tersedia di table dispatch")

                If sqldr("GoToLeader").ToString = "YES" And sqldr("ReAssign").ToString = "YES" Then 'Kondisi ada di CU

                    log.writedata("User Login : Layer 2 (" & Session("UserName") & ")")
                    strUpdate = "update tDispatch set DateDispatchPIC='" & Format(Date.Now, "yyyy-MM-dd hh:mm:ss") & "',UserDispatchPIC ='" & Session("UserName") & "',ReAssign ='NO',AlasanDispatchPIC='" & txt_keterangan_dispatch.Text & "' where TicketNumber ='" & lbl_ticket_number.Text & "'"
                    comUpdate = New SqlCommand(strUpdate, sqlcon)
                    Try
                        sqlcon.Open()
                        comUpdate.ExecuteNonQuery()
                    Catch ex As Exception
                        log.writedata(DateTime.Now() & "-Error Update tDispatch Dari CU ke PIC : " & ex.Message())
                    Finally
                        sqlcon.Close()
                        log.writedata("Ticket di dispatch kembali kepada Layer 3" & DateTime.Now())
                    End Try

                ElseIf sqldr("GoToLeader").ToString = "YES" And sqldr("ReAssign").ToString = "NO" Then

                    log.writedata("User Login : Layer 3 (" & Session("UserName") & ")")
                    strUpdate = "update tDispatch set DateFeedBackPICtoCU='" & Format(Date.Now, "yyyy-MM-dd hh:mm:ss") & "',UserReAssignPICtoCU ='" & Session("UserName") & "',ReAssign ='YES',AlasanDispatch='" & txt_keterangan_dispatch.Text & "' where TicketNumber ='" & lbl_ticket_number.Text & "'"
                    comUpdate = New SqlCommand(strUpdate, sqlcon)
                    Try
                        sqlcon.Open()
                        comUpdate.ExecuteNonQuery()
                    Catch ex As Exception
                        log.writedata(DateTime.Now() & "-Error Update tDispatch Reassign PIC ke CU: " & ex.Message())
                    Finally
                        sqlcon.Close()
                        log.writedata("Ticket di Re-Assign kembali kepada Layer 2" & DateTime.Now())
                    End Try

                ElseIf sqldr("GoToLeader").ToString = "NO" And sqldr("ReAssign").ToString = "NO" Then
                    log.writedata("User Login : Layer 2 (" & Session("UserName") & ")")
                    strUpdate = "update tDispatch set DateDispatchPIC='" & Format(Date.Now, "yyyy-MM-dd hh:mm:ss") & "',UserDispatchPIC ='" & Session("UserName") & "',GoToLeader='YES',ReAssign ='NO',AlasanDispatchPIC='" & txt_keterangan_dispatch.Text & "' where TicketNumber ='" & lbl_ticket_number.Text & "'"
                    comUpdate = New SqlCommand(strUpdate, sqlcon)
                    Try
                        sqlcon.Open()
                        comUpdate.ExecuteNonQuery()
                    Catch ex As Exception
                        log.writedata(DateTime.Now() & "-Error Update tDispatch Dari CU ke PIC: " & ex.Message())
                    Finally
                        sqlcon.Close()
                        log.writedata("Ticket pertama kali didispatch kelayer 3" & DateTime.Now())
                    End Try
                End If
            End If
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try

        Dim posisiTiketTerakhir, layer As String
        If HD_Posisi.Value = "3" Then
            posisiTiketTerakhir = "2"
            log.writedata("Ticket berada pada layer 3 dan akan di Re-Assign")

        ElseIf HD_Posisi.Value = "2" Or HD_Posisi.Value = "layer2" Then
            posisiTiketTerakhir = "3"
            log.writedata("Ticket berada pada layer 2 dan akan di Dispatch ke layer 3")

        ElseIf HD_Posisi.Value = "" Or HD_Posisi.Value = "layer1" Then
            posisiTiketTerakhir = "2"
            log.writedata("Ticket berada pada layer 1 dan akan di Dispatch ke layer 2")

        ElseIf HD_Posisi.Value = "1" Or HD_Posisi.Value = "layer1" Then
            posisiTiketTerakhir = "2"
            log.writedata("Ticket berada pada layer 1 dan akan di Dispatch ke layer 2")

        End If

        If Session("LoginType") = "layer1" Then
            strUpdate = "update tTicket set TicketPosition='" & posisiTiketTerakhir & "', dispatch_user='" & cmb_Personal_Support.Value & "' where TicketNumber ='" & lbl_ticket_number.Text & "'"
            'send_email(cmb_user_dispatch.Value, lbl_ticket_number.Text)

        ElseIf Session("LoginType") = "layer2" Then
            strUpdate = "update tTicket set TicketPosition='" & posisiTiketTerakhir & "', Divisi='" & cmb_unit_support.Value & "' where TicketNumber ='" & lbl_ticket_number.Text & "'"
            'send_email_group(cmb_group.Value, lbl_ticket_number.Text)

        End If
        comUpdate = New SqlCommand(strUpdate, sqlcon)
        Try
            sqlcon.Open()
            comUpdate.ExecuteNonQuery()
        Catch ex As Exception
            log.writedata(DateTime.Now() & "-Error Update : " & ex.Message())
        Finally
            sqlcon.Close()
            log.writedata("Ticket berhasil di dispatch/reassign dari" & HD_Posisi.Value & " menuju :" & posisiTiketTerakhir)
            log.writedata("--end--")
        End Try

        Response.Redirect("inbox.aspx")
    End Sub

    Private Sub Btn_Assign_Click(sender As Object, e As EventArgs) Handles Btn_Assign.ServerClick
        Dim count As Integer
        conn = New SqlConnection(connectionString)
        comm = New SqlCommand()
        comm.Connection = conn
        comm.CommandType = CommandType.StoredProcedure
        comm.CommandText = "sp_assign_ticket"
        comm.Parameters.Add("@ReAssign", Data.SqlDbType.VarChar).Value = "YES"
        If Session("LoginType") = "layer2" Then
            comm.Parameters.Add("@layer", Data.SqlDbType.VarChar).Value = 2
        ElseIf Session("LoginType") = "layer3" Then
            comm.Parameters.Add("@layer", Data.SqlDbType.VarChar).Value = 3
        End If
        comm.Parameters.Add("@UserReAssignPICtoCU", Data.SqlDbType.VarChar).Value = Session("UserName")
        comm.Parameters.Add("@TicketNumber", Data.SqlDbType.VarChar).Value = lbl_ticket_number.Text
        comm.Parameters.Add("@ResponseComplaint", Data.SqlDbType.VarChar).Value = html_solution.Html
        comm.Parameters.Add("@AgentCreate", Data.SqlDbType.VarChar).Value = Session("UserName")
        comm.Parameters.Add("@TicketPosition", Data.SqlDbType.VarChar).Value = "2"
        Try
            conn.Open()
            reader = comm.ExecuteReader()
            reader.Read()
            TicketNo = reader(0)
            reader.Close()
            conn.Close()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
        Btn_Assign.Visible = False
        Response.Redirect("todolist.aspx")
    End Sub

    Sub button_download()
        Response.Redirect("~/HTML/Upload/20160914013617_JSM.xlsx")
    End Sub

    Private Sub btn_update_customer_ServerClick(sender As Object, e As EventArgs) Handles btn_update_customer.ServerClick

    End Sub

    Private Sub Btn_Cancel_ServerClick(sender As Object, e As EventArgs) Handles Btn_Cancel.ServerClick
        Response.Redirect("inbox.aspx")
    End Sub

    Sub interaction()
        Dim strInteraction As String = "Select *,  mkaryawan.Name from tInteraction inner join mkaryawan on tInteraction.AgentCreate = mkaryawan.NIK where tInteraction.TicketNumber='" & lbl_ticket_number.Text & "' "
        Try
            sqldr = Proses.ExecuteReader(strInteraction)
            While sqldr.Read()
                tampungan &= "<li class='right clearfix'> " & _
                                    "<span class='chat-img pull-right'> " & _
                                            "<img src='img/user.jpg' alt=User Avatar'> " & _
                                        "</span> " & _
                                    "<div class='chat-body clearfix'>" & _
                                        "<div class='header'>" & _
                                            "<strong class='primary-font'>" & sqldr("Name").ToString & "</strong>" & _
                                            "<small class='pull-right text-muted'><i class='fa fa-clock-o'></i>" & sqldr("DateCreate").ToString & "</small>" & _
                                        "</div>" & _
                                        "<p> " & sqldr("ResponseComplaint").ToString & " </p>" & _
                                    "</div>" & _
                                "</li>"
            End While
            sqldr.Close()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
        interaction_agent.Text = tampungan
    End Sub
End Class