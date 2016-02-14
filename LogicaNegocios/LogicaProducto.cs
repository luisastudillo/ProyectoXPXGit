using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocios
{
    public static class LogicaProducto
    {
        public static string editar(Entidades.Producto p)
        {
            return Datos.CRUDProducto.editar(p);
        }

        public static Entidades.Producto buscar(int codigo)
        {
            return Datos.CRUDProducto.buscar(codigo);
        }

        public static string bajar(int codigo)
        {
            Entidades.Producto p = Datos.CRUDProducto.buscar(codigo);
            p.Baja = true;
            return Datos.CRUDProducto.editar(p);
        }

        public static string nuevo(int codigo, string modelo, string tipo, double costo, int cantidad)
        {
            Entidades.Producto nuevo = new Entidades.Producto(codigo, tipo, modelo, costo, cantidad, false);
            return Datos.CRUDProducto.editar(nuevo);
        }

        public static int siguienteCodigo()
        {
            return Datos.CRUDProducto.siguienteCodigo();
        }
    }
}
