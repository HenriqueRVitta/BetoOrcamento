<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Lista.aspx.cs" Inherits="Orcamento.Movimentacao.Criacao.Lista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="panel" id="Custos">
    <div class="panel-container show">
        <div class="panel-content">
            <div class="row" style="width:100%">
                 <div class="card text-left">
                    <div class="card-header text-center">
                    <h3>Projeto - Criação</h3>
                    </div>
                 </div>

                    <div class="col-12 text-left" style="margin-top:5px">
                        <asp:HyperLink NavigateUrl="/Projeto/Criacao/Cadastro" runat="server" asp-route-id="@pr_id" title="Editar Custos" style="background-color:#000438; color:white" class="btn btn-primary">Novo Projeto</asp:HyperLink>
                    </div>
                    <div class="card-body">
                        <div style="width:100%;overflow-y: scroll;">
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="GrdProjetos" runat="server" AutoGenerateColumns="false" class="table table-bordered table-hover table-striped w-100" AlternatingRowStyle-HorizontalAlign="Left" DataKeyNames="pr_id,ti_id" AllowSorting="True" OnSorting="GrdProjetos_Sorting" OnRowCommand="GrdProjetos_RowCommand" AllowPaging="True" onpageindexchanging="GrdProjetos_PageIndexChanging" PageSize="11">
                                        <Columns>
                                            <asp:ButtonField ButtonType="Image" CommandName="Editar" HeaderText="Editar" ItemStyle-Width="60px" ImageUrl="~/Content/images/lapisP.png"></asp:ButtonField>
                                            <asp:ButtonField ButtonType="Image" CommandName="Excluir" HeaderText="Excluir" ItemStyle-Width="60px" ImageUrl="~/Content/images/lixeiraP.png"></asp:ButtonField>
                                            <asp:ButtonField ButtonType="Image" CommandName="Selecionar" HeaderText="Selecionar" ItemStyle-Width="100px" ImageUrl="~/Content/images/checkbox.png"></asp:ButtonField>
                                            <asp:ButtonField ButtonType="Image" CommandName="Colonar" HeaderText="Clonar" ItemStyle-Width="60px" ImageUrl="~/Content/images/clone.png"></asp:ButtonField>
                                            <asp:BoundField DataField="ti_descricao" HeaderText="Tipologia" SortExpression="ti_descricao"/>
                                            <asp:BoundField DataField="pr_metragem" HeaderText="Metragem" SortExpression="pr_metragem"/> 
                                            <asp:BoundField DataField="pr_endereco" HeaderText="Endereço" />
                                            <asp:BoundField DataField="pr_conteudo" HeaderText="Conteudo" SortExpression="pr_conteudo"/>
                                            <asp:BoundField DataField="pr_proprietario" HeaderText="Proprietario"/>
                                            <asp:BoundField DataField="pr_data" HeaderText="Data" SortExpression="pr_data"/> 
                                            <asp:BoundField DataField="pr_responsavel" HeaderText="Responsavel" SortExpression="pr_responsavel"/>
                                            <asp:BoundField DataField="pr_margem_lucro" HeaderText="Margem Lucro" DataFormatString="{0:p2}" />
                                            <asp:BoundField DataField="pr_margem_dificuldade" HeaderText="Margem Dificuldade" DataFormatString="{0:p2}" />
                                            <asp:BoundField DataField="pr_margem_criativo" HeaderText="Criatividade" DataFormatString="{0:p2}" />
                                            <asp:BoundField DataField="pr_impostos" HeaderText="Impostos" DataFormatString="{0:p2}"/>
                                            <asp:BoundField DataField="pr_desconto" HeaderText="Desconto" DataFormatString="{0:p2}"/>
                                            <asp:BoundField DataField="pr_nome" HeaderText="Nome do Projeto" SortExpression="pr_nome"/>
                                        </Columns>
                                        <PagerSettings Position="Bottom" Mode="NextPreviousFirstLast"
                                        PreviousPageText="<img src='/Content/images/setasimplesesquerda.png' border='0' title='Página Anterior'/>"
                                        NextPageText="<img src='/Content/images/setasimplesdireita.png' border='0' title='Próxima Página'/>"
                                        FirstPageText="<img src='/Content/images/setaduplaesquerda.png' border='0' title='Primeira Página'/>"
                                        LastPageText="<img src='/Content/images/setadupladireita.png' border='0' title='Última Página'/>" 
                                        PageButtonCount="11"/>
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div> 
                    </div>
            </div>
       </div>
    </div>
</div>
</asp:Content>
