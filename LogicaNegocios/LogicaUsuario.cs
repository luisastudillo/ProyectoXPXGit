using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocios
{
    public static class LogicaUsuario
    {


        public static Entidades.Usuario buscar(string cedula)
        {
            return Datos.CRUDUsuario.buscar(cedula);
        }

        public static List<Entidades.Usuario> listaUsuario()
        {
            return Datos.CRUDUsuario.listaUsuario();
        }

        public static List<Entidades.Usuario> listaUsuarioPorCedula(string cedula)
        {
            return Datos.CRUDUsuario.listaUsuarioPorCedula(cedula);
        }

        public static List<Entidades.Usuario> listaUsuarioPorNombre(string nombre)
        {
            return Datos.CRUDUsuario.listaUsuarioPorNombre(nombre);
        }

        public static List<Entidades.Usuario> listaUsuarioPorApellido(string apellido)
        {
            return Datos.CRUDUsuario.listaUsuarioPorApellido(apellido);
        }

        public static bool nuevo(string cedula, string nombre, string apellido, string domicilio, string telefono, string contrasenia, string tipo)
        {
            Entidades.Usuario usuario = new Entidades.Usuario(cedula, nombre, domicilio, telefono, contrasenia, tipo, apellido, false);
            return Datos.CRUDUsuario.nuevo(usuario);
        }

        public static bool editar(string cedula, string nombre, string domicilio, string telefono, string contrasenia, string tipo, string apellido, bool baja)
        {
            Entidades.Usuario usuario = new Entidades.Usuario(cedula, nombre, domicilio, telefono, contrasenia, tipo, apellido, baja);
            return Datos.CRUDUsuario.editar(usuario);
        }
        public static bool editar(Entidades.Usuario usuario)
        {
            return Datos.CRUDUsuario.editar(usuario);
        }

    }
}
