Imports System.Data
Imports System.Data.SqlClient
Imports System.Web
Public Class setting_user
    Inherits System.Web.UI.Page

    Dim strArr
    Dim strTrustee
    Dim strSta
    Dim strStatus As String = ""
    Dim strCheckBox As String = ""
    Dim sql As String
    Dim Proses As New ClsConn
    Dim sqldr As SqlDataReader
    Dim i As Integer
    Dim com As New SqlCommand
    Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        btn_simpan.Visible = False
        sql_level_user.SelectCommand = "select * from mLevelUser"
        sql_submenu.SelectCommand = "select distinct User4.MenuID,  user1.MenuName, User2.SubMenuID, User2.SubMenuName from User4 " & _
                                    "inner join User2 on User4.SubMenuID = User2.SubMenuID left outer join user1 on user4.MenuID = user1.MenuID " & _
                                    "where User2.MenuID='" & txtGroupID.Value & "' and user4.UserID='" & mCatID.Value & "'"
        'sql_subMenu_dr.SelectCommand = "SELECT * FROM User2 Where MenuID='" & txtGroupID.Value & "'"
    End Sub

    Private Sub callbackPanelX_Callback(sender As Object, e As DevExpress.Web.ASPxClasses.CallbackEventArgsBase) Handles callbackPanelX.Callback
        sql_user.SelectCommand = "select ROW_NUMBER() over (order by User1.MenuID Asc) as Nomor, User1.MenuID, User1.MenuName from User4 inner join User1 on User4.MenuID = User1.MenuID where User4.UserID='" & mCatID.Value & "' group by User1.MenuName, User1.MenuID"
    End Sub

    Private Sub ASPxCallbackPanel1_Callback(sender As Object, e As DevExpress.Web.ASPxClasses.CallbackEventArgsBase) Handles ASPxCallbackPanel1.Callback
        ASPxGridView1.Visible = True
        sql_submenu.SelectCommand = "select distinct User4.MenuID,  user1.MenuName, User2.SubMenuID, User2.SubMenuName from User4 " & _
                                    "inner join User2 on User4.SubMenuID = User2.SubMenuID left outer join user1 on user4.MenuID = user1.MenuID " & _
                                    "where User2.MenuID='" & txtGroupID.Value & "' and user4.UserID='" & mCatID.Value & "'"
        sql_subMenu_dr.SelectCommand = "SELECT * FROM User2 Where MenuID='" & txtGroupID.Value & "'"
    End Sub

    Private Sub ASPxCallbackPanel2_Callback(sender As Object, e As DevExpress.Web.ASPxClasses.CallbackEventArgsBase) Handles ASPxCallbackPanel2.Callback
        sql_agent.SelectCommand = "select distinct(User4.UserID), mLevelUser.Description from  User4 left outer join mLevelUser on User4.LevelUserID = mLevelUser.LevelUserID where Description='" & hd_level_user.Value & "'"
    End Sub

    Private Sub gridLevelUser_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs) Handles gridLevelUser.RowDeleting
        sql_user.DeleteCommand = "DELETE FROM User4 WHERE MenuID=@MenuID And UserID='" & cmb_user.Value & "'"
        sql_user.SelectCommand = "select ROW_NUMBER() over (order by user1.menuid Asc) as Nomor, user1.MenuID, user1.MenuName from user4 inner join User1 on user4.MenuID = user1.MenuID where user4.UserID='" & mCatID.Value & "' group by user1.MenuName, user1.MenuID"
    End Sub

    Private Sub gridLevelUser_RowInserting(sender As Object, e As DevExpress.Web.Data.ASPxDataInsertingEventArgs) Handles gridLevelUser.RowInserting
        Dim lv_User As String = ""
        sql = "SELECT * FROM User4 where UserID='" & cmb_user.Value & "'"
        sqldr = Proses.ExecuteReader(sql)
        If sqldr.Read Then
            lv_User = sqldr("LevelUserID").ToString
        End If
        sqldr.Close()
        sql_user.InsertCommand = "INSERT INTO User4 (UserID, MenuID, SubMenuID,  LevelUserID) VALUES ('" & cmb_user.Value & "',@MenuName,'','" & lv_User & "')"
        sql_user.SelectCommand = "select ROW_NUMBER() over (order by user1.menuid Asc) as Nomor, user1.MenuID, user1.MenuName from user4 inner join User1 on user4.MenuID = user1.MenuID where user4.UserID='" & mCatID.Value & "' group by user1.MenuName, user1.MenuID"
    End Sub

    Private Sub ASPxGridView1_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs) Handles ASPxGridView1.RowDeleting
        Dim SubMenuID As String = e.Keys("SubMenuID")
        sql_submenu.DeleteCommand = "DELETE FROM user3 WHERE UserID='" & cmb_user.Value & "' And MenuID='" & txtGroupID.Value & "' And SubMenuID='" & SubMenuID & "'"
        sql_submenu.SelectCommand = "select distinct User4.MenuID,  user1.MenuName, User2.SubMenuID, User2.SubMenuName from User4 " & _
                                  "inner join User2 on User4.SubMenuID = User2.SubMenuID left outer join user1 on user4.MenuID = user1.MenuID " & _
                                 "where User2.MenuID='" & txtGroupID.Value & "' and user4.UserID='" & mCatID.Value & "'"
    End Sub

    Private Sub ASPxGridView1_RowInserting(sender As Object, e As DevExpress.Web.Data.ASPxDataInsertingEventArgs) Handles ASPxGridView1.RowInserting
        Dim lv_User As String = ""
        sql = "SELECT * FROM User3 where UserID='" & cmb_user.Value & "'"
        sqldr = Proses.ExecuteReader(sql)
        If sqldr.Read Then
            lv_User = sqldr("LevelUserID").ToString
        End If
        sqldr.Close()
        sql_submenu.InsertCommand = "INSERT INTO User3(UserID, MenuID, SubMenuID, LevelUserID) VALUES ('" & cmb_user.Value & "','" & txtGroupID.Value & "',@SubMenuName,'" & lv_User & "')"
        sql_submenu.SelectCommand = "select distinct User4.MenuID,  user1.MenuName, User2.SubMenuID, User2.SubMenuName from User4 " & _
                                   "inner join User2 on User4.SubMenuID = User2.SubMenuID left outer join user1 on user4.MenuID = user1.MenuID " & _
                                  "where User2.MenuID='" & txtGroupID.Value & "' and user4.UserID='" & mCatID.Value & "'"
    End Sub

    Private Sub btn_back_Click(sender As Object, e As EventArgs) Handles btn_back.Click
        Response.Redirect("~/HTML/dashboard.aspx?page=dashboard")
    End Sub

    Private Sub ASPxCallbackPanel3_Callback(sender As Object, e As DevExpress.Web.ASPxClasses.CallbackEventArgsBase) Handles ASPxCallbackPanel3.Callback
        ASPxGridView2.Visible = True
        sql_submenu_tree.SelectCommand = "select distinct user3.SubMenuIDTree, user3.MenuTreeName " & _
                                         "from User3 left outer join User2 on.user3.SubMenuID = user2.SubMenuID Where user3.SubMenuID='" & HiddenField1.Value & "'"
    End Sub
End Class