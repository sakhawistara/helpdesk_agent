<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/HTML/Ticket.Master" CodeBehind="telegram.aspx.vb" Inherits="ICC.telegram" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-sm-3">
            <div class="tab-content">
                <div class="panel panel-default table-responsive">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <i class="fa fa-envelope"></i>&nbsp; Inbox Telegram
                        </div>
                        <div class="panel-body">
                            <table class="table table-striped" id="responsiveTable">
                                <thead>
                                    <tr>
                                        <th style="width: 250px;">Customer</th>
                                        <%--<th style="width: 200px;">From</th>--%>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Literal ID="ltr_email" runat="server"></asp:Literal>
                                </tbody>
                            </table>
                            <!-- /panel -->
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- /.col -->
        <div class="col-sm-9">
            <div class="tab-content">
                <div class="panel panel-default table-responsive">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <i class="fa fa-envelope"></i>&nbsp; Interaction Telegram
										<div class="btn-group pull-right">
                                            <button type="button" class="btn btn-default btn-xs dropdown-toggle" data-toggle="dropdown">
                                                <i class="fa fa-chevron-down"></i>
                                            </button>
                                            <ul class="dropdown-menu slidedown">
                                                <li><a href="#"><i class="fa fa-refresh"></i>Refresh</a></li>
                                                <li><a href="#"><i class="fa fa-check-circle"></i>Available</a></li>
                                                <li><a href="#"><i class="fa fa-times-circle"></i>Busy</a></li>
                                                <li><a href="#"><i class="fa fa-clock-o"></i>Away</a></li>
                                                <li><a href="#"><i class="fa fa-sign-out"></i>Disconnect</a></li>
                                            </ul>
                                        </div>
                        </div>
                        <div class="panel-body">
                            <div id="chatScroll">
                                <ul class="chat">
                                    <li class="left clearfix">
                                        <span class="chat-img pull-left">
                                            <img src="img/nana.jpg" alt="User Avatar">
                                        </span>
                                        <div class="chat-body clearfix">
                                            <div class="header">
                                                <strong class="primary-font">John Doe</strong>
                                                <small class="pull-right text-muted"><i class="fa fa-clock-o"></i>12 mins ago</small>
                                            </div>
                                            <p>
                                                Lorem ipsum dolor sit amet, consectetur adipiscing elit.
                                            </p>
                                        </div>
                                    </li>
                                    <li class="right clearfix">
                                        <span class="chat-img pull-right">
                                            <img src="img/budi.jpg" alt="User Avatar">
                                        </span>
                                        <div class="chat-body clearfix">
                                            <div class="header">
                                                <strong class="primary-font">Jane Doe</strong>
                                                <small class="pull-right text-muted"><i class="fa fa-clock-o"></i>13 mins ago</small>
                                            </div>
                                            <p>
                                                Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur bibendum ornare dolor, quis ullamcorper ligula sodales at. 
                                            </p>
                                        </div>
                                    </li>
                                    <li class="left clearfix">
                                        <span class="chat-img pull-left">
                                            <img src="img/nana.jpg" alt="User Avatar">
                                        </span>
                                        <div class="chat-body clearfix">
                                            <div class="header">
                                                <strong class="primary-font">John Doe</strong>
                                                <small class="pull-right text-muted"><i class="fa fa-clock-o"></i>20 mins ago</small>
                                            </div>
                                            <p>
                                                Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
                                            </p>
                                        </div>
                                    </li>
                                    <li class="right clearfix">
                                        <span class="chat-img pull-right">
                                            <img src="img/budi.jpg" alt="User Avatar">
                                        </span>
                                        <div class="chat-body clearfix">
                                            <div class="header">
                                                <strong class="primary-font">Jane Doe</strong>
                                                <small class="pull-right text-muted"><i class="fa fa-clock-o"></i>25 mins ago</small>
                                            </div>
                                            <p>
                                                Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur bibendum ornare dolor, quis ullamcorper ligula sodales at. 
                                            </p>
                                        </div>
                                    </li>
                                </ul>
                            </div>
                        </div>
                        <div class="panel-footer">
                            <div class="input-group">
                                <input id="btn-input" type="text" class="form-control input-sm" placeholder="type your message here...">
                                <span class="input-group-btn">
                                    <button class="btn btn-info btn-sm" id="btn-chat">Send</button>
                                </span>
                            </div>
                            <!-- /input-group -->
                        </div>
                    </div>
                    <!-- /panel -->
                </div>

            </div>
            <!-- /panel -->
        </div>
        <!-- /.col -->
    </div>
    <%--<table>
        <tr>
            <td>
                <a href="inbox.html">
                    <span class="menu-icon">
                        <i class="fa fa-envelope fa-lg"></i>
                    </span>
                    <span class="text">Inbox
								</span>
                    <span class="badge badge-danger bounceIn animation-delay6">4</span>
                    <span class="menu-hover"></span>
                </a>
            </td>
        </tr>
    </table>--%>
    <table class="table table-striped" id="Table1">
        <thead>
            <tr>
                <th style="width: 250px;">Customer</th>
                <th style="width: 50px;">Chat</th>
                <%--<th style="width: 200px;">From</th>--%>
            </tr>
        </thead>
        <tbody>
            <tr>
            <td>
                <a href="inbox.html">
                    <span class="menu-icon">
                        <i class="fa fa-envelope fa-lg"></i>
                    </span>
                    <span class="text">Inbox
								</span>
                    <span class="badge badge-danger bounceIn animation-delay6">4</span>
                    <span class="menu-hover"></span>
                </a>
            </td>
        </tr>
        </tbody>
    </table>
</asp:Content>
