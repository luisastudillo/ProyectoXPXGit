using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Producto
    {
        int codigo;
        String tipo;
        String modelo;
        double costo;
        int cantidad;
        bool baja;


        public Producto()
        {

        }

        public Producto(int codigo, string tipo, string modelo, double costo, int cantidad, bool baja)
        {
            this.codigo = codigo;
            this.tipo = tipo;
            this.modelo = modelo;
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
