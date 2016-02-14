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

        public static string nuevo(Entidades.Pieza pieza)
        {
            string retorno = "exito";
            Pieza nuevo = entidadADato(pieza);
            try
            {
                db.Pieza.InsertOnSubmit(nuevo);
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                retorno = e.Message;
            }
            return retorno;
        }

        public static string editar(Entidades.Pieza pieza)
        {
            string retorno = "";
            try
            {
                var sql =
                    from c in db.Pieza
                    where c.pie_codigo == pieza.Codigo
                    select c;

                foreach (var s in sql)
                {
                    s.pie_baja = pieza.Baja;
                    s.pie_cantidad = pieza.Cantidad;
                    s.pie_codigo = pieza.Codigo;
                    s.pie_costo = Convert.ToDecimal(pieza.Costo);
                    s.pie_modelo = pieza.Modelo;
                    s.pie_tipo = pieza.Tipo;
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

        public static List<Entidades.Pieza> lista()
        {
            List<Entidades.Pieza> lista = new List<Entidades.Pieza>();
            try
            {
                var sql =
                    from c in db.Pieza
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

        public static List<Entidades.Pieza> listaPorModelo(string modelo)
        {
            List<Entidades.Pieza> lista = new List<Entidades.Pieza>();
            try
            {
                var sql =
                    from c in db.Pieza
                    select c;
                foreach (var c in sql)
                {
                    if (c.pie_modelo.ToLower().Contains(modelo.ToLower()))
                        lista.Add(datoAEntidad(c));
                }
            }
            catch (Exception e)
            {
            }
            return lista;
        }

        public static List<Entidades.Pieza> listaPorTipo(string tipo)
        {
            List<Entidades.Pieza> lista = new List<Entidades.Pieza>();
            try
            {
                var sql =
                    from c in db.Pieza
                    select c;
                foreach (var c in sql)
                {
                    if (c.pie_tipo.ToLower().Contains(tipo.ToLower()))
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
                    from c in db.Pieza
                    select c;
                foreach (var c in sql)
                {
                    if (c.pie_codigo >= retorno)
                        retorno = c.pie_codigo;
                }
            }
            catch (Exception e)
            {
            }

            return retorno + 1;
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
