<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/HTML/Ticket.Master" CodeBehind="ReportFilter.aspx.vb" Inherits="ICC.ReportFilter" %>

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
    <a href="ReportFilter.aspx">Refresh</a>
    <asp:SqlDataSource ID="dsJenisTransaksi" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
    <asp:SqlDataSource ID="dsChannelTransaksi" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
    <asp:SqlDataSource ID="dsUnitKerja" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
    <asp:SqlDataSource ID="dsSubject" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
    <asp:SqlDataSource ID="dsNamaKaryawan" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
    <br />
    <center>        
    <table width="90%" border="0">
        <tr>
            <td align="center">
                <b>
                    <dx:ASPxLabel ID="Label1" runat="server" Text="1. Choose Report Category" 
                        Font-Bold="True" ForeColor="#0076c4" Font-Names="Tahoma" Font-Size="10" Font-Italic="True">
                    </dx:ASPxLabel>
                </b>
            </td>
            <td colspan="2" align="center">
                <b>
                    <dx:ASPxLabel ID="Label2" runat="server" Text="2. Choose Report Period" 
                        Font-Bold="True" ForeColor="#0076c4" Font-Names="Tahoma" Font-Size="10" Font-Italic="True">                        
                    </dx:ASPxLabel>
                </b>
            </td>
            <td>
            
            </td>
            <td align="center" rowspan="2">
                <br /><br />
                
            </td>
        </tr>

        <tr>
            <td align="center">
                <br />
                
            </td>
            <td align="center">
                <br />
               
            </td>
lll                    <tr>
                        <td>
                            <table>
                                <tr><td><asp:Label ID="lbl_mesage" runat="server" ForeColor="red"></asp:Label></td></tr>
                                <tr runat="server" id="byTgl" >
                                    <td>
                                       
                                    </td>
                                    <td id="lblTo" runat="server">
                                        To
                                    </td>
                                    <td>
                                        
                                    </td> 
                                </tr>
                                <tr>
                                    <td>
                                    
                                        <dx:ASPxComboBox ID="filterMonth" runat="server" Theme="MetropolisBlue"
                                        DropDownStyle="DropDownList" DataSourceID="filterMonthSql" ValueField="Bulan"
                                        TextField="Bulan"
                                        ValueType="System.String" TextFormatString="{0}"  EnableCallbackMode="true" 
                                        IncrementalFilteringMode="StartsWith"
                                        CallbackPageSize="30">
                                        <Columns>                                          
                                            <dx:ListBoxColumn FieldName="NamaBulan" Caption="Bulan" Width="100px" />
                                        </Columns>                                        
                                        </dx:ASPxComboBox>
                                        <asp:SqlDataSource ID="filterMonthSql" runat="server"
                                            ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" >
                                        </asp:SqlDataSource>
                                    </td>
                                    <td> <dx:ASPxComboBox ID="selYear" runat="server" Theme="MetropolisBlue"
                                        DropDownStyle="DropDownList" DataSourceID="dsYear" ValueField="Year"
                                        ValueType="System.String" TextFormatString="{0}" EnableCallbackMode="true" 
                                        IncrementalFilteringMode="StartsWith"
                                        CallbackPageSize="30" Visible="false" >
                                        <Columns>
                                            <dx:ListBoxColumn FieldName="Year" Caption="Tahun" Width="100px" />
                                        </Columns>
                                        </dx:ASPxComboBox>
                                        <asp:SqlDataSource ID="dsYear" runat="server"
                                            ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" >
                                        </asp:SqlDataSource></td>
                                </tr>
                                <tr runat="server" id="byPeriod" >
                                    <td colspan="3" align="center" >
                                        <dx:ASPxRadioButtonList ID="rbPeriod" runat="server" RepeatColumns="1" Width="200"  RepeatLayout="Table">
                                        </dx:ASPxRadioButtonList>
                                        <br />
                                       
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>   
        </tr>    
       
