using AjaxControlToolkit;
using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Orcamento.Movimentacao.Criacao
{
    public partial class Cadastro : System.Web.UI.Page
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        int id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                con.Open();

                string Sel = "Select ti_id as codigo,ti_descricao as descricao from tb_tipologia order by ti_descricao";
                MySqlCommand qrySelect = new MySqlCommand(Sel, con);
                MySqlDataReader reader = qrySelect.ExecuteReader();

                pr_tipologia.DataSource = reader;
                pr_tipologia.DataTextField = "descricao";
                pr_tipologia.DataValueField = "codigo";
                pr_tipologia.DataBind();
                pr_tipologia.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Selecione a Tipologia.", ""));

                qrySelect.Dispose();

                con.Close();
            }


            if (Request.QueryString["ID"] != null)
            {
                if (!Page.IsPostBack)
                {
                    id  = Convert.ToInt32(Request.QueryString["ID"].ToString());

                    con.Open();

                    string Sel = "select pr_cliente,pr_tipologia,pr_metragem,pr_endereco,pr_conteudo,pr_proprietario,substring(pr_data,1,10) as pr_data,pr_responsavel,pr_margem_lucro,pr_margem_dificuldade,pr_margem_criativo,pr_impostos,pr_desconto,pr_nome,pr_data_cadastro from tb_projetos where pr_id = @id";
                    MySqlCommand qrySelect = new MySqlCommand(Sel, con);
                    qrySelect.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

                    MySqlDataReader reader = qrySelect.ExecuteReader();

                    while (reader.Read())
                    {
                        pr_tipologia.SelectedValue=reader["pr_tipologia"].ToString();
                        pr_metragem.Text=reader["pr_metragem"].ToString();
                        pr_endereco.Text=reader["pr_endereco"].ToString();
                        pr_conteudo.Text=reader["pr_conteudo"].ToString();
                        pr_proprietario.Text=reader["pr_proprietario"].ToString();                  
                        pr_data.Text=reader["pr_data"].ToString();
                        pr_responsavel.Text=reader["pr_responsavel"].ToString();
                        decimal valor = Convert.ToDecimal(reader["pr_margem_lucro"].ToString())*100;
                        pr_margem_lucro.Text=valor.ToString();
                        valor=Convert.ToDecimal(reader["pr_margem_dificuldade"].ToString())*100;
                        pr_margem_dificuldade.Text=valor.ToString();
                        valor=Convert.ToDecimal(reader["pr_margem_criativo"].ToString())*100;
                        pr_margem_criativo.Text=valor.ToString();
                        valor=Convert.ToDecimal(reader["pr_impostos"].ToString())*100;
                        pr_impostos.Text=valor.ToString();
                        valor=Convert.ToDecimal(reader["pr_desconto"].ToString())*100;
                        pr_desconto.Text=valor.ToString();
                        pr_nome.Text = reader["pr_nome"].ToString();
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

                string Ins = "insert INTO tb_projetos(pr_cliente,pr_tipologia,pr_metragem,pr_endereco,pr_conteudo,pr_proprietario,pr_data,pr_responsavel,pr_margem_lucro,pr_margem_dificuldade,pr_margem_criativo,pr_impostos,pr_desconto,pr_nome,pr_data_cadastro) values(@cliente,@tipologia,@metragem,@endereco,@conteudo,@proprietario,@data,@responsavel,@margem_lucro,@margem_dificuldade,@margem_criativo,@impostos,@desconto,@nome)";
                MySqlCommand qryInsert = new MySqlCommand(Ins, con);
                qryInsert.Parameters.Add("@cliente", MySqlDbType.VarChar,255).Value = Session["IdUser"].ToString();
                qryInsert.Parameters.Add("@tipologia", MySqlDbType.Int16).Value = Convert.ToInt16(pr_tipologia.SelectedValue.ToString());
                qryInsert.Parameters.Add("@metragem", MySqlDbType.Int32).Value = Convert.ToInt32(pr_metragem.Text);
                qryInsert.Parameters.Add("@endereco", MySqlDbType.VarChar,45).Value = pr_endereco.Text.ToUpper();
                qryInsert.Parameters.Add("@conteudo", MySqlDbType.VarChar, 45).Value = pr_conteudo.Text.ToUpper();
                qryInsert.Parameters.Add("@proprietario", MySqlDbType.VarChar, 45).Value = pr_proprietario.Text.ToUpper();
                qryInsert.Parameters.Add("@data", MySqlDbType.DateTime).Value = Convert.ToDateTime(pr_data.Text);
                qryInsert.Parameters.Add("@responsavel", MySqlDbType.VarChar, 45).Value = pr_responsavel.Text.ToUpper();
                qryInsert.Parameters.Add("@margem_lucro", MySqlDbType.Decimal).Value = Convert.ToDecimal(pr_margem_lucro.Text)/100;
                qryInsert.Parameters.Add("@margem_dificuldade", MySqlDbType.Decimal).Value = Convert.ToDecimal(pr_margem_dificuldade.Text)/100;
                qryInsert.Parameters.Add("@margem_criativo", MySqlDbType.Decimal).Value = Convert.ToDecimal(pr_margem_criativo.Text)/100;
                qryInsert.Parameters.Add("@impostos", MySqlDbType.Decimal).Value = Convert.ToDecimal(pr_impostos.Text)/100;
                qryInsert.Parameters.Add("@desconto", MySqlDbType.Decimal).Value = Convert.ToDecimal(pr_desconto.Text)/100;
                qryInsert.Parameters.Add("@nome", MySqlDbType.VarChar,80).Value = pr_nome.Text.ToUpper();
                qryInsert.Parameters.Add("@data_cadastro", MySqlDbType.DateTime).Value = DateTime.Now;


                try
                {
                    qryInsert.ExecuteNonQuery();

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Mensagem", "alert('Processo Executado Com Sucesso.');", true);
                }
                catch
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Mensagem", "alert('Erro no Insert Projetos.');", true);
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

                string Upd = "update tb_projetos set pr_tipologia=@tipologia,pr_metragem=@metragem,pr_endereco=@endereco,pr_conteudo=@conteudo,pr_proprietario=@proprietario,pr_data=@data,pr_responsavel=@responsavel,pr_margem_lucro=@margem_lucro,pr_margem_dificuldade=@margem_dificuldade,pr_margem_criativo=@margem_criativo,pr_impostos=@impostos,pr_desconto=@desconto,pr_nome=@nome where pr_id=@id";
                MySqlCommand qryUpdate = new MySqlCommand(Upd, con);
                qryUpdate.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                qryUpdate.Parameters.Add("@tipologia", MySqlDbType.Int16).Value = Convert.ToInt16(pr_tipologia.SelectedValue.ToString());
                qryUpdate.Parameters.Add("@metragem", MySqlDbType.Int32).Value = Convert.ToInt32(pr_metragem.Text);
                qryUpdate.Parameters.Add("@endereco", MySqlDbType.VarChar, 45).Value = pr_endereco.Text.ToUpper();
                qryUpdate.Parameters.Add("@conteudo", MySqlDbType.VarChar, 45).Value = pr_conteudo.Text.ToUpper();
                qryUpdate.Parameters.Add("@proprietario", MySqlDbType.VarChar, 45).Value = pr_proprietario.Text.ToUpper();
                qryUpdate.Parameters.Add("@data", MySqlDbType.DateTime).Value = Convert.ToDateTime(pr_data.Text);
                qryUpdate.Parameters.Add("@responsavel", MySqlDbType.VarChar, 45).Value = pr_responsavel.Text.ToUpper();
                qryUpdate.Parameters.Add("@margem_lucro", MySqlDbType.Decimal).Value = Convert.ToDecimal(pr_margem_lucro.Text) / 100;
                qryUpdate.Parameters.Add("@margem_dificuldade", MySqlDbType.Decimal).Value = Convert.ToDecimal(pr_margem_dificuldade.Text) / 100;
                qryUpdate.Parameters.Add("@margem_criativo", MySqlDbType.Decimal).Value = Convert.ToDecimal(pr_margem_criativo.Text) / 100;
                qryUpdate.Parameters.Add("@impostos", MySqlDbType.Decimal).Value = Convert.ToDecimal(pr_impostos.Text) / 100;
                qryUpdate.Parameters.Add("@desconto", MySqlDbType.Decimal).Value = Convert.ToDecimal(pr_desconto.Text) / 100;
                qryUpdate.Parameters.Add("@nome", MySqlDbType.VarChar, 80).Value = pr_nome.Text.ToUpper();

                try
                {
                    qryUpdate.ExecuteNonQuery();

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Mensagem", "alert('Processo Executado Com Sucesso.');", true);
                }
                catch
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Mensagem", "alert('Erro no Update de Projetos.');", true);
                }
                finally
                {
                    qryUpdate.Dispose();

                    con.Close();
                }
            }

            Response.Redirect("~/Projeto/Criacao/Lista.aspx");
        }
    }
}