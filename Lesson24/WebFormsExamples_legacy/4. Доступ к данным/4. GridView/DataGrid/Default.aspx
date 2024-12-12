<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DataGrid._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>

    <form id="Form1" method="post" runat="server">
    <div style="width:500px;height:300px; overflow:auto">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AlternatingRowStyle-BackColor="#3366FF" AlternatingRowStyle-ForeColor="#CC9900">
				<HeaderStyle BackColor="#000066" ForeColor="#ffffcc" Font-Bold="True" HorizontalAlign="Center">
				</HeaderStyle>
				<Columns>					
					<asp:BoundField DataField="book_name" HeaderText="Название" ItemStyle-Width="1000px"></asp:BoundField>
					<asp:BoundField DataField="book_author" HeaderText="Автор"  ItemStyle-Width="300px"></asp:BoundField>
					<asp:BoundField DataField="book_izd" HeaderText="Издательство"  ItemStyle-Width="300px"></asp:BoundField>
				</Columns>
	</asp:GridView>
    </div>
		</form>
</body>
</html>
