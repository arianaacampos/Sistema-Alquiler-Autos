using BLL;
using SistemaAlquiler.Seguridad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaAlquiler
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        //[STAThread]
        //static void Main()
        //{
        //    Application.EnableVisualStyles();
        //    Application.SetCompatibleTextRenderingDefault(false);
        //    Application.Run(new FormLogin());
        //}
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ConfiguradorBLL gestorConfig = new ConfiguradorBLL();

            // Le preguntamos a la BLL si la BD responde
            if (!gestorConfig.ProbarConexionActual())
            {
                // Si no responde, abrimos tu formulario escáner
                FormConfigurarServidor frmConfig = new FormConfigurarServidor();
                if (frmConfig.ShowDialog() != DialogResult.OK)
                {
                    return; // Si cierra con la X, matamos el programa
                }
            }

            // Si todo está bien, abrimos el Login
            Application.Run(new FormLogin());
        }
    }
}
