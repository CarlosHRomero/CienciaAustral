using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generales;

namespace Ciencia.DAL
{
    public class MapeadorPacientes
    {
        //public Boolean MapearPacientes()
        //{
        //    try
        //    {

        //        string query = "Delete from Ciencia_Car_Pac";
        //        TDatos.ExecuteQuery(query, CommandType.Text);
        //        query = "INSERT INTO Ciencia_Car_Pac (Pac_Id, Pac_Sexo_D, Pac_Nac_F, Pac_Apellido_Nombre ) " +
        //        "(SELECT Pac_Id, " +
        //        "CASE WHEN Pac_Sexo_D = 2 THEN 'F' ELSE 'M' END AS Pac_Sexo_D, " +
        //        "Pac_Nac_F, Pac_ApeNo " +
        //        "FROM CAR_PAC)";
        //        TDatos.ExecuteQuery(query, CommandType.Text);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        Utiles.WriteErrorLog("En MapeadorAlta: " + ex.Message);
        //        return false;
        //    }
        //}

    }
}
