<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Question3.aspx.cs" Inherits="Question3" %>

<html>
<head>
    <title>IN712 2013 Travel Quiz</title>
    <link href="Styles/Site.css" rel="stylesheet"/>
</head>
<body>
<div id="container" class="page">
    <form id="Form1" runat="server">


    <div id="divQuestionContainer" runat="server"></div>
    <h2>What do you like to do most when on holiday?</h2>
    <br />
    <br />
    <asp:RadioButtonList ID="RadioButtonList1" runat="server">
        <asp:ListItem>Shop</asp:ListItem>
        <asp:ListItem>Visit historical sites</asp:ListItem>
        <asp:ListItem>Enjoy the solitude</asp:ListItem>
        <asp:ListItem>Hiking, fishing, hunting, kayaking</asp:ListItem>
        <asp:ListItem>Go to museums, plays and concerts</asp:ListItem>
    </asp:RadioButtonList>
    <br />
    <br />
    <asp:Button ID="btnNext" runat="server" Text="Next Question" 
        onclick="btnNext_Click" />
    <br />
    </form>

</div>
</body>
</html>
