using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ciencia.OBJ;
using System.Data.OleDb;
using System.Data;
using Generales;
namespace Ciencia.DAL
{
    public class LocalSelectorManager
    {
        private string _conStr;
        public LocalSelectorManager(string constr)
        {
            _conStr= constr;
        }


        public List<clsSelector> ListaSeleccion()
        {
            try
            {
                List<clsSelector> lista = new List<clsSelector>();
                string query = "SELECT  SelectorId, ConsultaMedica from Selector order by SelectorId ";
                DataTable dt = TDatosAccess.GetDataNonQuery(query, CommandType.Text, _conStr);
                foreach (DataRow row in dt.Rows)
                {
                    clsSelector obj = new clsSelector();
                    obj.SelectorId = Convert.ToInt32(row["SelectorId"]);
                    obj.ConsultaMedica = row["ConsultaMedica"].ToString();
                    lista.Add(obj);
                }
                return lista;
            }


            catch(Exception ex)
            {
                Generales.Utiles.WriteErrorLog("Error en LocalSelectorManager.ListaSeleccion: " + ex.Message);
                return null;
            }
        }

        public Boolean Insertar(clsSelector obj)
        {
            try
            {
                string query = "insert into selector(ConsultaMedica) values (@0)";
                OleDbParameter[] param = new OleDbParameter[1];
                param[0] = new OleDbParameter("@0", obj.ConsultaMedica);
                TDatosAccess.conStr = _conStr;
                TDatosAccess.ExecuteCmd(query, CommandType.Text, param );
                return true;
            }
            catch(OleDbException ex)
            {
                Utiles.WriteErrorLog("Error en localSelectoManager.Insertar: " + ex.Message);
                return false;
            }
        }
        public Boolean BorrarTablaSelector()
        {
            try
            {
                string query = "delete from selector";
                TDatosAccess.conStr = _conStr;
                TDatosAccess.ExecuteCmd(query, CommandType.Text);
                return true;
            }
            catch(OleDbException ex)
            {
                Utiles.WriteErrorLog("Error en localSelectoManager.BorrarTablaSelector: " + ex.Message);
                return false;
            }
        }
        public Boolean VerificarTablaSelector()
        {
            try
            {
                TDatosAccess.conStr = _conStr;
                return TDatosAccess.ExisteTabla("selector");

            }
            catch (OleDbException ex)
            {
                Utiles.WriteErrorLog("Error en localSelectoManagerVerificarTablaSelector: " + ex.Message);
                return false;
            }
        }
    }
}
