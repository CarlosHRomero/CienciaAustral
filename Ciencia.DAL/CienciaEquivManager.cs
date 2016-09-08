using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ciencia.OBJ;
using Generales;

namespace Ciencia.DAL
{
    public class CienciaEquivManager : IBaseManager<CienciaEquiv>
    {
        private PetaPoco.Database db = new PetaPoco.Database("ICBA.Properties.Settings.ConnStr");
        List<CienciaEquiv> listaEquiv;
        //public CienciaEquiv ObtenerPorOrigen(string campoOrg, int tablaId) 

        public CienciaEquiv BuscarFechaEvento(int TablaId)
        {
            CienciaEquiv fechaEvento;
            string where = "fechaEvento = 1 and TablaId = " + TablaId.ToString();
            fechaEvento = Seleccionar(where, "", "").FirstOrDefault();
            return fechaEvento;
        }

        public CienciaEquiv BuscarFechaEventoPrincipal(int moduloId)
        {
            CienciaEquiv fechaEventoPrincipal;
            TablaEquivManager tabMan = new TablaEquivManager();
            
            CienciaTablaEquiv TablaTronco = tabMan.BuscarTablaTronco(moduloId);

            fechaEventoPrincipal = BuscarFechaEvento(TablaTronco.TablaId);
            return fechaEventoPrincipal;

        }

        public string BuscarFechaEvolucion(int moduloId)
        {
            string fechaEvolucion;
            TablaEquivManager tabMan = new TablaEquivManager();
            List<CienciaTablaEquiv> lista = tabMan.Seleccionar("", "", "").Where(x => x.EsEvolucion == true && x.ModuloId== moduloId).ToList();
            if(lista != null)
            {
                CienciaEquiv x;
                foreach(var tabla in lista)
                {
                    x = BuscarFechaEvento(tabla.TablaId);
                    if (x != null)
                    {
                        fechaEvolucion = x.CampoEquivalente;
                        return fechaEvolucion;
                    }
                }
                
            }
            return null;
        }

        
        public List<CienciaEquiv> ListarCamposPorModuloEvolucion(int moduloId, bool esEvolucion)
        {
            List<CienciaEquiv> lista;
            try
            {

                //var sql = PetaPoco.Sql.Builder.Append("select CienciaEquiv.* from CienciaEquiv, CienciaTablaEquiv ");
                string sql = "select CienciaEquiv.* from CienciaEquiv, CienciaTablaEquiv where " +
                             "CienciaEquiv.TablaId=CienciaTablaEquiv.TablaId and CienciaTablaEquiv.ModuloId = @0 and esEvolucion = @1 " +
                             "order by CienciaEquiv.EquivId";
                lista = db.Fetch<CienciaEquiv>(sql, moduloId, esEvolucion);
            }
            catch (Exception ex)
            {
                Utiles.WriteErrorLog("Error en CienciaEquivManager.Seleccionar " + ex.Message);
                lista = null;
            }
            return lista;
        }


        public List<CienciaEquiv> ListarCamposId(int moduloId,  List<clsCampo> campos,bool esEvolucion)
        {
            List<CienciaEquiv> lista, lista2=new List<CienciaEquiv>();
            List<int> listaTablaId= new List<int>();
            try
            {
                if(listaEquiv == null)
                    listaEquiv= Seleccionar("", "", "");

                foreach(var campo in campos)
                {
                    CienciaEquiv obj = listaEquiv.Find(x=> x.CampoEquivalente == campo.nombre);
                    if(listaTablaId.Find(x=> x == obj.TablaId) == 0)
                        listaTablaId.Add(obj.TablaId);
                }
                

                //var sql = PetaPoco.Sql.Builder.Append("select CienciaEquiv.* from CienciaEquiv, CienciaTablaEquiv ");
                string sql = "select CienciaEquiv.* from CienciaEquiv, CienciaTablaEquiv where " +
                             "CienciaEquiv.TablaId=CienciaTablaEquiv.TablaId and CienciaTablaEquiv.ModuloId = @0 and esEvolucion = @1 " +
                             " and CienciaEquiv.TipoDeDato = 'ID' order by CienciaEquiv.EquivId";
                lista = db.Fetch<CienciaEquiv>(sql, moduloId, esEvolucion);

                

                foreach(var obj in lista)
                {
                    var y = listaTablaId.Find(x => x == obj.TablaId);
                    if (y!= 0)
                        lista2.Add(obj);
                }
            }
            catch (Exception ex)
            {
                Utiles.WriteErrorLog("Error en CienciaEquivManager.Seleccionar " + ex.Message);
                lista = null;
            }
            return lista2;

        }
        public CienciaEquiv ObtenerPorOrigen(string campoOrg, int tablaId)
        {
            try
            {
                if(listaEquiv == null)
                    listaEquiv= Seleccionar("", "", "");

                CienciaEquiv cd = listaEquiv.FirstOrDefault(x => x.CampoOriginal.Trim().ToLower() == campoOrg.Trim().ToLower() && x.TablaId == tablaId);
                return cd;
                /*if(lista.Count == 0)
                    return null;
                if(lista.Count > 1)
                    throw new Exception("En ciencia Equiv Manager: Se encontro mas de un campo de origen con el mismo nombre.");
                return lista.First<CienciaCarEquiv>();*/
            }
            catch(Exception ex)
            {
                Utiles.WriteErrorLog(ex.Message);
                return null;
            }
        }

