﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Set.aspx.cs" Inherits="EF360CodeOnly.Querying.Set" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <asp:Label ID="Label1" runat="server" 
            Text="Set Operations" Font-Bold="True" 
            Font-Size="Large" ForeColor="#0033CC"></asp:Label>
        <hr />
    </div>

    <div style="margin-left: 15px;">
       <div>
            <asp:Label ID="Label6" runat="server" 
                Text="Set Operation (Customers in both OR and WA)" Font-Bold="True" 
                Font-Size="Small" ForeColor="#0033CC"></asp:Label>
            <hr />
        </div>

        <asp:GridView ID="gvSetOperation" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
            <emptydatatemplate>
              <asp:image id="NoDataImage"
                imageurl="~/Images/Grim1.jpg"
                alternatetext="No Image"
                runat="server"/>            
            </emptydatatemplate> 
        </asp:GridView>    
        <div  style="margin-left: 15px; margin-bottom:25px;"></div> 
        <hr /> 
    </div>


</asp:Content>