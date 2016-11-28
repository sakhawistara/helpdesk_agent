Imports System.Web
Imports System.Web.UI
Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class callback
    Inherits System.Web.UI.Page

    Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString)
    Dim Sqlcon_Sosmed As New SqlConnection(ConfigurationManager.ConnectionStrings("SosmedConnection").ConnectionString)
    Dim com As SqlCommand
    Dim dr As SqlDataReader
    Dim strSql, strSqlString As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SourceType.SelectCommand = "select * from mSourceType where NA='Y' order by name asc"
        GroupType.SelectCommand = "select * from mGroupType where NA='Y'"
        SourceCategori.SelectCommand = "select * from mcategory where NA='Y'"
        div_properties.Visible = True
    End Sub

    Private Sub callbackPanelX_Callback(sender As Object, e As DevExpress.Web.ASPxClasses.CallbackEventArgsBase) Handles callbackPanelX.Callback
        'SourceCategoriI.SelectCommand = "select * from mSubCategoryLv1 where CategoryID='" & mCatID.Value & "'"
        div_properties.Visible = True
        Dim Response_agent As String
        If mCatID.Value = "Refresh" Then
            Category.Value = ""
            SubCategoryI.Value = ""
            SubCategoryII.Value = ""
            SubCategoryIII.Value = ""
        Else
            If SubCategoryIII.Text <> "" Then
                Dim ExCat, Categori, Cat1, Sub1, Sub2, SubCategory1, SubCategory2, PriorityValue, SeverityValue, ValueSLA, SubCategory3 As String
                ExCat = " SELECT dbo.mCategory.*, dbo.mSubCategoryLv1.*,dbo.mSubCategoryLv1.SubName AS SubName1, dbo.mSubCategoryLv2.SubName AS SubName2, dbo.mSubCategoryLv3.* " & _
                        " FROM dbo.mCategory INNER JOIN " & _
                        " dbo.mSubCategoryLv1 ON dbo.mCategory.CategoryID = dbo.mSubCategoryLv1.CategoryID INNER JOIN " & _
                        " dbo.mSubCategoryLv2 ON dbo.mSubCategoryLv1.SubCategory1ID = dbo.mSubCategoryLv2.SubCategory1ID INNER JOIN " & _
                        " dbo.mSubCategoryLv3 ON dbo.mSubCategoryLv2.SubCategory2ID = dbo.mSubCategoryLv3.SubCategory2ID " & _
                        " where dbo.mSubCategoryLv3.SubCategory3ID = '" & mCatID.Value & "'"
                com = New SqlCommand(ExCat, con)
                con.Open()
                dr = com.ExecuteReader()
                dr.Read()
                Categori = dr("Name").ToString
                SubCategory1 = dr("SubName1").ToString
                SubCategory2 = dr("SubName2").ToString
                SubCategory3 = dr("SubName").ToString
                PriorityValue = dr("Priority").ToString
                SeverityValue = dr("Severity").ToString
                Cat1 = dr("CategoryID").ToString
                Sub1 = dr("SubCategory1ID").ToString
                Sub2 = dr("SubCategory2ID").ToString
                ValueSLA = dr("SLA").ToString
                Response_agent = dr("Response_Agent").ToString
                dr.Close()
                con.Close()
                Category.Value = Categori
                SubCategoryI.Value = SubCategory1
                SubCatI.Value = Sub1
                SubCatII.Value = Sub2
                CategoryHidden.Value = Cat1
                SubCategoryII.Value = SubCategory2
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
End Class