﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppWinProyectoo
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new RecepcionFactura());
            //Application.Run(new RecepcionAgregarIngreso());
            Application.Run(new RecepcionMenu());
            //Application.Run(new RecepcionFactura());
            //Application.Run(new RecepcionEquiposIngreso());
            Application.Run(new Login());
            //Application.Run(new AdministradorUsuarioListar());
            //Application.Run(new AdministradorRecepcion());
            //Application.Run(new AdministradorPiezas());
            //Application.Run(new AdministradorTrabajo());
            //Application.Run(new Administrador.AdministradorProducto());
            //Application.Run(new Tecnico.TecnicoAceptar());
            //Application.Run(new Tecnico.TecnicoModificar());
        }
    }
}
