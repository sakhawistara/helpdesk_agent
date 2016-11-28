<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/HTML/Ticket.Master" CodeBehind="MasterBackup.aspx.vb" Inherits="ICC.MasterBackup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="main-menu">
        <ul>
            <li id="div_menu_dashboard" runat="server" visible="false">
                <a href="dashboard.aspx?page=dashboard">
                    <span class="menu-icon">
                        <i class="fa fa-dashboard"></i>
                    </span>
                    <span class="text">Dashboard
                    </span>
                    <span class="menu-hover"></span>
                </a>
            </li>
            <li class="openable open" id="div_menu_master_table" runat="server">
                <a id="A1" href="#" runat="server">
                    <span class="menu-icon">
                        <i class="fa fa-th fa-lg"></i>
                    </span>
                    <span class="text">Master Table
                    </span>
                    <span class="menu-hover"></span>
                </a>
                <ul class="submenu">
                    <li id="div_master_Transaction_Type" runat="server" visible="false"><a href="Transaction_Type.aspx?page=mst_tt"><span class="submenu-label">Transaction Type</span></a></li>
                    <li id="div_master_calltypeone" runat="server" visible="false"><a href="calltype_one.aspx?page=mst_ctone" id="a_brand" runat="server"><span class="submenu-label">Brand</span></a></li>
                    <li id="div_master_calltypetwo" runat="server" visible="false"><a href="calltype_two.aspx?page=mst_cttwo"><span class="submenu-label">Product</span></a></li>
                    <li id="div_master_calltypetre" runat="server" visible="false"><a href="calltype_tre.aspx?page=mst_cttre"><span class="submenu-label">Problem</span></a></li>
                    <li id="div_master_sourcetype" runat="server" visible="false"><a href="sourcetype.aspx?page=mst_st"><span class="submenu-label">Source Type</span></a></li>
                    <li id="div_master_grouptype" runat="server" visible="false"><a href="grouptype.aspx?page=mst_gt"><span class="submenu-label">Group Type</span></a></li>
                    <li id="div_master_status" runat="server" visible="false"><a href="status.aspx?page=mst_ss"><span class="submenu-label">Status</span></a></li>
                    <li id="div_master_karyawan" runat="server" visible="false"><a href="karyawan.aspx?page=mst_ky"><span class="submenu-label">Data Karyawan</span></a></li>
                    <li id="div_master_email_alert" runat="server" visible="false"><a href="email_alert.aspx?page=mst_eal"><span class="submenu-label">Email Alert</span></a></li>
                    <li id="div_master_email_address" runat="server" visible="false"><a href="email_address.aspx?page=mst_ead"><span class="submenu-label">Email Address</span></a></li>
                </ul>
            </li>
            <li id="div_menu_customer" runat="server" visible="false">
                <a href="customer.aspx?page=customer">
                    <span class="menu-icon">
                        <i class="fa fa-user"></i>
                    </span>
                    <span class="text">Customer
                    </span>
                    <span class="menu-hover"></span>
                </a>
            </li>

            <li id="div_menu_todolist" runat="server" visible="false">
                <a href="inbox.aspx?page=todolist">
                    <span class="menu-icon">
                        <i class="fa fa-list-ul fa-lg"></i>
                    </span>
                    <span class="text">Todolist
                    </span>
                    <span class="menu-hover"></span>
                </a>
            </li>
            <li class="openable" id="div_menu_channel" runat="server" visible="false">
                <a href="#">
                    <span class="menu-icon">
                        <i class="fa fa-desktop fa-lg"></i>
                    </span>
                    <span class="text">Channel
                    </span>
                    <span class="menu-hover"></span>
                </a>
                <ul class="submenu">
                    <li class="openable" id="div_channel_twitter" runat="server">
                        <a href="#">
                            <span class="submenu-label">Twitter</span>
                            <span class="badge badge-success bounceIn animation-delay2 pull-right">2</span>
                        </a>
                        <ul class="submenu third-level">
                            <li id="div_twitter_history" runat="server">

                                <a href="alltw.aspx?page=twt_hs">
                                    <span class="submenu-label">Data Twitter</span>
                                </a>
                                <a href="twitter_keyword.aspx?page=twt_hs">
                                    <span class="submenu-label">Twitter History</span>
                                    <span class="badge badge-success bounceIn animation-delay1 pull-right">10</span>
                                </a>
                            </li>
                            <li id="div_twitter_keyword_setting" runat="server">
                                <a href="twitter_keyword.aspx?page=twt_ks">
                                    <span class="submenu-label">Keyword Setting</span>
                                    <span class="badge badge-success bounceIn animation-delay1 pull-right">10</span>
                                </a>
                            </li>
                        </ul>
                    </li>
                    <li class="openable" id="div_channel_facebook" runat="server">
                        <a href="#">
                            <span class="submenu-label">Facebook</span>
                            <span class="badge badge-success bounceIn animation-delay2 pull-right">2</span>
                        </a>
                        <ul class="submenu third-level">
                            <li id="div_facebook_history" runat="server">
                                <a href="allfb.aspx?page=fcb_hs">
                                    <span class="submenu-label">Data Facebook</span>
                                </a>
                                <a href="twitter_keyword.aspx?page=fcb_hs">
                                    <span class="submenu-label">Facebook History</span>
                                    <span class="badge badge-success bounceIn animation-delay1 pull-right">10</span>
                                </a></li>
                            <li id="div_facebook_keyword_setting" runat="server">
                                <a href="facebook_keyword.aspx?page=fcb_ks">
                                    <span class="submenu-label">Keyword Setting</span>
                                    <span class="badge badge-success bounceIn animation-delay1 pull-right">10</span>
                                </a>
                            </li>
                        </ul>
                    </li>
                    <li id="div_channel_email" runat="server">
                        <a href="inbox_email.aspx">
                            <span class="submenu-label">Email</span>
                            <span class="badge badge-success bounceIn animation-delay2 pull-right">2</span>
                        </a>
                        <%-- <ul class="submenu third-level">
                                            <li>
                                                <a href="inbox_email.aspx">
                                                    <span class="submenu-label">Inbox</span>
                                                    <span class="badge badge-success bounceIn animation-delay1 pull-right">2</span>
                                                </a>

                                            </li>
                                            <li>
                                                <a href="#">
                                                    <span class="submenu-label">Sent</span>
                                                    <span class="badge badge-success bounceIn animation-delay1 pull-right">0</span>
                                                </a>

                                            </li>
                                            <li>
                                                <a href="#">
                                                    <span class="submenu-label">Draft</span>
                                                    <span class="badge badge-success bounceIn animation-delay1 pull-right">20</span>
                                                </a>

                                            </li>
                                            <li>
                                                <a href="#">
                                                    <span class="submenu-label">Spam</span>
                                                    <span class="badge badge-success bounceIn animation-delay1 pull-right">10</span>
                                                </a>
                                            </li>
                                        </ul>--%>
                    </li>
                    <li id="div_channel_sms" runat="server">
                        <a href="inbox_email.aspx">
                            <span class="submenu-label">Sms</span>
                            <span class="badge badge-success bounceIn animation-delay2 pull-right">2</span>
                        </a>
                        <%-- <a href="#">
                                            <span class="submenu-label">Sms</span>
                                            <span class="badge badge-success bounceIn animation-delay2 pull-right">1</span>
                                        </a>
                                        <ul class="submenu third-level">
                                            <li>
                                                <a href="inbox_sms.aspx">
                                                    <span class="submenu-label">Inbox</span>
                                                    <span class="badge badge-success bounceIn animation-delay1 pull-right">2</span>
                                                </a>

                                            </li>
                                            <li>
                                                <a href="#">
                                                    <span class="submenu-label">Sent</span>
                                                    <span class="badge badge-success bounceIn animation-delay1 pull-right">0</span>
                                                </a>

                                            </li>

                                        </ul>--%>
                    </li>
                    <li id="div_channel_fax" runat="server">
                        <a href="#">
                            <span class="submenu-label">Fax</span>
                            <span class="badge badge-success bounceIn animation-delay2 pull-right">3</span>
                        </a>
                    </li>
                    <li id="div_channel_chat" runat="server">
                        <a href="#">
                            <span class="submenu-label">Chat</span>
                            <span class="badge badge-success bounceIn animation-delay2 pull-right">2</span>
                        </a>
                    </li>
                    <li>
                        <a href="allpostMP.aspx">
                            <span class="submenu-label">Post Facebook & Twit</span>
                            <span class="badge badge-success bounceIn animation-delay2 pull-right">2</span>
                        </a>
                    </li>
                    <li class="openable" id="div_Sentimen" runat="server">
                        <a href="#">
                            <span class="submenu-label">Sentimen</span>
                            <span class="badge badge-success bounceIn animation-delay2 pull-right">2</span>
                        </a>
                        <ul class="submenu third-level">
                            <li id="Li2" runat="server">
                                <a href="inputsentimenMP.aspx">
                                    <span class="submenu-label">Input Sentimen</span>
                                    <span class="badge badge-success bounceIn animation-delay1 pull-right">10</span>
                                </a>
                            </li>
                            <li id="Li3" runat="server">
                                <a href="#">
                                    <span class="submenu-label">Setting Sentimen</span>
                                    <span class="badge badge-success bounceIn animation-delay1 pull-right">10</span>
                                </a>
                            </li>
                        </ul>
                    </li>
                </ul>

            </li>

            <li class="openable open" id="div_menu_ticket" runat="server">
                <a href="#">
                    <span class="menu-icon">
                        <i class="fa fa-file-text fa-lg"></i>
                    </span>
                    <span class="text">Ticket
                    </span>
                    <span class="menu-hover"></span>
                </a>
                <ul class="submenu">
                    <%--<li id="div_ticket_create" runat="server"><a href="utama.aspx?page=tk_create&new=1&channel=phone"><span class="submenu-label">Create Ticket</span></a></li>--%>
                    <li id="div_ticket_create" runat="server"><a href="utama_ticket.aspx"><span class="submenu-label">Create Ticket</span></a></li>
                    <li id="div_ticket_todolist" runat="server" visible="false"><a href="todolist.aspx?page=ticket"><span class="submenu-label">Ticket Todolist</span></a></li>
                    <li id="div_ticket_assign" runat="server" visible="false"><a href="assign.aspx?page=ticket"><span class="submenu-label">Ticket Assign</span></a></li>
                    <li id="div_ticket_history" runat="server"><a href="history_ticket.aspx?page=tk_history"><span class="submenu-label">Ticket History</span></a></li>
                </ul>
            </li>

            <li class="openable open" id="div_menu_Management_user" runat="server">
                <a href="#">
                    <span class="menu-icon">
                        <i class="fa fa-cogs fa-lg"></i>
                    </span>
                    <span class="text">Management User
                    </span>
                    <span class="menu-hover"></span>
                </a>
                <ul class="submenu">
                    <li id="div_user_add" runat="server"><a href="add_user.aspx?page=usr_add"><span class="submenu-label">Add User</span></a></li>
                    <li id="div_user_setting" runat="server"><a href="user_sett.aspx?page=usr_set"><span class="submenu-label">Setting User Previledge</span></a></li>
                </ul>
            </li>
            <li class="openable open" id="div_menu_report" runat="server">
                <a href="#">
                    <span class="menu-icon">
                        <i class="fa fa-hdd-o fa-lg"></i>
                    </span>
                    <span class="text">Reporting
                    </span>
                    <span class="menu-hover"></span>
                </a>
                <ul class="submenu">
                    <li id="div_report_satu" runat="server"><a href="utama.aspx?page=report"><span class="submenu-label">Report 1</span></a></li>
                    <li id="div_report_dua" runat="server"><a href="inbox_todolist.aspx?page=report"><span class="submenu-label">Report 2</span></a></li>
                </ul>
            </li>

            <li id="div_menu_grafik" runat="server">
                <a href="customer.aspx?page=grafik">
                    <span class="menu-icon">
                        <i class="fa fa-bar-chart-o"></i>
                    </span>
                    <span class="text">Grafik
                    </span>
                    <span class="menu-hover"></span>
                </a>
            </li>
            <li id="div_menu_knowledge" runat="server">
                <a href="customer.aspx?page=grafik">
                    <span class="menu-icon">
                        <i class="fa fa-lightbulb-o"></i>
                    </span>
                    <span class="text">Knowledge Base
                    </span>
                    <span class="menu-hover"></span>
                </a>
            </li>

        </ul>

        <div class="alert alert-info">
            Invision Astrindo Pratama				
        </div>
    </div>
</asp:Content>
