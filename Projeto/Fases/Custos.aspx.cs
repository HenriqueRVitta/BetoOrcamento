using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Orcamento.Projeto.Fases
{
    public partial class Custos1 : System.Web.UI.Page
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

                    lblProjeto.Text=Request.QueryString["Projeto"].ToString();

                    con.Open();

                    string Sel = "select pc_id,cu_descricao, pc_valor_previsto,cu_id from tb_custos left join tb_projeto_custo on cu_id=pc_custo where pc_projeto=@projeto or pc_id is null order by cu_codigo";
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
                        linha["pc_id"] = reader["pc_id"].ToString();
                        linha["cu_id"] = reader["cu_id"].ToString();
                        linha["cu_descricao"] = reader["cu_descricao"].ToString();
                        linha["pc_valor_previsto"] = reader["pc_valor_previsto"].ToString();

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
            GrdCustos.DataSource = Session["DataTable"];
            GrdCustos.DataBind();
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
            DataColumn.ColumnName = "pc_id";
            DataTable.Columns.Add(DataColumn);

            DataColumn = new DataColumn();
            DataColumn.DataType = Type.GetType("System.String");
            DataColumn.ColumnName = "cu_id";
            DataTable.Columns.Add(DataColumn);

            DataColumn = new DataColumn();
            DataColumn.DataType = Type.GetType("System.String");
            DataColumn.ColumnName = "cu_descricao";
            DataTable.Columns.Add(DataColumn);

            DataColumn = new DataColumn();
            DataColumn.DataType = Type.GetType("System.String");
            DataColumn.ColumnName = "pc_valor_previsto";
            DataTable.Columns.Add(DataColumn);

            return DataTable;
        }

        protected void GrdCustos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GrdCustos.EditIndex = e.NewEditIndex;
            ShowData();
        }

        protected void GrdCustos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GrdCustos.EditIndex = -1;
            ShowData();
        }
        protected void GrdCustos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            DataTable DataTable = new DataTable();

            DataTable=(DataTable)Session["DataTable"];

            GridViewRow row = (GridViewRow)GrdCustos.Rows[e.RowIndex];
            string id = GrdCustos.DataKeys[row.RowIndex].Values["id"].ToString();
            TextBox txt_valor_previsto = GrdCustos.Rows[e.RowIndex].FindControl("txt_valor_previsto") as TextBox;

            for (int i = DataTable.Rows.Count - 1; i >= 0; i--)
            {
                DataRow dr = DataTable.Rows[i];

                if (dr["id"].ToString() == id)
                {
                    dr["pc_valor_previsto"] = txt_valor_previsto.Text;
                }
            }
            DataTable.AcceptChanges();
            GrdCustos.EditIndex = -1;
            ShowData();
        }

        protected void BtnVolta_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Projeto/Fases/Despesas.aspx?Projeto=" + lblProjeto.Text);
        }

        protected void BtnAvanca_Click(object sender, EventArgs e)
        {
            DataTable DataTable = new DataTable();

            DataTable=(DataTable)Session["DataTable"];

            for (int i = DataTable.Rows.Count - 1; i >= 0; i--)
            {
                DataRow dr = DataTable.Rows[i];

                if (dr["pc_id"].ToString().Length == 0 && dr["pc_valor_previsto"].ToString().Length>0)
                {
                    con.Open();

                    string Ins = "insert INTO tb_projeto_custo(pc_projeto,pc_custo,pc_valor_previsto) values(@projeto,@custo,@valor_previsto)";
                    MySqlCommand qryInsert = new MySqlCommand(Ins, con);
                    qryInsert.Parameters.Add("@projeto", MySqlDbType.Int32).Value = Convert.ToInt32(lblProjeto.Text);
                    qryInsert.Parameters.Add("@custo", MySqlDbType.Int32).Value = Convert.ToInt32(dr["cu_id"].ToString());
                    qryInsert.Parameters.Add("@valor_previsto", MySqlDbType.Decimal).Value = Convert.ToDecimal(dr["pc_valor_previsto"].ToString());

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
                    if (dr["pc_valor_previsto"].ToString().Length == 0 && dr["pc_id"].ToString().Length>0)
                    {
                        con.Open();

                        string Del = "delete from tb_projeto_custo where pc_id=@id";
                        MySqlCommand qryDelete = new MySqlCommand(Del, con);
                        qryDelete.Parameters.Add("@id", MySqlDbType.Int32).Value = Convert.ToInt32(dr["pc_id"].ToString());

                        try
                        {
                            qryDelete.ExecuteNonQuery();
                        }
                        catch
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Mensagem", "alert('Erro no Update de Despesas Administrativas.');", true);
                        }
                        finally
                        {
                            qryDelete.Dispose();

                            con.Close();
                        }
                    }
                    else
                    {
                        if (dr["pc_valor_previsto"].ToString().Length > 0 && dr["pc_id"].ToString().Length>0)
                        {
                            con.Open();

                            string Upd = "update tb_projeto_custo set pc_projeto=@projeto,pc_custo=@custo,pc_valor_previsto=@valor_previsto where pc_id=@id";
                            MySqlCommand qryUpdate = new MySqlCommand(Upd, con);
                            qryUpdate.Parameters.Add("@id", MySqlDbType.Int32).Value = Convert.ToInt32(dr["pc_id"].ToString());
                            qryUpdate.Parameters.Add("@projeto", MySqlDbType.Int32).Value = Convert.ToInt32(lblProjeto.Text);
                            qryUpdate.Parameters.Add("@custo", MySqlDbType.Int32).Value = Convert.ToInt32(dr["cu_id"].ToString());
                            qryUpdate.Parameters.Add("@valor_previsto", MySqlDbType.Decimal).Value = Convert.ToDecimal(dr["pc_valor_previsto"].ToString());

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

            Response.Redirect("~/Projeto/Fases/Etapas.aspx?Projeto=" + lblProjeto.Text);
        }
    }
}