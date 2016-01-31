using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class Equipo
    {
        string serie;
        string modelo;
        string tipo;
        int n_ingresos;
        int n_factura;


        public Equipo()
        {

        }

        public Equipo(string serie, string modelo, string tipo, int n_ingresos, int n_factura)
        {
            this.serie = serie;
            this.modelo = modelo;
            this.tipo = tipo;
            this.n_ingresos = n_ingresos;
            this.n_factura = n_factura;
        }

        public string Serie
        {
            get
            {
                return serie;
            }

            set
            {
                serie = value;
            }
        }

        public string Modelo
        {
            get
            {
                return modelo;
            }

            set
            {
                modelo = value;
            }
        }

        public string Tipo
        {
            get
            {
                return tipo;
            }

            set
            {
                tipo = value;
            }
        }

        public int N_ingresos
        {
            get
            {
                return n_ingresos;
            }

            set
            {
                n_ingresos = value;
            }
        }

        public int N_factura
        {
            get
            {
                return n_factura;
            }

            set
            {
                n_factura = value;
            }
        }
    }
}
