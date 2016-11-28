Imports System
Imports System.Data.SqlClient
Public Class user
    Inherits System.Web.UI.Page

    Dim Proses As New ClsConn
    Dim Sqldr, dr As SqlDataReader
    Dim com As New SqlCommand
    Dim sql, strsql, insStr As String
    Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString)
    Dim Ticket, Email, Twitter, Facebook, Fax, Chat, Sms, Telegram, Instagram As String
    Dim VTicket, VEmail, VTwitter, VFacebook, VFax, VChat, VSms, VTelegram, VInstagram As String
    Dim ISubMenu, IlevelUser, IMenuTree As String
    Dim MenuID, SubMenuID, SubMenuIDTree, Insr, STicket, InsertUser As String
    Dim i As Integer
    Dim c As Integer
    Dim Name As String
    Dim strMenu As String = ""
    Dim strSubMenu As String = ""
    Dim strSubMenuTree As String = ""
    Dim strArrMenu() As String
    Dim strArrSubMenu() As String
    Dim strArrSubMenuTree() As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        btn_simpan.Visible = True
        div_customer.Visible = True
        div_setting.Visible = True
        div_license.Visible = True
        hr_satu.Visible = True
        hr_dua.Visible = True
        hr_tiga.Visible = True
    End Sub

    Private Sub btn_simpan_Click(sender As Object, e As EventArgs) Handles btn_simpan.Click
        Dim IMenu As String = ""
        If chk_ticket.Checked = True Then
            Ticket = "TRUE"
            IMenu += "Insert Into User1 (MenuName,Url,Number,Icon,DivID) values('Master Data','','2','fa fa-th fa-lg','MD')"
            IMenu += "Insert Into User1 (MenuName,Url,Number,Icon,DivID) values('Ticket','','6','fa fa-file-text fa-lg','TC')"
        Else
            IMenu += "Insert Into User1 (MenuName,Url,Number,Icon,DivID) values('Master Data','','2','fa fa-th fa-lg','MD')"
            Ticket = "FALSE"
        End If
        If chk_email.Checked = True Or chk_twitter.Checked = True Or chk_facebook.Checked = True Or chk_fax.Checked = True Or chk_chat.Checked = True Or chk_sms.Checked = True Or chk_telegram.Checked = True Or chk_instagram.Checked = True Then
            IMenu += "Insert Into User1 (MenuName,Url,Number,Icon,DivID) values('Channel','','4','fa fa-desktop fa-lg','CH')"
        Else
        End If
        If chk_email.Checked = True Then
            Email = "TRUE"
        Else
            Email = "FALSE"
        End If
        If chk_twitter.Checked = True Then
            Twitter = "TRUE"
        Else
            Twitter = "FALSE"
        End If
        If chk_facebook.Checked = True Then
            Facebook = "TRUE"
        Else
            Facebook = "FALSE"
        End If
        If chk_fax.Checked = True Then
            Fax = "TRUE"
        Else
            Fax = "FALSE"
        End If
        If chk_chat.Checked = True Then
            Chat = "TRUE"
        Else
            Chat = "FALSE"
        End If
        If chk_sms.Checked = True Then
            Sms = "TRUE"
        Else
            Sms = "FALSE"
        End If
        If chk_telegram.Checked = True Then
            Telegram = "TRUE"
        Else
            Telegram = "FALSE"
        End If
        If chk_instagram.Checked = True Then
            Instagram = "TRUE"
        Else
            Instagram = "FALSE"
        End If
        IMenu += "Insert Into User1 (MenuName,Url,Number,Icon,DivID) values('Dashboard','dashboard.aspx?page=dashboard','1','fa fa-dashboard','DB')"
        IMenu += "Insert Into User1 (MenuName,Url,Number,Icon,DivID) values('Todolist','inbox.aspx','5','fa fa-list-ul fa-lg','TD')"
        IMenu += "Insert Into User1 (MenuName,Url,Number,Icon,DivID) values('Report','','9','fa fa-hdd-o fa-lg','RP')"
        IMenu += "Insert Into User1 (MenuName,Url,Number,Icon,DivID) values('Management User','','7','fa fa-cogs fa-lg','UM')"
        IMenu += "Insert Into User1 (MenuName,Url,Number,Icon,DivID) values('Customer','customer.aspx?page=customer','3','fa fa-user','CT')"
        IMenu += "Insert Into User1 (MenuName,Url,Number,Icon,DivID) values('Grafik','','8','fa fa-bar-chart-o','GR')"
        IMenu += "Insert Into User1 (MenuName,Url,Number,Icon,DivID) values('Knowledge Base','','10','fa fa-lightbulb-o','KB')"
        Try
            com = New SqlCommand(IMenu, con)
            con.Open()
            com.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception

        End Try

        sql = "insert into mApplikasi(Company_Name, Email_Address, Phone, Address, Ticket, Email, Twitter, Facebook, Fax, Chat, Sms, Telegram, Instagram, License, Login_Type, Date_Create, User_Create) " & _
              "values('" & txt_company_name.Text & "','" & txt_email.Text & "','" & txt_phone.Text & "','" & txt_address.Text & "','" & Ticket & "','" & Email & "','" & Twitter & "','" & Facebook & "','" & Fax & "'," & _
              "'" & Chat & "','" & Sms & "','" & Telegram & "','" & Instagram & "','" & txt_license.Text & "', '" & cmb_status.Value & "', GETDATE(),'Support')"
        com = New SqlCommand(sql, con)
        con.Open()
        com.ExecuteNonQuery()
        con.Close()

        insert_sub_menu()
        Sub_Menu_Tree()
        div_customer.Visible = False
        div_setting.Visible = False
        div_license.Visible = False
        div_generate.Visible = True
        btn_generate.Visible = True
        btn_finis.Visible = False
        btn_simpan.Visible = False
        hr_satu.Visible = False
        hr_dua.Visible = False
        hr_tiga.Visible = False
    End Sub

    Sub insert_sub_menu()
        strsql = "select * from mApplikasi"
        dr = Proses.ExecuteReader(strsql)
        If dr.Read Then
            VTicket = dr("Ticket")
            VEmail = dr("Email")
            VTwitter = dr("Twitter")
            VFacebook = dr("Facebook")
            VFax = dr("Fax")
            VChat = dr("Chat")
            VSms = dr("Sms")
            VTelegram = dr("Telegram")
            VInstagram = dr("Instagram")

            Dim MenuID As String
            sql = "SELECT menuid, menuName FROM User1 Where menuname='Master Data'"
            Sqldr = Proses.ExecuteReader(sql)
            If Sqldr.Read Then
                MenuID = Sqldr("MenuID")
                ISubMenu += "Insert into User2 (menuID, SubMenuName, Url, DivID) values ('" & MenuID & "','Transaction Type','Transaction_Type.aspx?page=mst_tt','TT')"
                If VTicket = "TRUE" Then
                    ISubMenu += "Insert into User2 (menuID, SubMenuName, Url, DivID) values ('" & MenuID & "','Brand','calltype_one.aspx?page=mst_ctone','BR')"
                    ISubMenu += "Insert into User2 (menuID, SubMenuName, Url, DivID) values ('" & MenuID & "','Product','calltype_two.aspx?page=mst_cttwo','PR')"
                    ISubMenu += "Insert into User2 (menuID, SubMenuName, Url, DivID) values ('" & MenuID & "','Problem','calltype_tre.aspx?page=mst_cttre','PL')"
                    ISubMenu += "Insert into User2 (menuID, SubMenuName, Url, DivID) values ('" & MenuID & "','Status','status.aspx?page=mst_ss','ST')"
                    ISubMenu += "Insert into User2 (menuID, SubMenuName, Url, DivID) values ('" & MenuID & "','Email Alert','email_alert.aspx?page=mst_eal','EA')"
                    ISubMenu += "Insert into User2 (menuID, SubMenuName, Url, DivID) values ('" & MenuID & "','Email Karyawan','email_address.aspx?page=mst_ead','EK')"
                    ISubMenu += "Insert into User2 (menuID, SubMenuName, Url, DivID) values ('" & MenuID & "','Source Type','sourcetype.aspx?page=sct_typ','SE')"
                    ISubMenu += "Insert into User2 (menuID, SubMenuName, Url, DivID) values ('" & MenuID & "','Group Type','grouptype.aspx?page=gro_typ','GE')"

                    IlevelUser += "Insert Into mLevelUser(Name, Description) Values('layer1','Agent')"
                    IlevelUser += "Insert Into mLevelUser(Name, Description) Values('layer2','CaseUnit')"
                    IlevelUser += "Insert Into mLevelUser(Name, Description) Values('layer3','PICUnit')"
                    IlevelUser += "Insert Into mLevelUser(Name, Description) Values('Admin','Administrator')"
                    IlevelUser += "Insert Into mLevelUser(Name, Description) Values('Supervisor','Supervisor')"
                Else
                    ISubMenu += "Insert into User2 (menuID, SubMenuName, Url, DivID) values ('" & MenuID & "','Source Type','sourcetype.aspx?page=sct_typ','SE')"
                    ISubMenu += "Insert into User2 (menuID, SubMenuName, Url, DivID) values ('" & MenuID & "','Group Type','grouptype.aspx?page=gro_typ','GE')"
                    ISubMenu += "Insert into User2 (menuID, SubMenuName, Url, DivID) values ('" & MenuID & "','Brand','calltype_one.aspx?page=mst_ctone','BR')"
                    ISubMenu += "Insert into User2 (menuID, SubMenuName, Url, DivID) values ('" & MenuID & "','Product','calltype_two.aspx?page=mst_cttwo','PR')"
                    ISubMenu += "Insert into User2 (menuID, SubMenuName, Url, DivID) values ('" & MenuID & "','Problem','calltype_tre.aspx?page=mst_cttre','PL')"
                    ISubMenu += "Insert into User2 (menuID, SubMenuName, Url, DivID) values ('" & MenuID & "','Status','status.aspx?page=mst_ss','ST')"

                    IlevelUser += "Insert Into mLevelUser(Name, Description) Values('layer1','Agent')"
                    IlevelUser += "Insert Into mLevelUser(Name, Description) Values('Admin','Administrator')"
                    IlevelUser += "Insert Into mLevelUser(Name, Description) Values('Supervisor','Supervisor')"
                End If
                Sqldr.Close()
            Else
            End If
            ISubMenu += "Insert into User2 (menuID, SubMenuName, Url, DivID) values ('" & MenuID & "','Data Karyawan','karyawan.aspx?page=mst_ky','DK')"
            Sqldr.Close()

            sql = "SELECT menuid FROM User1 Where menuname='Ticket'"
            Sqldr = Proses.ExecuteReader(sql)
            If Sqldr.Read Then
                MenuID = Sqldr("MenuID")
                If VTicket = "TRUE" Then
                    ISubMenu += "Insert into User2 (MenuID, SubMenuName, Url, DivID) values ('" & MenuID & "','Create Ticket','utama_ticket.aspx','CT')"
                    ISubMenu += "Insert into User2 (MenuID, SubMenuName, Url, DivID) values ('" & MenuID & "','Ticket History','history_ticket.aspx?page=tk_history','TH')"
                Else
                End If
                Sqldr.Close()
            Else
            End If
            Sqldr.Close()

            sql = "SELECT MenuID FROM User1 Where MenuName='Channel'"
            Sqldr = Proses.ExecuteReader(sql)
            If Sqldr.Read Then
                MenuID = Sqldr("MenuID")
                If VEmail = "TRUE" Then
                    ISubMenu += "Insert into User2 (MenuID, SubMenuName, Url, DivID) values ('" & MenuID & "','Email','inbox_email.aspx?page=in_eml','IE')"
                Else
                End If
                If VTwitter = "TRUE" Then
                    ISubMenu += "Insert into User2 (MenuID, SubMenuName, Url, DivID) values ('" & MenuID & "','Twitter','','TW')"
                Else
                End If
                If VFacebook = "TRUE" Then
                    ISubMenu += "Insert into User2 (MenuID, SubMenuName, Url, DivID) values ('" & MenuID & "','Facebook','','FB')"
                Else
                End If
                If VFax = "TRUE" Then
                    ISubMenu += "Insert into User2 (MenuID, SubMenuName, Url, DivID) values ('" & MenuID & "','Fax','','')"
                Else
                End If
                If VChat = "TRUE" Then
                    ISubMenu += "Insert into User2 (MenuID, SubMenuName, Url, DivID) values ('" & MenuID & "','Chat','chat.aspx?page=chat','CH')"
                Else
                End If
                If VSms = "TRUE" Then
                    ISubMenu += "Insert into User2 (MenuID, SubMenuName, Url, DivID) values ('" & MenuID & "','Sms','sms.aspx?page=sms','SM')"
                Else
                End If
                If VTelegram = "TRUE" Then
                    ISubMenu += "Insert into User2 (MenuID, SubMenuName, Url, DivID) values ('" & MenuID & "','Telegram','telegram.aspx?page=tlgrm','TG')"
                Else
                End If
                If VInstagram = "TRUE" Then
                    ISubMenu += "Insert into User2 (MenuID, SubMenuName, Url, DivID) values ('" & MenuID & "','Instagram','','')"
                Else
                End If
                Sqldr.Close()
            Else
            End If
            Sqldr.Close()

            sql = "SELECT MenuID FROM User1 Where MenuName='Management User'"
            Sqldr = Proses.ExecuteReader(sql)
            If Sqldr.Read Then
                MenuID = Sqldr("MenuID")
                ISubMenu += "Insert into User2 (MenuID, SubMenuName, Url, DivID) values ('" & MenuID & "','Add User','add_user.aspx?page=um_addusr','AU')"
                ISubMenu += "Insert into User2 (MenuID, SubMenuName, Url, DivID) values ('" & MenuID & "','User Setting Previledge','setting_user.aspx?page=um_usrpre','UP')"
            Else
            End If
            Sqldr.Close()

            sql = "SELECT MenuID FROM User1 Where menuname='Report'"
            Sqldr = Proses.ExecuteReader(sql)
            If Sqldr.Read Then
                MenuID = Sqldr("MenuID")
                ISubMenu += "Insert into User2 (MenuID, SubMenuName, Url, DivID) values ('" & MenuID & "','Report Customer','','')"
                ISubMenu += "Insert into User2 (MenuID, SubMenuName, Url, DivID) values ('" & MenuID & "','Report Channel','','')"
                'ISubMenu += "Insert into User2 (menuID, SubMenuName, Url, DivID) values ('" & MenuID & "','Report Dua','','')"
                'ISubMenu += "Insert into User2 (menuID, SubMenuName, Url, DivID) values ('" & MenuID & "','Report Dua','','')"
                'ISubMenu += "Insert into User2 (menuID, SubMenuName, Url, DivID) values ('" & MenuID & "','Report Dua','','')"
            Else
            End If
            Sqldr.Close()
            Try
                com = New SqlCommand(ISubMenu, con)
                con.Open()
                com.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                Response.Write(ex.Message)
            End Try
            Try
                com = New SqlCommand(IlevelUser, con)
                con.Open()
                com.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                Response.Write(ex.Message)
            End Try
        End If
        dr.Close()
    End Sub

    Private Sub Sub_Menu_Tree()
        insStr = "select * from mApplikasi"
        dr = Proses.ExecuteReader(insStr)
        If dr.Read Then
            VTicket = dr("Ticket")
            VEmail = dr("Email")
            VTwitter = dr("Twitter")
            VFacebook = dr("Facebook")
            VFax = dr("Fax")
            VChat = dr("Chat")
            VSms = dr("Sms")
            VTelegram = dr("Telegram")
            VInstagram = dr("Instagram")

            If VEmail = "TRUE" Then
                Dim MenuID, SubMenuID As String
                sql = "SELECT SubMenuID, MenuID, SubMenuName FROM User2 Where SubMenuName='Email'"
                Sqldr = Proses.ExecuteReader(sql)
                If Sqldr.Read Then
                    MenuID = Sqldr("MenuID")
                    SubMenuID = Sqldr("SubMenuID")
                    IMenuTree += "INSERT INTO  USER3 (MenuID, SubMenuID, MenuTreeName, Url, DivID) values ('" & MenuID & "','" & SubMenuID & "','Inbox','','EMA_INB')"
                    IMenuTree += "INSERT INTO  USER3 (MenuID, SubMenuID, MenuTreeName, Url, DivID) values ('" & MenuID & "','" & SubMenuID & "','Send','','EMA_SEN')"
                Else
                End If
                Sqldr.Close()
            Else

            End If

            If VTwitter = "TRUE" Then
                Dim MenuID, SubMenuID As String
                sql = "SELECT SubMenuID, MenuID, SubMenuName FROM User2 Where SubMenuName='Twitter'"
                Sqldr = Proses.ExecuteReader(sql)
                If Sqldr.Read Then
                    MenuID = Sqldr("MenuID")
                    SubMenuID = Sqldr("SubMenuID")
                    IMenuTree += "INSERT INTO  USER3 (MenuID, SubMenuID, MenuTreeName, Url, DivID) values ('" & MenuID & "','" & SubMenuID & "','Data History','','TWT_DTH')"
                    IMenuTree += "INSERT INTO  USER3 (MenuID, SubMenuID, MenuTreeName, Url, DivID) values ('" & MenuID & "','" & SubMenuID & "','Keyword Setting','','TWT_KYS')"
                    IMenuTree += "INSERT INTO  USER3 (MenuID, SubMenuID, MenuTreeName, Url, DivID) values ('" & MenuID & "','" & SubMenuID & "','Posting Status','','TWT_PST')"
                Else
                End If
                Sqldr.Close()
            Else

            End If

            If VFacebook = "TRUE" Then
                Dim MenuID, SubMenuID As String
                sql = "SELECT SubMenuID, MenuID, SubMenuName FROM User2 Where SubMenuName='Facebook'"
                Sqldr = Proses.ExecuteReader(sql)
                If Sqldr.Read Then
                    MenuID = Sqldr("MenuID")
                    SubMenuID = Sqldr("SubMenuID")
                    IMenuTree += "INSERT INTO  USER3 (MenuID, SubMenuID, MenuTreeName, Url, DivID) values ('" & MenuID & "','" & SubMenuID & "','Data History','','FCB_DTH')"
                    IMenuTree += "INSERT INTO  USER3 (MenuID, SubMenuID, MenuTreeName, Url, DivID) values ('" & MenuID & "','" & SubMenuID & "','Keyword Setting','','FCB_KYS')"
                    IMenuTree += "INSERT INTO  USER3 (MenuID, SubMenuID, MenuTreeName, Url, DivID) values ('" & MenuID & "','" & SubMenuID & "','Like Our Posting','','FCB_LOP')"
                    IMenuTree += "INSERT INTO  USER3 (MenuID, SubMenuID, MenuTreeName, Url, DivID) values ('" & MenuID & "','" & SubMenuID & "','Posting Status','','FCB_PST')"
                Else
                End If
                Sqldr.Close()
            Else

            End If

            If VFax = "TRUE" Then
                Dim MenuID, SubMenuID As String
                sql = "SELECT SubMenuID, MenuID, SubMenuName FROM User2 Where SubMenuName='Fax'"
                Sqldr = Proses.ExecuteReader(sql)
                If Sqldr.Read Then
                    MenuID = Sqldr("MenuID")
                    SubMenuID = Sqldr("SubMenuID")
                    IMenuTree += "INSERT INTO  USER3 (MenuID, SubMenuID, MenuTreeName, Url, DivID) values ('" & MenuID & "','" & SubMenuID & "','Inbox','','FAX_INB')"
                    IMenuTree += "INSERT INTO  USER3 (MenuID, SubMenuID, MenuTreeName, Url, DivID) values ('" & MenuID & "','" & SubMenuID & "','Send','','FAX_SEN')"
                Else
                End If
                Sqldr.Close()
            Else

            End If

            If VSms = "TRUE" Then
                Dim MenuID, SubMenuID As String
                sql = "SELECT SubMenuID, MenuID, SubMenuName FROM User2 Where SubMenuName='Sms'"
                Sqldr = Proses.ExecuteReader(sql)
                If Sqldr.Read Then
                    MenuID = Sqldr("MenuID")
                    SubMenuID = Sqldr("SubMenuID")
                    IMenuTree += "INSERT INTO  USER3 (MenuID, SubMenuID, MenuTreeName, Url, DivID) values ('" & MenuID & "','" & SubMenuID & "','Inbox','','SMS_INB')"
                    IMenuTree += "INSERT INTO  USER3 (MenuID, SubMenuID, MenuTreeName, Url, DivID) values ('" & MenuID & "','" & SubMenuID & "','Send','','SMS_SEN')"
                Else
                End If
                Sqldr.Close()
            Else

            End If

            Try
                com = New SqlCommand(IMenuTree, con)
                con.Open()
                com.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                Response.Write(ex.Message)
            End Try          
        End If
        dr.Close()
    End Sub

    Private Sub btn_generate_Click(sender As Object, e As EventArgs) Handles btn_generate.Click       
        Dim N As Integer = txt_license.Text
        Dim Desc As String
        Dim LVID As String
        sql = "select LevelUserID, Description from mleveluser where Name='layer1'"
        Sqldr = Proses.ExecuteReader(sql)
        If Sqldr.Read Then
            LVID = Sqldr("LevelUserID").ToString
            Desc = Sqldr("Description").ToString
        End If
        Sqldr.Close()

        strsql = "select user1.MenuID, user2.SubMenuID, user3.SubMenuIDTree from User1 left outer join User2 on user1.MenuID = user2.MenuID left outer join user3 on user2.SubMenuID = user3.SubMenuID"
        Sqldr = Proses.ExecuteReader(strsql)
        While Sqldr.Read
            MenuID &= Sqldr("menuID") & ";"
            SubMenuID &= Sqldr("SubMenuID") & ";"
            SubMenuIDTree &= Sqldr("SubMenuIDTree") & ";"
        End While
        Sqldr.Close()

        strMenu = MenuID
        strArrMenu = strMenu.Split(";")

        strSubMenu = SubMenuID
        strArrSubMenu = strSubMenu.Split(";")

        strSubMenuTree = SubMenuIDTree
        strArrSubMenuTree = strSubMenuTree.Split(";")

        For j = 0 To N
            For i = 0 To strArrSubMenu.Count - 2
                Insr = "Insert Into User4 (UserID, MenuID, SubMenuID, MenuIDTree, LevelUserID) Values ('" & "AGENT" & j & "','" & strArrMenu(i) & "','" & strArrSubMenu(i) & "','" & strArrSubMenuTree(i) & "','" & LVID & "')"
                    com = New SqlCommand(Insr, con)
                    con.Open()
                    com.ExecuteNonQuery()
                    con.Close()
            Next
            InsertUser = "insert into msUser(UserName, Password, LevelUser, NIK) values ('" & "AGENT" & j & "','12345','" & Desc & "','" & "AGENT" & j & "')"
            com = New SqlCommand(InsertUser, con)
            con.Open()
            com.ExecuteNonQuery()
            con.Close()
        Next

        Dim IAgent As String = ""
        strsql = "select * from mApplikasi"
        dr = Proses.ExecuteReader(strsql)
        If dr.Read Then
            STicket = dr("Ticket").ToString
        End If
        dr.Close()
        If STicket = "TRUE" Then
            layer_Two()
            layer_tree()
            Supervisor()
            Admin()
        Else
            Supervisor()
            Admin()
        End If

        div_setting.Visible = False
        div_license.Visible = False
        div_generate.Visible = True
        sql_user.SelectCommand = "SELECT DISTINCT UserID FROM USER4"
        btn_finis.Visible = True
        btn_simpan.Visible = False
        div_customer.Visible = False
        div_setting.Visible = False
        div_license.Visible = False
        hr_satu.Visible = False
        hr_dua.Visible = False
        hr_tiga.Visible = False
        btn_generate.Visible = False
    End Sub

    Sub bener()
        Dim MenuID, SubMenuID, Insr As String
        Dim i As Integer
        Dim N As Integer = 3
        Dim Name As String
        Dim strCheckBox As String = ""
        Dim strArr() As String
        sql = "select menuID from user1"
        Sqldr = Proses.ExecuteReader(sql)
        While Sqldr.Read()
            MenuID &= Sqldr("menuID") & ";"
        End While
        Sqldr.Close()
        strCheckBox = MenuID
        strArr = strCheckBox.Split(";")
        For j = 0 To 3
            For i = 0 To strArr.Count - 2
                Insr = "Insert Into User3 (UserID, MenuID, SubMenuID) Values ('" & j & "','" & strArr(i) & "','001')"
                com = New SqlCommand(Insr, con)
                con.Open()
                com.ExecuteNonQuery()
                con.Close()
            Next
        Next
    End Sub

    Private Sub gv_app_RowUpdating(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs) Handles gv_app.RowUpdating
        Dim NewUser As String = e.NewValues("UserID")
        Dim UserDefault As String = e.OldValues("UserID")
        sql_user.UpdateCommand = "UPDATE USER3 SET UserID='" & NewUser & "' WHERE UserID='" & UserDefault & "'"
        sql_user.SelectCommand = "SELECT DISTINCT UserID FROM USER3"
        div_generate.Visible = True
    End Sub

    Private Sub btn_finis_Click(sender As Object, e As EventArgs) Handles btn_finis.Click
        Response.Redirect("~/login.aspx")
    End Sub

    Sub layer_Two()
        Dim layer2 As String
        Dim Desc As String
        sql = "select LevelUserID, Description from mleveluser where Name='layer2'"
        Sqldr = Proses.ExecuteReader(sql)
        If Sqldr.Read Then
            layer2 = Sqldr("LevelUserID").ToString
            Desc = Sqldr("Description").ToString
        End If
        Sqldr.Close()

        strsql = "select user1.MenuID, user2.SubMenuID, user3.SubMenuIDTree from User1 left outer join User2 on user1.MenuID = user2.MenuID left outer join user3 on user2.SubMenuID = user3.SubMenuID"
        Sqldr = Proses.ExecuteReader(strsql)
        While Sqldr.Read
            MenuID &= Sqldr("menuID") & ";"
            SubMenuID &= Sqldr("SubMenuID") & ";"
            SubMenuIDTree &= Sqldr("SubMenuIDTree") & ";"
        End While
        Sqldr.Close()

        strMenu = MenuID
        strArrMenu = strMenu.Split(";")

        strSubMenu = SubMenuID
        strArrSubMenu = strSubMenu.Split(";")

        strSubMenuTree = SubMenuIDTree
        strArrSubMenuTree = strSubMenuTree.Split(";")

        For j = 0 To 3
            For i = 0 To strArrSubMenu.Count - 2
                For c = 0 To strArrSubMenuTree.Count - 2
                    Insr = "Insert Into User4 (UserID, MenuID, SubMenuID, MenuIDTree, LevelUserID) Values ('" & "LAYER2" & j & "','" & strArrMenu(i) & "','" & strArrSubMenu(i) & "','" & strArrSubMenuTree(c) & "','" & layer2 & "')"
                    com = New SqlCommand(Insr, con)
                    con.Open()
                    com.ExecuteNonQuery()
                    con.Close()
                Next
            Next
            InsertUser = "insert into msUser(UserName, Password, LevelUser, NIK) values ('" & "LAYER2" & j & "','12345','" & Desc & "','" & "LAYER2" & j & "')"
            com = New SqlCommand(InsertUser, con)
            con.Open()
            com.ExecuteNonQuery()
            con.Close()
        Next
    End Sub

    Sub layer_tree()
        Dim layer3 As String
        Dim Desc As String
        sql = "select LevelUserID, Description from mleveluser where Name='layer3'"
        Sqldr = Proses.ExecuteReader(sql)
        If Sqldr.Read Then
            layer3 = Sqldr("LevelUserID").ToString
            Desc = Sqldr("Description").ToString
        End If
        Sqldr.Close()

        strsql = "select user1.MenuID, user2.SubMenuID, user3.SubMenuIDTree from User1 left outer join User2 on user1.MenuID = user2.MenuID left outer join user3 on user2.SubMenuID = user3.SubMenuID"
        Sqldr = Proses.ExecuteReader(strsql)
        While Sqldr.Read
            MenuID &= Sqldr("menuID") & ";"
            SubMenuID &= Sqldr("SubMenuID") & ";"
            SubMenuIDTree &= Sqldr("SubMenuIDTree") & ";"
        End While
        Sqldr.Close()

        strMenu = MenuID
        strArrMenu = strMenu.Split(";")

        strSubMenu = SubMenuID
        strArrSubMenu = strSubMenu.Split(";")

        strSubMenuTree = SubMenuIDTree
        strArrSubMenuTree = strSubMenuTree.Split(";")

        For j = 0 To 3
            For i = 0 To strArrSubMenu.Count - 2
                For c = 0 To strArrSubMenuTree.Count - 2
                    Insr = "Insert Into User4 (UserID, MenuID, SubMenuID, MenuIDTree, LevelUserID) Values ('" & "LAYER3" & j & "','" & strArrMenu(i) & "','" & strArrSubMenu(i) & "','" & strArrSubMenuTree(c) & "','" & layer3 & "')"
                    com = New SqlCommand(Insr, con)
                    con.Open()
                    com.ExecuteNonQuery()
                    con.Close()
                Next
            Next
            InsertUser = "insert into msUser(UserName, Password, LevelUser, NIK) values ('" & "LAYER3" & j & "','12345','" & Desc & "','" & "LAYER3" & j & "')"
            com = New SqlCommand(InsertUser, con)
            con.Open()
            com.ExecuteNonQuery()
            con.Close()
        Next
    End Sub

    Sub Admin()
        Dim Admin As String
        Dim Desc As String
        sql = "select LevelUserID, Description from mleveluser where Name='Admin'"
        Sqldr = Proses.ExecuteReader(sql)
        If Sqldr.Read Then
            Admin = Sqldr("LevelUserID").ToString
            Desc = Sqldr("Description").ToString
        End If
        Sqldr.Close()

        strsql = "select user1.MenuID, user2.SubMenuID, user3.SubMenuIDTree from User1 left outer join User2 on user1.MenuID = user2.MenuID left outer join user3 on user2.SubMenuID = user3.SubMenuID"
        Sqldr = Proses.ExecuteReader(strsql)
        While Sqldr.Read
            MenuID &= Sqldr("menuID") & ";"
            SubMenuID &= Sqldr("SubMenuID") & ";"
            SubMenuIDTree &= Sqldr("SubMenuIDTree") & ";"
        End While
        Sqldr.Close()

        strMenu = MenuID
        strArrMenu = strMenu.Split(";")

        strSubMenu = SubMenuID
        strArrSubMenu = strSubMenu.Split(";")

        strSubMenuTree = SubMenuIDTree
        strArrSubMenuTree = strSubMenuTree.Split(";")

        For j = 0 To 1
            For i = 0 To strArrSubMenu.Count - 2
                For c = 0 To strArrSubMenuTree.Count - 2
                    Insr = "Insert Into User4 (UserID, MenuID, SubMenuID, MenuIDTree, LevelUserID) Values ('" & "ADMIN" & j & "','" & strArrMenu(i) & "','" & strArrSubMenu(i) & "','" & strArrSubMenuTree(c) & "','" & Admin & "')"
                    com = New SqlCommand(Insr, con)
                    con.Open()
                    com.ExecuteNonQuery()
                    con.Close()
                Next
            Next
            InsertUser = "insert into msUser(UserName, Password, LevelUser, NIK) values ('" & "ADMIN" & j & "','12345','" & Desc & "','" & "ADMIN" & j & "')"
            com = New SqlCommand(InsertUser, con)
            con.Open()
            com.ExecuteNonQuery()
            con.Close()
        Next
    End Sub

    Sub Supervisor()
        Dim Supervisor As String
        Dim Desc As String
        sql = "select LevelUserID, Description from mleveluser where Name='Supervisor'"
        Sqldr = Proses.ExecuteReader(sql)
        If Sqldr.Read Then
            Supervisor = Sqldr("LevelUserID").ToString
            Desc = Sqldr("Description").ToString
        End If
        Sqldr.Close()

        strsql = "select user1.MenuID, user2.SubMenuID, user3.SubMenuIDTree from User1 left outer join User2 on user1.MenuID = user2.MenuID left outer join user3 on user2.SubMenuID = user3.SubMenuID"
        Sqldr = Proses.ExecuteReader(strsql)
        While Sqldr.Read
            MenuID &= Sqldr("menuID") & ";"
            SubMenuID &= Sqldr("SubMenuID") & ";"
            SubMenuIDTree &= Sqldr("SubMenuIDTree") & ";"
        End While
        Sqldr.Close()

        strMenu = MenuID
        strArrMenu = strMenu.Split(";")

        strSubMenu = SubMenuID
        strArrSubMenu = strSubMenu.Split(";")

        strSubMenuTree = SubMenuIDTree
        strArrSubMenuTree = strSubMenuTree.Split(";")

        For j = 0 To 1
            For i = 0 To strArrSubMenu.Count - 2
                For c = 0 To strArrSubMenuTree.Count - 2
                    Insr = "Insert Into User4 (UserID, MenuID, SubMenuID, MenuIDTree, LevelUserID) Values ('" & "ADMIN" & j & "','" & strArrMenu(i) & "','" & strArrSubMenu(i) & "','" & strArrSubMenuTree(c) & "','" & Supervisor & "')"
                    com = New SqlCommand(Insr, con)
                    con.Open()
                    com.ExecuteNonQuery()
                    con.Close()
                Next
            Next
            InsertUser = "insert into msUser(UserName, Password, LevelUser, NIK) values ('" & "SUPERVISOR" & j & "','12345','" & Desc & "','" & "SUPERVISOR" & j & "')"
            com = New SqlCommand(InsertUser, con)
            con.Open()
            com.ExecuteNonQuery()
            con.Close()
        Next
    End Sub
End Class