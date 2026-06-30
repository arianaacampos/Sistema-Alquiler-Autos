using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaAlquiler
{
    public partial class FormConfigurarServidor : Form
    {
        public FormConfigurarServidor()
        {
            InitializeComponent();
        }

        private void FormConfigurarServidor_Load(object sender, EventArgs e)
        {

        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                cbInstancias.Items.Clear();
                cbInstancias.Items.Add(".");
                cbInstancias.Items.Add(".\\SQLEXPRESS");

                // Busca instancias de SQL en la red
                DataTable servidores = SqlDataSourceEnumerator.Instance.GetDataSources();
                foreach (DataRow row in servidores.Rows)
                {
                    string servidor = row["ServerName"].ToString();
                    string instancia = row["InstanceName"].ToString();

                    string nombreCompleto = string.IsNullOrEmpty(instancia) ? servidor : $"{servidor}\\{instancia}";
                    cbInstancias.Items.Add(nombreCompleto);
                }

                if (cbInstancias.Items.Count > 0) cbInstancias.SelectedIndex = 0;

                this.Cursor = Cursors.Default;
                MessageBox.Show("Búsqueda finalizada. Seleccione su instancia.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("Error al buscar instancias: " + ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbInstancias.Text)) return;

            string instanciaElegida = cbInstancias.Text;
            ConfiguradorBLL gestorConfig = new ConfiguradorBLL();

            this.Cursor = Cursors.WaitCursor;

            // Le preguntamos a la BLL si la conexión funciona
            if (gestorConfig.ProbarNuevaConexion(instanciaElegida))
            {
                gestorConfig.GuardarInstancia(instanciaElegida); // Guardamos
                this.Cursor = Cursors.Default;

                MessageBox.Show("Conexión establecida con éxito. El sistema se iniciará.", "Conectado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("No se pudo conectar a la base de datos en esa instancia. Verifique que el servicio SQL esté corriendo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
