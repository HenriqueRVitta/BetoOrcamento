<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Lista.aspx.cs" Inherits="Orcamento.Projeto.Fases.Profissionais.Lista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel" id="Cadastro">
    <asp:Label ID="lblProjeto" runat="server" Text="" Visible="false"></asp:Label>
    <div class="panel-container show">
        <div class="panel-content">
            <div class="row" style="width:100%">
                <div class="card text-left" style="background-color:#000438">
                    <div class="card-header text-center">
                        <div class="container">
                            <div class="row">
                            <div class="col-sm" style="color:white">
                                Escritório
                            </div>
                            <div class="col-sm" style="color:white">
                                Projeto
                            </div>
                            <div class="col-sm">
                            </div>
                            <div class="col-sm">
                            </div>
                            <div class="col-sm">
                            </div>
                            <div class="col-sm">
                            </div>
                            <div class="col-sm">
                            </div>
                            <div class="col-sm">
                            </div>
                            <div style="color:white;width:500px;">
                                <asp:Label ID="LblNome" runat="server" Text=""></asp:Label>
                            </div>
                            </div>
                        </div>
                        <div class="container">
                        <div class="row">
                            <div class="col-sm">
                                &nbsp;
                            </div>
                            <div class="col-sm" style="color:red">
                                Profissionais Alocados Para o Projeto
                            </div>
                            <div class="col-sm" style="color:white">
                                ->
                            </div>
                            <div class="col-sm" style="color:white">
                                Custos do Serviço
                            </div>
                            <div class="col-sm" style="color:white">
                                ->
                            </div>
                            <div class="col-sm" style="color:white">
                                Etapas do Projeto / Horas
                            </div>
                            <div class="col-sm" style="color:white">
                                ->
                            </div>
                            <div class="col-sm" style="color:white">
                                Orçamento
                            </div>
                            <div class="col-sm">
                            </div>
                            <div class="col-sm">
                            </div>
                            </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="card-body">
                <div>
                     <div>
                        <div class="col-12 text-left" style="margin-top:5px">
                            <asp:Button ID="BtnNovo" runat="server" Text="Novo Profissional" class="btn btn-primary" style="background-color:#000438; color:white" OnClick="BtnNovo_Click" />
                        </div>
                        <div class="card-body">
                            <div>
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="GrdProfissional" runat="server" AutoGenerateColumns="false" class="table table-bordered table-hover table-striped w-100" AlternatingRowStyle-HorizontalAlign="Left" DataKeyNames="pp_id,pp_profissional" OnRowCommand="GrdProfissional_RowCommand" AllowPaging="True" onpageindexchanging="GrdProfissional_PageIndexChanging" PageSize="20">
                                            <Columns>
                                                <asp:BoundField DataField="pp_projeto" HeaderText="Projeto"/>
                                                <asp:BoundField DataField="da_descricao" HeaderText="Profissional"/>  
                                                <asp:BoundField DataField="pp_hora_trabalhada" HeaderText="Horas Trabalhadas no Projeto"/>
                                                <asp:BoundField DataField="pp_quantidade" HeaderText="Quantidade"/>  
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
            <div class="container">
                <div class="row">
                <div class="col-sm">
                </div>
                <div class="col-sm">
                </div>
                <div class="col-sm">
                </div>
                <div class="col-sm">
                </div>
                <div class="col-sm">
                </div>
                <div class="col-sm">
                </div>
                <div class="col-sm">
                </div>
                <div class="col-sm">
                </div>
                <div class="col-sm">
                </div>
                </div>
            </div>
            <div class="container">
                <div class="row">
                <div class="col-sm">
                    <asp:Button ID="BtnVolta" runat="server" Text="Fase Anterior" style="background-color:#000438; color:white" class="btn btn-primary" OnClick="BtnVolta_Click"/>
                </div>
                <div class="col-sm">
                </div>
                <div class="col-sm">
                </div>
                <div class="col-sm">
                </div>
                <div class="col-sm">
                </div>
                <div class="col-sm">
                </div>
                <div class="col-sm">
                </div>
                <div class="col-sm">
                </div>
                <div class="col-sm">
                    <asp:Button ID="BtnAvanca" runat="server" Text="Avançar/Gravar" style="background-color:#000438; color:white" class="btn btn-primary" OnClick="BtnAvanca_Click"/>
                </div>
                </div>
            </div>
        </div>
    </div>
</div>
</asp:Content>
