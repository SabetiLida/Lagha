<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="Applicants" Title="Applicants" Codebehind="Applicants.aspx.cs" %>
<asp:Content ID="Content2" ContentPlaceHolderID="PageHeaderContentPlaceHolder" runat="server">
    <h1>
        Applicants</h1>
    <div class="descr">
        Somthing Important For Notice !</div>
    <hr />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="divOperations" runat="server">
        <div id="dvCommands" runat="server" style="width: 97%;">
        <asp:Button ID="btnAdd" runat="server" CausesValidation="False" OnClick="btnAdd_Click"
            Text="New" />
        <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update" 
                    OnClientClick="return confirm('Do you want to update this applicant? Are you sure?');"/>
        <asp:Button ID="btnRemove" runat="server" OnClick="btnRemove_Click" Text="Remove" 
                    OnClientClick="return confirm('Do you want to remove this applicant? Are you sure?');"/>
        </div> 
    </div>
    
    <div id="divDetail" runat="server" style="margin-top:10px; width:99%; ">
        <div id="dvMain"><h3 style="color:White;">Information</h3></div>
        <div style="width: 97%;">
            <fieldset style="margin-left:1%; width:100%;">
                <legend>Applicants Information</legend>
                <div style="margin-left:2%;">
                    <asp:Label ID="lblApplicantName" runat="server" Text="Applicant Name:"></asp:Label>
                    <asp:RequiredFieldValidator ID="ctrlAgentNameValidator" runat="server" ControlToValidate="txtApplicantName" ErrorMessage="*"></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="ctrlApplicantNameExistanceValidator" runat="server" ControlToValidate="txtApplicantName"
                        ErrorMessage="Already Exist!" OnServerValidate="ctrlApplicantNameExistanceValidator_ServerValidate"></asp:CustomValidator><asp:TextBox
                        ID="txtID" runat="server" Visible="False" Width="131px"></asp:TextBox><asp:Label ID="lblID" runat="server" Text="ID:" Visible="False"></asp:Label><br />
                    <asp:TextBox ID="txtApplicantName" runat="server" Width="603px"></asp:TextBox>&nbsp;
                    &nbsp;
                </div> 
            </fieldset>
        </div>
    </div>
    
    <div id="divGrid" runat="server" style="width: 97%; margin-left :1%; margin-top:5px">
        <asp:GridView ID="grdApplicantList" runat="server" AutoGenerateColumns="False" Caption="Applicants"
            CaptionAlign="Left" DataKeyNames="ID" HorizontalAlign="Center" OnSelectedIndexChanged="grdApplicantList_SelectedIndexChanged"
            Width="100%" AllowPaging="True" AllowSorting="True" OnPageIndexChanging="grdApplicantList_PageIndexChanging" BorderColor="#E0E0E0" BorderStyle="Ridge" BorderWidth="2px" BackColor="#404040" CellPadding="5">
            <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#E0E0E0" BorderColor="Black" />
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" Visible="False" />
                <asp:BoundField DataField="ApplicantName" HeaderText="Applicant Name" />
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
            <PagerStyle BorderColor="#404040" VerticalAlign="Bottom" BackColor="#404040" Font-Size="Larger" />
            <SelectedRowStyle BackColor="#C0C0FF" ForeColor="#404040" HorizontalAlign="Center"
                VerticalAlign="Middle" />
            <HeaderStyle BackColor="#404040" Font-Bold="True" ForeColor="White" />
        </asp:GridView>
    </div>
    
</asp:Content>

