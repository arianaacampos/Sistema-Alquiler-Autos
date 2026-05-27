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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void buttonIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                string usuario = textBoxUsuario.Text;
                string clave = textBoxPassword.Text;


                if (!string.IsNullOrEmpty(usuario) && !string.IsNullOrEmpty(clave))
                {

                    Sesion.Instancia.UsuarioActual = usuario;
                    BitacoraBLL gestorBitacora = new BitacoraBLL();
                    gestorBitacora.Registrar(usuario, "Usuario", "Inicio de Sesión Exitoso", "Baja");

                    MessageBox.Show("¡Bienvenido al sistema, " + usuario + "!");

 
                    FormMain menu = new FormMain();
                    menu.Show();
                    this.Hide(); 
                }
                else
                {
                    MessageBox.Show("Por favor, ingrese usuario y contraseña.");

                    BitacoraBLL gestorBitacora = new BitacoraBLL();
                    gestorBitacora.Registrar("Desconocido", "Usuario", "Intento de Sesión Fallido", "Alta");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al iniciar sesión: " + ex.Message);
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
