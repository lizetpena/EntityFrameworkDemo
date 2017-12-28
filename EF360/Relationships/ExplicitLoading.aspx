﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ExplicitLoading.aspx.cs" Inherits="EF360CodeOnly.Relationships.ExplicitLoading" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" 
            Text="Demonstrates Explicit Loading" Font-Bold="True" 
            Font-Size="Large" ForeColor="#0033CC"></asp:Label>
        <hr />
    </div>

    <div style="margin-left: 15px;">
       <div>
            <asp:Label ID="Label2" runat="server" 
                Text="Explicitly Query Customer and Child Orders" Font-Bold="True" 
                Font-Size="Small" ForeColor="#0033CC"></asp:Label>
            <hr />
        </div>

        <asp:GridView ID="gvExplicit" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
            <emptydatatemplate>
              <asp:image id="NoDataImage"
                imageurl="~/Images/Empty.jpg"
                alternatetext="No Image"
                runat="server"/>            
            </emptydatatemplate> 
        </asp:GridView> 
        <div  style="margin-left: 15px; margin-bottom:25px;"></div> 
        <hr /> 
    </div>
    
       <div style="margin-left: 15px;">
       <div>
            <asp:Label ID="Label3" runat="server" 
                Text="Explicitly Query Customer and Filter Child Orders" Font-Bold="True" 
                Font-Size="Small" ForeColor="#0033CC"></asp:Label>
            <hr />
        </div>

        <asp:GridView ID="gvExplicitFiltered" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
            <emptydatatemplate>
              <asp:image id="NoDataImage"
                imageurl="~/Images/Empty.jpg"
                alternatetext="No Image"
                runat="server"/>            
            </emptydatatemplate> 
        </asp:GridView> 
        <div  style="margin-left: 15px; margin-bottom:25px;"></div> 
        <hr /> 
    </div>
</asp:Content>
