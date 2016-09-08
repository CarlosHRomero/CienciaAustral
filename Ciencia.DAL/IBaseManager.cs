using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ciencia.DAL
{
        interface IBaseManager<T>
        {
            T GetByID(string Cod);

            //Devuelve una lista de elementos de Clase T recortados por clausula Where y Ordenados por Order By
            List<T> Seleccionar(string Where, string OrderBy, string Limit);

            //Inserta un Objeto de Clase T
            T Insertar(T Obj);

            //Modifica un Objeto de Clase T
            Boolean Modificar(T Obj);

            //Elimina un Objeto de Clase T
            Boolean Eliminar(T Obj);

            //Elimina un Objeto de Clase T por su ID
            Boolean Eliminar(string Cod);
    }
}
