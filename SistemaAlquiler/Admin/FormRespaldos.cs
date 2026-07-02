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
    public partial class FormRespaldos : Form, Services.Observer.IObserverIdioma
    {
        public FormRespaldos()
        {
            InitializeComponent();
        }

        private void btnExaminarBackup_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                fbd.Description = Services.Observer.IdiomaManager.Instancia.Traducir("fbd_DescBackup");
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtRutaBackup.Text = fbd.SelectedPath;
                }
            }
        }

        private void btnGenerarBackup_Click(object sender, EventArgs e)
        {
            var idioma = Services.Observer.IdiomaManager.Instancia;

            if (string.IsNullOrWhiteSpace(txtRutaBackup.Text))
            {
                MessageBox.Show(idioma.Traducir("msg_SeleccioneDirectorio"));
                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;

                new RespaldoBLL().RealizarBackup(txtRutaBackup.Text);

                this.Cursor = Cursors.Default;
                MessageBox.Show(idioma.Traducir("msg_ExitoBackup"), idioma.Traducir("tit_Exito"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtRutaBackup.Text = "";
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(idioma.Traducir("msg_ErrorGenerarBackup") + ex.Message, idioma.Traducir("tit_Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExaminarRestore_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Archivos de Backup SQL (*.bak)|*.bak";
                ofd.Title = Services.Observer.IdiomaManager.Instancia.Traducir("ofd_TituloRestoreBack");
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtRutaRestore.Text = ofd.FileName;
                }
            }
        }

        private void btnEjecutarRestore_Click(object sender, EventArgs e)
        {
            var idioma = Services.Observer.IdiomaManager.Instancia;

            if (string.IsNullOrWhiteSpace(txtRutaRestore.Text))
            {
                MessageBox.Show(idioma.Traducir("msg_SeleccioneBak"));
                return;
            }

            DialogResult confirmacion = MessageBox.Show(idioma.Traducir("msg_AdvertenciaRestore"), idioma.Traducir("tit_AdvertenciaCritica"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;

                    new RespaldoBLL().RealizarRestore(txtRutaRestore.Text);

                    this.Cursor = Cursors.Default;
                    MessageBox.Show(idioma.Traducir("msg_ExitoRestoreApp"), idioma.Traducir("tit_RestauracionExitosa"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Services.Observer.IdiomaManager.Instancia.Desuscribir(this);
                    Application.Restart();
                }
                catch (Exception ex)
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(idioma.Traducir("msg_ErrorRestore") + ex.Message, idioma.Traducir("tit_ErrorCritico"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FormRespaldos_Load(object sender, EventArgs e)
        {
            Services.Observer.IdiomaManager.Instancia.Suscribir(this);
            ActualizarIdioma();
        }

        public void ActualizarIdioma()
        {
            var idioma = Services.Observer.IdiomaManager.Instancia;

            this.Text = idioma.Traducir("tit_FormRespaldos");
            btnExaminarBackup.Text = idioma.Traducir("btnExaminarBackup");
            btnGenerarBackup.Text = idioma.Traducir("btnGenerarBackup");
            btnExaminarRestore.Text = idioma.Traducir("btnExaminarRestore");
            btnEjecutarRestore.Text = idioma.Traducir("btnEjecutarRestore");
        }

        private void FormRespaldos_FormClosed(object sender, FormClosedEventArgs e)
        {
            Services.Observer.IdiomaManager.Instancia.Desuscribir(this);
        }
    }
}

