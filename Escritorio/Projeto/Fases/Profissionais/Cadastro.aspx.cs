using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Transactions;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Orcamento.Projeto.Fases.Profissionais
{
    public partial class Cadastro : System.Web.UI.Page
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

                        pp_valor.Text= TimeSpan.FromHours(Convert.ToDouble(reader["pp_hora_trabalhada"].ToString())).TotalHours.ToString();

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
        protected void btnSalvar_Click(object sender, System.EventArgs e)
        {
            pp_valor.Text = pp_valor.Text.Replace(",", ".");

            int valor = Convert.ToInt32(pp_valor.Text.Substring(0, pp_valor.Text.IndexOf(".")));
            string cal = "";
            int dia = Convert.ToInt32(valor) / 24;

            int hor = Convert.ToInt32(valor) - (dia * 24);

            double min = Convert.ToInt32(pp_valor.Text.Substring(pp_valor.Text.IndexOf(".")+1, pp_valor.Text.Length- pp_valor.Text.IndexOf(".")-1));

            if (dia > 0)
                cal = dia.ToString() + "." + hor.ToString().PadLeft(2, '0') + ":" + min.ToString().PadLeft(2, '0') + ":00";
            else
                cal = hor.ToString().PadLeft(2, '0') + ":" + min.ToString().PadLeft(2, '0') + ":00";


            if (id==0)
            {
                con.Open();

                string Ins = "insert INTO tb_projeto_profissional(pp_projeto,pp_profissional,pp_hora_trabalhada,pp_quantidade) values(@projeto,@profissional,@valor,@quantidade)";
                MySqlCommand qryInsert = new MySqlCommand(Ins, con);
                qryInsert.Parameters.Add("@projeto", MySqlDbType.Int32).Value = Convert.ToInt32(lblProjeto.Text);
                qryInsert.Parameters.Add("@profissional", MySqlDbType.Int16).Value = Convert.ToInt16(pp_profissional.SelectedValue.ToString());
                qryInsert.Parameters.Add("@valor", MySqlDbType.Decimal).Value = Convert.ToDecimal(TimeSpan.Parse(cal).TotalHours);
                qryInsert.Parameters.Add("@quantidade", MySqlDbType.Int16).Value = Convert.ToInt16(pp_quantidade.Text);

                try
                {
                    qryInsert.ExecuteNonQuery();
                }
                catch
                {
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

                string Upd = "update tb_projeto_profissional set pp_profissional=@profissional,pp_hora_trabalhada=@valor,pp_quantidade=@quantidade where pp_id=@id";
                MySqlCommand qryUpdate = new MySqlCommand(Upd, con);
                qryUpdate.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                qryUpdate.Parameters.Add("@profissional", MySqlDbType.Int16).Value = Convert.ToInt16(pp_profissional.SelectedValue.ToString());
                qryUpdate.Parameters.Add("@valor", MySqlDbType.Decimal).Value = Convert.ToDecimal(TimeSpan.Parse(cal).TotalHours);
                qryUpdate.Parameters.Add("@quantidade", MySqlDbType.Int16).Value = Convert.ToInt16(pp_quantidade.Text);

                try
                {
                    qryUpdate.ExecuteNonQuery();
                }
                catch
                {
                }
                finally
                {
                    qryUpdate.Dispose();

                    con.Close();
                }
            }

            Response.Redirect("~/Escritorio/Projeto/Fases/Profissionais/Lista.aspx?Projeto=" + lblProjeto.Text);
        }

        protected void BtnAvanca_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Escritorio/Projeto/Fases/Resultado.aspx?ID=" + lblProjeto.Text);
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Escritorio/Projeto/Fases/Profissionais/Lista.aspx?Projeto=" + lblProjeto.Text);
        }
    }
}