<%@ Language="C#" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>
<html>
 <head>
  <title> BIT Music Survey </title>
 </head>
 <body>
    <form ID="mForm" runat="server">
    <div>
    <h1>Take Our Music Survey!</h1>
    <br />
    <p>Name:</p>
    <asp:TextBox ID="tbName" runat="server"></asp:TextBox>
    <br />
    <p>Email:</p>
    <asp:TextBox ID="tbEmail" runat="server"></asp:TextBox>
    <br />
    <p>Which musical genres do you enjoy?</p>
    <p>
       &nbsp;<asp:ListBox ID="lMusicGenre" runat="server" 
            SelectionMode="Multiple">
            <asp:ListItem>Rock</asp:ListItem>
            <asp:ListItem>Jazz</asp:ListItem>
            <asp:ListItem>Folk</asp:ListItem>
            <asp:ListItem>World</asp:ListItem>
            <asp:ListItem>Country</asp:ListItem>
            <asp:ListItem>Techno</asp:ListItem>
            <asp:ListItem>Hip Hop</asp:ListItem>
            <asp:ListItem>Blues</asp:ListItem>
            <asp:ListItem>Classical</asp:ListItem>
        </asp:ListBox>
     </p> 
    <br />
    <p>Would you like to join the BIT Glee Club?</p>
    <asp:RadioButtonList ID="rbGleeClub" runat="server">
        <asp:ListItem Selected="True">Yes</asp:ListItem>
        <asp:ListItem>No</asp:ListItem>
    </asp:RadioButtonList>
    <br />
    <br />
    <input runat="server" onserverclick="bSubmit_Click" id="bSubmit" type="submit" value="Send Data"/>
    </div>
    <br />
    <div>
        <asp:ListBox ID="lbResult" runat="server"></asp:ListBox>
    </div>
    
    </form>
</body>
</html>

