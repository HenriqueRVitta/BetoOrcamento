﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Orcamento.index" %>

<%@ Import Namespace="Orcamento" %>
<%@ Import Namespace="Microsoft.AspNet.Identity" %>

<!DOCTYPE html>

<html lang="pt">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css" rel="stylesheet">
    <link href="https://getbootstrap.com/docs/5.2/assets/css/docs.css" rel="stylesheet">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.bundle.min.js"></script>

    <title>Precificação para Arquitetos</title>

    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/modernizr") %>
    </asp:PlaceHolder>

    <webopt:bundlereference runat="server" path="~/Content/css" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />

</head>

<!-- Com espaçamento nas margens
<body class="p-3 m-0 border-0 bd-example"> 
-->
<body>

    
<div class="bg-image" 
     style="background-image: url('/Content/images/hero_bg_3.jpg');
            height: 100vh">

    <form runat="server">
        <asp:ScriptManager runat="server">
            <Scripts>
                <%--To learn more about bundling scripts in ScriptManager see https://go.microsoft.com/fwlink/?LinkID=301884 --%>
                <%--Framework Scripts--%>
                <asp:ScriptReference Name="MsAjaxBundle" />
                <asp:ScriptReference Name="jquery" />
                <asp:ScriptReference Name="WebForms.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebForms.js" />
                <asp:ScriptReference Name="WebUIValidation.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebUIValidation.js" />
                <asp:ScriptReference Name="MenuStandards.js" Assembly="System.Web" Path="~/Scripts/WebForms/MenuStandards.js" />
                <asp:ScriptReference Name="GridView.js" Assembly="System.Web" Path="~/Scripts/WebForms/GridView.js" />
                <asp:ScriptReference Name="DetailsView.js" Assembly="System.Web" Path="~/Scripts/WebForms/DetailsView.js" />
                <asp:ScriptReference Name="TreeView.js" Assembly="System.Web" Path="~/Scripts/WebForms/TreeView.js" />
                <asp:ScriptReference Name="WebParts.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebParts.js" />
                <asp:ScriptReference Name="Focus.js" Assembly="System.Web" Path="~/Scripts/WebForms/Focus.js" />
                <asp:ScriptReference Name="WebFormsBundle" />
                <%--Site Scripts--%>
            </Scripts>
        </asp:ScriptManager>
        <!-- light
        <nav class="navbar navbar-expand-lg bg-light">
        -->
        <!-- black
        <nav class="navbar navbar-expand-sm navbar-toggleable-sm navbar-dark bg-dark">
        -->
        <nav class="navbar navbar-expand-sm navbar-toggleable-sm navbar-dark bg-dark">
          <div class="container-fluid">
            <a class="navbar-brand" href="#">Precificação para Arquitetos</a>
            <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
              <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarSupportedContent">
              <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                <li class="nav-item dropdown">
                <li class="nav-item">
                  <a class="nav-link" href="/Contato.aspx">Contato</a>
                </li>
                <li class="nav-item">
                  <a class="nav-link" href="/Sobre.aspx">Sobre</a>
                </li>               

              </ul>
                    <asp:LoginView runat="server" ViewStateMode="Disabled">
                        <AnonymousTemplate>
                            <ul class="navbar-nav navbar-right">
                                <li><a runat="server" class="nav-link" href="~/Account/Register">Cadastrar-se</a></li>
                                <li><a runat="server" class="nav-link" href="~/Account/Login">Entrar</a></li>
                            </ul>
                        </AnonymousTemplate>
                        <LoggedInTemplate>
                            <ul class="navbar-nav navbar-right">
                                <li><a runat="server" class="nav-link" href="~/Account/Manage" title="Manage your account">Olá, <%: Context.User.Identity.GetUserName()  %> !</a></li>
                                <li>
                                    <asp:LoginStatus runat="server" CssClass="nav-link" LogoutAction="Redirect" LogoutText="Sair" LogoutPageUrl="~/" OnLoggingOut="Unnamed_LoggingOut" />
                                </li>
                            </ul>
                        </LoggedInTemplate>
                    </asp:LoginView>
            </div>
          </div>
        </nav>
            <div id="carouselExampleSlidesOnly" class="carousel slide" data-bs-ride="carousel">
              <div class="carousel-inner">
                <div class="carousel-item active">
                  <img src="/Content/images/Ivan.jpg" class="d-block w-100" alt="...">
                </div>
                <div class="carousel-item">
                  <img src="/Content/images/hero_bg_2.jpg" class="d-block w-100" alt="...">
                </div>
                <div class="carousel-item">
                  <img src="/Content/images/hero_bg_3.jpg" class="d-block w-100" alt="...">
                </div>
              </div>
            </div>      

        <div class="container body-content">
            <footer class="footer-content">
                <p>&copy; <%: DateTime.Now.Year %> - Precificação para Arquitetos</p>
            </footer>
        </div>
    </form>
</div>
    </body>
    </html>