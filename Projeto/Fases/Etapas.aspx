<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Etapas.aspx.cs" Inherits="Orcamento.Projeto.Fases.Etapas1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="panel" id="Etapas">
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
                    <div class="col-sm" style="color:red">
                        Custos
                    </div>
                    <div class="col-sm" style="color:white">
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
                    <div class="col-sm">
                    </div>
                    </div>
                </div>
            </div>
            <div class="card-body">
                <div class="col-sm-offset-1 col-sm-10">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="GrdEtapas" runat="server" AutoGenerateColumns="False" DataKeyNames="id" OnRowCancelingEdit="GrdEtapas_RowCancelingEdit" OnRowEditing="GrdEtapas_RowEditing" OnRowUpdating="GrdEtapas_RowUpdating">
                                <Columns>
                                    <asp:TemplateField HeaderText="Etapas">
                                        <ItemTemplate>
                                            <asp:Label ID="et_descricao" runat="server" Text='<%#Eval("et_descricao") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Horas Previstas">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_hora_previsto" runat="server" Text='<%#Eval("pe_hora_previsto") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txt_hora_previsto" runat="server" Text='<%#Eval("pe_hora_previsto") %>'></asp:TextBox>
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
