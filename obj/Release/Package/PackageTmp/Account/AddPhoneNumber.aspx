<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddPhoneNumber.aspx.cs" Inherits="Orcamento.Account.AddPhoneNumber" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../Scripts/jquery-mask.js"></script>

    <main aria-labelledby="title">

        <div class="card text-left" style="background-color:#000438">
            <div class="card-header text-center">
            <h3>Adcionar Telefone de Contato</h3>
            </div>
        </div>

        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <p class="text-danger">
            <asp:Literal runat="server" ID="ErrorMessage" />
        </p>
        <asp:HiddenField runat="server" ID="Code" />

        <div class="row">
            <asp:Label runat="server" AssociatedControlID="Code" CssClass="col-md-2 col-form-label">Número de telefone</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="PhoneNumber" CssClass="form-control" TextMode="Phone" placeholder="(__)_____-______" onkeyup="maskIt(this,event,'(##)#####-###############')"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="PhoneNumber"
                    CssClass="text-danger" ErrorMessage="O campo Telefone de Contato é obrigatório." />
            </div>
        </div>
        <div class="form-group">
            <div class="offset-md-2 col-md-10">
               <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="PhoneNumber_Click" class="btn btn-primary btnPrimary" />
               <asp:HyperLink NavigateUrl="/Account/Manage" runat="server" title="Voltar" class="btn btn-secondary btnSecundary">Voltar</asp:HyperLink>
            </div>
        </div>
</main>
</asp:Content>
