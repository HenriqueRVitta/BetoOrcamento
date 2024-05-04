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
    public partial class Etapas1 : System.Web.UI.Page
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

                    string Sel = "select pe_id,et_descricao, pe_hora_previsto,et_id from tb_etapas left join tb_projeto_etapas on et_id=pe_etapa where pe_projeto=@projeto or pe_id is null order by et_codigo";
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
                        linha["pe_id"] = reader["pe_id"].ToString();
                        linha["et_id"] = reader["et_id"].ToString();
                        linha["et_descricao"] = reader["et_descricao"].ToString();
                        linha["pe_hora_previsto"] = reader["pe_hora_previsto"].ToString();

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
            GrdEtapas.DataSource = Session["DataTable"];
            GrdEtapas.DataBind();
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
            DataColumn.ColumnName = "pe_id";
            DataTable.Columns.Add(DataColumn);

            DataColumn = new DataColumn();
            DataColumn.DataType = Type.GetType("System.String");
            DataColumn.ColumnName = "et_id";
            DataTable.Columns.Add(DataColumn);

            DataColumn = new DataColumn();
            DataColumn.DataType = Type.GetType("System.String");
            DataColumn.ColumnName = "et_descricao";
            DataTable.Columns.Add(DataColumn);

            DataColumn = new DataColumn();
            DataColumn.DataType = Type.GetType("System.String");
            DataColumn.ColumnName = "pe_hora_previsto";
            DataTable.Columns.Add(DataColumn);

            return DataTable;
        }

        protected void GrdEtapas_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GrdEtapas.EditIndex = e.NewEditIndex;
            ShowData();
        }

        protected void GrdEtapas_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GrdEtapas.EditIndex = -1;
            ShowData();
        }
        protected void GrdEtapas_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            DataTable DataTable = new DataTable();

            DataTable=(DataTable)Session["DataTable"];

            GridViewRow row = (GridViewRow)GrdEtapas.Rows[e.RowIndex];
            string id = GrdEtapas.DataKeys[row.RowIndex].Values["id"].ToString();
            TextBox txt_valor_previsto = GrdEtapas.Rows[e.RowIndex].FindControl("txt_hora_previsto") as TextBox;

            for (int i = DataTable.Rows.Count - 1; i >= 0; i--)
            {
                DataRow dr = DataTable.Rows[i];

                if (dr["id"].ToString() == id)
                {
                    dr["pe_hora_previsto"] = txt_valor_previsto.Text;
                }
            }
            DataTable.AcceptChanges();
            GrdEtapas.EditIndex = -1;
            ShowData();
        }

        protected void BtnVolta_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Projeto/Fases/Custos.aspx?Projeto=" +lblProjeto.Text);
        }

        protected void BtnAvanca_Click(object sender, EventArgs e)
        {
            DataTable DataTable = new DataTable();

            DataTable=(DataTable)Session["DataTable"];

            for (int i = DataTable.Rows.Count - 1; i >= 0; i--)
            {
                DataRow dr = DataTable.Rows[i];

                if (dr["pe_id"].ToString().Length == 0 && dr["pe_hora_previsto"].ToString().Length>0)
                {
                    con.Open();

                    string Ins = "insert INTO tb_projeto_etapas(pe_projeto,pe_etapa,pe_hora_previsto,pe_realisado) values(@projeto,@etapa,@hora_previsto,0)";
                    MySqlCommand qryInsert = new MySqlCommand(Ins, con);
                    qryInsert.Parameters.Add("@projeto", MySqlDbType.Int32).Value = Convert.ToInt32(lblProjeto.Text);
                    qryInsert.Parameters.Add("@etapa", MySqlDbType.Int32).Value = Convert.ToInt32(dr["et_id"].ToString());
                    qryInsert.Parameters.Add("@hora_previsto", MySqlDbType.Decimal).Value = Convert.ToDecimal(dr["pe_hora_previsto"].ToString());

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
                    if (dr["pe_hora_previsto"].ToString().Length == 0 && dr["pe_id"].ToString().Length>0)
                    {
                        con.Open();

                        string Del = "delete from tb_projeto_etapas where pe_id=@id";
                        MySqlCommand qryDelete = new MySqlCommand(Del, con);
                        qryDelete.Parameters.Add("@id", MySqlDbType.Int32).Value = Convert.ToInt32(dr["pe_id"].ToString());

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
                        if (dr["pe_hora_previsto"].ToString().Length > 0 && dr["pe_id"].ToString().Length>0)
                        {
                            con.Open();

                            string Upd = "update tb_projeto_etapas set pe_projeto=@projeto,pe_etapa=@etapa,pe_hora_previsto=@hora_previsto where pe_id=@id";
                            MySqlCommand qryUpdate = new MySqlCommand(Upd, con);
                            qryUpdate.Parameters.Add("@id", MySqlDbType.Int32).Value = Convert.ToInt32(dr["pe_id"].ToString());
                            qryUpdate.Parameters.Add("@projeto", MySqlDbType.Int32).Value = Convert.ToInt32(lblProjeto.Text);
                            qryUpdate.Parameters.Add("@etapa", MySqlDbType.Int32).Value = Convert.ToInt32(dr["et_id"].ToString());
                            qryUpdate.Parameters.Add("@hora_previsto", MySqlDbType.Decimal).Value = Convert.ToDecimal(dr["pe_hora_previsto"].ToString());

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

            Response.Redirect("~/Projeto/Fases/Profissionais/Lista.aspx?Projeto=" +lblProjeto.Text);
        }
    }
}