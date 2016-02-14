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
            return Datos.CRUDProducto.nuevo(nuevo);
        }

        public static string editar(int codigo, string modelo, string tipo, double costo, int cantidad, bool baja)
        {
            Entidades.Producto nuevo = new Entidades.Producto(codigo, tipo, modelo, costo, cantidad, baja);
            return Datos.CRUDProducto.editar(nuevo);
        }

        public static List<Entidades.Producto> lista()
        {
            return Datos.CRUDProducto.lista();
        }
        
        public static int siguienteCodigo()
        {
            return Datos.CRUDProducto.siguienteCodigo();
        }

        public static Entidades.Producto buscarPorModelo(string modelo)
        {
            return Datos.CRUDProducto.buscarPorModelo(modelo);
        }

        public static Entidades.Producto buscarPorTipo(string tipo)
        {
            return Datos.CRUDProducto.buscarPorTipo(tipo);
        }

        public static List<Entidades.Producto> listaPorModelo(string modelo)
        {
            return Datos.CRUDProducto.listaPorModelo(modelo);
        }

        public static List<Entidades.Producto> listaPorTipo(string tipo)
        {
            return Datos.CRUDProducto.listaPorTipo(tipo);
        }

    }
}
