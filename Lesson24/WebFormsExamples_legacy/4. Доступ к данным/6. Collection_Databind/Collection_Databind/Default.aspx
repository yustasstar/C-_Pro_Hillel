﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Collection_Databind._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server" AlternatingRowStyle-BackColor="#eeeeff">
 		<HeaderStyle BackColor="#000066" ForeColor="#ffffcc" Font-Bold="True" HorizontalAlign="Center">
				</HeaderStyle>
			    </asp:GridView><br />
            <asp:DropDownList id="ContinentDropDownList" runat="server" />
    </div>
    </form>
</body>
</html>
