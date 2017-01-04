using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ciencia.BLL
{
    public class MantenimientoArchivos
    {
        public bool BorrarArchivos(string dir, List<string> Archivos)
        {
            try
            {

                foreach (string archivo in Archivos)
                {
                    
                    string path = string.Format("{0}{1}",dir, archivo);
                    if(System.IO.File.Exists(path))
                        System.IO.File.Delete(path);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

    }
}
