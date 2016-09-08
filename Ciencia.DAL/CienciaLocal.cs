using System;
using System.Data;

using  System.Data.OleDb;
using System.Windows.Forms;
using  Generales;
using Ciencia.OBJ;


namespace Ciencia.DAL
{
    public class CienciaLocal
    {
        //string _conString ;
        //public CienciaLocal(String conStr)
        //{
        //    _conString = conStr;
        //}

        //public Boolean CopiaTablaSinSeleccion(string tabla)
        //{
        //    string queryDes = "select * from " + tabla;
        //    string queryOrg = "select * from " + tabla;

        //    return CopiaTablaLocal(queryOrg, queryDes, "");
        //}

        //public Boolean CopiaTablaConSeleccion(string tabla, string where)
        //{
        //    string queryOrg = "select distinct " + tabla + ".* from Ciencia_Car_Pac " +
        //                 "inner join Ciencia_Car_Ingr on Pac_Id = Ingr_Pac_Id " +
        //                 "inner join Ciencia_Car_Ant on Ingr_Id = Ant_Ingr_Id " +
        //                 "inner join Ciencia_Car_AntC on Ingr_Id = AntC_Ingr_Id " +
        //                 "inner join Ciencia_Car_Alta on Ingr_Id = Alta_Ingr_Id ";
        //    string queryDes = "select * from " + tabla + "_Sel";
        //    return CopiaTablaLocal(queryOrg, queryDes, where);
        //}

        //public Boolean CopiarTablaEvolucionConSeleccion()
        //{
        //    string queryOrg = "SELECT DISTINCT Ciencia_Car_Evol.*  FROM Ciencia_Car_Evol "+
        //                      "INNER JOIN (Ciencia_Car_Pac "+
        //                      "INNER JOIN Ciencia_Car_Ingr_sel ON Ciencia_Car_Pac.Pac_Id = Ciencia_Car_Ingr_sel.Ingr_Pac_Id) ON Ciencia_Car_Evol.Evol_Ingr_Id = Ciencia_Car_Ingr_sel.Ingr_Id";
        //    string queryDes = "select * from Ciencia_Car_Evol_Sel";

        //    TDatosAccess.conStr = _conString;


        //    DataTable dtOrg = TDatosAccess.ExecuteCmd(queryOrg, CommandType.Text);
        //    DataTable dtDes = TDatosAccess.ExecuteCmd(queryDes, CommandType.Text);
        //    int i = 0;
        //    foreach (DataRow row in dtOrg.Rows)
        //    {

        //        DataRow rowDes = dtDes.NewRow();
        //        foreach (DataColumn column in dtOrg.Columns)
        //        {
        //            rowDes[column.ColumnName] = row[column];
        //        }
        //        dtDes.Rows.Add(rowDes);
        //        i++;
        //    }
        //    TDatosAccess.UpdateTable(queryDes, dtDes);
        //    return true;
        //}

        //public Boolean CopiaTablaLocal(string queryOrg, string queryDes, string where)
        //{
        //    TDatosAccess.conStr = _conString;

        //    //string queryDes = "select * from " + tablaDes;
        //    //string queryOrg = "select * from " + tablaOrg;
        //    if (!string.IsNullOrEmpty(where))
        //        queryOrg = queryOrg + " where " + where;
                
        //    DataTable dtOrg = TDatos.ExecuteCmd(queryOrg, CommandType.Text);
        //    DataTable dtDes = TDatosAccess.ExecuteCmd(queryDes, CommandType.Text);
        //    int i = 0;
        //    foreach (DataRow row in dtOrg.Rows)
        //    {
                 