        public CienciaEquiv ObtenerPorCampoEquiv(string campoEqv, int tablaId)
        {
            try
            {
                if (listaEquiv == null)
                    listaEquiv = Seleccionar("", "", "");

                CienciaEquiv cd = listaEquiv.FirstOrDefault(x => x.CampoEquivalente.Trim() == campoEqv && x.TablaId == tablaId);
                return cd;
                /*if(lista.Count == 0)
                    return null;
                if(lista.Count > 1)
                    throw new Exception("En ciencia Equiv Manager: Se encontro mas de un campo de origen con el mismo nombre.");
                return lista.First<CienciaCarEquiv>();*/
            }
            catch (Exception ex)
            {
                Utiles.WriteErrorLog(ex.Message);
                return null;
            }
        }

        public List <string> ObtenerListaSolapas(int moduloId, bool esEvol)
        {
             var sql = PetaPoco.Sql.Builder.Append("select distinct solapa from cienciaEquiv inner join CienciaTablaEquiv on CienciaEquiv.TablaId = CienciaTAblaEquiv.TablaId");
                string Where = string.Format("moduloId = {0} and esEvolucion = {1} and solapa is not null", moduloId, esEvol== false ? "0":"1");
                if (!String.IsNullOrEmpty(Where))
                {
                    sql.Where(Where);
                }
                var lista = db.Fetch<CienciaEquiv>(sql);
                return (from eqv in lista
                        select eqv.Solapa).ToList();
        }


        public List<CienciaEquiv> ObtenerCamposPorTablaOrigen(int TablaOrgId)
        {
            try
            {
                string where = "TablaId = " + TablaOrgId.ToString();
                List<CienciaEquiv> lista = Seleccionar(where, "", "");
                return lista;
            }
            catch (Exception ex)
            {
                Utiles.WriteErrorLog(ex.Message);
                return null;
            }
        }

        public CienciaEquiv Insertar(CienciaEquiv Obj)
        {
            try
            {
                if ((Obj.EquivId = ObtenerMaxId() + 1) > 0)
                {
                    var res = db.Insert(Obj);
                }
                else
                    Obj = null;
            }
            catch (Exception ex)
            {
                Utiles.WriteErrorLog("En CienciaEquivManager " + ex.Message);
                Obj = null;
            }
            return Obj;
        }
        private int ObtenerMaxId()
        {
            try
            {
                var sql = PetaPoco.Sql.Builder
                    .Append("SELECT  Max(EquivId) FROM CienciaCarEquiv");
                return (db.ExecuteScalar<int>(sql));
            }
            catch (Exception ex)
            {
                Utiles.WriteErrorLog("Error en CienciaEquivManager.ObtenerMaxID: " + ex.Message);
                return -1;
            }
        }


        public bool Modificar(CienciaEquiv Obj)
        {
            Boolean result;
            try
            {
                db.Update(Obj);
                result = true;
            }
            catch (Exception ex)
            {
                Utiles.WriteErrorLog("En CienciaEquivManager " + ex.Message);
                result = false;
            }
            return result;
        }
        public List<CienciaEquiv> Seleccionar(string Where, string OrderBy, string Limit)
        {
            List<CienciaEquiv> lista;
            try
            {

                var sql = PetaPoco.Sql.Builder.Append("");
                //Where = "EquivId = 10";
                if (!String.IsNullOrEmpty(Where))
                {
                    sql.Where(Where);
                }
                if (!String.IsNullOrEmpty(OrderBy))
                {
                    sql.OrderBy(OrderBy);
                }
                lista = db.Fetch<CienciaEquiv>(sql);
            }
            catch (Exception ex)
            {
                Utiles.WriteErrorLog("Error en CienciaEquivManager.Seleccionar " + ex.Message);
                lista = null;
            }
            return lista;
        }
        public bool Eliminar(CienciaEquiv Obj)
        {
            Boolean result;
            try
            {
                db.Delete(Obj);
                result = true;
            }
            catch (Exception ex)
            {
                Utiles.WriteErrorLog("Error en CienciaEquivManager.Eliminar: " + ex.Message);
                result = false;
            }
            return result;

        }
        public bool Eliminar(string Cod)
        {
            throw new NotImplementedException();
        }
        public CienciaEquiv GetByID(String Cod)
        {
            try
            {
                var Ingr = db.SingleOrDefault<CienciaEquiv>("WHERE EquivId=@0", Cod);
                return Ingr;
            }
            catch (Exception ex)
            {
                Utiles.WriteErrorLog("CienciaEquivManager.GetById: " + ex.Message);
                return null;
            }
        }


    }
}
