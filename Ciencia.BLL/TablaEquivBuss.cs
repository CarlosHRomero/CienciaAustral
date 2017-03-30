using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ciencia.OBJ;
using Ciencia.DAL;

namespace Ciencia.BLL
{
    public class TablaEquivBuss
    {
        TablaEquivManager man = new TablaEquivManager();
        private List<CienciaTablaEquiv> ListaTablas;
        public string TablaPorCodigo(int tablaId, bool esEvol)
        {
            if (ListaTablas == null)
            {
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

        public string BuscarTablaEquivalentePorTablaOrigen(string tablaOrg)
        {
            return man.ObtenerTablaEquivalentePorTablaOrigen(tablaOrg);            
        }

    }
}
