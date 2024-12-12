<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RequiredFieldValidator._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
<head runat=server>
</head>
<body>
   <form id="Form1" runat="server">
      <h3>RequiredField Validator Example</h3>
      <table bgcolor="#eeeeee" cellpadding="10">
         <tr valign="top">
            <td colspan="3">
               <asp:Label ID="lblOutput" 
                    Text="Fill in the required field below"
                    runat="server"/>
               <br>
            </td>
         </tr>
 
         <tr>
            <td colspan="3">
               <b>Credit Card Information</b>
            </td>
         </tr>
     
         <tr>
            <td align="right">
               Card Number:
            </td>
            <td>
               <asp:TextBox id="TextBox1" 
                    runat="server"/>
            </td>
            <td>
               <asp:RequiredFieldValidator id="RequiredFieldValidator2"
                    ControlToValidate="TextBox1"
                    ErrorMessage="*" 
                    runat="server" EnableClientScript="False" /> 
            </td>
         </tr>
         <tr>
            <td></td>
            <td>
               <asp:Button id="Button1" 
                    Text="Validate" 
                    OnClick="ValidateBtn_Click" 
                    runat="server"/>
            </td>
            <td></td>
         </tr>
      </table>
   </form>
</body>
</html>
