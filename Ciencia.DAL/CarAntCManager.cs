using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ciencia.OBJ;
using Generales;
namespace Ciencia.DAL
{
    public class CarAntCManager
    {
        private PetaPoco.Database db = new PetaPoco.Database("ICBA.Properties.Settings.ConnStr");
        public bool Eliminar(CienciaCarAntC Obj)
        {
            Boolean result;
            try
            {
                db.Delete(Obj);
                result = true;
            }
            catch (Exception ex)
            {
                Utiles.WriteErrorLog("Error en CarAntManagerC.Eliminar: " + ex.Message);
                result = false;
            }
            return result;

        }
        public bool Eliminar(string Cod)
        {
            throw new NotImplementedException();
        }
        public CienciaCarAntC GetByID(String Cod)
        {
            try
            {
                var Ingr = db.SingleOrDefault<CienciaCarAntC>("WHERE Ant_Id=@0", Cod);
                return Ingr;
            }
            catch (Exception ex)
            {
                Utiles.WriteErrorLog("CarAntManagerC.GetById: " + ex.Message);
                return null;
            }
        }
        public CienciaCarAntC Insertar(CienciaCarAntC Obj)
        {
            try
            {
                var res = db.Insert(Obj);
            }
            catch (Exception ex)
            {
                Utiles.WriteErrorLog("En CarAntManagerC " + ex.Message);
                Obj = null;
            }
            return Obj;
        }

        public bool Modificar(CienciaCarAntC Obj)
        {
            Boolean result;
            try
            {
                db.Update(Obj);
                result = true;
            }
            catch (Exception ex)
            {
                Utiles.WriteErrorLog("En CarAntManagerC " + ex.Message);
                result = false;
            }
            return result;
        }
        public List<CienciaCarAntC> Seleccionar(string Where, string OrderBy, string Limit)
        {
            List<CienciaCarAntC> lista;
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
                lista = db.Fetch<CienciaCarAntC>(sql);
            }
            catch (Exception ex)
            {
                Utiles.WriteErrorLog("Error en CarAntManagerC.Seleccionar " + ex.Message);
                lista = null;
            }
            return lista;
        }

    }
}
