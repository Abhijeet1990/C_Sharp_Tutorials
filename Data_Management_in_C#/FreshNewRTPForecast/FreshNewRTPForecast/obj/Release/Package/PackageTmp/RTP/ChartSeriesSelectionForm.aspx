<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChartSeriesSelectionForm.aspx.cs" Inherits="RTPWebForecastService.SeriesSelectionForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Charts</title>
    <style type="text/css">
        .auto-style1 {
            top: 119px;
            position: absolute;
            left: 201px;
            width: 38px;
            height: 30px;
            background-color: #FFFFFF;
            z-index: 1;
            bottom: 543px;
        }
        .auto-style4 {
            top: 119px;
            background-color: #FFFFFF;
            position: absolute;
            left: 432px;
            bottom: 543px;
            z-index: 1;
        }
        .auto-style6 {
            font-family: Arial, Helvetica, sans-serif;
        }
        .auto-style7 {
            left: 347px;
            position: absolute;
            top: 414px;
            width: 56px;
            background-color: #FFFFFF;
            z-index: 1;
            height: 30px;
        }
        .auto-style8 {
            left: 409px;
            position: absolute;
            top: 414px;
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
            left: 31px;
            font-family: Arial, Helvetica, sans-serif;
            position: absolute;
            top: 449px;
            z-index: 1;
        }
        .auto-style12 {
            top: 151px;
            right: 722px;
            background-color: #FFFFFF;
            position: absolute;
            height: 30px;
            left: 432px;
            z-index: 1;
        }
        .auto-style13 {
            top: 150px;
            right: 953px;
            background-color: #FFFFFF;
            position: absolute;
            left: 201px;
            z-index: 1;
        }
        .auto-style14 {
            height: 313px;
        }
        .auto-style15 {
            position: absolute;
            left: 259px;
            top: 113px;
            height: 74px;
            margin-top: 0px;
            z-index: 1;
        }
        .auto-style16 {
            position: absolute;
            left: 258px;
            top: 215px;
            height: 74px;
            z-index: 1;
        }
        .auto-style17 {
            top: 221px;
            position: absolute;
            left: 203px;
            width: 38px;
            height: 30px;
            background-color: #FFFFFF;
            z-index: 1;
        }
        .auto-style18 {
            top: 252px;
            right: 951px;
            background-color: #FFFFFF;
            position: absolute;
            bottom: 410px;
            left: 203px;
            z-index: 1;
        }
        .auto-style19 {
            top: 216px;
            background-color: #FFFFFF;
            position: absolute;
            left: 433px;
            z-index: 1;
        }
        .auto-style20 {
            top: 249px;
            right: 721px;
            background-color: #FFFFFF;
            position: absolute;
            height: 30px;
            left: 433px;
            z-index: 1;
        }
        .auto-style21 {
            top: 322px;
            position: absolute;
            left: 202px;
            width: 38px;
            height: 30px;
            background-color: #FFFFFF;
            z-index: 1;
        }
        .auto-style22 {
            top: 354px;
            position: absolute;
            left: 202px;
            width: 38px;
            height: 30px;
            background-color: #FFFFFF;
            z-index: 1;
        }
        .auto-style23 {
            position: absolute;
            left: 257px;
            top: 314px;
            height: 74px;
            z-index: 1;
        }
        .auto-style24 {
            top: 323px;
            background-color: #FFFFFF;
            position: absolute;
            left: 430px;
            z-index: 1;
        }
        .auto-style25 {
            top: 356px;
            right: 724px;
            background-color: #FFFFFF;
            position: absolute;
            height: 30px;
            left: 430px;
            z-index: 1;
        }
        .auto-style26 {
            height: 83px;
        }
        .auto-style27 {
            position: absolute;
            top: 98px;
            left: 34px;
        }
        .auto-style28 {
            width: 499px;
            height: 19px;
            position: absolute;
            top: 69px;
            left: 12px;
            z-index: 1;
        }
        .auto-style29 {
            position: absolute;
            top: 94px;
            left: 283px;
            z-index: 1;
            font-family: Arial, Helvetica, sans-serif;
            font-weight: bold;
            color: #003399;
        }
        .auto-style30 {
            position: absolute;
            top: 194px;
            left: 284px;
            z-index: 1;
            font-family: Arial, Helvetica, sans-serif;
            font-weight: bold;
            color: #003399;
        }
        .auto-style31 {
            position: absolute;
            top: 295px;
            left: 283px;
            z-index: 1;
            font-family: Arial, Helvetica, sans-serif;
            font-weight: bold;
            color: #003399;
            height: 20px;
        }
    </style>
