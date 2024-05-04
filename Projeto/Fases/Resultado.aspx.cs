using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Web.UI;

namespace Orcamento.Projeto.Fases
{
    public partial class Resultado : System.Web.UI.Page
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Projeto"] != null)
            {
                if (!Page.IsPostBack)
                {
                    lblProjeto.Text=Request.QueryString["Projeto"].ToString();
                }
            }
        }
        protected void BtnVolta_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Projeto/Fases/Profissionais/Lista.aspx?Projeto=" + lblProjeto.Text);
        }

    }
}