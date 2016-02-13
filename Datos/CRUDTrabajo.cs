using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public static class CRUDTrabajo
    {
        static baseDataContext db = new baseDataContext();

        public static Entidades.Trabajo buscar(int codigo)
        {
            Entidades.Trabajo retorno = null;
            Trabajo encontrado = null;

            try
            {
                var sql =
                    from c in db.Trabajo
                    where c.tra_codigo == codigo
                    select c;
                foreach (var c in sql)
                {
                    encontrado = (Trabajo)c;
                }

                if (encontrado != null)
                {
                    retorno = datoAEntidad(encontrado);
                }
            }
            catch (Exception e)
            {
            }
            return retorno;
        }
                
        public static Entidades.Trabajo datoAEntidad(Trabajo t)
        {
            Entidades.Trabajo retorno = new Entidades.Trabajo();
            retorno.Codigo = t.tra_codigo;
            retorno.Costo = (double)t.tra_costo;
            retorno.Descripcion = t.tra_descripcion;
            return retorno;
        }

        public static Datos.Trabajo entidadADato(Entidades.Trabajo t)
        {
            Trabajo retorno = new Trabajo();
            retorno.tra_codigo = t.Codigo;
            retorno.tra_costo = Convert.ToDecimal(t.Costo);
            retorno.tra_descripcion = t.Descripcion;
            return retorno;
        }
    }
}
