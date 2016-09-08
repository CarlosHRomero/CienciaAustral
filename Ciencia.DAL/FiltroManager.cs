using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ciencia.OBJ;
using Generales;


namespace Ciencia.DAL
{
    public class FiltroManager
    {
        static private string _conStr;

        public FiltroManager(string conStr)
        {
            _conStr = conStr;
        }

        public Boolean Insertar(Ciencia_Car_Filtro Obj)
        {
            try
            {
                string query = "INSERT INTO Ciencia_Car_Filtro ( Tabla, Campo, Operador, Dato) VALUES (@1, @2, @3, @4)";
                OleDbConnection conec = new OleDbConnection(_conStr);
                OleDbCommand cmd = new OleDbCommand(query, conec);
                OleDbParameter par = new OleDbParameter();
                    par = new OleDbParameter("@1", Obj.Tabla);
                    cmd.Parameters.Add(par);
                    par = new OleDbParameter("@2", Obj.Campo);
                    cmd.Parameters.Add(par);
                    par = new OleDbParameter("@3", Obj.Operador);
                    cmd.Parameters.Add(par);
                    par = new OleDbParameter("@4", Obj.Dato);
                    cmd.Parameters.Add(par);

                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Utiles.WriteErrorLog("En FiltroManager " + ex.Message);
                return false;
            }
            
        }
    }
}
