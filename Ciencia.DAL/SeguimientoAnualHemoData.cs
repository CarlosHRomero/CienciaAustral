using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generales;

namespace Ciencia.DAL
{
    public class SeguimientoAnualHemoData
    {
        private TDatos _tdatosCiencia;
        public SeguimientoAnualHemoData()
        {
            _tdatosCiencia = new TDatos("ICBA.Properties.Settings.conStrCiencia");
        }
        public bool CrearTabla()
        {
            return true;
        }

        public bool InsertarPacientes(string where)
        {
            try
            {
                string query = "insert into SeguimientoAnualHemodinamia(PacId, Pac_ApeNom) " +
                    "select distinct e.Sgmt_pac_id, Pac_apeNo from " +
                    "Ciencia_Hemo_Evol as e inner join Ciencia_Hemo as c " +
                    "on e.Sgmt_Pac_Id = Pac_Id";
                _tdatosCiencia.ExecuteCmd(query, System.Data.CommandType.Text);
                return true;
            }
            catch(Exception ex)
            {
                Utiles.WriteErrorLog(ex.Message);
                return false;
            }
        }

        public bool ActualizarCampoReinterSiNoFecha()
        {
            try
            {
                string query = "update SeguimientoAnualHemodinamia " +
                    "set Reint_SiNo = Sgmt_Reinternac_A_D, " +
                    "Reint_Fecha= Sgmt_Reinternac_A_F " +
                    "from (select Sgmt_Reinternac_A_D, sgmt_pac_id, Sgmt_Reinternac_A_F, sgmt_a_f, ROW_NUMBER() over(partition by sgmt_pac_id order by  sgmt_a_f desc ) as seq " +
                    "from Ciencia_Hemo_Evol " + "where Sgmt_Reinternac_A_D= 'Si') as subquery " +
                    "inner join SeguimientoAnualHemodinamia on Sgmt_Pac_Id = pacid " + "where subquery.seq = 1";
                _tdatosCiencia.ExecuteCmd(query, System.Data.CommandType.Text);
                return true;

            }
            catch(Exception ex)
            {
                Utiles.WriteErrorLog(ex.Message);
                return false;
            }
        }

        public bool ActualizarCampoReinterCausa()
        {
            return true;
        }
    }
}
