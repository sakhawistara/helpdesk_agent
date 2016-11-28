Imports System.Data
Imports System.Data.SqlClient
Public Class calltype_two_lama
    Inherits System.Web.UI.Page

    Dim Proses As New ClsConn
    Dim Sqldr As SqlDataReader
    Dim sql As String
    Dim value As String
    Dim status As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.QueryString("act") = "edit" Then
            edit()
        ElseIf Request.QueryString("act") = "new" Then
            newdata()
        Else
            div_edit.Visible = False
            view()
        End If
    End Sub
    Sub edit()
        div_edit.Visible = True
        div_view.Visible = False
        lbl_header.Text = "Edit Product"
        'sql = "select * from mstatus where id='" & Request.QueryString("id") & "'"
        'Sqldr = Proses.ExecuteReader(sql)
        'Try
        '    If Sqldr.HasRows() Then
        '        Sqldr.Read()
        '        If Sqldr("NA") = "Y" Then
        '            status = "Active"
        '        Else
        '            status = "in Active"
        '        End If
        '        txt_id.Text = Sqldr("id").ToString
        '        txt_id.Enabled = False
        '        txt_Product.Text = Sqldr("status").ToString
        '        cmb_status.Text = status
        '        lbl_header.Text = "Edit Status"
        '    End If
        '    Sqldr.Close()
        'Catch ex As Exception
        '    Response.Write(ex.Message)
        'End Try
    End Sub
    Sub newdata()
        div_edit.Visible = True
        div_view.Visible = False
        lbl_header.Text = "New Product"
    End Sub
    Sub view()
        Dim Status As String
        sql = "select mCategory.CategoryID, mCategory.Name, mSubCategoryLv1.SubCategory1ID,  mSubCategoryLv1.SubName As Brand, " & _
              " mSubCategoryLv2.SubCategory2ID, mSubCategoryLv2.SubName As Product, mSubCategoryLv2.NA " & _
              "from mSubCategoryLv1 left outer join mCategory on mSubCategoryLv1.CategoryID = mCategory.CategoryID " & _
              "left outer join mSubCategoryLv2 on mSubCategoryLv1.SubCategory1ID = mSubCategoryLv2.SubCategory1ID"
        Sqldr = Proses.ExecuteReader(sql)
        Try
            While Sqldr.Read()
                If Sqldr("NA") = "Y" Then
                    Status = "Active"
                Else
                    Status = "in Active"
                End If
                value &= "<tr>" & _
                         "<td><span class='not-starred'><i><a class='nonelink' href='calltype_two.aspx?id=" & Sqldr("SubCategory1ID") & "' target='_blank'>" & Sqldr("SubCategory1ID") & "</i></span></td>" & _
                         "<td>" & Sqldr("Name").ToString & "</td>" & _
                         "<td>" & Sqldr("Brand").ToString & "</td>" & _
                         "<td>" & Sqldr("Product").ToString & "</td>" & _
                         "<td>" & Status & "</td>" & _
                         "<td><span class='not-starred'><i><a class='nonelink' href='calltype_two.aspx?act=edit&id=" & Sqldr("SubCategory1ID") & "'><img src='img/icon/Text-Edit-icon2.png'></a><a class='nonelink' href='calltype_two.aspx?act=new&id=" & Sqldr("SubCategory1ID") & "'><img src='img/icon/Apps-text-editor-icon2.png'></a></i></span></td>" & _
                         "</tr>"
            End While
            Sqldr.Close()
            ltr_brand.Text = value
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub
    Private Sub btn_submit_Click(sender As Object, e As EventArgs) Handles btn_submit.Click
        Response.Redirect("calltype_two.aspx")
    End Sub
    Private Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Response.Redirect("calltype_two.aspx")
    End Sub
End Class