Imports System.Data.SqlClient
Imports System.Web.Configuration
Public Class ClsSos
    Protected sql As String
    Protected cn As SqlConnection
    Protected cmd As SqlCommand
    Protected da As SqlDataAdapter
    Protected ds As DataSet
    Protected dt As DataTable
    Protected dr As SqlDataReader

    Public Function opencn() As Boolean
        Try
            cn = New SqlConnection(WebConfigurationManager.ConnectionStrings("SosmedConnection").ConnectionString)
            cn.Open()

            If cn.State <> ConnectionState.Open Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            'Call GetExceptionInfo(ex)
            Return Nothing
        End Try
    End Function

    Public Sub Closecn()
        Try
            If Not IsNothing(cn) Then
                cn.Close()
                cn = Nothing
            End If
        Catch ex As Exception
            'Call GetExceptionInfo(ex)
        End Try

    End Sub

    Public Function ExecuteQuery(ByVal sql As String) As DataTable
        Try
            If Not opencn() Then
                Return Nothing
                'ErrorTRAPZ(Now & vbTab & "Connection Failed")
                Exit Function
            End If

            cmd = New SqlCommand(sql, cn)
            da = New SqlDataAdapter
            ds = New Data.DataSet

            da.SelectCommand = cmd
            da.Fill(ds)

            dt = ds.Tables(0)
            Return dt

        Catch ex As Exception

            'Call GetExceptionInfo(ex)
        Finally

            dt = Nothing
            da = Nothing
            cmd = Nothing
            ds = Nothing

            Closecn()

        End Try
    End Function

    Public Sub ExecuteNonQuery(ByVal sql As String)
        Try
            If Not opencn() = True Then
                'ErrorTRAPZ(Now & vbTab & "Connection Failed")
                Exit Sub
            End If

            cmd = New SqlCommand
            cmd.Connection = cn
            cmd.CommandText = sql
            cmd.ExecuteNonQuery()
        Catch ex As Exception

            'Call GetExceptionInfo(ex)
        Finally

            cmd = Nothing
            Closecn()
        End Try

    End Sub

    Public Function ExecuteReader(ByVal sql As String)
        Try
            If Not opencn() = True Then
                Return Nothing
                'ErrorTRAPZ(Now & vbTab & "Connection Failed")
                Exit Function
            End If

            cmd = New SqlCommand(sql, cn)
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            'dr = cmd.ExecuteReader()

            Return dr

        Catch ex As Exception
            Return Nothing
            'Call GketExceptionInfo(ex)
        End Try
    End Function

    Public Sub CloseDR()
        Try
            If Not IsNothing(cn) Then
                dr.Close()
                cn.Close()
                cn = Nothing
            End If
        Catch ex As Exception

            'Call GetExceptionInfo(ex)
        End Try
    End Sub
End Class

