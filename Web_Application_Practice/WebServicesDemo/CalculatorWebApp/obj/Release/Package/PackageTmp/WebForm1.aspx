<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="CalculatorWebApp.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table style ="font-family:Arial">
            <tr>
                    <td>
                    <b>First Number</b>
                    </td>
                    <td>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </td>
                
            </tr>
            <tr>
                    <td>
                    <b>Second Number</b>
                    </td>
                    <td>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    </td>
                
            </tr>
            <tr>
                    <td>
                    <b>Result</b>
                    </td>
                    <td>
                    <asp:Label ID="lblResult" runat="server"></asp:Label>
                    </td>
                
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
                    <asp:Button ID="btnSubstract" runat="server" Text="Substract" OnClick="btnSubstract_Click" />
                    <asp:Button ID="btnMultiply" runat="server" Text="Multiply" OnClick="btnMultiply_Click" />
                    <asp:Button ID="btnDivide" runat="server" Text="Divide" OnClick="btnDivide_Click" />
                </td>
                <td colspan="2">
                    &nbsp;</td>
                <td colspan="2">
                    &nbsp;</td>
                <td colspan="2">
                    &nbsp;</td>
            </tr>
        </table>
    <div>
    
    </div>
    </form>
</body>
</html>
