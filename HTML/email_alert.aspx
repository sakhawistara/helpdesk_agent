<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/HTML/Ticket.Master" CodeBehind="email_alert.aspx.vb" Inherits="ICC.email_alert" %>


<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div id="div_email_alert" runat="server">
        <div id="breadcrumb">
            <ul class="breadcrumb">
                <li><i class="fa fa-home"></i>&nbsp;<a href="dashboard.aspx">Home</a></li>
                <li class="active">Email Alert</li>
            </ul>
        </div>
        <div class="padding-md">
            <div class="row">
                <div style="overflow: auto;">
                    <dx:ASPxGridView ID="ASPxGridView1" ClientInstanceName="ASPxGridView1" Width="1030px"
                        runat="server" DataSourceID="DsTools" KeyFieldName="ID" SettingsPager-PageSize="10" Theme="MetropolisBlue">
                        <SettingsPager>
                            <AllButton Text="All">
                            </AllButton>
                            <NextPageButton Text="Next &gt;">
                            </NextPageButton>
                            <PrevPageButton Text="&lt; Prev">
                            </PrevPageButton>
                        </SettingsPager>
                        <SettingsEditing Mode="Inline" />
                        <Settings ShowFilterRow="true" ShowFilterRowMenu="false" ShowGroupPanel="true" />
                        <SettingsBehavior ConfirmDelete="true" />
                        <Styles>
                            <%--<Header BackColor="#a5a494" ForeColor="White" HorizontalAlign="Center" Font-Bold="true">
                        </Header>--%>
                        </Styles>
                        <Columns>
                            <dx:GridViewCommandColumn Caption="Action" HeaderStyle-HorizontalAlign="Center" VisibleIndex="0"
                                ButtonType="Image" FixedStyle="Left" CellStyle-BackColor="#ffffd6" Width="130px">
                                <HeaderTemplate>
                                    <dx:ASPxHyperLink ID="lnkClearFilter" runat="server" ForeColor="White" Font-Bold="true"
                                        Text="Clear Filter" NavigateUrl="javascript:void(0);">
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
                            <dx:GridViewDataTextColumn Caption="ID" FieldName="ID" VisibleIndex="0" Width="10px"
                                HeaderStyle-HorizontalAlign="Center" Visible="false">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataComboBoxColumn Caption="Alert Email Setting" FieldName="ToolEmail"
                                VisibleIndex="1" HeaderStyle-HorizontalAlign="Center" Width="360px">
                                <PropertiesComboBox TextField="ToolEmail" ValueField="ToolEmail" EnableSynchronization="False"
                                    TextFormatString="{0}" IncrementalFilteringMode="StartsWith">
                                    <Items>
                                        <dx:ListEditItem Text="Email Create Ticket" Value="EmailCreate" />
                                        <dx:ListEditItem Text="Email Closed Ticket" Value="EmailClosed " />
                                        <dx:ListEditItem Text="Email Dispatch Ticket" Value="EmailDispatch" />
                                    </Items>
                                </PropertiesComboBox>
                            </dx:GridViewDataComboBoxColumn>
                            <dx:GridViewDataComboBoxColumn Caption="Status" FieldName="Status" VisibleIndex="2"
                                HeaderStyle-HorizontalAlign="Center" Width="70px">
                                <PropertiesComboBox>
                                    <Items>
                                        <dx:ListEditItem Text="Active" Value="True" />
                                        <dx:ListEditItem Text="In Active" Value="False" />
                                    </Items>
                                </PropertiesComboBox>
                            </dx:GridViewDataComboBoxColumn>
                        </Columns>
                    </dx:ASPxGridView>
                </div>
            </div>
            <asp:SqlDataSource ID="DsTools" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"
                SelectCommand="select * from tManejemEmail"></asp:SqlDataSource>
        </div>
    </div>
</asp:Content>
