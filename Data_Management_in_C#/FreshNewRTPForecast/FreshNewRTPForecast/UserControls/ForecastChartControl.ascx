<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ForecastChartControl.ascx.cs" Inherits="RTPWebForecastService.UserControls.ForecastChartControl" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<p>
    <asp:Chart ID="chart1" runat="server" Height="977px" Width="925px" style="margin-left: 39px; margin-right: 39px;" CssClass="auto-style1" Palette="None">
<Series>
        <asp:Series ChartArea="AmbientChart" Name="AmbTemp" Legend="Legend1" ChartType="Line" BorderColor="Olive" BorderWidth="2">
        </asp:Series>
        <asp:Series ChartArea="AmbientChart" ChartType="Line" Name="AmbRH" Legend="Legend1" BorderColor="Olive" BorderWidth="2">
        </asp:Series>
        <asp:Series ChartArea="AmbientChart" ChartType="Line" Name="AmbPress" Legend="Legend1" YAxisType="Secondary" BorderColor="Olive" BorderWidth="2">
        </asp:Series>
        <asp:Series BorderDashStyle="Dash" ChartArea="AmbientChart" ChartType="Area" LabelBorderDashStyle="Dot" Legend="Legend1" Name="AmbTemp*" IsVisibleInLegend="False">
        </asp:Series>
        <asp:Series BorderDashStyle="Dash" ChartArea="AmbientChart" ChartType="Area" Legend="Legend1" Name="AmbRH*" IsVisibleInLegend="False">
        </asp:Series>
        <asp:Series BorderDashStyle="Dash" ChartArea="AmbientChart" ChartType="Area" Legend="Legend1" Name="AmbPress*" IsVisibleInLegend="False">
        </asp:Series>
        <asp:Series BorderDashStyle="Dash" ChartArea="NetMWChart" ChartType="Area" Legend="Legend2" Name="BaseMW*" IsVisibleInLegend="False">
        </asp:Series>
        <asp:Series ChartArea="NetMWChart" ChartType="Line" Name="BaseMW1" Legend="Legend2" BorderColor="Olive" BorderWidth="2" Color="Navy">
        </asp:Series>
        <asp:Series ChartArea="NetMWChart" ChartType="Line" Name="BaseMW2" Legend="Legend2" BorderColor="Olive" BorderWidth="2" Color="Yellow">
        </asp:Series>
        <asp:Series ChartArea="NetMWChart" ChartType="Line" Name="BaseMW3" Legend="Legend2" BorderColor="Olive" BorderWidth="2" Color="Green">
        </asp:Series>
        <asp:Series ChartArea="NetMWChart" ChartType="Line" Name="BaseMW4" Legend="Legend2" BorderColor="Olive" BorderWidth="2" Color="Red">
        </asp:Series>
        <asp:Series ChartArea="NetMWChart" ChartType="Line" Name="BaseMW5" Legend="Legend2" BorderColor="Olive" BorderWidth="2" Color="Black">
        </asp:Series>

        <asp:Series ChartArea="NetMWChart" ChartType="Line" Legend="Legend2" Name="BaseMW6" BorderColor="Olive" BorderWidth="2" Color="Maroon">
        </asp:Series>
        <asp:Series ChartArea="NetMWChart" ChartType="Line" Legend="Legend2" Name="BaseMW7" BorderColor="Olive" BorderWidth="2" Color="Peru">
        </asp:Series>
        <asp:Series ChartArea="NetMWChart" ChartType="Line" Legend="Legend2" Name="BaseMW8" BorderColor="Olive" BorderWidth="2" Color="255, 128, 0">
        </asp:Series>
        <asp:Series ChartArea="NetMWChart" ChartType="Line" Legend="Legend2" Name="BaseMW9" BorderColor="Olive" BorderWidth="2" Color="Silver">
        </asp:Series>
        <asp:Series ChartArea="NetMWChart" ChartType="Line" Legend="Legend2" Name="BaseMW10" BorderColor="Olive" BorderWidth="2" Color="192, 0, 192">
        </asp:Series>
        <asp:Series BorderDashStyle="Dash" ChartArea="NetHHVHeatRateChart" ChartType="Area" Legend="Legend3" Name="BaseHR*" IsVisibleInLegend="False">
        </asp:Series>
        <asp:Series ChartArea="NetHHVHeatRateChart" ChartType="Line" Legend="Legend3" Name="BaseHR1" BorderColor="Olive" BorderWidth="2" Color="Red">
        </asp:Series>
        <asp:Series ChartArea="NetHHVHeatRateChart" ChartType="Line" Legend="Legend3" Name="BaseHR2" BorderColor="Olive" BorderWidth="2" Color="Yellow">
        </asp:Series>
        <asp:Series ChartArea="NetHHVHeatRateChart" ChartType="Line" Legend="Legend3" Name="BaseHR3" BorderColor="Olive" BorderWidth="2" Color="0, 0, 192">
        </asp:Series>
        <asp:Series ChartArea="NetHHVHeatRateChart" ChartType="Line" Legend="Legend3" Name="BaseHR4" BorderColor="Olive" BorderWidth="2" Color="Purple">
        </asp:Series>
        <asp:Series ChartArea="NetHHVHeatRateChart" ChartType="Line" Legend="Legend3" Name="BaseHR5" BorderColor="Olive" BorderWidth="2" Color="64, 64, 0">
        </asp:Series>

    </Series>
    <ChartAreas>
        <asp:ChartArea Name="AmbientChart">
            <AxisY TitleFont="Microsoft Sans Serif, 12pt" IntervalType="Number">
            </AxisY>
            <AxisX TitleFont="Microsoft Sans Serif, 12pt">
            </AxisX>
            <AxisX2 TitleFont="Microsoft Sans Serif, 12pt">
            </AxisX2>
            <AxisY2 TitleFont="Microsoft Sans Serif, 12pt" IntervalType="Number">
            </AxisY2>
            <InnerPlotPosition Height="80" Width="95" X="5" Y="10" />
        </asp:ChartArea>
        <asp:ChartArea Name="NetMWChart">
            <AxisY TitleFont="Microsoft Sans Serif, 12pt">
            </AxisY>
            <AxisX TitleFont="Microsoft Sans Serif, 12pt">
            </AxisX>
            <AxisX2 TitleFont="Microsoft Sans Serif, 12pt">
            </AxisX2>
            <AxisY2 TitleFont="Microsoft Sans Serif, 12pt">
            </AxisY2>
            <InnerPlotPosition Height="80" Width="95" X="5" Y="10" />
        </asp:ChartArea>
        <asp:ChartArea Name="NetHHVHeatRateChart">
            <AxisY TitleFont="Microsoft Sans Serif, 12pt">
            </AxisY>
            <AxisX TitleFont="Microsoft Sans Serif, 12pt">
            </AxisX>
            <AxisX2 TitleFont="Microsoft Sans Serif, 12pt">
            </AxisX2>
            <AxisY2 TitleFont="Microsoft Sans Serif, 12pt">
            </AxisY2>
            <InnerPlotPosition Height="80" Width="95" X="5" Y="10" />
        </asp:ChartArea>

    </ChartAreas>
    <Legends>
        <asp:Legend DockedToChartArea="AmbientChart" IsDockedInsideChartArea="False" Name="Legend1" Alignment="Far" BackColor="Transparent" BackGradientStyle="TopBottom" Font="Arial, 12pt" ForeColor="RoyalBlue" IsTextAutoFit="False" ShadowColor="White" Docking="Bottom">
        </asp:Legend>
        <asp:Legend DockedToChartArea="NetMWChart" IsDockedInsideChartArea="False" Name="Legend2" Alignment="Far" BackColor="Transparent" BackGradientStyle="TopBottom" Font="Arial, 12pt" ForeColor="RoyalBlue" IsTextAutoFit="False" ShadowColor="White" Docking="Bottom">
        </asp:Legend>
        <asp:Legend DockedToChartArea="NetHHVHeatRateChart" IsDockedInsideChartArea="False" Name="Legend3" Alignment="Far" BackColor="Transparent" BackGradientStyle="TopBottom" Font="Arial, 12pt" ForeColor="RoyalBlue" IsTextAutoFit="False" ShadowColor="White" Docking="Bottom">
        </asp:Legend>
        
    </Legends>
    </asp:Chart>

</p>

