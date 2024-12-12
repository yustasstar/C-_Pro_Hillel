<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BulletedList._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <asp:BulletedList ID="BulletedListLinks" runat="server" 
        BulletStyle ="Circle" DisplayMode="LinkButton" 
        OnClick="BulletedListLinks_Click">
        <asp:ListItem Value="Red">Красный</asp:ListItem>
        <asp:ListItem Value="Blue">Синий</asp:ListItem>
        <asp:ListItem Value="Green">Зеленый</asp:ListItem>
        </asp:BulletedList>
    </div>
    </form>
</body>
</html>
