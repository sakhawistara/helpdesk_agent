Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxGridView
Imports DevExpress.Web.ASPxClasses
Partial Class calltype_tre
    Inherits System.Web.UI.Page

    Dim Com As SqlCommand
    Dim Dr As SqlDataReader
    Dim SelTicket, SelTicket1, Categori As String
    Dim ConnectionTest As New SqlConnection(ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString)
    Dim Connection As New SqlConnection(ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString)
    Dim Comm As SqlCommand
    Dim Proses As New ClsConn
    Dim Sqldr As SqlDataReader
    Dim sql As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DsCategory.SelectCommand = "select d.CustomerID, d.IDKamus as IDKamus, a.Name as JenisTransaksi,b.SubName as UnitKerja,c.SubName as NameSubject,d.SubName as SubjectTable,d.NA,d.SLA,d.Response_Agent,d.Priority,d.Severity,d.ID, d.Status_Customer, d.Version, d.License, e.NamaPerusahaan  from mCategory a left outer join mSubCategoryLv3 d on a.CategoryID = d.CategoryID left outer join mSubCategoryLv2 as c on d.SubCategory2ID=c.SubCategory2ID left outer join mSubCategoryLv1 as b on d.SubCategory1ID=b.SubCategory1ID left outer join mCustomer e on d.CustomerID = e.CustomerID where d.SubName <> '' order by ID asc "
    End Sub
    Private Sub cmbCombo2_OnCallback(ByVal source As Object, ByVal e As CallbackEventArgsBase)
        FillComboUnitKerja(TryCast(source, ASPxComboBox), e.Parameter, dsmSubCategoryLv1)
    End Sub

    Private Sub cmbCombo3_OnCallback(ByVal source As Object, ByVal e As CallbackEventArgsBase)
        FillComboUnitKerja(TryCast(source, ASPxComboBox), e.Parameter, dsmSubCategoryLv1)
    End Sub

    Private Sub cmbCombo4_OnCallback(ByVal source As Object, ByVal e As CallbackEventArgsBase)
        FillComboSubject(TryCast(source, ASPxComboBox), e.Parameter, dsmSubCategoryLv2)
    End Sub

    Protected Sub InitializeComboUnitKerja(ByVal e As ASPxGridViewEditorEventArgs, ByVal parentComboName As String, ByVal source As SqlDataSource, ByVal callBackHandler As CallbackEventHandlerBase)

        Dim id As String = String.Empty
        If (Not ASPxGridView1.IsNewRowEditing) Then
            Dim val As Object = ASPxGridView1.GetRowValuesByKeyValue(e.KeyValue, parentComboName)
            If (val Is Nothing OrElse val Is DBNull.Value) Then
                id = Nothing
            Else
                id = val.ToString()
            End If
        End If
        Dim combo As ASPxComboBox = TryCast(e.Editor, ASPxComboBox)
        If combo IsNot Nothing Then
            ' unbind combo
            combo.DataSourceID = Nothing
            FillComboSubject(combo, id, source)
            AddHandler combo.Callback, callBackHandler
        End If
        Return
    End Sub
    Protected Sub InitializeComboSubject(ByVal e As ASPxGridViewEditorEventArgs, ByVal parentComboName As String, ByVal source As SqlDataSource, ByVal callBackHandler As CallbackEventHandlerBase)

        Dim id As String = String.Empty
        If (Not ASPxGridView1.IsNewRowEditing) Then
            Dim val As Object = ASPxGridView1.GetRowValuesByKeyValue(e.KeyValue, parentComboName)
            If (val Is Nothing OrElse val Is DBNull.Value) Then
                id = Nothing
            Else
                id = val.ToString()
            End If
        End If
        Dim combo As ASPxComboBox = TryCast(e.Editor, ASPxComboBox)
        If combo IsNot Nothing Then
            ' unbind combo
            combo.DataSourceID = Nothing
            FillComboSubject(combo, id, source)
            AddHandler combo.Callback, callBackHandler
        End If
        Return
    End Sub
    Protected Sub FillComboUnitKerja(ByVal cmb As ASPxComboBox, ByVal id As String, ByVal source As SqlDataSource)
        cmb.Items.Clear()
        ' trap null selection
        If String.IsNullOrEmpty(id) Then
            Return
        End If

        ' get the values
        source.SelectParameters(0).DefaultValue = id
        Dim view As DataView = CType(source.Select(DataSourceSelectArguments.Empty), DataView)
        For Each row As DataRowView In view
            cmb.Items.Add(row(3).ToString(), row(2))
        Next row
    End Sub
    Protected Sub FillComboSubject(ByVal cmb As ASPxComboBox, ByVal id As String, ByVal source As SqlDataSource)
        cmb.Items.Clear()
        ' trap null selection
        If String.IsNullOrEmpty(id) Then
            Return
        End If

        ' get the values
        source.SelectParameters(0).DefaultValue = id
        Dim view As DataView = CType(source.Select(DataSourceSelectArguments.Empty), DataView)
        For Each row As DataRowView In view
            cmb.Items.Add(row(4).ToString(), row(2))
        Next row
    End Sub
    Protected Sub ASPxGridView1_CellEditorInitialize(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridView.ASPxGridViewEditorEventArgs) Handles ASPxGridView1.CellEditorInitialize
        Select Case e.Column.FieldName
            'Case "JenisTransaksi"
            '    InitializeCombo(e, "CategoryID", dsmCategory, AddressOf cmbCombo2_OnCallback)
            Case "UnitKerja"
                InitializeComboUnitKerja(e, "SubCategory1ID", dsmSubCategoryLv1, AddressOf cmbCombo3_OnCallback)
            Case "NameSubject"
                InitializeComboSubject(e, "SubCategory2ID", dsmSubCategoryLv2, AddressOf cmbCombo4_OnCallback)

            Case Else
        End Select
        If ASPxGridView1.IsNewRowEditing Then
            If e.Column.FieldName = "NA" Then
                e.Editor.Value = "Y"
            End If
        Else
        End If
    End Sub

    Protected Sub ASPxGridView1_RowInserting(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataInsertingEventArgs) Handles ASPxGridView1.RowInserting
        '====Untuk cek Jenis Transaksi sudah ada atau belum
        Dim cekJenisTransaksi, cekSubjectTable, cekUnitKerja, cekNameSubject As String
        cekJenisTransaksi = e.NewValues("JenisTransaksi").ToString()
        cekSubjectTable = e.NewValues("SubjectTable").ToString()
        cekNameSubject = e.NewValues("NameSubject").ToString()
        cekUnitKerja = e.NewValues("UnitKerja").ToString()

        Dim SJenis As String
        sql = "Select COUNT (SubName) as CekTransaksi from mSubCategoryLv3 where CategoryID='" & cekJenisTransaksi & "' and SubCategory1ID='" & cekUnitKerja & "' and SubCategory2ID='" & cekNameSubject & "' and SubName='" & cekSubjectTable & "'"
        Sqldr = Proses.ExecuteReader(sql)
        If Sqldr.Read() Then
            SJenis = Sqldr("CekTransaksi").ToString
        End If
        Sqldr.Close()

        Dim ErrorCode As String
        sql = "Select COUNT (SubName) as CekTransaksi from mSubCategoryLv3 where IDKamus='" & e.NewValues("IDKamus").ToString & "'"
        Sqldr = Proses.ExecuteReader(sql)
        If Sqldr.Read() Then
            ErrorCode = Sqldr("CekTransaksi").ToString
        End If
        Sqldr.Close()

        If SJenis > 0 Then
            e.Cancel = True
            Throw New Exception(cekSubjectTable & " already exists")
        Else
            e.Cancel = False
        End If
        If ErrorCode > 0 Then
            e.Cancel = True
            Throw New Exception(ErrorCode & " already exists")
        Else
            e.Cancel = False
        End If

        Dim NLast, Number, GenerateNoID As String
        sql = "select SUBSTRING(SubCategory3ID,5,5) as Number from mSubCategoryLv3 order by ID desc"
        Sqldr = Proses.ExecuteReader(sql)
        If Sqldr.Read() Then
            Number = Sqldr("Number").ToString
        End If
        Sqldr.Close()

        If Number = "" Then
            sql = "select  NLast = Right(10001 + COUNT(ID) + 0, 5)  from mSubCategoryLv3"
        Else
            sql = "select  NLast = Right(100" & Number & " + 1 + 0, 5)  from mSubCategoryLv3"
        End If
        Sqldr = Proses.ExecuteReader(sql)
        If Sqldr.Read() Then
            NLast = Sqldr("NLast").ToString
        End If
        Sqldr.Close()

        GenerateNoID = "CT3-" & NLast & ""
        DsCategory.InsertCommand = "insert into mSubCategoryLv3 (IDKamus,CategoryID,SubCategory1ID,SubCategory2ID,SubCategory3ID,SubName,SLA,Response_Agent,Priority,Severity,NA) values (@IDKamus,@JenisTransaksi,@UnitKerja,@NameSubject,'" & GenerateNoID & "',@SubjectTable,@SLA,@Response_Agent,@Priority,@Severity,@NA)"
    End Sub
    Protected Sub ASPxGridView1_RowUpdating(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs) Handles ASPxGridView1.RowUpdating
        Dim cekSubjectTable, cekUnitKerja, cekNameSubject As String
        Dim OldcekSubjectTable, OldcekUnitKerja, OldcekNamaSubject As String

        'cekJenisTransaksi = e.NewValues("JenisTransaksi").ToString()
        cekSubjectTable = e.NewValues("SubjectTable").ToString()
        cekUnitKerja = e.NewValues("UnitKerja").ToString()
        cekNameSubject = e.NewValues("NameSubject").ToString

        'OldcekJenisTransaksi = e.OldValues("JenisTransaksi").ToString()
        OldcekSubjectTable = e.OldValues("SubjectTable").ToString()
        OldcekUnitKerja = e.OldValues("UnitKerja").ToString()
        OldcekNamaSubject = e.OldValues("NameSubject").ToString


        If cekSubjectTable <> OldcekSubjectTable And cekUnitKerja <> OldcekUnitKerja Then
            Dim SourceJenisTransaksi As String
            SourceJenisTransaksi = "select COUNT(a.SubName) as CekTransaksi from mSubCategoryLv3 a left outer join mSubCategoryLv2 b on a.SubCategory2ID=b.SubCategory2ID where b.SubName='" & cekNameSubject & "' and a.SubName='" & cekSubjectTable & "'"
            Comm = New SqlCommand(SourceJenisTransaksi, Connection)
            Connection.Open()
            Dr = Comm.ExecuteReader()
            Dr.Read()
            SourceJenisTransaksi = Dr("CekTransaksi").ToString
            Dr.Close()
            Connection.Close()

            If SourceJenisTransaksi > 0 Then
                e.Cancel = True
                Throw New Exception(cekSubjectTable & " already exists")
            Else
                e.Cancel = False
                'DsCategory.UpdateCommand = "UPDATE mSubCategoryLv3 SET CategoryID=@JenisTransaksi,SubCategory1ID=@UnitKerja,SubCategory2ID=@NameSubject,SubName=@SubjectTable,NA=@NA,Priority=@Priority, Severity=@Severity, SLA=@SLA where ID=@ID"
                DsCategory.UpdateCommand = "UPDATE mSubCategoryLv3 SET SubName=@SubjectTable,NA=@NA,Priority=@Priority, Severity=@Severity, SLA=@SLA, Response_Agent=@Response_Agent where ID=@ID"
            End If

        ElseIf OldcekNamaSubject <> cekNameSubject Then
            Dim SourceJenisTransaksi As String
            SourceJenisTransaksi = "select COUNT(a.SubName) as CekTransaksi from mSubCategoryLv3 a left outer join mSubCategoryLv2 b on a.SubCategory2ID=b.SubCategory2ID where b.SubName='" & cekNameSubject & "' and a.SubName='" & cekSubjectTable & "'"
            Comm = New SqlCommand(SourceJenisTransaksi, Connection)
            Connection.Open()
            Dr = Comm.ExecuteReader()
            Dr.Read()
            SourceJenisTransaksi = Dr("CekTransaksi").ToString
            Dr.Close()
            Connection.Close()

            If SourceJenisTransaksi > 0 Then
                e.Cancel = True
                Throw New Exception(cekSubjectTable & " already exists")
            Else
                e.Cancel = False
                DsCategory.UpdateCommand = "UPDATE mSubCategoryLv3 SET SubName=@SubjectTable, NA=@NA,Priority=@Priority, Severity=@Severity, SLA=@SLA, Response_Agent=@Response_Agent where ID=@ID"
            End If
        ElseIf cekUnitKerja <> OldcekUnitKerja Then
            'DsCategory.UpdateCommand = "UPDATE mSubCategoryLv3 SET CategoryID=@JenisTransaksi,SubCategory1ID=@UnitKerja,SubCategory2ID=@NameSubject,SubName=@SubjectTable,NA=@NA,Priority=@Priority, Severity=@Severity, SLA=@SLA where ID=@ID"
            DsCategory.UpdateCommand = "UPDATE mSubCategoryLv3 SET SubName=@SubjectTable,NA=@NA,Priority=@Priority, Severity=@Severity, SLA=@SLA, Response_Agent=@Response_Agent where ID=@ID"
        Else
            e.Cancel = False
            DsCategory.UpdateCommand = "UPDATE mSubCategoryLv3 SET SubName=@SubjectTable, NA=@NA,Priority=@Priority, Severity=@Severity, SLA=@SLA, Response_Agent=@Response_Agent where ID=@ID"
        End If
    End Sub
End Class
