<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Request._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <%-- Блок визуализации кода. Внутритекстовый код   --%>
    <div style="text-align:center"><% GetDateTime(); %></div>
    <form id="Form1" runat="server">
             <span>Имя компьютера: </span>
            <asp:Label id="machine" runat="server">
            </asp:Label>
            <br />
             <span>Версия ОС: </span>
            <asp:Label id="os" runat="server">
            </asp:Label>
            <br />
             <span>Объем памяти: </span>
            <asp:Label id="memory" runat="server">
            </asp:Label>
            <br />
             <span>Имя компьютера: </span>
            <asp:Label id="machinename" runat="server">
            </asp:Label>
            <br />
             <span>Локальный IP-адрес компьютера </span>
            <asp:Label id="localip" runat="server">
            </asp:Label>
            <br />
            <span>IP-адрес компьютера удаленного клиента: </span>
            <asp:Label id="ip_address" runat="server">
            </asp:Label>
            <br />
            <span>Имя DNS компьютера удаленного клиента: </span>
            <asp:Label id="dns" runat="server">
            </asp:Label>
            <br />
            <span>Виртуальный путь к приложению, выполняющемуся на сервере: </span>
            <asp:Label id="virtualpath" runat="server">
            </asp:Label>
            <br />
            <span>Информация о браузере клиента: </span>
        <%-- Блок визуализации кода. Внутритекстовое выражение   --%>
            <%= Request.ServerVariables["HTTP_USER_AGENT"] %>
            <br />
            <span>Обращение к ASP-странице: </span>
            <%= this.ToString() %>
        </form>

</body>
</html>
