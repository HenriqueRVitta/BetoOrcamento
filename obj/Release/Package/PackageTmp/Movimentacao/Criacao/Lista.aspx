<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Lista.aspx.cs" Inherits="Orcamento.Movimentacao.Criacao.Lista" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<div class="panel" id="Projetos">
    <div class="panel-container show">
        <div class="panel-content">
            <div class="row" style="width:100%">
                 <div class="card text-left">
                    <div class="card-header text-center">

                            <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0">
                               <ajaxToolkit:TabPanel runat="server" HeaderText="Projetos" ID="TabPnlProjetos">
                                    <ContentTemplate>
                                        <asp:Panel ID="PnlProjetos" runat="server">
                                            <asp:UpdatePanel ID="UpdProjetos" runat="server"><ContentTemplate>
                                                    <h2>Lista Projetos</h2>
                                                    </div>
                                                         <div>
                                                            <div class="col-12 text-left" style="margin-top:5px">
                                                                <asp:HyperLink NavigateUrl="/Movimentacao/Criacao/Cadastro" runat="server" asp-route-id="@cu_id" title="Editar Valores" class="btn btn-primary">Novo Projeto</asp:HyperLink>
                                                            </div>
                                                            <div class="card-body">
                                                                <div class="col-sm-offset-1 col-sm-10" style="width:100%;overflow-y: scroll;">
                                                                    <asp:UpdatePanel runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:GridView ID="GrdProjetos" runat="server" AutoGenerateColumns="false" class="table table-bordered table-hover table-striped w-100" AlternatingRowStyle-HorizontalAlign="Left" DataKeyNames="pr_id,ti_id" AllowSorting="True" OnSorting="GrdProjetos_Sorting" OnRowCommand="GrdProjetos_RowCommand" AllowPaging="True" onpageindexchanging="GrdProjetos_PageIndexChanging" PageSize="11">
                                                                                <Columns>
                                                                                    <asp:BoundField DataField="ti_descricao" HeaderText="Tipologia" SortExpression="ti_descricao"/>
                                                                                    <asp:BoundField DataField="pr_metragem" HeaderText="Metragem" SortExpression="pr_metragem"/> 
                                                                                    <asp:BoundField DataField="pr_endereco" HeaderText="Endereço" />
                                                                                    <asp:BoundField DataField="pr_conteudo" HeaderText="Conteudo" SortExpression="pr_conteudo"/>
                                                                                    <asp:BoundField DataField="pr_proprietario" HeaderText="Proprietario"/>
                                                                                    <asp:BoundField DataField="pr_data" HeaderText="Data" SortExpression="pr_data"/> 
                                                                                    <asp:BoundField DataField="pr_responsavel" HeaderText="Responsavel" SortExpression="pr_responsavel"/>
                                                                                    <asp:BoundField DataField="pr_margem_lucro" HeaderText="Margem Lucro"/>
                                                                                    <asp:BoundField DataField="pr_margem_dificuldade" HeaderText="Margem Dificuldade"/>
                                                                                    <asp:BoundField DataField="pr_margem_criativo" HeaderText="Criatividade"/>
                                                                                    <asp:BoundField DataField="pr_impostos" HeaderText="Impostos"/>
                                                                                    <asp:BoundField DataField="pr_desconto" HeaderText="Desconto"/>
                                                                                    <asp:ButtonField ButtonType="Image" CommandName="Editar" ItemStyle-Width="60px" ImageUrl="~/Content/images/lapisP.png"></asp:ButtonField>
                                                                                    <asp:ButtonField ButtonType="Image" CommandName="Excluir" ItemStyle-Width="60px" ImageUrl="~/Content/images/lixeiraP.png"></asp:ButtonField>
                                                                                    <asp:ButtonField ButtonType="Button" CommandName="Selecionar" ItemStyle-Width="60px"></asp:ButtonField>
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
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </asp:Panel>                           
                                     </ContentTemplate>              
                                </ajaxToolkit:TabPanel>
                                <ajaxToolkit:TabPanel runat="server" HeaderText="Despesas" ID="TabPnlDespesas">
                                    <ContentTemplate>
                                        <asp:Panel ID="PnlDespesas" runat="server">
                                        <div class="card-body">
                                            <div class="col-sm-offset-1 col-sm-10" style="width:100%;overflow-y: scroll">
                                                <asp:UpdatePanel ID="UpdDespesas" runat="server">
                                                    <ContentTemplate>
                                                        <asp:GridView ID="GrdDespesas" runat="server" class="table table-bordered table-hover table-striped w-100" AutoGenerateColumns="false" DataKeyNames="da_id">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Check" HeaderStyle-HorizontalAlign="Center">
                                                                    <HeaderTemplate>
                                                                        <asp:CheckBox ID="chkSelectAll" runat="server" AutoPostBack="true" OnCheckedChanged="chkSelectAllD_CheckedChanged" />
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="chkSelect" runat="server" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="da_descricao" HeaderText="Descrição" SortExpression="da_descricao"  ItemStyle-HorizontalAlign="Left"/>  
                                                            </Columns>
                                                        </asp:GridView>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                             </div>
                                          </div>
                                        </asp:Panel> 
                                        
                                    </ContentTemplate>            
                                </ajaxToolkit:TabPanel>

                               <ajaxToolkit:TabPanel runat="server" HeaderText="Custos" ID="TabPnlCustos">
                                    <ContentTemplate>
                                        <asp:Panel ID="PnlCustos" runat="server">
                                            <asp:UpdatePanel ID="UpdCustos" runat="server">
                                                <ContentTemplate>
                                                    <asp:GridView ID="GrdCustos" runat="server" class="table table-bordered table-hover table-striped w-100" AutoGenerateColumns="false" DataKeyNames="cu_id">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Check" HeaderStyle-HorizontalAlign="Center">
                                                                <HeaderTemplate>
                                                                    <asp:CheckBox ID="chkSelectAll" runat="server" AutoPostBack="true" OnCheckedChanged="chkSelectAllC_CheckedChanged" />
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="chkSelect" runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="cu_descricao" HeaderText="Descrição" SortExpression="cu_descricao" ItemStyle-HorizontalAlign="Left"/>  
                                                        </Columns>
                                                    </asp:GridView>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </asp:Panel>
                                    </ContentTemplate>             
                                </ajaxToolkit:TabPanel>

                                <ajaxToolkit:TabPanel runat="server" HeaderText="Etapas" ID="TabPnlEtapas">
                                    <ContentTemplate>
                                        <asp:Panel ID="PnlEtapas" runat="server">
                                            <asp:UpdatePanel ID="UpdEtapas" runat="server">
                                                <ContentTemplate>
                                                    <asp:GridView ID="GrdEtapas" runat="server" AutoGenerateColumns="false" class="table table-bordered table-hover table-striped w-100" AlternatingRowStyle-HorizontalAlign="Left" DataKeyNames="et_id" AllowSorting="True">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Check">
                                                                <HeaderTemplate>
                                                                    <asp:CheckBox ID="chkSelectAll" runat="server" AutoPostBack="true" OnCheckedChanged="chkSelectAllE_CheckedChanged" />
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="chkSelect" runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="et_descricao" HeaderText="Descrição" SortExpression="et_descricao"/>    
                                                        </Columns>
                                                    </asp:GridView>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </asp:Panel>                        
                                    </ContentTemplate>                    
                                </ajaxToolkit:TabPanel>

                                <ajaxToolkit:TabPanel runat="server" HeaderText="Profissionais" ID="TabPnlProfissionais">
                                    <ContentTemplate>
                                        <asp:Panel ID="PnlProfissionais" runat="server">
                                            <asp:UpdatePanel ID="UpdProfissionais" runat="server">
                                                <ContentTemplate>

                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </asp:Panel>              
                                        </ContentTemplate>        
                                </ajaxToolkit:TabPanel>
                            </ajaxToolkit:TabContainer>
                        </div>
                </div>
            </div>
        </div>
    </div>
</div>
</asp:Content>
