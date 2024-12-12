<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CheckBoxList._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
<head>
   
</head>
<body>
   <form id="Form1" runat="server">
      <h3> CheckBoxList Example </h3>
      Select items from the CheckBoxList.
      <br /><br />
      <asp:CheckBoxList id="checkboxlist1" 
           AutoPostBack="True"
           CellPadding="5"
           CellSpacing="5"
           RepeatColumns="2"
           RepeatDirection="Horizontal"
           TextAlign="Right"
           OnSelectedIndexChanged="Check_Clicked"
           runat="server">
         <asp:ListItem>Item 1</asp:ListItem>
         <asp:ListItem>Item 2</asp:ListItem>
         <asp:ListItem>Item 3</asp:ListItem>
         <asp:ListItem>Item 4</asp:ListItem>
         <asp:ListItem>Item 5</asp:ListItem>
         <asp:ListItem>Item 6</asp:ListItem>
      </asp:CheckBoxList>
      <br /><br />
      <asp:label id="Message" runat="server"/>
   </form>
</body>
</html>
