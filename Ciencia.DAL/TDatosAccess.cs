using System;
using System.Data;
using System.Configuration;
using System.Text;
using System.Web;
using System.Data.SqlClient;
using System.Collections;
using System.Data.OleDb;
using System.IO;
using System.Net.Mime;
using Generales;


/// <summary>
/// Summary description for TDatos
/// </summary>
/// 
namespace Ciencia.DAL
{

    /* Esta clase se utiliza para acceder directamente los datos a traves de ADO
     * Contiene informacion de la  CONEXION a la BD
     * 
     * Autor:
     * Fecha Creacion:
     * Fecha Ult. Modificacion:
     * 
     */
    public  class TDatosAccess
    {
        private static string _strCon;
        public static string conStr
        {
            get { return _strCon; }
            set { _strCon = value; }
        }

        // Get the application configuration file.    

        public static string currentConectionString()
        {
            return conStr;
        }

        public static OleDbCommand GetSchema(string query, CommandType type, string StrConn)
        {

            OleDbConnection conec = new OleDbConnection(StrConn);
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandType = type;
            cmd.CommandText = query;
            cmd.Connection = conec;
            return cmd;
        }
        public static OleDbCommand GetSchema(string query)
        {
            return GetSchema(query, CommandType.Text, currentConectionString());
        }

        public static string NormalizeQueryString(string query)
        {
            //string Ret=TUtils.ReplaceStr("\\", "\\\\", query); //Esto es necesario en MYSQL porque no toma la barra \
            string Ret = query.Trim();
            return Ret;
        }


        public static DataTable GetDataNonQuery(string query, CommandType type, OleDbParameter[] listaParams, string StrConn)
        {
            OleDbCommand cmd = GetSchema(NormalizeQueryString(query), type, StrConn);

            for (int j = 0; j < listaParams.Length; j++)
                cmd.Parameters.Add(listaParams[j]);


            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            try
            {
                da.Fill(dt);
                if ((dt.Rows == null) && (query.IndexOf("SELECT") == 0))
                {
                    dt = null;
                }
            }

            catch (SqlException ex)
            {
                string error = ex.Message;
                Utiles.WriteErrorLog("Error de base de datos: " + error + "<br /><br />" + query);
                dt = null;
                //HttpContext.Current.Session["internalErrorMsg"] = "Error de base de datos: " + error + "<br /><br />" + query;
                //if (!String.IsNullOrEmpty(clsCtrlApplication.PageInternalError))
                //    HttpContext.Current.Response.Redirect(clsCtrlApplication.PageInternalError);
            }
            finally
            {
                cmd.Connection.Close();
            }
            return dt;
        }

        public static DataTable GetDataNonQuery(string query, CommandType type, string StrConn)
        {

            OleDbCommand cmd = GetSchema(NormalizeQueryString(query), type, StrConn);
            
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            try
            {
                da.Fill(dt);
                if ((dt.Rows == null) && (query.IndexOf("SELECT") == 0))
                {
                    dt = null;
                }

            }

            catch (SqlException ex)
            {
                string error = ex.Message;
                Utiles.WriteErrorLog("Error de base de datos: " + error + "<br /><br />" + query);
                dt = null;
                //HttpContext.Current.Session["internalErrorMsg"] = "Error de base de datos: " + error + "<br /><br />" + query;
                //if (!String.IsNullOrEmpty(clsCtrlApplication.PageInternalError))
                //    HttpContext.Current.Response.Redirect(clsCtrlApplication.PageInternalError);
            }
            finally
            {
                cmd.Connection.Close();
            }
            return dt;
        }

        public static DataTable GetDataNonQuery(string Query, OleDbParameter[] listaParams, string StrConn)
        {
            return GetDataNonQuery(Query, CommandType.Text, listaParams, StrConn);
        }

        public static DataTable GetDataNonQuery(string Query, String StrConn)
        {
            return GetDataNonQuery(Query, CommandType.Text, StrConn);
        }

