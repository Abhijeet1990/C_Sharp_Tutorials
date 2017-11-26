<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PerformanceMonitoringForm.aspx.cs" Inherits="RTPInventoryManagement.PerformanceMonitoringForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
     .auto-style10 {
            font-family: Arial, Helvetica, sans-serif;
            font-weight: bold;
            color: #003399;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>   
        <asp:Label ID="Label1" runat="server" CssClass="auto-style1" Text="Performance Monitoring" style="font-family: Arial, Helvetica, sans-serif; font-weight: bold"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <span class="auto-style10">Site </span> <asp:DropDownList ID="SiteDDList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="OnSiteDDSelectedIndexChanged" Height="30px"></asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
           <span class="auto-style10">Block </span> <asp:DropDownList ID="BlockDDList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="OnBlockDDSelectedIndexChanged" Height="30px"></asp:DropDownList></br></br>
    </br>
        </br>
    </div>
        <div>
            <asp:GridView ID="PerformanceMonitoringGridView" runat="server" ShowFooter="false" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" AutoGenerateColumns="False" DataKeyNames="id" OnPageIndexChanging="OnDerateGVPageIndexChanging" OnRowCancelingEdit="OnDerateGVRowCancelingEdit" OnRowDeleting="OnDerateGVRowDeleting" OnRowEditing="OnDerateGVRowEditing" OnRowUpdating="OnDerateGVRowUpdating" BackColor="Yellow"  OnRowDataBound="OnForecastDerateGridViewRowDataBound" ShowHeaderWhenEmpty="true" Style="font-family: Arial" OnRowCommand="OnForecastDerateGridViewRowCommand" CssClass="auto-style2">
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
                        <asp:TemplateField HeaderText="Date">
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
                        <asp:TemplateField HeaderText="Status">
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
