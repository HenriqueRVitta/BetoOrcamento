using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Orcamento.Movimentacao.Criacao
{
    public partial class Lista : System.Web.UI.Page
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        MySqlConnection con1 = new MySqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        MySqlConnection con2 = new MySqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());

        public virtual System.Web.UI.WebControls.ButtonType ButtonType { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IdUser"] != null)
            {

                if (!Page.IsPostBack)
                {
                    Carrega();
                }
            } else
            {
                // Redireciona para Login caso não esteja logado
                Response.Redirect("/Account/Login.aspx");

            }

        }

        public void Carrega()
        {
            con.Open();

            string Sel = "select pr_id,pr_tipologia,pr_metragem,pr_endereco,pr_conteudo,pr_proprietario,DATE_FORMAT(pr_data, '%d/%m/%Y') as pr_data,pr_responsavel,pr_margem_lucro,pr_margem_dificuldade,pr_margem_criativo,pr_impostos,pr_desconto,pr_nome,DATE_FORMAT(pr_data_cadastro, '%d/%m/%Y') as pr_data_cadastro,ti_id,ti_descricao from tb_projetos inner join tb_tipologia on pr_tipologia=ti_id where pr_cliente=@cliente";
            MySqlCommand qrySelect = new MySqlCommand(Sel, con);
            qrySelect.Parameters.Add("@cliente", MySqlDbType.VarChar,255).Value = Session["IdUser"].ToString();

            DataTable dataTable = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(qrySelect);
            da.Fill(dataTable);

            Session["TaskTable"] = dataTable;
            GrdProjetos.DataSource = dataTable;
            GrdProjetos.DataBind();
            ViewState["dirState"] = dataTable;
            ViewState["sortdr"] = "Asc";

            qrySelect.Dispose();

            con.Close();

        }
        protected void GrdProjetos_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable dt = Session["TaskTable"] as DataTable;

            if (dt.Rows.Count > 0)
            {
                if (Convert.ToString(ViewState["sortdr"]) == "Asc")
                {
                    dt.DefaultView.Sort = e.SortExpression + " Desc";
                    ViewState["sortdr"] = "Desc";
                }
                else
                {
                    dt.DefaultView.Sort = e.SortExpression + " Asc";
                    ViewState["sortdr"] = "Asc";
                }
                GrdProjetos.DataSource = dt;
                GrdProjetos.DataBind();
            }
        }
        protected void GrdProjetos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdProjetos.PageIndex = e.NewPageIndex;
            BindData();
        }
        private void BindData()
        {
            GrdProjetos.DataSource = Session["TaskTable"];
            GrdProjetos.DataBind();
        }

        protected void GrdProjetos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandArgument.ToString() != "First" && e.CommandArgument.ToString() != "Next" && e.CommandArgument.ToString() != "Prev" && e.CommandArgument.ToString() != "Last" && e.CommandArgument.ToString() != "pr_data_cadastro" && e.CommandArgument.ToString() != "pr_nome" && e.CommandArgument.ToString() != "ti_descricao" && e.CommandArgument.ToString() != "pr_metragem" && e.CommandArgument.ToString() != "pr_conteudo" && e.CommandArgument.ToString() != "pr_data" && e.CommandArgument.ToString() != "pr_responsavel")
            {
                if (Convert.ToInt16(e.CommandArgument.ToString()) >= 0)
                {
                    string id = Convert.ToString(GrdProjetos.DataKeys[Convert.ToInt32(e.CommandArgument)].Value);

                    if (e.CommandName.CompareTo("Editar") == 0)
                    {
                        Response.Redirect("~/Escritorio/Projeto/Criacao/Cadastro.aspx?ID=" + id);
                    }
                    else
                    {
                        if (e.CommandName.CompareTo("Excluir") == 0)
                        {
                            Response.Redirect("~/Escritorio/Projeto/Criacao/Excluir.aspx?ID=" + id);
                        }
                        else
                        {
                            if (e.CommandName.CompareTo("Colonar") == 0)
                            {
                                Clonagem(Convert.ToInt32(id));
                                Carrega();
                            }
                            else
                            {
                                if (e.CommandName.CompareTo("Selecionar") == 0)
                                {
                                    Response.Redirect("~/Escritorio/Projeto/Fases/Profissionais/Lista.aspx?Projeto=" + id);
                                }
                            }
                        }
                    }
                }
            }
        }
        private void Clonagem(int id)
        {
            con.Open();

            string Sel = "select pr_cliente,pr_tipologia,pr_metragem,pr_endereco,pr_conteudo,pr_proprietario,pr_data,pr_responsavel,pr_margem_lucro,pr_margem_dificuldade,pr_margem_criativo,pr_impostos,pr_desconto,pr_nome from tb_projetos where pr_id = @id";
            MySqlCommand qrySelect = new MySqlCommand(Sel, con);
            qrySelect.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

            MySqlDataReader reader = qrySelect.ExecuteReader();

            string data = DateTime.Now.ToString();

            while (reader.Read())
            {
                con1.Open();

                string Ins = "insert INTO tb_projetos(pr_cliente,pr_tipologia,pr_metragem,pr_endereco,pr_conteudo,pr_proprietario,pr_data,pr_responsavel,pr_margem_lucro,pr_margem_dificuldade,pr_margem_criativo,pr_impostos,pr_desconto,pr_nome,pr_data_cadastro) values(@cliente,@tipologia,@metragem,@endereco,@conteudo,@proprietario,@data,@responsavel,@margem_lucro,@margem_dificuldade,@margem_criativo,@impostos,@desconto,@nome,@data_cadastro)";
                MySqlCommand qryInsert = new MySqlCommand(Ins, con1);
                qryInsert.Parameters.Add("@cliente", MySqlDbType.VarChar,255).Value = reader["pr_cliente"].ToString();
                qryInsert.Parameters.Add("@tipologia", MySqlDbType.Int16).Value = Convert.ToInt16(reader["pr_tipologia"].ToString());
                qryInsert.Parameters.Add("@metragem", MySqlDbType.Int32).Value = Convert.ToInt32(reader["pr_metragem"].ToString());
                qryInsert.Parameters.Add("@endereco", MySqlDbType.VarChar, 45).Value = reader["pr_endereco"].ToString();
                qryInsert.Parameters.Add("@conteudo", MySqlDbType.VarChar, 45).Value = reader["pr_conteudo"].ToString();
                qryInsert.Parameters.Add("@proprietario", MySqlDbType.VarChar, 45).Value = reader["pr_proprietario"].ToString();
                qryInsert.Parameters.Add("@data", MySqlDbType.DateTime).Value = Convert.ToDateTime(reader["pr_data"].ToString());
                qryInsert.Parameters.Add("@responsavel", MySqlDbType.VarChar, 45).Value = reader["pr_responsavel"].ToString();
                qryInsert.Parameters.Add("@margem_lucro", MySqlDbType.Decimal).Value = Convert.ToDecimal(reader["pr_margem_lucro"].ToString());
                qryInsert.Parameters.Add("@margem_dificuldade", MySqlDbType.Decimal).Value = Convert.ToDecimal(reader["pr_margem_dificuldade"].ToString());
                qryInsert.Parameters.Add("@margem_criativo", MySqlDbType.Decimal).Value = Convert.ToDecimal(reader["pr_margem_criativo"].ToString());
                qryInsert.Parameters.Add("@impostos", MySqlDbType.Decimal).Value = Convert.ToDecimal(reader["pr_impostos"].ToString());
                qryInsert.Parameters.Add("@desconto", MySqlDbType.Decimal).Value = Convert.ToDecimal(reader["pr_desconto"].ToString());
                qryInsert.Parameters.Add("@nome", MySqlDbType.VarChar, 80).Value = reader["pr_nome"].ToString();
                qryInsert.Parameters.Add("@data_cadastro", MySqlDbType.DateTime).Value = Convert.ToDateTime(data);

                try
                {
                    qryInsert.ExecuteNonQuery();
                }
                catch
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Mensagem", "alert('Erro no Insert Projetos.');", true);
                }
                finally
                {
                    qryInsert.Dispose();

                    con1.Close();
                }

                int Id_Novo = 0;

                con1.Open();

                string SelM = "select pr_id from tb_projetos where pr_data_cadastro = @data";
                MySqlCommand qrySelectM = new MySqlCommand(SelM, con1);
                qrySelectM.Parameters.Add("@data", MySqlDbType.DateTime).Value = Convert.ToDateTime(data);

                MySqlDataReader readerM = qrySelectM.ExecuteReader();

                while (readerM.Read())
                {
                    Id_Novo = Convert.ToInt32(readerM["pr_id"].ToString());
                }
                qrySelectM.Dispose();

                con1.Close();

                //  Inserir Profissionais

                con2.Open();

                string SelP = "select pp_profissional,pp_valor,pp_quantidade from tb_projeto_profissional where pp_projeto=@projeto";
                MySqlCommand qrySelectP = new MySqlCommand(SelP, con2);
                qrySelectP.Parameters.Add("@projeto", MySqlDbType.Int32).Value = id;
                MySqlDataReader readerP = qrySelectP.ExecuteReader();

                while (readerP.Read())
                {
                    con1.Open();

                    string InsP = "insert INTO tb_projeto_profissional(pp_projeto,pp_profissional,pp_valor,pp_quantidade) values(@projeto,@profissional,@valor,@quantidade)";
                    MySqlCommand qryInsertP = new MySqlCommand(InsP, con1);
                    qryInsertP.Parameters.Add("@projeto", MySqlDbType.Int32).Value = Id_Novo;
                    qryInsertP.Parameters.Add("@profissional", MySqlDbType.Int16).Value = Convert.ToInt16(readerP["pp_profissional"].ToString());
                    qryInsertP.Parameters.Add("@valor", MySqlDbType.Decimal).Value = Convert.ToDecimal(readerP["pp_valor"].ToString());
                    qryInsertP.Parameters.Add("@quantidade", MySqlDbType.Int16).Value = Convert.ToInt16(readerP["pp_quantidade"].ToString());

                    try
                    {
                        qryInsertP.ExecuteNonQuery();
                    }
                    catch
                    {
                    }
                    finally
                    {
                        qryInsertP.Dispose();

                        con1.Close();
                    }
                }

                qrySelectP.Dispose();
                con2.Close();

                // Inserir Despesas

                //con2.Open();

                //string SelD = "select pd_despesa,pd_valor_previsto from tb_projeto_despesas where pd_projeto=@projeto";
                //MySqlCommand qrySelectD = new MySqlCommand(SelD, con2);
                //qrySelectD.Parameters.Add("@projeto", MySqlDbType.Int32).Value = id;
                //MySqlDataReader readerD = qrySelectD.ExecuteReader();

                //while (readerD.Read())
                //{
                //    con1.Open();

                //    string InsD = "insert INTO tb_projeto_despesas(pd_projeto,pd_despesa,pd_valor_previsto) values(@projeto,@despesa,@valor_previsto)";
                //    MySqlCommand qryInsertD = new MySqlCommand(InsD, con1);
                //    qryInsertD.Parameters.Add("@projeto", MySqlDbType.Int32).Value = Id_Novo;
                //    qryInsertD.Parameters.Add("@despesa", MySqlDbType.Int32).Value = Convert.ToInt32(readerD["pd_despesa"].ToString());
                //    qryInsertD.Parameters.Add("@valor_previsto", MySqlDbType.Decimal).Value = Convert.ToDecimal(readerD["pd_valor_previsto"].ToString());

                //    try
                //    {
                //        qryInsertD.ExecuteNonQuery();
                //    }
                //    catch
                //    {
                //    }
                //    finally
                //    {
                //        qryInsertD.Dispose();

                //        con1.Close();
                //    }
                //}

                //qrySelectD.Dispose();
                //con2.Close();

                // Inserir Custos

                con2.Open();

                string SelC = "select pc_custo,pc_valor_previsto from tb_projeto_custo where pc_projeto=@projeto";
                MySqlCommand qrySelectC = new MySqlCommand(SelC, con2);
                qrySelectC.Parameters.Add("@projeto", MySqlDbType.Int32).Value = id;
                MySqlDataReader readerC = qrySelectC.ExecuteReader();

                while (readerC.Read())
                {
                    con1.Open();

                    string InsC = "insert INTO tb_projeto_custo(pc_projeto,pc_custo,pc_valor_previsto) values(@projeto,@custo,@valor_previsto)";
                    MySqlCommand qryInsertC = new MySqlCommand(InsC, con1);
                    qryInsertC.Parameters.Add("@projeto", MySqlDbType.Int32).Value = Id_Novo;
                    qryInsertC.Parameters.Add("@custo", MySqlDbType.Int32).Value = Convert.ToInt32(readerC["pc_custo"].ToString());
                    qryInsertC.Parameters.Add("@valor_previsto", MySqlDbType.Decimal).Value = Convert.ToDecimal(readerC["pc_valor_previsto"].ToString());

                    try
                    {
                        qryInsertC.ExecuteNonQuery();
                    }
                    catch
                    {
                    }
                    finally
                    {
                        qryInsertC.Dispose();

                        con1.Close();
                    }
                }
                qrySelectC.Dispose();
                con2.Close();

                // Inserir Etapas

                con2.Open();

                string SelE = "select pe_etapa,pe_hora_previsto,pe_realisado from tb_projeto_etapas where pe_projeto=@projeto";
                MySqlCommand qrySelectE = new MySqlCommand(SelE, con2);
                qrySelectE.Parameters.Add("@projeto", MySqlDbType.Int32).Value = id;
                MySqlDataReader readerE = qrySelectE.ExecuteReader();

                while (readerE.Read())
                {

                    con1.Open();

                    string InsE = "insert INTO tb_projeto_etapas(pe_projeto,pe_etapa,pe_hora_previsto,pe_realisado) values(@projeto,@etapa,@hora_previsto,0)";
                    MySqlCommand qryInsertE = new MySqlCommand(InsE, con1);
                    qryInsertE.Parameters.Add("@projeto", MySqlDbType.Int32).Value = Id_Novo;
                    qryInsertE.Parameters.Add("@etapa", MySqlDbType.Int32).Value = Convert.ToInt32(readerE["pe_etapa"].ToString());
                    if (readerE["pe_hora_previsto"].ToString().Length > 0)
                        qryInsertE.Parameters.Add("@hora_previsto", MySqlDbType.Decimal).Value = Convert.ToDecimal(readerE["pe_hora_previsto"].ToString());
                    else
                        qryInsertE.Parameters.Add("@hora_previsto", MySqlDbType.Decimal).Value = null;
                    if (readerE["pe_realisado"].ToString().Length > 0)
                        qryInsertE.Parameters.Add("@pe_realisado", MySqlDbType.Decimal).Value = Convert.ToDecimal(readerE["pe_realisado"].ToString());
                    else
                        qryInsertE.Parameters.Add("@pe_realisado", MySqlDbType.Decimal).Value = null;

                    try
                    {
                        qryInsertE.ExecuteNonQuery();
                    }
                    catch
                    {
                    }
                    finally
                    {
                        qryInsertE.Dispose();

                        con1.Close();
                    }
                }
                qrySelectC.Dispose();
                con2.Close();
            }

            qrySelect.Dispose();

            con.Close();

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Mensagem", "alert('Processo Executado Com Sucesso.');", true);
        }
    }
}