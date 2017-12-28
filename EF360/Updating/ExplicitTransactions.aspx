<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ExplicitTransactions.aspx.cs" Inherits="EF360CodeOnly.Updating.ExplicitTransactions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin-top:10px; margin-bottom: 10px;">
        <asp:Label ID="Label1" runat="server" 
            Text="Updates and Change Tracking" Font-Bold="True"
            Font-Size="Large" ForeColor="#0033CC"></asp:Label>
        <hr />
    </div>
    
    <div>
        <asp:Label ID="Label2" runat="server" 
            Text="Before Update" Font-Bold="True" Font-Italic="true" 
            Font-Size="Large" ForeColor="#0033CC"></asp:Label>
    </div>

    <asp:GridView ID="gvInsertBefore" runat="server" CellPadding="4" ForeColor="#333333" 
        GridLines="None">
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>    

    <div style="margin-top:25px;">
        <asp:Label ID="Label3" runat="server" 
            Text="After Update" Font-Bold="True" Font-Italic="true" 
            Font-Size="Large" ForeColor="#0033CC"></asp:Label>
    </div>

    <asp:GridView ID="gvInsertAfter" runat="server" CellPadding="4" ForeColor="#333333" 
        GridLines="None">
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>  
</asp:Content>
