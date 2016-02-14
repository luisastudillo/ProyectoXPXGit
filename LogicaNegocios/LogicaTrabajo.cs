using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocios
{
    public static class LogicaTrabajo
    {

        public static string nuevo(int codigo, string descripcion, decimal costo, bool baja)
        {
            Entidades.Trabajo trabajo = new Entidades.Trabajo(codigo, descripcion, costo, baja);
            return Datos.CRUDTrabajo.nuevo(trabajo);
        }

        public static string editar(int codigo, string descripcion, decimal costo, bool baja)
        {
            Entidades.Trabajo trabajo = new Entidades.Trabajo(codigo, descripcion, costo, baja);
            return Datos.CRUDTrabajo.editar(trabajo);
        }

        public static Entidades.Trabajo buscar(int codigo)
        {
            return Datos.CRUDTrabajo.buscar(codigo);
        }

        public static List<Entidades.Trabajo> lista()
        {
            return Datos.CRUDTrabajo.lista();
        }

        public static string bajar(int codigo)
        {
            Entidades.Trabajo trabajo = Datos.CRUDTrabajo.buscar(codigo);
            trabajo.Baja = true;
            return Datos.CRUDTrabajo.editar(trabajo); 
        }

        public static int siguienteCodigo()
        {
            return Datos.CRUDTrabajo.siguienteCodigo();
        }
    }
}
