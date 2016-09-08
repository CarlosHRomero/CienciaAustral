using Ciencia.OBJ;
using Generales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ciencia.DAL
{
    public class TablaEquivModuloManager
    {
        private static PetaPoco.Database db = new PetaPoco.Database("ICBA.Properties.Settings.ConnStr");
        public static List<clsEquiv> Seleccionar(string where, string OrderBy, string from)
        {
            try
            {
                List<clsEquiv> lista;
                var sql = PetaPoco.Sql.Builder
                    .Append("SELECT [Eqv_Val], [Eqv_Desc], [Eqv_Continua], [Eqv_Tit] FROM " + from);
                if (!string.IsNullOrEmpty(where))
                    sql.Where(where);
                if (!string.IsNullOrEmpty(OrderBy))
                    sql.OrderBy(OrderBy);
                lista = db.Fetch<clsEquiv>(sql);
                return lista;
            }
            catch (Exception ex)
            {
                Utiles.WriteErrorLog(ex.Message);
                return null;
            }
        }
    }
}
