using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocios
{
    public static class LogicaPieza
    {
        public static Entidades.Pieza buscar(int codigo)
        {
            return Datos.CRUDPieza.buscar(codigo);
        }

        public static string nuevo(int codigo, string modelo, string tipo, double costo, int cantidad)
        {
            Entidades.Pieza pieza = new Entidades.Pieza(codigo, modelo, tipo, costo, cantidad, false);
            return Datos.CRUDPieza.nuevo(pieza);
        }

        public static string editar(int codigo, string modelo, string tipo, double costo, int cantidad, bool baja)
        {
            Entidades.Pieza pieza = new Entidades.Pieza(codigo, modelo, tipo, costo, cantidad, baja);
            return Datos.CRUDPieza.editar(pieza);
        }

        public static List<Entidades.Pieza> lista()
        {
            return Datos.CRUDPieza.lista();
        }

        public static List<Entidades.Pieza> listaPorModelo(string modelo)
        {
            return Datos.CRUDPieza.listaPorModelo(modelo);
        }

        public static List<Entidades.Pieza> listaPorTipo(string tipo)
        {
            return Datos.CRUDPieza.listaPorTipo(tipo);
        }

        public static int siguienteCodigo()
        {
            return Datos.CRUDPieza.siguienteCodigo();
        }

    }
}
