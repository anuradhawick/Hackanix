<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="novacare._Default"%>

<asp:Content ID="tt" ContentPlaceHolderID="MainContent" runat="server" >
    <div class="jumbotron">
        <asp:Image ID="Image1" runat="server" Height="185px" ImageUrl="~/Cover.jpg" Width="1080px" />
        <br />
        <br />
        <br />
        <p>
                <a class="btn btn-primary btn-lg" href="http://localhost:4271/WebForm1">How you feel? &raquo;</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <a class="btn btn-primary btn-lg" href="http://localhost:4271/channelDocter">Channel Your Doctor &raquo;</a>
            </p>
    </div>

    </asp:Content>
