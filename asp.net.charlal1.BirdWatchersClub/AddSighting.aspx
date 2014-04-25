<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddSighting.aspx.cs" Inherits="AddSighting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div class="table">
        <asp:Panel ID="Pan1" BackColor="White" 
            ScrollBars="Auto" runat="server" HorizontalAlign="Justify" CssClass="panel">
            <h1>Add Bird Sighting&nbsp;<asp:Label ID="lbResult" runat="server" Text=""></asp:Label></h1>
            <hr />
            <div class="add">
                <asp:Label ID="Label8" runat="server" Text="Member Sighted"></asp:Label><br />
                <asp:DropDownList ID="ddlMember" runat="server" 
                    DataSourceID="sqlMemberName" DataTextField="first" DataValueField="memberID" 
                    Font-Size="XX-Large" Height="43px" Width="100%" ForeColor="DimGray">
                </asp:DropDownList>
                <asp:SqlDataSource ID="sqlMemberName" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:IN712_201401_CHARLAL1Connection %>" 
                    SelectCommand="SELECT [first], [last], [memberID] FROM [tblMember]"></asp:SqlDataSource>
                <br />
                   
                <asp:Label ID="Label7" runat="server" Text="Bird Sighted"></asp:Label><br />
                <asp:DropDownList ID="ddlBird" runat="server" DataSourceID="sqlBirdName" 
                    DataTextField="englishName" DataValueField="birdID" 
                    Font-Size="XX-Large" Height="43px" Width="100%" ForeColor="DimGray">
                </asp:DropDownList>
                <asp:SqlDataSource ID="sqlBirdName" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:IN712_201401_CHARLAL1Connection %>" 
                    
                    SelectCommand="SELECT [englishName], [birdID], [maoriName], [scientificName] FROM [tblBird]"></asp:SqlDataSource>
                
                <br />
                <br />
                <br />
                <p><asp:Button ID="Button1" runat="server" style="cursor:pointer;" 
                        Text="+ Add Sighting" Font-Size="XX-Large" 
                CssClass="button" ForeColor="#696969" BorderStyle="None" BorderWidth="0" 
                        BorderColor="White" BackColor="White" onclick="Button1_Click" /></p>
                
                                   
            </div>            
        </asp:Panel>
    </div>
    
</asp:Content>

