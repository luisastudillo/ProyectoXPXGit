using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocios
{
    public static class LogicaCliente
    {


        public static Entidades.Cliente buscarCliente(string cedula)
        {
            return Datos.CRUDCliente.buscar(cedula);
        }

        public static string nuevo(string cedula, string nombres, string apellidos, string direccion, string telefono, string celular)
        {
            Entidades.Cliente cliente = new Entidades.Cliente(cedula, nombres, apellidos, direccion, telefono, celular);
            return Datos.CRUDCliente.nuevo(cliente);
        }

        public static Entidades.Cliente buscar(string cedula)
        {
            return Datos.CRUDCliente.buscar(cedula);
        }

        public static string editar(string cedula, string nombre, string apellido, string domicilio, string telefono, string celular)
        {
            Entidades.Cliente cliente = new Entidades.Cliente(cedula, nombre, apellido, domicilio, telefono, celular);
            return Datos.CRUDCliente.editar(cliente);
        }

        public static List<Entidades.Cliente> listaClientes()
        {
            return Datos.CRUDCliente.listaClientes();
        }


    }
}
