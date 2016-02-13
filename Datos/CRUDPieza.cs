using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public static class CRUDPieza
    {

        static baseDataContext db = new baseDataContext();

        public static Entidades.Pieza buscar(int codigo)
        {
            Entidades.Pieza retorno = null;
            Pieza encontrado = null;

            try
            {
                var sql =
                    from c in db.Pieza
                    where c.pie_codigo == codigo
                    select c;
                foreach (var c in sql)
                {
                    encontrado = (Pieza)c;
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

        public static Entidades.Pieza datoAEntidad(Pieza p)
        {
            Entidades.Pieza retorno = new Entidades.Pieza();
            retorno.Baja = (bool)p.pie_baja;
            retorno.Cantidad = (int)p.pie_cantidad;
            retorno.Codigo = p.pie_codigo;
            retorno.Costo = (double)p.pie_costo;
            retorno.Modelo = p.pie_modelo;
            retorno.Tipo = p.pie_tipo;
            return retorno;
        }

        public static Pieza entidadADato(Entidades.Pieza p)
        {
            Pieza retorno = new Pieza();
            retorno.pie_baja = p.Baja;
            retorno.pie_cantidad = p.Cantidad;
            retorno.pie_codigo = p.Codigo;
            retorno.pie_costo = (decimal)p.Costo;
            retorno.pie_modelo = p.Modelo;
            retorno.pie_tipo = p.Tipo;
            return retorno;
        }

    }
}
