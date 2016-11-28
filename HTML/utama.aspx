<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/HTML/Ticket.Master" CodeBehind="utama.aspx.vb" Inherits="ICC.utama" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxCallback" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2 , Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
    <script type="text/javascript">
        function getKeyword(text) {
            //alert("MainContent_mCatID")
            document.getElementById('MainContent_mCatID').value = text;
            callbackPanelX.PerformCallback(text);
        }
        function getMcategory(text) {
            //alert("MainContent_mCatID")
            document.getElementById('MainContent_mCatID').value = text;
            callbackPanelX.PerformCallback(text);
        }
        function getMcategory1(text) {
            //alert(text)       
            document.getElementById('MainContent_mCatID').value = text;
            callbackPanelX.PerformCallback(text);
        }
        function getMcategory2(text) {
            //alert("ad")
            document.getElementById('MainContent_mCatID').value = text;
            callbackPanelX.PerformCallback(text);
        }
        function getMcategory3(text) {
            //alert("ad")
            document.getElementById('MainContent_mCatID').value = text;
            callbackPanelX.PerformCallback(text);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li><i class="fa fa-home"></i>&nbsp;<a href="dashboard.aspx">Home</a></li>
            <li class="active">
                <asp:HyperLink ID="hprlink" runat="server">
                    <asp:Label ID="lbl_link" runat="server"></asp:Label>
                </asp:HyperLink></li>
        </ul>
    </div>
    <asp:HiddenField runat="server" ID="mCatID" />
    <asp:HiddenField runat="server" ID="HD_Posisi" />
    <div class="padding-md">
        <div class="col-md-3 col-sm-3">
            <div class="row">
                <div class="panel-group" id="accordion">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapseOne">Customer Contact
							</a>
                            <div class="btn-group pull-right">
                                <button type="button" class="btn btn-default btn-xs dropdown-toggle" data-toggle="dropdown">
                                    <i class="fa fa-chevron-down"></i>
                                </button>
                            </div>
                        </div>
                        <div id="collapseOne" class="panel-collapse collapse in">
                            <div class="panel-body">
                                <address>
                                    <strong>
                                        <a href="customer.aspx?id=<%= Request.QueryString("NIK")%>">
                                            <asp:Label ID="lbl_nama_customer" runat="server"></asp:Label>
                                        </a></strong>
                                    <br />
                                    <asp:Label ID="lbl_alamat_perusahaan" runat="server"></asp:Label><br />
                                    <br />
                                    <div class="seperator"></div>
                                    <strong><span class="theme-font">
                                        <asp:Label ID="lbl_phone" runat="server"></asp:Label></span></strong><br />
                                    <strong><span class="theme-font">
                                        <asp:Label ID="lbl_email" runat="server"></asp:Label></span></strong>

                                </address>
                                <hr />
                                <h6>Get Social</h6>
                                <a href="inbox_facebook.aspx?account=<%= Request.QueryString("account")%>" class="social-connect tooltip-test facebook-hover pull-left m-right-xs" data-toggle="tooltip" data-original-title="Facebook"><i class="fa fa-facebook"></i></a>
                                <a href="inbox_twitter.aspx?account=<%= Request.QueryString("account")%>" class="social-connect tooltip-test twitter-hover pull-left m-right-xs" data-toggle="tooltip" data-original-title="Twitter"><i class="fa fa-twitter"></i></a>
                                <a href="#" class="social-connect tooltip-test google-plus-hover pull-left" data-toggle="tooltip" data-original-title="Google Plus"><i class="fa fa-google-plus"></i></a>
                                <a href="#" class="social-connect tooltip-test google-plus-hover pull-left" data-toggle="tooltip" data-original-title="Instagram"><i class="fa fa-instagram"></i></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <span class="pull-right"><a href="#ModalEmail" title="Edit Contact" class="social-connect tooltip-test google-plus-hover pull-left" data-toggle="modal" data-original-title="Instagram"><i class="fa fa-edit"></i></a></span>
                            </div>
                        </div>
                    </div>
                    <!-- /panel -->
                    <div class="panel panel-default" runat="server" id="div_properties">
                        <div class="panel-heading">
                            <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapseTwo">Ticket Properties
								</a>
                            <div class="btn-group pull-right">
                                <button type="button" class="btn btn-default btn-xs dropdown-toggle" data-toggle="dropdown">
                                    <i class="fa fa-chevron-down"></i>
                                </button>
                            </div>
                        </div>
                        <div id="collapseTwo" class="panel-collapse collapse in">
                            <div class="panel-body">
                                <dx:aspxcallbackpanel id="callbackPanelX" clientinstancename="callbackPanelX"
                                    runat="server" width="0%" height="0" rendermode="Table">
                    <PanelCollection>
                        <dx:PanelContent ID="PanelContent1" runat="server">
                               <asp:HiddenField ID="IDKamus" runat="server" />
                                <asp:HiddenField ID="hd_nik" runat="server" />                                   
                                  Source Type
                                    <dx:ASPxComboBox ID="cmb_source_type" Height="30px" runat="server" Theme="MetropolisBlue" Width="200px"
                                        DataSourceID="sql_source_type" TextField="Name" ValueField="TicketIDCode" CssClass="form-control chzn-select">
                                        <Columns>
                                            <dx:ListBoxColumn Caption="TicketIDCode" FieldName="ID" Width="80px" Visible="false" />
                                            <dx:ListBoxColumn Caption="Source Name" FieldName="Name" Width="150px" />
                                        </Columns>
                                    </dx:ASPxComboBox>
                                <asp:RequiredFieldValidator ID="rqr_source_type" ControlToValidate="cmb_source_type" ForeColor="Red"
                                                        runat="server" Display="Dynamic" Text="* Not Empty" ValidationGroup="Btn_Simpan"
                                                        ErrorMessage="Please enter a value."></asp:RequiredFieldValidator>
                                <asp:SqlDataSource ID="sql_source_type" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
                                <div class="seperator"></div> 
                                Group Type
                                    <dx:ASPxComboBox ID="cmb_group_type" Height="30px" runat="server" Theme="MetropolisBlue" Width="200px" TextFormatString="{0}" 
                                        DataSourceID="sql_group_type" TextField="GroupName" ValueField="GroupCode" CssClass="form-control chzn-select">
                                        <Columns>
                                            <dx:ListBoxColumn Caption="GroupCode" FieldName="GroupCode" Width="80px" Visible="false" />
                                            <dx:ListBoxColumn Caption="Group Name" FieldName="GroupName" Width="150px" />
                                        </Columns>
                                    </dx:ASPxComboBox>
                                <asp:RequiredFieldValidator ID="rqr_group_type" ControlToValidate="cmb_group_type" ForeColor="Red"
                                                        runat="server" Display="Dynamic" Text="* Not Empty" ValidationGroup="Btn_Simpan"
                                                        ErrorMessage="Please enter a value."></asp:RequiredFieldValidator>
                                <asp:SqlDataSource ID="sql_group_type" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
                                <div class="seperator"></div>
                               <div id="div_sosmed" runat="server">

                               </div>
                            <div id="div_ticket" runat="server">
                                  Transaction Type
                                    <dx:ASPxComboBox ID="Category" runat="server" AutoPostBack="false" Height="30px" TextField="Name" IncrementalFilteringMode="Contains" EnableSynchronization="false" CssClass="form-control chzn-select"
                                ValueField="CategoryID" DataSourceID="SourceCategori" Width="200px" TextFormatString="{1}" Theme="MetropolisBlue">
                                <ClientSideEvents SelectedIndexChanged="function(s, e) {getMcategory1(s.GetSelectedItem().texts[0]);}" />
                                <Columns>
                                    <dx:ListBoxColumn Caption="ID" FieldName="CategoryID" Width="80px" />
                                    <dx:ListBoxColumn Caption="Jenis Transaksi" FieldName="Name" Width="150px" />
                                </Columns>
                                <ItemStyle>
                                    <HoverStyle BackColor="#0076c4" ForeColor="#ffffff">
                                    </HoverStyle>
                                </ItemStyle>
                            </dx:ASPxComboBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="cmb_group_type" ForeColor="Red"
                                                        runat="server" Display="Dynamic" Text="* Not Empty" ValidationGroup="Btn_Simpan"
                                                        ErrorMessage="Please enter a value."></asp:RequiredFieldValidator>
                            <asp:HiddenField runat="server" ID="CategoryHidden" />
                                <div class="seperator"></div>
                                Problem
                                    <dx:ASPxComboBox ID="SubCategoryIII" runat="server" AutoPostBack="false" Height="30px" TextField="SubName" Theme="MetropolisBlue" CssClass="form-control chzn-select"
                                ValueField="SubCategory3ID" DataSourceID="SourceCategoriIII" ItemStyle-HoverStyle-BackColor="#F37021"
                                Width="200px" TextFormatString="{1}" IncrementalFilteringMode="Contains">
                                <ClientSideEvents SelectedIndexChanged="function(s, e) {getMcategory(s.GetSelectedItem().texts[0]);}" />
                                <%--<ValidationSettings ValidationGroup="SearchNoID" RequiredField-IsRequired="true"
                                                RequiredField-ErrorText=" " Display="Dynamic" CausesValidation="True">
                                                <RequiredField IsRequired="True" ErrorText=" "></RequiredField>
                                            </ValidationSettings>--%>
                                <Columns>
                                    <dx:ListBoxColumn Caption="ID" FieldName="SubCategory3ID" Width="150px" />
                                    <dx:ListBoxColumn Caption="Problem" FieldName="SubName" Width="400px" />
                                </Columns>
                                <ItemStyle>
                                    <HoverStyle BackColor="#0076c4" ForeColor="#ffffff">
                                    </HoverStyle>
                                </ItemStyle>
                            </dx:ASPxComboBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="cmb_group_type" ForeColor="Red"
                                                        runat="server" Display="Dynamic" Text="* Not Empty" ValidationGroup="Btn_Simpan"
                                                        ErrorMessage="Please enter a value."></asp:RequiredFieldValidator>
                                <div class="seperator"></div>
                                Brand
                                      <dx:ASPxComboBox ID="SubCategoryI" runat="server" AutoPostBack="false" Height="30px" TextField="SubCategory1ID" Theme="MetropolisBlue" CssClass="form-control chzn-select"
                                ValueField="SubCategory1ID" DataSourceID="SourceCategoriI" ItemStyle-HoverStyle-BackColor="#F37021"
                                Width="200px">
                                <ClientSideEvents SelectedIndexChanged="function(s, e) {getMcategory2(s.GetSelectedItem().texts[0]);}" />
                                <Columns>
                                    <dx:ListBoxColumn Caption="Brand" FieldName="SubCategory1ID" />
                                    <dx:ListBoxColumn Caption="Name" FieldName="SubName" />
                                </Columns>
                                <ItemStyle>
                                    <HoverStyle BackColor="#0076c4" ForeColor="#ffffff">
                                    </HoverStyle>
                                </ItemStyle>
                            </dx:ASPxComboBox>
                            <asp:HiddenField runat="server" ID="SubCatI" />
                                <div class="seperator"></div>
                                Product
                                     <dx:ASPxComboBox ID="SubCategoryII" runat="server" AutoPostBack="false" Height="30px" TextField="SubCategory2ID" Theme="MetropolisBlue" CssClass="form-control chzn-select"
                                ValueField="SubCategory2ID" DataSourceID="SourceCategoriII" ItemStyle-HoverStyle-BackColor="#F37021"
                                Width="200px">
                                <ClientSideEvents SelectedIndexChanged="function(s, e) {getMcategory3(s.GetSelectedItem().texts[0]);}" />
                                <Columns>
                                    <dx:ListBoxColumn Caption="Product" FieldName="SubCategory2ID" Width="400px" />
                                </Columns>
                                <ItemStyle>
                                    <HoverStyle BackColor="#0076c4">
                                    </HoverStyle>
                                </ItemStyle>
                            </dx:ASPxComboBox>
                            <asp:HiddenField runat="server" ID="SubCatII" />
                                <div class="seperator"></div>                                
                                Priority
                                   <dx:ASPxComboBox ID="cmb_priority" Height="30px" runat="server" Theme="MetropolisBlue" Width="200px"
                                       DataSourceID="sql_priority" TextField="jenis" ValueField="jenis" CssClass="form-control chzn-select">
                                       <Columns>
                                           <dx:ListBoxColumn Caption="Priority" FieldName="jenis" Width="150px" />
                                       </Columns>
                                   </dx:ASPxComboBox>
                                <asp:SqlDataSource ID="sql_priority" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
                                <div class="seperator"></div>
                                Severity
                                    <dx:ASPxComboBox ID="cmb_severity" Height="30px" runat="server" Theme="MetropolisBlue" Width="200px"
                                        DataSourceID="sql_severity" TextField="jenis" ValueField="jenis" CssClass="form-control chzn-select">
                                        <Columns>
                                            <dx:ListBoxColumn Caption="Severity" FieldName="jenis" Width="150px" />
                                        </Columns>
                                    </dx:ASPxComboBox>
                                <asp:SqlDataSource ID="sql_severity" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
                                <div class="seperator"></div>
                                Status
                                    <dx:ASPxComboBox ID="cmb_status" Height="30px" runat="server" Theme="MetropolisBlue" Width="200px"
                                        DataSourceID="sql_status" TextField="status" ValueField="status" CssClass="form-control chzn-select">
                                        <Columns>
                                            <dx:ListBoxColumn Caption="Status" FieldName="status" Width="150px" />
                                        </Columns>
                                    </dx:ASPxComboBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="cmb_group_type" ForeColor="Red"
                                                        runat="server" Display="Dynamic" Text="* Not Empty" ValidationGroup="Btn_Simpan"
                                                        ErrorMessage="Please enter a value."></asp:RequiredFieldValidator>
                                <asp:SqlDataSource ID="sql_status" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
                                <div class="seperator"></div>
                             <div class="panel panel-default panel-stat1 bg-success" id="div_sla" runat="server" visible="false">
							<div class="panel-body">
								<div class="value"><asp:Label ID="lbl_sla" runat="server"></asp:Label><asp:HiddenField ID="hd_sla" runat="server"/></div>
								<div class="title">
									<span class="m-left-xs">SLA in hours</span>
								</div>
							</div>
                            </div>
                              
						</div>
                            <!-- /panel -->
                            
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:aspxcallbackpanel>
                            </div>
                        </div>
                    </div>
                    <!-- /panel -->
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapseThree">History Transaction Ticket
							</a>
                            <div class="btn-group pull-right">
                                <button type="button" class="btn btn-default btn-xs dropdown-toggle" data-toggle="dropdown">
                                    <i class="fa fa-chevron-down"></i>
                                </button>
                            </div>
                        </div>
                        <div id="collapseThree" class="panel-collapse collapse">
                            <div class="panel-body">
                                <table class="table table-bordered table-condensed table-hover table-striped">
                                    <thead>
                                        <tr>
                                            <th>ID</th>
                                            <th>Ticket ID </th>
                                            <th style="width: 85px;">Date</th>
                                        </tr>
                                    </thead>
                                    <asp:Literal ID="ltr_history_ticket" runat="server"></asp:Literal>
                                </table>
                            </div>
                        </div>
                    </div>
                    <!-- /panel -->
                </div>
                <!-- /panel-group -->
            </div>
        </div>
        <!-- /.col -->
        <div class="col-md-9 col-sm-9">
            <h6><strong>Description Message</strong>
                <span class="line"><span class="label label-danger pull-right" runat="server" id="lbl_red">
                    <asp:Label ID="lbl_ticket_number" runat="server" Font-Bold="true" Font-Size="10px"></asp:Label></span></span>
            </h6>

            <div class="panel">
                <div class="panel-body">
                    <div class="media">
                        <a class="pull-left" href="#">
                            <img src="img/user.jpg" alt="Author" class="img-rounded" style="height: 50px; width: 50px;">
                        </a>
                        <div class="media-heading">
                            <strong>
                                <asp:Label ID="lbl_pic_customer" runat="server"></asp:Label></strong><span class="label pull-right"><small class="time text-muted"><asp:Label ID="lbl_date" runat="server"></asp:Label></small></span><br>
                            <small class="text-muted">
                                <asp:Label ID="lbl_customer" runat="server"></asp:Label></small>

                        </div>
                        <div class="media-body">
                            <asp:Label ID="lbl_message" runat="server"></asp:Label>
                            <asp:TextBox ID="txt_message" runat="server" TextMode="MultiLine" Width="100%" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div>
                            <asp:HiddenField ID="Path_Ticket" runat="server" />
                            <a id="a_download" runat="server" onserverclick="button_download"><small class="pull-right text-muted"><i class="fa fa-download"></i>&nbsp;Download</small></a>
                            <span class="line"></span>
                        </div>
                    </div>

                </div>
            </div>
            <div class="form-group">
                <div class="panel panel-default">
                    <div class="panel-heading clearfix">
                        <span class="pull-left">Customer Interaction</span>
                        <ul class="tool-bar">
                            <%-- <li><a href="#" class="refresh-widget" data-toggle="tooltip" data-placement="bottom" title="" data-original-title="Refresh"><i class="fa fa-refresh"></i></a></li>--%>
                            <li><a href="#collapseWidget" data-toggle="collapse"><i class="fa fa-chevron-down"></i></a></li>
                        </ul>
                    </div>
                    <div class="panel-body no-padding collapse " id="collapseWidget">
                        <div class="panel-body">
                            <div id="chatScroll">
                                <ul class="chat">
                                    <asp:Literal ID="interaction_agent" runat="server"></asp:Literal>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="loading-overlay">
                        <i class="loading-icon fa fa-refresh fa-spin fa-lg"></i>
                    </div>
                </div>
            </div>
            <div class="form-group">
                <label class="col-lg-1 control-label">Solution</label>
                <div class="col-lg-11">
                    <dx:aspxhtmleditor id="html_solution" width="100%" height="250px" runat="server" clientinstancename="htmlEditor">
                    </dx:aspxhtmleditor>
                    <div class="seperator"></div>
                    <asp:FileUpload ID="ASPxUploadControl1" Width="100%" runat="server" />
                    <div class="seperator"></div>
                    
                </div>
                <!-- /.col -->
            </div>
            <!-- /tab-content -->
            <div class="form-group">
                <label class="col-lg-1 control-label">Posting</label>
                <div class="col-lg-11">
                     <dx:ASPxCheckBox ID="chk_posting" runat="server"></dx:ASPxCheckBox>
                    <div id="div_button_ticket" runat="server" class="text-right">
                        <button id="Btn_Simpan" runat="server" class="btn btn-info" type="submit" validationgroup="Btn_Simpan">
                            <i class="fa fa-save"></i>&nbsp;Save
                        </button>
                        <button id="Btn_Update" runat="server" class="btn btn-info" type="submit">
                            <i class="fa fa-retweet"></i>&nbsp;Update
                        </button>
                        <button id="Btn_Assign" runat="server" class="btn btn-info" type="submit">
                            <i class="fa fa-smile-o"></i>&nbsp;Assign
                        </button>
                        <button id="Btn_Cancel" runat="server" class="btn btn-info" type="submit" validationgroup="Btn_Simpan">
                            <i class="fa fa-arrow-circle-left"></i>&nbsp;Cancel
                        </button>
                        <a href="#ModalDispatchSatu" role="button" data-toggle="modal" class="btn btn-info" id="modal_dispatch_satu" runat="server"><i class="fa fa-share-square-o"> </i>Dispatch</a>
                        <a href="#ModalDispatchDua" role="button" data-toggle="modal" class="btn btn-info" id="modal_dispatch_dua" runat="server"><i class="fa fa-share-square-o"> </i>Dispatch</a>
                    </div>
                </div>
            </div>
        </div>
        <!-- /.col -->
    </div>

    <!-- /.row -->

    <div class="modal fade" id="ModalEmail">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4>Contact Info</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label>Customer Name</label>
                        <asp:TextBox ID="txt_customer_name" runat="server" placeholder="Customer Name" CssClass="form-control input-sm"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Address</label>
                        <asp:TextBox ID="txt_address_1" runat="server" placeholder="Address" TextMode="MultiLine" CssClass="form-control input-sm"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Email</label>
                        <asp:TextBox ID="txt_email" runat="server" placeholder="Email" CssClass="form-control input-sm"></asp:TextBox>
                    </div>
                    <!-- /form-group -->
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Phone 1</label>
                                <asp:TextBox ID="txt_phone1" runat="server" placeholder="Phone 1" CssClass="form-control input-sm"></asp:TextBox>
                            </div>
                        </div>
                        <!-- /.col -->
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Phone 2</label>
                                <asp:TextBox ID="txt_phone2" runat="server" placeholder="Phone 2" CssClass="form-control input-sm"></asp:TextBox>
                            </div>
                        </div>
                        <!-- /.col -->
                    </div>
                    <!-- /.row -->
                </div>
                <div class="modal-footer">
                    <button id="btn_update_customer" runat="server" class="btn btn-info" type="submit">
                        <i class="fa fa-retweet"></i>&nbsp;Update
                    </button>
                    <button id="Button2" runat="server" class="btn btn-info" type="submit">
                        <i class="fa fa-arrow-circle-left"></i>&nbsp;Cancel
                    </button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>

    <div class="modal fade" id="ModalDispatchSatu">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4>Dispatch Ticket</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group" runat="server" id="div_Personal_Support">
                        <label>Personal Support</label>
                        <dx:aspxcombobox id="cmb_Personal_Support" height="30px" runat="server" theme="MetropolisBlue" width="200px"
                            datasourceid="sql_cmb_Personal_Support" textfield="Name" valuefield="NIK" textformatstring="{1}" cssclass="form-control chzn-select">
                         <Columns>
                            <dx:ListBoxColumn Caption="NIK" FieldName="NIK" Width="100px" />
                             <dx:ListBoxColumn Caption="Name" FieldName="Name" Width="300px" />
                          </Columns>
                         </dx:aspxcombobox>
                        <asp:SqlDataSource ID="sql_cmb_Personal_Support" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
                    </div>

                    <div class="form-group">
                        <label>Keterangan</label>
                        <asp:TextBox ID="txt_keterangan_dispatch" runat="server" TextMode="MultiLine" Width="100%" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="modal-footer">
                    <button id="btn_dispatch" runat="server" class="btn btn-info" type="submit">
                        <i class="fa fa-retweet"></i>&nbsp;Update
                    </button>
                    <button id="Btn_Dispatch_cancel" runat="server" class="btn btn-info" type="submit">
                        <i class="fa fa-arrow-circle-left"></i>&nbsp;Cancel
                    </button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>

    <div class="modal fade" id="ModalDispatchDua">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4>Dispatch Ticket</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group" runat="server" id="div_Unit_Support">
                        <label>Unit Support</label>
                        <dx:aspxcombobox id="cmb_unit_support" height="30px" runat="server" theme="MetropolisBlue" width="200px"
                            datasourceid="sql_cmb_unit_support" textfield="UnitKerja" valuefield="UnitKerja" cssclass="form-control chzn-select">
                         <Columns>
                            <dx:ListBoxColumn Caption="UnitKerja" FieldName="UnitKerja" Width="300px" />
                          </Columns>
                         </dx:aspxcombobox>
                        <asp:SqlDataSource ID="sql_cmb_unit_support" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
                    </div>
                    <div class="form-group">
                        <label>Keterangan</label>
                        <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Width="100%" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="modal-footer">
                    <button id="btn_dispatch_unit" runat="server" class="btn btn-info" type="submit">
                        <i class="fa fa-retweet"></i>&nbsp;Update
                    </button>
                    <button id="btn_dispatch_unit_cancel" runat="server" class="btn btn-info" type="submit">
                        <i class="fa fa-arrow-circle-left"></i>&nbsp;Cancel
                    </button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>

    <asp:SqlDataSource ID="SourceType" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
    <asp:SqlDataSource ID="GroupType" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SourceCategori" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SourceCategoriI" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SourceCategoriII" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SourceCategoriIII" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
    <asp:SqlDataSource ID="DSHistoryAgent" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
    <asp:SqlDataSource ID="DSCustHistory" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
</asp:Content>
