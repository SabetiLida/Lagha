<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="Logins" Title="Login" Codebehind="Logins.aspx.cs" %>
<asp:Content ID="Content2" ContentPlaceHolderID="PageHeaderContentPlaceHolder" runat="server">
    <h1>
        Login</h1>
    <div class="descr">Somthing Important For Notice !</div>
    <hr />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
        <div id="divWelcome" runat="server">
           <div id="divWelcomeMessage">
                <b id="welcomeMessage" runat="server" style="color:White;"></b>
                <sub><a href="Logins.aspx?chngpass=1">Change Password</a></sub>
            </div>
        </div>
        
        <div id="divLogin" runat="server">
            <asp:Login ID="ctrlLogin" runat="server" BackColor="#F7F7DE" BorderColor="#CCCC99"
                BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="10pt" OnAuthenticate="ctrlLogin_Authenticate">
                <TitleTextStyle BackColor="#6B696B" Font-Bold="True" ForeColor="#FFFFFF" />
            </asp:Login>
            
        </div>
        
        <div id="divChangePassword" runat="server" visible="False"> 
            <asp:ChangePassword ID="ctrlChangePassword" runat="server" BackColor="#F7F7DE" BorderColor="#CCCC99" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="10pt" OnChangingPassword="ctrlChangePassword_ChangingPassword" >
                <TitleTextStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            </asp:ChangePassword>
        </div>
    </center>
</asp:Content>

