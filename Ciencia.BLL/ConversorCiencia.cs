using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ciencia.OBJ;
using Ciencia.DAL;
using System.Windows.Forms;
using System.Data;

namespace Ciencia.BLL
{
    /// <summary>
    /// Clase encargada en la conversión de datos para su posterior procesamiento
    /// </summary>
    public class ConversorCiencia
    {
        private readonly List<CienciaTablaEquiv> _tablasOrigenModulo;
        private readonly MapeadorTabla _mapeadorTabla;
        private CienciaTablaEquiv _tablaPrincipal;
        private CienciaTablaEquiv _tablaPaciente;
        private readonly int _cantidadTablas;
        private int _cantidadTablasProcesadas;
        private readonly List<string> _mensajes;

        /// <summary>
        /// Inicializa componentes necesarios para la conversión
        /// </summary>
        /// <param name="moduloId"> ID del modulo que se va a convertir</param>
        public ConversorCiencia(int moduloId)
        {
            var tablaEquivManager = new TablaEquivManager();
            //Tablas correspondientes al modulo
            _tablasOrigenModulo = tablaEquivManager.ObtenerTablasOrigenPorModulo(moduloId);
            _cantidadTablas = _tablasOrigenModulo.Where(x => x.Procesar != false).Count();
            _mapeadorTabla = new MapeadorTabla();
            //Tabla paciente del modulo
            _tablaPaciente = _tablasOrigenModulo.FirstOrDefault(x => x.EsPaciente);
            _mensajes = new List<string>();
            //Actualiza la tabla elf_equiv apartir de la tabla elf_persvinc
            //if (moduloId == 1)
            //{
            //    //Operadores
            //    _mapeadorTabla.ActualizarElfEquivPersonalVinculado("PVi_Est_T=2 AND (PVi_Per_D=1 Or PVi_Per_D=2)", "Operador");
            //    //Anestesiologo
            //    _mapeadorTabla.ActualizarElfEquivPersonalVinculado("PVi_Est_T=2 AND (PVi_Per_D=1 Or PVi_Per_D=3)", "Anestesiologo");
            //    //Ayudante
            //    _mapeadorTabla.ActualizarElfEquivPersonalVinculado("PVi_Est_T=2 AND (PVi_Per_D=1 Or PVi_Per_D=4)", "Ayudante");
            //    //Instrumentista
            //    _mapeadorTabla.ActualizarElfEquivPersonalVinculado("PVi_Est_T=2 AND (PVi_Per_D=1 Or PVi_Per_D=7)", "Instrumentista");
            //    //Medico
            //    _mapeadorTabla.ActualizarElfEquivPersonalVinculado("PVi_Per_D=1 Or PVi_Per_D=6", "Medico");
            //    // Primer evento cardiologia
            //}
            if (moduloId == 2)
            {
                //EvolPrimeraCar epc = new EvolPrimeraCar();
                //epc.ActualizarTabla();
                //EvolUltimaCar euc = new EvolUltimaCar();
                //euc.ActualizarTabla();
            }
        }

