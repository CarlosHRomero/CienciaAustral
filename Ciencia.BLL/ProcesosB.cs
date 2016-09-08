using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cardiologia.DAL;
using  Ciencia.OBJ;
using  Ciencia.DAL;

namespace Ciencia.BLL
{
    public class ProcesosB
    {
        ProcesosManager _manager;
        private ProcesosManager Manager
        {
            get { return _manager ?? (_manager = new ProcesosManager()); }
        }

        public bool Insertar(Ciencia_Car_Procesos obj)
        {
            Boolean result;

            try
            {
                if (obj.ProcId == -1 )
                    return false;
                result = Manager.Insertar(obj) != null;
            }
            catch (Exception ex)
            {
                Utiles.WriteErrorLog("Error en ProcesosB.Insertar " + ex.Message);
                result = false;
            }
            return result;

        }
        public Ciencia_Car_Procesos ObtenerIngreso(int procId)
        {
            var obj = Manager.GetByID(procId.ToString());
            return obj;
        }

        public Boolean Modificar(Ciencia_Car_Procesos obj)
        {
            try
            {
                return Manager.Modificar(obj);
            }
            catch (Exception ex)
            {
                Utiles.WriteErrorLog("Error en IngresoBuss.Eliminar " + ex.Message);
                return false;
            }

        }

        public List<Ciencia_Car_Procesos> ObtenerProcesos()
        {
            try
            {
                var lstEPrev = Manager.Seleccionar("","","");
                return lstEPrev;
            }
            catch (Exception ex)
            {
                Utiles.WriteErrorLog("Error en ProcesosB.ObtenerProcesos " + ex.Message);
                return null;
            }
        }
    }
}
