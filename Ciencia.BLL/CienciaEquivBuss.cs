using Ciencia.DAL;
using Ciencia.OBJ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ciencia.BLL
{
    public class CienciaEquivBuss
    {
        CienciaEquivManager man = new CienciaEquivManager();

        public List<CienciaEquiv> ListaCampos(int tablaId)
        {
            return  man.ObtenerCamposPorTablaOrigen(tablaId);
        }
    }
}
