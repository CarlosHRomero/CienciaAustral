using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetaPoco;
using Ciencia.OBJ;
using Generales;

namespace Ciencia.DAL
{
    
    public class CienciaHemoEvolManager
    {
        private PetaPoco.Database _db = new PetaPoco.Database("ICBA.Properties.Settings.conStrCiencia");

        public List<Ciencia_Hemo_Evol> SeleccionarPorPaciente(int pacId)
        {
            string where = string.Format("sgmt_pac_id = {0}", pacId.ToString());
            return (Seleccionar(where));
        }

        public List<Ciencia_Hemo_Evol> Seleccionar(string Where= null, string OrderBy = null)
        {
            List<Ciencia_Hemo_Evol> lista;
            try
            {

                var sql = PetaPoco.Sql.Builder.Append("");

                if (!String.IsNullOrEmpty(Where))
                {
                    sql.Where(Where);
                }
                if (!String.IsNullOrEmpty(OrderBy))
                {
                    sql.OrderBy(OrderBy);
                }
                lista = _db.Fetch<Ciencia_Hemo_Evol>(sql);
            }
            catch (Exception ex)
            {
                Utiles.WriteErrorLog("Error en CienciaHemoEvolManager.Seleccionar " + ex.Message);
                lista = null;
            }
            return lista;
        }
    }
}
