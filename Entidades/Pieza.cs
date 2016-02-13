using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Pieza
    {
        int codigo;
        string modelo;
        string tipo;
        double costo;
        int cantidad;
        bool baja = false;


        public Pieza()
        {

        }

        public Pieza(int codigo, string modelo, string tipo, double costo, int cantidad, bool baja)
        {
            this.codigo = codigo;
            this.modelo = modelo;
            this.tipo = tipo;
            this.costo = costo;
            this.cantidad = cantidad;
            this.baja = baja;
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

        public double Costo
        {
            get
            {
                return costo;
            }

            set
            {
                costo = value;
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

        public bool Baja
        {
            get
            {
                return baja;
            }

            set
            {
                baja = value;
            }
        }
    }
}
