using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ciencia.OBJ;
using Generales;
using Microsoft.Office.Interop.Excel;
using DataTable = System.Data.DataTable;

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
            string query;
            CienciaEquiv obj;
            query = string.Format("CREATE TABLE {0} (", nombreTabla);
            CienciaEquivManager EqMan = new CienciaEquivManager();

            foreach(var campo in Campos)
            {
                obj = EqMan.ObtenerPorCampoEquiv(campo.nombre, campo.tablaId);
                query += campo.nombre + " " + obj.TipoDatoAccess.ToString() + ", ";

            }
            query = query.Substring(0,query.Length - 2);
            query += ")";

            TDatosAccess.ExecuteQuery(query, CommandType.Text);

            return true;
        }
        public Boolean CrearTablaResultado(List<String> TablasOrigen, String TablaResultado, List<clsCampo> Campos, string where, string clavePrimaria)
        {
            int i = 0;
            var tablas = (from campo in Campos
                          select campo.tabla).Distinct();

            try
            {

                string queryDes = "SELECT ";
                string queryOrg = "SELECT ";
                foreach(var campo in Campos)
                {
                    if (campo.nombre == clavePrimaria)
                    {
                        queryOrg += TablasOrigen.First() + "." + campo.nombre + ", ";
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
                string  primeraTabla  =TablasOrigen.First();
                queryOrg = queryOrg + string.Format(" from {0} ", primeraTabla);
                foreach(string tablaSiguiente in TablasOrigen.GetRange(1, TablasOrigen.Count-1))
                {
                    queryOrg += string.Format(" inner join {1} on {0}.{2} = {1}.{2} ", primeraTabla, tablaSiguiente, clavePrimaria);
                }
                TDatosAccess.conStr = conStr;
                TDatosAccess.DropTable(TablaResultado);
                
                CrearTabla(TablaResultado, Campos);
                //query = Campos.Aggregate("SELECT DISTINCT DATEDIFF('yyyy', Ciencia_Car_Pac_Sel.Pac_Nac_F, Now()) as EDAD,  ", (current, campo) => current + campo.tabla.Trim() + "." + campo.nombre.Trim() + ", ");
                //DataTable dt = dataOrg.GetDataNonQuery(query, CommandType.Text);

                if (!CopiaTablaLocal(queryOrg, queryDes, where))
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

        public Boolean CopiaTablaLocal(string queryOrg, string queryDes, string where)
        {
            TDatosAccess.conStr = conStr;

            if (!string.IsNullOrEmpty(where))
                queryOrg = queryOrg + " where " + where;

            TDatos dataOrg = new TDatos("ICBA.Properties.Settings.ConnStrCiencia");
            DataTable dtOrg = dataOrg.ExecuteCmd(queryOrg, CommandType.Text);
            DataTable dtDes = TDatosAccess.ExecuteCmd(queryDes, CommandType.Text);
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
            TDatosAccess.UpdateTable(queryDes, dtDes);
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
            foreach (var vcero in campo.ListaValores)
            {
                query = "Update " + tabla + " set " + campo.nombre + " = '0' "+ 
                        " where " + campo.nombre + " = '" + vcero + "'";

                TDatosAccess.conStr = conStr;
                Thread.Sleep(1000);
                ret= TDatosAccess.ExecuteQuery(query, CommandType.Text);
                
                if (ret < 1)
                    MessageBox.Show("No se modificaron registros\n"+ query);
            }
            Thread.Sleep(1000);
            query = "Update " + tabla + " set " + campo.nombre + " = '1' " +
                    " where " + campo.nombre + " <> '0'";
            ret = TDatosAccess.ExecuteQuery(query, CommandType.Text);

            return true;

        }

        public Boolean VerValores(string tabla, clsCampo campo)
        {
            /* Esta funcion toma un campo de tipo desplegable 
             * y deja los valores que estan  la lista ValoresDeCambio y los deja en su valor original
             * Los demas valores los deja en 0
             */
            string query= string.Format("SELECT DISTINCT {0} from {1}", campo.nombre, tabla);

            TDatosAccess.conStr = conStr;
            DataTable dt = TDatosAccess.GetDataNonQuery(query);
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

                
                Thread.Sleep(1000);
                ret = TDatosAccess.ExecuteQuery(query, CommandType.Text);

                if (ret < 1)
                    MessageBox.Show("No se modificaron registros\n" + query);
            }
            Thread.Sleep(1000);
            return true;

        }


        public Boolean ExportarAExcel(String NombreTabla)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Application.Workbooks.Add(true);
                string query = "Select * from " + NombreTabla;

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
                        Microsoft.Office.Interop.Excel.Range range =excel.Cells[rowIndex + 1, ColumnIndex];
                        range.Value= dato;
                        range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlLeft;
                        //excel.Cells[rowIndex + 1, ColumnIndex]
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

    }
}
