Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.UI
Imports DevExpress.Web
Public Class ReportFilter
    Inherits System.Web.UI.Page

    Dim getYear As String
    Dim FormatWaktuStart As System.DateTime
    Dim FormatWaktuEnd As System.DateTime
    Dim Tahun, Bulan, Hari, ReportTransaksiTime, TahunEnd, BulanEnd, HariEnd, ReportTransaksiEnd As String

    Protected Sub list()
        If Not Page.IsPostBack Then
            dsJenisTransaksi.SelectCommand = "select * from mCategory"
            dsChannelTransaksi.SelectCommand = "select * from mSourceType Where NA = 'Y'"
            dsUnitKerja.SelectCommand = "select b.SubCategory1ID as SubCategory1ID,a.Name as JenisTransaksi,b.SubName as SubjectTable,b.NA,b.ID from mCategory a left outer join mSubCategoryLv1 b on a.CategoryID = b.CategoryID where b.SubName <> ''"
            dsSubject.SelectCommand = "select b.SubCategory2ID as SubCategory2ID, a.Name as JenisTransaksi,b.SubName as SubjectTable,c.SubName as UnitKerja,b.NA,b.ID from mCategory a left outer join mSubCategoryLv2 b on a.CategoryID = b.CategoryID left outer join mSubCategoryLv1 as c on b.SubCategory1ID=c.SubCategory1ID where c.SubName <> ''"
            dsNamaKaryawan.SelectCommand = "select NIK,Name from mKaryawan order by Name asc"
            Dim myReport = New ArrayList
            'myReport.Add("Report Performance Team Support")
            myReport.Add("Report Transaksi")
            'myReport.Add("Report Performa Petugas HCSC")
            myReport.Add("Report Top Kategori Transaksi")
            myReport.Add("Report Sla Transaksi")
            myReport.Add("Report Product")
            myReport.Add("Report Staf")

            myReport.TrimToSize()
            rbList.DataSource = myReport
            rbList.DataBind()
            'rbList.Items.FindByValue("Report Performance Team Support").Selected = True
        End If
    End Sub

    Protected Sub checkList()
        If rbList.SelectedItem IsNot Nothing Then
            If rbList.SelectedItem.Index = 0 Or rbList.SelectedItem.Index = 1 Or rbList.SelectedItem.Index = 2 Or rbList.SelectedItem.Index = 3 Then
                Me.byTgl.Visible = False
                Me.byPeriod.Visible = True
                'Call listPeriod()
                Me.dsYear.SelectCommand = "SELECT DISTINCT year(DateCreate) as Year FROM tticket"
            Else
                Me.byTgl.Visible = True
                Me.byPeriod.Visible = False
            End If
        End If
    End Sub

    Protected Sub PreviewButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PreviewButton.Click
        Session("df") = ""
        Session("dt") = ""
        Dim aaa As String
        aaa = filterMonth.Value
        Dim lastMonth As System.DateTime
        lastMonth = System.DateTime.Now
        'Response.Write(rbList.SelectedItem.Value())

        If rbList.SelectedItem.Value() = "Report Performance Team Support" Then
            Session("df") = selYear.Value & "-" & filterMonth.Value & "-01"
            Session("dt") = filterMonth.Value
            Session("chnlTran") = cbChannelTransaksi.Text
            Session("jnsTran") = cbJenisTransaksi.Text
            Session("statTran") = cbStatusTransaksi.Text
            'Response.Write(Session("df"))
            Response.RedirectPermanent("Report2.aspx?3=Y")
        ElseIf rbList.SelectedItem.Value() = "Report Transaksi" Then
            'FormatWaktuStart = TxtDateFrom.Value
            'FormatWaktuEnd = TxtDateTo.Value
            'Tahun = FormatWaktuStart.Year
            'Bulan = FormatWaktuStart.Month
            'Hari = FormatWaktuStart.Day
            'TahunEnd = FormatWaktuEnd.Year
            'BulanEnd = FormatWaktuEnd.Month
            'HariEnd = FormatWaktuEnd.Day
            'ReportTransaksiTime = Tahun & "-" & Bulan & "-" & Hari
            'ReportTransaksiEnd = TahunEnd & "-" & BulanEnd & "-" & HariEnd
            'Session("df") = ReportTransaksiTime
            'Session("dt") = ReportTransaksiEnd
            Session("df") = FormatDateTime(TxtDateFrom.Value, DateFormat.ShortDate)
            Session("dt") = FormatDateTime(TxtDateTo.Value, DateFormat.ShortDate)
            Session("chnlTran") = cbChannelTransaksi.Text
            Session("jnsTran") = cbJenisTransaksi.Text
            Session("untKerja") = cbUnitKerja.Text
            Session("Subject") = cbSubject.Text
            Session("statTran") = cbStatusTransaksi.Text
            Response.RedirectPermanent("Report2.aspx?2=Y")
        ElseIf rbList.SelectedItem.Value() = "Report Performa Petugas HCSC" Then
            Session("df") = FormatDateTime(TxtDateFrom.Value, DateFormat.ShortDate)
            Session("dt") = FormatDateTime(TxtDateTo.Value, DateFormat.ShortDate)
            Session("tranOleh") = cbTransaksiOleh.Text
            Session("nmPetugas") = cbNamaKaryawan.Text
            Session("statTran") = cbStatusTransaksi.Text
            Session("jnsKerja") = cbJenisTransaksi.Text

            Response.RedirectPermanent("Report2.aspx?3=Y")
        ElseIf rbList.SelectedItem.Value() = "Report Top Kategori Transaksi" Then
            Session("df") = FormatDateTime(TxtDateFrom.Value, DateFormat.ShortDate)
            Session("dt") = FormatDateTime(TxtDateTo.Value, DateFormat.ShortDate)
            Dim Xtring As String = cbFilterTop.Value
            Dim strArray() As String = Xtring.Split(";")
            Session("filterTopJum") = strArray(0)
            Session("filterTopKet") = strArray(1)
            If cbJenisTransaksi.Text <> "" Then
                Session("filterBy") = cbJenisTransaksi.Text

            End If
            If cbUnitKerja.Text <> "" Then
                Session("filterBy") = cbUnitKerja.Text
            End If

            Response.RedirectPermanent("Report2.aspx?4=Y")
        ElseIf rbList.SelectedItem.Value() = "Report Sla Transaksi" Then
            Session("df") = FormatDateTime(TxtDateFrom.Value, DateFormat.ShortDate)
            Session("dt") = FormatDateTime(TxtDateTo.Value, DateFormat.ShortDate)
            Session("tranOleh") = cbTransaksiOleh.Text
            Session("nmPetugas") = cbNamaKaryawan.Text
            Session("statTran") = cbStatusTransaksi.Text
            Session("jnsTran") = cbJenisTransaksi.Text

            Response.RedirectPermanent("Report2.aspx?5=Y")

        ElseIf rbList.SelectedItem.Value() = "Report Product" Then
            Session("df") = FormatDateTime(TxtDateFrom.Value, DateFormat.ShortDate)
            Session("dt") = FormatDateTime(TxtDateTo.Value, DateFormat.ShortDate)

            Response.RedirectPermanent("report_inv.aspx?1=Y")

        ElseIf rbList.SelectedItem.Value() = "Report Staf" Then
            Session("df") = FormatDateTime(TxtDateFrom.Value, DateFormat.ShortDate)
            Session("dt") = FormatDateTime(TxtDateTo.Value, DateFormat.ShortDate)
            Session("divisi") = cmb_staf.Value
            Response.RedirectPermanent("report_inv.aspx?2=Y&div=" & Session("divisi") & "")

        End If

    End Sub

    Protected Sub TxtDateFrom_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDateFrom.ValueChanged
        TxtDateTo.MinDate = TxtDateFrom.Value
    End Sub

    Protected Sub TxtDateTo_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDateTo.ValueChanged
        TxtDateFrom.MaxDate = TxtDateTo.Value
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call list()
        'Call checkList()
        Me.byTgl.Visible = True
        Me.byPeriod.Visible = False
        Me.dsYear.SelectCommand = "SELECT DISTINCT year(DateCreate) as Year FROM tTicket"
        getYear = Year(Date.Now)
        filterMonth.Visible = False
        Dim typeCategory As String = rbList.Value

        If typeCategory = "Report Performance HCSC" Then
            filterMonthSql.SelectCommand = "select DISTINCT b.Bulan, b.NamaBulan,CAST(CAST(DATEPART(YYYY,DateCreate)AS VARCHAR(4))+'/'+ CAST(DATEPART(m, DATEADD(m, 0, DateCreate)) AS VARCHAR(2))+'/'+ '01' AS Date) as tanggal from tTicket a left outer join namabulan b on CAST(DATEPART(M,DateCreate)AS VARCHAR(20))= b.Bulan order by b.Bulan Asc"
            filterMonth.Visible = True
            selYear.Visible = True
            TxtDateFrom.Visible = False
            TxtDateTo.Visible = False
            lblTo.Visible = False
            SourceDetail.Visible = True
            'Response.Redirect("ReportFilter.aspx")

            ''filternya
            headChnlTrx.Visible = True
            isiChnlTrx.Visible = True

            headJnsTrx.Visible = True
            isiJnsTrx.Visible = True

            headStatTrx.Visible = True
            isiStatTrx.Visible = True

            headUnitKerja.Visible = False
            isiUnitKerja.Visible = False

            headSubject.Visible = False
            isiSubject.Visible = False

            headAgentName.Visible = False
            isiAgentName.Visible = False

            headClosedBy.Visible = False
            isiCLosedBy.Visible = False
            headTrxOleh.Visible = False

            staf.Visible = False
            cmb_staf.Visible = False
        ElseIf typeCategory = "Report Transaksi" Then
            selYear.Visible = False
            TxtDateFrom.Visible = True
            TxtDateTo.Visible = True
            filterMonth.Visible = False
            ''filternya
            headChnlTrx.Visible = True
            isiChnlTrx.Visible = True

            headJnsTrx.Visible = True
            isiJnsTrx.Visible = True

            headStatTrx.Visible = True
            isiStatTrx.Visible = True

            headUnitKerja.Visible = True
            isiUnitKerja.Visible = True

            headSubject.Visible = True
            isiSubject.Visible = True

            headAgentName.Visible = False
            isiAgentName.Visible = False

            headClosedBy.Visible = False
            isiCLosedBy.Visible = False
            headTrxOleh.Visible = False

            staf.Visible = False
            cmb_staf.Visible = False
        ElseIf typeCategory = "Report Performa Petugas HCSC" Then
            'filterMonth.Visible = False
            'lblTo.Visible = True
            selYear.Visible = False
            TxtDateFrom.Visible = True
            TxtDateTo.Visible = True
            ''filternya
            headChnlTrx.Visible = False
            isiChnlTrx.Visible = False

            headJnsTrx.Visible = True
            isiJnsTrx.Visible = True

            headStatTrx.Visible = True
            isiStatTrx.Visible = True

            headUnitKerja.Visible = False
            isiUnitKerja.Visible = False

            headSubject.Visible = False
            isiSubject.Visible = False

            headAgentName.Visible = True
            isiAgentName.Visible = True

            headTrxOleh.Visible = True
            headTrxClosed.Visible = False
            isiCLosedBy.Visible = True
            'SourceDetail.Visible = True
            'cbJenisTransaksi.Visible = True
            'cbStatusTransaksi.Visible = True
            'cbChannelTransaksi.Visible = False
            'cbSubject.Visible = False
            'cbUnitKerja.Visible = False

            staf.Visible = False
            cmb_staf.Visible = False
        ElseIf typeCategory = "Report Top Kategori Transaksi" Then
            ''filternya
            selYear.Visible = False
            TxtDateFrom.Visible = True
            TxtDateTo.Visible = True

            headFilterTop.Visible = True
            isiFilterTop.Visible = True

            filterMonth.Visible = False
            headChnlTrx.Visible = False
            isiChnlTrx.Visible = False

            headJnsTrx.Visible = False
            isiJnsTrx.Visible = False

            headStatTrx.Visible = False
            isiStatTrx.Visible = False

            headUnitKerja.Visible = False
            isiUnitKerja.Visible = False

            headSubject.Visible = False
            isiSubject.Visible = False

            headAgentName.Visible = False
            isiAgentName.Visible = False

            headClosedBy.Visible = False
            isiCLosedBy.Visible = False
            headTrxOleh.Visible = False

            staf.Visible = False
            cmb_staf.Visible = False

        ElseIf typeCategory = "Report Sla Transaksi" Then
            ''filternya
            selYear.Visible = False
            TxtDateFrom.Visible = True
            TxtDateTo.Visible = True
            filterMonth.Visible = False
            headChnlTrx.Visible = False
            isiChnlTrx.Visible = False

            headJnsTrx.Visible = True
            isiJnsTrx.Visible = True

            headStatTrx.Visible = True
            isiStatTrx.Visible = True

            headUnitKerja.Visible = False
            isiUnitKerja.Visible = False

            headSubject.Visible = False
            isiSubject.Visible = False

            headAgentName.Visible = False
            isiAgentName.Visible = False

            headClosedBy.Visible = False
            isiCLosedBy.Visible = True
            headTrxOleh.Visible = False
            headTrxClosed.Visible = True
            headFilterTop.Visible = False
            isiFilterTop.Visible = False

            staf.Visible = False
            cmb_staf.Visible = False

        ElseIf typeCategory = "Report Product" Then

        ElseIf typeCategory = "Report Staf" Then

        Else
            filterMonth.Visible = False
            lblTo.Visible = True
            TxtDateFrom.Visible = True
            TxtDateTo.Visible = True
            SourceDetail.Visible = True
        End If




        'If typeCategory = "Report Transaksi" Then
        '    filterMonthSql.SelectCommand = "select DISTINCT b.Bulan, b.NamaBulan,CAST(CAST(DATEPART(YYYY,DateCreate)AS VARCHAR(4))+'/'+ CAST(DATEPART(m, DATEADD(m, 0, DateCreate)) AS VARCHAR(2))+'/'+ '01' AS Date) as tanggal from tTicket a left outer join namabulan b on CAST(DATEPART(M,DateCreate)AS VARCHAR(20))= b.Bulan order by b.Bulan Asc"
        '    filterMonth.Visible = True
        '    selYear.Visible = True
        '    TxtDateFrom.Visible = False
        '    TxtDateTo.Visible = False
        '    lblTo.Visible = False
        '    SourceDetail.Visible = True
        '    'Response.Redirect("ReportFilter.aspx")

        '    ''filternya
        '    headChnlTrx.Visible = True
        '    isiChnlTrx.Visible = True

        '    headJnsTrx.Visible = True
        '    isiJnsTrx.Visible = True

        '    headStatTrx.Visible = True
        '    isiStatTrx.Visible = True

        '    headUnitKerja.Visible = True
        '    isiUnitKerja.Visible = True

        '    headSubject.Visible = True
        '    isiSubject.Visible = True

        '    headAgentName.Visible = False
        '    isiAgentName.Visible = False

        '    headClosedBy.Visible = False
        '    isiCLosedBy.Visible = False
        '    headTrxOleh.Visible = False
        '    headFilterTop.Visible = False
        '    isiFilterTop.Visible = False
        'End If
    End Sub

    Protected Sub rbList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbList.SelectedIndexChanged
        'Call checkList()
        'SourceDetail.Visible = True
        'filterMonth.Visible = True

        Dim typeCategory As String = rbList.Value
        dsJenisTransaksi.SelectCommand = "select * from mCategory"
        dsChannelTransaksi.SelectCommand = "select * from mSourceType where NA='Y'"
        dsUnitKerja.SelectCommand = "select b.SubCategory1ID as SubCategory1ID,a.Name as JenisTransaksi,b.SubName as SubjectTable,b.NA,b.ID from mCategory a left outer join mSubCategoryLv1 b on a.CategoryID = b.CategoryID where b.SubName <> ''"
        dsSubject.SelectCommand = "select b.SubCategory2ID as SubCategory2ID, a.Name as JenisTransaksi,b.SubName as SubjectTable,c.SubName as UnitKerja,b.NA,b.ID from mCategory a left outer join mSubCategoryLv2 b on a.CategoryID = b.CategoryID left outer join mSubCategoryLv1 as c on b.SubCategory1ID=c.SubCategory1ID where c.SubName <> ''"
        dsNamaKaryawan.SelectCommand = "select NIK,Name from mKaryawan order by Name asc"
        If typeCategory = "Report Performance HCSC" Then
            filterMonthSql.SelectCommand = "select DISTINCT b.Bulan, b.NamaBulan,CAST(CAST(DATEPART(YYYY,DateCreate)AS VARCHAR(4))+'/'+ CAST(DATEPART(m, DATEADD(m, 0, DateCreate)) AS VARCHAR(2))+'/'+ '01' AS Date) as tanggal from tTicket a left outer join namabulan b on CAST(DATEPART(M,DateCreate)AS VARCHAR(20))= b.Bulan order by b.Bulan Asc"
            filterMonth.Visible = True
            selYear.Visible = True
            TxtDateFrom.Visible = False
            TxtDateTo.Visible = False
            lblTo.Visible = False
            SourceDetail.Visible = True
            'Response.Redirect("ReportFilter.aspx")

            ''filternya
            headChnlTrx.Visible = True
            isiChnlTrx.Visible = True

            headJnsTrx.Visible = True
            isiJnsTrx.Visible = True

            headStatTrx.Visible = True
            isiStatTrx.Visible = True

            headUnitKerja.Visible = False
            isiUnitKerja.Visible = False

            headSubject.Visible = False
            isiSubject.Visible = False

            headAgentName.Visible = False
            isiAgentName.Visible = False

            headClosedBy.Visible = False
            isiCLosedBy.Visible = False
            headTrxOleh.Visible = False
            headTrxClosed.Visible = False
            headFilterTop.Visible = False
            isiFilterTop.Visible = False

            staf.Visible = False
            cmb_staf.Visible = False

        ElseIf typeCategory = "Report Transaksi" Then
            selYear.Visible = False
            TxtDateFrom.Visible = True
            TxtDateTo.Visible = True
            filterMonth.Visible = False
            ''filternya
            headChnlTrx.Visible = True
            isiChnlTrx.Visible = True

            headJnsTrx.Visible = True
            isiJnsTrx.Visible = True

            headStatTrx.Visible = True
            isiStatTrx.Visible = True

            headUnitKerja.Visible = True
            isiUnitKerja.Visible = True

            headSubject.Visible = True
            isiSubject.Visible = True

            headAgentName.Visible = False
            isiAgentName.Visible = False

            headClosedBy.Visible = False
            isiCLosedBy.Visible = False
            headTrxOleh.Visible = False
            headFilterTop.Visible = False
            isiFilterTop.Visible = False
            headTrxClosed.Visible = False

            staf.Visible = False
            cmb_staf.Visible = False

        ElseIf typeCategory = "Report Performa Petugas HCSC" Then
            'filterMonth.Visible = False
            'lblTo.Visible = True
            selYear.Visible = False
            TxtDateFrom.Visible = True
            TxtDateTo.Visible = True
            ''filternya
            headChnlTrx.Visible = False
            isiChnlTrx.Visible = False

            headJnsTrx.Visible = True
            isiJnsTrx.Visible = True

            headStatTrx.Visible = True
            isiStatTrx.Visible = True

            headUnitKerja.Visible = False
            isiUnitKerja.Visible = False

            headSubject.Visible = False
            isiSubject.Visible = False

            headAgentName.Visible = True
            isiAgentName.Visible = True

            headTrxOleh.Visible = True
            headTrxClosed.Visible = False
            isiCLosedBy.Visible = True
            headFilterTop.Visible = False
            isiFilterTop.Visible = False
            'SourceDetail.Visible = True
            'cbJenisTransaksi.Visible = True
            'cbStatusTransaksi.Visible = True
            'cbChannelTransaksi.Visible = False
            'cbSubject.Visible = False
            'cbUnitKerja.Visible = False
            staf.Visible = False
            cmb_staf.Visible = False

        ElseIf typeCategory = "Report Top Kategori Transaksi" Then
            ''filternya
            selYear.Visible = False
            TxtDateFrom.Visible = True
            TxtDateTo.Visible = True

            headFilterTop.Visible = True
            isiFilterTop.Visible = True

            filterMonth.Visible = False
            headChnlTrx.Visible = False
            isiChnlTrx.Visible = False

            headJnsTrx.Visible = False
            isiJnsTrx.Visible = False

            headStatTrx.Visible = False
            isiStatTrx.Visible = False

            headUnitKerja.Visible = False
            isiUnitKerja.Visible = False

            headSubject.Visible = False
            isiSubject.Visible = False

            headAgentName.Visible = False
            isiAgentName.Visible = False

            headClosedBy.Visible = False
            isiCLosedBy.Visible = False
            headTrxOleh.Visible = False
            headTrxClosed.Visible = False

            staf.Visible = False
            cmb_staf.Visible = False

        ElseIf typeCategory = "Report Sla Transaksi" Then
            ''filternya
            selYear.Visible = False
            TxtDateFrom.Visible = True
            TxtDateTo.Visible = True
            filterMonth.Visible = False
            headChnlTrx.Visible = False
            isiChnlTrx.Visible = False

            headJnsTrx.Visible = True
            isiJnsTrx.Visible = True

            headStatTrx.Visible = True
            isiStatTrx.Visible = True

            headUnitKerja.Visible = False
            isiUnitKerja.Visible = False

            headSubject.Visible = False
            isiSubject.Visible = False

            headAgentName.Visible = False
            isiAgentName.Visible = False

            headClosedBy.Visible = False
            isiCLosedBy.Visible = True
            headTrxOleh.Visible = False
            headTrxClosed.Visible = True
            headFilterTop.Visible = False
            isiFilterTop.Visible = False

            staf.Visible = False
            cmb_staf.Visible = False

        ElseIf typeCategory = "Report Product" Then
            selYear.Visible = False
            TxtDateFrom.Visible = True
            TxtDateTo.Visible = True
            filterMonth.Visible = False
            ''filternya
            headChnlTrx.Visible = False
            isiChnlTrx.Visible = False

            headJnsTrx.Visible = False
            isiJnsTrx.Visible = False

            headStatTrx.Visible = False
            isiStatTrx.Visible = False

            headUnitKerja.Visible = False
            isiUnitKerja.Visible = False

            headSubject.Visible = False
            isiSubject.Visible = False

            headAgentName.Visible = False
            isiAgentName.Visible = False

            headClosedBy.Visible = False
            isiCLosedBy.Visible = False
            headTrxOleh.Visible = False
            headFilterTop.Visible = False
            isiFilterTop.Visible = False
            headTrxClosed.Visible = False
            staf.Visible = False
            cmb_staf.Visible = False

        ElseIf typeCategory = "Report Staf" Then

            selYear.Visible = False
            TxtDateFrom.Visible = True
            TxtDateTo.Visible = True
            filterMonth.Visible = False
            ''filternya
            headChnlTrx.Visible = False
            isiChnlTrx.Visible = False

            headJnsTrx.Visible = False
            isiJnsTrx.Visible = False

            headStatTrx.Visible = False
            isiStatTrx.Visible = False

            headUnitKerja.Visible = False
            isiUnitKerja.Visible = False

            headSubject.Visible = False
            isiSubject.Visible = False

            headAgentName.Visible = False
            isiAgentName.Visible = False

            headClosedBy.Visible = False
            isiCLosedBy.Visible = False
            headTrxOleh.Visible = False
            headFilterTop.Visible = False
            isiFilterTop.Visible = False
            headTrxClosed.Visible = False

            staf.Visible = True
            cmb_staf.Visible = True
        Else
            filterMonth.Visible = False
            lblTo.Visible = True
            TxtDateFrom.Visible = True
            TxtDateTo.Visible = True
            SourceDetail.Visible = True
        End If
    End Sub

    Protected Sub cbFilterTop_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbFilterTop.SelectedIndexChanged
        dsJenisTransaksi.SelectCommand = "select * from mCategory"
        dsChannelTransaksi.SelectCommand = "select * from mSourceType"
        dsUnitKerja.SelectCommand = "select b.SubCategory1ID as SubCategory1ID,a.Name as JenisTransaksi,b.SubName as SubjectTable,b.NA,b.ID from mCategory a left outer join mSubCategoryLv1 b on a.CategoryID = b.CategoryID where b.SubName <> ''"
        dsSubject.SelectCommand = "select b.SubCategory2ID as SubCategory2ID, a.Name as JenisTransaksi,b.SubName as SubjectTable,c.SubName as UnitKerja,b.NA,b.ID from mCategory a left outer join mSubCategoryLv2 b on a.CategoryID = b.CategoryID left outer join mSubCategoryLv1 as c on b.SubCategory1ID=c.SubCategory1ID where c.SubName <> ''"
        dsNamaKaryawan.SelectCommand = "select NIK,Name from mKaryawan order by Name asc"

        filterMonthSql.SelectCommand = "select DISTINCT b.Bulan, b.NamaBulan,CAST(CAST(DATEPART(YYYY,DateCreate)AS VARCHAR(4))+'/'+ CAST(DATEPART(m, DATEADD(m, 0, DateCreate)) AS VARCHAR(2))+'/'+ '01' AS Date) as tanggal from tTicket a left outer join namabulan b on CAST(DATEPART(M,DateCreate)AS VARCHAR(20))= b.Bulan order by b.Bulan Asc"

        Dim Xtring As String = cbFilterTop.Value
        Dim strArray() As String = Xtring.Split(";")
        Dim cekFilterBy As String
        Session("filterTopJum") = strArray(0)
        Session("filterTopKet") = strArray(1)
        cekFilterBy = strArray(1)
        If cekFilterBy = "JenisTrx" Then
            'cbUnitKerja.Text = ""
            headJnsTrx.Visible = True
            isiJnsTrx.Visible = True
            headUnitKerja.Visible = False
            isiUnitKerja.Visible = False
        ElseIf cekFilterBy = "UnitKerja" Then
            'cbJenisTransaksi.Text = ""
            headUnitKerja.Visible = True
            isiUnitKerja.Visible = True
            headJnsTrx.Visible = False
            isiJnsTrx.Visible = False
        End If

    End Sub


End Class