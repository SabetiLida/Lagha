<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Letters.aspx.cs" Inherits="Laghaee.WebSite.Letters" Title="Letters"  ValidateRequest="false" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2"  %>
<asp:Content ID="Content2" ContentPlaceHolderID="PageHeaderContentPlaceHolder" runat="server">

<h1>Letters 
<script type="text/javascript" src="../../Javascripts/javascript.js"></script>
</h1>
<div class="descr">
        You can enter, search and view the letters .</div>
        <hr />
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div id="divOperations" runat="server">
     &nbsp;
     <img id="imgSearch" alt="Search" onclick="javascript:ToggleDivVisibility('divSearchInfo');"
         src="images/Search.png" style="border-top-style: none; border-right-style: none;
         border-left-style: none; border-bottom-style: none" />
     &nbsp;
          <div id="dvCommands" runat="server" style="width: 97%;">
    <asp:Button ID="BtnNew" runat="server" Height="24px"  Text="New" Width="48px" OnClick="BtnNew_Click" CausesValidation="False" />
    <asp:Button ID="BtnUpdate" runat="server" Height="24px" Text="Update" Width="71px" OnClick="BtnUpdate_Click" OnClientClick="return confirm('Do you want to update this Letter? Are you sure?');" />
    <asp:Button ID="BtnRemove" runat="server" Height="24px"  Text="Remove" Width="71px" OnClick="BtnRemove_Click" OnClientClick="return confirm('Do you want to remove this Letter? Are you sure?');"/>
    </div>
 </div>
 
    <div id="divDetail" runat="server" style="margin-top:10px; width:99%; ">
    <table>
      <tr>
       
        <td style="height: 37px; width: 53px;"><asp:Label ID="lblLetterDate" runat="server" Text="Letter Date:" Width="80px"/></td>
        <td style="height: 37px"><asp:TextBox ID="txtLetterYear" runat="server" MaxLength="4" Width="30px"></asp:TextBox></td>
        <td style="height: 37px"><asp:Label ID="Label7" runat="server" Text="/"></asp:Label></td>
        <td style="height: 37px"><asp:TextBox ID="txtLetterMonth" runat="server" MaxLength="2" Width="15px"></asp:TextBox></td>
        <td style="height: 37px"><asp:Label ID="Label6" runat="server">/</asp:Label></td>
        <td style="height: 37px"><asp:TextBox ID="txtLetterDay" runat="server" MaxLength="2" Width="15px"> </asp:TextBox></td>
        <td style="height: 37px"><asp:CustomValidator ID="ctrlLetterDateValidator" runat="server" ErrorMessage="Invalid Date!" OnServerValidate="ctrlLetterDateValidator_ServerValidate"></asp:CustomValidator></td>
        <td><fieldset>
        <legend >C/O</legend>
        <asp:RadioButtonList ID="RedioButtonListClientOfficeLetter" runat="server" Visible="True" TextAlign="Left" >
            <asp:ListItem Value="Client" Selected="True">Client&nbsp</asp:ListItem><asp:ListItem Value="Office">Office&nbsp</asp:ListItem>
        </asp:RadioButtonList>
        </fieldset> 
       </td>
         <td style="height: 37px"><asp:Label ID="lblAgentName" runat="server"  Text="Agent Name :" Width="80px" Visible="false"></asp:Label></td>
        <td style="height: 37px"> <asp:DropDownList ID="drpAgent" runat="server"  Width="135px" Visible="false" ></asp:DropDownList></td>
        <td style="text-align: left; width: 40px; height: 37px;"></td>
        
       <td style="height: 37px"> <asp:RadioButtonList ID="RadioButtonListDate" runat="server" Visible="false"  >
            <asp:ListItem>Hj</asp:ListItem><asp:ListItem Selected="True">Ad</asp:ListItem></asp:RadioButtonList>
       </td>
        <%--<td style="text-align: left; width: 10px; height: 37px;"></td>--%>
      </tr>
      <tr>
        <td style="width: 53px"><asp:Label ID="lblID" runat="server" Text="ID:" Visible="False"></asp:Label></td>
        <td><asp:TextBox ID="txtID" runat="server" Visible="False" Width="131px"></asp:TextBox></td>
      </tr>
    </table>
    <table><tr></tr></table>
    <table>
     <tr>    
       <td><asp:Label ID="lblTitle" runat="server"  Text="Letter Name :" Width="80px"></asp:Label></td>
       <td><asp:TextBox ID="txtTiltle" runat="server" Height="19px" Width="562px" ></asp:TextBox></td>
     </tr>
     
    </table>
   <table style="width:100%">
     <tr>
       <td><FCKeditorV2:FCKeditor ID="FCKeditor1" runat="server" BasePath="~/FCKeditor/" Height="300px" SkinPath="skins/office2003/"></FCKeditorV2:FCKeditor></td>
     </tr>
   </table> 
  <div id="dvCommand" style="width: 97%;" class="controlBox">
       &nbsp;<asp:Button ID="BtnAttachment" runat="server" Height="24px"  Text="Attachment" Width="90px" CssClass="input-submit-2" OnClientClick="OpenAttach()"  Visible="false"/></div>
     </div>  
    <div id="divGrid" runat="server" style="width: 97%; margin-left :1%;margin-top:5px">
        <asp:GridView ID="grdAgentLetter" runat="server" AutoGenerateColumns="False" Caption="Letters of agent:"
                      CaptionAlign="Left" DataKeyNames="ID" HorizontalAlign="Center" Width="100%" 
                      BorderColor="#E0E0E0" BorderStyle="Ridge" BorderWidth="2px" BackColor="#404040" CellPadding="5" 
                      OnSelectedIndexChanged="grdAgentLetter_SelectedIndexChanged" AllowPaging="True" AllowSorting="True" 
                      OnPageIndexChanging="grdAgentLetter_PageIndexChanging" OnSorting="grdAgentLetter_Sorting" OnRowCommand="grdAgentLetter_RowCommand">
                              <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#E0E0E0" BorderColor="Black"/>

        <Columns>
         <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="True" Visible="False" >
                <ControlStyle Width="0px" />
                <ItemStyle Width="0px" />
                <HeaderStyle Width="0px" />
                <FooterStyle Width="0px" />
            </asp:BoundField>
            <asp:BoundField DataField="AgentId" HeaderText="AgentID"  Visible="False" >
            </asp:BoundField>
            <asp:BoundField DataField="LetterContent" HeaderText="LetterContent" HtmlEncode="false" visible="false" >
            </asp:BoundField>
            <asp:BoundField DataField="AgentName" HeaderText="Agent" SortExpression="AgentName" Visible="false" />
            <asp:BoundField DataField="LetterDate" HeaderText="Date" SortExpression="LetterDate" />
            <asp:BoundField DataField="RegisterDate" HeaderText="RegisterDate" Visible="False" >
            </asp:BoundField>
            <asp:BoundField DataField="LetterName" HeaderText="Title" SortExpression="LetterName"/>
           <asp:TemplateField HeaderText="Attachments">           
           <ItemTemplate>
           <asp:HyperLink runat ="server" Target="_blank" ImageUrl='<%#HasAttachment(DataBinder.Eval(Container.DataItem,"Id"))%>'  NavigateUrl='<%# "Attachment.aspx?Id="+ DataBinder.Eval(Container.DataItem,"Id")+"&AgentId="+GetAgentId()+"&AgentName="+GetAgentName()%>' ></asp:HyperLink>
           </ItemTemplate>
           </asp:TemplateField>
            
            <asp:TemplateField HeaderText="C/O">           
           <ItemTemplate>
            <asp:Label runat="server" Text='<%#IsClientorOffice(DataBinder.Eval(Container.DataItem,"ClientorOffice"))%>'></asp:Label>
           </ItemTemplate>
           </asp:TemplateField>
            
            
           <asp:TemplateField HeaderText="LetterContent">           
           <ItemTemplate >
           <asp:HyperLink ID="HyperLink1" Target="_blank" ImageUrl= "~/Images/UI/mail.png" runat  ="server" Visible ='<%#HasContent(DataBinder.Eval(Container.DataItem,"LetterContent"))%>' NavigateUrl='<%# "LetterContent.aspx?Id="+ DataBinder.Eval(Container.DataItem,"Id")%>' ></asp:HyperLink>
           </ItemTemplate>
           </asp:TemplateField>
            <%--<asp:ButtonField ImageUrl="~/Images/UI/attachment2.png" HeaderText="Attachment Files" ButtonType="image" >
            </asp:ButtonField> --%>   
            <asp:CommandField ShowSelectButton="True" />
        </Columns>
        <SelectedRowStyle BackColor="#C0C0FF" ForeColor="#404040" HorizontalAlign="Center"
            VerticalAlign="Middle" />
        <HeaderStyle BackColor="#404040" Font-Bold="True" ForeColor="White" />
        <PagerStyle BorderColor="#404040" VerticalAlign="Bottom" BackColor="#404040" Font-Size="Larger" />
    </asp:GridView> 
    </div>
    <div id="divSearchInfo" style="position: absolute; top: 135px; left: 51px; visibility:hidden ; background-color:#b0c4de; ">
