using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Ciencia.OBJ;
using Ciencia.DAL;
using Cardiologia.OBJ;
using Cardiologia.DAL;
using System.Windows.Forms;
using  System.Data;
using System.Data.SqlClient;
using Ciencia.DAL.ICBA_Cirugia_2003DataSetTableAdapters;
using Generales;
using Utiles = Cardiologia.DAL.Utiles;


namespace Ciencia.DAL
{
    public class MapeadorAnt
    {

        //CarAntManager ManagerDest = new CarAntManager();
        //AntecedentesManager ManagerOrigen = new AntecedentesManager();
        //EquivMAnager CarEquivManager = new EquivMAnager();

        //public Boolean BorrarTabla()
        //{
        //    try
        //    {
        //        var entry = ConfigurationManager.ConnectionStrings["ICBA.Properties.Settings.ConnStr"];
        //        SqlConnection con = new SqlConnection(entry.ConnectionString);
        //        con.Open();
        //        SqlCommand com = new SqlCommand("DELETE FROM Ciencia_Car_Ant", con);
        //        com.ExecuteNonQuery();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        Utiles.WriteErrorLog(ex.Message);
        //        return false;
        //    }
        //}


        public Boolean MapearAntecedentes2(BackgroundWorker worker)
        {
            try
            {
                BorrarTabla();
                //DataTable dt;
                var entry = ConfigurationManager.ConnectionStrings["ICBA.Properties.Settings.ConnStr"];
                SqlConnection con = new SqlConnection(entry.ConnectionString);
                Ciencia_Car_AntTableAdapter daDest = new Ciencia_Car_AntTableAdapter();
                SqlDataAdapter daOrg = new SqlDataAdapter("select * from Car_Ant_New", con);
                DataTable dtOrg = new DataTable();
                string queryDes = "select * from ciencia_car_ant";
                DataTable dtDes = ExecuteCmd(queryDes, CommandType.Text);

        //public Boolean MapearAntecedentes2(BackgroundWorker worker)
        //{
        //    try
        //    {
        //        BorrarTabla();
        //        //DataTable dt;
        //        var entry = ConfigurationManager.ConnectionStrings["ICBA.Properties.Settings.ConnStr"];
        //        SqlConnection con = new SqlConnection(entry.ConnectionString);
        //        Ciencia_Car_AntTableAdapter daDest = new Ciencia_Car_AntTableAdapter();
        //        SqlDataAdapter daOrg = new SqlDataAdapter("select * from Car_Ant_New", con);
        //        DataTable dtOrg = new DataTable();
        //        string queryDes = "select * from ciencia_car_ant";
        //        DataTable dtDes = TDatos.ExecuteCmd(queryDes, CommandType.Text);


        //        CienciaEquiv equiv = new CienciaEquiv();
        //        CienciaEquivManager EqMan = new CienciaEquivManager();
        //        int i = 0;
        //        daOrg.Fill(dtOrg);
        //        //daDest.InsertCommand =
        //        //    new SqlCommand(
        //        //        "INSERT INTO [cirugia].[Ciencia_Car_Ingr] ([Ingr_Id], [Ingr_Ctro_D], [Ingr_Pac_Id], [Ingr_F], [Ingr_Diagnostico_D], [Ingr_SubDiag_D], [Ingr_Sintoma_D], [Ingr_DolorPreCord_B], [Ingr_Disnea_B], [Ingr_Sincope_B], [Ingr_Palpitac_B], [Ingr_Cansancio_B], [Ingr_Fiebre_B], [Ingr_Cefalea_B], [Ingr_Neurolog_B], [Ingr_Hematoma_B], [Ingr_OtroSintoma_B], [Ingr_Derivado_D], [Ingr_HTA_D], [Ingr_DLP_D], [Ingr_TBQ_D], [Ingr_DBT_D], [Ingr_AHF_B], [Ingr_FRCV_B], [Ingr_FEVI_N], [Ingr_DisfSist_D], [Ingr_CF_Habit_D], [Ingr_Timi_N], [Ingr_Grace_N], [Ingr_Crusade_N], [Ingr_Estado_N], [Ingr_Alta_F], [Ingr_Alta_Obito_D], [Ingr_Pase_M]) VALUES (@Ingr_Id, @Ingr_Ctro_D, @Ingr_Pac_Id, @Ingr_F, @Ingr_Diagnostico_D, @Ingr_SubDiag_D, @Ingr_Sintoma_D, @Ingr_DolorPreCord_B, @Ingr_Disnea_B, @Ingr_Sincope_B, @Ingr_Palpitac_B, @Ingr_Cansancio_B, @Ingr_Fiebre_B, @Ingr_Cefalea_B, @Ingr_Neurolog_B, @Ingr_Hematoma_B, @Ingr_OtroSintoma_B, @Ingr_Derivado_D, @Ingr_HTA_D, @Ingr_DLP_D, @Ingr_TBQ_D, @Ingr_DBT_D, @Ingr_AHF_B, @Ingr_FRCV_B, @Ingr_FEVI_N, @Ingr_DisfSist_D, @Ingr_CF_Habit_D, @Ingr_Timi_N, @Ingr_Grace_N, @Ingr_Crusade_N, @Ingr_Estado_N, @Ingr_Alta_F, @Ingr_Alta_Obito_D, @Ingr_Pase_M)");
                
        //        string campoDest;
        //        foreach (DataRow filaOrg in dtOrg.Rows)
        //        {
        //            if (worker.CancellationPending)
        //            {
        //                return false;
        //            }
        //            DataRow filaDest = dtDes.NewRow();
        //            foreach (DataColumn columna in dtOrg.Columns)
        //            {
        //                equiv = EqMan.ObtenerPorOrigen(columna.ColumnName);
        //                if (equiv == null)
        //                    continue;
        //                campoDest = equiv.CampoEquivalente.Trim();
        //                var valor = filaOrg[columna];
        //                if (String.IsNullOrEmpty(valor.ToString()))
        //                {
        //                    if (equiv.ValorPorDefecto == null)
        //                        filaDest[campoDest] = DBNull.Value;
        //                    else
        //                        filaDest[campoDest] = equiv.ValorPorDefecto.Trim();
        //                    continue;
        //                }
        //                if (equiv.Filtro == null)
        //                {
        //                    if (columna.DataType == typeof(DateTime) || columna.DataType == typeof(DateTime?))
        //                        filaDest[campoDest] = ((DateTime)valor);
        //                    else if (columna.DataType == typeof(Boolean) || columna.DataType == typeof(Boolean?))
        //                        filaDest[campoDest] = (Boolean)valor == false ? "N" : "S";
        //                    else if (columna.DataType == typeof(String))
        //                        filaDest[campoDest] = valor.ToString().Trim();
        //                    else
        //                        filaDest[campoDest] = valor;
        //                }
        //                else
        //                {
        //                    String s = ObtenerEquivalente(equiv.Filtro.Trim(), valor);
        //                    if (s == null)
        //                        filaDest[campoDest] = equiv.ValorPorDefecto.Trim();
        //                    else
        //                        filaDest[campoDest] = s.Trim();
        //                }
        //            }
        //            dtDes.Rows.Add(filaDest);
        //            i++;
        //            worker.ReportProgress(i*100 / 3000);

        //        }
        //        //daDest.Update(dtDes);
                
        //        //Completa la tabla con los valores de ingr que no estan en ant

<<<<<<< .mine
                dtOrg = GetDataNonQuery("select Ingr_Id, Ingr_Pac_Id from Car_Ingr_New " +
                                               "where not exists " +
                                               "(select * from Car_Ant_New " +
                                               "where Car_Ingr_New.Ingr_Id = Car_Ant_New.Ant_Ingr_Id)");
                foreach (DataRow filaOrg in dtOrg.Rows)
                {
                    DataRow filaDest = dtDes.NewRow();
                    filaDest["Ant_Ingr_Id"] = filaOrg["Ingr_Id"];
                    filaDest["Ant_Pac_Id"] = filaOrg["Ingr_Pac_Id"];
                    foreach (DataColumn columna in dtDes.Columns.Cast<DataColumn>().Where(columna => columna.ColumnName != "Ant_Ingr_Id" &&  columna.ColumnName != "Ant_Pac_Id"))
                    {
                        equiv = EqMan.ObtenerPorCampoEquiv(columna.ColumnName);
                        if (equiv == null)
                        {
                            throw new Exception("No encontro el campo");
                        }
                        if (equiv.ValorPorDefecto == null)
                            filaDest[columna] = DBNull.Value;
                        else
                        {
                            filaDest[columna] = equiv.ValorPorDefecto.Trim();
                        }
                    }
                    dtDes.Rows.Add(filaDest);
                }
                UpdateTable(queryDes, dtDes);
                //daDest.Update(dtDes);
                return true;
            }
            catch (Exception ex)
            {
                Utiles.WriteErrorLog("Error en mapearAntecedentes " + ex.Message);
                return false; 
            }
=======
        //        dtOrg = TDatos.GetDataNonQuery("select Ingr_Id, Ingr_Pac_Id from Car_Ingr_New " +
        //                                       "where not exists " +
        //                                       "(select * from Car_Ant_New " +
        //                                       "where Car_Ingr_New.Ingr_Id = Car_Ant_New.Ant_Ingr_Id)");
        //        foreach (DataRow filaOrg in dtOrg.Rows)
        //        {
        //            DataRow filaDest = dtDes.NewRow();
        //            filaDest["Ant_Ingr_Id"] = filaOrg["Ingr_Id"];
        //            filaDest["Ant_Pac_Id"] = filaOrg["Ingr_Pac_Id"];
        //            foreach (DataColumn columna in dtDes.Columns.Cast<DataColumn>().Where(columna => columna.ColumnName != "Ant_Ingr_Id" &&  columna.ColumnName != "Ant_Pac_Id"))
        //            {
        //                equiv = EqMan.ObtenerPorCampoEquiv(columna.ColumnName);
        //                if (equiv == null)
        //                {
        //                    throw new Exception("No encontro el campo");
        //                }
        //                if (equiv.ValorPorDefecto == null)
        //                    filaDest[columna] = DBNull.Value;
        //                else
        //                {
        //                    filaDest[columna] = equiv.ValorPorDefecto.Trim();
        //                }
        //            }
        //            dtDes.Rows.Add(filaDest);
        //        }
        //        TDatos.UpdateTable(queryDes, dtDes);
        //        //daDest.Update(dtDes);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        Utiles.WriteErrorLog("Error en mapearAntecedentes " + ex.Message);
        //        return false; 
        //    }




        //}
        //public Boolean MapearAntecedentes(ProgressBar p)
        //{
        //    List<clsAntecedentes> ListaOrigen;
        //    List<CienciaCarAnt> ListaDestino = new List<CienciaCarAnt>();
        //    int i = 0;
        //    try
        //    {
        //        ListaOrigen = ManagerOrigen.Seleccionar("", "", "");
        //        foreach (clsAntecedentes org in ListaOrigen)
        //        {
        //            CienciaCarAnt dest = new CienciaCarAnt();
        //            MapearObjetos(dest, org);
        //            ManagerDest.Insertar(dest);
        //            //ListaDestino.Add(dest);
        //            i++;
        //            p.Value = i;
        //        }

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        Utiles.WriteErrorLog("Error en MapearIngresos: " + ex.Message);
        //        return false;
        //    }
        //}

        //private void MapearObjetos(CienciaCarAnt dest, clsAntecedentes org)
        //{
        //    Type tipo = org.GetType();
        //    IList<PropertyInfo> campos = new List<PropertyInfo>(tipo.GetProperties());
        //    CienciaEquiv equiv = new CienciaEquiv();
        //    CienciaEquivManager EqMan = new CienciaEquivManager();
        //    //List<PropertyInfo> camposDest = new List<PropertyInfo>(dest.GetType().GetProperties());
        //    PropertyInfo campoDest;
        //    Type tipoDest = dest.GetType();
        //    String s;
        //    try
        //    {
        //        foreach (PropertyInfo campoOrg in campos)
        //        {
        //            equiv = EqMan.ObtenerPorOrigen(campoOrg.Name);
        //            if (equiv == null)
        //                continue;
        //            //if(campoOrg.Name == "Ingr_Sint_DolPreCord_B") 
        //            //     throw new Exception();
        //            campoDest = tipoDest.GetProperty(equiv.CampoEquivalente.Trim());
        //            if (campoDest == null)
        //                throw new Exception();
        //            //if (campoDest.Name == "Ingr_Derivado_D")
        //            //    throw new Exception();
        //            var valor = campoOrg.GetValue(org, null);
        //            if (valor == null)
        //            {
        //                campoDest.SetValue(dest, equiv.ValorPorDefecto);
        //                continue;
        //            }
        //            if (equiv.Filtro == null)
        //            {
        //                if (campoOrg.PropertyType == typeof(DateTime) || campoOrg.PropertyType == typeof(DateTime?))
        //                    campoDest.SetValue(dest, (DateTime)valor);
        //                else if (campoOrg.PropertyType == typeof(Boolean) || campoOrg.PropertyType == typeof(Boolean?))
        //                    campoDest.SetValue(dest, (Boolean)valor == false ? "N" : "S");
        //                else
        //                    campoDest.SetValue(dest, valor);
        //            }
        //            else
        //            {
        //                s = ObtenerEquivalente(equiv.Filtro.Trim(), valor);
        //                if (s == null)
        //                {
        //                    campoDest.SetValue(dest, equiv.ValorPorDefecto);
        //                }
        //                else
        //                    campoDest.SetValue(dest, s);
        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Utiles.WriteErrorLog(ex.Message);
        //        Utiles.WriteErrorLog("");
        //    }


        //    //MapearCampo(org.Ingr_Ctro_D, des);


        //}

        //private string ObtenerEquivalente(string filtro, object valor)
        //{
        //    String Where = "Eqv_Tit= '" + filtro + "' and Eqv_Val = " + valor;
        //    List<clsCarEquiv> lista = CarEquivManager.Seleccionar(Where, "");
        //    if (lista.Count == 0)
        //        return null;
        //    if (lista.Count > 1)
        //    {
        //        throw new Exception("En MapeadorIngresos.ObtenerEquivalente. Se encontró mas de un registro que cumple la condición");
        //    }
        //    return lista.First<clsCarEquiv>().Eqv_Desc;
        //}

    }
}
