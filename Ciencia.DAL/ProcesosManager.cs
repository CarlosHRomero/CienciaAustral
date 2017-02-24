using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Ciencia.OBJ;
using Generales;

namespace Ciencia.DAL
{
    public class ProcesosManager
    {
        private PetaPoco.Database db = new PetaPoco.Database("ICBA.Properties.Settings.conStr");
        public Ciencia_Procesos Insertar(Ciencia_Procesos Obj)
        {
            try
            {
               if ((Obj.ProcId = ObtenerMaxId() + 1) > 0)
               {
                    var res = db.Insert(Obj);
                }
                else
                    Obj=null;
            }
            catch (Exception ex)
            {
                Utiles.WriteErrorLog("En ProcesosManager " + ex.Message);
                Obj = null;
            }
            return Obj;
        }
        private int ObtenerMaxId()
        {
            try
            {
                var sql = PetaPoco.Sql.Builder.Append("select COUNT(*) from Ciencia_Procesos");
                var x = db.ExecuteScalar<int>(sql);
                if (x == 0)
                    return 0;
                sql = PetaPoco.Sql.Builder.Append("select MAX(procId) from Ciencia_Procesos");
                x = db.ExecuteScalar<int>(sql);
                return Convert.ToInt32(x);
            }
            catch (Exception ex)
            {
                Utiles.WriteErrorLog("Error en ProcesosManager.ObtenerMaxID: " + ex.Message);
                return 0;
            }
        }

        public bool Modificar(Ciencia_Procesos Obj)
        {
            Boolean result;
            try
            {
                db.Update(Obj);
                result = true;
            }
            catch (Exception ex)
            {
                Utiles.WriteErrorLog("En ProcesosManager " + ex.Message);
                result = false;
            }
            return result;
        }
        public Ciencia_Procesos GetByID(String Cod)
        {
            try
            {
                var obj = db.SingleOrDefault<Ciencia_Procesos>("WHERE Ant_Id=@0", Cod);
                return obj;
            }
            catch (Exception ex)
            {
                Utiles.WriteErrorLog("ProcesosManager.GetById: " + ex.Message);
                return null;
            }
        }
        public List<Ciencia_Procesos> Seleccionar(string Where, string OrderBy, string Limit)
        {
            List<Ciencia_Procesos> lista;
            try
            {
                var sql = PetaPoco.Sql.Builder.Append("");
                if (!String.IsNullOrEmpty(Where))
                {
                    sql.Where(Where);
                }
                if (!String.IsNullOrEmpty(OrderBy))
                {
                    sql.OrderBy(OrderBy);
                }
                lista = db.Fetch<Ciencia_Procesos>(sql);
            }
            catch (Exception ex)
            {
                Utiles.WriteErrorLog("Error en ProcesosManager.Seleccionar " + ex.Message);
                lista = null;
            }
            return lista;
        }
    }
}
