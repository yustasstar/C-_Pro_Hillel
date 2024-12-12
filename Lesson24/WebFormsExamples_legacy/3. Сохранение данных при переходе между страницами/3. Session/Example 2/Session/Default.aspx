<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Session.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="Label3" runat="server" Text="Вводить логин и пароль уже не нужно!!!" visible="false"></asp:Label>
        <asp:Panel ID="Panel1" runat="server" Height="50px" Width="125px">
        <asp:Label ID="Label1" runat="server" Text="Логин"></asp:Label>
        <asp:TextBox ID="login" runat="server"></asp:TextBox><br /> 
        <asp:Label ID="Label2" runat="server" Text="Пароль"></asp:Label>
        <asp:TextBox ID="TextBox3" runat="server" TextMode="Password"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Войти" OnClick="Vhod" />
        </asp:Panel>
    </form>
</body>
</html>
