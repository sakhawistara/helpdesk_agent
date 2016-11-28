<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/HTML/Ticket.Master" CodeBehind="calltype_two_lama.aspx.vb" Inherits="ICC.calltype_two_lama" %>

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
            <li class="active">Product</li>
        </ul>
    </div>
    <div class="padding-md">
        <div class="row">
            <div id="div_view" runat="server">
                <table class="table table-striped" id="dataTable">
                    <thead>
                        <tr>
                            <%--  <th style="width: 50px;">Action</th>--%>
                            <th style="width: 100px;">ID</th>
                            <th style="width: 250px;">Transaction Type</th>
                            <th style="width: 200px;">Brand</th>
                            <th style="width: 200px;">Product</th>
                            <th style="width: 20px;">Status</th>
                            <th style="width: 30px;">Action</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Literal ID="ltr_brand" runat="server"></asp:Literal>
                    </tbody>
                </table>
            </div>

            <div class="panel panel-default" id="div_edit" runat="server">
                <div class="panel-heading">
                    <asp:Label ID="lbl_header" runat="server"></asp:Label>
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label">Transaction Type</label>
                                <dx:ASPxComboBox ID="cmb_transaction_type" Height="30px" runat="server" Theme="MetropolisBlue"
                                    CssClass="form-control chzn-select" TextField="CategoryID" ValueField="Name" Width="100%">
                                    <Columns>
                                        <dx:ListBoxColumn Caption="ID" FieldName="CategoryID" />
                                        <dx:ListBoxColumn Caption="Name" FieldName="Name" />
                                    </Columns>
                                </dx:ASPxComboBox>
                            </div>
                            <!-- /form-group -->
                        </div>
                         <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label">Brand</label>
                                <dx:ASPxComboBox ID="cmb_brand" Height="30px" runat="server" Theme="MetropolisBlue"
                                    CssClass="form-control chzn-select" TextField="CategoryID" ValueField="Name" Width="100%">
                                    <Columns>
                                        <dx:ListBoxColumn Caption="ID" FieldName="CategoryID" />
                                        <dx:ListBoxColumn Caption="Name" FieldName="Name" />
                                    </Columns>
                                </dx:ASPxComboBox>
                            </div>
                            <!-- /form-group -->
                        </div>
                        <div class="col-md-10">
                            <div class="form-group">
                                <label class="control-label">Product</label>
                                <asp:TextBox ID="txt_Product" runat="server" CssClass="form-control input-sm" placeholder="Product"></asp:TextBox>
                            </div>
                            <!-- /form-group -->
                        </div>
                        <!-- /.col -->
                        <div class="col-md-2">
                            <div class="form-group">
                                <label class="control-label">Status</label>
                                <dx:ASPxComboBox ID="cmb_status" Height="30px" runat="server" Theme="MetropolisBlue"
                                    CssClass="form-control chzn-select">
                                    <Items>
                                        <dx:ListEditItem Text="Active" Value="Active" />
                                        <dx:ListEditItem Text="In Active" Value="In Active" />
                                    </Items>
                                </dx:ASPxComboBox>
                            </div>
                            <!-- /form-group -->
                        </div>
                        <!-- /.col -->
                    </div>
                    <!-- /.row -->
                </div>
                <div class="panel-footer text-right">
                    <asp:Button ID="btn_cancel" runat="server" Text="Cancel" CssClass="btn btn-info" />
                    <asp:Button ID="btn_submit" runat="server" Text="Submit" CssClass="btn btn-info" />
                </div>
            </div>
            <!-- /panel -->
        </div>
        <!-- /.row -->
    </div>
</asp:Content>
