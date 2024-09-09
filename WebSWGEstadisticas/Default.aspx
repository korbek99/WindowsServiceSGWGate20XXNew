<%@ Page Title="Página principal" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="WebSWGEstadisticas._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
<title>RightCom - Estadisticas</title>

    <link href="css/estilos.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<br />
<br />
<br />
    <%--<h2>
        ASP.NET
    </h2>
    <p>
        Para obtener más información acerca de ASP.NET, visite <a href="http://www.asp.net" title="Sitio web de ASP.NET">www.asp.net</a>.
    </p>
    <p>
        También puede encontrar <a href="http://go.microsoft.com/fwlink/?LinkID=152368"
            title="Documentación de ASP.NET en MSDN">documentación sobre ASP.NET en MSDN</a>.
    </p>--%>

    <div id="contenedor">
    <div id="top">SISTEMA DE ESTADISTICAS - MODULO DE ACCESO AL SISTEMA
    </div>
    <div id="logo"><a href="index.html">
   <%-- <img src="img/logoE.png" width="313" height="36" border="0"/></a>--%>
    </div>
    <div id="texto">Para ingresar al sistema debe hacer click en su botón correspondiente e ingresar los datos solicitados</div>
    <div id="botonera">
        
    <div class="btn"> <a href="GIEstadisticas/Admin/index.aspx"><img src="img/btnAdmin.png" width="250" height="300" border="0"/></a></div>
    <div class="btn"><a href="GIEstadisticas/Empresa/index.aspx"><img src="img/btnEmpresas.png" width="250" height="300" border="0" /></a></div>
   <%-- <div class="btn"><a href="especialistas_ex/index.php"><img src="img/btnEspecialistas.png" width="250" height="300" border="0" /></a></div>
    <div class="btn"><a href="trabajador/index.php"><img src="img/btnTrabajadores.png" width="250" height="300" border="0" /></a></div>--%>
    </div>
    <div id="recordarClave"></div>
    <div id="creditos">RESOLUCIÓN OPTIMA 1024 X 768 PÍXELES<br />
    DESARROLLADO RIGHTCOM © 2017 - DERECHOS RESERVADOS</div>
    </div>

    <br />
    <br />
    <br />
    <br />
</asp:Content>
