using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Ciencia.OBJ;
using Generales;
//using Microsoft.Office.Interop.Excel;
using System.IO;

namespace Ciencia.DAL
{
    public class TablaManager
    {
        private string conStr;

        public TablaManager(string constr)
        {
            conStr = constr;
        }

        //public string Where { get; set; }

        public Boolean CrearTabla(String nombreTabla, List<clsCampo> Campos)
        {
            try
            {
                string query;
                CienciaEquiv obj;
                TDatos dataOrg = new TDatos("ICBA.Properties.Settings.conStrCiencia");
                //Borra tabla si exite 
                dataOrg.BorrarTabla(nombreTabla);

                query = string.Format("CREATE TABLE {0} (", nombreTabla);
                CienciaEquivManager EqMan = new CienciaEquivManager();

                foreach (var campo in Campos)
                {
                    obj = EqMan.ObtenerPorCampoEquiv(campo.nombre, campo.tablaId);
                    query += campo.nombre + " " + obj.TipoDatoSqlServer.ToString() + ", ";

                }
                query = query.Substring(0, query.Length - 2);
                query += ")";
                
                dataOrg.ExecuteQuery(query, CommandType.Text);
                return true;
            }
            catch(Exception ex)
            {
                Utiles.WriteErrorLog(ex.Message);
                return false;
            }


            
        }



        public Boolean CrearTablaResultado(List<clsTablaEquivalente> TablasOrigen, String TablaResultado, List<clsCampo> Campos, string where, string clavePrimaria)
        {
            int i = 0;
            //var tablas = (from campo in Campos
            //              select campo.tabla).Distinct();

            try
            {

                string queryDes = "SELECT ";
                string queryOrg = "SELECT ";
                foreach(var campo in Campos)
                {
                    if (campo.nombre == clavePrimaria)
                    {
                        queryOrg += TablasOrigen.First().nombre + "." + campo.nombre + ", ";
                        queryDes += campo.nombre.Trim() + ", ";
                    }
                    else
                    {
                        queryOrg += campo.nombre.Trim() + ", ";
                        queryDes += campo.nombre.Trim() + ", ";
                    }
                }

                queryOrg = queryOrg.Substring(0, queryOrg.Length - 2);
                queryDes = queryDes.Substring(0, queryDes.Length - 2);
                queryDes = queryDes + string.Format(" from {0} ", TablaResultado);
                clsTablaEquivalente primeraTabla  =TablasOrigen.First();
                queryOrg = queryOrg + string.Format(" from {0} ", primeraTabla.nombre);
                foreach(clsTablaEquivalente tablaSiguiente in TablasOrigen.GetRange(1, TablasOrigen.Count-1))
                {
                    queryOrg += string.Format(" left join {1} on {0}.{2} = {1}.{3} ", primeraTabla.nombre, tablaSiguiente.nombre, clavePrimaria, tablaSiguiente.claveForanea);
                }
                //string order = string.Format("order by {0}", clavePrimaria);
                CrearTabla(TablaResultado, Campos);
                //query = Campos.Aggregate("SELECT DISTINCT DATEDIFF('yyyy', Ciencia_Car_Pac_Sel.Pac_Nac_F, Now()) as EDAD,  ", (current, campo) => current + campo.tabla.Trim() + "." + campo.nombre.Trim() + ", ");
                //DataTable dt = dataOrg.GetDataNonQuery(query, CommandType.Text);

                if (!CopiaTablaTemp(queryOrg, queryDes, where, clavePrimaria))
                {
                    Utiles.WriteErrorLog("No se adicionaron campos ");
                    throw new Exception();
                }
                foreach (var campo in Campos)
                {
                    if (campo.ListaValores != null && campo.verValor== false)
                    {
                        ActualizarCampoACero(TablaResultado, campo);
                    }
                    else if(campo.ListaValores != null && campo.verValor== true)
                    {
                        this.VerValores(TablaResultado, campo);
                    }
                }
                return true;

            }
            catch (Exception ex)
            {
                Utiles.WriteErrorLog("Error en TablaManager.CrearTabla "+ ex.Message);
                return false;
            }
        }



//*************
        public Boolean CrearXml2(List<clsTablaEquivalente> TablasOrigen, String Xml, List<clsCampo> Campos, string where, string clavePrimaria)
        {
            int i = 0;
           
            try
            {

                string queryOrg = "SELECT ";
                foreach (var campo in Campos)
                {
                    if (campo.nombre == clavePrimaria)
                    {
                        queryOrg += TablasOrigen.First().nombre + "." + campo.nombre + ", ";
                    }
                    else
                    {
                        queryOrg += campo.nombre.Trim() + ", ";
                    }
                }

                queryOrg = queryOrg.Substring(0, queryOrg.Length - 2);
                clsTablaEquivalente primeraTabla = TablasOrigen.First();
                queryOrg = queryOrg + string.Format(" from {0} ", primeraTabla.nombre);
                foreach (clsTablaEquivalente tablaSiguiente in TablasOrigen.GetRange(1, TablasOrigen.Count - 1))
                {
                    queryOrg += string.Format(" left join {1} on {0}.{2} = {1}.{3} ", primeraTabla.nombre, tablaSiguiente.nombre, clavePrimaria, tablaSiguiente.claveForanea);
                }
                //string order = string.Format("order by {0}", clavePrimaria);
                if (!string.IsNullOrEmpty(where))
                    queryOrg = queryOrg + " where " + where;
                queryOrg = queryOrg + " order by " + clavePrimaria;
                TDatos dataOrg = new TDatos("ICBA.Properties.Settings.conStrCiencia");
                System.Data.DataTable dtOrg = dataOrg.ExecuteCmd(queryOrg, CommandType.Text);

                foreach (var campo in Campos)
                {
                    if (campo.ListaValores != null && campo.verValor == false)
                    {
                        ActualizarCampoACero(dtOrg, campo);
                    }
                    else if (campo.ListaValores != null && campo.verValor == true)
                    {
                        this.VerValores(dtOrg, campo);
                    }
                }

                dtOrg.TableName = "TablaResultado";
                
                var ds = new DataSet();
                ds.Tables.Add(dtOrg);
                if (!Generales.ExportadorDatos.ExportarExcel(ds, Xml))
                    return false;
                //writer.w
                return true;

            }
            catch (Exception ex)
            {
                Utiles.WriteErrorLog("Error en TablaManager.CrearTabla " + ex.Message);
                return false;
            }
        }

