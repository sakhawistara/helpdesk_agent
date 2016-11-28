Imports System
Imports System.Data
Imports System.Data.SqlClient
Public Class AppSetting
    Inherits System.Web.UI.Page

    Dim sqlcon As SqlConnection
    Dim connectionString As String = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
    Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString)
    Dim com As SqlCommand
    Dim sql As String
    Dim VEmail As String
    Dim VTwitter As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        sql_app.SelectCommand = "select * from mApplikasi"
    End Sub

    Private Sub gv_app_RowUpdating(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs) Handles gv_app.RowUpdating
        sql_app.UpdateCommand = "update mApplikasi set Ticket=@Ticket, Email=@Email, Twitter=@Twitter, Facebook=@Facebook, Fax=@Fax, Chat=@Chat, Sms=@Sms where ID=@ID"
        Dim ID As String = e.NewValues("ID")
        Dim Ticket As String = e.NewValues("Ticket")
        Dim Email As String = e.NewValues("Email")
        Dim Twitter As String = e.NewValues("Twitter")
        Dim Facebook As String = e.NewValues("Facebook")
        Dim Fax As String = e.NewValues("Fax")
        Dim Sms As String = e.NewValues("Sms")
        Dim Chat As String = e.NewValues("Chat")
        If Ticket = "Yes" Then
            CREATE_TABLE(Ticket, Email, Twitter, Facebook, Fax, Sms, Chat)
            INSERT_MENU(Ticket, Email, Twitter, Facebook, Fax, Sms, Chat)
            INSERT_AGENT(Ticket, Email, Twitter, Facebook, Fax, Sms, Chat)
            INSERT_CASE_UNIT(Ticket, Email, Twitter, Facebook, Fax, Sms, Chat)
            INSERT_PIC_UNIT(Ticket, Email, Twitter, Facebook, Fax, Sms, Chat)
            INSERT_SUPERVISOR(Ticket, Email, Twitter, Facebook, Fax, Sms, Chat)
            INSERT_ADMIN(Ticket, Email, Twitter, Facebook, Fax, Sms, Chat)
        Else
            CREATE_TABLE_NO_TICKET(Ticket, Email, Twitter, Facebook, Fax, Sms, Chat)
            INSERT_MENU_NO_TICKET(Ticket, Email, Twitter, Facebook, Fax, Sms, Chat)
            INSERT_AGENT_NO_TICKET(Ticket, Email, Twitter, Facebook, Fax, Sms, Chat)
            INSERT_ADMIN_NO_TICKET(Ticket, Email, Twitter, Facebook, Fax, Sms, Chat)
            INSERT_SUPERVISOR_NO_TICKET(Ticket, Email, Twitter, Facebook, Fax, Sms, Chat)
        End If
    End Sub

    Function INSERT_MENU(ByVal Ticket As String, ByVal Email As String, ByVal Twitter As String, ByVal Facebook As String, ByVal Fax As String, ByVal Sms As String, ByVal Chat As String)
        Dim menu As String
        menu += "INSERT INTO MenuMaster (Name, Description, Flag) values('MT','Master Table','ALL')"
        menu += "INSERT INTO MenuMaster (Name, Description, Flag) values('MT_STY','Source Type','ALL')"
        menu += "INSERT INTO MenuMaster (Name, Description, Flag) values('MT_GTY','Group Type','ALL')"
        menu += "INSERT INTO MenuMaster (Name, Description, Flag) values('MT_TTY','Transaction Type','Ticket')"
        menu += "INSERT INTO MenuMaster (Name, Description, Flag) values('MT_CON','Brand','Ticket')"
        menu += "INSERT INTO MenuMaster (Name, Description, Flag) values('MT_CTW','Product','Ticket')"
        menu += "INSERT INTO MenuMaster (Name, Description, Flag) values('MT_CTR','Problem','Ticket')"
        menu += "INSERT INTO MenuMaster (Name, Description, Flag) values('MT_STS','Status','ALL')"
        menu += "INSERT INTO MenuMaster (Name, Description, Flag) values('MT_DKY','Data Karyawan','ALL')"
        menu += "INSERT INTO MenuMaster (Name, Description, Flag) values('MT_EAL','Email Alert','Ticket')"
        menu += "INSERT INTO MenuMaster (Name, Description, Flag) values('MT_EAD','Email Address','Ticket')"
        menu += "INSERT INTO MenuMaster (Name, Description, Flag) values('DS','Dashboard','ALL')"
        menu += "INSERT INTO MenuMaster (Name, Description, Flag) values('CH','Channel','CH')"
        If Email = "Yes" Then
            menu += "INSERT INTO MenuMaster (Name, Description, Flag) values('CH_EMA','Channel Email','EMA')"
        Else
        End If
        If Twitter = "Yes" Then
            menu += "INSERT INTO MenuMaster (Name, Description, Flag) values('CH_TWT','Channel Twitter','TWT')"
            menu += "INSERT INTO MenuMaster (Name, Description, Flag) values('CH_TKS','Twitter Keyword Setting','TKS')"
        Else
        End If
        If Facebook = "Yes" Then
            menu += "INSERT INTO MenuMaster (Name, Description, Flag) values('CH_FCB','Channel Facebook','FCB')"
            menu += "INSERT INTO MenuMaster (Name, Description, Flag) values('CH_FKS','Facebook Keyword Setting','FKS')"
        Else
        End If
        If Fax = "Yes" Then
            menu += "INSERT INTO MenuMaster (Name, Description, Flag) values('CH_FAX','Channel Fax','FAX')"
        Else
        End If
        If Sms = "Yes" Then
            menu += "INSERT INTO MenuMaster (Name, Description, Flag) values('CH_SMS','Channel Sms','SMS')"
        Else
        End If
        If Chat = "Yes" Then
            menu += "INSERT INTO MenuMaster (Name, Description, Flag) values('CH_CHA','Channel Chat','CHA')"
        Else
        End If
        menu += "INSERT INTO MenuMaster (Name, Description, Flag) values('TIK','Ticket','Ticket')"
        menu += "INSERT INTO MenuMaster (Name, Description, Flag) values('TK_CRT','Create Ticket','Ticket')"
        menu += "INSERT INTO MenuMaster (Name, Description, Flag) values('TK_THS','Ticket History','Ticket')"
        menu += "INSERT INTO MenuMaster (Name, Description, Flag) values('UM','User Management','ALL')"
        menu += "INSERT INTO MenuMaster (Name, Description, Flag) values('UM_ADS','Add User','ALL')"
        menu += "INSERT INTO MenuMaster (Name, Description, Flag) values('UM_SUP','Setting User Previledge','ALL')"
        menu += "INSERT INTO MenuMaster (Name, Description, Flag) values('RP','Reporting','ALL')"
        menu += "INSERT INTO MenuMaster (Name, Description, Flag) values('CT','Customer','ALL')"
        menu += "INSERT INTO MenuMaster (Name, Description, Flag) values('GF','Grafik','ALL')"
        menu += "INSERT INTO MenuMaster (Name, Description, Flag) values('KB','Knowledge Base','ALL')"
        com = New SqlCommand(menu, con)
        con.Open()
        com.ExecuteNonQuery()
        con.Close()
    End Function

    Function CREATE_TABLE(ByVal Ticket As String, ByVal Email As String, ByVal Twitter As String, ByVal Facebook As String, ByVal Fax As String, ByVal Sms As String, ByVal Chat As String)
        Dim query As String = "IF OBJECT_ID('dbo.show_invision', 'U') IS NULL "
        query += "BEGIN "
        query += "CREATE TABLE [dbo].[MTrustee]("
        query += "[TrusteeID] INT IDENTITY(1,1) NOT NULL CONSTRAINT pkCustomerId PRIMARY KEY,"
        query += "[LEVEL_USER] VARCHAR(500) NOT NULL,"
        query += "[LEVEL_USER_SBG] VARCHAR(500) NOT NULL,"
        query += "[DESCRIPTION] VARCHAR(MAX) NOT NULL,"
        query += "[MT] VARCHAR(50) NOT NULL,"
        query += "[MT_STY] VARCHAR(500) NOT NULL,"
        query += "[MT_GTY] VARCHAR(500) NOT NULL,"
        query += "[MT_TTY] VARCHAR(500) NOT NULL,"
        query += "[MT_CON] VARCHAR(500) NOT NULL,"
        query += "[MT_CTW] VARCHAR(500) NOT NULL,"
        query += "[MT_CTR] VARCHAR(500) NOT NULL,"
        query += "[MT_STS] VARCHAR(500) NOT NULL,"
        query += "[MT_DKY] VARCHAR(500) NOT NULL,"
        query += "[MT_EAL] VARCHAR(500) NOT NULL,"
        query += "[MT_EAD] VARCHAR(500) NOT NULL,"
        query += "[DS] VARCHAR(500) NOT NULL,"
        query += "[CH] VARCHAR(500) NOT NULL,"
        If Email = "Yes" Then
            query += "[CH_EMA] VARCHAR(500) NOT NULL,"
        Else
        End If
        If Twitter = "Yes" Then
            query += "[CH_TWT] VARCHAR(500) NOT NULL,"
            query += "[CH_TKS] VARCHAR(500) NOT NULL,"
        Else
        End If
        If Facebook = "Yes" Then
            query += "[CH_FCB] VARCHAR(500) NOT NULL,"
            query += "[CH_FKS] VARCHAR(500) NOT NULL,"
        Else
        End If
        If Fax = "Yes" Then
            query += "[CH_FAX] VARCHAR(500) NOT NULL,"
        Else
        End If
        If Sms = "Yes" Then
            query += "[CH_SMS] VARCHAR(500) NOT NULL,"
        Else
        End If
        If Chat = "Yes" Then
            query += "[CH_CHA] VARCHAR(500) NOT NULL,"
        Else
        End If
        query += "[TIK] VARCHAR(500) NOT NULL,"
        query += "[TK_CRT] VARCHAR(500) NOT NULL,"
        query += "[TK_THS] VARCHAR(500) NOT NULL,"
        query += "[UM] VARCHAR(500) NOT NULL,"
        query += "[UM_ADS] VARCHAR(500) NOT NULL,"
        query += "[UM_SUP] VARCHAR(500) NOT NULL,"
        query += "[RP] VARCHAR(500) NOT NULL,"
        query += "[CT] VARCHAR(500) NOT NULL,"
        query += "[GF] VARCHAR(500) NOT NULL,"
        query += "[KB] VARCHAR(500) NOT NULL"
        query += ")"
        query += " END"
        Try
            com = New SqlCommand(query, con)
            con.Open()
            com.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Function

    Function CREATE_TABLE_NO_TICKET(ByVal Ticket As String, ByVal Email As String, ByVal Twitter As String, ByVal Facebook As String, ByVal Fax As String, ByVal Sms As String, ByVal Chat As String)
        Dim query As String = "IF OBJECT_ID('dbo.show_invision', 'U') IS NULL "
        query += "BEGIN "
        query += "CREATE TABLE [dbo].[MTrustee]("
        query += "[TrusteeID] INT IDENTITY(1,1) NOT NULL CONSTRAINT pkCustomerId PRIMARY KEY,"
        query += "[LEVEL_USER] VARCHAR(500) NOT NULL,"
        query += "[LEVEL_USER_SBG] VARCHAR(500) NOT NULL,"
        query += "[DESCRIPTION] VARCHAR(MAX) NOT NULL,"
        query += "[MT] VARCHAR(50) NOT NULL,"
        query += "[MT_STY] VARCHAR(500) NOT NULL,"
        query += "[MT_GTY] VARCHAR(500) NOT NULL,"
        query += "[MT_TTY] VARCHAR(500) NOT NULL,"
        query += "[MT_STS] VARCHAR(500) NOT NULL,"
        query += "[MT_DKY] VARCHAR(500) NOT NULL,"
        query += "[DS] VARCHAR(500) NOT NULL,"
        query += "[CH] VARCHAR(500) NOT NULL,"
        If Email = "Yes" Then
            query += "[CH_EMA] VARCHAR(500) NOT NULL,"
        Else
        End If
        If Twitter = "Yes" Then
            query += "[CH_TWT] VARCHAR(500) NOT NULL,"
            query += "[CH_TKS] VARCHAR(500) NOT NULL,"
        Else
        End If
        If Facebook = "Yes" Then
            query += "[CH_FCB] VARCHAR(500) NOT NULL,"
            query += "[CH_FKS] VARCHAR(500) NOT NULL,"
        Else
        End If
        If Fax = "Yes" Then
            query += "[CH_FAX] VARCHAR(500) NOT NULL,"
        Else
        End If
        If Sms = "Yes" Then
            query += "[CH_SMS] VARCHAR(500) NOT NULL,"
        Else
        End If
        If Chat = "Yes" Then
            query += "[CH_CHA] VARCHAR(500) NOT NULL,"
        Else
        End If
        query += "[UM] VARCHAR(500) NOT NULL,"
        query += "[UM_ADS] VARCHAR(500) NOT NULL,"
        query += "[UM_SUP] VARCHAR(500) NOT NULL,"
        query += "[RP] VARCHAR(500) NOT NULL,"
        query += "[CT] VARCHAR(500) NOT NULL,"
        query += "[GF] VARCHAR(500) NOT NULL,"
        query += "[KB] VARCHAR(500) NOT NULL"
        query += ")"
        query += " END"
        com = New SqlCommand(query, con)
        Try
            con.Open()
            com.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Function

    Function INSERT_MENU_NO_TICKET(ByVal Ticket As String, ByVal Email As String, ByVal Twitter As String, ByVal Facebook As String, ByVal Fax As String, ByVal Sms As String, ByVal Chat As String)
        Dim menu As String
        menu += "INSERT INTO MenuMaster (Name, Description, Flag) values('MT','Master Table','ALL')"
        menu += "INSERT INTO MenuMaster (Name, Description, Flag) values('MT_STY','Source Type','ALL')"
        menu += "INSERT INTO MenuMaster (Name, Description, Flag) values('MT_GTY','Group Type','ALL')"
        menu += "INSERT INTO MenuMaster (Name, Description, Flag) values('MT_TTY','Transaction Type','Ticket')"
        menu += "INSERT INTO MenuMaster (Name, Description, Flag) values('MT_STS','Status','ALL')"
        menu += "INSERT INTO MenuMaster (Name, Description, Flag) values('MT_DKY','Data Karyawan','ALL')"
        menu += "INSERT INTO MenuMaster (Name, Description, Flag) values('DS','Dashboard','ALL')"
        menu += "INSERT INTO MenuMaster (Name, Description, Flag) values('CH','Channel','CH')"
        If Email = "Yes" Then
            menu += "INSERT INTO MenuMaster (Name, Description, Flag) values('CH_EMA','Channel Email','EMA')"
        Else
        End If
        If Twitter = "Yes" Then
            menu += "INSERT INTO MenuMaster (Name, Description, Flag) values('CH_TWT','Channel Twitter','TWT')"
            menu += "INSERT INTO MenuMaster (Name, Description, Flag) values('CH_TKS','Twitter Keyword Setting','TKS')"
        Else
        End If
        If Facebook = "Yes" Then
            menu += "INSERT INTO MenuMaster (Name, Description, Flag) values('CH_FCB','Channel Facebook','FCB')"
            menu += "INSERT INTO MenuMaster (Name, Description, Flag) values('CH_FKS','Facebook Keyword Setting','FKS')"
        Else
        End If
        If Fax = "Yes" Then
            menu += "INSERT INTO MenuMaster (Name, Description, Flag) values('CH_FAX','Channel Fax','FAX')"
        Else
        End If
        If Sms = "Yes" Then
            menu += "INSERT INTO MenuMaster (Name, Description, Flag) values('CH_SMS','Channel Sms','SMS')"
        Else
        End If
        If Chat = "Yes" Then
            menu += "INSERT INTO MenuMaster (Name, Description, Flag) values('CH_CHA','Channel Chat','CHA')"
        Else
        End If
        menu += "INSERT INTO MenuMaster (Name, Description, Flag) values('UM','User Management','ALL')"
        menu += "INSERT INTO MenuMaster (Name, Description, Flag) values('UM_ADS','Add User','ALL')"
        menu += "INSERT INTO MenuMaster (Name, Description, Flag) values('UM_SUP','Setting User Previledge','ALL')"
        menu += "INSERT INTO MenuMaster (Name, Description, Flag) values('RP','Reporting','ALL')"
        menu += "INSERT INTO MenuMaster (Name, Description, Flag) values('CT','Customer','ALL')"
        menu += "INSERT INTO MenuMaster (Name, Description, Flag) values('GF','Grafik','ALL')"
        menu += "INSERT INTO MenuMaster (Name, Description, Flag) values('KB','Knowledge Base','ALL')"
        com = New SqlCommand(menu, con)
        con.Open()
        com.ExecuteNonQuery()
        con.Close()
    End Function

    Function INSERT_AGENT(ByVal Ticket As String, ByVal Email As String, ByVal Twitter As String, ByVal Facebook As String, ByVal Fax As String, ByVal Sms As String, ByVal Chat As String)
        Dim sql As String
        sql += "INSERT INTO MTrustee("
        sql += "[LEVEL_USER],"
        sql += "[LEVEL_USER_SBG],"
        sql += "[DESCRIPTION],"
        sql += "[MT],"
        sql += "[MT_STY],"
        sql += "[MT_GTY],"
        sql += "[MT_TTY],"
        sql += "[MT_CON],"
        sql += "[MT_CTW],"
        sql += "[MT_CTR],"
        sql += "[MT_STS],"
        sql += "[MT_DKY],"
        sql += "[MT_EAL],"
        sql += "[MT_EAD],"
        sql += "[DS],"
        sql += "[CH],"
        If Email = "Yes" Then
            sql += "[CH_EMA],"
        Else
        End If
        If Twitter = "Yes" Then
            sql += "[CH_TWT],"
            sql += "[CH_TKS],"
        Else
        End If
        If Facebook = "Yes" Then
            sql += "[CH_FCB],"
            sql += "[CH_FKS],"
        Else
        End If
        If Fax = "Yes" Then
            sql += "[CH_FAX],"
        Else
        End If
        If Sms = "Yes" Then
            sql += "[CH_SMS],"
        Else
        End If
        If Chat = "Yes" Then
            sql += "[CH_CHA],"
        Else
        End If
        sql += "[TIK],"
        sql += "[TK_CRT],"
        sql += "[TK_THS],"
        sql += "[UM],"
        sql += "[UM_ADS],"
        sql += "[UM_SUP],"
        sql += "[RP],"
        sql += "[CT],"
        sql += "[GF],"
        sql += "[KB]"
        sql += ")"
        sql += "VALUES("
        sql += "'Agent','layer1','Layer1',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        If Email = "Yes" Then
            sql += "'TRUE',"
        Else
        End If
        If Twitter = "Yes" Then
            sql += "'TRUE',"
            sql += "'TRUE',"
        Else
        End If
        If Facebook = "Yes" Then
            sql += "'TRUE',"
            sql += "'TRUE',"
        Else
        End If
        If Fax = "Yes" Then
            sql += "'TRUE',"
        Else
        End If
        If Sms = "Yes" Then
            sql += "'TRUE',"
        Else
        End If
        If Chat = "Yes" Then
            sql += "'TRUE',"
        Else
        End If
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'FALSE',"
        sql += "'FALSE',"
        sql += "'FALSE',"
        sql += "'FALSE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE'"
        sql += ")"
        Try
            com = New SqlCommand(sql, con)
            con.Open()
            com.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Function

    Function INSERT_CASE_UNIT(ByVal Ticket As String, ByVal Email As String, ByVal Twitter As String, ByVal Facebook As String, ByVal Fax As String, ByVal Sms As String, ByVal Chat As String)
        Dim sql As String
        sql += "INSERT INTO MTrustee("
        sql += "[LEVEL_USER],"
        sql += "[LEVEL_USER_SBG],"
        sql += "[DESCRIPTION],"
        sql += "[MT],"
        sql += "[MT_STY],"
        sql += "[MT_GTY],"
        sql += "[MT_TTY],"
        sql += "[MT_CON],"
        sql += "[MT_CTW],"
        sql += "[MT_CTR],"
        sql += "[MT_STS],"
        sql += "[MT_DKY],"
        sql += "[MT_EAL],"
        sql += "[MT_EAD],"
        sql += "[DS],"
        sql += "[CH],"
        If Email = "Yes" Then
            sql += "[CH_EMA],"
        Else
        End If
        If Twitter = "Yes" Then
            sql += "[CH_TWT],"
            sql += "[CH_TKS],"
        Else
        End If
        If Facebook = "Yes" Then
            sql += "[CH_FCB],"
            sql += "[CH_FKS],"
        Else
        End If
        If Fax = "Yes" Then
            sql += "[CH_FAX],"
        Else
        End If
        If Sms = "Yes" Then
            sql += "[CH_SMS],"
        Else
        End If
        If Chat = "Yes" Then
            sql += "[CH_CHA],"
        Else
        End If
        sql += "[TIK],"
        sql += "[TK_CRT],"
        sql += "[TK_THS],"
        sql += "[UM],"
        sql += "[UM_ADS],"
        sql += "[UM_SUP],"
        sql += "[RP],"
        sql += "[CT],"
        sql += "[GF],"
        sql += "[KB]"
        sql += ")"
        sql += "VALUES("
        sql += "'CaseUnit','layer2','Layer2',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        If Email = "Yes" Then
            sql += "'TRUE',"
        Else
        End If
        If Twitter = "Yes" Then
            sql += "'TRUE',"
            sql += "'TRUE',"
        Else
        End If
        If Facebook = "Yes" Then
            sql += "'TRUE',"
            sql += "'TRUE',"
        Else
        End If
        If Fax = "Yes" Then
            sql += "'TRUE',"
        Else
        End If
        If Sms = "Yes" Then
            sql += "'TRUE',"
        Else
        End If
        If Chat = "Yes" Then
            sql += "'TRUE',"
        Else
        End If
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'FALSE',"
        sql += "'FALSE',"
        sql += "'FALSE',"
        sql += "'FALSE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE'"
        sql += ")"
        Try
            com = New SqlCommand(sql, con)
            con.Open()
            com.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Function

    Function INSERT_PIC_UNIT(ByVal Ticket As String, ByVal Email As String, ByVal Twitter As String, ByVal Facebook As String, ByVal Fax As String, ByVal Sms As String, ByVal Chat As String)
        Dim sql As String
        sql += "INSERT INTO MTrustee("
        sql += "[LEVEL_USER],"
        sql += "[LEVEL_USER_SBG],"
        sql += "[DESCRIPTION],"
        sql += "[MT],"
        sql += "[MT_STY],"
        sql += "[MT_GTY],"
        sql += "[MT_TTY],"
        sql += "[MT_CON],"
        sql += "[MT_CTW],"
        sql += "[MT_CTR],"
        sql += "[MT_STS],"
        sql += "[MT_DKY],"
        sql += "[MT_EAL],"
        sql += "[MT_EAD],"
        sql += "[DS],"
        sql += "[CH],"
        If Email = "Yes" Then
            sql += "[CH_EMA],"
        Else
        End If
        If Twitter = "Yes" Then
            sql += "[CH_TWT],"
            sql += "[CH_TKS],"
        Else
        End If
        If Facebook = "Yes" Then
            sql += "[CH_FCB],"
            sql += "[CH_FKS],"
        Else
        End If
        If Fax = "Yes" Then
            sql += "[CH_FAX],"
        Else
        End If
        If Sms = "Yes" Then
            sql += "[CH_SMS],"
        Else
        End If
        If Chat = "Yes" Then
            sql += "[CH_CHA],"
        Else
        End If
        sql += "[TIK],"
        sql += "[TK_CRT],"
        sql += "[TK_THS],"
        sql += "[UM],"
        sql += "[UM_ADS],"
        sql += "[UM_SUP],"
        sql += "[RP],"
        sql += "[CT],"
        sql += "[GF],"
        sql += "[KB]"
        sql += ")"
        sql += "VALUES("
        sql += "'PICUnit','layer3','Layer3',"
        sql += "'FALSE',"
        sql += "'FALSE',"
        sql += "'FALSE',"
        sql += "'FALSE',"
        sql += "'FALSE',"
        sql += "'FALSE',"
        sql += "'FALSE',"
        sql += "'FALSE',"
        sql += "'FALSE',"
        sql += "'FALSE',"
        sql += "'FALSE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        If Email = "Yes" Then
            sql += "'TRUE',"
        Else
        End If
        If Twitter = "Yes" Then
            sql += "'TRUE',"
            sql += "'TRUE',"
        Else
        End If
        If Facebook = "Yes" Then
            sql += "'TRUE',"
            sql += "'TRUE',"
        Else
        End If
        If Fax = "Yes" Then
            sql += "'TRUE',"
        Else
        End If
        If Sms = "Yes" Then
            sql += "'TRUE',"
        Else
        End If
        If Chat = "Yes" Then
            sql += "'TRUE',"
        Else
        End If
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'FALSE',"
        sql += "'FALSE',"
        sql += "'FALSE',"
        sql += "'FALSE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE'"
        sql += ")"
        Try
            com = New SqlCommand(sql, con)
            con.Open()
            com.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Function

    Function INSERT_ADMIN(ByVal Ticket As String, ByVal Email As String, ByVal Twitter As String, ByVal Facebook As String, ByVal Fax As String, ByVal Sms As String, ByVal Chat As String)
        Dim sql As String
        sql += "INSERT INTO MTrustee("
        sql += "[LEVEL_USER],"
        sql += "[LEVEL_USER_SBG],"
        sql += "[DESCRIPTION],"
        sql += "[MT],"
        sql += "[MT_STY],"
        sql += "[MT_GTY],"
        sql += "[MT_TTY],"
        sql += "[MT_CON],"
        sql += "[MT_CTW],"
        sql += "[MT_CTR],"
        sql += "[MT_STS],"
        sql += "[MT_DKY],"
        sql += "[MT_EAL],"
        sql += "[MT_EAD],"
        sql += "[DS],"
        sql += "[CH],"
        If Email = "Yes" Then
            sql += "[CH_EMA],"
        Else
        End If
        If Twitter = "Yes" Then
            sql += "[CH_TWT],"
            sql += "[CH_TKS],"
        Else
        End If
        If Facebook = "Yes" Then
            sql += "[CH_FCB],"
            sql += "[CH_FKS],"
        Else
        End If
        If Fax = "Yes" Then
            sql += "[CH_FAX],"
        Else
        End If
        If Sms = "Yes" Then
            sql += "[CH_SMS],"
        Else
        End If
        If Chat = "Yes" Then
            sql += "[CH_CHA],"
        Else
        End If
        sql += "[TIK],"
        sql += "[TK_CRT],"
        sql += "[TK_THS],"
        sql += "[UM],"
        sql += "[UM_ADS],"
        sql += "[UM_SUP],"
        sql += "[RP],"
        sql += "[CT],"
        sql += "[GF],"
        sql += "[KB]"
        sql += ")"
        sql += "VALUES("
        sql += "'Admin','Admin','Admin',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        If Email = "Yes" Then
            sql += "'TRUE',"
        Else
        End If
        If Twitter = "Yes" Then
            sql += "'TRUE',"
            sql += "'TRUE',"
        Else
        End If
        If Facebook = "Yes" Then
            sql += "'TRUE',"
            sql += "'TRUE',"
        Else
        End If
        If Fax = "Yes" Then
            sql += "'TRUE',"
        Else
        End If
        If Sms = "Yes" Then
            sql += "'TRUE',"
        Else
        End If
        If Chat = "Yes" Then
            sql += "'TRUE',"
        Else
        End If
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE'"
        sql += ")"
        Try
            com = New SqlCommand(sql, con)
            con.Open()
            com.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Function

    Function INSERT_SUPERVISOR(ByVal Ticket As String, ByVal Email As String, ByVal Twitter As String, ByVal Facebook As String, ByVal Fax As String, ByVal Sms As String, ByVal Chat As String)
        Dim sql As String
        sql += "INSERT INTO MTrustee("
        sql += "[LEVEL_USER],"
        sql += "[LEVEL_USER_SBG],"
        sql += "[DESCRIPTION],"
        sql += "[MT],"
        sql += "[MT_STY],"
        sql += "[MT_GTY],"
        sql += "[MT_TTY],"
        sql += "[MT_CON],"
        sql += "[MT_CTW],"
        sql += "[MT_CTR],"
        sql += "[MT_STS],"
        sql += "[MT_DKY],"
        sql += "[MT_EAL],"
        sql += "[MT_EAD],"
        sql += "[DS],"
        sql += "[CH],"
        If Email = "Yes" Then
            sql += "[CH_EMA],"
        Else
        End If
        If Twitter = "Yes" Then
            sql += "[CH_TWT],"
            sql += "[CH_TKS],"
        Else
        End If
        If Facebook = "Yes" Then
            sql += "[CH_FCB],"
            sql += "[CH_FKS],"
        Else
        End If
        If Fax = "Yes" Then
            sql += "[CH_FAX],"
        Else
        End If
        If Sms = "Yes" Then
            sql += "[CH_SMS],"
        Else
        End If
        If Chat = "Yes" Then
            sql += "[CH_CHA],"
        Else
        End If
        sql += "[TIK],"
        sql += "[TK_CRT],"
        sql += "[TK_THS],"
        sql += "[UM],"
        sql += "[UM_ADS],"
        sql += "[UM_SUP],"
        sql += "[RP],"
        sql += "[CT],"
        sql += "[GF],"
        sql += "[KB]"
        sql += ")"
        sql += "VALUES("
        sql += "'Supervisor','Supervisor','Supervisor',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        If Email = "Yes" Then
            sql += "'TRUE',"
        Else
        End If
        If Twitter = "Yes" Then
            sql += "'TRUE',"
            sql += "'TRUE',"
        Else
        End If
        If Facebook = "Yes" Then
            sql += "'TRUE',"
            sql += "'TRUE',"
        Else
        End If
        If Fax = "Yes" Then
            sql += "'TRUE',"
        Else
        End If
        If Sms = "Yes" Then
            sql += "'TRUE',"
        Else
        End If
        If Chat = "Yes" Then
            sql += "'TRUE',"
        Else
        End If
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE'"
        sql += ")"
        Try
            com = New SqlCommand(sql, con)
            con.Open()
            com.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Function

    Function INSERT_AGENT_NO_TICKET(ByVal Ticket As String, ByVal Email As String, ByVal Twitter As String, ByVal Facebook As String, ByVal Fax As String, ByVal Sms As String, ByVal Chat As String)
        Dim sql As String
        sql += "INSERT INTO MTrustee("
        sql += "[LEVEL_USER],"
        sql += "[LEVEL_USER_SBG],"
        sql += "[DESCRIPTION],"
        sql += "[MT],"
        sql += "[MT_STY],"
        sql += "[MT_GTY],"
        sql += "[MT_TTY],"
        sql += "[MT_STS],"
        sql += "[MT_DKY],"
        sql += "[DS],"
        sql += "[CH],"
        If Email = "Yes" Then
            sql += "[CH_EMA],"
        Else
        End If
        If Twitter = "Yes" Then
            sql += "[CH_TWT],"
            sql += "[CH_TKS],"
        Else
        End If
        If Facebook = "Yes" Then
            sql += "[CH_FCB],"
            sql += "[CH_FKS],"
        Else
        End If
        If Fax = "Yes" Then
            sql += "[CH_FAX],"
        Else
        End If
        If Sms = "Yes" Then
            sql += "[CH_SMS],"
        Else
        End If
        If Chat = "Yes" Then
            sql += "[CH_CHA],"
        Else
        End If
        sql += "[UM],"
        sql += "[UM_ADS],"
        sql += "[UM_SUP],"
        sql += "[RP],"
        sql += "[CT],"
        sql += "[GF],"
        sql += "[KB]"
        sql += ")"
        sql += "VALUES("
        sql += "'Agent','layer1','Layer1',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        If Email = "Yes" Then
            sql += "'TRUE',"
        Else
        End If
        If Twitter = "Yes" Then
            sql += "'TRUE',"
            sql += "'TRUE',"
        Else
        End If
        If Facebook = "Yes" Then
            sql += "'TRUE',"
            sql += "'TRUE',"
        Else
        End If
        If Fax = "Yes" Then
            sql += "'TRUE',"
        Else
        End If
        If Sms = "Yes" Then
            sql += "'TRUE',"
        Else
        End If
        If Chat = "Yes" Then
            sql += "'TRUE',"
        Else
        End If
        sql += "'FALSE',"
        sql += "'FALSE',"
        sql += "'FALSE',"
        sql += "'FALSE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE'"
        sql += ")"
        Try
            com = New SqlCommand(sql, con)
            con.Open()
            com.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Function

    Function INSERT_ADMIN_NO_TICKET(ByVal Ticket As String, ByVal Email As String, ByVal Twitter As String, ByVal Facebook As String, ByVal Fax As String, ByVal Sms As String, ByVal Chat As String)
        Dim sql As String
        sql += "INSERT INTO MTrustee("
        sql += "[LEVEL_USER],"
        sql += "[LEVEL_USER_SBG],"
        sql += "[DESCRIPTION],"
        sql += "[MT],"
        sql += "[MT_STY],"
        sql += "[MT_GTY],"
        sql += "[MT_TTY],"
        sql += "[MT_STS],"
        sql += "[MT_DKY],"
        sql += "[DS],"
        sql += "[CH],"
        If Email = "Yes" Then
            sql += "[CH_EMA],"
        Else
        End If
        If Twitter = "Yes" Then
            sql += "[CH_TWT],"
            sql += "[CH_TKS],"
        Else
        End If
        If Facebook = "Yes" Then
            sql += "[CH_FCB],"
            sql += "[CH_FKS],"
        Else
        End If
        If Fax = "Yes" Then
            sql += "[CH_FAX],"
        Else
        End If
        If Sms = "Yes" Then
            sql += "[CH_SMS],"
        Else
        End If
        If Chat = "Yes" Then
            sql += "[CH_CHA],"
        Else
        End If
        sql += "[UM],"
        sql += "[UM_ADS],"
        sql += "[UM_SUP],"
        sql += "[RP],"
        sql += "[CT],"
        sql += "[GF],"
        sql += "[KB]"
        sql += ")"
        sql += "VALUES("
        sql += "'Admin','Admin','Admin',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        If Email = "Yes" Then
            sql += "'TRUE',"
        Else
        End If
        If Twitter = "Yes" Then
            sql += "'TRUE',"
            sql += "'TRUE',"
        Else
        End If
        If Facebook = "Yes" Then
            sql += "'TRUE',"
            sql += "'TRUE',"
        Else
        End If
        If Fax = "Yes" Then
            sql += "'TRUE',"
        Else
        End If
        If Sms = "Yes" Then
            sql += "'TRUE',"
        Else
        End If
        If Chat = "Yes" Then
            sql += "'TRUE',"
        Else
        End If
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE'"
        sql += ")"
        Try
            com = New SqlCommand(sql, con)
            con.Open()
            com.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Function

    Function INSERT_SUPERVISOR_NO_TICKET(ByVal Ticket As String, ByVal Email As String, ByVal Twitter As String, ByVal Facebook As String, ByVal Fax As String, ByVal Sms As String, ByVal Chat As String)
        Dim sql As String
        sql += "INSERT INTO MTrustee("
        sql += "[LEVEL_USER],"
        sql += "[LEVEL_USER_SBG],"
        sql += "[DESCRIPTION],"
        sql += "[MT],"
        sql += "[MT_STY],"
        sql += "[MT_GTY],"
        sql += "[MT_TTY],"
        sql += "[MT_STS],"
        sql += "[MT_DKY],"
        sql += "[DS],"
        sql += "[CH],"
        If Email = "Yes" Then
            sql += "[CH_EMA],"
        Else
        End If
        If Twitter = "Yes" Then
            sql += "[CH_TWT],"
            sql += "[CH_TKS],"
        Else
        End If
        If Facebook = "Yes" Then
            sql += "[CH_FCB],"
            sql += "[CH_FKS],"
        Else
        End If
        If Fax = "Yes" Then
            sql += "[CH_FAX],"
        Else
        End If
        If Sms = "Yes" Then
            sql += "[CH_SMS],"
        Else
        End If
        If Chat = "Yes" Then
            sql += "[CH_CHA],"
        Else
        End If
        sql += "[UM],"
        sql += "[UM_ADS],"
        sql += "[UM_SUP],"
        sql += "[RP],"
        sql += "[CT],"
        sql += "[GF],"
        sql += "[KB]"
        sql += ")"
        sql += "VALUES("
        sql += "'Supervisor','Supervisor','Supervisor',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        If Email = "Yes" Then
            sql += "'TRUE',"
        Else
        End If
        If Twitter = "Yes" Then
            sql += "'TRUE',"
            sql += "'TRUE',"
        Else
        End If
        If Facebook = "Yes" Then
            sql += "'TRUE',"
            sql += "'TRUE',"
        Else
        End If
        If Fax = "Yes" Then
            sql += "'TRUE',"
        Else
        End If
        If Sms = "Yes" Then
            sql += "'TRUE',"
        Else
        End If
        If Chat = "Yes" Then
            sql += "'TRUE',"
        Else
        End If
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE',"
        sql += "'TRUE'"
        sql += ")"
        Try
            com = New SqlCommand(sql, con)
            con.Open()
            com.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Function

End Class