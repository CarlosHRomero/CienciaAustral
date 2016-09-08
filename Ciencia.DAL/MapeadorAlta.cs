using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generales;

namespace Ciencia.DAL
{
    public class MapeadorAlta
    {
        //public Boolean MapearAlta()
        //{
        //    try
        //    {

        //        string query = "Delete from Ciencia_Car_Alta";
        //        TDatos.ExecuteQuery(query, CommandType.Text);
        //        query = "INSERT INTO Ciencia_Car_Alta (Alta_Id, Alta_Ctro_D, Alta_Pac_Id, Alta_Ingr_Id, Alta_F, Alta_Obito_D) "+
        //        "(SELECT Alta_Id, "+
        //        "CASE WHEN Alta_Ctro_D = 2 THEN 'ICBA' ELSE 'f/d' END AS ALTA_CTRO, "+
        //        "Alta_Pac_Id, Alta_Ingr_Id, Alta_F, "+
        //        "CASE WHEN Alta_Obito_D = 3 THEN 'Si' ELSE 'No' END AS OBITO "+
        //        "FROM CAR_ALTA)";
        //    TDatos.ExecuteQuery(query, CommandType.Text);
        //        query = "insert into Ciencia_Car_Alta (Alta_Ctro_D, Alta_Pac_Id, Alta_Ingr_Id, Alta_Obito_D) " +
        //                "select 'ICBA', Ingr_Pac_Id, Ingr_Id, 'No' " +
        //                "from Car_Ingr_New where not exists " +
        //                "(select * from ciencia_Car_Alta " +
        //                "where Car_Ingr_New.Ingr_Id = ciencia_Car_Alta.Alta_Ingr_Id) ";
        //        TDatos.ExecuteQuery(query, CommandType.Text);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        Utiles.WriteErrorLog("En MapeadorAlta: "+ ex.Message);
        //        return false;
        //    }
        //}
    }
}
