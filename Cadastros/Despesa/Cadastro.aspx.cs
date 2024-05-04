using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Orcamento.Cadastros.Despesa
{
    public partial class Cadastro : System.Web.UI.Page
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        int id =0;
        protected void Page_Load(object sender, EventArgs e)
        {
                if (Request.QueryString["ID"] != null)
                {
                    if (!Page.IsPostBack)
                    {
                        id  = Convert.ToInt32(Request.QueryString["ID"].ToString());

                        con.Open();

                        string Sel = "select da_codigo,da_descricao from tb_despesas where da_id = @id";
                        MySqlCommand qrySelect = new MySqlCommand(Sel, con);
                        qrySelect.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

                        MySqlDataReader reader = qrySelect.ExecuteReader();

                        while (reader.Read())
                        {
                            da_codigo.Text = reader["da_codigo"].ToString();
                            da_descricao.Text = reader["da_descricao"].ToString();
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
            if(id==0)
            {
                con.Open();

                string Ins = "insert INTO tb_despesas(da_codigo,da_descricao) values(@codigo,@descricao)";
                MySqlCommand qryInsert = new MySqlCommand(Ins, con);
                qryInsert.Parameters.Add("@codigo", MySqlDbType.VarChar, 6).Value = da_codigo.Text;
                qryInsert.Parameters.Add("@descricao", MySqlDbType.VarChar, 45).Value = da_descricao.Text.ToUpper();

                try
                {
                    qryInsert.ExecuteNonQuery();

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Mensagem", "alert('Processo Executado Com Sucesso.');", true);
                }
                catch
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Mensagem", "alert('Erro no Insert Despesas Administrativas.');", true);
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

                string Upd = "update tb_despesas set da_codigo=@codigo,da_descricao=@descricao where da_id=@id";
                MySqlCommand qryUpdate = new MySqlCommand(Upd, con);
                qryUpdate.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                qryUpdate.Parameters.Add("@codigo", MySqlDbType.VarChar, 6).Value = da_codigo.Text;
                qryUpdate.Parameters.Add("@descricao", MySqlDbType.VarChar, 45).Value = da_descricao.Text.ToUpper();

                try
                {
                    qryUpdate.ExecuteNonQuery();

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Mensagem", "alert('Processo Executado Com Sucesso.');", true);
                }
                catch
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Mensagem", "alert('Erro no Update de Despesas Administrativas.');", true);
                }
                finally
                {
                    qryUpdate.Dispose();

                    con.Close();
                }
            }

            Response.Redirect("~/Cadastros/Despesa/Lista.aspx");
        }
    }
}