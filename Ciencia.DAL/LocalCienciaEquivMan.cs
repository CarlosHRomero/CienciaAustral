﻿using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.OleDb;
using  System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Ciencia.OBJ;
using Generales;

namespace Ciencia.DAL
{
    public class LocalCienciaEquivMan
    {
        private string conStr;

        public LocalCienciaEquivMan(string constr)
        {
            conStr = constr;
        }
        public List<CienciaEquiv> ListarCampos(int TablaId)
        {
            try
            {
   
                string query = "SELECT * FROM CienciaCarEquiv WHERE TablaId = @0";

                OleDbParameter[] param = new OleDbParameter[1];
                param[0] = new OleDbParameter("@0", TablaId);
                
                DataTable dt = TDatosAccess.GetDataNonQuery(query, CommandType.Text, param, conStr);
                /*OleDbConnection conec = new OleDbConnection(conStr);
                OleDbCommand cmd = new OleDbCommand(query, conec);*/
                
                List<CienciaEquiv> lista = new List<CienciaEquiv>();

                foreach (DataRow row in dt.Rows)
                {
                    CienciaEquiv obj = new CienciaEquiv();
                    obj.TablaId = Convert.ToInt32(row["TablaId"]);
                    obj.CampoOriginal = row["CampoOriginal"].ToString();
                    obj.CampoEquivalente = row["CampoEquivalente"].ToString();
                    obj.TipoDeDato = row["TipoDeDato"].ToString();
                    obj.Filtro = row["Filtro"].ToString();
                    obj.ValorPorDefecto = row["ValorPorDefecto"].ToString();
                    lista.Add(obj);
                }
                return lista;

            }
            catch (Exception ex)
            {
                Utiles.WriteErrorLog("Error en localCarEquivMan: "+ex.Message);
                throw;
            }
        }
        public List<CienciaEquiv> ListarCamposPorModuloEvolucion(int moduloId, bool esEvolucion)
        {
            try
            {
                //string query = "SELECT * FROM CienciaCarEquiv where TablaId <> 6";
                string query = "select CienciaEquiv.* from CienciaEquiv, CienciaTablaEquiv where " +
                            "CienciaEquiv.TablaId=CienciaTablaEquiv.TablaId and CienciaTablaEquiv.ModuloId = @0 and esEvolucion = @1 " +
                            "order by CienciaEquiv.EquivId";
                OleDbParameter[] param = new OleDbParameter[2];
                param[0] = new OleDbParameter("@0",moduloId);
                param[1] = new OleDbParameter("@1", esEvolucion);

                DataTable dt = TDatosAccess.GetDataNonQuery(query, CommandType.Text, param, conStr);
                /*OleDbConnection conec = new OleDbConnection(conStr);
                OleDbCommand cmd = new OleDbCommand(query, conec);*/

                List<CienciaEquiv> lista = new List<CienciaEquiv>();

                foreach (DataRow row in dt.Rows)
                {
                    CienciaEquiv obj = new CienciaEquiv();
                    obj.EquivId = Convert.ToInt32(row["EquivId"]);
                    obj.TablaId = Convert.ToInt32(row["TablaId"]);
                    obj.CampoOriginal = row["CampoOriginal"].ToString();
                    obj.CampoEquivalente = row["CampoEquivalente"].ToString();
                    obj.TipoDeDato = row["TipoDeDato"].ToString();
                    obj.Filtro = row["Filtro"].ToString();
                    obj.ValorPorDefecto = row["ValorPorDefecto"].ToString();
                    obj.Seleccion = Convert.ToBoolean(row["Seleccion"]);
                    obj.ValoresACero = row["ValoresACero"].ToString();
                    obj.Solapa = row["Solapa"].ToString();
                    lista.Add(obj);
                }
                return lista;

            }
            catch (Exception ex)
            {
                Utiles.WriteErrorLog("Error en localCarEquivMan: " + ex.Message);
                throw;
            }
        }

        public List<CienciaEquiv> ListarCamposEvolución()
        {
            try
            {
                string query = "SELECT * FROM CienciaCarEquiv where TablaId = 6";

                OleDbParameter[] param = new OleDbParameter[1];
                //param[0] = new OleDbParameter("@0", TablaId);

                DataTable dt = TDatosAccess.GetDataNonQuery(query, CommandType.Text, conStr);
                /*OleDbConnection conec = new OleDbConnection(conStr);
                OleDbCommand cmd = new OleDbCommand(query, conec);*/

                List<CienciaEquiv> lista = new List<CienciaEquiv>();

                foreach (DataRow row in dt.Rows)
                {
                    CienciaEquiv obj = new CienciaEquiv();
                    obj.EquivId = Convert.ToInt32(row["EquivId"]);
                    obj.TablaId = Convert.ToInt32(row["TablaId"]);
                    obj.CampoOriginal = row["CampoOriginal"].ToString();
                    obj.CampoEquivalente = row["CampoEquivalente"].ToString();
                    obj.TipoDeDato = row["TipoDeDato"].ToString();
                    obj.Filtro = row["Filtro"].ToString();
                    obj.ValorPorDefecto = row["ValorPorDefecto"].ToString();
                    obj.Seleccion = Convert.ToBoolean(row["Seleccion"]);
                    obj.ValoresACero = row["ValoresACero"].ToString();
                    lista.Add(obj);
                }
                return lista;

            }
            catch (Exception ex)
            {
                Utiles.WriteErrorLog("Error en localCarEquivMan: " + ex.Message);
                throw;
            }
        }

        OleDbConnection _conec;
        public Boolean Modificar(CienciaEquiv obj)
        {
            try
            {
                string query = "Update CienciaEquiv Set  Seleccion = @0, " +
                               "ValoresACero = @1 where EquivId = @2";

                //TDatosAccess.ExecuteCmd(query, CommandType.Text, )
                if(_conec == null)
                    _conec = new OleDbConnection(conStr);

                OleDbCommand cmd = new OleDbCommand(query, _conec);

                OleDbParameter param = new OleDbParameter();
                //param = new OleDbParameter("@0", );
                cmd.Parameters.AddWithValue("@0",obj.Seleccion);
                if(obj.ValoresACero != null)
                    param = new OleDbParameter("@1", obj.ValoresACero);
                else
                    param = new OleDbParameter("@1", DBNull.Value);
                cmd.Parameters.Add(param);
                //param = new OleDbParameter("@2", );
                cmd.Parameters.AddWithValue("@2", obj.EquivId);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return true;

            }
            catch (Exception ex)
            {
                Utiles.WriteErrorLog(ex.Message);
                return false;
            }

        }


        public void ModificarLista(List<CienciaEquiv> lista)
        {
            string query = "select * from CienciaEquiv";
            TDatosAccess.conStr = conStr;
            DataTable dt = TDatosAccess.GetDataNonQuery(query);
            dt.PrimaryKey = new DataColumn[] {dt.Columns["EquivId"]};
            foreach(CienciaEquiv obj in lista)
            {
                DataRow row = dt.Rows.Find(obj.EquivId);
                row["Seleccion"] = obj.Seleccion;
                row["ValoresACero"] = obj.ValoresACero;
            }
            TDatosAccess.UpdateTable(query, dt);
        }
    }
}
