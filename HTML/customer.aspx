<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/HTML/Ticket.Master" CodeBehind="customer.aspx.vb" Inherits="ICC.customer" %>


<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div id="div_menu_customer" runat="server">
        <div id="breadcrumb">
            <ul class="breadcrumb">
                <li><i class="fa fa-home"></i>&nbsp;<a href="dashboard.aspx">Home</a></li>
                <li class="active">Customer</li>
            </ul>
        </div>
        <div class="padding-md">
            <div class="row">
                <div style="overflow: auto;">
                    <dx:ASPxGridView ID="gv_customer" runat="server" KeyFieldName="ID" Width="1028px"
                        AutoGenerateColumns="False" DataSourceID="sql_customer" OnRowInserting="gv_customer_RowInserting"
                        Border-BorderWidth="1" SettingsPager-PageSize="10" Theme="MetropolisBlue">
                        <SettingsPager>
                            <AllButton Text="All">
                            </AllButton>
                            <NextPageButton Text="Next &gt;">
                            </NextPageButton>
                            <PrevPageButton Text="&lt; Prev">
                            </PrevPageButton>
                        </SettingsPager>
                        <SettingsEditing Mode="Inline" />
                        <Settings ShowFilterRow="true" ShowFilterRowMenu="false" ShowGroupPanel="true" ShowVerticalScrollBar="false" ShowHorizontalScrollBar="true" />
                        <SettingsBehavior ConfirmDelete="true" />
                        <Columns>
                            <dx:GridViewCommandColumn Caption="Action" HeaderStyle-HorizontalAlign="Center" VisibleIndex="0"
                                ButtonType="Image" FixedStyle="Left" CellStyle-BackColor="#ffffd6" Width="160px">
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
                            <dx:GridViewDataTextColumn Caption="ID" FieldName="ID" ReadOnly="true" VisibleIndex="0" Visible="false" Width="70px">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Customer ID" FieldName="CustomerID" ReadOnly="true" VisibleIndex="1">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Customer Name" FieldName="NamaPerusahaan" Width="400px" ReadOnly="false" VisibleIndex="2" Settings-AutoFilterCondition="Contains">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="PIC Name" FieldName="NamePIC" Width="400px" VisibleIndex="3" Settings-AutoFilterCondition="Contains">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataDateColumn Caption="Birth" FieldName="Birth" Width="100px" ReadOnly="false" VisibleIndex="4">
                                <PropertiesDateEdit DisplayFormatString="{0:yyyy-MM-dd}" NullText="yyyy-MM-dd" EditFormat="Custom" EditFormatString="yyyy-MM-dd" AllowUserInput="false"></PropertiesDateEdit>
                                <Settings AllowAutoFilterTextInputTimer="True" />
                            </dx:GridViewDataDateColumn>
                            <dx:GridViewDataComboBoxColumn Caption="Gender" FieldName="JenisKelamin"
                                HeaderStyle-HorizontalAlign="Center" Width="100px" VisibleIndex="5">
                                <PropertiesComboBox TextField="Gender" ValueField="Gender" EnableSynchronization="False"
                                    TextFormatString="{0}" IncrementalFilteringMode="StartsWith">
                                    <Items>
                                        <dx:ListEditItem Text="Male" Value="Male" />
                                        <dx:ListEditItem Text="Female" Value="Female" />
                                    </Items>
                                </PropertiesComboBox>
                            </dx:GridViewDataComboBoxColumn>
                            <dx:GridViewDataTextColumn Caption="Address" FieldName="Alamat" Width="600px" VisibleIndex="6" Settings-AutoFilterCondition="Contains">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="City" FieldName="City" Width="100px" VisibleIndex="7" Settings-AutoFilterCondition="Contains">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataComboBoxColumn Caption="Provinsi" FieldName="Region" VisibleIndex="8" Width="150px" Settings-FilterMode="DisplayText">
                                <PropertiesComboBox TextFormatString="{0}" TextField="RegionName" ValueField="RegionName" DataSourceID="sql_region">
                                    <Columns>
                                        <dx:ListBoxColumn Caption="Region Name" FieldName="RegionName" Width="200px" />
                                    </Columns>
                                </PropertiesComboBox>
                            </dx:GridViewDataComboBoxColumn>
                            <dx:GridViewDataComboBoxColumn Caption="Status Customer" FieldName="CusStatus" VisibleIndex="9" HeaderStyle-HorizontalAlign="Center"
                                Width="100px">
                                <PropertiesComboBox>
                                    <Items>
                                        <dx:ListEditItem Text="Contract" Value="Contract" />
                                        <dx:ListEditItem Text="Maintenance" Value="Maintenance" />
                                    </Items>
                                </PropertiesComboBox>
                            </dx:GridViewDataComboBoxColumn>
                            <dx:GridViewDataTextColumn Caption="Home Phone" FieldName="Telepon" Width="200px" VisibleIndex="10" Settings-AutoFilterCondition="Contains">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Mobile Phone" FieldName="NomorHpPIC" Width="200px" VisibleIndex="11" Settings-AutoFilterCondition="Contains">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Email" FieldName="Email" Width="200px" VisibleIndex="12" Settings-AutoFilterCondition="Contains">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Facebook" FieldName="Facebook" Width="200px" VisibleIndex="13">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Twitter" FieldName="Twitter" Width="200px" VisibleIndex="13">
                            </dx:GridViewDataTextColumn>
                        </Columns>
                    </dx:ASPxGridView>

                    <asp:SqlDataSource ID="sql_customer" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
                    <asp:SqlDataSource ID="sql_region" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
