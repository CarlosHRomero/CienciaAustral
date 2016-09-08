using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ciencia.OBJ;
using Generales;

namespace Ciencia.DAL
{
    public class CarAntManager
    {
        private PetaPoco.Database db = new PetaPoco.Database("ICBA.Properties.Settings.ConnStr");
        public bool Eliminar(CienciaCarAnt Obj)
        {
            Boolean result;
            try
            {
                db.Delete(Obj);
                result = true;
            }
            catch (Exception ex)
            {
                Utiles.WriteErrorLog("Error en CarAntManager.Eliminar: " + ex.Message);
                result = false;
            }
            return result;

        }
        public bool Eliminar(string Cod)
        {
            throw new NotImplementedException();
        }
        public CienciaCarAnt GetByID(String Cod)
        {
            try
            {
                var Ingr = db.SingleOrDefault<CienciaCarAnt>("WHERE Ant_Id=@0", Cod);
                return Ingr;
            }
            catch (Exception ex)
            {
                Utiles.WriteErrorLog("CarAntManager.GetById: " + ex.Message);
                return null;
            }
        }
        public CienciaCarAnt Insertar(CienciaCarAnt Obj)
        {
            try
            {
                var res = db.Insert(Obj);
            }
            catch (Exception ex)
            {
                Utiles.WriteErrorLog("En CarAntManager " + ex.Message);
                Obj = null;
            }
            return Obj;
        }

        public bool Modificar(CienciaCarAnt Obj)
        {
            Boolean result;
            try
            {
                db.Update(Obj);
                result = true;
            }
            catch (Exception ex)
            {
                Utiles.WriteErrorLog("En CarAntManager " + ex.Message);
                result = false;
            }
            return result;
        }
        public List<CienciaCarAnt> Seleccionar(string Where, string OrderBy, string Limit)
        {
            List<CienciaCarAnt> lista;
            try
            {

                var sql = PetaPoco.Sql.Builder.Append("");
                //Where = "Ant_Id = 10";
                if (!String.IsNullOrEmpty(Where))
                {
                    sql.Where(Where);
                }
                if (!String.IsNullOrEmpty(OrderBy))
                {
                    sql.OrderBy(OrderBy);
                }
                lista = db.Fetch<CienciaCarAnt>(sql);
            }
            catch (Exception ex)
            {
                Utiles.WriteErrorLog("Error en CarAntManager.Seleccionar " + ex.Message);
                lista = null;
            }
            return lista;
        }

    }
}
