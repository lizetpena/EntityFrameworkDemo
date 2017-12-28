<%@ Page Title="Type Inference" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Projection.aspx.cs" Inherits="EF360CodeOnly.Querying.Projection" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" 
            Text="Entity Framework-- Projection and Type Inference" Font-Bold="True" 
            Font-Size="Large" ForeColor="#0033CC"></asp:Label>
        <hr />
    </div>
 
      <table>
        <tr>
            <td style="width:300px;">
                <asp:Label ID="Label4" runat="server" 
                    Text="Project Entire Entity Object" Font-Bold="True" Font-Size="Medium" ForeColor="Black">
                </asp:Label>    

                <asp:GridView ID="gvEntireObject" runat="server" CellPadding="4" ForeColor="#333333" 
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
    
    <hr />
    
    <table>
        <tr>
            <td>
                <asp:Label ID="Label5" runat="server" 
                    Text="Project Single Value" Font-Bold="True" Font-Size="Medium" ForeColor="Black">
                </asp:Label>    
                
                <asp:GridView ID="gvSingeValue" runat="server" CellPadding="4" ForeColor="#333333" 
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
 
   <hr />
 
    <table>
        <tr>
            <td style="width:500px;">
                <asp:Label ID="Label3" runat="server"
                    Text="Project Against Anonymous Type" Font-Bold="True" Font-Size="Medium" ForeColor="Black">
                </asp:Label>    

                <asp:GridView ID="gvInfer" runat="server" CellPadding="4" ForeColor="#333333" 
                    GridLines="None">
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>   
            </td>
            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
            <td style="text-align:center;">
                <asp:Label ID="Label2" runat="server" 
                    Text="Project Against Concrete Type" Font-Bold="True" Font-Size="Medium" ForeColor="Black">
                </asp:Label>    
                
                <asp:GridView ID="gvExplicit" runat="server" CellPadding="4" ForeColor="#333333" 
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

    <hr />

</asp:Content>
