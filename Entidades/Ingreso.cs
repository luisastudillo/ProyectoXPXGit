using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ingreso
    {

        int codigo;
        DateTime fecha;
        string problema;
        string observaciones;
        string accesorios;
        string ced_cliente;
        string ced_tecnico;
        string ced_recepcionista;
        string serie_equipo;
        bool garantia;
        string estado;
        int n_factura;


        public Ingreso()
        {

        }


        public Ingreso(int codigo, DateTime fecha, string problema, string observaciones, string accesorios, string ced_cliente, string ced_tecnico, string ced_recepcionista, string serie_equipo, bool garantia, string estado, int n_factura)
        {
            this.codigo = codigo;
            this.fecha = fecha;
            this.problema = problema;
            this.observaciones = observaciones;
            this.accesorios = accesorios;
            this.ced_cliente = ced_cliente;
            this.ced_tecnico = ced_tecnico;
            this.ced_recepcionista = ced_recepcionista;
            this.serie_equipo = serie_equipo;
            this.garantia = garantia;
            this.estado = estado;
            this.n_factura = n_factura;
        }

        public int Codigo
        {
            get
            {
                return codigo;
            }

            set
            {
                codigo = value;
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

        public string Problema
        {
            get
            {
                return problema;
            }

            set
            {
                problema = value;
            }
        }

        public string Observaciones
        {
            get
            {
                return observaciones;
            }

            set
            {
                observaciones = value;
            }
        }

        public string Accesorios
        {
            get
            {
                return accesorios;
            }

            set
            {
                accesorios = value;
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

        public string Ced_tecnico
        {
            get
            {
                return ced_tecnico;
            }

            set
            {
                ced_tecnico = value;
            }
        }

        public string Ced_recepcionista
        {
            get
            {
                return ced_recepcionista;
            }

            set
            {
                ced_recepcionista = value;
            }
        }

        public string Serie_equipo
        {
            get
            {
                return serie_equipo;
            }

            set
            {
                serie_equipo = value;
            }
        }

        public bool Garantia
        {
            get
            {
                return garantia;
            }

            set
            {
                garantia = value;
            }
        }

        public string Estado
        {
            get
            {
                return estado;
            }

            set
            {
                estado = value;
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
