<%@ Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>
<html>
 <head>
  <title> Calender </title>
 </head>
 <body>
    
     <form id="form1" runat="server">
     <asp:Calendar ID="Calendar1" runat="server" BackColor="#FFFFCC" 
         BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" 
         Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="600px" 
         ondayrender="Calendar1_DayRender" 
         onselectionchanged="Calendar1_SelectionChanged" ShowGridLines="True" 
         Width="800px">
         <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
         <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
         <OtherMonthDayStyle ForeColor="#CC9966" />
         <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
         <SelectorStyle BackColor="#FFCC66" />
         <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" 
             ForeColor="#FFFFCC" />
         <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
     </asp:Calendar>
     </form>
    
 </body>
</html>

