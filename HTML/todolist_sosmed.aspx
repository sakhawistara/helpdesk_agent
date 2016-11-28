<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/HTML/Ticket.Master" CodeBehind="todolist_sosmed.aspx.vb" Inherits="ICC.todolist_sosmed" %>

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
            <li class="active">To Do List</li>
        </ul>
    </div>
   <div class="padding-md">
        <div class="row">
                            <div class="table-responsive">
                            <table class="table table-striped" id="dataTable">
                                <thead>
                                    <tr>
                                        <th class="text-center">Action</th>
                                        <th>Name</th>
                                        <th>Message</th>
                                        <th>Date</th>
                                        <th>Ket</th>
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
                <!-- /tab-content -->
</asp:Content>
