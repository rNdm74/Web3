<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Birds.aspx.cs" Inherits="Birds" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        
    <div class="table">
    
        <asp:Panel ID="Pan1" BackColor="White" ScrollBars="Auto" runat="server" HorizontalAlign="Justify" CssClass="panel">
            <h1>Birds&nbsp;<asp:Label ID="lRowCount" runat="server" Text=""></asp:Label></h1>
            <hr />
            <asp:Table ID="tblBirds" runat="server" CellPadding="10" CellSpacing="10"></asp:Table>
        </asp:Panel>
    </div>
</asp:Content>

