<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RangeValidator._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html> 
<head>
</head>
<body>
   <form id="Form1" runat="server">
      <h3> TextBox Example </h3>
      <table>
         <tr>
            <td colspan="5">
               Введите целочисленные значения в текстовые поля. <br />
               Нажмите кнопку Add для выполнения операции сложения. <br />
            </td>
         </tr>
         <tr>
            <td colspan="5">
               &nbsp;
            </td>
         </tr>
         <tr align="center">
            <td>
               <asp:TextBox ID="Value1"
                    Columns="2"
                    MaxLength="3"
                    Text="1"
                    runat="server"/>
            </td>
            <td>
               + 
            </td>
            <td>
               <asp:TextBox ID="Value2"
                    Columns="2"
                    MaxLength="3"
                    Text="1"
                    runat="server"/>
            </td>
            <td>
               =
            </td>
            <td>
               <asp:Label ID="AnswerMessage"
                    runat="server"/>
            </td>
         </tr>
         <tr>
            <td colspan="2">
               <asp:RequiredFieldValidator
                    ID="Value1RequiredValidator"
                    ControlToValidate="Value1"
                    ErrorMessage="Пожалуйста, введите значение.<br />"
                    runat="server" Display="Dynamic" EnableClientScript="True"/>
               <asp:RangeValidator
                    ID="Value1RangeValidator"
                    ControlToValidate="Value1"
                    Type="Integer"
                    MinimumValue="1"
                    MaximumValue="100"
                    ErrorMessage="Пожалуйста, введите целое число <br /> между 1 и 100.<br />"
                    runat="server" Display="Dynamic" EnableClientScript="False"/>
            </td>
            <td colspan="2">
               <asp:RequiredFieldValidator
                    ID="Value2RequiredValidator"
                    ControlToValidate="Value2"
                    ErrorMessage="Пожалуйста, введите значение.<br />"
                    runat="server" Display="Dynamic" EnableClientScript="True"/>
               <asp:RangeValidator
                    ID="Value2RangeValidator"
                    ControlToValidate="Value2"
                    Type="Integer"
                    MinimumValue="1"
                    MaximumValue="100"
                    ErrorMessage="Пожалуйста, введите целое число <br /> между 1 и 100.<br />"
                    runat="server" Display="Dynamic" EnableClientScript="False"/>
            </td>
            <td>
               &nbsp;
            </td>
         </tr>
         <tr align="center">
            <td colspan="4">
               <asp:Button ID="AddButton"
                    Text="Add"
                    OnClick="AddButton_Click"
                    runat="server"/>
            </td>
            <td>
               &nbsp;
            </td>
         </tr>
      </table>
   </form>
</body>
</html>
