<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/HTML/Ticket.Master" CodeBehind="karyawan.aspx.vb" Inherits="ICC.karyawan" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
    <script>
        function OnRowClick(s, e) {
            grid.GetRowValues(grid.GetFocusedRowIndex(), 'NIK;', OnGetRowValuesss);
        }
        function OnGetRowValuesss(values) {
            //alert(values[0]); //ini dapetin id
            document.getElementById('MainContent_GetIDs').value = values[0]; //ini dapetin id
            //document.getElementById('GetExtension').value = values[3]; //ini dapetin extension
            //document.getElementById('GetName').value = values[4]; //ini dapetin Name
            //document.getElementById('GetDate').value = values[5]; //ini dapetin Date
            //document.getElementById("player").URL = "../VoiceVRWeb/" + values[1];
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div id="div_karyawan" runat="server">
        <div id="breadcrumb">
            <ul class="breadcrumb">
                <li><i class="fa fa-home"></i>&nbsp;<a href="dashboard.aspx">Home</a></li>
                <li class="active">Karyawan</li>
            </ul>
        </div>
        <div class="padding-md">
            <div class="row">
                <dx:ASPxGridView ID="Grid" Width="100%" ClientInstanceName="grid" runat="server" Theme="MetropolisBlue"
                    DataSourceID="SqlDataSource1" KeyFieldName="ID" SettingsBehavior-AllowFocusedRow="true"
                    Styles-FocusedRow-BackColor="white" SettingsPager-PageSize="10" Styles-FocusedRow-ForeColor="black">
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
                        ShowVerticalScrollBar="false" ShowHorizontalScrollBar="true" />
                    <SettingsBehavior ConfirmDelete="true" />
                    <Styles>
                        <%--<Header BackColor="#a5a494" ForeColor="White" HorizontalAlign="Center" Font-Bold="true">
                        </Header>--%>
                    </Styles>
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
                        <dx:GridViewDataTextColumn Caption="NIK" FieldName="NIK" VisibleIndex="1" Width="100px" Settings-AutoFilterCondition="Contains"
                            HeaderStyle-HorizontalAlign="Center">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption=" Name " FieldName="Name" VisibleIndex="2" Width="250px" Settings-AutoFilterCondition="Contains"
                            HeaderStyle-HorizontalAlign="Center">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataDateColumn FieldName="TanggalLahir" Caption="Date Of Birth" VisibleIndex="3"
                            UnboundType="String" HeaderStyle-HorizontalAlign="Center" Width="150px">
                            <%--<PropertiesDateEdit DisplayFormatString="MM-dd-yyyy">
                            </PropertiesDateEdit>--%>
                            <PropertiesDateEdit DisplayFormatString="{0:d-M-yyyy}"></PropertiesDateEdit>
                            <Settings AllowAutoFilterTextInputTimer="True" />
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        </dx:GridViewDataDateColumn>
                        <dx:GridViewDataTextColumn Caption=" Handphone  " FieldName="Handphone" VisibleIndex="4" Settings-AutoFilterCondition="Contains"
                            HeaderStyle-HorizontalAlign="Center">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption=" Email  " FieldName="Email" VisibleIndex="5" Settings-AutoFilterCondition="Contains"
                            Width="200" HeaderStyle-HorizontalAlign="Center">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataComboBoxColumn Caption="Gender" FieldName="JenisKelamin" VisibleIndex="6"
                            HeaderStyle-HorizontalAlign="Center" Width="100px">
                            <PropertiesComboBox TextField="Gender" ValueField="Gender" EnableSynchronization="False"
                                TextFormatString="{0}" IncrementalFilteringMode="StartsWith">
                                <Items>
                                    <dx:ListEditItem Text="Male" Value="Male" />
                                    <dx:ListEditItem Text="Female" Value="Female" />
                                </Items>
                            </PropertiesComboBox>
                        </dx:GridViewDataComboBoxColumn>
                        <dx:GridViewDataTextColumn Caption=" Division  " FieldName="Divisi" VisibleIndex="7" Settings-AutoFilterCondition="Contains"
                            HeaderStyle-HorizontalAlign="Center" Width="250px">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption=" Address  " FieldName="Address" VisibleIndex="8" Settings-AutoFilterCondition="Contains"
                            HeaderStyle-HorizontalAlign="Center" Width="250px">
                        </dx:GridViewDataTextColumn>
                    </Columns>
                </dx:ASPxGridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
            </div>
        </div>
    </div>
</asp:Content>
