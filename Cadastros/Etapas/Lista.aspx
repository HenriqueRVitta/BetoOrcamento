<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Lista.aspx.cs" Inherits="Orcamento.Cadastros.Etapas.Lista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel" id="Despesas">
    <div class="panel-container show">
        <div class="panel-content">
            <div class="row" style="width:100%">
                 <div class="card text-left" style="background-color:#000438">
                        <div class="card-header text-center">
                        <h3>Cadastro - Etapas</h3>
                        </div>
                     </div>
                    <div class="col-12 text-left" style="margin-top:5px">
                        <asp:HyperLink NavigateUrl="/Cadastros/Etapas/Cadastro" runat="server" asp-route-id="@et_id" title="Editar Despesa" class="btn btn-primary">Nova Etapa</asp:HyperLink>
                    </div>
                <div class="card-body">
                    <div>
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="GrdEtapa" runat="server" AutoGenerateColumns="false" class="table table-bordered table-hover table-striped w-100" AlternatingRowStyle-HorizontalAlign="Left" DataKeyNames="et_id" AllowSorting="True" OnSorting="GrdEtapa_Sorting" OnRowCommand="GrdEtapa_RowCommand" AllowPaging="True" onpageindexchanging="GrdEtapa_PageIndexChanging" PageSize="11">
                                    <Columns>
                                        <asp:BoundField DataField="et_codigo" HeaderText="Código" SortExpression="et_codigo"/>
                                        <asp:BoundField DataField="et_descricao" HeaderText="Descrição" SortExpression="et_descricao"/>  
                                        <asp:ButtonField ButtonType="Image" CommandName="Editar" ItemStyle-Width="60px" ImageUrl="~/Content/images/lapis.png"></asp:ButtonField>
                                        <asp:ButtonField ButtonType="Image" CommandName="Excluir" ItemStyle-Width="60px" ImageUrl="~/Content/images/lixeira.png"></asp:ButtonField>
                                    </Columns>
                                    <PagerSettings Position="Bottom" Mode="NextPrevious"
                                    PreviousPageText="<img src='/Content/images/setasimplesesquerda.png' border='0' title='Página Anterior' class='navpage'/>"
                                    NextPageText="<img src='/Content/images/setasimplesdireita.png' border='0' title='Próxima Página' class='navpage'/>"
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
    </div>
</asp:Content>
