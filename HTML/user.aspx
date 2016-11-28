<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="user.aspx.vb" Inherits="ICC.user" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8">
    <title>Invision Helpdesk</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="">
    <meta name="author" content="">

    <!-- Bootstrap core CSS -->
    <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet">

    <!-- Font Awesome -->
    <link href="css/font-awesome.min.css" rel="stylesheet">

    <!-- Pace -->
    <link href="css/pace.css" rel="stylesheet">

    <!-- Datatable -->
    <link href="css/jquery.dataTables_themeroller.css" rel="stylesheet">

    <!-- Color box -->
    <link href="css/colorbox/colorbox.css" rel="stylesheet">

    <!-- Morris -->
    <link href="css/morris.css" rel="stylesheet" />

    <!-- Endless -->
    <link href="css/endless.min.css" rel="stylesheet">
    <link href="css/endless-skin.css" rel="stylesheet">

    <!-- Gritter -->
    <link href="css/gritter/jquery.gritter.css" rel="stylesheet">
</head>
<body>
    <div>
        <asp:SqlDataSource ID="sql_app" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"
            SelectCommand="select * from user4"></asp:SqlDataSource>
        <asp:SqlDataSource ID="sql_3" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
        <br />
        <div class="padding-md">
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-default">
                        <form class="form-horizontal form-border no-margin" data-validate="parsley" runat="server">
                            <div class="panel-heading">
                                Customer Configuration Application Setting
                            </div>
                            <div class="panel-body">
                                <div id="div_customer" runat="server" visible="false">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <label class="control-label">Company Name</label>
                                            <asp:TextBox ID="txt_company_name" runat="server" CssClass="form-control input-sm" placeholder="Company Name"></asp:TextBox>
                                        </div>
                                        <div class="col-md-6">
                                            <label class="control-label">Email</label>
                                            <asp:TextBox ID="txt_email" runat="server" CssClass="form-control input-sm" placeholder="Email"></asp:TextBox>
                                        </div>
                                        <div class="col-md-6">
                                            <label class="control-label">Phone</label>
                                            <asp:TextBox ID="txt_phone" runat="server" CssClass="form-control input-sm" placeholder="Phone"></asp:TextBox>
                                        </div>
                                        <div class="col-md-12">
                                            <label class="control-label">Address</label>
                                            <asp:TextBox ID="txt_address" TextMode="MultiLine" runat="server" CssClass="form-control input-sm" placeholder="Address"></asp:TextBox>
                                        </div>

                                        <!-- /.col -->
                                    </div>
                                    <!-- /.row -->
                                </div>
                                <hr id="hr_satu" runat="server" visible="false" />
                                <div id="div_setting" runat="server" visible="false">
                                    <div class="form-group">
                                        <div class="col-lg-3">
                                            <dx:ASPxCheckBox ID="chk_ticket" runat="server" Theme="MetropolisBlue" Text="Application Ticketing"></dx:ASPxCheckBox>
                                        </div>
                                        <!-- /.col -->
                                        <div class="col-lg-3">
                                            <dx:ASPxCheckBox ID="chk_email" runat="server" Theme="MetropolisBlue" Text="Channel Email"></dx:ASPxCheckBox>
                                        </div>
                                        <!-- /.col -->

                                        <div class="col-lg-3">
                                            <dx:ASPxCheckBox ID="chk_twitter" runat="server" Theme="MetropolisBlue" Text="Channel Twitter"></dx:ASPxCheckBox>
                                        </div>
                                        <div class="col-lg-3">
                                            <dx:ASPxCheckBox ID="chk_facebook" runat="server" Theme="MetropolisBlue" Text="Channel Facebook"></dx:ASPxCheckBox>
                                        </div>
                                        <!-- /.col -->
                                    </div>
                                    <!-- /form-group -->
                                    <div class="form-group">
                                        <div class="col-lg-3">
                                            <dx:ASPxCheckBox ID="chk_fax" runat="server" Theme="MetropolisBlue" Text="Channel Fax"></dx:ASPxCheckBox>
                                        </div>
                                        <!-- /.col -->
                                        <div class="col-lg-3">
                                            <dx:ASPxCheckBox ID="chk_chat" runat="server" Theme="MetropolisBlue" Text="Channel Chat"></dx:ASPxCheckBox>
                                        </div>
                                        <!-- /.col -->
                                        <div class="col-lg-3">
                                            <dx:ASPxCheckBox ID="chk_sms" runat="server" Theme="MetropolisBlue" Text="Channel Sms"></dx:ASPxCheckBox>
                                        </div>
                                        <div class="col-lg-3">
                                            <dx:ASPxCheckBox ID="chk_telegram" runat="server" Theme="MetropolisBlue" Text="Channel Telegram"></dx:ASPxCheckBox>
                                        </div>
                                        <!-- /.col -->
                                    </div>
                                    <div class="form-group">
                                        <div class="col-lg-3">
                                            <dx:ASPxCheckBox ID="chk_instagram" runat="server" Theme="MetropolisBlue" Text="Channel Instagram"></dx:ASPxCheckBox>
                                        </div>
                                        <!-- /.col -->
                                    </div>
                                </div>
                                <hr id="hr_dua" runat="server" visible="false" />
                                <div id="div_license" runat="server" visible="false">
                                    <div class="row">
                                        <div class="col-md-6">
                                            <label class="control-label">Agent License</label>
                                            <asp:TextBox ID="txt_license" runat="server" CssClass="form-control input-sm" placeholder="Agent License"></asp:TextBox>
                                        </div>
                                        <!-- /.col -->
                                        <div class="col-md-6">
                                            <label class="control-label">Login With</label>
                                            <dx:ASPxComboBox ID="cmb_status" Height="30px" runat="server" Theme="MetropolisBlue" Width="100%"
                                                CssClass="form-control chzn-select">
                                                <Items>
                                                    <dx:ListEditItem Text="LDAP" Value="LDAP" />
                                                    <dx:ListEditItem Text="Manual" Value="Manual" />
                                                </Items>
                                            </dx:ASPxComboBox>
                                        </div>
                                    </div>
                                </div>
                                <hr id="hr_tiga" runat="server" visible="false" />
                                <div id="div_generate" runat="server" visible="false">
                                    <dx:ASPxGridView ID="gv_app" runat="server" KeyFieldName="UserID"
                                        DataSourceID="sql_user" Width="100%" Theme="MetropolisBlue">
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
                                            <dx:GridViewCommandColumn Caption="Action" HeaderStyle-HorizontalAlign="Center" VisibleIndex="0"
                                                ButtonType="Image" FixedStyle="Left" CellStyle-BackColor="#ffffd6" Width="130px">
                                                <EditButton Visible="true">
                                                    <Image ToolTip="Edit" Url="img/icon/Text-Edit-icon2.png" />
                                                </EditButton>
                                                <NewButton Visible="false">
                                                    <Image ToolTip="New" Url="img/icon/Apps-text-editor-icon2.png" />
                                                </NewButton>
                                                <DeleteButton Visible="false">
                                                    <Image ToolTip="Delete" Url="img/icon/Actions-edit-clear-icon2.png" />
                                                </DeleteButton>
                                                <CancelButton>
                                                    <Image ToolTip="Cancel" Url="img/icon/cancel1.png">
                                                    </Image>
                                                </CancelButton>
                                                <UpdateButton>
                                                    <Image ToolTip="Update" Url="img/icon/Updated1.png" />
                                                </UpdateButton>
                                                <CellStyle BackColor="#FFFFD6">
                                                </CellStyle>
                                            </dx:GridViewCommandColumn>
                                            <dx:GridViewDataTextColumn Caption="User" FieldName="UserID"></dx:GridViewDataTextColumn>
                                        </Columns>
                                    </dx:ASPxGridView>
                                    <asp:SqlDataSource ID="sql_user" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
                                </div>
                            </div>
                            <div class="panel-footer">
                                <asp:Button ID="btn_simpan" CssClass="btn btn-info" Text="Submit" runat="server" Visible="false" />
                                <asp:Button ID="btn_back" CssClass="btn btn-danger" Text="Back" runat="server" Visible="false" />
                                <asp:Button ID="btn_generate" CssClass="btn btn-info" Text="Generate User" runat="server" Visible="false" />
                                <asp:Button ID="btn_finis" CssClass="btn btn-info" Text="Finis" runat="server" Visible="false" />
                            </div>
                        </form>
                    </div>
                    <!-- /panel -->
                </div>
                <!-- /.col-->
            </div>
        </div>
    </div>

    <!-- Placed at the end of the document so the pages load faster -->

    <!-- Jquery -->
    <script src="js/jquery-1.10.2.min.js"></script>

    <!-- Bootstrap -->
    <script src="bootstrap/js/bootstrap.js"></script>

    <!-- Datatable -->
    <script src='js/jquery.dataTables.min.js'></script>

    <!-- holder -->
    <script src='js/uncompressed/holder.js'></script>
    <!-- Gritter -->
    <script src="js/jquery.gritter.min.js"></script>

    <!-- Flot -->
    <script src='js/jquery.flot.min.js'></script>

    <!-- Morris -->
    <script src='js/rapheal.min.js'></script>
    <script src='js/morris.min.js'></script>

    <!-- Colorbox -->
    <script src='js/jquery.colorbox.min.js'></script>

    <!-- Sparkline -->
    <script src='js/jquery.sparkline.min.js'></script>

    <!-- Pace -->
    <script src='js/uncompressed/pace.js'></script>

    <!-- Popup Overlay -->
    <script src='js/jquery.popupoverlay.min.js'></script>

    <!-- Slimscroll -->
    <script src='js/jquery.slimscroll.min.js'></script>

    <!-- Modernizr -->
    <script src='js/modernizr.min.js'></script>

    <!-- Cookie -->
    <script src='js/jquery.cookie.min.js'></script>

    <!-- Endless -->
    <script src="js/endless/endless_dashboard.js"></script>
    <script src="js/endless/endless.js"></script>

    <!-- holder -->
    <script src='js/uncompressed/holder.js'></script>
    <!-- Gritter -->
    <script src="js/jquery.gritter.min.js"></script>
</body>
</html>
