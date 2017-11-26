<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForecastDerateForm.aspx.cs" Inherits="RTPWebForecastService.ForecastDerateForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Derate</title>
    <style type="text/css">
        .auto-style1 {
            font-family: Arial, Helvetica, sans-serif;
        }
 
        .auto-style2 {
            font-size: large;
        }
 
        </style>
</head>
<body>
    <form id="form1" runat="server">

        <div>
            <asp:Panel ID="Panel1" runat="server" Width="100%">
                <asp:Label ID="Label1" runat="server" Text="Configure Derate" Font-Bold="True" Font-Size="Larger" CssClass="auto-style1"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="InsertButton" runat="server" Text="Insert" OnClick="OnInsertButtonClick" Font-Bold="True" ForeColor="#003399" Width="100px" Height="30px" Font-Size="Large" BackColor="White"/>
                <asp:GridView ID="ForecastDerateGridView" runat="server" ShowFooter="false" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" AutoGenerateColumns="False" DataKeyNames="id" OnPageIndexChanging="OnDerateGVPageIndexChanging" OnRowCancelingEdit="OnDerateGVRowCancelingEdit" OnRowDeleting="OnDerateGVRowDeleting" OnRowEditing="OnDerateGVRowEditing" OnRowUpdating="OnDerateGVRowUpdating" BackColor="Yellow"  OnRowDataBound="OnForecastDerateGridViewRowDataBound" ShowHeaderWhenEmpty="true" Style="font-family: Arial" OnRowCommand="OnForecastDerateGridViewRowCommand" CssClass="auto-style2">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="ibEdit" runat="server" CommandName="Edit" ImageUrl="~/Images/Edit.png" Height="20px" Width="20px" ToolTip="Edit Derate"/>
                                <asp:ImageButton ID="ibDelete" runat="server" CommandName="Delete" ImageUrl="~/Images/Delete.png" Height="20px" Width="20px" ToolTip="Delete Derate"/>
                                <asp:ImageButton ID="ibPreview" runat="server" OnClick="OnPreviewImageClick" ImageUrl="~/Images/Preview.png" Height="20px" Width="20px" ToolTip="Preview Derate"/>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:ImageButton ID="ibUpdate" runat="server" CommandName="Update" ImageUrl="~/Images/Update.png" Height="20px" Width="20px" ToolTip="Update Derate"/>
                                <asp:ImageButton ID="ibCancel" runat="server" CommandName="Cancel" ImageUrl="~/Images/Cancel.png" Height="20px" Width="20px" ToolTip="Cancel Edit"/>
                                <asp:ImageButton ID="ibPreviewEdit" runat="server" OnClick="OnPreviewImageEditClick" ImageUrl="~/Images/Preview.png" Height="20px" Width="20px" ToolTip="Preview Derate"/>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:ImageButton ID="ibInsert" runat="server" OnClick="OnAddButtonClick" ImageUrl="~/Images/Update.png" Height="20px" Width="20px" ToolTip="Update Derate"/>
                                <asp:ImageButton ID="ibCancelInsert" runat="server" OnClick="OnInsertCancelClick" ImageUrl="~/Images/Cancel.png" Height="20px" Width="20px" ToolTip="Cancel Edit"/>
                                <asp:ImageButton ID="ibPreviewInsert" runat="server" OnClick="OnPreviewImageInsertClick" ImageUrl="~/Images/Preview.png" Height="20px" Width="20px" ToolTip="Preview Derate"/>
                            </FooterTemplate>
                        </asp:TemplateField>
                       
                        <asp:TemplateField HeaderText="Active">
                            <EditItemTemplate>
                                <asp:CheckBox ID="ActiveCB" runat="server" />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="ActiveCB" runat="server" Checked='<%# bool.Parse(Eval("Active").ToString())%>' />
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:CheckBox ID="ActiveCBInsert" runat="server" />
                                <%--<asp:LinkButton ID="ActiveCB" runat="server" OnClick="OnAddButtonClick" ForeColor="#003399">Insert</asp:LinkButton>--%>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Name">
                            <EditItemTemplate>
                                <asp:TextBox ID="EditName" runat="server" Text='<%# Bind("Name") %>' Width="100px" />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="DisplayName" runat="server" Text='<%# Bind("Name") %>' />
                            </ItemTemplate>

                            <FooterTemplate>
                                <asp:TextBox ID="InsertName" runat="server" Width="100px"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Site">
                            <EditItemTemplate>
                                <%--<asp:DropDownList ID="SiteDD" runat="server" AutoPostBack="true" OnSelectedIndexChanged="OnSiteDDSelectedIndexChanged">--%>
                                <asp:DropDownList ID="SiteDD" runat="server" AutoPostBack="true">
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="SiteLabel" runat="server" Text='<%# Bind("Site") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:DropDownList ID="InsertSiteDD" runat="server" AutoPostBack="true" OnSelectedIndexChanged="OnInsertSiteDDSelectedIndexChanged">
                                </asp:DropDownList>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Block">
                            <EditItemTemplate>
                                <%--<SelectedValue='<%# Bind("Block") %>'></SelectedValue>--%>
                                <asp:DropDownList ID="BlockDD" runat="server" AutoPostBack="true">
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="BlockLabel" runat="server" Text='<%# Bind("Block") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:DropDownList ID="InsertBlockDD" runat="server" AutoPostBack="true">
                                </asp:DropDownList>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Forecast">
                            <EditItemTemplate>
                                <asp:DropDownList ID="ForecastDD" runat="server" AutoPostBack="true" >
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="ForecastLabel" runat="server" Text='<%# Bind("ForecastName") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:DropDownList ID="InsertForecastDD" runat="server" AutoPostBack="true">
                                </asp:DropDownList>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Type">
                            <EditItemTemplate>
                                <asp:DropDownList ID="TypeDD" runat="server" AutoPostBack="true" SelectedValue='<%# Bind("DerateType") %>'>
                                    <asp:ListItem>Increase</asp:ListItem>
                                    <asp:ListItem>Decrease</asp:ListItem>
                                    <asp:ListItem>Multiple</asp:ListItem>
                                    <asp:ListItem>Maximum</asp:ListItem>
                                    <asp:ListItem>Minimum</asp:ListItem>
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="TypeLabel" runat="server" Text='<%# Bind("DerateType") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:DropDownList ID="InsertTypeDD" runat="server" AutoPostBack="true">
                                    <asp:ListItem>Increase</asp:ListItem>
                                    <asp:ListItem>Decrease</asp:ListItem>
                                    <asp:ListItem>Multiple</asp:ListItem>
                                    <asp:ListItem>Maximum</asp:ListItem>
                                    <asp:ListItem>Minimum</asp:ListItem>
                                </asp:DropDownList>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Value">
                            <EditItemTemplate>
                                <asp:TextBox ID="EditValue" runat="server" Text='<%# Bind("Value") %>' Width="50px"/>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="DisplayValue" runat="server" Text='<%# Bind("Value") %>' />
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="InsertValue" runat="server" Width="50px"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <%--<asp:ImageField DataImageUrlField="Criteria" HeaderText="Criteria"></asp:ImageField>--%>
                        <asp:TemplateField HeaderText="Criteria">
                            <EditItemTemplate>
                                <asp:TextBox ID="EditCriteria" runat="server" Text='<%# Bind("Criteria") %>' Width="100px"/>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="DisplayCriteria" runat="server" Text='<%# Bind("Criteria") %>' />
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="InsertCriteria" runat="server" Width="100px"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Expiration">
                            <EditItemTemplate>
                                <asp:TextBox ID="EditExpiration" runat="server" Text='<%# Bind("Expiration") %>' />
                                <asp:Calendar ID="ExpirationDateCalendar" runat="server" OnSelectionChanged="OnExpirationDateCalendarChanged" BackColor="White" Font-Size="Small"></asp:Calendar>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="DisplayExpiration" runat="server" Text='<%# Bind("Expiration") %>' />
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="InsertExpiration" runat="server" AutoPostBack="true" Visible="false"></asp:TextBox>
                                <asp:Calendar ID="ExpirationDateCalendar" AutoPostback="true" runat="server" OnSelectionChanged="OnInsertExpirationDateCalendarChanged" BackColor="White" Font-Size="Small"></asp:Calendar>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <%--<asp:TemplateField HeaderText="Expiration">
                    <EditItemTemplate>
                        <asp:Button ID="expirationButton" runat="server" AutoPostBack ="true"></asp:Button>
                    </EditItemTemplate>
                     <ItemTemplate>
                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Expiration") %>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="Reason">
                            <EditItemTemplate>
                                <asp:TextBox ID="EditReason" runat="server" Text='<%# Bind("Reason") %>' Width="100px" />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="DisplayReason" runat="server" Text='<%# Bind("Reason") %>' />
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="InsertReason" runat="server" Width="100px"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>

                        <asp:CommandField ShowEditButton="false" />
                        <asp:CommandField ShowDeleteButton="false" />


                    </Columns>
                    <EditRowStyle BackColor="#add8e6" />
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
            </asp:Panel>
            <asp:Panel ID="Panel2" runat="server" Width="100%" BackColor="#add8e6">
                <asp:Chart ID="Chart1" runat="server" Height="267px" Width ="1500px" BackColor="#add8e6" Visible="false">
                    <Series>
                        <asp:Series ChartType="Spline" Name="Raw" Legend="Legend1" XValueType="Date" BorderWidth="3" Color="SteelBlue">
                        </asp:Series>
                        <asp:Series BorderWidth="3" ChartArea="ChartArea1" ChartType="Spline" Name="Derate" Legend="Legend1" XValueType="DateTime" Color="Red">
                        </asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1" BackColor="White">
                            <AxisY TitleFont="Arial Narrow, 12pt">
                                <MinorGrid LineDashStyle="Dot" />
                            </AxisY>
                            <AxisX TitleFont="Arial Narrow, 12pt">
                                <MinorGrid LineDashStyle="Dot" />
                            </AxisX>
                        </asp:ChartArea>
                    </ChartAreas>
                    <Legends>
                        <asp:Legend BackColor="255, 255, 255" Name="Legend1">
                        </asp:Legend>
                    </Legends>
                </asp:Chart>
            </asp:Panel>
        </div>

    </form>
</body>
</html>
