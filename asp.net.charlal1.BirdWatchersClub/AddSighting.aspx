<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddSighting.aspx.cs" Inherits="AddSighting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div class="table">
        <asp:Panel ID="Pan1" BackColor="White" 
            ScrollBars="Auto" runat="server" HorizontalAlign="Justify" CssClass="panel">
            <h1>Add Bird Sighting&nbsp;</h1>
            <%--<hr />--%>
            
            <div class="add" id="sighting">
                <h2>Sighting&nbsp;<asp:Label ID="Label1" runat="server" Text=""></asp:Label></h2>
                <%--<hr />--%>
                <asp:Label ID="Label8" runat="server" Text="Member"></asp:Label>&nbsp;<asp:Button
                    ID="bAddMember" runat="server" style="cursor:pointer;" Text="+" BackColor="White" BorderColor="White" 
                    BorderStyle="None" BorderWidth="0px" Font-Size="X-Large" ForeColor="DimGray" 
                    ToolTip="Add new member" onclick="bAddMember_Click" /><br />
                <asp:DropDownList ID="ddlMember" runat="server" DataTextField="first" DataValueField="memberID" 
                    Font-Size="XX-Large" Height="43px" Width="100%" ForeColor="DimGray">
                </asp:DropDownList>
                <br />
                   
                <asp:Label ID="Label7" runat="server" Text="Bird"></asp:Label>&nbsp;<asp:Button
                    ID="bAddBird" runat="server" style="cursor:pointer;" Text="+" BackColor="White" BorderColor="White" 
                    BorderStyle="None" BorderWidth="0px" Font-Size="X-Large" ForeColor="DimGray" 
                    ToolTip="Add new bird" onclick="bAddBird_Click" /><br />
                <asp:DropDownList ID="ddlBird" runat="server" 
                    DataTextField="englishName" DataValueField="birdID" 
                    Font-Size="XX-Large" Height="43px" Width="100%" ForeColor="DimGray">
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
                CssClass="button" ForeColor="#696969" BorderStyle="None" BorderWidth="0" 
                        BorderColor="White" BackColor="White" onclick="Button1_Click" /></p>
            </div> 
            
            <%--<h1>Add Member&nbsp;<asp:Label ID="lResult" runat="server" Text=""></asp:Label></h1>
            <hr />--%>
            <div class="add" id="member" runat="server">  
                <h2>Member&nbsp;<asp:Label ID="Label10" runat="server" Text=""></asp:Label></h2>              
                <asp:Label ID="lFirstName" runat="server" Text="First Name *"></asp:Label><br />
                <asp:TextBox ID="tbFirstName" runat="server" Font-Size="XX-Large" Width="100%"></asp:TextBox><br />
                <asp:Label ID="lLastName" runat="server" Text="Last Name *"></asp:Label><br />
                <asp:TextBox ID="tbLastName" runat="server" Font-Size="XX-Large" Width="100%"></asp:TextBox><br />
                <asp:Label ID="lSuburb" runat="server" Text="Suburb *"></asp:Label><br />
                <asp:TextBox ID="tbSuburb" runat="server" Font-Size="XX-Large" Width="100%"></asp:TextBox><br />
                <p><asp:Button ID="btnAddMember" runat="server" style="cursor:pointer;" Text="+ Add Member" Font-Size="XX-Large" 
                CssClass="button" ForeColor="#696969" BorderStyle="None" BorderWidth="0" 
                        BorderColor="White" BackColor="White" onclick="Button4_Click"  /></p>                 
            </div>
                 
            <%--<h1>Add Bird&nbsp;<asp:Label ID="Label1" runat="server" Text=""></asp:Label></h1>
            <hr />--%>
            <div class="add" id="bird" runat="server">    
                <h2>Bird&nbsp;<asp:Label ID="Label11" runat="server" Text=""></asp:Label></h2>            
                <asp:Label ID="Label2" runat="server" Text="English Name *"></asp:Label><br />
                <asp:TextBox ID="tbEnglishName" runat="server" Font-Size="XX-Large" Width="100%"></asp:TextBox><br />
                <asp:Label ID="Label3" runat="server" Text="Maori Name *"></asp:Label><br />
                <asp:TextBox ID="tbMaoriName" runat="server" Font-Size="XX-Large" Width="100%"></asp:TextBox><br />
                <asp:Label ID="Label9" runat="server" Text="Scientific Name *"></asp:Label><br />
                <asp:TextBox ID="tbScientificName" runat="server" Font-Size="XX-Large" Width="100%"></asp:TextBox><br />
                <p><asp:Button ID="Button2" runat="server" style="cursor:pointer;" Text="+ Add Bird" Font-Size="XX-Large" 
                CssClass="button" ForeColor="#696969" BorderStyle="None" BorderWidth="0" 
                        BorderColor="White" BackColor="White" onclick="Button2_Click"  /></p>
                
            </div>      
        </asp:Panel>
    </div>
    <div class="footer">
        <h3><asp:Label ID="lbResult" runat="server" style="display: block; position:absolute; left: 0px; right: 0px; bottom: 30px;" Text="Enter the bird sighting details to be added to the database"></asp:Label></h3>
        
    </div>
</asp:Content>

