<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Database.aspx.cs" Inherits="Database" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Populate Database Tables</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    </br>
        <asp:Button ID="Button2" runat="server" Text="Homepage" 
            onclick="Button2_Click" /><asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Reset Database" />
    <h1><asp:Label ID="Label1" runat="server" Text=""></asp:Label></h1>
    </div>
    </br>
    <div>
    <h1><asp:Label ID="Label2" runat="server" Text="Bird Table"></asp:Label></h1>
    <asp:Table ID="tblBird" runat="server" BorderStyle="Solid" CellPadding="5" 
            CellSpacing="5" GridLines="Both"></asp:Table>
    </div>
    <div>
    <h1><asp:Label ID="Label3" runat="server" Text="Member Table"></asp:Label></h1>
    <asp:Table ID="tblMember" runat="server" BorderStyle="Solid" CellPadding="5" 
            CellSpacing="5" GridLines="Both"></asp:Table>
    </div>
    <div>
    <h1><asp:Label ID="Label4" runat="server" Text="Bird Member Table"></asp:Label></h1>
    <asp:Table ID="tblBirdMember" runat="server" BorderStyle="Solid" CellPadding="5" 
            CellSpacing="5" GridLines="Both"></asp:Table>
    </div>
    <h1><asp:Label ID="Label5" runat="server" Text="Bird Sightings"></asp:Label></h1>
    <asp:Table ID="tblTestQuery" runat="server" CellPadding="5" CellSpacing="5" 
        GridLines="Both"></asp:Table>
    </form>
</body>
</html>
