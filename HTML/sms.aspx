<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/HTML/Ticket.Master" CodeBehind="sms.aspx.vb" Inherits="ICC.sms" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
    <style>
         span.re {
                 background: #ffb7b7 none repeat scroll 0 0;
                 padding: 5px;
             }
             span.bl {
                 background: #a8d1ff none repeat scroll 0 0;
                 padding: 5px;
             }
             span.ye {
                 background: #fff2a8 none repeat scroll 0 0;
                 padding: 5px;
             }

     </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li><i class="fa fa-home"></i>&nbsp;<a href="dashboard_sosmed.aspx">Home</a></li>
            <li class="active">Channel</li>
            <li class="active">SMS</li>
        </ul>
    </div>
    <div class="row">
        <div class="col-sm-3">
            <div class="tab-content">
                <div class="panel panel-default table-responsive">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <i class="fa fa-envelope"></i>&nbsp; Inbox SMS
                            <div class="btn-group pull-right">
                                            <button type="button" class="btn btn-default btn-xs dropdown-toggle" data-toggle="dropdown">
                                                <i class="fa fa-chevron-down"></i>
                                            </button>
                                            <ul class="dropdown-menu slidedown">
                                                <li><a href="#"><i class="fa fa-refresh"></i> Refresh</a></li>
                                                <li><a href="#"><i class="fa fa-check-circle"></i> Available</a></li>
                                                <li><a href="#"><i class="fa fa-times-circle"></i> Busy</a></li>
                                                <li><a href="#"><i class="fa fa-clock-o"></i> Away</a></li>
                                                <li><a href="#"><i class="fa fa-sign-out"></i> Disconnect</a></li>
                                            </ul>
                                        </div>
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
                            <i class="fa fa-comment"></i>&nbsp; Conversation
                            <div class="btn-group pull-right">
                                            <button type="button" class="btn btn-default btn-xs dropdown-toggle" data-toggle="dropdown">
                                                <i class="fa fa-chevron-down"></i>
                                            </button>
                                            <ul class="dropdown-menu slidedown">
                                                <li><a href="#"><i class="fa fa-refresh"></i> Refresh</a></li>
                                                <li><a href="#"><i class="fa fa-check-circle"></i> Available</a></li>
                                                <li><a href="#"><i class="fa fa-times-circle"></i> Busy</a></li>
                                                <li><a href="#"><i class="fa fa-clock-o"></i> Away</a></li>
                                                <li><a href="#"><i class="fa fa-sign-out"></i> Disconnect</a></li>
                                            </ul>
                                        </div>
                        </div>
                        <div class="panel-body">
                            <div id="chatScroll">
                                <ul class="chat">
                                    <asp:Literal ID="ltr_detil" runat="server"></asp:Literal>
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
</asp:Content>
