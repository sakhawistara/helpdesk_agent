<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/HTML/Ticket.Master" CodeBehind="dashboard.aspx.vb" Inherits="ICC.dashboard" %>


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
            <li><i class="fa fa-home"></i><a href="default.aspx">Home</a></li>
            <li class="active">Dashboard</li>
        </ul>
    </div>
    <!-- /breadcrumb-->
    <div class="main-header clearfix">
        <div class="page-title">
            <h3 class="no-margin">Dashboard</h3>
            <span>
                <asp:Label ID="lbl_user_dashboard" runat="server"></asp:Label></span>
        </div>
        <!-- /page-title -->

        <ul class="page-stats">
            <%--<li>
                <div class="value">
                    <span>Total</span>
                    <h4 id="H1">4256</h4>
                </div>
                <span id="Span1" class="sparkline"></span>
            </li>--%>
            <li>
                <div class="value">
                    <span>Data Received</span>
                    <h4 id="currentVisitor">1000</h4>
                </div>
                <span id="visits" class="sparkline"></span>
            </li>
            <li>
                <div class="value">
                    <span>Data Handle</span>
                    <h4><strong id="currentBalance">300</strong></h4>
                </div>
                <span id="balances" class="sparkline"></span>
            </li>
        </ul>
        <!-- /page-stats -->
    </div>
    <!-- /main-header -->
    <asp:Panel ID="Panel1" runat="server" ScrollBars="None" BorderWidth="0"
        BorderColor="#336699">
        <asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional" EnableViewState="false">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
            </Triggers>
            <ContentTemplate>
                <asp:Timer ID="Timer1" runat="server" Interval="1000" Enabled="true" EnableViewState="false">
                </asp:Timer>
                <div class="grey-container shortcut-wrapper">
                    <a href="#ModalEmail" data-toggle="modal" class="shortcut-link" id="modal_email" runat="server">
                        <span class="shortcut-icon">
                            <i class="fa fa-envelope-o"></i>
                            <span class="shortcut-alert">
                                <asp:Label ID="lbl_email" runat="server"></asp:Label>
                            </span>
                        </span>
                        <span class="text">Email</span>
                    </a>
                    <a href="#ModalTwitter" class="shortcut-link" data-toggle="modal" id="modal_twitter" runat="server">
                        <span class="shortcut-icon">
                            <i class="fa fa-twitter"></i>
                            <span class="shortcut-alert">12
                            </span>
                        </span>
                        <span class="text">Twitter</span>
                    </a>
                    <a href="#ModalFacebook" class="shortcut-link" data-toggle="modal" id="modal_facebook" runat="server">
                        <span class="shortcut-icon">
                            <i class="fa fa-facebook"></i>
                            <span class="shortcut-alert">3
                            </span>
                        </span>
                        <span class="text">Facebook</span>
                    </a>
                    <a href="#ModalTelegram" class="shortcut-link" data-toggle="modal">
                        <span class="shortcut-icon">
                            <i class="fa fa-folder"></i>
                            <span class="shortcut-alert">8
                            </span>
                        </span>

                        <span class="text">Telegram</span>
                    </a>
                    <a href="#ModalSms" class="shortcut-link" data-toggle="modal" id="modal_sms" runat="server">
                        <span class="shortcut-icon">
                            <i class="fa fa-envelope"></i>
                            <span class="shortcut-alert">15
                            </span>
                        </span>
                        <span class="text">Sms</span>
                    </a>
                    <a href="#ModalFax" class="shortcut-link" data-toggle="modal">
                        <span class="shortcut-icon">
                            <i class="fa fa-fax"></i>
                            <span class="shortcut-alert">7
                            </span>
                        </span>
                        <span class="text">Fax</span>
                    </a>

                    <a href="#ModalChat" class="shortcut-link" data-toggle="modal">
                        <span class="shortcut-icon">
                            <i class="fa fa-comment-o"></i>
                            <span class="shortcut-alert">18
                            </span>
                        </span>

                        <span class="text">Chat</span>
                    </a>
                    <a href="#ModalVoice" role="button" data-toggle="modal" class="shortcut-link">
                        <span class="shortcut-icon">
                            <i class="fa fa-headphones"></i>
                            <span class="shortcut-alert">
                                <asp:Label ID="lbl_voice" runat="server"></asp:Label>
                            </span>
                        </span>
                        <span class="text">Voice</span>
                    </a>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" ScrollBars="None" BorderWidth="0"
        BorderColor="#336699">
        <asp:UpdatePanel runat="server" ID="UpdatePanel2" UpdateMode="Conditional" EnableViewState="false">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
            </Triggers>
            <ContentTemplate>
                <asp:Timer ID="Timer2" runat="server" Interval="1000" Enabled="true" EnableViewState="false">
                </asp:Timer>
                <div class="padding-md">
                    <div class="row">
                        <div class="row">
                            <div class="col-md-3 col-sm-4">
                                <div class="panel panel-default panel-stat2 bg-success">
                                    <div class="panel-body">
                                        <span class="stat-icon">
                                            <i class="fa fa-folder-open-o"></i>
                                        </span>
                                        <div class="pull-right text-right">
                                            <div class="value">
                                                <a href="#ModalTicketOpen" data-toggle="modal" class="shortcut-link" id="modal_ticket_open" runat="server">
                                                    <asp:Label ID="lbl_open" runat="server" ForeColor="White"></asp:Label>
                                                </a>
                                            </div>
                                            <div class="title">Ticket Open</div>
                                        </div>

                                    </div>
                                </div>
                                <!-- /panel -->
                            </div>
                            <!-- /.col -->
                            <div class="col-md-3 col-sm-4">
                                <div class="panel panel-default panel-stat2 bg-warning">
                                    <div class="panel-body">
                                        <span class="stat-icon">
                                            <i class="fa fa-bar-chart-o"></i>
                                        </span>
                                        <div class="pull-right text-right">
                                            <div class="value">
                                                <a href="#ModalTicketClose" data-toggle="modal" class="shortcut-link" id="modal_ticket_close" runat="server">
                                                    <asp:Label ID="lbl_close" runat="server" ForeColor="White"></asp:Label>
                                                </a>
                                            </div>
                                            <div class="title">Ticket Close</div>
                                        </div>
                                    </div>
                                </div>
                                <!-- /panel -->
                            </div>
                            <!-- /.col -->
                            <div class="col-md-3 col-sm-4">
                                <div class="panel panel-default panel-stat2 bg-info">
                                    <div class="panel-body">
                                        <span class="stat-icon">
                                            <i class="fa fa-envelope"></i>
                                        </span>
                                        <div class="pull-right text-right">
                                            <div class="value">
                                                <a href="#ModalTicketPending" data-toggle="modal" class="shortcut-link" id="modal_ticket_pending" runat="server">
                                                    <asp:Label ID="lbl_pending" runat="server" ForeColor="White"></asp:Label>
                                                </a>
                                            </div>
                                            <div class="title">Ticket Pending</div>
                                        </div>
                                    </div>
                                </div>
                                <!-- /panel -->
                            </div>
                            <!-- /.col -->
                            <div class="col-md-3 col-sm-4">
                                <div class="panel panel-default panel-stat2 bg-danger">
                                    <div class="panel-body">
                                        <span class="stat-icon">
                                            <i class="fa fa-shopping-cart"></i>
                                        </span>
                                        <div class="pull-right text-right">
                                            <div class="value">
                                                <a href="#ModalTicketProgress" data-toggle="modal" class="shortcut-link" id="modal_ticket_progress" runat="server">
                                                    <asp:Label ID="lbl_on_progress" runat="server" ForeColor="White"></asp:Label>
                                                </a>
                                            </div>
                                            <div class="title">Ticket On Progress</div>
                                        </div>
                                    </div>
                                </div>
                                <!-- /panel -->
                            </div>
                            <!-- /.col -->
                        </div>
                    </div>

                    <!-- /.row -->
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <div class="row">
            <div class="col-md-12 col-sm-12">
                <%--<div class="panel panel-default panel-stat2 bg-default">
                                    <div class="panel-body">
                                        <a class="btn btn-default quick-btn" id="remove-all"><i class="fa fa-print"></i><span>Remove All</span></a>
                                        <a class="btn btn-primary quick-btn" id="sticky-notification"><i class="fa fa-envelope"></i><span>Note Sticky</span></a>
                                        <a class="btn btn-info quick-btn" id="info-notification"><i class="fa fa-music"></i><span>Note Info</span></a>
                                        <a class="btn btn-success quick-btn" id="success-notification"><i class="fa fa-picture-o"></i><span>Note Succes</span></a>
                                        <a class="btn btn-warning quick-btn" id="warning-notification"><i class="fa fa-envelope"></i><span>Note Warning</span></a>
                                        <a class="btn btn-danger quick-btn" id="danger-notification"><i class="fa fa-print"></i><span>Note Danger</span></a>
                                        <a class="btn btn-info quick-btn" id="facebook-notification"><i class="fa fa-facebook"></i><span>Note Facebook</span></a>
                                        <a class="btn btn-info quick-btn" id="twitter-notification"><i class="fa fa-twitter"></i><span>Note Twitter</span></a>
                                    </div>
                                </div>--%>
                <div class="panel bg-info fadeInDown animation-delay4">
                    <div class="panel-body">
                        <div id="lineChart" style="height: 150px;"></div>
                        <div class="pull-right text-right">
                            <strong class="font-14">Balance $3210</strong><br />
                            <span><i class="fa fa-shopping-cart"></i>Total Sales 867</span>
                            <div class="seperator"></div>
                        </div>
                    </div>
                    <div class="panel-footer">
                        <div class="row">
                            <div class="col-xs-4">
                                Sales in June
									
                                        <strong class="block">$664</strong>
                            </div>
                            <!-- /.col -->
                            <div class="col-xs-4">
                                Sales in July
									
                                        <strong class="block">$731</strong>
                            </div>
                            <!-- /.col -->
                            <div class="col-xs-4">
                                Sales in August
									
                                        <strong class="block">$912</strong>
                            </div>
                            <!-- /.col -->
                        </div>
                        <!-- /.row -->
                    </div>
                </div>
                <!-- /panel -->
            </div>
        <!-- /panel -->
    </div>

    <div class="modal fade" id="ModalVoice">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4>Channel Voice</h4>
                </div>
                <div class="modal-body">
                    <table class="table table-bordered table-condensed table-hover table-striped">
                        <thead>
                            <tr>
                                <th style="width: 50px;">Action</th>
                                <th>From</th>
                                <th style="width: 85px;">Date</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>
                                    <a href="#" class="task-del" title="Write Email"><i class="fa fa-envelope-o fa-lg text-info"></i></a>
                                </td>
                                <td>John@yahoo.com
										</td>
                                <td>10-08-13
										</td>

                            </tr>
                            <tr>
                                <td>
                                    <a href="#" class="task-del" title="Write Email"><i class="fa fa-envelope-o fa-lg text-info"></i></a>
                                </td>
                                <td>John@yahoo.com
										</td>
                                <td>10-08-13
										</td>

                            </tr>
                            <tr>
                                <td>
                                    <a href="#" class="task-del" title="Write Email"><i class="fa fa-envelope-o fa-lg text-info"></i></a>
                                </td>
                                <td>John@yahoo.com
										</td>
                                <td>10-08-13
										</td>

                            </tr>
                            <tr>
                                <td>
                                    <a href="#" class="task-del" title="Write Email"><i class="fa fa-envelope-o fa-lg text-info"></i></a>
                                </td>
                                <td>John@yahoo.com
										</td>
                                <td>10-08-13
										</td>

                            </tr>
                            <tr>
                                <td>
                                    <a href="#" class="task-del" title="Write Email"><i class="fa fa-envelope-o fa-lg text-info"></i></a>
                                </td>
                                <td>John@yahoo.com
										</td>
                                <td>10-08-13
										</td>

                            </tr>
                        </tbody>
                    </table>
                </div>
                <div class="modal-footer">
                    <button class="btn btn-success btn-sm" data-dismiss="modal" aria-hidden="true">Close</button>
                    <%--  <a href="#" class="btn btn-danger btn-sm">Submit</a>--%>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>

    <div class="modal fade" id="ModalEmail">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4>Channel Email</h4>
                </div>
                <div class="modal-body">
                    <table class="table table-bordered table-condensed table-hover table-striped">
                        <thead>
                            <tr>
                                <th style="width: 50px;">Action</th>
                                <th style="width: 130px;">From</th>
                                <th>Subject</th>
                                <th style="width: 120px;">Date</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Literal ID="ltr_email" runat="server"></asp:Literal>
                        </tbody>
                    </table>

                    <div class="panel panel-default" id="div_email_assign" runat="server" style="width:300px;">
                        <div class="panel-heading">
                            <h1 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapsEmail"><strong>Assign To &nbsp;<i class="fa fa-sort-down"></i></strong>
                                </a>
                            </h1>
                        </div>
                        <div id="collapsEmail" class="panel-collapse collapse">
                            <div class="panel-body">
                                <dx:ASPxComboBox ID="cmb_karyawan" Height="30px" runat="server" Theme="MetropolisBlue"
                                    DataSourceID="sql_karyawan" TextField="Name" ValueField="NIK" CssClass="form-control chzn-select">
                                    <Columns>
                                        <dx:ListBoxColumn Caption="NIK" FieldName="NIK" Width="80px" Visible="false" />
                                        <dx:ListBoxColumn Caption="Name" FieldName="Name" Width="150px" />
                                    </Columns>
                                </dx:ASPxComboBox>                              
                                <asp:SqlDataSource ID="sql_karyawan" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
                            </div>
                        </div>
                    </div>

                </div>
                <div class="modal-footer">
                    <button class="btn btn-success btn-sm" data-dismiss="modal" aria-hidden="true">Submit</button>
                    <button class="btn btn-success btn-sm" data-dismiss="modal" aria-hidden="true">Close</button>
                    <%--  <a href="#" class="btn btn-danger btn-sm">Submit</a>--%>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>

    <div class="modal fade" id="ModalTwitter">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4>Channel Twitter</h4>
                </div>
                <div class="modal-body">
                    <table class="table table-bordered table-condensed table-hover table-striped">
                        <thead>
                            <tr>
                                <th style="width: 150px;">Account</th>
                                <th>From</th>
                                <th style="width: 85px;">Date</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Literal ID="ltr_twitter" runat="server"></asp:Literal>
                        </tbody>
                    </table>

                    <div class="panel panel-default" id="div_twitter_assign" runat="server" style="width:300px;">
                        <div class="panel-heading">
                            <h1 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapsTwitter"><strong>Assign To &nbsp;<i class="fa fa-sort-down"></i></strong>
                                </a>
                            </h1>
                        </div>
                        <div id="collapsTwitter" class="panel-collapse collapse">
                            <div class="panel-body">
                                <dx:ASPxComboBox ID="ASPxComboBox1" Height="30px" runat="server" Theme="MetropolisBlue"
                                    DataSourceID="sql_karyawan" TextField="Name" ValueField="NIK" CssClass="form-control chzn-select">
                                    <Columns>
                                        <dx:ListBoxColumn Caption="NIK" FieldName="NIK" Width="80px" Visible="false" />
                                        <dx:ListBoxColumn Caption="Name" FieldName="Name" Width="150px" />
                                    </Columns>
                                </dx:ASPxComboBox>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button class="btn btn-success btn-sm" data-dismiss="modal" aria-hidden="true">Submit</button>
                    <button class="btn btn-success btn-sm" data-dismiss="modal" aria-hidden="true">Close</button>
                    <%--  <a href="#" class="btn btn-danger btn-sm">Submit</a>--%>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>

    <div class="modal fade" id="ModalFacebook">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4>Channel Facebook</h4>
                </div>
                <div class="modal-body">
                    <table class="table table-bordered table-condensed table-hover table-striped">
                        <thead>
                            <tr>
                                <th style="width: 150px;">Account</th>
                                <th>From</th>
                                <th style="width: 85px;">Date</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Literal ID="ltr_facebook" runat="server"></asp:Literal>
                        </tbody>
                    </table>

                    <div class="panel panel-default" id="div_facebook_assign" runat="server" style="width:300px;">
                        <div class="panel-heading">
                            <h1 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapsFacebook"><strong>Assign To &nbsp;<i class="fa fa-sort-down"></i></strong>
                                </a>
                            </h1>
                        </div>
                        <div id="collapsFacebook" class="panel-collapse collapse">
                            <div class="panel-body">
                                <dx:ASPxComboBox ID="ASPxComboBox2" Height="30px" runat="server" Theme="MetropolisBlue"
                                    DataSourceID="sql_karyawan" TextField="Name" ValueField="NIK" CssClass="form-control chzn-select">
                                    <Columns>
                                        <dx:ListBoxColumn Caption="NIK" FieldName="NIK" Width="80px" Visible="false" />
                                        <dx:ListBoxColumn Caption="Name" FieldName="Name" Width="150px" />
                                    </Columns>
                                </dx:ASPxComboBox>
                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button class="btn btn-success btn-sm" data-dismiss="modal" aria-hidden="true">Submit</button>
                    <button class="btn btn-success btn-sm" data-dismiss="modal" aria-hidden="true">Close</button>
                    <%--  <a href="#" class="btn btn-danger btn-sm">Submit</a>--%>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>

    <div class="modal fade" id="ModalSms">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4>Channel SMS</h4>
                </div>
                <div class="modal-body">
                    <table class="table table-bordered table-condensed table-hover table-striped">
                        <thead>
                            <tr>
                                <th style="width: 150px;">Account</th>
                                <th>From</th>
                                <th style="width: 85px;">Date</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Literal ID="ltr_sms" runat="server"></asp:Literal>
                        </tbody>
                    </table>
                </div>
                <div class="modal-footer">
                    <button class="btn btn-success btn-sm" data-dismiss="modal" aria-hidden="true">Close</button>
                    <%--  <a href="#" class="btn btn-danger btn-sm">Submit</a>--%>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>

    <div class="modal fade" id="ModalTicketOpen">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4>Ticket Open</h4>
                </div>
                <div class="modal-body">
                    <table class="table table-bordered table-condensed table-hover table-striped">
                        <thead>
                            <tr>
                                <th style="width: 150px;">Ticket ID</th>
                                <th>NIK</th>
                                <th style="width: 185px;">Detail Complaint</th>
                                <th style="width: 115px;">Date</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Literal ID="ltr_ticket_open" runat="server"></asp:Literal>
                        </tbody>
                    </table>
                </div>
                <div class="modal-footer">
                    <button class="btn btn-success btn-sm" data-dismiss="modal" aria-hidden="true">Close</button>
                    <%--  <a href="#" class="btn btn-danger btn-sm">Submit</a>--%>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>

    <div class="modal fade" id="ModalTicketClose">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4>Ticket Close</h4>
                </div>
                <div class="modal-body">
                    <table class="table table-bordered table-condensed table-hover table-striped">
                        <thead>
                            <tr>
                                <th style="width: 150px;">Ticket ID</th>
                                <th>NIK</th>
                                <th style="width: 185px;">Detail Complaint</th>
                                <th style="width: 115px;">Date</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Literal ID="ltr_ticket_close" runat="server"></asp:Literal>
                        </tbody>
                    </table>
                </div>
                <div class="modal-footer">
                    <button class="btn btn-success btn-sm" data-dismiss="modal" aria-hidden="true">Close</button>
                    <%--  <a href="#" class="btn btn-danger btn-sm">Submit</a>--%>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>

    <div class="modal fade" id="ModalTicketPending">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4>Ticket Pending</h4>
                </div>
                <div class="modal-body">
                    <table class="table table-bordered table-condensed table-hover table-striped">
                        <thead>
                            <tr>
                                <th style="width: 150px;">Ticket ID</th>
                                <th>NIK</th>
                                <th style="width: 185px;">Detail Complaint</th>
                                <th style="width: 115px;">Date</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Literal ID="ltr_ticket_pending" runat="server"></asp:Literal>
                        </tbody>
                    </table>
                </div>
                <div class="modal-footer">
                    <button class="btn btn-success btn-sm" data-dismiss="modal" aria-hidden="true">Close</button>
                    <%--  <a href="#" class="btn btn-danger btn-sm">Submit</a>--%>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>

    <div class="modal fade" id="ModalTicketProgress">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4>Ticket On Progress</h4>
                </div>
                <div class="modal-body">
                    <table class="table table-bordered table-condensed table-hover table-striped">
                        <thead>
                            <tr>
                                <th style="width: 150px;">Ticket ID</th>
                                <th>NIK</th>
                                <th style="width: 185px;">Detail Complaint</th>
                                <th style="width: 115px;">Date</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Literal ID="ltr_ticket_progress" runat="server"></asp:Literal>
                        </tbody>
                    </table>
                </div>
                <div class="modal-footer">
                    <button class="btn btn-success btn-sm" data-dismiss="modal" aria-hidden="true">Close</button>
                    <%--  <a href="#" class="btn btn-danger btn-sm">Submit</a>--%>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
</asp:Content>
