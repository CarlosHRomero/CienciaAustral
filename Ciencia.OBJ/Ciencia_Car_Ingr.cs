using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ciencia.OBJ
{
    [PetaPoco.TableName("Ciencia_Car_Ingr")]
    [PetaPoco.PrimaryKey("Ingr_Id", AutoIncrement = false)]

    public class Ciencia_Car_Ingr
    {
        public int Ingr_Id { get; set; }
        public string Ingr_Ctro_D { get; set; }
        public double Ingr_Pac_Id { get; set; }
        public DateTime Ingr_F { get; set; }
        public string Ingr_Diagnostico_D { get; set; }
        public string Ingr_SubDiag_D { get; set; }
        public string Ingr_Sintoma_D { get; set; }
        public string Ingr_DolorPreCord_B { get; set; }                      
        public string Ingr_Disnea_B { get; set; }
        public string Ingr_Sincope_B { get; set; }
        public string Ingr_Palpitac_B { get; set; }
        public string Ingr_Cansancio_B { get; set; }
        public string Ingr_Fiebre_B { get; set; }
        public string Ingr_Cefalea_B { get; set; }
        public string Ingr_Neurolog_B { get; set; }
        public string Ingr_Hematoma_B { get; set; }
        public string Ingr_OtroSintoma_B { get; set; }
        public string Ingr_Derivado_D { get; set; }
        public string Ingr_HTA_D { get; set; }
        public string Ingr_DLP_D { get; set; }
        public string Ingr_TBQ_D { get; set; }
        public string Ingr_DBT_D { get; set; }
        public string Ingr_AHF_B { get; set; }
        public string Ingr_FRCV_B { get; set; }
        public Nullable<short> Ingr_FEVI_N { get; set; }
        public string Ingr_DisfSist_D { get; set; }
        public string Ingr_CF_Habit_D { get; set; }
        public Nullable<short> Ingr_Timi_N { get; set; }
        public Nullable<short> Ingr_Grace_N { get; set; }
        public Nullable<short> Ingr_Crusade_N { get; set; }
        public Nullable<short> Ingr_Estado_N { get; set; }
        public DateTime Ingr_Alta_F { get; set; }
        public string Ingr_Alta_Obito_D { get; set; }

    }
}
