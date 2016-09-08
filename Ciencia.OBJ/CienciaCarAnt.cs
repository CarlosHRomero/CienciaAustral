using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ciencia.OBJ
{
    [PetaPoco.TableName("Ciencia_Car_Ant")]
    [PetaPoco.PrimaryKey("Ant_Id", AutoIncrement = false)]
    public class CienciaCarAnt
    {
        public int Ant_Id { get; set; }
        public string Ant_Ctro_D { get; set; }
        public double Ant_Pac_Id { get; set; }
        public int Ant_Ingr_Id { get; set; }
        public DateTime Ant_F { get; set; }
        public string Ant_Infarto_B { get; set; }
        public Nullable<short> Ant_Cor_Infarto_Año_N { get; set; }
        public string Ant_Cor_Infarto_T { get; set; }
        public string Ant_Cor_Angiopl_B { get; set; }
        public Nullable<short> Ant_Cor_Angiopl_Año_N { get; set; }
        public string Ant_Cor_Angiopl_T { get; set; }
        public string Ant_Cor_CirCard_B { get; set; }
        public Nullable<short> Ant_Cor_CirCard_Año_N { get; set; }
        public string Ant_Cor_CirCard_T { get; set; }
        public string Ant_Cor_AngCron_B { get; set; }
        public string Ant_Cor_AngCron_T { get; set; }
        public string Ant_Cor_IsqSilent_B { get; set; }
        public string Ant_Cor_IsqSilent_T { get; set; }
        public string Ant_Cor_AngioCoro_B { get; set; }
        public Nullable<short> Ant_Cor_AngioCoro_Año_N { get; set; }
        public string Ant_Cor_AngioCoro_T { get; set; }
        public string Ant_Cor_PruebaFunc_B { get; set; }
        public Nullable<short> Ant_Cor_PruebaFunc_Año_N { get; set; }
        public string Ant_Cor_PruebaFunc_T { get; set; }
        public string Ant_Cor_Otro_B { get; set; }
        public string Ant_Cor_Otro_T { get; set; }
        public string Ant_Arr_FA_B { get; set; }
        public string Ant_Arr_FA_Tip_D { get; set; }
        public string Ant_Arr_Aleteo_B { get; set; }
        public string Ant_Arr_TPS_B { get; set; }
        public string Ant_Arr_TV_FV_B { get; set; }
        public string Ant_Arr_ExtrSistol_B { get; set; }
        public string Ant_Arr_ExtrSistol_Tip_D { get; set; }
        public string Ant_Arr_MP_B { get; set; }
        public Nullable<short> Ant_Arr_MP_Año_N { get; set; }
        public string Ant_Arr_Defibril_B { get; set; }
        public string Ant_Arr_Defibril_Tip_D { get; set; }
        public Nullable<short> Ant_Arr_Defibril_Año_N { get; set; }
        public string Ant_Arr_Otra_B { get; set; }
        public string Ant_Car_IntPrev_B { get; set; }
        public Nullable<short> Ant_Car_IntPrev_Tot_N { get; set; }
        public Nullable<short> Ant_Car_IntPrev_Año_N { get; set; }
        public string Ant_Car_FuncSist_D { get; set; }
        public string Ant_Car_HipertPulm_B { get; set; }
        public string Ant_Car_Transpl_B { get; set; }
        public Nullable<short> Ant_Car_Transpl_Año_N { get; set; }
        public string Ant_Car_EtiologPrim_D { get; set; }
        public string Ant_Car_Otro_B { get; set; }
        public Nullable<short> Ant_Val_Ecodopp_Año_N { get; set; }
        public string Ant_Val_EstenAo_B { get; set; }
        public string Ant_Val_EstenAo_Sev_D { get; set; }
        public string Ant_Val_EstenAo_Sev_Tip_D { get; set; }
        public Nullable<short> Ant_Val_EstenAo_GradPico_N { get; set; }
        public Nullable<short> Ant_Val_EstenAo_GradMed_N { get; set; }
        public Nullable<short> Ant_Val_EstenAo_Area_N { get; set; }
        public string Ant_Val_EstenAo_Etiolog_D { get; set; }
        public string Ant_Val_InsufAo_B { get; set; }
        public string Ant_Val_InsufAo_Sev_D { get; set; }
        public string Ant_Val_InsufAo_Sev_Tip_D { get; set; }
        public string Ant_Val_InsufAo_DilatAo_B { get; set; }
        public string Ant_Val_InsufAo_Etiolog_D { get; set; }
        public string Ant_Val_EstenMI_B { get; set; }
        public string Ant_Val_EstenMI_Sev_D { get; set; }
        public string Ant_Val_EstenMI_Sintomatica_B { get; set; }
        public string Ant_Val_EstenMI_Etiolog_D { get; set; }
        public Nullable<short> Ant_Val_EstenMI_GradPico_N { get; set; }
        public Nullable<short> Ant_Val_EstenMI_GradMed_N { get; set; }
        public Nullable<short> Ant_Val_EstenMI_Area_N { get; set; }
        public string Ant_Val_InsufMI_B { get; set; }
        public string Ant_Val_InsufMI_Sev_D { get; set; }
        public string Ant_Val_InsufMI_Sev_Tip_D { get; set; }
        public string Ant_Val_InsufMI_Etiolog_D { get; set; }
        public string Ant_Val_InsufMI_Etiolog_Tip_D { get; set; }
        public string Ant_Val_InsufTr_D { get; set; }
        public string Ant_Val_IntervPerc_B { get; set; }
        public Nullable<short> Ant_Val_IntervPerc_Año_N { get; set; }
        public string Ant_Val_CirugValv_B { get; set; }
        public string Ant_Val_CirugValv_Zona_D { get; set; }
        public string Ant_Val_CirugValv_Zona_Tip_D { get; set; }
        public string Ant_Val_Otro_B { get; set; }
        public string Ant_Vas_Carot_B { get; set; }
        public string Ant_Vas_Carot_Interv_D { get; set; }
        public string Ant_Vas_Carot_Interv_Tip_D { get; set; }
        public string Ant_Vas_MbroInf_B { get; set; }
        public string Ant_Vas_MbroInf_Interv_D { get; set; }
        public string Ant_Vas_MbroInf_Interv_Tip_D { get; set; }
        public string Ant_Vas_Ao_B { get; set; }
        public string Ant_Vas_Ao_Interv_D { get; set; }
        public string Ant_Vas_Ao_Interv_Tip_D { get; set; }
        public string Ant_Vas_Ao_Interv_sTip_D { get; set; }
        public string Ant_Vas_PatologVena_B { get; set; }
        public string Ant_Vas_PatologVena_Interv_D { get; set; }
        public string Ant_Vas_Otra_B { get; set; }
        public string Ant_Pat_CIA_B { get; set; }
        public string Ant_Pat_CIV_B { get; set; }
        public string Ant_Pat_Fallot_B { get; set; }
        public string Ant_Pat_Coartac_B { get; set; }
        public string Ant_Pat_Otras_B { get; set; }
        public string Ant_Pat_MasaIntracard_D { get; set; }
        public string Ant_Pat_HipertPulm_B { get; set; }
        public string Ant_Pat_Pericardiop_D { get; set; }
        public string Ant_Pat_Pericardiop_Tip_D { get; set; }
        public string Ant_Pat_Otro_B { get; set; }
        public string Ant_Otr_Anticoag_B { get; set; }
        public string Ant_Otr_Anticoag_Tip_D { get; set; }
        public string Ant_Otr_Etilismo_B { get; set; }
        public string Ant_Otr_Piel_B { get; set; }
        public string Ant_Otr_Alergia_B { get; set; }
        public string Ant_Otr_Hematolog_B { get; set; }
        public string Ant_Otr_Hematolog_Anemia_B { get; set; }
        public string Ant_Otr_MuscEsquel_B { get; set; }
        public string Ant_Otr_Metabolico_B { get; set; }
        public string Ant_Otr_Metabolico_Hipotiroid_B { get; set; }
        public string Ant_Otr_Infectolog_B { get; set; }
        public string Ant_Otr_Respirat_B { get; set; }
        public string Ant_Otr_Respirat_Asma_B { get; set; }
        public string Ant_Otr_Respirat_EPOC_B { get; set; }
        public string Ant_Otr_IRA_B { get; set; }
        public string Ant_Otr_Gastrointest_B { get; set; }
        public string Ant_Otr_Genitourinar_B { get; set; }
        public string Ant_Otr_Neurolog_B { get; set; }
        public string Ant_Otr_Neurolog_ACV_B { get; set; }
        public string Ant_Otr_Neurolog_Depres_B { get; set; }
        public string Ant_Otr_Traumatolog_B { get; set; }
        public string Ant_Otr_Otro_B { get; set; }
        public string Ant_Vas_TVP_TEP_B { get; set; }
        public string Ant_Vas_Varices_B { get; set; }
        public string Ant_Otr_IRA_D { get; set; }
        public string Ant_Otr_IRA_T { get; set; }
    }

}
