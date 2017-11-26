<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConfigureVariables.aspx.cs" Inherits="RTPWebForecastService.ConfigureVariables" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Configure Reports</title>
    <script type="text/javascript">
        function popup(row,url, title, width, height) {
            var rowData = row.parentNode.parentNode;
            var RowIndex = rowData.rowIndex;
            var tbl = document.getElementById('ForecastVariableGridView');
            var tbl_row = tbl.rows[parseInt(RowIndex)];

            var tbl_Cell1 = tbl_row.cells[1];
            var Name = tbl_Cell1.innerText.toString();

            var tbl_Cell2 = tbl_row.cells[2];
            var selectedSite = tbl_Cell2.innerText.toString();
            
            var tbl_Cell3 = tbl_row.cells[3];
            var selectedBlock = tbl_Cell3.innerText.toString();

            var market= document.getElementById('<%=MarketLabel.ClientID %>').innerText;
            var newurl = url.concat(selectedSite).concat('&Block=').concat(selectedBlock).concat('&Name=').concat(Name).concat('&Market=').concat(market);
            var left = (screen.width / 2) - (width / 2);
            var top = (screen.height / 2) - (height / 2);
            var options = '';
            options += ',width=' + width;
            options += ',height=' + height;
            options += ',top=' + top;
            options += ',left=' + left;
            options += ',location=no,toolbar=no,menubar=no,scrollbars=yes,resizable=yes,addressbar=0,titlebar=no,directories=no,channelmode=no,status=no';
            return window.open(newurl, title, options);
        }

         function popupChart(row,url, title, width, height) {
            var rowData = row.parentNode.parentNode;
            var RowIndex = rowData.rowIndex;
            var tbl = document.getElementById('ChartConfigureGridView');
            var tbl_row = tbl.rows[parseInt(RowIndex)];

            var tbl_Cell1 = tbl_row.cells[1];
            var Name = tbl_Cell1.innerText.toString();

            var tbl_Cell2 = tbl_row.cells[2];
            var selectedSite = tbl_Cell2.innerText.toString();
            
            var tbl_Cell3 = tbl_row.cells[3];
            var selectedBlock = tbl_Cell3.innerText.toString();

            var market= document.getElementById('<%=MarketLabel.ClientID %>').innerText;
            var newurl = url.concat(selectedSite).concat('&Block=').concat(selectedBlock).concat('&Name=').concat(Name).concat('&Market=').concat(market);
            var left = (screen.width / 2) - (width / 2);
            var top = (screen.height / 2) - (height / 2);
            var options = '';
            options += 'location=no,toolbar=no,menubar=no,scrollbars=yes,resizable=yes,addressbar=0,titlebar=no,directories=no,channelmode=no,status=no';
            options += ',width=' + width;
            options += ',height=' + height;
            options += ',top=' + top;
            options += ',left=' + left;
            
            return window.open(newurl, title, options);
        }

        function popupInsert(url, title, width, height) {
            var market= document.getElementById('<%=MarketLabel.ClientID %>').innerText;
            var newurl = url.concat('').concat('&Block=').concat('').concat('&Name=').concat('').concat('&Market=').concat(market);
            var left = (screen.width / 2) - (width / 2);
            var top = (screen.height / 2) - (height / 2);
            var options = '';
            options += ',width=' + width;
            options += ',height=' + height;
            options += ',top=' + top;
            options += ',left=' + left;
            options += ',location=no,toolbar=no,menubar=no,scrollbars=yes,resizable=yes,addressbar=0,titlebar=no,directories=no,channelmode=no,status=no';
            return window.open(newurl, title, options);
        }
    </script>
    <style type="text/css">
        .auto-style1 {
            font-family: Arial, Helvetica, sans-serif;
        }
        .auto-style2 {
            height: 30px;
            width: 79px;
        }
        .auto-style3 {
            height: 25px;
            width: 70px;
        }
        </style>
