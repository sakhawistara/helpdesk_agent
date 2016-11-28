﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="form.aspx.vb" Inherits="ICC.form" %>


<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>


<!DOCTYPE html>

<html lang="en">
<head>
    <meta charset="utf-8">
    <title>Endless Admin</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="">
    <meta name="author" content="">

    <!-- Bootstrap core CSS -->
    <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet">

    <!-- Font Awesome -->
    <link href="css/font-awesome.min.css" rel="stylesheet">

    <!-- Pace -->
    <link href="css/pace.css" rel="stylesheet">

    <!-- Chosen -->
    <link href="css/chosen/chosen.min.css" rel="stylesheet" />

    <!-- Datepicker -->
    <link href="css/datepicker.css" rel="stylesheet" />

    <!-- Timepicker -->
    <link href="css/bootstrap-timepicker.css" rel="stylesheet" />

    <!-- Slider -->
    <link href="css/slider.css" rel="stylesheet" />

    <!-- Tag input -->
    <link href="css/jquery.tagsinput.css" rel="stylesheet" />

    <!-- WYSIHTML5 -->
    <link href="css/bootstrap-wysihtml5.css" rel="stylesheet" />

    <!-- Dropzone -->
    <link href='css/dropzone/dropzone.css' rel="stylesheet" />

    <!-- Endless -->
    <link href="css/endless.min.css" rel="stylesheet">
    <link href="css/endless-skin.css" rel="stylesheet">
</head>

