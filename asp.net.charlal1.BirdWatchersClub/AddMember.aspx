<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddMember.aspx.cs" Inherits="AddMember" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h1>Add Member&nbsp;<asp:Label ID="lResult" runat="server" Text=""></asp:Label></h1>
    <hr />
    <div class="table">
        <asp:Panel ID="Pan1" Height="800px" Width="110%" BackColor="White" 
            ScrollBars="Auto" runat="server" HorizontalAlign="Justify" CssClass="panel">
            
            <div class="add">
                <%--<h3>Add New Member</h3>
                
                <hr />--%>
                <asp:Label ID="Label4" runat="server" Text="Firstname"></asp:Label><br />
                <asp:TextBox ID="tbFirstName" runat="server" Font-Size="XX-Large"></asp:TextBox><br />
                <asp:Label ID="Label5" runat="server" Text="Lastname"></asp:Label><br />
                <asp:TextBox ID="tbLastName" runat="server" Font-Size="XX-Large"></asp:TextBox><br />
                <asp:Label ID="Label6" runat="server" Text="Suburb"></asp:Label><br />
                <asp:TextBox ID="tbSuburb" runat="server" Font-Size="XX-Large"></asp:TextBox><br />
                <p><asp:Button ID="Button4" runat="server" style="cursor:pointer;" Text="+ Add Member" Font-Size="XX-Large" 
                CssClass="button" ForeColor="#696969" BorderStyle="None" BorderWidth="0" 
                        BorderColor="White" BackColor="White" onclick="Button4_Click"  /></p>                 
            </div>
        </asp:Panel>
    </div>
</asp:Content>

