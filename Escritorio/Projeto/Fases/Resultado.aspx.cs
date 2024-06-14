using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Web.Services.Description;
using System.Web.UI;

namespace Orcamento.Projeto.Fases
{
    public partial class Resultado : System.Web.UI.Page
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());

        decimal margem_lucro = 0;
        decimal margem_difi = 0;
        decimal margem_cria = 0;
        decimal imposto = 0;
        decimal desconto = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Projeto"] != null)
            {
                if (!Page.IsPostBack)
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

                    con.Open();

                    string SelN = "select pr_nome,pr_margem_lucro,pr_margem_dificuldade,pr_margem_criativo,pr_impostos,pr_desconto,pr_cliente from tb_projetos where pr_id=@projeto";
                    MySqlCommand qrySelectN = new MySqlCommand(SelN, con);
                    qrySelectN.Parameters.Add("@projeto", MySqlDbType.Int32).Value = Convert.ToInt32(lblProjeto.Text);
                    MySqlDataReader readerN = qrySelectN.ExecuteReader();

                    while (readerN.Read())
                    {
                        LblNome.Text = readerN["pr_nome"].ToString();
                        lblCliente.Text = readerN["pr_cliente"].ToString();

                        if (readerN["pr_margem_lucro"].ToString().Length > 0)
                        {
                            margem_lucro = Convert.ToDecimal(readerN["pr_margem_lucro"].ToString());
                            txtPercMargemLucro.Text = readerN["pr_margem_lucro"].ToString();
                        }

                        if (readerN["pr_margem_dificuldade"].ToString().Length > 0)
                        { 
                            margem_difi = Convert.ToDecimal(readerN["pr_margem_dificuldade"].ToString());
                            txtPercMargemDificuldade.Text = readerN["pr_margem_dificuldade"].ToString();
                        }

                        if (readerN["pr_margem_criativo"].ToString().Length > 0)
                        {
                            margem_cria = Convert.ToDecimal(readerN["pr_margem_criativo"].ToString());
                            txtPercMargemCriativo.Text = readerN["pr_margem_criativo"].ToString();
                        }

                        if (readerN["pr_impostos"].ToString().Length > 0)
                            imposto = Convert.ToDecimal(readerN["pr_impostos"].ToString());

                        if (readerN["pr_desconto"].ToString().Length > 0)
                        {
                            desconto = Convert.ToDecimal(readerN["pr_desconto"].ToString());
                            txtPercDesconto.Text = readerN["pr_desconto"].ToString();
                        }
                    }

                    qrySelectN.Dispose();
                    con.Close();

                    con.Open();

                    string Sel = "select COALESCE(sum(pd_valor_previsto),0) as valor from tb_cliente_despesas inner join tb_despesas on pd_despesa=da_id where pd_cliente=@cliente and substring(da_codigo,1,2)='01'";
                    MySqlCommand qrySelect = new MySqlCommand(Sel, con);
                    qrySelect.Parameters.Add("@cliente", MySqlDbType.VarChar,255).Value = lblCliente.Text;

                    MySqlDataReader reader = qrySelect.ExecuteReader();

                    decimal Adm = 0;

                    while (reader.Read())
                    {
                        lblDespAdmin.Text = string.Format("{0:c}", Convert.ToDecimal(reader["valor"].ToString()));

                        Adm = Convert.ToDecimal(reader["valor"].ToString());
                    }
                    qrySelect.Dispose();

                    con.Close();

                    con.Open();

                    string SelI = "select sum(da_hora_trabalhada) as valor from tb_cliente_despesas inner join tb_despesas on pd_despesa=da_id where pd_cliente=@cliente and substring(da_codigo,1,2)='01'";
                    MySqlCommand qrySelectI = new MySqlCommand(SelI, con);
                    qrySelectI.Parameters.Add("@cliente", MySqlDbType.VarChar,255).Value = lblCliente.Text;

                    MySqlDataReader readerI = qrySelectI.ExecuteReader();

                    decimal valor = 0;

                    while (readerI.Read())
                    {
                        if (readerI["valor"].ToString().Length > 0)
                            valor = Convert.ToDecimal(readerI["valor"].ToString());
                        else
                            valor = 0;
                    }
                    qrySelectI.Dispose();

                    con.Close();

                    Adm = Adm / valor;

                    con.Open();

                    decimal tempo = 0;

                    string SelV = "select COALESCE(sum(pe_hora_previsto),0) as valor from tb_projeto_etapas where pe_projeto=@projeto";
                    MySqlCommand qrySelectV = new MySqlCommand(SelV, con);
                    qrySelectV.Parameters.Add("@projeto", MySqlDbType.Int32).Value = Convert.ToInt32(lblProjeto.Text);

                    MySqlDataReader readerV = qrySelectV.ExecuteReader();

                    while (readerV.Read())
                    {
                        tempo=Convert.ToDecimal(readerV["valor"].ToString());
                        lblTempoTotal.Text = TimeSpan.FromHours(Convert.ToDouble(readerV["valor"].ToString())).ToString("c");
                    }
                    qrySelectV.Dispose();

                    con.Close();

                    decimal SubTI = (Adm * tempo);

                    lblDespAdminUni.Text = string.Format("{0:c}", (Adm * tempo));

                    con.Open();

                    string SelII = "select COALESCE(sum(pc_valor_previsto),0) as valor from tb_projeto_custo where pc_projeto=@projeto";
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

                    string SelIII = "select COALESCE(sum(pd_valor_previsto),0) as valor,COALESCE(sum(da_hora_trabalhada),0) as hora from tb_cliente_despesas inner join tb_despesas on pd_despesa=da_id where pd_cliente=@cliente and substring(da_codigo,1,3)='011'";
                    MySqlCommand qrySelectIII = new MySqlCommand(SelIII, con);
                    qrySelectIII.Parameters.Add("@cliente", MySqlDbType.VarChar,255).Value = lblCliente.Text;

                    MySqlDataReader readerIII = qrySelectIII.ExecuteReader();

                    decimal custo = 0;

                    while (readerIII.Read())
                    {
                        lblHoraTecnicaA.Text = string.Format("{0:c}", Convert.ToDecimal(readerIII["valor"].ToString()) / Convert.ToInt16(readerIII["hora"].ToString()));
                        custo = ((Convert.ToDecimal(readerIII["valor"].ToString()) / Convert.ToInt16(readerIII["hora"].ToString()))*223);
                        lblCapProdutivaA.Text = readerIII["hora"].ToString();
                    }
                    qrySelectIII.Dispose();

                    con.Close();

                    con.Open();

                    string SelIV = "select COALESCE(sum(pd_valor_previsto),0) as valor,COALESCE(sum(da_hora_trabalhada),0) as hora from tb_cliente_despesas inner join tb_despesas on pd_despesa=da_id where pd_cliente=@cliente and substring(da_codigo,1,3)='012'";
                    MySqlCommand qrySelectIV = new MySqlCommand(SelIV, con);
                    qrySelectIV.Parameters.Add("@cliente", MySqlDbType.VarChar,255).Value = lblCliente.Text;

                    MySqlDataReader readerIV = qrySelectIV.ExecuteReader();

                    while (readerIV.Read())
                    {
                        lblHoraTecnicaE.Text = string.Format("{0:c}", Convert.ToDecimal(readerIV["valor"].ToString()) / Convert.ToInt16(readerIV["hora"].ToString()));
                        custo = custo + ((Convert.ToDecimal(readerIV["valor"].ToString()) / Convert.ToInt16(readerIV["hora"].ToString()))*223);
                        lblCapProdutivaE.Text = readerIV["hora"].ToString();
                    }
                    qrySelectIV.Dispose();

                    con.Close();

                    LblMaoObra.Text = string.Format("{0:c}", custo);

                    SubTI = SubTI + custo;

                    lblSubTI.Text = SubTI.ToString();

                    lblSubTotal1.Text = string.Format("{0:c}", SubTI);

                    decimal SubTII = 0;

                    txtPercMargemLucro.Text = string.Format("{0:P2}", margem_lucro);
                    txtPercMargemDificuldade.Text = string.Format("{0:P2}", margem_difi);
                    txtPercMargemCriativo.Text = string.Format("{0:P2}", margem_cria);
                    txtPercDesconto.Text = string.Format("{0:P2}", desconto);

                    if (margem_lucro > 0)
                    {
                        lblMargemLucro.Text = string.Format("{0:c}", SubTI * margem_lucro);
                        SubTII = SubTII + (SubTI * margem_lucro);
                    }

                    if (margem_difi > 0)
                    {
                        lblMargemDificuldade.Text = string.Format("{0:c}", SubTI * margem_difi);
                        SubTII = SubTII + (SubTI * margem_difi);
                    }

                    if (margem_cria > 0)
                    {
                        lblMargemCriativo.Text = string.Format("{0:c}", SubTI * margem_cria);
                        SubTII = SubTII + (SubTI * margem_cria);
                    }

                    lblSubTotal2.Text = string.Format("{0:c}", SubTII);

                    lblTotal.Text = string.Format("{0:c}", (SubTI + SubTII));

                    decimal desc = 0;

                    if (desconto > 0)
                    {
                        lblDesconto.Text = string.Format("{0:c}", (SubTI + SubTII) * desconto);
                        desc = (SubTI + SubTII) * desconto;
                    }

                    lblTaxaImposto.Text = string.Format("{0:P2}", imposto);

                    lblImposto.Text = string.Format("{0:c}", ((SubTI + SubTII)-desc) * imposto);

                    lblTotalGeral.Text = string.Format("{0:c}", (SubTI + SubTII -desc) + (((SubTI + SubTII)-desc) * imposto));

                    con.Open();

                    string SelP = "select da_descricao,pp_hora_trabalhada,pp_quantidade from tb_projeto_profissional inner join tb_despesas on pp_profissional=da_id where pp_projeto=@projeto order by da_codigo";
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
        }
        public void Calcula()
        {
            txtPercMargemLucro.Text = txtPercMargemLucro.Text.Replace("%", "");
            txtPercMargemLucro.Text = txtPercMargemLucro.Text.Replace(",", ".");
            txtPercMargemDificuldade.Text = txtPercMargemDificuldade.Text.Replace("%", "");
            txtPercMargemDificuldade.Text = txtPercMargemDificuldade.Text.Replace(",", "."); 
            txtPercMargemCriativo.Text = txtPercMargemCriativo.Text.Replace("%", "");
            txtPercMargemCriativo.Text = txtPercMargemCriativo.Text.Replace(",", ".");
            txtPercDesconto.Text = txtPercDesconto.Text.Replace("%", "");
            txtPercDesconto.Text = txtPercDesconto.Text.Replace(",", ".");
            string a = lblTaxaImposto.Text;
            a = a.Replace("%", "");
            a = a.Replace(",", ".");

            margem_lucro = System.Convert.ToDecimal(txtPercMargemLucro.Text,CultureInfo.InvariantCulture);
            margem_difi = System.Convert.ToDecimal(txtPercMargemDificuldade.Text, CultureInfo.InvariantCulture);
            margem_cria = System.Convert.ToDecimal(txtPercMargemCriativo.Text, CultureInfo.InvariantCulture);
            desconto = System.Convert.ToDecimal(txtPercDesconto.Text, CultureInfo.InvariantCulture);
            imposto = System.Convert.ToDecimal(a, CultureInfo.InvariantCulture);

            margem_lucro = (decimal)margem_lucro/100;
            margem_difi = (decimal)margem_difi / 100; 
            margem_cria = (decimal)margem_cria /100;
            desconto = (decimal)desconto/100;
            imposto = (decimal)imposto / 100;

            txtPercMargemLucro.Text = string.Format("{0:P2}", margem_lucro);
            txtPercMargemDificuldade.Text = string.Format("{0:P2}", margem_difi);
            txtPercMargemCriativo.Text = string.Format("{0:P2}", margem_cria);
            txtPercDesconto.Text = string.Format("{0:P2}", desconto);

            decimal SubTI = Convert.ToDecimal(lblSubTI.Text);

            decimal SubTII = 0;
            if (margem_lucro > 0)
            {
                lblMargemLucro.Text = string.Format("{0:c}", SubTI * margem_lucro);
                SubTII = SubTII + (SubTI * margem_lucro);
            }

            if (margem_difi > 0)
            {
                lblMargemDificuldade.Text = string.Format("{0:c}", SubTI * margem_difi);
                SubTII = SubTII + (SubTI * margem_difi);
            }

            if (margem_cria > 0)
            {
                lblMargemCriativo.Text = string.Format("{0:c}", SubTI * margem_cria);
                SubTII = SubTII + (SubTI * margem_cria);
            }

            lblSubTotal2.Text = string.Format("{0:c}", SubTII);

            lblTotal.Text = string.Format("{0:c}", (SubTI + SubTII));

            decimal desc = 0;

            if (desconto > 0)
            {
                lblDesconto.Text = string.Format("{0:c}", (SubTI + SubTII) * desconto);
                desc = (SubTI + SubTII) * desconto;
            }

            lblTaxaImposto.Text = string.Format("{0:P2}", imposto);

            lblImposto.Text = string.Format("{0:c}", ((SubTI + SubTII) - desc) * imposto);

            lblTotalGeral.Text = string.Format("{0:c}", (SubTI + SubTII - desc) + (((SubTI + SubTII) - desc) * imposto));

            con.Open();

            string Upd = "update tb_projetos set pr_margem_lucro=@margem_lucro,pr_margem_dificuldade=@margem_dificuldade,pr_margem_criativo=@margem_criativo,pr_desconto=@desconto where pr_id=@id";
            MySqlCommand qryUpdate = new MySqlCommand(Upd, con);
            qryUpdate.Parameters.Add("@id", MySqlDbType.Int32).Value = System.Convert.ToInt32(lblProjeto.Text);
            qryUpdate.Parameters.Add("@margem_lucro", MySqlDbType.Decimal).Value = margem_lucro;
            qryUpdate.Parameters.Add("@margem_dificuldade", MySqlDbType.Decimal).Value = margem_difi;
            qryUpdate.Parameters.Add("@margem_criativo", MySqlDbType.Decimal).Value = margem_cria;
            qryUpdate.Parameters.Add("@desconto", MySqlDbType.Decimal).Value = desconto;

            try
            {
                qryUpdate.ExecuteNonQuery();
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

        protected void BtnVolta_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Escritorio/Projeto/Fases/Etapas.aspx?Projeto=" + lblProjeto.Text);
        }
        protected void btnSalvarOBS_Click(object sender, System.EventArgs e)
        {
            var idProjeto = lblProjeto.Text;
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

        protected void BtnCalcula_Click(object sender, EventArgs e)
        {
            Calcula();

        }
    }
}