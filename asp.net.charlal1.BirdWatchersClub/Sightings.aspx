<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Sightings.aspx.cs" Inherits="Sightings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div class="table">        
        <asp:Panel ID="Pan1" BackColor="White" ScrollBars="Auto" runat="server" HorizontalAlign="Justify" CssClass="panel">    
            <h1>Sightings&nbsp; <asp:Label ID="lRowCount" runat="server" Text=""></asp:Label></h1>
            <hr />        
            <asp:Table ID="tblSightingsBody" runat="server" CellPadding="10" CellSpacing="10" GridLines="None" BorderStyle="None" BorderColor="White"></asp:Table>      
        </asp:Panel>        
    </div>
</asp:Content>

