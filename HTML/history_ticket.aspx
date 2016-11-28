<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/HTML/Ticket.Master" CodeBehind="history_ticket.aspx.vb" Inherits="ICC.history_ticket" %>

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
                <li class="active">Ticket History</li>
            </ul>
        </div>
    </div>
    <div class="padding-md">
        <div class="row">
            <div>
                <dx:ASPxGridView ID="ASPxGridView1" ClientInstanceName="ASPxGridView1" runat="server" Theme="MetropolisBlue"
                    DataSourceID="masterDataSource" KeyFieldName="CustomerID" Width="100%">
                    <SettingsPager>
                        <AllButton Text="All">
                        </AllButton>
                        <NextPageButton Text="Next &gt;">
                        </NextPageButton>
                        <PrevPageButton Text="&lt; Prev">
                        </PrevPageButton>
                    </SettingsPager>
                    <SettingsPager PageSize="10" />
                    <Settings ShowFilterRow="true" ShowGroupPanel="false" ShowHorizontalScrollBar="true" />
                    <Columns>
                        <dx:GridViewDataColumn FieldName="CustomerID" VisibleIndex="1" Width="150px" Settings-AutoFilterCondition="Contains" />
                        <dx:GridViewDataColumn FieldName="NamaPerusahaan" Width="400px" VisibleIndex="2" Settings-AutoFilterCondition="Contains" />
                        <dx:GridViewDataColumn Caption="Nama PIC" FieldName="NamePIC" Width="200px" VisibleIndex="3" Settings-AutoFilterCondition="Contains">
                        </dx:GridViewDataColumn>
                        <dx:GridViewDataColumn FieldName="Email" VisibleIndex="4" Width="200px" Settings-AutoFilterCondition="Contains" />
                        <dx:GridViewDataColumn FieldName="Alamat" Width="600px" VisibleIndex="5" Settings-AutoFilterCondition="Contains" />
                    </Columns>
                    <Templates>
                        <DetailRow>
                            <dx:ASPxGridView ID="grid" Width="980px" runat="server" DataSourceID="SourceTicket" KeyFieldName="TicketNumber" ClientInstanceName="grid"
                                SettingsBehavior-AllowFocusedRow="true" OnBeforePerformDataSelect="TicketNumber_DataSelect" Theme="MetropolisBlue">
                                <SettingsPager>
                                    <AllButton Text="All">
                                    </AllButton>
                                    <NextPageButton Text="Next &gt;">
                                    </NextPageButton>
                                    <PrevPageButton Text="&lt; Prev">
                                    </PrevPageButton>
                                </SettingsPager>
                                <SettingsPager PageSize="2" />
                                <SettingsEditing Mode="Inline" />
                                <Settings ShowGroupPanel="true" ShowHorizontalScrollBar="true" ShowFilterRow="true" />
                                <SettingsBehavior ConfirmDelete="true" />
                                <Columns>
                                    <dx:GridViewDataTextColumn Caption="Customer ID" FieldName="NIK" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                        Width="90px" CellStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="left"
                                        Visible="true">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="PIC Name" FieldName="NamePIC" VisibleIndex="1" Settings-AutoFilterCondition="Contains"
                                        Width="150px" CellStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="left">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Ticket Number" FieldName="TicketNumber" VisibleIndex="2"
                                        Width="180px" CellStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="left">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Complaint" FieldName="DetailComplaint" VisibleIndex="3" Settings-AutoFilterCondition="Contains"
                                        Width="250px" HeaderStyle-HorizontalAlign="left">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption=" Response " FieldName="ResponComplaint" VisibleIndex="9" Settings-AutoFilterCondition="Contains"
                                        Width="250px" HeaderStyle-HorizontalAlign="left">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Status" FieldName="Status" VisibleIndex="4" Width="85px"
                                        CellStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="left">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Source" FieldName="TicketSource" VisibleIndex="5" Settings-AutoFilterCondition="Contains"
                                        Width="70px" CellStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="left">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="User Create" FieldName="Name" VisibleIndex="6" Settings-AutoFilterCondition="Contains"
                                        Width="150px" CellStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="left">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Date Create" FieldName="DateCreate" VisibleIndex="10"
                                        Width="170px" HeaderStyle-HorizontalAlign="left" CellStyle-HorizontalAlign="left">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Date Close" FieldName="DateClose" VisibleIndex="11"
                                        Width="170px" HeaderStyle-HorizontalAlign="left" CellStyle-HorizontalAlign="left">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="SLA" FieldName="SLA" VisibleIndex="7" Width="50px"
                                        CellStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="left">
                                        <PropertiesTextEdit DisplayFormatString="{0} Hour">
                                        </PropertiesTextEdit>
                                        <CellStyle HorizontalAlign="Center">
                                        </CellStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Over SLA" FieldName="Range" HeaderStyle-HorizontalAlign="left"
                                        VisibleIndex="8" Width="100px" CellStyle-HorizontalAlign="left">
                                        <PropertiesTextEdit DisplayFormatString="{0} Hour">
                                        </PropertiesTextEdit>
                                        <CellStyle HorizontalAlign="Center">
                                        </CellStyle>
                                    </dx:GridViewDataTextColumn>
                                </Columns>
                                <Templates>
                                    <DetailRow>
                                        <dx:ASPxGridView ID="GridList" Width="920px" runat="server" DataSourceID="SqlDataSource1"
                                            KeyFieldName="ID" OnBeforePerformDataSelect="GridList_DataSelect" Theme="MetropolisBlue">
                                            <SettingsEditing Mode="Inline" />
                                            <Settings VerticalScrollBarStyle="Virtual" />
                                            <Columns>
                                                <dx:GridViewDataTextColumn Caption="No" FieldName="Row" VisibleIndex="1" HeaderStyle-HorizontalAlign="left"
                                                    CellStyle-HorizontalAlign="left" Width="50px" Visible="true">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption=" Agent Create " FieldName="Name" VisibleIndex="2" Settings-AutoFilterCondition="Contains"
                                                    HeaderStyle-HorizontalAlign="left" CellStyle-HorizontalAlign="left" Width="200px">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption=" Response Complaint " FieldName="ResponseComplaint" Settings-AutoFilterCondition="Contains"
                                                    VisibleIndex="3" Width="700px" HeaderStyle-HorizontalAlign="left">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption=" Date Create " FieldName="DateCreate" VisibleIndex="4"
                                                    HeaderStyle-HorizontalAlign="left" Width="200px" CellStyle-HorizontalAlign="left">
                                                </dx:GridViewDataTextColumn>
                                            </Columns>
                                        </dx:ASPxGridView>
                                    </DetailRow>
                                </Templates>
                                <SettingsDetail ShowDetailRow="true" />
                                <Settings ShowFooter="True" />
                            </dx:ASPxGridView>
                        </DetailRow>
                    </Templates>
                    <SettingsDetail ShowDetailRow="true" />
                    <Settings ShowFooter="True" />
                </dx:ASPxGridView>
                <asp:SqlDataSource ID="SourceTicket" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
                <asp:SqlDataSource ID="masterDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
            </div>
        </div>
    </div>
</asp:Content>
