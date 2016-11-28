<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/HTML/Ticket.Master" CodeBehind="inputsentimenMP.aspx.vb" Inherits="ICC.inputsentimenMP" %>

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
            <li class="active">Data Sentiment</li>
        </ul>
    </div>
    <br />
    <div class="row">
        <div class="col-md-4">
            <div class="panel panel-default">
                <div class="panel-heading">
                    Input your Sentimen Data
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <label class="control-label">Sentimen</label>
                        <asp:TextBox ID="txtsentimen" placeholder="Sentimen" CssClass="form-control input-sm" runat="server"></asp:TextBox>
                    </div>
                    <!-- /form-group -->

                    <div class="form-group">
                        <label class="control-label">Description</label>
                        <asp:TextBox ID="txtdesc" placeholder="Description" CssClass="form-control input-sm" runat="server"></asp:TextBox>
                    </div>
                    <!-- /.row -->
                </div>
                <div class="panel-footer text-right">
                       <asp:Button ID="btnsubmitkey" runat="server" CssClass="btn btn-info" Text="Submit" />
                       <asp:Button ID="btnupdatekey" runat="server" CssClass="btn btn-info" Text="Update" PostBackUrl="~/HTML/inputsentimenMP.aspx" />
                </div>
            </div>
            <!-- /panel -->
        </div>
        <!-- /.col-->
        <div class="col-md-8">
            <div class="panel panel-default">
                <div class="panel-heading">
                    Data Sentimen
                </div>
                <div class="panel-body">
                    <table class="table table-bordered table-condensed table-hover table-striped">
                        <thead>
                            <tr>
                              <th style="width: 100px">ID Sentimen</th>
                              <th>Sentimen</th>
                                <th>Description</th>
                              <th style="width: 140px">Action</th>
                            </tr>
                        </thead>
                        <tbody>
                                             <asp:Literal runat="server" ID="show"></asp:Literal>
                                            <%--<tr>
                                         
                                                <td>
                                                    <a href="#" class="task-del" title="Write Email">05</a>
                                                </td>
                                                <td>Voice
                                                </td>
                                                <td>17-05-16
                                                </td>

                                            </tr>--%>
                                        </tbody>
                    </table>
                </div>

            </div>
            <!-- /panel -->
        </div>
        <!-- /.col-->
    </div>
</asp:Content>
