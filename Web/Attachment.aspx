<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Attachment.aspx.cs" Inherits="Laghaee.WebSite.Attachment"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml"  >
<head runat="server">
<meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <link href="Styles/StylesheetAttach.css" rel="stylesheet" type="text/css" />

<%--<link rel="stylesheet" media="screen,projection" type="text/css" href="../../styles/reset.css" />
<link rel="stylesheet" media="screen,projection" type="text/css" href="Styles/main.css" />
<link rel="stylesheet" media="screen,projection" type="text/css" href="Styles/2col.css" title="2col" />
<link rel="alternate stylesheet" media="screen,projection" type="text/css" href="Styles/1col.css" title="1col" />--%>
<script type="text/javascript" src="Javascripts/javascript.js"></script>
   <title>Attachment</title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="content">
     <h3>
          <img class="icon" src="Images/UI/attachment3232.png" alt=""/>Attachment Files</h3>
        <hr />
        <div id="divUpload" runat="server" >
    <table width="100%">
       <tr><td style="width: 100%"><asp:FileUpload ID="FileUpload1" runat="server" CssClass="input-submit" Width="100%" /></td></tr>
       <tr><td style="width: 100%"><asp:FileUpload ID="FileUpload2" runat="server" CssClass="input-submit" Width="100%"/></td></tr>
       <tr><td style="width: 100%"><asp:FileUpload ID="FileUpload3" runat="server" CssClass="input-submit" Width="100%"/></td></tr>
       <tr><td style="width: 100%"><asp:FileUpload ID="FileUpload4" runat="server" CssClass="input-submit" Width="100%"/></td></tr>
       <tr><td style="width: 100%"><asp:FileUpload ID="FileUpload5" runat="server" CssClass="input-submit" Width="100%"/></td></tr>
       <tr><td style="width: 100%"><asp:Button ID="BtnOk" runat="server" Text="Attach" CssClass="input-submit-2" OnClick="BtnOk_Click" Width="83px"  /></td></tr>
       </table>
       </div>
       <div id="divGrdAttachment" runat="server"  >
       <asp:GridView ID="gvAttachments" DataKeyNames="Id" runat="server" AutoGenerateColumns="False" AllowPaging="True"
       AllowSorting="True" OnRowCommand="gvAttachments_RowCommand" OnPageIndexChanging="gvAttachments_PageIndexChanging" 
       OnSelectedIndexChanged="gvAttachments_SelectedIndexChanged" BorderColor="#E0E0E0" BorderStyle="Ridge" 
        BorderWidth="2px" BackColor="#404040" CellPadding="5" Width="100%" CaptionAlign="Left"
       HorizontalAlign="Center">
                   <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#E0E0E0" BorderColor="Black"  />

            <Columns>
            <asp:BoundField DataField="Id" Visible="false" />
                <asp:CommandField ButtonType="Image" HeaderText="Select" SelectImageUrl="~/Images/UI/attachment2.png"
                     SelectText="" ShowSelectButton="True" HeaderStyle-Font-Names="Verdana,sans-serif" HeaderStyle-Font-Size="11px" ></asp:CommandField>
                <asp:ButtonField ButtonType="Image" CommandName="Del" HeaderText="Delete" ImageUrl="~/Images/UI/delete.png" 
                HeaderStyle-Font-Names="Verdana,sans-serif" HeaderStyle-Font-Size="11px">
                </asp:ButtonField> 
                <asp:TemplateField  HeaderText="Request Attach" HeaderStyle-Font-Names="Verdana,sans-serif" HeaderStyle-Font-Size="11px">
                <ItemTemplate >    
                <asp:HyperLink ID ="hpFile" runat ="Server" Text ='<%#DataBinder.Eval(Container.DataItem,"FileName")  %>' Target="_blank" NavigateUrl ='<%#GetFilePath(DataBinder.Eval(Container.DataItem,"Id"))%>' ></asp:HyperLink>
                </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <PagerStyle BorderColor="#404040" VerticalAlign="Bottom" BackColor="#404040" Font-Overline="False" Font-Size="Larger" Font-Strikeout="False" />
            <SelectedRowStyle BackColor="#C0C0FF" ForeColor="#404040" HorizontalAlign="Center"
                VerticalAlign="Middle" />
            <HeaderStyle BackColor="#404040" Font-Bold="True" ForeColor="White" />
        </asp:GridView>
        </div>
        <div id="divOperations" class="controlBox" runat="server">
            <asp:Button ID="btnOkDelAttach" runat="server" Text="OK" CssClass="input-submit-2" OnClick="btnOkDelAttach_Click" Width="61px"/>
            <asp:Button ID="btnCancelAttach" runat="server" Text="Cancel" CssClass="input-submit-2" OnClick="btnCancelAttach_Click" Width="61px"/>
            <asp:Button ID="btnClose" runat="server" CssClass="input-submit-2" OnClientClick="WindowsClose()" 
                Text="Exit" Width="61px"  />
        </div>
        <asp:Label ID="lblAttachMessage" runat="server" CssClass="Message" BackColor="#be1c1c" Width="99%" Font-Bold="true" Font-Names="Tahoma" Font-Size="13px"></asp:Label>

    </div>
    </form>
</body>
</html>
