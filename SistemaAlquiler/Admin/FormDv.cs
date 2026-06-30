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
    public partial class FormDv : Form
    {
        private string _detalleFalla;
        public FormDv(string detalleFalla)
        {
            InitializeComponent();
            _detalleFalla = detalleFalla;
        }

        private void FormDv_Load(object sender, EventArgs e)
        {
            MessageBox.Show("¡ALERTA CRÍTICA DE SEGURIDAD! La integridad de la Base de Datos está comprometida.", "Falla de DV", MessageBoxButtons.OK, MessageBoxIcon.Error);

            // Llenamos el ListBox con los detalles del error
            lstDetalles.Items.Add("--- REPORTE DE INCONSISTENCIA ---");
            lstDetalles.Items.Add(_detalleFalla);
            lstDetalles.Items.Add("Por favor, seleccione una acción correctiva.");

        }
        private void btnRecalcular_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("¿Está seguro de forzar el recálculo? El sistema asumirá que los datos actuales son los válidos.", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (r == DialogResult.Yes)
            {
                // Llama al motor dinámico que armamos para recalcular todas las tablas
                new DvBLL().RecalcularTodo();

                // OJO - Reportar en Bitácora con un usuario de emergencia porque el login no terminó
                string usu = Sesion.Instancia.UsuarioActual ?? "Admin_DV";
                new BitacoraBLL().Registrar(usu, "Base de Datos", "Recálculo forzado de DV por inconsistencia en BD.", "Alta");

                MessageBox.Show("Dígitos Verificadores recalculados con éxito. El sistema se reiniciará para que intente ingresar nuevamente.");
                Application.Restart(); // Reinicia la app para volver al Login
            }
        }

        // ===============================================
        // BOTÓN 2: RESTORE BD
        // ===============================================
        private void btnRestore_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Archivos de Backup (*.bak)|*.bak";
                ofd.Title = "Seleccione el Backup para reparar el sistema";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        this.Cursor = Cursors.WaitCursor;

                        // Llama a tu clase de respaldos para pisar la base de datos corrupta
                        new RespaldoBLL().RealizarRestore(ofd.FileName);

                        string usu = Sesion.Instancia.UsuarioActual ?? "Admin_DV";
                        new BitacoraBLL().Registrar(usu, "Base de Datos", "Restore ejecutado por falla de integridad.", "Alta");

                        this.Cursor = Cursors.Default;
                        MessageBox.Show("Restore exitoso. La base de datos ha sido recuperada. El sistema se reiniciará.");
                        Application.Restart(); // Reinicia la app
                    }
                    catch (Exception ex)
                    {
                        this.Cursor = Cursors.Default;
                        MessageBox.Show("Error crítico al intentar el Restore: " + ex.Message);
                    }
                }
            }
        }

        // ===============================================
        // BOTÓN 3: SALIR / CANCELAR
        // ===============================================
        private void btnSalir_Click(object sender, EventArgs e)
        {
            MessageBox.Show("El sistema se cerrará por seguridad. La base de datos sigue en estado inconsistente.", "Cierre de Emergencia", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            Application.Exit(); // Cierra el programa por completo
        }
    }
}
