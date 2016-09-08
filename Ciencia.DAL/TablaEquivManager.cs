using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ciencia.OBJ;
using Generales;

namespace Ciencia.DAL
{
    public class TablaEquivManager
    {
        private PetaPoco.Database db = new PetaPoco.Database("ICBA.Properties.Settings.ConnStr");


        public CienciaTablaEquiv BuscarTablaTronco(int moduloId)
        {
            string where = "ModuloId = " + moduloId.ToString() + " and esTronco = 1 and esEvolucion = 0";
            CienciaTablaEquiv tablaTronco = Seleccionar(where, "", "").FirstOrDefault();
            return tablaTronco;
        }


        public List<CienciaTablaEquiv> ObtenerTablasOrigenPorModulo(int moduloId, bool esEvol)
        {
            String where;
            try
            {
                if (!esEvol)
                    where = string.Format("ModuloId = {0} and esEvolucion = 0", moduloId.ToString());
                else
                    where = string.Format("ModuloId = {0} and esEvolucion = 1", moduloId.ToString());
                List<CienciaTablaEquiv> lista = Seleccionar(where, "orden", "");
                return lista;
            }
            catch (Exception ex)
            {
                Utiles.WriteErrorLog(ex.Message);
                return null;
            }
        }

        public List<CienciaTablaEquiv> ObtenerTablasOrigenPorModulo(int moduloId)
        {
            String where;
            try
            {

                where = string.Format("ModuloId = {0} ", moduloId.ToString());
                List<CienciaTablaEquiv> lista = Seleccionar(where, "", "");
                return lista;
            }
            catch (Exception ex)
            {
                Utiles.WriteErrorLog(ex.Message);
                return null;
            }
        }

        public string ObtenerTablaEquivalente(int moduloId)
        {
            String where = string.Format("where ModuloId = {0} and EsTronco=1 and esEvolucion = 0", moduloId.ToString());
            var tabla = db.SingleOrDefault<CienciaTablaEquiv>(where);
            if (tabla != null)
                return tabla.NombreTablaEquiv;
            else
                return null;
        }

        public List<string> ObtenerTablaSEquivalente(int moduloId)
        {

            String where = string.Format("ModuloId = {0} and  EsEvolucion = 0", moduloId.ToString());
            var sql = PetaPoco.Sql.Builder.Append("select distinct NombreTablaEquiv from cienciatablaequiv");
            sql.Where(where);
            var lista = db.Fetch<string>(sql);
            return lista;
        }

        /*public CienciaTablaEquiv ObtenerTablaEquivalente(int moduloId)
        {polimorfismo
            String where = string.Format("where ModuloId = {0} and EsTronco=1", moduloId.ToString());
            var tabla = db.SingleOrDefault<CienciaTablaEquiv>(where);
            if (tabla != null)
                return tabla;
            else
                return null;
        }*/

        public string ObtenerTablaEquivalenteEvolucion(int moduloId)
        {
            String where = string.Format("ModuloId = {0} and EsEvolucion=1", moduloId.ToString());
            var tabla = Seleccionar(where, "", "").FirstOrDefault();
            if (tabla != null)
                return tabla.NombreTablaEquiv;
            else
                return null;
        }

        public CienciaTablaEquiv ObtenerPorTablaOrigen(string TablaOrigen)
        {
            try
            {
                string where = "NombreTabla = '" + TablaOrigen + "'";
                var tabla = db.SingleOrDefault<CienciaTablaEquiv>("WHERE NombreTabla=@0", TablaOrigen);
                return tabla;
            }
            catch (Exception ex)
            {
                Utiles.WriteErrorLog("Error en TablaEquivManager.ObtenerPorTablaOrigen:  " + ex.Message);
                return null;
            }
        }

        public bool Eliminar(CienciaTablaEquiv Obj)
        {
            Boolean result;
            try
            {
                db.Delete(Obj);
                result = true;
            }
            catch (Exception ex)
            {
                Utiles.WriteErrorLog("Error en TablaEquivManager.Eliminar: " + ex.Message);
                result = false;
            }
            return result;

        }
        public bool Eliminar(string Cod)
        {
            throw new NotImplementedException();
        }
        public CienciaTablaEquiv GetByID(String Cod)
        {
            try
            {
                var Tabla = db.SingleOrDefault<CienciaTablaEquiv>("WHERE TablaId=@0", Cod);
                return Tabla;
            }
            catch (Exception ex)
            {
                Utiles.WriteErrorLog("TablaEquivManager.GetById: " + ex.Message);
                return null;
            }
        }


        public CienciaTablaEquiv Insertar(CienciaTablaEquiv Obj)
        {
            try
            {
                if ((Obj.TablaId = ObtenerMaxId() + 1) > 0)
                {
                    var res = db.Insert(Obj);
                }
                else
                    Obj = null;
            }
            catch (Exception ex)
            {
                Utiles.WriteErrorLog("En TablaEquivManager " + ex.Message);
                Obj = null;
            }
            return Obj;
        }
        private int ObtenerMaxId()
        {
            try
            {
                var sql = PetaPoco.Sql.Builder
                    .Append("SELECT  Max(TablaId) FROM CienciaCarTablaEquiv");
                return (db.ExecuteScalar<int>(sql));
            }
            catch (Exception ex)
            {
                Utiles.WriteErrorLog("Error en TablaEquivManager.ObtenerMaxID: " + ex.Message);
                return -1;
            }
        }


        public bool Modificar(CienciaTablaEquiv Obj)
        {
            Boolean result;
            try
            {
                db.Update(Obj);
                result = true;
            }
            catch (Exception ex)
            {
                Utiles.WriteErrorLog("En TablaEquivManager " + ex.Message);
                result = false;
            }
            return result;
        }
        public List<CienciaTablaEquiv> Seleccionar(string Where, string OrderBy, string Limit)
        {
            List<CienciaTablaEquiv> lista;
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
                lista = db.Fetch<CienciaTablaEquiv>(sql);
            }
            catch (Exception ex)
            {
                Utiles.WriteErrorLog("Error en TablaEquivManager.Seleccionar " + ex.Message);
                lista = null;
            }
            return lista;
        }


        public List<CienciaTablaEquiv> TraerListaTabla(bool esEvol)
        {
            string where;
            if (esEvol)
                where = "EsEvolucion <> 0";
            else
                where = "EsEvolucion = 0";

            return Seleccionar(where, "", "");

        }
    }
}
