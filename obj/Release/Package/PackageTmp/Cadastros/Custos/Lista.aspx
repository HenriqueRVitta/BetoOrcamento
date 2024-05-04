<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Lista.aspx.cs" Inherits="Orcamento.Cadastros.Custos.Lista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="panel" id="Custos">
    <div class="panel-container show">
        <div class="panel-content">
            <div class="row" style="width:100%">
             <div class="card text-left">
                <div class="card-header text-center">
                <h2>Lista Custos</h2>
                </div>
                 <div>
                    <div class="col-12 text-left" style="margin-top:5px">
                        <asp:HyperLink NavigateUrl="/Cadastros/Custos/Cadastro" runat="server" asp-route-id="@cu_id" title="Editar Despesa" class="btn btn-primary">Novo Custo</asp:HyperLink>
                    </div>
                <div class="card-body">
                    <div class="col-sm-offset-1 col-sm-10" style="width:100%">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="GrdCustos" runat="server" AutoGenerateColumns="false" class="table table-bordered table-hover table-striped w-100" AlternatingRowStyle-HorizontalAlign="Left" DataKeyNames="cu_id" AllowSorting="True" OnSorting="GrdCustos_Sorting" OnRowCommand="GrdCustos_RowCommand" AllowPaging="True" onpageindexchanging="GrdCustos_PageIndexChanging" PageSize="11">
                                    <Columns>
                                        <asp:BoundField DataField="cu_codigo" HeaderText="Código" SortExpression="cu_codigo"/>
                                        <asp:BoundField DataField="cu_descricao" HeaderText="Descrição" SortExpression="cu_descricao"/>  
                                        <asp:ButtonField ButtonType="Image" CommandName="Editar" ItemStyle-Width="60px" ImageUrl="~/Content/images/lapisP.png"></asp:ButtonField>
                                        <asp:ButtonField ButtonType="Image" CommandName="Excluir" ItemStyle-Width="60px" ImageUrl="~/Content/images/lixeiraP.png"></asp:ButtonField>
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
</div>
    </div>
</asp:Content>
