using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ciencia.OBJ;
using Generales;


namespace Ciencia.DAL
{
    public class CarIngrManager
    {
        private PetaPoco.Database db = new PetaPoco.Database("ICBA.Properties.Settings.ConnStr");
        public bool Eliminar(Ciencia_Car_Ingr Obj)
        {
            Boolean result;
            try
            {
                db.Delete(Obj);
                result = true;
            }
            catch (Exception ex)
            {
                Utiles.WriteErrorLog("Error en CarIngrManager.Eliminar: " + ex.Message);
                result = false;
            }
            return result;

        }
        public bool Eliminar(string Cod)
        {
            throw new NotImplementedException();
        }
        public Ciencia_Car_Ingr GetByID(String Cod)
        {
            try
            {
                var Ingr = db.SingleOrDefault<Ciencia_Car_Ingr>("WHERE Ingr_Id=@0", Cod);
                return Ingr;
            }
            catch (Exception ex)
            {
                Utiles.WriteErrorLog("CarIngrManager.GetById: " + ex.Message);
                return null;
            }
        }
        public Ciencia_Car_Ingr Insertar(Ciencia_Car_Ingr Obj)
        {
            try
            {
                var res = db.Insert(Obj);
            }
            catch (Exception ex)
            {
                Utiles.WriteErrorLog("En CarIngrManager " + ex.Message);
                Obj = null;
            }
            return Obj;
        }
        private int ObtenerMaxId()
        {
            try
            {
                var sql = PetaPoco.Sql.Builder
                    .Append("SELECT  Max(Ingr_Id) FROM Car_Ingr_New");
                return (db.ExecuteScalar<int>(sql));
            }
            catch (Exception ex)
            {
                Utiles.WriteErrorLog("Error en CarIngrManager.ObtenerMaxID: " + ex.Message);
                return -1;
            }
        }

        public bool Modificar(Ciencia_Car_Ingr Obj)
        {
            Boolean result;
            try
            {
                db.Update(Obj);
                result = true;
            }
            catch (Exception ex)
            {
                Utiles.WriteErrorLog("En CarIngrManager " + ex.Message);
                result = false;
            }
            return result;
        }
        public List<Ciencia_Car_Ingr> Seleccionar(string Where, string OrderBy, string Limit)
        {
            List<Ciencia_Car_Ingr> lista;
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
                lista = db.Fetch<Ciencia_Car_Ingr>(sql);
            }
            catch (Exception ex)
            {
                Utiles.WriteErrorLog("Error en CarIngrManager.Seleccionar " + ex.Message);
                lista = null;
            }
            return lista;
        }

    }
}
