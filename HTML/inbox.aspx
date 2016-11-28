<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/HTML/Ticket.Master" CodeBehind="inbox.aspx.vb" Inherits="ICC.inbox" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="div_all" runat="server">
        <div id="breadcrumb">
            <ul class="breadcrumb">
                <li><i class="fa fa-home"></i>&nbsp;<a href="dashboard.aspx">Home</a></li>
                <li class="active"><a href="inbox.aspx">Todolist</a></li>
            </ul>
        </div>
        <div class="padding-md">
            <div class="row">
                <div id="idv_ticket" runat="server">
                    <a href="inbox.aspx?status=Open" data-toggle="modal" id="modal_ticket_open" runat="server">
                        <div class="col-md-3 col-sm-4">
                            <div class="panel panel-default panel-stat2 bg-success">
                                <div class="panel-body">
                                    <span class="stat-icon">
                                        <i class="fa fa-folder-open-o"></i>
                                    </span>
                                    <div class="pull-right text-right">
                                        <div class="value">
                                            <asp:Label ID="lbl_open" runat="server" ForeColor="White"></asp:Label>
                                        </div>
                                        <div class="title">
                                            <asp:Label ID="Label1" runat="server" ForeColor="White" Text="Ticket Open"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!-- /panel -->
                        </div>
                    </a>
                    <div class="col-md-3 col-sm-4">
                        <a href="inbox.aspx?status=pending" data-toggle="modal" id="modal_ticket_pending" runat="server">
                            <div class="panel panel-default panel-stat2 bg-info">
                                <div class="panel-body">
                                    <span class="stat-icon">
                                        <i class="fa fa-envelope"></i>
                                    </span>
                                    <div class="pull-right text-right">
                                        <div class="value">
                                            <asp:Label ID="lbl_pending" runat="server" ForeColor="White"></asp:Label>
                                        </div>
                                        <div class="title">
                                            <asp:Label ID="Label2" runat="server" ForeColor="White" Text="Ticket Pending"></asp:Label>
                                        </div>
                                    </div>
                                </div>

                            </div>
                            <!-- /panel -->
                        </a>
                    </div>

                    <div class="col-md-3 col-sm-4">
                        <a href="inbox.aspx?status=progress" data-toggle="modal" id="modal_ticket_progress" runat="server">
                            <div class="panel panel-default panel-stat2 bg-warning">
                                <div class="panel-body">
                                    <span class="stat-icon">
                                        <i class="fa fa-shopping-cart"></i>
                                    </span>
                                    <div class="pull-right text-right">
                                        <div class="value">
                                            <asp:Label ID="lbl_on_progress" runat="server" ForeColor="White"></asp:Label>
                                        </div>
                                        <div class="title">
                                            <asp:Label ID="Label3" runat="server" ForeColor="White" Text="Ticket Progress"></asp:Label>
                                        </div>
                                    </div>

                                </div>
                            </div>
                            <!-- /panel -->
                        </a>
                    </div>
                    <div class="col-md-3 col-sm-4">
                        <div class="panel panel-default panel-stat2 bg-danger">
                            <div class="panel-body">
                                <span class="stat-icon">
                                    <i class="fa fa-bar-chart-o"></i>
                                </span>
                                <div class="pull-right text-right">
                                    <div class="value">
                                        <a href="inbox.aspx?status=close" data-toggle="modal" class="shortcut-link" id="modal_ticket_close" runat="server">
                                            <asp:Label ID="lbl_close" runat="server" ForeColor="White"></asp:Label>
                                        </a>
                                    </div>
                                    <div class="title">Ticket Close</div>
                                </div>
                            </div>
                        </div>
                        <!-- /panel -->
                    </div>
                </div>
                <div id="div_inbox" runat="server">
                    <table class="table table-striped" id="tbl_todolist">
                        <thead>
                            <tr>
                                <th class="text-center">Action</th>
                                <th>Name</th>
                                <th>Message</th>
                                <th>Date</th>
                                <th>Ket</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Literal ID="ltr_inbox" runat="server"></asp:Literal>
                        </tbody>
                    </table>
                </div>
                <div id="div_todolist" runat="server">
                    <table class="table table-striped" id="tbl_inbox">
                        <thead>
                            <tr>
                                <th style="width: 20px;">No</th>
                                <th style="width: 150px;">Ticket Number</th>
                                <th style="width:200px;">Customer Name</th>
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
