using System;
using System.Collections.Generic;
using System.ComponentModel;
using Cardiologia.DAL;
using Ciencia.DAL;
using Ciencia.OBJ;
using DAO;

namespace Ciencia.BLL
{
    public class CienciaB 
    {

        public event EventHandler CopiandoTabla;

        protected virtual void OnCopiandoTabla(EventArgs e)
        {
            EventHandler handler = CopiandoTabla;
            if(handler != null)
            {
                handler(this, e);
            }
        }
        public CienciaB()
        {
            
        }

        public int ContarTotalRegistros()
        {
            //String sql = "select COUNT(*) from Ciencia_Car_Ingr ";
            //int x =Convert.ToInt32( TDatos.GetDataEscalar(sql, CommandType.Text));
            //return x;

            return 0;
        }

        public string ObtenerTipoDato(String tabla, String campo)
        {
            return TipoDeDato.ObtenerTipoDato(tabla, campo);

        }
        
        
        public int ContarRegistrosConsulta(string where)
        {

            //String sql = "select distinct COUNT(*) from Ciencia_Car_Pac " +
            //            "inner join Ciencia_Car_Ingr on Pac_Id = Ingr_Pac_Id " +
            //            "inner join Ciencia_Car_Ant on Ingr_Id = Ant_Ingr_Id " +
            //            "inner join Ciencia_Car_AntC on Ingr_Id = AntC_Ingr_Id " +
            //            "inner join Ciencia_Car_Alta on Ingr_Id = Alta_Ingr_Id ";
                        
          
            //sql = sql + "where " + where;

            //int x = Convert.ToInt32(TDatos.GetDataEscalar(sql, CommandType.Text));
            //return x;

            return 0;
        }

        public DateTime ObtenerFechaDesde()
        {
            //const string sql = "select MIN(Ciencia_Car_Ingr.Ingr_F) from Ciencia_Car_Ingr";

            //DateTime x = Convert.ToDateTime(TDatos.GetDataEscalar(sql, CommandType.Text));
            //return x;
            return DateTime.MinValue;
        }

        public DateTime ObtenerFechaHasta()
        {
            //String sql = "select MAX(Ciencia_Car_Ingr.Ingr_F) from Ciencia_Car_Ingr";

            //DateTime x = Convert.ToDateTime(TDatos.GetDataEscalar(sql, CommandType.Text));
            //return x;

            return DateTime.MinValue;
        }

        private string _localConStr;

        public bool InsertarTablaSel(string @where, BackgroundWorker worker)
        {
            //CienciaLocal cl = new CienciaLocal(_localConStr);
            //cl.CopiaTablaSinSeleccion("Car_Equiv");
            //cl.CopiaTablaSinSeleccion("CienciaCarEquiv");
            //cl.CopiaTablaSinSeleccion("CienciaCarTablaEquiv");
            //worker.ReportProgress(5, "Copiando Tabla Pacientes");
            //cl.CopiaTablaSinSeleccion("ciencia_Car_Pac");
            //worker.ReportProgress(10);
            //cl.CopiaTablaConSeleccion("ciencia_Car_Pac", where);
            //worker.ReportProgress(15, "Copiando Tabla Ingresos");
            //cl.CopiaTablaSinSeleccion("ciencia_Car_Ingr");
            //cl.CopiaTablaConSeleccion("ciencia_Car_Ingr", where);
            //worker.ReportProgress(25, "Copiando Tabla Antecedentes");
            //cl.CopiaTablaSinSeleccion("ciencia_Car_Ant");
            //worker.ReportProgress(40);
            //cl.CopiaTablaConSeleccion("ciencia_Car_Ant", where);
            //worker.ReportProgress(50);
            //cl.CopiaTablaSinSeleccion("ciencia_Car_AntC");
            //worker.ReportProgress(65);
            //cl.CopiaTablaConSeleccion("ciencia_Car_AntC", where);
            //worker.ReportProgress(75, "Copiando Tabla Alta");
            //cl.CopiaTablaSinSeleccion("ciencia_Car_Alta");
            //worker.ReportProgress(80);
            //cl.CopiaTablaConSeleccion("ciencia_Car_Alta", where);
            //worker.ReportProgress(85, "Copiando Tabla Evolución");
            //cl.CopiaTablaSinSeleccion("ciencia_Car_Evol");
            //worker.ReportProgress(95);
            //cl.CopiarTablaEvolucionConSeleccion();

            return true;
        }



        /*
        public Boolean InsertarTablaSel(String where)
        {
            String sql = "INSERT INTO Ciencia_Car_Ingr_Sel " +
                         "select distinct Ciencia_Car_Ingr.* from Ciencia_Car_Ingr " +
                         "inner join Ciencia_Car_Ant on Ingr_Id = Ant_Ingr_Id " +
                         "inner join Ciencia_Car_AntC on Ingr_Id = AntC_Ingr_Id " +
                         "inner join Ciencia_Car_Alta on Ingr_Id = Alta_Ingr_Id ";
            sql = sql + "where " + where;
            TDatos.ExecuteQuery(sql, CommandType.Text, _localConStr);
            sql = "INSERT INTO Ciencia_Car_Ant_Sel " +
                         "select distinct Ciencia_Car_Ant.* from Ciencia_Car_Ingr " +
                         "inner join Ciencia_Car_Ant on Ingr_Id = Ant_Ingr_Id " +
                         "inner join Ciencia_Car_AntC on Ingr_Id = AntC_Ingr_Id " +
                         "inner join Ciencia_Car_Alta on Ingr_Id = Alta_Ingr_Id ";
            sql = sql + "where " + where;
            TDatos.ExecuteQuery(sql, CommandType.Text, _localConStr);
            sql = "INSERT INTO Ciencia_Car_AntC_Sel " +
                         "select distinct Ciencia_Car_AntC.* from Ciencia_Car_Ingr " +
                         "inner join Ciencia_Car_Ant on Ingr_Id = Ant_Ingr_Id " +
                         "inner join Ciencia_Car_AntC on Ingr_Id = AntC_Ingr_Id " +
                         "inner join Ciencia_Car_Alta on Ingr_Id = Alta_Ingr_Id ";
            sql = sql + "where " + where;
            TDatos.ExecuteQuery(sql, CommandType.Text, _localConStr);

            return true;
        }*/

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
                DAO.DBEngine dao = new DBEngine();
                //JRO.JetEngine jro = new DAO  JetEngine();

                dao.CompactDatabase(origen, Destino);
                _localConStr = ArmarCadenaDeConexion(Destino);
                return true;
            }
            catch (Exception ex)
            {
                Utiles.WriteErrorLog("No pudo crear la base de datos " + Destino+ex.Message);
                return false;
            }
        }
        public Boolean CrearBaseDeDatosLocal(string conStr)
        {
            try
            {
                ADOX.Catalog cat = new ADOX.Catalog();
                cat.Create(conStr);
                return true;
            }
            catch (Exception ex)
            {
                Utiles.WriteErrorLog("No pudo crear la base de datos "+conStr+ex.Message);
                return false;
            }

        }


        public Boolean GuardarSel(Ciencia_Car_Seleccion sel)
        {
            SelManager man = new SelManager(_localConStr);
            return  man.Insertar(sel);
        }

      
    }
}
