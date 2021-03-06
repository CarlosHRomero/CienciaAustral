using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ciencia.OBJ
{
    [PetaPoco.PrimaryKey("Evol_Id_1")]
    public partial class Car_evol_1
    {
        public int Evol_Id_1 { get; set; }
        public Nullable<double> Evol_Pac_Id_1 { get; set; }
        public Nullable<int> Evol_Ingr_Id_1 { get; set; }
        //public Nullable<System.DateTime> Evol_F { get; set; }
        public string Evol_Obs_1 { get; set; }
        //public Nullable<short> Evol_Usr_Id_1 { get; set; }
        public string Evol_Memo_1 { get; set; }
                public string Evol_Cama_T_1 { get; set; }
        public Nullable<System.DateTime> Evol_Cama_H_1 { get; set; }
        public Nullable<short> Evol_Grpo_D_1 { get; set; }
        public Nullable<short> Evol_Diag_D_1 { get; set; }
        public Nullable<short> Evol_Timi_N_1 { get; set; }
        public Nullable<short> Evol_Grace_N_1 { get; set; }
        public Nullable<short> Evol_Crusade_N_1 { get; set; }
        public Nullable<short> Evol_Asint_D_1 { get; set; }
        public Nullable<short> Evol_TA_N_1 { get; set; }
        public Nullable<short> Evol_TAc_N_1 { get; set; }
        public Nullable<short> Evol_FC_N_1 { get; set; }
        public Nullable<short> Evol_FR_N_1 { get; set; }
        public Nullable<short> Evol_I_N_1 { get; set; }
        public Nullable<short> Evol_E_N_1 { get; set; }
        public Nullable<int> Evol_IE_N_1 { get; set; }
        public Nullable<short> Evol_Sang_N_1 { get; set; }
        public string Evol_Objetivo_T_1 { get; set; }
        public Nullable<short> Evol_ECG_D_1 { get; set; }
        public Nullable<short> Evol_ExF_D_1 { get; set; }
        public Nullable<bool> Evol_Isq_B_1 { get; set; }
        public Nullable<bool> Evol_Isq_InfartoConSST_B_1 { get; set; }
        public Nullable<bool> Evol_Isq_InfartoSinSST_B_1 { get; set; }
        public Nullable<bool> Evol_Isq_AnginaInestable_B_1 { get; set; }
        public Nullable<bool> Evol_Isq_DiseccCoronaria_B_1 { get; set; }
        public Nullable<bool> Evol_Isq_NoReflowCoronario_B_1 { get; set; }
        public Nullable<bool> Evol_Isq_EmbolizacCoronaria_B_1 { get; set; }
        public Nullable<bool> Evol_Isq_AnginaSecundaria_B_1 { get; set; }
        public Nullable<bool> Evol_Isq_InfartoSecundario_B_1 { get; set; }
        public Nullable<bool> Evol_Isq_TrobosisStent_B_1 { get; set; }
        public Nullable<bool> Evol_Isq_VasoespasmoCoro_B_1 { get; set; }
        public Nullable<bool> Evol_Isq_Otras_B_1 { get; set; }
        public Nullable<bool> Evol_Ins_B_1 { get; set; }
        public Nullable<bool> Evol_Ins_InsufCardiologica_B_1 { get; set; }
        public Nullable<bool> Evol_Ins_HipertensPulmonar_B_1 { get; set; }
        public Nullable<bool> Evol_Ins_EdemaAgudoPulmon_B_1 { get; set; }
        public Nullable<bool> Evol_Ins_BajoGastoCardiaco_B_1 { get; set; }
        public Nullable<bool> Evol_Ins_FallaVD_B_1 { get; set; }
        public Nullable<bool> Evol_Ins_Otras_B_1 { get; set; }
        public Nullable<bool> Evol_Hem_B_1 { get; set; }
        public Nullable<bool> Evol_Hem_HipertensArterial_B_1 { get; set; }
        public Nullable<bool> Evol_Hem_HipotensArterial_B_1 { get; set; }
        public Nullable<bool> Evol_Hem_ShockCadiogenico_B_1 { get; set; }
        public Nullable<bool> Evol_Hem_ShockSeptico_B_1 { get; set; }
        public Nullable<bool> Evol_Hem_ShockHipovolemico_B_1 { get; set; }
        public Nullable<bool> Evol_Hem_Ortostatismo_B_1 { get; set; }
        public Nullable<bool> Evol_Hem_Vasoplejia_B_1 { get; set; }
        public Nullable<bool> Evol_Hem_FallaMultiorganica_B_1 { get; set; }
        public Nullable<bool> Evol_Hem_Hipovolemia_B_1 { get; set; }
        public Nullable<bool> Evol_Hem_Otras_B_1 { get; set; }
        public Nullable<bool> Evol_PQx_B_1 { get; set; }
        public Nullable<bool> Evol_PQx_SangradoMedico_B_1 { get; set; }
        public Nullable<bool> Evol_PQx_SangradoQx_B_1 { get; set; }
        public Nullable<bool> Evol_PQx_RoturaEsternal_B_1 { get; set; }
        public Nullable<bool> Evol_PQx_Hemotorax_B_1 { get; set; }
        public Nullable<bool> Evol_PQx_Taponamiento_B_1 { get; set; }
        public Nullable<bool> Evol_PQx_DehicencValvular_B_1 { get; set; }
        public Nullable<bool> Evol_PQx_ObstrucionSubAo_B_1 { get; set; }
        public Nullable<bool> Evol_PQx_ObstruccByPass_B_1 { get; set; }
        public Nullable<bool> Evol_PQx_ReopNoSangrado_B_1 { get; set; }
        public Nullable<bool> Evol_PQx_Otras_B_1 { get; set; }
        public Nullable<bool> Evol_Arritmias_B_1 { get; set; }
        public Nullable<bool> Evol_Sup_B_1 { get; set; }
        public Nullable<bool> Evol_Sup_FibrilacAuricular_B_1 { get; set; }
        public Nullable<bool> Evol_Sup_AleteoAuricular_B_1 { get; set; }
        public Nullable<bool> Evol_Sup_TPS_B_1 { get; set; }
        public Nullable<bool> Evol_Sup_TaquicardAuricular_B_1 { get; set; }
        public Nullable<bool> Evol_Sup_ExtrasistoliaAuricular_B_1 { get; set; }
        public Nullable<bool> Evol_Sup_TaquicardiaSinusal_B_1 { get; set; }
        public Nullable<bool> Evol_Sup_RitmoNodalActivo_B_1 { get; set; }
        public Nullable<bool> Evol_Sup_Otras_B_1 { get; set; }
        public Nullable<bool> Evol_Ven_B_1 { get; set; }
        public Nullable<bool> Evol_Ven_TaqVentricSostenida_B_1 { get; set; }
        public Nullable<bool> Evol_Ven_TaqVentricNoSosten_B_1 { get; set; }
        public Nullable<bool> Evol_Ven_FibrilacVentricular_B_1 { get; set; }
        public Nullable<bool> Evol_Ven_RIVA_B_1 { get; set; }
        public Nullable<bool> Evol_Ven_ExtrasistVentricular_B_1 { get; set; }
        public Nullable<bool> Evol_Ven_Otras_B_1 { get; set; }
        public Nullable<bool> Evol_Bra_B_1 { get; set; }
        public Nullable<bool> Evol_Bra_BCRI_B_1 { get; set; }
        public Nullable<bool> Evol_Bra_BCRD_B_1 { get; set; }
        public Nullable<bool> Evol_Bra_HBAI_B_1 { get; set; }
        public Nullable<bool> Evol_Bra_BAV1erGrado_B_1 { get; set; }
        public Nullable<bool> Evol_Bra_BAV2GradoMobitzI_B_1 { get; set; }
        public Nullable<bool> Evol_Bra_BAV2GradoMobitzII_B_1 { get; set; }
        public Nullable<bool> Evol_Bra_BAV3erGrado_B_1 { get; set; }
        public Nullable<bool> Evol_Bra_BAV2_1_B_1 { get; set; }
        public Nullable<bool> Evol_Bra_BradicardiaSinusal_B_1 { get; set; }
        public Nullable<bool> Evol_Bra_Otras_B_1 { get; set; }
        public Nullable<bool> Evol_PCa_B_1 { get; set; }
        public Nullable<bool> Evol_PCa_Asistolia_B_1 { get; set; }
        public Nullable<bool> Evol_PCa_AESP_B_1 { get; set; }
        public Nullable<bool> Evol_PCa_FV_TVsinPulso_B_1 { get; set; }
        public Nullable<bool> Evol_PCa_Otros_B_1 { get; set; }
        public Nullable<bool> Evol_Val_B_1 { get; set; }
        public Nullable<bool> Evol_Val_InsufMiAguda_B_1 { get; set; }
        public Nullable<bool> Evol_Val_InsufTrAguda_B_1 { get; set; }
        public Nullable<bool> Evol_Val_InsufAoAguda_B_1 { get; set; }
        public Nullable<bool> Evol_Val_Otras_B_1 { get; set; }
        public Nullable<bool> Evol_Mec_B_1 { get; set; }
        public Nullable<bool> Evol_Mec_CIV_B_1 { get; set; }
        public Nullable<bool> Evol_Mec_RoturaParedLibreVI_B_1 { get; set; }
        public Nullable<bool> Evol_Mec_TaponamNoPostQx_B_1 { get; set; }
        public Nullable<bool> Evol_Mec_RoturaCordalMI_B_1 { get; set; }
        public Nullable<bool> Evol_Mec_Otras_B_1 { get; set; }
        public Nullable<bool> Evol_Per_B_1 { get; set; }
        public Nullable<bool> Evol_Per_SindromeDressler_B_1 { get; set; }
        public Nullable<bool> Evol_Per_Pericarditis_B_1 { get; set; }
        public Nullable<bool> Evol_Per_PericardConstructiva_B_1 { get; set; }
        public Nullable<bool> Evol_Per_DerramePericardTapon_B_1 { get; set; }
        public Nullable<bool> Evol_Per_Taponamiento_B_1 { get; set; }
        public Nullable<bool> Evol_Per_Otras_B_1 { get; set; }
        public Nullable<bool> Evol_VPe_B_1 { get; set; }
        public Nullable<bool> Evol_VPe_DiseccionAo_B_1 { get; set; }
        public Nullable<bool> Evol_VPe_RoturaAoTorac_B_1 { get; set; }
        public Nullable<bool> Evol_VPe_RoturaAoAbdom_B_1 { get; set; }
        public Nullable<bool> Evol_VPe_HematoIntramural_B_1 { get; set; }
        public Nullable<bool> Evol_VPe_IsquemiaAgMMII_B_1 { get; set; }
        public Nullable<bool> Evol_VPe_OclusByPassMMII_B_1 { get; set; }
        public Nullable<bool> Evol_VPe_OclusStentMMII_B_1 { get; set; }
        public Nullable<bool> Evol_VPe_AmputacionMMII_B_1 { get; set; }
        public Nullable<bool> Evol_VPe_SangrExtAccesoQx_B_1 { get; set; }
        public Nullable<bool> Evol_VPe_HematAccesoQx_B_1 { get; set; }
        public Nullable<bool> Evol_VPe_Pseudoaneurisma_B_1 { get; set; }
        public Nullable<bool> Evol_VPe_Otras_B_1 { get; set; }
        public Nullable<bool> Evol_Inf_B_1 { get; set; }
        public Nullable<bool> Evol_Inf_EndocarditisProtesica_B_1 { get; set; }
        public Nullable<bool> Evol_Inf_EndocardNativaTricu_B_1 { get; set; }
        public Nullable<bool> Evol_Inf_EndocardNativaAO_B_1 { get; set; }
        public Nullable<bool> Evol_Inf_EndocardNativaMI_B_1 { get; set; }
        public Nullable<bool> Evol_Inf_Mediastinitis_B_1 { get; set; }
        public Nullable<bool> Evol_Inf_InfecBypassPerif_B_1 { get; set; }
        public Nullable<bool> Evol_Inf_Otras_B_1 { get; set; }
        public Nullable<bool> Evol_TnC_B_1 { get; set; }
        public Nullable<bool> Evol_TnC_TrombosVenosaMMII_B_1 { get; set; }
        public Nullable<bool> Evol_TnC_TrombosVenosaMMSS_B_1 { get; set; }
        public Nullable<bool> Evol_TnC_TrombosisPulmonar_B_1 { get; set; }
        public Nullable<bool> Evol_TnC_TrombosTerritArterial_B_1 { get; set; }
        public Nullable<bool> Evol_TnC_TrombosTerritVenoso_B_1 { get; set; }
        public Nullable<bool> Evol_TnC_TromboIntraVentrIzq_B_1 { get; set; }
        public Nullable<bool> Evol_TnC_TromboOrejuelaIzq_B_1 { get; set; }
        public Nullable<bool> Evol_TnC_Tromboflebitis_B_1 { get; set; }
        public Nullable<bool> Evol_TnC_Otras_B_1 { get; set; }
        public Nullable<bool> Evol_Ifc_B_1 { get; set; }
        public Nullable<bool> Evol_Ifc_Neumonia_B_1 { get; set; }
        public Nullable<bool> Evol_Ifc_NeumoniaARM_B_1 { get; set; }
        public Nullable<bool> Evol_Ifc_FiebreNoFiliada_B_1 { get; set; }
        public Nullable<bool> Evol_Ifc_InfecAsocCateter_B_1 { get; set; }
        public Nullable<bool> Evol_Ifc_InfecUrinaria_B_1 { get; set; }
        public Nullable<bool> Evol_Ifc_HC_B_1 { get; set; }
        public Nullable<bool> Evol_Ifc_UC_B_1 { get; set; }
        public Nullable<bool> Evol_Ifc_Retrocultivo_B_1 { get; set; }
        public Nullable<bool> Evol_Ifc_PuntaCateter_B_1 { get; set; }
        public Nullable<bool> Evol_Ifc_PuncSubxifoidea_B_1 { get; set; }
        public Nullable<bool> Evol_Ifc_Otras_B_1 { get; set; }
        public string Evol_Ifc_T_1 { get; set; }
        public Nullable<bool> Evol_Rsp_B_1 { get; set; }
        public Nullable<bool> Evol_Rsp_ReduccVolumPulm_B_1 { get; set; }
        public Nullable<bool> Evol_Rsp_DistressRespirat_B_1 { get; set; }
        public Nullable<bool> Evol_Rsp_Trali_B_1 { get; set; }
        public Nullable<bool> Evol_Rsp_Atelectasia_B_1 { get; set; }
        public Nullable<bool> Evol_Rsp_Neumotorax_B_1 { get; set; }
        public Nullable<bool> Evol_Rsp_DerrPeuralModSev_B_1 { get; set; }
        public Nullable<bool> Evol_Rsp_InsufRespNoEspecif_B_1 { get; set; }
        public Nullable<bool> Evol_Rsp_Otras_B_1 { get; set; }
        public Nullable<bool> Evol_Nef_B_1 { get; set; }
        public Nullable<bool> Evol_Nef_InsufRenalAgOligur_B_1 { get; set; }
        public Nullable<bool> Evol_Nef_InsufRenalAgNoOligur_B_1 { get; set; }
        public Nullable<bool> Evol_Nef_InsufRenalReagudiz_B_1 { get; set; }
        public Nullable<bool> Evol_Nef_Hematuria_B_1 { get; set; }
        public Nullable<bool> Evol_Nef_Hemodialisis_B_1 { get; set; }
        public Nullable<bool> Evol_Nef_GloboVesical_B_1 { get; set; }
        public Nullable<bool> Evol_Nef_Otras_B_1 { get; set; }
        public Nullable<bool> Evol_MeI_B_1 { get; set; }
        public Nullable<bool> Evol_MeI_AcidosRespirator_B_1 { get; set; }
        public Nullable<bool> Evol_MeI_AcidosMetabolica_B_1 { get; set; }
        public Nullable<bool> Evol_MeI_AlcalosisRepirator_B_1 { get; set; }
        public Nullable<bool> Evol_MeI_AlcalosisMetabolica_B_1 { get; set; }
        public Nullable<bool> Evol_MeI_Hiperkalemia_B_1 { get; set; }
        public Nullable<bool> Evol_MeI_Hipokalemia_B_1 { get; set; }
        public Nullable<bool> Evol_MeI_Hipercalcemia_B_1 { get; set; }
        public Nullable<bool> Evol_MeI_Hipocalcemia_B_1 { get; set; }
        public Nullable<bool> Evol_MeI_Hipomagnesemia_B_1 { get; set; }
        public Nullable<bool> Evol_MeI_Hipernatremia_B_1 { get; set; }
        public Nullable<bool> Evol_MeI_Hiponatremia_B_1 { get; set; }
        public Nullable<bool> Evol_MeI_Hiperglucemia_B_1 { get; set; }
        public Nullable<bool> Evol_MeI_Hipoglucemia_B_1 { get; set; }
        public Nullable<bool> Evol_MeI_Otras_B_1 { get; set; }
        public Nullable<bool> Evol_Hematologico_B_1 { get; set; }
        public Nullable<bool> Evol_Hmt_B_1 { get; set; }
        public Nullable<bool> Evol_Hmt_TrombocitopInduc_B_1 { get; set; }
        public Nullable<bool> Evol_Hmt_Plaquetopenia_B_1 { get; set; }
        public Nullable<bool> Evol_Hmt_AnemiaConTransf_B_1 { get; set; }
        public Nullable<bool> Evol_Hmt_AnemiaSinTransf_B_1 { get; set; }
        public Nullable<bool> Evol_Hmt_CoagulopConSangr_B_1 { get; set; }
        public Nullable<bool> Evol_Hmt_CoagulopSinSangr_B_1 { get; set; }
        public Nullable<bool> Evol_Hmt_Leucopenia_B_1 { get; set; }
        public Nullable<bool> Evol_Hmt_Neutropenia_B_1 { get; set; }
        public Nullable<bool> Evol_Hmt_Otras_B_1 { get; set; }
        public Nullable<bool> Evol_Sng_B_1 { get; set; }
        public Nullable<bool> Evol_Sng_SangradoMayor_B_1 { get; set; }
        public Nullable<bool> Evol_Sng_SangradoMenor_B_1 { get; set; }
        public Nullable<bool> Evol_Sng_Otros_B_1 { get; set; }
        public Nullable<bool> Evol_Hmd_B_1 { get; set; }
        public Nullable<bool> Evol_Hmd_TransfGR_B_1 { get; set; }
        public Nullable<bool> Evol_Hmd_TransfPFC_B_1 { get; set; }
        public Nullable<bool> Evol_Hmd_TransfPlaq_B_1 { get; set; }
        public Nullable<bool> Evol_Hmd_Fibrinogeno_B_1 { get; set; }
        public Nullable<bool> Evol_Hmd_TransfCrioprecipit_B_1 { get; set; }
        public Nullable<bool> Evol_Hmd_Otros_B_1 { get; set; }
        public Nullable<bool> Evol_Nrl_B_1 { get; set; }
        public Nullable<bool> Evol_Nrl_ACVisquemico_B_1 { get; set; }
        public Nullable<bool> Evol_Nrl_HemorragIntracran_B_1 { get; set; }
        public Nullable<bool> Evol_Nrl_AIT_B_1 { get; set; }
        public Nullable<bool> Evol_Nrl_ExitacPsicomotriz_B_1 { get; set; }
        public Nullable<bool> Evol_Nrl_DeterioroSensorio_B_1 { get; set; }
        public Nullable<bool> Evol_Nrl_Otras_B_1 { get; set; }
        public Nullable<bool> Evol_Gas_B_1 { get; set; }
        public Nullable<bool> Evol_Gas_AbdomenAgudo_B_1 { get; set; }
        public Nullable<bool> Evol_Gas_SangrDigestAlto_B_1 { get; set; }
        public Nullable<bool> Evol_Gas_SangrDigestBajo_B_1 { get; set; }
        public Nullable<bool> Evol_Gas_DisfuncFallaHepat_B_1 { get; set; }
        public Nullable<bool> Evol_Gas_Colestasis_B_1 { get; set; }
        public Nullable<bool> Evol_Gas_Otras_B_1 { get; set; }
        public Nullable<bool> Evol_Mdc_B_1 { get; set; }
        public Nullable<bool> Evol_Mdc_IntoxicacOpioides_B_1 { get; set; }
        public Nullable<bool> Evol_Mdc_Otras_B_1 { get; set; }
        public Nullable<short> Evol_Area_D_1 { get; set; }
        public string Evol_Pase_M_1 { get; set; }
        public string Evol_Info_M_1 { get; set; }
        public Nullable<short> Evol_SangSuma_N_1 { get; set; }
        public Nullable<short> Evol_Peso_N_1 { get; set; }
        public Nullable<short> Evol_PesoDif_N_1 { get; set; }
        public Nullable<decimal> Evol_IE2_N_1 { get; set; }
    }
}
