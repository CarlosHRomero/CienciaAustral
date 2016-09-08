using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using Generales;

using  Ciencia.OBJ;


namespace Ciencia.DAL
{

    public class AdmEquivMan
    {
        private List<AdmEquiv> _lista;
        public List<AdmEquiv> ListadoCompleto(string tabla)
        {
            List<AdmEquiv> lista = new List<AdmEquiv>();
            string query = string.Format("SELECT  Eqv_Tit, Eqv_Val, Eqv_Desc, Eqv_Ord, Eqv_continua FROM {0} ", tabla);
            TDatos data = new TDatos("ICBA.Properties.Settings.ConnStr");
            DataTable dtEq = data.GetDataNonQuery(query);
            foreach (DataRow row in dtEq.Rows)
            {
                AdmEquiv obj = new AdmEquiv
                {
                    Eqv_Desc = row["Eqv_Desc"].ToString(),
                    Eqv_Val = Convert.ToInt16(row["Eqv_Val"]),
                    Eqv_ord = Convert.ToInt16(row["Eqv_ord"]),
                    Eqv_Tit = row["Eqv_Tit"].ToString(),
                    Eqv_Continua = row["Eqv_continua"].ToString()
                };
                lista.Add(obj);
            }
            return lista;
        }
        
        public  string ObtenerEquivalente(string filtro, object valor, string tablaEquivModulo)
        {
            if (tablaEquivModulo == null)
            {
                throw new Exception("Los Modulos deben tener cargado una tabla TablaEquiv en la cual se encuentran los datos de los desplegables");
            }
            if (_lista == null)
                _lista = ListadoCompleto(tablaEquivModulo);
            List<AdmEquiv> lista = _lista.Where(x => appFiltroVal(x, filtro, Convert.ToInt32(valor))).ToList<AdmEquiv>();
            if (lista.Count == 0)
                return null;
            if (lista.Count > 1)
            {
                throw new Exception("En MapeadorIngresos. ObtenerEquivalente. Se encontró mas de un registro que cumple la condición");
            }
            return lista.First<AdmEquiv>().Eqv_Desc;
        }


        public bool appFiltroVal(AdmEquiv x, string filtro, int val)
        {
           
            List<string> listafiltro = filtro.Split(',').ToList();
            foreach (string f in listafiltro)
            {
                if (x.Eqv_Tit.ToUpper() == f.Trim().ToUpper() && x.Eqv_Val == val)
                    return true;
            }
            return false;
        }
        
        public List<AdmEquiv> ListadoFiltrado(string tabla, string filtro)
        {
            if (_lista == null)
                _lista = ListadoCompleto(tabla);
            List<AdmEquiv> lista = _lista.Where(x => x.Eqv_Tit == filtro).ToList<AdmEquiv>();
            return lista;
        }
        delegate bool testfunc(AdmEquiv x, string filtro, string desc);
        public AdmEquiv traerValor(string tabla, string filtro, string desc)
        {
            //testfunc test = appFiltro;

            if (_lista == null)
                _lista = ListadoCompleto(tabla);
            AdmEquiv obj = _lista.FirstOrDefault(x=> appFiltro(x, filtro, desc));
            if (obj != null)
                return obj;
            else
                return null;
        }

        public List<string> filtroSubDiag()
        {
            if (_lista == null)
                _lista = ListadoCompleto("car_equiv");
            //var listafiltro = (from eqv in _lista
            //                  where eqv.Eqv_Tit == "Grupo"
            //                  select eqv.Eqv_Continua).ToList<string>();
            var listafiltro = _lista.Where(x => x.Eqv_Tit == "Grupo").Select(x => x.Eqv_Continua).ToList<string>();

            return listafiltro;
                          
        }


        public  bool appFiltro(AdmEquiv x, string filtro, string desc)
        {
            
            List<string> listafiltro = filtro.Split(',').ToList();
            if (desc == "f/d")
                desc = "f/dato";
            foreach(string f in listafiltro)
            {
                if (x.Eqv_Tit == f.Trim() && x.Eqv_Desc == desc)
                    return true;
            }
            return false;
        }

        public List<AdmEquiv> ListadoPorTitulo(string Tit, string tabla)
        {
            try
            {
                List<string> listafiltro = Tit.Split(',').ToList();
                if(listafiltro.Count ==0)
                {
                    throw new Exception("Filtro inválido");
                }

                string query = string.Format("SELECT * FROM {0}  WHERE Eqv_Tit = '{1}'", tabla, listafiltro.First());
                listafiltro.Remove(listafiltro.First());
                foreach(var f in listafiltro )
                {
                    query += string.Format(" or eqv_tit = '{0}'", f.Trim());
                }
                query += " order by eqv_ord";
                List<AdmEquiv> lista = new List<AdmEquiv>();
                //SqlParameter[] param = new SqlParameter[1];
                //param[0] = new SqlParameter("@0", Tit);
                TDatos data = new TDatos("ICBA.Properties.Settings.ConnStr");
                DataTable dt = data.GetDataNonQuery(query);
                Type tipo = typeof(AdmEquiv);
                IList<PropertyInfo> campos = new List<PropertyInfo>(tipo.GetProperties());
                foreach (DataRow row in dt.Rows)
                {
                    AdmEquiv obj = new AdmEquiv();
                    foreach (var campo in campos)
                    {
                        if(row[campo.Name] != DBNull.Value)
                            campo.SetValue(obj, row[campo.Name]);
                    }
                    lista.Add(obj);
                }
                return lista;

            }
            catch
            {
                return null;
            }
        }
        
        List<AdmEquiv> listaEquiv;

        public string EquivPorCodigo(int cod, string tit, string tabla)
        {

           
            if (listaEquiv == null)
                listaEquiv = ListadoPorTitulo(tit, tabla);

            var equiv_desc = from eqv in listaEquiv
                             where eqv.Eqv_Val == cod
                             select eqv.Eqv_Desc;
            return equiv_desc.First().ToString();
        }

    }
}
