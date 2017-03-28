using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  Ciencia.OBJ;
using  Ciencia.DAL;



namespace Ciencia.BLL
{
    public class LocalEquivB
    {
        string _constr;

        public LocalEquivB(string constr )
        {
            _constr = constr;
            man =  new LocalCienciaEquivMan(_constr);
        }

      

        public List<CienciaEquiv> ListaTodosCampos(int moduloId, string constr, bool esEvolucion)
        {
            //LocalCienciaEquivMan man = new LocalCienciaEquivMan(constr);
            return (man.ListarCamposPorModuloEvolucion(moduloId, esEvolucion).Where(x=> x.TipoDeDato !=  "ID").ToList());
        }

        LocalCienciaEquivMan man;
        public Boolean ActualizarSelecciónCampo(CienciaEquiv obj)
        {
            
            return man.Modificar(obj);
        }

        private List<CienciaTablaEquiv> ListaTablas;
        
        List<AdmEquiv> listaEquiv;
       
        public List<CienciaEquiv> ListaCamposEvolucion(int moduloId, string localConStr)
        {
            return ListaTodosCampos(moduloId, localConStr, true);
        }

        public void ActualizarSelección(List<CienciaEquiv> lista)
        {
            man.ModificarLista(lista);
        }
    }
}
