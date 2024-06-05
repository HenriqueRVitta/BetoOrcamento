<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cadastro.aspx.cs" Inherits="Orcamento.Cadastros.Despesa.Cadastro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="panel" id="Cadastro">
    <div class="panel-container show">
        <div class="panel-content">
            <div class="row">
                 <div class="card text-left" style="background-color:#000438">
                        <div class="card-header text-center">
                        <h3>Cadastro - Despesas</h3>
                        </div>
                    </div>
                    <div class="card-body">
                        <div class="col-sm-offset-1 col-sm-10">
                            <div class="panel">
                                <div class="panel-container show">
                                    <div class="panel-content">
                                        <div asp-validation-summary="ModelOnly" class="text-danger"></div>
                                        <input ID="da_id" runat="server" type="hidden" />
                                        <div class="form-group col-md-8 offset-md-2 col-xl-6 offset-xl-3">
                                            <asp:Label ID="lblda_codigo" runat="server" Text="Código" />
                                            <asp:TextBox ID="da_codigo" runat="server" CssClass="form-control" required="true" AutoPostBack="True" OnTextChanged="da_codigo_TextChanged"/>
                                            <span asp-validation-for="da_codigo" class="text-danger"></span>
                                        </div>
                                        <div class="form-group col-md-8 offset-md-2 col-xl-6 offset-xl-3">
                                            <asp:Label ID="lblda_descricao" runat="server" Text="Descrição" />
                                            <asp:TextBox ID="da_descricao" runat="server" CssClass="form-control" required="true"/>
                                        </div>
                                        <asp:Panel ID="pnlFormula_Hora" runat="server" Visible="false">
                                            <div class="form-group col-md-8 offset-md-2 col-xl-6 offset-xl-3">
                                                <asp:Label ID="lblda_formula" runat="server" Text="Formula" />
                                                <asp:TextBox ID="da_formula" runat="server" CssClass="form-control"/>
                                            </div>
                                            <div class="form-group col-md-8 offset-md-2 col-xl-6 offset-xl-3">
                                                <asp:Label ID="lblHoras" runat="server" Text="Horas Trabalhadas Mês" />
                                                <asp:TextBox ID="da_hora_trabalhada" runat="server" CssClass="form-control"/>
                                            </div>
                                        </asp:Panel>

                                        <div class="form-group col-md-8 offset-md-2 col-xl-6 offset-xl-3" style="margin-top: 10px;">
    <%--                                        <button type="submit" id="btnSalvar_" onclick="btnSalvar_" runat="server" class="btn btn-primary btnPrimary">Salvar</button>--%>
                                            <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click" class="btn btn-primary btnPrimary" />
                                            <asp:HyperLink NavigateUrl="/Cadastros/Despesa/Lista" runat="server" asp-route-id="@da_id" title="Voltar para o pesquisa" class="btn btn-secondary btnSecundary">Voltar</asp:HyperLink>
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
