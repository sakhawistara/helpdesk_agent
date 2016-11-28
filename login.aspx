<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="login.aspx.vb" Inherits="ICC.login" %>

<!DOCTYPE html>

<html lang="en">
<head>
    <meta charset="utf-8">
    <title>Login</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="">
    <meta name="author" content="">

    <!-- Bootstrap core CSS -->
    <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet">
    <link href="documentation/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="HTML/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <!-- Font Awesome -->
    <link href="HTML/css/font-awesome.min.css" rel="stylesheet" />
    <!-- Endless -->
    <link href="HTML/css/endless.min.css" rel="stylesheet" />

</head>

<body>
    <form runat="server">
        <div class="login-wrapper">
            <div class="text-center">
                <h2 class="fadeInUp animation-delay8" style="font-weight: bold">
                    <span class="text-info">Invision</span> <span style="color: #ccc; text-shadow: 0 1px #fff">Telesto 2.1</span>
                </h2>
            </div>
            <div class="login-widget animation-delay1">
                <div class="panel panel-default">
                    <div class="panel-heading clearfix">
                        <div class="pull-left">
                            <i class="fa fa-lock fa-lg"></i>&nbsp;Login
				
                        </div>

                        <%--<div class="pull-right">
                        <span style="font-size: 11px;">Don't have any account?</span>
                        <a class="btn btn-default btn-xs login-link" href="register.html" style="margin-top: -2px;"><i class="fa fa-plus-circle"></i>Sign up</a>
                    </div>--%>
                    </div>
                    <div class="panel-body">
                        <div class="form-group">
                            <label>Username</label>
                            <%--                            <input type="text" placeholder="Username" class="form-control input-sm bounceIn animation-delay2">--%>
                            <asp:TextBox ID="txt_username" runat="server" CssClass="form-control input-sm bounceIn animation-delay2"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>Password</label>
                            <%--                            <input type="password" placeholder="Password" class="form-control input-sm bounceIn animation-delay4">--%>
                            <asp:TextBox ID="txt_password" runat="server" CssClass="form-control input-sm bounceIn animation-delay4" TextMode="Password"></asp:TextBox>
                        </div>
                        <div class="seperator"></div>
                        <div class="form-group">
                            Forgot your password?<br />
                            Click <a href="#simpleModal" data-toggle="modal">here</a> to reset your password
                        </div>
                        <div class="row" id="lblError" runat="server" visible="false">
                            <div class="col-sm-12">
                                <div class="alert alert-danger">
                                    <button type="button" class="close" data-dismiss="alert" aria-hidden="true" id="B_notError" runat="server">&times;</button>
                                    <strong>
                                        <asp:Label ID="lbl_Error" runat="server">User Tidak Terdaftar</asp:Label>
                                    </strong>
                                </div>
                            </div>
                        </div>
                        <div class="panel-footer">
                            <div class="text-right">
                                <button id="Btn_Simpan" runat="server" class="btn btn-info" type="submit"><i class="fa fa-sign-in"></i>&nbsp;Sign in</button>
                            </div>
                            <%--<i class="fa fa-save"><asp:Button ID="btn_login" runat="server" Text="Sign in" CssClass="btn btn-info pull-right" /></i>--%>
                        </div>
                        <!-- /.modal -->
                    </div>
                </div>
                <!-- /panel -->
                
            </div>
            <!-- /login-widget -->            
        </div>
        
     <!-- Notifed Error-->
    </form>
    <div class="modal fade" id="simpleModal">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                <h4>Forget Password</h4>
                            </div>
                            <div class="modal-body">
                                <p>One fine body...</p>
                            </div>
                            <div class="modal-footer">
                                <button class="btn btn-sm btn-success" data-dismiss="modal" aria-hidden="true">Close</button>
                                <a href="#" class="btn btn-danger btn-sm">Save</a>
                            </div>
                        </div>
                        <!-- /.modal-content -->
                    </div>
                    <!-- /.modal-dialog -->
                </div>
    <!-- /login-wrapper -->

    <!-- Le javascript
    ================================================== -->
    <!-- Placed at the end of the document so the pages load faster -->

    <!-- Jquery -->
    <script src="js/jquery-1.10.2.min.js"></script>
    <script src="HTML/js/jquery-1.10.2.min.js"></script>
    <!-- Bootstrap -->
    <script src="bootstrap/js/bootstrap.min.js"></script>
    <script src="HTML/bootstrap/js/bootstrap.min.js"></script>
    <!-- Modernizr -->
    <script src="HTML/js/modernizr.min.js"></script>
    <!-- Pace -->
    <script src="HTML/js/pace.min.js"></script>
    <!-- Popup Overlay -->
    <script src="HTML/js/jquery.popupoverlay.min.js"></script>
    <!-- Slimscroll -->
    <script src="HTML/js/jquery.slimscroll.min.js"></script>
    <!-- Cookie -->
    <script src="HTML/js/jquery.cookie.min.js"></script>
    <!-- Endless -->
    <script src="HTML/js/endless/endless.js"></script>
</body>
</html>
