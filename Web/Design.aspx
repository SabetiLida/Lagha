<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="Design" Title="Design" Codebehind="Design.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="PageHeaderContentPlaceHolder" runat="server">

<h1>Design</h1>
    <div class="descr">       
        Somthing Important For Notice !</div>
    <hr />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="divOperations" runat="server">
        <img alt="Search" src="images/Search.png" id="imgSearch" style="border-top-style: none; border-right-style: none; border-left-style: none; border-bottom-style: none" 
                 onclick="javascript:ToggleDivVisibility('divSearchInfo');" />&nbsp;
                 <div id="dvCommands" runat="server" style="width: 97%;">
            <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="New" CausesValidation="False" />
            <asp:Button ID="btnUpdate" runat="server" Text="Update"  OnClick="btnUpdate_Click" 
                        OnClientClick="return confirm('Do you want to update this design? Are you sure?');"/>
            <asp:Button ID="btnRemove" runat="server" OnClick="btnRemove_Click" Text="Remove" 
                        OnClientClick="return confirm('Do you want to remove this design? Are you sure?');"/>
            </div>  
    </div>
    
    <div id="divDetail" runat="server" style="margin-top:10px; width:99%; ">
    <div id="dvMain"><h3 style="color:White;margin-left:5px;">Information</h3></div>
        <div style="width: 97%;">
        <fieldset style="margin-left:1%; width:100%">
            <legend>Design Information</legend>
        <asp:Label ID="lblValidationFailed" runat="server" Font-Bold="True" Text="Please enter the * field first."
            Visible="False"></asp:Label>
            <div style="margin-left:5px; margin-right:5px">
                <table id="tblInformation" style="width: 96%">
                <tr>
                    <td style="width: 1px; "></td>
                    <td colspan="3">
                        <asp:Image style="margin-left:2px;margin-right:2px;" ID="imgPicture" runat="server" BorderColor="#E0E0E0" BorderStyle="Dashed" BorderWidth="8px" ImageAlign="Middle" Height="233px" Width="600px" />
                        <asp:FileUpload ID="ctrlUpload" runat="server" Visible="False" Height="22px" /><br />
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        <asp:Button ID="btnUpload" runat="server" Text="Upload" Visible="False" OnClick="btnUpload_Click" Width="80px" Height="22px" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 1px"></td>
                    <td style="width: 266px">
                        <asp:Label ID="lblFillingNo" runat="server" Text="Filling Number:"></asp:Label>
                        <asp:RequiredFieldValidator ID="ctrlFillingNoExistancev" runat="server" ControlToValidate="txtFillingNo"
                            ErrorMessage="*"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="ctrlFillingNoValidator" runat="server" ControlToValidate="txtFillingNo"
                            ErrorMessage="Invalid No!" ValidationExpression="(\d){1,15}"></asp:RegularExpressionValidator><br />
                        <asp:TextBox ID="txtFillingNo" runat="server" Width="103px"></asp:TextBox>
                        <asp:CustomValidator ID="ctrlFillingNoExistanceValidator" runat="server" ControlToValidate="txtFillingNo"
                            ErrorMessage="Already Exist!" OnServerValidate="ctrlFillingNoExistanceValidator_ServerValidate"></asp:CustomValidator></td>
                    <td style="width: 279px">
                        <asp:Label ID="lblID" runat="server" Text="ID:" Visible="False"></asp:Label><asp:TextBox ID="txtID" runat="server" Visible="False" Width="131px"></asp:TextBox><br />
                    </td>
                    <td style="width: 288px">
                        <asp:Label ID="lblYear" runat="server" Text="Year"></asp:Label>&nbsp;
                        <asp:RegularExpressionValidator ID="ctrlYearValidator" runat="server" ControlToValidate="txtYear" ErrorMessage="Invalid Year (yyyy)" ValidationExpression="(\d){4}"></asp:RegularExpressionValidator><br />
                        <asp:TextBox ID="txtYear" runat="server" Width="36px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 1px;"></td>
                    <td style="width: 266px;">
                        <asp:Label ID="lblRegNo" runat="server" Text="Registration Number:"></asp:Label><asp:RegularExpressionValidator ID="ctrlRegNoValidator" runat="server" ControlToValidate="txtRegNo"
                            ErrorMessage="Invalid No!" ValidationExpression="\d+"></asp:RegularExpressionValidator><br />
                        <asp:TextBox ID="txtRegNo" runat="server" Width="140px"></asp:TextBox>
                    <asp:CustomValidator
                                ID="ctrlRegNoExistanceValidator" runat="server" ControlToValidate="txtRegNo"
                                ErrorMessage="Already Exist!" OnServerValidate="ctrlRegNoExistanceValidator_ServerValidate"></asp:CustomValidator></td>
                    <td style="width: 279px; ">
                        <asp:Label ID="Label2" runat="server" Text="Registration Date: (Gregorian)"></asp:Label><br />
                        <asp:Label ID="lblRegDateG" runat="server"></asp:Label></td>
                    <td style="width: 288px; ">
                        <asp:Label ID="lblRegDate" runat="server" Text="Registration Date:"></asp:Label>
                        <asp:CustomValidator ID="ctrlRegDateValidator" runat="server" ErrorMessage="Invalid Date!" OnServerValidate="ctrlRegDateValidator_ServerValidate"></asp:CustomValidator><br />
                        <asp:TextBox ID="txtRegDateYear" runat="server" Width="30px" MaxLength="4"></asp:TextBox>
                        <asp:Label ID="Label6" runat="server">/</asp:Label>
                        <asp:TextBox ID="txtRegDateMonth" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                        <asp:Label ID="Label7" runat="server" Text="/"></asp:Label>
                        <asp:TextBox ID="txtRegDateDay" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
 
                    </td>
                </tr>
                <tr>
                    <td style="width: 1px"></td>
                    <td style="width: 266px">
                        <asp:Label ID="lblAppNo" runat="server" Text="Application Number:" Width="123px"></asp:Label><asp:RegularExpressionValidator ID="ctrlAppNoValidator" runat="server" ControlToValidate="txtAppNo"
                            ErrorMessage="Invalid No!" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                        <br />
                        <asp:TextBox ID="txtAppNo" runat="server" Width="140px"></asp:TextBox><asp:CustomValidator ID="ctrlAppNoExistanceValidator" runat="server" ControlToValidate="txtAppNo"
                            ErrorMessage="Already Exist!" OnServerValidate="ctrlAppNoExistanceValidator_ServerValidate"></asp:CustomValidator></td>
                    <td style="width: 279px">
                        <asp:Label ID="Label3" runat="server" Text="Application Date: (Gregorian)"></asp:Label><br />
                        <asp:Label ID="lblAppDateG" runat="server"></asp:Label></td>
                    <td style="width: 288px">
                        <asp:Label ID="lblAppDate" runat="server" Text="Application Date:"></asp:Label>
                        <asp:CustomValidator ID="ctrlAppDateValidator" runat="server" ErrorMessage="Invalid Date!" OnServerValidate="ctrlAppDateValidator_ServerValidate"></asp:CustomValidator><br />
                        <asp:TextBox ID="txtAppDateYear" runat="server" Width="30px" MaxLength="4"></asp:TextBox>
                        <asp:Label ID="Label8" runat="server">/</asp:Label>
                        <asp:TextBox ID="txtAppDateMonth" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                        <asp:Label ID="Label9" runat="server" Text="/"></asp:Label>
                        <asp:TextBox ID="txtAppDateDay" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 1px;" ></td>
                    <td style="width: 266px">
                        <asp:CheckBox ID="chkFirstRenewalDate" runat="server" Text="First Renewal Date" /><br />
                        <asp:Label ID="Label4" runat="server" Width="171px">Gregorian:</asp:Label><br />
                        <asp:Label ID="lblFirstRenewalDate" runat="server" Width="171px"></asp:Label><br />
                        <asp:Label ID="Label5" runat="server" Width="171px">Shamsi:</asp:Label><br />
                        <asp:Label ID="lblFirstRenewalDateShamsi" runat="server" Width="171px"></asp:Label></td>
                    <td style="width: 279px">
                        <asp:CheckBox ID="chkSecondRenewalDate" runat="server" Text="Second Renewal Date" /><br />
                        <asp:Label ID="Label10" runat="server" Width="171px">Gregorian:</asp:Label><br />
                        <asp:Label ID="lblSecondRenewalDate" runat="server" Width="166px"></asp:Label><br />
                        <asp:Label ID="Label11" runat="server" Width="171px">Shamsi:</asp:Label><br />
                        <asp:Label ID="lblSecondRenewalDateShamsi" runat="server" Width="171px"></asp:Label></td>
                    <td style="width: 288px">
                        <asp:CheckBox ID="chkThirdRenewalDate" runat="server" Text="Third Renewal Date" Visible="False" />
                        <asp:Label ID="Label12" runat="server" Width="171px" Visible="False">Gregorian:</asp:Label><br />
                        <asp:Label ID="lblThirdRenewalDate" runat="server" Width="163px" Visible="False"></asp:Label><br />
                        <asp:Label ID="Label13" runat="server" Width="171px" Visible="False">Shamsi:</asp:Label><br />
                        <asp:Label ID="lblThirdRenewalDateShamsi" runat="server" Width="171px" Visible="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 1px"></td>
                    <td colspan="3">
                        <asp:Label ID="lblStatusName" runat="server" Text="Status"></asp:Label>
                        <asp:CustomValidator ID="ctrlStatusValidator" runat="server" ControlToValidate="drpStatus"
                            ErrorMessage="Invalid Status!" OnServerValidate="ctrlStatusValidator_ServerValidate" ValidateEmptyText="True"></asp:CustomValidator><br />
                        <asp:DropDownList ID="drpStatus" runat="server" Width="605px">
                        </asp:DropDownList></td>
                </tr>
                    <tr>
                        <td style="width: 1px">
                        </td>
                        <td colspan="3">
                        <asp:Label ID="lblApplicant" runat="server" Text="Applicant"></asp:Label><asp:CustomValidator ID="ctrlApplicantValidator" runat="server" ControlToValidate="drpApplicant"
                            ErrorMessage="Invalid Applicant!" OnServerValidate="ctrlApplicantValidator_ServerValidate" ValidateEmptyText="True"></asp:CustomValidator><br />
                        <asp:DropDownList ID="drpApplicant" runat="server" Width="605px"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td style="width: 1px">
                        </td>
                        <td colspan="3">
                        <asp:Label ID="lblAgent" runat="server" Text="Agent"></asp:Label><asp:CustomValidator ID="ctrlAgentValidator" runat="server" ControlToValidate="drpAgent"
                            ErrorMessage="Invalid Agent!" OnServerValidate="ctrlAgentValidator_ServerValidate" ValidateEmptyText="True"></asp:CustomValidator><br />
                        <asp:DropDownList ID="drpAgent" runat="server" Width="605px">
                            <asp:ListItem Value="2">Test2</asp:ListItem>
                            <asp:ListItem Value="3">Test3</asp:ListItem>
                        </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td style="width: 1px">
                        </td>
                        <td colspan="3">
                        <asp:Label ID="lblAgent2" runat="server" Text="Agent-2"></asp:Label><asp:CustomValidator ID="ctrlAgentValidator2" runat="server" ControlToValidate="drpAgent2"
                            ErrorMessage="Invalid Agent-2!" OnServerValidate="ctrlAgent2Validator_ServerValidate" ValidateEmptyText="True"></asp:CustomValidator><br />
                        <asp:DropDownList ID="drpAgent2" runat="server" Width="605px">
                            <asp:ListItem Value="2">Test2</asp:ListItem>
                            <asp:ListItem Value="3">Test3</asp:ListItem>
                        </asp:DropDownList></td>
                    </tr>
                <tr>
                    <td style="width: 1px"></td>
                    <td style="width: 266px">
                        <asp:Label ID="lblPowerAtTorney" runat="server" Text="Power Of Attorney:"></asp:Label>
                        <asp:RegularExpressionValidator ID="ctrlPoweralValidator" runat="server" ControlToValidate="txtPowerOfAttorney"
                            ErrorMessage="Invalid No!" ValidationExpression="(\d){1,15}"></asp:RegularExpressionValidator>
                        <asp:TextBox ID="txtPowerOfAttorney" runat="server" Width="115px"></asp:TextBox></td>
                    <td style="width: 279px">
                        <asp:Label ID="lblKCommission" runat="server" Text="K-Commission:"></asp:Label><br />
                        <asp:TextBox ID="txtKCommission" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    <td style="width: 288px">
                        <asp:Label ID="lbllastUpdate" runat="server" Text="Last Checked Date: (Gregorian)"></asp:Label><br />
                        <asp:Label ID="lblLastCheckedDateValue" runat="server"></asp:Label>
                        &nbsp;
                    </td>
                </tr>
                    <tr>
                    <td style="width: 1px"></td>
                    <td style="width: 266px">
                        <asp:Label ID="lblAdditionalGoodsClasses" runat="server" Visible="false" Text="Additional of goods and classes (AppNo)"></asp:Label>
                         <asp:RegularExpressionValidator ID="ctrlAdditionalGoodsClassesValidator" runat="server" ControlToValidate="txtAdditionalGoodsClasses"
                                    ErrorMessage="Invalid No!" ValidationExpression="\d+" Visible="false"></asp:RegularExpressionValidator><br />
                        <asp:TextBox ID="txtAdditionalGoodsClasses" runat="server" Width="150px" Visible="false"></asp:TextBox>
                        <asp:CustomValidator ID="ctrlAdditionalGoodsClassesExistanceValidator" runat="server" ControlToValidate="txtAdditionalGoodsClasses"
                                    ErrorMessage="Already Exist!" OnServerValidate="ctrlAdditionalGoodsClassesExistanceValidator_ServerValidate" Visible="false"></asp:CustomValidator>
                    </td>
                    <td style="width: 279px">
                        
                        </td>
                    <td style="width: 288px">
                        
                    </td>
                </tr>

                <tr>
                    <td style="width: 1px; height: 46px;" ></td>
                    <td style="height: 46px;" colspan="3">
                        <asp:Label ID="Label1" runat="server" Text="Class:"></asp:Label>
                        <br />
                        <asp:TextBox ID="txtClass" runat="server" Width="601px"></asp:TextBox>
                    </td>
                </tr>
                     <tr>
                         <td style="width: 1px; height: 46px;" ></td>
                            <td colspan="3">
                                <asp:Label ID="lblComment" runat="server" Text="Comment:"></asp:Label><br />
                                <asp:TextBox ID="txtComment" runat="server" Width="97%" TextMode="MultiLine"></asp:TextBox></td>
                        </tr>
            </table>
            </div> 
            </fieldset>
        </div>
    </div>
    
    <div id="divGrid" runat="server" style="width: 97%; margin-left :1%;margin-top:5px">
        <asp:GridView ID="grdDesign" runat="server" AutoGenerateColumns="False" Caption="Design Applications:"
                      CaptionAlign="Left" DataKeyNames="ID" HorizontalAlign="Center" Width="100%" OnSelectedIndexChanged="grdDesign_SelectedIndexChanged" 
                      AllowPaging="True" AllowSorting="True" OnSorting="grdDesign_Sorting" OnPageIndexChanging="grdDesign_PageIndexChanging" 
                      BorderColor="#E0E0E0" BorderStyle="Ridge" BorderWidth="2px" BackColor="#404040" CellPadding="5">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="True" Visible="False" >
                <ControlStyle Width="0px" />
                <ItemStyle Width="0px" />
                <HeaderStyle Width="0px" />
                <FooterStyle Width="0px" />
            </asp:BoundField>
            <asp:BoundField DataField="Year" HeaderText="Year" SortExpression="Year" />
             <asp:TemplateField HeaderText="Status">
                    <ItemTemplate>
                       <asp:Label ID="lblGridStatus" runat="server" Text='<%#StatusName(DataBinder.Eval(Container.DataItem,"StatusId"))%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            <asp:TemplateField HeaderText="Letters">           
                <ItemTemplate >
                <asp:HyperLink ID="HyperLink1" Target="_self" runat  ="server" ImageUrl='<%#HasLetter(DataBinder.Eval(Container.DataItem,"FillingNo"))%>' NavigateUrl='<%# "Letters.aspx?FillingNo="+ DataBinder.Eval(Container.DataItem,"FillingNo")+"&LetterType=1"+"&AgentId="+DataBinder.Eval(Container.DataItem,"AgentId")%>' ></asp:HyperLink>
                </ItemTemplate>
                </asp:TemplateField>
            <asp:BoundField DataField="FillingNo" HeaderText="FillingNo" />
            <asp:BoundField DataField="RegNo" HeaderText="RegNo" />
            <asp:BoundField DataField="AppNo" HeaderText="AppNo" />
            <asp:BoundField DataField="Class" HeaderText="Class" />
            <asp:CommandField ShowSelectButton="True" />
        </Columns>
        <SelectedRowStyle BackColor="#C0C0FF" ForeColor="#404040" HorizontalAlign="Center"
            VerticalAlign="Middle" />
        <HeaderStyle BackColor="#404040" Font-Bold="True" ForeColor="White" />
        <PagerStyle BorderColor="#404040" VerticalAlign="Bottom" BackColor="#404040" Font-Size="Larger" />
        <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#E0E0E0" BorderColor="Black"  />
    </asp:GridView>
    </div>
    
    <div id="divSearchInfo" style="position: absolute; top: 155px; left: 50px; visibility:hidden ; background-color:#b0c4de;">
