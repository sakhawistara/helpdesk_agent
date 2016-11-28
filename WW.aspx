<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/HTML/Ticket.Master" CodeBehind="WW.aspx.vb" Inherits="ICC.WW" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <dx:ASPxComboBox ID="ASPxComboBox1" runat="server" ValueType="System.String"></dx:ASPxComboBox>
    <dx:ASPxHtmlEditor ID="ASPxHtmlEditor1" runat="server"></dx:ASPxHtmlEditor>
    <dx:ASPxCallbackPanel ID="ASPxCallbackPanel1" runat="server" Width="200px"></dx:ASPxCallbackPanel>
    <dx:ASPxPanel ID="ASPxPanel1" runat="server" Width="200px"></dx:ASPxPanel>
    <dx:ASPxGridView ID="ASPxGridView1" runat="server"></dx:ASPxGridView>
    <dx:ASPxTextBox ID="ASPxTextBox1" runat="server" Width="170px"></dx:ASPxTextBox>
</asp:Content>
