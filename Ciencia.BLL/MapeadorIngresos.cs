using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;
using System.Reflection;
using Ciencia.OBJ;
using Ciencia.DAL;
using Cardiologia.OBJ;
using Cardiologia.DAL;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using Ciencia.BLL.ICBA_Cirugia_2003DataSetTableAdapters;


namespace Ciencia.BLL
{
    public class MapeadorIngresos
    {
        readonly CarIngrManager ManagerDest = new CarIngrManager();
        readonly IngresoManager ManagerOrigen = new IngresoManager();
        readonly EquivMAnager CarEquivManager = new EquivMAnager();
        

        public Boolean MapearIngresos2(ProgressBar p)
        {
            DataTable dt;
            var entry = ConfigurationManager.ConnectionStrings["ICBA.Properties.Settings.ConnStr"];
            SqlConnection con = new SqlConnection(entry.ConnectionString);
            Ciencia_Car_IngrTableAdapter daDest = new Ciencia_Car_IngrTableAdapter();
            SqlDataAdapter daOrg = new SqlDataAdapter("select * from Car_Ingr_New",con);
            DataTable dtOrg = new DataTable();
            ICBA_Cirugia_2003DataSet.Ciencia_Car_IngrDataTable dtDes = new ICBA_Cirugia_2003DataSet.Ciencia_Car_IngrDataTable();
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
                            filaDest[campoDest] = equiv.ValorPorDefecto;
                        continue;
                    }
                    if (equiv.Filtro == null)
                    {
                        if (columna.DataType== typeof(DateTime) || columna.DataType == typeof(DateTime?))
                            filaDest[campoDest] =((DateTime)valor).ToShortDateString();
                        else if (columna.DataType == typeof(Boolean) || columna.DataType == typeof(Boolean?))
                            filaDest[campoDest] = (Boolean)valor == false ? "N" : "S";
                        else
                            filaDest[campoDest] = valor;
                    }
                    else
                    {
                        String s = ObtenerEquivalente(equiv.Filtro.Trim(), valor);
                        if(s == null)
                            filaDest[campoDest] = equiv.ValorPorDefecto;
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
        public Boolean MapearIngresos(ProgressBar p)
        {
            List<clsIngreso> ListaOrigen;
            List<Ciencia_Car_Ingr> ListaDestino = new List<Ciencia_Car_Ingr>();
            int i = 0;
            try
            {
                ListaOrigen = ManagerOrigen.Seleccionar("", "", "");
                foreach (clsIngreso org in ListaOrigen)
                {
                    Ciencia_Car_Ingr dest = new Ciencia_Car_Ingr();
                    MapearObjetos(dest, org);
                    ManagerDest.Insertar(dest);
                    //ListaDestino.Add(dest);
                    i++;
                    p.Value = i;
                }

                return true;
            }
            catch( Exception ex)
            {
                Utiles.WriteErrorLog("Error en MapearIngresos: " + ex.Message);
                return false;
            }
        }

        private void MapearObjetos(Ciencia_Car_Ingr dest, clsIngreso org)
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
                        return;
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
                        campoDest.SetValue(dest, s ?? equiv.ValorPorDefecto);
                    }

                }
            }
            catch(Exception ex)
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
