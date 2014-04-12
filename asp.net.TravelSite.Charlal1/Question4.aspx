<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Question4.aspx.cs" Inherits="Question4" %>

<html>
<head>
    <title>IN712 2013 Travel Quiz</title>
    <link href="Styles/Site.css" rel="stylesheet"/>
</head>
<body>
<div id="container" class="page">
    <form id="Form1" runat="server">


    <div id="divQuestionContainer" runat="server"></div>
    <h2>How do you like to travel?</h2>
    <br />
    <br />
    <asp:RadioButtonList ID="RadioButtonList1" runat="server">
        <asp:ListItem>With my friends</asp:ListItem>
        <asp:ListItem>With my partner</asp:ListItem>
        <asp:ListItem>With my family</asp:ListItem>
        <asp:ListItem>Solo</asp:ListItem>
    </asp:RadioButtonList>
    <br />
    <br />
    <asp:Button ID="btnNext" runat="server" Text="Where Should I Go?" 
        onclick="btnNext_Click" />
    <br />
    </form>

</div>
</body>
</html>