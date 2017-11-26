<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ServerListForm.aspx.cs" Inherits="RTPInventoryManagement.ServerListForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-family: Arial, Helvetica, sans-serif;
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>   
        <asp:Label ID="Label1" runat="server" CssClass="auto-style1" Text="PROPTIM Server List"></asp:Label>   
        <br/>
        <br/>
    </div>
        <div>
            <asp:GridView ID="ProptimServerGridView" runat="server" ShowFooter="false" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" AutoGenerateColumns="False" DataKeyNames="id" OnPageIndexChanging="OnDerateGVPageIndexChanging" OnRowCancelingEdit="OnDerateGVRowCancelingEdit" OnRowDeleting="OnDerateGVRowDeleting" OnRowEditing="OnDerateGVRowEditing" OnRowUpdating="OnDerateGVRowUpdating" BackColor="Yellow"  OnRowDataBound="OnForecastDerateGridViewRowDataBound" ShowHeaderWhenEmpty="true" Style="font-family: Arial" OnRowCommand="OnForecastDerateGridViewRowCommand" CssClass="auto-style2">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="ibEdit" runat="server" CommandName="Edit" ImageUrl="~/Images/Edit.png" Height="20px" Width="20px" ToolTip="Edit Derate"/>
                                <asp:ImageButton ID="ibDelete" runat="server" CommandName="Delete" ImageUrl="~/Images/Delete.png" Height="20px" Width="20px" ToolTip="Delete Derate"/>
                                <asp:ImageButton ID="ibPreview" runat="server" OnClick="OnPreviewImageClick" ImageUrl="~/Images/Preview.png" Height="20px" Width="20px" ToolTip="Preview Derate"/>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:ImageButton ID="ibUpdate" runat="server" CommandName="Update" ImageUrl="~/Images/Update.png" Height="20px" Width="20px" ToolTip="Update Derate"/>
                                <asp:ImageButton ID="ibCancel" runat="server" CommandName="Cancel" ImageUrl="~/Images/Cancel.png" Height="20px" Width="20px" ToolTip="Cancel Edit"/>
                                <asp:ImageButton ID="ibPreviewEdit" runat="server" OnClick="OnPreviewImageEditClick" ImageUrl="~/Images/Preview.png" Height="20px" Width="20px" ToolTip="Preview Derate"/>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:ImageButton ID="ibInsert" runat="server" OnClick="OnAddButtonClick" ImageUrl="~/Images/Update.png" Height="20px" Width="20px" ToolTip="Update Derate"/>
                                <asp:ImageButton ID="ibCancelInsert" runat="server" OnClick="OnInsertCancelClick" ImageUrl="~/Images/Cancel.png" Height="20px" Width="20px" ToolTip="Cancel Edit"/>
                                <asp:ImageButton ID="ibPreviewInsert" runat="server" OnClick="OnPreviewImageInsertClick" ImageUrl="~/Images/Preview.png" Height="20px" Width="20px" ToolTip="Preview Derate"/>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Active">
                            <ItemTemplate>
                                <asp:CheckBox ID="ActiveCB" runat="server" Checked='<%# bool.Parse(Eval("Active").ToString())%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Site">
                            <EditItemTemplate>
                                <asp:DropDownList ID="SiteDD" runat="server" AutoPostBack="true">
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="SiteLabel" runat="server" Text='<%# Bind("Site") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:DropDownList ID="InsertSiteDD" runat="server" AutoPostBack="true" OnSelectedIndexChanged="OnInsertSiteDDSelectedIndexChanged">
                                </asp:DropDownList>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Block">
                            <EditItemTemplate>
                                <asp:DropDownList ID="BlockDD" runat="server" AutoPostBack="true">
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="BlockLabel" runat="server" Text='<%# Bind("Block") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:DropDownList ID="InsertBlockDD" runat="server" AutoPostBack="true">
                                </asp:DropDownList>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Server">
                            <EditItemTemplate>
                                <asp:TextBox ID="EditServer" runat="server" Text='<%# Bind("Server") %>' Width="100px" />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="DisplayServer" runat="server" Text='<%# Bind("Server") %>' />
                            </ItemTemplate>

                            <FooterTemplate>
                                <asp:TextBox ID="InsertServer" runat="server" Width="100px"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="IP Address">
                            <EditItemTemplate>
                                <asp:TextBox ID="EditAddressTB" runat="server"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="DisplayAddressLabel" runat="server" Text='<%# Bind("IpAddress") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="InsertAddressTB" runat="server"></asp:TextBox>                                
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Issues">
                            <EditItemTemplate>
                                <asp:TextBox ID="EditIssue" runat="server" Text='<%# Bind("Issue") %>' Width="100px" />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="DisplayIssue" runat="server" Text='<%# Bind("Issue") %>' />
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="InsertIssue" runat="server" Width="100px"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>

                        <asp:CommandField ShowEditButton="false" />
                        <asp:CommandField ShowDeleteButton="false" />


                    </Columns>
                    <EditRowStyle BackColor="#add8e6" />
                    <FooterStyle BackColor="#add8e6" Font-Bold="True" ForeColor="#003399" />
                    <HeaderStyle BackColor="#add8e6" Font-Bold="True" ForeColor="#003399" HorizontalAlign="Center" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
        </div>
    </form>
</body>
</html>
