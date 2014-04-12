<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Question2.aspx.cs" Inherits="Question2" %>
<!DOCTYPE html />

<html>
<head>
    <title>IN712 2013 Travel Quiz</title>
    <link href="Styles/Site.css" rel="stylesheet"/>
</head>
<body>
<div id="container" class="page">
    <form id="Form1" runat="server">


    <div id="divQuestionContainer" runat="server"></div>
    <h2>I don't mind crowds at all</h2>
    <br />
    <br />
    <asp:RadioButtonList ID="RadioButtonList1" runat="server">
        <asp:ListItem>True</asp:ListItem>
        <asp:ListItem>False</asp:ListItem>
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
