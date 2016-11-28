<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/HTML/Ticket.Master" CodeBehind="calltype_tre.aspx.vb" Inherits="ICC.calltype_tre" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
    <script language="javascript" type="text/javascript">
        function OnJenisTransaksiChange(cmbParent) {
            var comboValue = cmbParent.GetSelectedItem().value;
            if (isUpdating)
                //return;
                ASPxGridView1.GetEditor("UnitKerja").PerformCallback(comboValue.toString());
            if (comboValue)
                ASPxGridView1.GetEditor("UnitKerja").PerformCallback(comboValue.toString());
            //alert(comboValue.toString());
        }

        function OnUnitKerjaChange(cmbParent) {
            var comboValue = cmbParent.GetSelectedItem().value;
            if (isUpdating)
                //return;
                ASPxGridView1.GetEditor("NameSubject").PerformCallback(comboValue.toString());
            if (comboValue)
                ASPxGridView1.GetEditor("NameSubject").PerformCallback(comboValue.toString());
            //alert(comboValue.toString());
        }

        function OnUnitKategory(cmbParent) {
            var comboValue = cmbParent.GetSelectedItem().value;
            if (isUpdating)
                //return;
                ASPxGridView1.GetEditor("SubjectTable").PerformCallback(comboValue.toString());
            if (comboValue)
                ASPxGridView1.GetEditor("SubjectTable").PerformCallback(comboValue.toString());
            //alert(comboValue.toString());
        }

        var combo = null;
        var isUpdating = true;
        // ]]>
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div id="div_calltype_tre" runat="server">
        <div id="breadcrumb">
            <ul class="breadcrumb">
                <li><i class="fa fa-home"></i>&nbsp;<a href="dashboard.aspx">Home</a></li>
                <li class="active">Problem</li>
            </ul>
        </div>
        <div class="padding-md">
            <div class="row">
                <dx:ASPxGridView ID="ASPxGridView1" ClientInstanceName="ASPxGridView1" Width="100%" runat="server" DataSourceID="DsCategory"
                    KeyFieldName="ID" SettingsPager-PageSize="10" Theme="MetropolisBlue">

                    <SettingsPager>
                        <AllButton Text="All">
                        </AllButton>
                        <NextPageButton Text="Next &gt;">
                        </NextPageButton>
                        <PrevPageButton Text="&lt; Prev">
                        </PrevPageButton>
                    </SettingsPager>
                    <SettingsEditing Mode="Inline" />
                    <Settings ShowFilterRow="true" ShowFilterRowMenu="false" ShowGroupPanel="true" HorizontalScrollBarMode="Auto" />
                    <SettingsBehavior ConfirmDelete="true" />
                    <Styles>
                        <%--   <Header BackColor="#a5a494" ForeColor="White" HorizontalAlign="Center" Font-Bold="true">
                        </Header>--%>
                    </Styles>
                    <Columns>
                        <dx:GridViewCommandColumn Caption="Action" HeaderStyle-HorizontalAlign="Center" VisibleIndex="0"
                            ButtonType="Image" FixedStyle="Left" CellStyle-BackColor="#ffffd6" Width="130px">
                            <HeaderTemplate>
                                <dx:ASPxHyperLink ID="lnkClearFilter" runat="server" ForeColor="White" Font-Bold="true" Text="Clear Filter" NavigateUrl="javascript:void(0);">
                                    <ClientSideEvents Click="function(s, e) {
                                        ASPxGridView1.ClearFilter();
                                    }" />
                                </dx:ASPxHyperLink>
                            </HeaderTemplate>
                            <EditButton Visible="True">
                                <Image ToolTip="Edit" Url="img/icon/Text-Edit-icon2.png" />
                            </EditButton>
                            <NewButton Visible="True">
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
                        <%--<dx:GridViewDataTextColumn FieldName="JenisTransaksi"></dx:GridViewDataTextColumn>--%>
                        <dx:GridViewDataTextColumn Caption="ID" FieldName="ID" VisibleIndex="0"
                            Width="30px" HeaderStyle-HorizontalAlign="Center">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataComboBoxColumn FieldName="JenisTransaksi" Caption="Transaction Type" Settings-AutoFilterCondition="Contains" Settings-FilterMode="DisplayText">
                            <PropertiesComboBox TextFormatString="{1}" TextField="Name" ValueField="CategoryID" DataSourceID="dsmCategory">
                                <%--  <Columns>
                                    <dx:ListBoxColumn Caption="ID" FieldName="CategoryID" Width="80px" />
                                    <dx:ListBoxColumn Caption="Jenis Transaksi" FieldName="Name" Width="150px" />
                                </Columns>--%>
                                <ClientSideEvents SelectedIndexChanged="function(s, e) { OnJenisTransaksiChange(s); }"></ClientSideEvents>
                            </PropertiesComboBox>
                        </dx:GridViewDataComboBoxColumn>
                        <dx:GridViewDataComboBoxColumn FieldName="UnitKerja" Caption="Brand" Settings-FilterMode="DisplayText" Settings-AutoFilterCondition="Contains">
                            <PropertiesComboBox TextFormatString="{0}" TextField="SubName" ValueField="SubCategory1ID" DataSourceID="dsmSubCategoryLv1" Width="250px">
                                <%-- <Columns>
                                    <dx:ListBoxColumn Caption="ID" FieldName="SubCategory1ID" Width="80px" />
                                    <dx:ListBoxColumn Caption="Unit Kerja" FieldName="SubName" Width="150px" />
                                </Columns>--%>
                                <ClientSideEvents SelectedIndexChanged="function(s, e) { OnUnitKerjaChange(s); }"></ClientSideEvents>
                            </PropertiesComboBox>
                        </dx:GridViewDataComboBoxColumn>
                        <dx:GridViewDataComboBoxColumn Caption="Product" FieldName="NameSubject" Settings-FilterMode="DisplayText" Width="200px" Settings-AutoFilterCondition="Contains">
                            <PropertiesComboBox TextFormatString="{1}" TextField="SubName" ValueField="SubCategory2ID" DataSourceID="dsmSubCategoryLv2">
                                <%-- <Columns>
                                    <dx:ListBoxColumn Caption="ID" FieldName="SubCategory2ID" Width="80px" />
                                    <dx:ListBoxColumn Caption="Subject" FieldName="SubName" Width="150px" />
                                </Columns>--%>
                            </PropertiesComboBox>
                        </dx:GridViewDataComboBoxColumn>
                        <dx:GridViewDataTextColumn Caption="Problem" FieldName="SubjectTable" Width="500px" Settings-AutoFilterCondition="Contains">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="SLA" FieldName="SLA" Width="40px">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Response Agent" FieldName="Response_Agent">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataComboBoxColumn Caption="Priority" FieldName="Priority"
                            HeaderStyle-HorizontalAlign="Center" Width="60px">
                            <PropertiesComboBox TextField="Priority" ValueField="Priority" EnableSynchronization="False"
                                TextFormatString="{0}" IncrementalFilteringMode="StartsWith">
                                <Items>
                                    <dx:ListEditItem Text="Low" Value="Low" />
                                    <dx:ListEditItem Text="Medium " Value="Medium" />
                                    <dx:ListEditItem Text="High" Value="High" />
                                </Items>
                            </PropertiesComboBox>
                        </dx:GridViewDataComboBoxColumn>
                        <dx:GridViewDataComboBoxColumn Caption="Severity" FieldName="Severity"
                            HeaderStyle-HorizontalAlign="Center" Width="60px">
                            <PropertiesComboBox TextField="Severity" ValueField="Severity" EnableSynchronization="False"
                                TextFormatString="{0}" IncrementalFilteringMode="StartsWith">
                                <Items>
                                    <dx:ListEditItem Text="Low" Value="Low" />
                                    <dx:ListEditItem Text="Medium " Value="Medium" />
                                    <dx:ListEditItem Text="High" Value="High" />
                                </Items>
                            </PropertiesComboBox>
                        </dx:GridViewDataComboBoxColumn>
                        <dx:GridViewDataTextColumn Caption="Error Code" FieldName="IDKamus" Width="50px">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataComboBoxColumn Caption="Status" FieldName="NA" HeaderStyle-HorizontalAlign="Center"
                            Width="70px">
                            <PropertiesComboBox>
                                <Items>
                                    <dx:ListEditItem Text="Active" Value="Y" />
                                    <dx:ListEditItem Text="In Active" Value="N" />
                                </Items>
                            </PropertiesComboBox>
                        </dx:GridViewDataComboBoxColumn>
                    </Columns>
                </dx:ASPxGridView>
                <asp:SqlDataSource ID="DsCategory" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
                <asp:SqlDataSource ID="dsmCategory" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"
                    SelectCommand="select top 10 * from mCategory Where NA='Y'"></asp:SqlDataSource>
                <asp:SqlDataSource ID="dsmSubCategoryLv1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"
                    SelectCommand="select * from mSubCategoryLv1 Where NA='Y' and CategoryID=@CategoryID">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="0" Name="CategoryID" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="dsmSubCategoryLv2" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"
                    SelectCommand="select ID,CategoryID,SubCategory2ID,SubCategory1ID,SubName,Description,NA  from mSubCategoryLv2 Where NA='Y' and SubCategory1ID=@SubCategory1ID">
                    <%--SelectCommand="select a.SubCategory2ID,a.SubName  from mSubCategoryLv2 a left outer join mSubCategoryLv1 b on a.SubCategory1ID=b.SubCategory1ID Where a.NA='Y' and b.ID=@SubCategory1ID">--%>
                    <SelectParameters>
                        <asp:Parameter DefaultValue="0" Name="SubCategory1ID" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </div>
        </div>
    </div>
</asp:Content>
