<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="app.aspx.vb" Inherits="ICC.app" %>

<!DOCTYPE html>

<html lang="en">
<head>
    <meta charset="utf-8">
    <title>Invision Sosial Media</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="">
    <meta name="author" content="">

    <!-- Bootstrap core CSS -->
    <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet">

    <!-- Font Awesome -->
    <link href="css/font-awesome.min.css" rel="stylesheet">

    <!-- Pace -->
    <link href="css/pace.css" rel="stylesheet">

    <!-- Endless -->
    <link href="css/endless.min.css" rel="stylesheet">
    <link href="css/endless-landing.min.css" rel="stylesheet">
</head>

<body class="overflow-hidden">
    <!-- Overlay Div -->
    <div id="overlay" class="transparent"></div>
    <form runat="server">
        <div id="wrapper" class="preload">
        <header class="navbar navbar-fixed-top bg-white" style="background-color: #003366;">
            <div class="form-group">
                <div class="col-lg-11">
                    <div class="row">
                        <img src="img/cukai.png" alt="">
                    </div>
                    <!-- /.row -->
                </div>
                <!-- /.col -->
            </div>
            <div class="form-group">
                <div class="col-lg-1">
                    <div class="row">
                        <asp:Label ID="lbl_tgl" runat="server" ForeColor="White" Font-Size="26px" Font-Names="times new roman" Text="14:20:10"></asp:Label>
                        &nbsp;&nbsp;<asp:Label ID="Label1" runat="server" ForeColor="White" Font-Names="times new roman" Font-Size="16px" Text="2016-07-29"></asp:Label>
                    </div>
                    <!-- /.row -->
                </div>
                <!-- /.col -->
            </div>

            <br />
        </header>

        <br />
        <br />
        <div id="landing-content">
            <br />
            <br />
             <br />
            <asp:Button ID="btn_test" Text="Testing" runat="server" />
            <div class="padding-md">
                <div class="row">
                    <div class="col-sm-6 col-md-4">
                        <div class="panel-stat3 bg-danger">
                            <h2 class="m-top-none" id="userCount">
                                <asp:Label ID="lbl1" runat="server" Text="Menu 1"></asp:Label></h2>
                            <h5>
                                <asp:Label ID="Label3" runat="server" Text="92" ForeColor="Transparent"></asp:Label></h5>
                            <span class="m-left-xs">
                                <asp:Label ID="Label2" runat="server" Text="92" ForeColor="Transparent"></asp:Label></span>
                            <div class="stat-icon">
                                <i class="fa fa-user fa-3x"></i>
                            </div>
                            <div class="loading-overlay">
                                <i class="loading-icon fa fa-refresh fa-spin fa-lg"></i>
                            </div>
                        </div>
                    </div>
                    <!-- /.col -->
                    <div class="col-sm-6 col-md-4">
                        <div class="panel-stat3 bg-info">
                            <h2 class="m-top-none" id="H5">
                                <asp:Label ID="Label4" runat="server" Text="Menu 1"></asp:Label></h2>
                            <h5>
                                <asp:Label ID="Label5" runat="server" Text="92" ForeColor="Transparent"></asp:Label></h5>
                            <span class="m-left-xs">
                                <asp:Label ID="Label6" runat="server" Text="92" ForeColor="Transparent"></asp:Label></span>
                            <div class="stat-icon">
                                <i class="fa fa-user fa-3x"></i>
                            </div>
                            <div class="loading-overlay">
                                <i class="loading-icon fa fa-refresh fa-spin fa-lg"></i>
                            </div>
                        </div>
                    </div>
                    <!-- /.col -->
                    <div class="col-sm-6 col-md-4">
                        <div class="panel-stat3 bg-warning">
                            <h2 class="m-top-none" id="H6">
                                <asp:Label ID="Label7" runat="server" Text="Menu 3"></asp:Label></h2>
                            <h5>
                                <asp:Label ID="Label8" runat="server" Text="92" ForeColor="Transparent"></asp:Label></h5>
                            <span class="m-left-xs">
                                <asp:Label ID="Label9" runat="server" Text="92" ForeColor="Transparent"></asp:Label></span>
                            <div class="stat-icon">
                                <i class="fa fa-user fa-3x"></i>
                            </div>
                            <div class="loading-overlay">
                                <i class="loading-icon fa fa-refresh fa-spin fa-lg"></i>
                            </div>
                        </div>
                    </div>
                    <!-- /.col -->
                    <div class="col-sm-6 col-md-4">
                        <div class="panel-stat3 bg-success">
                            <h2 class="m-top-none" id="H7">
                                <asp:Label ID="Label10" runat="server" Text="Menu 4"></asp:Label></h2>
                            <h5>
                                <asp:Label ID="Label11" runat="server" Text="92" ForeColor="Transparent"></asp:Label></h5>
                            <span class="m-left-xs">
                                <asp:Label ID="Label12" runat="server" Text="92" ForeColor="Transparent"></asp:Label></span>
                            <div class="stat-icon">
                                <i class="fa fa-user fa-3x"></i>
                            </div>
                            <div class="loading-overlay">
                                <i class="loading-icon fa fa-refresh fa-spin fa-lg"></i>
                            </div>
                        </div>
                    </div>
                    <!-- /.col -->
                    <div class="col-sm-6 col-md-4">
                        <div class="panel-stat3 bg-danger">
                            <h2 class="m-top-none" id="H1">
                                 <asp:Label ID="Label13" runat="server" Text="Menu 5"></asp:Label></h2>
                            <h5>
                                <asp:Label ID="Label14" runat="server" Text="92" ForeColor="Transparent"></asp:Label></h5>
                            <span class="m-left-xs">
                                <asp:Label ID="Label15" runat="server" Text="92" ForeColor="Transparent"></asp:Label></span>
                            <div class="stat-icon">
                                <i class="fa fa-user fa-3x"></i>
                            </div>
                            <div class="loading-overlay">
                                <i class="loading-icon fa fa-refresh fa-spin fa-lg"></i>
                            </div>
                        </div>
                    </div>
                    <!-- /.col -->
                    <div class="col-sm-6 col-md-4">
                        <div class="panel-stat3 bg-info">
                            <h2 class="m-top-none" id="H8">
                                <asp:Label ID="Label16" runat="server" Text="Menu 6"></asp:Label></h2>
                            <h5>
                                <asp:Label ID="Label17" runat="server" Text="92" ForeColor="Transparent"></asp:Label></h5>
                            <span class="m-left-xs">
                                <asp:Label ID="Label18" runat="server" Text="92" ForeColor="Transparent"></asp:Label></span>
                            <div class="stat-icon">
                                <i class="fa fa-user fa-3x"></i>
                            </div>
                            <div class="loading-overlay">
                                <i class="loading-icon fa fa-refresh fa-spin fa-lg"></i>
                            </div>
                        </div>
                    </div>
                    <!-- /.col -->
                    <div class="col-sm-6 col-md-4">
                        <div class="panel-stat3 bg-warning">
                            <h2 class="m-top-none" id="H2">
                                <asp:Label ID="Label19" runat="server" Text="Menu 7"></asp:Label></h2>
                            <h5>
                                <asp:Label ID="Label20" runat="server" Text="92" ForeColor="Transparent"></asp:Label></h5>
                            <span class="m-left-xs">
                                <asp:Label ID="Label21" runat="server" Text="92" ForeColor="Transparent"></asp:Label></span>
                           <div class="stat-icon">
                                <i class="fa fa-user fa-3x"></i>
                            </div>
                            <div class="loading-overlay">
                                <i class="loading-icon fa fa-refresh fa-spin fa-lg"></i>
                            </div>
                        </div>
                    </div>
                    <!-- /.col -->
                    <div class="col-sm-6 col-md-4">
                        <div class="panel-stat3 bg-success">
                            <h2 class="m-top-none" id="H3">
                                 <asp:Label ID="Label22" runat="server" Text="Menu 8"></asp:Label></h2>
                            <h5>
                                <asp:Label ID="Label23" runat="server" Text="92" ForeColor="Transparent"></asp:Label></h5>
                            <span class="m-left-xs">
                                <asp:Label ID="Label24" runat="server" Text="92" ForeColor="Transparent"></asp:Label></span>
                            <div class="stat-icon">
                                <i class="fa fa-user fa-3x"></i>
                            </div>
                            <div class="loading-overlay">
                                <i class="loading-icon fa fa-refresh fa-spin fa-lg"></i>
                            </div>
                        </div>
                    </div>
                    <!-- /.col -->
                    <div class="col-sm-6 col-md-4">
                        <div class="panel-stat3 bg-danger">
                            <h2 class="m-top-none" id="H4">
                                 <asp:Label ID="Label25" runat="server" Text="Menu 9"></asp:Label></h2>
                            <h5>
                                <asp:Label ID="Label26" runat="server" Text="92" ForeColor="Transparent"></asp:Label></h5>
                            <span class="m-left-xs">
                                <asp:Label ID="Label27" runat="server" Text="92" ForeColor="Transparent"></asp:Label></span>
                            <div class="stat-icon">
                                <i class="fa fa-user fa-3x"></i>
                            </div>
                            <div class="loading-overlay">
                                <i class="loading-icon fa fa-refresh fa-spin fa-lg"></i>
                            </div>
                        </div>
                    </div>
                    <!-- /.col -->
                    <div class="col-sm-6 col-md-4">
                        <div class="panel-stat3 bg-info">
                            <h2 class="m-top-none" id="H9">
                                 <asp:Label ID="Label28" runat="server" Text="Menu 10"></asp:Label></h2>
                            <h5>
                                <asp:Label ID="Label29" runat="server" Text="92" ForeColor="Transparent"></asp:Label></h5>
                            <span class="m-left-xs">
                                <asp:Label ID="Label30" runat="server" Text="92" ForeColor="Transparent"></asp:Label></span>
                             <div class="stat-icon">
                                <i class="fa fa-user fa-3x"></i>
                            </div>
                            <div class="loading-overlay">
                                <i class="loading-icon fa fa-refresh fa-spin fa-lg"></i>
                            </div>
                        </div>
                    </div>
                    <!-- /.col -->
                </div>
            </div>
        </div>
        <!-- /landing-content -->
        <footer style="background-color: #003366;">
            <div class="container">
                <div class="padding-md">
                    <div class="row">
                        <div class="col-sm-3 padding-md">
                            <%--                            <p class="font-lg">About Our Company</p>
                            <p><small>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum auctor suscipit lobortis.</small></p>--%>
                        </div>
                        <!-- /.col -->
                        <div class="col-sm-3 padding-md">
                            <%--<p class="font-lg">Useful Links</p>
                            <ul class="list-unstyled useful-link">
                                <li>
                                    <a href="#">
                                        <small><i class="fa fa-chevron-right"></i>Our Profile</small>
                                    </a>
                                </li>
                                <li>
                                    <a href="#">
                                        <small><i class="fa fa-chevron-right"></i>New Products</small>
                                    </a>
                                </li>
                                <li>
                                    <a href="#">
                                        <small><i class="fa fa-chevron-right"></i>Support Portal</small>
                                    </a>
                                </li>
                            </ul>--%>
                        </div>
                        <!-- /.col -->
                        <div class="col-sm-3 padding-md">
                            <%--                            <p class="font-lg">Stay Connect</p>
                            <a href="#" class="social-connect tooltip-test facebook-hover pull-left m-right-xs" data-toggle="tooltip" data-original-title="Facebook"><i class="fa fa-facebook"></i></a>
                            <a href="#" class="social-connect tooltip-test twitter-hover pull-left m-right-xs" data-toggle="tooltip" data-original-title="Twitter"><i class="fa fa-twitter"></i></a>
                            <a href="#" class="social-connect tooltip-test google-plus-hover pull-left m-right-xs" data-toggle="tooltip" data-original-title="Google Plus"><i class="fa fa-google-plus"></i></a>
                            <a href="#" class="social-connect tooltip-test rss-hover pull-left m-right-xs" data-toggle="tooltip" data-original-title="Rss feed"><i class="fa fa-rss"></i></a>
                            <a href="#" class="social-connect tooltip-test tumblr-hover pull-left m-right-xs" data-toggle="tooltip" data-original-title="Tumblr"><i class="fa fa-tumblr"></i></a>
                            <a href="#" class="social-connect tooltip-test dribbble-hover pull-left m-right-xs" data-toggle="tooltip" data-original-title="Dribbble"><i class="fa fa-dribbble"></i></a>
                            <a href="#" class="social-connect tooltip-test linkedin-hover pull-left m-right-xs" data-toggle="tooltip" data-original-title="Linkedin"><i class="fa fa-linkedin"></i></a>
                            <a href="#" class="social-connect tooltip-test pinterest-hover pull-left" data-toggle="tooltip" data-original-title="Pinterest"><i class="fa fa-pinterest"></i></a>--%>
                        </div>
                        <!-- /.col -->
                          <div class="col-sm-3 padding-md">
                            
                        </div>
                        <!-- /.col -->
                    </div>
                </div>
                <!-- /.row -->
            </div>
        </footer>
    </div>
    </form>
    
    <!-- /wrapper -->

    <a href="" id="scroll-to-top" class="hidden-print"><i class="fa fa-chevron-up"></i></a>

    <!-- Le javascript
    ================================================== -->
    <!-- Placed at the end of the document so the pages load faster -->

    <!-- Jquery -->
    <script src="js/jquery-1.10.2.min.js"></script>

    <!-- Bootstrap -->
    <script src="bootstrap/js/bootstrap.min.js"></script>

    <!-- Waypoint -->
    <script src='js/waypoints.min.js'></script>

    <!-- LocalScroll -->
    <script src='js/jquery.localscroll.min.js'></script>

    <!-- ScrollTo -->
    <script src='js/jquery.scrollTo.min.js'></script>

    <!-- Modernizr -->
    <script src='js/modernizr.min.js'></script>

    <!-- Pace -->
    <script src='js/pace.min.js'></script>

    <!-- Popup Overlay -->
    <script src='js/jquery.popupoverlay.min.js'></script>

    <!-- Slimscroll -->
    <script src='js/jquery.slimscroll.min.js'></script>

    <!-- Cookie -->
    <script src='js/jquery.cookie.min.js'></script>

    <!-- Endless -->
    <script src="js/endless/endless.js"></script>

    <script>
        $(function () {
            $('.animated-element').waypoint(function () {

                $(this).removeClass('no-animation');

            }, { offset: '70%' });

            $('.nav').localScroll({ duration: 800 });
        });
	</script>

</body>
</html>
