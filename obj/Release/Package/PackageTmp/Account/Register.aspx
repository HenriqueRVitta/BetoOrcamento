<%@ Page Title="Registre-se" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Orcamento.Account.Register" %>

<%@ Import Namespace="Orcamento" %>
<%@ Import Namespace="Microsoft.AspNet.Identity" %>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

<div class="row">
      <div class="col-sm-6">
        <div class="card mb-3">
          <div class="card-body">
                    <h2 id="title"><%: Title %>.</h2>
                    <p class="text-danger">
                        <asp:Literal runat="server" ID="Literal1" />
                    </p>
                        <h4>Criar uma nova conta</h4>
                        <hr />
                        <asp:ValidationSummary runat="server" CssClass="text-danger" />
                        <div class="row">
                            <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 col-form-label">E-mail</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="TextBox1" CssClass="form-control" TextMode="Email" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                                    CssClass="text-danger" ErrorMessage="O campo e-mail é exigido." />
                            </div>
                        </div>
                        <div class="row">
                            <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 col-form-label">Senha</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="TextBox2" TextMode="Password" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                                    CssClass="text-danger" ErrorMessage="O campo senha é obrigatório." />
                            </div>
                        </div>
                        <div class="row">
                            <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-2 col-form-label">Confirmar senha</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="TextBox3" TextMode="Password" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                                    CssClass="text-danger" Display="Dynamic" ErrorMessage="O campo para confirmar senha é obrigatório." />
                                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                                    CssClass="text-danger" Display="Dynamic" ErrorMessage="A senha e a senha de confirmação não coincidem." />
                            </div>
                        </div>
                        <div class="row">
                            <div class="offset-md-2 col-md-10">
                                <asp:Button runat="server" OnClick="CreateUser_Click" Text="Registre-se" CssClass="btn btn-primary" />
                            </div>
                        </div>
            </div>
          </div>
        </div>
      <div class="col-sm-6">
        <div class="card text-dark bg-light mb-3" style="max-width: 20rem;">
         <div class="card-header"><h4>A senha deve conter</h4></div>
              <div class="card-body" style="color:green;">
                <p class="card-text">Mínimo de 8 caracteres</p>
                <p class="card-text">Máximo de 16 caracteres</p>
                <p class="card-text">Pelo menos um caractere maiúsculo</p>
                <p class="card-text">Um número</p>
                <p class="card-text">Um caractere especial</p>
              </div>
        </div>
      </div>
</div>

<!--
<div class="container-fluid col-7">
    <div class="card" style="border-radius: 25px;">
        <div class="card-body">
        <section>
            <main aria-labelledby="title">
                <h2 id="title"><%: Title %>.</h2>
                <p class="text-danger">
                    <asp:Literal runat="server" ID="ErrorMessage" />
                </p>
                    <h4>Criar uma nova conta</h4>
                    <hr />
                    <asp:ValidationSummary runat="server" CssClass="text-danger" />
                    <div class="row">
                        <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 col-form-label">E-mail</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                                CssClass="text-danger" ErrorMessage="O campo e-mail é exigido." />
                        </div>
                    </div>
                    <div class="row">
                        <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 col-form-label">Senha</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                                CssClass="text-danger" ErrorMessage="O campo senha é obrigatório." />
                        </div>
                    </div>
                    <div class="row">
                        <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-2 col-form-label">Confirmar senha</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                                CssClass="text-danger" Display="Dynamic" ErrorMessage="O campo para confirmar senha é obrigatório." />
                            <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                                CssClass="text-danger" Display="Dynamic" ErrorMessage="A senha e a senha de confirmação não coincidem." />
                        </div>
                    </div>
                    <div class="row">
                        <div class="offset-md-2 col-md-10">
                            <asp:Button runat="server" OnClick="CreateUser_Click" Text="Registre-se" CssClass="btn btn-primary" />
                        </div>
                    </div>
                </div>
            </main>
        </section>
        </div>
    </div>
</div>

 -->
</asp:Content>
