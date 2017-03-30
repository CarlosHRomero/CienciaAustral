using System;
using System.Collections.Generic;
using System.Linq;
using Ciencia.OBJ;
using Ciencia.DAL;
using System.Data;

namespace Ciencia.BLL
{
    public class ListasDesplegables
    {
        public List<CienciaTablaEquiv> ListaTabla(int moduloId)
        {
            TablaEquivManager man = new TablaEquivManager();
            List<CienciaTablaEquiv> lista = man.ObtenerTablasOrigenPorModulo(moduloId);
            return lista;
        }

        public List<Ciencia_Modulo> ListaModulo()
        {
            ModuloManager man = new ModuloManager();
            List<Ciencia_Modulo> lista = man.Seleccionar("", "", "");
            return lista;

        }
        public List<CienciaTablaEquiv> ListaTabla(int ModuloId, bool esEvolucion, bool incTodas)
        {
            TablaEquivManager man = new TablaEquivManager();
            List<CienciaTablaEquiv> lista = new List<CienciaTablaEquiv>();

            CienciaTablaEquiv obj = new CienciaTablaEquiv
            {
                TablaId = 0,
                NombreTabla = "*"
            };
            if(incTodas)
                lista.Add(obj);
            lista.AddRange( man.ObtenerTablasOrigenPorModulo(ModuloId, esEvolucion));
            var tablaPaciente = man.ObtenerTablasOrigenPorModulo(ModuloId).Where(x => x.EsPaciente).FirstOrDefault();
            lista.Add(tablaPaciente);
            return lista;
        }

        public List<string> ListaSolapaEvol(int moduloId)
        {
            CienciaEquivManager man = new CienciaEquivManager();
            string s = "*";
            List<string> lista = new List<string>();
            lista.Add(s);
            lista.AddRange(man.ObtenerListaSolapas(moduloId, true));
            //lista.AddRange(man.ObtenerListaSolapas(moduloId, true));
            return lista;
        }

        public List<string> ListaSolapa(int moduloId, bool esEvol)
        {
            CienciaEquivManager man = new CienciaEquivManager();
            string s = "*";
            List<string> lista = new List<string>();
            lista.Add(s);
            lista.AddRange(man.ObtenerListaSolapas(moduloId, esEvol));
            //lista.AddRange(man.ObtenerListaSolapas(moduloId, true));
            return lista;
        }
        public List<string> ListaSolapa(int moduloId)
        {
            CienciaEquivManager man = new CienciaEquivManager();
            string s = "*";
            List<string> lista = new List<string>();
            lista.Add(s);
            lista.AddRange(man.ObtenerListaSolapas(moduloId, false));
            return lista;
        }

        public List<string> ListaSolapaPorTabla(int moduloId, int tablaId)
        {
            CienciaEquivManager man = new CienciaEquivManager();
            string s = "*";
            List<string> lista = new List<string>();
            lista.Add(s);
            lista.AddRange(man.ObtenerListaSolapas(moduloId, tablaId, false));
            return lista;
        }
      
        public List<CienciaEquiv> ListaCampos(int TablaId, int moduloId)
        {
            string where;
            CienciaEquivManager man = new CienciaEquivManager();

            List<CienciaEquiv> lista; 
            if(TablaId == 0)
            {
                lista =man.ListarCamposPorModuloEvolucion(moduloId, false).Where(x => x.TipoDeDato != null && x.TipoDeDato.ToUpper() != "ID").ToList();
            }

            else
            {
                where = "TablaId = " + TablaId.ToString() + " and TipoDeDato is not null and TipoDeDato <> 'id'";
                lista = man.Seleccionar(where, "", "");
            }
            return lista;
        }



        public List<string> ListaOperador()
        {
            var lista = new List<string>();
            lista.Add("Like");
            lista.Add("=");
            lista.Add(">");
            lista.Add("<");
            lista.Add(">=");
            lista.Add("<=");
            lista.Add("<>");
            return lista;
        }

        public List<string> ListaNoSi()
        {
            var lista = new List<string>();
            lista.Add("*");
            lista.Add("No");
            lista.Add("Si");
            return lista;
        }


        public List<String> ListaDatos(int moduloId, String Campo, string Where, int equivId)
        {
            moduloBuss modB = new moduloBuss();
            CienciaEquivManager equivMan = new CienciaEquivManager();
            CienciaEquiv eq = equivMan.GetByID(equivId.ToString());
            List<string> lista;
            if(eq == null)
            {
                throw new Exception("No se encontro Campo en la tabla CienciaEquiv. ListasDesplegables.ListaDatos");               
            }

            string sql;

            string tablasAgregadas = modB.ObtnerTablasAgregadas(moduloId);

            if (!string.IsNullOrEmpty(Where))
                sql = string.Format("SELECT DISTINCT {0} FROM {1} WHERE {2} ORDER BY {0}", Campo, tablasAgregadas, Where);
            else
                sql = string.Format("SELECT DISTINCT {0} FROM {1} ORDER BY {0}", Campo, tablasAgregadas);
            TDatos dat = new TDatos("ICBA.Properties.Settings.conStrCiencia");
            DataTable dt = dat.GetDataNonQuery(sql);
            if (dt != null)
            {
                lista = (from DataRow row in dt.Rows select row[0].ToString()).ToList();
                //return lista;
            }
            else 
                return null;


            if (eq.TipoDeDato.Trim().ToLower() == "tabla")
            {
                string tablaEq = modB.ObtenerDatosModulo(moduloId).TablaEquiv;
                List<string> lista2;
                AdmEquivMan AdmEqMan = new AdmEquivMan();

                if (Campo.ToLower() == "ingr_subdiag_d")
                {
                    string filtros;
                    filtros = AdmEqMan.filtroSubDiag().Aggregate((current, filtro) => current + ", " + filtro.Trim());
                    List<AdmEquiv> listaEq = AdmEqMan.ListadoPorTitulo(filtros, tablaEq);
                    lista2= listaEq.OrderBy (x=> x.Eqv_ord).Select(x => x.Eqv_Desc).ToList<string>();
                }
                else
                {
                    List<AdmEquiv> listaEq = AdmEqMan.ListadoPorTitulo(eq.Filtro, tablaEq);
                    lista2 = listaEq.Select(x => x.Eqv_Desc).ToList<string>();
                }
                return lista2.Intersect(lista).ToList();
            }
            else
            {
                //TDatos data = new TDatos();
                return lista;
            }
        }


        public object ListaAnd()
        {
            var lista = new List<string>();
            lista.Add("");
            lista.Add("AND");
            lista.Add("OR");
            return lista;
        }
    }
}
