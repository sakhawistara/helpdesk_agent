Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxGridView
Imports DevExpress.Web.ASPxClasses
Partial Class calltype_two
    Inherits System.Web.UI.Page
    Dim Com As SqlCommand
    Dim Dr As SqlDataReader
    Dim SelTicket, SelTicket1, Categori As String
    Dim ConnectionTest As New SqlConnection(ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString)
    Dim Connection As New SqlConnection(ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString)
    Dim Comm As SqlCommand

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dsSubject.SelectCommand = "select a.Name as JenisTransaksi,b.SubName as SubjectTable,c.SubName as UnitKerja,b.NA,b.ID from mCategory a left outer join mSubCategoryLv2 b on a.CategoryID = b.CategoryID left outer join mSubCategoryLv1 as c on b.SubCategory1ID=c.SubCategory1ID where c.SubName <> ''"
    End Sub
    Private Sub cmbCombo2_OnCallback(ByVal source As Object, ByVal e As CallbackEventArgsBase)
        FillComboUnitKerja(TryCast(source, ASPxComboBox), e.Parameter, dsmSubCategoryLv1)
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
            FillComboUnitKerja(combo, id, source)
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
    Protected Sub ASPxGridView1_CellEditorInitialize(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridView.ASPxGridViewEditorEventArgs) Handles ASPxGridView1.CellEditorInitialize

        Dim SelectData, val1, val2 As String
        val1 = ""
        val2 = ""
        If ASPxGridView1.GetRowValues(e.VisibleIndex, "JenisTransaksi") <> "" Then
            SelectData = "select * from mSubCategoryLv2 where ID='" & ASPxGridView1.GetRowValues(e.VisibleIndex, "ID") & "'"
            Com = New SqlCommand(SelectData, ConnectionTest)
            ConnectionTest.Open()
            Dr = Com.ExecuteReader()
            If Dr.Read() Then
                val1 = Dr("CategoryID")
                val2 = Dr("SubCategory1ID")
            End If
            Dr.Close()
            ConnectionTest.Close()

            If ASPxGridView1.IsEditing Then
                If e.Column.FieldName = "JenisTransaksi" Then
                    e.Editor.Value = val1
                ElseIf e.Column.FieldName = "UnitKerja" Then
                    e.Editor.Value = val2
                End If
            End If
        Else
            dsSubject.SelectCommand = "select a.Name as JenisTransaksi,b.SubName as UnitKerja,c.SubName as SubjectTable,c.NA,c.ID from mCategory a left outer join mSubCategoryLv2 b on a.CategoryID = b.CategoryID left outer join mSubCategoryLv1 c on b.SubCategory1ID=c.SubCategory1ID where c.SubName <> ''"
            dsmCategory.SelectCommand = "select top 10 * from mCategory Where NA='Y'"
            dsmSubCategoryLv1.SelectCommand = "select * from mSubCategoryLv1 Where categoryid=@categoryid and NA='Y'"
        End If

        If ASPxGridView1.IsNewRowEditing Then
            If e.Column.FieldName = "NA" Then
                e.Editor.Value = "Y"
            End If
        Else
            SelectData = "select * from mSubCategoryLv2 where ID='" & ASPxGridView1.GetRowValues(e.VisibleIndex, "ID") & "'"
            Com = New SqlCommand(SelectData, ConnectionTest)
            ConnectionTest.Open()
            Dr = Com.ExecuteReader()
            If Dr.Read() Then
                val1 = Dr("NA")
            End If
            Dr.Close()
            ConnectionTest.Close()

            If e.Column.FieldName = "NA" Then
                e.Editor.Value = val1
            End If
        End If
        Select Case e.Column.FieldName
            'Case "JenisTransaksi"
            '    InitializeCombo(e, "CategoryID", dsmCategory, AddressOf cmbCombo2_OnCallback)
            Case "UnitKerja"
                InitializeComboUnitKerja(e, "CategoryID", dsmSubCategoryLv1, AddressOf cmbCombo2_OnCallback)
            Case Else
        End Select
        If ASPxGridView1.IsNewRowEditing Then
            If e.Column.FieldName = "NA" Then
                e.Editor.Value = "Y"
            End If
        Else
        End If
    End Sub

    Protected Sub ASPxGridView1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ASPxGridView1.Init
        dsSubject.SelectCommand = "select a.Name as JenisTransaksi,b.SubName as SubjectTable,c.SubName as UnitKerja,b.NA,b.ID from mCategory a left outer join mSubCategoryLv2 b on a.CategoryID = b.CategoryID left outer join mSubCategoryLv1 as c on b.SubCategory1ID=c.SubCategory1ID where c.SubName <> ''"
    End Sub

    Protected Sub ASPxGridView1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles ASPxGridView1.Load
    End Sub

    Protected Sub ASPxGridView1_RowInserting(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataInsertingEventArgs) Handles ASPxGridView1.RowInserting

        '====Untuk cek Jenis Transaksi sudah ada atau belum
        Dim cekJenisTransaksi, cekSubjectTable, cekUnitKerja As String
        cekJenisTransaksi = e.NewValues("JenisTransaksi").ToString()
        cekSubjectTable = e.NewValues("SubjectTable").ToString()
        cekUnitKerja = e.NewValues("UnitKerja").ToString()

        Dim SourceJenisTransaksi As String
        SourceJenisTransaksi = "Select COUNT (SubName) as CekTransaksi from mSubCategoryLv2 where CategoryID='" & cekJenisTransaksi & "' and SubCategory1ID='" & cekUnitKerja & "' and SubName='" & cekSubjectTable & "'"
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
        End If

        Dim nourutAkhir, angkaTerakhir, GenerateNoID As String
        Dim querySelectData As String = "select SUBSTRING(SubCategory2ID,5,5) as nourutAkhir from mSubCategoryLv2 order by ID desc"
        Comm = New SqlCommand(querySelectData, Connection)
        Connection.Open()
        Dr = Comm.ExecuteReader()
        If Dr.Read() Then
            nourutAkhir = Dr("nourutAkhir").ToString
        End If
        Dr.Close()
        Connection.Close()

        If nourutAkhir = "" Then
            querySelectData = "select  AngkaTerakhir = Right(10001 + COUNT(ID) + 0, 5)  from mSubCategoryLv2"
        Else
            querySelectData = "select  AngkaTerakhir = Right(100" & nourutAkhir & " + 1 + 0, 5)  from mSubCategoryLv2"
        End If


        Comm = New SqlCommand(querySelectData, Connection)
        Connection.Open()

        Dr = Comm.ExecuteReader()
        If Dr.Read() Then
            angkaTerakhir = Dr("AngkaTerakhir").ToString
        End If
        Dr.Close()
        Connection.Close()

        GenerateNoID = "CT2-" & angkaTerakhir & ""

        dsSubject.InsertCommand = "insert into mSubCategoryLv2 (CategoryID,SubCategory1ID,SubCategory2ID,SubName,NA) values (@JenisTransaksi,@UnitKerja,'" & GenerateNoID & "',@SubjectTable,@NA)"
 
    End Sub

    Protected Sub ASPxGridView1_RowUpdating(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs) Handles ASPxGridView1.RowUpdating

        Dim cekJenisTransaksi, cekSubjectTable, cekUnitKerja As String
        Dim OldcekJenisTransaksi, OldcekSubjectTable, OldcekUnitKerja As String

        'cekJenisTransaksi = e.NewValues("JenisTransaksi").ToString()
        cekSubjectTable = e.NewValues("SubjectTable").ToString()
        cekUnitKerja = e.NewValues("UnitKerja").ToString()

        'OldcekJenisTransaksi = e.OldValues("JenisTransaksi").ToString()
        OldcekSubjectTable = e.OldValues("SubjectTable").ToString()
        OldcekUnitKerja = e.OldValues("UnitKerja").ToString()


        'If OldcekJenisTransaksi <> cekJenisTransaksi And cekSubjectTable <> OldcekSubjectTable And cekUnitKerja <> OldcekUnitKerja Then
        If OldcekUnitKerja <> cekUnitKerja And cekSubjectTable <> OldcekSubjectTable Then
            Dim SourceJenisTransaksi As String
            SourceJenisTransaksi = "select COUNT(a.SubName) as CekTransaksi from mSubCategoryLv2 a left outer join mSubCategoryLv1 b on a.SubCategory1ID=b.SubCategory1ID where b.SubCategory1ID='" & cekUnitKerja & "' and a.SubName='" & cekSubjectTable & "'"
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
                'dsSubject.UpdateCommand = "UPDATE mSubCategoryLv2 SET CategoryID=@JenisTransaksi,SubCategory1ID=@UnitKerja,SubName=@SubjectTable,  NA=@NA where ID=@ID"
                dsSubject.UpdateCommand = "UPDATE mSubCategoryLv2 SET SubName=@SubjectTable,  NA=@NA where ID=@ID"
            End If


        ElseIf cekSubjectTable <> OldcekSubjectTable Then
            Dim SourceJenisTransaksi As String
            SourceJenisTransaksi = "select COUNT(a.SubName) as CekTransaksi from mSubCategoryLv2 a left outer join mSubCategoryLv1 b on a.SubCategory1ID=b.SubCategory1ID where b.SubName='" & cekUnitKerja & "' and a.SubName='" & cekSubjectTable & "'"
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
                dsSubject.UpdateCommand = "UPDATE mSubCategoryLv2 SET SubName=@SubjectTable,  NA=@NA where ID=@ID"
            End If

        ElseIf OldcekUnitKerja <> cekUnitKerja Then
            dsSubject.UpdateCommand = "UPDATE mSubCategoryLv2 SET CategoryID=@JenisTransaksi,SubCategory1ID=@UnitKerja,SubName=@SubjectTable,  NA=@NA where ID=@ID"

        Else
            e.Cancel = False
            dsSubject.UpdateCommand = "UPDATE mSubCategoryLv2 SET SubName=@SubjectTable,  NA=@NA where ID=@ID"
        End If

    End Sub
End Class
