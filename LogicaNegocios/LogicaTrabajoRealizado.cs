using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocios
{
    public static class LogicaTrabajoRealizado
    {

        public static string nuevo(int codigo_trabajo, int codigo_ingreso)
        {
            Entidades.TrabajoRealizado trabajo = new Entidades.TrabajoRealizado(codigo_trabajo, codigo_ingreso);
            return Datos.CRUDTrabajoRealizado.nuevo(trabajo);
        }

        public static Entidades.TrabajoRealizado buscar(int codtrabajo, int codingreso)
        {
            return Datos.CRUDTrabajoRealizado.buscar(codtrabajo, codingreso);
        }

        public static List<Entidades.Trabajo> trabajosPorIngreso(int codigo)
        {
            return Datos.CRUDTrabajoRealizado.trabajosPorIngreso(codigo);
        }
        
        public static string eliminar(int codtrabajo, int codingreso)
        {
            return Datos.CRUDTrabajoRealizado.eliminar(codtrabajo, codingreso);
        }
        
        public static string descripcion(Entidades.TrabajoRealizado t)
        {
            Entidades.Trabajo trabajo = LogicaTrabajo.buscar(t.Codigo_trabajo);
            return trabajo.Descripcion;
        }

        public static List<Entidades.TrabajoRealizado> trabajosRealizadosPorIngreso(int codigo)
        {
            return Datos.CRUDTrabajoRealizado.trabajosRealizadosPorIngreso(codigo);
        }



    }
}
