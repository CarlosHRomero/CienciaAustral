using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Ciencia.OBJ;
using Generales;
using System.ComponentModel;


namespace Ciencia.DAL
{
    public class EvolucionMan
    {
        public string conStr { get; set; }

        public DataTable SeleccionarTablaEvolucion(List<clsCampo> Campos)
        {
            int i = 0;
            var tablas = (from campo in Campos
                          select campo.tabla).Distinct();
            try
            {
                string query;
                TDatosAccess.conStr = conStr;

                query = Campos.Aggregate("SELECT DISTINCT ", (current, campo) => current + campo.tabla.Trim() + "." + campo.nombre.Trim() + ", ");
                query = query.Substring(0, query.Length - 2);
                query += " FROM Ciencia_Car_Ingr_Sel INNER JOIN Ciencia_Car_Evol_Sel ON Ciencia_Car_Ingr_Sel.Ingr_Id = Ciencia_Car_Evol_Sel.Evol_Ingr_Id";
                DataTable ret = TDatosAccess.GetDataNonQuery(query);
                return ret;
            }
            catch (Exception ex)
            {
                Utiles.WriteErrorLog("En EvolucionMan.seleccionar: " + ex.Message);
                return null;
            }

        }

        public Boolean copiarDatos(List<clsCampo> Campos, string vistaOrigen, int moduloId, BackgroundWorker bw)
        {
            try
            {
                TDatosAccess.conStr = conStr;
                string query;
                TDatos data = new TDatos("ICBA.Properties.Settings.conStr");
                TDatos dataCiencia = new TDatos("ICBA.Properties.Settings.conStrCiencia");
                TablaEquivManager teMan = new TablaEquivManager();
                string tablaOrigenEvol = teMan.ObtenerTablaEquivalenteEvolucion(moduloId);
                string tablaResultadoEvol = tablaOrigenEvol + "_Sel";
                CienciaEquivManager ceMan = new CienciaEquivManager();
                string fechaEvolucion  = ceMan.BuscarFechaEvolucion(moduloId);
                if (fechaEvolucion == null)
                    throw new Exception("El modulo no contiene una fecha evolucion");
                string fechaEventoprincipal = ceMan.BuscarFechaEventoPrincipal(moduloId).CampoEquivalente;
                if (fechaEventoprincipal == null)
                    throw new Exception("El modulo no contiene fecha de evento principal");
                LocalSelectInfManager infMan = new LocalSelectInfManager(conStr);
                string where = infMan.ObtenerInfSeleccion().where;

                ModuloManager modMan = new ModuloManager();
                string clavePrimariaEvol = modMan.ObtenerDatosModulo(moduloId.ToString()).ClavePrimariaEvol;
                string claveExternaEvol = modMan.ObtenerDatosModulo(moduloId.ToString()).ClaveExternaEvol;



                query = "SELECT DISTINCT ";
                foreach (clsCampo campo in Campos)
                {
                    if (campo.selTe != null)
                        continue;
                    if (campo.Func == null)
                    {
                        query += campo.nombre.Trim() + ", ";
                    }
                    else if (campo.Func.ToLower() == "primera" || campo.Func.ToLower() == "ultima")
                        continue;
                    else
                    {
                        query += campo.Func + "(" + campo.nombre.Trim() + ") as " + campo.Func + "_" + campo.nombre + ", ";
                    }
                }
                bw.ReportProgress(30);
                query = query.Substring(0, query.Length - 2);

                query += " FROM " + vistaOrigen + " left JOIN " + tablaOrigenEvol + " ON " + vistaOrigen + "." + clavePrimariaEvol + " = " + tablaOrigenEvol + "." + claveExternaEvol;
                query += " GROUP BY " + clavePrimariaEvol + ", "+ fechaEventoprincipal + " ORDER BY " + clavePrimariaEvol;
                DataTable dtOrg = dataCiencia.GetDataNonQuery(query, CommandType.Text);

                string queryDes = string.Format("SELECT * FROM {0}", tablaResultadoEvol);
                DataTable dtDes = TDatosAccess.ExecuteCmd(queryDes, CommandType.Text);

                bw.ReportProgress(40);
                int c, y, i = 0;
                c = dtOrg.Rows.Count;

                foreach (DataRow row in dtOrg.Rows)
                {
                    DataRow rowDes = dtDes.NewRow();
                    foreach (clsCampo campo in Campos)
                    {
                        if (string.IsNullOrEmpty(campo.Func))
                            rowDes[campo.nombre] = row[campo.nombre];
                        else if (campo.Func.ToLower() == "primera" || campo.Func.ToLower() == "ultima" || campo.Func.ToLower() == "tabla")
                            continue;       //rowDes[campo.nombre] = row[campo.nombre];
                        else
                        {
                            string s = string.Format("{0}_{1}", campo.Func, campo.nombre);
                            rowDes[s] = row[s];
                        }
                    }
                    dtDes.Rows.Add(rowDes);
                    i++;

                }



                List<clsCampo> camposPri = Campos.Where<clsCampo>(x => x.Func != null && (x.Func.ToLower() == "primera")).ToList();
                DataTable dtPri = null, dtUlt = null, dtTabla = null;
                if (camposPri != null && camposPri.Count > 0)
                {
                    string queryPri = camposPri.Aggregate("SELECT DISTINCT ", (current, campo) => current + campo.nombre.Trim() + ", ");
                    queryPri += string.Format("MIN ({0}) OVER (PARTITION BY {1}), {1} FROM {2} ORDER BY {1}", fechaEvolucion, claveExternaEvol, tablaOrigenEvol);
                    dtPri = dataCiencia.GetDataNonQuery(queryPri);
                }



                List<clsCampo> camposUlt = Campos.Where<clsCampo>(x => x.Func != null && (x.Func.ToLower() == "ultima")).ToList();
                if (camposUlt != null && camposUlt.Count > 0)
                {
                    string queryUlt = camposUlt.Aggregate("SELECT DISTINCT ", (current, campo) => current + campo.nombre.Trim() + ", ");
                    queryUlt += string.Format("MIN ({0}) OVER (PARTITION BY {1}), {1} FROM {2} ORDER BY {1}", fechaEvolucion, claveExternaEvol, tablaOrigenEvol);
                    dtUlt = dataCiencia.GetDataNonQuery(queryUlt);
                }


                foreach (DataRow row in dtDes.Rows)
                {
                    foreach (clsCampo campo in Campos)
                    {
                        if (campo.Func == null ? false : campo.Func.ToLower() == "primera" && dtPri != null)
                        {
                            string wh = string.Format("{0} = {1}", claveExternaEvol, row[clavePrimariaEvol]);
                            DataRow[] result = dtPri.Select(wh);
                            if (result.Count() > 0)
                                row[campo.nombre] = result.First()[campo.nombre];
                        }
                        if (campo.Func == null ? false : campo.Func.ToLower() == "ultima" && dtPri != null)
                        {
                            string wh = string.Format("{0} = {1}", claveExternaEvol, row[clavePrimariaEvol]);
                            DataRow[] result = dtUlt.Select(wh);
                            if (result.Count() > 0)
                                row[campo.nombre] = result.First()[campo.nombre];
                        }

                    }
                }

                List<clsCampo> camposTabla = Campos.Where<clsCampo>(x => x.Func != null && (x.Func.ToLower() == "tabla")).ToList();
                
                if (camposTabla != null && camposTabla.Count > 0)
                {
                    foreach (clsCampo campo in camposTabla)
                    {
                        if (campo.selTe == null)
                            throw new Exception("Campo tipo tabla no contiene lista");
                        if (campo.selTe.Count < 1)
                            throw new Exception("Campo tipo tabla no contiene lista");
                        int n = 0;
                        foreach (SelTablaEvol st in campo.selTe)
                        {
                            n++;
                            if (st.pri_ult == OrdenSel.Primera)
                            {
                                if (st.listaVal.Count < 1)
                                    throw new Exception("el campo de tipo tabla no contiene lista de valores");
                                else
                                    query = string.Format("select {0}, {1}, MIN({2}) over (partition by {0}) as {3} from {4} where {1} = '{5}' ", claveExternaEvol, campo.nombre, fechaEvolucion, "fecha", tablaOrigenEvol, st.listaVal.First());
                                if (st.listaVal.Count > 1)
                                    query = st.listaVal.Aggregate(query, (current, valor) => string.Format(" {0} or {1} = '{2}'", current, campo.nombre, valor));
                            }
                            else
                            {
                                if (st.listaVal.Count < 1)
                                    throw new Exception("el campo de tipo tabla no contiene lista de valores");
                                else
                                    query = string.Format("select {0}, {1}, MAX({2}) over (partition by {0}) as {3} from {4} where {1} = '{5}' ", claveExternaEvol, campo.nombre, fechaEvolucion, "fecha", tablaOrigenEvol, st.listaVal.First());
                                if (st.listaVal.Count > 1)
                                    query = st.listaVal.Aggregate(query, (current, valor) => string.Format(" {0} or {1} = '{2}'", current, campo.nombre, valor));

                            }
                            dtTabla = dataCiencia.GetDataNonQuery(query);
                            foreach (DataRow row in dtDes.Rows)
                            {
                                string wh = string.Format("{0} = {1}", claveExternaEvol, row[clavePrimariaEvol]);
                                DataRow[] result = dtTabla.Select(wh);
                                if (result.Count() > 0)
                                {
                                    string s = string.Format("{0}_{1}_{2}_val", campo.nombre, n.ToString(), st.pri_ult);
                                    row[s] = result.First()[campo.nombre];
                                    s = string.Format("{0}_{1}_{2}_F", campo.nombre, n.ToString(), st.pri_ult);
                                    row[s] = result.First()["fecha"];
                                    string ndias = string.Format("{0}_{1}_{2}_NDias", campo.nombre, n.ToString(), st.pri_ult);
                                    row[ndias] = -((DateTime)row[fechaEventoprincipal]).Subtract((DateTime)row[s]).Days;
                                }
                            }

                        }

                    }


                }

                TDatosAccess.UpdateTable(queryDes, dtDes);
                //string queryPri = "select * from "

                //    foreach (clsCampo campo in Campos)
                //    {
                //        if (campo.Func == "primera")
                //        {
                //            int Ingr_Id = Convert.ToInt32(fila["Ingr_id"]);
                //            query = "select " + campo.nombre + " from ciencia_car_evol_sel " +
                //                    "where Evol_Ingr_Id = " + Ingr_Id.ToString() + " order by evol_F asc ";
                //            DataTable dt2 = TDatosAccess.ExecuteCmd(query, CommandType.Text);
                //            string s = dt2.Rows[0][campo.nombre].ToString();
                //            if (!String.IsNullOrEmpty(s))
                //                fila[campo.nombre] = s;
                //        }
                //        if (campo.Func == "ultima")
                //        {
                //            int Ingr_Id = Convert.ToInt32(fila["Ingr_id"]);
                //            query = "select " + campo.nombre + " from ciencia_car_evol_sel " +
                //                   "where Evol_Ingr_Id = " + Ingr_Id.ToString() + " order by evol_F desc ";
                //            DataTable dt2 = TDatosAccess.ExecuteCmd(query, CommandType.Text);
                //            string s = dt2.Rows[0][campo.nombre].ToString();
                //            if (!String.IsNullOrEmpty(s))
                //                fila[campo.nombre] = s;
                //        }
                //    }
                //    i++;
                //    y = ((53 * i) / c) + 40;
                //    bw.ReportProgress(y);
                //}
                //query = "SELECT * FROM EVOLUCION";
                //
                //bw.ReportProgress(100);
                return true;
            }
            catch (Exception ex)
            {
                Utiles.WriteErrorLog(ex.Message);
                return false;
            }
        }

