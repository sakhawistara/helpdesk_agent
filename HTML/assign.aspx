<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/HTML/Ticket.Master" CodeBehind="assign.aspx.vb" Inherits="ICC.assign" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="div_assign" runat="server">
        <div id="breadcrumb">
            <ul class="breadcrumb">
                <li><i class="fa fa-home"></i>&nbsp;<a href="dashboard.aspx">Home</a></li>
                <li class="active">Ticket Assign</li>
            </ul>
        </div>
        <div class="padding-md">
            <div class="row">
                <div>
                    <dx:ASPxGridView ID="gv_assign" runat="server" KeyFieldName="ID"
                        DataSourceID="sql_assign" Width="100%" Theme="MetropolisBlue">
                        <SettingsPager>
                            <AllButton Text="All">
                            </AllButton>
                            <NextPageButton Text="Next &gt;">
                            </NextPageButton>
                            <PrevPageButton Text="&lt; Prev">
                            </PrevPageButton>
                        </SettingsPager>
                        <SettingsEditing Mode="Inline" />
                        <Settings ShowFilterRow="true" ShowFilterRowMenu="false" ShowGroupPanel="true"
                            ShowVerticalScrollBar="false" ShowHorizontalScrollBar="false" />
                        <SettingsBehavior ConfirmDelete="true" />
                        <Columns>
                            <dx:GridViewDataTextColumn Caption="Action" FieldName="UserCreate" VisibleIndex="0"
                                Width="60px" CellStyle-HorizontalAlign="Center">
                                <DataItemTemplate>
                                    <a href="utama.aspx?tid=<%# Eval("TicketNumber")%>&NIK=<%# Eval("NIK")%>" target="_blank">
                                        <img src='img/icon/Text-Edit-icon2.png' /></a>
                                </DataItemTemplate>
                                <CellStyle HorizontalAlign="Center">
                                </CellStyle>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Ticket Number" FieldName="TicketNumber" Width="130px"></dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Name" FieldName="NamaPerusahaan"></dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Description" FieldName="DetailComplaint"></dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Status" FieldName="Status" Width="70px"></dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Date Create" FieldName="DateCreate"></dx:GridViewDataTextColumn>
                        </Columns>
                    </dx:ASPxGridView>
                    <asp:SqlDataSource ID="sql_assign" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
