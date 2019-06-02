using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ciencia.OBJ;
using Generales;

namespace Ciencia.DAL
{
    public class SegAnualHemoMananger
    {
        private PetaPoco.Database _db = new PetaPoco.Database("Au.Properties.Settings.conStrCiencia");

        public bool BorrarTodo()
        {
            try
            {
                string query = "DELETE from SeguimientoAnualHemodinamia";
                _db.Execute(query);
                return true;
            }
            catch(Exception ex)
            {
                Utiles.WriteErrorLog("Error en SegAnualHemoMananger.BorrarTodo " + ex.Message);
                return false;
            }
        }
        public bool Modificar(SeguimientoAnualHemodinamia obj)
        {
            try
            {
                _db.Update(obj);
                return true;
            }
            catch (Exception ex)
            {
                Utiles.WriteErrorLog("Error en SegAnualHemoMananger.Modificar " + ex.Message);
                return false;
            }

        }
        public bool InsertarPacientes(string where)
        {
            try
            {
                string query = "INSERT INTO SeguimientoAnualHemodinamia(PacId, Pac_ApeNom, Obito_sino, Obito_fecha) " +
                               "SELECT distinct Ciencia_Hemo_Evol.Sgmt_pac_Id, Pac_ApeNo, Pac_Obito_T, Pac_Obito_F  FROM " +
                               "Ciencia_Hemo inner join Ciencia_Hemo_Evol  on " +
                               "Ciencia_Hemo.Pac_Id = Ciencia_Hemo_Evol.Sgmt_Pac_Id ";
                if(!string.IsNullOrEmpty(where))
                {
                    query += string.Format("where {0}", where);
                }
                _db.Execute(query);
                return true;
            }
            catch(Exception ex)
            {
                Utiles.WriteErrorLog("Error en SegAnualHemoMananger.InsertarPacientes " + ex.Message);
                return false;
            }
        }
        public SeguimientoAnualHemodinamia ObtenerPorPaciente(int pacId)
        {
            try
            {
                return (_db.SingleOrDefault<SeguimientoAnualHemodinamia>(pacId));
                //return null;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        public List<SeguimientoAnualHemodinamia> Seleccionar(string Where = null, string OrderBy = null)
        {
            List<SeguimientoAnualHemodinamia> lista;
            try
            {

                var sql = PetaPoco.Sql.Builder.Append("");

                if (!String.IsNullOrEmpty(Where))
                {
                    sql.Where(Where);
                }
                if (!String.IsNullOrEmpty(OrderBy))
                {
                    sql.OrderBy(OrderBy);
                }
                lista = _db.Fetch<SeguimientoAnualHemodinamia>(sql);
            }
            catch (Exception ex)
            {
                Utiles.WriteErrorLog("Error en SegAnualHemoMananger.Seleccionar " + ex.Message);
                lista = null;
            }
            return lista;
        }

    }
}