</table>
    </center>
    <table style="margin-left: 90px;" runat="server" id="SourceDetail" visible="false">
        <tr>
            <td align="center" runat="server" id="headChnlTrx" visible="false">
                <b>
                    <%--Channel Transaksi--%>
                    <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Source Type"
                        Font-Bold="True" ForeColor="#0076c4" Font-Names="Tahoma" Font-Size="10" Font-Italic="True">
                    </dx:ASPxLabel>
                </b>
            </td>
            <td align="center" runat="server" id="headFilterTop" visible="false">
                <b>
                    <dx:ASPxLabel ID="ASPxLabel9" runat="server" Text="TOP Kategori"
                        Font-Bold="True" ForeColor="#0076c4" Font-Names="Tahoma" Font-Size="10" Font-Italic="True">
                    </dx:ASPxLabel>
                </b>
            </td>
            <td align="center" runat="server" id="headJnsTrx" visible="false">
                <b>
                    <%--Jenis Transaksi--%>
                    <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="Category"
                        Font-Bold="True" ForeColor="#0076c4" Font-Names="Tahoma" Font-Size="10" Font-Italic="True">
                    </dx:ASPxLabel>
                </b>
            </td>
            <td align="center" runat="server" id="headUnitKerja" visible="false">
                <b>
                    <%--Call Type 1--%>
                    <dx:ASPxLabel ID="ASPxLabel3" runat="server" Text="Brand"
                        Font-Bold="True" ForeColor="#0076c4" Font-Names="Tahoma" Font-Size="10" Font-Italic="True">
                    </dx:ASPxLabel>
                </b>
            </td>
            <td align="center" runat="server" id="headSubject" visible="false">
                <b>
                    <%--Call Type 2--%>
                    <dx:ASPxLabel ID="ASPxLabel4" runat="server" Text="Product"
                        Font-Bold="True" ForeColor="#0076c4" Font-Names="Tahoma" Font-Size="10" Font-Italic="True">
                    </dx:ASPxLabel>
                </b>
            </td>


            <td align="center" runat="server" id="headStatTrx" visible="false">
                <b>
                    <dx:ASPxLabel ID="ASPxLabel6" runat="server" Text="Status Transaksi"
                        Font-Bold="True" ForeColor="#0076c4" Font-Names="Tahoma" Font-Size="10" Font-Italic="True">
                    </dx:ASPxLabel>
                </b>
            </td>
            <td align="center" runat="server" id="headClosedBy" visible="false">
                <b>
                    <dx:ASPxLabel ID="ASPxLabel5" runat="server" Text="Closed By"
                        Font-Bold="True" ForeColor="#0076c4" Font-Names="Tahoma" Font-Size="10" Font-Italic="True">
                    </dx:ASPxLabel>
                </b>
            </td>
            <td align="center" runat="server" id="headTrxOleh" visible="false">
                <b>
                    <dx:ASPxLabel ID="ASPxLabel8" runat="server" Text="Transaksi Oleh"
                        Font-Bold="True" ForeColor="#0076c4" Font-Names="Tahoma" Font-Size="10" Font-Italic="True">
                    </dx:ASPxLabel>
                </b>
            </td>
            <td align="center" runat="server" id="headTrxClosed" visible="false">
                <b>
                    <dx:ASPxLabel ID="ASPxLabel10" runat="server" Text="Transaksi Oleh"
                        Font-Bold="True" ForeColor="#0076c4" Font-Names="Tahoma" Font-Size="10" Font-Italic="True">
                    </dx:ASPxLabel>
                </b>
            </td>
            <td align="center" runat="server" id="headAgentName" visible="false">
                <b>
                    <dx:ASPxLabel ID="ASPxLabel7" runat="server" Text="Agent Name"
                        Font-Bold="True" ForeColor="#0076c4" Font-Names="Tahoma" Font-Size="10" Font-Italic="True">
                    </dx:ASPxLabel>
                </b>
            </td>
            <td align="center" runat="server" id="staf" visible="false">
                <b>
                    <dx:ASPxLabel ID="ASPxLabel11" runat="server" Text="Divisi"
                        Font-Bold="True" ForeColor="#0076c4" Font-Names="Tahoma" Font-Size="10" Font-Italic="True">
                    </dx:ASPxLabel>
                </b>
            </td>
        </tr>
        <tr>
            <td align="center" runat="server" id="isiChnlTrx" visible="false">
                <b></b>
            </td>
            <td align="center" runat="server" id="isiFilterTop" visible="false">
                <b>
                    <dx:ASPxComboBox ID="cbFilterTop" ClientInstanceName="cbFilterTop" runat="server" DropDownWidth="220" Theme="MetropolisBlue"
                        DropDownStyle="DropDownList"
                        ValueType="System.String" TextFormatString="{0}" EnableCallbackMode="true" IncrementalFilteringMode="StartsWith"
                        Width="130px" OnSelectedIndexChanged="cbFilterTop_SelectedIndexChanged" AutoPostBack="true">
                        <Items>
                            <dx:ListEditItem Value="5;Kategori" Text="Top 5 by Jenis Transaksi" />
                            <dx:ListEditItem Value="5;UnitKerja" Text="Top 5 by Brand" />
                            <dx:ListEditItem Selected="True" Value="5;Subjek" Text="Top 5 by Product" />
                            <dx:ListEditItem Value="5;JenisTrx" Text="Top 5 by Problem" />
                            <dx:ListEditItem Value="5;Status" Text="Top 5 by Status" />
                            <dx:ListEditItem Value="5;All" Text="Top 5 by All" />
                            <dx:ListEditItem Value="10;Kategori" Text="Top 10 by Jenis Transaksi" />
                            <dx:ListEditItem Value="10;UnitKerja" Text="Top 10 by Brand" />
                            <dx:ListEditItem Value="10;Subjek" Text="Top 10 by Product" />
                            <dx:ListEditItem Value="10;JenisTrx" Text="Top 10 by Problem" />
                            <dx:ListEditItem Value="10;Status" Text="Top 10 by Status" />
                            <dx:ListEditItem Value="10;All" Text="Top 10 by All" />
                        </Items>
                        <%-- <ClientSideEvents Init="function(s, e) {
                                if (cbFilterTop.GetItem(0).value!=0)
                            {
                                 cbFilterTop.InsertItem(0,'All',0);
                            }
                                 cbFilterTop.SetSelectedIndex(0);
                            }" />--%>
                    </dx:ASPxComboBox></td>
            <td align="center" runat="server" id="isiJnsTrx" visible="false">
                <b>
                    <dx:ASPxComboBox ID="cbJenisTransaksi" ClientInstanceName="cbJenisTransaksi" runat="server" DropDownWidth="130" Theme="MetropolisBlue"
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
                </b>
            </td>
            <td align="center" runat="server" id="isiUnitKerja" visible="false">
                <b>
                    <dx:ASPxComboBox ID="cbUnitKerja" ClientInstanceName="cbUnitKerja" runat="server" DropDownWidth="130" Theme="MetropolisBlue"
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
                </b>
            </td>
            <td align="center" runat="server" id="isiSubject" visible="false">
                <b>
                    <dx:ASPxComboBox ID="cbSubject" ClientInstanceName="cbSubject" runat="server" DropDownWidth="130" Theme="MetropolisBlue"
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
                </b>
            </td>

            <td align="center" runat="server" id="isiStatTrx" visible="false">
                <b>
                    <dx:ASPxComboBox ID="cbStatusTransaksi" ClientInstanceName="cbStatusTransaksi" runat="server" DropDownWidth="130" Theme="MetropolisBlue"
                        DropDownStyle="DropDownList"
                        ValueType="System.String" TextFormatString="{0}" EnableCallbackMode="true" IncrementalFilteringMode="StartsWith"
                        Width="130px">
                        <Items>
                            <dx:ListEditItem Value="Open" Text="Open" />
                            <dx:ListEditItem Value="Closed" Text="Closed" />
                        </Items>
                        <ClientSideEvents Init="function(s, e) {
                                if (cbStatusTransaksi.GetItem(0).value!=0)
                            {
                                 cbStatusTransaksi.InsertItem(0,'All',0);
                            }
                                 cbStatusTransaksi.SetSelectedIndex(0);
                            }" />
                    </dx:ASPxComboBox></td>
            <td align="center" runat="server" id="isiCLosedBy" visible="false">
                <b>
                    <dx:ASPxComboBox ID="cbTransaksiOleh" ClientInstanceName="cbTransaksiOleh" runat="server" DropDownWidth="130" Theme="MetropolisBlue"
                        DropDownStyle="DropDownList"
                        ValueType="System.String" TextFormatString="{0}" EnableCallbackMode="true" IncrementalFilteringMode="StartsWith"
                        Width="130px">
                        <Items>
                            <dx:ListEditItem Value="Agengt" Text="Agent" />
                            <dx:ListEditItem Value="Case Unit" Text="Team Support" />
                            <dx:ListEditItem Value="PIC" Text="Divisi" />
                        </Items>

                        <ClientSideEvents Init="function(s, e) {
                                if (cbTransaksiOleh.GetItem(0).value!=0)
                            {
                                 cbTransaksiOleh.InsertItem(0,'All',0);
                            }
                                 cbTransaksiOleh.SetSelectedIndex(0);
                            }" />
                    </dx:ASPxComboBox></td>
            <td align="center" runat="server" id="isiAgentName" visible="false">
                <b>
                    <dx:ASPxComboBox ID="cbNamaKaryawan" ClientInstanceName="cbNamaKaryawan" runat="server" DropDownWidth="130" Theme="MetropolisBlue"
                        DropDownStyle="DropDownList" DataSourceID="dsNamaKaryawan" ValueField="Name" TextField="Name"
                        ValueType="System.String" TextFormatString="{0}" EnableCallbackMode="true" IncrementalFilteringMode="StartsWith"
                        Width="130px">

                        <Columns>
                            <dx:ListBoxColumn FieldName="Name" Caption="Subject" Width="10px" />
                        </Columns>

                        <ClientSideEvents Init="function(s, e) {
                                if (cbNamaKaryawan.GetItem(0).value!=0)
                            {
                                 cbNamaKaryawan.InsertItem(0,'All',0);
                            }
                                 cbNamaKaryawan.SetSelectedIndex(0);
                            }" />
                    </dx:ASPxComboBox>
                </b>
            </td>
            <td>
                <dx:ASPxComboBox ID="cmb_staf" Visible="false" ClientInstanceName="cmb_staf" runat="server" DropDownWidth="130" Theme="MetropolisBlue"
                    DropDownStyle="DropDownList"
                    ValueType="System.String" TextFormatString="{0}" EnableCallbackMode="true" IncrementalFilteringMode="StartsWith"
                    Width="130px">
                    <Items>
                        <dx:ListEditItem Value="TS" Text="TS" />
                        <dx:ListEditItem Value="Non TS" Text="Non TS" />
                    </Items>

                </dx:ASPxComboBox>
            </td>
        </tr>
    </table>


    <div class="padding-md">
        <div class="row">
            <div class="col-md-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        Report Standard
                    </div>
                    <div class="panel-body">
                        <div id="div_customer" runat="server">
                            <div class="row">
                                <div class="col-md-12">
                                    <dx:ASPxRadioButtonList ID="ASPxRadioButtonList1" runat="server" RepeatLayout="Table">
                                    </dx:ASPxRadioButtonList>
                                </div>
                                <div class="col-md-3">
                                    <label class="control-label">Level User</label>
                                    <dx:ASPxRadioButtonList ID="rbList" AutoPostBack="true" OnSelectedIndexChanged="rbList_SelectedIndexChanged"
                                        runat="server" RepeatLayout="Table" Theme="MetropolisBlue">
                                    </dx:ASPxRadioButtonList>
                                </div>
                                <div class="col-md-3">
                                    <label class="control-label">Start Date</label>
                                    <dx:ASPxDateEdit ID="TxtDateFrom" runat="server" Theme="MetropolisBlue"
                                        EditFormat="Custom" EditFormatString="yyyy-MM-dd" DisplayFormatString="yyyy-MM-dd" AutoPostBack="False">
                                    </dx:ASPxDateEdit>
                                </div>
                                <div class="col-md-3">
                                    <label class="control-label">End Date</label>
                                    <dx:ASPxDateEdit ID="TxtDateTo" runat="server" Theme="MetropolisBlue"
                                        EditFormat="Custom" EditFormatString="yyyy-MM-dd" DisplayFormatString="yyyy-MM-dd" AutoPostBack="False">
                                    </dx:ASPxDateEdit>
                                </div>
                                <div class="col-md-3">
                                    <dx:ASPxButton ID="PreviewButton" runat="server" Text="Preview" Width="70%" ValidationGroup="reportValidation" Theme="MetropolisBlue">
                                    </dx:ASPxButton>
                                </div>
                            </div>

                            <div class="row">
                                <div>
                                    <dx:ASPxComboBox ID="cbChannelTransaksi" ClientInstanceName="cbChannelTransaksi" runat="server" DropDownWidth="130" Theme="MetropolisBlue"
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
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
