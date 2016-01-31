using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class FacturaCompra
    {
        int numero;
        DateTime fecha;
        string cedula;

        public FacturaCompra()
        {

        }

        public FacturaCompra(int numero, DateTime fecha, string cedula)
        {
            this.numero = numero;
            this.fecha = fecha;
            this.cedula = cedula;
        }

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

        public string Cedula
        {
            get
            {
                return cedula;
            }

            set
            {
                cedula = value;
            }
        }
    }
}
