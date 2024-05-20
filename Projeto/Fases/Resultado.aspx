<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Resultado.aspx.cs" Inherits="Orcamento.Projeto.Fases.Resultado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel" id="Cadastro">
            <asp:Label ID="lblProjeto" runat="server" Text="" Visible="false"></asp:Label>
                <div class="card text-left" style="background-color:#000438">
                    <div class="card-header text-center">
                        <div class="container">
                            <div class="row">
                            <div class="col-sm" style="color:white">
                                Projeto
                            </div>
                            <div class="col-sm">
                                &nbsp;
                            </div>
                            <div class="col-sm">
                                &nbsp;
                            </div>
                            <div class="col-sm">
                                &nbsp;
                            </div>
                            <div class="col-sm">
                                &nbsp;
                            </div>
                            <div class="col-sm">
                                &nbsp;
                            </div>
                            <div class="col-sm">
                                &nbsp;
                            </div>
                            <div class="col-sm">
                                &nbsp;
                            </div>
                            <div style="color:white;width:400px;">
                                <asp:Label ID="LblNome" runat="server" Text=""></asp:Label>
                            </div>
                            </div>
                        </div>
                        <div class="container">
                        <div class="row">
                            <div class="col-sm">
                                &nbsp;
                            </div>
                            <div class="col-sm" style="color:red">
                                Profissionais
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
                                Resultado
                            </div>
                            <div class="col-sm">
                                &nbsp;
                            </div>
                            <div class="col-sm">
                                &nbsp;
                            </div>
                            <div class="col-sm">
                                &nbsp;
                            </div>
                            </div>
                        </div>
                    </div>
                </div>
            <div class="col-12 text-left" style="margin-top:5px"></div>
            <div class="card-body">
                <div class="col-sm-offset-1 col-sm-10">
                    <div class="container">
                        <div class="row">
                            <div style="width:400px;">Despesas Administrativas
                            </div>
                            <div style="width:100px; text-align:left;">Total
                                &nbsp;
                            </div>
                            <div style="width:200px;">
                                <asp:Label ID="lblDespAdmin" runat="server" Text=""></asp:Label>
                            </div>
                            <div style="width:200px;">
                                <asp:Label ID="lblPercDespAdmin" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div style="width:400px;">
                                &nbsp;
                            </div>
                            <div style="width:100px; text-align:left;">Unitária
                            </div>
                            <div style="width:200px;">
                                <asp:Label ID="lblDespAdminUni" runat="server" Text=""></asp:Label>
                            </div>
                            <div style="width:200px;">
                                &nbsp;
                            </div>
                        </div>
                        <div class="row">
                            <div style="width:400px;">Custo do Serviço
                            </div>
                            <div style="width:100px; text-align:left;">Projeto
                            </div>
                            <div style="width:200px;">
                                <asp:Label ID="lblCusto" runat="server" Text=""></asp:Label>
                            </div>
                            <div style="width:200px;">
                                <asp:Label ID="lblPercCusto" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                         <div class="row">
                            <div style="width:400px;">Capacidade Produtiva
                            </div>
                            <div style="width:100px; text-align:left;">Arquiteto
                            </div>
                            <div style="width:200px;">
                                <asp:Label ID="lblCapProdutivaA" runat="server" Text=""></asp:Label>
                            </div>
                            <div style="width:200px;">
                                &nbsp;
                            </div>
                        </div>
                        <div class="row">
                            <div style="width:400px;">
                            </div>
                            <div style="width:100px; text-align:left;">Estagiário
                            </div>
                            <div style="width:200px;">
                               <asp:Label ID="lblCapProdutivaE" runat="server" Text=""></asp:Label>
                            </div>
                            <div style="width:200px;">
                            </div>
                        </div>
                        <div class="row">
                            <div style="width:400px;">
                                &nbsp;
                            </div>
                            <div style="width:100px; text-align:left;">Total
                            </div>
                            <div style="width:200px;">
                                <asp:Label ID="lblTempoTotal" runat="server" Text=""></asp:Label>
                            </div>
                            <div style="width:200px;">
                                &nbsp;
                            </div>
                        </div>
                        <div class="row">
                            <div style="width:400px;">Estimativa de Tempo para Produção (em Horas)
                            </div>
                            <div  style="width:100px; text-align:left;">Arquiteto 50%
                            </div>
                            <div style="width:200px;">
                                <asp:Label ID="lblTempArquiteto" runat="server" Text=""></asp:Label>
                            </div>
                            <div style="width:200px;">
                            </div>
                        </div>
                        <div class="row">
                            <div style="width:400px;">
                            </div>
                            <div  style="width:100px; text-align:left;">Estagiario 50%
                            </div>
                            <div style="width:200px;">
                                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                            </div>
                            <div style="width:200px;">
                            </div>
                        </div>
                        <div class="row">
                            <div style="width:400px;">Valor Hora Técnica (em reais)
                            </div>
                            <div style="width:100px; text-align:left;">Arquiteto
                            </div>
                            <div style="width:200px;">
                                <asp:Label ID="lblHoraTecnicaA" runat="server" Text=""></asp:Label>
                            </div>
                            <div style="width:200px;">
                            </div>
                        </div>
                        <div class="row">
                            <div style="width:400px;">
                            </div>
                            <div  style="width:100px; text-align:left;">Estagiário
                            </div>
                            <div style="width:200px;">
                                <asp:Label ID="lblHoraTecnicaE" runat="server" Text=""></asp:Label>
                            </div>
                            <div style="width:200px;">
                            </div>
                        </div>
                        <div class="row">
                            <div style="width:400px;">Custo Mão de Obra(em reais)
                            </div>
                            <div style="width:100px;">
                            </div>
                            <div style="width:200px;">
                                <asp:Label ID="LblMaoObra" runat="server" Text=""></asp:Label>
                            </div>
                            <div style="width:200px;">
                                <asp:Label ID="LblPercMaoObra" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div style="width:400px;">Sub Total
                            </div>
                            <div style="width:100px;">
                            </div>
                            <div style="width:200px;">
                                <asp:Label ID="lblSubTotal1" runat="server" Text=""></asp:Label>
                            </div>
                            <div style="width:200px;">
                                <asp:Label ID="lblPercSubTotal1" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div style="width:400px;">Margem de Lucro
                            </div>
                            <div style="width:100px;">
                                <asp:Label ID="lblPercMargemLucro" runat="server" Text=""></asp:Label>
                            </div>
                            <div style="width:200px;">
                                <asp:Label ID="lblMargemLucro" runat="server" Text=""></asp:Label>
                            </div>
                            <div style="width:200px;">
                            </div>
                        </div>
                        <div class="row">
                            <div style="width:400px;">Margem de Dificuldade
                            </div>
                            <div style="width:100px;">
                                <asp:Label ID="lblPercMargemDificuldade" runat="server" Text=""></asp:Label>
                            </div>
                            <div style="width:200px;">
                                <asp:Label ID="lblMargemDificuldade" runat="server" Text=""></asp:Label>
                            </div>
                            <div style="width:200px;">
                            </div>
                        </div>
                        <div class="row">
                            <div style="width:400px;">Margem de Potencial Criativo
                            </div>
                            <div style="width:100px;">
                                <asp:Label ID="lblPercMargemCriativo" runat="server" Text=""></asp:Label>
                            </div>
                            <div style="width:200px;">
                                <asp:Label ID="lblMargemCriativo" runat="server" Text=""></asp:Label>
                            </div>
                            <div style="width:200px;">
                                &nbsp;
                            </div>
                        </div>
                        <div class="row">
                            <div style="width:400px;">Sub Total
                            </div>
                            <div style="width:100px;">
                            </div>
                            <div style="width:200px;">
                                <asp:Label ID="lblSubTotal2" runat="server" Text=""></asp:Label>
                            </div>
                            <div style="width:200px;">
                                <asp:Label ID="lblPercSubTotal2" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                       <div class="row">
                            <div style="width:400px;">Total
                            </div>
                            <div style="width:100px;">
                            </div>
                            <div style="width:200px;">
                                <asp:Label ID="lblTotal" runat="server" Text=""></asp:Label>
                            </div>
                            <div style="width:200px;">
                            </div>
                        </div>
                        <div class="row">
                            <div style="width:400px;">Impostos sobre o preço de Venda (em percentual)
                            </div>
                            <div style="width:100px;">
                                <asp:Label ID="lblTaxaImposto" runat="server" Text=""></asp:Label>
                            </div>
                            <div style="width:200px;">
                                <asp:Label ID="lblImposto" runat="server" Text=""></asp:Label>
                            </div>
                            <div style="width:200px;">
                               &nbsp;
                            </div>
                        </div>
                        <div class="row">
                            <div style="width:400px;">Total
                            </div>
                            <div style="width:100px;">
                                &nbsp;
                            </div>
                            <div style="width:200px;">
                                <asp:Label ID="lblTotalGeral" runat="server" Text=""></asp:Label>
                            </div>
                            <div style="width:200px;">
                                &nbsp;
                            </div>
                        </div>
                        <div class="row">
                            <asp:GridView ID="grdProfisionais" runat="server" AutoGenerateColumns="false" >
                                <Columns>
                                    <asp:BoundField DataField="da_descricao" HeaderText="Profissional" />
                                    <asp:BoundField DataField="pp_quantidade" HeaderText="Nº Profissionais"/>  
                                    <asp:BoundField DataField="pp_valor" HeaderText="Horas Trabalhadas"/>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div style="width:400px;">
                    </div>
                    <div style="width:100px;">
                        &nbsp;
                    </div>
                    <div style="width:200px;">
                        &nbsp;
                    </div>
                    <div style="width:200px;">
                        &nbsp;
                    </div>
                </div>
                <div class="row">
                <div class="col-sm">
                    <asp:Button ID="BtnVolta" runat="server" Text="Fase Anterior" style="background-color:#000438; color:white" class="btn btn-primary" OnClick="BtnVolta_Click"/>
                </div>
                <div class="col-sm">
                </div>
                <div class="col-sm">
                </div>
                <div class="col-sm">
                </div>
                <div class="col-sm">
                    <asp:Button ID="BtnObservacao" runat="server" Text="Observação" style="background-color:#000438; color:white" class="btn btn-primary"/>
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
</asp:Content>
