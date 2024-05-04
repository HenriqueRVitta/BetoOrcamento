<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Custos.aspx.cs" Inherits="Orcamento.Projeto.Fases.Custos1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="panel" id="Custos">
        <asp:Label ID="lblProjeto" runat="server" Text="" Visible="false"></asp:Label>
    <div class="panel-container show">
        <div class="panel-content">
            <div class="row">
                <div class="container">
                    <div class="row" style="background-color:#000438">
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
                    <div class="col-sm">
                    </div>
                    </div>
                </div>
                <div class="container">
                <div class="row" style="background-color:#000438">
                    <div class="col-sm">
                    </div>
                    <div class="col-sm" style="color:red">
                        Despesas Administrativas
                    </div>
                    <div class="col-sm" style="color:white">
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
                    <div class="col-sm">
                    </div>
                    </div>
                </div>
            </div>
            <div class="card-body">
                <div class="col-sm-offset-1 col-sm-10">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="GrdCustos" runat="server" AutoGenerateColumns="False" DataKeyNames="id" OnRowCancelingEdit="GrdCustos_RowCancelingEdit" OnRowEditing="GrdCustos_RowEditing" OnRowUpdating="GrdCustos_RowUpdating">
                                <Columns>
                                    <asp:TemplateField HeaderText="Custos">
                                        <ItemTemplate>
                                            <asp:Label ID="cu_descricao" runat="server" Text='<%#Eval("cu_descricao") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Valor Mensal">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_valor_previsto" runat="server" Text='<%#Eval("pc_valor_previsto") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txt_valor_previsto" runat="server" Text='<%#Eval("pc_valor_previsto") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Button ID="btn_Edit" runat="server" CommandName="Edit" Text="Editar" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:Button ID="btn_Update" runat="server" CommandName="Update" Text="Alterar" />
                                            <asp:Button ID="btn_Cancel" runat="server" CommandName="Cancel" Text="Cancelar" />
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
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
