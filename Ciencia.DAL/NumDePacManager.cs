using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using  Ciencia.OBJ;
using Generales;

namespace Ciencia.DAL
{
    public class NumDePacManager
    {
        private string conStr;

        public NumDePacManager(string constr)
        {
            conStr = constr;
        }
        public List<NumDePac> CalcularNumDePac(string tablas, string where, string campo, string filtro, string TipoDeDato, string TablaEquiv)
        {
            //TablaEquiv Contiene la  tabla de equivalencias del modulo determinado
            List<NumDePac> lista= new List<NumDePac>();
            AdmEquivMan man = new AdmEquivMan();
            try
            {
                string campoext = campo;
                string query;
                //query = string.Format("SELECT  Eqv_Val, Eqv_Desc FROM {0} WHERE Eqv_Tit = {1} ORDER BY EQV_ORD", TablaEquiv, filtro.Trim());
              
                DataTable dt;
                TDatos dataCiencia = new TDatos("Au.Properties.Settings.conStrCiencia");
                switch (TipoDeDato)
                {
                    case "Tabla":
                        query = string.Format("SELECT DISTINCT {0}, COUNT(*) as cant FROM {1} where {2}  GROUP BY {0}", campoext, tablas, where); 
                        dt = dataCiencia.GetDataNonQuery(query);
                        

                        foreach (DataRow row  in dt.Rows)
                        {
                            NumDePac obj = new NumDePac();
                            obj.Equivalencia = row[campo].ToString();
                            obj.Cant = Convert.ToInt32(row["cant"]);
                            AdmEquiv val;
                            if ((val = man.traerValor(TablaEquiv, filtro, obj.Equivalencia)) != null) 
                            {
                                obj.Valor = Convert.ToInt32(val.Eqv_Val);
                                obj.Ord = Convert.ToInt32(val.Eqv_ord);
                            }
                            lista.Add(obj);
                        }
                        break;

                    default:
                        query = "SELECT " + campoext + ", COUNT(*) as cant FROM " + tablas + " GROUP BY " + campoext;
                        dt = dataCiencia.GetDataNonQuery(query);
                        foreach (DataRow row in dt.Rows)
                        {
                            NumDePac obj = new NumDePac();
                            obj.Equivalencia = row[campo].ToString();
                            obj.Cant = Convert.ToInt32(row["cant"]);
                            //obj.Valor = Convert.ToInt32(row["valor"]);
                            lista.Add(obj);
                        }
                        break;
                }
                return lista;
            }


            catch (Exception ex)
            {
                Utiles.WriteErrorLog("" + ex.Message);
                return null;
            }


        }
    }
}
