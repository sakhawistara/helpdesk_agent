Public Class assign
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("LoginType") = "layer1" Then
            sql_assign.SelectCommand = "select * from tTicket inner join mCustomer on tTicket.NIK = mCustomer.CustomerID Where tTicket.Status='Open' And tTicket.TicketPosition <> '1'"
        ElseIf Session("LoginType") = "layer2" Then
            sql_assign.SelectCommand = "select * from tTicket inner join mCustomer on tTicket.NIK = mCustomer.CustomerID Where tTicket.Status='Open' And tTicket.TicketPosition <> '2' and tTicket.Divisi='" & Session("Divisi") & "'"
        ElseIf Session("LoginType") = "layer3" Then
            sql_assign.SelectCommand = "select * from tTicket inner join mCustomer on tTicket.NIK = mCustomer.CustomerID Where tTicket.Status='Open' And (tTicket.TicketPosition <> '2' or tTicket.TicketPosition <> '1') and tTicket.dispatch_user='" & Session("UserName") & "'"
        Else
            sql_assign.SelectCommand = "select * from tticket inner join mCustomer on tTicket.NIK = mCustomer.CustomerID where status='Open' and dispatch_user <> '' and divisi <> ''"
        End If
    End Sub

End Class