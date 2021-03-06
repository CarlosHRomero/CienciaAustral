
using Cardiologia.OBJ;
using Ciencia.OBJ;
using Electrofisiologia.DAL;
using Generales;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ciencia.DAL
{
    public class MapeadorTabla
    {
        private readonly TDatos _tdatos;
        private readonly TDatos _tdatosCiencia;
        private DataTable _dtDes;
        private readonly AdmEquivMan _admMan;
        private readonly CienciaEquivManager _eqMan;
        private readonly ModuloManager _moduloMan;
        private readonly TablaEquivManager _tablaEquivMan;
        private const int CantidadColumnas = 800;
        private readonly Electrofisiologia.DAL.PersVincManager _elfPersVincManager;
        private const string _fechaNcimiento = "PAC_NAC_F";
        private const string _edad = "PROC_EDAD_N";
        public MapeadorTabla()
        {
            _tdatos = new TDatos("Au.Properties.Settings.conStr");
            _tdatosCiencia = new TDatos("Au.Properties.Settings.conStr");
            //_carEquivManager = new EquivMAnager();
            _admMan = new AdmEquivMan();
            _eqMan = new CienciaEquivManager();
            _moduloMan = new ModuloManager();
            _tablaEquivMan = new TablaEquivManager();
            //_elfPersVincManager = new PersVincManager();
        }

        public Boolean EliminarTabla(List<string> tablasDestino)
        {
            try
            {
                if (tablasDestino.Any(x => x == null))
                {
                    throw new Exception("No se han cargado correctamente las tablas destino, toda tabla principal o tronco debe tener el nombre de la tabla destino correspondiente");
                }
                foreach (var tablaDestino in tablasDestino)
                {
                    string query = "IF EXISTS ( SELECT [name] FROM sys.tables WHERE [name] = '" + tablaDestino + "') DROP TABLE " + tablaDestino;
                    _tdatosCiencia.ExecuteQuery(query, System.Data.CommandType.Text);
                }
                return true;
            }
            catch (Exception ex)
            {
                Generales.Utiles.WriteErrorLog("Error en MapeadorTabla.EliminarTabla: " + ex.Message);
                return false;
            }
        }

        public Boolean EliminarTabla(string tablaDestino)
        {
            try
            {
                if (tablaDestino == null)
                {
                    throw new Exception("No se han cargado correctamente las tablas destino, toda tabla principal o tronco debe tener el nombre de la tabla destino correspondiente");
                }
                string query = "IF EXISTS ( SELECT [name] FROM sys.tables WHERE [name] = '" + tablaDestino + "') DROP TABLE " + tablaDestino;
                _tdatosCiencia.ExecuteQuery(query, System.Data.CommandType.Text);
                return true;
            }
            catch (Exception ex)
            {
                Generales.Utiles.WriteErrorLog("Error en MapeadorTabla.EliminarTabla: " + ex.Message);
                return false;
            }
        }

        public Boolean CrearTablaDestino(CienciaTablaEquiv cienciaTabla)
        {
            try
            {
                var query = "CREATE TABLE " + cienciaTabla.NombreTablaEquiv + " ( ";
                var campos = _eqMan.ObtenerCamposPorTablaOrigen(cienciaTabla.TablaId);
                foreach (var campo in campos)
                {
                    query += campo.CampoEquivalente + " " + campo.TipoDatoSqlServer + ", ";
                }
                query += ")";
                _tdatosCiencia.ExecuteQuery(query, System.Data.CommandType.Text);
                return true;
            }
            catch (Exception ex)
            {
                Generales.Utiles.WriteErrorLog("Error en MapeadorTabla.CrearTablaDestino: " + ex.Message);
                return false;
            }
        }

        private Boolean CrearTablaDestino(string crearTabla)
        {
            try
            {
                string query = crearTabla;
                _tdatosCiencia.ExecuteQuery(query, System.Data.CommandType.Text);
                return true;
            }
            catch (Exception ex)
            {
                Generales.Utiles.WriteErrorLog("Error en MapeadorTabla.CrearTablaDestino: " + ex.Message);
                return false;
            }
        }

        public Boolean CrearTablaDestino(List<CienciaTablaEquiv> cienciaTablas, string nombreTablaDestino, string clavePrimaria, int idModulo)
        {
            try
            {
                int i = 0;
                int j = 0;
                string tablaDestino = nombreTablaDestino;
                List<CienciaTablaEquiv> tablasOrigen = new List<CienciaTablaEquiv>();
                var crearTabla = "CREATE TABLE " + nombreTablaDestino + " ( ";
                foreach (var tablaEquiv in cienciaTablas.OrderByDescending(x => x.EsTronco))
                {
                    var campos = _eqMan.ObtenerCamposPorTablaOrigen(tablaEquiv.TablaId);
                    i += campos.Count;
                    if (i > CantidadColumnas)
                    {
                        crearTabla += ")";
                        CrearTablaDestino(crearTabla);
                        _tdatosCiencia.AgregarClavePrimaria(clavePrimaria, tablaDestino);
                        foreach (var tablaOrigen in tablasOrigen)
                        {
                            tablaOrigen.NombreTablaEquiv = tablaDestino;
                            _tablaEquivMan.Modificar(tablaOrigen);
                        }
                        ++j;
                        tablaDestino = "";
                        tablaDestino += nombreTablaDestino + "_" + j;
                        crearTabla = "CREATE TABLE " + tablaDestino + " ( " + clavePrimaria + " int, ";
                        tablasOrigen.Clear();
                        i = 0;
                    }
                    tablasOrigen.Add(tablaEquiv);
                    foreach (var campo in campos)
                    {
                        crearTabla += campo.CampoEquivalente + " " + campo.TipoDatoSqlServer + ", ";
                    }
                }
                crearTabla += ")";
                var res = CrearTablaDestino(crearTabla);
                if (!res)
                    return false;
                _tdatosCiencia.AgregarClavePrimaria(clavePrimaria, tablaDestino);
                foreach (var tablaOrigen in tablasOrigen)
                {
                    tablaOrigen.NombreTablaEquiv = tablaDestino;
                    _tablaEquivMan.Modificar(tablaOrigen);
                }
                var modulo = _moduloMan.GetByID(idModulo.ToString());
                modulo.TablasGeneradas = ++j;
                return _moduloMan.Modificar(modulo);
            }
            catch (Exception ex)
            {
                Generales.Utiles.WriteErrorLog("En MapeadorTabla.CrearTablaDestino: " + ex.Message);
                return false;
            }
        }


        public Boolean MapearDatosClavePrimaria(CienciaTablaEquiv nombreTablaOrigen, BackgroundWorker worker, string tablaDestino)
        {
            try
            {
                string queryOrg = "SELECT " + nombreTablaOrigen.ClavePrimaria + " FROM " + nombreTablaOrigen.NombreTabla;
                DataTable dtOrg = _tdatos.ExecuteCmd(queryOrg, CommandType.Text);
                var queryDes = "SELECT * FROM " + tablaDestino;
                _dtDes = _tdatosCiencia.ExecuteCmd(queryDes, CommandType.Text);
                foreach (DataRow filaOrg in dtOrg.Rows)
                {
                    var filaDest = _dtDes.NewRow();
                    var columna = dtOrg.Columns[nombreTablaOrigen.ClavePrimaria];
                    var equiv = _eqMan.ObtenerPorOrigen(columna.ColumnName, nombreTablaOrigen.TablaId);
                    var campoDest = equiv.CampoEquivalente.Trim();
                    filaDest[campoDest] = filaOrg[columna];
                    _dtDes.Rows.Add(filaDest);
                }
                _dtDes.PrimaryKey = new DataColumn[] { _dtDes.Columns[nombreTablaOrigen.ClavePrimariaEquiv] };
                return true;
            }
            catch (Exception ex)
            {
                Generales.Utiles.WriteErrorLog("Error en MapeadorTabla.MapearDatosClavePrimaria: " + ex.Message);
                return false;
            }
        }

        public Boolean MapearDatosTablaOrigen(CienciaTablaEquiv cienciaTablaEquiv, BackgroundWorker worker, string clavePrimaria, string claveForanea)
        {
            try
            {
                var modulo = _moduloMan.ObtenerDatosModulo(cienciaTablaEquiv.ModuloId.ToString());
                int i = 0;
                int diag = 0;
                var queryOrg = "SELECT * FROM " + cienciaTablaEquiv.NombreTabla;
                //if (cienciaTablaEquiv.NombreTabla == "Car_Evol_New" || cienciaTablaEquiv.NombreTabla == "Car_Proc_New")
                //    queryOrg += " ORDER BY " + cienciaTablaEquiv.CampoFecha + " DESC";
                var dtOrg = _tdatos.ExecuteCmd(queryOrg, CommandType.Text);
                var max = dtOrg.Rows.Count;
                int maxLength;
                foreach (DataRow filaOrg in dtOrg.Rows)
                {
                    if (worker.CancellationPending)
                    {
                        return false;
                    }
                    if (cienciaTablaEquiv.NombreTabla == "CVP_Parte_Q")
                    {
                        //if (filaOrg["Comp_Id"].ToString() == "9588")
                        max = max;
                    }
                    var filaDest = _dtDes.Rows.Find(filaOrg[claveForanea]);
                    if (filaDest != null)
                    {
                        foreach (DataColumn columna in dtOrg.Columns)
                        {

                            var equiv = _eqMan.ObtenerPorOrigen(cienciaTablaEquiv.ModuloId, columna.ColumnName, cienciaTablaEquiv.TablaId);
                            if (equiv == null)
                                continue;
                            var campoDest = equiv.CampoEquivalente.Trim();
                            var valor = filaOrg[columna];
                            if (columna.ColumnName == "Ingr_Grpo_D" || columna.ColumnName == "Ini_Grpo_D" || columna.ColumnName == "Fin_Grpo_D")
                            {
                                if(valor != DBNull.Value)
                                    diag = Convert.ToInt32(valor);
                            }
                            if (String.IsNullOrEmpty(valor.ToString()))
                            {
                                if (equiv.ValorPorDefecto == null)
                                    filaDest[campoDest] = DBNull.Value;
                                else
                                    filaDest[campoDest] = equiv.ValorPorDefecto.Trim();
                                continue;
                            }
                            if (columna.ColumnName == "Ingr_Diag_D" || columna.ColumnName == "Ini_Diag_D" || columna.ColumnName == "Fin_Diag_D")
                            {
                                string s;
                                if (diag == 0)
                                    s = string.Empty;
                                else
                                    s= BuscarSubDiagnostico(valor, diag);
                                if (s == null)
                                    filaDest[campoDest] = equiv.ValorPorDefecto.Trim();
                                else
                                    filaDest[campoDest] = s.Trim();
                                continue;
                            }
                            if (columna.ColumnName == "Ini_Prediabetes_B")
                                max = max;
                            if (equiv.Filtro_var != null)
                            {
                                object valorDependiente = filaOrg[equiv.Filtro_var];
                                string s = ObtenerEquivalenteSecundario(valor, equiv.Filtro_var, valorDependiente, modulo.TablaEquiv, cienciaTablaEquiv.TablaId);
                                if (s == null)
                                    filaDest[campoDest] = equiv.ValorPorDefecto.Trim();
                                else
                                {
                                    s = s.Trim();
                                    maxLength = int.Parse(equiv.TipoDatoSqlServer.ToUpper().Split('(')[1].Split(')')[0]);
                                    if (s.Length < maxLength)
                                        filaDest[campoDest] = s;
                                    else
                                        filaDest[campoDest] = s.Substring(0, maxLength);
                                }
                            }

                            if (equiv.Filtro == null)
                            {
                                if (columna.DataType == typeof(DateTime) || columna.DataType == typeof(DateTime?))
                                {
                                    if (valor == null)
                                        filaDest[campoDest] = DBNull.Value;
                                    else
                                        filaDest[campoDest] = (DateTime)valor;
                                }
                                else if (columna.DataType == typeof(Boolean) || columna.DataType == typeof(Boolean?))
                                    filaDest[campoDest] = (Boolean)valor == false ? "No" : "Si";
                                else if ((columna.DataType == typeof(int) || columna.DataType == typeof(short) || columna.DataType == typeof(int?) || columna.DataType == typeof(short?)) && columna.ColumnName.Substring(columna.ColumnName.Length - 2) == "_B")
                                {
                                    if (columna.DataType == typeof(int))
                                        valor = Convert.ToInt16(valor);
                                    var val = ConvertirIntABool((short)valor);
                                    filaDest[campoDest] = val == false ? "No" : "Si";
                                }
                                else if (columna.DataType == typeof(String))
                                {
                                    if (int.TryParse(equiv.TipoDatoSqlServer.ToUpper().Split('(')[1].Split(')')[0], out maxLength))
                                    {
                                        if (valor.ToString().Trim().Length < maxLength)
                                            filaDest[campoDest] = valor.ToString().Trim();
                                        else
                                            filaDest[campoDest] = valor.ToString().Trim().Substring(0, maxLength);
                                    }
                                    else
                                    {
                                        filaDest[campoDest] = valor.ToString().Trim();
                                    }
                                }
                                else
                                    filaDest[campoDest] = valor;
                            }
                            else
                            {
                                String s = ObtenerEquivalente(equiv.Filtro.Trim(), valor, modulo.TablaEquiv);
                                if (s == null)
                                    filaDest[campoDest] = equiv.ValorPorDefecto.Trim();
                                else
                                {
                                    s = s.Trim();
                                    maxLength = int.Parse(equiv.TipoDatoSqlServer.ToUpper().Split('(')[1].Split(')')[0]);
                                    if (s.Length < maxLength)
                                        filaDest[campoDest] = s;
                                    else
                                        filaDest[campoDest] = s.Substring(0, maxLength);
                                }
                            }
                        }
                    }
                    else
                    {
                        Generales.Utiles.WriteErrorLog("La tabla " + cienciaTablaEquiv.NombreTabla + " tiene un registro que no tiene equivalente en la tabla principal o tronco.");
                    }
                    i++;

                    worker.ReportProgress(i * 100 / max);
                    var n = _dtDes.Rows.IndexOf(filaDest);
                }
                return true;
            }
            catch (Exception ex)
            {
                Generales.Utiles.WriteErrorLog("Error en MapeadorEvolucion.MapearDatosTablaOrigen: " + ex.Message);
                return false;
            }
        }

        public Boolean MapearDatosTablaOrigen(CienciaTablaEquiv cienciaTablaEquiv, BackgroundWorker worker, ref DataTable dtDes)
        {
            try
            {
                var modulo = _moduloMan.ObtenerDatosModulo(cienciaTablaEquiv.ModuloId.ToString());
                int i = 0;
                var queryOrg = "SELECT * FROM " + cienciaTablaEquiv.NombreTabla;
                DataTable dtOrg = _tdatos.ExecuteCmd(queryOrg, CommandType.Text);
                var queryDes = "SELECT * FROM " + cienciaTablaEquiv.NombreTablaEquiv;
                dtDes = _tdatosCiencia.ExecuteCmd(queryDes, CommandType.Text);
                var max = dtOrg.Rows.Count;
                int maxLength;
                DataRow filaDest = null;
                foreach (DataRow filaOrg in dtOrg.Rows)
                {
                    if (worker.CancellationPending)
                    {
                        return false;
                    }
                    filaDest = dtDes.NewRow();
                    foreach (DataColumn columna in dtOrg.Columns)
                    {
                        var equiv = _eqMan.ObtenerPorOrigen(cienciaTablaEquiv.ModuloId, columna.ColumnName, cienciaTablaEquiv.TablaId);
                        if (equiv == null)
                            continue;
                        var campoDest = equiv.CampoEquivalente.Trim();
                        var valor = filaOrg[columna];
                        if (String.IsNullOrEmpty(valor.ToString()))
                        {
                            if (equiv.ValorPorDefecto == null)
                                filaDest[campoDest] = DBNull.Value;
                            else
                                filaDest[campoDest] = equiv.ValorPorDefecto.Trim();
                            continue;
                        }
                        if (equiv.Filtro == null)
                        {
                            if (columna.DataType == typeof(DateTime) || columna.DataType == typeof(DateTime?))
                                filaDest[campoDest] = (DateTime)valor;
                            else if (columna.DataType == typeof(Boolean) || columna.DataType == typeof(Boolean?))
                                filaDest[campoDest] = (Boolean)valor == false ? "No" : "Si";
                            else if (columna.DataType == typeof(String))
                            {
                                maxLength = int.Parse(equiv.TipoDatoSqlServer.ToUpper().Split('(')[1].Split(')')[0]);
                                if (valor.ToString().Trim().Length < maxLength)
                                    filaDest[campoDest] = valor.ToString().Trim();
                                else
                                    filaDest[campoDest] = valor.ToString().Trim().Substring(0, --maxLength);
                            }
                            else if ((columna.DataType == typeof(int?) || columna.DataType == typeof(short?)) && columna.ColumnName.Substring(columna.ColumnName.Length - 2) == "_B")
                                filaDest[campoDest] = (Boolean)ConvertirIntABool((int?)valor) == false ? "No" : "Si";
                            else
                                filaDest[campoDest] = valor;
                        }
                        else
                        {
                            String s = ObtenerEquivalente(equiv.Filtro.Trim(), valor, modulo.TablaEquiv);
                            if (s == null)
                                filaDest[campoDest] = equiv.ValorPorDefecto.Trim();
                            else
                            {
                                s = s.Trim();
                                maxLength = int.Parse(equiv.TipoDatoSqlServer.ToUpper().Split('(')[1].Split(')')[0]);
                                if (s.Length < maxLength)
                                    filaDest[campoDest] = s;
                                else
                                    filaDest[campoDest] = s.Substring(0, --maxLength);
                            }
                        }
                    }
                    dtDes.Rows.Add(filaDest);
                    i++;
                    worker.ReportProgress(i * 100 / max);
                }
                return true;
            }
            catch (Exception ex)
            {
                Generales.Utiles.WriteErrorLog("Error en MapeadorEvolucion.MapearDatosTablaOrigen: " + ex.Message);
                return false;
            }
        }

        public Boolean MapearDatosTablaOrigenPaciente(CienciaTablaEquiv tablaTroncal, string claveForanea, CienciaTablaEquiv cienciaTablasEquiv, BackgroundWorker worker)
        {
            try
            {
                var modulo = _moduloMan.ObtenerDatosModulo(cienciaTablasEquiv.ModuloId.ToString());
                int i = 0;
                string queryOrg = "SELECT * FROM " + cienciaTablasEquiv.NombreTabla;
                DataTable dtOrg = _tdatos.ExecuteCmd(queryOrg, CommandType.Text);
                var max = dtOrg.Rows.Count;
                int maxLength;
                foreach (DataRow filaOrg in dtOrg.Rows)
                {
                    if (worker.CancellationPending)
                    {
                        return false;
                    }
                    var ListfilaDest = (from DataRow Row in _dtDes.AsEnumerable()
                                        where Row.Field<int?>(claveForanea) == Convert.ToInt32(filaOrg[cienciaTablasEquiv.ClavePrimaria])
                                        select Row).ToList();
                    if (ListfilaDest.Count() != 0)
                    {
                        foreach (var filaDest in ListfilaDest)
                        {
                            foreach (DataColumn columna in dtOrg.Columns)
                            {
                                var equiv = _eqMan.ObtenerPorOrigen(cienciaTablasEquiv.ModuloId, columna.ColumnName, cienciaTablasEquiv.TablaId);
                                if (equiv == null)
                                    continue;
                                var campoDest = equiv.CampoEquivalente.Trim();
                                var valor = filaOrg[columna];
                                //Se le agrega la edad del paciente al campo proc_edad_n de la tabla hemo_proc1 corresponciente a ciencia hemodinamia
                                if (columna.ColumnName.ToUpper() == _fechaNcimiento && tablaTroncal.ModuloId == 5)
                                {
                                    int edad = (DateTime.Today - Convert.ToDateTime(valor)).Days / 365;
                                    filaDest[_edad] = edad.ToString();
                                    filaDest[_fechaNcimiento] = valor;
                                    continue;
                                }
                                if (String.IsNullOrEmpty(valor.ToString()))
                                {
                                    if (equiv.ValorPorDefecto == null)
                                        filaDest[campoDest] = DBNull.Value;
                                    else
                                        filaDest[campoDest] = equiv.ValorPorDefecto.Trim();
                                    continue;
                                }
                                if (equiv.Filtro == null)
                                {
                                    if (columna.DataType == typeof(DateTime) || columna.DataType == typeof(DateTime?))
                                        filaDest[campoDest] = (DateTime)valor;
                                    else if (columna.DataType == typeof(Boolean) || columna.DataType == typeof(Boolean?))
                                        filaDest[campoDest] = (Boolean)valor == false ? "No" : "Si";
                                    else if (columna.DataType == typeof(String))
                                    {
                                        maxLength = int.Parse(equiv.TipoDatoSqlServer.ToUpper().Split('(')[1].Split(')')[0]);
                                        if (valor.ToString().Trim().Length < maxLength)
                                            filaDest[campoDest] = valor.ToString().Trim();
                                        else
                                            filaDest[campoDest] = valor.ToString().Trim().Substring(0, --maxLength);
                                    }
                                    else if ((columna.DataType == typeof(int?) || columna.DataType == typeof(short?)) && columna.ColumnName.Substring(columna.ColumnName.Length - 2) == "_B")
                                        filaDest[campoDest] = (Boolean)ConvertirIntABool((int?)valor) == false ? "No" : "Si";
                                    else
                                        filaDest[campoDest] = valor;
                                }
                                else
                                {
                                    String s = ObtenerEquivalente(equiv.Filtro.Trim(), valor, modulo.TablaEquiv);
                                    if (s == null)
                                        filaDest[campoDest] = equiv.ValorPorDefecto.Trim();
                                    else
                                    {
                                        s = s.Trim();
                                        maxLength = int.Parse(equiv.TipoDatoSqlServer.ToUpper().Split('(')[1].Split(')')[0]);
                                        if (s.Length < maxLength)
                                            filaDest[campoDest] = s;
                                        else
                                            filaDest[campoDest] = s.Substring(0, --maxLength);
                                    }
                                }
                            }
                        }
                        i++;
                        worker.ReportProgress(i * 100 / max);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Generales.Utiles.WriteErrorLog("Error en MapeadorEvolucion.MapearDatosTablaOrigen: " + ex.Message);
                return false;
            }
        }

        private bool ConvertirIntABool(int? valor)
        {
            if (valor == null)
                return false;
            if (valor == 0)
                return false;
            else
                return true;
        }
        private bool ConvertirIntABool(short? valor)
        {
            if (valor == null)
                return false;
            if (valor == 0)
                return false;
            else
                return true;
        }
        private bool ConvertirIntABool(short valor)
        {
            if (valor == 0)
                return false;
            else
                return true;
        }
        public bool Modificar(string nombreTablaDestino)
        {
            Boolean result;
            try
            {
                string queryDes = "SELECT * FROM " + nombreTablaDestino;
                result = _tdatosCiencia.UpdateTable(queryDes, _dtDes);
            }
            catch (Exception ex)
            {
                Generales.Utiles.WriteErrorLog("En CienciaEquivManager.Modificar: " + ex.Message);
                result = false;
            }
            return result;
        }

        public bool Modificar(string nombreTablaDestino, DataTable dtDes)
        {
            Boolean result;
            try
            {
                string queryDes = "SELECT * FROM " + nombreTablaDestino;
                result = _tdatosCiencia.UpdateTable(queryDes, dtDes);
            }
            catch (Exception ex)
            {
                Generales.Utiles.WriteErrorLog("En CienciaEquivManager.Modificar: " + ex.Message);
                result = false;
            }
            return result;
        }

        private string BuscarSubDiagnostico(object valor, int diag)
        {
            try
            {
                if (diag == 1)
                    return null;
                //var eqv = _carEquivManager.Seleccionar("Eqv_Tit='Grupo' AND Eqv_Val = " + diag.ToString(), "Eqv_Ord").FirstOrDefault();
                //var eqv2 = _carEquivManager.Seleccionar("Eqv_Tit='" + eqv.Eqv_Continua + "' AND Eqv_Val = " + valor.ToString(), "Eqv_Ord").FirstOrDefault();
                //if (eqv2 == null)
                //    return null;
                return ""; //eqv2.Eqv_Desc;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
        private string ObtenerEquivalenteSecundario(object valor, string CampoDependiente, object valorDependiente, string tablaEquivModulo, int tablaId)
        {
            try
            {
                string filtro1 = _eqMan.ObtenerPorOrigen(CampoDependiente, tablaId).Filtro;
                string filtro2 = _admMan.ObtenerContinua(filtro1, valorDependiente, tablaEquivModulo);
                if (filtro2 == null)
                    return null;
                return ObtenerEquivalente(filtro2, valor, tablaEquivModulo);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        private string ObtenerEquivalente(string filtro, object valor, string tablaEquivModulo)
        {
            if (filtro == "Com_CC")
                throw new Exception("");
            return _admMan.ObtenerEquivalente(filtro, valor, tablaEquivModulo);
        }

        public bool ActualizarElfEquivPersonalVinculado(string where, string titulo)
        {
            int i = 0;
            Electrofisiologia.DAL.EquivManager elfMan = new Electrofisiologia.DAL.EquivManager();
            var operadores = _elfPersVincManager.Seleccionar(where, "", "");
            var operadoresElf = elfMan.Seleccionar("Eqv_Tit = '" + titulo + "'", "", "");
            Electrofisiologia.OBJ.clsEquiv clsEquiv;

            if (operadoresElf != null)
            {
                var personas = operadores.Select(x => x.PVi_ApNo).Except(operadoresElf.Select(x => x.Eqv_desc)).ToList<string>();
                clsEquiv = new Electrofisiologia.OBJ.clsEquiv();
                foreach (var persona in personas)
                {
                    var operador = operadores.First(x => x.PVi_ApNo == persona);
                    clsEquiv.Eqv_Tit = titulo;
                    clsEquiv.Eqv_desc = operador.PVi_ApNo;
                    clsEquiv.Eqv_val = (short)operador.PVi_Id;
                    clsEquiv.Eqv_ord = ++i;
                    elfMan.Insertar(clsEquiv);
                }
            }
            else
            {
                clsEquiv = new Electrofisiologia.OBJ.clsEquiv();
                foreach (var operador in operadores)
                {
                    clsEquiv.Eqv_Tit = titulo;
                    clsEquiv.Eqv_desc = operador.PVi_ApNo;
                    clsEquiv.Eqv_val = (short)operador.PVi_Id;
                    clsEquiv.Eqv_ord = ++i;
                    elfMan.Insertar(clsEquiv);
                }
            }
            return true;
        }

        public int CantidadDeRegistrosAGuardar()
        {
            return _dtDes.Rows.Count;
        }
    }
}
