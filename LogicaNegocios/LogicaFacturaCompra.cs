using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocios
{
    public static class LogicaFacturaCompra
    {

        public static Entidades.FacturaCompra buscar(int numero)
        {
            return Datos.CRUDFacturaCompra.buscar(numero);
        }

        public static bool nuevo(int numero, DateTime fecha, string cedula)
        {
            Entidades.FacturaCompra factura = new Entidades.FacturaCompra(numero, fecha, cedula);
            return Datos.CRUDFacturaCompra.nuevo(factura);
        }

    }
}
