<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="StoringPassword.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Table ID="Table1" runat="server">
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">
                    <asp:Label ID="Label1" runat="server" Text="Логин: "></asp:Label></asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:TextBox ID="login" runat="server"></asp:TextBox><asp:RequiredFieldValidator
                        ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="login"></asp:RequiredFieldValidator></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">
                    <asp:Label ID="Label2" runat="server" Text="Пароль: "></asp:Label></asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:TextBox ID="password" runat="server" TextMode="Password"></asp:TextBox><asp:RequiredFieldValidator 
                        ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="password"></asp:RequiredFieldValidator></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server"> <asp:Button ID="Button1" runat="server" Text="Войти" onclick="Button1_Click" /></asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Registration.aspx">Регистрация</asp:HyperLink></asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:Label ID="info" runat="server" Text=""></asp:Label>
    </div>
    </form>
</body>
</html>
