<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="user_previledge.aspx.vb" Inherits="ICC.user_previledge" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8">
    <title>Invision Helpdesk</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="">
    <meta name="author" content="">

    <!-- Bootstrap core CSS -->
    <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet">

    <!-- Font Awesome -->
    <link href="css/font-awesome.min.css" rel="stylesheet">

    <!-- Pace -->
    <link href="css/pace.css" rel="stylesheet">

    <!-- Datatable -->
    <link href="css/jquery.dataTables_themeroller.css" rel="stylesheet">

    <!-- Color box -->
    <link href="css/colorbox/colorbox.css" rel="stylesheet">

    <!-- Morris -->
    <link href="css/morris.css" rel="stylesheet" />

    <!-- Endless -->
    <link href="css/endless.min.css" rel="stylesheet">
    <link href="css/endless-skin.css" rel="stylesheet">

    <!-- Gritter -->
    <link href="css/gritter/jquery.gritter.css" rel="stylesheet">

    <script>
        function getMcategory(text) {
            //alert("MainContent_mCatID")
            document.getElementById('mCatID').value = text;
            callbackPanelX.PerformCallback(text);
        }
        function OnRowClickUserTrustee(s, e) {
            //Unselect all rows
            //Select the row        
            gridLevelUser.GetRowValues(gridLevelUser.GetFocusedRowIndex(), 'MenuID;MenuName', OnGetRowValuesssUserTrustee);
        }
        function OnGetRowValuesssUserTrustee(values) {
            var status;
            var tablename;
            var checkVoice;
            var suara;
            //alert(values)
            // document.getElementById("MainContent_callbackPanelX_txtKodeGroup_I").value = values[1];
            document.getElementById("ASPxCallbackPanel1_txtGroupID").value = values[0];
            ASPxCallbackPanel1.PerformCallback(values[0]);
        }

        function grid_SelectionChanged(s, e) {
            s.GetSelectedFieldValues("MenuName", GetSelectedFieldValuesCallback);
        }
        function GetSelectedFieldValuesCallback(values) {
            document.getElementById("selCount").innerHTML = grid.GetSelectedRowCount();
        }
    </script>
