<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="Agents" Title="Agents" Codebehind="Agents.aspx.cs" %>
<asp:Content ID="Content2" ContentPlaceHolderID="PageHeaderContentPlaceHolder" runat="server">
    <h1>
        Agent Applications</h1>
    <div class="descr">Somthing Important For Notice !</div>
    <hr />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="divOperations" runat="server">
        <div id="dvCommands" runat="server" style="width: 97%;">
            <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="New" CausesValidation="False" />
            <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" 
                        OnClientClick="return confirm('Do you want to update this agent? Are you sure?');"/>
            <asp:Button ID="btnRemove" runat="server" OnClick="btnRemove_Click" Text="Remove" 
                        OnClientClick="return confirm('Do you want to remove this agent? Are you sure?');"/>
        </div>
    </div> 
    
    <div id="divDetail" runat="server" style="margin-top:10px; width:99%;">
        <div id="dvMain"><h3 style="color:White;">Information</h3></div>
        <div style="width: 97%;">
            <fieldset style="margin-left:1%; width:100%" dir="ltr">
            <legend>Agent Information</legend>
                <div style="margin-left:2%;">
                <asp:Label ID="lblAgentName" runat="server" Text="Agent Name:"></asp:Label>&nbsp;
                <asp:RequiredFieldValidator ID="ctrlAgentNameValidator" runat="server" ControlToValidate="txtAgentName" ErrorMessage="*"></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="ctrlAgentNameExistanceValidator" runat="server" ControlToValidate="txtAgentName"
                        ErrorMessage="Already Exist!" OnServerValidate="ctrlAgentNameExistanceValidator_ServerValidate"></asp:CustomValidator>
                    <asp:Label ID="lblID" runat="server" Text="ID:" Visible="False"></asp:Label><asp:TextBox
                        ID="txtID" runat="server" Visible="False" Width="131px"></asp:TextBox><br />
                <asp:TextBox ID="txtAgentName" runat="server" Width="603px"></asp:TextBox>
                </div>
            </fieldset> 
        </div>
    </div>
 
    <div id="divGrid" runat="server" style="width: 97%; margin-left :1%; margin-top:5px">
        <asp:GridView ID="grdAgentList" runat="server" AutoGenerateColumns="False" Caption="Agent Applications:"
            CaptionAlign="Left" DataKeyNames="ID" HorizontalAlign="Center" OnSelectedIndexChanged="grdAgentList_SelectedIndexChanged"
            Width="100%" AllowPaging="True" AllowSorting="True" OnPageIndexChanging="grdAgentList_PageIndexChanging" 
            BorderColor="#E0E0E0" BorderStyle="Ridge" BorderWidth="2px" BackColor="#404040" CellPadding="5">
            <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#E0E0E0" BorderColor="Black" />
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" Visible="False" />
                <asp:BoundField DataField="AgentName" HeaderText="Agent Name" />
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
            <PagerStyle BorderColor="#404040" VerticalAlign="Bottom" BackColor="#404040" Font-Overline="False" Font-Size="Larger" Font-Strikeout="False" />
            <SelectedRowStyle BackColor="#C0C0FF" ForeColor="#404040" HorizontalAlign="Center"
                VerticalAlign="Middle" />
            <HeaderStyle BackColor="#404040" Font-Bold="True" ForeColor="White" />
        </asp:GridView>
    </div>
</asp:Content>

