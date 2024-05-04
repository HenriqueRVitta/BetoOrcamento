<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="beto.aspx.cs" Inherits="Orcamento.beto" %>

<!doctype html>
<html lang="pt">
<head runat="server">
    <!-- Required meta tags -->
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    
    <link href="https://fonts.googleapis.com/css?family=Open+Sans:300,400,700" rel="stylesheet" />

    <link rel="stylesheet" href="Content/fonts/icomoon/style.css" />

    <link rel="stylesheet" href="Content/css/owl.carousel.min.css" />

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="Content/css/bootstrap.min.css" />
    
    <!-- Style -->
    <link rel="stylesheet" href="Content/css/style.css" />

    <title>Precificação para Arquitetos</title>
</head>
<body>
    <form runat="server" style="background-color:darkgray;">
    <div class="site-mobile-menu site-navbar-target" style="background-color:dimgrey;">
        <div class="site-mobile-menu-header" >
          <div class="site-mobile-menu-close mt-3">
            <span class="icon-close2 js-menu-toggle"></span>
          </div>
        </div>
        <div class="site-mobile-menu-body"></div>
      </div>
      <header class="site-navbar site-navbar-target py-4" role="banner">
        <div class="container">
          <div class="row align-items-center position-relative">

            <div class="col-2 ml-auto text-right order-2">
              <div class="site-logo">
                <a href="beto.aspx.html" class="font-weight-bold text-white">Juliana & Ivan</a>
              </div>
            </div>
            <div class="col-9 order-1 text-left mr-auto">
              <span class="d-inline-block d-lg-block"><a href="#" class="text-black site-menu-toggle js-menu-toggle py-5"><span class="icon-menu h3 text-white"></span></a></span>
              <nav class="site-navigation text-right ml-auto d-none d-lg-none" role="navigation">
                  <ul class="site-menu main-menu js-clone-nav ml-auto ">
                      <li><a href="index.html" class="nav-link">Home</a></li>
                      <li class="has-children">
                          <a href="#" class="nav-link">Cadastro</a>
                          <ul class="dropdown arrow-top">
                              <li><a href="#" class="nav-link">Cliente</a></li>
                              <li><a href="/Cadastros/Profissional/Lista" class="nav-link">Profissional</a></li>
                              <li><a href="/Cadastros/Despesa/Lista" class="nav-link">Despesas Administrativas</a></li>
                              <li><a href="/Cadastros/Custos/Lista" class="nav-link">Custos</a></li>
                              <li><a href="/Cadastros/Etapas/Lista" class="nav-link">Etapas de Projetos</a></li>
                              <li><a href="/Cadastros/Preco/Lista" class="nav-link">Preços</a></li>
                              <li><a href="/Cadastros/Tipologia/Lista" class="nav-link">Tipologia</a></li>
                          </ul>
                      </li>
                      <li><a href="about.html" class="nav-link">Projetos</a></li>
                      <li><a href="services.html" class="nav-link">Dashboard</a></li>
                      <li><a href="blog.html" class="nav-link">Manual</a></li>
                      <li><a href="contact.html" class="nav-link">Contato</a></li>
                  </ul>
              </nav>
            </div>
          </div>
        </div>
      </header>

    <div class="hero" style="background-image: url('Content/images/ivan.jpg');"></div>

    <script src="Content/js/jquery-3.3.1.min.js"></script>
    <script src="Content/js/popper.min.js"></script>
    <script src="Content/js/bootstrap.min.js"></script>
    <script src="Content/js/jquery.sticky.js"></script>
    <script src="Content/js/main.js"></script>
    <footer class="footer-content">
        <p>&copy; <%: DateTime.Now.Year %> - Precificação para Arquitetos</p>
    </footer>
    </form>
</body>
</html>
