using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public static class CRUDCliente
    {

        static baseDataContext db = new baseDataContext();



        public static Entidades.Cliente buscar(string cedula)
        {
            Entidades.Cliente retorno = null;
            Cliente encontrado = null;

            try
            {
                var sql =
                    from c in db.Cliente
                    where c.cli_cedula == cedula
                    select c;
                foreach (var c in sql)
                {
                    encontrado = (Cliente)c;
                }

                if (encontrado != null)
                {
                    retorno = new Entidades.Cliente();

                    retorno.Apellido = encontrado.cli_apellido;
                    retorno.Cedula = encontrado.cli_cedula;
                    retorno.Celular = encontrado.cli_celular;
                    retorno.Domicilio = encontrado.cli_domicilio;
                    retorno.Nombre = encontrado.cli_nombre;
                    retorno.Telefono = encontrado.cli_telefono;                                      
                }
            }
            catch (Exception e)
            {
            }
            return retorno;
        }


    }
}
