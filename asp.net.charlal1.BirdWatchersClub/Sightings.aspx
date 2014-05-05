<%@ Page Title="Sightings" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Sightings.aspx.cs" Inherits="Sightings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div class="table">        
          <asp:Panel ID="Pan1" BackColor="#F6F5EB" ScrollBars="Auto" runat="server" HorizontalAlign="Justify" CssClass="panel">    
            <h1><asp:Label ID="lSelectedGridView" runat="server" ForeColor="#366592"></asp:Label></h1><br />
            <%--<hr /> --%>       
            <asp:Table ID="tblSightingsBody" runat="server" CellPadding="10" 
                CellSpacing="10" BorderStyle="None" BorderColor="White"></asp:Table>      
            <asp:GridView ID="gvSightings" runat="server" CellPadding="4" 
                ForeColor="#333333" Width="100%" GridLines="None">
                <AlternatingRowStyle BackColor="#F6F5EB" ForeColor="#284775" />
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                    HorizontalAlign="Center" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle HorizontalAlign="Justify" BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
        </asp:Panel>              
    </div>
    <div class="footer"><asp:Image ID="Image2" runat="server" Width="100px"  style="float: right;" ImageUrl="~/Images/logo.png" />
        <h3><asp:RadioButtonList ID="rblGridView" runat="server" style="display: block; position:absolute; left: 25px; right: 0px; bottom: 30px;"  
            RepeatDirection="Horizontal" AutoPostBack="True" ForeColor="#CC6600">
            <asp:ListItem Selected="True" Value="">Sightings</asp:ListItem>
            <asp:ListItem Value="">Birds</asp:ListItem>
            <asp:ListItem Value="">Members</asp:ListItem>
        </asp:RadioButtonList></h3>
        <h3><asp:Label ID="lRowCount" runat="server" style="display: block; float:right; margin-right:50px;" ForeColor="#CC6600"></asp:Label>
            <asp:Label ID="Label1" runat="server" style="display: block; float:right; margin-right:0px;" Text="Records Found:" ForeColor="#CC6600"></asp:Label></h3>
    </div>
</asp:Content>

