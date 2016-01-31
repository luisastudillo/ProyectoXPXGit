using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppWinProyectoo
{
    public class DetalleProducto
    {
        int num_factura;
        int cod_producto;
        int cantidad;
        string descripcion;
        double subtotal;

        public int Num_factura
        {
            get
            {
                return num_factura;
            }

            set
            {
                num_factura = value;
            }
        }

        public int Cod_producto
        {
            get
            {
                return cod_producto;
            }

            set
            {
                cod_producto = value;
            }
        }

        public int Cantidad
        {
            get
            {
                return cantidad;
            }

            set
            {
                cantidad = value;
            }
        }

        public double Subtotal
        {
            get
            {
                return subtotal;
            }

            set
            {
                subtotal = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return descripcion;
            }

            set
            {
                descripcion = value;
            }
        }
    }
}
