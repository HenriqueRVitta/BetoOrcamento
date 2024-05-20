<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Excluir.aspx.cs" Inherits="Orcamento.Cadastros.Etapas.Excluir" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div class="panel" id="Cadastro">
    <div class="panel-container show">
        <div class="panel-content">
            <div class="row">
                 <div class="card text-left" style="background-color:#000438">
                        <div class="card-header text-center">
                        <h3>Cadastro - Etapas - Excluir</h3>
                        </div>
                    </div>
                    <div class="card-body">
                        <div class="col-sm-offset-1 col-sm-10">
                            <div class="panel">
                                <div class="panel-container show">
                                    <div class="panel-content">
                                        <div asp-validation-summary="ModelOnly" class="text-danger"></div>
                                        <input ID="et_id" runat="server" type="hidden" />
                                        <div class="form-group col-md-8 offset-md-2 col-xl-6 offset-xl-3">
                                            <asp:Label ID="lblet_codigo" runat="server" Text="Código" />
                                            <asp:TextBox ID="et_codigo" runat="server" CssClass="form-control" required="true"/>
                                            <span asp-validation-for="et_codigo" class="text-danger"></span>
                                        </div>
                                        <div class="form-group col-md-8 offset-md-2 col-xl-6 offset-xl-3">
                                            <asp:Label ID="lblet_descricao" runat="server" Text="Descrição" />
                                            <asp:TextBox ID="et_descricao" runat="server" CssClass="form-control" required="true"/>
                                        </div>
                                        <div class="form-group col-md-8 offset-md-2 col-xl-6 offset-xl-3" style="margin-top: 10px;">
                                            <asp:Button ID="btExcluir" runat="server" Text="Excluir" class="btn btn-primary btnPrimary" OnClick="btExcluir_Click" />
                                            <asp:HyperLink NavigateUrl="/Cadastros/Etapas/Lista" runat="server" asp-route-id="@et_id" title="Voltar para o pesquisa" class="btn btn-secondary btnSecundary">Voltar</asp:HyperLink>
                                        </div>
                                    </div>
                                </div>
                            </div>
                          </div>
                    </div>
             </div>
       </div>
</div>
</asp:Content>
