<%@ Language="C#" AutoEventWireup="true" CodeFile="BirdWatchers.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>
<html>
<head>
<title>Bird Watchers Club</title>
</head>
<body>
    
    <form id="form1" runat="server">
    <asp:ListBox ID="ListBox1" runat="server" AutoPostBack="True" 
        DataSourceID="SqlDataSource1" DataTextField="first" DataValueField="memberID" 
        Height="142px" Width="317px"></asp:ListBox>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:IN712_201401_CHARLAL1ConnectionString %>" 
        SelectCommand="SELECT * FROM [tblMember]"></asp:SqlDataSource>
    <asp:ListBox ID="ListBox2" runat="server" AutoPostBack="True" 
        DataSourceID="IN712_201401_CHARLAL1" DataTextField="maoriName" 
        DataValueField="birdID" Height="178px" Width="322px"></asp:ListBox>
    <asp:SqlDataSource ID="IN712_201401_CHARLAL1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:IN712_201401_CHARLAL1Connection %>" 
        SelectCommand="SELECT * FROM [tblBird]"></asp:SqlDataSource>
    </form>
    
</body>
</html>