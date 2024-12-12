<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel runat="Server" ID="UpdatePanell" UpdateMode="Conditional" 
            ChildrenAsTriggers="False"> 
            <Triggers> 
                <%--AsyncPostBackTrigger — этот класс заставляет UpdatePanel обновиться, когда возникнет определенное событие в определенном элементе управления--%>
                <asp:AsyncPostBackTrigger ControlID="Button3" EventName="Click" /> 
            </Triggers> 
            <ContentTemplate> 
                <asp:Button runat="Server" ID="Button1" Text="Click Me" /> 
                <small>Panel 1 render time: <% =DateTime.Now.ToLongTimeString() %></small> 
            </ContentTemplate> 
        </asp:UpdatePanel> 
        <asp:UpdatePanel runat="Server" ID="UpdatePanel2"> 
            <ContentTemplate> 
                <asp:Button runat="Server" ID="Button2" Text="Click Me" /> 
                <small>Panel 2 render time: <% =DateTime.Now.ToLongTimeString() %></small> 
            </ContentTemplate> 
        </asp:UpdatePanel> 
    <small>Page render time: <% =DateTime.Now.ToLongTimeString() %></small> 
    </div>
    <asp:Button ID="Button3" runat="server" Text="Button" />
    </form>
</body>
</html>
