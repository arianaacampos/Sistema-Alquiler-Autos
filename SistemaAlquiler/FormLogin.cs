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
                    UsuarioBLL gestorUsuario = new UsuarioBLL();
                    string resultado = gestorUsuario.ValidarLogin(usuario, clave);

                    if (resultado == "OK")
                    {

                        Sesion.Instancia.UsuarioActual = usuario;

                        BitacoraBLL gestorBitacora = new BitacoraBLL();
                        gestorBitacora.Registrar(usuario, "Usuario", "Login", "Baja");

                        FormMain menu = new FormMain();
                        menu.Show();
                        this.Hide();
                    }
                    else
                    {

                        BitacoraBLL gestorBitacora = new BitacoraBLL();
                        gestorBitacora.Registrar(usuario, "Usuario", "Login Fallido", "Alta");


                        MessageBox.Show(resultado, "Error de Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, ingrese usuario y contraseña.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el sistema: " + ex.Message);
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBoxUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
