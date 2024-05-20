﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Custos.aspx.cs" Inherits="Orcamento.Projeto.Fases.Custos1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="panel" id="Custos">
        <asp:Label ID="lblProjeto" runat="server" Text="" Visible="false"></asp:Label>
            <asp:Label ID="lblTotal" runat="server" Text="" Visible="false"></asp:Label>
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
                            <div class="col-sm" style="color:red">
                                Profissionais
                            </div>
                            <div class="col-sm" style="color:red">
                                Despesas Administrativas
                            </div>
                            <div class="col-sm"  style="color:white">
                                Custos
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
                    </div>
                </div>
            <div class="col-12 text-left" style="margin-top:5px"></div>

            <div class="card-body">
                <div class="col-sm-offset-1 col-sm-10">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="GrdCustos" runat="server" AutoGenerateColumns="False" class="table table-bordered table-hover table-striped w-100" AlternatingRowStyle-HorizontalAlign="Left" DataKeyNames="id" ShowFooter="True" OnRowCancelingEdit="GrdCustos_RowCancelingEdit" OnRowEditing="GrdCustos_RowEditing" OnRowUpdating="GrdCustos_RowUpdating" AllowPaging="True" onpageindexchanging="GrdCustos_PageIndexChanging" PageSize="12">
                                <Columns>
                                    <asp:TemplateField HeaderText="Custos">
                                        <ItemTemplate>
                                            <asp:Label ID="cu_descricao" runat="server" Text='<%#Eval("cu_descricao") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Valor Mensal">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_valor_previsto" runat="server" Text='<%#string.Format("{0:c}",Eval("pc_valor_previsto"))%>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txt_valor_previsto" runat="server" Text='<%#Eval("pc_valor_previsto")%>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="% Custo Total">
                                        <ItemTemplate>
                                            <asp:Label ID="percentual" runat="server" Text='<%#string.Format("{0:P2}",Eval("percentual")) %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btn_Edit" runat="server" ImageUrl="~/Content/images/lapis.png" CommandName="Edit" ToolTip="Pressione Para Editar">
                                            </asp:ImageButton>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:ImageButton ID="btn_Update" runat="server" CommandName="Update" ImageUrl="~/Content/images/salvar.png" ToolTip="Pressione Para Salvar"/>
                                            <asp:ImageButton ID="btn_Cancel" runat="server" CommandName="Cancel" ImageUrl="~/Content/images/cancel.png" ToolTip="Pressione Para Cancelar"/>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="#CCCC99" />
                                <PagerSettings Position="Bottom" Mode="NextPreviousFirstLast"
                                PreviousPageText="<img src='/Content/images/setasimplesesquerda.png' border='0' title='Página Anterior' class='navpage'/>"
                                NextPageText="<img src='/Content/images/setasimplesdireita.png' border='0' title='Próxima Página' class='navpage'/>"
                                FirstPageText="<img src='/Content/images/setaduplaesquerda.png' border='0' title='Primeira Página' class='navpage'/>"
                                LastPageText="<img src='/Content/images/setadupladireita.png' border='0' title='Última Página' class='navpage'/>" 
                                PageButtonCount="12"/>
                            </asp:GridView>
                        </ContentTemplate>
                       <Triggers>
                            <asp:PostBackTrigger ControlID="GrdCustos" />
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
                    <asp:Button ID="BtnObservacao" runat="server" Text="Observação" style="background-color:#000438; color:white" class="btn btn-primary"/>
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
