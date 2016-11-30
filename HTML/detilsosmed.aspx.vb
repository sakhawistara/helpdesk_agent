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
Imports System.Windows.Forms
Imports System.Linq
Imports System.IO
Imports ICC.ClsConn
Imports DevExpress.Web.ASPxHtmlEditor
Public Class detilsosmed
    Inherits System.Web.UI.Page

    Dim sqlCon As New SqlConnection(ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString)
    Dim Con As New SqlConnection(ConfigurationManager.ConnectionStrings("SosmedConnection").ConnectionString)
    Dim Com, Comm, Cmd As SqlCommand
    Dim Dr, reader, sqldr As SqlDataReader
    Dim commentID, replyID, messageID, dmID As String
    Dim Con1 As New SqlConnection(ConfigurationManager.ConnectionStrings("SosmedConnection").ConnectionString)
    Dim sqlconn As New SqlConnection(ConfigurationManager.ConnectionStrings("SosmedConnection").ConnectionString)
    Dim Com1, comInsert, comUpdate As SqlCommand
    Dim Dr1 As SqlDataReader
    Dim conn As SqlConnection
    Dim connection As New ClsConn
    Dim connectionString As String = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
    Dim TicketNo As String = ""
    Dim sql As String = ""
    Dim statusTicket As String = ""
    Dim Createlog As New ClsConn
    Dim NotEmailSend As New ClsConn
    Dim Proses As New ClsConn
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
    Dim log As New ClsConn
    Dim strInsert, strUpdate As String

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
        If Request.QueryString("ket") = "Email" Then
            Channel_Email()
        ElseIf Request.QueryString("ket") = "Sms" Then
            Channel_Sms()
        ElseIf Request.QueryString("ket") = "Facebook" Then
            Channel_Facebook()
        ElseIf Request.QueryString("ket") = "Twitter" Then
            Channel_Twitter()
        ElseIf Request.QueryString("ket") = "Chat" Then
            Response.Redirect("chat.aspx?id=" & Request.QueryString("id") & "")
        End If
        hprlink.Visible = True
        hprlink.NavigateUrl = "inbox.aspx"
        lbl_link.Text = "Todolist"


        'conversation
        Dim tampungan As String = ""
        Dim alldata As String = ""
        Dim selecthistory As String = "Select ROW_NUMBER() over(order by ddate Desc)as No, idTbl,  Name, TextNya, ddate, dSource, flagread, agent_handle From ( " & _
                                    "Select P_ddate as ddate, P_ID_Post as idTbl, P_User_Name as Name, P_Message as TextNya, P_flagread as flagread ,dSource, P_agent_handle as agent_handle from GetSosmed_One " & _
                                    "UNION " & _
                                    "Select C_ddate as ddate, C_ID_Post as idTbl, C_User_Name as Name, C_Message as TextNya, C_flagread as flagread, dSource, C_agent_handle as agent_handle from GetSosmed_Two " & _
                                    "UNION " & _
                                    "Select R_ddate as ddate, R_ID_Post as idTbl, R_User_name as Name, R_Message as TextNya, R_flagread as flagread, dSource, R_agent_handle as agent_handle from GetSosmed_Three " & _
                                    "UNION " & _
                                    "select tTime as ddate, id_Chat as idTbl, tfrom as Name, tMessage as TextNya, flag_Read as flagread, 'inbox' as dSource, agent_handle from GetSosmed_Inbox ) " & _
                                    "as a " & _
                                    "WHERE flagread = '1' and Name ='" & Request.QueryString("Name") & "'" & _
                                    "order by  ddate desc"

        Com = New SqlCommand(selecthistory, Con)
        Con.Open()
        Dr = Com.ExecuteReader()
        While Dr.Read()
            alldata &= "<tr>" & _
                       "<td>" & _
                           "<a href='#' class='task-del'>" & Dr("No").ToString & "</a>" & _
                       "</td>" & _
                       "<td>" & Dr("dSource").ToString & "</td>" & _
                       "<td>" & Dr("ddate").ToString & "</td>" & _
                       "</tr>"
            tampungan &= "<li class='left clearfix'> " & _
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
                    tampungan &= "<li class='right clearfix'> " & _
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
        showhistory.Text = tampungan
        trxticket.Text = alldata
        'End Conversation
    End Sub

    Function fmention(ByVal id As String, ByVal Name As String)

        txt_message.Visible = False
        Dim selectdetil As String = "select SUBSTRING(dSource, 1, 2) AS Channel, * from getSosmed_one where P_ID_Post = '" & id & "' and P_User_Name = '" & Name & "'"
        Com = New SqlCommand(selectdetil, Con)
        Con.Open()
        Dr = Com.ExecuteReader()
        Try
            Dr.Read()
            lbl_nama_customer.Text = Name
            lbl_message.Text = highlightText(Dr("P_Message").ToString)
            lbl_date.Text = Dr("P_ddate").ToString
            If Dr("Channel").ToString = "fb" Then
                SourceCategori.SelectCommand = "select * from mSubCategoryLv1 where SubName = 'FB'"
            Else
                SourceCategori.SelectCommand = "select * from mSubCategoryLv1 where SubName = 'TW'"
            End If

        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
        Dr.Close()
        Con.Close()
        lbl_pic_customer.Text = Name
        lbl_customer.Text = Name
    End Function

    Function fheader(ByVal id As String, ByVal Name As String)
        txt_message.Visible = False
        Dim selectdetil As String = "select SUBSTRING(dSource, 1, 2) AS Channel, * from getSosmed_one where P_ID_Post = '" & id & "' and P_User_Name = '" & Name & "'"
        Com = New SqlCommand(selectdetil, Con)
        Con.Open()
        Dr = Com.ExecuteReader()
        Try
            Dr.Read()
            lbl_nama_customer.Text = Name
            lbl_message.Text = highlightText(Dr("P_Message").ToString)
            lbl_date.Text = Dr("P_ddate").ToString
            If Dr("Channel").ToString = "fb" Then
                SourceCategori.SelectCommand = "select * from mSubCategoryLv1 where SubName = 'FB'"
            Else
                SourceCategori.SelectCommand = "select * from mSubCategoryLv1 where SubName = 'TW'"
            End If
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
        Dr.Close()
        Con.Close()
        lbl_pic_customer.Text = Name
        lbl_customer.Text = Name
    End Function

    Function fcomment(ByVal id As String, ByVal Name As String)

        txt_message.Visible = False
        Dim selectdetil As String = "select SUBSTRING(dSource, 1, 2) AS Channel, * from GetSosmed_Two where C_ID_Post = '" & id & "' and C_User_Name = '" & Name & "'"
        Com = New SqlCommand(selectdetil, Con)
        Con.Open()
        Dr = Com.ExecuteReader()
        Try
            Dr.Read()
            lbl_nama_customer.Text = Name
            lbl_message.Text = Dr("C_Message").ToString
            lbl_date.Text = Dr("C_ddate").ToString
            If Dr("Channel").ToString = "fb" Then
                SourceCategori.SelectCommand = "select * from mSubCategoryLv1 where SubName = 'FB'"
            Else
                SourceCategori.SelectCommand = "select * from mSubCategoryLv1 where SubName = 'TW'"
            End If
            commentID = Dr("P_ID_Post").ToString
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
        Dr.Close()
        Con.Close()
        lbl_pic_customer.Text = Name
        lbl_customer.Text = Name
    End Function

    Function freply(ByVal id As String, ByVal Name As String)

        txt_message.Visible = False
        Dim selectdetil As String = "select SUBSTRING(dSource, 1, 2) AS Channel, * from GetSosmed_Three where R_ID_Post = '" & id & "' and R_User_name = '" & Name & "'"
        Com = New SqlCommand(selectdetil, Con)
        Con.Open()
        Dr = Com.ExecuteReader()
        Try
            Dr.Read()
            lbl_nama_customer.Text = Name
            lbl_message.Text = Dr("R_Message").ToString
            lbl_date.Text = Dr("R_ddate").ToString
            If Dr("Channel").ToString = "fb" Then
                SourceCategori.SelectCommand = "select * from mSubCategoryLv1 where SubName = 'FB'"
            Else
                SourceCategori.SelectCommand = "select * from mSubCategoryLv1 where SubName = 'TW'"
            End If
            replyID = Dr("C_ID_Post").ToString
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
        Dr.Close()
        Con.Close()
        lbl_pic_customer.Text = Name
        lbl_customer.Text = Name
    End Function

    Function finbox(ByVal id As String, ByVal Name As String)
        txt_message.Visible = False
        Dim selectdetil As String = "select * from getsosmed_inbox where id_Chat = '" & id & "' and tfrom = '" & Name & "'"
        Com = New SqlCommand(selectdetil, Con)
        Con.Open()
        Dr = Com.ExecuteReader()
        Try
            Dr.Read()
            lbl_nama_customer.Text = Name
            lbl_message.Text = highlightText(Dr("P_Message").ToString)
            lbl_date.Text = Dr("P_ddate").ToString
            SourceCategori.SelectCommand = "select * from mSubCategoryLv1 where SubName = 'FB'"
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
        Dr.Close()
        Con.Close()
        lbl_pic_customer.Text = Name
        lbl_customer.Text = Name
    End Function

    Function fdm(ByVal id As String, ByVal Name As String)
        txt_message.Visible = False
        Dim selectdetil As String = "select SUBSTRING(dSource, 1, 2) AS Channel, * from getSosmed_one where P_ID_Post = '" & id & "' and P_User_Name = '" & Name & "'"
        Com = New SqlCommand(selectdetil, Con)
        Con.Open()
        Dr = Com.ExecuteReader()
        Try
            Dr.Read()
            lbl_nama_customer.Text = Name
            lbl_message.Text = highlightText(Dr("P_Message").ToString)
            lbl_date.Text = Dr("P_ddate").ToString
            If Dr("Channel").ToString = "fb" Then
                SourceCategori.SelectCommand = "select * from mSubCategoryLv1 where SubName = 'FB'"
            Else
                SourceCategori.SelectCommand = "select * from mSubCategoryLv1 where SubName = 'TW'"
            End If

        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
        Dr.Close()
        Con.Close()
        lbl_pic_customer.Text = Name
        lbl_customer.Text = Name
    End Function

    Sub get_Dropdown()
        SourceCategori.SelectCommand = "select * from mCategory where NA='Y'"
        sql_group_type.SelectCommand = "select * from mGroupType"
        sql_status.SelectCommand = "select * from mstatus"
        If Session("LoginTypeSbg") = "Administrator" Or Session("leveluser") = "Supervisor" Then
            Div_Button.Visible = False
        Else
            Div_Button.Visible = True
        End If
        cmb_status.Value = "Open"
    End Sub

    Private Sub callbackPanelX_Callback(sender As Object, e As DevExpress.Web.ASPxClasses.CallbackEventArgsBase) Handles callbackPanelX.Callback
        Dim Response_agent As String
        If mCatID.Value = "Refresh" Then
            Category.Value = ""
            SubCategoryI.Value = ""
            SubCategoryII.Value = ""
            SubCategoryIII.Value = ""
        Else
            If SubCategoryIII.Text <> "" Then
                div_sla.Visible = True
                Dim erroCode, ExCat, Categori, Cat1, Sub1, Sub2, SubCategory1, SubCategory2, PriorityValue, SeverityValue, ValueSLA, SubCategory3 As String
                ExCat = " SELECT dbo.mCategory.*, dbo.mSubCategoryLv1.*,dbo.mSubCategoryLv1.SubName AS SubName1, dbo.mSubCategoryLv2.SubName AS SubName2, dbo.mSubCategoryLv3.* " & _
                        " FROM dbo.mCategory INNER JOIN " & _
                        " dbo.mSubCategoryLv1 ON dbo.mCategory.CategoryID = dbo.mSubCategoryLv1.CategoryID INNER JOIN " & _
                        " dbo.mSubCategoryLv2 ON dbo.mSubCategoryLv1.SubCategory1ID = dbo.mSubCategoryLv2.SubCategory1ID INNER JOIN " & _
                        " dbo.mSubCategoryLv3 ON dbo.mSubCategoryLv2.SubCategory2ID = dbo.mSubCategoryLv3.SubCategory2ID " & _
                        " where dbo.mSubCategoryLv3.SubCategory3ID = '" & mCatID.Value & "'"
                Com = New SqlCommand(ExCat, sqlCon)
                sqlCon.Open()
                Dr = Com.ExecuteReader()
                Dr.Read()
                Categori = Dr("Name").ToString
                SubCategory1 = Dr("SubName1").ToString
                SubCategory2 = Dr("SubName2").ToString
                SubCategory3 = Dr("SubName").ToString
                cmb_priority.Text = Dr("Priority").ToString
                cmb_severity.Text = Dr("Severity").ToString
                Cat1 = Dr("CategoryID").ToString
                Sub1 = Dr("SubCategory1ID").ToString
                Sub2 = Dr("SubCategory2ID").ToString
                ValueSLA = Dr("SLA").ToString
                Response_agent = Dr("Response_Agent").ToString
                erroCode = Dr("IDKamus").ToString
                Dr.Close()
                sqlCon.Close()
                Category.Value = Categori
                SubCategoryI.Value = SubCategory1
                SubCatI.Value = Sub1
                SubCatII.Value = Sub2
                'CategoryHidden.Value = Cat1
                SubCategoryII.Value = SubCategory2
                hd_sla.Value = ValueSLA.ToString
                lbl_sla.Text = hd_sla.Value
                IDKamus.Value = erroCode.ToString

                'Btn_Update.Visible = False
                'btn_dispatch.Visible = False
            ElseIf Category.Text <> "" Then
                Dim Categori As String
                sql = "Select  * from mcategory where CategoryID ='" & mCatID.Value & "' and NA = 'Y'"
                sqldr = Proses.ExecuteReader(sql)
                If sqldr.Read() Then
                    Categori = sqldr("CategoryID")
                End If
                sqldr.Close()
                SourceCategoriIII.SelectCommand = "Select  * from mSubCategoryLv3 where CategoryID ='" & Categori & "' and NA = 'Y'"
            End If
        End If
    End Sub

    Private Sub btnsent_Click(sender As Object, e As EventArgs) Handles btnsent.ServerClick
        Save()       
        ASPxHtmlEditor1.Html = ""
    End Sub

    Sub Simpan()
        btnsent.Visible = False
        Dim Time As String = DateTime.Now.ToString("yyyyMMddhhmmss")
        Dim FilePath As String = ConfigurationManager.AppSettings("FilePath").ToString()
        Dim FileFullPath As String = ConfigurationManager.AppSettings("FileFullPath").ToString()
        Dim blSucces As Boolean = False
        Dim filename As String = String.Empty
        'To check whether file is selected or not to uplaod
        If uploadfile.HasFile Then
            Try
                Dim allowdFile As String() = {".jpg", ".xls", ".pdf", ".doc", ".docx", ".xlsx", ".flv", ".mkv", ".avi", ".mp4", ".mp3", ".png", ".951"}
                'Here we are allowing only pdf file so verifying selected file pdf or not
                Dim FileExt As String = System.IO.Path.GetExtension(uploadfile.PostedFile.FileName)
                Dim isValidFile As Boolean = allowdFile.Contains(FileExt)
                If Not isValidFile Then
                    'ASPxLabel2.ForeColor = System.Drawing.Color.Red
                    'ASPxLabel2.Text = "Please upload only jpg "
                Else
                    ' Get size of uploaded file, here restricting size of file
                    Dim FileSize As Integer = uploadfile.PostedFile.ContentLength
                    If FileSize <= 1073741824 Then
                        '1048576 byte = 1MB
                        'Get file name of selected file
                        filename = Path.GetFileName(String.Format("{0}_{1}", Time, uploadfile.FileName))
                        'Save selected file into specified location
                        uploadfile.SaveAs(Server.MapPath(FilePath) & filename)
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

        Dim NIK As String
        Dim SCustomer As String = "select * from mCustomer Where Facebook='" & Request.QueryString("Name") & "' or Twitter='" & Request.QueryString("Name") & "' or NetworkSocial='" & Request.QueryString("Name") & "'"
        Com = New SqlCommand(SCustomer, sqlCon)
        sqlCon.Open()
        sqldr = Com.ExecuteReader
        If sqldr.Read() Then
            NIK = sqldr("CustomerID").ToString
        End If
        sqldr.Close()
        sqlCon.Close()

        Dim Attch As String
        If filename <> "" Then
            Attch = FileFullPath & filename
        Else
            Attch = "Attchment Kosong"
        End If
        conn = New SqlConnection(connectionString)
        Comm = New SqlCommand()
        Comm.Connection = conn
        Comm.CommandType = CommandType.StoredProcedure
        Comm.CommandText = "GENERATE_SOSMED"
        Comm.Parameters.Add("@nik", NIK)
        Comm.Parameters.Add("@sourcetype", cmb_source_type.Value)
        Comm.Parameters.Add("@sourcetypeName", cmb_source_type.Text)
        Comm.Parameters.Add("@grouptype", cmb_group_type.Value)
        Comm.Parameters.Add("@grouptypeName", cmb_group_type.Text)
        'Comm.Parameters.Add("@categoryID", cbcategory.Value)
        'Comm.Parameters.Add("@categoryName", cbcategory.Text)
        'Comm.Parameters.Add("@subCategory1ID", cbsubkeyword.Value)
        'Comm.Parameters.Add("@SubCategory1Name", cbsubkeyword.Text)
        If lbl_message.Text <> "" Then
            Comm.Parameters.Add("@detailComplaint", lbl_message.Text)
        Else
            Comm.Parameters.Add("@detailComplaint", ReplaceSpecialLetter(txt_message.Text))
        End If
        Comm.Parameters.Add("@responseComplaint", ASPxHtmlEditor1.Html)
        Comm.Parameters.Add("@status", cmb_status.Text)
        Comm.Parameters.Add("@dateAgentResponse", waktu)
        Comm.Parameters.Add("@userCreate", Session("UserName"))
        Comm.Parameters.Add("@attch", Attch)
        Try
            conn.Open()
            reader = Comm.ExecuteReader()
            reader.Read()
            TicketNo = reader(0)
            reader.Close()
            conn.Close()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub

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
            If uploadfile.HasFile Then
                Try
                    Dim allowdFile As String() = {".jpg", ".xls", ".pdf", ".doc", ".docx", ".xlsx", ".flv", ".mkv", ".avi", ".mp4", ".mp3", ".png", ".951"}
                    'Here we are allowing only pdf file so verifying selected file pdf or not
                    Dim FileExt As String = System.IO.Path.GetExtension(uploadfile.PostedFile.FileName)
                    Dim isValidFile As Boolean = allowdFile.Contains(FileExt)
                    If Not isValidFile Then
                        'ASPxLabel2.ForeColor = System.Drawing.Color.Red
                        'ASPxLabel2.Text = "Please upload only jpg "
                    Else
                        ' Get size of uploaded file, here restricting size of file
                        Dim FileSize As Integer = uploadfile.PostedFile.ContentLength
                        If FileSize <= 1073741824 Then
                            '1048576 byte = 1MB
                            'Get file name of selected file
                            filename = Path.GetFileName(String.Format("{0}_{1}", Time, uploadfile.FileName))
                            'Save selected file into specified location
                            uploadfile.SaveAs(Server.MapPath(FilePath) & filename)
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

            Dim Posting As String
            If chk_posting.Checked = True Then
                Posting = "YES"
            Else
                Posting = "NO"
            End If

            Dim Attch As String
            If filename <> "" Then
                Attch = FileFullPath & filename
            Else
                Attch = "Attchment Kosong"
            End If
            Dim NIK As String = hd_nik.Value
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
            Comm.Parameters.Add("@detailComplaint", Data.SqlDbType.VarChar).Value = ReplaceSpecialLetter(lbl_message.Text)
            Comm.Parameters.Add("@responseComplaint", Data.SqlDbType.VarChar).Value = ReplaceSpecialLetter(ASPxHtmlEditor1.Html)
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
            Comm.Parameters.Add("@posting", Data.SqlDbType.VarChar).Value = Posting
            Try
                conn.Open()
                reader = Comm.ExecuteReader()
                reader.Read()
                TicketNo = reader(0)
                reader.Close()
                conn.Close()
            Catch ex As Exception
                Response.Write(ex.Message)
            End Try

            If chk_posting.Checked = True Then
                Reply_Posting(cmb_source_type.Value, TicketNo, ReplaceSpecialLetter(ASPxHtmlEditor1.Html), NIK)
            Else

            End If

            If Request.QueryString("Ket") = "Twitter" Or Request.QueryString("Ket") = "Facebook" Then
                update_sosmed()
            Else

            End If

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
                            "<tr><td style=font-weight:bold>Detail Complaint</td><td>:</td><td>" & lbl_message.Text & "</td></tr>" & _
                            "<tr><td style=font-weight:bold>Response</td><td>:</td><td>" & ASPxHtmlEditor1.Html & "</td></tr>" & _
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
            If uploadfile.HasFile Then
                Try
                    Dim allowdFile As String() = {".jpg", ".xls", ".pdf", ".doc", ".docx", ".xlsx", ".flv", ".mkv", ".avi", ".mp4", ".mp3", ".png", ".951"}
                    'Here we are allowing only pdf file so verifying selected file pdf or not
                    Dim FileExt As String = System.IO.Path.GetExtension(uploadfile.PostedFile.FileName)
                    Dim isValidFile As Boolean = allowdFile.Contains(FileExt)
                    If Not isValidFile Then
                        'ASPxLabel2.ForeColor = System.Drawing.Color.Red
                        'ASPxLabel2.Text = "Please upload only jpg "
                    Else
                        ' Get size of uploaded file, here restricting size of file
                        Dim FileSize As Integer = uploadfile.PostedFile.ContentLength
                        If FileSize <= 1073741824 Then
                            '1048576 byte = 1MB
                            'Get file name of selected file
                            filename = Path.GetFileName(String.Format("{0}_{1}", Time, uploadfile.FileName))
                            'Save selected file into specified location
                            uploadfile.SaveAs(Server.MapPath(FilePath) & filename)
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
            Dim Posting As String
            If chk_posting.Checked = True Then
                Posting = "YES"
            Else
                Posting = "NO"
            End If

            Dim NIK As String = hd_nik.Value
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
            Comm.Parameters.Add("@categoryID", Data.SqlDbType.VarChar).Value = Category.Value
            Comm.Parameters.Add("@categoryName", Data.SqlDbType.VarChar).Value = Category.Text
            Comm.Parameters.Add("@subCategory1ID", Data.SqlDbType.VarChar).Value = SubCatI.Value
            Comm.Parameters.Add("@SubCategory1Name", Data.SqlDbType.VarChar).Value = SubCategoryI.Text
            Comm.Parameters.Add("@subCategory2ID", Data.SqlDbType.VarChar).Value = SubCatII.Value
            Comm.Parameters.Add("@SubCategory2Name", Data.SqlDbType.VarChar).Value = SubCategoryII.Text
            Comm.Parameters.Add("@subCategory3ID", Data.SqlDbType.VarChar).Value = SubCategoryIII.Value
            Comm.Parameters.Add("@SubCategory3Name", Data.SqlDbType.VarChar).Value = SubCategoryIII.Text
            Comm.Parameters.Add("@detailComplaint", Data.SqlDbType.VarChar).Value = ReplaceSpecialLetter(lbl_message.Text)
            Comm.Parameters.Add("@responseComplaint", Data.SqlDbType.VarChar).Value = ReplaceSpecialLetter(ASPxHtmlEditor1.Html)
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
            Comm.Parameters.Add("@posting", Data.SqlDbType.VarChar).Value = Posting
            Try
                conn.Open()
                reader = Comm.ExecuteReader()
                reader.Read()
                TicketNo = reader(0)
                reader.Close()
                conn.Close()
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

            If chk_posting.Checked = True Then
                Reply_Posting(cmb_source_type.Value, TicketNo, ReplaceSpecialLetter(ASPxHtmlEditor1.Html), NIK)
            Else

            End If

            If Request.QueryString("Ket") = "Twitter" Or Request.QueryString("Ket") = "Facebook" Then
                update_sosmed()
            Else

            End If

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
                        "<tr><td style=font-weight:bold>Detail Complaint</td><td>:</td><td>" & lbl_message.Text & "</td></tr>" & _
                        "<tr><td style=font-weight:bold>Response</td><td>:</td><td>" & ASPxHtmlEditor1.Html & "</td></tr>" & _
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
            modal_dispatch_satu.Visible = True
            lbl_message.Text = txt_message.Text
            txt_message.Visible = False
            lbl_sla.Text = hd_sla.Value
            lbl_ticket_number.Text = TicketNo
        End If
        sql_user_dispatch_source()
        lbl_red.Visible = True
        btncancel.Visible = False
    End Sub

    Sub sql_user_dispatch_source()
        sql = "select * from tticket where TicketNumber='" & lbl_ticket_number.Text & "'"
        sqldr = Proses.ExecuteReader(sql)
        If sqldr.HasRows Then
            sqldr.Read()
            HD_Posisi.Value = sqldr("TicketPosition").ToString
        End If
        sqldr.Close()
        sql_cmb_Personal_Support.SelectCommand = "select distinct msUser.NIK, mKaryawan.Name from msUser inner join mKaryawan on msUser.NIK = mKaryawan.NIK where msUser.LevelUser = 'Caseunit'"
    End Sub

    Public Function updateFlagEmail(ByVal NoTicket As String) As String
        Dim UpdateCekMailKirim As String
        UpdateCekMailKirim = "UPDATE tTicket set KirimEmail='YES' where TicketNumber='" & NoTicket & "'"
        com = New SqlCommand(UpdateCekMailKirim, sqlcon)
        sqlcon.Open()
        com.ExecuteNonQuery()
        sqlcon.Close()
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

    Sub button_download()
        Dim Attch As String = ""
        sql = "select * from tticket where TicketNumber='" & lbl_ticket_number.Text & "'"
        sqldr = Proses.ExecuteReader(sql)
        If sqldr.HasRows Then
            sqldr.Read()
            Attch = sqldr("Attch").ToString
        End If
        sqldr.Close()
        Response.Redirect("D:\ICC\ICC\HTML\Upload\20161114031037_DSR.xlsx")
    End Sub

    Sub layer1()
        Dim TicketIDNumber As String = Request.QueryString("tid")
        Dim NIKToDoList As String = Request.QueryString("NIK")
        Dim PertanyaanToDolist As String = Request.QueryString("Pertanyaan")
        Dim DateToDolist As String = Request.QueryString("DateCreate")
        ASPxHtmlEditor1.Visible = True
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
                lbl_nama_customer.Text = dr("NamaPerusahaan").ToString
                lbl_customer.Text = dr("NamaPerusahaan").ToString
                lbl_pic_customer.Text = dr("NamePIC").ToString
                lbl_alamat_perusahaan.Text = dr("Alamat").ToString
                lbl_email.Text = dr("Email").ToString
                lbl_phone.Text = dr("Telepon").ToString
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
                Path_Ticket.Value = dr("Attch").ToString
                If dr("Attch").ToString = "" Then
                    uploadfile.Visible = True
                Else
                    uploadfile.Visible = False
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
        btnsent.Visible = False
        lbl_red.Visible = True
        ASPxHtmlEditor1.Visible = True
        modal_dispatch_satu.Visible = False
        sql_status.SelectCommand = "select * from mstatus"
        sql = "select * from mcustomer where customerid='" & Request.QueryString("NIK") & "'"
        sqldr = Proses.ExecuteReader(sql)
        If sqldr.HasRows Then
            sqldr.Read()
            txt_customer_name.Text = sqldr("NamaPerusahaan").ToString
            txt_address.Text = sqldr("Alamat").ToString
            txt_email.Text = sqldr("email").ToString
            txt_phone1.Text = sqldr("Office").ToString
            txt_phone2.Text = sqldr("NomorHPPIC").ToString
            txt_customer_name.Enabled = False
        End If
        hprlink.Visible = True
        hprlink.NavigateUrl = "inbox.aspx"
        lbl_link.Text = "Todolist"
    End Sub

    Private Sub Channel_Sosmed()
        If Request.QueryString("ket") = "fb_Post" Then
            cmb_source_type.Value = "Facebook"
        ElseIf Request.QueryString("ket") = "fb_comment" Then
            cmb_source_type.Value = "Facebook"
        ElseIf Request.QueryString("ket") = "twMention" Then
            cmb_source_type.Value = "Twitter"
        End If
        modal_dispatch_satu.Visible = False

        Dim tampungan As String = ""
        Dim alldata As String = ""

        If Request.QueryString("ket") = "twMention" Then
            fmention(Request.QueryString("id"), Request.QueryString("Name"))
        ElseIf Request.QueryString("ket") = "fb_Post" Then
            fheader(Request.QueryString("id"), Request.QueryString("Name"))
        ElseIf Request.QueryString("ket") = "fb_comment" Then
            fcomment(Request.QueryString("id"), Request.QueryString("Name"))
        ElseIf Request.QueryString("ket") = "fb_reply" Then
            freply(Request.QueryString("id"), Request.QueryString("Name"))
        ElseIf Request.QueryString("ket") = "Inbox Facebook" Then
            finbox(Request.QueryString("id"), Request.QueryString("Name"))
        ElseIf Request.QueryString("ket") = "tw_DM" Then
            fdm(Request.QueryString("id"), Request.QueryString("Name"))
        End If

        get_Dropdown()
        Dim selecthistory As String = "Select ROW_NUMBER() over(order by ddate Desc)as No, idTbl,  Name, TextNya, ddate, dSource, flagread, agent_handle From ( " & _
                                    "Select P_ddate as ddate, P_ID_Post as idTbl, P_User_Name as Name, P_Message as TextNya, P_flagread as flagread ,dSource, P_agent_handle as agent_handle from GetSosmed_One " & _
                                    "UNION " & _
                                    "Select C_ddate as ddate, C_ID_Post as idTbl, C_User_Name as Name, C_Message as TextNya, C_flagread as flagread, dSource, C_agent_handle as agent_handle from GetSosmed_Two " & _
                                    "UNION " & _
                                    "Select R_ddate as ddate, R_ID_Post as idTbl, R_User_name as Name, R_Message as TextNya, R_flagread as flagread, dSource, R_agent_handle as agent_handle from GetSosmed_Three " & _
                                    "UNION " & _
                                    "select tTime as ddate, id_Chat as idTbl, tfrom as Name, tMessage as TextNya, flag_Read as flagread, 'inbox' as dSource, agent_handle from GetSosmed_Inbox ) " & _
                                    "as a " & _
                                    "WHERE flagread = '1' and Name ='" & Request.QueryString("Name") & "'" & _
                                    "order by  ddate desc"

        Com = New SqlCommand(selecthistory, Con)
        Con.Open()
        Dr = Com.ExecuteReader()
        While Dr.Read()
            alldata &= "<tr>" & _
                       "<td>" & _
                           "<a href='#' class='task-del'>" & Dr("No").ToString & "</a>" & _
                       "</td>" & _
                       "<td>" & Dr("dSource").ToString & "</td>" & _
                       "<td>" & Dr("ddate").ToString & "</td>" & _
                       "</tr>"
            tampungan &= "<li class='left clearfix'> " & _
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
                    tampungan &= "<li class='right clearfix'> " & _
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
        showhistory.Text = tampungan
        trxticket.Text = alldata

    End Sub

    Private Sub Channel_Email()
        Dim ESUBJECT, EBODY As String
        sql = "select * from ICC_EMAIL_IN  LEFT OUTER JOIN mCustomer ON ICC_EMAIL_IN.EFROM = mCustomer.Email where IVC_ID='" & Request.QueryString("id") & "'"
        sqldr = Proses.ExecuteReader(sql)
        If sqldr.Read Then
            hd_nik.Value = sqldr("CustomerID").ToString
            lbl_message.Text = sqldr("EBODY").ToString
            lbl_customer.Text = sqldr("NamaPerusahaan").ToString
            lbl_pic_customer.Text = sqldr("NamePIC").ToString
            lbl_nama_customer.Text = sqldr("NamaPerusahaan").ToString
            lbl_alamat_perusahaan.Text = sqldr("Alamat").ToString
            lbl_phone.Text = sqldr("Telepon").ToString
            lbl_email.Text = sqldr("Email").ToString
        End If
        sqldr.Close()
        cmb_source_type.Value = "Email"
        get_Dropdown()
        txt_message.Visible = False
        modal_dispatch_satu.Visible = False
        div_sla.visible = False
    End Sub

    Private Sub Channel_Sms()
        Dim ESUBJECT, EBODY As String
        sql = "select * from ICC_SMSInput LEFT OUTER JOIN mCustomer ON ICC_SMSInput.PhoneSender = mCustomer.HP where ICC_SMSInput.MessageID='" & Request.QueryString("id") & "'"
        sqldr = Proses.ExecuteReader(sql)
        If sqldr.Read Then
            hd_nik.Value = sqldr("CustomerID").ToString
            lbl_message.Text = sqldr("Message").ToString
            lbl_customer.Text = sqldr("NamaPerusahaan").ToString
            lbl_pic_customer.Text = sqldr("NamePIC").ToString
            lbl_nama_customer.Text = sqldr("NamaPerusahaan").ToString
            lbl_alamat_perusahaan.Text = sqldr("Alamat").ToString
            lbl_phone.Text = sqldr("Telepon").ToString
            lbl_email.Text = sqldr("Email").ToString
        End If
        sqldr.Close()
        cmb_source_type.Value = "Sms"
        get_Dropdown()
        txt_message.Visible = False
        modal_dispatch_satu.Visible = False
        div_sla.Visible = False
    End Sub

    Private Sub Channel_Facebook()       
        div_sla.Visible = False
        Try
            Dim selectfacebook As String = "select * from v_allsosmed where idTbl = '" & Request.QueryString("IDREF") & "'"
            Com = New SqlCommand(selectfacebook, Con)
            Con.Open()
            Dr = Com.ExecuteReader()
            Dr.Read()
            lbl_nama_customer.Text = Dr("Name").ToString
            lbl_customer.Text = Dr("Name").ToString
            lbl_date.Text = Dr("ddate").ToString
            lbl_message.Text = Dr("TextNya").ToString
            Session("source") = Dr("dSource").ToString
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
        Dr.Close()
        Con.Close()
        cmb_source_type.Value = "Facebook"
        get_Dropdown()
        txt_message.Visible = False
        modal_dispatch_satu.Visible = False
        div_sla.Visible = False
    End Sub

    Private Sub Channel_Twitter()
        div_sla.Visible = False
        Try
            Dim selectfacebook As String = "select * from v_allsosmed where idTbl = '" & Request.QueryString("IDREF") & "'"
            Com = New SqlCommand(selectfacebook, Con)
            Con.Open()
            Dr = Com.ExecuteReader()
            Dr.Read()
            lbl_nama_customer.Text = Dr("Name").ToString
            lbl_customer.Text = Dr("Name").ToString
            lbl_date.Text = Dr("ddate").ToString
            lbl_message.Text = Dr("TextNya").ToString
            Session("source") = Dr("dSource").ToString
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
        Dr.Close()
        Con.Close()
        cmb_source_type.Value = "Twitter"
        get_Dropdown()
        txt_message.Visible = False
        modal_dispatch_satu.Visible = False
        div_sla.Visible = False
    End Sub

    Function Reply_Posting(ByVal Type As String, ByVal TicketNumber As String, ByVal Message As String, ByVal Account As String)
        Dim Direction As String = "in"
        Dim PhoneSender As String = "085710002311"
        Dim SqlInsert As String
        If Type = "Email" Then
            'insertTable("ICC_EMAIL_OUT", "DIRECTION,EFROM,ETO,EBODY,Email_Date", "" & Direction & "," & EmailForm & "," & lbl_email.Text & "," & Message & ", getdate()")
            SqlInsert = "INSERT INTO ICC_EMAIL_OUT(DIRECTION,EFROM,ETO,EBODY,Email_Date) VALUES ('" & Direction & "','" & EmailForm & "','" & lbl_email.Text & "','" & Message & "', getdate())"
            Com = New SqlCommand(SqlInsert, sqlCon)
            Try
                sqlCon.Open()
                Com.ExecuteNonQuery()
                sqlCon.Close()
            Catch ex As Exception
                Response.Write(ex.Message)
            End Try

        ElseIf Type = "Sms" Then
            SqlInsert = "INSERT INTO ICC_SMSOutput(MESSAGE,PHONEDESTINATION,PHONESENDER) VALUES ('" & ReplaceSpecialLetter(ASPxHtmlEditor1.Html) & "','" & lbl_phone.Text & "','" & PhoneSender & "')"
            Com = New SqlCommand(SqlInsert, sqlCon)
            Try
                sqlCon.Open()
                Com.ExecuteNonQuery()
                sqlCon.Close()
            Catch ex As Exception
                Response.Write(ex.Message)
            End Try
            'insertTable("ICC_SMSOutput", "MESSAGEID,MESSAGE,PHONEDESTINATION,PHONESENDER", "" & Request.QueryString("id") & "," & ReplaceSpecialLetter(ASPxHtmlEditor1.Html) & "," & lbl_phone.Text & "," & PhoneSender & "")
        ElseIf Type = "Facebook" Then

        ElseIf Type = "Twitter" Then

        End If
    End Function

    Private Sub btn_dispatch_ServerClick(sender As Object, e As EventArgs) Handles btn_dispatch.ServerClick
        ' log gagal insert dispatch
        log.writedata("--Start--")
        log.writedata("UserName/Date : " & Session("UserName") & "/" & DateTime.Now)
        log.writedata("Ticket Number: " & lbl_ticket_number.Text)

        sql = "select * from tTicket where TicketNumber='" & lbl_ticket_number.Text & "'"
        Try
            sqldr = Proses.ExecuteReader(sql)
            If sqldr.HasRows Then
                sqldr.Read()
                statusTicket = Dr("Status").ToString
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
        comInsert = New SqlCommand(strInsert, sqlCon)
        Try
            sqlCon.Open()
            comInsert.ExecuteNonQuery()
        Catch ex As Exception
            log.writedata(DateTime.Now() & "-Error Insert tDIspatch Agent ke CU: " & ex.Message())
        Finally
            sqlCon.Close()
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
            strUpdate = "update tTicket set TicketPosition='" & posisiTiketTerakhir & "', dispatch_user='" & cmb_Personal_Support.Value & "', Status='progress' where TicketNumber ='" & lbl_ticket_number.Text & "'"
            'send_email(cmb_user_dispatch.Value, lbl_ticket_number.Text)
        Else

        End If
        comUpdate = New SqlCommand(strUpdate, sqlCon)
        Try
            sqlCon.Open()
            comUpdate.ExecuteNonQuery()
        Catch ex As Exception
            log.writedata(DateTime.Now() & "-Error Update : " & ex.Message())
        Finally
            sqlCon.Close()
            log.writedata("Ticket berhasil di dispatch/reassign dari" & HD_Posisi.Value & " menuju :" & posisiTiketTerakhir)
            log.writedata("--end--")
        End Try

        Response.Redirect("inbox.aspx")
    End Sub

    Sub update_sosmed()
        'save sosmed 
        Dim path As String = Server.MapPath("~/HTML/Upload/")
        Dim insertdata As String
        If chk_posting.Checked = True Then
            If Request.QueryString("ket") = "Twitter" Then
                If Session("source") = "twMention" Then
                    Dim insert As String = "INSERT INTO sosmed_post (dsource, ID_Post, tMessage, tImage, tName, agent_handle, ddate) VALUES ('tw_reply', '" & Request.QueryString("IDREF") & "', '" & ASPxHtmlEditor1.Html & "', '', '" & Request.QueryString("Name") & "', '" & Session("username") & "', GETDATE())"
                    Com = New SqlCommand(insert, Con)
                    Con.Open()
                    Com.ExecuteNonQuery()
                    Con.Close()
                    'End If

                    Dim insertlog As String = "INSERT INTO mslog (Username, Flag, Data, datetime) VALUES ('" & Session("username") & "', 'Handle Mention', '" & ASPxHtmlEditor1.Html & "', GETDATE())"
                    Com = New SqlCommand(insertlog, Con)
                    Con.Open()
                    Com.ExecuteNonQuery()
                    Con.Close()

                    Dim updateflag As String = "update GetSosmed_One set P_flagread = '1' where P_ID_Post = '" & Request.QueryString("IDREF") & "' "
                    Com = New SqlCommand(updateflag, Con)
                    Con.Open()
                    Com.ExecuteNonQuery()
                    Con.Close()

                ElseIf Session("source") = "tw_DM" Then
                    Dim insert As String = "INSERT INTO sosmed_post (dsource, ID_Post, tMessage, tImage, tName, agent_handle, ddate) VALUES ('tw_sendDM', '" & Request.QueryString("IDREF") & "', '" & ASPxHtmlEditor1.Html & "', '', '" & Request.QueryString("Name") & "', '" & Session("username") & "', GETDATE())"
                    Com = New SqlCommand(insert, Con)
                    Con.Open()
                    Com.ExecuteNonQuery()
                    Con.Close()
                    'End If

                    Dim insertlog As String = "INSERT INTO mslog (Username, Flag, Data, datetime) VALUES ('" & Session("username") & "', 'Handle DM', '" & ASPxHtmlEditor1.Html & "', GETDATE())"
                    Com = New SqlCommand(insertlog, Con)
                    Con.Open()
                    Com.ExecuteNonQuery()
                    Con.Close()

                    Dim updateflag As String = "update GetSosmed_One set P_flagread = '1' where P_ID_Post = '" & Request.QueryString("IDREF") & "' "
                    Com = New SqlCommand(updateflag, Con)
                    Con.Open()
                    Com.ExecuteNonQuery()
                    Con.Close()
                End If
                'If uploadfile.HasFile Then
                '    Try
                '        uploadfile.SaveAs(path + uploadfile.FileName)
                '    Catch ex As Exception
                '        Response.Write(DirectCast("", String))
                '    End Try
                '    Dim insert As String = "INSERT INTO sosmed_post (dsource, ID_Post, tMessage, tImage, tName, agent_handle, ddate) VALUES ('tw_reply', '" & Request.QueryString("id") & "', '" & ASPxHtmlEditor1.Html & "', '" & path + uploadfile.FileName & "', '" & Request.QueryString("Name") & "', '" & Session("username") & "', GETDATE())"
                '    Com = New SqlCommand(insert, Con)
                '    Con.Open()
                '    Com.ExecuteNonQuery()
                '    Con.Close()
                'Else

            Else
                If Session("source") = "fb_Post" Then
                    'If uploadfile.HasFile Then
                    '    Try
                    '        uploadfile.SaveAs(path + uploadfile.FileName)
                    '    Catch ex As Exception
                    '        Response.Write(DirectCast("", String))
                    '    End Try
                    '    Dim insert As String = "INSERT INTO sosmed_post (dsource, ID_Post, tMessage, tImage, tName, agent_handle, ddate) VALUES ('fb_post_cr', '" & Request.QueryString("id") & "', '" & ASPxHtmlEditor1.Html & "', '" & path + uploadfile.FileName & "', '" & Request.QueryString("Name") & "', '" & Session("username") & "', GETDATE())"
                    '    Com = New SqlCommand(insert, Con)
                    '    Con.Open()
                    '    Com.ExecuteNonQuery()
                    '    Con.Close()
                    'Else
                    Dim insert As String = "INSERT INTO sosmed_post (dsource, ID_Post, tMessage, tImage, tName, agent_handle, ddate) VALUES ('fb_post_cr', '" & Request.QueryString("IDREF") & "', '" & ASPxHtmlEditor1.Html & "', '', '" & Request.QueryString("Name") & "', '" & Session("username") & "', GETDATE())"
                    Com = New SqlCommand(insert, Con)
                    Con.Open()
                    Com.ExecuteNonQuery()
                    Con.Close()
                    'End If

                    Dim insertlog As String = "INSERT INTO mslog (Username, Flag, Data, datetime) VALUES ('" & Session("username") & "', 'handle Post', '" & ASPxHtmlEditor1.Html & "', GETDATE())"
                    Com = New SqlCommand(insertlog, Con)
                    Con.Open()
                    Com.ExecuteNonQuery()
                    Con.Close()

                    Dim updateflag As String = "update GetSosmed_One set P_flagread = '1' where P_ID_Post = '" & Request.QueryString("IDREF") & "' "
                    Com = New SqlCommand(updateflag, Con)
                    Con.Open()
                    Com.ExecuteNonQuery()
                    Con.Close()

                ElseIf Session("source") = "fb_comment" Then
                    'If uploadfile.HasFile Then
                    '    Try
                    '        uploadfile.SaveAs(path + uploadfile.FileName)
                    '    Catch ex As Exception
                    '        Response.Write(DirectCast("", String))
                    '    End Try
                    '    Dim insert As String = "INSERT INTO sosmed_post (dsource, ID_Post, tMessage, tImage, tName, agent_handle, ddate) VALUES ('fb_post_cr', '" & Request.QueryString("id") & "', '" & ASPxHtmlEditor1.Html & "', '" & path + uploadfile.FileName & "', '" & Request.QueryString("Name") & "', '" & Session("username") & "', GETDATE())"
                    '    Com = New SqlCommand(insert, Con)
                    '    Con.Open()
                    '    Com.ExecuteNonQuery()
                    '    Con.Close()
                    'Else
                    Dim insert As String = "INSERT INTO sosmed_post (dsource, ID_Post, tMessage, tImage, tName, agent_handle, ddate) VALUES ('fb_post_cr', '" & Request.QueryString("IDREF") & "', '" & ASPxHtmlEditor1.Html & "', '', '" & Request.QueryString("Name") & "', '" & Session("username") & "', GETDATE())"
                    Com = New SqlCommand(insert, Con)
                    Con.Open()
                    Com.ExecuteNonQuery()
                    Con.Close()
                    'End If

                    Dim insertlog As String = "INSERT INTO mslog (Username, Flag, Data, datetime) VALUES ('" & Session("username") & "', 'Handle Comment', '" & ASPxHtmlEditor1.Html & "', GETDATE())"
                    Com = New SqlCommand(insertlog, Con)
                    Con.Open()
                    Com.ExecuteNonQuery()
                    Con.Close()

                    Dim updateflag As String = "update GetSosmed_Two set C_flagread = '1' where C_ID_Post = '" & Request.QueryString("IDREF") & "' "
                    Com = New SqlCommand(updateflag, Con)
                    Con.Open()
                    Com.ExecuteNonQuery()
                    Con.Close()

                ElseIf Session("source") = "fb_reply" Then
                    'If uploadfile.HasFile Then
                    '    Try
                    '        uploadfile.SaveAs(path + uploadfile.FileName)
                    '    Catch ex As Exception
                    '        Response.Write(DirectCast("", String))
                    '    End Try
                    '    Dim insert As String = "INSERT INTO sosmed_post (dsource, ID_Post, tMessage, tImage, tName, agent_handle, ddate) VALUES ('fb_post_cr', '" & Request.QueryString("id") & "', '" & ASPxHtmlEditor1.Html & "', '" & path + uploadfile.FileName & "', '" & Request.QueryString("Name") & "', '" & Session("username") & "', GETDATE())"
                    '    Com = New SqlCommand(insert, Con)
                    '    Con.Open()
                    '    Com.ExecuteNonQuery()
                    '    Con.Close()
                    'Else
                    Dim insert As String = "INSERT INTO sosmed_post (dsource, ID_Post, tMessage, tImage, tName, agent_handle, ddate) VALUES ('fb_post_cr', '" & Request.QueryString("IDREF") & "', '" & ASPxHtmlEditor1.Html & "', '', '" & Request.QueryString("Name") & "', '" & Session("username") & "', GETDATE())"
                    Com = New SqlCommand(insert, Con)
                    Con.Open()
                    Com.ExecuteNonQuery()
                    Con.Close()
                    'End If

                    Dim insertlog As String = "INSERT INTO mslog (Username, Flag, Data, datetime) VALUES ('" & Session("username") & "', 'Handle Reply', '" & ASPxHtmlEditor1.Html & "', GETDATE())"
                    Com = New SqlCommand(insertlog, Con)
                    Con.Open()
                    Com.ExecuteNonQuery()
                    Con.Close()

                    Dim updateflag As String = "update GetSosmed_Three set R_flagread = '1' where R_ID_Post = '" & Request.QueryString("IDREF") & "' "
                    Com = New SqlCommand(updateflag, Con)
                    Con.Open()
                    Com.ExecuteNonQuery()
                    Con.Close()

                    'If uploadfile.HasFile Then
                    '    Try
                    '        uploadfile.SaveAs(path + uploadfile.FileName)
                    '    Catch ex As Exception
                    '        Response.Write(DirectCast("", String))
                    '    End Try
                    '    Dim insert As String = "INSERT INTO sosmed_post (dsource, ID_Post, tMessage, tImage, tName, agent_handle, ddate) VALUES ('tw_sendDM', '" & Request.QueryString("id") & "', '" & ASPxHtmlEditor1.Html & "', '" & path + uploadfile.FileName & "', '" & Request.QueryString("Name") & "', '" & Session("username") & "', GETDATE())"
                    '    Com = New SqlCommand(insert, Con)
                    '    Con.Open()
                    '    Com.ExecuteNonQuery()
                    '    Con.Close()
                    'Else


                ElseIf Session("source") = "Inbox" Then
                    'If uploadfile.HasFile Then
                    '    Try
                    '        uploadfile.SaveAs(path + uploadfile.FileName)
                    '    Catch ex As Exception
                    '        Response.Write(DirectCast("", String))
                    '    End Try
                    '    Dim insert As String = "INSERT INTO sosmed_post (dsource, ID_Post, tMessage, tImage, tName, agent_handle, ddate) VALUES ('fb_post_Inbox', '" & Request.QueryString("id") & "', '" & ASPxHtmlEditor1.Html & "', '" & path + uploadfile.FileName & "', '" & Request.QueryString("Name") & "', '" & Session("username") & "', GETDATE())"
                    '    Com = New SqlCommand(insert, Con)
                    '    Con.Open()
                    '    Com.ExecuteNonQuery()
                    '    Con.Close()
                    'Else
                    Dim insert As String = "INSERT INTO sosmed_post (dsource, ID_Post, tMessage, tImage, tName, agent_handle, ddate) VALUES ('fb_post_Inbox', '" & Request.QueryString("IDREF") & "', '" & ASPxHtmlEditor1.Html & "', '', '" & Request.QueryString("Name") & "', '" & Session("username") & "', GETDATE())"
                    Com = New SqlCommand(insert, Con)
                    Con.Open()
                    Com.ExecuteNonQuery()
                    Con.Close()
                    'End If

                    Dim insertlog As String = "INSERT INTO mslog (Username, Flag, Data, datetime) VALUES ('" & Session("username") & "', 'Handle Inbox', '" & ASPxHtmlEditor1.Html & "', GETDATE())"
                    Com = New SqlCommand(insertlog, Con)
                    Con.Open()
                    Com.ExecuteNonQuery()
                    Con.Close()

                    Dim updateflag As String = "update GetSosmed_Inbox set P_flagread = '1' where P_ID_Post = '" & Request.QueryString("IDREF") & "' "
                    Com = New SqlCommand(updateflag, Con)
                    Con.Open()
                    Com.ExecuteNonQuery()
                    Con.Close()

                End If
            End If
        Else
            If Request.QueryString("ket") = "Twitter" Then
                If Session("source") = "twMention" Then
                    Dim insert As String = "INSERT INTO sosmed_post (fProcess, dsource, ID_Post, tMessage, tImage, tName, agent_handle, ddate) VALUES ('1', 'tw_reply', '" & Request.QueryString("IDREF") & "', '" & ASPxHtmlEditor1.Html & "', '', '" & Request.QueryString("Name") & "', '" & Session("username") & "', GETDATE())"
                    Com = New SqlCommand(insert, Con)
                    Con.Open()
                    Com.ExecuteNonQuery()
                    Con.Close()
                    'End If

                    Dim insertlog As String = "INSERT INTO mslog (Username, Flag, Data, datetime) VALUES ('" & Session("username") & "', 'Handle Mention, No Posting', '" & ASPxHtmlEditor1.Html & "', GETDATE())"
                    Com = New SqlCommand(insertlog, Con)
                    Con.Open()
                    Com.ExecuteNonQuery()
                    Con.Close()

                    Dim updateflag As String = "update GetSosmed_One set P_flagread = '1' where P_ID_Post = '" & Request.QueryString("IDREF") & "' "
                    Com = New SqlCommand(updateflag, Con)
                    Con.Open()
                    Com.ExecuteNonQuery()
                    Con.Close()

                ElseIf Session("source") = "tw_DM" Then
                    Dim insert As String = "INSERT INTO sosmed_post (fProcess, dsource, ID_Post, tMessage, tImage, tName, agent_handle, ddate) VALUES ('1', 'tw_sendDM', '" & Request.QueryString("IDREF") & "', '" & ASPxHtmlEditor1.Html & "', '', '" & Request.QueryString("Name") & "', '" & Session("username") & "', GETDATE())"
                    Com = New SqlCommand(insert, Con)
                    Con.Open()
                    Com.ExecuteNonQuery()
                    Con.Close()
                    'End If

                    Dim insertlog As String = "INSERT INTO mslog (Username, Flag, Data, datetime) VALUES ('" & Session("username") & "', 'Handle DM, No Posting', '" & ASPxHtmlEditor1.Html & "', GETDATE())"
                    Com = New SqlCommand(insertlog, Con)
                    Con.Open()
                    Com.ExecuteNonQuery()
                    Con.Close()

                    Dim updateflag As String = "update GetSosmed_One set P_flagread = '1' where P_ID_Post = '" & Request.QueryString("IDREF") & "' "
                    Com = New SqlCommand(updateflag, Con)
                    Con.Open()
                    Com.ExecuteNonQuery()
                    Con.Close()
                End If
                'If uploadfile.HasFile Then
                '    Try
                '        uploadfile.SaveAs(path + uploadfile.FileName)
                '    Catch ex As Exception
                '        Response.Write(DirectCast("", String))
                '    End Try
                '    Dim insert As String = "INSERT INTO sosmed_post (dsource, ID_Post, tMessage, tImage, tName, agent_handle, ddate) VALUES ('tw_reply', '" & Request.QueryString("id") & "', '" & ASPxHtmlEditor1.Html & "', '" & path + uploadfile.FileName & "', '" & Request.QueryString("Name") & "', '" & Session("username") & "', GETDATE())"
                '    Com = New SqlCommand(insert, Con)
                '    Con.Open()
                '    Com.ExecuteNonQuery()
                '    Con.Close()
                'Else

            Else
                If Session("source") = "fb_Post" Then
                    'If uploadfile.HasFile Then
                    '    Try
                    '        uploadfile.SaveAs(path + uploadfile.FileName)
                    '    Catch ex As Exception
                    '        Response.Write(DirectCast("", String))
                    '    End Try
                    '    Dim insert As String = "INSERT INTO sosmed_post (dsource, ID_Post, tMessage, tImage, tName, agent_handle, ddate) VALUES ('fb_post_cr', '" & Request.QueryString("id") & "', '" & ASPxHtmlEditor1.Html & "', '" & path + uploadfile.FileName & "', '" & Request.QueryString("Name") & "', '" & Session("username") & "', GETDATE())"
                    '    Com = New SqlCommand(insert, Con)
                    '    Con.Open()
                    '    Com.ExecuteNonQuery()
                    '    Con.Close()
                    'Else
                    Dim insert As String = "INSERT INTO sosmed_post (fProcess, dsource, ID_Post, tMessage, tImage, tName, agent_handle, ddate) VALUES ('1', 'fb_post_cr', '" & Request.QueryString("IDREF") & "', '" & ASPxHtmlEditor1.Html & "', '', '" & Request.QueryString("Name") & "', '" & Session("username") & "', GETDATE())"
                    Com = New SqlCommand(insert, Con)
                    Con.Open()
                    Com.ExecuteNonQuery()
                    Con.Close()
                    'End If

                    Dim insertlog As String = "INSERT INTO mslog (Username, Flag, Data, datetime) VALUES ('" & Session("username") & "', 'handle Post', '" & ASPxHtmlEditor1.Html & "', GETDATE())"
                    Com = New SqlCommand(insertlog, Con)
                    Con.Open()
                    Com.ExecuteNonQuery()
                    Con.Close()

                    Dim updateflag As String = "update GetSosmed_One set P_flagread = '1' where P_ID_Post = '" & Request.QueryString("IDREF") & "' "
                    Com = New SqlCommand(updateflag, Con)
                    Con.Open()
                    Com.ExecuteNonQuery()
                    Con.Close()

                ElseIf Session("source") = "fb_comment" Then
                    'If uploadfile.HasFile Then
                    '    Try
                    '        uploadfile.SaveAs(path + uploadfile.FileName)
                    '    Catch ex As Exception
                    '        Response.Write(DirectCast("", String))
                    '    End Try
                    '    Dim insert As String = "INSERT INTO sosmed_post (dsource, ID_Post, tMessage, tImage, tName, agent_handle, ddate) VALUES ('fb_post_cr', '" & Request.QueryString("id") & "', '" & ASPxHtmlEditor1.Html & "', '" & path + uploadfile.FileName & "', '" & Request.QueryString("Name") & "', '" & Session("username") & "', GETDATE())"
                    '    Com = New SqlCommand(insert, Con)
                    '    Con.Open()
                    '    Com.ExecuteNonQuery()
                    '    Con.Close()
                    'Else
                    Dim insert As String = "INSERT INTO sosmed_post (fProcess, dsource, ID_Post, tMessage, tImage, tName, agent_handle, ddate) VALUES ('1','fb_post_cr', '" & Request.QueryString("IDREF") & "', '" & ASPxHtmlEditor1.Html & "', '', '" & Request.QueryString("Name") & "', '" & Session("username") & "', GETDATE())"
                    Com = New SqlCommand(insert, Con)
                    Con.Open()
                    Com.ExecuteNonQuery()
                    Con.Close()
                    'End If

                    Dim insertlog As String = "INSERT INTO mslog (Username, Flag, Data, datetime) VALUES ('" & Session("username") & "', 'Handle Comment', '" & ASPxHtmlEditor1.Html & "', GETDATE())"
                    Com = New SqlCommand(insertlog, Con)
                    Con.Open()
                    Com.ExecuteNonQuery()
                    Con.Close()

                    Dim updateflag As String = "update GetSosmed_Two set C_flagread = '1' where C_ID_Post = '" & Request.QueryString("IDREF") & "' "
                    Com = New SqlCommand(updateflag, Con)
                    Con.Open()
                    Com.ExecuteNonQuery()
                    Con.Close()

                ElseIf Session("source") = "fb_reply" Then
                    'If uploadfile.HasFile Then
                    '    Try
                    '        uploadfile.SaveAs(path + uploadfile.FileName)
                    '    Catch ex As Exception
                    '        Response.Write(DirectCast("", String))
                    '    End Try
                    '    Dim insert As String = "INSERT INTO sosmed_post (dsource, ID_Post, tMessage, tImage, tName, agent_handle, ddate) VALUES ('fb_post_cr', '" & Request.QueryString("id") & "', '" & ASPxHtmlEditor1.Html & "', '" & path + uploadfile.FileName & "', '" & Request.QueryString("Name") & "', '" & Session("username") & "', GETDATE())"
                    '    Com = New SqlCommand(insert, Con)
                    '    Con.Open()
                    '    Com.ExecuteNonQuery()
                    '    Con.Close()
                    'Else
                    Dim insert As String = "INSERT INTO sosmed_post (fProcess, dsource, ID_Post, tMessage, tImage, tName, agent_handle, ddate) VALUES ('1', 'fb_post_cr', '" & Request.QueryString("IDREF") & "', '" & ASPxHtmlEditor1.Html & "', '', '" & Request.QueryString("Name") & "', '" & Session("username") & "', GETDATE())"
                    Com = New SqlCommand(insert, Con)
                    Con.Open()
                    Com.ExecuteNonQuery()
                    Con.Close()
                    'End If

                    Dim insertlog As String = "INSERT INTO mslog (Username, Flag, Data, datetime) VALUES ('" & Session("username") & "', 'Handle Reply', '" & ASPxHtmlEditor1.Html & "', GETDATE())"
                    Com = New SqlCommand(insertlog, Con)
                    Con.Open()
                    Com.ExecuteNonQuery()
                    Con.Close()

                    Dim updateflag As String = "update GetSosmed_Three set R_flagread = '1' where R_ID_Post = '" & Request.QueryString("IDREF") & "' "
                    Com = New SqlCommand(updateflag, Con)
                    Con.Open()
                    Com.ExecuteNonQuery()
                    Con.Close()

                    'If uploadfile.HasFile Then
                    '    Try
                    '        uploadfile.SaveAs(path + uploadfile.FileName)
                    '    Catch ex As Exception
                    '        Response.Write(DirectCast("", String))
                    '    End Try
                    '    Dim insert As String = "INSERT INTO sosmed_post (dsource, ID_Post, tMessage, tImage, tName, agent_handle, ddate) VALUES ('tw_sendDM', '" & Request.QueryString("id") & "', '" & ASPxHtmlEditor1.Html & "', '" & path + uploadfile.FileName & "', '" & Request.QueryString("Name") & "', '" & Session("username") & "', GETDATE())"
                    '    Com = New SqlCommand(insert, Con)
                    '    Con.Open()
                    '    Com.ExecuteNonQuery()
                    '    Con.Close()
                    'Else


                ElseIf Session("source") = "Inbox" Then
                    'If uploadfile.HasFile Then
                    '    Try
                    '        uploadfile.SaveAs(path + uploadfile.FileName)
                    '    Catch ex As Exception
                    '        Response.Write(DirectCast("", String))
                    '    End Try
                    '    Dim insert As String = "INSERT INTO sosmed_post (dsource, ID_Post, tMessage, tImage, tName, agent_handle, ddate) VALUES ('fb_post_Inbox', '" & Request.QueryString("id") & "', '" & ASPxHtmlEditor1.Html & "', '" & path + uploadfile.FileName & "', '" & Request.QueryString("Name") & "', '" & Session("username") & "', GETDATE())"
                    '    Com = New SqlCommand(insert, Con)
                    '    Con.Open()
                    '    Com.ExecuteNonQuery()
                    '    Con.Close()
                    'Else
                    Dim insert As String = "INSERT INTO sosmed_post (fProcess, dsource, ID_Post, tMessage, tImage, tName, agent_handle, ddate) VALUES ('1', 'fb_post_Inbox', '" & Request.QueryString("IDREF") & "', '" & ASPxHtmlEditor1.Html & "', '', '" & Request.QueryString("Name") & "', '" & Session("username") & "', GETDATE())"
                    Com = New SqlCommand(insert, Con)
                    Con.Open()
                    Com.ExecuteNonQuery()
                    Con.Close()
                    'End If

                    Dim insertlog As String = "INSERT INTO mslog (Username, Flag, Data, datetime) VALUES ('" & Session("username") & "', 'Handle Inbox', '" & ASPxHtmlEditor1.Html & "', GETDATE())"
                    Com = New SqlCommand(insertlog, Con)
                    Con.Open()
                    Com.ExecuteNonQuery()
                    Con.Close()

                    Dim updateflag As String = "update GetSosmed_Inbox set P_flagread = '1' where P_ID_Post = '" & Request.QueryString("IDREF") & "' "
                    Com = New SqlCommand(updateflag, Con)
                    Con.Open()
                    Com.ExecuteNonQuery()
                    Con.Close()

                End If
            End If
        End If

        ASPxHtmlEditor1.Html = ""
        'end save sosmed
    End Sub
End Class