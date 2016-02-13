using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public static class CRUDTrabajoRealizado
    {
        static baseDataContext db = new baseDataContext();


        public static List<Entidades.Trabajo> trabajosPorIngreso(int codigo)
        {
            List<Entidades.Trabajo> lista = new List<Entidades.Trabajo>();
            try
            {
                var sql =
                    from c in db.Trabajo_realizado
                    where c.codigo_ingreso == codigo
                    select c;
                foreach (var c in sql)
                {
                    lista.Add(CRUDTrabajo.buscar((int)c.codigo_trabajo));
                }
            }
            catch (Exception e)
            {
            }
            return lista;
        }



    }
}
