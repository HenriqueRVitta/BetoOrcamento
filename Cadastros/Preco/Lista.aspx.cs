using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Orcamento.Cadastros.Preco
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
            }
        }

        public void Carrega()
        {
            con.Open();

            string Sel = "select * from tb_precos";
            MySqlCommand qrySelect = new MySqlCommand(Sel, con);
            DataTable dataTable = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(qrySelect);
            da.Fill(dataTable);

            Session["TaskTable"] = dataTable;
            GrdPreco.DataSource = dataTable;
            GrdPreco.DataBind();
            ViewState["dirState"] = dataTable;
            ViewState["sortdr"] = "Asc";

            qrySelect.Dispose();

            con.Close();
        }
        protected void GrdPreco_Sorting(object sender, GridViewSortEventArgs e)
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
                GrdPreco.DataSource = dt;
                GrdPreco.DataBind();
            }
        }
        protected void GrdPreco_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdPreco.PageIndex = e.NewPageIndex;
            BindData();
        }
        private void BindData()
        {
            GrdPreco.DataSource = Session["TaskTable"];
            GrdPreco.DataBind();
        }

        protected void GrdPreco_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandArgument.ToString()!="First" && e.CommandArgument.ToString()!="Next" && e.CommandArgument.ToString()!="Prev" && e.CommandArgument.ToString()!="Last" && e.CommandArgument.ToString()!="pe_meses" && e.CommandArgument.ToString()!="pe_preco")
            {
                if (Convert.ToInt16(e.CommandArgument.ToString())>=0)
                {
                    string id = Convert.ToString(GrdPreco.DataKeys[Convert.ToInt32(e.CommandArgument)].Value);

                    if (e.CommandName.CompareTo("Editar") == 0)
                    {
                        Response.Redirect("~/Cadastros/Preco/Cadastro.aspx?ID=" + id);

                    }
                    else
                    {
                        if (e.CommandName.CompareTo("Excluir") == 0)
                        {
                            Response.Redirect("~/Cadastros/Preco/Excluir.aspx?ID=" + id);
                        }
                    }
                }
            }
        }
    }
}