using Services.Entities;
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
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
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
            Application.Exit();
        }
    }
}