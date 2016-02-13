using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocios
{
    public static class LogicaFactura
    {
        public static List<Entidades.Ingreso> listaIngresos(int numero)
        {
            List<Entidades.Ingreso> retorno = new List<Entidades.Ingreso>();
            List<Entidades.Ingreso> lista = LogicaIngreso.listaIngresos();
            foreach(Entidades.Ingreso i in lista)
            {
                if (i.N_factura == numero)
                    retorno.Add(i);
            }
            return retorno;
        }

        public static List<Entidades.DetalleProducto> listaDetalles(int numero)
        {
            return Datos.CRUDDetalleProducto.detallesPorFactura(numero);
        }

        public static Entidades.Factura buscar(int numero)
        {
            return Datos.CRUDFactura.buscar(numero);
        }

        public static Entidades.Cliente cliente(int numero)
        {
            Entidades.Factura factura = Datos.CRUDFactura.buscar(numero);
            return Datos.CRUDCliente.buscar(factura.Ced_cliente);
        }

        public static string nuevo(Entidades.Factura factura)
        {
            return Datos.CRUDFactura.nuevo(factura);
        }

        public static bool anular(int numero)
        {
            bool retorno = true;
            List<Entidades.DetalleProducto> lista = listaDetalles(numero);
            foreach(Entidades.DetalleProducto detalle in lista)
            {
                LogicaDetalle.eliminar(detalle);
            }

            return retorno;
        }

    }
}
