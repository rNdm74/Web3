<%@ Language="C#" AutoEventWireup="true" CodeFile="BirdWatchers.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>
<html>
<head>
<title>Bird Watchers Club</title>
</head>
<body>
    
    <form id="form1" runat="server">
    <asp:ListBox ID="ListBox1" runat="server" AutoPostBack="True" 
        DataSourceID="tblBird" DataTextField="englishName" DataValueField="birdID">
    </asp:ListBox>
    <asp:SqlDataSource ID="tblBird" runat="server" 
        ConnectionString="<%$ ConnectionStrings:IN712_201401_CHARLAL1Connection %>" 
        SelectCommand="SELECT * FROM [tblBird]"></asp:SqlDataSource>
    <asp:ListBox ID="ListBox2" runat="server" AutoPostBack="True" 
        DataSourceID="tblMember" DataTextField="first" DataValueField="memberID">
    </asp:ListBox>
    <asp:SqlDataSource ID="tblMember" runat="server" 
        ConnectionString="<%$ ConnectionStrings:IN712_201401_CHARLAL1Connection %>" 
        SelectCommand="SELECT * FROM [tblMember]"></asp:SqlDataSource>
    <asp:ListBox ID="ListBox3" runat="server" AutoPostBack="True" 
        DataSourceID="tblBirdMember" DataTextField="memberID" DataValueField="memberID">
    </asp:ListBox>
    <asp:SqlDataSource ID="tblBirdMember" runat="server" 
        ConnectionString="<%$ ConnectionStrings:IN712_201401_CHARLAL1Connection %>" 
        SelectCommand="SELECT * FROM [tblBirdMember]"></asp:SqlDataSource>
    <asp:ListBox ID="ListBox4" runat="server" DataSourceID="birdSightings" 
        DataTextField="English" DataValueField="English"></asp:ListBox>
    <asp:SqlDataSource ID="birdSightings" runat="server" 
        ConnectionString="<%$ ConnectionStrings:IN712_201401_CHARLAL1Connection %>" 
        SelectCommand="SELECT tblBird.englishName AS English, tblBird.maoriName AS Maori, tblMember.first AS Firstname, tblMember.last AS Lastname FROM tblBird INNER JOIN tblBirdMember ON tblBird.birdID = tblBirdMember.birdID INNER JOIN tblMember ON tblBirdMember.memberID = tblMember.memberID">
    </asp:SqlDataSource>
    </form>
    
</body>
</html>