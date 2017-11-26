<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ColumnSelectionForm.aspx.cs" Inherits="RTPWebForecastService.ColumnSelectionForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reports</title>
    <style type="text/css">
        .auto-style1 {
            top: 147px;
            position: absolute;
            left: 219px;
            width: 38px;
            height: 30px;
            background-color: #FFFFFF;
            z-index: 1;
            bottom: 515px;
        }
        .auto-style4 {
            top: 148px;
            background-color: #FFFFFF;
            position: absolute;
            left: 458px;
            z-index: 1;
        }
        .auto-style6 {
            font-family: Arial, Helvetica, sans-serif;
        }
        .auto-style7 {
            left: 308px;
            position: absolute;
            top: 308px;
            height: 30px;
            background-color: #FFFFFF;
            z-index: 1;
            bottom: 354px;
            width: 59px;
        }
        .auto-style8 {
            left: 374px;
            position: absolute;
            top: 308px;
            background-color: #FFFFFF;
            z-index: 1;
            height: 30px;
        }
        .auto-style9 {
            color: #003399;
            font-weight: bold;
        }
        .auto-style10 {
            font-family: Arial, Helvetica, sans-serif;
            font-weight: bold;
            color: #003399;
        }
        .auto-style11 {
            left: 18px;
            font-family: Arial, Helvetica, sans-serif;
            position: absolute;
            top: 337px;
            z-index: 1;
            width: 140px;
        }
        .auto-style12 {
            top: 182px;
            right: 696px;
            background-color: #FFFFFF;
            position: absolute;
            left: 458px;
            z-index: 1;
        }
        .auto-style13 {
            top: 180px;
            right: 935px;
            background-color: #FFFFFF;
            position: absolute;
            left: 219px;
            z-index: 1;
        }
        .auto-style14 {
            position: absolute;
            left: 282px;
            top: 101px;
            z-index: 1;
            height: 197px;
        }
        .auto-style15 {
            height: 62px;
        }
    </style>
</head>
<body style="width: 502px">
    <form id="form1" runat="server">
        <div style="background-color: #add8e6">
            </br>
            <span class="auto-style10">Name </span> <asp:TextBox ID="NameText" runat="server" BorderStyle="None" Height="25px"></asp:TextBox>&nbsp;&nbsp;
           <span class="auto-style10">Site </span> <asp:DropDownList ID="SiteDDList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="OnSiteDDSelectedIndexChanged" Height="30px"></asp:DropDownList>&nbsp;&nbsp;
           <span class="auto-style10">Block </span> <asp:DropDownList ID="BlockDDList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="OnBlockDDSelectedIndexChanged" Height="30px"></asp:DropDownList></br></br>
        </div>
        <div style="background-color: #add8e6"><span class="auto-style6">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="auto-style9">Available Columns</span>&nbsp; </span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="auto-style10">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Selected Columns</span></div>

        <div style="background-color: #add8e6">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:ListBox ID="AvailableColumns" runat="server" Height="200px" Width="150px"></asp:ListBox>
            <asp:ImageButton ID="RightButton" runat="server" ImageUrl="~/Images/RightArrow.png" CssClass="auto-style1" OnClick="OnRightButtonClick" />

            <asp:IMageButton ID="LeftButton" runat="server" Height="30px" ImageUrl="~/Images/LeftArrow.png" Width="38px" CssClass="auto-style13" OnClick="OnLeftButtonClick" />

            <asp:ListBox ID="SelectedColumns" runat="server" Width="150px" CssClass="auto-style14"></asp:ListBox>

            <asp:ImageButton ID="UpButton" runat="server" Height="30px" ImageUrl="~/Images/UpArrow.png" Width="38px" CssClass="auto-style4" OnClick="OnUpButtonClick" />

            <asp:ImageButton ID="DownButton" runat="server" Height="30px" ImageUrl="~/Images/DownArrow.png" Width="38px" CssClass="auto-style12" OnClick="OnDownButtonClick" />

        </div>
        <div style="background-color: #add8e6" class="auto-style15">
            <asp:Button ID="OkButton" runat="server" Text="Ok" CssClass="auto-style7" OnClick="OnOkButtonClick" BorderStyle="None" />
            <asp:Label ID="StatusLabel" runat="server" Text="" CssClass="auto-style11"></asp:Label>
            <asp:Button ID="CancelButton" runat="server" Text="Cancel" CssClass="auto-style8" OnClick="OnCancelButtonClick" BorderStyle="None" />
        </div>
    </form>
</body>
</html>
