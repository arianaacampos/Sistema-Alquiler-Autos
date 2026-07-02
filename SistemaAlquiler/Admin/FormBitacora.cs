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
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace SistemaAlquiler.Seguridad
{
    public partial class FormBitacora : Form, Services.Observer.IObserverIdioma
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
                ActualizarGrillaTítulos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Services.Observer.IdiomaManager.Instancia.Traducir("msg_ErrorTraerDatos") + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormBitacora_Load(object sender, EventArgs e)
        {
            dateTimePickerDesde.Value = DateTime.Now.AddDays(-3);
            dateTimePickerHasta.Value = DateTime.Now;

            button1_Click(null, null);


            comboBoxLogin.Items.Clear();
            UsuarioBLL gestorUsuario = new UsuarioBLL();
            foreach (var usu in gestorUsuario.Listar())
            {
                comboBoxLogin.Items.Add(usu.NombreUsuario);
            }
            Services.Observer.IdiomaManager.Instancia.Suscribir(this);
            ActualizarIdioma();
        }

        private void button4_Click(object sender, EventArgs e)
        {
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
                ActualizarGrillaTítulos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Services.Observer.IdiomaManager.Instancia.Traducir("msg_ErrorFiltro") + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            catch (Exception ex) { MessageBox.Show(Services.Observer.IdiomaManager.Instancia.Traducir("msg_ErrorGeneral") + ex.Message); }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = "Reporte_Bitacora_" + DateTime.Now.ToString("ddMMyyyy") + ".pdf";

                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show(Services.Observer.IdiomaManager.Instancia.Traducir("msg_ErrorReemplazarArchivo") + ex.Message);
                        }
                    }

                    if (!fileError)
                    {
                        try
                        {
                            PdfPTable pdfTable = new PdfPTable(dataGridView1.Columns.Count);
                            pdfTable.DefaultCell.Padding = 3;
                            pdfTable.WidthPercentage = 100;
                            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
                            foreach (DataGridViewColumn column in dataGridView1.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                                cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                                pdfTable.AddCell(cell);
                            }

                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                if (!row.IsNewRow)
                                {
                                    foreach (DataGridViewCell cell in row.Cells)
                                    {
                                        pdfTable.AddCell(cell.Value != null ? cell.Value.ToString() : "");
                                    }
                                }
                            }

                            using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                            {
                                Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 20f, 10f);
                                PdfWriter.GetInstance(pdfDoc, stream);
                                pdfDoc.Open();

                                pdfDoc.Add(new Paragraph(Services.Observer.IdiomaManager.Instancia.Traducir("pdf_TituloReporte") + "\n\n"));
                                pdfDoc.Add(pdfTable);

                                pdfDoc.Close();
                                stream.Close();
                            }

                            MessageBox.Show(Services.Observer.IdiomaManager.Instancia.Traducir("msg_ExitoPDF"), Services.Observer.IdiomaManager.Instancia.Traducir("tit_ExportacionPDF"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(Services.Observer.IdiomaManager.Instancia.Traducir("msg_ErrorCrearPDF") + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show(Services.Observer.IdiomaManager.Instancia.Traducir("msg_GrillaVacia"), Services.Observer.IdiomaManager.Instancia.Traducir("tit_Atencion"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FormBitacora_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void comboBoxModulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxTipo.Items.Clear();
            comboBoxTipo.Text = "";

            var idioma = Services.Observer.IdiomaManager.Instancia;
            switch (comboBoxModulo.SelectedIndex)
            {
                case 0: // Admin
                    comboBoxTipo.Items.AddRange(new string[] { idioma.Traducir("cbx_Admin_Usuarios"), idioma.Traducir("cbx_Admin_Perfiles"), idioma.Traducir("cbx_Admin_Backup"), idioma.Traducir("cbx_Admin_Restore"), idioma.Traducir("cbx_Admin_Bitacora"), idioma.Traducir("cbx_Admin_DV") });
                    break;
                case 1: // Maestros
                    comboBoxTipo.Items.AddRange(new string[] { idioma.Traducir("cbx_Mae_Vehiculo"), idioma.Traducir("cbx_Mae_Cliente"), idioma.Traducir("cbx_Mae_Taller") });
                    break;
                case 2: // Usuario
                    comboBoxTipo.Items.AddRange(new string[] { idioma.Traducir("cbx_Usu_Login"), idioma.Traducir("cbx_Usu_ReLogin"), idioma.Traducir("cbx_Usu_Clave"), idioma.Traducir("cbx_Usu_Logout"), idioma.Traducir("cbx_Usu_Idioma") });
                    break;
                case 3: // Operaciones
                    comboBoxTipo.Items.AddRange(new string[] { idioma.Traducir("cbx_Ope_Alquiler"), idioma.Traducir("cbx_Ope_Devolucion"), idioma.Traducir("cbx_Ope_Cancelar"), idioma.Traducir("cbx_Ope_Disp") });
                    break;
                case 4: // Mantenimiento
                    comboBoxTipo.Items.AddRange(new string[] { idioma.Traducir("cbx_Man_Enviar"), idioma.Traducir("cbx_Man_Servicio") });
                    break;
                case 5: // Reporte
                    comboBoxTipo.Items.AddRange(new string[] { idioma.Traducir("cbx_Rep_Rentabilidad"), idioma.Traducir("cbx_Rep_Historial"), idioma.Traducir("cbx_Rep_Estadisticas") });
                    break;
                case 6: // Ayuda
                    comboBoxTipo.Items.AddRange(new string[] { idioma.Traducir("cbx_Ayu_Manual") });
                    break;
            }
        }

        private void comboBoxTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void FormBitacora_FormClosing(object sender, FormClosingEventArgs e)
        {
            Services.Observer.IdiomaManager.Instancia.Desuscribir(this);
        }

        public void ActualizarIdioma()
        {
            var idioma = Services.Observer.IdiomaManager.Instancia;

            this.Text = idioma.Traducir("tituloBitacora");

            button1.Text = idioma.Traducir("btnConsultarBitacora");
            button2.Text = idioma.Traducir("btnLimpiarBitacora");
            button3.Text = idioma.Traducir("btnImprimirPDF");
            button4.Text = idioma.Traducir("btnSalir");

            groupBox1.Text = idioma.Traducir("gbFiltros");
            label1.Text = idioma.Traducir("lblDesde");
            label2.Text = idioma.Traducir("lblHasta");
            label3.Text = idioma.Traducir("lblFiltroLogin");
            label8.Text = idioma.Traducir("lblFiltroModulo");
            label4.Text = idioma.Traducir("lblFiltroTipo");
            label7.Text = idioma.Traducir("lblFiltroCriticidad");
            label5.Text = idioma.Traducir("lblApellidosBottom");
            label6.Text = idioma.Traducir("lblNombresBottom");

            int idxMod = comboBoxModulo.SelectedIndex;
            int idxCrit = comboBoxCriticidad.SelectedIndex;

            comboBoxModulo.Items.Clear();
            comboBoxModulo.Items.AddRange(new string[] { idioma.Traducir("cbx_Mod_Admin"), idioma.Traducir("cbx_Mod_Maestros"), idioma.Traducir("cbx_Mod_Usuario"), idioma.Traducir("cbx_Mod_Operaciones"), idioma.Traducir("cbx_Mod_Mantenimiento"), idioma.Traducir("cbx_Mod_Reporte"), idioma.Traducir("cbx_Mod_Ayuda") });

            comboBoxCriticidad.Items.Clear();
            comboBoxCriticidad.Items.AddRange(new string[] { idioma.Traducir("cbx_Crit_Alta"), idioma.Traducir("cbx_Crit_Media"), idioma.Traducir("cbx_Crit_Baja") });

            comboBoxModulo.SelectedIndex = idxMod;
            comboBoxCriticidad.SelectedIndex = idxCrit;

            ActualizarGrillaTítulos();
        }
        private void ActualizarGrillaTítulos()
        {
            if (dataGridView1.Columns.Count > 0)
            {
                if (dataGridView1.Columns["Usuario"] != null)
                    dataGridView1.Columns["Usuario"].HeaderText = Services.Observer.IdiomaManager.Instancia.Traducir("colLogin");

                if (dataGridView1.Columns["FechaHora"] != null)
                    dataGridView1.Columns["FechaHora"].HeaderText = Services.Observer.IdiomaManager.Instancia.Traducir("colFechaHora");

                if (dataGridView1.Columns["Modulo"] != null)
                    dataGridView1.Columns["Modulo"].HeaderText = Services.Observer.IdiomaManager.Instancia.Traducir("colModulo");

                if (dataGridView1.Columns["Evento"] != null)
                    dataGridView1.Columns["Evento"].HeaderText = Services.Observer.IdiomaManager.Instancia.Traducir("colEvento");

                if (dataGridView1.Columns["Criticidad"] != null)
                    dataGridView1.Columns["Criticidad"].HeaderText = Services.Observer.IdiomaManager.Instancia.Traducir("colCriticidad");
            }
        }
    }
}