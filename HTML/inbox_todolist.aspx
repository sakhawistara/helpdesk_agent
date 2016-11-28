<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/HTML/Ticket.Master" CodeBehind="inbox_todolist.aspx.vb" Inherits="ICC.inbox_todolist" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <!-- /.col -->
        <div class="col-sm-12">
            <div class="tab-content">
                <div class="panel panel-default table-responsive">
                    <div class="panel-heading">
                          <strong>Todolist</strong>
                        <span class="label label-info pull-right">
                            <asp:Label ID="lbl_jumlah_todolist" runat="server"></asp:Label></span>
                    </div>
                    <div class="padding-md clearfix" runat="server" id="div_table">
                        <table class="table table-striped" id="dataTable">
                            <thead>
                                <tr>
                                    <th style="width: 160px;">Ticket ID</th>
                                    <th style="width: 200px;">NIK</th>
                                    <th>Detail Complaint</th>
                                    <th style="width: 160px;">Date</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Literal ID="ltr_email" runat="server"></asp:Literal>
                            </tbody>
                        </table>
                        <!-- /panel -->
                    </div>
                    <div class="panel-body" id="div_compose" runat="server">
                        <div class="form-group">
                            <label class="sr-only">To</label>
                            <asp:TextBox ID="txt_to" runat="server" CssClass="form-control input-sm" placeholder="To"></asp:TextBox>
                        </div>
                        <!-- /form-group -->
                        <div class="form-group">
                            <label class="sr-only">Cc</label>
                            <input type="password" class="form-control input-sm" placeholder="Cc">
                        </div>
                        <!-- /form-group -->
                        <div class="form-group">
                            <label class="sr-only">Cc</label>
                            <input type="password" class="form-control input-sm" placeholder="Subject">
                        </div>
                        <div class="form-group">
                            <dx:ASPxHtmlEditor ID="ASPxHtmlEditor1" Width="100%" Height="250px" runat="server"></dx:ASPxHtmlEditor>
                        </div>
                        <!-- /checkbox -->
                        <button type="submit" class="btn btn-sm btn-success">Send</button>
                    </div>
                    <!-- /panel -->
                </div>

            </div>
            <!-- /panel -->
        </div>
        <!-- /.col -->
      <%--  <a href="#" class="task-del" title="Replay Email">
                                            <span class="not-starred">
                                                <i class="fa fa-reply fa-lg text-info"></i>
                                            </span>&nbsp;
                                        </a>--%>
    </div>
</asp:Content>
