using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Web.UI;

namespace Orcamento.Projeto.Fases
{
    public partial class Resultado : System.Web.UI.Page
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Projeto"] != null)
            {

                lblProjeto.Text = Request.QueryString["Projeto"].ToString();

                string OBS = "";

                con.Open();

                string SelecO = "select pb_observacao from tb_projeto_observacao where pb_projeto = @idProjeto";
                MySqlCommand qrySelectO = new MySqlCommand(SelecO, con);
                qrySelectO.Parameters.Add("@idProjeto", MySqlDbType.Int32).Value = Convert.ToInt32(lblProjeto.Text);
                MySqlDataReader readerO = qrySelectO.ExecuteReader();

                while (readerO.Read())
                {
                    OBS = readerO["pb_observacao"].ToString(); ;
                }

                qrySelectO.Dispose();
                con.Close();

                TextBox1.Text = OBS;

                decimal marge_lucro = 0;
                decimal margem_difi = 0;
                decimal margem_cria = 0;
                decimal imposto = 0;
                decimal desconto = 0;

                con.Open();

                string SelN = "select pr_nome,pr_margem_lucro,pr_margem_dificuldade,pr_margem_criativo,pr_impostos,pr_desconto from tb_projetos where pr_id=@projeto";
                MySqlCommand qrySelectN = new MySqlCommand(SelN, con);
                qrySelectN.Parameters.Add("@projeto", MySqlDbType.Int32).Value = Convert.ToInt32(lblProjeto.Text);
                MySqlDataReader readerN = qrySelectN.ExecuteReader();

                while (readerN.Read())
                {
                    LblNome.Text = readerN["pr_nome"].ToString();

                    if (readerN["pr_margem_lucro"].ToString().Length > 0)
                        marge_lucro = Convert.ToDecimal(readerN["pr_margem_lucro"].ToString());

                    if (readerN["pr_margem_dificuldade"].ToString().Length > 0)
                        margem_difi = Convert.ToDecimal(readerN["pr_margem_dificuldade"].ToString());

                    if (readerN["pr_margem_criativo"].ToString().Length > 0)
                        margem_cria = Convert.ToDecimal(readerN["pr_margem_criativo"].ToString());

                    if (readerN["pr_impostos"].ToString().Length > 0)
                        imposto = Convert.ToDecimal(readerN["pr_impostos"].ToString());

                    if (readerN["pr_desconto"].ToString().Length > 0)
                        desconto = Convert.ToDecimal(readerN["pr_desconto"].ToString());
                }

                qrySelectN.Dispose();
                con.Close();

                con.Open();

                string Sel = "select sum(pd_valor_previsto) as valor from tb_projeto_despesas inner join tb_despesas on pd_despesa=da_id where pd_projeto=@projeto and da_codigo<>'0201'";
                MySqlCommand qrySelect = new MySqlCommand(Sel, con);
                qrySelect.Parameters.Add("@projeto", MySqlDbType.Int32).Value = Convert.ToInt32(lblProjeto.Text);

                MySqlDataReader reader = qrySelect.ExecuteReader();

                decimal Adm=0;

                while (reader.Read())
                {
                    lblDespAdmin.Text = string.Format("{0:c}", Convert.ToDecimal(reader["valor"].ToString()));

                    Adm = Convert.ToDecimal(reader["valor"].ToString());

                }
                qrySelect.Dispose();

                con.Close();

                Adm = Adm / 223;

                con.Open();

                string SelI = "select sum(pe_hora_previsto) as valor from tb_projeto_etapas where pe_projeto=@projeto";
                MySqlCommand qrySelectI = new MySqlCommand(SelI, con);
                qrySelectI.Parameters.Add("@projeto", MySqlDbType.Int32).Value = Convert.ToInt32(lblProjeto.Text);

                MySqlDataReader readerI = qrySelectI.ExecuteReader();

                decimal valor = 0;

                while (readerI.Read())
                {
                    if(readerI["valor"].ToString().Length>0)
                        valor = Convert.ToDecimal(readerI["valor"].ToString());
                    else 
                        valor = 0;
                }
                qrySelectI.Dispose();

                decimal SubTI = (Adm * valor);

                lblDespAdminUni.Text = string.Format("{0:c}", (Adm * valor));

                con.Close();

                con.Open();

                string SelII = "select sum(pc_valor_previsto) as valor from tb_projeto_custo where pc_projeto=@projeto";
                MySqlCommand qrySelectII = new MySqlCommand(SelII, con);
                qrySelectII.Parameters.Add("@projeto", MySqlDbType.Int32).Value = Convert.ToInt32(lblProjeto.Text);

                MySqlDataReader readerII = qrySelectII.ExecuteReader();

                while (readerII.Read())
                {
                    lblCusto.Text = string.Format("{0:c}", Convert.ToDecimal(readerII["valor"].ToString()));
                    SubTI = SubTI + Convert.ToDecimal(readerII["valor"].ToString());
                }
                qrySelectII.Dispose();

                con.Close();

                con.Open();

                string SelIII = "select sum(pd_valor_previsto) as valor from tb_projeto_despesas inner join tb_despesas on pd_despesa=da_id where pd_projeto=@projeto and substring(da_codigo,1,3)='011'";
                MySqlCommand qrySelectIII= new MySqlCommand(SelIII, con);
                qrySelectIII.Parameters.Add("@projeto", MySqlDbType.Int32).Value = Convert.ToInt32(lblProjeto.Text);

                MySqlDataReader readerIII = qrySelectIII.ExecuteReader();

                decimal custo = 0;

                while (readerIII.Read())
                {
                    lblHoraTecnicaA.Text = string.Format("{0:c}", Convert.ToDecimal(readerIII["valor"].ToString())/149);
                    custo = (Convert.ToDecimal(readerIII["valor"].ToString()) / 149) * 223;
                }
                qrySelectIII.Dispose();

                con.Close();

                con.Open();

                string SelIV = "select sum(pd_valor_previsto) as valor from tb_projeto_despesas inner join tb_despesas on pd_despesa=da_id where pd_projeto=1 and substring(da_codigo,1,3)='012'";
                MySqlCommand qrySelectIV = new MySqlCommand(SelIV, con);
                qrySelectIV.Parameters.Add("@projeto", MySqlDbType.Int32).Value = Convert.ToInt32(lblProjeto.Text);

                MySqlDataReader readerIV = qrySelectIV.ExecuteReader();

                while (readerIV.Read())
                {
                    lblHoraTecnicaE.Text = string.Format("{0:c}", Convert.ToDecimal(readerIV["valor"].ToString())/74);
                    custo = custo + (Convert.ToDecimal(readerIV["valor"].ToString()) / 74)*223;
                }
                qrySelectIV.Dispose();

                con.Close();

                LblMaoObra.Text = string.Format("{0:c}", custo);
                SubTI = SubTI + custo;

                lblSubTotal1.Text= string.Format("{0:c}", SubTI);

                decimal SubTII = 0;

                lblPercMargemLucro.Text = string.Format("{0:P2}", marge_lucro);
                if (marge_lucro > 0)
                {
                    lblMargemLucro.Text = string.Format("{0:c}", SubTI * marge_lucro);
                    SubTII = SubTII+(SubTI * marge_lucro);


                }
                lblPercMargemDificuldade.Text = string.Format("{0:P2}", margem_difi);
                if (margem_difi > 0)
                {
                    lblMargemDificuldade.Text = string.Format("{0:c}", SubTI * margem_difi);
                    SubTII = SubTII + (SubTI * margem_difi);

                }
                    lblPercMargemCriativo.Text= string.Format("{0:P2}", margem_cria);
                if (margem_cria > 0)
                {
                    lblMargemCriativo.Text = string.Format("{0:c}", SubTI * margem_cria);
                    SubTII = SubTII + (SubTI * margem_cria);
                }

                lblSubTotal2.Text = string.Format("{0:c}", SubTII);

                lblTotal.Text = string.Format("{0:c}", (SubTI+SubTII));

                lblTaxaImposto.Text = string.Format("{0:P2}", imposto);

                lblImposto.Text= string.Format("{0:c}", (SubTI + SubTII)*imposto);

                lblTotalGeral.Text = string.Format("{0:c}", SubTI + SubTII+((SubTI + SubTII) * imposto));

                con.Open();

                string SelP = "select da_descricao,pp_quantidade,pp_valor from tb_projeto_profissional inner join tb_despesas on pp_profissional=da_id where pp_projeto=@projeto and (substring(da_codigo,1,3)='010' or substring(da_codigo,1,3)='011' or substring(da_codigo,1,3)='012'  or substring(da_codigo,1,3)='013')";
                MySqlCommand qrySelectP = new MySqlCommand(SelP, con);
                qrySelectP.Parameters.Add("@projeto", MySqlDbType.Int32).Value = Convert.ToInt32(lblProjeto.Text);
                DataTable dataTable = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(qrySelectP);
                da.Fill(dataTable);

                Session["TaskTable"] = dataTable;
                grdProfisionais.DataSource = dataTable;
                grdProfisionais.DataBind();
                ViewState["dirState"] = dataTable;
                ViewState["sortdr"] = "Asc";

                qrySelectP.Dispose();

                con.Close();

            }
        }

        protected void BtnVolta_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Projeto/Fases/Etapas.aspx?Projeto=" + lblProjeto.Text);
        }


        protected void btnSalvarOBS_Click(object sender, System.EventArgs e)
        {

            var idProjeto = Request.QueryString["Projeto"].ToString();
            bool existeOrcamento = false;
            string observacao = TextBox1.Text;

            if (Convert.ToDecimal(idProjeto) > 0)
            {
                con.Open();

                string Selec = "select pb_projeto from tb_projeto_observacao where pb_projeto = @idProjeto";
                MySqlCommand qrySelect = new MySqlCommand(Selec, con);
                qrySelect.Parameters.Add("@idProjeto", MySqlDbType.Int32).Value = idProjeto;
                MySqlDataReader readerN = qrySelect.ExecuteReader();

                while (readerN.Read())
                {
                    existeOrcamento = true;
                }

                qrySelect.Dispose();
                con.Close();

                if (!existeOrcamento)
                {
                    con.Open();
                    string Ins = "insert INTO tb_projeto_observacao(pb_projeto,pb_observacao) values(@idProjeto,@observacao)";
                    MySqlCommand qryInsert = new MySqlCommand(Ins, con);
                    qryInsert.Parameters.Add("@idProjeto", MySqlDbType.Int32).Value = idProjeto;
                    qryInsert.Parameters.Add("@observacao", MySqlDbType.VarChar, 2083).Value = observacao;

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

                    string Upd = "update tb_projeto_observacao set pb_observacao=@observacao where pb_projeto=@idProjeto";
                    MySqlCommand qryUpdate = new MySqlCommand(Upd, con);
                    qryUpdate.Parameters.Add("@idProjeto", MySqlDbType.Int32).Value = idProjeto;
                    qryUpdate.Parameters.Add("@observacao", MySqlDbType.VarChar, 2083).Value = observacao;

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

            }

        }

    }
}