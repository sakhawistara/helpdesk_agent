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
            <li class="active">Inbox Email</li>
        </ul>
    </div>
    <br />
    <div class="row">
        <div class="col-sm-3">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h1 class="panel-title">
                        <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapseThree"><strong>Mail Folder &nbsp;<i class="fa fa-sort-down"></i></strong>
                        </a>

                    </h1>

                </div>
                <div id="collapseThree" class="panel-collapse collapse">
                    <div class="panel-body">
                        <a href="inbox_email.aspx?inbox">
                            <i class="fa fa-inbox fa-lg"></i>
                            <span class="m-left-xs">Inbox</span>
                            <span class="badge badge-success pull-right">19</span>
                        </a>
                        <hr />
                        <%--<a href="#">
                            <i class="fa fa-star fa-lg"></i>
                            <span class="m-left-xs">Starred</span>
                            <span class="badge badge-warning pull-right">2</span>
                        </a>
                        <hr />
                        <a href="#">
                            <i class="fa fa-bookmark-o fa-lg"></i><span class="m-left-sm">Important</span>
                        </a>
                        <hr />--%>
                        <a href="#">
                            <i class="fa fa-envelope fa-lg"></i>
                            <span class="m-left-xs">Sent Mail</span>
                            <span class="badge badge-danger pull-right">1</span>
                        </a>
                        <hr />
                        <a href="#">
                            <i class="fa fa-pencil fa-lg"></i><span class="m-left-xs">Drafts</span>
                        </a>
                        <hr />
                        <asp:Button ID="btn_compose" runat="server" CssClass="btn btn-sm btn-info" Text="Compose" />

                    </div>
                </div>
            </div>
        </div>
        <!-- /.col -->
        <div class="col-sm-9">
            <div class="row" id="div_table" runat="server">
                <dx:ASPxGridView ID="gv_inbox_email" runat="server" KeyFieldName="id"
                    DataSourceID="sql_inbox_email" Width="100%" Theme="MetropolisBlue">
                    <SettingsPager>
                        <AllButton Text="All">
                        </AllButton>
                        <NextPageButton Text="Next &gt;">
                        </NextPageButton>
                        <PrevPageButton Text="&lt; Prev">
                        </PrevPageButton>
                    </SettingsPager>
                    <SettingsEditing Mode="Inline" />
                    <Settings ShowFilterRow="true" ShowFilterRowMenu="false" ShowGroupPanel="true"
                        ShowVerticalScrollBar="false" ShowHorizontalScrollBar="false" />
                    <SettingsBehavior ConfirmDelete="true" />
                    <Columns>
                        <dx:GridViewDataTextColumn Caption="Replay" VisibleIndex="0"
                            Width="40px" CellStyle-HorizontalAlign="Center">
                            <DataItemTemplate>
                                <a href="inbox_email.aspx?reply=<%# Eval("IVC_ID")%>&account=<%# Eval("EFROM")%>">
                                    <img src='img/icon/Text-Edit-icon2.png' /></a>
                            </DataItemTemplate>
                            <CellStyle HorizontalAlign="Center">
                            </CellStyle>
                        </dx:GridViewDataTextColumn>
                         <dx:GridViewDataTextColumn Caption="Ticket" VisibleIndex="0"
                            Width="40px" CellStyle-HorizontalAlign="Center">
                            <DataItemTemplate>
                                <a href="utama.aspx?channel=email&id=<%# Eval("IVC_ID")%>&account=<%# Eval("EFROM")%>">
                                    <img src='img/icon/Text-Edit-icon2.png' /></a>
                            </DataItemTemplate>
                            <CellStyle HorizontalAlign="Center">
                            </CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Account Name" FieldName="EFROM" Width="200px"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Subject" FieldName="ESUBJECT"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Date" FieldName="Email_Date"></dx:GridViewDataTextColumn>
                    </Columns>
                </dx:ASPxGridView>
                <asp:SqlDataSource ID="sql_inbox_email" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
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
        <!-- /.col -->
    </div>
    <!-- /.row -->
</asp:Content>
