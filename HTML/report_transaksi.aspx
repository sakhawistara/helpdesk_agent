<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/HTML/Ticket.Master" CodeBehind="report_transaksi.aspx.vb" Inherits="ICC.report_transaksi" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView.Export" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.XtraReports.v13.2.Web, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="div_calltype_one" runat="server">
        <div id="breadcrumb">
            <ul class="breadcrumb">
                <li><i class="fa fa-home"></i>&nbsp;<a href="dashboard.aspx">Home</a></li>
                <li class="active">Report Transaksi</li>
            </ul>
        </div>
        <div class="padding-md">
            <div class="row">
                <div style="overflow: auto;" id="div_ticket" runat="server">
                    <div class="col-md-2">
                        <label class="control-label">Source Type</label>
                        <dx:ASPxComboBox ID="cbChannelTransaksi" ClientInstanceName="cbChannelTransaksi" runat="server" CssClass="form-control chzn-select"
                            DropDownWidth="130" Theme="MetropolisBlue"
                            DropDownStyle="DropDownList" DataSourceID="dsChannelTransaksi" ValueField="TicketIDCode" TextField="Name"
                            ValueType="System.String" TextFormatString="{0}" EnableCallbackMode="true" IncrementalFilteringMode="StartsWith"
                            Width="130px">
                            <Columns>
                                <dx:ListBoxColumn FieldName="Name" Caption="Source Type" Width="10px" />
                            </Columns>
                            <ClientSideEvents Init="function(s, e) {
                                if (cbChannelTransaksi.GetItem(0).value!=0)
                            {
                                 cbChannelTransaksi.InsertItem(0,'All',0);
                            }
                                 cbChannelTransaksi.SetSelectedIndex(0);
                            }" />
                        </dx:ASPxComboBox>
                        <asp:SqlDataSource ID="dsChannelTransaksi" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>

                    </div>
                    <div class="col-md-2">
                        <label class="control-label">Category</label>
                        <dx:ASPxComboBox ID="cbJenisTransaksi" ClientInstanceName="cbJenisTransaksi" runat="server" DropDownWidth="130" Theme="MetropolisBlue" CssClass="form-control chzn-select"
                            DropDownStyle="DropDownList" DataSourceID="dsJenisTransaksi" ValueField="CategoryID" TextField="Name"
                            ValueType="System.String" TextFormatString="{0}" EnableCallbackMode="true" IncrementalFilteringMode="StartsWith"
                            Width="130px">
                            <Columns>
                                <dx:ListBoxColumn FieldName="Name" Caption="Category" Width="10px" />
                            </Columns>
                            <ClientSideEvents Init="function(s, e) {
                                if (cbJenisTransaksi.GetItem(0).value!=0)
                            {
                                 cbJenisTransaksi.InsertItem(0,'All',0);
                            }
                                 cbJenisTransaksi.SetSelectedIndex(0);
                            }" />
                        </dx:ASPxComboBox>
                        <asp:SqlDataSource ID="dsJenisTransaksi" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
                    </div>
                    <div class="col-md-2">
                        <label class="control-label">Brand</label>
                        <dx:ASPxComboBox ID="cbUnitKerja" ClientInstanceName="cbUnitKerja" runat="server" Theme="MetropolisBlue" CssClass="form-control chzn-select"
                            DropDownStyle="DropDownList" DataSourceID="dsUnitKerja" ValueField="SubCategory1ID" TextField="SubjectTable"
                            ValueType="System.String" TextFormatString="{0}" EnableCallbackMode="true" IncrementalFilteringMode="StartsWith"
                            Width="130px">
                            <Columns>
                                <dx:ListBoxColumn FieldName="SubjectTable" Caption="Brand" Width="10px" />
                            </Columns>
                            <ClientSideEvents Init="function(s, e) {
                                if (cbUnitKerja.GetItem(0).value!=0)
                            {
                                 cbUnitKerja.InsertItem(0,'All',0);
                            }
                                 cbUnitKerja.SetSelectedIndex(0);
                            }" />
                        </dx:ASPxComboBox>
                        <asp:SqlDataSource ID="dsUnitKerja" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
                    </div>
                    <div class="col-md-2">
                        <label class="control-label">Product</label>
                        <dx:ASPxComboBox ID="cbSubject" ClientInstanceName="cbSubject" runat="server" DropDownWidth="130" Theme="MetropolisBlue" CssClass="form-control chzn-select"
                            DropDownStyle="DropDownList" DataSourceID="dsSubject" ValueField="SubCategory2ID" TextField="SubjectTable"
                            ValueType="System.String" TextFormatString="{0}" EnableCallbackMode="true" IncrementalFilteringMode="StartsWith"
                            Width="130px">
                            <Columns>
                                <dx:ListBoxColumn FieldName="SubjectTable" Caption="Product" Width="10px" />
                            </Columns>

                            <ClientSideEvents Init="function(s, e) {
                                if (cbSubject.GetItem(0).value!=0)
                            {
                                 cbSubject.InsertItem(0,'All',0);
                            }
                                 cbSubject.SetSelectedIndex(0);
                            }" />
                        </dx:ASPxComboBox>
                        <asp:SqlDataSource ID="dsSubject" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>

                    </div>
                    <div class="col-md-2">
                        <label class="control-label">Status Transaksi</label>
                        <dx:ASPxComboBox ID="cbStatusTransaksi" ClientInstanceName="cbStatusTransaksi" runat="server" DropDownWidth="130" Theme="MetropolisBlue" CssClass="form-control chzn-select"
                            DropDownStyle="DropDownList"
                            ValueType="System.String" TextFormatString="{0}" EnableCallbackMode="true" IncrementalFilteringMode="StartsWith"
                            Width="130px">
                            <Items>
                                <dx:ListEditItem Value="Open" Text="Open" />
                                <dx:ListEditItem Value="Closed" Text="Closed" />
                            </Items>
                           <%-- <ClientSideEvents Init="function(s, e) {
                                if (cbStatusTransaksi.GetItem(0).value!=0)
                            {
                                 cbStatusTransaksi.InsertItem(0,'All',0);
                            }
                                 cbStatusTransaksi.SetSelectedIndex(0);
                            }" />--%>
                        </dx:ASPxComboBox>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
