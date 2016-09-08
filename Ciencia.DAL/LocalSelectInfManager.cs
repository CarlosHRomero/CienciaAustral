using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using Generales;
using Ciencia.OBJ;

namespace Ciencia.DAL
{
    public class LocalSelectInfManager
    {
        private string _conStr;
        public LocalSelectInfManager(string constr)
        {
            _conStr = constr;
        }


        public SelecInf ObtenerInfSeleccion()
        {
            try
            {
                List<SelecInf> lista = new List<SelecInf>();
                string query = "SELECT Id, ModuloId, Filtro from SelecInf ";
                if (TDatosAccess.conStr == null)
                    TDatosAccess.conStr = _conStr;
                DataTable dt = TDatosAccess.GetDataNonQuery(query, CommandType.Text, _conStr);
                foreach (DataRow row in dt.Rows)
                {
                    SelecInf obj = new SelecInf();
                    obj.id = Convert.ToInt32(row["Id"]);
                    obj.moduloId = Convert.ToInt32(row["moduloId"]);
                    obj.where = row["Filtro"].ToString();
                    lista.Add(obj);
                }
                return lista.FirstOrDefault<SelecInf>();
            }


            catch (OleDbException ex )
            {
                Generales.Utiles.WriteErrorLog("Error en LocalSelectorManager.ListaSeleccion: " + ex.Message);
                return null;
            }
        }
        public Boolean VerificarTablaSelecInf()
        {
            try
            {
                TDatosAccess.conStr = _conStr;
                return TDatosAccess.ExisteTabla("SelecInf");

            }
            catch (OleDbException ex)
            {
                Utiles.WriteErrorLog("Error en localSelectoManagerVerificarTablaSelecInf: " + ex.Message);
                return false;
            }
        }

        public Boolean Insertar(SelecInf obj)
        {
            try
            {
                string query = "insert into selecInf(ModuloId, filtro) values (@0, @1)";
                OleDbParameter[] param = new OleDbParameter[2];
                param[0] = new OleDbParameter("@0", obj.moduloId);
                param[1] = new OleDbParameter("@1", obj.where);
                TDatosAccess.conStr = _conStr;
                TDatosAccess.ExecuteCmd(query, CommandType.Text, param);
                return true;
            }
            catch (OleDbException ex)
            {
                Utiles.WriteErrorLog("Error en localSelectoManager.Insertar: " + ex.Message);
                return false;
            }

        }
        public Boolean BorrarTabla()
        {
            try
            {
                string query = "Delete from selecInf";
                TDatosAccess.conStr = _conStr;
                TDatosAccess.ExecuteCmd(query, CommandType.Text);
                return true;
            }
            catch (Exception ex)
            {
                Utiles.WriteErrorLog("Error en localSelectoManager.BorrarTabla: " + ex.Message);
                return false;
            }
        }
    }

}

