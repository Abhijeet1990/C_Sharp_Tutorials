<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Addrow.aspx.cs" Inherits="GridViewAddrow.Addrow" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:gridview ID="Gridview1" runat="server" ShowFooter="true"
                             AutoGenerateColumns="false">
        <Columns>
        <asp:BoundField DataField="RowNumber" HeaderText="Row Number" />
        <asp:TemplateField HeaderText="Header 1">
            <ItemTemplate>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </ItemTemplate>
            <FooterTemplate>
                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Header 2">
            <ItemTemplate>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </ItemTemplate>
            <FooterTemplate>
                <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Header 3">
            <ItemTemplate>
                 <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            </ItemTemplate>
            <FooterStyle HorizontalAlign="Right" />
            <FooterTemplate>
                 <asp:Button ID="ButtonAdd" runat="server" Text="Add New Row" onclick="ButtonAdd_Click"/>
            </FooterTemplate>
        </asp:TemplateField>
        </Columns>
</asp:gridview>
    </div>
    </form>
</body>
</html>
