<%@ Language="C#" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>
<html>
<head>
<title>Default Site</title>
</head>
<body>
    
    <form id="form1" runat="server">
    <asp:ListBox ID="lbResult" runat="server" AutoPostBack="True" Height="188px" 
        Width="270px"></asp:ListBox>
    <p>
        <asp:Button ID="bFetchData" runat="server" onclick="bFetchData_Click" 
            Text="Fetch Data" />
    </p>
    </form>
    
</body>
</html>