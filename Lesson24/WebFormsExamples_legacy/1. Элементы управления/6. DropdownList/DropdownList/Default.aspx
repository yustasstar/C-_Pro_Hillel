<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DropdownList._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
<head></head>
<body>
   <form id="Form1" runat="server">
      <h3> DropDownList Example </h3>
      Select a text colour in the label.
      <br /><br /> 
         <asp:Label id="ColorText" Text="Some Text Here" runat="server"/>
      <br /><br />
       <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
      <table cellpadding="5">
         <tr>
            <td>
               Text color:
            </td>
         </tr>
         <tr>
            <td>
               <asp:DropDownList id="ColorList"
                    AutoPostBack="False"
                    OnSelectedIndexChanged="Selection_Change"
                    runat="server">
                  <asp:ListItem Selected="True" Value="Black"> Black </asp:ListItem>
                  <asp:ListItem Value="Silver"> Silver </asp:ListItem>
                  <asp:ListItem Value="DarkGray"> Dark Gray </asp:ListItem>
                  <asp:ListItem Value="Khaki"> Khaki </asp:ListItem>
                  <asp:ListItem Value="DarkKhaki"> Dark Khaki </asp:ListItem>
               </asp:DropDownList>
            </td>
         </tr>
          </table>  
   </form>
</body>
</html>
