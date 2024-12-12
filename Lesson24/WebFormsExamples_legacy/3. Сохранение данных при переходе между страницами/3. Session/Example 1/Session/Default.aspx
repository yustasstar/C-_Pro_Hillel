<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Session.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
   <form id="form1" runat="server">
     <asp:Label ID="Label1" runat="server" Text="Label" Width ="70">Имя: </asp:Label>
    <asp:TextBox ID="FirstName" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Label" Width ="70">Фамилия: </asp:Label>
    <asp:TextBox ID="LastName" runat="server"></asp:TextBox>
    <br />

    <asp:Button ID="Button1" runat="server" Text="Подача запроса" Width="230" 
        onclick="Button1_Click" />
    <br />
    <asp:Label ID="info" runat="server" Text=""></asp:Label>
    <br />
    <asp:Label ID="oldinfo" runat="server" Text=""></asp:Label>
    </form>
</body>
</html>
