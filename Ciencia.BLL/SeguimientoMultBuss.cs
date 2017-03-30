using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ciencia.OBJ;
using Ciencia.DAL;
using System.ComponentModel;
using System.Data;

namespace Ciencia.BLL
{
    public class SeguimientoMultBuss
    {
        private string _conStr;

        public SeguimientoMultBuss(string conStr)
        {
            _conStr = conStr;
            man = new LocalCamposSgmtoMan(_conStr);
        }
        LocalCamposSgmtoMan man;
        public List<int> LeerIdCamposSeleccionados()
        {
            man.CrearTabla();
            var lista = man.SeleccionarCampos();
            return lista;
        }

        public List<clsCampo> LeerCamposSeleccionados()
        {
            var lista = new List<clsCampo>();
            var equivMan = new CienciaEquivManager();
            var listaId = LeerIdCamposSeleccionados();
            foreach(var equivId in listaId )
            {
                var obj = equivMan.GetByID(equivId.ToString());
                var campo = new clsCampo();
                campo.EquivId = equivId;
                campo.nombre = obj.CampoEquivalente;
                lista.Add(campo);
            }
            return lista;
        }
        public void ActualizarCamposSgmto(List<clsCampo> campos)
        {
            man.LimpiarTabla();
            foreach(var campo in campos )
            {
                man.InsertarCampo(campo);
            }
        }

        public void ConstruirSgmto(BackgroundWorker bw)
        {
            LocalSelectInfManager infMan = new LocalSelectInfManager(_conStr);
            string where = infMan.ObtenerInfSeleccion().where;
            var moduloId = infMan.ObtenerInfSeleccion().moduloId;
            TablaEquivManager teMan = new TablaEquivManager();
            string tablaEvol = teMan.ObtenerTablaEquivalenteEvolucion(moduloId);
            string tablaPrincipal = teMan.ObtenerTablaEquivalente(moduloId);
            ModuloManager modMan = new ModuloManager();
            string clavePrimaria = modMan.ObtenerDatosModulo(moduloId.ToString()).ClavePrimariaEvol;
            string claveExternaEvol = modMan.ObtenerDatosModulo(moduloId.ToString()).ClaveExternaEvol;
            var campos = new List<clsCampo>();
            //Agregar paciente
            var tablaPaciente = teMan.ObtenerTablasOrigenPorModulo(moduloId).Where(x => x.EsPaciente).FirstOrDefault();
            var PacienteId = tablaPaciente.ClavePrimaria;
            var pacId = new clsCampo();
            pacId.nombre = PacienteId;
            pacId.tabla = tablaPaciente.NombreTablaEquiv;
            campos.Add(pacId);
            campos.AddRange(LeerCamposSeleccionados());
            var sd = new SeguimientoData();
            var dt = sd.LeerDatosSeguimiento(campos, tablaPrincipal, tablaEvol, clavePrimaria, claveExternaEvol, where);
            var ds = new DataSet();
            ds.Tables.Add(dt);
            Generales.ExportadorDatos.ExportarExcel(ds, @"c:\sistemas\ciencia\prueba.xlsx");

        }
        public List<CienciaEquiv> ListaCampos()
        {
            LocalSelectInfManager infMan = new LocalSelectInfManager(_conStr);
            var moduloId = infMan.ObtenerInfSeleccion().moduloId;

            CienciaEquivManager ceMan = new CienciaEquivManager();
            List<CienciaEquiv> lista = ceMan.ListarCamposPorModuloEvolucion(moduloId, true).Where(x => x.TipoDeDato != null && x.TipoDeDato.ToUpper() != "ID").ToList();
            TablaEquivManager teMan = new TablaEquivManager();
            var tablaPaciente = teMan.ObtenerTablasOrigenPorModulo(moduloId).Where(x => x.EsPaciente).FirstOrDefault();
            var listaPac = ceMan.ObtenerCamposPorTablaOrigen(tablaPaciente.TablaId);
            lista.AddRange(listaPac);
            List<clsCampo> listaCampos = LeerCamposSeleccionados();
            clsCampo c;
            foreach (var campo in lista)
            {
                c = listaCampos.Find(x => x.EquivId == campo.EquivId);
                if (c != null)
                {
                    campo.Seleccion = true;
                }
            }
            return lista;
        }
    }
}
