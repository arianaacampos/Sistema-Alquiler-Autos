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

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            Logout salir= new Logout();
            salir.Show();
            this.Hide();
        }

        private void buttonUsuarios_Click(object sender, EventArgs e)
        {
            FormBitacora bit = new FormBitacora(); bit.ShowDialog();
            this.Close();
        }

        private void buttonEntidades_Click(object sender, EventArgs e)
        {
            FormUsuarios usuarios = new FormUsuarios();
            usuarios.Show();
            this.Hide();
        }
    }
}
