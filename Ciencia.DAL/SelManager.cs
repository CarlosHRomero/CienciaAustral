using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ciencia.OBJ;
using Generales;


namespace Ciencia.DAL
{
    public class SelManager
    {
        static private string _conStr;

        public SelManager(string conStr)
        {
            _conStr = conStr;
        }


        public Boolean Insertar(Ciencia_Car_Seleccion Obj)
        {
            try
            {
                string query = "INSERT INTO Ciencia_Car_Seleccion ( Sel_fecha, Sel_desde, Sel_hasta, Sel_Usuario, Sel_filtro) VALUES (@1, @2, @3, @4, @5)";
                OleDbConnection conec = new OleDbConnection(_conStr);
                OleDbCommand cmd = new OleDbCommand(query, conec);
                OleDbParameter par = new OleDbParameter();
                if (Obj.Sel_fecha.HasValue)
                {
                    par = new OleDbParameter("@1", Obj.Sel_fecha);
                    cmd.Parameters.Add(par);
                }
                else
                {
                    cmd.Parameters.Add(DBNull.Value);
                }
                if (Obj.sel_desde.HasValue)
                {
                    par = new OleDbParameter("@2", Obj.sel_desde);
                    cmd.Parameters.Add(par);
                }
                else
                {
                    cmd.Parameters.Add(DBNull.Value);
                }
                if (Obj.Sel_hasta.HasValue)
                {
                    par = new OleDbParameter("@3", Obj.Sel_hasta);
                    cmd.Parameters.Add(par);
                }
                else
                {
                    cmd.Parameters.Add(DBNull.Value);
                }
                par = new OleDbParameter("@4", Obj.Sel_usuario);
                    cmd.Parameters.Add(par);
                par = new OleDbParameter("@5", Obj.Sel_filtro);
                cmd.Parameters.Add(par);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Utiles.WriteErrorLog("En CarAntManagerC " + ex.Message);
                return false;
            }
        }
    }
}
