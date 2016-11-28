<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/HTML/Ticket.Master" CodeBehind="chat.aspx.vb" Inherits="ICC.chat" %>

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
            //alert(text)
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
    <div class="row">
        <div class="col-sm-3">
            <asp:HiddenField runat="server" ID="mCatID" />
            <div class="panel-group" id="accordion">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapseOne">Customer Chat 							
                        </a>
                        <div class="btn-group pull-right">
                            <button type="button" class="btn btn-default btn-xs dropdown-toggle" data-toggle="dropdown">
                                <i class="fa fa-chevron-down"></i>
                            </button>
                            <ul class="dropdown-menu slidedown">
                                <li><a href="chat.aspx"><i class="fa fa-refresh"></i>&nbsp;Refresh</a></li>
                            </ul>
                        </div>
                    </div>
                    <div id="collapseOne" class="panel-collapse collapse in">
                        <div class="panel-body">
                            <table class="table table-striped" id="responsiveTable">
                                <thead>
                                    <tr>
                                        <th style="width: 250px;">Customer</th>
                                        <th style="width: 50px;">Chat</th>

                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Literal ID="showhistory" runat="server"></asp:Literal>
                                </tbody>
                            </table>
                            <!-- /panel -->
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
                    <div id="collapseTwo" class="panel-collapse collapse">
                        <div class="panel-body">
                            <dx:ASPxCallbackPanel ID="callbackPanelX" ClientInstanceName="callbackPanelX"
                                runat="server" Width="0%" Height="0" RenderMode="Table">
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
                                            runat="server" Display="Dynamic" Text="* Not Empty" ValidationGroup="btnsent"
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
                                            runat="server" Display="Dynamic" Text="* Not Empty" ValidationGroup="btnsent"
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
                                                runat="server" Display="Dynamic" Text="* Not Empty" ValidationGroup="btnsent"
                                                ErrorMessage="Please enter a value."></asp:RequiredFieldValidator>
                                            <asp:HiddenField runat="server" ID="CategoryHidden" />
                                            <div class="seperator"></div>
                                            Problem
                                    <dx:ASPxComboBox ID="SubCategoryIII" runat="server" Height="30px" AutoPostBack="false" TextField="SubName" Theme="MetropolisBlue" CssClass="form-control chzn-select"
                                        ValueField="SubCategory3ID" DataSourceID="SourceCategoriIII" ItemStyle-HoverStyle-BackColor="#F37021"
                                        Width="200px" TextFormatString="{1}" IncrementalFilteringMode="Contains">
                                        <ClientSideEvents SelectedIndexChanged="function(s, e) {getMcategory(s.GetSelectedItem().texts[0]);}" />
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
                                                runat="server" Display="Dynamic" Text="* Not Empty" ValidationGroup="btnsent"
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
                                                    <div class="value">
                                                        <asp:Label ID="lbl_sla" runat="server"></asp:Label><asp:HiddenField ID="hd_sla" runat="server" />
                                                    </div>
                                                    <div class="title">
                                                        <span class="m-left-xs">SLA in hours</span>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                        <!-- /panel -->

                                    </dx:PanelContent>
                                </PanelCollection>
                            </dx:ASPxCallbackPanel>
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
       <%--                                 <th>ID</th>--%>
                                        <th>Ticket ID </th>
                                        <th style="width: 125px;">Date</th>
                                    </tr>
                                </thead>    
                                <asp:Literal ID="ltr_history_ticket" runat="server"></asp:Literal>
                            </table>
                        </div>
                    </div>
                </div>
                <!-- /panel -->
            </div>
        </div>
        <!-- /.col -->
        <div class="col-sm-9">
            <div class="tab-content">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <i class="fa fa-comment"></i>&nbsp; Interaction Chat	
                             <div class="btn-group pull-right">
                                 <button type="button" class="btn btn-default btn-xs dropdown-toggle" data-toggle="dropdown">
                                     <i class="fa fa-chevron-down"></i>
                                 </button>
                                 <ul class="dropdown-menu slidedown">
                                     <asp:Literal ID="ltr_refresh" runat="server"></asp:Literal>
                                 </ul>
                             </div>
                        <asp:HiddenField ID="UserId" runat="server" />
                    </div>

                    <div class="padding-md">
                        <div class="panel-body">
                            <div id="chatScroll">
                                <ul class="chat">
                                    <asp:Literal ID="ltr_chat" runat="server"></asp:Literal>
                                    <asp:Literal ID="cht_agent" runat="server"></asp:Literal>
                                </ul>
                            </div>
                        </div>
                    </div>

                    <div class="panel-footer">
                        <div class="input-group">
                            <input id="textchat" type="text" runat="server" class="form-control input-sm" placeholder="type your message here...">
                            <span class="input-group-btn">
                                <button class="btn btn-info btn-sm" id="btnchat" runat="server" type="submit">Send</button>
                            </span>

                        </div>
                        <hr />
                        <div>
                            <button id="btnsent" runat="server" class="btn btn-info" type="submit" validationgroup="btnsent">
                                <i class="fa fa-save"></i>&nbsp;Create Ticket
                            </button>
                        </div>
                        <div class="row" id="lblError" runat="server" visible="false">
                            <div class="col-sm-12">
                                <div class="alert alert-info">
                                    <button type="button" class="close" data-dismiss="alert" aria-hidden="true" id="B_notError" runat="server">&times;</button>
                                    <strong>
                                        <asp:Label ID="lbl_Error" runat="server">Insert Ticket Success With Ticket Number :</asp:Label>
                                        <asp:Label ID="lbl_ticket" runat="server" Font-Bold="true" ForeColor="Red"></asp:Label>
                                    </strong>
                                </div>
                            </div>
                        </div>
                        <!-- /input-group -->
                    </div>
                </div>
            </div>
        </div>
        <!-- /panel -->
        <asp:SqlDataSource ID="SourceCategori" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SourceCategoriI" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SourceCategoriII" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SourceCategoriIII" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
    </div>
    <!-- /.col -->
</asp:Content>
