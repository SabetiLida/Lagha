<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    Inherits="TradeMark" Title="Trademark" CodeBehind="TradeMark.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="PageHeaderContentPlaceHolder" runat="server">
    <script language="javascript" type="text/javascript">
        // <!CDATA[



        // ]]>
    </script>

    <h1>Trademark</h1>
    <div class="descr">
        Somthing Important For Notice !
    </div>
    <hr />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div id="divOperations" runat="server">
        <img alt="Search" src="images/Search.png" id="imgSearch"
            style="border-top-style: none; border-right-style: none; border-left-style: none; border-bottom-style: none"
            onclick="javascript:ToggleDivVisibility('divSearchInfo');" />
        <div id="dvCommands" runat="server" style="width: 97%;">
            <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="New" CausesValidation="False" />
            <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click"
                OnClientClick="return confirm('Do you want to update this trademark? Are you sure?');" />
            <asp:Button ID="btnRemove" runat="server" OnClick="btnRemove_Click" Text="Remove"
                OnClientClick="return confirm('Do you want to remove this trademark? Are you sure?');" />&nbsp;
        </div>
    </div>

    <div id="divDetail" runat="server" style="margin-top: 10px; width: 99%;">
        <div id="dvMain">
            <h3 style="color: White; margin-left: 10px;">Information</h3>
        </div>
        <div style="width: 97%;">
            <fieldset style="margin-left: 1%; width: 100%">
                <legend>Trademark Information</legend>
                <asp:Label ID="lblValidationFailed" runat="server" Font-Bold="True" Text="Please enter the * field first."
                    Visible="False"></asp:Label>
                <div style="margin-left: 5px; margin-right: 5px">
                    <table id="tblInformation">
                        <tr>
                            <td></td>
                            <td style="width: 219px">
                                <asp:Image ID="imgPicture" runat="server" BorderColor="#E0E0E0" BorderStyle="Dashed"
                                    BorderWidth="8px" ImageAlign="Middle" Height="120px" Width="120px" />
                            </td>
                            <td align="right" colspan="2" valign="middle">
                                <asp:FileUpload ID="ctrlUpload" runat="server" Visible="False" Height="22px" /><br />
                                <asp:Button ID="btnUpload" runat="server" Text="Upload" Visible="False" OnClick="btnUpload_Click" Width="80px" Height="22px" />
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td style="width: 219px">
                                <asp:Label ID="lblFillingNo" runat="server" Text="Filling Number:"></asp:Label><asp:RequiredFieldValidator ID="ctrlFillingNoEmptiness" runat="server" ControlToValidate="txtFillingNo"
                                    ErrorMessage="*"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="ctrlFillingNoValidator" runat="server" ControlToValidate="txtFillingNo"
                                        ErrorMessage="Invalid No!" ValidationExpression="(\d){1,15}"></asp:RegularExpressionValidator><br />
                                <asp:TextBox ID="txtFillingNo" runat="server" Width="105px"></asp:TextBox><asp:CustomValidator
                                    ID="ctrlFillingNoExistanceValidator" runat="server" ControlToValidate="txtFillingNo"
                                    ErrorMessage="Already Exist!" OnServerValidate="ctrlFillingNoExistanceValidator_ServerValidate"></asp:CustomValidator></td>
                            <td style="width: 228px">
                                <asp:TextBox ID="txtID" runat="server" Visible="False" Width="131px"></asp:TextBox><asp:Label
                                    ID="lblID" runat="server" Text="ID:" Visible="False"></asp:Label><br />
                            </td>
                            <td style="width: 214px;">
                                <asp:Label ID="lblYear" runat="server" Text="Year"></asp:Label>
                                <asp:RegularExpressionValidator ID="ctrlYearValidator" runat="server" ControlToValidate="txtYear"
                                    ErrorMessage="Invalid Year (yyyy)" ValidationExpression="(\d){4}"></asp:RegularExpressionValidator><br />
                                <asp:TextBox ID="txtYear" runat="server" Width="52px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td colspan="3">
                                <asp:Label ID="lblTradeMark" runat="server" Text="Trademark:"></asp:Label><br />
                                <asp:TextBox ID="txtTradeMark" runat="server" Width="99%" TextMode="MultiLine"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td style="width: 255px">
                                <asp:Label ID="lblRegNo" runat="server" Text="Registration Number:"></asp:Label>
                                <asp:RegularExpressionValidator ID="ctrlRegNoValidator" runat="server" ControlToValidate="txtRegNo"
                                    ErrorMessage="Invalid No!" ValidationExpression="\d+"></asp:RegularExpressionValidator><br />
                                <asp:TextBox ID="txtRegNo" runat="server" Width="150px"></asp:TextBox><asp:CustomValidator ID="ctrlRegNoExistanceValidator" runat="server" ControlToValidate="txtRegNo"
                                    ErrorMessage="Already Exist!" OnServerValidate="ctrlRegNoExistanceValidator_ServerValidate"></asp:CustomValidator></td>
                            <td style="width: 228px">
                                <asp:Label ID="Label1" runat="server" Text="Registration Date: (Gregorian)"></asp:Label><br />
                                <asp:Label ID="lblRegDateG" runat="server"></asp:Label></td>
                            <td>
                                <asp:Label ID="lblRegDate" runat="server" Text="Registration Date:"></asp:Label><asp:CustomValidator
                                    ID="ctrlRegDateValidator" runat="server" ErrorMessage="Invalid Date!" OnServerValidate="ctrlRegDateValidator_ServerValidate"></asp:CustomValidator><br />
                                <asp:TextBox ID="txtRegDateYear" runat="server" MaxLength="4" Width="30px"></asp:TextBox><asp:Label
                                    ID="Label6" runat="server">/</asp:Label><asp:TextBox ID="txtRegDateMonth" runat="server"
                                        MaxLength="2" Width="15px"></asp:TextBox><asp:Label ID="Label7" runat="server" Text="/"></asp:Label><asp:TextBox
                                            ID="txtRegDateDay" runat="server" MaxLength="2" Width="15px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td style="width: 255px">
                                <asp:Label ID="lblAppNo" runat="server" Text="Application Number:" Width="124px"></asp:Label>
                                <asp:RegularExpressionValidator ID="ctrlAppNoValidator" runat="server" ControlToValidate="txtAppNo"
                                    ErrorMessage="Invalid No!" ValidationExpression="\d+"></asp:RegularExpressionValidator><br />
                                <asp:TextBox ID="txtAppNo" runat="server" Width="150px"></asp:TextBox><asp:CustomValidator ID="ctrlAppNoExistanceValidator" runat="server" ControlToValidate="txtAppNo"
                                    ErrorMessage="Already Exist!" OnServerValidate="ctrlAppNoExistanceValidator_ServerValidate"></asp:CustomValidator></td>
                            <td style="width: 228px">
                                <asp:Label ID="Label2" runat="server" Text="Application Date: (Gregorian)"></asp:Label><br />
                                <asp:Label ID="lblAppDateG" runat="server"></asp:Label></td>
                            <td style="width: 214px;">
                                <asp:Label ID="lblAppDate" runat="server" Text="Application Date:"></asp:Label><asp:CustomValidator
                                    ID="ctrlAppDateValidator" runat="server" ErrorMessage="Invalid Date!" OnServerValidate="ctrlAppDateValidator_ServerValidate"></asp:CustomValidator><br />
                                <asp:TextBox ID="txtAppDateYear" runat="server" MaxLength="4" Width="30px"></asp:TextBox><asp:Label ID="Label5" runat="server" Text="/"></asp:Label><asp:TextBox
                                    ID="txtAppDateMonth" runat="server" MaxLength="2" Width="15px"></asp:TextBox><asp:Label
                                        ID="Label9" runat="server" Text="/"></asp:Label><asp:TextBox ID="txtAppDateDay" runat="server"
                                            MaxLength="2" Width="15px"></asp:TextBox></td>
                        </tr>

                        <tr>
                            <td></td>
                            <td style="width: 255px">
                                <asp:Label ID="lblOppositionAgainst" runat="server" Text="Opposition Against:(App No)" Width="165px"></asp:Label>
                                <asp:RegularExpressionValidator ID="ctrlOppositionAgainstValidator" runat="server" ControlToValidate="txtOppositionAgainst"
                                    ErrorMessage="Invalid No!" ValidationExpression="\d+"></asp:RegularExpressionValidator><br />
                                <asp:TextBox ID="txtOppositionAgainst" runat="server" Width="150px"></asp:TextBox>
                                <asp:CustomValidator ID="ctrlOppositionAganistExistanceValidator" runat="server" ControlToValidate="txtOppositionAgainst"
                                    ErrorMessage="Already Exist!" OnServerValidate="ctrlOppositionAgainstExistanceValidator_ServerValidate"></asp:CustomValidator>
                            </td>
                            <td style="width: 228px">
                                <asp:Label ID="lblAdditionalGoodsClasses" runat="server" Text="Additional of goods and classes (AppNo)" ></asp:Label>
                                <asp:RegularExpressionValidator ID="ctrlAdditionalGoodsClassesValidator" runat="server" ControlToValidate="txtAdditionalGoodsClasses"
                                    ErrorMessage="Invalid No!" ValidationExpression="\d+"></asp:RegularExpressionValidator><br />
                                <asp:TextBox ID="txtAdditionalGoodsClasses" runat="server" Width="150px"></asp:TextBox>
                                <asp:CustomValidator ID="ctrlAdditionalGoodsClassesExistanceValidator" runat="server" ControlToValidate="txtAdditionalGoodsClasses"
                                    ErrorMessage="Already Exist!" OnServerValidate="ctrlAdditionalGoodsClassesExistanceValidator_ServerValidate"></asp:CustomValidator>
                                </td>
                            <td style="width: 214px;">
                                <asp:Label ID="lblKCommission" runat="server" Text="K-Commission"></asp:Label><br />
                                <asp:TextBox ID="txtKCommission" runat="server" Width="150px"></asp:TextBox>
                            </td>

                        </tr>
                        <tr>
                            <td></td>
                            <td colspan="3">
                                <asp:Label ID="lblStatusName" runat="server" Text="Status"></asp:Label>
                                <asp:CustomValidator ID="ctrlStatusValidator" runat="server" ControlToValidate="drpStatus"
                                    ErrorMessage="Invalid Status!" OnServerValidate="ctrlStatusValidator_ServerValidate" ValidateEmptyText="True"></asp:CustomValidator><br />
                                <asp:DropDownList ID="drpStatus" runat="server" Width="605px">
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td colspan="3">
                                <asp:Label ID="lblApplicant" runat="server" Text="Applicant"></asp:Label><asp:CustomValidator ID="ctrlApplicantValidator" runat="server" ControlToValidate="drpApplicant"
                                    ErrorMessage="Invalid Applicant!" OnServerValidate="ctrlApplicantValidator_ServerValidate" ValidateEmptyText="True"></asp:CustomValidator><br />
                                <asp:DropDownList ID="drpApplicant" runat="server" Width="605px">
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td colspan="3">
                                <asp:Label ID="lblAgent" runat="server" Text="Agent"></asp:Label><asp:CustomValidator ID="ctrlAgentValidator" runat="server" ControlToValidate="drpAgent"
                                    ErrorMessage="Invalid Agent!" OnServerValidate="ctrlAgentValidator_ServerValidate" ValidateEmptyText="True"></asp:CustomValidator><br />
                                <asp:DropDownList ID="drpAgent" runat="server" Width="605px">
                                    <asp:ListItem Value="2">Test2</asp:ListItem>
                                    <asp:ListItem Value="3">Test3</asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td colspan="3">
                                <asp:Label ID="lblAgent2" runat="server" Text="Agent-2"></asp:Label><asp:CustomValidator ID="ctrlAgent2Validator" runat="server" ControlToValidate="drpAgent2"
                                    ErrorMessage="Invalid Agent-2!" OnServerValidate="ctrlAgent2Validator_ServerValidate" ValidateEmptyText="True"></asp:CustomValidator><br />
                                <asp:DropDownList ID="drpAgent2" runat="server" Width="605px">
                                    <asp:ListItem Value="2">Test2</asp:ListItem>
                                    <asp:ListItem Value="3">Test3</asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td style="vertical-align: top; width: 219px">
                                <asp:CheckBox ID="chkRenewalDate" runat="server" Text="Renewal Date" Width="190px" /></td>
                            <td style="width: 228px">
                                <asp:Label ID="Label10" runat="server" Width="171px">Gregorian:</asp:Label><br />
                                <asp:Label ID="lblRenewalDate" runat="server" Width="172px"></asp:Label></td>
                            <td dir="ltr" style="vertical-align: top">
                                <asp:Label ID="Label11" runat="server" Width="171px">Shamsi:</asp:Label><br />
                                <asp:Label ID="lblRenewalDateShamsi" runat="server" Width="171px"></asp:Label></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td style="width: 219px; vertical-align: top;">
                                <asp:Label ID="lblPowerAtTorney" runat="server" Text="Power Of Attorney:"></asp:Label><asp:RegularExpressionValidator ID="ctrlPoweralValidator" runat="server" ControlToValidate="txtPowerOfAttorney"
                                    ErrorMessage="Invalid No!" ValidationExpression="(\d){1,15}"></asp:RegularExpressionValidator><br />
                                <asp:TextBox ID="txtPowerOfAttorney" runat="server" Width="115px"></asp:TextBox></td>
                            <%--<td style="width: 228px"></td>--%>
                            <td>
                                <asp:Label ID="lblExtractNumber" runat="server" Text="Extract Number:" Width="124px"></asp:Label>
                                <asp:TextBox ID="txtExtractNumber" runat="server" Width="150px"></asp:TextBox>

                            </td>

                            <td dir="ltr" style="vertical-align: top;">
                                <asp:Label ID="lblLastUpdate" runat="server" Text="Last Checked Date:"></asp:Label>
                                <asp:Label ID="Label3" runat="server" Width="59px">(Gregorian)</asp:Label><br />
                                <asp:Label ID="lblLastCheckedDateValue" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td colspan="4">Classes:<br />
                                <asp:Panel ID="pnlClasses" runat="server" Width="100%">
                                </asp:Panel>
                                <div id="divClasses" runat="server">
                                </div>
                            </td>
                        </tr>
                        <tr>

                            <td colspan="4">
                                <asp:Label ID="lblComment" runat="server" Text="Comment:"></asp:Label><br />
                                <asp:TextBox ID="txtComment" runat="server" Width="100%" TextMode="MultiLine"></asp:TextBox></td>
                        </tr>
                    </table>
                </div>
            </fieldset>
        </div>
    </div>

    <div id="divGrid" runat="server" style="width: 97%; margin-left: 1%; margin-top: 5px">
        <asp:GridView ID="grdTradeMark" runat="server" AutoGenerateColumns="False" Caption="TradeMark Applications:"
            CaptionAlign="Left" DataKeyNames="ID" HorizontalAlign="Center" Width="100%" OnSelectedIndexChanged="grdTradeMark_SelectedIndexChanged" AllowPaging="True" AllowSorting="True" OnSorting="grdTradeMark_Sorting" OnPageIndexChanging="grdTradeMark_PageIndexChanging" BorderColor="#E0E0E0" BorderStyle="Ridge" BorderWidth="2px" BackColor="White" CellPadding="5">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="True" Visible="False" />
                <asp:BoundField DataField="AgentId" HeaderText="AgentId" Visible="false" />
                <asp:BoundField DataField="Year" HeaderText="Year" SortExpression="Year" />
                <asp:TemplateField HeaderText="Status">
                    <ItemTemplate>
                        <asp:Label ID="lblGridStatus" runat="server" Text='<%#StatusName(DataBinder.Eval(Container.DataItem,"StatusId"))%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Letters">
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" Target="_self" runat="server" ImageUrl='<%#HasLetter(DataBinder.Eval(Container.DataItem,"FillingNo"))%>' NavigateUrl='<%# "Letters.aspx?FillingNo="+ DataBinder.Eval(Container.DataItem,"FillingNo")+"&LetterType=3"+"&AgentId="+DataBinder.Eval(Container.DataItem,"AgentId")%>'></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="FillingNo" HeaderText="FillingNo" />
                <asp:BoundField DataField="RegNo" HeaderText="RegNo" />
                <asp:BoundField DataField="AppNo" HeaderText="AppNo" />
                <asp:BoundField DataField="Trademark" HeaderText="Trademark" />
                <asp:CommandField ShowSelectButton="true" />
            </Columns>
            <SelectedRowStyle BackColor="#C0C0FF" ForeColor="#404040" HorizontalAlign="Center"
                VerticalAlign="Middle" />
            <HeaderStyle BackColor="#404040" Font-Bold="True" ForeColor="White" />
            <PagerStyle BorderColor="#404040" VerticalAlign="Bottom" BackColor="#404040" Font-Size="Larger" />
            <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#E0E0E0" BorderColor="Black" />
        </asp:GridView>
    </div>

    <div id="divSearchInfo" style="position: absolute; top: 155px; left: 50px; visibility: hidden; background-color: #b0c4de;">
        <table id="table13" cellspacing="0" cellpadding="0" width="45%">
            <tr>
                <td style="height: 23px">
                    <div onmousedown="dragStart(event, 'divSearchInfo')" id="DragAreaDiv" style="background-color: #404040">
                        <a id="CloseLink" href="javascript:SetHidden(divSearchInfo);">
                            <img alt="Close" src="images/Close.jpg" width="21" style="border-top-style: none; border-right-style: none; border-left-style: none; border-bottom-style: none" id="IMG1" onclick="return IMG1_onclick()" />
                        </a>
                    </div>
                </td>
            </tr>
            <tr>
                <td class="TextArea" style="width: 423px">
                    <table border="0" cellpadding="0" cellspacing="0" id="table1" style="border-top-style: groove; border-right-style: groove; border-left-style: groove; border-bottom-style: groove">
                        <tr>
                            <td style="text-align: left; height: 46px;">
                                <b>Application Number:<asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                                    runat="server" ControlToValidate="txtSrchAppNo" ErrorMessage="Invalid!" Font-Bold="False"
                                    ValidationExpression="\d+" ValidationGroup="Search"></asp:RegularExpressionValidator></b><br />
                                <asp:TextBox ID="txtSrchAppNo" runat="server" Width="180px"></asp:TextBox></td>
                            <td style="height: 46px">
                                <strong>Registration Number:</strong><asp:RegularExpressionValidator ID="RegularExpressionValidator2"
                                    runat="server" ControlToValidate="txtSrchRegNo" ErrorMessage="Invalid!" Font-Bold="False"
                                    ValidationExpression="\d+" ValidationGroup="Search"></asp:RegularExpressionValidator><br />
                                <asp:TextBox ID="txtSrchRegNo" runat="server" Width="180px"></asp:TextBox>
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
                                <strong>Applicant:<br />
                                </strong>
                                <asp:DropDownList ID="drpSrchApplicant" runat="server" Width="450px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left">
                                <strong>Filling No:</strong>
                                <asp:RegularExpressionValidator ID="ctrlsrchFillingNoValidator" runat="server" ControlToValidate="txtsrchFillingNo"
                                    ErrorMessage="Invalid Number!" ValidationExpression="(\d){1,15}" ValidationGroup="Search"></asp:RegularExpressionValidator><br />
                                <asp:TextBox ID="txtsrchFillingNo" runat="server" Width="180px"></asp:TextBox>
                            </td>
                            <td style="text-align: left">
                                <strong>Status:<br />
                                </strong>
                                <asp:DropDownList ID="drpSrchStatus" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: left">
                                <strong>TradeMark:<br />
                                </strong>
                                <asp:TextBox ID="txtsrchTrademark" runat="server" Width="444px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: left">
                                <strong>Opposition Aganist:(App No)<br />
                                </strong>
                                <asp:TextBox ID="txtSrchOppositionAganist" runat="server" Width="444px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: left">
                                <strong>Additional of goods and classes (AppNo)<br />
                                </strong>
                                <asp:TextBox ID="txtSrchAdditionalGoodsClassesNo" runat="server" Width="444px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: left">
                                <asp:Label ID="Label4" runat="server" Text="Application Date "></asp:Label><asp:CustomValidator
                                    ID="ctrlSrchAppDateValidator" runat="server" ErrorMessage="Invalid Date!" OnServerValidate="ctrlSrchAppDateValidator_ServerValidate" ValidationGroup="Search"></asp:CustomValidator><br />
                                From:<asp:TextBox ID="txtRenewalDateYearFrom" runat="server" MaxLength="4" Width="30px"></asp:TextBox><asp:Label
                                    ID="Label8" runat="server">/</asp:Label><asp:TextBox ID="txtRenewalDateMonthFrom" runat="server"
                                        MaxLength="2" Width="15px"></asp:TextBox><asp:Label ID="Label12" runat="server" Text="/"></asp:Label><asp:TextBox
                                            ID="txtRenewalDateDayFrom" runat="server" MaxLength="2" Width="15px"></asp:TextBox>
                                To:
                                    <asp:TextBox ID="txtRenewalDateYearTo" runat="server" MaxLength="4" Width="30px"></asp:TextBox><asp:Label
                                        ID="Label13" runat="server">/</asp:Label><asp:TextBox ID="txtRenewalDateMonthTo" runat="server"
                                            MaxLength="2" Width="15px"></asp:TextBox><asp:Label ID="Label14" runat="server" Text="/"></asp:Label><asp:TextBox
                                                ID="txtRenewalDateDayTo" runat="server" MaxLength="2" Width="15px"></asp:TextBox></td>
                        </tr>
                    </table>
                    <asp:Button Style="margin-top: 5px" ID="btnStartSearch" runat="server" Text="Search" OnClick="btnStartSearch_Click" CausesValidation="False" />
                </td>
            </tr>
        </table>
    </div>

</asp:Content>
