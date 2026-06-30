using BLL;
using Services.Entities;
using Services.Observer;
using SistemaAlquiler.Admin;
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
                        Services.Entities.Usuario usuarioCompleto = gestorUsuario.ObtenerPorNombre(usuario);

                        // =========================================================================
                        // INTERCEPCIÓN DÍGITO VERIFICADOR (Validar Integridad de BD)
                        // =========================================================================
                        BLL.DvBLL gestorDV = new BLL.DvBLL();
                        string errorIntegridad;

                        if (!gestorDV.ValidarIntegridad(out errorIntegridad))
                        {
                            // Si detecta manipulación externa, verificamos si es jefe
                            if (usuarioCompleto.Rol == "Administrador" || usuarioCompleto.Rol == "Gerente")
                            {
                                // Es Administrador: Le abrimos la pantalla de solución (CUS-020)
                                FormDv frmDV = new FormDv(errorIntegridad);
                                frmDV.Show();
                                this.Hide();
                                return; // Cortamos el login acá
                            }
                            else
                            {
                                // Es usuario común: Lo rebotamos
                                MessageBox.Show("El sistema no se encuentra disponible en este momento. Intente más tarde.", "Falla de Integridad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return; // Cortamos el login acá
                            }
                        }
                        // =========================================================================

                        // Si pasó el Dígito Verificador, seguimos con el login normal:
                        BitacoraBLL gestorBitacora = new BitacoraBLL();

                        Sesion.Instancia.UsuarioActual = usuarioCompleto.NombreUsuario;
                        RolBLL gestorRol = new RolBLL();
                        Sesion.Instancia.Permisos = gestorRol.ObtenerPermisosDelUsuario(usuarioCompleto.ID_Usuario);

                        string idiomaPreferencia = "es-AR";
                        if (usuarioCompleto != null && !string.IsNullOrEmpty(usuarioCompleto.IdiomaPreferencia))
                        {
                            idiomaPreferencia = usuarioCompleto.IdiomaPreferencia;
                        }

                        Services.Observer.IdiomaManager.Instancia.CambiarIdioma(idiomaPreferencia);

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


        private void FormLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
          
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
       
        }
    }
}
