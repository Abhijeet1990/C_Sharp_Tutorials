<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ImageForecastControl.ascx.cs" Inherits="RTPWebForecastService.UserControls.ImageForecastControl" %>
<asp:Panel ID="Panel1" runat="server" Width="100px" Height="162px">
<asp:Label ID="dateLabel" runat="server" Text="AMB/RH" Font-Size="Smaller" style="font-family: Arial; color: #000080; font-weight: 700"></asp:Label><br>
<asp:Label ID="ambTempLabel" runat="server" Text="AMB/RH" Font-Size="Small" style="font-family: Arial; color: #000080; font-weight: 700"></asp:Label>
    <br />
    <br>
<asp:Image ID="Image1" runat="server" Height="63px" Width="70px" /><br>
<asp:Label ID="Label1" runat="server" Text="Wind" Font-Size="Smaller" style="font-family: Arial; color: #000080; font-weight: 700"></asp:Label><br>
<asp:Label ID="windSpeedLabel" runat="server" Text="9mph/NW" Font-Size="Small" style="font-family: Arial; color: #000080; font-weight: 700"></asp:Label>
</asp:Panel>