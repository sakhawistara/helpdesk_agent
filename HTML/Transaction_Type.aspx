<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/HTML/Ticket.Master" CodeBehind="Transaction_Type.aspx.vb" Inherits="ICC.Transaction_Type" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="div_transaction_type" runat="server">
        <div id="breadcrumb">
            <ul class="breadcrumb">
                <li><i class="fa fa-home"></i>&nbsp;<a href="dashboard.aspx">Home</a></li>
                <li class="active">Transaction Type</li>
            </ul>
        </div>
        <div class="padding-md">
            <div class="row">
                <dx:ASPxGridView ID="gv_transaction_type" runat="server" KeyFieldName="CategoryID"
                    DataSourceID="sql_transaction_type" Width="100%" Theme="MetropolisBlue">
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
                                <Image ToolTip="Edit" Url="img/icon/Text-Edit-icon2.png" />
                            </EditButton>
                            <NewButton Visible="True">
                                <Image ToolTip="New" Url="img/icon/Apps-text-editor-icon2.png" />
                            </NewButton>
                            <DeleteButton Visible="True">
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
                        <dx:GridViewDataTextColumn Caption="ID" FieldName="CategoryID" ReadOnly="true" PropertiesTextEdit-ReadOnlyStyle-BackColor="LightGray"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Name" FieldName="Name"></dx:GridViewDataTextColumn>
                    </Columns>
                </dx:ASPxGridView>
            </div>
            <!-- /.row -->
        </div>
        <asp:SqlDataSource ID="sql_transaction_type" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
    </div>
</asp:Content>
