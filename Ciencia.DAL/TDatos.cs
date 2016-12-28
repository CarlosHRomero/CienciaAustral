using System;
using System.Data;
using System.Configuration;
using System.Text;
using System.Data.SqlClient;
using Generales;


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
    public class TDatos
    {

        //Database _db;

        //Database db
        //{
        //    get
        //    {
        //        if (db == null)
        //        {
        //            _db = new Database(currentConectionString());
        //        }
        //        return _db;
        //    }
        //}

        // Get the application configuration file.    

        private string _connStr = "";

        TDatos()
        {

        }

        public string ConnStr
        {
            set
            { _connStr = value; }
        }

        public TDatos(string constrName )
        {
            var entry = ConfigurationManager.ConnectionStrings[constrName];
            _connStr = entry.ConnectionString;
        }

        public string CurrentConectionString()
        {
            if (_connStr == "")
            {
                return null;
            }
            return _connStr;
        }

        public SqlCommand GetSchema(string query, CommandType type, string StrConn)
        {
            SqlConnection conec = new SqlConnection(StrConn);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = type,
                CommandText = query,
                Connection = conec
            };
            return cmd;
        }
        public SqlCommand GetSchema(string query)
        {
            return GetSchema(query, CommandType.Text, CurrentConectionString());
        }

        public string NormalizeQueryString(string query)
        {
            //string ret=TUtils.ReplaceStr("\\", "\\\\", query); //Esto es necesario en MYSQL porque no toma la barra \
            string ret = query.Trim();
            return ret;
        }

        public DataTable GetDataNonQuery(string query, CommandType type, SqlParameter[] listaParams, string StrConn)
        {
            SqlCommand cmd = GetSchema(NormalizeQueryString(query), type, StrConn);
            foreach (SqlParameter t in listaParams)
                cmd.Parameters.Add(t);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            try
            {
                da.Fill(dt);
                if ((dt.Rows == null) && (query.IndexOf("SELECT", StringComparison.Ordinal) == 0))
                {
                    dt = null;
                }
            }
            catch (SqlException ex)
            {
                string error = ex.Message;
                Utiles.WriteErrorLog("Error de base de datos: " + error + "<br /><br />" + query);
                dt = null;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return dt;
        }

        public DataTable GetDataNonQuery(string query, CommandType type, string StrConn)
        {
            SqlCommand cmd = GetSchema(NormalizeQueryString(query), type, StrConn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            try
            {
                da.Fill(dt);
                if ((dt.Rows == null) && (query.IndexOf("SELECT", StringComparison.Ordinal) == 0))
                {
                    dt = null;
                }
            }

            catch (SqlException ex)
            {
                string error = ex.Message;
                Utiles.WriteErrorLog("Error de base de datos: " + error + "<br /><br />" + query);
                dt = null;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return dt;
        }

        public DataTable GetDataNonQuery(string Query, SqlParameter[] listaParams, string StrConn)
        {
            return GetDataNonQuery(Query, CommandType.Text, listaParams, StrConn);
        }

        public DataTable GetDataNonQuery(string Query, String StrConn)
        {
            return GetDataNonQuery(Query, CommandType.Text, StrConn);
        }

        public DataTable GetDataNonQuery(string query, CommandType type, SqlParameter[] listaParams)
        {
            SqlCommand cmd = GetSchema(NormalizeQueryString(query), type, CurrentConectionString());
            foreach (SqlParameter t in listaParams)
                cmd.Parameters.Add(t);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            try
            {
                da.Fill(dt);
                if ((dt.Rows == null) && (query.IndexOf("SELECT", StringComparison.Ordinal) == 0))
                {
                    dt = null;
                }
            }
            catch (SqlException ex)
            {
                string error = ex.Message;
                Utiles.WriteErrorLog("Error de base de datos: " + error + "<br /><br />" + query);
                dt = null;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return dt;
        }

        public DataTable GetDataNonQuery(string query, SqlParameter[] listaParams)
        {
            return GetDataNonQuery(query, CommandType.Text, listaParams);
        }

        public DataTable GetDataNonQuery(string query, CommandType type)
        {
            SqlCommand cmd = GetSchema(NormalizeQueryString(query), type, CurrentConectionString());

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            try
            {
                da.Fill(dt);
                if ((dt.Rows == null) && (query.IndexOf("SELECT", StringComparison.Ordinal) == 0))
                {
                    dt = null;
                }
            }
            catch (SqlException ex)
            {
                string error = ex.Message;
                Utiles.WriteErrorLog("Error de base de datos: " + error + "<br /><br />" + query);
                dt = null;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return dt;
        }

        public DataTable GetDataNonQuery(string query)
        {
            return GetDataNonQuery(query, CommandType.Text);
        }

        public DataTable ExecuteCmd(string query, CommandType type, SqlParameter[] listaParams)
        {
            SqlCommand cmd = GetSchema(NormalizeQueryString(query), type, CurrentConectionString());

            foreach (SqlParameter t in listaParams)
                cmd.Parameters.Add(t);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            try
            {
                da.Fill(dt);
                if ((dt.Rows == null) && (query.IndexOf("SELECT", StringComparison.Ordinal) == 0))
                {
                    dt = null;
                }
            }

            catch (SqlException ex)
            {
                string error = ex.Message;
                Utiles.WriteErrorLog("Error de base de datos: " + error + "<br /><br />" + query);
                dt = null;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return dt;
        }

        public DataTable ExecuteCmd(string query, CommandType type)
        {
            SqlCommand cmd = GetSchema(NormalizeQueryString(query), type, CurrentConectionString());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            try
            {
                da.Fill(dt);
                if ((dt.Rows == null) && (query.IndexOf("SELECT", StringComparison.Ordinal) == 0))
                {
                    dt = null;
                }
            }

            catch (SqlException ex)
            {
                string error = ex.Message;
                Utiles.WriteErrorLog("Error de base de datos: " + error + "<br /><br />" + query);
                dt = null;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return dt;
        }

        public int ExecuteQuery(string query, CommandType type)
        {
            SqlCommand cmd = GetSchema(NormalizeQueryString(query), type, CurrentConectionString());
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
                throw;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return ret;
        }

        public int ExecuteQuery(string query, CommandType type, string conStr)
        {
            SqlCommand cmd = GetSchema(NormalizeQueryString(query), type, conStr);
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
            }
            finally
            {
                cmd.Connection.Close();
            }
            return ret;
        }

        public object GetDataEscalar(string query, CommandType type, SqlParameter[] listaParams)
        {
            SqlCommand cmd = GetSchema(NormalizeQueryString(query), type, CurrentConectionString());
            foreach (SqlParameter t in listaParams)
                cmd.Parameters.Add(t);
            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                string error = ex.Message;
                Utiles.WriteErrorLog("Error de base de datos: " + error + "<br /><br />" + query);
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Dispose();
            }
            return listaParams;
        }

        public object GetDataEscalar(string query, CommandType type)
        {
            object respuesta;
            SqlCommand cmd = GetSchema(NormalizeQueryString(query), type, CurrentConectionString());

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
            return respuesta;
        }

        /// <summary>
        /// Executa y Obtiene el Valor de una Funcion 
        /// </summary>
        /// <param name="functionName"></param>
        /// <returns></returns>
        public string GetFunctionData(string functionName)
        {
            SqlCommand cmd = GetSchema(functionName, CommandType.StoredProcedure, CurrentConectionString());
            string ret;
            try
            {
                cmd.Parameters.Add("ret", SqlDbType.Text, 4000).Direction = ParameterDirection.ReturnValue;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                ret = cmd.Parameters["ret"].Value.ToString();
            }
            catch (SqlException ex)
            {
                string error = ex.Message;
                Utiles.WriteErrorLog("Error de base de datos: " + error + "<br /><br />");
                ret = null;
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
        /// <param name="tableName"></param>
        /// <param name="condicion"></param>
        /// <returns></returns>
        public int CantidadRegistros(string tableName, string condicion)
        {
            int ret = 0;
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT COUNT(*) TOTAL FROM " + tableName);
            if (condicion.Trim() != "")
                sql.Append(" WHERE " + condicion);
            DataTable Dt = GetDataNonQuery(sql.ToString(), CommandType.Text);
            if (Dt.Rows.Count == 1)
            {
                ret = Convert.ToInt32(Dt.Rows[0]["TOTAL"].ToString());
            }
            return ret;
        }

        //public bool TruncateTable(string TableName)
        //{
        //    bool ret = false;

        //    string query = "DELETE " + TableName;

         //   SqlCommand cmd = TDatos.GetSchema(query, CommandType.Text, currentConectionString());

        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        da.Fill(dt);
        //        if ((dt.Rows == null) && (query.IndexOf("SELECT") == 0))
        //        {
        //            dt = null;
        //        }
        //        ret = true;
        //    }
        //    catch (SqlException ex)
        //    {
        //        string error = ex.Message;
        //        ret = false;
        //        //HttpContext.Current.Session["internalErrorMsg"] = "Error de base de datos: " + error + "<br /><br />" + query;
        //        //HttpContext.Current.Response.Redirect("~/InternalError.aspx");
        //    }
        //    finally
        //    {
        //        cmd.Connection.Close();
        //    }
        //    return ret;
        //}

        internal bool UpdateTable(string query, DataTable dt)
        {
            bool ret = false;
            SqlCommand cmd = GetSchema(query, CommandType.Text, CurrentConectionString());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                SqlCommandBuilder buid = new SqlCommandBuilder(da);
                if (da.Update(dt) > 0)
                    ret = true;
            }
            catch (SqlException ex)
            {
                string error = ex.Message;
                ret = false;
                Generales.Utiles.WriteErrorLog("Error en TDatos.UpdateTable: " + ex.Message);
            }
            finally
            {
                cmd.Connection.Close();
            }
            return ret;
        }

        internal bool UpdateTable(string query, DataSet ds)
        {
            bool ret = false;
            SqlCommand cmd = GetSchema(query, CommandType.Text, CurrentConectionString());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                SqlCommandBuilder buid = new SqlCommandBuilder(da);
                if (da.Update(ds) > 0)
                    ret = true;
            }
            catch (SqlException ex)
            {
                string error = ex.Message;
                ret = false;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return ret;
        }

        public Boolean AgregarClavePrimaria(string campo, string tabla)
        {
            try
            {
                SqlConnection conec = new SqlConnection(CurrentConectionString());
                conec.Open();
                string query = "ALTER TABLE " + tabla + " ALTER COLUMN " + campo + " INT NOT NULL";
                SqlCommand cmd = new SqlCommand(query, conec);
                cmd.ExecuteNonQuery();
                query = "ALTER TABLE " + tabla +
                                " ADD CONSTRAINT PK_" + tabla + " PRIMARY KEY (" + campo + ")";
                cmd = new SqlCommand(query, conec);
                cmd.ExecuteNonQuery();
                conec.Close();
                return true;
            }
            catch (SqlException ex)
            {
                Utiles.WriteErrorLog(ex.Message);
                return true;
            }
        }

        public string CrearVista(string nombre, string query)
        {
            try
            {
                var view = nombre;
                string s = string.Format("IF OBJECT_ID ('{0}', 'V') IS NOT NULL DROP VIEW {0}", view);
                ExecuteQuery(s, CommandType.Text);
                query = string.Format("Create View {0} as {1} ", view, query);
                ExecuteCmd(query, CommandType.Text);
                return view;
            }
            catch (Exception ex)
            {
                Utiles.WriteErrorLog("Error en CrearVista: " + ex.Message);
                return null;
            }
        }
        public  bool BorrarTabla(string tabla)
        {
            try
            {
                string s = string.Format("IF OBJECT_ID ('{0}', 'U') IS NOT NULL DROP TABLE {0}", tabla);
                ExecuteQuery(s, CommandType.Text);
                return true;
            }
            catch( Exception ex)
            {
                Utiles.WriteErrorLog(ex.Message);
                return false;
            }
        }

    }
}
