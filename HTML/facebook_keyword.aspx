<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/HTML/Ticket.Master" CodeBehind="facebook_keyword.aspx.vb" Inherits="ICC.facebook_keyword" %>


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
            <li class="active">Facebook Keyword Setting</li>
        </ul>
    </div>
    <br />
    <div class="panel panel-default">
        <div class="panel-tab">
            <ul class="wizard-steps wizard-demo" id="wizardDemo1">
                <li class="active">
                    <a href="#wizardContent1" data-toggle="tab">Universal Keyword</a>
                </li>
                <li>
                    <a href="#wizardContent2" data-toggle="tab">Spesifikasi Keyword</a>
                </li>
            </ul>
        </div>

        <div class="panel-body">
            <div class="tab-content">
                <div class="tab-pane fade in active" id="wizardContent1">
                    <div class="row">
                        <div class="col-md-4">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    Input Universal Keyword / Category
                                </div>
                                <div class="panel-body">
                                    <div class="form-group">
                                        <label class="control-label">Universal Keyword / Category</label>
                                        <asp:TextBox ID="txtsentimen" CssClass="form-control input-sm" runat="server"></asp:TextBox>
                                    </div>
                                    <!-- /form-group -->
                                </div>
                                <div class="panel-footer text-right">
                                    <asp:Button ID="btnsubmitkey" runat="server" CssClass="btn btn-info" Text="Submit" />
                                    <asp:Button ID="btnupdatekey" runat="server" CssClass="btn btn-info" Text="Update" />
                                </div>
                            </div>
                            <!-- /panel -->
                        </div>
                        <!-- /.col-->
                        <div class="col-md-8">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    Universal Keyword / Category
                                </div>
                                <div class="panel-body">
                                    <table class="table table-bordered table-condensed table-hover table-striped">
                                        <thead>
                                            <tr>
                                               <th style="width: 35px">#</th>
                                               <th>Keyword</th>
                                                <th>Sub-Keyword</th>
                                             <th style="width:120px">Action</th>
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
                </div>
                <div class="tab-pane fade" id="wizardContent2">
                    <div class="row">
                        <div class="col-md-4">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    Input Your Spesific Keyword / Sub-Category
                                </div>
                                <div class="panel-body">
                                    <div class="form-group">
                                        <label class="control-label">Select Category before submit your Specific Keyword</label>
                <asp:DropDownList ID="DD1" CssClass="form-control" runat="server" DataSourceID="DsDropdown" DataTextField="Text_Keywords" DataValueField="id"></asp:DropDownList>
                  <asp:SqlDataSource ID="DsDropdown" runat="server" ConnectionString="<%$ ConnectionStrings:SosmedConnection %>" SelectCommand="select id, Text_Keywords from mKeyword where FlagSource='fb'"></asp:SqlDataSource>
                                       
                                    </div>
                                    <!-- /form-group -->

                                    <div class="form-group">
                                        <label class="control-label">Spesific Keyword/Sub-Category</label>
                                        <asp:TextBox ID="txtsub" runat="server" placeholder="Spesific Keyword" CssClass="form-control input-sm"></asp:TextBox>
                                    </div>
                                    <!-- /.row -->
                                </div>
                                <div class="panel-footer text-right">
                                    <asp:Button ID="btnsubmitsub" runat="server" CssClass="btn btn-info" Text="Submit" />
                                    <asp:Button ID="btnupdatesub" runat="server" CssClass="btn btn-info" Text="Update" />
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
                                               <th style="width: 35px">#</th>
                                                  <th>Keyword</th>
                                                <th>Sub-Keyword</th>
                                             <th style="width: 120px">Action</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Literal runat="server" ID="bukadeh"></asp:Literal>
                                          <%--  <tr>
                                                <td>
                                                    <a href="#" class="task-del" title="Write Email">01</a>
                                                </td>
                                                <td>Twitter
                                                </td>
                                                <td>10-08-16
                                                </td>

                                            </tr>
                                            <tr>
                                                <td>
                                                    <a href="#" class="task-del" title="Write Email">02</a>
                                                </td>
                                                <td>Twitter
                                                </td>
                                                <td>10-07-16
                                                </td>

                                            </tr>
                                            <tr>
                                                <td>
                                                    <a href="#" class="task-del" title="Write Email">03</a>
                                                </td>
                                                <td>Facebook
                                                </td>
                                                <td>03-07-16
                                                </td>

                                            </tr>
                                            <tr>
                                                <td>
                                                    <a href="#" class="task-del" title="Write Email">04</a>
                                                </td>
                                                <td>Email
                                                </td>
                                                <td>09-06-16
                                                </td>

                                            </tr>
                                            <tr>
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
                </div>
            </div>
            <%-- <div class="panel-footer clearfix">
                <div class="pull-left">
                    <button class="btn btn-success btn-sm disabled" id="prevStep1" disabled>Previous</button>
                    <button type="submit" class="btn btn-sm btn-success" id="nextStep1">Next</button>
                </div>

                <div class="pull-right" style="width: 30%">
                    <div class="progress progress-striped active m-top-sm m-bottom-none">
                        <div class="progress-bar progress-bar-success" id="wizardProgress" style="width: 33%;">
                        </div>
                    </div>
                </div>
            </div>--%>
        </div>
    </div>
    <!-- /panel -->
</asp:Content>
