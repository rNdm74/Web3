<%@ Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>
<html>
 <head>
  <title> Web Controls </title>
     <style type="text/css">
         #form1
         {
             height: 89px;
         }
     </style>
 </head>
 <body style="width: 531px">
     <form id="form1" runat="server">
     <asp:Label ID="lSelectFont" runat="server" Text="Select Your Font:" 
         Font-Size="Large"></asp:Label>
     <p>
     <asp:DropDownList ID="ddlFont" runat="server" Width="428px" Font-Size="Large" 
             style="margin-left: 65px">
     </asp:DropDownList>
     </p>
     <p>
         <asp:Label ID="lEnterText" runat="server" Font-Size="Large" 
             Text="Enter Your Text:"></asp:Label>
     </p>
     <p>
         <asp:TextBox ID="tbUserText" runat="server" Font-Size="Large" 
             style="margin-left: 64px" Width="426px"></asp:TextBox>
     </p>
     <asp:Button ID="bDisplay" runat="server" onclick="bDisplay_Click" 
         Text="Display" Width="128px" />
     <asp:Table ID="tblDisplay" runat="server">
     </asp:Table>
     </form>
 </body>
</html>