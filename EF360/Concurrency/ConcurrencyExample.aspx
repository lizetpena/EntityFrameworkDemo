<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConcurrencyExample.aspx.cs" Inherits="EF360CodeOnly.Concurrency.ConcurrencyExample" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
   
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <asp:Label ID="Label1" runat="server" 
            Text="Concurrency Example" Font-Bold="True" 
            Font-Size="Large" ForeColor="#0033CC"></asp:Label>
        <hr />
    </div>

    <div style="margin-left: 15px;">
       <div>
           <asp:Label ID="Label5" runat="server" Text="Id" Font-Bold="True" /> 
           &nbsp;&nbsp;&nbsp;<asp:Label id="lblId" Font-Size="Small" ForeColor="#0033CC" runat="server"/>
           <p />
           <asp:Label ID="Label6" runat="server" Text="Carrier Name" Font-Bold="True" /> 
           &nbsp;&nbsp;&nbsp;<asp:Label id="lblName" Font-Size="Small" ForeColor="#0033CC" runat="server"/>
          <p />
           <asp:Label ID="Label7" runat="server" Text="Carrier Abberviation" Font-Bold="True" /> 
           &nbsp;&nbsp;&nbsp;<asp:Label id="lblAbbrev" Font-Size="Small" ForeColor="#0033CC" runat="server"/>
           <p />
           <asp:Label ID="Label9" runat="server" Text="Carrier Rating" Font-Bold="True" /> 
           &nbsp;&nbsp;&nbsp;<asp:Label id="lblRating" Font-Size="Small" ForeColor="#0033CC" runat="server"/>
           <p />
           <asp:Label ID="Label11" runat="server" Text="Months in Service" Font-Bold="True" /> 
           &nbsp;&nbsp;&nbsp;<asp:Label id="lblMonths" Font-Size="Small" ForeColor="#0033CC" runat="server"/>
           <p />
           <asp:Label ID="Label13" runat="server" Text="RowVersion" Font-Bold="True" /> 
           &nbsp;&nbsp;&nbsp;<asp:Label id="lblRowVersion" Font-Size="Small" ForeColor="#0033CC" runat="server"/>
       </div>
       <div  style="margin-left: 15px; margin-bottom:25px;"></div> 
       <hr /> 
    </div>


    <div style="margin-left: 15px;">
       <div>
           <asp:Label ID="Label2" runat="server" Text="Concurrency Resolution Strategy" Font-Bold="True" /> 
           &nbsp;&nbsp;&nbsp;<asp:DropDownList id="ddlResolution" Font-Size="Small" ForeColor="#0033CC" runat="server"/>
           <p />
           <asp:Label ID="Label4" runat="server" Text="Carrier Rating" Font-Bold="True" /> 
           &nbsp;&nbsp;&nbsp;<asp:DropDownList id="ddlCarrierRating" Font-Size="Small" ForeColor="#0033CC" runat="server"/>
           <p />
           <asp:Button ID="btnSumbit" runat="server" Text="Submit"/>
       </div>
       <div  style="margin-left: 15px; margin-bottom:25px;"></div> 
       <hr /> 
    </div>
</asp:Content>
