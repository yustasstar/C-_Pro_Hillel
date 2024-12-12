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
    <asp:UpdatePanel runat="Server" ID="UpdatePanell" UpdateMode="Conditional" ChildrenAsTriggers="false"> 
    <%--ChildrenAsTriggers определяет, изменяют ли содержимое панели обратные передачи из непосредственных дочерних элементов управления UpdatePanel--%>
        <ContentTemplate> 
        <asp:Button runat="Server" ID="Buttonl" Text="Click Me" OnClick="Button1_Click" />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>     
        <small>Panel 1 render time: <% =DateTime.Now.ToLongTimeString () %></small> 
        </ContentTemplate> 
        </asp:UpdatePanel> 
        <asp:UpdatePanel runat="Server" ID="UpdatePanel2" UpdateMode="Always"> 
        <ContentTemplate> 
         <asp:Button runat="Server" ID="Button1" Text="Click Me" OnClick="Button2_Click" />
         <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox> 
        <small>Panel 2 render time: <% =DateTime.Now.ToLongTimeString() %></small> 
        </ContentTemplate> 
        </asp:UpdatePanel> 
        <small>Page render time: <% =DateTime.Now.ToLongTimeString() %></small> 

    </div>
    </form>
</body>
</html>
