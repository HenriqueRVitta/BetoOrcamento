using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Orcamento.Projeto.Fases
{
    public partial class Despesas : System.Web.UI.Page
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        MySqlConnection con1 = new MySqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());

        internal DataTable dtb = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Projeto"] != null)
            {
                if (!Page.IsPostBack)
                {

                    lblProjeto.Text = Request.QueryString["Projeto"].ToString();

                    con.Open();

                    string SelN = "select pr_nome from tb_projetos where pr_id=@projeto";
                    MySqlCommand qrySelectN = new MySqlCommand(SelN, con);
                    qrySelectN.Parameters.Add("@projeto", MySqlDbType.Int32).Value = Convert.ToInt32(lblProjeto.Text);
                    MySqlDataReader readerN = qrySelectN.ExecuteReader();

                    while (readerN.Read())
                    {
                        LblNome.Text = readerN["pr_nome"].ToString();
                    }

                    qrySelectN.Dispose();
                    con.Close();

                    con.Open();

                    string SelT = "select sum(pd_valor_previsto) as total from tb_despesas left join tb_projeto_despesas on da_id=pd_despesa where pd_projeto=@projeto";
                    MySqlCommand qrySelectT = new MySqlCommand(SelT, con);
                    qrySelectT.Parameters.Add("@projeto", MySqlDbType.Int32).Value = Convert.ToInt32(lblProjeto.Text);
                    MySqlDataReader readerT = qrySelectT.ExecuteReader();

                    while (readerT.Read())
                    {
                        lblTotal.Text = readerT["total"].ToString();
                    }
                    double total = 0;
                    qrySelectT.Dispose();
                    con.Close();

                    dtb = new DataTable();

                    dtb = CriaDataTable();

                    con.Open();

                    string Sel = "select pd_id,da_descricao,pd_valor_previsto,da_id,da_codigo,da_formula,COALESCE(pp_valor, 0) as pp_valor,COALESCE(pp_quantidade, 1) as pp_quantidade from (select * from tb_despesas left join tb_projeto_despesas on da_id=pd_despesa and pd_projeto=@projeto or pd_id is null order by da_codigo) as b left join tb_projeto_profissional on b.da_id=pp_profissional and pp_projeto=@projeto";
                    MySqlCommand qrySelect = new MySqlCommand(Sel, con);
                    qrySelect.Parameters.Add("@projeto", MySqlDbType.Int32).Value = Convert.ToInt32(lblProjeto.Text);
                    MySqlDataReader reader = qrySelect.ExecuteReader();

                    total = Convert.ToDouble(lblTotal.Text);
                    int indice = 0;

                    while (reader.Read())
                    {
                        indice++;
                        DataRow linha;

                        linha = dtb.NewRow();

                        linha["id"] = indice;
                        linha["pd_id"] = reader["pd_id"].ToString();
                        linha["da_id"] = reader["da_id"].ToString();
                        linha["da_descricao"] = reader["da_descricao"].ToString();
                        if (reader["da_formula"].ToString().Length == 0)
                            linha["pd_valor_previsto"] = Convert.ToDouble(reader["pp_valor"].ToString()) * Convert.ToInt16(reader["pp_quantidade"].ToString());
                        else
                        {
                            if (reader["pd_valor_previsto"].ToString().Length > 0)
                                linha["pd_valor_previsto"] = Convert.ToDouble(reader["pd_valor_previsto"].ToString());
                            else
                                linha["pd_valor_previsto"] = 0;
                        }
                        linha["da_codigo"] = reader["da_codigo"].ToString();
                        linha["da_formula"] = reader["da_formula"].ToString();

                        string teste = linha["pd_valor_previsto"].ToString();
                        linha["percentual"] = ((double)linha["pd_valor_previsto"] / total);

                        dtb.Rows.Add(linha);
                    }

                    qrySelect.Dispose();
                    con.Close();

                    con.Open();
                    string SelF = "select da_codigo,da_formula from (select * from tb_despesas left join tb_projeto_despesas on da_id=pd_despesa and pd_projeto=@projeto or pd_id is null order by da_codigo) as b left join tb_projeto_profissional on b.da_id=pp_profissional and pp_projeto=@projeto where da_formula is not null";
                    MySqlCommand qrySelectF = new MySqlCommand(SelF, con);
                    qrySelectF.Parameters.Add("@projeto", MySqlDbType.Int32).Value = Convert.ToInt32(lblProjeto.Text);
                    MySqlDataReader readerF = qrySelectF.ExecuteReader();
                    string Valor = "";
                    string Campo = "";

                    while (readerF.Read())
                    {
                        string formula = readerF["da_formula"].ToString();

                        int c = 0;
                        while (c <= formula.Length)
                        {
                            if (readerF["da_formula"].ToString().IndexOf("#", c) != -1)
                            {
                                Campo = readerF["da_formula"].ToString().Substring(readerF["da_formula"].ToString().IndexOf("#", c), 5);

                                c = readerF["da_formula"].ToString().IndexOf("#", c) + 1;

                                for (int i = dtb.Rows.Count - 1; i >= 0; i--)
                                {
                                    DataRow dr = dtb.Rows[i];

                                    if (dr["da_codigo"].ToString() == Campo.Substring(1, 4))
                                    {
                                        Valor = dr["pd_valor_previsto"].ToString();
                                        break;
                                    }
                                }
                                formula = formula.Replace(Campo, Valor);
                            }
                            else
                                c = formula.Length + 1;
                        }

                        if (formula.IndexOf("%") != - 1)
                        {
                            int aliquota = Convert.ToInt16(formula.Substring(formula.IndexOf("%") + 1, 1));

                            Campo = "%" + aliquota.ToString();

                            con1.Open();

                            string SelA = "select al_percentual from tb_aliquota where al_indice=@aliquota";
                            MySqlCommand qrySelectA = new MySqlCommand(SelA, con1);
                            qrySelectA.Parameters.Add("@aliquota", MySqlDbType.Int16).Value = aliquota;
                            MySqlDataReader readerA = qrySelectA.ExecuteReader();

                            string percentual = "";

                            while (readerA.Read())
                            {
                                percentual = "("+readerA["al_percentual"].ToString()+"/100)";
                            }

                            qrySelectA.Dispose();
                            con1.Close();

                            formula = formula.Replace(Campo, percentual);
                        }

                        if (formula.IndexOf("se") != -1)
                        {
                            formula = formula.Replace("se", "");

                            Campo = formula.Substring(0, formula.IndexOf("("));

                            formula = formula.Replace(Campo, "");
                        }

                        if ( Convert.ToDecimal(Valor) > 0)
                        {
                            var norberto = Calcular(formula.Replace(",", "."));

                            for (int i = dtb.Rows.Count - 1; i >= 0; i--)
                            {
                                DataRow dr = dtb.Rows[i];

                                if (dr["da_codigo"].ToString() == readerF["da_codigo"].ToString())
                                {
                                    dr["pd_valor_previsto"] = norberto;
                                }
                            }
                        }
                    }

                    for (int i = dtb.Rows.Count - 1; i >= 0; i--)
                    {
                        DataRow dr = dtb.Rows[i];

                        if (dr["pd_valor_previsto"].ToString().Length>0)
                            dr["percentual"] = ((double)dr["pd_valor_previsto"] / total);
                    }

                    lblTotal.Text = total.ToString();

                    qrySelectF.Dispose();
                    con.Close();

                    var query = from r in dtb.AsEnumerable()
                                where ((r.Field<string>("da_codigo").Substring(0,2) == "01" && r.Field<double>("pd_valor_previsto") >0)|| r.Field<string>("da_codigo").Substring(0, 2) != "01")
                                select r;
                    DataTable dtLink = new DataTable();
                    dtLink = query.CopyToDataTable();
                    Session["DataTable"] = dtLink;

                    ShowData();
                }
            }
        }
        protected void ShowData()
        {
            DataTable DataTable = new DataTable();
            DataTable = (DataTable)Session["DataTable"];
            GrdDespesas.DataSource = DataTable;
            GrdDespesas.DataBind();

            if (DataTable.Rows.Count > 0)
            {
                string total = DataTable.Compute("SUM(pd_valor_previsto)", String.Empty).ToString();

                GrdDespesas.FooterRow.Cells[0].Text = "Total--> ";
                GrdDespesas.FooterRow.Cells[1].Text = string.Format("{0:c}", Convert.ToDecimal(total));
            }
        }

        protected void GrdDespesas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdDespesas.PageIndex = e.NewPageIndex;
            ShowData();
        }
        private DataTable CriaDataTable()
        {
            DataTable DataTable = new DataTable();
            DataColumn DataColumn;

            DataColumn = new DataColumn();
            DataColumn.DataType = Type.GetType("System.Int16");
            DataColumn.ColumnName = "id";
            DataTable.Columns.Add(DataColumn);

            DataColumn = new DataColumn();
            DataColumn.DataType = Type.GetType("System.String");
            DataColumn.ColumnName = "pd_id";
            DataTable.Columns.Add(DataColumn);

            DataColumn = new DataColumn();
            DataColumn.DataType = Type.GetType("System.String");
            DataColumn.ColumnName = "da_id";
            DataTable.Columns.Add(DataColumn);

            DataColumn = new DataColumn();
            DataColumn.DataType = Type.GetType("System.String");
            DataColumn.ColumnName = "da_descricao";
            DataTable.Columns.Add(DataColumn);

            DataColumn = new DataColumn();
            DataColumn.DataType = Type.GetType("System.Double");
            DataColumn.ColumnName = "pd_valor_previsto";
            DataTable.Columns.Add(DataColumn);

            DataColumn = new DataColumn();
            DataColumn.DataType = Type.GetType("System.String");
            DataColumn.ColumnName = "da_codigo";
            DataTable.Columns.Add(DataColumn);

            DataColumn = new DataColumn();
            DataColumn.DataType = Type.GetType("System.String");
            DataColumn.ColumnName = "da_formula";
            DataTable.Columns.Add(DataColumn);

            DataColumn = new DataColumn();
            DataColumn.DataType = Type.GetType("System.Decimal");
            DataColumn.ColumnName = "percentual";
            DataTable.Columns.Add(DataColumn);

            return DataTable;
        }

        protected void GrdDespesas_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GrdDespesas.EditIndex = e.NewEditIndex;
            ShowData();
        }

        protected void GrdDespesas_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GrdDespesas.EditIndex = -1;
            ShowData();
        }
        protected void GrdDespesas_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            double total = Convert.ToDouble(lblTotal.Text);
            DataTable DataTable = new DataTable();

            DataTable = (DataTable)Session["DataTable"];

            GridViewRow row = (GridViewRow)GrdDespesas.Rows[e.RowIndex];
            string id = GrdDespesas.DataKeys[row.RowIndex].Values["id"].ToString();
            TextBox txt_valor_previsto = GrdDespesas.Rows[e.RowIndex].FindControl("txt_valor_previsto") as TextBox;

            for (int i = DataTable.Rows.Count - 1; i >= 0; i--)
            {
                DataRow dr = DataTable.Rows[i];

                if (txt_valor_previsto.Text.Length == 0)
                    txt_valor_previsto.Text = "0";

                if (dr["pd_valor_previsto"].ToString().Length > 0)
                {
                    total = total - (double)dr["pd_valor_previsto"];
                }

                if (dr["id"].ToString() == id)
                {
                    dr["pd_valor_previsto"] = txt_valor_previsto.Text;
                }

                if (dr["pd_valor_previsto"].ToString().Length > 0)
                {
                    total = total + (double)dr["pd_valor_previsto"];
                }
            }

            for (int i = DataTable.Rows.Count - 1; i >= 0; i--)
            {
                DataRow dr = DataTable.Rows[i];

                if (dr["pd_valor_previsto"].ToString().Length > 0)
                {
                    dr["percentual"] = ((double)dr["pd_valor_previsto"] / total);
                }
            }

            lblTotal.Text = total.ToString();

            DataTable.AcceptChanges();
            GrdDespesas.EditIndex = -1;
            ShowData();
        }

        protected void BtnAvanca_Click(object sender, EventArgs e)
        {
            DataTable DataTable = new DataTable();

            DataTable = (DataTable)Session["DataTable"];

            for (int i = DataTable.Rows.Count - 1; i >= 0; i--)
            {
                DataRow dr = DataTable.Rows[i];

                if (dr["pd_id"].ToString().Length == 0 && Convert.ToDecimal(dr["pd_valor_previsto"].ToString()) > 0)
                {
                    con.Open();

                    string Ins = "insert INTO tb_projeto_despesas(pd_projeto,pd_despesa,pd_valor_previsto) values(@projeto,@despesa,@valor_previsto)";
                    MySqlCommand qryInsert = new MySqlCommand(Ins, con);
                    qryInsert.Parameters.Add("@projeto", MySqlDbType.Int32).Value = Convert.ToInt32(lblProjeto.Text);
                    qryInsert.Parameters.Add("@despesa", MySqlDbType.Int32).Value = Convert.ToInt32(dr["da_id"].ToString());
                    qryInsert.Parameters.Add("@valor_previsto", MySqlDbType.Decimal).Value = Convert.ToDecimal(dr["pd_valor_previsto"].ToString());

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
                    if (dr["pd_valor_previsto"].ToString().Length == 0 && dr["pd_id"].ToString().Length > 0)
                    {
                        con.Open();

                        string Del = "delete from tb_projeto_despesas where pd_id=@id";
                        MySqlCommand qryDelete = new MySqlCommand(Del, con);
                        qryDelete.Parameters.Add("@id", MySqlDbType.Int32).Value = Convert.ToInt32(dr["pd_id"].ToString());

                        try
                        {
                            qryDelete.ExecuteNonQuery();
                        }
                        catch
                        {
                        }
                        finally
                        {
                            qryDelete.Dispose();

                            con.Close();
                        }
                    }
                    else
                    {
                        if (dr["pd_valor_previsto"].ToString().Length > 0 && dr["pd_id"].ToString().Length > 0)
                        {
                            con.Open();

                            string Upd = "update tb_projeto_despesas set pd_projeto=@projeto,pd_despesa=@despesa,pd_valor_previsto=@valor_previsto where pd_id=@id";
                            MySqlCommand qryUpdate = new MySqlCommand(Upd, con);
                            qryUpdate.Parameters.Add("@id", MySqlDbType.Int32).Value = Convert.ToInt32(dr["pd_id"].ToString());
                            qryUpdate.Parameters.Add("@projeto", MySqlDbType.Int32).Value = Convert.ToInt32(lblProjeto.Text);
                            qryUpdate.Parameters.Add("@despesa", MySqlDbType.Int32).Value = Convert.ToInt32(dr["da_id"].ToString());
                            qryUpdate.Parameters.Add("@valor_previsto", MySqlDbType.Decimal).Value = Convert.ToDecimal(dr["pd_valor_previsto"].ToString());

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

            Response.Redirect("~/Projeto/Fases/Custos.aspx?Projeto=" + lblProjeto.Text);
        }
        public static double Calcular(string expression)
        {
            return (double)new System.Xml.XPath.XPathDocument
            (new StringReader("<r/>")).CreateNavigator().Evaluate
            (string.Format("number({0})", new
            System.Text.RegularExpressions.Regex(@"([\+\-\*])")
            .Replace(expression, " ${1} ")
            .Replace("/", " div ")
            .Replace("%", " mod ")
            .Replace("x", " * ")));
        }
        protected void BtnVolta_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Projeto/Fases/Profissionais/Lista.aspx?Projeto=" + lblProjeto.Text);
        }

        protected void GrdDespesas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (GrdDespesas.DataKeys[e.Row.RowIndex].Values["da_codigo"].ToString().Substring(0, 2) == "01")
                {
                    ImageButton imgSave = (ImageButton)e.Row.FindControl("btn_Edit");
                    if (imgSave != null)
                    {
                        imgSave.Visible = false;
                    }
                }
                else
                {
                    ImageButton imgSave = (ImageButton)e.Row.FindControl("btn_Edit");
                    if (imgSave != null)
                    {
                        imgSave.Visible = true;
                    }
                }

            }
        }
    }
}