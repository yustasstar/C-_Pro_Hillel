<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CompareValidator._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
<head>
</head>
<body>
   <form id="Form1" runat=server>
      <h3>CompareValidator Example</h3>
      <p>
      Введите значение в каждый textbox. Выберете оператор сравнения<br />
      и тип данных. Нажмите "Validate" для сравнения значений.
      </p>
      <table bgcolor="#eeeeee" cellpadding=10>
         <tr valign="top">
            <td>
               <h5>Строка 1:</h5>
               <asp:TextBox id="TextBox1" 
                    runat="server"/>
            </td>
            <td>
               <h5>Оператор сравнения:</h5>
               <asp:ListBox id="ListOperator" 
                    OnSelectedIndexChanged="Operator_Index_Changed" 
                    runat="server">
                  <asp:ListItem Selected Value="Equal">Равно</asp:ListItem>
                  <asp:ListItem Value="NotEqual">Не равно</asp:ListItem>
                  <asp:ListItem Value="GreaterThan">Больше</asp:ListItem>
                  <asp:ListItem Value="GreaterThanEqual">Больше или равно</asp:ListItem>
                  <asp:ListItem Value="LessThan">Меньше</asp:ListItem>
                  <asp:ListItem Value="LessThanEqual">Меньше или равно</asp:ListItem>
                  <asp:ListItem Value="DataTypeCheck">Проверка типа данных</asp:ListItem>
               </asp:ListBox>
            </td>
            <td>
               <h5>Строка 2:</h5>
               <asp:TextBox id="TextBox2" 
                    runat="server"/>
               <p>
               <asp:Button id="Button1"
                    Text="Validate"  
                    OnClick="Button_Click" 
                    runat="server"/>
               </p>
            </td>
         </tr>
         <tr>
            <td colspan="3" align="center">
               <h5>Тип данных:</h5>
               <asp:ListBox id="ListType" 
                    OnSelectedIndexChanged="Type_Index_Changed" 
                    runat="server">
                  <asp:ListItem Selected Value="String" >String</asp:ListItem>
                  <asp:ListItem Value="Integer" >Integer</asp:ListItem>
                  <asp:ListItem Value="Double" >Double</asp:ListItem>
               </asp:ListBox>
            </td>
         </tr>
      </table>
       <asp:CompareValidator id="Compare1" 
           ControlToValidate="TextBox1" 
           ControlToCompare="TextBox2"
           EnableClientScript="False" 
           Type="String" 
           runat="server" />
       <br />
       <asp:Label id="lblOutput" 
           Font-Name="verdana" 
           Font-Size="10pt" 
           runat="server"/>
    </form>
 </body>
</html>
