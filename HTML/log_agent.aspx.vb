Public Class log_agent
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If StarDate.Text = "" And EndDate.Text = "" Then
            dslog.SelectCommand = "select * from mslog order by datetime desc"
        Else
            dslog.SelectCommand = "select * from mslog where datetime between '" & StarDate.Text & "' and '" & EndDate.Text & "' order by datetime desc "
        End If

    End Sub

    Private Sub bconvert_Click(sender As Object, e As EventArgs) Handles bconvert.Click
        Dim au As String = cbExpLogin.Value
        GVExpTax.ReportHeader = "Agent Activity" & ControlChars.CrLf & _
            "Tanggal : '" & StarDate.Text & "' s/d '" & EndDate.Text & "'"
        Select Case au
            Case "xlsx"
                GVExpTax.WriteXlsxToResponse()
            Case "xls"
                GVExpTax.WriteXlsToResponse()
            Case "pdf"
                GVExpTax.WritePdfToResponse()
        End Select
    End Sub
End Class