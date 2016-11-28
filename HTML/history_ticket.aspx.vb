Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.UI
Imports DevExpress.Web.ASPxGridView
Partial Class history_ticket
    Inherits System.Web.UI.Page

    Dim ceknull As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        masterDataSource.SelectCommand = "Select * from mCustomer"
    End Sub
    Protected Sub TicketNumber_DataSelect(ByVal sender As Object, ByVal e As EventArgs)
        Session("NIK") = (TryCast(sender, ASPxGridView)).GetMasterRowKeyValue()
        SourceTicket.SelectCommand = "sp_TicketHistory '" & Session("NIK") & "'"
    End Sub
    Protected Sub GridList_DataSelect(ByVal sender As Object, ByVal e As EventArgs)
        Session("TicketNumber") = (TryCast(sender, ASPxGridView)).GetMasterRowKeyValue()
        SqlDataSource1.SelectCommand = "select ROW_NUMBER() OVER(ORDER BY a.ID DESC) As Row, AgentCreate,ResponseComplaint,a.DateCreate, b.Name, b.NIK " & _
                                        "from tInteraction a left outer join mKaryawan b on a.AgentCreate = b.NIK " & _
                                        "left outer join tTicket c on a.TicketNumber = c.TicketNumber where (b.NIK = '" & Session("TicketNumber") & "' or c.TicketNumber='" & Session("TicketNumber") & "')"
    End Sub
End Class