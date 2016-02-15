using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public static class CRUDIngreso
    {
        static baseDataContext db = new baseDataContext();
        public static bool nuevo(Entidades.Ingreso ingreso)
        {
            bool retorno = true;
            Ingreso nuevo = new Ingreso();
            nuevo.ing_ced_cliente = ingreso.Ced_cliente;
            nuevo.ing_accesorios = ingreso.Accesorios;
            nuevo.ing_ced_recepcionista = ingreso.Ced_recepcionista;
            nuevo.ing_ced_tecnico = ingreso.Ced_tecnico;
            nuevo.ing_codigo = ingreso.Codigo;
            nuevo.ing_estado = ingreso.Estado;
            nuevo.ing_fecha = ingreso.Fecha;
            nuevo.ing_garantía = ingreso.Garantia;
            nuevo.ing_n_factura = ingreso.N_factura;
            nuevo.ing_observaciones = ingreso.Observaciones;
            nuevo.ing_problema = ingreso.Problema;
            nuevo.ing_serie_equipo = ingreso.Serie_equipo;

            //try
            //{
                db.Ingreso.InsertOnSubmit(nuevo);
                db.SubmitChanges();
            //}
            //catch (Exception e)
            //{
            //    retorno = false;
            //}


            return retorno;
        }

        public static bool editar(Entidades.Ingreso ingreso)
        {
            bool retorno = false;
            try
            {                var sql =
                    from c in db.Ingreso
                    where c.ing_codigo == ingreso.Codigo
                    select c;
                foreach (var s in sql)
                {
                    s.ing_accesorios = ingreso.Accesorios;
                    s.ing_ced_cliente = ingreso.Ced_cliente;
                    s.ing_ced_recepcionista = ingreso.Ced_recepcionista;
                    s.ing_ced_tecnico = ingreso.Ced_tecnico;
                    s.ing_codigo = ingreso.Codigo;
                    s.ing_estado = ingreso.Estado;
                    s.ing_fecha = ingreso.Fecha;
                    s.ing_garantía = ingreso.Garantia;
                    s.ing_n_factura = ingreso.N_factura;
                    s.ing_observaciones = ingreso.Observaciones;
                    s.ing_problema = ingreso.Problema;
                    s.ing_serie_equipo = ingreso.Serie_equipo;

                    db.SubmitChanges();
                    retorno = true;
                }
            }
            catch (Exception e)
            {
            }
            return retorno;
        }

        public static bool eliminar(int codigo)
        {
            bool retorno = false;

            try
            {
                var sql =
                    from c in db.Ingreso
                    where c.ing_codigo == codigo
                    select c;
                foreach (var c in sql)
                {
                    db.Ingreso.DeleteOnSubmit(c);
                    db.SubmitChanges();
                    retorno = true;
                }
            }
            catch (Exception e)
            {
            }
            return retorno;
        }

        public static Entidades.Ingreso buscar(int codigo)
        {
            Entidades.Ingreso retorno = null;
            Ingreso encontrado = null;

            try
            {
                var sql =
                    from c in db.Ingreso
                    where c.ing_codigo == codigo
                    select c;
                foreach (var c in sql)
                {
                    encontrado = (Ingreso)c;
                }

                if (encontrado != null)
                {
                    retorno = new Entidades.Ingreso();

                    retorno.Codigo = encontrado.ing_codigo;
                    retorno.Accesorios = encontrado.ing_accesorios;
                    retorno.Ced_cliente = encontrado.ing_ced_cliente;
                    retorno.Ced_recepcionista = encontrado.ing_ced_recepcionista;
                    retorno.Ced_tecnico = encontrado.ing_ced_tecnico;
                    retorno.Estado = encontrado.ing_estado;
                    retorno.Fecha = (DateTime)encontrado.ing_fecha;
                    retorno.Garantia = (bool)encontrado.ing_garantía;
                    retorno.N_factura = (int)encontrado.ing_n_factura;
                    retorno.Observaciones = encontrado.ing_observaciones;
                    retorno.Problema = encontrado.ing_problema;
                    retorno.Serie_equipo = encontrado.ing_serie_equipo;
                }
            }
            catch (Exception e)
            {

            }
            return retorno;
        }

        public static int siguienteIngreso()
        {
            int retorno = 0;
            try
            {
                var sql =
                    from c in db.Ingreso                    
                    select c;
                foreach (var c in sql)
                {
                    retorno = c.ing_codigo + 1;
                }               
            }
            catch (Exception e)
            {
            }
            return retorno +1;
        }

        public static List<Entidades.Ingreso> listaIngresos()
        {
            List<Entidades.Ingreso> lista = new List<Entidades.Ingreso>();
            try
            {
                var sql =
                    from c in db.Ingreso
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

        public static List<Entidades.Ingreso> listaReparadas()
        {
            List<Entidades.Ingreso> lista = new List<Entidades.Ingreso>();
            try
            {
                var sql =
                    from c in db.Ingreso
                    where c.ing_estado == "reparado" && (bool)c.ing_garantía
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
        
        public static Entidades.Ingreso datoAEntidad(Ingreso encontrado)
        {
            Entidades.Ingreso retorno = new Entidades.Ingreso();
            retorno.Codigo = encontrado.ing_codigo;
            retorno.Accesorios = encontrado.ing_accesorios;
            retorno.Ced_cliente = encontrado.ing_ced_cliente;
            retorno.Ced_recepcionista = encontrado.ing_ced_recepcionista;
            retorno.Ced_tecnico = encontrado.ing_ced_tecnico;
            retorno.Estado = encontrado.ing_estado;
            retorno.Fecha = (DateTime)encontrado.ing_fecha;
            retorno.Garantia = (bool)encontrado.ing_garantía;
            retorno.N_factura = (int)encontrado.ing_n_factura;
            retorno.Observaciones = encontrado.ing_observaciones;
            retorno.Problema = encontrado.ing_problema;
            retorno.Serie_equipo = encontrado.ing_serie_equipo;
            return retorno;
        }

        public static List<Entidades.Ingreso> listaIngresados()
        {
            List<Entidades.Ingreso> lista = new List<Entidades.Ingreso>();
            try
            {
                var sql =
                    from c in db.Ingreso
                    where c.ing_estado == "ingresado"
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

        public static List<Entidades.Ingreso> listaAceptados()
        {
            List<Entidades.Ingreso> lista = new List<Entidades.Ingreso>();
            try
            {
                var sql =
                    from c in db.Ingreso
                    where c.ing_estado == "aceptado"
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


    }
}
