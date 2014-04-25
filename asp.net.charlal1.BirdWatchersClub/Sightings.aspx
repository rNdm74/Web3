<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Sightings.aspx.cs" Inherits="Sightings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Sightings&nbsp; <asp:Label ID="lRowCount" runat="server" Text=""></asp:Label></h1>
    <hr />
    
    <%--<asp:Table ID="tblSightingsHeader" BackColor="White" runat="server" CellPadding="10" CellSpacing="10" CssClass="tableHeader" Height="50px"></asp:Table>--%>
    <div class="table">
        
        <asp:Panel ID="Pan1" Height="10em" BackColor="White" ScrollBars="Auto" runat="server" HorizontalAlign="Justify" CssClass="panel">            
        <asp:Table ID="tblSightingsBody" runat="server" CellPadding="10" CellSpacing="10" GridLines="None" BorderStyle="None" BorderColor="White"></asp:Table>
        
    <%--<asp:GridView ID="GridView1" runat="server" style="height:400px; overflow:auto" AutoGenerateColumns="False" 
        DataSourceID="sqlSightings" CellPadding="5" CellSpacing="5" ShowFooter="False" HeaderStyle-CssClass="HeaderFreez">
        <AlternatingRowStyle BackColor="WhiteSmoke" />
        <Columns>
            <asp:BoundField DataField="English" HeaderText="English" 
                SortExpression="English" />
            <asp:BoundField DataField="Maori" HeaderText="Maori" 
                SortExpression="Maori" />
            <asp:BoundField DataField="Firstname" HeaderText="Firstname" 
                SortExpression="Firstname" />
            <asp:BoundField DataField="Lastname" HeaderText="Lastname" 
                SortExpression="Lastname" />
        </Columns>
    </asp:GridView>
            <asp:SqlDataSource ID="sqlSightings" runat="server" 
                ConnectionString="<%$ ConnectionStrings:IN712_201401_CHARLAL1Connection %>" 
                SelectCommand="SELECT tblBird.englishName AS English, tblBird.maoriName AS Maori, tblMember.first AS Firstname, tblMember.last AS Lastname FROM tblBird INNER JOIN tblBirdMember ON tblBird.birdID = tblBirdMember.birdID INNER JOIN tblMember ON tblBirdMember.memberID = tblMember.memberID">
            </asp:SqlDataSource>--%>
    </asp:Panel>
        
    </div>
    <div class="footer">
    </div>
</asp:Content>

