using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Web.UI;

namespace Orcamento.Cadastros.Tipificacao
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

                string Sel = "select ti_descricao from tb_tipologia where ti_id = @id";
                MySqlCommand qrySelect = new MySqlCommand(Sel, con);
                qrySelect.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

                MySqlDataReader reader = qrySelect.ExecuteReader();

                while (reader.Read())
                {
                    ti_descricao.Text = reader["ti_descricao"].ToString();
                }

                qrySelect.Dispose();

                con.Close();
            }
        }

        protected void btExcluir_Click(object sender, EventArgs e)
        {
            con.Open();

            string Del = "delete from tb_tipologia where ti_id=@id";
            MySqlCommand qryDelete = new MySqlCommand(Del, con);
            qryDelete.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

            try
            {
                qryDelete.ExecuteNonQuery();

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Mensagem", "alert('Processo Executado Com Sucesso.');", true);
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Mensagem", "alert('Erro no Update de Tipologia.');", true);
            }
            finally
            {
                qryDelete.Dispose();

                con.Close();
            }

            Response.Redirect("~/Cadastros/Tipificacao/Lista.aspx");
        }
    }
}