</head>
<body style="width: 711px">
    <form id="form1" runat="server">
    <div>
    
                <asp:Label ID="Label1" runat="server" Text="Settings - " Font-Bold="True" Font-Size="Larger" CssClass="auto-style1" style="font-family: Arial, Helvetica, sans-serif"></asp:Label>
                <asp:Label ID="MarketLabel" runat="server" Text="" CssClass="auto-style1"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <%--<asp:Button ID="InsertButton" runat="server" Text="Insert" OnClick="OnInsertButtonClick" Font-Bold="True" ForeColor="#003399" Width="100px" Height="30px" Font-Size="Large"/>--%>
                <input id="InsertButtonTable" visible="true" runat="server" type="button" value="Insert" style="color:#003399;font-weight:bold;" onclick="popupInsert('ColumnSelectionForm.aspx?Site=', '', 470, 360)" class="auto-style3"/>
                <input id="InsertButtonChart" visible="false" runat="server" type="button" value="Insert" style="color:#003399;font-weight:bold;" onclick="popupInsert('ChartSeriesSelectionForm.aspx?Site=', '', 470, 440)" class="auto-style3"/>
                <asp:RadioButton ID="chartRadio" runat="server" AutoPostBack="true"  Font-Italic="False" Font-Size="Large" ForeColor="#000000" GroupName="SearchType" OnCheckedChanged="OnChartRadioCheckedChanged" Style="text-align: right" Text="Chart" CssClass="auto-style1" />
                <asp:RadioButton ID="tableRadio" runat="server" AutoPostBack="true"  Checked="True" Font-Italic="False" Font-Size="Large" ForeColor="#000000" GroupName="SearchType" OnCheckedChanged="OnTableRadioCheckedChanged" Style="text-align: right" Text="Table" CssClass="auto-style1" />
                <asp:RadioButton ID="formulaRadio" runat="server" AutoPostBack="true"  Font-Italic="False" Font-Size="Large" ForeColor="#000000" GroupName="SearchType" OnCheckedChanged="OnFormulaRadioCheckedChanged" Style="text-align: right" Text="Formula" CssClass="auto-style1" />
                <br/>
                <br/>
        <asp:Panel ID="Panel1" runat="server" Width="100%">
                <asp:GridView ID="ForecastVariableGridView" runat="server" ShowFooter="false" CellPadding="4" ForeColor="#333333" GridLines="None" Width="92%" AutoGenerateColumns="False" DataKeyNames="id" OnPageIndexChanging="OnVariableGVPageIndexChanging" OnRowCancelingEdit="OnVariableGVRowCancelingEdit" OnRowDeleting="OnVariableGVRowDeleting" OnRowEditing="OnVariableGVRowEditing" OnRowUpdating="OnVariableGVRowUpdating" BackColor="Yellow"  OnRowDataBound="OnForecastVariableGridViewRowDataBound" ShowHeaderWhenEmpty="true" Style="font-family: Arial" OnRowCommand="OnForecastVariableGridViewRowCommand" CssClass="auto-style2">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <%--<asp:ImageButton ID="ibEdit" runat="server" CommandName="Edit" ImageUrl="~/Images/Edit.png" Height="20px" Width="20px" ToolTip="Edit Variable"/>--%>
                                <input id="ibEdit" type="button" style="border:none ;background-image: url(/Images/Edit.png);height:20px;width:20px; background-size:100%;background-color:transparent;" onclick="popup(this,'ColumnSelectionForm.aspx?Site=', '', 470, 320)"/>
                                <asp:ImageButton ID="ibDelete" runat="server" CommandName="Delete" ImageUrl="~/Images/Delete.png" Height="20px" Width="20px" ToolTip="Delete Variable"/>
                            </ItemTemplate>
                            <%--<EditItemTemplate>
                                <asp:ImageButton ID="ibUpdate" runat="server" CommandName="Update" ImageUrl="~/Images/Update.png" Height="20px" Width="20px" ToolTip="Update Variable"/>
                                <asp:ImageButton ID="ibCancel" runat="server" CommandName="Cancel" ImageUrl="~/Images/Cancel.png" Height="20px" Width="20px" ToolTip="Cancel Edit"/>
                            </EditItemTemplate>--%>
                            <%--<FooterTemplate>
                                <asp:ImageButton ID="ibInsert" runat="server" OnClick="OnAddButtonClick" ImageUrl="~/Images/Update.png" Height="20px" Width="20px" ToolTip="Update Variable"/>
                                <asp:ImageButton ID="ibCancelInsert" runat="server" OnClick="OnInsertCancelClick" ImageUrl="~/Images/Cancel.png" Height="20px" Width="20px" ToolTip="Cancel Edit"/>
                            </FooterTemplate>--%>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Name">
                            <%--<EditItemTemplate>
                                <asp:DropDownList ID="SiteDD" runat="server" AutoPostBack="true">
                                </asp:DropDownList>
                            </EditItemTemplate>--%>
                            <ItemTemplate>
                                <asp:Label ID="NameLabel" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                            </ItemTemplate>
                           
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Site">
                            <%--<EditItemTemplate>
                                <asp:DropDownList ID="SiteDD" runat="server" AutoPostBack="true">
                                </asp:DropDownList>
                            </EditItemTemplate>--%>
                            <ItemTemplate>
                                <asp:Label ID="SiteLabel" runat="server" Text='<%# Bind("Site") %>'></asp:Label>
                            </ItemTemplate>
                            <%--<FooterTemplate>
                                <asp:DropDownList ID="InsertSiteDD" runat="server" AutoPostBack="true" OnSelectedIndexChanged="OnInsertSiteDDSelectedIndexChanged">
                                </asp:DropDownList>
                            </FooterTemplate>--%>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Block">
                            <%--<EditItemTemplate>
                                <asp:DropDownList ID="BlockDD" runat="server" AutoPostBack="true">
                                </asp:DropDownList>
                            </EditItemTemplate>--%>
                            <ItemTemplate>
                                <asp:Label ID="BlockLabel" runat="server" Text='<%# Bind("Block") %>'></asp:Label>
                            </ItemTemplate>
                            <%--<FooterTemplate>
                                <asp:DropDownList ID="InsertBlockDD" runat="server" AutoPostBack="true">
                                </asp:DropDownList>
                            </FooterTemplate>--%>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Variables">
                            <ItemTemplate>
                                <asp:Label ID="VariableLabel" runat="server" Text='<%# Bind("Variables") %>'></asp:Label>
                            </ItemTemplate>
