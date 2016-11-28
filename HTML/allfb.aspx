<%@ Page Title="Data Facebook" Language="vb" AutoEventWireup="false" MasterPageFile="~/HTML/Ticket.Master" CodeBehind="allfb.aspx.vb" Inherits="ICC.allfb" %>

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
            <li><i class="fa fa-home"></i>&nbsp;<a href="dashboard.aspx">Home</a></li>
            <li class="active">Data Facebook</li>
        </ul>
    </div>
    <div class="padding-md">
        <div class="row">
            <div class="col-sm-6">
                <div class="panel panel-default">
                    <div class="panel-body">
                        <div class="panel-heading">
                            Data Masuk
                        </div>
                        <br />
                        <div class="table-responsive">
                            <table class="table table-striped" id="dataTable">
                                <thead>
                                    <tr>
                                        <th style="width: 50px;">Action</th>
                                        <th style="width: 100px;">Source</th>
                                        <th style="width: 100px;">From</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Literal ID="ltr_email" runat="server"></asp:Literal>
                                </tbody>
                            </table>
                        </div>

                        <!-- /panel -->

                    </div>
                </div>
            </div>
            <!-- /.col -->
            <div class="col-sm-6">
                <div class="tab-content">
                    <div class="panel panel-default table-responsive">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <i class="fa fa-comment"></i>&nbsp; History Conversation
                            </div>
                            <div class="panel-body">
                                <div id="chatScroll">
                                    <ul class="chat">
                                        <asp:Literal ID="ltr_detil" runat="server"></asp:Literal>
                                        <%--<li class='left clearfix'>
                                        <span class='chat-img pull-left'>
                                            <img src='img/user.jpg' alt=User Avatar'>
                                        </span>
                                        <div class='chat-body clearfix'>
                                            <div class='header'>
                                                <strong class='primary-font'>John Doe</strong>
                                                <small class='pull-right text-muted'><i class='fa fa-clock-o'></i>12 mins ago</small>
                                            </div>
                                            <p> Lorem ipsum dolor sit amet, consectetur adipiscing elit. </p>
                                        </div>
                                    </li>
                                    <li class='right clearfix'>
                                        <span class='chat-img pull-right'>
                                            <img src='img/user2.jpg' alt='User Avatar'>
                                        </span>
                                        <div class='chat-body clearfix'>
                                            <div class='header'>
                                                <strong class='primary-font'>Jane Doe</strong>
                                                <small class='pull-right text-muted'><i class='fa fa-clock-o'></i>13 mins ago</small>
                                            </div>
                                            <p> Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur bibendum ornare dolor, quis ullamcorper ligula sodales at. </p>
                                        </div>
                                    </li>--%>
                                    </ul>
                                </div>
                            </div>
                        </div>
                        <!-- /panel -->
                    </div>

                </div>
                <!-- /panel -->
            </div>
            <!-- /.col -->
        </div>
    </div>
</asp:Content>