        public static DataTable GetDataNonQuery(string query, CommandType type, OleDbParameter[] listaParams)
        {
            OleDbCommand cmd = GetSchema(NormalizeQueryString(query), type, currentConectionString());

            for (int j = 0; j < listaParams.Length; j++)
                cmd.Parameters.Add(listaParams[j]);

            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();

            try
            {
                da.Fill(dt);
                if ((dt.Rows == null) && (query.IndexOf("SELECT") == 0))
                {
                    dt = null;
                }
                //cmd.Connection.Open();
                //cmd.ExecuteNonQuery();           
                //cmd.Dispose();
            }
            catch (SqlException ex)
            {
                string error = ex.Message;
                Utiles.WriteErrorLog("Error de base de datos: " + error + "<br /><br />" + query);
                dt = null;
                //HttpContext.Current.Session["internalErrorMsg"] = "Error de base de datos: " + error + "<br /><br />" + query;
                //if (!string.IsNullOrEmpty(clsCtrlApplication.PageInternalError))
                //    HttpContext.Current.Response.Redirect(clsCtrlApplication.PageInternalError);
            }
            finally
            {
                cmd.Connection.Close();
            }
            return dt;
        }

        public static DataTable GetDataNonQuery(string query, OleDbParameter[] listaParams)
        {
            return GetDataNonQuery(query, CommandType.Text, listaParams);
        }        

        public static DataTable GetDataNonQuery(string query, CommandType type)
        {
            OleDbCommand cmd = GetSchema(NormalizeQueryString(query), type, currentConectionString());

            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();

            try
            {
                da.Fill(dt);
                if ((dt.Rows == null) && (query.IndexOf("SELECT") == 0))
                {
                    dt = null;
                }
                //cmd.Connection.Open();
                //cmd.ExecuteNonQuery();
                //cmd.Dispose();
            }
            catch (OleDbException ex)
            {
                string error = ex.Message;
                Utiles.WriteErrorLog("Error de base de datos: " + error + "<br /><br />" + query);
                dt = null;
                //HttpContext.Current.Session["internalErrorMsg"] = "Error de base de datos: " + error + "<br /><br />" + query;
                //if (!String.IsNullOrEmpty(clsCtrlApplication.PageInternalError))
                //    HttpContext.Current.Response.Redirect(clsCtrlApplication.PageInternalError);
            }
            finally
            {
                cmd.Connection.Close();
            }
            return dt;
        }

        public static DataTable GetDataNonQuery(string Query)
        {
            return GetDataNonQuery(Query, CommandType.Text);
        }

        


        public static Boolean ExecuteCmd(string query, CommandType type, OleDbParameter[] listaParams)
        {
            OleDbCommand cmd = GetSchema(NormalizeQueryString(query), type, currentConectionString());

            for (int j = 0; j < listaParams.Length; j++)
                cmd.Parameters.Add(listaParams[j]);

            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                return true;
            }

            catch (SqlException ex)
            {
                string error = ex.Message;
                Utiles.WriteErrorLog("Error de base de datos: " + error + "<br /><br />" + query);
                return false;
            }
        }

        public static DataTable ExecuteCmd(string query, CommandType type)
        {
            OleDbCommand cmd = GetSchema(NormalizeQueryString(query), type, currentConectionString());

            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();

            try
            {
                da.Fill(dt);
                if ((dt.Rows == null) && (query.IndexOf("SELECT") == 0))
                {
                    dt = null;
                }
                //cmd.Connection.Open();
                //cmd.ExecuteNonQuery();           
                //cmd.Dispose();
            }

            catch (SqlException ex)
            {
                string error = ex.Message;
                Utiles.WriteErrorLog("Error de base de datos: " + error + "<br /><br />" + query);
                dt = null;
                //HttpContext.Current.Session["internalErrorMsg"] = "Error de base de datos: " + error + "<br /><br />" + query;
                //if (!string.IsNullOrEmpty(clsCtrlApplication.PageInternalError))
                //    HttpContext.Current.Response.Redirect(clsCtrlApplication.PageInternalError);
            }
            finally
            {
                cmd.Connection.Close();
            }
            return dt;
        }        

