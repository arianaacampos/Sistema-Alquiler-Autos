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
    public partial class FormCambiarClave : Form
    {
        public FormCambiarClave()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string claveActual = txtClaveActual.Text;
                string nuevaClave = txtNuevaClave.Text;
                string confirmar = txtConfirmarClave.Text;

                if (string.IsNullOrWhiteSpace(claveActual) || string.IsNullOrWhiteSpace(nuevaClave) || string.IsNullOrWhiteSpace(confirmar))
                {
                    MessageBox.Show("Por favor, complete todos los campos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (nuevaClave != confirmar)
                {
                    MessageBox.Show("Las contraseñas nuevas no coinciden. Vuelva a intentarlo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string usuarioLogueado = Sesion.Instancia.UsuarioActual;

                UsuarioBLL gestorUsuario = new UsuarioBLL();
                string resultado = gestorUsuario.CambiarClave(usuarioLogueado, claveActual, nuevaClave);

                if (resultado == "OK")
                {
                    MessageBox.Show("¡Contraseña cambiada con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); 
                }
                else
                {
                    MessageBox.Show(resultado, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error del sistema: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
