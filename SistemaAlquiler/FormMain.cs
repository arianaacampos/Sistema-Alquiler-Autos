using Services.Entities;
using Services.Observer;
using SistemaAlquiler.Admin;
using SistemaAlquiler.Seguridad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SistemaAlquiler
{
    public partial class FormMain : Form, IObserverIdioma
    {
        public FormMain()
        {
            InitializeComponent();
            IdiomaManager.Instancia.Suscribir(this);
            ActualizarIdioma();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUsuarios usuarios = new FormUsuarios();
            this.Hide();           
            usuarios.ShowDialog(); 
            this.Show();
        }

        private void bitacoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBitacora bit = new FormBitacora();
            this.Hide();           
            bit.ShowDialog();      
            this.Show();
        }

        private void cambiarClaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCambiarClave cambiarClave = new FormCambiarClave();
            this.Hide();               
            cambiarClave.ShowDialog(); 
            this.Show();
        }

        private void reLoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLogin loginExtra = new FormLogin();
            this.Hide();               
            loginExtra.ShowDialog();   
            this.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logout salir = new Logout();
            this.Hide();           
            salir.ShowDialog();    

            if (Sesion.Instancia.UsuarioActual != null)
            {
                this.Show();
            }
            else
            {
                this.Close();
            }
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            IdiomaManager.Instancia.Desuscribir(this);
            Application.Exit();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void CambiarYGuardarIdioma(string idioma)
        {
            Services.Observer.IdiomaManager.Instancia.CambiarIdioma(idioma);

            if (!string.IsNullOrEmpty(Services.Entities.Sesion.Instancia.UsuarioActual))
            {
                string usuarioLogueado = Services.Entities.Sesion.Instancia.UsuarioActual;

                BLL.UsuarioBLL gestorUsuario = new BLL.UsuarioBLL();
                gestorUsuario.ModificarIdiomaUsuario(usuarioLogueado, idioma);

                BLL.BitacoraBLL gestorBitacora = new BLL.BitacoraBLL();
                gestorBitacora.Registrar(usuarioLogueado, "Usuario", "Cambiar Idioma", "Baja");
            }

            MessageBox.Show(idioma == "es-AR" ? "Idioma actualizado a Español." : "Language updated to English.",
                            "Idioma", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void inglesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            CambiarYGuardarIdioma("en-US");

        }

        private void españolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CambiarYGuardarIdioma("es-AR");
         
        }

        public void ActualizarIdioma()
        {
            // MENÚS PRINCIPALES
            adminToolStripMenuItem.Text = Services.Observer.IdiomaManager.Instancia.Traducir("Admin");
            maestrosToolStripMenuItem.Text = Services.Observer.IdiomaManager.Instancia.Traducir("Maestros");
            usuarioToolStripMenuItem.Text = Services.Observer.IdiomaManager.Instancia.Traducir("Usuario");
            operacionesToolStripMenuItem.Text = Services.Observer.IdiomaManager.Instancia.Traducir("Operaciones");
            mantenimientoToolStripMenuItem.Text = Services.Observer.IdiomaManager.Instancia.Traducir("Mantenimiento");
            reporteToolStripMenuItem.Text = Services.Observer.IdiomaManager.Instancia.Traducir("Reportes");
            ayudaToolStripMenuItem.Text = Services.Observer.IdiomaManager.Instancia.Traducir("Ayuda");

            // SUBMENÚS ADMIN
            usuariosToolStripMenuItem.Text = Services.Observer.IdiomaManager.Instancia.Traducir("Usuarios");
            perfilesToolStripMenuItem.Text = Services.Observer.IdiomaManager.Instancia.Traducir("Perfiles");
            backupToolStripMenuItem.Text = Services.Observer.IdiomaManager.Instancia.Traducir("Backup");
            restoreToolStripMenuItem.Text = Services.Observer.IdiomaManager.Instancia.Traducir("Restore");
            bitacoraToolStripMenuItem.Text = Services.Observer.IdiomaManager.Instancia.Traducir("Bitacora");
            digitoVerificarToolStripMenuItem.Text = Services.Observer.IdiomaManager.Instancia.Traducir("DigitoVerificar"); 

            // SUBMENÚS MAESTROS
            vehiculoToolStripMenuItem.Text = Services.Observer.IdiomaManager.Instancia.Traducir("Vehiculo");
            clienteToolStripMenuItem.Text = Services.Observer.IdiomaManager.Instancia.Traducir("Cliente");
            tallerToolStripMenuItem.Text = Services.Observer.IdiomaManager.Instancia.Traducir("Taller");

            // SUBMENÚS USUARIO
            cambiarIdiomaToolStripMenuItem.Text = Services.Observer.IdiomaManager.Instancia.Traducir("CambiarIdioma");
            cambiarClaveToolStripMenuItem.Text = Services.Observer.IdiomaManager.Instancia.Traducir("CambiarClave");
            reLoginToolStripMenuItem.Text = Services.Observer.IdiomaManager.Instancia.Traducir("ReLogin");
            logoutToolStripMenuItem.Text = Services.Observer.IdiomaManager.Instancia.Traducir("Logout");

            // Los submenús para cambiar el idioma propiamente dichos:
            inglesToolStripMenuItem.Text = Services.Observer.IdiomaManager.Instancia.Traducir("Ingles"); 
            españolToolStripMenuItem.Text = Services.Observer.IdiomaManager.Instancia.Traducir("Espanol"); 

            // SUBMENÚS OPERACIONES
            registrarAlquilerToolStripMenuItem.Text = Services.Observer.IdiomaManager.Instancia.Traducir("RegistrarAlquiler");
            registrarDevolucionToolStripMenuItem.Text = Services.Observer.IdiomaManager.Instancia.Traducir("RegistrarDevolucion");
            cancelarReservaToolStripMenuItem.Text = Services.Observer.IdiomaManager.Instancia.Traducir("CancelarReserva");
            consultarDisponibilidadToolStripMenuItem.Text = Services.Observer.IdiomaManager.Instancia.Traducir("ConsultarDisponibilidad");

            // SUBMENÚS MANTENIMIENTO
            enviarAlTallerToolStripMenuItem.Text = Services.Observer.IdiomaManager.Instancia.Traducir("EnviarTaller");
            registrarServicioMecanicoToolStripMenuItem.Text = Services.Observer.IdiomaManager.Instancia.Traducir("RegistrarServicioMecanico"); 

            // SUBMENÚS REPORTES 
            rentabilidadPorVehiculoToolStripMenuItem.Text = Services.Observer.IdiomaManager.Instancia.Traducir("RepAlquileres"); 
            historialDeGastosPorUnidadToolStripMenuItem.Text = Services.Observer.IdiomaManager.Instancia.Traducir("RepVehiculos"); 
            estadisticaDeAlquileresMasSolicitadosToolStripMenuItem.Text = Services.Observer.IdiomaManager.Instancia.Traducir("RepBitacora");

            // SUBMENÚS AYUDA
            manualDeUsuarioToolStripMenuItem.Text = Services.Observer.IdiomaManager.Instancia.Traducir("ManualUsuario"); 

            this.Text = Services.Observer.IdiomaManager.Instancia.Traducir("tituloMain");

        }

        private void perfilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPerfiles perfil = new FormPerfiles();
            this.Hide();
            perfil.ShowDialog();
            this.Show();
        }
    }
}