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

namespace SistemaAlquiler.Admin
{
    public partial class FormDv : Form, Services.Observer.IObserverIdioma
    {
        private string _detalleFalla;
        public FormDv(string detalleFalla)
        {
            InitializeComponent();
            _detalleFalla = detalleFalla;
        }

        private void FormDv_Load(object sender, EventArgs e)
        {
            Services.Observer.IdiomaManager.Instancia.Suscribir(this);
            ActualizarIdioma();

            var idioma = Services.Observer.IdiomaManager.Instancia;

            MessageBox.Show(idioma.Traducir("msg_AlertaCriticaDV"), idioma.Traducir("tit_FallaDV"), MessageBoxButtons.OK, MessageBoxIcon.Error);

            lstDetalles.Items.Add(idioma.Traducir("lst_ReporteInconsistencia"));
            lstDetalles.Items.Add(_detalleFalla); 
            lstDetalles.Items.Add(idioma.Traducir("lst_SeleccioneAccion"));

        }
        private void btnRecalcular_Click(object sender, EventArgs e)
        {
            var idioma = Services.Observer.IdiomaManager.Instancia;

            DialogResult r = MessageBox.Show(idioma.Traducir("msg_AvisoRecalculo"), idioma.Traducir("tit_Aviso"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (r == DialogResult.Yes)
            {
                new DvBLL().RecalcularTodo();

                string usu = Sesion.Instancia.UsuarioActual ?? "Admin_DV";
                new BitacoraBLL().Registrar(usu, "Base de Datos", "Recálculo forzado de DV por inconsistencia en BD.", "Alta");

                MessageBox.Show(idioma.Traducir("msg_ExitoRecalculo"));

                Services.Observer.IdiomaManager.Instancia.Desuscribir(this);
                Application.Restart();
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            var idioma = Services.Observer.IdiomaManager.Instancia;

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Archivos de Backup (*.bak)|*.bak";
                ofd.Title = idioma.Traducir("ofd_TituloRestore"); // ¡Traducción de la ventanita de Windows!

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        this.Cursor = Cursors.WaitCursor;

                        new RespaldoBLL().RealizarRestore(ofd.FileName);

                        string usu = Sesion.Instancia.UsuarioActual ?? "Admin_DV";
                        new BitacoraBLL().Registrar(usu, "Base de Datos", "Restore ejecutado por falla de integridad.", "Alta");

                        this.Cursor = Cursors.Default;
                        MessageBox.Show(idioma.Traducir("msg_ExitoRestoreDV"));

                        Services.Observer.IdiomaManager.Instancia.Desuscribir(this);
                        Application.Restart();
                    }
                    catch (Exception ex)
                    {
                        this.Cursor = Cursors.Default;
                        MessageBox.Show(idioma.Traducir("msg_ErrorCriticoRestore") + ex.Message);
                    }
                }
            }
        }
        

        private void btnSalir_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            var idioma = Services.Observer.IdiomaManager.Instancia;

            MessageBox.Show(idioma.Traducir("msg_CierreSeguridad"), idioma.Traducir("tit_CierreEmergencia"), MessageBoxButtons.OK, MessageBoxIcon.Stop);

            Services.Observer.IdiomaManager.Instancia.Desuscribir(this);
            Application.Exit();
        }

        public void ActualizarIdioma()
        {
            var idioma = Services.Observer.IdiomaManager.Instancia;

            this.Text = idioma.Traducir("tit_FormDV");
            btnRecalcular.Text = idioma.Traducir("btnRecalcular");
            btnRestore.Text = idioma.Traducir("btnRestore");
            btnSalir.Text = idioma.Traducir("btnSalir");
        }

        private void FormDv_FormClosed(object sender, FormClosedEventArgs e)
        {
            Services.Observer.IdiomaManager.Instancia.Desuscribir(this);
        }
    }
}
