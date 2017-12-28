<%@ Page Title="Explicit Relationships" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ExplicitRelationships.aspx.cs" Inherits="EF360CodeOnly.Relationships.ExplicitRelationships" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
         <div>
        <asp:Label ID="Label1" runat="server" 
            Text="Explicit Relationships<br>Relationships defined in the Model, but not database" Font-Bold="True" 
            Font-Size="Large" ForeColor="#0033CC"></asp:Label>
        <hr />
    </div>

    <div style="margin-left: 15px;">
       <div>
            <asp:Label ID="Label2" runat="server" 
                Text="Explicit Join" Font-Bold="True" 
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
    
       <table>
        <tr>
            <td style="Width: 200px; vertical-align: top;">
                <div style=" height: 28px; width:200px; background-color: #990000; color: White; font-weight:bold; vertical-align:bottom; text-align:center;">Oregon Developers</div>
                <asp:ListBox ID="listBoxSupplierTypes" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="ListBoxCompanySelectedIndexChanged" />
            </td>
        </tr>
    </table>

</asp:Content>
