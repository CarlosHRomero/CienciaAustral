using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generales;
using Ciencia.OBJ;

namespace Ciencia.DAL
{
    public class car_evol1Manager
    {
        private PetaPoco.Database db = new PetaPoco.Database("Au.Properties.Settings.conStr");

        public List<Car_evol_1> Seleccionar(string Where, string OrderBy)
        {
            List<Car_evol_1> lista;
            try
            {

                var sql = PetaPoco.Sql.Builder.Append("");
                //Where = "Ingr_Id = 10";
                if (!String.IsNullOrEmpty(Where))
                {
                    sql.Where(Where);
                }
                if (!String.IsNullOrEmpty(OrderBy))
                {
                    sql.OrderBy(OrderBy);
                }
                lista = db.Fetch<Car_evol_1>(sql);
            }
            catch (Exception ex)
            {
                Utiles.WriteErrorLog("Error en car_evol1Manager.Seleccionar " + ex.Message);
                lista = null;
            }
            return lista;
        
        }
        public void Update(Car_evol_1 Obj)
        {
            var res = db.Update(Obj);
        }
        public Car_evol_1 Insertar(Car_evol_1 Obj)
        {
            try
            {
                var res = db.Insert(Obj);
            }
            catch (Exception ex)
            {
                Utiles.WriteErrorLog("En car_evol1Manager.Insertar " + ex.Message);
                Obj = null;
            }
            return Obj;
        }
        private int ObtenerMaxId()
        {
            try
            {
                var sql = PetaPoco.Sql.Builder
                    .Append("SELECT  Max(Evol_Id) FROM Car_evol_1");
                return (db.ExecuteScalar<int>(sql));
            }
            catch (Exception ex)
            {
                Utiles.WriteErrorLog("Error en car_evol1Manager.ObtenerMaxID: " + ex.Message);
                return -1;
            }
        }

    }
}
