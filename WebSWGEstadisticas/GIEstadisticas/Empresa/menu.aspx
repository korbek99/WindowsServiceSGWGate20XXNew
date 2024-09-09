
<%@ Page Title="Acerca de nosotros" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="menu.aspx.cs" Inherits="WebSWGEstadisticas.GIEstadisticas.menu" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
 <link href="../../css/style.css" rel="stylesheet" type="text/css" />

    <link href="../../css/stylesM.css" rel="stylesheet" type="text/css" />
   <script src="http://code.jquery.com/jquery-latest.min.js" type="text/javascript"></script>
  
    <script src="../../Scripts/script.js" type="text/javascript"></script>
   <title>Menu Principal</title>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
   <div id='cssmenu'>
                       
                        <ul>
                           <%--<li><a href='#'><span>Maestros</span></a></li>--%>
                           <li class='active has-sub'><a href='#'><span>Empresa</span></a>
                              <ul>
                                 <li><a href="SC_Maestros/Clientes/ListClientes.aspx"><span>Estadisticas Empresa</span></a>
                                   <%-- <ul>
                                       <li><a href='#'><span>Sub Product</span></a></li>
                                       <li class='last'><a href='#'><span>Sub Product</span></a></li>
                                    </ul>--%>
                                 </li>
                                <li ><a href='SC_Maestros/ClientesExter/ListClientesExt.aspx'><span>Grafico 1</span></a></li>
                                 <li ><a href='SC_Maestros/Proveedores/ListaProvee.aspx'><span>Grafico 2</span></a></li>
                                 <li ><a href='SC_Maestros/FichaPersonal/ListaFicha.aspx'><span>Grafico 3</span></a></li>
                                 <li class='last'><a href='SC_Maestros/BaseCurricular/ListaBase.aspx'><span>Grafico 4</span></a></li>
                              </ul>

                           </li>
                           
                        </ul>
               </div>
</asp:Content>