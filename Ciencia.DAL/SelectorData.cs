using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Generales;

namespace Ciencia.DAL
{
    public class SelectorData
    {

        public int ContarRegistros(string tabla)
        {
            String sql = string.Format("select COUNT(*) from {0}", tabla);
            TDatos data = new TDatos("ICBA.Properties.Settings.ConnStrCiencia");
            int x = Convert.ToInt32(data.GetDataEscalar(sql, CommandType.Text));
            return x;

        }

        public int ContarRegistros(string tabla, string where)
        {
            String sql = string.Format("select COUNT(*) from {0} where {1}", tabla, where);
            TDatos data = new TDatos("ICBA.Properties.Settings.ConnStrCiencia");
            int x = Convert.ToInt32(data.GetDataEscalar(sql, CommandType.Text));
            return x;

        }

        


        
    }
}
