<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompareForecastForm.aspx.cs" Inherits="RTPWebForecastService.CompareForecastForm" %>
<%@ Register TagPrefix="uc" TagName="ForecastChartControl" Src="~/UserControls/ForecastChartControl.ascx" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            position: absolute;
            top: 21px;
            left: 303px;
            z-index: 1;
        }
        .auto-style3 {
            position: absolute;
            top: 299px;
            left: 3px;
            z-index: 1;
            width: 53px;
            height: -2px;
            margin-top: 0px;
        }
        .auto-style4 {
            position: absolute;
            top: 275px;
            left: 1px;
            z-index: 1;
            font-family: Arial, Helvetica, sans-serif;
            bottom: -219px;
        }
        .auto-style5 {
            font-family: Arial, Helvetica, sans-serif;
        }
        .auto-style6 {
            height: 38px;
            width: 1322px;
        }
        .auto-style7 {
            position: absolute;
            top: 0px;
            left: 389px;
            z-index: 1;
            font-family: Arial, Helvetica, sans-serif;
            font-weight: bold;
            bottom: 41px;
            margin-top: 0px;
        }
        .auto-style8 {
            position: absolute;
            top: 0px;
            left: 0px;
            z-index: 1;
            font-family: Arial, Helvetica, sans-serif;
            font-weight: bold;
        }
        .auto-style9 {
            position: absolute;
            top: 285px;
            left: 129px;
            z-index: 1;
            width: 127px;
            height: 36px;
        }
        .auto-style11 {

            height: 57px;
            position: absolute;
            top: 30px;
            left: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" class="auto-style11" style="z-index: 1">

        <div class="auto-style6">
            <asp:Label ID="SiteBlockLabel" runat="server" Text="Label" CssClass="auto-style8"></asp:Label>
            <asp:Label ID="TitleLabel" runat="server" Text="Label" CssClass="auto-style7"></asp:Label>

            <br />
            <br />
            <asp:Label ID="SelectDateLabel" runat="server" Text="Select Date" CssClass="auto-style5"></asp:Label>
            <asp:Label ID="SelectHourLabel" runat="server" Text="Forecast Hour" CssClass="auto-style4"></asp:Label>
            <asp:Calendar ID="SelectDateCalendar" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" CssClass="auto-style5" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" Width="258px" OnSelectionChanged="OnSelectDateCalendarSelectionChanged" OnDayRender="OnSelectDateCalendarDayRender">
                <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                <OtherMonthDayStyle ForeColor="#999999" />
                <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                <WeekendDayStyle BackColor="#CCCCFF" />
            </asp:Calendar>
            <asp:Label ID="PageLoadLabel" runat="server" Text="true" Visible="false"></asp:Label>
            <asp:DropDownList ID="SelectHourDropDown" runat="server" AutoPostBack="true" CssClass="auto-style3" OnSelectedIndexChanged="OnSelectHourDropDownSelectedIndexChanged">
                <asp:ListItem>00</asp:ListItem>
                <asp:ListItem>01</asp:ListItem>
                <asp:ListItem>02</asp:ListItem>
                <asp:ListItem>03</asp:ListItem>
                <asp:ListItem>04</asp:ListItem>
                <asp:ListItem>05</asp:ListItem>
                <asp:ListItem>06</asp:ListItem>
                <asp:ListItem>07</asp:ListItem>
                <asp:ListItem>08</asp:ListItem>
                <asp:ListItem>09</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>
                <asp:ListItem>11</asp:ListItem>
                <asp:ListItem>12</asp:ListItem>
                <asp:ListItem>13</asp:ListItem>
                <asp:ListItem>14</asp:ListItem>
                <asp:ListItem>15</asp:ListItem>
                <asp:ListItem>16</asp:ListItem>
                <asp:ListItem>17</asp:ListItem>
                <asp:ListItem>18</asp:ListItem>
                <asp:ListItem>19</asp:ListItem>
                <asp:ListItem>20</asp:ListItem>
                <asp:ListItem>21</asp:ListItem>
                <asp:ListItem>22</asp:ListItem>
                <asp:ListItem>23</asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="CompareButton" runat="server" Text="Compare" CssClass="auto-style9" OnClick="OnCompareButtonClicked" BackColor="White" Font-Bold="True" Font-Size="Large" />
        </div>
        <div>
            <uc:ForecastChartControl ID="ForecastChartControl1" runat="server" Visible="True" />
        </div>
    </form>
</body>
</html>
