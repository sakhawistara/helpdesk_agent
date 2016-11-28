Imports System.IO
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports System.Web.Configuration

Public Class cls_globe
    Inherits System.Web.UI.Page
    Protected Da As SqlDataAdapter
    Protected Ds As DataSet
    Protected Dt As DataTable
    Dim mycom As New SqlCommand()
    Dim mycon As New SqlConnection()
    Dim cs, TmpStr As String
    Dim f As System.IO.FileStream
    Dim p As DirectoryInfo
    Dim objreader As System.IO.StreamWriter

    Public Sub koneksi(dbName As String)
        CloseKoneksi()
        Try
            If dbName = "fax" Then
                cs = WebConfigurationManager.ConnectionStrings("dbFax").ConnectionString()
            ElseIf dbName = "KM" Then
                cs = WebConfigurationManager.ConnectionStrings("dbKM").ConnectionString()
            End If
            mycon.ConnectionString = cs
            mycon.Open()
            mycom.Connection = mycon
        Catch ex As Exception
            writedata("Error", "Open Database", dbName, "", "")
            Session("Error") = "Can't Open Database, please contact Team Web"
            Exit Sub
        End Try
    End Sub
    Public Sub CloseKoneksi()
        mycon.Close()
        SqlConnection.ClearAllPools()
    End Sub

    Public Sub writedata(ByVal id_user As String, ByVal action As String, ByVal keterangan As String, ByVal query As String, ByVal ChName As String)
        Dim strdata As String = id_user & " | " & action & " | " & keterangan & " | " & query & " | " & ChName

        Dim dt As String = Date.Now.ToString("MM-dd-yyyy")
        Dim namalog, nmdir As String
        Try
            nmdir = Server.MapPath(ConfigurationManager.AppSettings.Item("Logsys"))
            If System.IO.Directory.Exists(nmdir) = False Then
                p = Directory.CreateDirectory(nmdir)
                p.Create()
            End If
            nmdir = ConfigurationManager.AppSettings.Item("Logsys")
            namalog = Server.MapPath(nmdir & "logFile-" & ChName & "-" & dt & ".txt")
            'namalog = Server.MapPath(nmdir & "logFile-" & dt & ".txt")
            If System.IO.File.Exists(namalog) = False Then
                f = File.Create(namalog)
                f.Close()
            End If
            objreader = New System.IO.StreamWriter(namalog, True)
            objreader.Write(Now & " : " & strdata)
            objreader.WriteLine()
            objreader.Close()
        Catch ex As Exception
            Session("Error") = ex.Message
            writedata("System", "WriteData", ex.Message, strdata, Session("dbName"))
        End Try
    End Sub
    Public Sub LogSys(ByVal id_user As String, ByVal action As String, ByVal keterangan As String, ByVal query As String, ByVal ChName As String)
        If Session("Error") <> "" Then Exit Sub
        If Session("IPAddress") = "::1" Then
            Session("IPAddress") = "127.0.0.1"
        End If
        If id_user <> "" Then
            koneksi(Session("dbName"))
            mycom.CommandText = "insert LogSys (usr_id,menu,action,ddate,keterangan,query,IPAddress) values " & _
                "('" & id_user & "','" & Session("dbName") & "','" & action & "',getdate(),'" & ReplaceSpecialLetter(keterangan) & "','" & ReplaceSpecialLetter(query) & "','" & Session("IPAddress") & "')"
            mycom.ExecuteNonQuery()
        End If
    End Sub
    Public Function ReplaceSpecialLetter(ByVal str)
        TmpStr = str
        TmpStr = Replace(TmpStr, "'", "&#39;")
        ReplaceSpecialLetter = TmpStr
    End Function
    Public Function InFileFAX() As String
        Return ConfigurationManager.AppSettings.Item("InFileFAX")
    End Function
    Public Function PrefixFAX() As String
        Return ConfigurationManager.AppSettings.Item("PrefixFAX")
    End Function

    Public Function ExecuteQuery(ByVal Query As String) As DataTable
        koneksi(Session("dbName"))
        If Session("Error") <> "" Then Exit Function
        Try
            mycom.CommandText = Query
            Da = New SqlDataAdapter
            Da.SelectCommand = mycom

            Ds = New Data.DataSet
            Da.Fill(Ds)

            Dt = Ds.Tables(0)

            Return Dt
        Catch ex As Exception
            Session("Error") = ex.Message
            writedata("System", "ExecuteQuery", ex.Message, Query, Session("dbName"))
        End Try
    End Function
    Public Function ExecuteNonQuery(ByVal Query As String)
        koneksi(Session("dbName"))
        If Session("Error") <> "" Then Exit Function
        Try
            mycom.CommandText = Query
            mycom.ExecuteNonQuery()
        Catch ex As Exception
            Session("Error") = ex.Message
            writedata("System", "ExecuteNonQuery", ex.Message, Query, Session("dbName"))
        End Try
    End Function
End Class
