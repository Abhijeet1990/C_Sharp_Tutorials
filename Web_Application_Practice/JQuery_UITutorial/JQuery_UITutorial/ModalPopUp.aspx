<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModalPopUp.aspx.cs" Inherits="JQuery_UITutorial.ModalPopUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
    <link rel="stylesheet" href="/resources/demos/style.css">
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
   <%-- <script>
  $( function() {
    $( ".widget input[type=submit], .widget a, .widget button" ).button();
    $( "button, input, a" ).click( function( event ) {
      event.preventDefault();
    } );
  } );
    </script>--%>
    <script>
        $("#btnSubmit").click(function () {
            var name = $('#' + txtName).val();
            $.ajax({
                type: "POST",
                url: "ModalPopUp.aspx/GetDate",
                data: "{'name': '" + name + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {
                    $.unblockUI();

                }
            });
        });

        </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <input type="button" value="Show" id="Button1" />
    </div>
    <div id="dvBlock" style="display: none;">
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        <input type="button" value="Submit" id="btnSubmit" />
        <input type="button" value="Close" id="btnClose" />
    </div>
    </form>
</body>
</html>
