﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Excluir.aspx.cs" Inherits="Orcamento.Cadastros.Tipificacao.Excluir" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="panel" id="Tipologia">
    <div class="panel-container show">
        <div class="panel-content">
            <div class="row">
                 <div class="card text-left" style="background-color:#000438">
                        <div class="card-header text-center">
                        <h3>Cadastro - Tipologia</h3>
                        </div>
                    </div>
                    <div class="card-body">
                        <div class="col-sm-offset-1 col-sm-10">
                            <div class="panel">
                                <div class="panel-container show">
                                    <div class="panel-content">
                                        <div asp-validation-summary="ModelOnly" class="text-danger"></div>
                                        <input ID="ti_id" runat="server" type="hidden" />
                                        <asp:Label ID="lbID" runat="server" Text="" Visible="false" />
                                        <div class="form-group col-md-8 offset-md-2 col-xl-6 offset-xl-3">
                                            <asp:Label ID="lblti_descricao" runat="server" Text="Descrição" />
                                            <asp:TextBox ID="ti_descricao" runat="server" CssClass="form-control" required="true"/>
                                        </div>
                                        <div class="form-group col-md-8 offset-md-2 col-xl-6 offset-xl-3" style="margin-top: 10px;">
                                            <asp:Button ID="btExcluir" runat="server" Text="Excluir" class="btn btn-primary btnPrimary" OnClick="btExcluir_Click" />
                                            <asp:HyperLink NavigateUrl="/Cadastros/Tipologia/Lista" runat="server" asp-route-id="@ti_id" title="Voltar para o pesquisa" class="btn btn-secondary btnSecundary">Voltar</asp:HyperLink>
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
