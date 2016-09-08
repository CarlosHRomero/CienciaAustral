using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Ciencia.OBJ;
using Ciencia.DAL;
using System.ComponentModel;


namespace Ciencia.BLL
{
    public class EvolucionBuss 
    {
        EvolucionMan man = new EvolucionMan();
        TablaEquivManager tbMan = new TablaEquivManager();
        CienciaEquivManager ceMan = new CienciaEquivManager();
        public List<CienciaEquiv> ListaCampos(int moduloId, string conStr)
        {
            List<CienciaEquiv> lista = ceMan.ListarCamposPorModuloEvolucion(moduloId, true).Where(x => x.TipoDeDato != null && x.TipoDeDato.ToUpper() != "ID").ToList();
            LocalCamposManager campManager = new LocalCamposManager(conStr);
            List<clsCampo> listaCampos = campManager.ObtenerCamposEvolucion();
            clsCampo c;
            foreach (var campo in lista)
            {
                c = listaCampos.Find(x => x.EquivId == campo.EquivId);
                if (c != null)
                {
                    campo.Seleccion = true;
                    campo.ValoresACero = c.Func;
                }
            }
            return lista;
        }

        public string ObtenerTablaEquivalenteEvolucion(int moduloId)
        {
           return(tbMan.ObtenerTablaEquivalenteEvolucion(moduloId));
        }
        public string CrearVista(int moduloId, string conStr)
        {
            LocalSelectInfManager infMan = new LocalSelectInfManager(conStr);
            string where = infMan.ObtenerInfSeleccion().where;
            string tabla = tbMan.ObtenerTablaEquivalente(moduloId);
            string tablaEvol = tbMan.ObtenerTablaEquivalenteEvolucion(moduloId);
            return man.CrearVista(tabla, tablaEvol, where, moduloId);
        }

        public string JoinEvolucion(int moduloId, string conStr)
        {
            LocalSelectInfManager infMan = new LocalSelectInfManager(conStr);
            moduloBuss modB = new moduloBuss();
            string tablasAgregadas = modB.ObtnerTablasAgregadas(moduloId);

            string tabla = tbMan.ObtenerTablaEquivalente(moduloId);
            string tablaEvol = tbMan.ObtenerTablaEquivalenteEvolucion(moduloId);
            ModuloManager modMan = new ModuloManager();
            string clavePrimariaEvol = modMan.ObtenerDatosModulo(moduloId.ToString()).ClavePrimariaEvol;
            string claveExternaEvol = modMan.ObtenerDatosModulo(moduloId.ToString()).ClaveExternaEvol;
            if(string.IsNullOrEmpty(clavePrimariaEvol))
            {
                throw new Exception("Clave Primaria Evolucion no establecida");
            }
            if (string.IsNullOrEmpty(claveExternaEvol))
            {
                throw new Exception("Clave Externa Evolucion no establecida");
            }

            string query = string.Format("{0} inner join {1} on {4}.{2} = {1}.{3}", tablasAgregadas, tablaEvol, clavePrimariaEvol, claveExternaEvol, tabla);

            return query;
        }

        public Boolean ConstruirEvolucion(List<clsCampo> Campos, string conStr, int moduloId, BackgroundWorker bw)
        {
            try
            {
                CienciaEquivManager eqMan = new CienciaEquivManager();
                
                clsCampo campo = new clsCampo();

                ModuloManager modMan = new ModuloManager();
                Ciencia_Modulo mod = modMan.ObtenerDatosModulo(moduloId.ToString());
                string clavePrimariaEvol = mod.ClavePrimariaEvol;
                int tablaId = tbMan.ObtenerTablasOrigenPorModulo(moduloId).FirstOrDefault(x => x.EsTronco == true && x.EsEvolucion == false).TablaId;
                CienciaEquiv c = eqMan.ObtenerPorOrigen(clavePrimariaEvol, tablaId);
                campo.tablaId = c.TablaId;
                campo.nombre = c.CampoEquivalente;
                Campos.Add(campo);
                CienciaEquiv fechaEventoprincipal = eqMan.BuscarFechaEventoPrincipal(moduloId);
                clsCampo campo2 = new clsCampo();
                campo2.tablaId = fechaEventoprincipal.TablaId;
                campo2.nombre = fechaEventoprincipal.CampoEquivalente;
                Campos.Add(campo2);

                man.conStr = conStr;
                if(!man.ConstruirEvolucion(Campos, moduloId , bw))
                    return false;
                return true;
                
            }
            catch
            {
                return false;
            }
        }

        public Boolean ExportarAExcel(int moduloId, string conStr)
        {
            TablaEquivManager teMan = new TablaEquivManager();
            man.conStr = conStr;
            string tablaOrigenEvol = teMan.ObtenerTablaEquivalenteEvolucion(moduloId);
            string tablaResultadoEvol = tablaOrigenEvol + "_Sel";

            if (!man.ExportarAExcel(tablaResultadoEvol))
                return false;
            return true;

        }

        public Boolean ActualizarCamposEvolucion(List<clsCampo> campos, string conStr)
        {

            LocalCamposManager campManager = new LocalCamposManager(conStr);
            if(!campManager.BorrarCamposEvolucion())
                return false;
            SelEvolManager selEManager = new SelEvolManager(conStr);
            if (!selEManager.BorrarTabla())
                return false;

            foreach( clsCampo campo in campos)
            {
                if(!campManager.InsertarCamposEvolucion(campo))
                    return false;
                if(campo.selTe != null)
                {
                    foreach(var selEvol in campo.selTe)
                    {
                        selEvol.equivId = campo.EquivId;
                        selEManager.insertar(selEvol);
                    }
                }
            }
            return true;
        }

        public List<SelTablaEvol>  ObtenerSeleccionEvolucion(int EquivId, string conStr)
        {
            SelEvolManager selEManager = new SelEvolManager(conStr);
            return selEManager.ObtenerporEquivId(EquivId);
        }
            
    }
}
