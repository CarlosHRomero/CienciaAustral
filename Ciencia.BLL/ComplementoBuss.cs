using System;
using System.Collections.Generic;
using System.Linq;
using Ciencia.OBJ;
using Ciencia.DAL;

namespace Ciencia.BLL
{
    public class ComplementoBuss
    {
        CienciaEquivManager man = new CienciaEquivManager();

        string _tablaResultado;

        public string filtroSubDiag()
        {
            AdmEquivMan AdmEqMan = new AdmEquivMan();
            string filtros;
            filtros = AdmEqMan.filtroSubDiag().Aggregate((current, filtro) => current + ", " + filtro.Trim());
            return filtros;
        }

        public  CienciaEquiv ObtenerDatosCampo(int EquivId)
        {
            return man.GetByID(EquivId.ToString());
        }

        public List<CienciaEquiv> ListaCampos(int moduloId, string conStr)
        {
            List<CienciaEquiv> lista = man.ListarCamposPorModuloEvolucion(moduloId, false).Where(x => x.TipoDeDato != null && x.TipoDeDato.ToUpper() != "ID").ToList();
            LocalCamposManager campManager = new LocalCamposManager(conStr);
            List<clsCampo> listaCampos = campManager.ObtenerCamposSeleccion();
            List<clsCampo> listaCampos2;
            AdmEquivMan manAdmEq = new AdmEquivMan();
             ModuloManager modMan = new ModuloManager();
            string tablaEquiv = modMan.ObtenerDatosModulo(moduloId.ToString()).TablaEquiv;
            foreach (var campo in lista)
            {
                listaCampos2 = listaCampos.Where(x => x.EquivId == campo.EquivId).ToList();
                if (listaCampos2.Count > 0)
                {
                    campo.Seleccion = true;
                    campo.ValoresACeroStr = listaCampos2.First().ListaValores.Aggregate((current, vcero) => current + ", " + vcero.Trim());
                    campo.VerValor = listaCampos2.First().verValor;
                    if (!string.IsNullOrEmpty(campo.ValoresACeroStr))
                    {
                        campo.ValoresACero = campo.ValoresACeroStr;
                        /*
                        foreach (string val in listaCampos2.First().ValoresACero)
                        {
                            campo.ValoresACero += manAdmEq.traerValor(tablaEquiv, campo.Filtro, val.Trim()).Eqv_Val + ", ";
                        }*/
                    }
                }
            }
            return lista;
        }


        public Boolean ActualizarCamposSeleccion(List<clsCampo> campos, string conStr)
        {

            LocalCamposManager campManager = new LocalCamposManager(conStr);
            if (!campManager.BorrarCamposSeleccion())
                return false;


            foreach (clsCampo campo in campos)
            {
                if (!campManager.InsertarCamposSeleccion(campo))
                    return false;
            }
            return true;
        }


        public Boolean CrearTablaCiencia(string constr, List<clsCampo> campos, int moduloId)
        {
            CienciaEquivManager eqMan = new CienciaEquivManager();
            List<CienciaEquiv> listaId = eqMan.ListarCamposId(moduloId, campos, false);
            TablaEquivManager teMan = new TablaEquivManager();
            List<CienciaTablaEquiv> lista = teMan.ObtenerTablasOrigenPorModulo(moduloId, false);
            string clavePrimaria = lista.Where(x => x.EsTronco == true).FirstOrDefault().ClavePrimaria;
            List<string> tablasOrigen = teMan.ObtenerTablaSEquivalente(moduloId);
            foreach (CienciaEquiv c in listaId)
            {
                clsCampo campo = new clsCampo();
                campo.tablaId = c.TablaId;
                    campo.nombre =c.CampoEquivalente;
                campos.Add(campo);
            }
            //string tablaOrigen = teMan.ObtenerTablaEquivalente(moduloId);
            LocalSelectInfManager infMan = new LocalSelectInfManager(constr);
            string where = infMan.ObtenerInfSeleccion().where;
            TablaManager man = new TablaManager(constr);
            _tablaResultado = tablasOrigen.First() + "_sel";
            if (!man.CrearTablaResultado(tablasOrigen, _tablaResultado, campos, where, clavePrimaria))
                return false;
            System.Threading.Thread.Sleep(3000);
            return true;
        }

        public Boolean ExportarAExcel(string conStr)
        {
            if (string.IsNullOrEmpty(_tablaResultado))
                return false;
            TablaManager man = new TablaManager(conStr);
            if (!man.ExportarAExcel(_tablaResultado))
                return false;
            return true;
        }
    }
}
