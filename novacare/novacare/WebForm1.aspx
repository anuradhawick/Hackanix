<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="novacare.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>How you feel? </title>
    <style type="text/css">
        #form1 {
            height: 366px;
            width: 1026px;
        }
    </style>
</head>
<body style="height: 369px; width: 1022px; margin-left: 9px">
    <form id="form1" runat="server">
        <asp:Panel ID="Panel1" runat="server" Height="172px" Width="1015px">
            <asp:Image ID="Image1" runat="server" Height="166px" ImageUrl="~/Cover2.jpg" Width="1080px" />
        </asp:Panel>
        <p>
            What are the discomforts you have?</p>
        <asp:TextBox ID="TextBox1" runat="server" Height="16px" OnTextChanged="TextBox1_TextChanged1" ToolTip="Enter here" Width="1080px" OnDataBinding="TextBox1_DataBinding"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Here are some suggetions to get rid of your pain"></asp:Label>
        <br />
        <br />
        <asp:TextBox ID="TextBox2" runat="server" Width="1080px"></asp:TextBox>
    </form>
</body>
</html>
