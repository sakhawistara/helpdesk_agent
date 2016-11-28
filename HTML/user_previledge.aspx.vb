Imports System.Data
Imports System.Data.SqlClient
Imports System.Web
Public Class user_previledge
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
        btn_simpan.Visible = True
        sql_agent.SelectCommand = "select distinct(user3.userid), mLevelUser.Description from  user3 left outer join mLevelUser on user3.LevelUserID = mLevelUser.LevelUserID"
        sql_submenu.SelectCommand = "select user3.MenuID,  user1.MenuName, user2.SubMenuID, user2.SubMenuName, user3.Status  from User3  inner join User2 on User3.SubMenuID = user2.SubMenuID " & _
              "inner join user1 on User1.MenuID = user3.MenuID where User3.MenuID='373' and user3.UserID='Agent-0'" & _
              "group by user1.MenuName,user2.SubMenuID, user2.SubMenuName, user3.Status, user3.MenuID"
    End Sub

    Private Sub callbackPanelX_Callback(sender As Object, e As DevExpress.Web.ASPxClasses.CallbackEventArgsBase) Handles callbackPanelX.Callback
        sql_user.SelectCommand = "select ROW_NUMBER() over (order by user1.menuid Asc) as Nomor, user1.MenuID, user1.MenuName from user3 inner join User1 on user3.MenuID = user1.MenuID where user3.UserID='" & mCatID.Value & "' group by user1.MenuName, user1.MenuID"
        sql_submenu.SelectCommand = "select user3.MenuID,  user1.MenuName, user2.SubMenuID, user2.SubMenuName, user3.Status  from User3  inner join User2 on User3.SubMenuID = user2.SubMenuID " & _
              "inner join user1 on User1.MenuID = user3.MenuID where User3.MenuID='373' and user3.UserID='Agent-0'" & _
              "group by user1.MenuName,user2.SubMenuID, user2.SubMenuName, user3.Status, user3.MenuID"
    End Sub

    Private Sub ASPxCallbackPanel1_Callback(sender As Object, e As DevExpress.Web.ASPxClasses.CallbackEventArgsBase) Handles ASPxCallbackPanel1.Callback    
        sql_submenu.SelectCommand = "select user3.MenuID,  user1.MenuName, user2.SubMenuID, user2.SubMenuName  from User3  inner join User2 on User3.SubMenuID = user2.SubMenuID " & _
              "inner join user1 on User1.MenuID = user3.MenuID where User3.MenuID='" & txtGroupID.Value & "' and user3.UserID='" & mCatID.Value & "'" & _
              "group by user1.MenuName,user2.SubMenuID, user2.SubMenuName, user3.MenuID"
        Dim i As Integer = 0
        'sql = "select user3.MenuID,  user1.MenuName, user2.SubMenuID, user2.SubMenuName from User3  inner join User2 on User3.SubMenuID = user2.SubMenuID " & _
        '      "inner join user1 on User1.MenuID = user3.MenuID where User3.MenuID='" & txtGroupID.Value & "' and user3.UserID='" & mCatID.Value & "'" & _
        '      "group by user1.MenuName,user2.SubMenuID, user2.SubMenuName, user3.MenuID"
        'sqldr = Proses.ExecuteReader(sql)
        'While sqldr.Read()
        '    strCheckBox += "" & sqldr("SubMenuID") & ";"
        '    strStatus += "" & sqldr("Status") & ";"
        'End While
        'sqldr.Close()
        'strCheckBox = strCheckBox.TrimEnd(";")
        'strStatus = strStatus.TrimEnd(";")

        'strArr = strStatus.Split(";")
        'For i = 0 To checkBoxList.Items.Count - 1
        '    checkBoxList.Items(i).Selected = False
        '    For count = 0 To strArr.Length - 1
        '        If strArr(i) = "TRUE" Then
        '            checkBoxList.Items(i).Selected = True
        '        Else
        '            checkBoxList.Items(i).Selected = False
        '        End If
        '        'MsgBox(strArr(count), vbSystemModal)
        '    Next
        'Next
    End Sub
End Class