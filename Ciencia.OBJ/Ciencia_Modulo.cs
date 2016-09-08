using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ciencia.OBJ
{
    [PetaPoco.TableName("Ciencia_Modulo")]
    [PetaPoco.PrimaryKey("ModuloId", AutoIncrement = false)]
    public class Ciencia_Modulo
    {
        public int ModuloId { get; set; }
        public string Nombre { get; set; }
        public string TablaEquiv { get; set; }
        public int TablasGeneradas { get; set; }
        public string ClavePrimariaEvol { get; set; }
        public string ClaveExternaEvol {get; set;}
        public int TablaExternaEvol_Id { get; set; }
    }
}
