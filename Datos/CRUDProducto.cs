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
