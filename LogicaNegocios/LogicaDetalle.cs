using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocios
{
    public static class LogicaDetalle
    {
        public static List<Entidades.DetalleProducto> detallesPorFactura(int numero)
        {
            return Datos.CRUDDetalleProducto.detallesPorFactura(numero);
        }

        public static string nuevo(Entidades.DetalleProducto detalle)
        {
            return Datos.CRUDDetalleProducto.nuevo(detalle);
        }


        public static bool eliminar(Entidades.DetalleProducto detalle)
        {
            bool retorno = false;
            Entidades.Producto p = LogicaProducto.buscar(detalle.Cod_producto);
            p.Cantidad = p.Cantidad + detalle.Cantidad;
            string resultado = LogicaProducto.editar(p);
            if(resultado == "exito")
            {
                retorno = Datos.CRUDDetalleProducto.eliminar(detalle.Num_factura, detalle.Cod_producto);
            }

            return retorno;
        }

    }
}
