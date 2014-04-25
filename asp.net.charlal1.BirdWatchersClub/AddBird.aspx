<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddBird.aspx.cs" Inherits="AddBird" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h1>Add Bird&nbsp;<asp:Label ID="lResult" runat="server" Text=""></asp:Label></h1>
    <hr />
    <div class="table">
        <asp:Panel ID="Pan1" Height="800px" Width="110%" BackColor="White" 
            ScrollBars="Auto" runat="server" HorizontalAlign="Justify" CssClass="panel">
            
            <div class="add">
                <%--<h3>Add New Bird</h3>
                
                <hr />--%>
                <asp:Label ID="Label1" runat="server" Text="English"></asp:Label><br />
                <asp:TextBox ID="tbEnglishName" runat="server" Font-Size="XX-Large"></asp:TextBox><br />
                <asp:Label ID="Label2" runat="server" Text="Maori"></asp:Label><br />
                <asp:TextBox ID="tbMaoriName" runat="server" Font-Size="XX-Large"></asp:TextBox><br />
                <asp:Label ID="Label3" runat="server" Text="Scientific"></asp:Label><br />
                <asp:TextBox ID="tbScientificName" runat="server" Font-Size="XX-Large"></asp:TextBox><br />
                <p><asp:Button ID="Button2" runat="server" style="cursor:pointer;" Text="+ Add Bird" Font-Size="XX-Large" 
                CssClass="button" ForeColor="#696969" BorderStyle="None" BorderWidth="0" 
                        BorderColor="White" BackColor="White" onclick="Button2_Click"  /></p>
                
            </div>
        </asp:Panel>
    </div>
</asp:Content>

