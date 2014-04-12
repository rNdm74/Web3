<%@ Page Language="C#" AutoEventWireup="true"
    CodeFile="TravelQuizHome.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html />

<html>
<head>
    <title>IN712 2013 Travel Quiz</title>
    <link href="Styles/Site.css" rel="stylesheet"/>
</head>
<body>
<div id="container" class="page">


    <h2>Welcome to the IN712 Travel Quiz. Answer these questions to find your perfect 
    travel destination....</h2>
    <form runat="server">
    <br />
    <br />
    <br />
    <asp:Button ID="btnStartQuiz" runat="server" Text="Start Quiz" 
        onclick="btnStartQuiz_Click"/>
    <div id="divQuestionContainer" runat="server"></div>
    </form>

</div>
</body>
</html>
