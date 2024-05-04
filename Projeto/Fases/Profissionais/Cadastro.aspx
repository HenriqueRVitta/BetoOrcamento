<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cadastro.aspx.cs" Inherits="Orcamento.Projeto.Fases.Profissionais.Cadastro" %>
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
            <div class="panel">
                <div class="panel-container show">
                    <div class="panel-content">
                        <div asp-validation-summary="ModelOnly" class="text-danger"></div>
                        <input ID="pp_id" runat="server" type="hidden" />
                        <div class="form-group col-md-8 offset-md-2 col-xl-6 offset-xl-3">
                            <asp:Label ID="lblpp_profissional" runat="server" Text="Profissional" />
                            <asp:DropDownList ID="pp_profissional" runat="server" CssClass="form-control" required="true"></asp:DropDownList> 
                        </div>
                        <div class="form-group col-md-8 offset-md-2 col-xl-6 offset-xl-3">
                            <asp:Label ID="lblpp_valor" runat="server" Text="Valor" />
                            <asp:TextBox ID="pp_valor" runat="server" CssClass="form-control" required="true"/>
                        </div>
                        <div class="form-group col-md-8 offset-md-2 col-xl-6 offset-xl-3">
                            <asp:Label ID="lblpp_quantidade" runat="server" Text="Quantidade" />
                            <asp:TextBox ID="pp_quantidade" runat="server" CssClass="form-control" required="true"/>
                        </div>
                        <div class="form-group col-md-8 offset-md-2 col-xl-6 offset-xl-3" style="margin-top: 10px;">
                            <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click" class="btn btn-primary btnPrimary" />
                            <asp:HyperLink NavigateUrl="/Projeto/Fases/Profissionais/Lista" runat="server" asp-route-id="@pr_id" title="Voltar para o pesquisa" class="btn btn-secondary btnSecundary">Voltar</asp:HyperLink>
                        </div>
                    </div>
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
