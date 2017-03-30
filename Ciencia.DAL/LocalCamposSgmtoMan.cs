using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ciencia.OBJ;
using System.Data;

namespace Ciencia.DAL
{
    public class LocalCamposSgmtoMan
    {
        private string _conStr;

        public LocalCamposSgmtoMan(string conStr)
        {
            _conStr = conStr;
        }
        public void CrearTabla()
        {
            try
            {
                if (TDatosAccess.ExisteTabla("camposSgmto"))
                    return;
                string query = "CREATE TABLE camposSgmto (EquivId int)";
                TDatosAccess.conStr = _conStr;
                TDatosAccess.ExecuteQuery(query, System.Data.CommandType.Text);
            }
            catch(Exception ex)
            {
                throw (ex);
            }
        }

        public void InsertarCampo(clsCampo campo)
        {
            string query = string.Format("Insert into camposSgmto values ({0})", campo.EquivId);
            TDatosAccess.conStr = _conStr;
            TDatosAccess.ExecuteQuery(query, System.Data.CommandType.Text);
        }

        public List<int> SeleccionarCampos()
        {
            string query = "Select equivId from camposSgmto";
            TDatosAccess.conStr = _conStr;
            var dt = TDatosAccess.GetDataNonQuery(query);
            var lista = new List<int>();
            foreach(DataRow row in dt.Rows)
            {
                lista.Add(Convert.ToInt32(row["EquivId"]));
            }
            return lista;
        }

        public void LimpiarTabla()
        {
            string query = string.Format("Delete from camposSgmto ");
            TDatosAccess.conStr = _conStr;
            TDatosAccess.ExecuteQuery(query, System.Data.CommandType.Text);
        }
    }
}
