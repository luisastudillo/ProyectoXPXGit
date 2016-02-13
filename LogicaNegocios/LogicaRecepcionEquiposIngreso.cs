using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocios
{
    public static class LogicaRecepcionEquiposIngreso
    {
        public static bool nuevo(int codigo, DateTime fecha, string problema, string observaciones, string accesorios, string ced_cliente, 
            string ced_tecnico, string ced_recepcionista, string serie_equipo, bool garantia, string estado, int n_factura)
        {
            Entidades.Ingreso ingreso = new Entidades.Ingreso(codigo, fecha, problema, observaciones, accesorios, ced_cliente, 
                ced_tecnico, ced_recepcionista, serie_equipo, garantia, estado, n_factura);

            return Datos.CRUDIngreso.nuevo(ingreso);
        }


        public static bool editar(int codigo, DateTime fecha, string problema, string observaciones, string accesorios, string ced_cliente,
            string ced_tecnico, string ced_recepcionista, string serie_equipo, bool garantia, string estado, int n_factura)
        {
            Entidades.Ingreso ingreso = new Entidades.Ingreso(codigo, fecha, problema, observaciones, accesorios, ced_cliente,
                ced_tecnico, ced_recepcionista, serie_equipo, garantia, estado, n_factura);

            return Datos.CRUDIngreso.editar(ingreso);

        }


        public static Entidades.Ingreso buscar(int codigo)
        {
            return  Datos.CRUDIngreso.buscar(codigo);            
        }


        public static Entidades.FacturaCompra buscarFactura(int numero)
        {
            return Datos.CRUDFacturaCompra.buscar(numero);
        }


        public static bool nuevaFactura(int numero, DateTime fecha, string cedula)
        {
            Entidades.FacturaCompra factura = new Entidades.FacturaCompra(numero, fecha, cedula);
            return Datos.CRUDFacturaCompra.nuevo(factura);
        }


        public static Entidades.Equipo buscarEquipo(string serie)
        {
            return Datos.CRUDEquipo.buscar(serie);
        }


        public static bool nuevoEquipo(string serie, string modelo, string tipo, short n_ingresos, int n_factura)
        {
            Entidades.Equipo equipo = new Entidades.Equipo(serie, modelo, tipo, n_ingresos, n_factura);
            return Datos.CRUDEquipo.nuevo(equipo);
        }

        public static int siguienteIngreso()
        {
            return Datos.CRUDIngreso.siguienteIngreso();
        }

    }
}
