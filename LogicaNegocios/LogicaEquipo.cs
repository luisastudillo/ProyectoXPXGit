using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocios
{
    public static class LogicaEquipo
    {
        public static Entidades.Equipo buscar(string serie)
        {
            return Datos.CRUDEquipo.buscar(serie);
        }

        public static bool nuevo(string serie, string modelo, string tipo, int n_factura)
        {
            Entidades.Equipo equipo = new Entidades.Equipo(serie, modelo, tipo, 1, n_factura);
            return Datos.CRUDEquipo.nuevo(equipo);
        }


    }
}
