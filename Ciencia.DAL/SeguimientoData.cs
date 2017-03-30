using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ciencia.OBJ;
using System.Data;

namespace Ciencia.DAL
{
    public class SeguimientoData
    {
        public DataTable LeerDatosSeguimiento(List<clsCampo>campos, string tablaPrincipal, string tablaEvol, string clavePrincipal, string claveExtEvol, string where)
        {
            string query = "Select ";            
            foreach(clsCampo campo in campos)
            {
                query += string.Format("{0}, ", campo.nombre);
            }
            query = query.Substring(0, query.Length - 2);
            if(!string.IsNullOrEmpty(where))
                query += string.Format(" from {0} inner join {1} on {0}.{2} = {1}.{3} where {4}", tablaPrincipal, tablaEvol, clavePrincipal, claveExtEvol, where);
            else
                query += string.Format(" from {0} inner join {1} on {0}.{2} = {1}.{3} ", tablaPrincipal, tablaEvol, clavePrincipal, claveExtEvol);
            TDatos dataCiencia = new TDatos("ICBA.Properties.Settings.conStrCiencia");
            var dt = dataCiencia.GetDataNonQuery(query);
            return dt;
        }
    }
}
