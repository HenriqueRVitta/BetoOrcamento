﻿using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Orcamento.Movimentacao.Criacao
{
    public partial class Excluir : System.Web.UI.Page
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

                    string Sel = "select pr_cliente,pr_tipologia,pr_metragem,pr_endereco,pr_conteudo,pr_proprietario,substring(pr_data,1,10) as pr_data,pr_responsavel,pr_margem_lucro,pr_margem_dificuldade,pr_margem_criativo,pr_impostos,pr_desconto,pr_nome from tb_projetos where pr_id = @id";
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

        protected void btExcluir_Click(object sender, EventArgs e)
        {

            con.Open();

            string DelD = "delete from tb_projeto_despesas where pd_projeto=@projeto";
            MySqlCommand qryDeleteD= new MySqlCommand(DelD, con);
            qryDeleteD.Parameters.Add("@projeto", MySqlDbType.Int32).Value = id;

            try
            {
                qryDeleteD.ExecuteNonQuery();
            }
            catch
            {
            }
            finally
            {
                qryDeleteD.Dispose();

                con.Close();
            }

            con.Open();

            string DelC = "delete from tb_projeto_custo where pc_projeto=@projeto";
            MySqlCommand qryDeleteC = new MySqlCommand(DelC, con);
            qryDeleteC.Parameters.Add("@projeto", MySqlDbType.Int32).Value = id;

            try
            {
                qryDeleteC.ExecuteNonQuery();
            }
            catch
            {
            }
            finally
            {
                qryDeleteD.Dispose();

                con.Close();
            }

            con.Open();

            string DelE = "delete from tb_projeto_etapas where pe_projeto=@projeto";
            MySqlCommand qryDeleteE = new MySqlCommand(DelE, con);
            qryDeleteE.Parameters.Add("@projeto", MySqlDbType.Int32).Value = id;

            try
            {
                qryDeleteE.ExecuteNonQuery();
            }
            catch
            {
            }
            finally
            {
                qryDeleteE.Dispose();

                con.Close();
            }

            con.Open();

            string DelP = "delete from tb_projeto_profissional where pp_projeto=@projeto";
            MySqlCommand qryDeleteP = new MySqlCommand(DelP, con);
            qryDeleteP.Parameters.Add("@projeto", MySqlDbType.Int32).Value = id;

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

            con.Open();

            string DelO = "delete from tb_projeto_observacao where pb_projeto=@projeto";
            MySqlCommand qryDeleteO = new MySqlCommand(DelO, con);
            qryDeleteO.Parameters.Add("@projeto", MySqlDbType.Int32).Value = id;

            try
            {
                qryDeleteO.ExecuteNonQuery();
            }
            catch
            {
            }
            finally
            {
                qryDeleteO.Dispose();

                con.Close();
            }

            con.Open();

            string Del = "delete from tb_projetos where pr_id=@id";
            MySqlCommand qryDelete = new MySqlCommand(Del, con);
            qryDelete.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

            try
            {
                qryDelete.ExecuteNonQuery();

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Mensagem", "alert('Processo Executado Com Sucesso.');", true);
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Mensagem", "alert('Erro no Delete de Projetos.');", true);
            }
            finally
            {
                qryDelete.Dispose();

                con.Close();
            }

            Response.Redirect("~/Projeto/Criacao/Lista.aspx");
        }
    }
}