<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Lista.aspx.cs" Inherits="Orcamento.Cadastros.Tipificacao.Lista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="panel" id="Tipologia">
    <div class="panel-container show">
        <div class="panel-content">
            <div class="row" style="width:100%">
                 <div class="card text-left" style="background-color:#000438">
                    <div class="card-header text-center">
                    <h3>Cadastro - Tipologia</h3>
                    </div>
                 </div>
                    <div class="col-12 text-left" style="margin-top:5px">
                        <asp:HyperLink NavigateUrl="/Cadastros/Tipologia/Cadastro" runat="server" asp-route-id="@ti_id" title="Editar Despesa" class="btn btn-primary">Nova Tipologia</asp:HyperLink>
                    </div>
                <div class="card-body">
                    <div class="col-sm-offset-1 col-sm-10" style="width:100%">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="GrdTipologia" runat="server" AutoGenerateColumns="false" class="table table-bordered table-hover table-striped w-100" AlternatingRowStyle-HorizontalAlign="Left" DataKeyNames="ti_id" AllowSorting="True" OnSorting="GrdTipologia_Sorting" OnRowCommand="GrdTipologia_RowCommand" AllowPaging="True" onpageindexchanging="GrdTipologia_PageIndexChanging" PageSize="11">
                                    <Columns>
                                        <asp:BoundField DataField="ti_descricao" HeaderText="Tipologia" SortExpression="ti_descricao"/>  
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
