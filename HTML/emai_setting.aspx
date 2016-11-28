<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/HTML/Ticket.Master" CodeBehind="emai_setting.aspx.vb" Inherits="ICC.emai_setting" %>


<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="div_alltwt" runat="server">
        <div id="breadcrumb">
            <ul class="breadcrumb">
                <li><i class="fa fa-home"></i>&nbsp;<a href="dashboard.aspx">Home</a></li>
                <li class="active">Setting Account Email</li>
            </ul>
        </div>
        <div class="padding-md">
            <div class="row">
                <div class="panel-body">
                    <div class="form-group">
                        <label class="control-label">Account Email</label>
                        <asp:TextBox ID="txt_acc_email" runat="server" CssClass="form-control input-sm" data-required="true"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rqr_acc_email" ControlToValidate="txt_acc_email" ForeColor="Red"
                            runat="server" Display="Dynamic" Text="* Account Email Empty" ValidationGroup="Btn_Simpan"
                            ErrorMessage="Please enter a value.">
                        </asp:RequiredFieldValidator>
                    </div>
                    <!-- /form-group -->
                    <div class="form-group">
                        <label class="control-label">Password</label>
                        <asp:TextBox ID="txt_acc_password" runat="server" CssClass="form-control input-sm" data-required="true"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rqr_acc_pass" ControlToValidate="txt_acc_password" ForeColor="Red"
                            runat="server" Display="Dynamic" Text="* Password Email Empty" ValidationGroup="Btn_Simpan"
                            ErrorMessage="Please enter a value.">
                        </asp:RequiredFieldValidator>
                    </div>
                    <!-- /form-group -->
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label">SMTP</label>
                                <asp:TextBox ID="txt_acc_smtp" runat="server" CssClass="form-control input-sm" data-required="true"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rqr_acc_smtp" ControlToValidate="txt_acc_smtp" ForeColor="Red"
                                    runat="server" Display="Dynamic" Text="* SMTP Email Empty" ValidationGroup="Btn_Simpan"
                                    ErrorMessage="Please enter a value.">
                                </asp:RequiredFieldValidator>
                            </div>
                            <!-- /form-group -->
                        </div>
                        <!-- /.col -->
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label">Port</label>
                                <asp:TextBox ID="txt_port" runat="server" CssClass="form-control input-sm" data-required="true"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rqr_acc_port" ControlToValidate="txt_port" ForeColor="Red"
                                    runat="server" Display="Dynamic" Text="* Port Email Empty" ValidationGroup="Btn_Simpan"
                                    ErrorMessage="Please enter a value.">
                                </asp:RequiredFieldValidator>
                            </div>
                            <!-- /form-group -->
                        </div>
                        <!-- /.col -->
                    </div>
                    <!-- /.row -->
                    <div class="form-group">
                        <label class="label-checkbox inline">
                            <input name="agreement" data-required="true" class="parsley-validated" type="checkbox">
                            <span class="custom-checkbox"></span>
                            I accept the user agreement								
                        </label>
                    </div>
                    <!-- /form-group -->
                </div>
                <div class="panel-footer text-right">
                    <button id="Btn_Simpan" runat="server" class="btn btn-info" type="submit" validationgroup="Btn_Simpan">
                        <i class="fa fa-save"></i>&nbsp;Save
                    </button>
                    <button id="Btn_Cancel" runat="server" class="btn btn-info" type="submit">
                        <i class="fa fa-arrow-circle-left"></i>&nbsp;Cancel
                    </button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
