using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using Orcamento.Models;

namespace Orcamento.Account
{
    public partial class Register : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var nomeUsuario = NomeDoUsuario.Text;
            var email = Email.Text;
            var senha = Password.Text;
            var telefone = Telefone.Text;

            DateTime today = DateTime.Now;
            DateTime validade = today.AddDays(7);

            var user = new ApplicationUser() { UserName = email, Email = email, NomeDoUsuario = nomeUsuario, PhoneNumber = telefone, DataValidade = validade };
            IdentityResult result = manager.Create(user, senha);
            if (result.Succeeded)
            {
                // Para obter mais informações sobre como habilitar a confirmação da conta e redefinição de senha, visite https://go.microsoft.com/fwlink/?LinkID=320771
                //string code = manager.GenerateEmailConfirmationToken(user.Id);
                //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                //manager.SendEmail(user.Id, "Confirme sua conta", "Confirme sua conta clicando <a href=\"" + callbackUrl + "\">aqui</a>.");

                Session["logado"] = user.NomeDoUsuario;
                Session["IdUser"] = user.Id;

                signInManager.SignIn( user, isPersistent: false, rememberBrowser: false);
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else 
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
                Session["logado"] = null;
                Session["IdUser"] = null;
            }
        }
    }
}