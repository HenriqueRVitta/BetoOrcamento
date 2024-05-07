using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Orcamento.Projeto.Fases.Profissionais
{
    public partial class Lista : System.Web.UI.Page
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        int id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Projeto"] != null)
            {
                if (!Page.IsPostBack)
                {

                    lblProjeto.Text=Request.QueryString["Projeto"].ToString();

                    con.Open();

                    string Sel = "select pr_nome from tb_projetos where pr_id=@projeto";
                    MySqlCommand qrySelect = new MySqlCommand(Sel, con);
                    qrySelect.Parameters.Add("@projeto", MySqlDbType.Int32).Value = Convert.ToInt32(lblProjeto.Text);
                    MySqlDataReader reader = qrySelect.ExecuteReader();

                    while (reader.Read())
                    {
                        LblNome.Text=reader["pr_nome"].ToString();
                    }

                    qrySelect.Dispose();
                    con.Close();


                    Carrega();
                }
            }
        }
        public void Carrega()
        {
            con.Open();

            string Sel = "select pp_id,pp_projeto,pp_profissional,pp_valor,pp_quantidade,da_descricao from tb_projeto_profissional inner join tb_despesas on pp_profissional=da_id where pp_projeto=@projeto";
            MySqlCommand qrySelect = new MySqlCommand(Sel, con);
            qrySelect.Parameters.Add("@projeto", MySqlDbType.Int32).Value = Convert.ToInt32(lblProjeto.Text);
            DataTable dataTable = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(qrySelect);
            da.Fill(dataTable);
            GrdProfissional.DataSource = dataTable;
            GrdProfissional.DataBind();

            qrySelect.Dispose();

            con.Close();
        }
        protected void GrdProfissional_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdProfissional.PageIndex = e.NewPageIndex;
            Carrega();
        }
        protected void GrdProfissional_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandArgument.ToString()!="First" && e.CommandArgument.ToString()!="Next" && e.CommandArgument.ToString()!="Prev" && e.CommandArgument.ToString()!="Last")
            {
                if (Convert.ToInt16(e.CommandArgument.ToString())>=0)
                {
                    string id = Convert.ToString(GrdProfissional.DataKeys[Convert.ToInt32(e.CommandArgument)].Value);

                    if (e.CommandName.CompareTo("Editar") == 0)
                    {
                        Response.Redirect("~/Projeto/Fases/Profissionais/Cadastro.aspx?Projeto=" + lblProjeto.Text+"&ID="+id);
                    }
                    else
                    {
                        if (e.CommandName.CompareTo("Excluir") == 0)
                        {
                            Response.Redirect("~/Projeto/Fases/Profissionais/Excluir.aspx?Projeto=" + lblProjeto.Text+"&ID="+id);
                        }
                    }
                }
            }
        }
        protected void BtnVolta_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Projeto/Criacao/Lista.aspx");
        }

        protected void BtnAvanca_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Projeto/Fases/Despesas.aspx?Projeto="+lblProjeto.Text);
        }

        protected void BtnNovo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Projeto/Fases/Profissionais/Cadastro.aspx?Projeto=" + lblProjeto.Text);
        }
    }
}