<table id="table13" cellspacing="0" cellpadding="0" width="45%" style="z-index: 100; left: 378px;  top: 48px">
                <tr>
                    <td style="height: 17px" >
                        <div onmousedown="dragStart(event, 'divSearchInfo')" id="DragAreaDiv" style="background-color: #404040">
                            <a id="CloseLink" href="javascript:SetHidden(divSearchInfo);">
                                <img alt="Close" src="images/Close.jpg" width="21" style="border-top-style: none; border-right-style: none; border-left-style: none; border-bottom-style: none; text-decoration: underline;" /><span
                                    style="color: #ffffff"> </span>
                            </a>
                        </div>
                    </td>
                </tr>
                <tr style="color: #ffffff">
                    <td class="TextArea" style="width: 423px; height: 265px;">
                        <table border="0" cellpadding="0" cellspacing="0" id="table1" style="BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove">
                            <tr>
                                <td style="text-align: left;" >
                                    <b>Application Number:<asp:RegularExpressionValidator ID="RegularExpressionValidator3"
                                        runat="server" ControlToValidate="txtSrchAppNo" ErrorMessage="Invalid!" Font-Bold="False"
                                        ValidationExpression="\d+" ValidationGroup="Search"></asp:RegularExpressionValidator></b><br />
                                    <asp:TextBox ID="txtSrchAppNo" runat="server" Width="180px"></asp:TextBox></td>
                                <td style="font-weight: bold" >
                                    Registration Number:<asp:RegularExpressionValidator ID="RegularExpressionValidator4"
                                        runat="server" ControlToValidate="txtSrchRegNo" ErrorMessage="Invalid!" Font-Bold="False"
                                        ValidationExpression="\d+" ValidationGroup="Search"></asp:RegularExpressionValidator><br />
                                    <asp:TextBox ID="txtSrchRegNo" runat="server" Width="180px"></asp:TextBox>
                                </td>
                            </tr>
                             <tr style="display:none">
                                    <td colspan="2" style="text-align: left;display:none">
                                <strong style="display:none">Additional of goods and classes (AppNo)<br />
                                </strong>
                                <asp:TextBox ID="txtSrchAdditionalGoodsClassesNo" runat="server" Width="444px" Visible="false"></asp:TextBox>
                            </td>
                            </tr>
                            <tr>
                                <td style="text-align: left;" colspan="2">
                                    <b>Agent:</b><br />
                                    <asp:DropDownList ID="drpSrchAgent" runat="server" Width="450px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left;" colspan="2">
                                    <b>Agent-2:</b><br />
                                    <asp:DropDownList ID="drpSrchAgent2" runat="server" Width="450px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="text-align: left">
                                   <b> Applicant:</b><br />
                                    <asp:DropDownList ID="drpSrchApplicant" runat="server" Width="450px">
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td style="text-align: left">
                                    <strong>Filling No:</strong>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtsrchFillingNo"
                                        ErrorMessage="Invalid Number!" ValidationExpression="(\d){1,15}" ValidationGroup="Search"></asp:RegularExpressionValidator><br />
                                    <asp:TextBox ID="txtsrchFillingNo" runat="server" Width="180px"></asp:TextBox>
                                </td>
                                <td style="text-align: left">
                                    <b>Status:</b><br />
                                    <asp:DropDownList ID="drpSrchStatus" runat="server" >
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="text-align: left">
                                    <strong>Trademark:<br />
                                    </strong>
                                    <asp:TextBox ID="txtsrchTrademark" runat="server" Width="444px"></asp:TextBox>
                                </td>
                            </tr>
                        </table>           
                        <asp:Button style="margin-top:5px" ID="Button1" runat="server" Text="Search" OnClick="btnStartSearch_Click" CausesValidation="False"/>
                    </td>
                </tr>
            </table>

        </div>
        
</asp:Content>

