<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="Orcamento.Account.Manage" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
<div class="panel" id="Cadastro">
    <div class="panel-container show">
        <div class="panel-content">
            <div class="row">

                 <div class="card text-left" style="background-color:#000438">
                        <div class="card-header text-center">
                        <h3>Alterar as configurações de conta</h3>
                        </div>
                    </div>

            <div>
                <asp:PlaceHolder runat="server" ID="successMessage" Visible="false" ViewStateMode="Disabled">
                    <p class="text-success"><%: SuccessMessage %></p>
                </asp:PlaceHolder>
            </div>


            <div class="col-md-12">
                <div class="row">
                    <hr />
                    <dl class="dl-horizontal">
                        <dt>Senha:</dt>
                        <dd>
                            <asp:HyperLink NavigateUrl="/Account/ManagePassword" Text="[Alterar]" Visible="false" ID="ChangePassword" runat="server"/>
                            <asp:HyperLink NavigateUrl="/Account/ManagePassword" Text="[Create]" Visible="false" ID="CreatePassword" runat="server" />
                        </dd>
                        <%--
                            Phone Numbers can used as a second factor of verification in a two-factor authentication system.
                            See <a href="https://go.microsoft.com/fwlink/?LinkId=403804">this article</a>
                            for details on setting up this ASP.NET application to support two-factor authentication using SMS.
                            Uncomment the following blocks after you have set up two-factor authentication
                        --%>
                        <dt>Telefone de Contato:
                        <% if (HasPhoneNumber)
                            { %>
                        <dd>
                            <asp:HyperLink NavigateUrl="/Account/AddPhoneNumber" runat="server" Text="[Adicionar]" />
                        </dd>
                        <% }
                            else
                            { %>
                        <dd>
                            <asp:Label Text="" ID="PhoneNumber" runat="server" />
                            <asp:HyperLink NavigateUrl="/Account/AddPhoneNumber" runat="server" Text="[Alterar]" /> &nbsp;|&nbsp;
                            <asp:LinkButton Text="[Remover]" OnClick="RemovePhone_Click" runat="server" />
                        </dd>
                        <% } %>
                        <!-- <dt>Autenticação de dois fatores:</dt> -->
                        <dd>
                            <!--
                            <p>
                                Não há provedores de autenticação de dois fatores configurados. Consulte <a href="https://go.microsoft.com/fwlink/?LinkId=403804">este artigo</a>
                                para obter detalhes sobre como configurar este aplicativo ASP.NET para dar suporte à autenticação de dois fatores.
                            </p>
                            -->
                            <% if (TwoFactorEnabled)
                                { %> 
                            <%--
                            Enabled
                            <asp:LinkButton Text="[Disable]" runat="server" CommandArgument="false" OnClick="TwoFactorDisable_Click" />
                            --%>
                            <% }
                                else
                                { %> 
                            <%--
                            Disabled
                            <asp:LinkButton Text="[Enable]" CommandArgument="true" OnClick="TwoFactorEnable_Click" runat="server" />
                            --%>
                            <% } %>
                        </dd>
                    </dl>
                </div>
            </div>
          </div>
    </div>
 </div>
</div>
</asp:Content>
