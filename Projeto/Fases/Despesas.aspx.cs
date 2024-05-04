using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
        internal DataTable dtb = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Projeto"] != null)
            {
                if (!Page.IsPostBack)
                {
                    dtb = new DataTable();

                    dtb = CriaDataTable();

                    lblProjeto.Text = Request.QueryString["Projeto"].ToString();

                    con.Open();

                    string Sel = "select pd_id,da_descricao,pd_valor_previsto,da_id from tb_despesas left join tb_projeto_despesas on da_id=pd_despesa where pd_projeto=@projeto or pd_id is null order by da_codigo";
                    MySqlCommand qrySelect = new MySqlCommand(Sel, con);
                    qrySelect.Parameters.Add("@projeto", MySqlDbType.Int32).Value = Convert.ToInt32(lblProjeto.Text);
                    MySqlDataReader reader = qrySelect.ExecuteReader();

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
                        linha["pd_valor_previsto"] = reader["pd_valor_previsto"].ToString();

                        dtb.Rows.Add(linha);
                    }

                    qrySelect.Dispose();
                    con.Close();

                    Session["DataTable"] = dtb;

                    ShowData();
                }
            }
        }
        protected void ShowData()
        {
            GrdDespesas.DataSource = Session["DataTable"];
            GrdDespesas.DataBind();
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
            DataColumn.DataType = Type.GetType("System.String");
            DataColumn.ColumnName = "pd_valor_previsto";
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
            DataTable DataTable = new DataTable();

            DataTable=(DataTable)Session["DataTable"];

            GridViewRow row = (GridViewRow)GrdDespesas.Rows[e.RowIndex];
            string id = GrdDespesas.DataKeys[row.RowIndex].Values["id"].ToString();
            TextBox txt_valor_previsto = GrdDespesas.Rows[e.RowIndex].FindControl("txt_valor_previsto") as TextBox;

            for (int i = DataTable.Rows.Count - 1; i >= 0; i--)
            {
                DataRow dr = DataTable.Rows[i];

                if ( dr["id"].ToString() == id )
                {
                    dr["pd_valor_previsto"] = txt_valor_previsto.Text;
                }
            }
            DataTable.AcceptChanges();
            GrdDespesas.EditIndex = -1;
            ShowData();
        }

        protected void BtnAvanca_Click(object sender, EventArgs e)
        {
            DataTable DataTable = new DataTable();

            DataTable=(DataTable)Session["DataTable"];

            for (int i = DataTable.Rows.Count - 1; i >= 0; i--)
            {
                DataRow dr = DataTable.Rows[i];

                if (dr["pd_id"].ToString().Length == 0 && dr["pd_valor_previsto"].ToString().Length>0)
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
                    if (dr["pd_valor_previsto"].ToString().Length == 0 && dr["pd_id"].ToString().Length>0)
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
                        if (dr["pd_valor_previsto"].ToString().Length > 0 && dr["pd_id"].ToString().Length>0)
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

        protected void BtnVolta_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Projeto/Criacao/Lista.aspx?Projeto=" + lblProjeto.Text);
        }
    }
}