<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Databind._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>

    <form id="Form1" method="post" runat="server">
			<asp:Label id="Label1" 
                style="Z-INDEX: 101; LEFT: 10px; POSITION: absolute; TOP: 10px; right: 1209px;" runat="server"
				Width="176px">№ редактируемой записи:</asp:Label>
                <asp:TextBox id="txtNum" style="Z-INDEX: 102; LEFT: 195px; POSITION: absolute; TOP: 5px" runat="server"
				Width="80px"></asp:TextBox>
                <asp:Button id="Button1" style="Z-INDEX: 103; LEFT: 280px; POSITION: absolute; TOP: 5px" runat="server"
				Width="63px" Text="Ok" OnClick="SelectData"></asp:Button>
		

            <asp:Label id="Label2" style="Z-INDEX: 105; LEFT: 10px; POSITION: absolute; TOP: 45px" runat="server"
				Width="120px">Название</asp:Label>
            <asp:TextBox id="txtName" style="Z-INDEX: 109; LEFT: 140px; POSITION: absolute; TOP: 40px" runat="server"
				Width="205px" Text='<%# books["Name"] %>'>
			</asp:TextBox>

            <asp:Label id="Label5" style="Z-INDEX: 108; LEFT: 10px; POSITION: absolute; TOP: 120px" runat="server"
				Width="120px">Год издания</asp:Label>
			<asp:TextBox id="txtPubYear" style="Z-INDEX: 112; LEFT: 140px; POSITION: absolute; TOP: 115px"
				runat="server" Width="105px" Text='<%# books["YearPress"] %>'>
			</asp:TextBox>

            <asp:Label id="Label4" style="Z-INDEX: 107; LEFT: 10px; POSITION: absolute; TOP: 95px" runat="server"
				Width="120px">Издательство</asp:Label>
			<asp:TextBox id="txtPub" style="Z-INDEX: 111; LEFT: 140px; POSITION: absolute; TOP: 90px" runat="server"
				Width="205px" Text='<%# books["Press"] %>'>
			</asp:TextBox>

            <asp:Label id="Label3" style="Z-INDEX: 106; LEFT: 10px; POSITION: absolute; TOP: 70px" runat="server"
				Width="120px">Автор</asp:Label>
			<asp:TextBox id="txtAuthor" style="Z-INDEX: 110; LEFT: 140px; POSITION: absolute; TOP: 65px"
				runat="server" Width="205px" Text='<%# books["Author"] %>'>
			</asp:TextBox>
			  
				<asp:Button id="Button2" style="Z-INDEX: 113; LEFT: 140px; POSITION: absolute; TOP: 145px" runat="server"
				Width="105px" Text="Обновить" OnClick="UpdateData"></asp:Button>

						
			<asp:Label id="lblError" style="Z-INDEX: 114; LEFT: 350px; POSITION: absolute; TOP: 10px" runat="server"
				Font-Bold="True" ForeColor="#C00000" Text=""></asp:Label></form>
</body>
</html>
