using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuario
    {
        string cedula;
        string nombre;
        string domicilio;
        string telefono;
        string contrasenia;
        string tipo;
        string apellido;
        bool baja = false;

        public Usuario()
        {

        }

        public Usuario(string cedula, string nombre, string domicilio, string telefono, string contrasenia, string tipo, string apellido)
        {
            this.cedula = cedula;
            this.nombre = nombre;
            this.domicilio = domicilio;
            this.telefono = telefono;
            this.contrasenia = contrasenia;
            this.tipo = tipo;
            this.apellido = apellido;
        }

        public Usuario(string cedula, string nombre, string domicilio, string telefono, string contrasenia, string tipo, string apellido, bool baja)
        {
            this.cedula = cedula;
            this.nombre = nombre;
            this.domicilio = domicilio;
            this.telefono = telefono;
            this.contrasenia = contrasenia;
            this.tipo = tipo;
            this.apellido = apellido;
            this.baja = baja;
        }

        public string Cedula
        {
            get
            {
                return cedula;
            }

            set
            {
                cedula = value;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public string Domicilio
        {
            get
            {
                return domicilio;
            }

            set
            {
                domicilio = value;
            }
        }

        public string Telefono
        {
            get
            {
                return telefono;
            }

            set
            {
                telefono = value;
            }
        }

        public string Contrasenia
        {
            get
            {
                return contrasenia;
            }

            set
            {
                contrasenia = value;
            }
        }

        public string Tipo
        {
            get
            {
                return tipo;
            }

            set
            {
                tipo = value;
            }
        }

        public string Apellido
        {
            get
            {
                return apellido;
            }

            set
            {
                apellido = value;
            }
        }

        public bool Baja
        {
            get
            {
                return baja;
            }

            set
            {
                baja = value;
            }
        }
    }
}
