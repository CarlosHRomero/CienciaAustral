using System;
using System.Data;
using System.Threading;
using  System.Data.OleDb;
using System.Windows.Forms;
using  Generales;
using Ciencia.OBJ;


namespace Ciencia.DAL
{
    public static class CopiarLocal
    {
        public static string conString {get;set;}


        public static Boolean CopiaTablaLocal(string tabla, string where = "")
        {
            TDatosAccess.conStr = conString;

            string queryDes = "select * from " + tabla;
            string queryOrg = "select * from " + tabla;
            if (!string.IsNullOrEmpty(where))
                queryOrg = queryOrg + " where " + where;

            TDatos data = new TDatos("ICBA.Properties.Settings.conStr"); 
            string querydel = string.Format("delete from {0}", tabla);
            TDatosAccess.ExecuteQuery(querydel, CommandType.Text);
            Thread.Sleep(1000);
            DataTable dtOrg = data.ExecuteCmd(queryOrg, CommandType.Text);
            DataTable dtDes = TDatosAccess.ExecuteCmd(queryDes, CommandType.Text);
            int i = 0;
            foreach (DataRow row in dtOrg.Rows)
            {
                 
                DataRow rowDes = dtDes.NewRow();
                foreach (DataColumn column in dtOrg.Columns)
                {
                    rowDes[column.ColumnName] = row[column];
                }
                dtDes.Rows.Add(rowDes);
                i++;
            }
            TDatosAccess.UpdateTable(queryDes, dtDes);
            return true;
        }


    }
}
