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
            var tablasConvertidas = tablasOrigenModulo.Where(x => x.EsEvolucion == false).Select(x => x.NombreTablaEquiv).Distinct().ToList<string>();
            string primeraTabla= tablasConvertidas.First();
            string tablasAgregadas = primeraTabla;
            tablasConvertidas.Remove(primeraTabla);
            foreach (string tabla in tablasConvertidas)
            {
                tablasAgregadas += string.Format(" inner join {1} on {0}.{2} = {1}.{2}", primeraTabla, tabla, clavePrimariaTronco);
            }

            return tablasAgregadas;


        }

    }
}
