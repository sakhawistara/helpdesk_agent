Public Class report_transaksi
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dsChannelTransaksi.SelectCommand = "select * from mSourceType Where NA = 'Y'"
        dsJenisTransaksi.SelectCommand = "select * from mCategory"
        dsUnitKerja.SelectCommand = "select b.SubCategory1ID as SubCategory1ID,a.Name as JenisTransaksi,b.SubName as SubjectTable,b.NA,b.ID from mCategory a left outer join mSubCategoryLv1 b on a.CategoryID = b.CategoryID where b.SubName <> ''"
        dsSubject.SelectCommand = "select b.SubCategory2ID as SubCategory2ID, a.Name as JenisTransaksi,b.SubName as SubjectTable,c.SubName as UnitKerja,b.NA,b.ID from mCategory a left outer join mSubCategoryLv2 b on a.CategoryID = b.CategoryID left outer join mSubCategoryLv1 as c on b.SubCategory1ID=c.SubCategory1ID where c.SubName <> ''"

    End Sub

End Class