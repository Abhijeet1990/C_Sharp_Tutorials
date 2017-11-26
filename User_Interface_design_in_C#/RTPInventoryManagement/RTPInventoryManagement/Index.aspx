<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="RTPInventoryManagement.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style2 {
            font-family: Arial, Helvetica, sans-serif;
            font-size: x-large;
            font-weight: bold;
        }
        .auto-style3 {
            font-family: Arial, Helvetica, sans-serif;
            font-weight: bold;
            font-size: small;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="auto-style2">
    
        Inventory Management System</div>
        <div>
            </br></br>
        </div>

        <div>
            <asp:Menu ID="Menu1" runat="server" CssClass="auto-style3" BackColor="#FFFBD6" DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="Large" ForeColor="#990000" StaticSubMenuIndent="10px">
                <DynamicHoverStyle BackColor="#990000" ForeColor="White" />
                <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                <DynamicMenuStyle BackColor="#FFFBD6" />
                <DynamicSelectedStyle BackColor="#FFCC66" />
                <Items>
                    <asp:MenuItem Text="Contact List" Value="Contact List" NavigateUrl="~/ContactListForm.aspx"></asp:MenuItem>
                    <asp:MenuItem Text="Inventory List" Value="Inventory List" NavigateUrl="~/InventoryListForm.aspx"></asp:MenuItem>
                    <asp:MenuItem Text="Performance Monitoring" Value="Performance Monitoring" NavigateUrl="~/PerformanceMonitoringForm.aspx"></asp:MenuItem>
                    <asp:MenuItem Text="Server List" Value="Server List" NavigateUrl="~/ServerListForm.aspx"></asp:MenuItem>
                </Items>
                <StaticHoverStyle BackColor="#990000" ForeColor="White" />
                <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                <StaticSelectedStyle BackColor="#FFCC66" />
            </asp:Menu>
        </div>
    </form>
</body>
</html>
