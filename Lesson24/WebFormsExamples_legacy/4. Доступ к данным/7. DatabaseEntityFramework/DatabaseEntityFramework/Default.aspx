<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DatabaseEntityFramework.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Table ID="Table1" runat="server">
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">
                    <asp:Button ID="Button1" runat="server" Text="Запрос на выборку без указания фильтра" OnClick="Button1_Click" />
                </asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:Button ID="Button2" runat="server" Text="Выбрать всех преподавателей с фамилией на &quot;В&quot;" OnClick="Button2_Click" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">
                    <asp:Button ID="Button3" runat="server" Text="Выбрать все кафедры всех факультетов" OnClick="Button3_Click"/>
                </asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:Button ID="Button4" runat="server" Text="Исполнение хранимой процедуры" OnClick="Button4_Click"/>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">
                    <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:GridView ID="GridView1" runat="server"></asp:GridView> 
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>      
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    </form>
</body>
</html>
