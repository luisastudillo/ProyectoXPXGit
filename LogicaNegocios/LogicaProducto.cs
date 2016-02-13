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

    }
}
