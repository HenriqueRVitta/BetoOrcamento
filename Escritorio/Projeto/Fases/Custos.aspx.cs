using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
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

                    string SelT = "select sum(pc_valor_previsto) as total from tb_projeto_custo where pc_projeto=@projeto";
                    MySqlCommand qrySelectT = new MySqlCommand(SelT, con);
                    qrySelectT.Parameters.Add("@projeto", MySqlDbType.Int32).Value = Convert.ToInt32(lblProjeto.Text);
                    MySqlDataReader readerT = qrySelectT.ExecuteReader();

                    double total = 0;

                    while (readerT.Read())
                    {
                        lblTotal.Text= readerT["total"].ToString();
                    }

                    qrySelectT.Dispose();
                    con.Close();

                    dtb = new DataTable();

                    dtb = CriaDataTable();

                    con.Open();

                    string Sel = "select pc_id,cu_descricao, pc_valor_previsto,cu_id from tb_custos left join tb_projeto_custo on cu_id=pc_custo where pc_projeto=@projeto or pc_id is null order by cu_codigo";
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
                        linha["pc_id"] = reader["pc_id"].ToString();
                        linha["cu_id"] = reader["cu_id"].ToString();
                        linha["cu_descricao"] = reader["cu_descricao"].ToString();

                        if (reader["pc_valor_previsto"].ToString().Length > 0)
                           linha["pc_valor_previsto"] = Convert.ToDouble(reader["pc_valor_previsto"].ToString());
                        else
                            linha["pc_valor_previsto"] = 0;

                        linha["percentual"] = ((double)linha["pc_valor_previsto"] / total);

                        dtb.Rows.Add(linha);
                    }

                    qrySelect.Dispose();
                    con.Close();

                    Session["DataTable"] = dtb;

                    ShowData();
                }
            }
        }

        protected void GrdCustos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdCustos.PageIndex = e.NewPageIndex;
            ShowData();
        }

        protected void ShowData()
        {
            DataTable DataTable = new DataTable();
            DataTable = (DataTable)Session["DataTable"];
            GrdCustos.DataSource = DataTable;
            GrdCustos.DataBind();

            if (DataTable.Rows.Count > 0)
            {
                string total = DataTable.Compute("SUM(pc_valor_previsto)", String.Empty).ToString();

                GrdCustos.FooterRow.Cells[0].Text = "Total--> ";
                GrdCustos.FooterRow.Cells[1].Text = string.Format("{0:c}", Convert.ToDecimal(total));
            }
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
            DataColumn.DataType = Type.GetType("System.Double");
            DataColumn.ColumnName = "pc_valor_previsto";
            DataTable.Columns.Add(DataColumn);

            DataColumn = new DataColumn();
            DataColumn.DataType = Type.GetType("System.Double");
            DataColumn.ColumnName = "percentual";
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
            double total = Convert.ToDouble(lblTotal.Text);
            DataTable DataTable = new DataTable();

            DataTable = (DataTable)Session["DataTable"];

            GridViewRow row = (GridViewRow)GrdCustos.Rows[e.RowIndex];
            string id = GrdCustos.DataKeys[row.RowIndex].Values["id"].ToString();
            TextBox txt_valor_previsto = GrdCustos.Rows[e.RowIndex].FindControl("txt_valor_previsto") as TextBox;

            for (int i = DataTable.Rows.Count - 1; i >= 0; i--)
            {
                DataRow dr = DataTable.Rows[i];

                if (txt_valor_previsto.Text.Length == 0)
                    txt_valor_previsto.Text = "0";

                if (dr["pc_valor_previsto"].ToString().Length > 0)
                {
                    total = total - (double)dr["pc_valor_previsto"];
                }

                if (dr["id"].ToString() == id)
                {
                    dr["pc_valor_previsto"] = Convert.ToDouble(txt_valor_previsto.Text);
                }

                if (dr["pc_valor_previsto"].ToString().Length > 0)
                {
                    total = total + (double)dr["pc_valor_previsto"];
                }
            }

            for (int i = DataTable.Rows.Count - 1; i >= 0; i--)
            {
                DataRow dr = DataTable.Rows[i];

                if (dr["pc_valor_previsto"].ToString().Length > 0)
                {
                    dr["percentual"] = ((double)dr["pc_valor_previsto"] / total);
                }
            }
            lblTotal.Text = total.ToString();
            DataTable.AcceptChanges();
            GrdCustos.EditIndex = -1;
            ShowData();
        }

        protected void BtnVolta_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Escritorio/Projeto/Fases/Profissionais/Lista.aspx?Projeto=" + lblProjeto.Text);
        }

        protected void BtnAvanca_Click(object sender, EventArgs e)
        {
            DataTable DataTable = new DataTable();

            DataTable = (DataTable)Session["DataTable"];

            for (int i = DataTable.Rows.Count - 1; i >= 0; i--)
            {
                DataRow dr = DataTable.Rows[i];

                if (dr["pc_id"].ToString().Length == 0 && (dr["pc_valor_previsto"].ToString().Length>0 && Convert.ToDecimal(dr["pc_valor_previsto"].ToString()) > 0))
                {
                    con.Open();

                    string Ins = "insert INTO tb_projeto_custo(pc_projeto,pc_custo,pc_valor_previsto) values(@projeto,@custo,@valor_previsto)";
                    MySqlCommand qryInsert = new MySqlCommand(Ins, con);
                    qryInsert.Parameters.Add("@projeto", MySqlDbType.Int32).Value = Convert.ToInt32(lblProjeto.Text);
                    qryInsert.Parameters.Add("@custo", MySqlDbType.Int32).Value = Convert.ToInt32(dr["cu_id"].ToString());
                    qryInsert.Parameters.Add("@valor_previsto", MySqlDbType.Decimal).Value = dr["pc_valor_previsto"];

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
                    if (dr["pc_valor_previsto"].ToString().Length == 0 && dr["pc_id"].ToString().Length > 0)
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
                        if (dr["pc_valor_previsto"].ToString().Length > 0 && dr["pc_id"].ToString().Length > 0)
                        {
                            con.Open();

                            string Upd = "update tb_projeto_custo set pc_projeto=@projeto,pc_custo=@custo,pc_valor_previsto=@valor_previsto where pc_id=@id";
                            MySqlCommand qryUpdate = new MySqlCommand(Upd, con);
                            qryUpdate.Parameters.Add("@id", MySqlDbType.Int32).Value = Convert.ToInt32(dr["pc_id"].ToString());
                            qryUpdate.Parameters.Add("@projeto", MySqlDbType.Int32).Value = Convert.ToInt32(lblProjeto.Text);
                            qryUpdate.Parameters.Add("@custo", MySqlDbType.Int32).Value = Convert.ToInt32(dr["cu_id"].ToString());
                            qryUpdate.Parameters.Add("@valor_previsto", MySqlDbType.Decimal).Value = dr["pc_valor_previsto"];

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

    }
}