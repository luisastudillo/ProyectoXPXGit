using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public static class CRUDFactura
    {
        static baseDataContext db = new baseDataContext();

        public static string nuevo(Entidades.Factura factura)
        {
            string retorno = "agregado";
            Factura nuevo = entidadADato(factura);
            try
            {
                db.Factura.InsertOnSubmit(nuevo);
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                retorno = e.Message;
            }
            return retorno;
        }

        public static Entidades.Factura buscar(int numero)
        {
            Entidades.Factura retorno = null;
            Factura encontrado = null;

            try
            {
                var sql =
                    from c in db.Factura
                    where c.fac_n_factura == numero
                    select c;
                foreach (var c in sql)
                {
                    encontrado = (Factura)c;
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
        
        public static Entidades.Factura datoAEntidad(Factura f)
        {
            Entidades.Factura retorno = new Entidades.Factura();
            retorno.Anulada = (bool)f.fac_anulada;
            retorno.Ced_cliente = f.fac_ced_cliente;
            retorno.Ced_recep = f.fac_ced_recep;
            retorno.Fecha = (DateTime)f.fac_fecha;
            retorno.Iva = (double)f.fac_iva;
            retorno.Numero = f.fac_n_factura;
            retorno.Subtotal = (double)f.fac_subtotal;
            retorno.Total = (double)f.fac_total;
            return retorno;
        }

        public static Factura entidadADato(Entidades.Factura f)
        {
            Factura nuevo = new Factura();
            nuevo.fac_ced_cliente = f.Ced_cliente;
            nuevo.fac_ced_recep = f.Ced_recep;
            nuevo.fac_fecha = f.Fecha;
            nuevo.fac_iva = Convert.ToDecimal(f.Iva);
            nuevo.fac_n_factura = f.Numero;
            nuevo.fac_subtotal = Convert.ToDecimal(f.Subtotal);
            nuevo.fac_total = Convert.ToDecimal(f.Total);
            return nuevo;
        }
    }
}
