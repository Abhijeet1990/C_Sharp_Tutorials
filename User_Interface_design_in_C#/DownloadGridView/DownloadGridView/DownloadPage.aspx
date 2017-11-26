<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DownloadPage.aspx.cs" Inherits="DownloadGridView.DownloadPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Customer Id" ItemStyle-Width="100" />
                    <asp:BoundField DataField="Name" HeaderText="Name" ItemStyle-Width="150" />
                    <asp:BoundField DataField="Country" HeaderText="Country" ItemStyle-Width="150" />
                    <asp:BoundField DataField="Age" HeaderText="Age" ItemStyle-Width="100" />
                    <asp:BoundField DataField="Sex" HeaderText="Sex" ItemStyle-Width="150" />
                    <asp:BoundField DataField="NickName" HeaderText="NickName" ItemStyle-Width="150" />
                </Columns>
            </asp:GridView>
            <br />
            <asp:Button Text="Export" OnClick="ExportTextFile" runat="server" />
        </div>
    </form>
</body>
</html>
