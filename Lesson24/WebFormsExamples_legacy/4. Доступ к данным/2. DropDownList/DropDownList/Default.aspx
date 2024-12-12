<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DropDownList._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
   <form id="Form1" method="post" runat="server">
			<b>Название:</b>
			<asp:dropdownlist id="ddl_name" Runat="server" Width="220px"></asp:dropdownlist>&nbsp;
			<b>Издательство:</b>
			<asp:dropdownlist id="ddl_press" Runat="server" Width="220px"></asp:dropdownlist>&nbsp;
	</form>
</body>
</html>
