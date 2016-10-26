using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ciencia.OBJ
{
    public class CienciaEquiv
    {
        public int EquivId { get; set; }
        public int TablaId { get; set; }
        public string CampoOriginal { get; set; }
        public string CampoEquivalente { get; set; }
        public string TipoDeDato { get; set; }
        public string ValorPorDefecto { get; set; }
        public string Solapa { get; set; }
        public string Filtro { get; set; }
        public int? orden { get; set; }
        public Boolean Seleccion { get; set; }
        public string ValoresACero { get; set; }
        public string ValoresACeroStr { get; set; }
        public string TipoDatoSqlServer { get; set; }
        public string TipoDatoAccess { get; set; }
        public bool VerValor { get; set; }
    }
}