<table id="table13" cellspacing="0" cellpadding="0" style="z-index: 100; left: 378px; top: 48px;">
                <tr>
                    <td style="height: 21px; width: 475px;" >
                        <div onmousedown="dragStart(event, 'divSearchInfo')" id="DragAreaDiv" style="background-color: #404040">
                            <a id="CloseLink" href="javascript:SetHidden(divSearchInfo);">
                                <img alt="Close" src="images/Close.jpg" width="21" style="border-top-style: none; border-right-style: none; border-left-style: none; border-bottom-style: none; text-decoration: underline;" />
                                <span style="color: #ffffff"> </span>
                            </a>
                        </div>
                    </td>
                </tr>
                <tr style="color: #ffffff">
                    <td class="TextArea" style="width: 400px; height: 97px;">
                        <table border="0" cellpadding="0" cellspacing="0" id="table1" style="BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove; width: 475px;">
                         <tr>
                              <td> <asp:Label ID="Label2" runat="server" Text="Letter Name:" Width="79px"></asp:Label>
                                  <asp:TextBox ID="txtSrchLetterName" runat="server" Width="160px"></asp:TextBox></td>
                             <td ></td>
                             <td > <asp:Label ID="LblSrchAgent" runat="server" Text="Agent:" Visible="false"></asp:Label></td>
                                <td><asp:DropDownList ID="drpSrchAgent" runat="server" Width="27px" Visible="false"></asp:DropDownList></td>
                            </tr>
                          </table>
                          <table>
                             <tr>
                                <td > <asp:Label ID="LblSearchDate" runat="server" Text="LetterDate:" Width="86px"></asp:Label></td>
                                <td ><asp:TextBox ID="txtSrchLetterYear" runat="server" Width="30px"></asp:TextBox></td>
                               <td ><asp:Label ID="LblSlash1" runat="server" Text="/"></asp:Label></td>   
                               <td ><asp:TextBox ID="txtSrchLetterMonth" runat="server" Width="15px"></asp:TextBox></td>
                               <td ><asp:Label ID="LblSlash2" runat="server" Text="/"></asp:Label></td>
                                <td><asp:TextBox ID="txtSrchLetterDay" runat="server" Width="15px"></asp:TextBox></td>
                                <td><asp:CustomValidator ID="CtrlLetterDateSrchControl" runat="server" ErrorMessage="Invalid Date!" OnServerValidate="CtrlLetterDateSrchControl_ServerValidate"></asp:CustomValidator></td>
  
                            </tr>
                             </table>

                        <asp:Button style="margin-top:5px" ID="Button1" runat="server" Text="Search"  CausesValidation="false" OnClick="Button1_Click"/>   
                       </td>
                </tr>
            </table>

        </div>
        
</asp:Content>
