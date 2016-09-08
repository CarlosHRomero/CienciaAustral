using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ciencia.OBJ;

namespace Ciencia.DAL
{
    class ListasDesplegables
    {
        public List<CienciaCarTablaEquiv> ListaTabla()
        {
            TablaEquivManager man = new TablaEquivManager();
            List<CienciaCarTablaEquiv>  lista = man.Seleccionar("", "", "");
            return lista;
        }

        public List<CienciaCarEquiv> ListaCampos(int TablaId)
        {
            CienciaEquivManager man = new CienciaEquivManager();
            string where = "TablaId = " + TablaId.ToString();
            List<CienciaCarEquiv> lista = man.Seleccionar(where, "", "");
            return lista;
        }

        public List<string> ListaOperador()
        {
            var lista = new List<string>();
            lista.Add("Like");
            lista.Add("=");
            lista.Add(">");
            lista.Add("<");
            lista.Add(">=");
            lista.Add("<=");
            lista.Add("<>");
            return lista;
        }
        /*
        public List<String> ListaDatos(String Tabla, String Campo)
        {
            object valor;


        }*/

    }
}
