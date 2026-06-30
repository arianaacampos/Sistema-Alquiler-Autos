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

namespace SistemaAlquiler.Admin
{
    public partial class FormRespaldos : Form
    {
        public FormRespaldos()
        {
            InitializeComponent();
        }

        private void btnExaminarBackup_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Seleccione la carpeta para guardar el Backup";
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtRutaBackup.Text = fbd.SelectedPath;
                }
            }
        }

        private void btnGenerarBackup_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRutaBackup.Text))
            {
                MessageBox.Show("Por favor, seleccione un directorio de destino usando el botón Examinar.");
                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;

                new RespaldoBLL().RealizarBackup(txtRutaBackup.Text);

                this.Cursor = Cursors.Default;
                MessageBox.Show("¡Backup generado y guardado correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtRutaBackup.Text = "";
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("Error al generar el Backup: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExaminarRestore_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Archivos de Backup SQL (*.bak)|*.bak";
                ofd.Title = "Seleccione el archivo de Backup a restaurar";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtRutaRestore.Text = ofd.FileName;
                }
            }
        }

        private void btnEjecutarRestore_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRutaRestore.Text))
            {
                MessageBox.Show("Por favor, seleccione el archivo .bak a restaurar.");
                return;
            }

            DialogResult confirmacion = MessageBox.Show("¿Está seguro que desea sobrescribir la base de datos actual? Se perderán todos los datos que no estén en este respaldo. El sistema se cerrará tras finalizar.", "Advertencia Crítica", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;

                    new RespaldoBLL().RealizarRestore(txtRutaRestore.Text);

                    this.Cursor = Cursors.Default;
                    MessageBox.Show("¡Restore ejecutado correctamente! El sistema se reiniciará por seguridad.", "Restauración Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Application.Restart();
                }
                catch (Exception ex)
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("Error al restaurar la base de datos: " + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

