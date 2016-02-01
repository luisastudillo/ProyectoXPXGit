using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocios
{
    public static class LogicaLogin
    {
        public static Entidades.Usuario ingresar(string cedula, string contrasenia)
        {
            Entidades.Usuario retorno;
            retorno = Datos.CRUDUsuario.buscar(cedula);
            if(retorno != null)
            {
                if (!retorno.Contrasenia.Equals(contrasenia))
                    retorno = null;
            }
            return retorno;
        }
    }
}
