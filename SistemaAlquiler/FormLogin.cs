using BLL;
using Services.Entities;
using Services.Observer;
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
    public partial class FormLogin : Form, IObserverIdioma
    {
        public FormLogin()
        {
            InitializeComponent();
            IdiomaManager.Instancia.Suscribir(this);
            ActualizarIdioma();
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
                        BitacoraBLL gestorBitacora = new BitacoraBLL();
                        Sesion.Instancia.UsuarioActual = usuario;
                        gestorBitacora.Registrar(usuario, "Usuario", "Login", "Baja");

                        FormMain menu = new FormMain();
                        menu.Show();
                        this.Hide();
                    }
                    else
                    {
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
            this.Close();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            if (Sesion.Instancia.UsuarioActual != null)
            {
                MessageBox.Show("Error: ya hay una sesión iniciada.", "Error de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        public void ActualizarIdioma()
        {
            lblUsuario.Text = IdiomaManager.Instancia.Traducir("lblUsuario");
            lblClave.Text = IdiomaManager.Instancia.Traducir("lblClave");
            btnAceptar.Text = IdiomaManager.Instancia.Traducir("btnAceptar");
            buttonCancelar.Text = IdiomaManager.Instancia.Traducir("buttonCancelar");
            this.Text = IdiomaManager.Instancia.Traducir("tituloLogin");
        }

        private void FormLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            IdiomaManager.Instancia.Desuscribir(this);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Ingles")
            {
                // Le dice al jefe que cargue en-US.json y pegue el grito
                IdiomaManager.Instancia.CambiarIdioma("en-US");
            }
            else if (comboBox1.Text == "Español")
            {
                // Le dice al jefe que cargue es-AR.json y pegue el grito
                IdiomaManager.Instancia.CambiarIdioma("es-AR");
            }
        }
    }
}
