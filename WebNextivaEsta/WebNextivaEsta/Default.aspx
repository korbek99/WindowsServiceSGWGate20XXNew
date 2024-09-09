<%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebNextivaEsta._Default" %>
--%>
<%@ Page Title="Acerca de nosotros" Language="C#" MasterPageFile="~/Site1.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="WebNextivaEsta._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <div id="DivContenedor" >
    <br />
        <asp:DropDownList ID="DDlCustomers" runat="server">
        </asp:DropDownList>
     <br />
        <asp:Label ID="Lbl" runat="server" Text="Fecha Inicio"></asp:Label>
      
    </div>
    <br />
    <br />
    <br />
    <div id="DivGraficos">
    
    
    </div>
    <br />
    <br />
    <br />
</asp:Content>
