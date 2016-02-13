using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocios
{
    public static class LogicaIngreso
    {
        public static List<Entidades.Ingreso> listaReparados()
        {
           return Datos.CRUDIngreso.listaReparadas();
        }

        public static Entidades.Ingreso buscar(int codigo)
        {
            return Datos.CRUDIngreso.buscar(codigo);
        }

        public static List<string> trabajos(int codigo)
        {
            List<string> retorno = new List<string>();

            List<Entidades.Trabajo> trabajos = Datos.CRUDTrabajoRealizado.trabajosPorIngreso(codigo);

            foreach(Entidades.Trabajo t in trabajos)
            {
                retorno.Add(t.Descripcion);
            }

            List<Entidades.Pieza> piezas = Datos.CRUDPiezaUsada.piezasPorIngreso(codigo);

            foreach (Entidades.Pieza p in piezas)
            {
                retorno.Add("Cambio de "  + p.Tipo);
            }

            return retorno;
        }

        public static bool retirar(int codigo)
        {
            bool retorno = false;
            Entidades.Ingreso ingreso = Datos.CRUDIngreso.buscar(codigo);
            ingreso.Estado = "retirado";
            retorno = Datos.CRUDIngreso.editar(ingreso);
            return retorno;
        }

        public static List<string[]> lista()
        {
            List<string[]> retorno = new List<string[]>();
            string[] cadena;
            Entidades.Equipo equipo;
            Entidades.Cliente cliente;
            List<Entidades.Ingreso> lista = Datos.CRUDIngreso.listaIngresos();
            foreach(Entidades.Ingreso ingreso in lista)
            {
                equipo = Datos.CRUDEquipo.buscar(ingreso.Serie_equipo);
                cliente = Datos.CRUDCliente.buscar(ingreso.Ced_cliente);
                cadena = new string[5];
                cadena[0] = ingreso.Codigo.ToString();
                cadena[1] = equipo.Modelo;
                cadena[2] = cliente.nombreCompleto();
                cadena[3] = ingreso.Estado;
                cadena[4] = ingreso.Costo.ToString();
                retorno.Add(cadena);
            }
            return retorno;
        }

        public static List<string[]> listaCobrar()
        {
            List<string[]> retorno = new List<string[]>();
            string[] cadena;
            Entidades.Equipo equipo;
            Entidades.Cliente cliente;
            List<Entidades.Ingreso> lista = Datos.CRUDIngreso.listaIngresos();
            foreach (Entidades.Ingreso ingreso in lista)
            {
                if(ingreso.Estado == "reparado" && !ingreso.Garantia)
                {
                    equipo = Datos.CRUDEquipo.buscar(ingreso.Serie_equipo);
                    cliente = Datos.CRUDCliente.buscar(ingreso.Ced_cliente);
                    cadena = new string[4];
                    cadena[0] = ingreso.Codigo.ToString();
                    cadena[1] = equipo.Modelo;
                    cadena[2] = cliente.nombreCompleto();
                    cadena[3] = ingreso.Costo.ToString();
                    retorno.Add(cadena);
                }                
            }
            return retorno;
        }

        public static Entidades.Cliente cliente(int codigo)
        {
            Entidades.Ingreso ingreso = Datos.CRUDIngreso.buscar(codigo);
            return LogicaCliente.buscar(ingreso.Ced_cliente);
        }

        public static Entidades.Equipo equipo(int codigo)
        {
            Entidades.Ingreso ingreso = Datos.CRUDIngreso.buscar(codigo);
            return LogicaEquipo.buscar(ingreso.Serie_equipo);
        }

        public static bool editar(Entidades.Ingreso ingreso)
        {
            return Datos.CRUDIngreso.editar(ingreso);
        }
    }
}