        public static int ExecuteQuery(string query, CommandType type)
        {
            OleDbCommand cmd = GetSchema(NormalizeQueryString(query), type, currentConectionString());
            int ret = 0;
            try
            {
                cmd.Connection.Open();
                ret = cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                string error = ex.Message;
                Utiles.WriteErrorLog("Error de base de datos: " + error + "<br /><br />" + query);                
                //HttpContext.Current.Session["internalErrorMsg"] = "Error de base de datos: " + error + "<br /><br />" + query;
                //if (!string.IsNullOrEmpty(clsCtrlApplication.PageInternalError))
                //    HttpContext.Current.Response.Redirect(clsCtrlApplication.PageInternalError);
            }
            catch(Exception ex )
            {
                string error = ex.Message;
                Utiles.WriteErrorLog("Error: " + error + "<br /><br />");                

            }
            finally
            {
                cmd.Connection.Close();
                cmd.Dispose();
            }
            return ret;
        }

        public static int ExecuteQuery(string query, CommandType type, string conStr)
        {
            OleDbCommand cmd = GetSchema(NormalizeQueryString(query), type, conStr);
            int ret = 0;
            try
            {
                cmd.Connection.Open();
                ret = cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (SqlException ex)
            {
                string error = ex.Message;
                Utiles.WriteErrorLog("Error de base de datos: " + error + "<br /><br />" + query);
                //HttpContext.Current.Session["internalErrorMsg"] = "Error de base de datos: " + error + "<br /><br />" + query;
                //if (!string.IsNullOrEmpty(clsCtrlApplication.PageInternalError))
                //    HttpContext.Current.Response.Redirect(clsCtrlApplication.PageInternalError);
            }
            finally
            {
                cmd.Connection.Close();
            }
            return ret;
        }




        public static object GetDataEscalar(string query, CommandType type, OleDbParameter[] listaParams)
        {

            OleDbCommand cmd = GetSchema(NormalizeQueryString(query), type, currentConectionString());

            for (int j = 0; j < listaParams.Length; j++)
                cmd.Parameters.Add(listaParams[j]);

            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }

            catch (SqlException ex)
            {
                string error = ex.Message;
                Utiles.WriteErrorLog("Error de base de datos: " + error + "<br /><br />" + query);                
                //HttpContext.Current.Session["internalErrorMsg"] = "Error de base de datos: " + error + "<br /><br />" + query;
                //if (!string.IsNullOrEmpty(clsCtrlApplication.PageInternalError))
                //    HttpContext.Current.Response.Redirect(clsCtrlApplication.PageInternalError);
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Dispose();
            }
            return ((object)listaParams);
        }
        public static object GetDataEscalar(string query, CommandType type)
        {
            object respuesta;
            OleDbCommand cmd = GetSchema(NormalizeQueryString(query), type, currentConectionString());

            try
            {
                cmd.Connection.Open();
                respuesta = cmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                string error = ex.Message;
                respuesta = null;
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Dispose();
            }
            return (respuesta);
        }

        /// <summary>
        /// Executa y Obtiene el Valor de una Funcion 
        /// </summary>
        /// <param name="functionName"></param>
        /// <returns></returns>
        public static string GetFunctionData(string functionName)
        {
            OleDbCommand cmd = GetSchema(functionName, CommandType.StoredProcedure, currentConectionString());

            string ret = null;

            try
            {

                cmd.Parameters.Add("ret", OleDbType.VarChar, 4000).Direction = ParameterDirection.ReturnValue;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                ret = cmd.Parameters["ret"].Value.ToString();
            }
            catch (SqlException ex)
            {
                string error = ex.Message;
                Utiles.WriteErrorLog("Error de base de datos: " + error + "<br /><br />");
                ret = null;
                //HttpContext.Current.Session["internalErrorMsg"] = "Error de base de datos: " + error + "<br /><br />" + functionName;
                //if (!string.IsNullOrEmpty(clsCtrlApplication.PageInternalError))
                //    HttpContext.Current.Response.Redirect(clsCtrlApplication.PageInternalError);
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Dispose();
            }
            return ret;
        }

        /// <summary>
        /// Cuenta los Registros que hay en una tabla (NO INCLUIR WHERE)
        /// </summary>
        /// <param name="TableName"></param>
        /// <returns></returns>
        public static int CantidadRegistros(string TableName, string Condicion)
        {
            int ret = 0;
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT COUNT(*) TOTAL FROM " + TableName);
            if (Condicion.Trim() != "")
                sql.Append(" WHERE " + Condicion);
            DataTable Dt = GetDataNonQuery(sql.ToString(), CommandType.Text);
            if (Dt.Rows.Count == 1)
            {
                ret = Convert.ToInt32(Dt.Rows[0]["TOTAL"].ToString());
            }
            return ret;
        }

