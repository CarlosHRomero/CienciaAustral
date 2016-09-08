using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ciencia.OBJ
{
    [PetaPoco.TableName("Ciencia_Car_AntC")]
    [PetaPoco.PrimaryKey("AntC_Id", AutoIncrement = false)]

    public class CienciaCarAntC
    {
        public int AntC_Id { get; set; }
        public string AntC_Ctro_D { get; set; }
        public Nullable<double> AntC_Pac_Id { get; set; }
        public Nullable<int> AntC_Ingr_Id { get; set; }
        public DateTime AntC_F { get; set; }
        public string AntC_Pulso_Carot_Izq_D { get; set; }
        public string AntC_Pulso_Carot_Der_D { get; set; }
        public string AntC_Soplo_Carot_Izq_B { get; set; }
        public string AntC_Soplo_Carot_Der_B { get; set; }
        public string AntC_Pulso_Rad_Izq_D { get; set; }
        public string AntC_Pulso_Rad_Der_D { get; set; }
        public string AntC_Pulso_Femor_Izq_D { get; set; }
        public string AntC_Pulso_Femor_Der_D { get; set; }
        public string AntC_Soplo_Femor_Izq_B { get; set; }
        public string AntC_Soplo_Femor_Der_B { get; set; }
        public string AntC_Pulso_Popl_Izq_D { get; set; }
        public string AntC_Pulso_Popl_Der_D { get; set; }
        public string AntC_Pulso_Tibial_Izq_D { get; set; }
        public string AntC_Pulso_Tibial_Der_D { get; set; }
        public string AntC_Auscultac_T { get; set; }
        public string AntC_Pulso_Obs_T { get; set; }
        public string AntC_ECG_Ritmo_D { get; set; }
        public Nullable<short> AntC_FC_N { get; set; }
        public Nullable<short> AntC_PR_N { get; set; }
        public Nullable<short> AntC_AQRS_N { get; set; }
        public string AntC_Hipertrof_B { get; set; }
        public string AntC_Hipertrof_VI_B { get; set; }
        public string AntC_Hipertrof_VD_B { get; set; }
        public string AntC_Hipertrof_AI_B { get; set; }
        public string AntC_Hipertrof_AD_B { get; set; }
        public string AntC_QPatolog_B { get; set; }
        public string AntC_QPatolog_Ant_B { get; set; }
        public string AntC_QPatolog_Inf_B { get; set; }
        public string AntC_QPatolog_lateral_B { get; set; }
        public string AntC_ST_T_D { get; set; }
        public string AntC_Bloqueo_B { get; set; }
        public string AntC_Bloqueo_AV_B { get; set; }
        public string AntC_Bloqueo_BCRI_B { get; set; }
        public string AntC_Bloqueo_BCRD_B { get; set; }
        public string AntC_Bloqueo_HBA_B { get; set; }
        public string AntC_Bloqueo_HBP_B { get; set; }
        public string AntC_Descripcion_T { get; set; }
        public string AntC_Radiografia_T { get; set; }
        public string AntC_Ecocardiograma_T { get; set; }
        public string AntC_Tomografia_T { get; set; }
        public string AntC_Hematocrito_T { get; set; }
        public string AntC_GlobBlanco_T { get; set; }
        public string AntC_Plaqueta_T { get; set; }
        public string AntC_Urea_T { get; set; }
        public string AntC_Creatinina_T { get; set; }
        public string AntC_Sodio_T { get; set; }
        public string AntC_Potasio_T { get; set; }
        public string AntC_Glu_T { get; set; }
        public string AntC_TP_Quick_T { get; set; }
        public string AntC_KPTT_T { get; set; }
        public string AntC_RIN_T { get; set; }
        public string AntC_Tnt_T { get; set; }
        public string AntC_Colest_T { get; set; }
        public string AntC_General_T { get; set; }
        public Nullable<float> AntC_ExF_FC_N { get; set; }
        public Nullable<float> AntC_FR_N { get; set; }
        public Nullable<float> AntC_TA_N { get; set; }
        public Nullable<float> AntC_TAc_N { get; set; }
        public Nullable<float> AntC_Temp_N { get; set; }
        public Nullable<float> AntC_Peso_N { get; set; }
        public Nullable<float> AntC_Altura_N { get; set; }
        public Nullable<float> AntC_SupCorp_N { get; set; }
        public Nullable<float> AntC_IMC_N { get; set; }
        public string AntC_Piel_Edema_B { get; set; }
        public string AntC_Piel_Cianosis_B { get; set; }
        public string AntC_Piel_PerfPerif_B { get; set; }
        public string AntC_Piel_T { get; set; }
        public string AntC_CardV_PuntaDespl_B { get; set; }
        public string AntC_CardV_IngurgYugul_B { get; set; }
        public string AntC_CardV_ReflujHepatY_B { get; set; }
        public string AntC_CardV_Ascultac_R1_B { get; set; }
        public string AntC_CardV_Ascultac_R2_B { get; set; }
        public string AntC_CardV_Ascultac_R3_B { get; set; }
        public string AntC_CardV_Ascultac_R4_B { get; set; }
        public string AntC_CardV_Ascultac_SS_B { get; set; }
        public string AntC_CardV_Ascultac_SD_B { get; set; }
        public string AntC_CardV_T { get; set; }
        public string AntC_Respirat_Rales_B { get; set; }
        public string AntC_Respirat_Sibilanc_B { get; set; }
        public string AntC_Respirat_Hipoventil_D { get; set; }
        public string AntC_Respirat_Der_B { get; set; }
        public string AntC_Respirat_Izq_B { get; set; }
        public string AntC_Respirat_T { get; set; }
        public string AntC_Abdom_Hepatomega_B { get; set; }
        public string AntC_Abdom_Esplenomeg_B { get; set; }
        public string AntC_Abdom_Soplo_B { get; set; }
        public string AntC_Abdom_MasaPulsat_B { get; set; }
        public string AntC_Abdom_T { get; set; }
        public string AntC_Genitourinario_T { get; set; }
        public string AntC_MusculoEsquelet_T { get; set; }
        public string AntC_Neurologico_T { get; set; }
        public string AntC_G_Sang_D { get; set; }
        public string AntC_G_PH_T { get; set; }
        public string AntC_pCO2_T { get; set; }
        public string AntC_pO2_T { get; set; }
        public string AntC_HcO3_T { get; set; }
        public string AntC_sO2_T { get; set; }
        public string AntC_AcLact_T { get; set; }
        public string AntC_TGO_T { get; set; }
        public string AntC_TGP_T { get; set; }
        public string AntC_FAL_T { get; set; }
        public string AntC_Bil_T_T { get; set; }
        public string AntC_Bil_D_T { get; set; }
        public string AntC_Pts_T { get; set; }
        public Nullable<float> AntC_TFG_N { get; set; }
        public string AntC_NT_ProBNP_T { get; set; }
        public string AntC_Lab_T { get; set; }
        public DateTime AntC_Lab_F { get; set; }


    }
}
