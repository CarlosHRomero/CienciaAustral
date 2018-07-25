using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Ciencia.DAL
{
    public class EvolPrimeraCarData
    {
        public void InsertarNuevosRegistros()
        {
            string query = "insert into car_evol_1 (evol_pac_id_1, evol_ingr_id_1) " +
                            "select distinct Evol_Pac_Id, evol_ingr_id " +
                            "from car_evol_new where not exists(select evol_ingr_id_1 from car_evol_1 "+
                            "where car_evol_1.evol_ingr_id_1= car_evol_new.evol_ingr_id)";
            var data = new TDatos("ICBA.Properties.Settings.conStr");
            data.ExecuteCmd(query, System.Data.CommandType.Text);

            query = "insert into car_evol_u (evol_pac_id_u, evol_ingr_id_u) " +
                            "select distinct Evol_Pac_Id, evol_ingr_id " +
                            "from car_evol_new where not exists(select evol_ingr_id_u from car_evol_u " +
                            "where car_evol_u.evol_ingr_id_u= car_evol_new.evol_ingr_id)";
            //data = new TDatos("ICBA.Properties.Settings.conStr");
            data.ExecuteCmd(query, System.Data.CommandType.Text);

        }

        //public DataTable Leer
    
        public void ActualizarCampo(string campo, int ingrId )
        {
            string query =  string.Format("select {1} from car_evol_new where evol_ingrId = {1} ");
        }
    }
}
