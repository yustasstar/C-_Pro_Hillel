<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MyStyle._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
    <head>
      
    </head>

    <body>
        <form id="Form1" runat="server">
            <table cellPadding="6" border="0">
                <tr>
                    <td>
                        <asp:label id="Label1" 
                            Text="Border Properties Example" Runat="server">
                            <center><br>Label Styles</center>
                        </asp:label>
                    </td>
                    <td>
                        <asp:button id="Button1" runat="server" 
                            Text="Button Styles">
                        </asp:button>
                    </td>
                    <td>
                        <asp:listbox id="ListBox1" Runat="server">
                            <asp:ListItem Value="0" Text="List Item 0">
                            </asp:ListItem>
                            <asp:ListItem Value="1" Text="List Item 1">
                            </asp:ListItem>
                            <asp:ListItem Value="2" Text="List Item 2">
                            </asp:ListItem>
                        </asp:listbox>
                    </td>
                    <td>
                        <asp:textbox id="TextBox1" 
                            Text="TextBox Styles" Runat="server">
                        </asp:textbox>
                    </td>
                    <td>
                        <asp:table id="Table1" Runat="server">
                            <asp:TableRow>
                                <asp:TableCell Text="(0,0)"></asp:TableCell>
                                <asp:TableCell Text="(0,1)"></asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Text="(1,0)"></asp:TableCell>
                                <asp:TableCell Text="(1,1)"></asp:TableCell>
                            </asp:TableRow>
                        </asp:table>
                    </td>
                </tr>
            </table>
        </form>
    </body>
</html>
