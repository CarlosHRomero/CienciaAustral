using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ciencia.OBJ
{
    public class clsCampo 
    {
        public int EquivId { get; set; }
        public int tablaId { get; set; }
        public string tabla { get; set; }
        public string nombre { get; set; }
        public List<string> ListaValores{ get; set; }
        public string Func { get; set; }
        public List<SelTablaEvol> selTe { get; set; }
        public bool verValor { get; set; }
    }
}
