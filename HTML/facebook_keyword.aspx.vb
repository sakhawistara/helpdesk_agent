Imports System.Collections.Generic
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Timers
Imports System.Data.OleDb
Public Class facebook_keyword
    Inherits System.Web.UI.Page

    'Dim Proses As New ClsSos
    Dim Con As New SqlConnection(ConfigurationManager.ConnectionStrings("SosmedConnection").ConnectionString)
    Dim Com As SqlCommand
    Dim Dr As SqlDataReader
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session("txtcategory") = txtsentimen.Text
        Session("txtsub") = txtsub.Text
        btnupdatekey.Visible = False
        Dim tampung As String
        If Request.QueryString("id") = "" Then
            Dim selectdata As String = "SELECT ROW_NUMBER()OVER (ORDER BY id) AS Row, id, FlagSource, Text_Keywords FROM mKeyword where FlagSource='fb'"
            Com = New SqlCommand(selectdata, Con)
            Con.Open()
            Dr = Com.ExecuteReader()
            Try
                While Dr.Read
                    tampung &= "<tr>" & _
                        "<td>" & Dr("Row").ToString & "</td>" & _
                                   "<td>" & Dr("Text_Keywords") & "</td>" & _
                                   "<td><a href='facebook_keyword.aspx?id=" & Dr("id").ToString & "&status=edit&text=" & Dr("Text_Keywords").ToString & "' class='btn btn-info btn-xs'>Update</a>&nbsp;" & _
                                    "<a href='facebook_keyword.aspx?id=" & Dr("id").ToString & "&status=delete&text=" & Dr("Text_Keywords").ToString & "' class='btn btn-danger btn-xs'>Delete</a></td>" & _
                        "</tr>"
                End While
            Catch ex As Exception
                Response.Write(ex.Message)
            End Try
            Dr.Close()
            Con.Close()
            show.Text = tampung
        Else
            If Request.QueryString("status") = "edit" Then
                btnsubmitkey.Visible = False
                btnupdatekey.Visible = True
                Dim selectupdate As String = "select * from mKeyword where id = '" & Request.QueryString("id").ToString & "'"
                Com = New SqlCommand(selectupdate, Con)
                Con.Open()
                Dr = Com.ExecuteReader()
                Dr.Read()
                txtsentimen.Text = Dr("Text_Keywords").ToString
                Session("idKeyword") = Request.QueryString("id").ToString
                Dr.Close()
                Con.Close()
            Else
                Try
                    Dim insertlog As String = "insert into mslog (Username, Flag, Data, datetime) VALUES ('" & Session("username") & "', 'Delete Keyword Facebook', '" & Request.QueryString("text") & "', GETDATE())"
                    Com = New SqlCommand(insertlog, Con)
                    Con.Open()
                    Com.ExecuteNonQuery()
                    Con.Close()
                Catch ex As Exception
                    Response.Write(DirectCast("", String))
                Finally
                End Try
                Try
                    Dim querydelete As String = "delete from mKeyword where id ='" & Request.QueryString("id").ToString & "'"
                    Com = New SqlCommand(querydelete, Con)
                    Con.Open()
                    Com.ExecuteNonQuery()
                    Con.Close()
                Catch ex As Exception
                    Response.Write(DirectCast("", String))
                Finally
                End Try
                Response.Redirect("facebook_keyword.aspx")
            End If
        End If


        If Request.QueryString("idsub") = "" Then
            btnupdatesub.Visible = False
            Dim tampungan As String
            Dim selectsub As String = "SELECT ROW_NUMBER() OVER (Order By mSubkeyword.idsub) as ROW, mSubkeyword.idsub, mKeyword.Text_Keywords, mSubkeyword.Text_SubKeywords " & _
                                    "FROM mSubkeyword INNER JOIN mKeyword ON mSubkeyword.Keyword_ID = mKeyword.id WHERE mSubkeyword.FlagSource ='fb'"
            Com = New SqlCommand(selectsub, Con)
            Con.Open()
            Dr = Com.ExecuteReader()
            While Dr.Read
                tampungan &= "<tr>" & _
                            "<td>" & Dr("ROW").ToString & "</td>" & _
                            "<td>" & Dr("Text_Keywords").ToString & "</td>" & _
                            "<td>" & Dr("Text_SubKeywords").ToString & "</td>" & _
                            "<td><a href='facebook_keyword.aspx?idsub=" & Dr("idsub").ToString & "&status=edit&text=" & Dr("Text_Keywords").ToString & "#wizardContent2' class='btn btn-info btn-xs'>Update</a>&nbsp; " & _
                            "<a href='facebook_keyword.aspx?idsub=" & Dr("idsub").ToString & "&status=delete&text=" & Dr("Text_Keywords").ToString & "#wizardContent2' class='btn btn-danger btn-xs'>Delete</a></td>" & _
                        "</tr>"
            End While
            Dr.Close()
            Con.Close()
            bukadeh.Text = tampungan
        Else
            If Request.QueryString("status") = "edit" Then
                btnupdatesub.Visible = True
                btnsubmitsub.Visible = False
                Dim tampungdata As String = "SELECT mSubkeyword.idsub, mKeyword.Text_Keywords, mSubkeyword.Text_SubKeywords, mSubkeyword.PointValue " & _
                                    "FROM mSubkeyword INNER JOIN mKeyword ON mSubkeyword.Keyword_ID = mKeyword.id " & _
                                    " WHERE mSubkeyword.idsub = '" & Request.QueryString("idsub").ToString & "'"
                Com = New SqlCommand(tampungdata, Con)
                Con.Open()
                Dr = Com.ExecuteReader()
                Dr.Read()
                txtsub.Text = Dr("Text_SubKeywords").ToString

                'showsub.Visible = False
                Session("idsub") = Request.QueryString("idsub").ToString
                Dr.Close()
                Con.Close()
            ElseIf Request.QueryString("status") = "delete" Then
                'If MsgBox("Would you like to remove this item?" & "informations you have", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Try
                    Dim insertlog As String = "insert into mslog (Username, Flag, Data, datetime) VALUES ('" & Session("username") & "', 'Delete SubKeyword Facebook', '" & Request.QueryString("text") & "', GETDATE())"
                    Com = New SqlCommand(insertlog, Con)
                    Con.Open()
                    Com.ExecuteNonQuery()
                    Con.Close()
                Catch ex As Exception
                    Response.Write(DirectCast("", String))
                Finally
                End Try
                Try
                    Dim querydelete As String = "delete from mSubkeyword where idsub ='" & Request.QueryString("idsub").ToString & "'"
                    Com = New SqlCommand(querydelete, Con)
                    Con.Open()
                    Com.ExecuteNonQuery()
                    Con.Close()
                Catch ex As Exception

                    Response.Write(DirectCast("", String))
                Finally
                End Try
                Response.Redirect("facebook_keyword.aspx#wizardContent2")
            End If
        End If
    End Sub

    Private Sub btnsubmitkey_Click(sender As Object, e As EventArgs) Handles btnsubmitkey.Click
        Try
            Dim insertlog As String = "insert into mslog (Username, Flag, Data, datetime) VALUES ('" & Session("username") & "', 'Add Category facebook', '" & txtsentimen.Text & "', GETDATE())"
            Com = New SqlCommand(insertlog, Con)
            Con.Open()
            Com.ExecuteNonQuery()
            Con.Close()
        Catch ex As Exception
            Response.Write(DirectCast("", String))
        Finally
        End Try

        Try
            Dim Insert As String = "insert into mKeyword (FlagSource, Text_Keywords) values ('FB','" & txtsentimen.Text & "')"
            Com = New SqlCommand(Insert, Con)
            Con.Open()
            Com.ExecuteNonQuery()
            Con.Close()
            'Response.Write(DirectCast(Replace(textuniversal.Text, """", ""), String))
        Catch ex As Exception
            Response.Write(DirectCast("", String))
        Finally

        End Try
        txtsentimen.Text = ""
        Response.Redirect("facebook_keyword.aspx")
    End Sub

    Private Sub btnupdatekey_Click(sender As Object, e As EventArgs) Handles btnupdatekey.Click
        Try
            Dim insertlog As String = "insert into mslog (Username, Flag, Data, datetime) VALUES ('" & Session("username") & "', 'Update Keyword Facebook', '" & Session("txtcategory") & "', GETDATE())"
            Com = New SqlCommand(insertlog, Con)
            Con.Open()
            Com.ExecuteNonQuery()
            Con.Close()
        Catch ex As Exception
            Response.Write(DirectCast("", String))
        Finally
        End Try

        Try
            Dim Insert As String = "update mKeyword set Text_Keywords = '" & Session("txtcategory") & "' where id='" & Session("idKeyword") & "'"
            Com = New SqlCommand(Insert, Con)
            Con.Open()
            Com.ExecuteNonQuery()
            Con.Close()
            'Response.Write(DirectCast(Replace(Isi, """", ""), String))
        Catch ex As Exception
            Response.Write(DirectCast("", String))
        Finally

        End Try
        txtsentimen.Text = ""
        Response.Redirect("facebook_keyword.aspx")
    End Sub

    Private Sub btnsubmitsub_Click(sender As Object, e As EventArgs) Handles btnsubmitsub.Click
        Try
            Dim insertlog As String = "insert into mslog (Username, Flag, Data, datetime) VALUES ('" & Session("username") & "', 'Insert Subkeyword Facebook', '" & txtsub.Text & "', GETDATE())"
            Com = New SqlCommand(insertlog, Con)
            Con.Open()
            Com.ExecuteNonQuery()
            Con.Close()
        Catch ex As Exception
            Response.Write(DirectCast("", String))
        Finally
        End Try

        Try
            Dim Insert As String = "insert into mSubkeyword (FlagSource, Text_SubKeywords, Keyword_ID, PointValue) values ('FB','" & txtsub.Text & "','" & DD1.Text & "', 'NA')"
            Com = New SqlCommand(Insert, Con)
            Con.Open()
            Com.ExecuteNonQuery()
            Con.Close()
            Dr.Close()
            Con.Close()
        Catch ex As Exception
            Response.Write(DirectCast("", String))
        Finally

        End Try
        Response.Redirect("facebook_keyword.aspx#wizardContent2")
        'wizardContent2.Visible = True
    End Sub

    Private Sub btnupdatesub_Click(sender As Object, e As EventArgs) Handles btnupdatesub.Click
        Try
            Dim insertlog As String = "insert into mslog (Username, Flag, Data, datetime) VALUES ('" & Session("username") & "', 'Update SubKeyword Facebook', '" & Session("txtsub") & "', GETDATE())"
            Com = New SqlCommand(insertlog, Con)
            Con.Open()
            Com.ExecuteNonQuery()
            Con.Close()
        Catch ex As Exception
            Response.Write(DirectCast("", String))
        Finally
        End Try

        Try

            Dim updatedata As String = "update mSubkeyword set Text_SubKeywords = '" & Session("txtsub") & "', Keyword_ID = '" & DD1.Text & "' where idsub ='" & Session("idsub") & "'"
            Com = New SqlCommand(updatedata, Con)
            Con.Open()
            Com.ExecuteNonQuery()
            Con.Close()
        Catch ex As Exception
            Response.Write(DirectCast("", String))
        Finally
        End Try
        Response.Redirect("facebook_keyword.aspx#wizardContent2")
    End Sub
End Class