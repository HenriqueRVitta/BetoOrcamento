using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Orcamento.Projeto.Fases.Profissionais
{
    public partial class Excluir : System.Web.UI.Page
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        int id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["Projeto"] != null)
                {
                    lblProjeto.Text=Request.QueryString["Projeto"].ToString();

                    con.Open();

                    string SelN = "select pr_nome from tb_projetos where pr_id=@projeto";
                    MySqlCommand qrySelectN = new MySqlCommand(SelN, con);
                    qrySelectN.Parameters.Add("@projeto", MySqlDbType.Int32).Value = Convert.ToInt32(lblProjeto.Text);
                    MySqlDataReader readerN = qrySelectN.ExecuteReader();

                    while (readerN.Read())
                    {
                        LblNome.Text=readerN["pr_nome"].ToString();
                    }

                    qrySelectN.Dispose();
                    con.Close();
                }

                con.Open();

                string Sel = "Select pr_id as codigo,pr_descricao as descricao from tb_profissional order by pr_descricao";
                MySqlCommand qrySelect = new MySqlCommand(Sel, con);
                MySqlDataReader reader = qrySelect.ExecuteReader();

                pp_profissional.DataSource = reader;
                pp_profissional.DataTextField = "descricao";
                pp_profissional.DataValueField = "codigo";
                pp_profissional.DataBind();
                pp_profissional.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Selecione o Profissional.", ""));

                qrySelect.Dispose();

                con.Close();
            }

            if (Request.QueryString["ID"] != null)
            {
                if (!Page.IsPostBack)
                {
                    id  = Convert.ToInt32(Request.QueryString["ID"].ToString());

                    con.Open();

                    string Sel = "select pp_profissional,pp_valor,pp_quantidade from tb_projeto_profissional where pp_id = @id";
                    MySqlCommand qrySelect = new MySqlCommand(Sel, con);
                    qrySelect.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

                    MySqlDataReader reader = qrySelect.ExecuteReader();

                    while (reader.Read())
                    {
                        pp_profissional.SelectedValue=reader["pp_profissional"].ToString();
                        pp_valor.Text=reader["pp_valor"].ToString();
                        pp_quantidade.Text=reader["pp_quantidade"].ToString();
                    }

                    qrySelect.Dispose();

                    con.Close();
                }
                else
                    id  = Convert.ToInt32(Request.QueryString["ID"].ToString());
            }
            else
                id=0;
        }

        protected void btExcluir_Click(object sender, EventArgs e)
        {
            con.Open();

            string Del = "delete from tb_projeto_profissional where pp_id=@id";
            MySqlCommand qryDelete = new MySqlCommand(Del, con);
            qryDelete.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

            try
            {
                qryDelete.ExecuteNonQuery();
            }
            catch
            {
            }
            finally
            {
                qryDelete.Dispose();

                con.Close();
            }

            Response.Redirect("~/Projeto/Fases/Profissionais/Lista.aspx");
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Projeto/Fases/Profissionais/Lista.aspx?Projeto=" + lblProjeto.Text);
        }
    }
}