        //        DataRow rowDes = dtDes.NewRow();
        //        foreach (DataColumn column in dtOrg.Columns)
        //        {
        //            rowDes[column.ColumnName] = row[column];
        //        }
        //        dtDes.Rows.Add(rowDes);
        //        i++;
        //    }
        //    TDatosAccess.UpdateTable(queryDes, dtDes);
        //    return true;
        //    /*BorrarTabla();
        //    DataTable dt;
        //    var entry = 
        //    SqlConnection con = new SqlConnection(entry.ConnectionString);
        //    Ciencia_Car_IngrTableAdapter daDest = new Ciencia_Car_IngrTableAdapter();
        //    SqlDataAdapter daOrg = new SqlDataAdapter("select * from Car_Ingr_New", con);
        //    DataTable dtOrg = new DataTable();
        //    ICBA_Cirugia_2003DataSet.Ciencia_Car_IngrDataTable dtDes = new ICBA_Cirugia_2003DataSet.Ciencia_Car_IngrDataTable();
        //    CienciaCarEquiv equiv = new CienciaCarEquiv();
        //    CienciaEquivManager EqMan = new CienciaEquivManager();
        //    int i = 0;
        //    daOrg.Fill(dtOrg);
        //    //daDest.InsertCommand =
        //    //    new SqlCommand(
        //    //        "INSERT INTO [cirugia].[Ciencia_Car_Ingr] ([Ingr_Id], [Ingr_Ctro_D], [Ingr_Pac_Id], [Ingr_F], [Ingr_Diagnostico_D], [Ingr_SubDiag_D], [Ingr_Sintoma_D], [Ingr_DolorPreCord_B], [Ingr_Disnea_B], [Ingr_Sincope_B], [Ingr_Palpitac_B], [Ingr_Cansancio_B], [Ingr_Fiebre_B], [Ingr_Cefalea_B], [Ingr_Neurolog_B], [Ingr_Hematoma_B], [Ingr_OtroSintoma_B], [Ingr_Derivado_D], [Ingr_HTA_D], [Ingr_DLP_D], [Ingr_TBQ_D], [Ingr_DBT_D], [Ingr_AHF_B], [Ingr_FRCV_B], [Ingr_FEVI_N], [Ingr_DisfSist_D], [Ingr_CF_Habit_D], [Ingr_Timi_N], [Ingr_Grace_N], [Ingr_Crusade_N], [Ingr_Estado_N], [Ingr_Alta_F], [Ingr_Alta_Obito_D], [Ingr_Pase_M]) VALUES (@Ingr_Id, @Ingr_Ctro_D, @Ingr_Pac_Id, @Ingr_F, @Ingr_Diagnostico_D, @Ingr_SubDiag_D, @Ingr_Sintoma_D, @Ingr_DolorPreCord_B, @Ingr_Disnea_B, @Ingr_Sincope_B, @Ingr_Palpitac_B, @Ingr_Cansancio_B, @Ingr_Fiebre_B, @Ingr_Cefalea_B, @Ingr_Neurolog_B, @Ingr_Hematoma_B, @Ingr_OtroSintoma_B, @Ingr_Derivado_D, @Ingr_HTA_D, @Ingr_DLP_D, @Ingr_TBQ_D, @Ingr_DBT_D, @Ingr_AHF_B, @Ingr_FRCV_B, @Ingr_FEVI_N, @Ingr_DisfSist_D, @Ingr_CF_Habit_D, @Ingr_Timi_N, @Ingr_Grace_N, @Ingr_Crusade_N, @Ingr_Estado_N, @Ingr_Alta_F, @Ingr_Alta_Obito_D, @Ingr_Pase_M)");

        //    string campoDest;
        //    foreach (DataRow filaOrg in dtOrg.Rows)
        //    {
        //        DataRow filaDest = dtDes.NewRow();
        //        foreach (DataColumn columna in dtOrg.Columns)
        //        {
        //            equiv = EqMan.ObtenerPorOrigen(columna.ColumnName);
        //            if (equiv == null || equiv.CampoEquivalente == null)
        //                continue;
        //            campoDest = equiv.CampoEquivalente.Trim();
        //            var valor = filaOrg[columna];
        //            if (String.IsNullOrEmpty(valor.ToString()))
        //            {
        //                if (equiv.ValorPorDefecto == null)
        //                    filaDest[campoDest] = DBNull.Value;
        //                else
        //                    filaDest[campoDest] = equiv.ValorPorDefecto;
        //                continue;
        //            }
        //            if (equiv.Filtro == null)
        //            {
        //                if (columna.DataType == typeof(DateTime) || columna.DataType == typeof(DateTime?))
        //                    filaDest[campoDest] = ((DateTime)valor).ToShortDateString();
        //                else if (columna.DataType == typeof(Boolean) || columna.DataType == typeof(Boolean?))
        //                    filaDest[campoDest] = (Boolean)valor == false ? "N" : "S";
        //                else
        //                    filaDest[campoDest] = valor;
        //            }
        //            else
        //            {
        //                String s = ObtenerEquivalente(equiv.Filtro.Trim(), valor);
        //                if (s == null)
        //                    filaDest[campoDest] = equiv.ValorPorDefecto;
        //                else
        //                    filaDest[campoDest] = s.Trim();
        //            }
        //        }
        //        dtDes.Rows.Add(filaDest);
        //        i++;
        //        p.Maximum = 3000;
        //        p.Value = i;

        //    }
        //    //daDest.InsertCommand.Connection = con;
        //    daDest.Update(dtDes);


        //    return false;*/
        //}


    }
}
