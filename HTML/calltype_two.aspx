<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/HTML/Ticket.Master" CodeBehind="calltype_two.aspx.vb" Inherits="ICC.calltype_two" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
    <script language="javascript" type="text/javascript">
        function OnJenisTransaksiChange(cmbParent) {

            var comboValue = cmbParent.GetSelectedItem().value;
            if (comboValue)
                ASPxGridView1.GetEditor("UnitKerja").PerformCallback(comboValue.toString());
            //alert(comboValue.toString());
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div id="div_calltype_two" runat="server">
        <div id="breadcrumb">
            <ul class="breadcrumb">
                <li><i class="fa fa-home"></i>&nbsp;<a href="dashboard.aspx">Home</a></li>
                <li class="active">Product</li>
            </ul>
        </div>
        <div class="padding-md">
            <div class="row">
                <div style="overflow: auto;">
                    <dx:ASPxGridView ID="ASPxGridView1" ClientInstanceName="ASPxGridView1" Width="100%" runat="server" DataSourceID="dsSubject"
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
                        <Settings ShowFilterRow="true" ShowFilterRowMenu="false" ShowGroupPanel="true" />
                        <SettingsBehavior ConfirmDelete="true" />
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
                            <dx:GridViewDataTextColumn Caption="ID" FieldName="ID" VisibleIndex="0"
                                Width="10px" HeaderStyle-HorizontalAlign="Center">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataComboBoxColumn FieldName="JenisTransaksi" Caption="Transaction Type" Settings-AutoFilterCondition="Contains" VisibleIndex="1" Width="150px" Settings-FilterMode="DisplayText">
                                <PropertiesComboBox IncrementalFilteringMode="Contains" TextFormatString="{1}" TextField="CategoryID" ValueField="CategoryID" DataSourceID="dsmCategory">
                                    <Columns>
                                        <dx:ListBoxColumn Caption="ID" FieldName="CategoryID" Width="80px" />
                                        <dx:ListBoxColumn Caption="Jenis Transaksi" FieldName="Name" Width="150px" />
                                    </Columns>
                                    <ClientSideEvents SelectedIndexChanged="function(s, e) { OnJenisTransaksiChange(s); }"></ClientSideEvents>
                                </PropertiesComboBox>
                            </dx:GridViewDataComboBoxColumn>
                            <dx:GridViewDataComboBoxColumn FieldName="UnitKerja" Caption="Brand" VisibleIndex="2" Settings-FilterMode="DisplayText" Settings-AutoFilterCondition="Contains" Width="200px">
                                <PropertiesComboBox IncrementalFilteringMode="Contains" TextFormatString="{1}" TextField="SubName" ValueField="SubCategory1ID" DataSourceID="dsmSubCategoryLv1">
                                    <%-- <Columns>
                                    <dx:ListBoxColumn Caption="ID" FieldName="SubCategory1ID" Width="80px" />
                                    <dx:ListBoxColumn Caption="Jenis Transaksi" FieldName="SubName" Width="150px" />
                                </Columns>--%>
                                </PropertiesComboBox>
                            </dx:GridViewDataComboBoxColumn>
                            <dx:GridViewDataTextColumn Caption="Product" FieldName="SubjectTable" VisibleIndex="3" Settings-FilterMode="DisplayText" Settings-AutoFilterCondition="Contains">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataComboBoxColumn Caption="Status" FieldName="NA" VisibleIndex="4" HeaderStyle-HorizontalAlign="Center"
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
                    <asp:SqlDataSource ID="dsSubject" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
                    <asp:SqlDataSource ID="dsmCategory" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"
                        SelectCommand="select * from mCategory Where NA='Y'"></asp:SqlDataSource>
                    <asp:SqlDataSource ID="dsmSubCategoryLv1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"
                        SelectCommand="select * from mSubCategoryLv1 Where NA='Y' and CategoryID=@CategoryID">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="0" Name="CategoryID" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
