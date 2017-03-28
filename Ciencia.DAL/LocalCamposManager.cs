using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using Ciencia.OBJ;

namespace Ciencia.DAL
{
    public class LocalCamposManager
    {
        public string conStr {get; set;}




        public LocalCamposManager( string con)
        {
            conStr = con;
        }




        public Boolean BorrarCamposEvolucion()
        {
            string query = "DELETE * FROM CAMPOS WHERE ESEVOL <> 0 ";
            TDatosAccess.conStr = conStr;
            TDatosAccess.ExecuteQuery(query, CommandType.Text);
            return true;
        }

        public Boolean BorrarCamposSeleccion()
        {
            string query = "DELETE * FROM CAMPOS WHERE ESEVOL = 0 ";
            TDatosAccess.conStr = conStr;
            TDatosAccess.ExecuteQuery(query, CommandType.Text);
            return true;
        }

        public clsCampo BuscarCampo(int equivId)
        {
            if (TDatosAccess.conStr == null)
                TDatosAccess.conStr = conStr;
            string query = string.Format("select EquivId, ListaValores, Func, SelTe, EsEvol from   campos where EquivId = {0}", equivId);
            DataTable dt = TDatosAccess.GetDataNonQuery(query, CommandType.Text);
            clsCampo campo = null;
            if(dt.Rows.Count > 0 )
            {
                var row = dt.Rows[0];
                campo.EquivId = equivId;
                campo.Func = row["func"].ToString();

            }
            return campo;
        }
        public Boolean InsertarCamposEvolucion(clsCampo campo)
        {
            string svalCero = null;
            if (TDatosAccess.conStr == null)
                TDatosAccess.conStr = conStr;
            if (campo.ListaValores != null)
                if (campo.ListaValores.Count > 0)
                    svalCero = campo.ListaValores.Aggregate((current, vcero) => current + vcero.Trim() + ", ");
            string query = string.Format("insert into Campos (EquivId, ListaValores, Func, SelTe, EsEvol)  values( {0}, '{1}', '{2}',{3}, 1)", campo.EquivId, svalCero, campo.Func, campo.selTe == null ? 0 : 1);
            TDatosAccess.ExecuteQuery(query, CommandType.Text);

            return true;
        }
        public Boolean InsertarCamposSeleccion(clsCampo campo)
        {
            string svalCero = null;
            if (TDatosAccess.conStr == null)
                TDatosAccess.conStr = conStr;
            if (campo.ListaValores != null)
                if (campo.ListaValores.Count > 0)
                    svalCero = campo.ListaValores.Aggregate((current, vcero) => current + ", " + vcero.Trim());

            string query = string.Format("insert into Campos (EquivId, ListaValores, Func, SelTe, EsEvol, verValor)  values( {0}, '{1}', '{2}',{3}, 0, {4})", campo.EquivId, svalCero, campo.Func, campo.selTe == null ? 0 : 1, campo.verValor == false ? 0 : 1);
            TDatosAccess.ExecuteQuery(query, CommandType.Text);

            return true;
        }

        public List<clsCampo> ObtenerCamposSeleccion()
        {
            if (TDatosAccess.conStr == null)
                TDatosAccess.conStr = conStr;
            string query = string.Format("select EquivId, ListaValores, Func, SelTe, EsEvol, VerValor from   campos where esEvol = 0");
            DataTable dt = TDatosAccess.GetDataNonQuery(query, CommandType.Text);
            List<clsCampo> lista = new List<clsCampo>();
            if (dt.Rows.Count > 0)
            {

                foreach (DataRow row in dt.Rows)
                {
                    clsCampo campo = new clsCampo();
                    campo.EquivId = Convert.ToInt32(row["equivId"]);
                    //List<string> vcero = new List<string>();
                    campo.ListaValores = row["ListaValores"].ToString().Split(',').ToList();
                    campo.verValor = Convert.ToBoolean(row["VerValor"]);
                    lista.Add(campo);
                }
                
            }
            return lista;
        }


        public List<clsCampo> ObtenerCamposEvolucion()
        {
            return ObtenerCampos(true);
        }

        public List<clsCampo> ObtenerCampos(bool esEvol)
        {
            if (TDatosAccess.conStr == null)
                TDatosAccess.conStr = conStr;
            string query = string.Format("select EquivId, ListaValores, Func, SelTe, EsEvol from   campos where esEvol = {0}", esEvol == true ? -1 : 0);
            DataTable dt = TDatosAccess.GetDataNonQuery(query, CommandType.Text);
            if(dt== null)
            {
                return null;
            }
            List<clsCampo> lista = new List<clsCampo>();
            if (dt.Rows.Count > 0)
            {

                foreach (DataRow row in dt.Rows)
                {
                    clsCampo campo = new clsCampo();
                    campo.EquivId = Convert.ToInt32(row["equivId"]);
                    campo.Func = row["Func"].ToString();
                    lista.Add(campo);
                }

            }
            return lista;

        }
    }
}
