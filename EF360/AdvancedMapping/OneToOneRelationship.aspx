<%@ Page Title="One-To-One Relationships"
    Language="C#" 
    MasterPageFile="~/MasterPage/DemoMaster.Master" 
    AutoEventWireup="true" 
    CodeBehind="OneToOneRelationship.aspx.cs" 
    Inherits="GettingStarted.UI.EFAdvancedMapping.OneToOneRelationship" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <asp:Label ID="Label1" runat="server" 
            Text="Entity Framework -- Mapping One-to-One Relationships" Font-Bold="True" 
            Font-Size="Large" ForeColor="#0033CC"></asp:Label>
        <hr />
    </div>

    <asp:GridView ID="gvEF" runat="server" CellPadding="4" ForeColor="#333333" 
        GridLines="None">
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>    
    
</asp:Content>
