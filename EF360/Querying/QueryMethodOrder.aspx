<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="QueryMethodOrder.aspx.cs" Inherits="EF360CodeOnly.Querying.QueryMethodOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <asp:Label ID="Label1" runat="server" 
            Text="Demonstrates the Effect of Ordering LINQ Query Extension Methods" Font-Bold="True" 
            Font-Size="Large" ForeColor="#0033CC"></asp:Label>
        <hr />
    </div>

    <div style="margin-left: 15px;">
       <div>
            <asp:Label ID="Label2" runat="server" 
                Text="Query #1: Where, OrderBy, ThenBy and Select" Font-Bold="True" 
                Font-Size="Small" ForeColor="#0033CC"></asp:Label>
            <hr />
        </div>

        <asp:GridView ID="gvQuery1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
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
                Text="Query #2: OrderBy, ThenBy, Where and Select" Font-Bold="True" 
                Font-Size="Small" ForeColor="#0033CC"></asp:Label>
            <hr />
        </div>

        <asp:GridView ID="gvQuery2" runat="server" CellPadding="4" ForeColor="#333333" 
            GridLines="None">
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
            <asp:Label ID="Label4" runat="server" 
                Text="Query #3: Select, Where, OrderBy and ThenBy" Font-Bold="True" 
                Font-Size="Small" ForeColor="#0033CC"></asp:Label>
            <hr />
        </div>

        <asp:GridView ID="gvQuery3" runat="server" CellPadding="4" ForeColor="#333333" 
            GridLines="None">
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
            <asp:Label ID="Label5" runat="server" 
                Text="Query #4: Where, Select, OrderBy and ThenBy" Font-Bold="True" 
                Font-Size="Small" ForeColor="#0033CC"></asp:Label>
            <hr />
        </div>
    
        <asp:GridView ID="gvQuery4" runat="server" CellPadding="4" ForeColor="#333333" 
            GridLines="None">
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
