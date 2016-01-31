using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppWinProyectoo
{
    public class Factura
    {
        int numero;
        DateTime fecha;
        String ced_recep;
        String ced_cliente;
        double subtotal;
        double iva;
        double total;

        public int Numero
        {
            get
            {
                return numero;
            }

            set
            {
                numero = value;
            }
        }

        public DateTime Fecha
        {
            get
            {
                return fecha;
            }

            set
            {
                fecha = value;
            }
        }

        public string Ced_recep
        {
            get
            {
                return ced_recep;
            }

            set
            {
                ced_recep = value;
            }
        }

        public string Ced_cliente
        {
            get
            {
                return ced_cliente;
            }

            set
            {
                ced_cliente = value;
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

        public double Iva
        {
            get
            {
                return iva;
            }

            set
            {
                iva = value;
            }
        }

        public double Total
        {
            get
            {
                return total;
            }

            set
            {
                total = value;
            }
        }
    }
}
