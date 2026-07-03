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
        private DvBLL _dvBLL = new DvBLL();
        public FormDv(string detalleFalla)
        {
            InitializeComponent();
            _detalleFalla = detalleFalla;
        }

        private void FormDv_Load(object sender, EventArgs e)
        {

            if (dataGridView1 != null)
            {
                dataGridView1.ReadOnly = true;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.MultiSelect = false;
            }

            Services.Observer.IdiomaManager.Instancia.Suscribir(this);
            ActualizarIdioma();

            var idioma = Services.Observer.IdiomaManager.Instancia;

            MessageBox.Show(idioma.Traducir("msg_AlertaCriticaDV"), idioma.Traducir("tit_FallaDV"), MessageBoxButtons.OK, MessageBoxIcon.Error);


            lstDetalles.Items.Clear();
            lstDetalles.Items.Add(idioma.Traducir("lst_ReporteInconsistencia") ?? "--- REPORTE FORENSE DE INCONSISTENCIAS ---");
            lstDetalles.Items.Add("");

            try
            {
                List<DetalleFalla> fallas = _dvBLL.EscanearFallas();
                if (fallas.Count > 0)
                {
                    foreach (var falla in fallas)
                    {
                        lstDetalles.Items.Add($"▶ TABLA AFECTADA: {falla.Tabla}  |  ID DEL REGISTRO: {falla.FilaID}");
                        lstDetalles.Items.Add($"   » Columnas a revisar: [{falla.Columnas}]");
                        lstDetalles.Items.Add($"   » Tipo de Falla: {falla.Error}");
                        lstDetalles.Items.Add("");
                    }
                }
                else
                {
                    lstDetalles.Items.Add(_detalleFalla);
                }
            }
            catch
            {
                lstDetalles.Items.Add(_detalleFalla);
            }

            lstDetalles.Items.Add(idioma.Traducir("lst_SeleccioneAccion") ?? "Seleccione una acción para continuar:");

            CargarHistorialBitacora();
        }
        private void CargarHistorialBitacora()
        {
            try
            {
                if (dataGridView1 != null)
                {
                    dataGridView1.DataSource = null;
                    dataGridView1.Columns.Clear();
                    dataGridView1.AutoGenerateColumns = true;
                    dataGridView1.DataSource = _dvBLL.ObtenerHistorialLog();
                    FormatGrillaHistorial();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la bitácora de DV: " + ex.Message);
            }
        }
        private void FormatGrillaHistorial()
        {
            var idioma = Services.Observer.IdiomaManager.Instancia;
            if (dataGridView1 != null && dataGridView1.Columns.Count > 0)
            {
                if (dataGridView1.Columns["FechaHora"] != null)
                {
                    dataGridView1.Columns["FechaHora"].HeaderText = idioma.Traducir("col_Fecha") ?? "Fecha";
                    dataGridView1.Columns["FechaHora"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
                }

                if (dataGridView1.Columns["Usuario"] != null)
                    dataGridView1.Columns["Usuario"].HeaderText = idioma.Traducir("col_Usuario") ?? "Usuario";

                if (dataGridView1.Columns["Modulo"] != null)
                    dataGridView1.Columns["Modulo"].HeaderText = idioma.Traducir("col_Modulo") ?? "Módulo";

                if (dataGridView1.Columns["Evento"] != null)
                {
                    dataGridView1.Columns["Evento"].HeaderText = idioma.Traducir("col_Evento") ?? "Evento";
                    dataGridView1.Columns["Evento"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                if (dataGridView1.Columns["Criticidad"] != null)
                    dataGridView1.Columns["Criticidad"].HeaderText = idioma.Traducir("col_Criticidad") ?? "Criticidad";
            }
        }
        private void ActualizarTitulosGrilla()
        {
            var idioma = Services.Observer.IdiomaManager.Instancia;
            if (dataGridView1 != null && dataGridView1.Columns.Count > 0)
            {
                if (dataGridView1.Columns["Tabla"] != null)
                    dataGridView1.Columns["Tabla"].HeaderText = idioma.Traducir("col_Tabla");

                if (dataGridView1.Columns["FilaID"] != null)
                    dataGridView1.Columns["FilaID"].HeaderText = idioma.Traducir("col_FilaID");

                if (dataGridView1.Columns["Error"] != null)
                {
                    dataGridView1.Columns["Error"].HeaderText = idioma.Traducir("col_ErrorDV");
                    dataGridView1.Columns["Error"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
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
                ofd.Title = idioma.Traducir("ofd_TituloRestore");

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

            this.Text = idioma.Traducir("tituloPerfilesABMC"); 

            btnRecalcular.Text = idioma.Traducir("btnRecalcular") ?? "Recalcular Dígitos";
            btnRestore.Text = idioma.Traducir("btnRestore") ?? "Restaurar Copia";
            btnSalir.Text = idioma.Traducir("btnSalir");


            CargarHistorialBitacora();
        }

        private void FormDv_FormClosed(object sender, FormClosedEventArgs e)
        {
            Services.Observer.IdiomaManager.Instancia.Desuscribir(this);
        }
    }
}
