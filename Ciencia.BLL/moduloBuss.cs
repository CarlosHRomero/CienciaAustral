using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ciencia.OBJ;
using Ciencia.DAL;

namespace Ciencia.BLL
{
    public class moduloBuss
    {
        ModuloManager man = new ModuloManager();

        public Ciencia_Modulo ObtenerDatosModulo(int moduloId)
        {
            return man.ObtenerDatosModulo(moduloId.ToString());
        }

        public string ObtnerTablasAgregadas(int moduloId)
        {
            List<CienciaTablaEquiv> tablasOrigenModulo;
            TablaEquivManager teMan = new TablaEquivManager();
            tablasOrigenModulo = teMan.ObtenerTablasOrigenPorModulo(moduloId, false);
            var clavePrimariaTronco = tablasOrigenModulo.Where(x => x.EsTronco == true).First().ClavePrimaria;
            var tablasConvertidas = tablasOrigenModulo.Where(x => x.EsEvolucion == false && x.EsMultiple == false).Select(x => x.NombreTablaEquiv).Distinct().ToList<string>();
            string primeraTabla= tablasConvertidas.First();
            string tablasAgregadas = primeraTabla;
            tablasConvertidas.Remove(primeraTabla);
            foreach (string tabla in tablasConvertidas)
            {
                tablasAgregadas += string.Format(" inner join {1} on {0}.{2} = {1}.{2}", primeraTabla, tabla, clavePrimariaTronco);
            }
            /////
            var tablasMultiple = tablasOrigenModulo.Where(x => x.EsMultiple == true);
            string tablasMultiplesAgregadas=null;
            var tablaPrincipal = tablasOrigenModulo.Where(x => x.EsTronco == true).First();
            foreach (var tablaMultiple in tablasMultiple)
            {
                tablasAgregadas += string.Format(" left join {0} on {1}.{2} = {3}.{4}", tablaMultiple.NombreTablaEquiv, tablaPrincipal.NombreTablaEquiv, tablaPrincipal.ClavePrimaria, tablaMultiple.NombreTablaEquiv, tablaMultiple.ClaveForanea);
            }
            ///////
            //var tablasConvertidasMul = tablasOrigenModulo.Where(x => x.EsEvolucion == false && x.EsMultiple == true).Select(x => x.NombreTablaEquiv).Distinct().ToList<string>();

            return tablasAgregadas;


        }

    }
}
