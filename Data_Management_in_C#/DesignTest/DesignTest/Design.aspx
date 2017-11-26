<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Design.aspx.cs" Inherits="DesignTest.Design" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style2 {
            width: 27%;
            height: 161px;
        }
        .auto-style3 {
            height: 34px;
        }
        .auto-style4 {
            height: 23px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table class="auto-style2">
            <tr>
                <td>&nbsp;</td>
                <td><asp:Label ID="siteLabel" runat="server" Text="Site " Font-Bold="True" Font-Italic="False" Font-Size="Large" ForeColor="#0099FF" Style="font-family: Arial"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="SiteListDD" runat="server" AutoPostBack="True" BackColor="White" Font-Size="Large" Height="36px" OnSelectedIndexChanged="SiteListDD_SelectedIndexChanged" style="color: #008000; font-weight: 700; font-family: Arial; text-align: right;" Width="140px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td >
                    &nbsp;</td>
                <td >
                    <asp:Label ID="blockLabel" runat="server" Font-Bold="True" Font-Italic="False" Font-Size="Large" ForeColor="#0099FF" Style="font-family: Arial" Text="Block "></asp:Label>
                </td>
                <td >
                    <asp:DropDownList ID="BlockListDD" runat="server" AutoPostBack="true" BackColor="White" Font-Size="Large" Height="36px" OnSelectedIndexChanged="BlockListDD_SelectedIndexChanged" style="color: #008000; font-weight: 700; font-family: Arial; text-align: right; margin-left: 0px;" Width="140px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#0099FF" Style="font-family: Arial" Text="Type"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="FileTypeSelection" runat="server" AutoPostBack="true" Font-Size="Large" Height="36px" OnSelectedIndexChanged="FileTypeSelection_SelectedIndexChanged" style="color: #008000; font-family: Arial; font-weight: 700; text-align: right;" Width="140px">
                        <asp:ListItem Selected="True">Trader</asp:ListItem>
                    <asp:ListItem>Operator</asp:ListItem>
                    <asp:ListItem>RawFile</asp:ListItem>
                    <asp:ListItem>Formula</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style4"></td>
                <td class="auto-style4"></td>
                <td class="auto-style4"></td>
            </tr>
            <tr>
                <td class="auto-style3">
                    &nbsp;</td>
                <td class="auto-style3">
                    
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#0099FF" Style="font-family: Arial" Text="Forecast"></asp:Label>
                    
                </td>
                <td class="auto-style3">
                    <asp:RadioButton ID="realTimeRadio" runat="server" Text="RT" AutoPostBack="true" GroupName="DaySearchType" OnCheckedChanged="realTimeRadio_CheckedChanged" Font-Italic="False" Font-Size="Medium"  Font-Bold="True" ForeColor="#006600" Checked="True" style="text-align: right" />
                <asp:RadioButton ID="dayAheadRadio" runat="server" Text="DA" AutoPostBack="true" GroupName="DaySearchType" OnCheckedChanged="dayAheadRadio_CheckedChanged" Font-Italic="False" Font-Size="Medium" Font-Bold="True" ForeColor="#006600" style="text-align: right" />
                </td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td class="auto-style3">
                    &nbsp;</td>
                <td class="auto-style3">
                    
                    <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#0099FF" Style="font-family: Arial" Text="Format"></asp:Label>
                    
                </td>
                <td class="auto-style3">
                    <asp:RadioButton ID="chartRadio" runat="server" AutoPostBack="true" Checked="True" Font-Bold="True" Font-Italic="False" Font-Size="Medium" ForeColor="#006600" GroupName="SearchType" OnCheckedChanged="chartRadio_CheckedChanged" style="text-align: right" Text="Chart" />
                    <asp:RadioButton ID="tableRadio" runat="server" AutoPostBack="true" Font-Bold="True" Font-Italic="False" Font-Size="Medium" ForeColor="#006600" GroupName="SearchType" OnCheckedChanged="tableRadio_CheckedChanged" style="text-align: right" Text="Table" />
                </td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td ></td>
                <td>
                    <asp:ImageButton ID="GetForecastButton" runat="server" Height="35px" ImageUrl="~/Images/go.gif" OnClick="GetForecastButton_Click" Width="96px" />
                </td>
                <td>
                    <asp:ImageButton ID="DownloadButton" runat="server" Height="36px" ImageUrl="~/Images/download.png" OnClick="DownloadButton_Click" Width="36px" />
                </td>
            </tr>

        </table>
    </div>
    </form>
</body>
</html>
