using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Orcamento.Movimentacao.Criacao
{
    public partial class Lista : System.Web.UI.Page
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());

        public virtual System.Web.UI.WebControls.ButtonType ButtonType { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Carrega();
                con.Open();
            }
        }

        public void Carrega()
        {
            con.Open();

            string Sel = "select * from tb_projetos inner join tb_tipologia on pr_tipologia=ti_id where pr_cliente=1";
            MySqlCommand qrySelect = new MySqlCommand(Sel, con);
            DataTable dataTable = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(qrySelect);
            da.Fill(dataTable);

            Session["TaskTable"] = dataTable;
            GrdProjetos.DataSource = dataTable;
            GrdProjetos.DataBind();
            ViewState["dirState"] = dataTable;
            ViewState["sortdr"] = "Asc";

            qrySelect.Dispose();

            con.Close();

        }
        protected void GrdProjetos_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable dt = Session["TaskTable"] as DataTable;

            if (dt.Rows.Count > 0)
            {
                if (Convert.ToString(ViewState["sortdr"]) == "Asc")
                {
                    dt.DefaultView.Sort = e.SortExpression + " Desc";
                    ViewState["sortdr"] = "Desc";
                }
                else
                {
                    dt.DefaultView.Sort = e.SortExpression + " Asc";
                    ViewState["sortdr"] = "Asc";
                }
                GrdProjetos.DataSource = dt;
                GrdProjetos.DataBind();
            }
        }
        protected void GrdProjetos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdProjetos.PageIndex = e.NewPageIndex;
            BindData();
        }
        private void BindData()
        {
            GrdProjetos.DataSource = Session["TaskTable"];
            GrdProjetos.DataBind();
        }

        protected void GrdProjetos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandArgument.ToString()!="First" && e.CommandArgument.ToString()!="Next" && e.CommandArgument.ToString()!="Prev" && e.CommandArgument.ToString()!="Last" && e.CommandArgument.ToString()!="cu_codigo" && e.CommandArgument.ToString()!="cu_descricao")
            {
                if (Convert.ToInt16(e.CommandArgument.ToString())>=0)
                {
                    string id = Convert.ToString(GrdProjetos.DataKeys[Convert.ToInt32(e.CommandArgument)].Value);

                    if (e.CommandName.CompareTo("Editar") == 0)
                    {
                        Response.Redirect("~/Projeto/Criacao/Cadastro.aspx?ID=" + id);

                    }
                    else
                    {
                        if (e.CommandName.CompareTo("Excluir") == 0)
                        {
                            Response.Redirect("~/Projeto/Criacao/Excluir.aspx?ID=" + id);
                        }
                        else
                        {
                            Response.Redirect("~/Projeto/Fases/Despesas.aspx?Projeto=" + id);
                        }
                    }
                }
            }
        }
    }
}