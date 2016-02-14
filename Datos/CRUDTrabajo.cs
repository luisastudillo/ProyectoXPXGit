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

        public static string nuevo(Entidades.Trabajo trabajo)
        {
            string retorno = "exito";
            Trabajo nuevo = entidadADato(trabajo);
            try
            {
                db.Trabajo.InsertOnSubmit(nuevo);
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                retorno = e.Message;
            }
            return retorno;
        }

        public static string editar(Entidades.Trabajo trabajo)
        {
            string retorno = "";
            try
            {
                var sql =
                    from c in db.Trabajo
                    where c.tra_codigo == trabajo.Codigo
                    select c;

                foreach (var s in sql)
                {
                    s.tra_codigo = trabajo.Codigo;
                    s.tra_costo = trabajo.Costo;
                    s.tra_descripcion = trabajo.Descripcion;
                    s.pie_baja = trabajo.Baja;
                    db.SubmitChanges();
                    retorno = "exito";
                }
            }
            catch (Exception e)
            {
                retorno = e.Message;
            }
            return retorno;
        }

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

        public static List<Entidades.Trabajo> lista()
        {
            List<Entidades.Trabajo> lista = new List<Entidades.Trabajo>();
            try
            {
                var sql =
                    from c in db.Trabajo
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
        
        public static int siguienteCodigo()
        {
            int retorno = 0;

            try
            {
                var sql =
                    from c in db.Trabajo
                    select c;
                foreach (var c in sql)
                {
                    if (c.tra_codigo > retorno)
                        retorno = c.tra_codigo;
                }               
            }
            catch (Exception e)
            {
            }

            return retorno + 1;
        }

        public static Entidades.Trabajo datoAEntidad(Trabajo t)
        {
            Entidades.Trabajo retorno = new Entidades.Trabajo();
            retorno.Codigo = t.tra_codigo;
            retorno.Costo = (decimal)t.tra_costo;
            retorno.Descripcion = t.tra_descripcion;
            retorno.Baja = (bool)t.pie_baja;
            return retorno;
        }

        public static Datos.Trabajo entidadADato(Entidades.Trabajo t)
        {
            Trabajo retorno = new Trabajo();
            retorno.tra_codigo = t.Codigo;
            retorno.tra_costo = Convert.ToDecimal(t.Costo);
            retorno.tra_descripcion = t.Descripcion;
            retorno.pie_baja = t.Baja;
            return retorno;
        }



    }
}
