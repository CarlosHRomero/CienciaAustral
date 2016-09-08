using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ciencia.DAL;
using Ciencia.OBJ;

namespace Ciencia.BLL
{
    public class NumDePacB
    {

        public List<NumDePac> CalcularNumDePac(string tablas, string where, string campo, string filtro, string TipoDeDato, string strcon, int  moduloId)
        {
            NumDePacManager man = new NumDePacManager(strcon);

            ModuloManager modMan = new ModuloManager();
            //string query = string.Format("select {0} from {1} where {2} ", campo, tablas, where);

            return man.CalcularNumDePac(tablas,  where, campo, filtro, TipoDeDato, modMan.ObtenerDatosModulo(moduloId.ToString()).TablaEquiv);

           

        }
    }
}
