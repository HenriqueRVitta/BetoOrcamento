<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Despesas04.aspx.cs" Inherits="Orcamento.Escritorio.Despesas.Despesas04" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
            <link rel="stylesheet" href="../../Content/bootstrap.min.css">
    <script src="../../Content/js/jquery-3.3.1.min.js"></script>
    <script src="../../Content/js/bootstrap.min.js"></script>

<div class="panel" id="Despesas">
        <asp:Label ID="lblCliente" runat="server" Text="" Visible="false"></asp:Label>
        <asp:Label ID="lblTotal" runat="server" Text="" Visible="false"></asp:Label>
            <div class="card text-left" style="background-color:#000438">
                    <div class="card-header text-center">
                        <div class="container">
                            <div class="row">
                            <div class="col-sm" style="color:white;">
                                Escritório
                            </div>
                            <div class="col-sm" style="color:white;">
                                Despesas
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
                            </div>
                            <div class="col-sm" style="color:white">
                                <asp:Label ID="lblDespesa1" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="col-sm" style="color:white">
                                <asp:Label ID="lblSeta1" runat="server" Text="->"></asp:Label>
                            </div>
                             <div class="col-sm" style="color:white">
                                <asp:Label ID="lblDespesa2" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="col-sm" style="color:white">
                                <asp:Label ID="lblSeta2" runat="server" Text="->"></asp:Label>
                            </div>
                             <div class="col-sm" style="color:white">
                                <asp:Label ID="lblDespesa3" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="col-sm" style="color:white">
                                <asp:Label ID="lblSeta3" runat="server" Text="->"></asp:Label>
                            </div>
                             <div class="col-sm" style="color:red">
                                <asp:Label ID="lblDespesa4" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="col-sm" style="color:white">
                                <asp:Label ID="lblSeta4" runat="server" Text="->"></asp:Label>
                            </div>
                             <div class="col-sm" style="color:white">
                                <asp:Label ID="lblDespesa5" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="col-sm" style="color:white">
                                <asp:Label ID="lblSeta5" runat="server" Text="->"></asp:Label>
                            </div>
                            <div class="col-sm" style="color:white">
                                <asp:Label ID="lblDespesa6" runat="server" Text=""></asp:Label>
                            </div>
                            </div>
                        </div>
                    </div>
                </div>
            <div class="col-12 text-left" style="margin-top:5px"></div>

            <div class="card-body">
                <div>
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="GrdDespesas" runat="server" AutoGenerateColumns="False" class="table table-bordered table-hover table-striped w-100" AlternatingRowStyle-HorizontalAlign="Left" DataKeyNames="id,da_codigo,da_formula" ShowFooter="True" OnRowCancelingEdit="GrdDespesas_RowCancelingEdit" OnRowEditing="GrdDespesas_RowEditing" OnRowUpdating="GrdDespesas_RowUpdating" AllowPaging="True" onpageindexchanging="GrdDespesas_PageIndexChanging" PageSize="12" OnRowDataBound="GrdDespesas_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="Despesa Administrativa">
                                        <ItemTemplate>
                                            <asp:Label ID="da_descricao" runat="server" Text='<%#Eval("da_descricao") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Valor Mensal">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_valor_previsto" runat="server" Text='<%#string.Format("{0:c}",Eval("pd_valor_previsto"))%>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txt_valor_previsto" runat="server" Text='<%#Eval("pd_valor_previsto")%>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="% Despesas Administrativas Total">
                                        <ItemTemplate>
                                            <asp:Label ID="percentual" runat="server" Text='<%#string.Format("{0:P2}",Eval("percentual"))%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Alterar">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btn_Edit" runat="server" Visible="false" ImageUrl="~/Content/images/lapis.png" CommandName="Edit" ToolTip="Pressione Para Editar">
                                            </asp:ImageButton>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:ImageButton ID="btn_Update" runat="server" CommandName="Update" ImageUrl="~/Content/images/salvar.png" ToolTip="Pressione Para Salvar" />
                                            <asp:ImageButton ID="btn_Cancel" runat="server" CommandName="Cancel" ImageUrl="~/Content/images/cancel.png" ToolTip="Pressione Para Cancelar"/>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="#CCCC99" />
                                <PagerSettings Position="Bottom" Mode="NextPrevious"
                                PreviousPageText="<img src='/Content/images/setasimplesesquerda.png' border='0' title='Página Anterior' class='navpage'/>"
                                NextPageText="<img src='/Content/images/setasimplesdireita.png' border='0' title='Próxima Página' class='navpage'/>"
                                PageButtonCount="11"/>
                            </asp:GridView>
                        </ContentTemplate>
                       <Triggers>
                            <asp:PostBackTrigger ControlID="GrdDespesas" />
                       </Triggers>
                    </asp:UpdatePanel>
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
</asp:Content>
