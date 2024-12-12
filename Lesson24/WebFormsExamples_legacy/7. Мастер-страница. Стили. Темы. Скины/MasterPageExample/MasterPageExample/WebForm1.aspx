<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" 
    CodeBehind="WebForm1.aspx.cs" Inherits="MasterPageExample.WebForm1"  Theme ="Red" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Page1</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 align="center">Эти кнопки принадлежат WebForm1</h1>
    <div align="center"> 
    <asp:Button ID="Button1" runat="server"  Text="Go to WebForm2" 
        Width="200px"  Height="50px"  CssClass="btn1" OnClick="Button1_Click"/>
     <asp:Button ID="Button2" runat="server"  
        Text="Go to WebForm2" Width="200px" Height="50px" CssClass="btn2" OnClick="Button2_Click"/>
     </div>
</asp:Content>
