<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestDownLoad.aspx.cs" Inherits="RTPWebForecastService.TestDownLoad" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
            <br />
            <asp:Button Text="Export" OnClick="ExportTextFile" runat="server" />
        </div>
    </form>
</body>
</html>
