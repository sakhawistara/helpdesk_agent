<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AppSetting.aspx.vb" Inherits="ICC.AppSetting" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <dx:ASPxGridView ID="gv_app" runat="server" KeyFieldName="ID"
                DataSourceID="sql_app" Width="100%" Theme="MetropolisBlue">
                <SettingsPager>
                    <AllButton Text="All">
                    </AllButton>
                    <NextPageButton Text="Next &gt;">
                    </NextPageButton>
                    <PrevPageButton Text="&lt; Prev">
                    </PrevPageButton>
                </SettingsPager>
                <SettingsEditing Mode="Inline" />
                <Settings ShowFilterRow="true" ShowFilterRowMenu="false" ShowGroupPanel="true"
                    ShowVerticalScrollBar="false" ShowHorizontalScrollBar="false" />
                <SettingsBehavior ConfirmDelete="true" />
                <Columns>
                    <dx:GridViewCommandColumn Caption="Action" HeaderStyle-HorizontalAlign="Center" VisibleIndex="0"
                        ButtonType="Image" FixedStyle="Left" CellStyle-BackColor="#ffffd6" Width="130px">
                        <EditButton Visible="True">
                            <Image ToolTip="Edit" Url="HTML/img/icon/Text-Edit-icon2.png" />
                        </EditButton>
                        <NewButton Visible="false">
                            <Image ToolTip="New" Url="HTML/img/icon/Apps-text-editor-icon2.png" />
                        </NewButton>
                        <DeleteButton Visible="false">
                            <Image ToolTip="Delete" Url="HTML/img/icon/Actions-edit-clear-icon2.png" />
                        </DeleteButton>
                        <CancelButton>
                            <Image ToolTip="Cancel" Url="HTML/img/icon/cancel1.png">
                            </Image>
                        </CancelButton>
                        <UpdateButton>
                            <Image ToolTip="Update" Url="HTML/img/icon/Updated1.png" />
                        </UpdateButton>
                        <CellStyle BackColor="#FFFFD6">
                        </CellStyle>
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataTextColumn Caption="ID" FieldName="ID" ></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="User" FieldName="UserID"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataComboBoxColumn Caption="Ticket" FieldName="Ticket">
                        <PropertiesComboBox>
                            <Items>
                                <dx:ListEditItem Text="Yes" Value="Yes" />
                                <dx:ListEditItem Text="No" Value="No" />
                            </Items>
                        </PropertiesComboBox>
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataComboBoxColumn Caption="Email" FieldName="Email">
                        <PropertiesComboBox>
                            <Items>
                                <dx:ListEditItem Text="Yes" Value="Yes" />
                                <dx:ListEditItem Text="No" Value="No" />
                            </Items>
                        </PropertiesComboBox>
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataComboBoxColumn Caption="Twitter" FieldName="Twitter">
                        <PropertiesComboBox>
                            <Items>
                                <dx:ListEditItem Text="Yes" Value="Yes" />
                                <dx:ListEditItem Text="No" Value="No" />
                            </Items>
                        </PropertiesComboBox>
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataComboBoxColumn Caption="Facebook" FieldName="Facebook">
                        <PropertiesComboBox>
                            <Items>
                                <dx:ListEditItem Text="Yes" Value="Yes" />
                                <dx:ListEditItem Text="No" Value="No" />
                            </Items>
                        </PropertiesComboBox>
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataComboBoxColumn Caption="Fax" FieldName="Fax">
                        <PropertiesComboBox>
                            <Items>
                                <dx:ListEditItem Text="Yes" Value="Yes" />
                                <dx:ListEditItem Text="No" Value="No" />
                            </Items>
                        </PropertiesComboBox>
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataComboBoxColumn Caption="Chat" FieldName="Chat">
                        <PropertiesComboBox>
                            <Items>
                                <dx:ListEditItem Text="Yes" Value="Yes" />
                                <dx:ListEditItem Text="No" Value="No" />
                            </Items>
                        </PropertiesComboBox>
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataComboBoxColumn Caption="Sms" FieldName="Sms">
                        <PropertiesComboBox>
                            <Items>
                                <dx:ListEditItem Text="Yes" Value="Yes" />
                                <dx:ListEditItem Text="No" Value="No" />
                            </Items>
                        </PropertiesComboBox>
                        <DataItemTemplate>
                            <dx:ASPxCheckBox ID="xx" runat="server"></dx:ASPxCheckBox>
                        </DataItemTemplate>
                    </dx:GridViewDataComboBoxColumn>
                    
                </Columns>
                
            </dx:ASPxGridView>
            <asp:SqlDataSource ID="sql_app" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
