<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Birds.aspx.cs" Inherits="Birds" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        
    <div class="table">
    
        <asp:Panel ID="Pan1" BackColor="White" ScrollBars="Auto" runat="server" HorizontalAlign="Justify" CssClass="panel">
            <h1>Birds&nbsp;<asp:Label ID="lRowCount" runat="server" Text=""></asp:Label></h1>
            <hr />
            <%--<asp:Table ID="tblBirds" runat="server" CellPadding="10" CellSpacing="0"></asp:Table>--%>
            <asp:GridView ID="gvBirds" runat="server" AutoGenerateColumns="true" 
                Width="100%" CellPadding="4" ForeColor="#333333" GridLines="Both">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                    HorizontalAlign="Center" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
            <asp:SqlDataSource ID="sqlBirds" runat="server" 
                ConnectionString="<%$ ConnectionStrings:IN712_201401_CHARLAL1Connection %>" 
                SelectCommand="SELECT [maoriName], [englishName], [scientificName] FROM [tblBird]">
            </asp:SqlDataSource>
        </asp:Panel>
    </div>
</asp:Content>

