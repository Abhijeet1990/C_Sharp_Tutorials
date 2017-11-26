<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestGV.aspx.cs" Inherits="gridViewTutorial.TestGV" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
        .Gridview {
            font-family: Verdana;
            font-size: 10pt;
            font-weight: normal;
            color: black;
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
            background-color: #8B2323;
            cursor: pointer;
            border: solid 1px black;
        }
        .selectedRow
        {
            background-color: #6495ED;
            cursor: pointer;
            border: solid 1px black;
            color: White;
        }
    </style>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#GridView1 thead').addClass('headerRow');
            $('#GridView1 tbody tr').mouseover(function () {
                $(this).addClass('highlightRow');
            }).mouseout(function () {
                $(this).removeClass('highlightRow');
            }).click(function () {
                $(this).toggleClass('selectedRow');
            });
        });
</script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating"
                BackColor="White" Font-Size="10"
      Font-Names="Verdana" BorderColor="#000000" BorderStyle="Solid" BorderWidth="1px"
      CellPadding="3" Width="400px" CellSpacing="0" GridLines="Horizontal">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="S.No." />
                    <asp:BoundField DataField="FirstName" HeaderText="FirstName" />
                    <asp:BoundField DataField="LastName" HeaderText="LastName" />
                    <asp:TemplateField HeaderText="Gender">
                        <EditItemTemplate>
                            <%--<asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Gender") %>'></asp:TextBox>--%>
                            <asp:DropDownList ID="GenderDD" runat="server" AutoPostBack="true">
                                <asp:ListItem>Male</asp:ListItem>
                                <asp:ListItem>Female</asp:ListItem>
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <%--<asp:DropDownList ID="GenderDD" runat="server" AutoPostBack="true">
                                <asp:ListItem>Male</asp:ListItem>
                                <asp:ListItem>Female</asp:ListItem>
                            </asp:DropDownList>--%>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Gender") %>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Salary" HeaderText="Salary" />
                    <asp:CommandField ShowEditButton="true" />
                    <asp:CommandField ShowDeleteButton="true" />
                </Columns>

            </asp:GridView>
        </div>
        <div>
            <asp:Label ID="lblresult" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
