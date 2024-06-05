<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Lista.aspx.cs" Inherits="Orcamento.Cadastros.Preco.Lista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="panel" id="Precos">
    <div class="panel-container show">
        <div class="panel-content">
            <div class="row" style="width:100%">
                 <div class="card text-left" style="background-color:#000438">
                    <div class="card-header text-center">
                    <h3>Cadastro - Lista de Preços</h3>
                    </div>
                 </div>
                    <div class="col-12 text-left" style="margin-top:5px">
                        <asp:HyperLink NavigateUrl="/Cadastros/Preco/Cadastro" runat="server" asp-route-id="@pe_id" title="Editar Preços" class="btn btn-primary">Novo Preço</asp:HyperLink>
                    </div>
                <div class="card-body">
                    <div>
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="GrdPreco" runat="server" AutoGenerateColumns="false" class="table table-bordered table-hover table-striped w-100" AlternatingRowStyle-HorizontalAlign="Left" DataKeyNames="pe_id" AllowSorting="True" OnSorting="GrdPreco_Sorting" OnRowCommand="GrdPreco_RowCommand" AllowPaging="True" onpageindexchanging="GrdPreco_PageIndexChanging" PageSize="11">
                                    <Columns>
                                        <asp:BoundField DataField="pe_meses" HeaderText="Nº Meses" SortExpression="pe_meses"/>
                                        <asp:BoundField DataField="pe_preco" HeaderText="Valor" SortExpression="pe_preco" DataFormatString="{0:c}"/>  
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
</asp:Content>
