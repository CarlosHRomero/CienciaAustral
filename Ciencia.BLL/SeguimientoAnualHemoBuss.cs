using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ciencia.OBJ;
using Ciencia.DAL;

namespace Ciencia.BLL
{
    public class SeguimientoAnualHemoBuss
    {
        SegAnualHemoMananger man = new SegAnualHemoMananger();

        List<Ciencia_Hemo_Evol> _listaEvolucion;
        public void ProcesarSeguimiento(string where, string nombreArchivo)
        {
            InsertarPacientes(where);
            if (evolMan == null)
                evolMan = new CienciaHemoEvolManager();
            _listaEvolucion = evolMan.Seleccionar();
            ProcesarPacientes(nombreArchivo);
        }

        public bool InsertarPacientes(string where)
        {
            if (man.BorrarTodo())
            {
                return (man.InsertarPacientes(where));
            }
            else
                return false;
        }

        public bool ProcesarPacientes(string nombreArchivo)
        {
            try
            {
                var ListaPacientes = man.Seleccionar().ToList();
                foreach (var pac in ListaPacientes)
                {
                    ProcesarPaciente(pac);
                    //man.Modificar(pac);
                }
                nombreArchivo = nombreArchivo.Replace(".mdb", ".xlsx");
                if (!Generales.ExportadorDatos.ExportaListaAExcel2(ListaPacientes, nombreArchivo, "aaaa"))
                    throw new Exception(string.Format("Error al exportar a Excel. Verifique que el archivo {0} no este abierto", nombreArchivo));
                return true;
            }
            catch (Exception ex)
            {
                throw(ex);
                return false;
            }
        }

        private void ProcesarPaciente(SeguimientoAnualHemodinamia paciente)
        {
            var listaEvol = BuscarEvolPorPaciente(paciente.PacId).ToList();
            ActualizarTipoDeObito(paciente, listaEvol);
            ActualizarReinternacion(paciente, listaEvol);
            ActualizarReintervencion(paciente, listaEvol);
            ActualizarCalidadDeVida(paciente, listaEvol);
            ActualizarFechaUltimoSeguimiento(paciente, listaEvol);
        }