        public Boolean ActualizarCampoACero(DataTable tabla, clsCampo campo)
        /*
         * Esta funcion tom un campo de tipo desplegable dentro de una tabla y
         * lo actualiza a 0. Los demas campos los actualiza a 1;
         */
        {
            string query;
            int ret;

            foreach (DataRow fila in tabla.Rows)
            {
                if(campo.ListaValores.Find(x=> x ==fila[campo.nombre].ToString()) != null )
                {
                    fila[campo.nombre] = "0";
                }
                else
                {
                    fila[campo.nombre] = "1";
                }
            }

            return true;

        }


        public Boolean VerValores(DataTable tabla, clsCampo campo)
        /* Esta funcion toma un campo de tipo desplegable 
            * y deja los valores que estan  la lista ListaValores y los deja en su valor original
            * Los demas valores los deja en 0
            */
        {
            string query;
            int ret;

            foreach (DataRow fila in tabla.Rows)
            {
                if (campo.ListaValores.Find(x => x == fila[campo.nombre].ToString()) == null)
                {
                    fila[campo.nombre] = "0";
                }
            }

            return true;

        }

        //**************
        public Boolean CopiaTablaTemp(string queryOrg, string queryDes, string where, string order)
        {
            TDatosAccess.conStr = conStr;

            if (!string.IsNullOrEmpty(where))
                queryOrg = queryOrg + " where " + where;
            if (!string.IsNullOrEmpty(order))
                queryOrg = queryOrg + " order by " + order;

            TDatos dataOrg = new TDatos("ICBA.Properties.Settings.conStrCiencia");
            System.Data.DataTable dtOrg = dataOrg.ExecuteCmd(queryOrg, CommandType.Text);
            System.Data.DataTable dtDes = dataOrg.ExecuteCmd(queryDes, CommandType.Text);
            int i = 0;
            foreach (DataRow row in dtOrg.Rows)
            {

                DataRow rowDes = dtDes.NewRow();
                foreach (DataColumn column in dtOrg.Columns)
                {
                    rowDes[column.ColumnName] = row[column];
                }
                dtDes.Rows.Add(rowDes);
                i++;
            }
            dataOrg.UpdateTable(queryDes, dtDes);
            
            return true;
        }

  

