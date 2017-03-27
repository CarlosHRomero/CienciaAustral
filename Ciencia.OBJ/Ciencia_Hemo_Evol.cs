using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ciencia.OBJ
{
    [PetaPoco.TableName("Ciencia_Hemo_Evol")]
    //[PetaPoco.PrimaryKey("Sgmt_Id", AutoIncrement = false)]
    public class Ciencia_Hemo_Evol
    {
        public int Sgmt_Id { get; set; }
        public Nullable<int> Sgmt_Pac_Id { get; set; }
        public Nullable<int> Sgmt_Proc_Id { get; set; }
        public Nullable<int> Sgmt_Usr_Id { get; set; }
        public string Sgmt_Est_A_T { get; set; }
        public Nullable<System.DateTime> Sgmt_A_F { get; set; }
        public string Sgmt_Telefonico_A_B { get; set; }
        public string Sgmt_Obito_A_D { get; set; }
        public string Sgmt_Obito_Tip_A_D { get; set; }
        public Nullable<System.DateTime> Sgmt_Obito_A_F { get; set; }
        public string Sgmt_Reinternac_A_D { get; set; }
        public Nullable<System.DateTime> Sgmt_Reinternac_A_F { get; set; }
        public string Sgmt_Rn_SCA_A_D { get; set; }
        public string Sgmt_Rn_Estable_A_D { get; set; }
        public string Sgmt_Rn_ACV_A_B { get; set; }
        public string Sgmt_Rn_ACVisquem_A_B { get; set; }
        public string Sgmt_Rn_ACVhemorrag_A_B { get; set; }
        public string Sgmt_Rn_ACVinvalidante_A_B { get; set; }
        public string Sgmt_Rn_TIA_A_B { get; set; }
        public string Sgmt_Rn_InsufCardiaca_A_B { get; set; }
        public string Sgmt_Rn_Arritmia_A_B { get; set; }
        public string Sgmt_Rn_ArritmiaFA_A_B { get; set; }
        public string Sgmt_Rn_ArritmiaAA_A_B { get; set; }
        public string Sgmt_Rn_ArritmiaFV_A_B { get; set; }
        public string Sgmt_Rn_ArritmiaTV_A_B { get; set; }
        public string Sgmt_Rn_Acceso_A_B { get; set; }
        public string Sgmt_Rn_AccesoHematoma_A_B { get; set; }
        public string Sgmt_Rn_AccesoLocalizac_A_D { get; set; }
        public string Sgmt_Rn_AccesoTip_A_D { get; set; }
        public string Sgmt_Rn_PseudAnComprMan_A_B { get; set; }
        public string Sgmt_Rn_PseudAnTrombina_A_B { get; set; }
        public string Sgmt_Rn_PseudAnCirugia_A_B { get; set; }
        public string Sgmt_Rn_HematRetroperit_A_B { get; set; }
        public string Sgmt_Rn_IsquemiaMMII_A_B { get; set; }
        public string Sgmt_Reintervencion_A_D { get; set; }
        public Nullable<System.DateTime> Sgmt_Reintervencion_A_F { get; set; }
        public string Sgmt_RV_ATC_A_B { get; set; }
        public string Sgmt_RV_ATC_Localiz_A_B { get; set; }
        public string Sgmt_RV_ATClocVasoTratado_A_B { get; set; }
        public string Sgmt_RV_ATClocLesionTratada_A_B { get; set; }
        public string Sgmt_RV_ATClocVasoNoTratado_A_B { get; set; }
        public string Sgmt_RV_ATC_Mecanismo_A_B { get; set; }
        public string Sgmt_RV_ATCrestenosisBMS_A_B { get; set; }
        public string Sgmt_RV_ATCrestenosisPOBA_A_B { get; set; }
        public string Sgmt_RV_ATCrestenosisDES_A_B { get; set; }
        public string Sgmt_RV_ATCrestenosisDEB_A_B { get; set; }
        public string Sgmt_RV_ATCtrombosPosible_A_B { get; set; }
        public string Sgmt_RV_ATCtrombosProbable_A_B { get; set; }
        public string Sgmt_RV_ATCtrombosDefinida_A_B { get; set; }
        public string Sgmt_RV_ATCtrombosSubAguda_A_B { get; set; }
        public string Sgmt_RV_ATCtrombosTardia_A_B { get; set; }
        public string Sgmt_RV_ATCtrombosMuyTardia_A_B { get; set; }
        public string Sgmt_RV_ATC_Tratamiento_A_B { get; set; }
        public string Sgmt_RV_ATCtratamBMS_A_B { get; set; }
        public string Sgmt_RV_ATCtratamPOBA_A_B { get; set; }
        public string Sgmt_RV_ATCtratamDES_A_B { get; set; }
        public string Sgmt_RV_ATCtratamDEB_A_B { get; set; }
        public string Sgmt_RV_ATP_A_B { get; set; }
        public string Sgmt_RV_ATP_Localiz_A_B { get; set; }
        public string Sgmt_RV_ATPlocVasoTratado_A_B { get; set; }
        public string Sgmt_RV_ATPlocLesionTratada_A_B { get; set; }
        public string Sgmt_RV_ATPlocVasoNoTratado_A_B { get; set; }
        public string Sgmt_RV_ATP_Mecanismo_A_B { get; set; }
        public string Sgmt_RV_ATPrestenosisBMS_A_B { get; set; }
        public string Sgmt_RV_ATPrestenosisPOBA_A_B { get; set; }
        public string Sgmt_RV_ATPrestenosisDES_A_B { get; set; }
        public string Sgmt_RV_ATPrestenosisDEB_A_B { get; set; }
        public string Sgmt_RV_ATPtrombosPosible_A_B { get; set; }
        public string Sgmt_RV_ATPtrombosProbable_A_B { get; set; }
        public string Sgmt_RV_ATPtrombosDefinida_A_B { get; set; }
        public string Sgmt_RV_ATPtrombosSubAguda_A_B { get; set; }
        public string Sgmt_RV_ATPtrombosTardia_A_B { get; set; }
        public string Sgmt_RV_ATPtrombosMuyTardia_A_B { get; set; }
        public string Sgmt_RV_ATP_Tratamiento_A_B { get; set; }
        public string Sgmt_RV_ATPtratamBMS_A_B { get; set; }
        public string Sgmt_RV_ATPtratamPOBA_A_B { get; set; }
        public string Sgmt_RV_ATPtratamDES_A_B { get; set; }
        public string Sgmt_RV_ATPtratamDEB_A_B { get; set; }
        public string Sgmt_RV_Cirugia_A_B { get; set; }
        public string Sgmt_RV_CirugiaCRM_A_B { get; set; }
        public string Sgmt_RV_CirugiaAmputac_A_B { get; set; }
        public string Sgmt_RV_CirugiaByPassPerif_A_B { get; set; }
        public string Sgmt_RV_CirugiaValvular_A_B { get; set; }
        public string Sgmt_Asintomatico_A_D { get; set; }
        public Nullable<System.DateTime> Sgmt_Asintomatico_A_F { get; set; }
        public string Sgmt_AsintomaticoAngina_A_D { get; set; }
        public string Sgmt_AsintomaticoDisnea_A_D { get; set; }
        public string Sgmt_AsintomaticoClaudInterm_A_D { get; set; }
        public string Sgmt_Sangrado_A_D { get; set; }
        public string Sgmt_SangradoTip_A_D { get; set; }
        public string Sgmt_SangradoLocaliz_A_D { get; set; }
        public string Sgmt_Antiagregante_A_D { get; set; }
        public Nullable<System.DateTime> Sgmt_AntiagrSuspenc_A_F { get; set; }
        public string Sgmt_AntiagrTip_A_D { get; set; }
        public string Sgmt_Pseudoaneurisma_A_B { get; set; }
        public string Sgmt_RV_ATCmecanRestenosis_A_B { get; set; }
        public string Sgmt_RV_ATCmecanTrombosis_A_B { get; set; }
        public string Sgmt_RV_ATPmecanRestenosis_A_B { get; set; }
        public string Sgmt_RV_ATPmecanTrombosis_A_B { get; set; }
        public string Sgmt_Eco_ETT_A_B { get; set; }
        public string Sgmt_Eco_ETE_A_B { get; set; }
        public Nullable<int> Sgmt_Eco_DDVI_A_N { get; set; }
        public Nullable<int> Sgmt_Eco_DSVI_A_N { get; set; }
        public Nullable<int> Sgmt_Eco_SIV_A_N { get; set; }
        public Nullable<int> Sgmt_Eco_PP_A_N { get; set; }
        public Nullable<int> Sgmt_Eco_PSAP_A_N { get; set; }
        public Nullable<int> Sgmt_Eco_FEY_A_N { get; set; }
        public Nullable<int> Sgmt_Eco_AVA_Ao_A_N { get; set; }
        public Nullable<int> Sgmt_Eco_GradMax_Ao_A_N { get; set; }
        public Nullable<int> Sgmt_Eco_GradMed_Ao_A_N { get; set; }
        public Nullable<int> Sgmt_Eco_AVA_Mi_A_N { get; set; }
        public Nullable<int> Sgmt_Eco_GradMax_M_A_N { get; set; }
        public Nullable<int> Sgmt_Eco_GradMed_M_A_N { get; set; }
        public string Sgmt_Eco_InsuficAo_A_D { get; set; }
        public string Sgmt_Eco_InsuficMi_A_D { get; set; }
        public string Sgmt_Eco_InsuficTri_A_D { get; set; }
        public string Sgmt_Eco_EstenosisAo_A_D { get; set; }
        public string Sgmt_Eco_EstenosisMi_A_D { get; set; }
        public Nullable<int> Sgmt_Eco_DiamMenor_A_N { get; set; }
        public Nullable<int> Sgmt_Eco_DiamMayor_A_N { get; set; }
        public Nullable<int> Sgmt_Eco_PromedDiam_A_N { get; set; }
        public Nullable<int> Sgmt_Eco_Area_A_N { get; set; }
        public Nullable<int> Sgmt_Eco_Perimetro_A_N { get; set; }
        public string Sgmt_Eco_Calcificac_A_D { get; set; }
        public string Sgmt_Eco_ValvulaTip_A_D { get; set; }

    }
}
