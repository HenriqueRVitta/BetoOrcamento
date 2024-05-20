<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cadastro.aspx.cs" Inherits="Orcamento.Projeto.Fases.Profissionais.Cadastro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel" id="Cadastro">
    <asp:Label ID="lblProjeto" runat="server" Text="" Visible="false"></asp:Label>
    <div class="panel-container show">
        <div class="panel-content">
            <div class="row" style="width:100%">
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
                            <asp:Button ID="btnVoltar" runat="server" Text="Voltar" class="btn btn-secondary btnSecundary" OnClick="btnVoltar_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
</asp:Content>
