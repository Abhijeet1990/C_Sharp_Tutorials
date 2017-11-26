<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BarChartControl.ascx.cs" Inherits="RTPWebForecastService.UserControls.BarChartControl" %>
<asp:Chart ID="Chart1" runat="server" Height="401px" Width="820px">
    <Series>
        <asp:Series Legend="Legend1" Name="Series1">
        </asp:Series>
    </Series>
    <ChartAreas>
        <asp:ChartArea Name="ChartArea1">
        </asp:ChartArea>
    </ChartAreas>
    <Legends>
        <asp:Legend Name="Legend1">
        </asp:Legend>
    </Legends>
</asp:Chart>

