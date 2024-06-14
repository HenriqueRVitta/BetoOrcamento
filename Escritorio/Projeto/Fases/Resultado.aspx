<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Resultado.aspx.cs" Inherits="Orcamento.Projeto.Fases.Resultado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="../../Content/bootstrap.min.css">
    <script src="../../Content/js/jquery-3.3.1.min.js"></script>
    <script src="../../Content/js/bootstrap.min.js"></script>
    <div class="panel" id="Cadastro">
            <asp:Label ID="lblProjeto" runat="server" Text="" Visible="false"></asp:Label>
            <asp:Label ID="lblCliente" runat="server" Text="1" Visible="false"></asp:Label>
                <div class="card text-left" style="background-color:#000438">
                    <div class="card-header text-center">
                        <div class="container">
                            <div class="row">
                            <div class="col-sm" style="color:white">
                                Escritório
                            </div>
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
                            <div class="col-sm" style="color:white">
                                Profissionais Alocados Para o Projeto
                            </div>
                            <div class="col-sm" style="color:white">
                                ->
                            </div>
                            <div class="col-sm" style="color:white">
                                Custos do Serviço
                            </div>
                            <div class="col-sm" style="color:white">
                                ->
                            </div>
                            <div class="col-sm" style="color:white">
                                Etapas do Projeto / Horas
                            </div>
                            <div class="col-sm" style="color:white">
                                ->
                            </div>
                            <div class="col-sm" style="color:red">
                                Orçamento
                            </div>
                            <div class="col-sm">
                            </div>
                            <div class="col-sm">
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
                            <div style="width:400px;">Total Horas de Projeto
                            </div>
                            <div style="width:100px; text-align:left;">
                            </div>
                            <div style="width:200px;">
                                <asp:Label ID="lblTempo" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:Label ID="lblTempoTotal" runat="server" Text=""></asp:Label>
                                <asp:Label ID="lblSubTI" runat="server" Visible="false"></asp:Label>
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
                                    <asp:BoundField DataField="pp_hora_trabalhada" HeaderText="Hora Trabalhadas"/>
                                </Columns>
                            </asp:GridView>
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
                                <asp:TextBox ID="txtPercMargemLucro" runat="server" Width="60 px" MaxLength="5"></asp:TextBox>
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
                                <asp:TextBox ID="txtPercMargemDificuldade" runat="server" Width="60px" MaxLength="5"></asp:TextBox>
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
                                <asp:TextBox ID="txtPercMargemCriativo" runat="server" Width="60px" MaxLength="5"></asp:TextBox>
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
                            <div style="width:400px;">Desconto
                            </div>
                            <div style="width:100px;">
                                <asp:TextBox ID="txtPercDesconto" runat="server" Width="60px" MaxLength="5"></asp:TextBox>
                            </div>
                            <div style="width:200px;">
                                <asp:Label ID="lblDesconto" runat="server" Text=""></asp:Label>
                            </div>
                            <div style="width:200px;">
                            </div>
                        </div>
                        <div class="row">
                            <div style="width:400px;">Impostos sobre o preço de Venda (em percentual)
                            </div>
                            <div style="width:100px;">
                                <asp:Label ID="lblTaxaImposto" runat="server" Width="60px"></asp:Label>
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
                        <button type="button" ID="BtnObservacao" style="background-color:#000438; color:white" class="btn btn-primary" data-toggle="modal" data-target="#myModal">Minhas Considerações</button>
                        <!-- Modal -->
                        <div class="modal fade" id="myModal" role="dialog">
                            <div class="modal-dialog">
                                <!-- Modal content-->
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <h3 class="modal-title">Minhas Considerações</h3>
                                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                                    </div>
                                    <div class="modal-body">
                                        <asp:TextBox runat="server" ID="TextBox1" TextMode="MultiLine" rows="10" maxlength="2083" style="width: 100%;"></asp:TextBox>
                                    </div>
                                    <div class="modal-footer">
                                        <asp:Button runat="server" Text="Salvar" OnClick="btnSalvarOBS_Click" class="btn btn-primary btnPrimary"></asp:Button>
                                        <asp:Button runat="server" class="btn btn-secondary btnSecundary" data-dismiss="modal" Text="Fechar"></asp:Button>
                                    </div>
                                </div>

                            </div>
                        </div>
                </div>
                <div class="col-sm">
                </div>
                <div class="col-sm">
                </div>
                <div class="col-sm">
                </div>
                <div class="col-sm">
                    <asp:Button ID="BtnCalcula" runat="server" Text="Calcular/Gravar" style="background-color:#000438; color:white" class="btn btn-primary" OnClick="BtnCalcula_Click"/>
                </div>
                </div>
           </div>
        </div>
    </div>
</asp:Content>
