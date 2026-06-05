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
            dateTimePickerDesde.Value = DateTime.Now.AddDays(-3);
            dateTimePickerHasta.Value = DateTime.Now;

            button1_Click(null, null);

            comboBoxLogin.Items.Clear();
            UsuarioBLL gestorUsuario = new UsuarioBLL();
            foreach (var usu in gestorUsuario.Listar())
            {
                comboBoxLogin.Items.Add(usu.NombreUsuario);
            }
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
                            MessageBox.Show("No se puede reemplazar el archivo. Puede que este abierto. " + ex.Message);
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

                                pdfDoc.Add(new Paragraph("Reporte de Auditoria\n\n"));
                                pdfDoc.Add(pdfTable);

                                pdfDoc.Close();
                                stream.Close();
                            }

                            MessageBox.Show("Reporte exportado exitosamente!", "Exportacion PDF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ocurrio un error al crear el PDF: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("La grilla está vacia, no hay nada para exportar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FormBitacora_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void comboBoxModulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxTipo.Items.Clear();
            comboBoxTipo.Text = "";

            switch (comboBoxModulo.Text)
            {
                case "Admin":
                    comboBoxTipo.Items.AddRange(new string[] { "Usuarios", "Perfiles", "Backup", "Restore", "BitacoraEventos", "Digito verificador" });
                    break;
                case "Maestros":
                    comboBoxTipo.Items.AddRange(new string[] { "Vehiculo", "Cliente", "Taller" });
                    break;
                case "Usuario":
                    comboBoxTipo.Items.AddRange(new string[] { "Login", "ReLogin", "Cambiar clave", "Logout", "Cambiar idioma" });
                    break;
                case "Operaciones":
                    comboBoxTipo.Items.AddRange(new string[] { "Registrar alquiler", "Registrar devolución", "Cancelar reserva", "Consultar disponibilidad" });
                    break;
                case "Mantenimiento":
                    comboBoxTipo.Items.AddRange(new string[] { "Enviar a taller", "Registrar servicio mecánico" });
                    break;
                case "Reporte":
                    comboBoxTipo.Items.AddRange(new string[] { "Rentabilidad por vehiculo", "Historial de gastos por unidad", "Estadísticas de alquileres" });
                    break;
                case "Ayuda":
                    comboBoxTipo.Items.AddRange(new string[] { "Manual de usuario" });
                    break;
            }
        }

        private void comboBoxTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void FormBitacora_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}