﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;

namespace Orcamento
{
    public partial class SiteMaster : MasterPage
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;

        protected void Page_Init(object sender, EventArgs e)
        {

            // O código abaixo ajuda a proteger contra ataques XSRF
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Use o token Anti-XSRF do cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Gerar um novo token Anti-XSRF e salvar no cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                // Configurar o token Anti-XSRF
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validar o token Anti-XSRF
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Falha na validação do token Anti-XSRF.");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
            Response.AppendHeader("Refresh",
                        //Session TimeOut é em minutos e o Refresh e segundos, por isso o Session.Timeout * 60
                        String.Concat((Session.Timeout * 60),
                        //Página para onde o usuário será redirecionado
                        ";URL=/Account/Login.aspx"));
            

            

            if (HttpContext.Current.Session["LoggedIn"] != null)
            {
                //CadastroLinkListItem.Visible = true;
                //MovimentacaoLinkListItem.Visible = true;
                //DashboardLinkListItem.Visible = true;
            }
            

            if (Session["logado"] != null)
            {
                //CadastroLinkListItem.Visible = true;
                //MovimentacaoLinkListItem.Visible = true;
                //DashboardLinkListItem.Visible = true;
                //FundoInicial.Style.Value = "";
                //FundoInicial.Attributes.Add("background-color", "#DC143C");

            }

        }

        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Session["logado"] = null;
            Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }
    }

}