<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Excluir.aspx.cs" Inherits="Orcamento.Projeto.Fases.Profissionais.Excluir" %>
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
                    <div style="color:white;width:500px;">
                        <asp:Label ID="LblNome" runat="server" Text=""></asp:Label>
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
                                    <asp:Button ID="btExcluir" runat="server" Text="Excluir" class="btn btn-primary btnPrimary" OnClick="btExcluir_Click" />
                                    <asp:Button ID="btnVoltar" runat="server" Text="Voltar" class="btn btn-secondary btnSecundary" OnClick="btnVoltar_Click" />                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
</div>
</asp:Content>
