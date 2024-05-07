using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Orcamento.Cadastros.Custos
{
    public partial class Lista : System.Web.UI.Page
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Carrega();
            }
        }

        public void Carrega()
        {
            con.Open();

            string Sel = "select * from tb_custos order by cu_codigo";
            MySqlCommand qrySelect = new MySqlCommand(Sel, con);
            DataTable dataTable = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(qrySelect);
            da.Fill(dataTable);

            Session["TaskTable"] = dataTable;
            GrdCustos.DataSource = dataTable;
            GrdCustos.DataBind();
            ViewState["dirState"] = dataTable;
            ViewState["sortdr"] = "Asc";

            qrySelect.Dispose();

            con.Close();
        }
        protected void GrdCustos_Sorting(object sender, GridViewSortEventArgs e)
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
                GrdCustos.DataSource = dt;
                GrdCustos.DataBind();
            }
        }
        protected void GrdCustos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdCustos.PageIndex = e.NewPageIndex;
            BindData();
        }
        private void BindData()
        {
            GrdCustos.DataSource = Session["TaskTable"];
            GrdCustos.DataBind();
        }

        protected void GrdCustos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandArgument.ToString() != "First" && e.CommandArgument.ToString() != "Next" && e.CommandArgument.ToString() != "Prev" && e.CommandArgument.ToString() != "Last" && e.CommandArgument.ToString() != "cu_codigo" && e.CommandArgument.ToString() != "cu_descricao")
            {
                if (Convert.ToInt16(e.CommandArgument.ToString()) >= 0)
                {
                    string id = Convert.ToString(GrdCustos.DataKeys[Convert.ToInt32(e.CommandArgument)].Value);

                    if (e.CommandName.CompareTo("Editar") == 0)
                    {
                        Response.Redirect("~/Cadastros/Custos/Cadastro.aspx?ID=" + id);

                    }
                    else
                    {
                        if (e.CommandName.CompareTo("Excluir") == 0)
                        {
                            Response.Redirect("~/Cadastros/Custos/Excluir.aspx?ID=" + id);
                        }
                    }
                }
            }
        }
    }
}