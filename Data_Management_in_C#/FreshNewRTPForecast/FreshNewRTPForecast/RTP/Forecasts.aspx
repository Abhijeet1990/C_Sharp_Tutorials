<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Forecasts.aspx.cs" Inherits="RTPWebForecastService.Forecasts" %>
<%@ Register TagPrefix="uc" TagName="ForecastChartControl" Src="~/UserControls/ForecastChartControl.ascx" %>
<%@ Register TagPrefix="uc" TagName="BarChartControl" Src="~/UserControls/BarChartControl.ascx" %>
<%@ Register TagPrefix="uc" TagName="RunningStatusControl" Src="~/UserControls/RunningStatusUserControl.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script type="text/c#">
        protected void Timer1_Tick(object sender, EventArgs e)
        {
            UpdateCharts();
        }

        //function UpdateCharts() {
        //    $.ajax({
        //        type: "POST",
        //        url: "Bellingham.aspx/UpdateCharts",
        //        data: '',
        //        contentType: "application/json; charset=utf-8",
        //        dataType: "json"
        //    });
        //}

        </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#ForecastDataGridView tr td:first').addClass('FixedWidthColumn');
            $('#ForecastDataGridView thead').addClass('headerRow');
            $('#ForecastDataGridView tbody tr').mouseover(function () {
                $(this).addClass('highlightRow');
            }).mouseout(function () {
                $(this).removeClass('highlightRow');
            }).click(function () {
                $(this).toggleClass('selectedRow');
            });
        });
        $(document).ready(function () {
            $('#MinMaxAvgGridView tr td:first').addClass('FixedWidthColumn');
            $('#MinMaxAvgGridView thead').addClass('headerRow');
            $('#MinMaxAvgGridView tbody tr').mouseover(function () {
                $(this).addClass('highlightRow');
            }).mouseout(function () {
                $(this).removeClass('highlightRow');
            }).click(function () {
                $(this).toggleClass('selectedRow');
            });
        });
