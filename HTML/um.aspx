<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/HTML/Ticket.Master" CodeBehind="um.aspx.vb" Inherits="ICC.um" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="div_assign" runat="server">
        <div id="breadcrumb">
            <ul class="breadcrumb">
                <li><i class="fa fa-home"></i>&nbsp;<a href="dashboard.aspx">Home</a></li>
                <li class="active">User Setting Previledge</li>
            </ul>
        </div>
    </div>
    <div class="padding-md">
        <div class="row">
            <div>
                <dx:ASPxGridView ID="ASPxGridView1" ClientInstanceName="ASPxGridView1" runat="server" Theme="MetropolisBlue"
                    DataSourceID="sql_user" KeyFieldName="USERNAME" Width="100%">
                    <SettingsPager>
                        <AllButton Text="All">
                        </AllButton>
                        <NextPageButton Text="Next &gt;">
                        </NextPageButton>
                        <PrevPageButton Text="&lt; Prev">
                        </PrevPageButton>
                    </SettingsPager>
                    <SettingsPager PageSize="20" />
                     <SettingsEditing Mode="Inline" />
                    <Settings ShowFilterRow="true" ShowGroupPanel="false" ShowHorizontalScrollBar="false" />
                    <SettingsBehavior ConfirmDelete="true" />
                    <Columns>
                        <dx:GridViewCommandColumn Caption="Action" ButtonType="Image" Width="150px" HeaderStyle-HorizontalAlign="Center">
                            <NewButton Visible="true">
                                <Image Url="~/Images/icon/Apps-text-editor-icon2.png"></Image>
                            </NewButton>
                            <UpdateButton Visible="true">
                                <Image Url="~/Images/icon/Apps-text-editor-icon2.png"></Image>
                            </UpdateButton>
                            <DeleteButton Visible="true">
                                <Image Url="~/Images/icon/Actions-edit-clear-icon2.png"></Image>
                            </DeleteButton>
                            <CancelButton Visible="true">
                                <Image ToolTip="Cancel" Url="~/Images/icon/cancel1.png">
                                </Image>
                            </CancelButton>
                            <UpdateButton Visible="true">
                                <Image ToolTip="Update" Url="~/Images/icon/Updated1.png" />
                            </UpdateButton>
                        </dx:GridViewCommandColumn>
                        <dx:GridViewDataColumn FieldName="USERNAME" VisibleIndex="1" Settings-AutoFilterCondition="Contains" />
                        <dx:GridViewDataComboBoxColumn Caption="LEVELUSER" FieldName="LEVELUSER" HeaderStyle-HorizontalAlign="left">
                            <PropertiesComboBox TextField="Description" ValueField="LevelUserID" EnableSynchronization="False"
                                TextFormatString="{0}" IncrementalFilteringMode="Contains" DataSourceID="sql_level_user">
                                <Columns>
                                    <dx:ListBoxColumn Caption="ID" FieldName="LevelUserID" Width="50px" />
                                    <dx:ListBoxColumn Caption="Level User" FieldName="Description" Width="200px" />
                                </Columns>
                            </PropertiesComboBox>
                        </dx:GridViewDataComboBoxColumn>
                        <dx:GridViewDataColumn FieldName="FAX" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" />
                        <dx:GridViewDataColumn FieldName="SMS" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" />
                        <dx:GridViewDataColumn FieldName="EMAIL" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" />
                        <dx:GridViewDataColumn FieldName="CHAT" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" />
                        <dx:GridViewDataColumn FieldName="FACEBOOK" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" />
                        <dx:GridViewDataColumn FieldName="TWITTER" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" />
                    </Columns>
                    <Templates>
                        <DetailRow>
                            <dx:ASPxGridView ID="grid" Width="100%" runat="server" DataSourceID="sql_menu" KeyFieldName="MenuID" ClientInstanceName="grid"
                                SettingsBehavior-AllowFocusedRow="true" OnBeforePerformDataSelect="TicketNumber_DataSelect" Theme="MetropolisBlue">
                                <SettingsPager>
                                    <AllButton Text="All">
                                    </AllButton>
                                    <NextPageButton Text="Next &gt;">
                                    </NextPageButton>
                                    <PrevPageButton Text="&lt; Prev">
                                    </PrevPageButton>
                                </SettingsPager>
                                <SettingsPager PageSize="10" />
                                <SettingsEditing Mode="Inline" />
                                <Settings ShowGroupPanel="true" ShowHorizontalScrollBar="false" ShowFilterRow="true" />
                                <SettingsBehavior ConfirmDelete="true" />
                                <Columns>
                                    <dx:GridViewCommandColumn Caption="Action" ButtonType="Image" Width="150px" HeaderStyle-HorizontalAlign="Center">
                                        <NewButton Visible="true">
                                            <Image Url="~/Images/icon/Apps-text-editor-icon2.png"></Image>
                                        </NewButton>
                                        <DeleteButton Visible="true">
                                            <Image Url="~/Images/icon/Actions-edit-clear-icon2.png"></Image>
                                        </DeleteButton>
                                        <CancelButton>
                                            <Image ToolTip="Cancel" Url="~/Images/icon/cancel1.png">
                                            </Image>
                                        </CancelButton>
                                        <UpdateButton>
                                            <Image ToolTip="Update" Url="~/Images/icon/Updated1.png" />
                                        </UpdateButton>
                                    </dx:GridViewCommandColumn>
                                    <dx:GridViewDataTextColumn Caption="ID" FieldName="MenuID" Settings-AutoFilterCondition="Contains"
                                        CellStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="left">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataComboBoxColumn Caption="Menu" FieldName="MenuName" HeaderStyle-HorizontalAlign="left">
                                        <PropertiesComboBox TextField="MenuName" ValueField="MenuID" EnableSynchronization="False"
                                            TextFormatString="{0}" IncrementalFilteringMode="Contains" DataSourceID="sql_user_satu">
                                            <Columns>
                                                <dx:ListBoxColumn Caption="ID" FieldName="MenuID" Width="50px" />
                                                <dx:ListBoxColumn Caption="Menu" FieldName="MenuName" Width="200px" />
                                            </Columns>
                                        </PropertiesComboBox>
                                    </dx:GridViewDataComboBoxColumn>
                                </Columns>
                                <Templates>
                                    <DetailRow>
                                        <dx:ASPxGridView ID="GridList" Width="100%" runat="server" DataSourceID="sql_sub_menu"
                                            KeyFieldName="SubMenuID" OnBeforePerformDataSelect="GridList_DataSelect" Theme="MetropolisBlue">
                                            <SettingsEditing Mode="PopupEditForm" />
                                            <Settings VerticalScrollBarStyle="Standard" ShowGroupPanel="true" ShowHorizontalScrollBar="false" ShowFilterRow="true" />
                                            <Columns>
                                                <dx:GridViewCommandColumn Caption="Action" ButtonType="Image" Width="150px" HeaderStyle-HorizontalAlign="Center">
                                                    <NewButton Visible="true">
                                                        <Image Url="~/Images/icon/Apps-text-editor-icon2.png"></Image>
                                                    </NewButton>
                                                    <DeleteButton Visible="true">
                                                        <Image Url="~/Images/icon/Actions-edit-clear-icon2.png"></Image>
                                                    </DeleteButton>
                                                    <CancelButton>
                                                        <Image ToolTip="Cancel" Url="~/Images/icon/cancel1.png">
                                                        </Image>
                                                    </CancelButton>
                                                    <UpdateButton>
                                                        <Image ToolTip="Update" Url="~/Images/icon/Updated1.png" />
                                                    </UpdateButton>
                                                </dx:GridViewCommandColumn>
                                                <dx:GridViewDataTextColumn Caption="ID" FieldName="SubMenuID" Settings-AutoFilterCondition="Contains"
                                                    Width="50px" CellStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="left">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataComboBoxColumn Caption="Sub Menu" FieldName="SubMenuName" HeaderStyle-HorizontalAlign="left">
                                                    <PropertiesComboBox TextField="SubMenuName" ValueField="SubMenuID" EnableSynchronization="False"
                                                        TextFormatString="{0}" IncrementalFilteringMode="Contains" DataSourceID="sql_subMenu_dr">
                                                        <Columns>
                                                            <dx:ListBoxColumn Caption="ID" FieldName="SubMenuID" Width="50px" />
                                                            <dx:ListBoxColumn Caption="Sub Menu" FieldName="SubMenuName" Width="200px" />
                                                        </Columns>
                                                    </PropertiesComboBox>
                                                </dx:GridViewDataComboBoxColumn>
                                            </Columns>
                                            <Templates>
                                                <DetailRow>
                                                    <dx:ASPxGridView ID="gv_menu_tree" runat="server" Width="100%" DataSourceID="sql_menu_tree"
                                                        KeyFieldName="SubMenuIDTree" OnBeforePerformDataSelect="gv_menu_tree_DataSelect" Theme="MetropolisBlue">
                                                        <SettingsEditing Mode="Inline" />
                                                        <Settings VerticalScrollBarStyle="Standard" ShowGroupPanel="true" ShowHorizontalScrollBar="false" ShowFilterRow="true" />
                                                        <Columns>
                                                            <dx:GridViewCommandColumn Caption="Action" ButtonType="Image" Width="150px" HeaderStyle-HorizontalAlign="Center">
                                                                <NewButton Visible="true">
                                                                    <Image Url="~/Images/icon/Apps-text-editor-icon2.png"></Image>
                                                                </NewButton>
                                                                <DeleteButton Visible="true">
                                                                    <Image Url="~/Images/icon/Actions-edit-clear-icon2.png"></Image>
                                                                </DeleteButton>
                                                                <CancelButton>
                                                                    <Image ToolTip="Cancel" Url="~/Images/icon/cancel1.png">
                                                                    </Image>
                                                                </CancelButton>
                                                                <UpdateButton>
                                                                    <Image ToolTip="Update" Url="~/Images/icon/Updated1.png" />
                                                                </UpdateButton>
                                                            </dx:GridViewCommandColumn>
                                                            <dx:GridViewDataTextColumn Caption="ID" FieldName="SubMenuIDTree" Settings-AutoFilterCondition="Contains"
                                                                Width="50px" CellStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="left">
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataComboBoxColumn Caption="Menu Tree" FieldName="MenuTreeName" HeaderStyle-HorizontalAlign="left">
                                                                <PropertiesComboBox TextField="MenuTreeName" ValueField="SubMenuIDTree" EnableSynchronization="False"
                                                                    TextFormatString="{0}" IncrementalFilteringMode="Contains" DataSourceID="sql_User3">
                                                                    <Columns>
                                                                        <dx:ListBoxColumn Caption="ID" FieldName="SubMenuIDTree" Width="50px" />
                                                                        <dx:ListBoxColumn Caption="Menu Tree" FieldName="MenuTreeName" Width="200px" />
                                                                    </Columns>
                                                                </PropertiesComboBox>
                                                            </dx:GridViewDataComboBoxColumn>
                                                        </Columns>
                                                    </dx:ASPxGridView>
                                                </DetailRow>
                                            </Templates>
                                            <SettingsDetail ShowDetailRow="true" />
                                            <Settings ShowFooter="True" />
                                        </dx:ASPxGridView>
                                    </DetailRow>
                                </Templates>
                                <SettingsDetail ShowDetailRow="true" />
                                <Settings ShowFooter="True" />
                            </dx:ASPxGridView>
                        </DetailRow>
                    </Templates>
                    <SettingsDetail ShowDetailRow="true" />
                    <Settings ShowFooter="True" />
                </dx:ASPxGridView>
                <asp:SqlDataSource ID="sql_menu" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
                <asp:SqlDataSource ID="sql_sub_menu" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
                <asp:SqlDataSource ID="sql_user" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
                <asp:SqlDataSource ID="sql_user_satu" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"
                    SelectCommand="SELECT * FROM User1"></asp:SqlDataSource>
                <asp:SqlDataSource ID="sql_subMenu_dr" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
                <asp:SqlDataSource ID="sql_menu_tree" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
                <asp:SqlDataSource ID="sql_User3" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
                <asp:SqlDataSource ID="sql_level_user" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
            
            </div>
        </div>
    </div>
</asp:Content>
