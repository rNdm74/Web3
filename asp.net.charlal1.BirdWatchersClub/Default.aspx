<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="table">
    <h1><asp:Label ID="Label1" runat="server" Text="Welcome to the Bird Watchers Club" ForeColor="#CC6600"></asp:Label></h1>
    <%--<hr />--%>
        <div style="padding: 50px; z-index: 9;display:block;
    position:absolute;">
            <p>At the Bird Watchers Club lets you keep a record of all sightings around New Zealand.
            <asp:BulletedList ID="BulletedList1" runat="server" BulletStyle="Circle">
                <asp:ListItem>View a list of club members</asp:ListItem>
                <asp:ListItem>List of all birds that have been sighted</asp:ListItem>
                <asp:ListItem>All recorded sightings</asp:ListItem>
                <asp:ListItem>Add new bird sightings</asp:ListItem>
    
            </asp:BulletedList>
            </p>
        </div>  
        <div class="logo">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/flock.png" />
    </div>  
    </div>
    <div class="footer"><asp:Image ID="Image2" runat="server" Width="100px"  style="float: right;" ImageUrl="~/Images/logo.png" />
        <h3><asp:Label ID="lbResult" runat="server" 
                style="display: block; position:absolute;  left:0; right: 0px; bottom: 30px;" 
                Text="Copyright © - All rights reserved" 
                ForeColor="#CC6600"></asp:Label>
            <asp:HyperLink ID="HyperLink1" runat="server" style="display: block; position:absolute; left: 0px; bottom: 30px; text-decoration: none;" 
                NavigateUrl="~/Database.aspx" ForeColor="#CC6600">Reset Database</asp:HyperLink></h3>
                
        
    </div>
</asp:Content>

