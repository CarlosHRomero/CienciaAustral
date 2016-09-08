using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cardiologia.OBJ;
using Cardiologia.DAL;
using Ciencia.OBJ;
using Ciencia.DAL;
using System.Windows.Forms;
using System.Reflection;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Ciencia.BLL.ICBA_Cirugia_2003DataSetTableAdapters;

namespace Ciencia.BLL
{
    public class MapeadorAntC
    {
        CarAntCManager ManagerDest = new CarAntCManager();
        AntecedentesCManager ManagerOrigen = new AntecedentesCManager();
        private EquivMAnager CarEquivManager = new EquivMAnager();

        public Boolean MapearAntecedentesC2(ProgressBar p)
        {
            DataTable dt;
            var entry = ConfigurationManager.ConnectionStrings["ICBA.Properties.Settings.ConnStr"];
            SqlConnection con = new SqlConnection(entry.ConnectionString);
            CienciaCarAntCTableAdapter daDest = new CienciaCarAntCTableAdapter();
            SqlDataAdapter daOrg = new SqlDataAdapter("select * from Car_AntC_New", con);
            DataTable dtOrg = new DataTable();
            ICBA_Cirugia_2003DataSet.CienciaCarAntCDataTable dtDes = new ICBA_Cirugia_2003DataSet.CienciaCarAntCDataTable();
            CienciaCarEquiv equiv = new CienciaCarEquiv();
            CienciaEquivManager EqMan = new CienciaEquivManager();
            int i = 0;
            daOrg.Fill(dtOrg);
            //daDest.InsertCommand =
            //    new SqlCommand(
            //        "INSERT INTO [cirugia].[Ciencia_Car_Ingr] ([Ingr_Id], [Ingr_Ctro_D], [Ingr_Pac_Id], [Ingr_F], [Ingr_Diagnostico_D], [Ingr_SubDiag_D], [Ingr_Sintoma_D], [Ingr_DolorPreCord_B], [Ingr_Disnea_B], [Ingr_Sincope_B], [Ingr_Palpitac_B], [Ingr_Cansancio_B], [Ingr_Fiebre_B], [Ingr_Cefalea_B], [Ingr_Neurolog_B], [Ingr_Hematoma_B], [Ingr_OtroSintoma_B], [Ingr_Derivado_D], [Ingr_HTA_D], [Ingr_DLP_D], [Ingr_TBQ_D], [Ingr_DBT_D], [Ingr_AHF_B], [Ingr_FRCV_B], [Ingr_FEVI_N], [Ingr_DisfSist_D], [Ingr_CF_Habit_D], [Ingr_Timi_N], [Ingr_Grace_N], [Ingr_Crusade_N], [Ingr_Estado_N], [Ingr_Alta_F], [Ingr_Alta_Obito_D], [Ingr_Pase_M]) VALUES (@Ingr_Id, @Ingr_Ctro_D, @Ingr_Pac_Id, @Ingr_F, @Ingr_Diagnostico_D, @Ingr_SubDiag_D, @Ingr_Sintoma_D, @Ingr_DolorPreCord_B, @Ingr_Disnea_B, @Ingr_Sincope_B, @Ingr_Palpitac_B, @Ingr_Cansancio_B, @Ingr_Fiebre_B, @Ingr_Cefalea_B, @Ingr_Neurolog_B, @Ingr_Hematoma_B, @Ingr_OtroSintoma_B, @Ingr_Derivado_D, @Ingr_HTA_D, @Ingr_DLP_D, @Ingr_TBQ_D, @Ingr_DBT_D, @Ingr_AHF_B, @Ingr_FRCV_B, @Ingr_FEVI_N, @Ingr_DisfSist_D, @Ingr_CF_Habit_D, @Ingr_Timi_N, @Ingr_Grace_N, @Ingr_Crusade_N, @Ingr_Estado_N, @Ingr_Alta_F, @Ingr_Alta_Obito_D, @Ingr_Pase_M)");

            string campoDest;
            foreach (DataRow filaOrg in dtOrg.Rows)
            {
                DataRow filaDest = dtDes.NewRow();
                foreach (DataColumn columna in dtOrg.Columns)
                {
                    equiv = EqMan.ObtenerPorOrigen(columna.ColumnName);
                    if (equiv == null)
                        continue;
                    campoDest = equiv.CampoEquivalente.Trim();
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
                            filaDest[campoDest] = ((DateTime)valor).ToShortDateString();
                        else if (columna.DataType == typeof(Boolean) || columna.DataType == typeof(Boolean?))
                            filaDest[campoDest] = (Boolean)valor == false ? "N" : "S";
                        else if (columna.DataType == typeof(String))
                            filaDest[campoDest] = valor.ToString().Trim();
                        else
                            filaDest[campoDest] = valor;
                    }
                    else
                    {
                        String s = ObtenerEquivalente(equiv.Filtro.Trim(), valor);
                        if (s == null)
                            filaDest[campoDest] = equiv.ValorPorDefecto.Trim();
                        else
                            filaDest[campoDest] = s.Trim();
                    }

                }
                dtDes.Rows.Add(filaDest);
                i++;
                p.Maximum = 3000;
                p.Value = i;

            }
            //daDest.InsertCommand.Connection = con;
            daDest.Update(dtDes);

