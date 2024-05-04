using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Orcamento.Cadastros.Custos
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

                    string Sel = "select cu_codigo,cu_descricao from tb_custos where cu_id = @id";
                    MySqlCommand qrySelect = new MySqlCommand(Sel, con);
                    qrySelect.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

                    MySqlDataReader reader = qrySelect.ExecuteReader();

                    while (reader.Read())
                    {
                        cu_codigo.Text = reader["cu_codigo"].ToString();
                        cu_descricao.Text = reader["cu_descricao"].ToString();
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

                string Ins = "insert INTO tb_custos(cu_codigo,cu_descricao) values(@codigo,@descricao)";
                MySqlCommand qryInsert = new MySqlCommand(Ins, con);
                qryInsert.Parameters.Add("@codigo", MySqlDbType.VarChar, 6).Value = cu_codigo.Text;
                qryInsert.Parameters.Add("@descricao", MySqlDbType.VarChar, 45).Value = cu_descricao.Text.ToUpper();

                try
                {
                    qryInsert.ExecuteNonQuery();

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Mensagem", "alert('Processo Executado Com Sucesso.');", true);
                }
                catch
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Mensagem", "alert('Erro no Insert Custos.');", true);
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

                string Upd = "update tb_custos set cu_codigo=@codigo,cu_descricao=@descricao where cu_id=@id";
                MySqlCommand qryUpdate = new MySqlCommand(Upd, con);
                qryUpdate.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                qryUpdate.Parameters.Add("@codigo", MySqlDbType.VarChar, 6).Value = cu_codigo.Text;
                qryUpdate.Parameters.Add("@descricao", MySqlDbType.VarChar, 45).Value = cu_descricao.Text.ToUpper();

                try
                {
                    qryUpdate.ExecuteNonQuery();

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Mensagem", "alert('Processo Executado Com Sucesso.');", true);
                }
                catch
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Mensagem", "alert('Erro no Update de Custos.');", true);
                }
                finally
                {
                    qryUpdate.Dispose();

                    con.Close();
                }
            }

            Response.Redirect("~/Cadastros/Custos/Lista.aspx");
        }
    }
}