        /// <summary>
        /// Convierte tablas origen a tablas de equivalencia, traduciendo los campos correspondientes
        /// </summary>
        /// <param name="worker"> BackgroundWorker</param>
        public Boolean ConvertirTablas(BackgroundWorker worker)
        {
            try
            {
                //Solo para cardiología
                bool res;
                //Tabla principal del modulo
                _tablaPrincipal = _tablasOrigenModulo.First(x => x.EsTronco && x.EsEvolucion == false);
                _mensajes.Add("Tablas procesadas " + _cantidadTablasProcesadas + " de " + _cantidadTablas);
                //Nombre de las tablas destino donde se guardaron las tablas traducidas en un proceso anterior, exceptuando las que son evolución o seguimiento
                var tablaDestino = _tablasOrigenModulo.Where(x => x.EsEvolucion == false).Select(x => x.NombreTablaEquiv).Distinct().ToList();
                if (_tablaPrincipal != null)
                {
                    //Borra tablas destino cradas en un proceso anterior
                    res = _mapeadorTabla.EliminarTabla(tablaDestino);
                    if (!res)
                        return false;
                }
                else
                {
                    throw new Exception("Falta Tabla Troncal");
                }
                //Crea tablas destino para nuevo proceso
                res = _mapeadorTabla.CrearTablaDestino(_tablasOrigenModulo.Where(x => x.EsEvolucion == false && x.EsMultiple == false).ToList(), _tablaPrincipal.NombreTablaEquiv, _tablaPrincipal.ClavePrimaria, _tablaPrincipal.ModuloId);
                if (!res)
                    return false;
                //Busca tablas destino recien cradas
                tablaDestino = _tablasOrigenModulo.Where(x => x.EsEvolucion == false && x.EsMultiple == false).Select(x => x.NombreTablaEquiv).Distinct().ToList();
                //Recorre las tablas destino recien generadas
                foreach (var nombreTabla in tablaDestino)
                {
                    //Mapea datos de la clave primaria de tabla principal a las distintas tablas destino generadas para poder relacionar los datos contenidos en ella como si fueran una única tabla
                    res = _mapeadorTabla.MapearDatosClavePrimaria(_tablaPrincipal, worker, nombreTabla);
                    if (!res)
                        return false;
                    var tabla = nombreTabla;
                    foreach (var cienciaTablaEquiv in _tablasOrigenModulo.Where(x => x.EsEvolucion == false && x.EsMultiple == false && x.NombreTablaEquiv == tabla && x.Procesar == true).OrderByDescending(x => x.EsTronco))
                    {
                        _mensajes.Add("Procesando " + cienciaTablaEquiv.NombreTabla + " - " + cienciaTablaEquiv.Descripcion);
                        worker.ReportProgress(0, _mensajes);
                        if (cienciaTablaEquiv.EsPaciente)
                        {
                            //Agrega datos de los paciente a las tablas generadas 
                            res = _mapeadorTabla.MapearDatosTablaOrigenPaciente(_tablaPrincipal, cienciaTablaEquiv.ClaveForanea, cienciaTablaEquiv, worker);
                            if (!res)
                                return false;
                        }
                        else
                        {
                            if (cienciaTablaEquiv.EsTronco == false)
                            {
                                //Si la tabla no tiene la marca correspondiente para ser procesada no se procesa
                                if (cienciaTablaEquiv.Procesar)
                                {
                                    //Agrega datos de la tabla origen a la tabla destino relacionando la clave primaria de la tabla principal con la clave foránea de la tabla a procesar 
                                    res = _mapeadorTabla.MapearDatosTablaOrigen(cienciaTablaEquiv, worker, _tablaPrincipal.ClavePrimaria, cienciaTablaEquiv.ClaveForanea);
                                    if (!res)
                                        return false;
                                }
                            }
                            else
                            {
                                //Agrega datos de la tabla origen a la tabla destino relacionando, en el caso de la tabla principal esto se hace a través de su clave primaria ya previamente cargada en la tabla destino
                                res = _mapeadorTabla.MapearDatosTablaOrigen(cienciaTablaEquiv, worker, _tablaPrincipal.ClavePrimaria, cienciaTablaEquiv.ClavePrimaria);
                                if (!res)
                                    return false;
                            }
                        }
                        _mensajes.Clear();
                        _mensajes.Add("Tablas procesadas " + ++_cantidadTablasProcesadas + " de " + _cantidadTablas);
                    }
                    _mensajes.Clear();
                    _mensajes.Add("Tablas procesadas " + _cantidadTablasProcesadas + " de " + _cantidadTablas);
                    _mensajes.Add("Persistiendo Datos en BD");
                    _mensajes.Add(_mapeadorTabla.CantidadDeRegistrosAGuardar().ToString());
                    worker.ReportProgress(0, _mensajes);
                    //Persiste la informacion mapeada en BD
                    res = _mapeadorTabla.Modificar(nombreTabla);
                    if (!res)
                        return false;
                    _mensajes.Clear();
                    _mensajes.Add("Tablas procesadas " + _cantidadTablasProcesadas + " de " + _cantidadTablas);
                }
                return true;
            }
            catch (Exception ex)
            {
                Generales.Utiles.WriteErrorLog("Error en ConversorCiencia.ConvertirTablas: " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Convierte tablas evolucion o tablas seguimiento originales a tablas de equivalencia, traduciendo los campos correspondientes
        /// </summary>
        /// <param name="worker"> BackgroundWorker</param>
        public Boolean ConvertirTablasEvolucion(BackgroundWorker worker)
        {
            try
            {
                _mensajes.Add("Tablas procesadas " + _cantidadTablasProcesadas + " de " + _cantidadTablas);
                //Conjunto de tablas evolución o seguimiento
                var tablaEvolucion = _tablasOrigenModulo.Where(x => (x.EsEvolucion && x.Procesar));
                if (tablaEvolucion.Count() < 1)
                    return true;
                //Tabla principal de evolución
                var tablaPrincipalEvol = _tablasOrigenModulo.First(x => x.EsTronco && x.EsEvolucion);
                //Nombre de las tablas destino para evolucion o seguimiento donde se guardaron las tablas traducidas en un proceso anterior
                var tablaDestino = _tablasOrigenModulo.Where(x => x.EsEvolucion).Select(x => x.NombreTablaEquiv).Distinct().ToList();
                //Borra tablas destino destino para evolucion o seguimiento cradas en un proceso anterior
                var res = _mapeadorTabla.EliminarTabla(tablaDestino);
                if (!res)
                    return false;
                //Crea tablas destino de evolucion o seguimiento para nuevo proceso
                var cienciaTablaEquivs = tablaEvolucion as CienciaTablaEquiv[] ?? tablaEvolucion.ToArray();
                res = _mapeadorTabla.CrearTablaDestino(_tablasOrigenModulo.Where(x => x.EsEvolucion).ToList(), cienciaTablaEquivs.First().NombreTablaEquiv, cienciaTablaEquivs.First().ClavePrimaria, cienciaTablaEquivs.First().ModuloId);
                if (!res)
                    return false;
                //Recorre las tablas destino de evolucion o seguimiento recien generadas
                foreach (var nombreTabla in tablaDestino)
                {
                    //Mapea datos de la clave primaria de tabla principal a las distintas tablas destino generadas para poder relacionar los datos contenidos en ella como si fueran una única tabla
                    res = _mapeadorTabla.MapearDatosClavePrimaria(tablaPrincipalEvol, worker, nombreTabla);
                    if (!res)
                        return false;
                    var tabla = nombreTabla;
                    foreach (var cienciaTablaEquiv in _tablasOrigenModulo.Where(x => x.EsEvolucion && x.NombreTablaEquiv == tabla))
                    {
                        if (cienciaTablaEquiv.EsTronco)
                        {
                            //Agrega datos de la tabla origen a la tabla destino relacionando, en el caso de la tabla principal esto se hace a través de su clave primaria ya previamente cargada en la tabla destino
                            res = _mapeadorTabla.MapearDatosTablaOrigen(cienciaTablaEquiv, worker, tablaPrincipalEvol.ClavePrimaria, cienciaTablaEquiv.ClavePrimaria);
                            if (!res)
                                return false;
                        }
                        else
                        {
                            //Agrega datos de la tabla origen a la tabla destino relacionando la clave primaria de la tabla principal con la clave foránea de la tabla a procesar
                            res = _mapeadorTabla.MapearDatosTablaOrigen(cienciaTablaEquiv, worker, tablaPrincipalEvol.ClavePrimaria, cienciaTablaEquiv.ClaveForanea);
                            if (!res)
                                return false;
                        }
                        _mensajes.Clear();
                        _mensajes.Add("Tablas procesadas " + ++_cantidadTablasProcesadas + " de " + _cantidadTablas);
                    }
                    _mensajes.Add("Persistiendo Datos en BD");
                    worker.ReportProgress(0, _mensajes);
                    //Persiste la informacion mapeada en BD
                    res = _mapeadorTabla.Modificar(nombreTabla);
                    if (!res)
                        return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                Generales.Utiles.WriteErrorLog("Error en ConversorCiencia.ConvertirTablasEvolucion: " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Convierte tablas que tienen relacion uno a muchos con la tabla principal a tablas de equivalencia, traduciendo los campos correspondientes
        /// </summary>
        /// <param name="worker"> BackgroundWorker</param>
        public Boolean ConvertirTablasMultiples(BackgroundWorker worker)
        {
            try
            {
                _mensajes.Add("Tablas procesadas " + _cantidadTablasProcesadas + " de " + _cantidadTablas);
                //Conjunto de tablas que tienen una relacion uno a muchos con la tabla principal
                var tablasMultiple = _tablasOrigenModulo.Where(x => x.EsMultiple);
                foreach (var tablaMul in tablasMultiple)
                {
                    var res = _mapeadorTabla.EliminarTabla(tablaMul.NombreTablaEquiv);
                    if (!res)
                        return false;
                    res = _mapeadorTabla.CrearTablaDestino(tablaMul);
                    if (!res)
                        return false;
                    DataTable dtDes = new DataTable();
                    res = _mapeadorTabla.MapearDatosTablaOrigen(tablaMul, worker, ref dtDes);
                    if (!res)
                        return false;
                    _mensajes.Clear();
                    _mensajes.Add("Tablas procesadas " + ++_cantidadTablasProcesadas + " de " + _cantidadTablas);
                    _mensajes.Add("Persistiendo Datos en BD");
                    worker.ReportProgress(0, _mensajes);
                    //Persiste la informacion mapeada en BD
                    res = _mapeadorTabla.Modificar(tablaMul.NombreTablaEquiv, dtDes);
                    if (!res)
                        return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                Generales.Utiles.WriteErrorLog("Error en ConversorCiencia.ConvertirTablasMultiples: " + ex.Message);
                return false;
            }
        }
    }
}
