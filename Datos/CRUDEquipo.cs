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
    }
}
