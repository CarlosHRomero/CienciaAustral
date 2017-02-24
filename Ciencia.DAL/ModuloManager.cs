using Ciencia.OBJ;
using Generales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ciencia.DAL
{
    public class ModuloManager : IBaseManager<Ciencia_Modulo>
    {
        private PetaPoco.Database _db = new PetaPoco.Database("ICBA.Properties.Settings.conStr");

        public Ciencia_Modulo ObtenerDatosModulo(String moduloId)
        {
            String where = "ModuloId = " + moduloId;
            List<Ciencia_Modulo> lista = Seleccionar(where, "", "");
            if (lista.Count > 0)
                return (lista.First());
            else
                return null;
        }

        public List<Ciencia_Modulo> Seleccionar(string @where, string orderBy, string limit)
        {
            List<Ciencia_Modulo> lista;
            try
            {
                var sql = PetaPoco.Sql.Builder;
                if (!String.IsNullOrEmpty(@where))
                {
                    sql.Where(@where);
                }
                if (!String.IsNullOrEmpty(orderBy))
                {
                    sql.OrderBy(orderBy);
                }
                lista = _db.Fetch<Ciencia_Modulo>(sql);
            }
            catch (Exception e)
            {
                Utiles.WriteErrorLog("Error en ModuloManager.Seleccionar " + e.Message);
                lista = null;
            }
            return lista;
        }


        public Ciencia_Modulo GetByID(String Cod)
        {
            try
            {
                var Tabla = _db.SingleOrDefault<Ciencia_Modulo>("WHERE ModuloId=@0", Cod);
                return Tabla;
            }
            catch (Exception ex)
            {
                Utiles.WriteErrorLog("ModuloManager.GetById: " + ex.Message);
                return null;
            }
        }

        public bool Modificar(Ciencia_Modulo Obj)
        {
            Boolean result;
            try
            {
                _db.Update(Obj);
                result = true;
            }
            catch (Exception ex)
            {
                Utiles.WriteErrorLog("En ModuloManager " + ex.Message);
                result = false;
            }
            return result;
        }

        public Ciencia_Modulo Insertar(Ciencia_Modulo Obj)
        {
            throw new NotImplementedException();
        }

        public bool Eliminar(Ciencia_Modulo Obj)
        {
            throw new NotImplementedException();
        }

        public bool Eliminar(string Cod)
        {
            throw new NotImplementedException();
        }
    }
}