        public Boolean ActualizarCampoACero(string tabla, clsCampo campo) 
            /*
             * Esta funcion tom un campo de tipo desplegable dentro de una tabla y
             * lo actualiza a 0. Los demas campos los actualiza a 1;
             */
        {
            string query;
            int ret;
            TDatos td = new TDatos("ICBA.Properties.Settings.conStrCiencia");
            foreach (var vcero in campo.ListaValores)
            {
                query = "Update " + tabla + " set " + campo.nombre + " = '0' "+ 
                        " where " + campo.nombre + " = '" + vcero + "'";

                
                Thread.Sleep(500);
                ret= td.ExecuteQuery(query, CommandType.Text);
                
                if (ret < 1)
                    MessageBox.Show("No se modificaron registros\n"+ query);
            }
            Thread.Sleep(1000);
            query = "Update " + tabla + " set " + campo.nombre + " = '1' " +
                    " where " + campo.nombre + " <> '0'";
            ret = td.ExecuteQuery(query, CommandType.Text);

            return true;

        }

        public Boolean VerValores(string tabla, clsCampo campo)
        {
            /* Esta funcion toma un campo de tipo desplegable 
             * y deja los valores que estan  la lista ValoresDeCambio y los deja en su valor original
             * Los demas valores los deja en 0
             */
            string query= string.Format("SELECT DISTINCT {0} from {1}", campo.nombre, tabla);

            TDatos td = new TDatos("ICBA.Properties.Settings.conStrCiencia");
            System.Data.DataTable dt = td.GetDataNonQuery(query);
            List<string> valACero = new List<string>();


            foreach(DataRow row in dt.Rows)
            {
                string nombreCampo = row[0].ToString().Trim().ToLower();
                var val = campo.ListaValores.Find(x => x.ToLower() == nombreCampo);
                if( val== null)
                {
                    valACero.Add(nombreCampo);
                }

            }

            int ret;
            foreach (var vcero in valACero)
            {
                query = "Update " + tabla + " set " + campo.nombre + " = '0' " +
                        " where " + campo.nombre + " = '" + vcero + "'";

                
                Thread.Sleep(500);
                ret = td.ExecuteQuery(query, CommandType.Text);

                if (ret < 1)
                    MessageBox.Show("No se modificaron registros\n" + query);
            }
            Thread.Sleep(1000);
            return true;

        }

        public Boolean ExportarAExcel(String NombreTabla, string Xml)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Application.Workbooks.Add(true);
                string query = "Select * from " + NombreTabla;
                TDatos td = new TDatos("ICBA.Properties.Settings.conStrCiencia");
                System.Data.DataTable dt = td.GetDataNonQuery(query);
                var ds = new DataSet();
                ds.Tables.Add(dt);
                if (!Generales.ExportadorDatos.ExportarExcel(ds, Xml))
                    return false;

                return true;

            }
            catch (Exception ex)
            {
                Mensajes.msgError(ex);                
                throw;
                return false;
            }
        }

        //public Boolean ExportarAExcel(List<String> listaTablas, string Xml)
        //{
        //    try
        //    {
        //        Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
        //        excel.Application.Workbooks.Add(true);
        //        int columnaIncial = 0;
        //        foreach(string tabla in listaTablas)
        //        {
        //            string query = "Select * from " + tabla;
        //            System.Data.DataTable dt = TDatosAccess.GetDataNonQuery(query, conStr);
        //            if (!Generales.ExportadorDatos.ExportarExcel(ds, Xml))
        //                return false;
        //            columnaIncial += dt.Columns.Count;
        //        }
        //        excel.Visible = true;
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        Mensajes.msgError(ex);
        //        throw;
        //        return false;
        //    }
        //}

        //public Boolean ExportarAXml(List<String> listaTablas)
        //{
        //    try
        //    {

        //        int columnaIncial = 0;
        //        foreach (string tabla in listaTablas)
        //        {
        //            string query = "Select * from " + tabla;
        //            DataTable dt = TDatosAccess.GetDataNonQuery(query, conStr);
        //            if (!CopiarAExcel(excel, dt, columnaIncial))
        //                return false;
        //            columnaIncial += dt.Columns.Count;
        //        }
        //        excel.Visible = true;
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        Mensajes.msgError(ex);
        //        throw;
        //        return false;
        //    }
        //}

        private bool CopiarAExcel(Microsoft.Office.Interop.Excel.Application excel, System.Data.DataTable dt, int columnaInicial)
        {
            try
            {
                int ColumnIndex = columnaInicial;
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
                    ColumnIndex = columnaInicial;
                    foreach (DataColumn col in dt.Columns)
                    {
                        ColumnIndex++;

                        string dato = row[col.ColumnName].ToString();
                        DateTime val;

                        if (DateTime.TryParse(dato, out val) == true)
                            dato = val.ToString("yyyy/MM/dd");
                        Microsoft.Office.Interop.Excel.Range range = excel.Cells[rowIndex + 1, ColumnIndex];
                        range.Value = dato;
                        
                        range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlLeft;
                        //excel.Cells[rowIndex + 1, ColumnIndex]
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }


    }
}
