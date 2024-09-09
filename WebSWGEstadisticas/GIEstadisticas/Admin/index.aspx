<%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WebSWGEstadisticas.GIEstadisticas.Admin.Index" %>--%>
<%@ Page Title="Ingreso" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="index.aspx.cs" Inherits="WebSWGEstadisticas.GIEstadisticas.Admin.Index" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="../../css/estilos.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
     <div id="contenedor">
        <div id="top">SISTEMA DE ESTADISTICAS  - MODULO INGRESO DE ADMINISTRACIÓN</div>
        <div id="logo"><a href="index.html"><img src="../img/logoE.png" width="313" height="36" border="0" /></a>
        </div>
        <div id="ingreAdmin">
      <%--  <img src="../img/ingresoEmpresa.png" width="800" height="150" />--%>
            <img src="../../img/ingresoAdmin.png"  width="800" height="150" />
        </div>
        <div id="formulario">

        <table width="300" align="center">
        <tr id="letras">
        <td></td>
        <td><p><asp:Label ID="lblmensaje" runat="server" Text=""></asp:Label></p></td>
           
        </tr> 
        <tr id="letras">
        <td>USUARIO</td>
        <td align="right"><label for="Usuario"></label>
       <%-- <input name="txtnombre_usuario" type="text" id="txtnombre_usuario" size="30" />--%>
        <asp:TextBox ID="txtnombre_usuario" runat="server" size="30" ></asp:TextBox>
        </td>
            
        </tr>
        <tr>
        <td id="letras">PASSWORD</td>
        <td align="right"><label for="Clave de Acceso"></label>
       <%-- <input name="txtcontrasena" type="text" id="txtcontrasena" size="30" />--%>
        <asp:TextBox ID="txtcontrasena" runat="server" size="30" ></asp:TextBox>
        </td>
        </tr>
        <tr>
        <td>&nbsp;</td>
        <td align="right">
       <%-- <input type="submit" name="button" id="ingresar"  class="ingresar" value="ingresar" onclick="return validaForm(field)"  />--%>
        
            <asp:Button ID="ingresar" runat="server" Text="ingresar"  class="ingresar" 
                onclick="ingresar_Click" />
        </td>
        </tr>
        </table>

        </div>
        <div id="recordarClave"></div>
        <div id="creditos">RESOLUCIÓN OPTIMA 1024 X 768 PÍXELES<br />
        DESARROLLADO RIGHTCOM © 2017 - DERECHOS RESERVADOS</div>
        </div>
</asp:Content>
