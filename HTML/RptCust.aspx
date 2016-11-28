<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/HTML/Ticket.Master" CodeBehind="RptCust.aspx.vb" Inherits="ICC.RptCust" %>

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
                <li class="active">Report Customer</li>
            </ul>
        </div>
        <div class="padding-md">
            <div class="row">
                <div class="col-md-12">
                    <asp:TextBox ID="txt_phone" runat="server" CssClass="form-control input-sm" placeholder="Phone"></asp:TextBox>
                </div>
            </div>
            <hr />
            <div class="row">
                <div class="col-md-12">
                    <div style="overflow: auto;">
                        <dx:ASPxGridView ID="Gv_rpt_customer" runat="server" DataSourceID="sql_rpt_customer"
                            Width="100%" Theme="MetropolisBlue">
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
                                <dx:GridViewDataTextColumn Caption="No" Width="50px"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Ticket Number"></dx:GridViewDataTextColumn>
                            </Columns>
                        </dx:ASPxGridView>
                    </div>
                </div>
            </div>
            <asp:SqlDataSource ID="sql_rpt_customer" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
        </div>
    </div>
</asp:Content>
