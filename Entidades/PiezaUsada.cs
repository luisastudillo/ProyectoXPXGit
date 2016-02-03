using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class PiezaUsada
    {
        int codigo_pieza;
        int codigo_ingreso;
        string serie;


        public PiezaUsada()
        {

        }

        public PiezaUsada(int codigo_pieza, int codigo_ingreso, string serie)
        {
            this.codigo_pieza = codigo_pieza;
            this.codigo_ingreso = codigo_ingreso;
            this.serie = serie;
        }

        public int Codigo_pieza
        {
            get
            {
                return codigo_pieza;
            }

            set
            {
                codigo_pieza = value;
            }
        }

        public int Codigo_ingreso
        {
            get
            {
                return codigo_ingreso;
            }

            set
            {
                codigo_ingreso = value;
            }
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
    }
}
