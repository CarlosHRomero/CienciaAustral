using System;
using System.Collections.Generic;
using System.Data;

namespace Ciencia.DAL
{
    public static class TipoDeDato
    {
        public static string ObtenerTipoDato(String tabla, String campo)
        {
            String sql = "select DATA_TYPE from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME= '" + tabla +
                         "' and COLUMN_NAME = '" + campo + "'";
            TDatos data = new TDatos("ICBA.Properties.Settings.conStrCiencia");
            return data.GetDataEscalar(sql, CommandType.Text).ToString();
            //return string.Empty;
        }
    }
}
