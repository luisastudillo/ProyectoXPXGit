using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocios
{
    public static class LogicaPiezaUsada
    {

        public static string descripcion(Entidades.PiezaUsada p)
        {
            Entidades.Pieza pieza = LogicaPieza.buscar(p.Codigo_pieza);
            return pieza.Tipo + " " + pieza.Modelo;
        }

        public static string nuevo(int codigo_pieza, int codigo_ingreso)
        {
            Entidades.PiezaUsada pieza = new Entidades.PiezaUsada(codigo_pieza, codigo_ingreso);
            return Datos.CRUDPiezaUsada.nuevo(pieza);
        }

        public static Entidades.PiezaUsada buscar(int codpieza, int codingreso)
        {
            return Datos.CRUDPiezaUsada.buscar(codpieza, codingreso);
        }

        public static bool eliminar(int codpieza, int codingreso)
        {
            return Datos.CRUDPiezaUsada.eliminar(codpieza, codingreso);
        }

        public static List<Entidades.Pieza> piezasPorIngreso(int codigo)
        {
            return Datos.CRUDPiezaUsada.piezasPorIngreso(codigo);
        }

        public static List<Entidades.PiezaUsada> piezasUsadasPorIngreso(int codigo)
        {
            return Datos.CRUDPiezaUsada.piezasUsadasPorIngreso(codigo);
        }

    }
}
