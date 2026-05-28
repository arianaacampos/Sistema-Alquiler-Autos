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
        private BitacoraBLL gestorBitacora = new BitacoraBLL();
        public FormBitacora()
        {
            InitializeComponent();
        }
        private void ActualizarGrilla()
        {
            try
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = gestorBitacora.Consultar();

                dataGridView1.Columns["ID_Bitacora"].Visible = false;
                dataGridView1.Columns["Usuario"].HeaderText = "Login";
                dataGridView1.Columns["FechaHora"].HeaderText = "Fecha y Hora";
                dataGridView1.Columns["FechaHora"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al traer los datos: " + ex.Message);
            }
        }

        private void FormBitacora_Load(object sender, EventArgs e)
        {
            button2_Click(null, null);
            dateTimePickerDesde.Value = DateTime.Now.AddDays(-3);
            dateTimePickerHasta.Value = DateTime.Now;
            ActualizarGrilla();
            comboBoxLogin.Items.Clear();
            foreach (DataGridViewRow fila in dataGridView1.Rows)
            {
                string nombre = fila.Cells["Usuario"].Value?.ToString();
                if (!string.IsNullOrEmpty(nombre) && !comboBoxLogin.Items.Contains(nombre))
                {
                    comboBoxLogin.Items.Add(nombre);
                }
            }
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows[0].Selected = true;
            }
        
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormMain main = new FormMain(); main.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime desde = dateTimePickerDesde.Value.Date;
                DateTime hasta = dateTimePickerHasta.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59);

                string usuario = comboBoxLogin.Text.Trim();
                string modulo = comboBoxModulo.Text.Trim();
                string evento = comboBoxTipo.Text.Trim();
                string criticidad = comboBoxCriticidad.Text.Trim();


                dataGridView1.DataSource = null;
                dataGridView1.DataSource = gestorBitacora.ConsultarFiltrado(desde, hasta, usuario, modulo, evento, criticidad);


                if (dataGridView1.Columns.Count > 0)
                {
                    dataGridView1.Columns["ID_Bitacora"].Visible = false;
                    dataGridView1.Columns["Usuario"].HeaderText = "Login";
                    dataGridView1.Columns["FechaHora"].HeaderText = "Fecha y Hora";
                    dataGridView1.Columns["FechaHora"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en Filtro: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            dateTimePickerDesde.Value = DateTime.Now.AddDays(-3);
            dateTimePickerHasta.Value = DateTime.Now;

            comboBoxLogin.SelectedIndex = -1; comboBoxLogin.Text = "";
            comboBoxModulo.SelectedIndex = -1; comboBoxModulo.Text = "";
            comboBoxTipo.SelectedIndex = -1; comboBoxTipo.Text = "";
            comboBoxCriticidad.SelectedIndex = -1; comboBoxCriticidad.Text = "";

            button1_Click(null, null);
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
 

                CargarDatosUsuarioSeleccionado();
           
        }
        private void CargarDatosUsuarioSeleccionado()
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    string loginSeleccionado = dataGridView1.CurrentRow.Cells["Usuario"].Value.ToString().Trim();
                    UsuarioBLL gestorUsuario = new UsuarioBLL();
                    var usu = gestorUsuario.ObtenerPorNombre(loginSeleccionado);
                    if (usu != null)
                    {
                        textBox2.Text = usu.Nombre;
                        textBox3.Text = usu.Apellido;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }
        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