            return false;    
        }
        public Boolean MapearAntecedentesC(ProgressBar p)
        {
            List<clsAntecedentesC> ListaOrigen;
            List<CienciaCarAntC> ListaDestino = new List<CienciaCarAntC>();
            int i = 0;
            try
            {
                ListaOrigen = ManagerOrigen.Seleccionar("", "", "");
                foreach (clsAntecedentesC org in ListaOrigen)
                {
                    CienciaCarAntC dest = new CienciaCarAntC();
                    MapearObjetos(dest, org);
                    ManagerDest.Insertar(dest);
                    //ListaDestino.Add(dest);
                    i++;
                    p.Value = i;
                }

                return true;
            }
            catch (Exception ex)
            {
                Utiles.WriteErrorLog("Error en MapearAntecedentesC: " + ex.Message);
                return false;
            }
        }

        private void MapearObjetos(CienciaCarAntC dest, clsAntecedentesC org)
        {
            Type tipo = org.GetType();
            IList<PropertyInfo> campos = new List<PropertyInfo>(tipo.GetProperties());
            CienciaCarEquiv equiv = new CienciaCarEquiv();
            CienciaEquivManager EqMan = new CienciaEquivManager();
            //List<PropertyInfo> camposDest = new List<PropertyInfo>(dest.GetType().GetProperties());
            PropertyInfo campoDest;
            Type tipoDest = dest.GetType();
            String s;
            try
            {
                foreach (PropertyInfo campoOrg in campos)
                {
                    equiv = EqMan.ObtenerPorOrigen(campoOrg.Name);
                    if (equiv == null)
                        continue;
                    //if(campoOrg.Name == "Ingr_Sint_DolPreCord_B") 
                    //     throw new Exception();
                    campoDest = tipoDest.GetProperty(equiv.CampoEquivalente.Trim());
                    if (campoDest == null)
                        throw new Exception();
                    //if (campoDest.Name == "Ingr_Derivado_D")
                    //    throw new Exception();
                    var valor = campoOrg.GetValue(org, null);
                    if (valor == null)
                    {
                        campoDest.SetValue(dest, equiv.ValorPorDefecto);
                        continue;
                    }
                    if (equiv.Filtro == null)
                    {
                        if (campoOrg.PropertyType == typeof(DateTime) || campoOrg.PropertyType == typeof(DateTime?))
                            campoDest.SetValue(dest, ((DateTime)valor).ToShortDateString());
                        else if (campoOrg.PropertyType == typeof(Boolean) || campoOrg.PropertyType == typeof(Boolean?))
                            campoDest.SetValue(dest, (Boolean)valor == false ? "N" : "S");
                        else
                            campoDest.SetValue(dest, valor);
                    }
                    else
                    {
                        s = ObtenerEquivalente(equiv.Filtro.Trim(), valor);
                        if (s == null)
                        {
                            campoDest.SetValue(dest, equiv.ValorPorDefecto);
                        }
                        else
                            campoDest.SetValue(dest, s);
                    }

                }
            }
            catch (Exception ex)
            {
                Utiles.WriteErrorLog("");
            }


            //MapearCampo(org.Ingr_Ctro_D, des);


        }

        private string ObtenerEquivalente(string filtro, object valor)
        {
            String Where = "Eqv_Tit= '" + filtro + "' and Eqv_Val = " + valor;
            List<clsCarEquiv> lista = CarEquivManager.Seleccionar(Where, "");
            if (lista.Count == 0)
                return null;
            if (lista.Count > 1)
            {
                throw new Exception("En MapeadorIngresos.ObtenerEquivalente. Se encontró mas de un registro que cumple la condición");
            }
            return lista.First<clsCarEquiv>().Eqv_Desc;
        }

    }
}
