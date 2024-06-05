<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Etapas.aspx.cs" Inherits="Orcamento.Projeto.Fases.Etapas1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="../../Content/bootstrap.min.css">
    <script src="../../Content/js/jquery-3.3.1.min.js"></script>
    <script src="../../Content/js/bootstrap.min.js"></script>
<div class="panel" id="Etapas">
        <asp:Label ID="lblProjeto" runat="server" Text="" Visible="false"></asp:Label>
        <asp:Label ID="lblTotal" runat="server" Text="" Visible="false"></asp:Label>
    <div class="panel-container show">
        <div class="panel-content">

            <div class="card text-left" style="background-color:#000438">
                    <div class="card-header text-center">
                        <div class="container">
                            <div class="row">
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
                            </div>
                            <div class="col-sm" style="color:white">
                                Profissionais
                            </div>
                            <div class="col-sm" style="color:white">
                                Despesas Administrativas
                            </div>
                            <div class="col-sm" style="color:white">
                                Custos
                            </div>
                            <div class="col-sm" style="color:red">
                                Etapas
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
                    </div>
                </div>
            <div class="col-12 text-left" style="margin-top:5px"></div>
            <div class="card-body">
                <div class="col-sm-offset-1 col-sm-10">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="GrdEtapas" runat="server" AutoGenerateColumns="False" class="table table-bordered table-hover table-striped w-100" AlternatingRowStyle-HorizontalAlign="Left" DataKeyNames="id" ShowFooter="True" OnRowCancelingEdit="GrdEtapas_RowCancelingEdit" OnRowEditing="GrdEtapas_RowEditing" OnRowUpdating="GrdEtapas_RowUpdating" AllowPaging="True" onpageindexchanging="GrdEtapas_PageIndexChanging" PageSize="12">
                                <Columns>
                                    <asp:TemplateField HeaderText="Etapas">
                                        <ItemTemplate>
                                            <asp:Label ID="et_descricao" runat="server" Text='<%#Eval("et_descricao") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Horas">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_hora_previsto" runat="server" Text='<%#Eval("pe_hora_previsto")%>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txt_hora_previsto" runat="server" Text='<%#Eval("pe_hora_previsto") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>                                    
                                    <asp:TemplateField HeaderText="Minutos">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_minuto_previsto" runat="server" Text='<%#Eval("pe_minuto_previsto") %>' MaxLength="2"></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txt_minuto_previsto" runat="server" Text='<%#Eval("pe_minuto_previsto") %>' MaxLength="2"></asp:TextBox>
<%--<asp:RangeValidator id="Range1"
           ControlToValidate="txt_minuto_previsto"
           MinimumValue="0"
           MaximumValue="59"
           Type="Integer"
           EnableClientScript="false"
           Text='<%#Eval("pe_minuto_previsto") %>' 
           MaxLength="2"
           runat="server"/>--%>

                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="% Etapas Total">
                                        <ItemTemplate>
                                            <asp:Label ID="percentual" runat="server" Text='<%#string.Format("{0:P2}",Eval("percentual"))%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btn_Edit"  runat="server" ImageUrl="~/Content/images/lapis.png" CommandName="Edit" ToolTip="Pressione Para Editar">
                                            </asp:ImageButton>
<%--                                            <asp:Button ID="btn_Edit" runat="server" CommandName="Edit" Text="Editar" />--%>
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
                            <asp:PostBackTrigger ControlID="GrdEtapas" />
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
                        <button type="button" ID="BtnObservacao" style="background-color:#000438; color:white" class="btn btn-primary" data-toggle="modal" data-target="#myModal">Minhas Considerações</button>
                        <!-- Modal -->
                        <div class="modal fade" id="myModal" role="dialog">
                            <div class="modal-dialog">
                                <!-- Modal content-->
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <h3 class="modal-title">Minhas Considerações</h3>
                                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                                    </div>
                                    <div class="modal-body">
                                        <asp:TextBox runat="server" ID="TextBox1" TextMode="MultiLine" rows="10" maxlength="2083" style="width: 100%;"></asp:TextBox>
                                    </div>
                                    <div class="modal-footer">
                                        <asp:Button runat="server" Text="Salvar" OnClick="btnSalvarOBS_Click" class="btn btn-primary btnPrimary"></asp:Button>
                                        <asp:Button runat="server" class="btn btn-secondary btnSecundary" data-dismiss="modal" Text="Fechar"></asp:Button>
                                    </div>
                                </div>

                            </div>
                        </div>
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
