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

        public string ObtenerTablaEquivalentePorTablaOrigen(string tablaOrigen)
        {
            try
            {
                var sql = PetaPoco.Sql.Builder.Append("select NombreTabla from cienciatablaequiv ");
                sql.Where("tablaOrigen = " + tablaOrigen);
                var lista = db.Fetch<string>(sql);
                if (lista.Count != 1)
                {
                    throw new Exception("hay mas de una tabla equivalente");
                }
                return lista.First();
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

        public List<clsTablaEquivalente> ObtenerTablaSEquivalente(int moduloId)
        {
            var lista = ObtenerTablasSimpleEquivalente(moduloId);
            lista.AddRange(ObtenerTablasMultiplesEquivalente(moduloId));
            return lista;
        }

        
        public List<clsTablaEquivalente> ObtenerTablasSimpleEquivalente(int moduloId)
        {

            String where = string.Format("ModuloId = {0} and  EsEvolucion = 0 and esMultiple = 0", moduloId.ToString());
            var sql = PetaPoco.Sql.Builder.Append("select distinct NombreTablaEquiv from cienciatablaequiv");
            sql.Where(where);
            var lista = db.Fetch<string>(sql);
            var tablasOrigenModulo = ObtenerTablasOrigenPorModulo(moduloId, false);
            var clavePrimariaTronco = tablasOrigenModulo.Where(x => x.EsTronco == true).First().ClavePrimaria;
            var listaRes = new List<clsTablaEquivalente>();
            foreach(string tabla in lista)
            {
                clsTablaEquivalente obRes = new clsTablaEquivalente();
                obRes.nombre = tabla;
                obRes.claveForanea = clavePrimariaTronco;
                listaRes.Add(obRes);
            }
            return listaRes;
        }

        public List<clsTablaEquivalente> ObtenerTablasMultiplesEquivalente(int moduloId)
        {

            String where = string.Format("ModuloId = {0} and  EsEvolucion = 0 and esMultiple = 1", moduloId.ToString());
            var sql = PetaPoco.Sql.Builder.Append("select * from cienciatablaequiv");
            sql.Where(where);
            var lista = db.Fetch<CienciaTablaEquiv>(sql);
            var listaRes = new List<clsTablaEquivalente>();
            foreach( var obj in lista)
            {
                var obRes = new clsTablaEquivalente();
                obRes.nombre = obj.NombreTablaEquiv;
                obRes.claveForanea= obj.ClaveForanea;
                listaRes.Add(obRes);
            }
            return listaRes;
        }

        public List<clsTablaEquivalente> ObtenerTablasEquivalente(int moduloId, List<string> TablasOrg)
        {
            String where;
            PetaPoco.Sql sql;
            List<CienciaTablaEquiv> lista = new List<CienciaTablaEquiv>();
            CienciaTablaEquiv tE;
            foreach(string tabla in TablasOrg)
            {
                sql = PetaPoco.Sql.Builder.Append("select * from cienciatablaequiv");
                where = string.Format("ModuloId = {0} and  NombreTabla = '{1}'", moduloId, tabla);
                sql.Where(where);
                tE = db.Single<CienciaTablaEquiv>(sql);
                if(lista.Find(x=> x.NombreTabla == tE.NombreTabla)== null)
                    lista.Add(tE);
            }
            
            var listaRes = new List<clsTablaEquivalente>();
            foreach (var obj in lista)
            {
                var obRes = new clsTablaEquivalente();
                obRes.nombre = obj.NombreTablaEquiv;
                obRes.claveForanea = obj.ClaveForanea;
                if (listaRes.Find(x => x.nombre== obRes.nombre) == null)
                    listaRes.Add(obRes); ;
                
            }
            return listaRes;
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
