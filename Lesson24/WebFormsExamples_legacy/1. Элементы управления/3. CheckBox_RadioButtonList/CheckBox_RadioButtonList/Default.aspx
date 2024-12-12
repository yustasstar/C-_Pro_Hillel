<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CheckBox_RadioButtonList._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
 <head>
</head>
 <body>
     <h3>RadioButtonList Example</h3>
     <form id="Form1" runat="server">
         <asp:RadioButtonList id="RadioButtonList1" runat="server" AutoPostBack="true" 
             onselectedindexchanged="RadioButtonList1_SelectedIndexChanged">
            <asp:ListItem>Item 1</asp:ListItem>
            <asp:ListItem>Item 2</asp:ListItem>
            <asp:ListItem>Item 3</asp:ListItem>
            <asp:ListItem>Item 4</asp:ListItem>
            <asp:ListItem>Item 5</asp:ListItem>
            <asp:ListItem>Item 6</asp:ListItem>
         </asp:RadioButtonList>
         <br />
         <asp:CheckBox id="chkDirection" OnCheckedChanged="chkDirection_CheckedChanged" Text="Отобразить горизонтально" AutoPostBack="true" runat="server" />
          <p>
            <asp:Label id="Label1" font-name="Verdana" font-size="8pt" runat="server"/>
         </p>
     </form>
</body>
 </html>
