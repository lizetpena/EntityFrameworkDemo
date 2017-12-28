<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ObjectGraph.aspx.cs" Inherits="EF360CodeOnly.Relationships.ObjectGraph" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <asp:Label ID="Label1" runat="server" 
            Text="Lazy vs. Eager Loading (Implications on Database Traffic)" Font-Bold="True"  
            Font-Size="Large" ForeColor="#0033CC"></asp:Label>
        <hr />
         <asp:Label ID="Label2" runat="server" 
            Text="Simulate Multiple Calls to an Object Graph" Font-Bold="True"  
            Font-Size="Large" ForeColor="#0033CC"></asp:Label>
    </div>
    
    <div>
        <asp:RadioButtonList ID="RadioButtonLoadingType" runat="server">
            <asp:ListItem Selected="True" Value="0"><i>Lazy Loading</i></asp:ListItem>
            <asp:ListItem Value="1"><i>Eager Loading</i></asp:ListItem>
        </asp:RadioButtonList>
    </div>

    <table>
        <tr>
            <br/>
            <td style="Width: 200px; vertical-align: top;">
                <div style=" height: 28px; width:190px; background-color: #990000; color: White; font-weight:bold; vertical-align:bottom; text-align:center;">Oregon Customers</div>
                <asp:ListBox ID="listBoxCompany" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="ListBoxCompanySelectedIndexChanged" />
            </td>
            <td>
                <asp:GridView ID="gvLazy" runat="server" CellPadding="4" ForeColor="#333333" 
                    GridLines="None">
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" /> 
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>    
            </td>
        </tr>
    </table>


</asp:Content>
