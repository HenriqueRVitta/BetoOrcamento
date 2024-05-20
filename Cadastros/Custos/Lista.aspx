<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Lista.aspx.cs" Inherits="Orcamento.Cadastros.Custos.Lista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="panel" id="Custos">
    <div class="panel-container show">
        <div class="panel-content">
            <div class="row" style="width:100%">
                 <div class="card text-left" style="background-color:#000438">
                    <div class="card-header text-center">
                    <h3>Cadastro - Lista Custos</h3>
                    </div>
                 </div>
                    <div class="col-12 text-left" style="margin-top:5px">
                        <asp:HyperLink NavigateUrl="/Cadastros/Custos/Cadastro" runat="server" asp-route-id="@cu_id" title="Editar Custos" class="btn btn-primary">Novo Custo</asp:HyperLink>
                    </div>
                <div class="card-body">
                    <div>
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="GrdCustos" runat="server" AutoGenerateColumns="false" class="table table-bordered table-hover table-striped w-100" AlternatingRowStyle-HorizontalAlign="Left" DataKeyNames="cu_id" AllowSorting="True" OnSorting="GrdCustos_Sorting" OnRowCommand="GrdCustos_RowCommand" AllowPaging="True" onpageindexchanging="GrdCustos_PageIndexChanging" PageSize="11">
                                    <Columns>
                                        <asp:BoundField DataField="cu_codigo" HeaderText="Código" SortExpression="cu_codigo"/>
                                        <asp:BoundField DataField="cu_descricao" HeaderText="Descrição" SortExpression="cu_descricao"/>  
                                        <asp:ButtonField ButtonType="Image" CommandName="Editar" ItemStyle-Width="60px" ImageUrl="~/Content/images/lapis.png"></asp:ButtonField>
                                        <asp:ButtonField ButtonType="Image" CommandName="Excluir" ItemStyle-Width="60px" ImageUrl="~/Content/images/lixeira.png"></asp:ButtonField>
                                    </Columns>
                                    <PagerSettings Position="Bottom" Mode="NextPreviousFirstLast"
                                    PreviousPageText="<img src='/Content/images/setasimplesesquerda.png' border='0' title='Página Anterior' class='navpage'/>"
                                    NextPageText="<img src='/Content/images/setasimplesdireita.png' border='0' title='Próxima Página' class='navpage'/>"
                                    FirstPageText="<img src='/Content/images/setaduplaesquerda.png' border='0' title='Primeira Página' class='navpage'/>"
                                    LastPageText="<img src='/Content/images/setadupladireita.png' border='0' title='Última Página' class='navpage'/>" 
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
