<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/HTML/Ticket.Master" CodeBehind="setting_user.aspx.vb" Inherits="ICC.setting_user" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
    <script>
        function gLevelUser(text) {
            //alert(text)
            document.getElementById('MainContent_hd_level_user').value = text;
            ASPxCallbackPanel2.PerformCallback(text);
        }
        function getMcategory(text) {
            //alert("MainContent_mCatID")
            document.getElementById('MainContent_ASPxCallbackPanel2_mCatID').value = text;
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
            document.getElementById("MainContent_ASPxCallbackPanel1_txtGroupID").value = values[0];
            //alert(values(0))
            ASPxCallbackPanel1.PerformCallback(values[0]);
        }
        function onSubmenu(s, e) {
            //Unselect all rows
            //Select the row        
            ASPxGridView1.GetRowValues(ASPxGridView1.GetFocusedRowIndex(), 'SubMenuID;SubMenuName', onGetSubmenu);
        }
        function onGetSubmenu(values) {
            var status;
            var tablename;
            var checkVoice;
            var suara;
            //alert(values)
            // document.getElementById("MainContent_callbackPanelX_txtKodeGroup_I").value = values[1];
            document.getElementById("MainContent_ASPxCallbackPanel3_HiddenField1").value = values[0];
            //alert(values(0))
            ASPxCallbackPanel3.PerformCallback(values[0]);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="padding-md">
        <div class="row">
            <div class="col-md-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        User Management Setting
                    </div>
                    <div class="panel-body">
                        <div id="div_customer" runat="server">
                            <div class="row">
                                <div class="col-md-6">
                                    <label class="control-label">Level User</label>
                                    <dx:ASPxComboBox ID="cmb_level_user" Height="30px" runat="server" Theme="MetropolisBlue" Width="100%" IncrementalFilteringMode="Contains"
                                        DataSourceID="sql_level_user" TextField="Description" ValueField="LevelUserID" CssClass="form-control chzn-select">
                                        <ClientSideEvents SelectedIndexChanged="function(s, e) {gLevelUser(s.GetSelectedItem().texts[0]);}" />
                                        <Columns>
                                            <dx:ListBoxColumn Caption="Level User" FieldName="Description" Width="250px" />
                                        </Columns>
                                    </dx:ASPxComboBox>
                                    <asp:HiddenField runat="server" ID="hd_level_user" />
                                    <asp:SqlDataSource ID="sql_level_user" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
                                </div>
                                <div class="col-md-6">
                                    <dx:ASPxCallbackPanel ID="ASPxCallbackPanel2" runat="server" Theme="Moderno"
                                        Width="100%" RenderMode="Table" ClientInstanceName="ASPxCallbackPanel2">
                                        <PanelCollection>
                                            <dx:PanelContent ID="PanelContent3" runat="server">
                                                <asp:HiddenField runat="server" ID="mCatID" />
                                                <label class="control-label">User Name</label>
                                                <dx:ASPxComboBox ID="cmb_user" Height="30px" runat="server" Theme="MetropolisBlue" Width="100%" IncrementalFilteringMode="Contains"
                                                    DataSourceID="sql_agent" TextField="userid" ValueField="userid" CssClass="form-control chzn-select">
                                                    <ClientSideEvents SelectedIndexChanged="function(s, e) {getMcategory(s.GetSelectedItem().texts[0]);}" />
                                                    <Columns>
                                                        <dx:ListBoxColumn Caption="User Name" FieldName="userid" Width="300px" />
                                                        <dx:ListBoxColumn Caption="Level User" FieldName="Description" Width="150px" />
                                                    </Columns>
                                                </dx:ASPxComboBox>

                                                <asp:SqlDataSource ID="sql_agent" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
                                            </dx:PanelContent>
                                        </PanelCollection>
                                    </dx:ASPxCallbackPanel>
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
                                                    <dx:GridViewCommandColumn Caption="Action" ButtonType="Image" Width="150px" HeaderStyle-HorizontalAlign="Center">
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
                                                    <dx:GridViewDataTextColumn Caption="ID" FieldName="MenuID" Width="50px" CellStyle-HorizontalAlign="Left"></dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataComboBoxColumn Caption="Menu" FieldName="MenuName" HeaderStyle-HorizontalAlign="left">
                                                        <PropertiesComboBox TextField="MenuName" ValueField="MenuID" EnableSynchronization="False"
                                                            TextFormatString="{0}" IncrementalFilteringMode="Contains" DataSourceID="sql_menu">
                                                            <Columns>
                                                                <dx:ListBoxColumn Caption="ID" FieldName="MenuID" Width="50px" />
                                                                <dx:ListBoxColumn Caption="Menu" FieldName="MenuName" Width="200px" />
                                                            </Columns>
                                                        </PropertiesComboBox>
                                                    </dx:GridViewDataComboBoxColumn>
                                                </Columns>
                                            </dx:ASPxGridView>
                                            <asp:SqlDataSource ID="sql_menu" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"
                                                SelectCommand="SELECT * FROM User1"></asp:SqlDataSource>
                                            <asp:SqlDataSource ID="sql_user" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
                                        </div>
                                        <hr />
                                    </dx:PanelContent>
                                </PanelCollection>
                            </dx:ASPxCallbackPanel>

                            <dx:ASPxCallbackPanel ID="ASPxCallbackPanel1" runat="server" Theme="Moderno"
                                Width="100%" Height="100px" RenderMode="Table" ClientInstanceName="ASPxCallbackPanel1">
                                <PanelCollection>
                                    <dx:PanelContent ID="PanelContent1" runat="server">
                                        <asp:HiddenField runat="server" ID="txtGroupID" />
                                        <dx:ASPxGridView ID="ASPxGridView1" runat="server" DataSourceID="sql_submenu" Width="100%" SettingsPager-PageSize="20"
                                            KeyFieldName="SubMenuID" Theme="MetropolisBlue" Visible="false" ClientInstanceName="ASPxGridView1">
                                            <SettingsBehavior EnableRowHotTrack="true" ConfirmDelete="true" AllowFocusedRow="true" />
                                            <ClientSideEvents RowDblClick="function(s, e) 
                                                           { 
                                                            onSubmenu(s,e); 
                                                           }" />
                                            <Columns>
                                                <dx:GridViewCommandColumn Caption="Action" ButtonType="Image" Width="150px" HeaderStyle-HorizontalAlign="Center">
                                                    <NewButton Visible="true">
                                                        <Image Url="~/Images/icon/Apps-text-editor-icon2.png"></Image>
                                                    </NewButton>
                                                    <DeleteButton Visible="true">
                                                        <Image Url="~/Images/icon/Actions-edit-clear-icon2.png"></Image>
                                                    </DeleteButton>
                                                    <CancelButton>
                                                        <Image ToolTip="Cancel" Url="~/img/icon/cancel1.png">
                                                        </Image>
                                                    </CancelButton>
                                                    <UpdateButton>
                                                        <Image ToolTip="Update" Url="~/img/icon/Updated1.png" />
                                                    </UpdateButton>
                                                </dx:GridViewCommandColumn>
                                                <dx:GridViewDataTextColumn Caption="ID" FieldName="SubMenuID" Width="50px" CellStyle-HorizontalAlign="left"></dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Menu" FieldName="MenuName" Width="150px" HeaderStyle-HorizontalAlign="left"></dx:GridViewDataTextColumn>
                                                <dx:GridViewDataComboBoxColumn Caption="Sub Menu" FieldName="SubMenuName" HeaderStyle-HorizontalAlign="left">
                                                    <PropertiesComboBox TextField="SubMenuName" ValueField="SubMenuID" EnableSynchronization="False"
                                                        TextFormatString="{0}" IncrementalFilteringMode="Contains" DataSourceID="sql_subMenu_dr">
                                                        <Columns>
                                                            <dx:ListBoxColumn Caption="ID" FieldName="SubMenuID" Width="50px" />
                                                            <dx:ListBoxColumn Caption="Sub Menu" FieldName="SubMenuName" Width="200px" />
                                                        </Columns>
                                                    </PropertiesComboBox>
                                                </dx:GridViewDataComboBoxColumn>
                                            </Columns>
                                        </dx:ASPxGridView>
                                        <hr />
                                    </dx:PanelContent>
                                </PanelCollection>
                            </dx:ASPxCallbackPanel>

                            <dx:ASPxCallbackPanel ID="ASPxCallbackPanel3" runat="server" Theme="Moderno"
                                Width="100%" Height="100px" RenderMode="Table" ClientInstanceName="ASPxCallbackPanel3">
                                <PanelCollection>
                                    <dx:PanelContent ID="PanelContent4" runat="server">
                                        <asp:HiddenField runat="server" ID="HiddenField1" />
                                        <dx:ASPxGridView ID="ASPxGridView2" runat="server" DataSourceID="sql_submenu_tree" Width="100%" SettingsPager-PageSize="20"
                                            KeyFieldName="SubMenuIDTree" Theme="MetropolisBlue" Visible="false">
                                            <SettingsBehavior EnableRowHotTrack="true" ConfirmDelete="true" AllowFocusedRow="true" />
                                            <Columns>
                                                <dx:GridViewCommandColumn Caption="Action" ButtonType="Image" Width="150px" HeaderStyle-HorizontalAlign="Center">
                                                    <NewButton Visible="true">
                                                        <Image Url="~/Images/icon/Apps-text-editor-icon2.png"></Image>
                                                    </NewButton>
                                                    <DeleteButton Visible="true">
                                                        <Image Url="~/Images/icon/Actions-edit-clear-icon2.png"></Image>
                                                    </DeleteButton>
                                                    <CancelButton>
                                                        <Image ToolTip="Cancel" Url="~/img/icon/cancel1.png">
                                                        </Image>
                                                    </CancelButton>
                                                    <UpdateButton>
                                                        <Image ToolTip="Update" Url="~/img/icon/Updated1.png" />
                                                    </UpdateButton>
                                                </dx:GridViewCommandColumn>
                                                <dx:GridViewDataTextColumn Caption="ID" FieldName="SubMenuIDTree" Width="50px" CellStyle-HorizontalAlign="left"></dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Menu" FieldName="MenuTreeName" Width="450px" HeaderStyle-HorizontalAlign="left"></dx:GridViewDataTextColumn>
                                            </Columns>
                                        </dx:ASPxGridView>
                                    </dx:PanelContent>
                                </PanelCollection>
                            </dx:ASPxCallbackPanel>
                        </div>
                        <asp:SqlDataSource ID="sql_subMenu_dr" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
                        <asp:SqlDataSource ID="sql_submenu" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
                        <asp:SqlDataSource ID="sql_submenu_tree" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
                        <asp:SqlDataSource ID="sql_submenu_user3" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
                    </div>
                    <div class="panel-footer">
                        <asp:Button ID="btn_back" CssClass="btn btn-info" Text="Back" runat="server" />
                        <asp:Button ID="btn_simpan" CssClass="btn btn-info" Text="Submit" runat="server" Visible="false" />
                    </div>
                </div>
                <!-- /panel -->
            </div>
            <!-- /.col-->
        </div>
    </div>
</asp:Content>
