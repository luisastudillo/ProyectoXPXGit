﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Trabajo
    {
        int codigo;
        string descripcion;
        decimal costo;


        public Trabajo()
        {

        }

        public Trabajo(int codigo, string descripcion, decimal costo)
        {
            this.codigo = codigo;
            this.descripcion = descripcion;
            this.costo = costo;
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

        public decimal Costo
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
    }
}
