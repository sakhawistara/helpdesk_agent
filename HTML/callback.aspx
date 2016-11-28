<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/HTML/Ticket.Master" CodeBehind="callback.aspx.vb" Inherits="ICC.callback" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxCallback" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2 , Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
    <script>
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
    <asp:HiddenField runat="server" ID="mCatID" />
    <div class="padding-md">
        <div class="col-md-3 col-sm-3">
            <div class="row">
                <div class="panel panel-default" runat="server" id="div_properties">
                    <div class="panel-heading">
                        <h4 class="panel-title">
                            <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapseTwo">Ticket Properties
								</a>
                        </h4>
                    </div>
                    <div id="collapseTwo" class="panel-collapse collapse">
                        <div class="panel-body">
                            <dx:aspxcallbackpanel id="callbackPanelX" clientinstancename="callbackPanelX"
                                runat="server" width="0%" height="0" rendermode="Table">
                    <PanelCollection>
                        <dx:PanelContent ID="PanelContent1" runat="server">
                                  Source Type
                                    <dx:ASPxComboBox ID="cmb_source_type" Height="30px" runat="server" Theme="MetropolisBlue"
                                        DataSourceID="sql_source_type" TextField="Name" ValueField="TicketIDCode" CssClass="form-control chzn-select">
                                        <Columns>
                                            <dx:ListBoxColumn Caption="TicketIDCode" FieldName="ID" Width="80px" Visible="false" />
                                            <dx:ListBoxColumn Caption="Source Name" FieldName="Name" Width="150px" />
                                        </Columns>
                                    </dx:ASPxComboBox>
                                <asp:SqlDataSource ID="sql_source_type" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
                                <div class="seperator"></div>                              <div class="seperator"></div>
                                Group Type
                                    <dx:ASPxComboBox ID="cmb_group_type" Height="30px" runat="server" Theme="MetropolisBlue"
                                        DataSourceID="sql_group_type" TextField="GroupName" ValueField="GroupCode" CssClass="form-control chzn-select">
                                        <Columns>
                                            <dx:ListBoxColumn Caption="GroupCode" FieldName="GroupCode" Width="80px" Visible="false" />
                                            <dx:ListBoxColumn Caption="Group Name" FieldName="GroupName" Width="150px" />
                                        </Columns>
                                    </dx:ASPxComboBox>
                                <asp:SqlDataSource ID="sql_group_type" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
                                <div class="seperator"></div>
                                Transaction Type
                                    <dx:ASPxComboBox ID="Category" runat="server" AutoPostBack="false" TextField="Name" IncrementalFilteringMode="Contains" EnableSynchronization="false" CssClass="form-control chzn-select"
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
                            <asp:HiddenField runat="server" ID="CategoryHidden" />
                                <div class="seperator"></div>
                                Brand
                                      <dx:ASPxComboBox ID="SubCategoryI" runat="server" AutoPostBack="false" TextField="SubCategory1ID" Theme="MetropolisBlue" CssClass="form-control chzn-select"
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
                                     <dx:ASPxComboBox ID="SubCategoryII" runat="server" AutoPostBack="false" TextField="SubCategory2ID" Theme="MetropolisBlue" CssClass="form-control chzn-select"
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
                                Problem
                                    <dx:ASPxComboBox ID="SubCategoryIII" runat="server" AutoPostBack="false" TextField="SubName" Theme="MetropolisBlue" CssClass="form-control chzn-select"
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
                                <div class="seperator"></div>
                                Priority
                                   <dx:ASPxComboBox ID="cmb_priority" Height="30px" runat="server" Theme="MetropolisBlue"
                                       DataSourceID="sql_priority" TextField="jenis" ValueField="jenis" CssClass="form-control chzn-select">
                                       <Columns>
                                           <dx:ListBoxColumn Caption="Priority" FieldName="jenis" Width="150px" />
                                       </Columns>
                                   </dx:ASPxComboBox>
                                <asp:SqlDataSource ID="sql_priority" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
                                <div class="seperator"></div>
                                Severity
                                    <dx:ASPxComboBox ID="cmb_severity" Height="30px" runat="server" Theme="MetropolisBlue"
                                        DataSourceID="sql_severity" TextField="jenis" ValueField="jenis" CssClass="form-control chzn-select">
                                        <Columns>
                                            <dx:ListBoxColumn Caption="Severity" FieldName="jenis" Width="150px" />
                                        </Columns>
                                    </dx:ASPxComboBox>
                                <asp:SqlDataSource ID="sql_severity" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
                                <div class="seperator"></div>
                                Status
                                    <dx:ASPxComboBox ID="cmb_status" Height="30px" runat="server" Theme="MetropolisBlue"
                                        DataSourceID="sql_status" TextField="status" ValueField="status" CssClass="form-control chzn-select">
                                        <Columns>
                                            <dx:ListBoxColumn Caption="Status" FieldName="status" Width="150px" />
                                        </Columns>
                                    </dx:ASPxComboBox>
                                <asp:SqlDataSource ID="sql_status" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
                            </dx:PanelContent>
                    </PanelCollection>
                </dx:aspxcallbackpanel>
                        </div>
                    </div>
                </div>
            </div>
        </div>
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
