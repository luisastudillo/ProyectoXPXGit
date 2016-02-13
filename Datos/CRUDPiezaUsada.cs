using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public static class CRUDPiezaUsada
    {

        static baseDataContext db = new baseDataContext();
        
        public static List<Entidades.Pieza> piezasPorIngreso(int codigo)
        {
            List<Entidades.Pieza> lista = new List<Entidades.Pieza>();
            try
            {
                var sql =
                    from c in db.Pieza_usada
                    where c.codigo_ingreso == codigo
                    select c;
                foreach (var c in sql)
                {
                    lista.Add(CRUDPieza.buscar((int)c.codigo_pieza));
                }
            }
            catch (Exception e)
            {
            }
            return lista;
        }

    }
}
