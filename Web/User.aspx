<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="Laghaee.WebSite.User" Title="Users" %>


<asp:Content ID="Content1" ContentPlaceHolderID="PageHeaderContentPlaceHolder" runat="server">
<h1>Users 
   <script type="text/javascript" src="../../Javascripts/javascript.js"></script>
   </h1>
   <div class="descr">
        You can define user .</div>
   <hr/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div id="divOperations" runat="server">
     &nbsp;
     <img id="imgSearch" alt="Search" onclick="javascript:ToggleDivVisibility('divSearchInfo');"
         src="images/Search.png" style="border-top-style: none; border-right-style: none;
         border-left-style: none; border-bottom-style: none" />
     &nbsp;
          <div id="dvCommands" style="width: 97%;">
    <asp:Button ID="BtnNew" runat="server" Height="24px"  Text="New" Width="48px" OnClick="BtnNew_Click" CausesValidation="False" />
    <asp:Button ID="BtnUpdate" runat="server" Height="24px" Text="Update" Width="71px" OnClick="BtnUpdate_Click"  OnClientClick="return confirm('Do you want to update this User? Are you sure?');" />
    <asp:Button ID="BtnRemove" runat="server" Height="24px"  Text="Remove" Width="71px" OnClick="BtnRemove_Click" OnClientClick="return confirm('Do you want to remove this User? Are you sure?');"/>
    </div>
 </div> 
 <div id="divDetail" runat="server" style="margin-top:10px; width:99%; ">
    <table style="width: 650px">
    <tr>
        <td style="width: 87px; height: 24px"><asp:Label ID="lblID" runat="server" Text="ID:" Visible="False"></asp:Label></td>
        <td style="width: 206px; height: 24px;"><asp:TextBox ID="txtID" runat="server" Visible="False" Width="131px"></asp:TextBox></td>
      </tr>
    <tr>
        <td style="width: 87px; height: 37px;"><asp:Label ID="LblFirstName" runat="server"  Text="FirstName:" Width="69px"></asp:Label></td>
        <td style="height: 37px; width: 206px;"><asp:TextBox ID="txtFirstName" runat="server" Width="96%"></asp:TextBox></td>
        <td style="height: 37px; width: 66px;"><asp:Label ID="lblLastName" runat="server" Text="LastName:"/></td>
        <td style="height: 37px"><asp:TextBox ID="txtLastName" runat="server" Width="96%"></asp:TextBox></td>    
    </tr>
      <tr>
        <td style="width: 87px; height: 37px;"><asp:Label ID="LblUserName" runat="server"  Text="User Name:" Width="69px"></asp:Label></td>
        <td style="height: 37px; width: 206px;"><asp:TextBox ID="txtUserName" runat="server" Width="96%"></asp:TextBox></td>
        <td style="height: 37px; width: 66px;"><asp:Label ID="LblPassword" runat="server" Text="Password:"/></td>
        <td style="height: 37px"><asp:TextBox ID="txtPassword" runat="server" Width="96%" ></asp:TextBox></td>           
      </tr>
    </table>
    <table>
       <tr>
        <td style="height: 37px"><asp:Label ID="LblEmailAddress" runat="server" Text="Email Address:"></asp:Label></td>
        <td style="height: 37px; width: 556px;"><asp:TextBox ID="txtEmailAddress" runat="server" Width="98%"></asp:TextBox></td> 
      </tr>
    </table>

    <table >
    <tr>
      <td style="width: 194px; height: 136px;"> 
      <asp:CheckBoxList  ID="AccessPageCheckBoxList" runat="server" TextAlign="Right"  Width="228px"  CellSpacing="3" CellPadding="3" RepeatLayout="Flow"   BorderStyle="Double">
      <asp:ListItem Value="HasAgentAccess"      Text="Agent"></asp:ListItem>
      <asp:ListItem Value="HasPatentAccess"     Text="Patent"></asp:ListItem>
      <asp:ListItem Value="HasDesignAccess"     Text="Design"></asp:ListItem>
      <asp:ListItem Value="HasApplicantAccess"  Text="Applicant"></asp:ListItem>
      <asp:ListItem Value="HasTradeMarkAccess"  Text="Trademark"></asp:ListItem>
      <asp:ListItem Value="HasLetterAccess"     Text="Letter"></asp:ListItem>
      <asp:ListItem Value="HasAttachmentAccess" Text="Attachment"></asp:ListItem>
      <asp:ListItem Value="IsAdmin"             Text="Is admin"></asp:ListItem>
      </asp:CheckBoxList>
      </td>
      </tr>
    </table>
  </div> 
  <div id="divGrid" runat="server" style="width: 97%; margin-left :1%;margin-top:5px">
        <asp:GridView ID="grdUser" runat="server" AutoGenerateColumns="False" Caption="List of users:"
                      CaptionAlign="Left" DataKeyNames="ID" HorizontalAlign="Center" Width="100%" BorderColor="#E0E0E0" BorderStyle="Ridge" BorderWidth="2px" BackColor="#404040" CellPadding="5" AllowPaging="True" AllowSorting="True" OnSelectedIndexChanged="grdUser_SelectedIndexChanged" OnSorting="grdUser_Sorting" OnPageIndexChanging="grdUser_PageIndexChanging">
        <Columns>
         <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="True" Visible="False" ></asp:BoundField>
            <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="FirstName" ></asp:BoundField>
            <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName" ></asp:BoundField>
            <asp:BoundField DataField="EmailAddress" HeaderText="Email Address" ></asp:BoundField>
            <asp:BoundField DataField="IsAdmin" HeaderText="Is Admin" ></asp:BoundField>
            <asp:CommandField ShowSelectButton="True" />
        </Columns>
        <SelectedRowStyle BackColor="#C0C0FF" ForeColor="#404040" HorizontalAlign="Center"
            VerticalAlign="Middle" />
        <HeaderStyle BackColor="#404040" Font-Bold="True" ForeColor="White" />
        <PagerStyle BorderColor="#404040" VerticalAlign="Bottom" BackColor="#404040" Font-Size="Larger" />
        <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#E0E0E0" BorderColor="Black"  />
    </asp:GridView> 
    </div>
    
</asp:Content>
 