<%@ Page Title="AddSightings" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddSighting.aspx.cs" Inherits="AddSighting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div class="table">
        <asp:Panel ID="Pan1" BackColor="#F6F5EB" 
            ScrollBars="Auto" runat="server" HorizontalAlign="Justify" CssClass="panel">
            <h1><asp:Label ID="Label4" runat="server" Text="Add Bird Sighting" ForeColor="#366592"></asp:Label>&nbsp;</h1>
                        
            <div class="add" id="sighting">
                <h2><asp:Label ID="Label1" runat="server" Text="Sighting" ForeColor="#FF616F"></asp:Label></h2>
                
                <asp:Label ID="Label8" runat="server" Text="Member"></asp:Label>&nbsp;<asp:Button
                    ID="bAddMember" runat="server" style="cursor:pointer;text-shadow: rgb(224, 224, 224) 1px 1px 0px; float: right;" Text="+ Add New Member" 
                    BackColor="#F6F5EB" BorderColor="#F6F5EB" 
                    BorderStyle="None" BorderWidth="0px" Font-Size="X-Large" ForeColor="#CC0000" 
                    ToolTip="Add new member" onclick="bAddMember_Click" /><br />
                <asp:DropDownList ID="ddlMember" runat="server" DataTextField="first" DataValueField="memberID" 
                    Font-Size="XX-Large" Height="43px" Width="100%" ForeColor="DimGray" 
                    AutoPostBack="True">
                </asp:DropDownList>
                <br />
                   
                <asp:Label ID="Label7" runat="server" Text="Bird"></asp:Label>&nbsp;<asp:Button
                    ID="bAddBird" runat="server" style="cursor:pointer; text-shadow: rgb(224, 224, 224) 1px 1px 0px; float: right;" Text="+ Add New Bird" BackColor="#F6F5EB" BorderColor="#F6F5EB" 
                    BorderStyle="None" BorderWidth="0px" Font-Size="X-Large"  
                    ToolTip="Add new bird" onclick="bAddBird_Click" ForeColor="#CC0000" /><br />
                <asp:DropDownList ID="ddlBird" runat="server" 
                    DataTextField="englishName" DataValueField="birdID" 
                    Font-Size="XX-Large" Height="43px" Width="100%" ForeColor="DimGray" 
                    AutoPostBack="True">
                </asp:DropDownList>     
                <asp:Label ID="Label12" runat="server" Text="Change Bird Name"></asp:Label><br />   
                <asp:RadioButtonList ID="rblBirdName" runat="server" 
                    RepeatDirection="Horizontal" Width="100%" Height="43px" 
                    AutoPostBack="True" 
                    onselectedindexchanged="RadioButtonList1_SelectedIndexChanged">
                    <asp:ListItem Selected="True" Value="englishName">English</asp:ListItem>
                    <asp:ListItem Value="maoriName">Maori</asp:ListItem>
                    <asp:ListItem Value="scientificName">Scientific</asp:ListItem>
                </asp:RadioButtonList>
                <p><asp:Button ID="Button1" runat="server" style="cursor:pointer;" 
                        Text="+ Add Sighting" Font-Size="XX-Large" 
                CssClass="button" ForeColor="#68BCAC" BorderStyle="None" BorderWidth="0" 
                        BorderColor="#F6F5EB" BackColor="#F6F5EB" onclick="Button1_Click" /></p>
            </div> 
            
            <div class="add" id="member" runat="server">  
                <h2><asp:Label ID="Label10" runat="server" Text="Member" ForeColor="#EFC236"></asp:Label></h2>              
                First Name<asp:Label ID="lFirstName" runat="server" Text=" *" ForeColor="#CC0000"></asp:Label><br />
                <asp:TextBox ID="tbFirstName" runat="server" Font-Size="XX-Large" Width="100%"></asp:TextBox><br />
                Last Name<asp:Label ID="lLastName" runat="server" Text=" *" ForeColor="#CC0000"></asp:Label><br />
                <asp:TextBox ID="tbLastName" runat="server" Font-Size="XX-Large" Width="100%"></asp:TextBox><br />
                Suburb<asp:Label ID="lSuburb" runat="server" Text=" *" ForeColor="#CC0000"></asp:Label><br />
                <asp:TextBox ID="tbSuburb" runat="server" Font-Size="XX-Large" Width="100%"></asp:TextBox><br />
                <p><asp:Button ID="btnAddMember" runat="server" style="cursor:pointer;" Text="+ Add Member" Font-Size="XX-Large" 
                CssClass="button" ForeColor="#68BCAC" BorderStyle="None" BorderWidth="0" 
                        BorderColor="#F6F5EB" BackColor="#F6F5EB" onclick="Button4_Click"  /></p>                 
            </div>
                        
            <div class="add" id="bird" runat="server">    
                <h2><asp:Label ID="Label11" runat="server" Text="Bird" ForeColor="#6CBA0E"></asp:Label></h2>            
                English Name<asp:Label ID="Label2" runat="server" Text=" *" ForeColor="#CC0000"></asp:Label><br />
                <asp:TextBox ID="tbEnglishName" runat="server" Font-Size="XX-Large" Width="100%"></asp:TextBox><br />
                Maori Name<asp:Label ID="Label3" runat="server" Text=" *" ForeColor="#CC0000"></asp:Label><br />
                <asp:TextBox ID="tbMaoriName" runat="server" Font-Size="XX-Large" Width="100%"></asp:TextBox><br />
                Scientific Name<asp:Label ID="Label9" runat="server" Text=" *" 
                    ForeColor="#CC0000"></asp:Label><br />
                <asp:TextBox ID="tbScientificName" runat="server" Font-Size="XX-Large" Width="100%"></asp:TextBox><br />
                <p><asp:Button ID="bAddBirdDatabase" runat="server" style="cursor:pointer;" Text="+ Add Bird" Font-Size="XX-Large" 
                CssClass="button" ForeColor="#68BCAC" BorderStyle="None" BorderWidth="0" 
                        BorderColor="#F6F5EB" BackColor="#F6F5EB" onclick="Button2_Click"  /></p>
                
            </div>  
                
        </asp:Panel>
        
    </div>
    <div class="footer"><asp:Image ID="Image2" runat="server" Width="100px" style="float: right;" ImageUrl="~/Images/logo.png" />
        <h3><asp:Label ID="lbResult" runat="server" 
                style="display: block; position:absolute; left: 0px; bottom: 30px;" 
                Text="Enter the bird sighting details to be added to the database" 
                ForeColor="#CC6600"></asp:Label></h3>
        
    </div>
</asp:Content>

