Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.UI
Imports DevExpress.Web.ASPxGridView
Public Class um
    Inherits System.Web.UI.Page

    Dim ceknull As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        sql_user.SelectCommand = "Select * from msuser"
        sql_user.InsertCommand = "INSERT INTO MSUSER (USERNAME, LEVELUSER) VALUES (@USERNAME,@LEVELUSER)"
        sql_user.DeleteCommand = "DELETE MSUSER WHERE USERNAME=@USERNAME"
        sql_level_user.SelectCommand = "select * from mLevelUser"
        sql_menu.InsertCommand = "INSERT INTO USER4 (USERID, MENUID, LEVELUSERID) VALUES ('" & Session("NIK") & "', @MenuName, '312')"
    End Sub
    Protected Sub TicketNumber_DataSelect(ByVal sender As Object, ByVal e As EventArgs)
        Session("NIK") = (TryCast(sender, ASPxGridView)).GetMasterRowKeyValue()
        sql_menu.SelectCommand = "select DISTINCT USER4.MenuID, USER1.MenuName from user4 LEFT OUTER JOIN User1 ON.USER4.MenuID = USER1.MenuID where USER4.UserID='" & Session("NIK") & "'"
        sql_sub_menu.InsertCommand = "INSERT INTO USER4 (USERID, MENUID, SUBMENUID, LEVELUSERID) VALUES ('" & Session("NIK") & "','" & Session("MenuID") & "', @SubMenuName, '312')"
    End Sub
    Protected Sub GridList_DataSelect(ByVal sender As Object, ByVal e As EventArgs)
        Session("MenuID") = (TryCast(sender, ASPxGridView)).GetMasterRowKeyValue()
        sql_subMenu_dr.SelectCommand = "SELECT * FROM USER2 WHERE MENUID='" & Session("MenuID") & "'"
        sql_sub_menu.SelectCommand = "select DISTINCT user2.MenuID, USER4.SubMenuID, USER2.SubMenuName from user4 LEFT OUTER JOIN User2 ON.USER4.SubMenuID = USER2.SubMenuID where USER4.UserID='" & Session("NIK") & "' And USER2.MenuID='" & Session("MenuID") & "'"
    End Sub

    Protected Sub gv_menu_tree_DataSelect(ByVal sender As Object, ByVal e As EventArgs)
        Session("SubMenuID") = (TryCast(sender, ASPxGridView)).GetMasterRowKeyValue()
        sql_menu_tree.SelectCommand = "select DISTINCT USER3.SubMenuIDTree, USER3.MenuTreeName from user4 LEFT OUTER JOIN USER3 ON.USER4.MenuIDTree = USER3.SubMenuIDTree where USER3.SubMenuID='" & Session("SubMenuID") & "'"
        sql_User3.SelectCommand = "Select * from user3 where SubMenuID='" & Session("SubMenuID") & "'"
    End Sub
End Class