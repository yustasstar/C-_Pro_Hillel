<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Button._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
<head>
</head>
<body>
   <form id="Form1" runat="server">
      <h3>Button Example</h3>
      Click on the submit button.<br /><br />
      <asp:Button id="Button1"
           Text="Submit"
           OnClick="SubmitBtn_Click" 
           runat="server"/>
      <p>
      <asp:label id="Message" runat="server" />
      <input id="Text1" type="text" runat="server"/>
      </p>
   </form>
</body>
</html>