</head>
<body>
    <div class="padding-md">
        <div class="row">
            <div class="col-md-12">
                <div class="panel panel-default">
                    <form id="Form1" class="form-horizontal form-border no-margin" data-validate="parsley" runat="server">
                        <div class="panel-heading">
                            User Management Setting
                        </div>
                        <div class="panel-body">
                            <div id="div_customer" runat="server">
                                <div class="row">
                                    <div class="col-md-6">
                                        <label class="control-label">UserName</label>
                                        <dx:ASPxComboBox ID="cmb_user" Height="30px" runat="server" Theme="MetropolisBlue" Width="100%" IncrementalFilteringMode="Contains"
                                            DataSourceID="sql_agent" TextField="userid" ValueField="userid" CssClass="form-control chzn-select">
                                            <ClientSideEvents SelectedIndexChanged="function(s, e) {getMcategory(s.GetSelectedItem().texts[0]);}" />
                                            <Columns>
                                                <dx:ListBoxColumn Caption="User ID" FieldName="userid" Width="300px" />
                                                <dx:ListBoxColumn Caption="Level User" FieldName="Description" Width="100px" />
                                            </Columns>
                                        </dx:ASPxComboBox>
                                        <asp:HiddenField runat="server" ID="mCatID" />
                                        <asp:SqlDataSource ID="sql_agent" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
                                    </div>
                                </div>
                                <!-- /.row -->
                            </div>
                            <hr />
                            <div id="div_checkbox" runat="server">
                                <dx:ASPxCallbackPanel ID="callbackPanelX" runat="server" Theme="Moderno"
                                    Width="100%" Height="100px" RenderMode="Table" ClientInstanceName="callbackPanelX">
                                    <PanelCollection>
                                        <dx:PanelContent ID="PanelContent2" runat="server">
                                            <div id="div_generate" runat="server">
                                                <dx:ASPxGridView ID="gridLevelUser" ClientInstanceName="gridLevelUser" runat="server" KeyFieldName="MenuID"
                                                    DataSourceID="sql_user" Width="100%" Theme="MetropolisBlue" SettingsPager-PageSize="20">
                                                    <SettingsPager>
                                                        <AllButton Text="All">
                                                        </AllButton>
                                                        <NextPageButton Text="Next &gt;">
                                                        </NextPageButton>
                                                        <PrevPageButton Text="&lt; Prev">
                                                        </PrevPageButton>
                                                    </SettingsPager>
                                                    <SettingsEditing Mode="Inline" />
                                                    <SettingsBehavior EnableRowHotTrack="true" ConfirmDelete="true" AllowFocusedRow="true" />
                                                    <Settings ShowFilterRow="true" ShowFilterRowMenu="false" ShowGroupPanel="true"
                                                        ShowVerticalScrollBar="false" ShowHorizontalScrollBar="false" />
                                                    <ClientSideEvents RowDblClick="function(s, e) 
                                                           { 
                                                            OnRowClickUserTrustee(s,e); 
                                                           }" />
                                                    <Columns>
                                                        <dx:GridViewCommandColumn Caption="Action" ButtonType="Image" Width="150px">
                                                            <NewButton Visible="true">
                                                                <Image Url="~/Images/icon/Apps-text-editor-icon2.png"></Image>
                                                            </NewButton>
                                                            <DeleteButton Visible="true">
                                                                <Image Url="~/Images/icon/Actions-edit-clear-icon2.png"></Image>
                                                            </DeleteButton>
                                                            <CancelButton>
                                                                <Image ToolTip="Cancel" Url="~/Images/icon/cancel1.png">
                                                                </Image>
                                                            </CancelButton>
                                                            <UpdateButton>
                                                                <Image ToolTip="Update" Url="~/Images/icon/Updated1.png" />
                                                            </UpdateButton>
                                                        </dx:GridViewCommandColumn>
                                                        <%-- <dx:GridViewDataTextColumn Caption="No" FieldName="Nomor" Width="10px"></dx:GridViewDataTextColumn>--%>
                                                        <dx:GridViewDataTextColumn Caption="ID" FieldName="MenuID" Width="30px"></dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Menu" FieldName="MenuName"></dx:GridViewDataTextColumn>
                                                       <%-- <dx:GridViewDataButtonEditColumn Caption="Action" Width="100px">
                                                            <DataItemTemplate>
                                                                <a id="clickElement" target="_blank" href="user_previledge.aspx?id=<%# Container.KeyValue%>">Update
                                                                    <img src="~/Images/icon/Apps-text-editor-icon2.png" alt="HTML tutorial" style="width:42px;height:42px;border:0;">
                                                                </a>
                                                                <a id="A1" target="_blank" href="user_previledge.aspx?id=<%# Container.KeyValue%>">Delete</a>
                                                            </DataItemTemplate>
                                                        </dx:GridViewDataButtonEditColumn>--%>
                                                    </Columns>
                                                </dx:ASPxGridView>
                                                <asp:SqlDataSource ID="sql_user" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
                                            </div>
                                            <hr />
                                        </dx:PanelContent>
                                    </PanelCollection>
                                </dx:ASPxCallbackPanel>

                                <dx:ASPxCallbackPanel ID="ASPxCallbackPanel1" runat="server" Theme="Moderno" SettingsPager-PageSize="20"
                                    Width="100%" Height="100px" RenderMode="Table" ClientInstanceName="ASPxCallbackPanel1">
                                    <PanelCollection>
                                        <dx:PanelContent ID="PanelContent1" runat="server">
                                            <asp:HiddenField runat="server" ID="txtGroupID" />
                                            <dx:ASPxGridView ID="ASPxGridView1" runat="server" DataSourceID="sql_submenu" Width="100%"
                                                KeyFieldName="SubMenuID" Theme="MetropolisBlue">
                                                <Columns>
                                                    <dx:GridViewCommandColumn Caption="Action" ButtonType="Image" Width="150px">
                                                        <NewButton Visible="true">
                                                            <Image Url="~/Images/icon/Apps-text-editor-icon2.png"></Image>
                                                        </NewButton>
                                                        <DeleteButton Visible="true">
                                                            <Image Url="~/Images/icon/Actions-edit-clear-icon2.png"></Image>
                                                        </DeleteButton>
                                                        <CancelButton>
                                                            <Image ToolTip="Cancel" Url="~/Images/icon/cancel1.png">
                                                            </Image>
                                                        </CancelButton>
                                                        <UpdateButton>
                                                            <Image ToolTip="Update" Url="~/Images/icon/Updated1.png" />
                                                        </UpdateButton>
                                                    </dx:GridViewCommandColumn>
                                                    <dx:GridViewDataTextColumn Caption="ID" FieldName="SubMenuID" Width="50px"></dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn Caption="Sub Menu" FieldName="SubMenuName"></dx:GridViewDataTextColumn>
                                                </Columns>
                                            </dx:ASPxGridView>

                                            <%-- <dx:ASPxCheckBoxList ID="checkBoxList" runat="server" DataSourceID="sql_submenu" Width="100%" Theme="MetropolisBlue"
                                                ValueField="SubMenuID" TextField="SubMenuName" RepeatColumns="6" RepeatLayout="Table" ToolTip="Menu Name">
                                            </dx:ASPxCheckBoxList>
                                            --%>
                                        </dx:PanelContent>
                                    </PanelCollection>
                                </dx:ASPxCallbackPanel>
                            </div>
                            <asp:SqlDataSource ID="sql_submenu" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
                        </div>
                        <div class="panel-footer">
                            <asp:Button ID="btn_simpan" CssClass="btn btn-info" Text="Submit" runat="server" Visible="false" />
                        </div>
                    </form>
                </div>
                <!-- /panel -->
            </div>
            <!-- /.col-->
        </div>
    </div>
    <!-- Placed at the end of the document so the pages load faster -->

    <!-- Jquery -->
    <script src="js/jquery-1.10.2.min.js"></script>

    <!-- Bootstrap -->
    <script src="bootstrap/js/bootstrap.js"></script>

    <!-- Datatable -->
    <script src='js/jquery.dataTables.min.js'></script>

    <!-- holder -->
    <script src='js/uncompressed/holder.js'></script>
    <!-- Gritter -->
    <script src="js/jquery.gritter.min.js"></script>

    <!-- Flot -->
    <script src='js/jquery.flot.min.js'></script>

    <!-- Morris -->
    <script src='js/rapheal.min.js'></script>
    <script src='js/morris.min.js'></script>

    <!-- Colorbox -->
    <script src='js/jquery.colorbox.min.js'></script>

    <!-- Sparkline -->
    <script src='js/jquery.sparkline.min.js'></script>

    <!-- Pace -->
    <script src='js/uncompressed/pace.js'></script>

    <!-- Popup Overlay -->
    <script src='js/jquery.popupoverlay.min.js'></script>

    <!-- Slimscroll -->
    <script src='js/jquery.slimscroll.min.js'></script>

    <!-- Modernizr -->
    <script src='js/modernizr.min.js'></script>

    <!-- Cookie -->
    <script src='js/jquery.cookie.min.js'></script>

    <!-- Endless -->
    <script src="js/endless/endless_dashboard.js"></script>
    <script src="js/endless/endless.js"></script>

    <!-- holder -->
    <script src='js/uncompressed/holder.js'></script>
    <!-- Gritter -->
    <script src="js/jquery.gritter.min.js"></script>
</body>
</html>
