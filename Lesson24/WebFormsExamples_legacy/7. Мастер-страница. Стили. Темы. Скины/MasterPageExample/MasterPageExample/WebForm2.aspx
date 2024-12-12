<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" 
    CodeBehind="WebForm2.aspx.cs" Inherits="MasterPageExample.WebForm2"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Page2</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 align="center">Эти кнопки принадлежат WebForm2</h1>
    <div align="center"> 
    <asp:Button ID="Button1" runat="server"  Text="Go to WebForm1" 
        Width="200px"  Height="50px"  SkinID="skin1" OnClick="Button1_Click"/>
     <asp:Button ID="Button2" runat="server"  
        Text="Go to WebForm1" Width="200px" Height="50px"  SkinID="skin2" OnClick="Button2_Click"/>
     </div>
</asp:Content>
