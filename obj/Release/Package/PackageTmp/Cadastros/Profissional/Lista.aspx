<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Lista.aspx.cs" Inherits="Orcamento.Cadastros.Profissional.Lista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel" id="Profissional">
    <div class="panel-container show">
        <div class="panel-content">
            <div class="row" style="width:100%">
             <div class="card text-left">
                <div class="card-header text-center">
                <h3>Cadastro - Lista dos Profissionais</h3>
                </div>
             </div>
                <div class="col-12 text-left">
                    <asp:HyperLink NavigateUrl="/Cadastros/Profissional/Cadastro" runat="server" asp-route-id="@cu_id" title="Editar Despesa" class="btn btn-primary">Novo Profissional</asp:HyperLink>
                </div>
                <div class="card-body">
                    <div>
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="GrdProfissional" runat="server" AutoGenerateColumns="false" class="table table-bordered table-hover table-striped w-100" AlternatingRowStyle-HorizontalAlign="Left" DataKeyNames="pr_id" AllowSorting="True" OnSorting="GrdProfissional_Sorting" OnRowCommand="GrdProfissional_RowCommand" AllowPaging="True" onpageindexchanging="GrdProfissional_PageIndexChanging" PageSize="11">
                                    <Columns>
                                        <asp:BoundField DataField="pr_descricao" HeaderText="Profissão" SortExpression="pr_descricao"/>  
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

    <!-- Adicionado em Default.aspx
    <script src="Content/js/jquery-3.3.1.min.js"></script>
    <script src="Content/js/popper.min.js"></script>
    <script src="Content/js/bootstrap.min.js"></script>
    <script src="Content/js/jquery.sticky.js"></script>
    <script src="Content/js/main.js"></script>
     -->

</asp:Content>
