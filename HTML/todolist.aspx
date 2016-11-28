<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/HTML/Ticket.Master" CodeBehind="todolist.aspx.vb" Inherits="ICC.todolist" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="div_todolist" runat="server">
        <div id="breadcrumb">
            <ul class="breadcrumb">
                <li><i class="fa fa-home"></i>&nbsp;<a href="dashboard.aspx">Home</a></li>
                <li class="active"><a href="todolist.aspx">Todolist</a></li>
            </ul>
        </div>
        <div class="padding-md">
            <div class="row">
                <div id="div_view" runat="server">
                    <table class="table table-striped" id="dataTable">
                        <thead>
                            <tr>
                                <th style="width: 20px;">No</th>
                                <th style="width: 150px;">Ticket Number</th>
                                <th>Customer Name</th>
                                <th>Description</th>
                                <th>Status</th>
                                <th>Ticket Progress</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Literal ID="ltr_todolist" runat="server"></asp:Literal>
                        </tbody>
                    </table>
                </div>
                <!-- /panel -->
            </div>
            <!-- /.row -->
        </div>
    </div>
</asp:Content>
