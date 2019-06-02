using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Ciencia.OBJ;
using Ciencia.DAL;
//using Cardiologia.OBJ;
//using Cardiologia.DAL;

namespace Ciencia.BLL
{
    class EvolPrimeraCar
    {
        public void ActualizarTabla()
        {
            InsertarNuevosRegistros();
            ActualizarRegistros();
        }
        private void InsertarNuevosRegistros()
        {
            var data = new EvolPrimeraCarData();
            data.InsertarNuevosRegistros();
        }
        private void ActualizarRegistros()
        {
            car_evol1Manager man = new car_evol1Manager();
            var lista = man.Seleccionar("", "");
            int i = 0;
            foreach (Car_evol_1 reg in lista)
            {
                ActualizarRegistro(reg);
                man.Update(reg);
                i++;
            }
        }
        CienciaEquivManager man = new CienciaEquivManager();
        List<PropertyInfo> campos = typeof(Car_evol_1).GetProperties().ToList();
        private void ActualizarRegistro(Car_evol_1 regDes)
        {
            //List<clsEvolucion> listaEvol;
            //string where = string.Format("Evol_Ingr_Id = {0} ", regDes.Evol_Ingr_Id_1.ToString());
            //string order = "evol_f";
            //listaEvol = evolMan.Seleccionar(where, order);
            //CienciaEquiv ceCampo;
            //foreach (PropertyInfo campo in campos)
            //{
            //    ceCampo = ObtenerPorOrigen(campo.Name);
            //    if (ceCampo == null || ceCampo.TipoDeDato.ToLower() == "id")
            //    {
            //        //throw new Exception("campo no encontrado en ciencia equiv" + campo.Name);
            //        continue;
            //    }
            //    ActualizarCampo(listaEvol, campo, ceCampo, regDes);
            //}
        }
        List<CienciaEquiv> listaEquiv;
        public CienciaEquiv ObtenerPorOrigen(string campoOrg)
        {
            if(listaEquiv == null)
                listaEquiv = man.Seleccionar("tablaId =100", "", "");
            CienciaEquiv cd = listaEquiv.FirstOrDefault(x => x.CampoOriginal.Trim().ToLower() == campoOrg.Trim().ToLower());
            return cd;
        }

        EvolucionManager evolMan = new EvolucionManager();

        void ActualizarCampo(List<clsEvolucion> lista, PropertyInfo campo, CienciaEquiv ceCampo, Car_evol_1 regDes)
        {
            string nombre = campo.Name.Substring(0, campo.Name.Length - 2);
            PropertyInfo c = typeof(clsEvolucion).GetProperty(nombre);

            switch (ceCampo.TipoDeDato)
            {
                case "Tabla":
                    foreach (var obj in lista)
                    {
                        object v = c.GetValue(obj);
                        if (v != null)
                        {
                            short valor = Convert.ToInt16(v);
                            if (valor != 0 && valor != 1)
                            {
                                campo.SetValue(regDes, valor);
                                break;
                            }
                        }
                    }
                    break;
                case "NoSi":
                    foreach (var obj in lista)
                    {
                        object v = c.GetValue(obj);
                        if (v != null)
                        {
                            bool valor = Convert.ToBoolean(v);
                            if (valor == true)
                            {
                                campo.SetValue(regDes, valor);
                                break;
                            }
                        }
                    }
                    break;
                default:
                    foreach (var obj in lista)
                    {
                        object v = c.GetValue(obj);
                        if (v != null)
                        {
                            campo.SetValue(regDes, v);
                            break;
                        }
                    }
                    break;
            }
        }


    }



}
