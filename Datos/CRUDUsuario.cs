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
            bool retorno = true;
            Usuario nuevo = new Usuario();
            nuevo.usu_nombre = usuario.Nombre;
            nuevo.usu_apellido = usuario.Apellido;
            nuevo.usu_cedula = usuario.Cedula;
            nuevo.usu_contrasenia = usuario.Contrasenia;
            nuevo.usu_domicilio = usuario.Contrasenia;
            nuevo.usu_telefono = usuario.Telefono;
            nuevo.usu_tipo = usuario.Tipo;

            try
            {
                db.Usuario.InsertOnSubmit(nuevo);
                db.SubmitChanges();
            }
            catch(Exception e)
            {
                retorno =  false;
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
    }
}
