<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InventoryListForm.aspx.cs" Inherits="RTPInventoryManagement.InventoryListForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" CssClass="auto-style1" Text="Inventory List" style="font-family: Arial, Helvetica, sans-serif; font-weight: bold"></asp:Label>
    </br>
        </br>
    </div>
        <div>
            <asp:GridView ID="InventoryListGridView" runat="server" ShowFooter="false" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" AutoGenerateColumns="False" DataKeyNames="id" OnPageIndexChanging="OnDerateGVPageIndexChanging" OnRowCancelingEdit="OnDerateGVRowCancelingEdit" OnRowDeleting="OnDerateGVRowDeleting" OnRowEditing="OnDerateGVRowEditing" OnRowUpdating="OnDerateGVRowUpdating" BackColor="Yellow"  OnRowDataBound="OnForecastDerateGridViewRowDataBound" ShowHeaderWhenEmpty="true" Style="font-family: Arial" OnRowCommand="OnForecastDerateGridViewRowCommand" CssClass="auto-style2">
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
                        <asp:TemplateField HeaderText="Part No.">
                            <EditItemTemplate>
                                <asp:TextBox ID="EditPartTB" runat="server"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="PartLabel" runat="server" Text='<%# Bind("PartNo") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="InsertPartTB" runat="server"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Name">
                            <EditItemTemplate>
                                <asp:TextBox ID="EditNameTB" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="NameLabel" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="InsertNameTB" runat="server"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Description">
                            <EditItemTemplate>
                                <asp:TextBox ID="EditDescriptionTB" runat="server" Text='<%# Bind("Description") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="DescriptionLabel" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="InsertDescriptionTB" runat="server"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Vendor">
                            <EditItemTemplate>
                                <asp:TextBox ID="EditVendorTB" runat="server" Text='<%# Bind("Vendor") %>' Width="100px" />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="VendorLabel" runat="server" Text='<%# Bind("Vendor") %>' />
                            </ItemTemplate>
                         <FooterTemplate>
                                <asp:TextBox ID="InsertVendorTB" runat="server" Width="100px"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Lead Time(in Weeks)">
                            <EditItemTemplate>
                                <asp:TextBox ID="EditLeadTimeTB" runat="server" Text='<%# Bind("LeadTime") %>' Width="100px" />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="LeadTimeLabel" runat="server" Text='<%# Bind("LeadTime") %>' />
                            </ItemTemplate>
                         <FooterTemplate>
                                <asp:TextBox ID="InsertLeadTimeTB" runat="server" Width="100px"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="In Stock">
                            <EditItemTemplate>
                                <asp:TextBox ID="EditStockTB" runat="server" Text='<%# Bind("Stock") %>' Width="100px" />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="StockLabel" runat="server" Text='<%# Bind("Stock") %>' />
                            </ItemTemplate>
                         <FooterTemplate>
                                <asp:TextBox ID="InsertStockTB" runat="server" Width="100px"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Required">
                            <EditItemTemplate>
                                <asp:TextBox ID="EditRequiredTB" runat="server" Text='<%# Bind("Required") %>' Width="100px" />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="RequiredLabel" runat="server" Text='<%# Bind("Required") %>' />
                            </ItemTemplate>
                         <FooterTemplate>
                                <asp:TextBox ID="InsertRequiredTB" runat="server" Width="100px"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Need To Order">
                            <EditItemTemplate>
                                <asp:TextBox ID="EditOrderTB" runat="server" Text='<%# Bind("Order") %>' Width="100px" />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="OrderLabel" runat="server" Text='<%# Bind("Order") %>' />
                            </ItemTemplate>
                         <FooterTemplate>
                                <asp:TextBox ID="InsertOrderTB" runat="server" Width="100px"></asp:TextBox>
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
