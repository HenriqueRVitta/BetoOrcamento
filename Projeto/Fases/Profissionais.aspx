<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profissionais.aspx.cs" Inherits="Orcamento.Projeto.Fases.Profissionais1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel" id="Cadastro">
    <asp:Label ID="lblProjeto" runat="server" Text="" Visible="false"></asp:Label>
    <div class="panel-container show">
        <div class="panel-content">
            <div class="row">
                <div class="container">
                    <div class="row" style="background-color:#000438">
                    <div class="col-sm" style="color:white">
                        Projeto
                    </div>
                    <div class="col-sm">
                    </div>
                    <div class="col-sm">
                    </div>
                    <div class="col-sm">
                    </div>
                    <div class="col-sm">
                    </div>
                    <div class="col-sm">
                    </div>
                    <div class="col-sm">
                    </div>
                    <div class="col-sm">
                    </div>
                    <div class="col-sm">
                    </div>
                    </div>
                </div>
                <div class="container">
                <div class="row" style="background-color:#000438">
                    <div class="col-sm">
                    </div>
                    <div class="col-sm" style="color:red">
                        Despesas Administrativas
                    </div>
                    <div class="col-sm" style="color:red">
                        Custos
                    </div>
                    <div class="col-sm" style="color:red">
                        Etapas
                    </div>
                    <div class="col-sm" style="color:white">
                        Profissionais
                    </div>
                    <div class="col-sm">
                    </div>
                    <div class="col-sm">
                    </div>
                    <div class="col-sm">
                    </div>
                    <div class="col-sm">
                    </div>
                    </div>
                </div>
            </div>
            <div class="card-body">
                <div class="col-sm-offset-1 col-sm-10">


                </div>
            </div>
            <div class="container">
                <div class="row" style="background-color:#000438">
                <div class="col-sm">
                    <asp:Button ID="BtnVolta" runat="server" Text="Fase Anterior" style="background-color:#000438; color:white" OnClick="BtnVolta_Click"/>
                </div>
                <div class="col-sm">
                </div>
                <div class="col-sm">
                </div>
                <div class="col-sm">
                </div>
                <div class="col-sm">
                </div>
                <div class="col-sm">
                </div>
                <div class="col-sm">
                </div>
                <div class="col-sm">
                </div>
                <div class="col-sm">
                    <asp:Button ID="BtnAvanca" runat="server" Text="Avançar/Gravar" style="background-color:#000438; color:white" OnClick="BtnAvanca_Click"/>
                </div>
                </div>
            </div>
        </div>
    </div>
</div>
</asp:Content>
