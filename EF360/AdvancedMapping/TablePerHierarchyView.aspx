<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TablePerHierarchyView.aspx.cs" Inherits="EF360CodeOnly.AdvancedMapping.TablePerHierarchyView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server" />

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" 
            Text="Table Per Hierarchy Inheritance - Suppliers" Font-Bold="True" 
            Font-Size="Large" ForeColor="#0033CC"></asp:Label>
        <hr />
    </div>

    <div>
        <asp:Label ID="Label2" runat="server" 
            Text="Preferred Suppliers" Font-Bold="True" Font-Italic="true" 
            Font-Size="Large" ForeColor="#0033CC"></asp:Label>
    </div>

    <asp:GridView ID="gvManagement" runat="server" CellPadding="4" ForeColor="#333333" 
        GridLines="None">
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>    
    
    <hr />
    <div>
        <asp:Label ID="Label3" runat="server" 
            Text="Suppliers" Font-Bold="True" Font-Italic="true" 
            Font-Size="Large" ForeColor="#0033CC"></asp:Label>
    </div>

    <asp:GridView ID="gvEmployees" runat="server" CellPadding="4" ForeColor="#333333" 
        GridLines="None">
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>    
    
    <hr />    
    
</asp:Content>
