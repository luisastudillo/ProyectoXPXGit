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

        public static string nuevo(Entidades.PiezaUsada pieza)
        {
            string retorno = "exito";
            Pieza_usada nuevo = entidadADato(pieza);
            try
            {
                db.Pieza_usada.InsertOnSubmit(nuevo);
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                retorno = e.Message;
            }
            return retorno;
        }

        public static Entidades.PiezaUsada buscar(int codpieza, int codingreso)
        {
            Entidades.PiezaUsada retorno = null;
            Pieza_usada encontrado = null;

            try
            {
                var sql =
                    from c in db.Pieza_usada
                    where c.codigo_ingreso == codingreso && c.codigo_pieza == codpieza
                    select c;
                foreach (var c in sql)
                {
                    encontrado = (Pieza_usada)c;
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

        public static bool eliminar(int codpieza, int codingreso)
        {
            bool retorno = false;

            try
            {
                var sql =
                    from c in db.Pieza_usada
                    where c.codigo_ingreso == codingreso && c.codigo_pieza == codpieza
                    select c;
                foreach (var c in sql)
                {
                    db.Pieza_usada.DeleteOnSubmit(c);
                    db.SubmitChanges();
                    retorno = true;
                }
            }
            catch (Exception e)
            {
            }
            return retorno;
        }

        public static Entidades.PiezaUsada datoAEntidad(Pieza_usada p)
        {
            Entidades.PiezaUsada retorno = new Entidades.PiezaUsada();
            retorno.Codigo_ingreso = p.codigo_ingreso;
            retorno.Codigo_pieza = p.codigo_pieza;
            return retorno;
        }

        public static Pieza_usada entidadADato(Entidades.PiezaUsada p)
        {
            Pieza_usada retorno = new Pieza_usada();
            retorno.codigo_ingreso = p.Codigo_ingreso;
            retorno.codigo_pieza = p.Codigo_pieza;
            return retorno;
        }
        
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


        public static List<Entidades.PiezaUsada> piezasUsadasPorIngreso(int codigoingreso)
        {
            List<Entidades.PiezaUsada> lista = new List<Entidades.PiezaUsada>();
            try
            {
                var sql =
                    from c in db.Pieza_usada
                    where c.codigo_ingreso == codigoingreso
                    select c;
                foreach (var c in sql)
                {
                    lista.Add(datoAEntidad(c));
                }
            }
            catch (Exception e)
            {
            }
            return lista;
        }

    }
}
