using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.OBJ;

namespace Ciencia
{
    public static class Seguridad
    {
        //static List<Permiso> _permisos;
        //static public List<Permiso> Permisos { get; set; }

        public static bool VerProcesoCiencia()
        {
            //if (Permisos.Find(x => x.Formulario_Id == 30) == null)
            //    return false;
            return true;
        }


        internal static bool VerSeguimientoAnualHemo()
        {
        //    if (Permisos.Find(x => x.Formulario_Id == 31) == null)
        //        return false;
            return true;
        }

        internal static bool VerSeguimientoMultiple()
        {
            //if (Permisos.Find(x => x.Formulario_Id == 32) == null)
            //    return false;
            return true;
        }
    }
}
