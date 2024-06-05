<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Excluir.aspx.cs" Inherits="Orcamento.Movimentacao.Criacao.Excluir" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel" id="Cadastro">
    <div class="panel-container show">
        <div class="panel-content">
            <div class="row">
                 <div class="card text-left" style="background-color:#000438">
                        <div class="card-header text-center">
                        <h3>Escritório - Projeto - Cadastro</h3>
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
                                        <asp:Label ID="lblpr_nome" runat="server" Text="Nome" />
                                        <asp:TextBox ID="pr_nome" runat="server" CssClass="form-control" required="true" ToolTip="Digite o Nome do Projeto"/>
                                    </div>
                                    <div class="form-group col-md-8 offset-md-2 col-xl-6 offset-xl-3">
                                        <asp:Label ID="lblpr_tipologia" runat="server" Text="Tipologia" />
                                        <asp:DropDownList ID="pr_tipologia" runat="server" CssClass="form-control" required="true" ToolTip="Escolha a Tipologia que Define o Projeto"></asp:DropDownList> 
                                    </div>
                                    <div class="form-group col-md-8 offset-md-2 col-xl-6 offset-xl-3">
                                        <asp:Label ID="lblpr_metragem" runat="server" Text="Metragem" />
                                        <asp:TextBox ID="pr_metragem" runat="server" CssClass="form-control" required="true" ToolTip="Digite a Metragem do Projeto"/>
                                    </div>
                                    <div class="form-group col-md-8 offset-md-2 col-xl-6 offset-xl-3">
                                        <asp:Label ID="lblpr_endereco" runat="server" Text="Endereço" />
                                        <asp:TextBox ID="pr_endereco" runat="server" CssClass="form-control" required="true" ToolTip="Digite o Endereço Projeto"/>
                                    </div>
                                    <div class="form-group col-md-8 offset-md-2 col-xl-6 offset-xl-3">
                                        <asp:Label ID="lblpr_conteudo" runat="server" Text="Conteudo" />
                                        <asp:TextBox ID="pr_conteudo" runat="server" CssClass="form-control" required="true" ToolTip="Digite o Conteudo do Projeto"/>
                                    </div>
                                    <div class="form-group col-md-8 offset-md-2 col-xl-6 offset-xl-3">
                                        <asp:Label ID="lblpr_proprietario" runat="server" Text="Proprietario" />
                                        <asp:TextBox ID="pr_proprietario" runat="server" CssClass="form-control" required="true" ToolTip="Digite o Nome do Proprietário"/>
                                    </div>
                                    <div class="form-group col-md-8 offset-md-2 col-xl-6 offset-xl-3">
                                        <asp:Label ID="lblpr_data" runat="server" Text="Data" />
                                        <asp:TextBox ID="pr_data" runat="server" CssClass="form-control" TextMode="Date" required="true" ToolTip="Digite o Data do Projeto" Width="180px"/>
                                    </div>
                                    <div class="form-group col-md-8 offset-md-2 col-xl-6 offset-xl-3">
                                        <asp:Label ID="lblpr_responsavel" runat="server" Text="Responsável" />
                                        <asp:TextBox ID="pr_responsavel" runat="server" CssClass="form-control" required="true" ToolTip="Digite o Nome do Responsavel Pelo Projeto"/>
                                    </div>
                                    <div class="form-group col-md-8 offset-md-2 col-xl-6 offset-xl-3">
                                        <asp:Label ID="lblpr_margem_lucro" runat="server" Text="Magem de Lucro" />
                                        <asp:TextBox ID="pr_margem_lucro" runat="server" CssClass="form-control" TextMode="Number" min="1" max="999" onKeyDown="if(this.value.length==3 && event.keyCode!=8) return false;" required="true" ToolTip="Digite o Valor do Percentual da Margem de Lucro" Width="180px"/>
                                    </div>
                                    <div class="form-group col-md-8 offset-md-2 col-xl-6 offset-xl-3">
                                        <asp:Label ID="lblpr_margem_dificuldade" runat="server" Text="Magem de Dificuldade" />
                                        <asp:TextBox ID="pr_margem_dificuldade" runat="server" CssClass="form-control" TextMode="Number" min="1" max="999" onKeyDown="if(this.value.length==3 && event.keyCode!=8) return false;" required="true" ToolTip="Digite o Valor do Percentual da Margem de Dificuldade" Width="180px"/>
                                    </div>
                                    <div class="form-group col-md-8 offset-md-2 col-xl-6 offset-xl-3">
                                        <asp:Label ID="lblpr_margem_criativo" runat="server" Text="Magem de Criatividade" />
                                        <asp:TextBox ID="pr_margem_criativo" runat="server" CssClass="form-control" TextMode="Number" min="1" max="999" onKeyDown="if(this.value.length==3 && event.keyCode!=8) return false;" required="true" ToolTip="Digite o Valor do Percentual da Margem de Criatividade" Width="180px"/>
                                    </div>
                                    <div class="form-group col-md-8 offset-md-2 col-xl-6 offset-xl-3">
                                        <asp:Label ID="lblpr_impostos" runat="server" Text="Impostos" />
                                        <asp:TextBox ID="pr_impostos" runat="server" CssClass="form-control" TextMode="Number" min="1" max="999" onKeyDown="if(this.value.length==3 && event.keyCode!=8) return false;" required="true" ToolTip="Digite o Valor do Percentual de Impostos" Width="180px"/>
                                    </div>
                                    <div class="form-group col-md-8 offset-md-2 col-xl-6 offset-xl-3">
                                        <asp:Label ID="lblpr_desconto" runat="server" Text="Desconto" />
                                        <asp:TextBox ID="pr_desconto" runat="server" CssClass="form-control" TextMode="Number" min="1" max="999" onKeyDown="if(this.value.length==3 && event.keyCode!=8) return false;" required="true" ToolTip="Digite o Valor do Percentual de Desconto" Width="180px"/>
                                    </div>
                                    <div class="form-group col-md-8 offset-md-2 col-xl-6 offset-xl-3" style="margin-top: 10px;">
                                        <asp:Button ID="btExcluir" runat="server" Text="Excluir" class="btn btn-primary btnPrimary" OnClick="btExcluir_Click" />
                                        <asp:HyperLink NavigateUrl="/Projeto/Criacao/Lista" runat="server" asp-route-id="@pr_id" title="Voltar para o pesquisa" class="btn btn-secondary btnSecundary">Voltar</asp:HyperLink>
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
