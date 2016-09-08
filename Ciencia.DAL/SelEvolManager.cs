using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using Ciencia.OBJ;

namespace Ciencia.DAL
{
    public class SelEvolManager
    {
        string _conStr;
        public SelEvolManager(string conStr)
        {
            _conStr = conStr;
        }
        public Boolean insertar(SelTablaEvol obj)
        {
            string lista = obj.listaVal.Aggregate((current, s) => current +  ", " + s );
            string query = string.Format("insert into selEvolucion(EquivID, ListaVal, pri_ult) values ({0}, '{1}', {2})", obj.equivId, lista, Convert.ToInt16(obj.pri_ult));
            TDatosAccess.conStr = _conStr;
            TDatosAccess.ExecuteQuery(query, System.Data.CommandType.Text);
            return true;
        }

        public List <SelTablaEvol> ObtenerporEquivId(int equivId)
        {
            string query = string.Format("SELECT SelEvolucion.EquivId, SelEvolucion.ListaVal, SelEvolucion.pri_ult FROM SelEvolucion where EquivId = {0}", equivId);
            TDatosAccess.conStr = _conStr;
            DataTable dt = TDatosAccess.GetDataNonQuery(query);
            if(dt.Rows.Count == 0)
                return null;
            List<SelTablaEvol> lista = new List<SelTablaEvol>();
            string s;
            foreach(DataRow row in dt.Rows)
            {
                SelTablaEvol obj = new  SelTablaEvol();
                obj.equivId = equivId;
                s = row["ListaVal"].ToString();
                obj.listaVal = s.Split(',').ToList();
                obj.pri_ult = (OrdenSel) Convert.ToInt16(row["pri_ult"])  ;
                lista.Add(obj);
            }
            return lista;
        }


        public bool BorrarTabla()
        {
            string query = "DELETE * FROM SelEvolucion";
            TDatosAccess.conStr = _conStr;
            TDatosAccess.ExecuteQuery(query, CommandType.Text);
            return true;
        }
    }
}
