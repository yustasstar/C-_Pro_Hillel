<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="StoringPassword.Registration" %>

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
                    <asp:Label ID="Label1" runat="server" Text="Имя: "></asp:Label>
</asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:TextBox ID="FirstName" runat="server"></asp:TextBox>
<asp:RequiredFieldValidator 
                        ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="FirstName"></asp:RequiredFieldValidator>
</asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">
                    <asp:Label ID="Label2" runat="server" Text="Фамилия: "></asp:Label>
</asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:TextBox ID="LastName" runat="server"></asp:TextBox>
<asp:RequiredFieldValidator 
                        ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="LastName"></asp:RequiredFieldValidator>
</asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">
                    <asp:Label ID="Label3" runat="server" Text="Логин: "></asp:Label>
</asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:TextBox ID="Login" runat="server"></asp:TextBox>
<asp:RequiredFieldValidator 
                        ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="Login"></asp:RequiredFieldValidator>
</asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">
                    <asp:Label ID="Label4" runat="server" Text="Пароль: "></asp:Label>
</asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:TextBox ID="Password1" runat="server" TextMode="Password"></asp:TextBox>
<asp:CompareValidator ID="CompareValidator1" 
                        runat="server" ErrorMessage="Пароли не совпадают!" ControlToValidate="Password1" ControlToCompare="Password2" EnableClientScript="False"></asp:CompareValidator>
</asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">
                    <asp:Label ID="Label5" runat="server" Text="Подтверждение: "></asp:Label>
</asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:TextBox ID="Password2" runat="server" TextMode="Password"></asp:TextBox>
</asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server"> 
                <asp:Button ID="Button1" runat="server" Text="Отправить на сервер" onclick="Button1_Click"    />
                    </asp:TableCell>
                      <asp:TableCell ID="TableCell1" runat="server">
                    <asp:Label ID="info" runat="server" Text=""></asp:Label>
</asp:TableCell>
            </asp:TableRow>
        </asp:Table>
   
    </div>
    </form>
</body>
</html>
