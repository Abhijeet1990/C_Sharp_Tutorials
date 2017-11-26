<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContactListForm.aspx.cs" Inherits="RTPInventoryManagement.ContactListForm" %>

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
    
        <asp:Label ID="Label1" runat="server" CssClass="auto-style1" Text="Plant Contacts"></asp:Label>
    </br>
        </br>
    </div>
        <div>
            <asp:GridView ID="ContactListGridView" runat="server" ShowFooter="false" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" AutoGenerateColumns="False" DataKeyNames="id" OnPageIndexChanging="OnDerateGVPageIndexChanging" OnRowCancelingEdit="OnDerateGVRowCancelingEdit" OnRowDeleting="OnDerateGVRowDeleting" OnRowEditing="OnDerateGVRowEditing" OnRowUpdating="OnDerateGVRowUpdating" BackColor="Yellow"  OnRowDataBound="OnForecastDerateGridViewRowDataBound" ShowHeaderWhenEmpty="true" Style="font-family: Arial" OnRowCommand="OnForecastDerateGridViewRowCommand" CssClass="auto-style2">
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
                        <asp:TemplateField HeaderText="Name">
                            <EditItemTemplate>
                                <asp:TextBox ID="EditNameTB" runat="server"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="NameLabel" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="InsertNameTB" runat="server"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Company">
                            <EditItemTemplate>
                                <asp:DropDownList ID="EditCompanyDD" runat="server" AutoPostBack="true">
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="CompanyLabel" runat="server" Text='<%# Bind("Company") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:DropDownList ID="InsertCompanyDD" runat="server" AutoPostBack="true" OnSelectedIndexChanged="OnInsertCompanyDDSelectedIndexChanged">
                                </asp:DropDownList>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Title">
                            <EditItemTemplate>
                                <asp:TextBox ID="EditTitleTB" runat="server"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="TitleLabel" runat="server" Text='<%# Bind("Title") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="InsertTitleTB" runat="server"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Email">
                            <EditItemTemplate>
                                <asp:TextBox ID="EditEmailTB" runat="server" Text='<%# Bind("Email") %>' Width="100px" />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="EmailLabel" runat="server" Text='<%# Bind("Email") %>' />
                            </ItemTemplate>
                         <FooterTemplate>
                                <asp:TextBox ID="InsertEmailTB" runat="server" Width="100px"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Office No">
                            <EditItemTemplate>
                                <asp:TextBox ID="EditOfficeTB" runat="server" Text='<%# Bind("Office") %>' Width="100px" />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="OfficeLabel" runat="server" Text='<%# Bind("Office") %>' />
                            </ItemTemplate>
                         <FooterTemplate>
                                <asp:TextBox ID="InsertOfficeTB" runat="server" Width="100px"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Mobile No">
                            <EditItemTemplate>
                                <asp:TextBox ID="EditMobileTB" runat="server" Text='<%# Bind("Mobile") %>' Width="100px" />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="MobileLabel" runat="server" Text='<%# Bind("Mobile") %>' />
                            </ItemTemplate>
                         <FooterTemplate>
                                <asp:TextBox ID="InsertMobileTB" runat="server" Width="100px"></asp:TextBox>
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