        public Boolean ExportarAExcel(String NombreTabla)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Application.Workbooks.Add(true);
                string query = "Select * from " + NombreTabla;
                TDatosAccess.conStr = conStr;
                DataTable dt = TDatosAccess.GetDataNonQuery(query, conStr);
                int ColumnIndex = 0;
                if (dt.Rows.Count == 0)
                {
                    Utiles.WriteErrorLog("No se adicionaron campos ");
                    throw new Exception();
                }
                foreach (DataColumn col in dt.Columns)
                {
                    ColumnIndex++;
                    excel.Cells[1, ColumnIndex] = col.ColumnName;
                }
                int rowIndex = 0;
                foreach (DataRow row in dt.Rows)
                {
                    rowIndex++;
                    ColumnIndex = 0;
                    foreach (DataColumn col in dt.Columns)
                    {
                        ColumnIndex++;

                        string dato = row[col.ColumnName].ToString();
                        DateTime val;

                        if (DateTime.TryParse(dato, out val) == true)
                            dato = val.ToShortDateString();
                        excel.Cells[rowIndex + 1, ColumnIndex] = dato;
                    }
                }
                excel.Visible = true;
                return true;

            }
            catch (Exception ex)
            {
                Mensajes.msgError(ex);
                throw;
                return false;
            }
        }
        public Boolean CrearTabla(String nombreTabla, List<clsCampo> Campos)
        {
            string query;
            CienciaEquiv obj;
            if (!TDatosAccess.DropTable(nombreTabla))
            {
                return false;
            }

            query = string.Format("CREATE TABLE {0} (", nombreTabla);
            CienciaEquivManager EqMan = new CienciaEquivManager();

            foreach (var campo in Campos)
            {
                obj = EqMan.ObtenerPorCampoEquiv(campo.nombre, campo.tablaId);
                switch (campo.Func)
                {
                    case ("MAX"):
                    case ("MIN"):
                    case ("AVG"):
                        query += string.Format("{0}_{1} {2}, ", campo.Func, campo.nombre, obj.TipoDatoAccess.ToString());
                        break;
                    default:
                        if (campo.selTe == null)
                        {
                            query += campo.nombre + " " + obj.TipoDatoAccess.ToString() + ", ";
                        }
                        else if (campo.selTe.Count == 0)
                        {
                            query += campo.nombre + " " + obj.TipoDatoAccess.ToString() + ", ";
                        }
                        else
                        {
                            int n = 1;
                            foreach (var x in campo.selTe)
                            {
                                query += string.Format("{0}_{1}_{2}_F {3}, ", campo.nombre, n.ToString(), x.pri_ult, "DateTime");
                                query += string.Format("{0}_{1}_{2}_val {3}, ", campo.nombre, n.ToString(), x.pri_ult, obj.TipoDatoAccess);
                                query += string.Format("{0}_{1}_{2}_NDias {3}, ", campo.nombre, n.ToString(), x.pri_ult, "Integer");
                                n++;
                            }
                        }

                        break;
                }
            }
            query = query.Substring(0, query.Length - 2);
            query += ")";

            TDatosAccess.ExecuteQuery(query, CommandType.Text);

            return true;
        }
        public Boolean ConstruirEvolucion(List<clsCampo> Campos, int moduloId, BackgroundWorker bw)
        {
            try
            {
                //DataTable dt = SeleccionarTablaEvolucion(Campos);

                TDatos data = new TDatos("ICBA.Properties.Settings.conStrCiencia");
                TablaEquivManager teMan = new TablaEquivManager();
                string tablaOrigenEvol = teMan.ObtenerTablaEquivalenteEvolucion(moduloId);
                string tablaResultadoEvol = tablaOrigenEvol + "_Sel";

                string tablaOrigen = teMan.ObtenerTablaEquivalente(moduloId);

                LocalSelectInfManager infMan = new LocalSelectInfManager(conStr);
                string where = infMan.ObtenerInfSeleccion().where;

                string query = string.Format("select * from {0} where {1}", tablaOrigen, where);
                string vistaOrigen = data.CrearVista("view_" + tablaOrigen, query);

                if (CrearTabla(tablaResultadoEvol, Campos) == false)
                {
                    return false;
                }
                if (copiarDatos(Campos, vistaOrigen, moduloId, bw)== false)
                {
                    return false;
                }




                /*  List<DataRow> filas = dt.AsEnumerable().ToList();
                  var grupos = from fila in filas
                               group fila by fila["Ingr_id"] into grupo
                               orderby grupo.Key
                               select grupo.ToList<DataRow>();


                  foreach (List<DataRow> grupo in grupos)
                  {
                      DataRow filaDest = dtDes.NewRow();
                      foreach (var campo in Campos)
                      {

                          switch (campo.Func)
                          {
                              case (null):
                                  filaDest[campo.nombre] = grupo.FirstOrDefault()[campo.nombre];
                                  break;
                              case ("MAX"):
                                  //grupo.Max(x => x[campo.nombre]);
                                  var a = grupo.Where(x => x[campo.nombre] != DBNull.Value);
                                      if(a.Count() >0)
                                       filaDest[campo.nombre] =a.Max(x => Convert.ToDouble(x[campo.nombre]));
                                
                                  //DataRow a =  CalcularMaximo(grupo, campo.nombre); // (DataRow)grupo.Max(x => x[campo.nombre]);
                              
                                  break;
                              case ("MIN"):
                                  a = grupo.Where(x => x[campo.nombre] != DBNull.Value);
                                      if(a.Count() >0)
                                       filaDest[campo.nombre] =a.Min(x => Convert.ToDouble(x[campo.nombre]));
                                  break;
                              case ("AVG"):
                                  a = grupo.Where(x => x[campo.nombre] != DBNull.Value);
                                  if (a.Count() > 0)
                                      filaDest[campo.nombre] = a.Average(x => Convert.ToDouble(x[campo.nombre]));
                                  break;

                          }
                      }
                      dtDes.Rows.Add(filaDest);
                  }
                  TDatosAccess.UpdateTable("select * from Evolucion", dtDes);*/
                return true;
            }
            catch (Exception ex)
            {
                Utiles.WriteErrorLog(ex.Message);
                return false;
            }
        }
        public string CrearVista(string tabla, string tablaEvol, string where, int moduloId)
        {
            try
            {
                TDatos data = new TDatos("ICBA.Properties.Settings.conStrCiencia");
                string query = string.Format("select * from {0} where {1}", tabla, where);
                ModuloManager modMan = new ModuloManager();
                string clavePrimariaEvol = modMan.ObtenerDatosModulo(moduloId.ToString()).ClavePrimariaEvol;
                string claveExternaEvol = modMan.ObtenerDatosModulo(moduloId.ToString()).ClaveExternaEvol;

                string vistaOrigen = data.CrearVista("view_" + tabla, query);
                query = string.Format("select * from {0} inner join {1} on {0}.{2} = {1}.{3}", vistaOrigen, tablaEvol, clavePrimariaEvol, claveExternaEvol);
                //query += " GROUP BY " + clavePrimariaEvol;
                return data.CrearVista("view_" + tablaEvol, query);
            }
            catch (Exception ex)
            {
                Utiles.WriteErrorLog("Error en CrearVista: " + ex.Message);
                return null;
            }
        }

        public DataRow CalcularMaximo(List<DataRow> grupo, string campo)
        {
            try
            {
                DataRow ret = null;
                foreach (DataRow fila in grupo)
                {
                    if (ret == null)
                    {
                        ret = fila;
                        continue;
                    }

                    if (Convert.ToInt32(fila[campo]) >= Convert.ToInt32(ret[campo]))
                    {
                        ret = fila;
                    }
                }
                return ret;
            }
            catch (Exception ex)
            {
                Utiles.WriteErrorLog(ex.Message);
                return null;
            }
        }
    }
}
