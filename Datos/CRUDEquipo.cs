using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public static class CRUDEquipo
    {
        static baseDataContext db = new baseDataContext();

        public static bool nuevo(Entidades.Equipo equipo)
        {
            bool retorno = true;
            Equipo nuevo = new Equipo();
            
            nuevo.equ_modelo = equipo.Modelo;
            nuevo.equ_n_factura = equipo.N_factura;
            nuevo.equ_serie = equipo.Serie;
            nuevo.equ_tipo = equipo.Tipo;
            nuevo.equ__n_ingresos = equipo.N_ingresos;
            try
            {
                db.Equipo.InsertOnSubmit(nuevo);
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                retorno = false;
            }
            return retorno;
        }

        public static bool editar(Entidades.Equipo equipo)
        {
            bool retorno = false;
            try
            {
                var sql =
                    from c in db.Equipo
                    where c.equ_serie == equipo.Serie
                    select c;

                foreach (var s in sql)
                {
                    s.equ_modelo = equipo.Modelo;
                    s.equ_n_factura = equipo.N_factura;
                    s.equ_serie = equipo.Serie;
                    s.equ_tipo = equipo.Tipo;
                    s.equ__n_ingresos = equipo.N_ingresos;
                    db.SubmitChanges();
                    retorno = true;
                }
            }
            catch (Exception e)
            {

            }
            return retorno;
        }

        public static bool eliminar(string serie)
        {
            bool retorno = false;

            try
            {
                var sql =
                    from c in db.Equipo
                    where c.equ_serie == serie
                    select c;
                foreach (var c in sql)
                {
                    db.Equipo.DeleteOnSubmit(c);
                    db.SubmitChanges();
                    retorno = true;
                }
            }
            catch (Exception e)
            {

            }
            return retorno;
        }

        public static Entidades.Equipo buscar(string serie)
        {
            Entidades.Equipo retorno = null;
            Equipo encontrado = null;

            try
            {
                var sql =
                    from c in db.Equipo
                    where c.equ_serie == serie
                    select c;
                foreach (var c in sql)
                {
                    encontrado = (Equipo)c;
                }

                if (encontrado != null)
                {
                    retorno = new Entidades.Equipo();

                    retorno.Modelo = encontrado.equ_modelo;
                    retorno.N_factura = (int)encontrado.equ_n_factura;
                    retorno.N_ingresos = (short)encontrado.equ__n_ingresos;
                    retorno.Serie = encontrado.equ_serie;
                    retorno.Tipo = encontrado.equ_tipo;
                }
            }
            catch (Exception e)
            {
            }
            return retorno;
        }

        public static List<Entidades.Equipo> listar()
        {
            List<Entidades.Equipo> retorno = new List<Entidades.Equipo>();
            try
            {
                var sql =
                    from c in db.Equipo
                    select c;

                foreach (var s in sql)
                {
                    retorno.Add(datoAEntidad(s));
                }
            }
            catch (Exception e)
            {
            }
            return retorno;
        }
        
        public static Entidades.Equipo datoAEntidad(Equipo equipo)
        {
            Entidades.Equipo retorno = new Entidades.Equipo();
            retorno.Modelo = equipo.equ_modelo;
            retorno.N_factura = (int)equipo.equ_n_factura;
            retorno.N_ingresos = (short)equipo.equ__n_ingresos;
            retorno.Serie = equipo.equ_serie;
            retorno.Tipo = equipo.equ_tipo;
            return retorno;
        }

        public static Equipo entidadADato(Entidades.Equipo equipo)
        {
            Equipo retorno = new Equipo();
            retorno.equ_modelo = equipo.Modelo;
            retorno.equ_n_factura = equipo.N_factura;
            retorno.equ_serie = equipo.Serie;
            retorno.equ_tipo = equipo.Tipo;
            retorno.equ__n_ingresos = equipo.N_ingresos;
            return retorno;
        }

    }
}
