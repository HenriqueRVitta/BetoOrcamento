using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Orcamento.Projeto.Fases
{
    public partial class Profissionais1 : System.Web.UI.Page
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        int id = 0;
        internal DataTable dtb = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ID"] != null)
            {
                if (!Page.IsPostBack)
                {
                    id  = Convert.ToInt32(Request.QueryString["ID"].ToString());
                    lblProjeto.Text=Request.QueryString["ID"].ToString();
                }
            }
        }

        protected void BtnVolta_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Projeto/Fases/Etapas.aspx?ID=" + lblProjeto.Text);
        }

        protected void BtnAvanca_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Projeto/Fases/Resultado.aspx?ID=" + lblProjeto.Text);
        }
    }
}