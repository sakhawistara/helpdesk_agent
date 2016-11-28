Imports System.Web
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Public Class functionWeber
    Implements IHttpModule

    Private WithEvents _context As HttpApplication

    ''' <summary>
    '''  Author      : Restu Ramadhika
    '''  Email       : resturamadhika@gmail.com
    '''  Date Create : 24-05-2013 10:00 WIB
    '''  Last Update : 
    '''  see the following link: http://www.invision-ap.com
    ''' </summary>
#Region "IHttpModule Members"

    Public Sub Dispose() Implements IHttpModule.Dispose

        ' Clean-up code here

    End Sub

    Public Sub Init(ByVal context As HttpApplication) Implements IHttpModule.Init
        _context = context
    End Sub

#End Region

    Public Shared Function cekFileExists(ByVal pathFile As String, ByVal FolderDanNameFile As String) As Boolean

        If File.Exists(pathFile + FolderDanNameFile) Then
            Return True
        Else
            Return False
        End If

    End Function
    Private Shared Function GetWeberConnection() As SqlConnection
        Dim weberConnection As New SqlConnection(ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString)

        Return weberConnection
    End Function
    Public Shared Function selectTable(ByVal tableName As String, ByVal fieldsName As String, ByVal conditionSelect As String) As String()

        Dim Com As SqlCommand
        Dim Dr As SqlDataReader
        Dim weberConnection As SqlConnection = GetWeberConnection()
        Dim sqlCekMailKirim As String = "select " & fieldsName & " from " & tableName & " where " & conditionSelect & ""
        Com = New SqlCommand(sqlCekMailKirim, weberConnection)
        weberConnection.Open()
        Dr = Com.ExecuteReader()
        Dr.Read()
        Dim Xtring As String = fieldsName
        Dim strArray() As String = Xtring.Split(",")

        Dim i As Integer = 0
        While (i < strArray.Length.ToString())
            strArray(i) = Dr(strArray(i)).ToString
            i = i + 1
        End While
        Dr.Close()
        weberConnection.Close()
        Return strArray

    End Function

    Public Shared Function countTable(ByVal tableName As String, ByVal fieldsName As String, ByVal conditionSelect As String) As String
        Dim strArray As String = ""
        Dim Com As SqlCommand
        Dim Dr As SqlDataReader
        Dim weberConnection As SqlConnection = GetWeberConnection()
        Dim sqlCekMailKirim As String = "select " & fieldsName & " as iniCountTable from " & tableName & " where " & conditionSelect & ""
        Com = New SqlCommand(sqlCekMailKirim, weberConnection)
        weberConnection.Open()
        Dr = Com.ExecuteReader()
        If Dr.Read() Then
            strArray = Dr("iniCountTable").ToString
        Else
            strArray = ""
        End If
        'Dim Xtring As String = fieldsName
        'Dim strArray() As String = Xtring.Split(",")

        'Dim i As Integer = 0
        'While (i < strArray.Length.ToString())
        '    strArray(i) = Dr(strArray(i)).ToString
        '    i = i + 1
        'End While

        Dr.Close()
        weberConnection.Close()
        Return strArray

    End Function

    Public Shared Function insertTable(ByVal tableName As String, ByVal fieldsName As String, ByVal valuesName As String) As Boolean
        Dim Com As SqlCommand
        Dim weberConnection As SqlConnection = GetWeberConnection()

        Dim XtringField As String = fieldsName
        Dim strArrayField() As String = XtringField.Split(",")
        Dim resultFields As String = ""

        Dim XtringValue As String = valuesName
        Dim strArrayValue() As String = XtringValue.Split(",")
        Dim resultValues As String = ""

        If strArrayField.Length.ToString() <> strArrayValue.Length.ToString() Then

            Return False

        Else

            Dim i As Integer = 0
            While (i < strArrayField.Length.ToString())

                resultFields &= "" & strArrayField(i).ToString & "" & ","
                resultValues &= "'" & strArrayValue(i).ToString & "'" & ","

                i = i + 1
            End While

            Dim insertQuery As String = "insert into " & tableName & " (" & RemoveLastCharacter(resultFields.ToString) & ") values (" & RemoveLastCharacter(resultValues.ToString) & ")"
            Com = New SqlCommand(insertQuery, weberConnection)
            weberConnection.Open()
            Com.ExecuteNonQuery()
            weberConnection.Close()
            Return True
        End If
    End Function

    Public Shared Function updateTable(ByVal tableName As String, ByVal fieldsName As String, ByVal valuesName As String, ByVal conditionUpdate As String) As Boolean
        Dim Com As SqlCommand
        Dim weberConnection As SqlConnection = GetWeberConnection()

        Dim XtringField As String = fieldsName
        Dim strArrayField() As String = XtringField.Split(",")
        Dim resultFields As String = ""

        Dim XtringValue As String = valuesName
        Dim strArrayValue() As String = XtringValue.Split(",")
        Dim resultValues As String = ""

        If strArrayField.Length.ToString() <> strArrayValue.Length.ToString() Then

            Return False

        Else

            Dim i As Integer = 0
            Dim updateContent As String = ""
            While (i < strArrayField.Length.ToString())

                resultFields &= "" & strArrayField(i).ToString & "='" & strArrayValue(i).ToString & "'" & ","


                i = i + 1
            End While
            updateContent = resultFields
            Dim updateQuery As String = "update " & tableName & " SET " & RemoveLastCharacter(updateContent.ToString) & " WHERE " & conditionUpdate & ""
            Com = New SqlCommand(updateQuery, weberConnection)
            weberConnection.Open()
            Com.ExecuteNonQuery()
            weberConnection.Close()
            Return True
        End If
    End Function

    Public Shared Function deleteRowTable(ByVal tableName As String, ByVal conditionUpdate As String) As Boolean
        Dim Com As SqlCommand
        Dim weberConnection As SqlConnection = GetWeberConnection()

        Dim deleteQuery As String = "delete from " & tableName & " WHERE " & conditionUpdate & ""
        Com = New SqlCommand(deleteQuery, weberConnection)
        weberConnection.Open()
        If Com.ExecuteNonQuery() Then
            Return True
        Else
            Return False
        End If
        weberConnection.Close()
    End Function

    Public Shared Function RemoveLastCharacter(ByVal Text As String) As String
        Return Text.Substring(0, Text.Length - 1)
    End Function

    Public Shared Function disabledButtonDelete(ByVal valPublish As String) As Boolean

        Return False

    End Function

    Public Shared Function replaceAnything(ByVal valueString As String, ByVal ygDiReplace As String, ByVal menjadi As String)


        Return valueString.Replace(ygDiReplace, menjadi)


    End Function

    Public Shared Function cekSessionLogin(ByVal LevelUser As String, ByVal PageFile As String) As Boolean
        Dim Com As SqlCommand
        Dim Dr As SqlDataReader
        Dim weberConnection As SqlConnection = GetWeberConnection()
        Dim sqlCekMailKirim As String = "select * from msUserTrustee where LevelUser = '" & LevelUser & "'"
        Com = New SqlCommand(sqlCekMailKirim, weberConnection)
        Try
            weberConnection.Open()
            Dr = Com.ExecuteReader()
            While Dr.Read()
                If Dr("LevelUser").ToString = LevelUser Then
                    If PageFile = "RPT" Then
                        If Dr("RPT").ToString = True Then
                            Return True
                        Else
                            Return False
                        End If
                    End If
                    If PageFile = "MasterTable" Then
                        If Dr("MasterTable").ToString = True Then
                            Return True
                        Else
                            Return False
                        End If
                    End If
                    If PageFile = "TH" Then
                        If Dr("TH").ToString = True Then
                            Return True
                        Else
                            Return False
                        End If
                    End If
                    If PageFile = "TIC" Then
                        If Dr("TIC").ToString = True Then
                            Return True
                        Else
                            Return False
                        End If
                    End If
                    If PageFile = "KB" Then
                        If Dr("KB").ToString = True Then
                            Return True
                        Else
                            Return False
                        End If
                    End If
                    If PageFile = "Email" Then
                        If Dr("Email").ToString = True Then
                            Return True
                        Else
                            Return False
                        End If
                    End If
                    If PageFile = "Customer" Then
                        If Dr("Customer").ToString = True Then
                            Return True
                        Else
                            Return False
                        End If
                    End If

                Else
                    Return False
                End If
            End While
            Dr.Close()
        Catch ex As Exception

        Finally
            weberConnection.Close()
        End Try


        'If userType = "2" Then

        '    If PageFile = "ManageUser" Or PageFile = "LogActivity" Then
        '        Return True
        '    Else
        '        Return False
        '    End If

        'ElseIf userType = "3" Then

        '    If PageFile = "CreateAnn" Or PageFile = "Comment" Or PageFile = "LogActivity" Or PageFile = "RunText" Then
        '        Return True
        '    Else
        '        Return False
        '    End If


        'ElseIf userType = "4" Then

        '    If PageFile = "Search" Or PageFile = "ArticlesDisplay" Or PageFile = "DisplayAnn" Then
        '        Return True
        '    Else
        '        Return False
        '    End If

        'End If
    End Function

End Class

