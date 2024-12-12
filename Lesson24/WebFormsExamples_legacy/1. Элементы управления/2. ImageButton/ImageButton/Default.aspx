<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ImageButton._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
<head>
</head>
<body>
   <form id="Form1" runat="server" method ="get">
      <h3>ImageButton Sample</h3>
      Click anywhere on the image.<br /><br />
      <asp:ImageButton id="imagebutton1" 
           AlternateText="ImageButton 1"
           ImageAlign="left"
           ImageUrl="cat.jpg"
           runat="server" onclick="imagebutton1_Click" />
      <br /><br />
      <asp:label id="Label1" runat="server" EnableViewState="False" />
   </form>
</body>
</html>
