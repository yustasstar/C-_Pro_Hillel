<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CalendarControl._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Calendar ID="calVoyage" runat="server"  BackColor="lightgreen" CellPadding="3"
            CellSpacing="3" NextPrevFormat="FullMonth" SelectionMode="DayWeekMonth" 
            OnSelectionChanged="calSelectChange" />
    <asp:Label ID="TextToUser" runat="server" Font-Bold="True" Font-Underline="False" /><br />
    </div>
    </form>
</body>
</html>