</script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#Mysidenav").css("width", "20%");
            $("#headText").css("width", "80%");
            $("#rightsidebar").css("width", "80%");
        });
        function openNav() {
            document.getElementById("Mysidenav").style.width = "20%";
            document.getElementById("headText").style.width = "80%";
            document.getElementById("rightsidebar").style.width = "80%";
        }

        function closeNav() {
            document.getElementById("Mysidenav").style.width = "0%";
            document.getElementById("headText").style.width = "100%";
            document.getElementById("rightsidebar").style.width = "100%";
        }

        function GetHeaderText(gridID) {
            var grid = document.getElementById(gridID);
            var HeaderText = grid.rows[0].cells[gridID].innerText;
            alert(HeaderText);
        }

        function popup(url, title, width, height, sitename, blockname) {
            var control = document.getElementById('<%= SiteListDD.ClientID %>');
            var selectedvalue = control.options[control.selectedIndex].value;
            var newurl = url.concat(selectedvalue);
            var left = (screen.width / 2) - (width / 2);
            var top = (screen.height / 2) - (height / 2);
            var options = '';
            options += ',width=' + width;
            options += ',height=' + height;
            options += ',top=' + top;
            options += ',left=' + left;
            return window.open(newurl, title, options);
        }

        function popupCompare(url, title, width, height, sitename, blockname) {
            var control = document.getElementById('<%= SiteListDD.ClientID %>');
            var selectedSite = control.options[control.selectedIndex].value;
            var control1 = document.getElementById('<%= BlockListDD.ClientID %>');
            var selectedBlock= control1.options[control1.selectedIndex].value;
            var newurl = url.concat(selectedSite).concat('&Block=').concat(selectedBlock);
            var left = (screen.width / 2) - (width / 2);
            var top = (screen.height / 2) - (height / 2);
            var options = '';
            options += ',width=' + width;
            options += ',height=' + height;
            options += ',top=' + top;
            options += ',left=' + left;
            return window.open(newurl, title, options);
        }

        function popupVariables(url, title, width, height) {
            var control = document.getElementById('<%= MarketLabel.ClientID %>');
            var selectedvalue = control.innerText;
            var left = (screen.width / 2) - (width / 2);
            var top = (screen.height / 2) - (height / 2);
            var newurl = url.concat(selectedvalue);
            var options = '';
            options += ',width=' + width;
            options += ',height=' + height;
            options += ',top=' + top;
            options += ',left=' + left;
            return window.open(newurl, title, options);
        }

        function popupTestPage(url,width,height)
        {
            var left = (screen.width / 2) - (width / 2);
            var top = (screen.height / 2) - (height / 2);
            var title = "website";
            var options = '';
            options += ',width=' + width;
            options += ',height=' + height;
            options += ',top=' + top;
            options += ',left=' + left;
            return window.open(url, title, options);
        }

    </script>

    <style type="text/css">
        /*.DivStyle{
   Display: Inline-block;
}*/

        td.FixedWidthColumn /*fixed width for the first columns of the gridviews*/
{
    width: 200px;
}

        #Mysidenav {
        width: 23%;
    }

    #wrapper.toggled #Mysidenav {
        width: 0%;
    }

        .float-left {
            float: left;
        }

        label {
            font-family: Arial;
        }

        #leftsidebar {
            width: 20%;
            float: left;
            height: 700px;
        }

        label {
            font-family: Arial;
        }

        #leftsidebar {
            float: left;
            background-color: #FFFFCC;
            position: relative;
            top: 0px;
            left: 0px;
        }

        #rightsidebar {
            width: 100%;
            float: right;
            background-color: transparent;
            text-align: center;
        }

        .sidenav {
            height: 100%;
            width: 0;
            position: fixed;
            z-index: 1;
            top: -15px;
            left: 0;
            background-color: #EFF3FB;
            overflow-x: hidden;
            transition: 0.5s;
            padding-top: 30px;
            text-align: center;
        }

            .sidenav .closebtn {
                position: inherit;
                top: 0;
                right: 25px;
                font-size: 36px;
                margin-left: 50px;
            }

        @media screen and (max-height: 450px) {
            .sidenav {
                padding-top: 15px;
            }

                .sidenav a {
                    font-size: 18px;
                }
        }
        .auto-style1 {
            width: 10px;
        }
        .auto-style2 {
            width: 10px;
            height: 24px;
        }
        .auto-style3 {
            height: 24px;
        }
        .auto-style7 {
            width: 10px;
            height: 30px;
        }
        .auto-style8 {
            position: absolute;
            height: 30px;
        }
        .auto-style9 {
            text-align: left;
        }
        .auto-style10 {
            height: 24px;
            text-align: left;
        }
        .auto-style13 {
            height: 5px;
        }

        th
        {
            text-align: left;
        }
        .headerRow
        {
            background-color: #458B74;
            color: White;
            font-weight: bold;
        }
        .highlightRow
        {
            background-color:#add8e6;
            cursor: pointer;
            border: solid 2px black;
            color: #003399;
            font-size:larger;
        }
        .selectedRow
        {
            background-color:transparent;
            cursor: pointer;
            border: solid 2px black;
            color: Black;
            font-size:larger;
        }
        .auto-style14 {
            font-family: Arial, Helvetica, sans-serif;
            font-weight: bold;
            font-size: x-large;
            color: #003399;
        }
        .auto-style15 {
            font-family: Arial, Helvetica, sans-serif;
            font-weight: bold;
            font-size: x-large;
            color: #003399;
        }
        .auto-style16 {
            font-family: Arial, Helvetica, sans-serif;
            font-weight: bold;
            font-size: x-large;
            color: #003399;
        }
        .auto-style17 {
            font-family: Arial, Helvetica, sans-serif;
        }
        .auto-style19 {
            height: 100%;
            width: 0;
            position: fixed;
            z-index: 1;
            top: -15px;
            left: 0;
            overflow-x: hidden;
            transition: 0.5s;
            text-align: right;
            padding-top: 15px;
            background-color: #EFF3FB;
        }
        .auto-style20 {
            text-align: center;
        }
        .auto-style22 {
            font-family: Arial, Helvetica, sans-serif;
            font-weight: bold;
        }
        .auto-style23 {
            height: 30px;
            width:30px;
            text-align: center;
            vertical-align:middle;
        }
        .auto-style24 {
            position: absolute;
            
            left: 239px;
            z-index: 1;
        }
    </style>
    

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server" ID="ScriptManager1">
        </asp:ScriptManager>
        <div id="headText" style ="float:right; width:100%;" runat ="server">

            <asp:Panel ID="Panel2" runat="server" BackColor="#add8e6" Height="103px">
                <table style="width: 100%;">
                    <tr>
                        <td><asp:Image ID="Image1" runat="server" Height="90px" ImageUrl="~/Images/RTP IntelligenOptimization Logo - Horizontal.jpg" Width="291px" style="margin-left: 5px; margin-top: 5px; margin-bottom:5px; " CssClass="float-left" /></td>
                        <td><asp:Label ID="Label1" runat="server" Text="RTP Load Forecast" Font-Bold="True" ForeColor="#003399" Font-Size="XX-Large" style="text-align: center; top: 113px; left: 573px; position: relative; float: none; height: 36px; width: 268px;" CssClass="auto-style17"></asp:Label></td>
                        <td><asp:Label ID="MarketLabel" runat="server" Text="" CssClass="auto-style22"></asp:Label></td>
                        <td><asp:Image ID="GraphImage" runat="server" Height="90px" ImageUrl="~/Images/graph-trend.jpg" Width="230px" style="margin-right: 5px; margin-top: 5px; margin-bottom:5px; float: right;" /></td>
                        
                    </tr>
                   
                </table>
                
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                
                <br />
            </asp:Panel>
        </div>
        
        <span style="font-size:25px;cursor:pointer" onclick="openNav()">&#9776;</span>
        <%--<div id="leftsidebar" class="sidenav">--%>
          <div id="wrapper">
        <div id="Mysidenav" class="auto-style19">
            
            <a href="javascript:void(0)" onclick="closeNav()">&times;</a>
            <br />
            
            <asp:Panel ID="LoadForecastPanel" runat="server" Style="border-style: none; background-color: transparent; text-align: right; position: relative;">
                <table id="selectionTable" class="auto-style2" style="width:auto">
                    <%--<tr>
                        <td class="auto-style1">&nbsp;</td>
                        <td class="auto-style9">
                            <asp:ImageButton ID="RefreshButton" runat="server" Height="36px" ImageUrl="~/Images/Refresh.png" OnClick="OnRefreshButtonClick" Width="36px" visible="true"/>
                        </td>
           
                        <td class="auto-style8"></td>
                    </tr>--%>
                    <tr>
                        <td class="auto-style1">&nbsp;</td>
                        <td class="auto-style9">
                            <asp:Label ID="siteLabel" runat="server" Text="Site " Font-Bold="True" Font-Italic="False" Font-Size="Large" ForeColor="#003399" Style="font-family: Arial"></asp:Label></td>
                        <td>
                            <asp:DropDownList ID="SiteListDD" runat="server" AutoPostBack="True" BackColor="White" Font-Size="Large" Height="36px" OnSelectedIndexChanged="OnSiteListDDSelectedIndexChanged" Style="color: #000000; font-family: Arial; text-align: right;" Width="140px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style7"></td>
                        <td class="auto-style8"></td>
                        <td class="auto-style8"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">&nbsp;</td>
                        <td class="auto-style9">
                            <asp:Label ID="blockLabel" runat="server" Font-Bold="True" Font-Italic="False" Font-Size="Large" ForeColor="#003399" Style="font-family: Arial" Text="Block "></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="BlockListDD" runat="server" AutoPostBack="true" BackColor="White" Font-Size="Large" Height="36px" OnSelectedIndexChanged="OnBlockListDDSelectedIndexChanged" Style="color: #000000; font-family: Arial; text-align: right; margin-left: 0px;" Width="140px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style7"></td>
                        <td class="auto-style8"></td>
                        <td class="auto-style8"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">&nbsp;</td>
                        <td class="auto-style9">
                            <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#003399" Style="font-family: Arial" Text="Report"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="FileTypeSelection" runat="server" AutoPostBack="true" Font-Size="Large" Height="36px" OnSelectedIndexChanged="OnFileTypeSelectionSelectedIndexChanged" Style="color:#000000; font-family: Arial; text-align: right;" Width="140px">
                                <asp:ListItem Selected="True">Trader</asp:ListItem>
                                <asp:ListItem>Operator</asp:ListItem>
                                <asp:ListItem>RawFile</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td class="auto-style23">
                            &nbsp;&nbsp;&nbsp;<asp:ImageButton ID="ImageButton1" runat="server" Height="24px" ImageUrl="~/Images/Refresh.png" OnClick="OnRefreshButtonClick" Width="24px" visible="true" CssClass="auto-style24" style="z-index: 1"/>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style7"></td>
                        <td class="auto-style8"></td>
                        <td class="auto-style8"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">&nbsp;</td>
                        <td class="auto-style10">

                            <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#003399" Style="font-family: Arial" Text="Forecast"></asp:Label>

                        </td>
                        <td class="auto-style3">
                            <asp:RadioButton ID="realTimeRadio" runat="server" Text="RT" AutoPostBack="true" GroupName="DaySearchType" OnCheckedChanged="OnRealTimeRadioCheckedChanged" Font-Italic="False" Font-Size="Large" Font-Bold="False" ForeColor="#000000" Checked="True" Style="text-align: right" />
                            <asp:RadioButton ID="dayAheadRadio" runat="server" Text="DA" AutoPostBack="true" GroupName="DaySearchType" OnCheckedChanged="OnDayAheadRadioCheckedChanged" Font-Italic="False" Font-Size="Large" Font-Bold="False" ForeColor="#000000" Style="text-align: right" />
                            <asp:RadioButton ID="allRadio" runat="server" Text="All" AutoPostBack="true" GroupName="DaySearchType" OnCheckedChanged="OnAllRadioCheckedChanged" Font-Italic="False" Font-Size="Large" Font-Bold="False" ForeColor="#000000" Style="text-align: right" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style7"></td>
                        <td class="auto-style8"></td>
                        <td class="auto-style8"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">&nbsp;</td>
                        <td class="auto-style10">

                            <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#003399" Style="font-family: Arial" Text="Display"></asp:Label>

                        </td>
                        <td class="auto-style3">
                            <asp:RadioButton ID="chartRadio" runat="server" AutoPostBack="true"  Font-Italic="False" Font-Size="Large" ForeColor="#000000" GroupName="SearchType" OnCheckedChanged="OnChartRadioCheckedChanged" Style="text-align: right" Text="Chart" />
                            <asp:RadioButton ID="tableRadio" runat="server" AutoPostBack="true"  Checked="True" Font-Italic="False" Font-Size="Large" ForeColor="#000000" GroupName="SearchType" OnCheckedChanged="OnTableRadioCheckedChanged" Style="text-align: right" Text="Table" />
                        </td>
                        
                        <td class="auto-style8">
                            <input id="SettingButton" type="button" runat="server" style="border:none ;background-image: url(/Images/Setting.png);height:24px;width:24px; background-size:100%;background-color:transparent;" onclick="popupVariables('ConfigureVariables.aspx?Market=', '', 720, 270)" visible="true" />
                    </td>
                    </tr>
                    
                </table>
            </asp:Panel>
            <br />
            <table style="width: 100%;" >
                <tr>
                    <td class="auto-style20">
                        <input id="DerateButton" type="button" value="Derate" onclick="popup('ForecastDerateForm.aspx?Site=', '', 1500, 800)" style="background-color: #FFFFFF; font-size: large; font-weight: bold; font-family: Arial, Helvetica, sans-serif; width: 240px; height: 50px; color: #003399;" /></td>
                </tr>
                <tr>
                    <td class="auto-style13"></td>
                </tr>
                <tr>
                    <td class="auto-style20">
                        <asp:Button ID="Button1" runat="server" Text="Weather Forecast" OnClick="OnWeatherForecastClick" BackColor="#FFFFFF" Font-Bold="True" ForeColor="#003399" Width="240px" Height="50px" Font-Size="Large" /></td>
                </tr>
                <tr>
                    <td class="auto-style13"></td>
                </tr>
                <tr>
                    <td class="auto-style20">
                        <asp:Button ID="dlButton" runat="server" Text="Download" OnClick="OnDownloadButtonClick" BackColor="#FFFFFF" Font-Bold="True" ForeColor="#003399" Width="240px" Height="50px" Font-Size="Large" visible="false"/>
                    </td>
                    
                </tr>
                <tr>
                    <td class="auto-style13"></td>
                </tr>
                <tr>
                    <td class="auto-style20">
                        <input id="CompareButton" type="button" value="Compare Forecast" onclick="popupCompare('CompareForecastForm.aspx?Site=', '', 1500, 800)" style="background-color: #FFFFFF; font-size: large; font-weight: bold; font-family: Arial, Helvetica, sans-serif; width: 240px; height: 50px; color: #003399;" /></td>
                </tr>
                <tr>
                    <td class="auto-style13"></td>
                </tr>
                <tr>
                    <td class="auto-style20">
                        <asp:Button ID="OperatingModeButton" runat="server" Text="Plot Operating Modes" OnClick="OnOperatingModeButtonClick" BackColor="#FFFFFF" Font-Bold="True" ForeColor="#003399" Width="240px" Height="50px" Font-Size="Large" visible="true"/>
                    </td>
                    
                </tr>
            </table>
            
        </div>
            </div>

        <div id="rightsidebar" class:"column">
            <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                <ContentTemplate>                    
                    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="1">
                        <asp:View ID="Chart" runat="server">
                            <asp:Panel ID="ForecastChartPanel" runat="server" Height="100%" ViewStateMode="Inherit" Width="100%">
                                <br>
                                <br>
                              
                                <asp:Label ID="chartTitle" runat="server" CssClass="auto-style14" Font-Bold="True" Font-Size="Larger" Text=""></asp:Label>
                                <br>
                                <br>
                                <br>
                                
                                <uc:ForecastChartControl ID="ForecastChartControl1" runat="server" Visible="True" />
                                <uc:BarChartControl ID="BarChartControl1" runat="server" Visible="False" />
                                
                            </asp:Panel>
                        </asp:View>
                        <asp:View ID="Table" runat="server">
                            <br>
                            <br></br>
                            <asp:Label ID="tableTitle" runat="server" CssClass="auto-style15" Font-Size="Larger" Text=""></asp:Label>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <br>
                            <br></br>
                            <asp:GridView ID="MinMaxAvgGridView" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" HeaderStyle-HorizontalAlign="Justify" OnRowDataBound="MinMaxAvgGridView_RowDataBound" style="table-layout: fixed; position: relative; height: 100%; font-family: Arial;">
                                <AlternatingRowStyle BackColor="White" />
                                <EditRowStyle BackColor="#2461BF" />
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
                            <asp:GridView ID="ForecastDataGridView" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" HeaderStyle-HorizontalAlign="Justify" OnRowCommand="ForecastDataGridView_RowCommand" OnRowDataBound="ForecastDataGridView_RowDataBound" style="table-layout: fixed; position: relative; height: 100%; font-family: Arial;">
                                <AlternatingRowStyle BackColor="White" />
                                <EditRowStyle BackColor="#2461BF" />
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
                            </br>
                            </br>

                        </asp:View>
                        <asp:View ID="Status" runat="server">
                            <asp:Panel ID="EquipmentStatusPanel" runat="server" Height="100%" Width="100%">
                              
                                <asp:Table ID="EquipmentStatusTable" runat="server" style="text-align: right">
                                    <asp:TableRow runat="server">
                                        <asp:TableCell runat="server"></asp:TableCell>
                                        <asp:TableCell runat="server"></asp:TableCell>
                                        <asp:TableCell runat="server"></asp:TableCell>
                                        <asp:TableCell runat="server"></asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow runat="server">
                                        <asp:TableCell runat="server"></asp:TableCell>
                                        <asp:TableCell runat="server"></asp:TableCell>
                                        <asp:TableCell runat="server"></asp:TableCell>
                                        <asp:TableCell runat="server"></asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow runat="server">
                                        <asp:TableCell runat="server"></asp:TableCell>
                                        <asp:TableCell runat="server"></asp:TableCell>
                                        <asp:TableCell runat="server"></asp:TableCell>
                                        <asp:TableCell runat="server"></asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow runat="server">
                                        <asp:TableCell runat="server"></asp:TableCell>
                                        <asp:TableCell runat="server"></asp:TableCell>
                                        <asp:TableCell runat="server"></asp:TableCell>
                                        <asp:TableCell runat="server"></asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow runat="server">
                                        <asp:TableCell runat="server"></asp:TableCell>
                                        <asp:TableCell runat="server"></asp:TableCell>
                                        <asp:TableCell runat="server"></asp:TableCell>
                                        <asp:TableCell runat="server"></asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                            </asp:Panel>
                        </asp:View>
                        <asp:View ID="Weather" runat="server">
                            
                            <asp:Panel ID="WeatherForecastPanel" runat="server" Visible="false" Height="100%" Width="100%">
                                
                                <br>
                                <br>
                                <br></br>
                                <asp:Label ID="WeatherForecastLabel" runat="server" CssClass="auto-style16" Text=""></asp:Label>
                                <td>
                                    <asp:Image ID="WeatherImage" runat="server" Height="70px" ImageUrl="~/Images/wundergroundLogo.jpg" style="margin-right: 5px; margin-top: 5px; margin-bottom:5px; float: right;" Width="230px" />
                                </td>
                                <br>
                                <br>
                                <br></br>
                                <asp:Table ID="WeatherForecastTable" runat="server" BorderColor="#add8e6" BorderWidth="2px" HorizontalAlign="Center">
                                    <asp:TableRow runat="server">
                                        <asp:TableCell runat="server"></asp:TableCell>
                                        <asp:TableCell runat="server"></asp:TableCell>
                                        <asp:TableCell runat="server"></asp:TableCell>
                                        <asp:TableCell runat="server"></asp:TableCell>
                                        <asp:TableCell runat="server"></asp:TableCell>
                                        <asp:TableCell runat="server"></asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow runat="server">
                                        <asp:TableCell runat="server"></asp:TableCell>
                                        <asp:TableCell runat="server"></asp:TableCell>
                                        <asp:TableCell runat="server"></asp:TableCell>
                                        <asp:TableCell runat="server"></asp:TableCell>
                                        <asp:TableCell runat="server"></asp:TableCell>
                                        <asp:TableCell runat="server"></asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow runat="server">
                                        <asp:TableCell runat="server"></asp:TableCell>
                                        <asp:TableCell runat="server"></asp:TableCell>
                                        <asp:TableCell runat="server"></asp:TableCell>
                                        <asp:TableCell runat="server"></asp:TableCell>
                                        <asp:TableCell runat="server"></asp:TableCell>
                                        <asp:TableCell runat="server"></asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow runat="server">
                                        <asp:TableCell runat="server"></asp:TableCell>
                                        <asp:TableCell runat="server"></asp:TableCell>
                                        <asp:TableCell runat="server"></asp:TableCell>
                                        <asp:TableCell runat="server"></asp:TableCell>
                                        <asp:TableCell runat="server"></asp:TableCell>
                                        <asp:TableCell runat="server"></asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                                <br></br>
                                <br></br>
                                </br>
                                </br>
                                </br>
                                </br>
                            </asp:Panel>
                        </asp:View>
                    </asp:MultiView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        
    </form>
</body>
</html>