<body class="overflow-hidden">
    <!-- Overlay Div -->
    <div id="overlay" class="transparent"></div>

    <a href="" id="theme-setting-icon"><i class="fa fa-cog fa-lg"></i></a>
    <div id="theme-setting">
        <div class="title">
            <strong class="no-margin">Skin Color</strong>
        </div>
        <div class="theme-box">
            <a class="theme-color" style="background: #323447" id="default"></a>
            <a class="theme-color" style="background: #efefef" id="skin-1"></a>
            <a class="theme-color" style="background: #a93922" id="skin-2"></a>
            <a class="theme-color" style="background: #3e6b96" id="skin-3"></a>
            <a class="theme-color" style="background: #635247" id="skin-4"></a>
            <a class="theme-color" style="background: #3a3a3a" id="skin-5"></a>
            <a class="theme-color" style="background: #495B6C" id="skin-6"></a>
        </div>
        <div class="title">
            <strong class="no-margin">Sidebar Menu</strong>
        </div>
        <div class="theme-box">
            <label class="label-checkbox">
                <input type="checkbox" checked id="fixedSidebar">
                <span class="custom-checkbox"></span>
                Fixed Sidebar
		
            </label>
        </div>
    </div>
    <!-- /theme-setting -->

    <div id="wrapper" class="preload">
        <div id="top-nav" class="skin-6 fixed">
            <div class="brand">
                <span>Endless</span>
                <span class="text-toggle">Admin</span>
            </div>
            <!-- /brand -->
            <button type="button" class="navbar-toggle pull-left" id="sidebarToggle">
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
            </button>
            <button type="button" class="navbar-toggle pull-left hide-menu" id="menuToggle">
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
            </button>
            <ul class="nav-notification clearfix">
                <li class="dropdown">
                    <a class="dropdown-toggle" data-toggle="dropdown" href="#">
                        <i class="fa fa-envelope fa-lg"></i>
                        <span class="notification-label bounceIn animation-delay4">7</span>
                    </a>
                    <ul class="dropdown-menu message dropdown-1">
                        <li><a>You have 4 new unread messages</a></li>
                        <li>
                            <a class="clearfix" href="#">
                                <img src="img/user.jpg" alt="User Avatar">
                                <div class="detail">
                                    <strong>John Doe</strong>
                                    <p class="no-margin">
                                        Lorem ipsum dolor sit amet...
								
                                    </p>
                                    <small class="text-muted"><i class="fa fa-check text-success"></i>27m ago</small>
                                </div>
                            </a>
                        </li>
                        <li>
                            <a class="clearfix" href="#">
                                <img src="img/user2.jpg" alt="User Avatar">
                                <div class="detail">
                                    <strong>Jane Doe</strong>
                                    <p class="no-margin">
                                        Lorem ipsum dolor sit amet...
								
                                    </p>
                                    <small class="text-muted"><i class="fa fa-check text-success"></i>5hr ago</small>
                                </div>
                            </a>
                        </li>
                        <li>
                            <a class="clearfix" href="#">
                                <img src="img/user.jpg" alt="User Avatar">
                                <div class="detail">
                                    <strong>Bill Doe</strong>
                                    <p class="no-margin">
                                        Lorem ipsum dolor sit amet...
								
                                    </p>
                                    <small class="text-muted"><i class="fa fa-reply"></i>Yesterday</small>
                                </div>
                            </a>
                        </li>
                        <li>
                            <a class="clearfix" href="#">
                                <img src="img/user2.jpg" alt="User Avatar">
                                <div class="detail">
                                    <strong>Baby Doe</strong>
                                    <p class="no-margin">
                                        Lorem ipsum dolor sit amet...
								
                                    </p>
                                    <small class="text-muted"><i class="fa fa-reply"></i>9 Feb 2013</small>
                                </div>
                            </a>
                        </li>
                        <li><a href="#">View all messages</a></li>
                    </ul>
                </li>
                <li class="dropdown hidden-xs">
                    <a href="#" class="dropdown-toggle" data-toggle="dropdown">
                        <i class="fa fa-tasks fa-lg"></i>
                        <span class="notification-label bounceIn animation-delay5">4</span>
                    </a>
                    <ul class="dropdown-menu task dropdown-2">
                        <li><a href="#">You have 4 tasks to complete</a></li>
                        <li>
                            <a href="#">
                                <div class="clearfix">
                                    <span class="pull-left">Bug Fixes</span>
                                    <small class="pull-right text-muted">78%</small>
                                </div>
                                <div class="progress">
                                    <div class="progress-bar" style="width: 78%"></div>
                                </div>
                            </a>
                        </li>
                        <li>
                            <a href="#">
                                <div class="clearfix">
                                    <span class="pull-left">Software Updating</span>
                                    <small class="pull-right text-muted">54%</small>
                                </div>
                                <div class="progress progress-striped">
                                    <div class="progress-bar progress-bar-success" style="width: 54%"></div>
                                </div>
                            </a>
                        </li>
                        <li>
                            <a href="#">
                                <div class="clearfix">
                                    <span class="pull-left">Database Migration</span>
                                    <small class="pull-right text-muted">23%</small>
                                </div>
                                <div class="progress">
                                    <div class="progress-bar progress-bar-warning" style="width: 23%"></div>
                                </div>
                            </a>
                        </li>
                        <li>
                            <a href="#">
                                <div class="clearfix">
                                    <span class="pull-left">Unit Testing</span>
                                    <small class="pull-right text-muted">92%</small>
                                </div>
                                <div class="progress progress-striped active">
                                    <div class="progress-bar progress-bar-danger " style="width: 92%"></div>
                                </div>
                            </a>
                        </li>
                        <li><a href="#">View all tasks</a></li>
                    </ul>
                </li>
                <li class="dropdown">
                    <a class="dropdown-toggle" data-toggle="dropdown" href="#">
                        <i class="fa fa-bell fa-lg"></i>
                        <span class="notification-label bounceIn animation-delay6">5</span>
                    </a>
                    <ul class="dropdown-menu notification dropdown-3">
                        <li><a href="#">You have 5 new notifications</a></li>
                        <li>
                            <a href="#">
                                <span class="notification-icon bg-warning">
                                    <i class="fa fa-warning"></i>
                                </span>
                                <span class="m-left-xs">Server #2 not responding.</span>
                                <span class="time text-muted">Just now</span>
                            </a>
                        </li>
                        <li>
                            <a href="#">
                                <span class="notification-icon bg-success">
                                    <i class="fa fa-plus"></i>
                                </span>
                                <span class="m-left-xs">New user registration.</span>
                                <span class="time text-muted">2m ago</span>
                            </a>
                        </li>
                        <li>
                            <a href="#">
                                <span class="notification-icon bg-danger">
                                    <i class="fa fa-bolt"></i>
                                </span>
                                <span class="m-left-xs">Application error.</span>
                                <span class="time text-muted">5m ago</span>
                            </a>
                        </li>
                        <li>
                            <a href="#">
                                <span class="notification-icon bg-success">
                                    <i class="fa fa-usd"></i>
                                </span>
                                <span class="m-left-xs">2 items sold.</span>
                                <span class="time text-muted">1hr ago</span>
                            </a>
                        </li>
                        <li>
                            <a href="#">
                                <span class="notification-icon bg-success">
                                    <i class="fa fa-plus"></i>
                                </span>
                                <span class="m-left-xs">New user registration.</span>
                                <span class="time text-muted">1hr ago</span>
                            </a>
                        </li>
                        <li><a href="#">View all notifications</a></li>
                    </ul>
                </li>
                <li class="profile dropdown">
                    <a class="dropdown-toggle" data-toggle="dropdown" href="#">
                        <strong>John Doe</strong>
                        <span><i class="fa fa-chevron-down"></i></span>
                    </a>
                    <ul class="dropdown-menu">
                        <li>
                            <a class="clearfix" href="#">
                                <img src="img/user.jpg" alt="User Avatar">
                                <div class="detail">
                                    <strong>John Doe</strong>
                                    <p class="grey">John_Doe@email.com</p>
                                </div>
                            </a>
                        </li>
                        <li><a tabindex="-1" href="profile.html" class="main-link"><i class="fa fa-edit fa-lg"></i>Edit profile</a></li>
                        <li><a tabindex="-1" href="gallery.html" class="main-link"><i class="fa fa-picture-o fa-lg"></i>Photo Gallery</a></li>
                        <li><a tabindex="-1" href="#" class="theme-setting"><i class="fa fa-cog fa-lg"></i>Setting</a></li>
                        <li class="divider"></li>
                        <li><a tabindex="-1" class="main-link logoutConfirm_open" href="#logoutConfirm"><i class="fa fa-lock fa-lg"></i>Log out</a></li>
                    </ul>
                </li>
            </ul>
        </div>
        <!-- /top-nav-->

        <aside class="fixed skin-6">
            <div class="sidebar-inner scrollable-sidebar">
                <div class="size-toggle">
                    <a class="btn btn-sm" id="sizeToggle">
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </a>
                    <a class="btn btn-sm pull-right logoutConfirm_open" href="#logoutConfirm">
                        <i class="fa fa-power-off"></i>
                    </a>
                </div>
                <!-- /size-toggle -->
                <div class="user-block clearfix">
                    <img src="img/user.jpg" alt="User Avatar">
                    <div class="detail">
                        <strong>John Doe</strong><span class="badge badge-danger bounceIn animation-delay4 m-left-xs">4</span>
                        <ul class="list-inline">
                            <li><a href="profile.html">Profile</a></li>
                            <li><a href="inbox.html" class="no-margin">Inbox</a></li>
                        </ul>
                    </div>
                </div>
                <!-- /user-block -->
                <div class="search-block">
                    <div class="input-group">
                        <input type="text" class="form-control input-sm" placeholder="search here...">
                        <span class="input-group-btn">
                            <button class="btn btn-default btn-sm" type="button"><i class="fa fa-search"></i></button>
                        </span>
                    </div>
                    <!-- /input-group -->
                </div>
                <!-- /search-block -->
                <div class="main-menu">
                    <ul>
                        <li>
                            <a href="index.html">
                                <span class="menu-icon">
                                    <i class="fa fa-desktop fa-lg"></i>
                                </span>
                                <span class="text">Dashboard
								</span>
                                <span class="menu-hover"></span>
                            </a>
                        </li>
                        <li class="openable">
                            <a href="#">
                                <span class="menu-icon">
                                    <i class="fa fa-file-text fa-lg"></i>
                                </span>
                                <span class="text">Page
								</span>
                                <span class="menu-hover"></span>
                            </a>
                            <ul class="submenu">
                                <li><a href="login.html"><span class="submenu-label">Sign in</span></a></li>
                                <li><a href="register.html"><span class="submenu-label">Sign up</span></a></li>
                                <li><a href="lock_screen.html"><span class="submenu-label">Lock Screen</span></a></li>
                                <li><a href="profile.html"><span class="submenu-label">Profile</span></a></li>
                                <li><a href="blog.html"><span class="submenu-label">Blog</span></a></li>
                                <li><a href="single_post.html"><span class="submenu-label">Single Post</span></a></li>
                                <li><a href="landing.html"><span class="submenu-label">Landing</span></a></li>
                                <li><a href="search_result.html"><span class="submenu-label">Search Result</span></a></li>
                                <li><a href="chat.html"><span class="submenu-label">Chat Room</span></a></li>
                                <li><a href="movie.html"><span class="submenu-label">Movie Gallery</span></a></li>
                                <li><a href="pricing.html"><span class="submenu-label">Pricing</span></a></li>
                                <li><a href="invoice.html"><span class="submenu-label">Invoice</span></a></li>
                                <li><a href="faq.html"><span class="submenu-label">FAQ</span></a></li>
                                <li><a href="contact.html"><span class="submenu-label">Contact</span></a></li>
                                <li><a href="error404.html"><span class="submenu-label">Error404</span></a></li>
                                <li><a href="error500.html"><span class="submenu-label">Error500</span></a></li>
                                <li><a href="blank.html"><span class="submenu-label">Blank</span></a></li>
                            </ul>
                        </li>
                        <li class="active openable open">
                            <a href="#">
                                <span class="menu-icon">
                                    <i class="fa fa-tag fa-lg"></i>
                                </span>
                                <span class="text">Component
								</span>
                                <span class="badge badge-success bounceIn animation-delay5">9</span>
                                <span class="menu-hover"></span>
                            </a>
                            <ul class="submenu">
                                <li><a href="ui_element.html"><span class="submenu-label">UI Features</span></a></li>
                                <li><a href="button.html"><span class="submenu-label">Button & Icons</span></a></li>
                                <li><a href="tab.html"><span class="submenu-label">Tab</span></a></li>
                                <li><a href="nestable_list.html"><span class="submenu-label">Nestable List</span></a></li>
                                <li><a href="calendar.html"><span class="submenu-label">Calendar</span></a></li>
                                <li><a href="table.html"><span class="submenu-label">Table</span></a></li>
                                <li><a href="widget.html"><span class="submenu-label">Widget</span></a></li>
                                <li class="active"><a href="form_element.html"><span class="submenu-label">Form Element</span></a></li>
                                <li><a href="form_wizard.html"><span class="submenu-label">Form Wizard</span></a></li>
                            </ul>
                        </li>
                        <li>
                            <a href="timeline.html">
                                <span class="menu-icon">
                                    <i class="fa fa-clock-o fa-lg"></i>
                                </span>
                                <span class="text">Timeline
								</span>
                                <span class="menu-hover"></span>
                            </a>
                        </li>
                        <li>
                            <a href="gallery.html">
                                <span class="menu-icon">
                                    <i class="fa fa-picture-o fa-lg"></i>
                                </span>
                                <span class="text">Gallery
								</span>
                                <span class="menu-hover"></span>
                            </a>
                        </li>
                        <li>
                            <a href="inbox.html">
                                <span class="menu-icon">
                                    <i class="fa fa-envelope fa-lg"></i>
                                </span>
                                <span class="text">Inbox
								</span>
                                <span class="badge badge-danger bounceIn animation-delay6">4</span>
                                <span class="menu-hover"></span>
                            </a>
                        </li>
                        <li>
                            <a href="email_selection.html">
                                <span class="menu-icon">
                                    <i class="fa fa-tasks fa-lg"></i>
                                </span>
                                <span class="text">Email Template
								</span>
                                <small class="badge badge-warning bounceIn animation-delay7">New</small>
                                <span class="menu-hover"></span>
                            </a>
                        </li>
                        <li class="openable">
                            <a href="#">
                                <span class="menu-icon">
                                    <i class="fa fa-magic fa-lg"></i>
                                </span>
                                <span class="text">Multi-Level menu
								</span>
                                <span class="menu-hover"></span>
                            </a>
                            <ul class="submenu">
                                <li class="openable">
                                    <a href="#">
                                        <span class="submenu-label">menu 2.1</span>
                                        <span class="badge badge-danger bounceIn animation-delay1 pull-right">3</span>
                                    </a>
                                    <ul class="submenu third-level">
                                        <li><a href="#"><span class="submenu-label">menu 3.1</span></a></li>
                                        <li><a href="#"><span class="submenu-label">menu 3.2</span></a></li>
                                        <li class="openable">
                                            <a href="#">
                                                <span class="submenu-label">menu 3.3</span>
                                                <span class="badge badge-danger bounceIn animation-delay1 pull-right">2</span>
                                            </a>
                                            <ul class="submenu fourth-level">
                                                <li><a href="#"><span class="submenu-label">menu 4.1</span></a></li>
                                                <li><a href="#"><span class="submenu-label">menu 4.2</span></a></li>
                                            </ul>
                                        </li>
                                    </ul>
                                </li>
                                <li class="openable">
                                    <a href="#">
                                        <span class="submenu-label">menu 2.2</span>
                                        <span class="badge badge-success bounceIn animation-delay2 pull-right">3</span>
                                    </a>
                                    <ul class="submenu third-level">
                                        <li class="openable">
                                            <a href="#">
                                                <span class="submenu-label">menu 3.1</span>
                                                <span class="badge badge-success bounceIn animation-delay1 pull-right">2</span>
                                            </a>
                                            <ul class="submenu fourth-level">
                                                <li><a href="#"><span class="submenu-label">menu 4.1</span></a></li>
                                                <li><a href="#"><span class="submenu-label">menu 4.2</span></a></li>
                                            </ul>
                                        </li>
                                        <li><a href="#"><span class="submenu-label">menu 3.2</span></a></li>
                                        <li><a href="#"><span class="submenu-label">menu 3.3</span></a></li>
                                    </ul>
                                </li>
                            </ul>
                        </li>
                    </ul>

                    <div class="alert alert-info">
                        Welcome to Endless Admin. Do not forget to check all my pages. 
				
                    </div>
                </div>
                <!-- /main-menu -->
            </div>
            <!-- /sidebar-inner scrollable-sidebar -->
        </aside>

        <div id="main-container">
            <div id="breadcrumb">
                <ul class="breadcrumb">
                    <li><i class="fa fa-home"></i><a href="index.html">Home</a></li>
                    <li>Form</li>
                    <li class="active">Form Element</li>
                </ul>
            </div>
            <!--breadcrumb-->
            <div class="padding-md">
                <div class="row">
                    <div class="col-md-6">
                        <div class="panel panel-default">
                            <div class="panel-heading">Simple Form</div>
                            <div class="panel-body">
                                <form>
                                    <div class="form-group">
                                        <label for="exampleInputEmail1">Email address</label>
                                        <input type="email" class="form-control input-sm" id="exampleInputEmail1" placeholder="Enter email">
                                    </div>
                                    <!-- /form-group -->
                                    <div class="form-group">
                                        <label for="exampleInputPassword1">Password</label>
                                        <input type="password" class="form-control input-sm" id="exampleInputPassword1" placeholder="Password">
                                    </div>
                                    <!-- /form-group -->
                                    <div class="form-group">
                                        <label class="label-checkbox">
                                            <input type="checkbox">
                                            <span class="custom-checkbox"></span>
                                            Remember me
									
                                        </label>
                                    </div>
                                    <!-- /form-group -->
                                    <button type="submit" class="btn btn-success btn-sm">Submit</button>
                                </form>
                            </div>
                        </div>
                        <!-- /panel -->
                    </div>
                    <!-- /.col -->
                    <div class="col-md-6">
                        <div class="panel panel-default">
                            <div class="panel-heading">Horizontal Form</div>
                            <div class="panel-body">
                                <form class="form-horizontal">
                                    <div class="form-group">
                                        <label for="inputEmail1" class="col-lg-2 control-label">Email</label>
                                        <div class="col-lg-10">
                                            <input type="email" class="form-control input-sm" id="inputEmail1" placeholder="Email">
                                        </div>
                                        <!-- /.col -->
                                    </div>
                                    <!-- /form-group -->
                                    <div class="form-group">
                                        <label for="inputPassword1" class="col-lg-2 control-label">Password</label>
                                        <div class="col-lg-10">
                                            <input type="password" class="form-control input-sm" id="inputPassword1" placeholder="Password">
                                        </div>
                                        <!-- /.col -->
                                    </div>
                                    <!-- /form-group -->
                                    <div class="form-group">
                                        <div class="col-lg-offset-2 col-lg-10">
                                            <label class="label-checkbox">
                                                <input type="checkbox">
                                                <span class="custom-checkbox"></span>
                                                Remember me
										
                                            </label>
                                        </div>
                                        <!-- /.col -->
                                    </div>
                                    <!-- /form-group -->
                                    <div class="form-group">
                                        <div class="col-lg-offset-2 col-lg-10">
                                            <button type="submit" class="btn btn-success btn-sm">Sign in</button>
                                        </div>
                                        <!-- /.col -->
                                    </div>
                                    <!-- /form-group -->
                                </form>
                            </div>
                        </div>
                        <!-- /panel -->
                    </div>
                    <!-- /.col -->
                </div>
                <!-- /.row -->
                <div class="panel panel-default">
                    <div class="panel-heading">Inline form</div>
                    <div class="panel-body">
                        <form class="form-inline no-margin">
                            <div class="form-group">
                                <label class="sr-only">Email address</label>
                                <input type="text" class="form-control input-sm" placeholder="Email Address">
                            </div>
                            <!-- /form-group -->
                            <div class="form-group">
                                <label class="sr-only">Password</label>
                                <input type="password" class="form-control input-sm" placeholder="Password">
                            </div>
                            <!-- /form-group -->
                            <div class="checkbox">
                                <label class="label-checkbox">
                                    <input type="checkbox" checked />
                                    <span class="custom-checkbox"></span>
                                    Remember me<br />
                                </label>
                            </div>
                            <!-- /checkbox -->
                            <button type="submit" class="btn btn-sm btn-success">Sign in</button>
                        </form>
                    </div>
                </div>
                <!-- /panel -->
                <div class="panel panel-default">
                    <div class="panel-heading">Search form</div>
                    <div class="panel-body">
                        <form class="form-inline no-margin">
                            <div class="row">
                                <div class="col-md-5">
                                    <div class="input-group">
                                        <input type="text" class="form-control input-sm">
                                        <div class="input-group-btn">
                                            <button type="button" class="btn btn-sm btn-success" tabindex="-1">Search</button>
                                            <button type="button" class="btn btn-sm btn-success dropdown-toggle" data-toggle="dropdown" tabindex="-1">
                                                Options
							              
                                            </button>
                                            <ul class="dropdown-menu pull-right" role="menu">
                                                <li><a href="#">Action</a></li>
                                                <li><a href="#">Another action</a></li>
                                                <li><a href="#">Something else here</a></li>
                                                <li class="divider"></li>
                                                <li><a href="#">Separated link</a></li>
                                            </ul>
                                        </div>
                                        <!-- /input-group-btn -->
                                    </div>
                                    <!-- /input-group -->
                                </div>
                                <!-- /.col -->
                            </div>
                            <!-- /.row -->
                        </form>
                    </div>
                </div>
                <!-- /panel -->
                <div class="panel panel-default">
                    <div class="panel-heading">
                        Form Element
					
                        <span class="pull-right">
                            <label class="label-checkbox inline">
                                <input type="checkbox" id="toggleLine" checked>
                                <span class="custom-checkbox"></span>
                                Toggle Line
						
                            </label>
                        </span>
                    </div>
                    <div class="panel-body">
                        <form id="formToggleLine" class="form-horizontal no-margin form-border">
                            <div class="form-group">
                                <label class="col-lg-2 control-label">Help Text</label>
                                <div class="col-lg-10">
                                    <input class="form-control" type="text" placeholder="input here...">
                                    <span class="help-block">A block of help text that breaks onto a new line and may extend beyond one line.</span>
                                </div>
                                <!-- /.col -->
                            </div>
                            <!-- /form-group -->
                            <div class="form-group">
                                <label class="col-lg-2 control-label">Disabled</label>
                                <div class="col-lg-10">
                                    <input class="form-control" type="text" placeholder="Disabled input here..." disabled>
                                </div>
                                <!-- /.col -->
                            </div>
                            <!-- /form-group -->
                            <div class="form-group">
                                <label class="col-lg-2 control-label">Password</label>
                                <div class="col-lg-10">
                                    <input class="form-control" type="password" placeholder="Password">
                                </div>
                                <!-- /.col -->
                            </div>
                            <!-- /form-group -->
                            <div class="form-group">
                                <label class="col-lg-2 control-label">Static Control</label>
                                <div class="col-lg-10">
                                    <p class="form-control-static">email@example.com</p>
                                </div>
                                <!-- /.col -->
                            </div>
                            <!-- /form-group -->
                            <div class="form-group">
                                <label class="col-lg-2 control-label">Textarea</label>
                                <div class="col-lg-10">
                                    <textarea class="form-control" rows="3"></textarea>
                                </div>
                                <!-- /.col -->
                            </div>
                            <!-- /form-group -->
                            <div class="form-group">
                                <label class="col-lg-2 control-label">Stacked Checkbox</label>
                                <div class="col-lg-10">
                                    <label class="label-checkbox">
                                        <input type="checkbox">
                                        <span class="custom-checkbox"></span>
                                        Option one is this and that be sure to include why it's great
								
                                    </label>
                                    <label class="label-checkbox">
                                        <input type="checkbox">
                                        <span class="custom-checkbox"></span>
                                        Option two can be something else and selecting it will deselect option one		
								
                                    </label>
                                </div>
                                <!-- /.col -->
                            </div>
                            <!-- /form-group -->
                            <div class="form-group">
                                <label class="col-lg-2 control-label">Inline Checkbox</label>
                                <div class="col-lg-10">
                                    <label class="label-checkbox inline">
                                        <input type="checkbox">
                                        <span class="custom-checkbox"></span>
                                        Checkbox1
								
                                    </label>
                                    <label class="label-checkbox inline">
                                        <input type="checkbox">
                                        <span class="custom-checkbox"></span>
                                        Checkbox2
								
                                    </label>
                                </div>
                                <!-- /.col -->
                            </div>
                            <!-- /form-group -->
                            <div class="form-group">
                                <label class="col-lg-2 control-label">Stacked Radio Button</label>
                                <div class="col-lg-10">
                                    <label class="label-radio">
                                        <input type="radio" name="stack-radio">
                                        <span class="custom-radio"></span>
                                        Option one is this and that be sure to include why it's great
								
                                    </label>
                                    <label class="label-checkbox">
                                        <input type="radio" name="stack-radio">
                                        <span class="custom-radio"></span>
                                        Option two can be something else and selecting it will deselect option one		
								
                                    </label>
                                </div>
                                <!-- /.col -->
                            </div>
                            <!-- /form-group -->
                            <div class="form-group">
                                <label class="col-lg-2 control-label">Inline Radio Button</label>
                                <div class="col-lg-10">
                                    <label class="label-radio inline">
                                        <input type="radio" name="inline-radio">
                                        <span class="custom-radio"></span>
                                        Option1
								
                                    </label>
                                    <label class="label-radio inline">
                                        <input type="radio" name="inline-radio">
                                        <span class="custom-radio"></span>
                                        Option2
								
                                    </label>
                                </div>
                                <!-- /.col -->
                            </div>
                            <!-- /form-group -->
                            <div class="form-group has-success">
                                <label class="col-lg-2 control-label">Input with success</label>
                                <div class="col-lg-10">
                                    <input class="form-control" type="text">
                                </div>
                                <!-- /.col -->
                            </div>
                            <!-- /form-group -->
                            <div class="form-group has-warning">
                                <label class="col-lg-2 control-label">Input with success</label>
                                <div class="col-lg-10">
                                    <input class="form-control" type="text">
                                </div>
                                <!-- /.col -->
                            </div>
                            <!-- /form-group -->
                            <div class="form-group has-error">
                                <label class="col-lg-2 control-label">Input with error</label>
                                <div class="col-lg-10">
                                    <input class="form-control" type="text">
                                </div>
                                <!-- /.col -->
                            </div>
                            <!-- /form-group -->
                            <div class="form-group">
                                <label class="col-lg-2 control-label">Select</label>
                                <div class="col-lg-10">
                                    <select class="form-control">
                                        <option>1</option>
                                        <option>2</option>
                                        <option>3</option>
                                        <option>4</option>
                                        <option>5</option>
                                    </select>
                                </div>
                                <!-- /.col -->
                            </div>
                            <!-- /form-group -->
                            <div class="form-group">
                                <label class="col-lg-2 control-label">Chosen Select</label>
                                <div class="col-lg-10">
                                    <select class="form-control chzn-select">
                                        <option>Alabama</option>
                                        <option>Alaska</option>
                                        <option>Arizona</option>
                                        <option>Arkansas</option>
                                        <option>California</option>
                                        <option>Colorado</option>
                                        <option>Connecticut</option>
                                        <option>Delaware</option>
                                        <option>District Of Columbia</option>
                                        <option>Florida</option>
                                        <option>Georgia</option>
                                        <option>Hawaii</option>
                                        <option>Idaho</option>
                                        <option>Illinois</option>
                                        <option>Indiana</option>
                                        <option>Iowa</option>
                                        <option>Kansas</option>
                                        <option>Kentucky</option>
                                        <option>Louisiana</option>
                                        <option>Maine</option>
                                        <option>Maryland</option>
                                        <option>Massachusetts</option>
                                        <option>Michigan</option>
                                        <option>Minnesota</option>
                                        <option>Mississippi</option>
                                        <option>Missouri</option>
                                        <option>Montana</option>
                                        <option>Nebraska</option>
                                        <option>Nevada</option>
                                        <option>New Hampshire</option>
                                        <option>New Jersey</option>
                                        <option>New Mexico</option>
                                        <option>New York</option>
                                        <option>North Carolina</option>
                                        <option>North Dakota</option>
                                        <option>Ohio</option>
                                        <option>Oklahoma</option>
                                        <option>Oregon</option>
                                        <option>Pennsylvania</option>
                                        <option>Rhode Island</option>
                                        <option>South Carolina</option>
                                        <option>South Dakota</option>
                                        <option>Tennessee</option>
                                        <option>Texas</option>
                                        <option>Utah</option>
                                        <option>Vermont</option>
                                        <option>Virginia</option>
                                        <option>Washington</option>
                                        <option>West Virginia</option>
                                        <option>Wisconsin</option>
                                        <option>Wyoming</option>
                                    </select>
                                </div>
                                <!-- /.col -->
                            </div>
                            <!-- /form-group -->
                            <div class="form-group">
                                <label class="col-lg-2 control-label">Multiple Select</label>
                                <div class="col-lg-10">
                                    <select multiple class="form-control">
                                        <option>1</option>
                                        <option>2</option>
                                        <option>3</option>
                                        <option>4</option>
                                        <option>5</option>
                                    </select>
                                </div>
                                <!-- /.col -->
                            </div>
                            <!-- /form-group -->
                            <div class="form-group">
                                <label class="col-lg-2 control-label">Chosen Multiple Select</label>
                                <div class="col-lg-10">
                                    <select multiple class="form-control chzn-select">
                                        <option>Alabama</option>
                                        <option>Alaska</option>
                                        <option>Arizona</option>
                                        <option>Arkansas</option>
                                        <option>California</option>
                                        <option>Colorado</option>
                                        <option>Connecticut</option>
                                        <option>Delaware</option>
                                        <option>District Of Columbia</option>
                                        <option>Florida</option>
                                        <option>Georgia</option>
                                        <option>Hawaii</option>
                                        <option>Idaho</option>
                                        <option>Illinois</option>
                                        <option>Indiana</option>
                                        <option>Iowa</option>
                                        <option>Kansas</option>
                                        <option>Kentucky</option>
                                        <option>Louisiana</option>
                                        <option>Maine</option>
                                        <option>Maryland</option>
                                        <option>Massachusetts</option>
                                        <option>Michigan</option>
                                        <option>Minnesota</option>
                                        <option>Mississippi</option>
                                        <option>Missouri</option>
                                        <option>Montana</option>
                                        <option>Nebraska</option>
                                        <option>Nevada</option>
                                        <option>New Hampshire</option>
                                        <option>New Jersey</option>
                                        <option>New Mexico</option>
                                        <option>New York</option>
                                        <option>North Carolina</option>
                                        <option>North Dakota</option>
                                        <option>Ohio</option>
                                        <option>Oklahoma</option>
                                        <option>Oregon</option>
                                        <option>Pennsylvania</option>
                                        <option>Rhode Island</option>
                                        <option>South Carolina</option>
                                        <option>South Dakota</option>
                                        <option>Tennessee</option>
                                        <option>Texas</option>
                                        <option>Utah</option>
                                        <option>Vermont</option>
                                        <option>Virginia</option>
                                        <option>Washington</option>
                                        <option>West Virginia</option>
                                        <option>Wisconsin</option>
                                        <option>Wyoming</option>
                                    </select>
                                </div>
                                <!-- /.col -->
                            </div>
                            <!-- /form-group -->
                            <div class="form-group">
                                <label class="col-lg-2 control-label">Height sizing</label>
                                <div class="col-lg-10">
                                    <input class="form-control input-lg" type="text" placeholder=".input-lg">
                                    <div class="seperator"></div>
                                    <input class="form-control" type="text" placeholder="Default input">
                                    <div class="seperator"></div>
                                    <input class="form-control input-sm" type="text" placeholder=".input-sm">
                                </div>
                                <!-- /.col -->
                            </div>
                            <!-- /form-group -->
                            <div class="form-group">
                                <label class="col-lg-2 control-label">Column sizing</label>
                                <div class="col-lg-10">
                                    <div class="row">
                                        <div class="col-lg-2">
                                            <input type="text" class="form-control" placeholder=".col-lg-2">
                                        </div>
                                        <!-- /.col -->
                                        <div class="col-lg-3">
                                            <input type="text" class="form-control" placeholder=".col-lg-3">
                                        </div>
                                        <!-- /.col -->
                                        <div class="col-lg-4">
                                            <input type="text" class="form-control" placeholder=".col-lg-4">
                                        </div>
                                        <!-- /.col -->
                                    </div>
                                    <!-- /.row -->
                                </div>
                                <!-- /.col -->
                            </div>
                            <!-- /form-group -->
                            <div class="form-group">
                                <label class="col-lg-2 control-label">Input Groups</label>
                                <div class="col-lg-10">
                                    <div class="input-group">
                                        <span class="input-group-addon">@</span>
                                        <input type="text" class="form-control" placeholder="Username">
                                    </div>
                                    <!-- /input-group -->
                                    <div class="seperator"></div>
                                    <div class="input-group">
                                        <input type="text" class="form-control">
                                        <span class="input-group-addon">.00</span>
                                    </div>
                                    <!-- /input-group -->
                                    <div class="seperator"></div>
                                    <div class="input-group">
                                        <span class="input-group-addon">$</span>
                                        <input type="text" class="form-control">
                                        <span class="input-group-addon">.00</span>
                                    </div>
                                    <!-- /input-group -->
                                    <div class="seperator"></div>
                                    <div class="input-group">
                                        <span class="input-group-addon">
                                            <label class="label-checkbox no-padding">
                                                <input type="checkbox">
                                                <span class="custom-checkbox"></span>
                                            </label>
                                        </span>
                                        <input type="text" class="form-control">
                                    </div>
                                    <!-- /input-group -->
                                    <div class="seperator"></div>
                                    <div class="input-group">
                                        <span class="input-group-addon">
                                            <label class="label-radio no-padding">
                                                <input type="radio">
                                                <span class="custom-radio"></span>
                                            </label>
                                        </span>
                                        <input type="text" class="form-control">
                                    </div>
                                    <!-- /input-group -->
                                </div>
                                <!-- /.col -->
                            </div>
                            <!-- /form-group -->
                            <div class="form-group">
                                <label class="col-lg-2 control-label">Button addons</label>
                                <div class="col-lg-10">
                                    <div class="input-group">
                                        <span class="input-group-btn">
                                            <button class="btn btn-default" type="button">Go!</button>
                                        </span>
                                        <input type="text" class="form-control">
                                    </div>
                                    <!-- /input-group -->
                                    <div class="seperator"></div>
                                    <div class="input-group">
                                        <input type="text" class="form-control">
                                        <span class="input-group-btn">
                                            <button class="btn btn-default" type="button">Go!</button>
                                        </span>
                                    </div>
                                    <!-- /input-group -->
                                    <div class="seperator"></div>
                                    <div class="input-group">
                                        <div class="input-group-btn">
                                            <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown">Action <span class="caret"></span></button>
                                            <ul class="dropdown-menu">
                                                <li><a href="#">Action</a></li>
                                                <li><a href="#">Another action</a></li>
                                                <li><a href="#">Something else here</a></li>
                                                <li class="divider"></li>
                                                <li><a href="#">Separated link</a></li>
                                            </ul>
                                        </div>
                                        <!-- /btn-group -->
                                        <input type="text" class="form-control">
                                    </div>
                                    <!-- /input-group -->
                                    <div class="seperator"></div>
                                    <div class="input-group">
                                        <input type="text" class="form-control">
                                        <div class="input-group-btn">
                                            <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown">Action <span class="caret"></span></button>
                                            <ul class="dropdown-menu pull-right">
                                                <li><a href="#">Action</a></li>
                                                <li><a href="#">Another action</a></li>
                                                <li><a href="#">Something else here</a></li>
                                                <li class="divider"></li>
                                                <li><a href="#">Separated link</a></li>
                                            </ul>
                                        </div>
                                        <!-- /btn-group -->
                                    </div>
                                    <!-- /input-group -->
                                </div>
                                <!-- /.col -->
                            </div>
                            <!-- /form-group -->
                            <div class="form-group">
                                <label class="col-lg-2 control-label">Segmented buttons</label>
                                <div class="col-lg-10">
                                    <div class="input-group">
                                        <div class="input-group-btn">
                                            <button type="button" class="btn btn-default" tabindex="-1">Action</button>
                                            <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown" tabindex="-1">
                                                <span class="caret"></span>
                                            </button>
                                            <ul class="dropdown-menu" role="menu">
                                                <li><a href="#">Action</a></li>
                                                <li><a href="#">Another action</a></li>
                                                <li><a href="#">Something else here</a></li>
                                                <li class="divider"></li>
                                                <li><a href="#">Separated link</a></li>
                                            </ul>
                                        </div>
                                        <input type="text" class="form-control">
                                    </div>
                                    <!-- /input-group -->
                                    <div class="seperator"></div>
                                    <div class="input-group">
                                        <input type="text" class="form-control">
                                        <div class="input-group-btn">
                                            <button type="button" class="btn btn-default" tabindex="-1">Action</button>
                                            <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown" tabindex="-1">
                                                <span class="caret"></span>
                                            </button>
                                            <ul class="dropdown-menu pull-right" role="menu">
                                                <li><a href="#">Action</a></li>
                                                <li><a href="#">Another action</a></li>
                                                <li><a href="#">Something else here</a></li>
                                                <li class="divider"></li>
                                                <li><a href="#">Separated link</a></li>
                                            </ul>
                                        </div>
                                    </div>
                                    <!-- /input-group -->
                                </div>
                                <!-- /.col -->
                            </div>
                            <!-- /form-group -->

                            <div class="form-group">
                                <label class="col-lg-2 control-label">Tags</label>
                                <div class="col-lg-10">
                                    <input type="text" class="tag-demo1" value="foo,bar,baz">
                                </div>
                                <!-- /.col -->
                            </div>
                            <!-- /form-group -->
                            <div class="form-group">
                                <label class="col-lg-2 control-label">WYSIHTML5</label>
                                <div class="col-lg-10">
                                    <textarea id="wysihtml5-textarea" placeholder="Enter your text ..." class="form-control" rows="6"></textarea>
                                </div>
                                <!-- /.col -->
                            </div>
                            <!-- /form-group -->
                            <div class="form-group">
                                <label class="col-lg-2 control-label">Date Picker</label>
                                <div class="col-lg-10">
                                    <div class="input-group">
                                        <input type="text" value="06/10/2013" class="datepicker form-control">
                                        <span class="input-group-addon"><i class="fa fa-calendar"></i></span>
                                    </div>
                                </div>
                                <!-- /.col -->
                            </div>
                            <!-- /form-group -->
                            <div class="form-group">
                                <label class="col-lg-2 control-label">Time Picker</label>
                                <div class="col-lg-10">
                                    <div class="input-group bootstrap-timepicker">
                                        <input class="timepicker form-control" type="text" />
                                        <span class="input-group-addon"><i class="fa fa-clock-o"></i></span>
                                    </div>
                                </div>
                                <!-- /.col -->
                            </div>
                            <!-- /form-group -->
                            <div class="form-group">
                                <label class="col-lg-2 control-label">Slider</label>
                                <div class="col-lg-10">
                                    <input type="text" class="form-control" value="4" id="sl1" data-slider-handle="round">
                                </div>
                                <!-- /.col -->
                            </div>
                            <!-- /form-group -->
                            <div class="form-group">
                                <label class="col-lg-2 control-label">Range Slider</label>
                                <div class="col-lg-10">
                                    <input type="text" class="form-control" value="" data-slider-min="10" data-slider-max="1000" data-slider-step="5" data-slider-value="[150,650]" id="sl2">
                                </div>
                                <!-- /.col -->
                            </div>
                            <!-- /form-group -->
                            <div class="form-group">
                                <label class="col-lg-2 control-label">Vertical Slider</label>
                                <div class="col-lg-10">
                                    <input type="text" class="form-control" id="sl3" data-slider-value="-13" data-slider-min="-20" data-slider-max="20" data-slider-handle="round" data-slider-orientation="vertical">
                                    <input type="text" class="form-control" id="sl4" data-slider-value="-3" data-slider-min="-20" data-slider-max="20" data-slider-handle="round" data-slider-orientation="vertical">
                                    <input type="text" class="form-control" id="sl5" data-slider-value="16" data-slider-min="-20" data-slider-max="20" data-slider-handle="round" data-slider-orientation="vertical">
                                </div>
                                <!-- /.col -->
                            </div>
                            <!-- /form-group -->
                            <div class="form-group">
                                <label class="col-lg-2 control-label">Form in modal</label>
                                <div class="col-lg-10">
                                    <a href="#formModal" class="btn btn-success" data-toggle="modal">Form In Modal</a>
                                </div>
                                <!-- /.col -->
                            </div>
                            <!-- /form-group -->
                        </form>
                    </div>
                </div>
                <!-- /panel -->
                <div class="panel panel-default">
                    <div class="panel-heading">
                        File Upload
				
                    </div>
                    <div class="panel-body">
                        <fieldset class="form-horizontal form-border">
                            <div class="form-group">
                                <label class="col-lg-2 control-label">Default</label>
                                <div class="col-lg-10">
                                    <input type="file">
                                </div>
                                <!-- /.col -->
                            </div>
                            <!-- /form-group -->
                            <div class="form-group">
                                <label class="control-label col-lg-2">Custom</label>
                                <div class="col-lg-10">
                                    <div class="upload-file">
                                        <input type="file" id="upload-demo" class="upload-demo">
                                        <label data-title="Select file" for="upload-demo">
                                            <span data-title="No file selected..."></span>
                                        </label>
                                    </div>
                                </div>
                                <!-- /.col -->
                            </div>
                            <!-- /form-group -->
                            <div class="form-group">
                                <label class="control-label col-lg-2">Dropzone</label>
                                <div class="col-lg-10">
                                    <div class="alert">
                                        <i class="fa fa-warning"></i><span class="m-left-xs">This is just a demo dropzone. Uploaded files are not stored.</span>
                                    </div>
                                    <form action="." class="dropzone">
                                        <div class="fallback">
                                            <input name="file" type="file" multiple />
                                        </div>
                                    </form>
                                </div>
                                <!-- /.col -->
                            </div>
                            <!-- /form-group -->
                        </fieldset>
                    </div>
                </div>
                <!-- /panel -->
                <div class="panel panel-default">
                    <div class="panel-heading">
                        Mask Input
				
                    </div>
                    <div class="panel-body">
                        <form class="form-horizontal form-border">
                            <div class="form-group">
                                <label class="control-label col-lg-2 col-sm-2">Date</label>
                                <div class="col-lg-10 col-sm-10">
                                    <input id="date-mask" type="text" class="form-control input-sm date">
                                    <p class="help-block">99/99/9999</p>
                                </div>
                                <!-- /.col -->
                            </div>
                            <!-- /form-group -->
                            <div class="form-group">
                                <label class="control-label col-lg-2  col-sm-2">Phone</label>
                                <div class="col-lg-10  col-sm-10">
                                    <input id="phone-mask" type="text" class=" form-control input-sm phone">
                                    <p class="help-block">(999) 999-9999</p>
                                </div>
                                <!-- /.col -->
                            </div>
                            <!-- /form-group -->
                            <div class="form-group">
                                <label class="control-label col-lg-2  col-sm-2">SSN</label>
                                <div class="col-lg-10  col-sm-10">
                                    <input id="ssn-mask" type="text" class=" form-control input-sm ssn">
                                    <p class="help-block">999-99-9999</p>
                                </div>
                                <!-- /.col -->
                            </div>
                            <!-- /form-group -->
                            <div class="form-group">
                                <label class="control-label col-lg-2 col-sm-2">Eye script</label>
                                <div class="col-lg-10 col-sm-10">
                                    <input id="eyescript" type="text" class=" form-control input-sm eyescript">
                                    <p class="help-block">~9.99 ~9.99 999</p>
                                </div>
                                <!-- /.col -->
                            </div>
                            <!-- /form-group -->
                            <div class="form-group">
                                <label class="control-label col-lg-2 col-sm-2">Product key</label>
                                <div class="col-lg-10 col-sm-10">
                                    <input id="product-key" type="text" class=" form-control input-sm product-key">
                                    <p class="help-block">a*-999-a999</p>
                                </div>
                                <!-- /.col -->
                            </div>
                            <!-- /form-group -->
                        </form>
                    </div>
                </div>
                <!-- /panel -->
                <div class="panel panel-default">
                    <div class="panel-heading">
                        Draggable Multiselect
				
                    </div>
                    <div class="panel-body relative">
                        <select multiple="multiple" id="selectedBox1" class="select-box pull-left form-control">
                            <option value="1">Apple</option>
                            <option value="2">Banana</option>
                            <option value="3">Cola</option>
                            <option value="4">Dog</option>
                            <option value="5">Elephant</option>
                        </select>

                        <div class="select-box-option">
                            <a class="btn btn-sm btn-default" id="btnRemove">
                                <i class="fa fa-angle-left"></i>
                            </a>
                            <a class="btn btn-sm btn-default" id="btnSelect">
                                <i class="fa fa-angle-right"></i>
                            </a>
                            <div class="seperator"></div>
                            <a class="btn btn-sm btn-default" id="btnRemoveAll">
                                <i class="fa fa-angle-double-left"></i>
                            </a>
                            <a class="btn btn-sm btn-default" id="btnSelectAll">
                                <i class="fa fa-angle-double-right"></i>
                            </a>
                        </div>

                        <select multiple="multiple" id="selectedBox2" class="select-box pull-right form-control">
                            <option>Alabama</option>
                            <option>Montana</option>
                            <option>New Jersey</option>
                            <option>New York</option>
                            <option>Texas</option>
                        </select>
                    </div>
                </div>
                <!-- /panel -->
            </div>
            <!-- /.padding-md -->
        </div>
        <!-- /main-container -->

        <!-- /Modal -->
        <div class="modal fade" id="formModal">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        <h4>Modal with form</h4>
                    </div>
                    <div class="modal-body">
                        <form>
                            <div class="form-group">
                                <label>Username</label>
                                <input type="text" class="form-control input-sm" placeholder="Email Address">
                            </div>
                            <div class="form-group">
                                <label>Password</label>
                                <input type="password" class="form-control input-sm" placeholder="Password">
                            </div>
                            <div class="form-group">
                                <label class="label-checkbox">
                                    <input type="checkbox" class="regular-checkbox" />
                                    <span class="custom-checkbox"></span>
                                    Remember me
							
                                </label>
                            </div>
                            <div class="form-group text-right">
                                <a href="#" class="btn btn-success">Sign in</a>
                                <a href="#" class="btn btn-success">Sign up</a>
                            </div>
                        </form>
                    </div>
                </div>
                <!-- /.modal-content -->
            </div>
            <!-- /.modal-dialog -->
        </div>
        <!-- /.modal -->
    </div>
    <!-- /wrapper -->

    <a href="" id="scroll-to-top" class="hidden-print"><i class="fa fa-chevron-up"></i></a>

    <!-- Logout confirmation -->
    <div class="custom-popup width-100" id="logoutConfirm">
        <div class="padding-md">
            <h4 class="m-top-none">Do you want to logout?</h4>
        </div>

        <div class="text-center">
            <a class="btn btn-success m-right-sm" href="login.html">Logout</a>
            <a class="btn btn-danger logoutConfirm_close">Cancel</a>
        </div>
    </div>

    <!-- Le javascript
    ================================================== -->
    <!-- Placed at the end of the document so the pages load faster -->

    <!-- Jquery -->
    <script src="js/jquery-1.10.2.min.js"></script>

    <!-- Bootstrap -->
    <script src="bootstrap/js/bootstrap.min.js"></script>

    <!-- Chosen -->
    <script src='js/chosen.jquery.min.js'></script>

    <!-- Mask-input -->
    <script src='js/jquery.maskedinput.min.js'></script>

    <!-- Datepicker -->
    <script src='js/bootstrap-datepicker.min.js'></script>

    <!-- Timepicker -->
    <script src='js/bootstrap-timepicker.min.js'></script>

    <!-- Slider -->
    <script src='js/bootstrap-slider.min.js'></script>

    <!-- Tag input -->
    <script src='js/jquery.tagsinput.min.js'></script>

    <!-- WYSIHTML5 -->
    <script src='js/wysihtml5-0.3.0.min.js'></script>
    <script src='js/uncompressed/bootstrap-wysihtml5.js'></script>

    <!-- Dropzone -->
    <script src='js/dropzone.min.js'></script>

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
    <script src="js/endless/endless_form.js"></script>
    <script src="js/endless/endless.js"></script>

</body>
</html>
