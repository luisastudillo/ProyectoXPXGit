using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TrabajoRealizado
    {
        int codigo_trabajo;
        int codigo_ingreso;


        public TrabajoRealizado()
        {

        }

        public TrabajoRealizado(int codigo_trabajo, int codigo_ingreso)
        {
            this.codigo_trabajo = codigo_trabajo;
            this.codigo_ingreso = codigo_ingreso;
        }

        public int Codigo_trabajo
        {
            get
            {
                return codigo_trabajo;
            }

            set
            {
                codigo_trabajo = value;
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
    }
}
