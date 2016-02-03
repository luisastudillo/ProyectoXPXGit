using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public static class CRUDFacturaCompra
    {

        static baseDataContext db = new baseDataContext();
        public static bool nuevo(Entidades.FacturaCompra factura)
        {
            bool retorno = true;
            Factura_compra nuevo = new Factura_compra();
            nuevo.fc_numero = factura.Numero;
            nuevo.fc_cedula = factura.Cedula;
            nuevo.fc_fecha = factura.Fecha;
            try
            {
                db.Factura_compra.InsertOnSubmit(nuevo);
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                retorno = false;
            }

            return retorno;

        }


        public static Entidades.FacturaCompra buscar(int numero)
        {
            Entidades.FacturaCompra retorno = null;
            Factura_compra encontrado = null;

            try
            {
                var sql =
                    from c in db.Factura_compra
                    where c.fc_numero == numero
                    select c;
                foreach (var c in sql)
                {
                    encontrado = (Factura_compra)c;
                }

                if (encontrado != null)
                {
                    retorno = new Entidades.FacturaCompra();

                    retorno.Fecha = (DateTime)encontrado.fc_fecha;
                    retorno.Cedula = encontrado.fc_cedula;
                    retorno.Numero = encontrado.fc_numero;
                }
            }
            catch (Exception e)
            {

            }
            return retorno;
        }

    }
}
