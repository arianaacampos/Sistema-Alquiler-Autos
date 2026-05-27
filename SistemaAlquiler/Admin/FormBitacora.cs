using BLL;
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
    public partial class FormBitacora : Form
    {
        public FormBitacora()
        {
            InitializeComponent();
        }
        private void ActualizarGrilla()
        {
            try
            {
                BitacoraBLL gestorBitacora = new BitacoraBLL();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = gestorBitacora.Consultar();

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al traer los datos: " + ex.Message);
            }
        }

        private void FormBitacora_Load(object sender, EventArgs e)
        {
            ActualizarGrilla();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormMain main = new FormMain(); main.ShowDialog();
            this.Close();
        }
    }
}
