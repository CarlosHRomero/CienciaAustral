using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ciencia.OBJ
{
    [PetaPoco.TableName("CienciaTablaEquiv")]
    [PetaPoco.PrimaryKey("TablaId", AutoIncrement = false)]
    public class CienciaTablaEquiv
    {
        public int TablaId { get; set; }
        public string NombreTabla { get; set; }
        public string NombreTablaEquiv { get; set; }
        public string Descripcion { get; set; }
        public bool EsTronco { get; set; }
        public bool EsEvolucion { get; set; }
        public bool EsPaciente { get; set; }
        public int ModuloId { get; set; }
        public string ClaveForanea { get; set; }
        public string ClavePrimaria { get; set; }
        public string ClavePrimariaEquiv { get; set; }
        public string ClaveForaneaEvol { get; set; }
        public bool EsMultiple { get; set; }
        public bool Procesar { get; set; }
        public string CampoFecha { get; set; }
    }
}
