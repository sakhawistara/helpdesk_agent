<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/HTML/Ticket.Master" CodeBehind="email_address.aspx.vb" Inherits="ICC.email_address" %>


<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="div_email_address" runat="server">
        <div id="breadcrumb">
            <ul class="breadcrumb">
                <li><i class="fa fa-home"></i>&nbsp;<a href="dashboard.aspx">Home</a></li>
                <li class="active">Email Address</li>
            </ul>
        </div>
        <div class="padding-md">
            <div class="row">
                <div style="overflow: auto;">
                    <dx:ASPxGridView ID="GRmEmailSuzuki" ClientInstanceName="ASPxGridView1" Width="1030px" runat="server" DataSourceID="sql_email_address" KeyFieldName="ID"
                        SettingsPager-PageSize="10" Theme="MetropolisBlue">
                        <SettingsPager>
                            <AllButton Text="All">
                            </AllButton>
                            <NextPageButton Text="Next &gt;">
                            </NextPageButton>
                            <PrevPageButton Text="&lt; Prev">
                            </PrevPageButton>
                        </SettingsPager>
                        <SettingsEditing Mode="Inline" />
                        <Settings ShowFilterRow="true" ShowGroupPanel="true" />
                        <SettingsBehavior ConfirmDelete="true" />
                        <Columns>
                            <dx:GridViewCommandColumn Caption="Action" HeaderStyle-HorizontalAlign="Center" VisibleIndex="0"
                                ButtonType="Image" FixedStyle="Left" CellStyle-BackColor="#ffffd6" Width="130px">
                                <HeaderTemplate>
                                    <dx:ASPxHyperLink ID="lnkClearFilter" runat="server" ForeColor="White" Font-Bold="true" Text="Clear Filter" NavigateUrl="javascript:void(0);">
                                        <ClientSideEvents Click="function(s, e) {
                                        ASPxGridView1.ClearFilter();
                                    }" />
                                    </dx:ASPxHyperLink>
                                </HeaderTemplate>
                                <EditButton Visible="True">
                                    <Image ToolTip="Edit" Url="img/icon/Text-Edit-icon2.png" />
                                </EditButton>
                                <NewButton Visible="True">
                                    <Image ToolTip="New" Url="img/icon/Apps-text-editor-icon2.png" />
                                </NewButton>
                                <DeleteButton Visible="false">
                                    <Image ToolTip="Delete" Url="img/icon/Actions-edit-clear-icon2.png" />
                                </DeleteButton>
                                <CancelButton>
                                    <Image ToolTip="Cancel" Url="img/icon/cancel1.png">
                                    </Image>
                                </CancelButton>
                                <UpdateButton>
                                    <Image ToolTip="Update" Url="img/icon/Updated1.png" />
                                </UpdateButton>
                                <CellStyle BackColor="#FFFFD6">
                                </CellStyle>
                            </dx:GridViewCommandColumn>
                            <dx:GridViewDataTextColumn Caption="Email Address" FieldName="EmailAddress" VisibleIndex="2" Width="450px" HeaderStyle-HorizontalAlign="Center">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataComboBoxColumn Caption="Type" FieldName="TypeLevel" VisibleIndex="3" HeaderStyle-HorizontalAlign="Center"
                                Width="70px">
                                <PropertiesComboBox>
                                    <Items>
                                        <dx:ListEditItem Text="Create Ticket" Value="CreateTicket" />
                                        <dx:ListEditItem Text="Close Ticket" Value="CloseTicket" />
                                        <dx:ListEditItem Text="Dispatch Ticket" Value="DispatchTicket" />
                                    </Items>
                                </PropertiesComboBox>
                            </dx:GridViewDataComboBoxColumn>
                            <dx:GridViewDataComboBoxColumn Caption="Status" FieldName="NA" VisibleIndex="4" HeaderStyle-HorizontalAlign="Center"
                                Width="70px">
                                <PropertiesComboBox>
                                    <Items>
                                        <dx:ListEditItem Text="Active" Value="Y" Selected="true" />
                                        <dx:ListEditItem Text="In Active" Value="N" Selected="false" />
                                    </Items>
                                </PropertiesComboBox>
                            </dx:GridViewDataComboBoxColumn>
                        </Columns>
                    </dx:ASPxGridView>
                </div>
            </div>
            <asp:SqlDataSource ID="sql_email_address" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
        </div>
    </div>
</asp:Content>
