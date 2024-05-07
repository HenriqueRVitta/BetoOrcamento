<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Lista.aspx.cs" Inherits="Orcamento.Cadastros.Despesa.Lista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="panel" id="Despesas">
    <div class="panel-container show">
        <div class="panel-content">
            <div class="row" style="width:100%">
                 <div class="card text-left">
                    <div class="card-header text-center">
                    <h3>Cadastro - Lista Despesas Administrativas</h3>
                    </div>
                 </div>
                    <div class="col-12 text-left" style="margin-top:5px">
                        <asp:HyperLink NavigateUrl="/Cadastros/Despesa/Cadastro" runat="server" asp-route-id="@da_id" title="Editar Despesas Administrativas" class="btn btn-primary">Nova Despesa</asp:HyperLink>
                    </div>
                <div class="card-body">
                    <div>
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="GrdDespesas" runat="server" AutoGenerateColumns="false" class="table table-bordered table-hover table-striped w-100" AlternatingRowStyle-HorizontalAlign="Left" DataKeyNames="da_id" AllowSorting="True" OnSorting="GrdDespesas_Sorting" OnRowCommand="GrdDespesas_RowCommand" AllowPaging="True" onpageindexchanging="GrdDespesas_PageIndexChanging" PageSize="11">
                                    <Columns>
                                        <asp:BoundField DataField="da_codigo" HeaderText="Código" SortExpression="da_codigo"/>
                                        <asp:BoundField DataField="da_descricao" HeaderText="Descrição" SortExpression="da_descricao"/>  
                                        <asp:BoundField DataField="da_formula" HeaderText="Formula" SortExpression="da_formula"/>  
                                        <asp:ButtonField ButtonType="Image" CommandName="Editar" ItemStyle-Width="60px" ImageUrl="~/Content/images/lapisP.png"></asp:ButtonField>
                                        <asp:ButtonField ButtonType="Image" CommandName="Excluir" ItemStyle-Width="60px" ImageUrl="~/Content/images/lixeiraP.png"></asp:ButtonField>
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