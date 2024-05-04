using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Web.UI;

namespace Orcamento.Cadastros.Tipificacao
{
    public partial class Cadastro : System.Web.UI.Page
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        int id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ID"] != null)
            {
                if (!Page.IsPostBack)
                {
                    id  = Convert.ToInt32(Request.QueryString["ID"].ToString());

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
                else
                    id  = Convert.ToInt32(Request.QueryString["ID"].ToString());
            }
            else
                id=0;
        }
        protected void btnSalvar_Click(object sender, System.EventArgs e)
        {
            if (id==0)
            {
                con.Open();

                string Ins = "insert INTO tb_tipologia(ti_descricao) values(@descricao)";
                MySqlCommand qryInsert = new MySqlCommand(Ins, con);
                qryInsert.Parameters.Add("@descricao", MySqlDbType.VarChar, 45).Value = ti_descricao.Text.ToUpper();

                try
                {
                    qryInsert.ExecuteNonQuery();

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Mensagem", "alert('Processo Executado Com Sucesso.');", true);
                }
                catch
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Mensagem", "alert('Erro no Insert Tipologia.');", true);
                }
                finally
                {
                    qryInsert.Dispose();

                    con.Close();
                }
            }
            else
            {
                con.Open();

                string Upd = "update tb_tipologia set ti_descricao=@descricao where ti_id=@id";
                MySqlCommand qryUpdate = new MySqlCommand(Upd, con);
                qryUpdate.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                qryUpdate.Parameters.Add("@descricao", MySqlDbType.VarChar, 45).Value = ti_descricao.Text.ToUpper();

                try
                {
                    qryUpdate.ExecuteNonQuery();

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Mensagem", "alert('Processo Executado Com Sucesso.');", true);
                }
                catch
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Mensagem", "alert('Erro no Update de Tipologia.');", true);
                }
                finally
                {
                    qryUpdate.Dispose();

                    con.Close();
                }
            }

            Response.Redirect("~/Cadastros/Tipologia/Lista.aspx");
        }
    }
}