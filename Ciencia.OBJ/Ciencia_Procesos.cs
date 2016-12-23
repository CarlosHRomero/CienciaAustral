using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ciencia.OBJ
{
    [PetaPoco.TableName("Ciencia_Procesos")]
    [PetaPoco.PrimaryKey("ProcId")]
    public class Ciencia_Procesos
    {
        public int ProcId { get; set; }
        public int ModuloId { get; set; }
        public string User_LogOn { get; set; }
        public Nullable<DateTime> Proc_ini_F { get; set; }
        public Nullable<DateTime> Proc_fin_F { get; set; }
        public string Proc_Maq_T { get; set; }
    }
}
