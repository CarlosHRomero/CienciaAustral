using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Ciencia.OBJ;
using Ciencia.DAL;
using Generales;

namespace Ciencia.BLL
{
    public class SelectorBuss
    {
        public string constr { get; set; }
        SelectorData sd = new SelectorData();

        public string ArmarCadenaDeConexion(string nombreArchivo)
        {
            string strcon = "Provider=Microsoft.ACE.OLEDB.12.0; " +
                            "Data Source= " + nombreArchivo;
            return strcon;
        }
        public Boolean CopiarBaseDeDatos(string origen, string Destino)
        {
            try
            {
                DAO.DBEngine dao = new DAO.DBEngine();
                dao.CompactDatabase(origen, Destino);
                constr = ArmarCadenaDeConexion(Destino);
                return true;
            }
            catch (Exception ex)
            {
                Utiles.WriteErrorLog("No pudo crear la base de datos " + Destino + ex.Message);
                return false;
            }
        }

        public List<clsSelector> ListaSeleccion()
        {
            LocalSelectorManager man = new LocalSelectorManager(constr);
            return man.ListaSeleccion();
        }


        public string ConstruirCriterio(string and, string tablaOrg, string Campo, string operador, string valor)
        {
            string crit;
            TablaEquivManager man = new TablaEquivManager();
            string tablaeq = man.ObtenerPorTablaOrigen(tablaOrg).NombreTablaEquiv;
            if (Campo.Substring(Campo.Length - 2) == "_F")
            {
                string dato = Utiles.ConverToSqlDate(valor);
                if (dato == null)
                    return null;
                crit = string.Format("{0} ({1}.{2} {3} {4})", and,
                    tablaeq, Campo, operador, dato);
            }
            else
            {
                string tipo = ObtenerTipoDato(tablaeq, Campo);
                crit = string.Format((tipo == "nvarchar" || tipo == "nchar" || tipo == "varchar" || tipo == "char")
                    ? "{0} ({1}.{2} {3} '{4}')" : "{0} ({1}.{2} {3} {4})", and,
                    tablaeq, Campo, operador, valor);
            }
            return crit;
        }
        public string ObtenerTipoDato(String tabla, String campo)
        {
            return TipoDeDato.ObtenerTipoDato(tabla, campo);

        }

        public string ObtenerTablaEquivalente(string tablaOrg)
        {
            TablaEquivManager man = new TablaEquivManager();
            CienciaTablaEquiv eqv = man.ObtenerPorTablaOrigen(tablaOrg);
            if (eqv != null)
                return eqv.NombreTablaEquiv;
            else
                return null;
        }

        public int ContarRegistros(int moduloId)
        {
            moduloBuss modB = new moduloBuss();
            string tablasAgregadas = modB.ObtnerTablasAgregadas(moduloId);
            
            if (tablasAgregadas != null)
                return sd.ContarRegistros(tablasAgregadas);
            else
                return 0;
        }
        public int ContarRegistros(int moduloId, string where)
        {
            
            moduloBuss modB = new moduloBuss();
            string tablasAgregadas = modB.ObtnerTablasAgregadas(moduloId);
            return sd.ContarRegistros(tablasAgregadas, where);
        }

        public Boolean GuardarSelector(List<clsSelector> listaConsulta)
        {
            try
            {
                LocalSelectorManager man = new LocalSelectorManager(constr);
                //Borra tabla selector
                man.BorrarTablaSelector();
                foreach (clsSelector obj in listaConsulta)
                {
                    man.Insertar(obj);
                }
                return true;
            }
            catch(Exception ex)
            {
                Utiles.WriteErrorLog("Error en SelectorBuss.guardar selector: " + ex.Message);
                return false;
            }

        }
        public Boolean GuardarSelecInf(SelecInf obj)
        {
            try
            {
                LocalSelectInfManager man = new LocalSelectInfManager(constr);
                man.BorrarTabla();
                man.Insertar(obj);
                return true;
            }
            catch (Exception ex)
            {
                Utiles.WriteErrorLog("Error en guardar SelectorBuss.GuardarSelecInf: " + ex.Message);
                return false;
            }
        }
        public SelecInf ObtenerSelectInf()
        {
            try
            {
                 LocalSelectInfManager man = new LocalSelectInfManager(constr);
                 SelecInf inf = man.ObtenerInfSeleccion();
                 if (inf == null)
                     return null;
                if(inf.moduloId == 0 || string.IsNullOrEmpty(inf.where) )
                {
                    throw new Exception("El archivo no contiene un formato válido");
                }
                return inf;
            }
            catch (Exception ex)
            {
                Utiles.WriteErrorLog("Error en guardar SelectorBuss.ObtenerSelectInf: " + ex.Message);
                return null;
            }
        }

        public Boolean VerificarBaseDeDatos()
        {
            LocalSelectorManager selman = new LocalSelectorManager(constr);
            LocalSelectInfManager infMan = new LocalSelectInfManager(constr);
            if (!selman.VerificarTablaSelector())
                return false;
            if (!infMan.VerificarTablaSelecInf())
                return false;
            return true;

        }

        //public string CrearVista(int moduloId, string where)
        //{
        //    TablaEquivManager man = new TablaEquivManager();
        //    moduloBuss modB = new moduloBuss();
        //    string tablasAgregadas = modB.ObtnerTablasAgregadas(moduloId);

        //    return sd.CrearVista(tablasAgregadas, where);

        //}
    }
}
