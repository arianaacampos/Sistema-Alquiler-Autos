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
                    MessageBox.Show("Completa todos los campos", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (nuevaClave != confirmar)
                {
                    MessageBox.Show("Las contraseñas no coinciden", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult respuesta = MessageBox.Show("¿Desea confirmar?","Confirmar cambio",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

                if (respuesta == DialogResult.No)
                {
                    return;
                }

                string usuarioLogueado = Sesion.Instancia.UsuarioActual;

                UsuarioBLL gestorUsuario = new UsuarioBLL();
                string resultado = gestorUsuario.CambiarClave(usuarioLogueado, claveActual, nuevaClave);

                if (resultado == "OK")
                {
                    MessageBox.Show("Contraseña cambiada con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void FormCambiarClave_Load(object sender, EventArgs e)
        {
            txtUsuario.Text = Sesion.Instancia.UsuarioActual; 
            txtUsuario.Enabled = false;
        }
    }
}
