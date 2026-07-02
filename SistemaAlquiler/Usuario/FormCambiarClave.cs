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
    public partial class FormCambiarClave : Form, Services.Observer.IObserverIdioma
    {
        public FormCambiarClave()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var idioma = Services.Observer.IdiomaManager.Instancia;
            try
            {
                string claveActual = txtClaveActual.Text;
                string nuevaClave = txtNuevaClave.Text;
                string confirmar = txtConfirmarClave.Text;

                if (string.IsNullOrWhiteSpace(claveActual) || string.IsNullOrWhiteSpace(nuevaClave) || string.IsNullOrWhiteSpace(confirmar))
                {
                    MessageBox.Show(idioma.Traducir("msg_CamposVacios"), idioma.Traducir("tit_Atencion"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (nuevaClave != confirmar)
                {
                    MessageBox.Show(idioma.Traducir("msg_ClavesNoCoinciden"), idioma.Traducir("tit_Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult respuesta = MessageBox.Show(idioma.Traducir("msg_ConfirmarCambioClave"), idioma.Traducir("tit_ConfirmarCambio"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta == DialogResult.No)
                {
                    return;
                }

                string usuarioLogueado = Sesion.Instancia.UsuarioActual;

                UsuarioBLL gestorUsuario = new UsuarioBLL();
                string resultado = gestorUsuario.CambiarClave(usuarioLogueado, claveActual, nuevaClave);

                if (resultado == "OK")
                {
                    MessageBox.Show(idioma.Traducir("msg_ClaveCambiadaExito"), idioma.Traducir("tit_Exito"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show(idioma.Traducir(resultado), idioma.Traducir("tit_Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(idioma.Traducir("msg_ErrorSistema") + ex.Message, idioma.Traducir("tit_Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormCambiarClave_Load(object sender, EventArgs e)
        {
            txtUsuario.Text = Sesion.Instancia.UsuarioActual;
            txtUsuario.Enabled = false;

            Services.Observer.IdiomaManager.Instancia.Suscribir(this);
            ActualizarIdioma();
        }

        public void ActualizarIdioma()
        {
            var idioma = Services.Observer.IdiomaManager.Instancia;

            this.Text = idioma.Traducir("tituloCambiarClave");
            label1.Text = idioma.Traducir("tituloCambiarClave");
            label5.Text = idioma.Traducir("lblClaveActual");
            label4.Text = idioma.Traducir("lblNuevaClave");
            label3.Text = idioma.Traducir("lblConfirmarClave");
            label2.Text = idioma.Traducir("lblUsuario");

            btnAceptar.Text = idioma.Traducir("btnAceptar");
            btnCancelar.Text = idioma.Traducir("buttonCancelar");
        }

        private void FormCambiarClave_FormClosing(object sender, FormClosingEventArgs e)
        {
            Services.Observer.IdiomaManager.Instancia.Desuscribir(this);
        }
    }
}
