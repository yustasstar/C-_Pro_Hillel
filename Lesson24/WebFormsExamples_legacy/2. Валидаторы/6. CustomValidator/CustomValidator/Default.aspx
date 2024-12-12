<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CustomValidator._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
<head>
</head>
<body>
   <form id="Form1" runat="server">
      <h3>CustomValidator ServerValidate Example</h3>
      <asp:Label id="Message"  
           Text="Введите четное число:" 
           Font-Name="Verdana" 
           Font-Size="10pt" 
           runat="server"/>
      <p>
      <asp:TextBox id="Text1" 
           runat="server" />
        
      <asp:CustomValidator id="CustomValidator1"
           ControlToValidate="Text1"
           ErrorMessage="Число не является четным!"
           ForeColor="green"
           Font-Name="verdana" 
           Font-Size="10pt"
           OnServerValidate="ServerValidation"
           EnableClientScript="False"
           runat="server"/>
      </p>
      <p>
      <asp:Button id="Button1"
           Text="Validate" 
           OnClick="ValidateBtn_OnClick" 
           runat="server"/>
      </p>
   </form>
</body>
</html>
