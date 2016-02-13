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


    }
}
