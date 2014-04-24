<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddSighting.aspx.cs" Inherits="AddSighting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Add Bird Sighting</h1>
    <hr />
    <div class="table">
        <asp:Panel ID="Pan1" Height="800px" Width="110%" BackColor="White" 
            ScrollBars="Auto" runat="server" HorizontalAlign="Justify" CssClass="panel">
            <div class="add">
                <h3>Add Bird Sighting</h3> <hr />
                <asp:Label ID="Label8" runat="server" Text="Member Sighted"></asp:Label><br />
                <asp:DropDownList ID="DropDownList1" runat="server" 
                    DataSourceID="sqlMemberName" DataTextField="first" DataValueField="first" 
                    Font-Size="XX-Large" Height="43px" Width="100%" ForeColor="#696969">
                </asp:DropDownList>
                <asp:SqlDataSource ID="sqlMemberName" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:IN712_201401_CHARLAL1Connection %>" 
                    SelectCommand="SELECT [first],[last] FROM [tblMember]"></asp:SqlDataSource>
                <br />
                   
                <asp:Label ID="Label7" runat="server" Text="Bird Sighted"></asp:Label><br />
                <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="sqlBirdName" 
                    DataTextField="englishName" DataValueField="englishName" 
                    Font-Size="XX-Large" Height="43px" Width="100%" ForeColor="#696969">
                </asp:DropDownList>
                <asp:SqlDataSource ID="sqlBirdName" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:IN712_201401_CHARLAL1Connection %>" 
                    SelectCommand="SELECT [englishName] FROM [tblBird]"></asp:SqlDataSource>
                
                <br />
                <br />
                <br />
                <p><asp:Button ID="Button1" runat="server" Text="+ Add Sighting" Font-Size="XX-Large" 
                CssClass="button" ForeColor="#696969" BorderStyle="None" BorderWidth="0" BorderColor="White" BackColor="White" /></p>
                
                                   
            </div>            
        </asp:Panel>
    </div>
    
</asp:Content>

