<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="channelDocter.aspx.cs" Inherits="novacare.channelDocter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Channel your Doctor</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Panel ID="Panel1" runat="server" Height="351px">
            <asp:Image ID="Image1" runat="server" Height="170px" Width="1080px" ImageUrl="~/meetyourdoc.jpg" />
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Select the speciality"></asp:Label>
            <br />
            <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                <asp:ListItem>Any</asp:ListItem>
                <asp:ListItem>Cardiologist</asp:ListItem>
                <asp:ListItem>Physician</asp:ListItem>
                <asp:ListItem>Counselling</asp:ListItem>
                <asp:ListItem>Dental Surgeon</asp:ListItem>
                <asp:ListItem>Oncologist</asp:ListItem>
            </asp:DropDownList>
        </asp:Panel>
    
    </div>
    </form>
</body>
</html>
