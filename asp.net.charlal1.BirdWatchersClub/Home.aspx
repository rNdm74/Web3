<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div class="table">
    <h1>Welcome to the Bird Watchers Club</h1>
    <hr />
    <p>At the Bird Watchers Club lets you keep a record of all sightings around New Zealand.
    <asp:BulletedList ID="BulletedList1" runat="server" BulletStyle="Circle">
        <asp:ListItem>View a list of club members</asp:ListItem>
        <asp:ListItem>List of all birds that have been sighted</asp:ListItem>
        <asp:ListItem>All recorded sightings</asp:ListItem>
        <asp:ListItem>Add new bird sightings</asp:ListItem>
    
    </asp:BulletedList>
    </p>
    </div>

</asp:Content>

