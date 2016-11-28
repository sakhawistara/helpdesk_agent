<%@ Page Title="Agent Activity" Language="vb" AutoEventWireup="false" MasterPageFile="~/HTML/Ticket.Master" CodeBehind="log_agent.aspx.vb" Inherits="ICC.log_agent" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView.Export" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li><i class="fa fa-home"></i>&nbsp;<a href="dashboard.aspx">Home</a></li>
            <li class="active">Agent Activity</li>
        </ul>
    </div>
    <div class="padding-md">
        <div class="row">
            <table>
    <tr>
    <td align="left">
    <span class="style1"><strong>Star Date:</strong></span>
    <dx:aspxdateedit ID="StarDate" runat="server" CssClass="form-control input-sm"></dx:aspxdateedit>
    </td>
    <td align="left">  
     &nbsp; &nbsp;
    </td>
    <td align="Left" class="style3">
    <span class="style1"><strong>End Date:</strong></span>
    <dx:aspxdateedit ID="EndDate" runat="server" CssClass="form-control input-sm"></dx:aspxdateedit>
    </td>
        <td align="left">  
     &nbsp; &nbsp;
    </td>
        <td align="left">  
    <asp:Button ID="btnsubmit" runat="server" Text="Show" CssClass="btn btn-info" Height="46px" />
    </td>
    </tr>
    </table>
            
            
            <br />
                            <div style="overflow: auto;">
                    <dx:ASPxGridView ID="GridAddUser" runat="server" KeyFieldName="IdLog" AutoGenerateColumns="False"
                        DataSourceID="dslog" Width="100%" Theme="MetropolisBlue">
            <Columns>
            <dx:GridViewDataTextColumn FieldName="Username" Caption="Name" VisibleIndex="1">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Data" Caption="Message" VisibleIndex="2">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn PropertiesTextEdit-DisplayFormatString="dd-MM-yyyy" FieldName="datetime" Caption="Date" VisibleIndex="3">
            </dx:GridViewDataTextColumn>
           <dx:GridViewDataTextColumn FieldName="Flag" Caption="Ket" VisibleIndex="4">
            </dx:GridViewDataTextColumn>
        </Columns>
         <SettingsPager Position="Bottom">
             <PageSizeItemSettings Items="10" />
          <AllButton Text="All">
          </AllButton>
          <NextPageButton Text="Next &gt;">
          </NextPageButton>
          <PrevPageButton Text="&lt; Prev">
          </PrevPageButton>
          </SettingsPager>
            <SettingsEditing Mode="Inline" />
            <SettingsBehavior EnableRowHotTrack="true" ConfirmDelete="true" AllowFocusedRow="true" />
            <Settings ShowFilterRow="true" ShowFilterRowMenu="false" ShowFilterBar="Hidden" ShowVerticalScrollBar="false" ShowHorizontalScrollBar="false"
            VerticalScrollableHeight="150" ShowGroupPanel="True" />
            <SettingsBehavior ConfirmDelete="true" />
    </dx:ASPxGridView>
          <asp:SqlDataSource ID="dslog" runat="server" ConnectionString="<%$ ConnectionStrings:SosmedConnection %>"></asp:SqlDataSource>
                                <br />
    <table>
    <tr>
    <td>
    <asp:Label ID="Label1" runat="server" Text="Export To:" Font-Bold="True"></asp:Label>
    <dx:ASPxComboBox ID="cbExpLogin" runat="server" CssClass="form-control input-sm">
        <Items>
            <dx:ListEditItem Text="pdf" Value="pdf" />
            <dx:ListEditItem Text="Excel 97-2003" Value="xls" />
            <dx:ListEditItem Text="Excel" Value="xlsx" />
        </Items>
    </dx:ASPxComboBox> 
     </td>
     <td>
     &nbsp; &nbsp;
     </td>
     <td>
      <asp:Button ID="bconvert" runat="server" Text="Convert" CssClass="btn btn-info" Height="46px" />
     <dx:ASPxGridViewExporter ID="GVExpTax" runat="server" GridViewID="GridAddUser">
    </dx:ASPxGridViewExporter>
                                        </td>
                                    </tr>
                                </table>
        
     
                            <%--<table class="table table-striped" id="dataTable">
                                <thead>
                                    <tr>
                                        <th>Action</th>
                                        <th>Name</th>
                                        <th>Message</th>
                                        <th>Date</th>
                                        <th>Ket</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Literal ID="ltr_email" runat="server"></asp:Literal>
                                </tbody>
                            </table>--%>
                        </div>
                        <!-- /panel -->
                    </div>

                </div>
</asp:Content>
