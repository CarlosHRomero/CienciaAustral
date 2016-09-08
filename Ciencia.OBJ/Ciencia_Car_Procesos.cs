using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ciencia.OBJ
{
    [PetaPoco.TableName("Ciencia_Car_Procesos")]
    [PetaPoco.PrimaryKey("ProcId", AutoIncrement = false)]
    public class Ciencia_Car_Procesos
    {
        public int ProcId { get; set; }
        public Nullable<DateTime> Proc_F { get; set; }
        public Nullable<int> UsrId { get; set; }
        public Nullable<DateTime> SelD_F { get; set; }
        public Nullable<DateTime> SelH_F { get; set; }
        public string Motivo { get; set; }
    }
}
