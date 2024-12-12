<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <%--ScriptManager управляет регистрацией клиентских скриптов, поддерживающих технологию AJAX--%>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <%--UpdatePanel позволяет обновлять отдельные участки страницы. UpdatePanel использует элемент ScriptManager для контроля за частичными обновлениями страниц--%>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Button ID="Button1" runat="server" Text="Button" onclick="Button1_Click" /><asp:TextBox ID="TextBox1"
                runat="server"></asp:TextBox>
                <small>Panel 1 render time: <% =DateTime.Now.ToLongTimeString () %></small> 
            <br />
        </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <asp:Button ID="Button2" runat="server" Text="Button" onclick="Button2_Click" /><asp:TextBox ID="TextBox2"
                runat="server"></asp:TextBox>
                 <small>Panel 2 render time: <% =DateTime.Now.ToLongTimeString () %></small> 
            <br />
        </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        <asp:TextBox ID="TextBox3" runat="server" Width="182px"></asp:TextBox>
        <asp:Button
            ID="Button3" runat="server" Text="Button" onclick="Button3_Click" />
    </div>
    </form>
</body>
</html>
