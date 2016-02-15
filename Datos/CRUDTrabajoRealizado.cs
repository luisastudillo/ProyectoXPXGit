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

        public static string nuevo(Entidades.TrabajoRealizado trabajo)
        {
            string retorno = "exito";
            Trabajo_realizado nuevo = entidadADato(trabajo);
            try
            {
                db.Trabajo_realizado.InsertOnSubmit(nuevo);
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                retorno = e.Message;
            }
            return retorno;
        }

        public static Entidades.TrabajoRealizado buscar(int codtrabajo, int codingreso)
        {
            Entidades.TrabajoRealizado retorno = null;
            Trabajo_realizado encontrado = null;

            try
            {
                var sql =
                    from c in db.Trabajo_realizado
                    where c.codigo_ingreso == codingreso && c.codigo_trabajo == codtrabajo
                    select c;
                foreach (var c in sql)
                {
                    encontrado = (Trabajo_realizado)c;
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

        public static string eliminar(int codtrabajo, int codingreso)
        {
            string retorno = "exito";

            try
            {
                var sql =
                    from c in db.Trabajo_realizado
                    where c.codigo_ingreso == codingreso && c.codigo_trabajo == codtrabajo
                    select c;
                foreach (var c in sql)
                {
                    db.Trabajo_realizado.DeleteOnSubmit(c);
                    db.SubmitChanges();                   
                }
            }
            catch (Exception e)
            {
                retorno = e.Message;
            }
            return retorno;
        }

        public static Trabajo_realizado entidadADato(Entidades.TrabajoRealizado t)
        {
            Trabajo_realizado retorno = new Trabajo_realizado();
            retorno.codigo_ingreso = t.Codigo_ingreso;
            retorno.codigo_trabajo = t.Codigo_trabajo;
            return retorno;
        }

        public static Entidades.TrabajoRealizado datoAEntidad(Trabajo_realizado t)
        {
            Entidades.TrabajoRealizado retorno = new Entidades.TrabajoRealizado();
            retorno.Codigo_ingreso = t.codigo_ingreso;
            retorno.Codigo_trabajo = t.codigo_trabajo;
            return retorno;
        }

        public static List<Entidades.TrabajoRealizado> trabajosRealizadosPorIngreso(int codigoingreso)
        {
            List<Entidades.TrabajoRealizado> lista = new List<Entidades.TrabajoRealizado>();
            try
            {
                var sql =
                    from c in db.Trabajo_realizado
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
