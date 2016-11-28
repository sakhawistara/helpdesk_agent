<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/HTML/Ticket.Master" CodeBehind="todolist_ticket.aspx.vb" Inherits="ICC.todolist_ticket" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
    <script>
        function OnRowClick(s, e) {
            grid.GetRowValues(grid.GetFocusedRowIndex(), 'TicketNumber;', OnGetRowValuesss);
        }
        function OnGetRowValuesss(values) {
            //alert(values[0]); //ini dapetin id
            //alert(values[1]); //ini dapetin voice_file
            //alert(values[2]); ini dapetin duration
            //alert(values[3]); //ini dapetin extension

            document.getElementById('MainContent_callbackPanelX_NIK').value = values[0]; //ini dapetin id
            //document.getElementById('MainContent_GetIDs').value = values[0]; //ini dapetin id
            //alert(values[0]);
            callbackPanelX.PerformCallback(values[0]);
            //document.getElementById('GetExtension').value = values[3]; //ini dapetin extension
            //document.getElementById('GetName').value = values[4]; //ini dapetin Name
            //document.getElementById('GetDate').value = values[5]; //ini dapetin Date
            //document.getElementById("player").URL = "../VoiceVRWeb/" + values[1];
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li><i class="fa fa-home"></i>&nbsp;<a href="dashboard.aspx">Home</a></li>
            <li class="active">Todolist</li>
        </ul>
    </div>
    <div class="padding-md">
        <div class="row">
            <input type="hidden" name="loginsearch" value="<% Response.Write(Request.QueryString("sul"))%>" />
            <asp:SqlDataSource ID="SourceCRO" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
            <input type="hidden" id="fileMenu" name="fileMenu" value="TTicketing.aspx" />
            <dx:ASPxGridView ID="grid" Width="100%" runat="server" Theme="MetropolisBlue"
                 ClientInstanceName="grid" SettingsBehavior-AllowFocusedRow="false"
                AutoGenerateColumns="False">
                <SettingsPager PageSize="20">
                    <AllButton Text="All">
                    </AllButton>
                    <NextPageButton Text="Next &gt;">
                    </NextPageButton>
                    <PrevPageButton Text="&lt; Prev">
                    </PrevPageButton>
                </SettingsPager>
                <SettingsEditing Mode="Inline" />
                <Settings ShowFilterRow="false" ShowFilterRowMenu="false" ShowGroupPanel="true" ShowHorizontalScrollBar="true" />
                <Settings ShowVerticalScrollBar="false" />
                <SettingsBehavior ConfirmDelete="true" />
                <SettingsLoadingPanel ImagePosition="Top" />
                <Columns>
                    <dx:GridViewDataTextColumn Caption="Action" FieldName="UserCreate" VisibleIndex="0"
                        Width="60px" CellStyle-HorizontalAlign="Center">
                        <DataItemTemplate>
                            <a href="utama.aspx?tid=<%# Eval("TicketNumber") %>&layer=<%# Session("LoginType") %>&NIK=<%# Eval("NIK") %>&DateCreate=<%# Eval("DateCreate") %>">
                              <img src='img/icon/Text-Edit-icon2.png' /></a>
                        </DataItemTemplate>
                        <CellStyle HorizontalAlign="Center">
                        </CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataImageColumn Caption="Indikator Response Agent" FieldName="RangeResponse" VisibleIndex="0"
                        Width="150px" HeaderStyle-HorizontalAlign="Center">
                        <CellStyle HorizontalAlign="Center">
                        </CellStyle>
                    </dx:GridViewDataImageColumn>
                    <dx:GridViewDataImageColumn Caption="Indikator SLA" FieldName="StatusIndikator" VisibleIndex="0"
                        Width="110px" HeaderStyle-HorizontalAlign="Center">
                        <CellStyle HorizontalAlign="Center">
                        </CellStyle>
                    </dx:GridViewDataImageColumn>
                    <dx:GridViewDataTextColumn Caption="No" FieldName="NumberRow" HeaderStyle-HorizontalAlign="left"
                        VisibleIndex="0" Width="70px" CellStyle-HorizontalAlign="left">
                        <CellStyle HorizontalAlign="left">
                        </CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="No" FieldName="NoUrut" HeaderStyle-HorizontalAlign="left"
                        VisibleIndex="0" Width="70px" CellStyle-HorizontalAlign="left" Visible="false">
                        <CellStyle HorizontalAlign="left">
                        </CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Ticket Number" HeaderStyle-HorizontalAlign="left"
                        FieldName="TicketNumber" VisibleIndex="2" Width="180px" CellStyle-HorizontalAlign="left">
                        <CellStyle HorizontalAlign="left">
                        </CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Customer ID" FieldName="NIK" HeaderStyle-HorizontalAlign="left"
                        VisibleIndex="1" Width="100px" CellStyle-HorizontalAlign="left" Visible="false">
                        <CellStyle HorizontalAlign="left">
                        </CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Customer Name" FieldName="NamePIC" HeaderStyle-HorizontalAlign="left"
                        VisibleIndex="1" Width="180px" CellStyle-HorizontalAlign="left">
                        <CellStyle HorizontalAlign="left">
                        </CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Description" HeaderStyle-HorizontalAlign="left"
                        FieldName="DetailComplaint" VisibleIndex="6" Width="600px">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Status" FieldName="Status" HeaderStyle-HorizontalAlign="left"
                        VisibleIndex="3" Width="80px" CellStyle-HorizontalAlign="left">
                        <CellStyle HorizontalAlign="left">
                        </CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="SLA" FieldName="SLA" HeaderStyle-HorizontalAlign="left"
                        VisibleIndex="4" Width="120px" CellStyle-HorizontalAlign="left">
                        <PropertiesTextEdit DisplayFormatString="{0} Hours">
                        </PropertiesTextEdit>
                        <CellStyle HorizontalAlign="left">
                        </CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Over SLA" FieldName="Range" HeaderStyle-HorizontalAlign="left"
                        VisibleIndex="5" Width="120px" CellStyle-HorizontalAlign="left">
                        <PropertiesTextEdit DisplayFormatString="{0} Hours">
                        </PropertiesTextEdit>
                        <CellStyle HorizontalAlign="left">
                        </CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Date Create" FieldName="DateCreate" HeaderStyle-HorizontalAlign="left"
                        VisibleIndex="6" Width="170px" CellStyle-HorizontalAlign="left">
                        <CellStyle HorizontalAlign="left">
                        </CellStyle>
                    </dx:GridViewDataTextColumn>
                </Columns>
                <StylesEditors>
                    <CalendarHeader Spacing="1px">
                    </CalendarHeader>
                    <ProgressBar Height="29px">
                    </ProgressBar>
                </StylesEditors>
            </dx:ASPxGridView>

        </div>
    </div>
    <asp:SqlDataSource ID="SourceTicket" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
    
</asp:Content>
