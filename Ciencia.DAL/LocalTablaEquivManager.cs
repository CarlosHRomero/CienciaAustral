using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using Cardiologia.DAL;
using Ciencia.OBJ;

namespace Ciencia.DAL
{
    public class LocalTablaEquivManager
    {
        private string conStr;
        public LocalTablaEquivManager(string constr)
        {
            conStr = constr;
        }

        public List<CienciaTablaEquiv> TraerListaTabla(Boolean evol)
        {
            try
            {
                string query = "SELECT TablaId, NombreTabla, Descripcion FROM CienciaTablaEquiv ";  //Se excluye la tabla evolucion
                if (evol)
                    query += "where EsEvolucion <> 0";
                else
                    query += "where EsEvolucion = 0";
                List<CienciaTablaEquiv> lista = new List<CienciaTablaEquiv>();
                TDatosAccess.conStr = conStr;
                DataTable dt = TDatosAccess.GetDataNonQuery(query, CommandType.Text);
                
                foreach (DataRow row in dt.Rows)
                {
                    CienciaTablaEquiv obj = new CienciaTablaEquiv();
                    obj.TablaId = Convert.ToInt32(row["TablaId"]);
                    obj.NombreTabla = row["NombreTabla"].ToString();
                    obj.Descripcion = row["Descripcion"].ToString();
                    lista.Add(obj);
                }
                return lista;
            }
            catch (Exception ex)
            {
                Utiles.WriteErrorLog("" + ex.Message);
                return null;
            }
        }
        public string TraerTablaPorCodigo(int TablaId)
        {
            try
            {
                string query = "SELECT NombreTabla FROM CienciaCarTablaEquiv WHERE TablaId = @0";

                OleDbParameter[] param = new OleDbParameter[1];
                param[0] = new OleDbParameter("@0", TablaId);
                TDatosAccess.conStr = conStr;
                DataTable dt = TDatosAccess.GetDataNonQuery(query, CommandType.Text, param);
                string tabla = dt.Rows[0]["Nombre tabla"].ToString();
                return tabla.ToString();
            }
            catch (Exception ex)
            {
                Utiles.WriteErrorLog("" + ex.Message);
                return null;
            }
        }
    }
}
