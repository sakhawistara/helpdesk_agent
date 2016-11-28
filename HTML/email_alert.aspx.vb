Public Class email_alert
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DsTools.InsertCommand = "Insert Into tManejemEmail (ToolEmail,Status) " & _
                                  "values (@ToolEmail,@Status) "
        DsTools.UpdateCommand = "Update tManejemEmail set ToolEmail=@ToolEmail , Status=@Status Where ID=@ID"
    End Sub

End Class