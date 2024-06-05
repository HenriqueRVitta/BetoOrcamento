using Antlr.Runtime;
using Microsoft.Ajax.Utilities;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
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

                    string SelT = "select sum(pe_hora_previsto) as total from tb_projeto_etapas where pe_projeto=@projeto";
                    MySqlCommand qrySelectT = new MySqlCommand(SelT, con);
                    qrySelectT.Parameters.Add("@projeto", MySqlDbType.Int32).Value = Convert.ToInt32(lblProjeto.Text);
                    MySqlDataReader readerT = qrySelectT.ExecuteReader();

                    double total = 0;

                    while (readerT.Read())
                    {
                        lblTotal.Text = readerT["total"].ToString();
                    }

                    if (lblTotal.Text != "")
                        total = Convert.ToDouble(lblTotal.Text);

                    qrySelectT.Dispose();
                    con.Close();

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


                        if (reader["pe_hora_previsto"].ToString().Length > 0)
                        {
                            string hora = TimeSpan.FromHours(Convert.ToDouble(reader["pe_hora_previsto"].ToString())).ToString("c");

                            if (hora.Length > 8)
                            {
                                linha["pe_hora_previsto"] =  Convert.ToInt32(hora.Substring(0, hora.IndexOf(".")))*24;
                                linha["pe_hora_previsto"] = (Int32)linha["pe_hora_previsto"] + Convert.ToInt32(hora.Substring(hora.IndexOf(".") + 1, 2));
                                linha["pe_minuto_previsto"] = Convert.ToInt16(hora.Substring(hora.IndexOf(".") + 4, 2));
                            }
                            else
                            {
                                if (hora.Length == 8)
                                {
                                    if (hora.Substring(0, 2) != "00")
                                    {
                                        linha["pe_hora_previsto"] = Convert.ToInt32(hora.Substring(0, 2));
                                        linha["pe_minuto_previsto"] = Convert.ToInt16(hora.Substring(3, 2));
                                    }
                                    else
                                    {
                                        linha["pe_hora_previsto"] = 0;
                                        linha["pe_minuto_previsto"] = Convert.ToInt16(hora.Substring(3, 2));
                                    }
                                }
                            }
                        }
                        else
                        {
                            linha["pe_hora_previsto"] = 0;

                            linha["pe_minuto_previsto"]= 0;
                        }

                        int dia = (Int32)linha["pe_hora_previsto"] / 24;

                        int hor = (Int32)linha["pe_hora_previsto"]-(dia * 24);

                        int min = (Int16)linha["pe_minuto_previsto"];

                        string cal = "";

                        if(dia>0)
                            cal = dia.ToString() + "." + hor.ToString().PadLeft(2, '0') + ":" + min.ToString().PadLeft(2, '0') + ":00";
                        else
                            cal = hor.ToString().PadLeft(2, '0') + ":" + min.ToString().PadLeft(2, '0') + ":00";

                        linha["percentual"] = (double)Convert.ToDecimal(TimeSpan.Parse(cal).TotalHours) / total;

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
            DataTable DataTable = new DataTable();
            DataTable = (DataTable)Session["DataTable"];
            GrdEtapas.DataSource = Session["DataTable"];
            GrdEtapas.DataBind();

            if (DataTable.Rows.Count > 0)
            {
                string totalH = DataTable.Compute("SUM(pe_hora_previsto)", String.Empty).ToString();
                string totalM = DataTable.Compute("SUM(pe_minuto_previsto)", String.Empty).ToString();

                int hora = Convert.ToInt16(totalM)/60;
                int minuto = Convert.ToInt16(totalM) - (hora * 60);

                totalM = minuto.ToString();

                totalH = (Convert.ToInt32(totalH) + hora).ToString();

                GrdEtapas.FooterRow.Cells[0].Text = "Total--> ";
                GrdEtapas.FooterRow.Cells[1].Text = totalH;
                GrdEtapas.FooterRow.Cells[2].Text = totalM;
            }
        }

        protected void GrdEtapas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdEtapas.PageIndex = e.NewPageIndex;
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
            DataColumn.DataType = Type.GetType("System.Int32");
            DataColumn.ColumnName = "pe_hora_previsto";
            DataTable.Columns.Add(DataColumn);

            DataColumn = new DataColumn();
            DataColumn.DataType = Type.GetType("System.Int16");
            DataColumn.ColumnName = "pe_minuto_previsto";
            DataTable.Columns.Add(DataColumn);

            DataColumn = new DataColumn();
            DataColumn.DataType = Type.GetType("System.Double");
            DataColumn.ColumnName = "percentual";
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
            double total = Convert.ToDouble(lblTotal.Text);
            DataTable DataTable = new DataTable();

            DataTable=(DataTable)Session["DataTable"];

            GridViewRow row = (GridViewRow)GrdEtapas.Rows[e.RowIndex];
            string id = GrdEtapas.DataKeys[row.RowIndex].Values["id"].ToString();
            TextBox txt_hora_previsto = GrdEtapas.Rows[e.RowIndex].FindControl("txt_hora_previsto") as TextBox;
            TextBox txt_minuto_previsto = GrdEtapas.Rows[e.RowIndex].FindControl("txt_minuto_previsto") as TextBox;

            for (int i = DataTable.Rows.Count - 1; i >= 0; i--)
            {
                DataRow dr = DataTable.Rows[i];

                if (txt_hora_previsto.ToString().Length == 0)
                    txt_hora_previsto.Text = "0";

                if (txt_minuto_previsto.ToString().Length == 0)
                    txt_minuto_previsto.Text = "0";

                int dia = (Int32)dr["pe_hora_previsto"] / 24;

                int hor = (Int32)dr["pe_hora_previsto"] - (dia * 24);

                int min = (Int16)dr["pe_minuto_previsto"];

                string cal = "";

                if (dia > 0)
                    cal = dia.ToString() + "." + hor.ToString().PadLeft(2, '0') + ":" + min.ToString().PadLeft(2, '0') + ":00";
                else
                    cal = hor.ToString().PadLeft(2, '0') + ":" + min.ToString().PadLeft(2, '0') + ":00";

                total = total - (double)Convert.ToDecimal(TimeSpan.Parse(cal).TotalHours);


                if (dr["id"].ToString() == id)
                {
                    dr["pe_hora_previsto"] = txt_hora_previsto.Text;
                    dr["pe_minuto_previsto"] = txt_minuto_previsto.Text;
                }
                
                dia = (Int32)dr["pe_hora_previsto"] / 24;

                hor = (Int32)dr["pe_hora_previsto"] - (dia * 24);

                min = (Int16)dr["pe_minuto_previsto"];

                if (dia > 0)
                    cal = dia.ToString() + "." + hor.ToString().PadLeft(2, '0') + ":" + min.ToString().PadLeft(2, '0') + ":00";
                else
                    cal = hor.ToString().PadLeft(2, '0') + ":" + min.ToString().PadLeft(2, '0') + ":00";

                total = total + (double)Convert.ToDecimal(TimeSpan.Parse(cal).TotalHours);
            }

            for (int i = DataTable.Rows.Count - 1; i >= 0; i--)
            {
                DataRow dr = DataTable.Rows[i];
                int dia = (Int32)dr["pe_hora_previsto"] / 24;

                int hor = (Int32)dr["pe_hora_previsto"] - (dia * 24);

                int min = (Int16)dr["pe_minuto_previsto"];

                string cal = "";

                if (dia > 0)
                    cal = dia.ToString() + "." + hor.ToString().PadLeft(2, '0') + ":" + min.ToString().PadLeft(2, '0') + ":00";
                else
                    cal = hor.ToString().PadLeft(2, '0') + ":" + min.ToString().PadLeft(2, '0') + ":00";

                dr["percentual"] = (double)Convert.ToDecimal(TimeSpan.Parse(cal).TotalHours) / total;
            }

            lblTotal.Text = total.ToString();
            DataTable.AcceptChanges();
            GrdEtapas.EditIndex = -1;
            ShowData();
        }

        protected void BtnVolta_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Escritorio/Projeto/Fases/Custos.aspx?Projeto=" + lblProjeto.Text);
        }

        protected void BtnAvanca_Click(object sender, EventArgs e)
        {
            DataTable DataTable = new DataTable();

            DataTable=(DataTable)Session["DataTable"];
            int dia;
            int hor;
            int min;
            string cal;

            for (int i = DataTable.Rows.Count - 1; i >= 0; i--)
            {
                DataRow dr = DataTable.Rows[i];

                if (dr["pe_id"].ToString().Length == 0 && ((Int32)dr["pe_hora_previsto"]>0 || (Int16)dr["pe_minuto_previsto"] > 0))
                { 
                    dia = (Int32)dr["pe_hora_previsto"] / 24;

                    hor = (Int32)dr["pe_hora_previsto"] - (dia * 24);

                    min = (Int16)dr["pe_minuto_previsto"];

                    if (dia > 0)
                        cal = dia.ToString() + "." + hor.ToString().PadLeft(2, '0') + ":" + min.ToString().PadLeft(2, '0') + ":00";
                    else
                        cal = hor.ToString().PadLeft(2, '0') + ":" + min.ToString().PadLeft(2, '0') + ":00";

                    con.Open();

                    string Ins = "insert INTO tb_projeto_etapas(pe_projeto,pe_etapa,pe_hora_previsto,pe_realisado) values(@projeto,@etapa,@hora_previsto,null)";
                    MySqlCommand qryInsert = new MySqlCommand(Ins, con);
                    qryInsert.Parameters.Add("@projeto", MySqlDbType.Int32).Value = Convert.ToInt32(lblProjeto.Text);
                    qryInsert.Parameters.Add("@etapa", MySqlDbType.Int32).Value = Convert.ToInt32(dr["et_id"].ToString());
                    qryInsert.Parameters.Add("@hora_previsto", MySqlDbType.Decimal).Value = Convert.ToDecimal(TimeSpan.Parse(cal).TotalHours); 

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
                    if ((Int32)dr["pe_hora_previsto"] == 0 && (Int16)dr["pe_minuto_previsto"]==0 && dr["pe_id"].ToString().Length>0)
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
                        if (((Int32)dr["pe_hora_previsto"]> 0 || (Int16)dr["pe_minuto_previsto"]> 0) && dr["pe_id"].ToString().Length>0)
                        { 
                            dia = (Int32)dr["pe_hora_previsto"] / 24;

                            hor = (Int32)dr["pe_hora_previsto"] - (dia * 24);

                            min = (Int16)dr["pe_minuto_previsto"];

                            if (dia > 0)
                                cal = dia.ToString() + "." + hor.ToString().PadLeft(2, '0') + ":" + min.ToString().PadLeft(2, '0') + ":00";
                            else
                                cal = hor.ToString().PadLeft(2, '0') + ":" + min.ToString().PadLeft(2, '0') + ":00";

                            con.Open();

                            string Upd = "update tb_projeto_etapas set pe_projeto=@projeto,pe_etapa=@etapa,pe_hora_previsto=@hora_previsto where pe_id=@id";
                            MySqlCommand qryUpdate = new MySqlCommand(Upd, con);
                            qryUpdate.Parameters.Add("@id", MySqlDbType.Int32).Value = Convert.ToInt32(dr["pe_id"].ToString());
                            qryUpdate.Parameters.Add("@projeto", MySqlDbType.Int32).Value = Convert.ToInt32(lblProjeto.Text);
                            qryUpdate.Parameters.Add("@etapa", MySqlDbType.Int32).Value = Convert.ToInt32(dr["et_id"].ToString());
                            qryUpdate.Parameters.Add("@hora_previsto", MySqlDbType.Decimal).Value = Convert.ToDecimal(TimeSpan.Parse(cal).TotalHours);

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
            Response.Redirect("~/Escritorio/Projeto/Fases/Resultado.aspx?Projeto=" + lblProjeto.Text);
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