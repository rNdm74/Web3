<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Finish.aspx.cs" Inherits="Finish" %>

<html>
<head>
    <title>IN712 2013 Travel Quiz</title>
    <link href="Styles/Site.css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
    <div id="divContainer" class="page" runat="server">
        <h2>You should go to....</h2>

        <asp:Image ID="imgTravelDestination" runat="server" />

        <br />

        <asp:Label ID="lblDestination" runat="server"></asp:Label>

    </div>
    </form>
</body>
</html>