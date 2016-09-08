using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  Ciencia.OBJ;
using  Ciencia.DAL;



namespace Ciencia.BLL
{
    public class LocalEquivB
    {
        string _constr;

        public LocalEquivB(string constr )
        {
            _constr = constr;
            man =  new LocalCienciaEquivMan(_constr);
        }

        public List<CienciaEquiv> ListaCamposPorTabla(int tablaId,  string constr)
        {
            //if (tablaId == 0)
            //    return ListaTodosCampos(constr);
            //LocalCarEquivMan man = new LocalCarEquivMan(constr);
            //return (man.ListarCampos(tablaId));
            return null;
        }

        public List<CienciaEquiv> ListaTodosCampos(int moduloId, string constr, bool esEvolucion)
        {
            //LocalCienciaEquivMan man = new LocalCienciaEquivMan(constr);
            return (man.ListarCamposPorModuloEvolucion(moduloId, esEvolucion).Where(x=> x.TipoDeDato !=  "ID").ToList());
        }

        LocalCienciaEquivMan man;
        public Boolean ActualizarSelecciónCampo(CienciaEquiv obj)
        {
            
            return man.Modificar(obj);
        }

        private List<CienciaTablaEquiv> ListaTablas;
        public string TablaPorCodigo(int tablaId, string constr, bool esEvol)
        {
            if (ListaTablas == null)
            {
                LocalTablaEquivManager man = new LocalTablaEquivManager(constr);
                ListaTablas = man.TraerListaTabla(esEvol);
            }
            //string tabla 
            
            //ListaTablas.Where(x => x)

            var tabla2 = from tabla in ListaTablas
                         where tabla.TablaId == tablaId
                                    select tabla.NombreTabla;
            var firstOrDefault = tabla2.FirstOrDefault();
            if (firstOrDefault != null) return firstOrDefault.ToString();

            return null;


            //return man.TraerTablaPorCodigo(tablaId);
        }
        List<AdmEquiv> listaEquiv;
        //public string EquivPorCodigo(int cod, string tit, string strcon)
        //{

        //    AdmEquivMan man = new AdmEquivMan();
        //    if (listaEquiv == null)
        //        listaEquiv = man.ListadoPorTitulo(tit);

        //    var equiv_desc = from eqv in listaEquiv
        //                     where eqv.Eqv_Val == cod
        //                     select eqv.Eqv_Desc;
        //    return equiv_desc.First().ToString();
        //}

        public List<CienciaEquiv> ListaCamposEvolucion(int moduloId, string localConStr)
        {
            return ListaTodosCampos(moduloId, localConStr, true);
        }

        public void ActualizarSelección(List<CienciaEquiv> lista)
        {
            man.ModificarLista(lista);
        }
    }
}
