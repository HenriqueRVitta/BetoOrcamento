<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cadastro.aspx.cs" Inherits="Orcamento.Cadastros.Profissional.Cadastro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel" id="Cadastro">
    <div class="panel-container show">
        <div class="panel-content">
            <div class="row">
                <div class="card text-left">
                    <div class="card-header text-center">
                    <h2>Cadastro de Profissional</h2>
                    </div>
                    <div class="card-body">
                    <div class="col-sm-offset-1 col-sm-10">
                        <div class="panel">
                            <div class="panel-container show">
                                <div class="panel-content">
                                    <div asp-validation-summary="ModelOnly" class="text-danger"></div>
                                    <input ID="pr_id" runat="server" type="hidden" />
                                    <div class="form-group col-md-8 offset-md-2 col-xl-6 offset-xl-3">
                                        <asp:Label ID="lblpr_descricao" runat="server" Text="Descrição" />
                                        <asp:TextBox ID="pr_descricao" runat="server" CssClass="form-control" required="true"/>
                                    </div>
                                    <div class="form-group col-md-8 offset-md-2 col-xl-6 offset-xl-3" style="margin-top: 10px;">
                                        <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click" class="btn btn-primary btnPrimary" />
                                        <asp:HyperLink NavigateUrl="/Cadastros/Profissional/Lista" runat="server" asp-route-id="@pr_id" title="Voltar para o pesquisa" class="btn btn-secondary btnSecundary">Voltar</asp:HyperLink>
                                    </div>
                                </div>
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
