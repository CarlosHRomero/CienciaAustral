using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ciencia.OBJ
{
    [PetaPoco.TableName("SeguimientoAnualHemodinamia")]
    [PetaPoco.PrimaryKey("PacId", AutoIncrement = false)]
    public class SeguimientoAnualHemodinamia
    {
        public int PacId { get; set; }
        public string Pac_ApeNom { get; set; }
        public string Obito_sino { get; set; }
        public DateTime? Obito_fecha { get; set; }
        public string Obito_tipo { get; set; }
        public string Reint_SiNo { get; set; }
        public Nullable<System.DateTime> Reint_Fecha { get; set; }
        public string Reint_Causa { get; set; }
        public string Reinterv_SiNo { get; set; }
        public Nullable<System.DateTime> Reinterv_fecha { get; set; }
        public string Reinterv_Localiz { get; set; }
        public string Reinterv_Mec_Reste { get; set; }
        public string Reinterv_Mec_Trom_ARC { get; set; }
        public string Reinterv_Mec_Trom_Tiempo { get; set; }
        public string Sangr_SiNo { get; set; }
        public string Sangr_tipo { get; set; }
        public string Sangr_Local { get; set; }
        public string Antiagr_SiNo { get; set; }
        public Nullable<System.DateTime> Antiagr_FechaSus { get; set; }
        public string Antiagr_Tipo { get; set; }
        public DateTime? Ultimo_Sgmto { get; set; }

    }
}
