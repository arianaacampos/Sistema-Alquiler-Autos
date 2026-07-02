using BLL;
using Services.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaAlquiler.Seguridad
{
    public partial class Logout : Form, Services.Observer.IObserverIdioma
    {
        public Logout()
        {
            InitializeComponent();
        }

        public void ActualizarIdioma()
        {
            this.Text = Services.Observer.IdiomaManager.Instancia.Traducir("tituloLogout");
            label1.Text = Services.Observer.IdiomaManager.Instancia.Traducir("lblConfirmacionLogout");
            button1.Text = Services.Observer.IdiomaManager.Instancia.Traducir("btnAceptarLogout");
            button2.Text = Services.Observer.IdiomaManager.Instancia.Traducir("btnCancelarLogout");
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var idioma = Services.Observer.IdiomaManager.Instancia;
            try
            {
                string mensaje = string.Format(idioma.Traducir("msg_SesionCerrada"), Sesion.Instancia.UsuarioActual);

                MessageBox.Show(mensaje, idioma.Traducir("tit_SesionFinalizada"), MessageBoxButtons.OK, MessageBoxIcon.Information);

                BitacoraBLL gestorBitacora = new BitacoraBLL();
                gestorBitacora.Registrar(Sesion.Instancia.UsuarioActual, "Usuario", "Logout", "Baja");

                Sesion.Instancia.FinalizarSesion();

                FormLogin login = new FormLogin();
                login.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(idioma.Traducir("msg_ErrorCerrarSesion") + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Logout_Load(object sender, EventArgs e)
        {
            Services.Observer.IdiomaManager.Instancia.Suscribir(this);
            ActualizarIdioma();
        }

        private void Logout_FormClosing(object sender, FormClosingEventArgs e)
        {
            Services.Observer.IdiomaManager.Instancia.Desuscribir(this);
        }
    }
}
