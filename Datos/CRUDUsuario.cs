using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public static class CRUDUsuario
    {
        static baseDataContext db = new baseDataContext();

        public static bool nuevo(Entidades.Usuario usuario)
        {
            bool retorno = false;
            Usuario nuevo = new Usuario();
            nuevo.usu_nombre = usuario.Nombre;
            nuevo.usu_apellido = usuario.Apellido;
            nuevo.usu_cedula = usuario.Cedula;
            nuevo.usu_contrasenia = usuario.Contrasenia;
            nuevo.usu_domicilio = usuario.Contrasenia;
            nuevo.usu_telefono = usuario.Telefono;
            nuevo.usu_tipo = usuario.Tipo;
            nuevo.usu_baja = usuario.Baja;
            try
            {
                db.Usuario.InsertOnSubmit(nuevo);
                db.SubmitChanges();
                retorno = true;
            }
            catch(Exception e)
            {
            }

            return retorno;
        }

        public static bool editar(Entidades.Usuario usuario)
        {
            bool retorno = false;

            try
            {
                var sql =
                    from c in db.Usuario
                    where c.usu_cedula == usuario.Cedula
                    select c;

                foreach (var s in sql)
                {
                    s.usu_nombre = usuario.Nombre;
                    s.usu_apellido = usuario.Apellido;
                    s.usu_baja = usuario.Baja;
                    s.usu_contrasenia = usuario.Contrasenia;
                    s.usu_domicilio = usuario.Domicilio;
                    s.usu_nombre = usuario.Nombre;
                    s.usu_telefono = usuario.Telefono;
                    s.usu_tipo = usuario.Tipo;
                    db.SubmitChanges();
                    retorno = true;
                }
            }
            catch (Exception e)
            {
                
            }

            return retorno;

        }

        public static bool eliminar(string cedula)
        {
            bool retorno = false;

            try
            {
                var sql =
                    from c in db.Usuario
                    where c.usu_cedula == cedula
                    select c;
                foreach (var c in sql)
                {
                    db.Usuario.DeleteOnSubmit(c);
                    db.SubmitChanges();
                    retorno = true;
                }
            }
            catch (Exception e)
            {

            }
            return retorno;

        }

        public static Entidades.Usuario buscar(string cedula)
        {
            Entidades.Usuario retorno = null;
            Usuario encontrado = null;

            try
            {
                var sql =
                    from c in db.Usuario
                    where c.usu_cedula == cedula
                    select c;
                foreach (var c in sql)
                {
                    encontrado = (Usuario)c;
                }

                if(encontrado != null)
                {
                    retorno = new Entidades.Usuario();

                    retorno.Cedula = encontrado.usu_cedula;
                    retorno.Apellido = encontrado.usu_apellido;
                    retorno.Baja = (bool)encontrado.usu_baja;
                    retorno.Contrasenia = encontrado.usu_contrasenia;
                    retorno.Domicilio = encontrado.usu_domicilio;
                    retorno.Nombre = encontrado.usu_nombre;
                    retorno.Telefono = encontrado.usu_telefono;
                    retorno.Tipo = encontrado.usu_tipo;                   

                }
            }
            catch (Exception e)
            {

            }
            return retorno;
        }

        public static List<Entidades.Usuario> listaUsuario()
        {
            List<Entidades.Usuario> lista = new List<Entidades.Usuario>();
            try
            {
                var sql =
                    from c in db.Usuario
                    select c;
                foreach (var c in sql)
                {
                    if(!c.usu_cedula.StartsWith("0         "))
                        lista.Add(datoAEntidad(c));
                }
            }
            catch (Exception e)
            {
            }
            return lista;
        }

        public static List<Entidades.Usuario> listaUsuarioPorCedula(string cedula)
        {
            List<Entidades.Usuario> lista = new List<Entidades.Usuario>();
            try
            {
                var sql =
                    from c in db.Usuario
                    select c;
                foreach (var c in sql)
                {
                    if (c.usu_cedula.ToLower().Contains(cedula.ToLower()))
                        lista.Add(datoAEntidad(c));
                }
            }
            catch (Exception e)
            {
            }
            return lista;
        }

        public static List<Entidades.Usuario> listaUsuarioPorNombre(string nombre)
        {
            List<Entidades.Usuario> lista = new List<Entidades.Usuario>();
            try
            {
                var sql =
                    from c in db.Usuario
                    select c;
                foreach (var c in sql)
                {
                    if (c.usu_nombre.ToLower().Contains(nombre.ToLower()))
                        lista.Add(datoAEntidad(c));
                }
            }
            catch (Exception e)
            {
            }
            return lista;
        }

        public static List<Entidades.Usuario> listaUsuarioPorApellido(string apellido)
        {
            List<Entidades.Usuario> lista = new List<Entidades.Usuario>();
            try
            {
                var sql =
                    from c in db.Usuario
                    select c;
                foreach (var c in sql)
                {
                    if (c.usu_apellido.ToLower().Contains(apellido.ToLower()))
                        lista.Add(datoAEntidad(c));
                }
            }
            catch (Exception e)
            {
            }
            return lista;
        }
                
        public static Entidades.Usuario datoAEntidad(Usuario u)
        {
            Entidades.Usuario retorno = new Entidades.Usuario();
            retorno.Apellido = u.usu_apellido;
            retorno.Baja = (bool)u.usu_baja;
            retorno.Telefono = u.usu_telefono;
            retorno.Cedula = u.usu_cedula;
            retorno.Contrasenia = u.usu_contrasenia;
            retorno.Domicilio = u.usu_domicilio;
            retorno.Nombre = u.usu_nombre;
            retorno.Tipo = u.usu_tipo;            
            return retorno;
        }

    }
}
