<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/HTML/Ticket.Master" CodeBehind="allpostMP.aspx.vb" Inherits="ICC.allpostMP" %>

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
            <li class="active">Post Facebook & Twitter</li>
        </ul>
    </div>
    <br />
    <div class="row">
        <!-- /panel -->
        <div class="col-md-6">
            <div class="panel panel-default">
                <div class="panel-heading">
                		Post Something on your wall facebook		
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <textarea id="txtfacebook" runat="server" class="form-control" rows="6" placeholder="Whats on your mind?"></textarea>
                    </div> 
                    <label class="label-checkbox">
                <asp:CheckBox ID="cbpantau" runat="server" />
                <span class="custom-checkbox"></span>
                Pantau Post
            </label>
                    <div class="form-group">
                        <div class="text-right m-bottom-md">
                            <asp:Button CssClass="btn btn-info"  ID="btnfacebook" runat="server" Text="Submit Post" /> 
                        </div>
                    </div>
                    <!-- /form-group -->
                </div>
            </div>
        </div>
        <!-- /panel -->
        <div class="col-md-6">
            <div class="panel panel-default">
                <div class="panel-heading">
                   Post Something on your timeline twitter		
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <textarea id="txttwittter" runat="server" class="form-control" rows="6" placeholder="What happening?"></textarea>
                    </div>
                    <div class="form-group">
                        <div class="text-right m-bottom-md">
                            <asp:Button CssClass="btn btn-info"  ID="btntwitter" runat="server" Text="Submit Post" /> 
                        </div>
                    </div>
                    <!-- /form-group -->
                </div>
            </div>
        </div>
        <!-- /.col -->
        <div class="col-md-6">
        </div>
        <!-- /.col -->
    </div>
    <!-- /.row -->
</asp:Content>
