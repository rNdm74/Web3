<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Sightings.aspx.cs" Inherits="Sightings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Sightings</h1>
    <hr />
    <div class="table">
        <asp:Panel ID="Pan1" Height="500px" BackColor="White" ScrollBars="Auto" runat="server" HorizontalAlign="Justify" CssClass="panel">
            <asp:Table ID="tblSightings" runat="server" CellPadding="10" CellSpacing="10"></asp:Table>
        </asp:Panel>
    </div>
</asp:Content>

