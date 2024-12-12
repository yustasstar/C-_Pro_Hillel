<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Books._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
	<head>
		<title>WebForm2</title>
	</head>
	<body>
		<form id="Form1" method="post" runat="server">
		    <b>Тематика:</b>
			<asp:dropdownlist id="ddl_themes" Runat="server" Width="200px"></asp:dropdownlist>&nbsp;
			<b>Издательство:</b>
			<asp:dropdownlist id="ddl_press" Runat="server" Width="100px"></asp:dropdownlist>&nbsp;
			<asp:Button id="Button2" runat="server"	Width="105px" Text="Отобразить" OnClick="ShowData"></asp:Button>
			<br /><br />	
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AlternatingRowStyle-BackColor="#eeeeff">
        <HeaderStyle BackColor="#000066" ForeColor="#ffffcc" Font-Bold="True" HorizontalAlign="Center">
				</HeaderStyle>
				<Columns>	
                    <asp:BoundField DataField="Code" HeaderText="Код" ItemStyle-Width="300px"></asp:BoundField>		
                    <asp:BoundField DataField="New" HeaderText="Новинка" ItemStyle-Width="300px"></asp:BoundField>				
					<asp:BoundField DataField="Name" HeaderText="Название" ItemStyle-Width="300px"></asp:BoundField>
                    <asp:BoundField DataField="Price" HeaderText="Цена"  ItemStyle-Width="300px"></asp:BoundField>
                    <asp:BoundField DataField="Izd" HeaderText="Издательство"  ItemStyle-Width="300px"></asp:BoundField>
					<asp:BoundField DataField="Pages" HeaderText="Количество страниц"  ItemStyle-Width="300px"></asp:BoundField>
                    <asp:BoundField DataField="Format" HeaderText="Формат"  ItemStyle-Width="300px"></asp:BoundField>
					<asp:BoundField DataField="Date" HeaderText="Год издания"  ItemStyle-Width="300px"></asp:BoundField>
                    <asp:BoundField DataField="Pressrun" HeaderText="Тираж"  ItemStyle-Width="300px"></asp:BoundField>
					<asp:BoundField DataField="Themes" HeaderText="Тематика"  ItemStyle-Width="300px"></asp:BoundField>							
					<asp:BoundField DataField="Category" HeaderText="Категория"  ItemStyle-Width="300px"></asp:BoundField>
				</Columns>
        </asp:GridView>	
		</form>
	</body>
</html>
