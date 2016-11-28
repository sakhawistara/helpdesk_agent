<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/HTML/Ticket.Master" CodeBehind="add_user.aspx.vb" Inherits="ICC.add_user" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="div_calltype_one" runat="server">
        <div id="breadcrumb">
            <ul class="breadcrumb">
                <li><i class="fa fa-home"></i>&nbsp;<a href="dashboard.aspx">Home</a></li>
                <li class="active">Add User</li>
            </ul>
        </div>
        <div class="padding-md">
            <div class="row">
                <div style="overflow: auto;" id="div_ticket" runat="server">
                    <dx:ASPxGridView ID="ASPxGridView1" KeyFieldName="UserId" Width="100%" runat="server" Theme="MetropolisBlue"
                        DataSourceID="sql_add_user" OnRowInserting="ASPxGridView1_RowInserting" SettingsPager-PageSize="10">
                        <SettingsPager>
                            <AllButton Text="All">
                            </AllButton>
                            <NextPageButton Text="Next &gt;">
                            </NextPageButton>
                            <PrevPageButton Text="&lt; Prev">
                            </PrevPageButton>
                        </SettingsPager>
                        <SettingsEditing Mode="Inline" />
                        <Settings ShowFilterRow="true" ShowFilterRowMenu="false" ShowFilterBar="Hidden" ShowVerticalScrollBar="false"
                             ShowGroupPanel="false" />
                        <SettingsBehavior ConfirmDelete="true" />
                        <Columns>
                            <dx:GridViewCommandColumn Caption="ACTION" HeaderStyle-HorizontalAlign="Center" VisibleIndex="0"
                                ButtonType="Image" FixedStyle="Left" CellStyle-BackColor="#ffffd6" Width="130px">
                                <EditButton Visible="True">
                                    <Image ToolTip="Edit" Url="img/Icon/Text-Edit-icon2.png" />
                                </EditButton>
                                <NewButton Visible="True">
                                    <Image ToolTip="New" Url="img/Icon/Apps-text-editor-icon2.png" />
                                </NewButton>
                                <DeleteButton Visible="True">
                                    <Image ToolTip="Delete" Url="img/Icon/Actions-edit-clear-icon2.png" />
                                </DeleteButton>
                                <CancelButton>
                                    <Image ToolTip="Cancel" Url="img/Icon/cancel1.png">
                                    </Image>
                                </CancelButton>
                                <UpdateButton>
                                    <Image ToolTip="Update" Url="img/Icon/Updated1.png" />
                                </UpdateButton>
                                <CellStyle BackColor="#FFFFD6">
                                </CellStyle>
                            </dx:GridViewCommandColumn>
                            <dx:GridViewDataTextColumn Caption="USERNAME" Width="100px" FieldName="UserName" Settings-AutoFilterCondition="Contains"
                                VisibleIndex="1" HeaderStyle-HorizontalAlign="Center">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="PASSWORD" Width="100px" FieldName="Password" Settings-AutoFilterCondition="Contains"
                                VisibleIndex="2" HeaderStyle-HorizontalAlign="Center">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataComboBoxColumn Caption="LEVEL USER" FieldName="LevelUser" VisibleIndex="4"
                                HeaderStyle-HorizontalAlign="Center" Width="150px">
                                <PropertiesComboBox TextField="Name" ValueField="Name" EnableSynchronization="False"
                                    TextFormatString="{0}" IncrementalFilteringMode="Contains" DataSourceID="sql_level_user">
                                    <Columns>
                                        <dx:ListBoxColumn Caption="Level User" FieldName="Name" Width="100px" />
                                    </Columns>
                                </PropertiesComboBox>
                            </dx:GridViewDataComboBoxColumn>
                            <dx:GridViewDataComboBoxColumn Caption="DIVISION" FieldName="UnitKerja" VisibleIndex="5" HeaderStyle-HorizontalAlign="Center"
                                Width="150px" Settings-AutoFilterCondition="Contains">
                                <PropertiesComboBox TextField="Divisi" ValueField="Divisi" EnableSynchronization="False"
                                    TextFormatString="{0}" IncrementalFilteringMode="Contains" DataSourceID="sql_unit_kerja">
                                    <Columns>
                                        <dx:ListBoxColumn Caption="Divisi" FieldName="Divisi" Width="200px" />
                                    </Columns>
                                </PropertiesComboBox>
                            </dx:GridViewDataComboBoxColumn>
                            <dx:GridViewDataComboBoxColumn Caption="NIK" FieldName="NIK" VisibleIndex="6" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains"
                                Width="150px">
                                <PropertiesComboBox TextField="Description" ValueField="NIK" EnableSynchronization="False"
                                    TextFormatString="{0}" IncrementalFilteringMode="Contains" DataSourceID="sql_nik">
                                    <Columns>
                                        <dx:ListBoxColumn Caption="NIK" FieldName="NIK" Width="100px" />
                                        <dx:ListBoxColumn Caption="Name" FieldName="Name" Width="100px" />
                                    </Columns>
                                </PropertiesComboBox>
                            </dx:GridViewDataComboBoxColumn>
                            <dx:GridViewDataTextColumn Caption="INBOUND" Width="100px" FieldName="INBOUND" Settings-AutoFilterCondition="Contains"
                                HeaderStyle-HorizontalAlign="Center">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="OUTBOUND" Width="100px" FieldName="OUTBOUND" Settings-AutoFilterCondition="Contains"
                                HeaderStyle-HorizontalAlign="Center">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="FAX" Width="100px" FieldName="FAX" Settings-AutoFilterCondition="Contains"
                                HeaderStyle-HorizontalAlign="Center">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="SMS" Width="100px" FieldName="SMS" Settings-AutoFilterCondition="Contains"
                                 HeaderStyle-HorizontalAlign="Center">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="CHAT" Width="100px" FieldName="CHAT" Settings-AutoFilterCondition="Contains"
                                HeaderStyle-HorizontalAlign="Center">
                            </dx:GridViewDataTextColumn>
                            <%--<dx:GridViewDataTextColumn Caption="SOSMED" Width="100px" FieldName="UserName" Settings-AutoFilterCondition="Contains"
                                 HeaderStyle-HorizontalAlign="Center">
                            </dx:GridViewDataTextColumn>--%>
                        </Columns>
                    </dx:ASPxGridView>
                    <asp:SqlDataSource ID="sql_add_user" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
                    <asp:SqlDataSource ID="sql_user_sbg" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
                    <asp:SqlDataSource ID="sql_unit_kerja" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
                    <asp:SqlDataSource ID="sql_nik" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
                    <asp:SqlDataSource ID="sql_level_user" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
