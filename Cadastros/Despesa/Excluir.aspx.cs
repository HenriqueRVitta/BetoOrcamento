using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Web.UI;

namespace Orcamento.Cadastros.Despesa
{
    public partial class Excluir : System.Web.UI.Page
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        int id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ID"] != null)
            {
                id = Convert.ToInt32(Request.QueryString["ID"].ToString());

                con.Open();

                string Sel = "select da_codigo,da_descricao,da_formula,da_hora_trabalhada from tb_despesas where da_id = @id";
                MySqlCommand qrySelect = new MySqlCommand(Sel, con);
                qrySelect.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

                MySqlDataReader reader = qrySelect.ExecuteReader();

                while (reader.Read())
                {
                    da_codigo.Text = reader["da_codigo"].ToString();
                    da_descricao.Text = reader["da_descricao"].ToString();
                    da_formula.Text = reader["da_formula"].ToString();
                    da_hora_trabalhada.Text = reader["da_hora_trabalhada"].ToString();

                    if (reader["da_codigo"].ToString().Substring(0, 2) == "01")
                        pnlFormula_Hora.Visible = true;
                    else
                        pnlFormula_Hora.Visible = false;
                }

                qrySelect.Dispose();

                con.Close();
            }
        }

        protected void btExcluir_Click(object sender, EventArgs e)
        {
            con.Open();

            string Del = "delete from tb_despesas where da_id=@id";
            MySqlCommand qryDelete = new MySqlCommand(Del, con);
            qryDelete.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

            try
            {
                qryDelete.ExecuteNonQuery();

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Mensagem", "alert('Processo Executado Com Sucesso.');", true);
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Mensagem", "alert('Erro no Update de Despesas Administrativas.');", true);
            }
            finally
            {
                qryDelete.Dispose();

                con.Close();
            }

            Response.Redirect("~/Cadastros/Despesa/Lista.aspx");
        }
    }
}