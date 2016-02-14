using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public static class CRUDProducto
    {
        static baseDataContext db = new baseDataContext();

        public static string nuevo(Entidades.Producto Producto)
        {
            string retorno = "exito";
            Producto nuevo = entidadADato(Producto);
            try
            {
                db.Producto.InsertOnSubmit(nuevo);
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                retorno = e.Message;
            }
            return retorno;
        }
        
        public static Entidades.Producto buscar(int codigo)
        {
            Entidades.Producto retorno = null;
            Producto encontrado = null;

            try
            {
                var sql =
                    from c in db.Producto
                    where c.pro_codigo == codigo
                    select c;
                foreach (var c in sql)
                {
                    encontrado = (Producto)c;
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

        public static Entidades.Producto buscarPorModelo(string modelo)
        {
            Entidades.Producto retorno = null;
            Producto encontrado = null;

            try
            {
                var sql =
                    from c in db.Producto
                    where c.pro_modelo.ToLower().Contains(modelo.ToLower())
                    select c;
                foreach (var c in sql)
                {
                    encontrado = (Producto)c;
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

        public static Entidades.Producto buscarPorTipo(string tipo)
        {
            Entidades.Producto retorno = null;
            Producto encontrado = null;

            try
            {
                var sql =
                    from c in db.Producto
                    where c.pro_tipo.ToLower().Contains(tipo.ToLower())
                    select c;
                foreach (var c in sql)
                {
                    encontrado = (Producto)c;
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
        
        public static string editar(Entidades.Producto p)
        {
            string retorno = "";
            try
            {
                var sql =
                    from c in db.Producto
                    where c.pro_codigo == p.Codigo
                    select c;

                foreach (var nuevo in sql)
                {
                    nuevo.pro_baja = p.Baja;
                    nuevo.pro_cantidad = p.Cantidad;
                    nuevo.pro_codigo = p.Codigo;
                    nuevo.pro_costo = Convert.ToDecimal(p.Costo);
                    nuevo.pro_modelo = p.Modelo;
                    nuevo.pro_tipo = p.Tipo;

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

        public static List<Entidades.Producto> lista()
        {
            List<Entidades.Producto> lista = new List<Entidades.Producto>();
            try
            {
                var sql =
                    from c in db.Producto
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

        public static List<Entidades.Producto> listaPorModelo(string modelo)
        {
            List<Entidades.Producto> lista = new List<Entidades.Producto>();
            try
            {
                var sql =
                    from c in db.Producto
                    select c;
                foreach (var c in sql)
                {
                    if(c.pro_modelo.ToLower().Contains(modelo.ToLower()))
                        lista.Add(datoAEntidad(c));
                }
            }
            catch (Exception e)
            {
            }
            return lista;
        }

        public static List<Entidades.Producto> listaPorTipo(string tipo)
        {
            List<Entidades.Producto> lista = new List<Entidades.Producto>();
            try
            {
                var sql =
                    from c in db.Producto
                    select c;
                foreach (var c in sql)
                {
                    if (c.pro_tipo.ToLower().Contains(tipo.ToLower()))
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
                    from c in db.Producto
                    select c;
                foreach (var c in sql)
                {
                    if (c.pro_codigo > retorno)
                        retorno = c.pro_codigo;
                }                
            }
            catch (Exception e)
            {
            }
            return retorno +1;
        }
        
        public static Entidades.Producto datoAEntidad(Producto p)
        {
            Entidades.Producto retorno = new Entidades.Producto();
            retorno.Baja = (bool)p.pro_baja;
            retorno.Cantidad = (int)p.pro_cantidad;
            retorno.Codigo = p.pro_codigo;
            retorno.Costo = (double)p.pro_costo;
            retorno.Modelo = p.pro_modelo;
            retorno.Tipo = p.pro_tipo;
            return retorno;
        }

        public static Producto entidadADato(Entidades.Producto p)
        {
            Producto nuevo = new Producto();
            nuevo.pro_baja = p.Baja;
            nuevo.pro_cantidad = p.Cantidad;
            nuevo.pro_codigo = p.Codigo;
            nuevo.pro_costo = Convert.ToDecimal(p.Costo);
            nuevo.pro_modelo = p.Modelo;
            nuevo.pro_tipo = p.Tipo;
            return nuevo;
        }

        

    }
}
