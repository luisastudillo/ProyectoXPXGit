using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public static class CRUDDetalleProducto
    {
        static baseDataContext db = new baseDataContext();

        public static string nuevo(Entidades.DetalleProducto detalle)
        {
            string retorno = "agregado";
            Detalle_producto nuevo = entidadADato(detalle);
            try
            {
                db.Detalle_producto.InsertOnSubmit(nuevo);
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                retorno = e.Message;
            }
            return retorno;
        }

        public static bool eliminar(int factura, int codigo)
        {
            bool retorno = false;
            try
            {
                var sql =
                    from c in db.Detalle_producto
                    where c.nfactura == factura && c.pro_codigo == codigo
                    select c;
                foreach (var c in sql)
                {
                    db.Detalle_producto.DeleteOnSubmit(c);
                    db.SubmitChanges();
                    retorno = true;
                }
            }
            catch (Exception e)
            {
            }
            return retorno;
        }

        public static List<Entidades.DetalleProducto> detallesPorFactura(int numero)
        {
            List<Entidades.DetalleProducto> lista = new List<Entidades.DetalleProducto>();
            try
            {
                var sql =
                    from c in db.Detalle_producto
                    where c.nfactura == numero
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

        public static Entidades.DetalleProducto datoAEntidad(Detalle_producto detalle)
        {
            Entidades.DetalleProducto retorno = new Entidades.DetalleProducto();
            retorno.Cantidad = (int)detalle.cantidad;
            retorno.Cod_producto =(int) detalle.pro_codigo;
            retorno.Num_factura =(int) detalle.cantidad;
            retorno.Subtotal = (double)detalle.subtotal;
            retorno.Descripcion = detalle.descripcion;
            return retorno;
        }

        public static Detalle_producto entidadADato(Entidades.DetalleProducto d)
        {
            Detalle_producto nuevo = new Detalle_producto();
            nuevo.cantidad = d.Cantidad;
            nuevo.descripcion = d.Descripcion;
            nuevo.nfactura = d.Num_factura;
            nuevo.pro_codigo = d.Cod_producto;
            nuevo.subtotal = Convert.ToDecimal(d.Subtotal);
            return nuevo;
        }

        public static Entidades.Cliente datoAEntidad(Cliente c)
        {
            Entidades.Cliente retorno = new Entidades.Cliente();
            retorno.Apellido = c.cli_apellido;
            retorno.Cedula = c.cli_cedula;
            retorno.Celular = c.cli_celular;
            retorno.Domicilio = c.cli_domicilio;
            retorno.Nombre = c.cli_nombre;
            retorno.Telefono = c.cli_telefono;
            return retorno;
        }


    }
}