        private void ActualizarTipoDeObito(SeguimientoAnualHemodinamia paciente, List<Ciencia_Hemo_Evol> listaEvol)
        {
            try
            {
                var evolPac = listaEvol.Where(x => x.Sgmt_Obito_A_D.ToLower() == "si").OrderBy(x => x.Sgmt_A_F).FirstOrDefault();
                if (evolPac != null)
                {
                    paciente.Obito_tipo = evolPac.Sgmt_Obito_Tip_A_D;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        private void ActualizarFechaUltimoSeguimiento(SeguimientoAnualHemodinamia paciente, List<Ciencia_Hemo_Evol> listaEvol)
        {
            try
            {
                var evolPac = listaEvol.OrderByDescending(x => x.Sgmt_A_F).FirstOrDefault();
                if (evolPac != null)
                {
                    paciente.Ultimo_Sgmto = evolPac.Sgmt_A_F;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        private List<Ciencia_Hemo_Evol> BuscarEvolPorPaciente(int pacId)
        {
            var evolPac = _listaEvolucion.Where(x => x.Sgmt_Pac_Id == pacId).ToList();
            return evolPac;
        }

        private void ActualizarCalidadDeVida(SeguimientoAnualHemodinamia paciente, List<Ciencia_Hemo_Evol> listaEvolucion)
        {
            try
            {
                var evolPac = listaEvolucion.Where(x => x.Sgmt_Sangrado_A_D.ToLower() == "si").OrderBy(x => x.Sgmt_A_F).FirstOrDefault();
                if (evolPac != null)
                {
                    paciente.Sangr_SiNo = evolPac.Sgmt_Sangrado_A_D;
                    paciente.Sangr_tipo = evolPac.Sgmt_SangradoTip_A_D;
                    paciente.Sangr_Local = evolPac.Sgmt_SangradoLocaliz_A_D;
                }
                evolPac = listaEvolucion.Where(x => x.Sgmt_Reintervencion_A_D.ToLower() == "si").OrderBy(x => x.Sgmt_Reintervencion_A_F).FirstOrDefault();
                if (evolPac != null)
                {
                    paciente.Antiagr_SiNo = evolPac.Sgmt_Antiagregante_A_D;
                    paciente.Antiagr_Tipo = evolPac.Sgmt_AntiagrTip_A_D;
                    paciente.Antiagr_FechaSus = evolPac.Sgmt_AntiagrSuspenc_A_F;
                    return;
                }
                evolPac = listaEvolucion.Where(x => x.Sgmt_Reinternac_A_D.ToLower() == "si").OrderBy(x => x.Sgmt_Reinternac_A_F).FirstOrDefault();
                if (evolPac != null)
                {
                    paciente.Antiagr_SiNo = evolPac.Sgmt_Antiagregante_A_D;
                    paciente.Antiagr_Tipo = evolPac.Sgmt_AntiagrTip_A_D;
                    paciente.Antiagr_FechaSus = evolPac.Sgmt_AntiagrSuspenc_A_F;
                    return;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        private void ActualizarReintervencion(SeguimientoAnualHemodinamia paciente, List<Ciencia_Hemo_Evol> listaEvolucion)
        {
            try
            {
                var evolPac = listaEvolucion.Where(x => x.Sgmt_Reintervencion_A_D.ToLower() == "si").OrderBy(x => x.Sgmt_Reintervencion_A_F).FirstOrDefault();
                if (evolPac != null)
                {
                    paciente.Reinterv_SiNo = evolPac.Sgmt_Reintervencion_A_D;
                    paciente.Reinterv_fecha = evolPac.Sgmt_Reintervencion_A_F;
                    paciente.Reinterv_Localiz = TraerLocalReinterv(evolPac);
                    paciente.Reinterv_Mec_Reste = TraerMecRestenosis(evolPac);
                    paciente.Reinterv_Mec_Trom_ARC = TraerMecTromARC(evolPac);
                    paciente.Reinterv_Mec_Trom_Tiempo = TraerMecTromTiempo(evolPac);
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        private string TraerMecTromTiempo(Ciencia_Hemo_Evol evolPac)
        {
            if (evolPac.Sgmt_RV_ATC_Mecanismo_A_B.ToLower() == "si")
            {
                if (evolPac.Sgmt_RV_ATCmecanTrombosis_A_B.ToLower() == "si")
                {
                    if (evolPac.Sgmt_RV_ATCtrombosSubAguda_A_B.ToLower() == "si")
                        return "Subaguda";
                    if (evolPac.Sgmt_RV_ATCtrombosTardia_A_B.ToLower() == "si")
                        return "Tardía";
                    if (evolPac.Sgmt_RV_ATCtrombosMuyTardia_A_B.ToLower() == "si")
                        return "Muy tardía";
                    return null;
                }
                return null;
            }
            return null;
        }

        private string TraerMecTromARC(Ciencia_Hemo_Evol evolPac)
        {
            if (evolPac.Sgmt_RV_ATC_Mecanismo_A_B.ToLower() == "si")
            {
                if (evolPac.Sgmt_RV_ATCmecanTrombosis_A_B.ToLower() == "si")
                {
                    if (evolPac.Sgmt_RV_ATCtrombosPosible_A_B.ToLower() == "si")
                        return "Posible";
                    if (evolPac.Sgmt_RV_ATCtrombosProbable_A_B.ToLower() == "si")
                        return "Probable";
                    if (evolPac.Sgmt_RV_ATCtrombosDefinida_A_B.ToLower() == "si")
                        return "Definida";
                    return null;
                }
                return null;
            }
            return null;
        }

        private string TraerMecRestenosis(Ciencia_Hemo_Evol evolPac)
        {
            if (evolPac.Sgmt_RV_ATC_Mecanismo_A_B.ToLower() == "si")
            {
                if (evolPac.Sgmt_RV_ATCmecanRestenosis_A_B.ToLower() == "si")
                {
                    if (evolPac.Sgmt_RV_ATCrestenosisBMS_A_B.ToLower() == "si")
                        return "BMS";
                    if (evolPac.Sgmt_RV_ATCrestenosisPOBA_A_B.ToLower() == "si")
                        return "POBA";
                    if (evolPac.Sgmt_RV_ATCrestenosisDES_A_B.ToLower() == "si")
                        return "DES";
                    if (evolPac.Sgmt_RV_ATCrestenosisDEB_A_B.ToLower() == "si")
                        return "DEB";
                    return null;
                }
                return null;
            }
            return null;
        }

        private string TraerLocalReinterv(Ciencia_Hemo_Evol evolPac)
        {
            if (evolPac.Sgmt_RV_ATC_Localiz_A_B.ToLower() == "si")
            {
                if (evolPac.Sgmt_RV_ATClocVasoTratado_A_B.ToLower() == "si")
                    return "Vaso tratado";
                if (evolPac.Sgmt_RV_ATClocLesionTratada_A_B.ToLower() == "si")
                    return "Lesión tratada";
                if (evolPac.Sgmt_RV_ATClocVasoNoTratado_A_B.ToLower() == "si")
                    return "Vaso no tratado";
                return null;
            }
            return null;
        }
        CienciaHemoEvolManager evolMan;
        private void ActualizarReinternacion(SeguimientoAnualHemodinamia paciente, List<Ciencia_Hemo_Evol> listaEvolucion)
        {
            try
            {
                var evolPac = listaEvolucion.Where(x => x.Sgmt_Reinternac_A_D.ToLower() == "si" && x.Sgmt_Reinternac_A_F != null).OrderBy(x => x.Sgmt_Reinternac_A_F).FirstOrDefault();

                //var = lista;
                if (evolPac != null)
                {
                    paciente.Reint_SiNo = evolPac.Sgmt_Reinternac_A_D;
                    paciente.Reint_Fecha = evolPac.Sgmt_Reinternac_A_F;
                    paciente.Reint_Causa = TraerCausaReint(evolPac);
                }
                else
                {
                    evolPac = listaEvolucion.Where(x => x.Sgmt_Reinternac_A_D.ToLower() == "si").OrderBy(x => x.Sgmt_A_F).FirstOrDefault();
                    if (evolPac != null)
                    {
                        paciente.Reint_SiNo = evolPac.Sgmt_Reinternac_A_D;
                        paciente.Reint_Fecha = evolPac.Sgmt_Reinternac_A_F;
                        paciente.Reint_Causa = TraerCausaReint(evolPac);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string TraerCausaReint(Ciencia_Hemo_Evol reint)
        {
            if (!string.IsNullOrEmpty(reint.Sgmt_Rn_SCA_A_D) && reint.Sgmt_Rn_SCA_A_D.ToLower() != "f/d")
            {
                return reint.Sgmt_Rn_SCA_A_D;
            }
            if (!string.IsNullOrEmpty(reint.Sgmt_Rn_Estable_A_D) && reint.Sgmt_Rn_Estable_A_D.ToLower() != "f/d")
            {
                return reint.Sgmt_Rn_Estable_A_D;
            }
            if (reint.Sgmt_Rn_ACV_A_B.ToLower() == "si")
            {
                if (reint.Sgmt_Rn_ACVisquem_A_B.ToLower() == "si")
                    return "ACV - Isquémico";
                if (reint.Sgmt_Rn_ACVhemorrag_A_B.ToLower() == "si")
                    return "ACV - Hemorrágico";
                if (reint.Sgmt_Rn_ACVinvalidante_A_B.ToLower() == "si")
                    return "ACB - Invalidante";
                return "ACV -";
            }

            if (reint.Sgmt_Rn_TIA_A_B == "si")
            {
                return "TIA";
            }
            if (reint.Sgmt_Rn_InsufCardiaca_A_B.ToLower() == "si")
            {
                return ("Insuf. Cardiaca");
            }
            if (reint.Sgmt_Rn_Arritmia_A_B.ToLower() == "si")
            {
                if (reint.Sgmt_Rn_ArritmiaFA_A_B.ToLower() == "si")
                    return "Arritmia - FA";
                if (reint.Sgmt_Rn_ArritmiaAA_A_B.ToLower() == "si")
                    return "Arritmia - AA";
                if (reint.Sgmt_Rn_ArritmiaFV_A_B.ToLower() == "si")
                    return "Arritmia - FV";
                if (reint.Sgmt_Rn_ArritmiaTV_A_B.ToLower() == "si")
                    return "Arritmia - TV";
            }
            return null;
        }
    }
}