<%--                            <FooterTemplate>
                                <asp:Label ID="VariableLabel" runat="server" Text='<%# Bind("Variables") %>'></asp:Label>
                            </FooterTemplate>--%>

                        </asp:TemplateField>
                        <%--<asp:TemplateField HeaderText="Select Columns">
                            <ItemTemplate>
                                <input id="SelectColumnsButton" type="button" value="Select Columns" onclick="popup('ColumnSelectionForm.aspx?Site=', '', 500, 300)" />
                            </ItemTemplate>
                            <FooterTemplate>
                                <input id="InsertSelectColumnsButton" type="button" value="Select Columns" onclick="popupInsert('ColumnSelectionForm.aspx?Site=', '', 500, 300)" />
                            </FooterTemplate>
                        </asp:TemplateField>--%>
                       
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


                 <asp:GridView ID="ChartConfigureGridView" runat="server" Visible="false" ShowFooter="false" CellPadding="4" ForeColor="#333333" GridLines="None" Width="92%" AutoGenerateColumns="False" DataKeyNames="id" OnPageIndexChanging="OnChartGVPageIndexChanging" OnRowCancelingEdit="OnChartGVRowCancelingEdit" OnRowDeleting="OnChartGVRowDeleting" OnRowEditing="OnChartGVRowEditing" OnRowUpdating="OnChartGVRowUpdating" BackColor="Yellow"  OnRowDataBound="OnChartConfigureGridViewRowDataBound" ShowHeaderWhenEmpty="true" Style="font-family: Arial" OnRowCommand="OnChartConfigureGridViewRowCommand" CssClass="auto-style2">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <%--<asp:ImageButton ID="ibEdit" runat="server" CommandName="Edit" ImageUrl="~/Images/Edit.png" Height="20px" Width="20px" ToolTip="Edit Variable"/>--%>
                                <input id="ibEdit1" type="button" style="border:none ;background-image: url(/Images/Edit.png);height:20px;width:20px; background-size:100%;background-color:transparent;" onclick="popupChart(this,'ChartSeriesSelectionForm.aspx?Site=', '', 470, 440)"/>
                                <asp:ImageButton ID="ibDelete1" runat="server" CommandName="Delete" ImageUrl="~/Images/Delete.png" Height="20px" Width="20px" ToolTip="Delete Variable"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <asp:Label ID="NameLabel1" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                            </ItemTemplate>                           
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Site">
                            <ItemTemplate>
                                <asp:Label ID="SiteLabel1" runat="server" Text='<%# Bind("Site") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Block">
                            <ItemTemplate>
                                <asp:Label ID="BlockLabel1" runat="server" Text='<%# Bind("Block") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Chart1">
                            <ItemTemplate>
                                <asp:Label ID="Series1Label" runat="server" Text='<%# Bind("Chart1") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Chart2">
                            <ItemTemplate>
                                <asp:Label ID="Series2Label" runat="server" Text='<%# Bind("Chart2") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                       <asp:TemplateField HeaderText="Chart3">
                            <ItemTemplate>
                                <asp:Label ID="Series3Label" runat="server" Text='<%# Bind("Chart3") %>'></asp:Label>
                            </ItemTemplate>
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

        <asp:Panel ID="FormulaPanel" runat="server" Width="100%" Visible="false">
            <br/>&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="SiteFormulaLabel" runat="server" Text="Select Site " CssClass="auto-style1"></asp:Label>
            <asp:DropDownList ID="SiteDropDownList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="OnSiteDropDownListSelectedIndexChanged"></asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="BlockFormulaLabel" runat="server" Text="Select Block " CssClass="auto-style1"></asp:Label>
            <asp:DropDownList ID="BlockDropDownList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="OnBlockDropDownListSelectedIndexChanged" CssClass="auto-style1"></asp:DropDownList>
            <br/>
            <br/>
            <asp:GridView ID="FormulaGridView" runat="server" CssClass="auto-style1" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />        
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
            </asp:Panel>
    </div>
    </form>
</body>
</html>
