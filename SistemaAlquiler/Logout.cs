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
    public partial class Logout : Form
    {
        public Logout()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
   
                BitacoraBLL gestorBitacora = new BitacoraBLL();
                gestorBitacora.Registrar(Sesion.Instancia.UsuarioActual, "Usuario", "Cierre de Sesión", "Baja");
                Sesion.Instancia.FinalizarSesion();
               FormLogin login = new FormLogin();
                login.Show();
                this.Close(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cerrar sesión: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           FormMain main = new FormMain(); main.ShowDialog();
            this.Close();
        }
    }
}
