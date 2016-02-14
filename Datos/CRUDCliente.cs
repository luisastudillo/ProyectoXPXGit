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
                    retorno = datoAEntidad(encontrado);                                      
                }
            }
            catch (Exception e)
            {
            }
            return retorno;
        }

        public static string nuevo(Entidades.Cliente cliente)
        {
            string retorno = "agregado";
            Cliente nuevo = entidadADato(cliente);
            try
            {
                db.Cliente.InsertOnSubmit(nuevo);
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                retorno = e.Message;
            }
            return retorno;
        }

        public static string editar(Entidades.Cliente cliente)
        {
            string retorno = "";
            try
            {
                var sql =
                    from c in db.Cliente
                    where c.cli_cedula == cliente.Cedula
                    select c;

                foreach (var s in sql)
                {
                    s.cli_apellido = cliente.Apellido;
                    s.cli_cedula = cliente.Cedula;
                    s.cli_celular = cliente.Celular;
                    s.cli_domicilio = cliente.Domicilio;
                    s.cli_nombre = cliente.Nombre;
                    s.cli_telefono = cliente.Telefono;
                    
                    db.SubmitChanges();
                   retorno = "exito";

                }
            }
            catch (Exception e)
            {
                retorno = e.Message;
            }
            return retorno;
        }

        public static bool eliminar(string cedula)
        {
            bool retorno = false;

            try
            {
                var sql =
                    from c in db.Cliente
                    where c.cli_cedula == cedula
                    select c;
                foreach (var c in sql)
                {
                    db.Cliente.DeleteOnSubmit(c);
                    db.SubmitChanges();
                    retorno = true;
                }
            }
            catch (Exception e)
            {
            }
            return retorno;
        }

        public static List<Entidades.Cliente> listaClientes()
        {
            List<Entidades.Cliente> lista = new List<Entidades.Cliente>();
            try
            {
                var sql =
                    from c in db.Cliente
                    select c;
                foreach (var c in sql)
                {
                    lista.Add(datoAEntidad(c));                   
                }
            }
            catch (Exception e)
            {
            }
            return lista;
        }

        public static Entidades.Cliente datoAEntidad(Cliente c)
        {
            Entidades.Cliente retorno = new Entidades.Cliente();
            retorno.Apellido = c.cli_apellido;
            retorno.Cedula = c.cli_cedula;
            retorno.Celular = c.cli_celular;
            retorno.Domicilio = c.cli_domicilio;
            retorno.Nombre = c.cli_nombre;
            retorno.Telefono = c.cli_telefono;
            return retorno;
        }

        public static Cliente entidadADato(Entidades.Cliente cliente)
        {
            Cliente nuevo = new Cliente();
            nuevo.cli_apellido = cliente.Apellido;
            nuevo.cli_cedula = cliente.Cedula;
            nuevo.cli_celular = cliente.Celular;
            nuevo.cli_domicilio = cliente.Domicilio;
            nuevo.cli_nombre = cliente.Nombre;
            nuevo.cli_telefono = cliente.Telefono;
            return nuevo;
        }        
    }
}