        public static bool TruncateTable(string TableName)
        {
            bool ret = false;

            string query = "DELETE " + TableName;

            OleDbCommand cmd = TDatosAccess.GetSchema(query, CommandType.Text, currentConectionString());

            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            try
            {
                da.Fill(dt);
                if ((dt.Rows == null) && (query.IndexOf("SELECT") == 0))
                {
                    dt = null;
                }
                ret = true;
            }
            catch (SqlException ex)
            {
                string error = ex.Message;
                ret = false;
                //HttpContext.Current.Session["internalErrorMsg"] = "Error de base de datos: " + error + "<br /><br />" + query;
                //HttpContext.Current.Response.Redirect("~/InternalError.aspx");
            }
            finally
            {
                cmd.Connection.Close();
            }
            return ret;
        }

        public static bool UpdateTable(string query, DataTable dt)
        {
            bool ret = false;
            OleDbCommand cmd = TDatosAccess.GetSchema(query, CommandType.Text, currentConectionString());

            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            try
            {
                OleDbCommandBuilder buid = new OleDbCommandBuilder(da);

                //da.InsertCommand = new OleDbCommand(query, con);
                if (da.Update(dt) > 0)
                    ret = true;
            }
            catch (SqlException ex)
            {
                string error = ex.Message;
                ret = false;
                //HttpContext.Current.Session["internalErrorMsg"] = "Error de base de datos: " + error + "<br /><br />" + query;
                //HttpContext.Current.Response.Redirect("~/InternalError.aspx");
            }
            finally
            {
                cmd.Connection.Close();
            }
            return ret;

        }
        public static Boolean DropTable(string tabla)
        {
            try
            {
                OleDbConnection conec = new OleDbConnection(_strCon);

                conec.Open();

                string query = "SELECT Name From Msysobjects WHERE Type = 1 AND Flags = 0 ORDER BY Name";
                DataTable dt = conec.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new Object[] { null, null, null, "TABLE" });
                if (dt.Select("Table_Name = '" + tabla+ "'").Length == 0)
                    return true;
                query = "Drop Table " + tabla;
                OleDbCommand cmd = new OleDbCommand(query, conec);
                cmd.ExecuteNonQuery();
                conec.Close();
                return true;
            }
            catch (OleDbException ex)
            {
                Utiles.WriteErrorLog(ex.Message);
                return false;
            }
        }

        public static Boolean ExisteTabla(string tabla)
        {
            OleDbConnection conec = new OleDbConnection(_strCon);
            conec.Open();

            //string query = "SELECT Name From Msysobjects WHERE Type = 1 AND Flags = 0 ORDER BY Name";
            DataTable dt = conec.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new Object[] { null, null, null, "TABLE" });
            if (dt.Select("Table_Name = '" + tabla + "'").Length == 0)
                return false;
            return true;


        }


        internal static Boolean AgregarCampo(string campo, string tabla, string TipoDeDato)
        {
            try
            {
                OleDbConnection conec = new OleDbConnection(_strCon);
                conec.Open();
                string query = "ALTER TABLE " + tabla +
                                " ADD " + campo + " " + TipoDeDato;
                OleDbCommand cmd = new OleDbCommand(query, conec);
                cmd.ExecuteNonQuery();
                conec.Close();
                return true;
            }
            catch (OleDbException ex)
            {
                Utiles.WriteErrorLog(ex.Message);
                return true;
            }

        }
        public static Boolean AgregarClavePrimaria(string campo, string tabla)
        {
            try
            {
                OleDbConnection conec = new OleDbConnection(_strCon);
                conec.Open();
                string query = "ALTER TABLE "+ tabla +" ALTER COLUMN "+ campo +" NUMERIC NOT NULL";
                OleDbCommand cmd = new OleDbCommand(query, conec);
                cmd.ExecuteNonQuery();
                query = "CREATE UNIQUE INDEX  PK_" + tabla +
                                " ON " + tabla + " (" + campo + ") WITH PRIMARY";
                cmd = new OleDbCommand(query, conec);
                cmd.ExecuteNonQuery();
                conec.Close();
                return true;
            }
            catch (OleDbException ex)
            {
                Utiles.WriteErrorLog(ex.Message);
                return true;
            }

        }

    }
}
