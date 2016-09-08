using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ciencia.OBJ
{

    public class Ciencia_Car_Seleccion
    {
        int id;
        public DateTime? Sel_fecha { get; set; }
        public DateTime? sel_desde { get; set; }
        public DateTime? Sel_hasta { get; set; }
        public String Sel_usuario { get; set; } 
        public String Sel_filtro { get; set; }
    }
}
