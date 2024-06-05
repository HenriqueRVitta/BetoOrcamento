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
        MySqlConnection con1 = new MySqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
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

                string Sel = "select da_id as codigo,da_descricao as descricao from tb_despesas where LENGTH(da_codigo)=4 and SUBSTRING(da_codigo,1,2)='01' order by da_descricao";
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

                    string Sel = "select pp_profissional,pp_hora_trabalhada,pp_quantidade from tb_projeto_profissional where pp_id = @id";
                    MySqlCommand qrySelect = new MySqlCommand(Sel, con);
                    qrySelect.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

                    MySqlDataReader reader = qrySelect.ExecuteReader();

                    while (reader.Read())
                    {
                        pp_profissional.SelectedValue=reader["pp_profissional"].ToString();
                        pp_valor.Text=reader["pp_hora_trabalhada"].ToString();
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

            con.Open();

            string DelP = "delete from tb_projeto_despesas where pd_projeto=@projeto and pd_despesa=@despesa";
            MySqlCommand qryDeleteP = new MySqlCommand(DelP, con);
            qryDeleteP.Parameters.Add("@projeto", MySqlDbType.Int32).Value = Convert.ToInt32(lblProjeto.Text);
            qryDeleteP.Parameters.Add("@despesa", MySqlDbType.Int32).Value = Convert.ToInt32(pp_profissional.SelectedValue);

            try
            {
                qryDeleteP.ExecuteNonQuery();
            }
            catch
            {
            }
            finally
            {
                qryDeleteP.Dispose();

                con.Close();
            }

            string codigo="";

            con.Open();

            string SelD = "select da_codigo from tb_despesas where da_id=@despesa";
            MySqlCommand qrySelectD = new MySqlCommand(SelD, con);
            qrySelectD.Parameters.Add("@despesa", MySqlDbType.Int32).Value = Convert.ToInt32(pp_profissional.SelectedValue);
            MySqlDataReader readerD = qrySelectD.ExecuteReader();

            while (readerD.Read())
            {
                codigo = readerD["da_codigo"].ToString();
            }

            qrySelectD.Dispose();
            con.Close();

            con.Open();

            string SelV = "select da_id from tb_despesas where da_formula like ('%se#" + codigo + "%')";
            MySqlCommand qrySelectV = new MySqlCommand(SelV, con);
            qrySelectV.Parameters.Add("@despesa", MySqlDbType.Int32).Value = Convert.ToInt32(pp_profissional.SelectedValue);
            MySqlDataReader readerV = qrySelectV.ExecuteReader();

            while (readerV.Read())
            {
                con1.Open();

                string DelN = "delete from tb_projeto_despesas where pd_projeto=@projeto and pd_despesa=@despesa";
                MySqlCommand qryDeleteN = new MySqlCommand(DelN, con1);
                qryDeleteN.Parameters.Add("@projeto", MySqlDbType.Int32).Value = Convert.ToInt32(lblProjeto.Text);
                qryDeleteN.Parameters.Add("@despesa", MySqlDbType.Int32).Value = Convert.ToInt32(readerV["da_id"].ToString());

                try
                {
                    qryDeleteN.ExecuteNonQuery();
                }
                catch
                {
                }
                finally
                {
                    qryDeleteN.Dispose();

                    con1.Close();
                }

            }

            qrySelectV.Dispose();
            con.Close();

            Response.Redirect("~/Escritorio/Projeto/Fases/Profissionais/Lista.aspx?Projeto=" + lblProjeto.Text);

        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Escritorio/Projeto/Fases/Profissionais/Lista.aspx?Projeto=" + lblProjeto.Text);
        }
    }
}