<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ValidationSummary._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%--

Свойства:
DisplayMode – Устанавливает тип сообщения об ошибках, выводимым 
	данным элементом управления. Возможные значения: BulletList, 
	List и SingleParagraph.
EnabledClientScript – Разрешает или запрещает клиентскую проверку 
	корректности данных. По умолчанию используется true.
Enabled – Разрешает или запрещает клиентскую и серверную проверки 
	корректности данных. По умолчанию используется true.
HeaderText – Устанавливает текст, который будет выводиться в 
	заголовке отчета.
ShowMessageBox – Если значение этого свойства равно true, сообщения 
	об ошибках выводятся в всплывающем окне.
ShowSummary – Разрешает или запрещает выводить отчет об ошибках.

--%>

<html>
 <head>
</head>
 <body>
    <h3>ValidationSummary Sample</h3>
    <p>
    <form id="Form1" runat="server">
       <table cellpadding="10">
          <tr>
             <td>
                <table bgcolor="#eeeeee" cellpadding="10">
                   <tr>
                      <td colspan="3">
                         <b>Информация о кредитной карточке</b> 
                      </td>
                   </tr>
                   <tr>
                      <td align="right">
                         Тип карточки: 
                      </td>
                      <td>
                         <asp:RadioButtonList id="RadioButtonList1" 
                              RepeatLayout="Flow"
                               runat="server">
                            <asp:ListItem>MasterCard</asp:ListItem>
                            <asp:ListItem>Visa</asp:ListItem>
                         </asp:RadioButtonList>
                      </td>
                      <td align="middle" rowspan="1">
                         <asp:RequiredFieldValidator 
                              id="RequiredFieldValidator1"
                              ControlToValidate="RadioButtonList1" 
                              ErrorMessage="Тип карточки. " 
                              InitialValue="" Width="100%" runat="server" Text="*">
                         </asp:RequiredFieldValidator>
                      </td>
                   </tr>
                   <tr>
                      <td align="right">
                         Номер карточки: 
                      </td>
                      <td>
                         <asp:TextBox id="TextBox1" runat="server" />
                      </td>
                      <td>
                         <asp:RequiredFieldValidator 
                              id="RequiredFieldValidator2"
                              ControlToValidate="TextBox1" 
                              ErrorMessage="Номер карточки. "
                              Width="100%" runat="server"
                             Text="*">
                         </asp:RequiredFieldValidator>
                      </td>
                   </tr>
                   <tr>
                      <td></td>
                      <td>
                         <asp:Button 
                              id="Button1" 
                              text="Validate" 
                              runat="server" />
                      </td>
                      <td></td>
                   </tr>
                </table>
             </td>
             <td valign="top">
                <table cellpadding="20">
                   <tr>
                      <td>
                         <asp:ValidationSummary 
                              id="valSum" 
                              DisplayMode="BulletList" 
                              runat="server"
                              HeaderText="Вы должны заполнить следующие поля:"
                              Font-Name="verdana" 
                              Font-Size="12"/>
                      </td>
                   </tr>
                </table>
             </td>
          </tr>
       </table>
    </form>
</body>
 </html>
