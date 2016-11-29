<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/HTML/Ticket.Master" CodeBehind="inbox_email.aspx.vb" Inherits="ICC.inbox_email" %>

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
            <li title="Email"><i class="fa fa-envelope-o"></i><a href="inbox_email.aspx"> Email</a></li>
            <asp:Literal ID="lit_miniMenuEmail" runat="server"></asp:Literal>
        </ul>
    </div>

    <div class="padding-sm">
        <div class="row" id="Dashboard_email" runat="server">
            <div class="col-md-3">
                <a id="A1" href="?status=open" data-toggle="modal" runat="server">
                <div class="panel panel-default panel-stat2 bg-success">
                    <div class="panel-body">
                        <span class="stat-icon">
                            <i class="fa fa-folder-open-o"></i>
                        </span>
                        <div class="pull-right text-right">
                            <div class="value">
                                <%--<a id="A1" href="?status=open" data-toggle="modal" class="shortcut-link" runat="server">--%>
                                <asp:Label ID="lbl_open" runat="server" ForeColor="White" Text="1"></asp:Label>
                                <%--</a>--%>
                            </div>
                            <div class="title">New Email</div>
                        </div>
                    </div>
                </div>
                </a>
            </div><!-- col-md-3 col-sm-4 New Email-->            
            <div class="col-md-3">
                <a id="A2" href="?status=inbox" data-toggle="modal" runat="server">
                <div class="panel panel-default panel-stat2 bg-info">
                    <div class="panel-body">
                        <span class="stat-icon">
                            <i class="fa fa-archive"></i>
                        </span>
                        <div class="pull-right text-right">
                            <div class="value">                                
                                <asp:Label ID="lbl_inboxEmail" runat="server" ForeColor="White" Text="1"></asp:Label>                                
                            </div>
                            <div class="title">Inbox Email</div>
                        </div>
                    </div>
                </div>
                </a>
            </div><!-- col-md-3 col-sm-4 Inbox Email-->
            <div class="col-md-3">
                <a id="A3" href="?status=send" data-toggle="modal" runat="server">
                <div class="panel panel-default panel-stat2 bg-warning">
                    <div class="panel-body">
                        <span class="stat-icon">
                            <i class="fa fa-send"></i>
                        </span>
                        <div class="pull-right text-right">
                            <div class="value">                                
                                <asp:Label ID="lbl_sendEmail" runat="server" ForeColor="White" Text="1"></asp:Label>                                
                            </div>
                            <div class="title">Send Email</div>
                        </div>
                    </div>
                </div>
                </a>
            </div><!-- col-md-3 col-sm-4 Send Fax-->
        </div><!-- Dashboard Fax-->

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>            
                <div class="row" id="lblError" runat="server" visible="false">
                    <div class="col-sm-12">
                        <div class="alert alert-danger">
                            <button type="button" class="close" data-dismiss="alert" aria-hidden="true" id="B_notError" runat="server">&times;</button>
                            <strong>
                                <asp:Label ID="lbl_Error" runat="server">error Massege</asp:Label>
                            </strong>
                        </div>
                    </div>
                </div><!-- Notified Error-->
                <div class="row" id="lblSuccess" runat="server" visible="false">
                    <div class="col-sm-12">
                        <div class="alert alert-success">
                            <button type="button" class="close" data-dismiss="alert" aria-hidden="true" id="b_notSuccess" runat="server">&times;</button>
                            <strong>
                                <asp:Label ID="lbl_Success" runat="server">Success Massege</asp:Label>
                            </strong>
                        </div>
                    </div>
                </div><!-- Notified Succes-->
            </ContentTemplate>
        </asp:UpdatePanel><!-- Update Panel Notified-->

    </div>
    <div class="row">
        <div class="col-sm-3">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h1 class="panel-title">
                        <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapseThree"><strong>Mail Folder </strong>
                        </a>
                    </h1>
                </div>
                <div id="collapseThree" class="panel-collapse collapse in">
                    <div class="panel-body">
                        <a href="?status=inbox">
                            <i class="fa fa-inbox fa-lg"></i>
                            <span class="m-left-xs">Inbox</span>
                            <%--<span class="badge badge-success pull-right">19</span>--%>
                            <asp:Literal ID="lit_TNew" runat="server"></asp:Literal>
                        </a>
                        <hr />
                        <a href="?status=send">
                            <i class="fa fa-envelope fa-lg"></i>
                            <span class="m-left-xs">Sent Mail</span>
                        </a>
                        <hr />
                        <%--<a href="?status=draft">
                            <i class="fa fa-pencil fa-lg"></i><span class="m-left-xs">Drafts</span>
                        </a>
                        <hr />--%>
                        <asp:Button ID="btn_compose" runat="server" CssClass="btn btn-sm btn-info" Text="Compose" />

                    </div>
                </div>
            </div>
        </div>
        <!-- /.col -->
        <div class="col-sm-9" id="Email_table" runat="server" visible="true">
            <div class="clearfix">
                <table class="table table-striped" id="dataTable">
                    <thead>
                        <tr>
                            <th>#</th>
                            <th>Account Name</th>
                            <th>Subject</th>
                            <th>Date and Time</th>
                        </tr>
                    </thead>
                    <tbody>
                        <%--<tr>
                            <td>
                                <a href="?action=detail&id=1" title="view detail"><img src="img/icon/Apps-text-editor-icon22.png"/></a>
                                <a href="?action=replay&id=1" title="Replay Email"><i class="fa fa-reply fa-lg"></i></a>
                                <a href="?action=ticket&id=1" title="Ticket Email"><i class="fa fa-ticket fa-lg"></i></a>
                            </td>
                            <td>support@invision-ap.com</td>
                            <td>Test Template</td>
                            <td>Feb 20 2016 12:20PM</td>
                        </tr>--%>
                        <asp:Literal ID="lit_dataEmailIN" runat="server"></asp:Literal>
                    </tbody>
                </table>
            </div>
        </div><!-- Data Email IN dan OUT -->
        <div class="col-md-9" id="Email_Compose" runat="server" visible="false">
                <div class="col-md-12 form-group">
                    <asp:TextBox ID="txt_to" runat="server" CssClass="form-control input-sm" placeholder="To"></asp:TextBox>
                </div>
                <div class="col-md-12 form-group">
                    <asp:TextBox ID="txt_cc" runat="server" CssClass="form-control input-sm" placeholder="Cc"></asp:TextBox>
                </div>
                <div class="col-md-12 form-group">
                    <asp:TextBox ID="txt_subject" runat="server" CssClass="form-control input-sm" placeholder="Subject"></asp:TextBox>
                </div>
                <div class="col-md-12 form-group">
                    <dx:ASPxHtmlEditor ID="html_editor_Body" Width="100%" Height="250px" runat="server">
                        <Settings AllowHtmlView="false" AllowPreview="false" />
                    </dx:ASPxHtmlEditor>
                    <asp:FileUpload ID="fu_EmailAttach" runat="server"/>
                    <div class="text-right">
                        <button ID="btn_send" runat="server" type="submit" class="btn btn-info" onclick="confirm('Entar Saja, Diseragamin...?');"><i class="fa fa-send"></i> Send</button>
                        <button ID="btn_cancelCompose" runat="server" Class="btn btn-info" type="submit" onclick="confirm('Entar Saja, Diseragamin...?');"><i class="fa fa-arrow-circle-left"></i> Cancel</button>
                    </div>
                </div>              
            </div>        
        <!-- /.col -->
    </div>
    <!-- /.row -->
</asp:Content>
