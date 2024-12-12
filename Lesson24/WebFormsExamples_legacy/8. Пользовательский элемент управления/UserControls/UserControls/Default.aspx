<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UserControls._Default" %>
<%@ Register TagPrefix="pcs" TagName="UserC1" Src="PCSUserC1.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
  <form id="form1" runat="server">
  <div>
    <pcs:UserC1 runat="server" ID="myUserControl" />
    <asp:RadioButtonList runat="server" ID="suitList" AutoPostBack="True" OnSelectedIndexChanged="suitList_SelectedIndexChanged">
      <asp:ListItem Value="club" Selected="True">Club</asp:ListItem>
      <asp:ListItem Value="diamond">Diamond</asp:ListItem>
      <asp:ListItem Value="heart">Heart</asp:ListItem>
      <asp:ListItem Value="spade">Spade</asp:ListItem>
    </asp:RadioButtonList>
    <asp:ImageButton runat="server" ID="clubButton" ImageUrl="~/Images/CLUB.BMP" OnClick="clubButton_Click" />
    <asp:ImageButton runat="server" ID="diamondButton" ImageUrl="~/Images/DIAMOND.BMP" OnClick="diamondButton_Click" />
    <asp:ImageButton runat="server" ID="heartButton" ImageUrl="~/Images/HEART.BMP" OnClick="heartButton_Click" />
    <asp:ImageButton runat="server" ID="spadeButton" ImageUrl="~/Images/SPADE.BMP" OnClick="spadeButton_Click" />
  </div>
  </form>
</body>
</html>
