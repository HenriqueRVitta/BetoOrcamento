using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using Orcamento.Models;

namespace Orcamento.Account
{
    public partial class AddPhoneNumber : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var phonenumber = Request.QueryString["PhoneNumber"];
            var tokenFone = manager.GenerateChangePhoneNumberToken(User.Identity.GetUserId(), phonenumber);
            Code.Value = tokenFone;
            var user = manager.FindById(User.Identity.GetUserId());
        }


        protected void PhoneNumber_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();

            var user = manager.FindById(User.Identity.GetUserId());
            user.PhoneNumber = PhoneNumber.Text;
            
            //var user_ = new ApplicationUser() { PhoneNumber = PhoneNumber.Text };

            IdentityResult result = manager.Update(user);
            //var result = manager.ChangePhoneNumber(User.Identity.GetUserId(), PhoneNumber.Text, Code.Value);

            if (result.Succeeded)
            {
                 Response.Redirect("/Account/Manage?m=AddPhoneNumberSuccess");
            }


            // Se chegamos até aqui, algo falhou, reexiba o formulário
            ModelState.AddModelError("", "Falha ao gravar o Telefone de Contato");

            /* Validação do Telefone por sms*/
            /*
            var code = manager.GenerateChangePhoneNumberToken(User.Identity.GetUserId(), PhoneNumber.Text);
            if (manager.SmsService != null)
            {
                var message = new IdentityMessage
                {
                    Destination = PhoneNumber.Text,
                    Body = "Seu código de segurança é " + code
                };

                manager.SmsService.Send(message);
            }

            Response.Redirect("/Account/VerifyPhoneNumber?PhoneNumber=" + HttpUtility.UrlEncode(PhoneNumber.Text));
            */
        }
    }
}