<%@ Language="C#" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>
<html>
<head>
<title>Default Site</title>
</head>
<body>
    <form id="mForm" runat="server">
    <asp:Button ID="bParis" runat="server" Text="Paris" onclick="Button1_Click" />
    <asp:Button ID="bAmsterdam"
        runat="server" Text="Amsterdam" onclick="Button2_Click" />
    <p>
        <asp:Image ID="iPhoto" runat="server" Height="198px" Width="362px" 
            ImageUrl="~/Paris.jpg" />
    </p>
    </form>
</body>
</html>
