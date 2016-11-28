<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/HTML/Ticket.Master" CodeBehind="user_sett.aspx.vb" Inherits="ICC.user_sett" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
    <script>
        function OnRowClickUserTrustee(s, e) {
            //Unselect all rows

            //Select the row

            //alert(values);
            gridLevelUser.GetRowValues(gridLevelUser.GetFocusedRowIndex(), 'TrusteeID;LEVEL_USER', OnGetRowValuesssUserTrustee);
        }
        function OnGetRowValuesssUserTrustee(values) {
            var status;
            var tablename;
            var checkVoice;
            var suara;
            // document.getElementById("MainContent_callbackPanelX_txtKodeGroup_I").value = values[1];
            document.getElementById("MainContent_callbackPanelX_txtGroupID").value = values[0];
            //alert(values[0]);
            callbackPanelX.PerformCallback(values[0]);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="div_calltype_one" runat="server">
        <div id="breadcrumb">
            <ul class="breadcrumb">
                <li><i class="fa fa-home"></i>&nbsp;<a href="dashboard.aspx">Home</a></li>
                <li class="active">Setting User Previledge</li>
            </ul>
        </div>
        <div class="padding-md">
            <div class="row">
                <div id="div_ticket" runat="server">
                    <div class="form-group">
                        <dx:ASPxGridView ID="gridLevelUser" KeyFieldName="TrusteeID" runat="server" Theme="MetropolisBlue"
                            DataSourceID="sql_user" ClientInstanceName="gridLevelUser" Width="100%">
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
                            <Settings ShowFilterRow="true" ShowFilterRowMenu="false" ShowFilterBar="Hidden" ShowVerticalScrollBar="false"
                                VerticalScrollableHeight="150" ShowGroupPanel="false" />
                            <SettingsBehavior ConfirmDelete="true" />
                            <ClientSideEvents RowDblClick="function(s, e) 
                   { 
                    OnRowClickUserTrustee(s,e); 
                   }" />
                            <Columns>
                                <dx:GridViewDataComboBoxColumn Caption="Level User" FieldName="LEVEL_USER" VisibleIndex="1"
                                    HeaderStyle-HorizontalAlign="Center" Width="20%">
                                    <PropertiesComboBox TextField="Name" ValueField="Name" EnableSynchronization="False"
                                        TextFormatString="{0}" IncrementalFilteringMode="StartsWith" DataSourceID="sql_level_user">
                                        <Columns>
                                            <dx:ListBoxColumn Caption="Level User" FieldName="Name" Width="10%" />
                                        </Columns>
                                    </PropertiesComboBox>
                                </dx:GridViewDataComboBoxColumn>
                                <dx:GridViewDataTextColumn Caption="User Previlege" FieldName="LEVEL_USER_SBG"
                                    Width="20%" VisibleIndex="2" HeaderStyle-HorizontalAlign="Center">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Level User Description" FieldName="DESCRIPTION"
                                    Width="70%" VisibleIndex="3" HeaderStyle-HorizontalAlign="Center">
                                </dx:GridViewDataTextColumn>
                            </Columns>
                        </dx:ASPxGridView>
                    </div>
                    <div class="form-group">
                        <div id="div_new" runat="server">
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label">Level User</label>
                                        <asp:TextBox ID="txt_level_user" runat="server" CssClass="form-control input-sm" placeholder="Level User"></asp:TextBox>
                                    </div>
                                </div>
                                <!-- /.col -->
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label">Autorizhation</label>
                                        <dx:ASPxComboBox ID="KodeLevelUserSbg" runat="server" DropDownWidth="200px" class="form-control"
                                            DropDownStyle="DropDownList" DataSourceID="sql_user_level" ValueField="Name" ValueType="System.String"
                                            TextFormatString="{0}" EnableCallbackMode="true" IncrementalFilteringMode="StartsWith" CssClass="form-control"
                                            Width="200px">
                                            <ValidationSettings ValidationGroup="BtnSave" RequiredField-IsRequired="true" RequiredField-ErrorText="Tidak Boleh Kosong!"
                                                Display="Dynamic" CausesValidation="True">
                                                <RequiredField IsRequired="True" ErrorText="Tidak Boleh Kosong!"></RequiredField>
                                            </ValidationSettings>
                                            <Columns>
                                                <dx:ListBoxColumn FieldName="Description" Caption="Level User" Width="90px" />
                                            </Columns>
                                        </dx:ASPxComboBox>
                                    </div>
                                </div>
                                <!-- /.col -->
                            </div>
                            <!-- /form-group -->
                            <div class="form-group">
                                <label class="control-label">Description</label>
                                <asp:TextBox ID="txt_description" runat="server" CssClass="form-control" placeholder="Description..." TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <asp:SqlDataSource ID="sql_user" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
                    <asp:SqlDataSource ID="sql_user_level" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
                    <asp:SqlDataSource ID="sql_muser_trustee" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
                    <asp:SqlDataSource ID="sql_level_user" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
                </div>
                <hr />
                <div>
                    <dx:ASPxCallbackPanel ID="callbackPanelX" ClientInstanceName="callbackPanelX" runat="server" Theme="Moderno"
                        Width="100%" Height="100px" RenderMode="Table">
                        <PanelCollection>
                            <dx:PanelContent ID="PanelContent2" runat="server">
                                <asp:HiddenField runat="server" ID="txtGroupID" />
                                <dx:ASPxCheckBoxList ID="checkBoxList" runat="server" DataSourceID="sql_muser_trustee" Width="100%" Theme="MetropolisBlue"
                                    ValueField="MenuID" TextField="Description" RepeatColumns="6" RepeatLayout="Table" ToolTip="Menu Name">
                                </dx:ASPxCheckBoxList>
                                <br />
                                <asp:Button ID="Btn_Add" runat="server" Text="Add Level User" CssClass="btn btn-sm btn-success" />
                                <asp:Button ID="Btn_Update" runat="server" Text="Update" CssClass="btn btn-sm btn-success" />
                                <asp:Button ID="Btn_Save" runat="server" Text="Save" CssClass="btn btn-sm btn-success" />
                                <asp:Button ID="Btn_Cancel" runat="server" Text="Cancel" CssClass="btn btn-sm btn-success" />
                            </dx:PanelContent>
                        </PanelCollection>
                    </dx:ASPxCallbackPanel>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
