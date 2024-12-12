<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RegularExpressionValidator._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
 <head>
  </head>
 <body>
     <h3>RegularExpressionValidator Example</h3>
    <p>
     <form id="Form1" runat="server">
        <table bgcolor="#eeeeee" cellpadding="10">
          <tr valign="top">
             <td colspan="3">
                <asp:Label ID="lblOutput" 
                     Text="Введите почтовый индекс" 
                     runat="server"/>
             </td>
          </tr>
           <tr>
             <td colspan="3">
                <b>Личная информация</b>
             </td>
          </tr>
          <tr>
             <td align="right">
                Почтовый индекс:
             </td>
             <td>
                <asp:TextBox id="TextBox1" 
                     runat="server" MaxLength="5" />
             </td>
             <td>
                <asp:RegularExpressionValidator id="RegularExpressionValidator1" 
                     ControlToValidate="TextBox1"
                     ValidationExpression="\d{5}"
                     ErrorMessage="В почтовом индексе должно быть 5 цифр"
                     EnableClientScript="false" 
                     runat="server"/>
             </td>
          </tr>
          <tr>
             <td></td>
             <td>
                <asp:Button ID="Button1" text="Validate" 
                     OnClick="ValidateBtn_Click" 
                     runat="server" />
             </td>
             <td></td>
          </tr>
       </table>
     </form>
   </p>
  </body>
 </html>
