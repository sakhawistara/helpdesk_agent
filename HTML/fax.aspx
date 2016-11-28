<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/HTML/Ticket.Master" CodeBehind="fax.aspx.vb" Inherits="ICC.fax" %>


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
            <li><i class="fa fa-home"></i>&nbsp;<a href="dashboard.aspx" title="Home">Home</a></li>
            <li title="Fax"><i class="fa fa-fax"></i><a href="fax.aspx"> Fax</a></li>
            <%--<li title="Fax Inbox"><i class="fa fa-inbox"></i><a href="fax_inbox.aspx"> Inbox</a></li>
            <%--<li title="Fax detail"><i class="fa fa-server"></i> Fax detail</li>--%>
            <asp:Literal ID="lit_miniMenuFax" runat="server"></asp:Literal>
        </ul>
    </div>
    
    <div class="padding-sm">        
        <div class="row">            
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
                            <div class="title">New Fax</div>
                        </div>
                    </div>
                </div>
                </a>
            </div><!-- col-md-3 col-sm-4 New Fax-->            
            <div class="col-md-3">
                <a id="A2" href="?status=all" data-toggle="modal" runat="server">
                <div class="panel panel-default panel-stat2 bg-info">
                    <div class="panel-body">
                        <span class="stat-icon">
                            <i class="fa fa-archive"></i>
                        </span>
                        <div class="pull-right text-right">
                            <div class="value">                                
                                <asp:Label ID="lbl_inboxFax" runat="server" ForeColor="White" Text="1"></asp:Label>                                
                            </div>
                            <div class="title">Inbox Fax</div>
                        </div>
                    </div>
                </div>
                </a>
            </div><!-- col-md-3 col-sm-4 Inbox Fax-->
            <div class="col-md-3">
                <a id="A3" href="?status=send" data-toggle="modal" runat="server">
                <div class="panel panel-default panel-stat2 bg-warning">
                    <div class="panel-body">
                        <span class="stat-icon">
                            <i class="fa fa-send"></i>
                        </span>
                        <div class="pull-right text-right">
                            <div class="value">                                
                                <asp:Label ID="lbl_sendFax" runat="server" ForeColor="White" Text="1"></asp:Label>                                
                            </div>
                            <div class="title">Send Fax</div>
                        </div>
                    </div>
                </div>
                </a>
            </div><!-- col-md-3 col-sm-4 Send Fax-->
        </div><!-- Dashboard Fax-->
        <div class="row" id="lblError" runat="server" visible="false"> 
            <div class="col-sm-12">
                <div class="alert alert-danger">
                    <button type="button" class="close" data-dismiss="alert" aria-hidden="true" id="B_notError" runat="server">&times;</button>
                    <strong>
                        <asp:Label ID="lbl_Error" runat="server">error Massege</asp:Label>
                    </strong>
                </div>
            </div>
        </div><!-- Notifed Error-->
        <div class="row" id="lblSuccess" runat="server" visible="false"> 
            <div class="col-sm-12">
                <div class="alert alert-success">
                    <button type="button" class="close" data-dismiss="alert" aria-hidden="true" id="b_notSuccess" runat="server">&times;</button>
                    <strong>
                        <asp:Label ID="lbl_Success" runat="server">Success Massege</asp:Label>
                    </strong>
                </div>
            </div>
        </div><!-- Notifed Success-->
        <div class="row" id="fax_TableSend" runat="server">
            <div class="col-md-3">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h1 class="panel-title">
                            <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapseOne"><strong>Fax Folder</strong></a>
                        </h1>
                    </div>
                    <div id="collapseOne" class="panel-collapse collapse in">
                        <div class="panel-body">
                            <a href="?status=all">
                                <i class="fa fa-inbox fa-lg"></i>
                                <span class="m-left-xs">Inbox</span>
                                <%--<span class="badge badge-success pull-right" id="span_Tnew" runat="server">2</span>--%>
                                <asp:Literal ID="lit_Tnew" runat="server"></asp:Literal>
                            </a>
                            <hr />
                            <a href="?status=send">
                                <i class="fa fa-send fa-lg"></i>
                                <span class="m-left-xs">Send</span>
                            </a>
                            <hr />
                            <asp:Button ID="btn_compose" runat="server" CssClass="btn btn-sm btn-info" Text="Compose" />
                        </div>
                    </div>
                </div>
            </div><!-- Menu collapse-->
            <div class="col-md-9" id="Fax_table" runat="server" visible="false">
                <div class="clearfix">
                    <table class="table table-striped" id="dataTable">
                        <thead>
                            <tr>
                                <th>#</th>
                                <th>File Name</th>
                                <th>From</th>
                                <th>For</th>
                                <th>Date and Time</th>
                                <th>User Read</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Literal ID="lit_dataFaxInbox" runat="server"></asp:Literal>
                            <%--<tr>
                                <td>
                                    <%--<a href="?action=detail&id=24" title="view detail"><img src="img/icon/Apps-text-editor-icon22.png"/></a>
                                    <a href="#ButtonConfirm" title="view detail" class="main-link ButtonConfirm_open"><img src="img/icon/Apps-text-editor-icon22.png"/></a>
                                </td>
                                <td>
                                    File Name
                                </td>
                                <td>#1001</td>
                                <td>#1001</td>
                                <td>Leather Bag</td>
                                <td>$89</td>                               
                            </tr>--%>
                        </tbody>
                    </table>
                </div>

            </div><!-- Table Inbox-->            
            <div class="col-md-9" id="Fax_send" runat="server" visible="false">
                <div class="clearfix">
                    <table class="table table-striped" id="dataTable">
                        <thead>
                            <tr>
                                <th>Re-send</th>
                                <th>User ID</th>
                                <th>Dial Number</th>
                                <th>Filename</th>
                                <th>Date and Time</th>
                                <th>Status</th>
                                <th>Reason</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Literal ID="lit_dataFaxSend" runat="server"></asp:Literal>                            
                            <%--<tr>
                                <td>
                                    <a href="?action=resend&id=64"><img src="img/Fax-Send.png" height="20px"/></a>
                                </td>
                                <td>#1001</td>
                                <td>#1001</td>
                                <td>Leather Bag</td>
                                <td>$89</td>                               
                            </tr>--%>
                        </tbody>
                    </table>
                </div>
            </div><!-- Fax send-->
            <div class="col-md-9" id="Fax_Compose" runat="server" visible="false">
                <div class="col-md-12 form-group">
                    <asp:TextBox ID="txt_to" runat="server" CssClass="form-control input-sm" placeholder="To"></asp:TextBox>
                </div>
                <div class="col-md-12 form-group">
                    <asp:TextBox ID="txt_cc" runat="server" CssClass="form-control input-sm" placeholder="Cc" Enabled="false"></asp:TextBox>
                </div>
                <div class="col-md-12 form-group">
                    <asp:TextBox ID="txt_subject" runat="server" CssClass="form-control input-sm" placeholder="Subject"></asp:TextBox>
                </div>
                <div class="col-md-12 form-group">
                    <dx:ASPxHtmlEditor ID="html_editor_Body" Width="100%" Height="250px" runat="server" Enabled="false">
                        <Settings AllowHtmlView="false" AllowPreview="false" />
                    </dx:ASPxHtmlEditor>
                    <asp:FileUpload ID="fu_FaxSend" runat="server"/>
                    <div class="text-right">
                        <button ID="btn_send" runat="server" type="submit" class="btn btn-info"><i class="fa fa-send"></i> Send</button>
                        <button ID="btn_cancelCompose" runat="server" Class="btn btn-info" type="submit"><i class="fa fa-arrow-circle-left"></i> Cancel</button>
                    </div>
                </div>              
            </div>
        </div>       
        <div class="row" id="fax_detail" runat="server" visible="false">
            <div class="col-md-3">
                <div class="panel-group" id="accordion">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapseOne">Customer Contact</a>
                            </h4>
                            <div id="Div1" class="panel-collapse collapse in">
                                <div class="panel-body">
                                    <address>
                                        <strong>
                                            <a href="customer.aspx?id=<%= Request.QueryString("NIK")%>">
                                                <asp:Label ID="lbl_nama_customer" runat="server"></asp:Label>
                                            </a></strong>
                                        <br />
                                        <asp:Label ID="lbl_alamat_perusahaan" runat="server"></asp:Label><br />
                                        <br />
                                        <div class="seperator"></div>
                                        <strong><span class="theme-font"><asp:Label ID="lbl_phone" runat="server"></asp:Label></span></strong><br />
                                        <strong><span class="theme-font"><asp:Label ID="lbl_email" runat="server"></asp:Label></span></strong>
                                    </address>
                                    <hr />
                                    <h6>Get Social</h6>
                                    <a href="inbox_facebook.aspx?account=<%= Request.QueryString("account")%>" class="social-connect tooltip-test facebook-hover pull-left m-right-xs" data-toggle="tooltip" data-original-title="Facebook"><i class="fa fa-facebook"></i></a>
                                    <a href="inbox_twitter.aspx?account=<%= Request.QueryString("account")%>" class="social-connect tooltip-test twitter-hover pull-left m-right-xs" data-toggle="tooltip" data-original-title="Twitter"><i class="fa fa-twitter"></i></a>
                                    <a href="#" class="social-connect tooltip-test google-plus-hover pull-left" data-toggle="tooltip" data-original-title="Google Plus"><i class="fa fa-google-plus"></i></a>
                                    <a href="#" class="social-connect tooltip-test google-plus-hover pull-left" data-toggle="tooltip" data-original-title="Instagram"><i class="fa fa-instagram"></i></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <span class="pull-right"><a href="#ModalEmail" title="Edit Contact" class="social-connect tooltip-test google-plus-hover pull-left" data-toggle="modal" data-original-title="Instagram"><i class="fa fa-edit"></i></a></span>
                                </div>
                            </div>
                        </div>
                    </div><!-- Customer Contact -->
                    <div class="panel panel-default" runat="server" id="div_properties">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapseTwo">Ticket Properties</a>
                            </h4>
                        </div>
                        <div id="collapseTwo" class="panel-collapse collapse">
                            <div class="panel-body">
                                    
                            </div>
                        </div>
                    </div><!-- Ticket Properties -->
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapseThree">History Ticket
										</a>
                            </h4>
                        </div>
                        <div id="collapseThree" class="panel-collapse collapse">
                            <div class="panel-body">
                                <table class="table table-bordered table-condensed table-hover table-striped">
                                    <thead>
                                        <tr>
                                            <th>ID</th>
                                            <th>Ticket ID </th>
                                            <th style="width: 85px;">Date</th>
                                        </tr>
                                    </thead>
                                    <asp:Literal ID="ltr_history_ticket" runat="server"></asp:Literal>
                                </table>
                            </div>
                        </div>
                    </div><!-- Tiket History -->
                </div>
            </div><!-- Fax menu detail-->
            <div class="col-md-9">
                <div class="panel panel-default">    
                    <div class="panel-heading clearfix">
                        <span class="pull-left">Description Message</span>
                    </div> 
                    <div class="panel-body">            
                        <div class="media">
                            <a class="pull-left" href="#">
                                <img src="img/user.jpg" alt="Author" class="img-rounded" style="height: 50px; width: 50px;">
                            </a>
                            <div class="media-heading">
                                <strong>
                                    <asp:Label ID="lbl_pic_customer" runat="server">No Fax</asp:Label></strong>
                                <span class="label pull-right"><asp:Label ID="lbl_date" runat="server">Date and Time</asp:Label></span><br>                                    
                                <asp:Label ID="lbl_customer" runat="server">Nama File Fax</asp:Label>
                                
                                <button class="btn btn-xs btn-success" type="button" title="Download" id="DownloadFax" runat="server"><i class="fa fa-download" title="Download"></i> Download</button>
                            </div>                                
                        </div>
                    </div>
                </div><!-- Description Message -->
                <div class="panel panel-default">
                    <div class="panel-heading clearfix">
                        <span class="pull-left">Customer Interaction</span>
                        <ul class="tool-bar">                           
                            <li><a href="#collapseWidget" data-toggle="collapse"><i class="fa fa-arrows-v"></i></a></li>
                        </ul>
                    </div>
                    <div class="panel-body no-padding collapse " id="collapseWidget">
                        <div class="padding-md">
                            <div class="panel-body">
                                <div id="chatScroll">
                                    <ul class="chat">
                                        <li class="left clearfix">
                                            <span class="chat-img pull-left">
                                                <img src="img/user.jpg" alt="User Avatar">
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
                                                <img src="img/user2.jpg" alt="User Avatar">
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
                                                <img src="img/user.jpg" alt="User Avatar">
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
                                                <img src="img/user2.jpg" alt="User Avatar">
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
                        </div>
                    </div>
                    <div class="loading-overlay">
                        <i class="loading-icon fa fa-refresh fa-spin fa-lg"></i>
                    </div>
                </div><!-- Customer Interaction -->
                <div class="panel panel-default">    
                    <div class="panel-heading clearfix">
                        <div class="row">
                            <div class="col-md-1">
                                <span class="pull-left">Solution</span></div>
                            <div class="col-md-11">
                                <dx:aspxhtmleditor id="html_solution" width="100%" height="250px" runat="server" Settings-AllowHtmlView="false">
                                </dx:aspxhtmleditor>
                                <div class="seperator"></div>
                                <asp:FileUpload ID="ASPxUploadControl1" Width="100%" runat="server" />
                                <div class="seperator"></div>
                                <div class="text-right">
                                    <button ID="Btn_Simpan" runat="server" Class="btn btn-info" type="submit"><i class="fa fa-save"></i> Save</button>
                                    <button ID="Btn_Update" runat="server" Class="btn btn-info" type="submit"><i class="fa fa-retweet"></i> Update</button>
                                    <button ID="Btn_Assign" runat="server" Class="btn btn-info" type="submit"><i class="fa fa-smile-o"></i> Assign</button>
                                    <button ID="Btn_Delete" runat="server" Class="btn btn-info" type="submit"><i class="fa fa-trash"></i> Delete</button>
                                    <button ID="Btn_Cancel" runat="server" Class="btn btn-info" type="submit"><i class="fa fa-arrow-circle-left"></i> Cancel</button>
                                    <%--<asp:Button ID="Btn_Update" runat="server" Text="Update" CssClass="btn btn-success" />
                                    <asp:Button ID="Btn_Assign" runat="server" Text="Assign" CssClass="btn btn-success" />--%>
                                </div>                                
                            </div>
                        </div>
                    </div> 

                </div><!-- Solution -->
            </div><!-- Fax interaction-->
        </div>
    </div>
    
</asp:Content>
