using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using Generales;
using Ciencia.OBJ;
using Cardiologia.OBJ;
using Cardiologia.DAL;

namespace Ciencia.DAL
{
    public class MapeadorEvolucion
    {
        //EquivMAnager CarEquivManager = new EquivMAnager();
        //public Boolean BorrarTabla()
        //{
        //    try
        //    {
        //        string query = "DELETE FROM ciencia_car_evol";
        //        TDatos.ExecuteQuery(query, System.Data.CommandType.Text);
        //        return true;
        //    }
        //    catch(Exception ex)
        //    {
        //        Generales.Utiles.WriteErrorLog("Error en MapeadorEvolución.Boorartabla: " + ex.Message);
        //        return false;
        //    }
        //}

        //public Boolean MapearEvolucion(BackgroundWorker worker)
        //{
        //    try
        //    {
        //        BorrarTabla();
        //        string queryOrg = "SELECT * FROM Car_Evol_New";
                
        //        DataTable dtOrg = TDatos.ExecuteCmd(queryOrg, CommandType.Text);
        //        int max = dtOrg.Rows.Count;
        //        string queryDes = "SELECT * FROM Ciencia_car_Evol";
        //        DataTable dtDes = TDatos.ExecuteCmd(queryDes, CommandType.Text);
        //        CienciaEquiv equiv = new CienciaEquiv();
        //        CienciaEquivManager EqMan = new CienciaEquivManager();
        //        string campoDest;
        //        int i = 0;
                
        //        foreach (DataRow filaOrg in dtOrg.Rows)
        //        {
        //            if (worker.CancellationPending)
        //            {
        //                return false;
        //            }
        //            DataRow filaDest = dtDes.NewRow();
        //            foreach (DataColumn columna in dtOrg.Columns)
        //            {
        //                equiv = EqMan.ObtenerPorOrigen(columna.ColumnName);
        //                if (equiv == null)
        //                    continue;
        //                campoDest = equiv.CampoEquivalente.Trim();
        //                var valor = filaOrg[columna];
        //                if (String.IsNullOrEmpty(valor.ToString()))
        //                {
        //                    if (equiv.ValorPorDefecto == null)
        //                        filaDest[campoDest] = DBNull.Value;
        //                    else
        //                        filaDest[campoDest] = equiv.ValorPorDefecto.Trim();
        //                    continue;
        //                }
        //                if (equiv.Filtro == null)
        //                {
        //                    if (columna.DataType == typeof(DateTime) || columna.DataType == typeof(DateTime?))
        //                        filaDest[campoDest] = ((DateTime)valor);
        //                    else if (columna.DataType == typeof(Boolean) || columna.DataType == typeof(Boolean?))
        //                        filaDest[campoDest] = (Boolean)valor == false ? "N" : "S";
        //                    else if (columna.DataType == typeof(String))
        //                        filaDest[campoDest] = valor.ToString().Trim();
        //                    else
        //                        filaDest[campoDest] = valor;
        //                }
        //                else
        //                {
        //                    String s = ObtenerEquivalente(equiv.Filtro.Trim(), valor);
        //                    if (s == null)
        //                        filaDest[campoDest] = equiv.ValorPorDefecto.Trim();
        //                    else
        //                        filaDest[campoDest] = s.Trim();
        //                }
        //            }
        //            dtDes.Rows.Add(filaDest);
        //            i++;
        //            int k= (i * 100 )/(max+100);
        //            worker.ReportProgress( k<100 ? k:100 );
        //        }
        //        //Completa la tabla con los valores de ingr que no estan en evol
                
        //        queryOrg = "select Ingr_Id, Ingr_Pac_Id from Car_Ingr_New " +
        //                                       "where not exists " +
        //                                       "(select * from Car_Evol_New " +
        //                                       "where Car_Ingr_New.Ingr_Id = Car_Evol_New.Evol_Ingr_Id)";
        //        dtOrg = TDatos.GetDataNonQuery(queryOrg);
        //        foreach (DataRow filaOrg in dtOrg.Rows)
        //        {
        //            DataRow filaDest = dtDes.NewRow();
        //            filaDest["Evol_Ingr_Id"] = filaOrg["Ingr_Id"];
        //            filaDest["Evol_Pac_Id"] = filaOrg["Ingr_Pac_Id"];
        //            foreach (DataColumn columna in dtDes.Columns.Cast<DataColumn>().Where(columna => columna.ColumnName != "Evol_Ingr_Id" && columna.ColumnName != "Evol_Pac_Id"))
        //            {
        //                equiv = EqMan.ObtenerPorCampoEquiv(columna.ColumnName);
        //                if (equiv == null)
        //                {
        //                    throw new Exception("No encontro el campo");
        //                }
        //                if (equiv.ValorPorDefecto == null)
        //                    filaDest[columna] = DBNull.Value;
        //                else
        //                {
        //                    filaDest[columna] = equiv.ValorPorDefecto.Trim();
        //                }
        //            }
        //            dtDes.Rows.Add(filaDest);
        //        }
        //        TDatos.UpdateTable(queryDes, dtDes);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        Generales.Utiles.WriteErrorLog("Error en MapeadorEvolucion: "+ ex.Message);
        //        return false;
        //    }
        //}

        //private string ObtenerEquivalente(string filtro, object valor)
        //{
        //    String Where = "Eqv_Tit= '" + filtro + "' and Eqv_Val = " + valor;
        //    List<clsCarEquiv> lista = CarEquivManager.Seleccionar(Where, "");
        //    if (lista.Count == 0)
        //        return null;
        //    if (lista.Count > 1)
        //    {
        //        throw new Exception("En MapeadorIngresos. ObtenerEquivalente. Se encontró mas de un registro que cumple la condición");
        //    }
        //    return lista.First<clsCarEquiv>().Eqv_Desc;
        //}
    }
}