</head>
<body style="width: 502px">
    <form id="form1" runat="server">
        <div style="background-color: #add8e6">
            </br>
            <span class="auto-style10">Name </span> <asp:TextBox ID="NameText" runat="server" BorderStyle="None" Height="25px"></asp:TextBox>&nbsp;&nbsp;
           <span class="auto-style10">Site </span> <asp:DropDownList ID="SiteDDList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="OnSiteDDSelectedIndexChanged" Height="30px"></asp:DropDownList>&nbsp;&nbsp;
           <span class="auto-style10">Block </span> <asp:DropDownList ID="BlockDDList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="OnBlockDDSelectedIndexChanged" Height="30px"></asp:DropDownList></br>
        <div style="background-color: #add8e6" class="auto-style28"><span class="auto-style6">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="auto-style9">Available Columns</span>&nbsp; </span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="auto-style10">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Selected Columns</span></div>

        

            </br>
        </div>

        

        <div style="background-color: #add8e6" class="auto-style14">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:ListBox ID="AvailableColumns" runat="server" Height="301px" Width="150px" CssClass="auto-style27" style="z-index: 1"></asp:ListBox>
             
            <asp:ImageButton ID="RightButtonAmbient" runat="server" Height="30px" Width="38px" ImageUrl="~/Images/RightArrow.png" CssClass="auto-style1" OnClick="OnRightButtonAmbientClick" />
            <asp:ImageButton ID="LeftButtonAmbient" runat="server" Height="30px" Width="38px" ImageUrl="~/Images/LeftArrow.png" CssClass="auto-style13" OnClick="OnLeftButtonAmbientClick" />
            <asp:ImageButton ID="LeftButtonMW" runat="server" Height="30px" ImageUrl="~/Images/LeftArrow.png"  Width="38px" CssClass="auto-style18" OnClick="OnLeftButtonMWClick" />
            <asp:ImageButton ID="RightButtonMW" runat="server" ImageUrl="~/Images/RightArrow.png" CssClass="auto-style17" OnClick="OnRightButtonMWClick" />
            <asp:ImageButton ID="LeftButtonHR" runat="server" ImageUrl="~/Images/LeftArrow.png"  CssClass="auto-style22" OnClick="OnLeftButtonHRClick" />

            <asp:ImageButton ID="RightButtonHR" runat="server" ImageUrl="~/Images/RightArrow.png" CssClass="auto-style21" OnClick="OnRightButtonHRClick" />

            <asp:ImageButton ID="UpButtonHR" runat="server" ImageUrl="~/Images/UpArrow.png" Height="30px" Text="Up" Width="38px" CssClass="auto-style24" OnClick="OnUpButtonHRClick" />
            <asp:ImageButton ID="UpButtonAmbient" runat="server" ImageUrl="~/Images/UpArrow.png" Height="30px" Text="Up" Width="38px" CssClass="auto-style4" OnClick="OnUpButtonAmbientClick" />
            <asp:ListBox ID="SelectedColumnsMW" runat="server" Width="150px" CssClass="auto-style16"></asp:ListBox>
            <asp:ListBox ID="SelectedColumnsAmbient" runat="server" Width="150px" CssClass="auto-style15"></asp:ListBox>
            <asp:ImageButton ID="DownButtonMW" runat="server" ImageUrl="~/Images/DownArrow.png" Width="38px" CssClass="auto-style20" OnClick="OnDownButtonMWClick" />

            <asp:ImageButton ID="UpButtonMW" runat="server" Height="30px" ImageUrl="~/Images/UpArrow.png" Width="38px" CssClass="auto-style19" OnClick="OnUpButtonMWClick" />
            <asp:ListBox ID="SelectedColumnsHR" runat="server" Width="150px" CssClass="auto-style23"></asp:ListBox>
            <asp:ImageButton ID="DownButtonAmbient" runat="server" ImageUrl="~/Images/DownArrow.png" Width="38px" CssClass="auto-style12" OnClick="OnDownButtonAmbientClick" />
            <asp:ImageButton ID="DownButtonHR" runat="server" ImageUrl="~/Images/DownArrow.png" Width="38px" CssClass="auto-style25" OnClick="OnDownButtonHRClick" />
            <asp:Label ID="Label1" runat="server" CssClass="auto-style29" Text="Top - Amb Cond"></asp:Label>
            <asp:Label ID="Label2" runat="server" CssClass="auto-style30" Text="Middle - MW"></asp:Label>
            <asp:Label ID="Label3" runat="server" CssClass="auto-style31" Text="Bottom - HR"></asp:Label>
        </div>
        <div style="background-color: #add8e6" class="auto-style26">
            

            <asp:Button ID="OkButton" runat="server" Text="Ok" CssClass="auto-style7" OnClick="OnOkButtonClick" BorderStyle="None" />
            <asp:Label ID="StatusLabel" runat="server" Text="" CssClass="auto-style11"></asp:Label>
            <asp:Button ID="CancelButton" runat="server" Text="Cancel" CssClass="auto-style8" OnClick="OnCancelButtonClick" BorderStyle="None" />
        </div>
    </form>
</body>
</html>