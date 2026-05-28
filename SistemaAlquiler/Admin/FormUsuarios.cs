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

namespace SistemaAlquiler.Seguridad
{
    public partial class FormUsuarios : Form
    {
        private UsuarioBLL gestorUsuario = new UsuarioBLL();

        enum TiposOperacion { Consulta = 0, Alta = 1, Modificacion = 2, Desbloqueo = 3, ActivarDesactivar = 4 }
        private TiposOperacion TipoOperacion { get; set; }

        public FormUsuarios()
        {
            InitializeComponent();
        }

        private void FormUsuarios_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;


            cbRol.Items.Clear();
            cbRol.Items.AddRange(new string[] { "Gerente", "Recepcionista" });
            cbRol.DropDownStyle = ComboBoxStyle.DropDownList;

            rdbActivos.Checked = true;

            ActualizarGrilla();
            ModoConsulta();
        }


        private void ModoConsulta()
        {
            TipoOperacion = TiposOperacion.Consulta;

            txtDNI.Enabled = false;
            txtApellido.Enabled = false;
            txtNombre.Enabled = false;
            txtEmail.Enabled = false;
            txtLogin.Enabled = false;
            cbRol.Enabled = false;

            btnCancelar.Enabled = false;
            btnAceptar.Enabled = false;

            btnCrear.Enabled = true;
            btnModificar.Enabled = true;
            btnDesbloquear.Enabled = true;
            btnActDesact.Enabled = true;

            dataGridView1.Enabled = true;
            rdbActivos.Enabled = true;
            rdbTodos.Enabled = true;

            Limpiar();
        }

        private void PrepararOperacion(TiposOperacion tipoOp, string mensaje, bool habilitarCajas)
        {
            TipoOperacion = tipoOp;

            txtDNI.Enabled = habilitarCajas;
            txtApellido.Enabled = habilitarCajas;
            txtNombre.Enabled = habilitarCajas;
            txtEmail.Enabled = habilitarCajas;
            txtLogin.Enabled = habilitarCajas;
            cbRol.Enabled = habilitarCajas;

            btnAceptar.Enabled = true;
            btnCancelar.Enabled = true;

            btnCrear.Enabled = false;
            btnModificar.Enabled = false;
            btnDesbloquear.Enabled = false;
            btnActDesact.Enabled = false;

            rdbActivos.Enabled = false;
            rdbTodos.Enabled = false;
            dataGridView1.Enabled = false; 
        }

        private void Limpiar()
        {
            txtDNI.Clear();
            txtApellido.Clear();
            txtNombre.Clear();
            txtEmail.Clear();
            txtLogin.Clear();
            cbRol.SelectedIndex = -1;
        }


        private void btnCrear_Click(object sender, EventArgs e)
        {
            Limpiar();
            PrepararOperacion(TiposOperacion.Alta, "Modo Añadir", true);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                PrepararOperacion(TiposOperacion.Modificacion, "Modo Modificar", true);

                CargarDatosEnCajas();
            }
            else
            {
                MessageBox.Show("Seleccione un registro desde la grilla superior.");
            }
        }

        private void btnDesbloquear_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                PrepararOperacion(TiposOperacion.Desbloqueo, "Modo Desbloquear", false);
                CargarDatosEnCajas();
            }
            else
            {
                MessageBox.Show("Seleccione un registro desde la grilla superior.");
            }
        }

        private void btnActDesact_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                PrepararOperacion(TiposOperacion.ActivarDesactivar, "Modo Activar/Desactivar", false);
                CargarDatosEnCajas();
            }
            else
            {
                MessageBox.Show("Seleccione un registro desde la grilla superior.");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ModoConsulta();
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usuarioOperacion = new Usuario();

                switch (TipoOperacion)
                {
                    case TiposOperacion.Alta:
                        usuarioOperacion.DNI = txtDNI.Text;
                        usuarioOperacion.Nombre = txtNombre.Text;
                        usuarioOperacion.Apellido = txtApellido.Text;
                        usuarioOperacion.Email = txtEmail.Text;
                        usuarioOperacion.Rol = cbRol.Text;

                        usuarioOperacion.NombreUsuario = string.IsNullOrWhiteSpace(txtLogin.Text) ? txtEmail.Text : txtLogin.Text;
                        usuarioOperacion.Clave = Criptografia.EncriptarHash(txtDNI.Text);

                        usuarioOperacion.Activo = true;
                        usuarioOperacion.Bloqueado = false;

                        gestorUsuario.Alta(usuarioOperacion);
                        MessageBox.Show("Operación Añadir Exitosa.");
                        break;

                    case TiposOperacion.Modificacion:
                        usuarioOperacion = ArmarUsuarioDesdeGrilla();
                        usuarioOperacion.DNI = txtDNI.Text;
                        usuarioOperacion.Nombre = txtNombre.Text;
                        usuarioOperacion.Apellido = txtApellido.Text;
                        usuarioOperacion.Email = txtEmail.Text;
                        usuarioOperacion.NombreUsuario = txtLogin.Text;
                        usuarioOperacion.Rol = cbRol.Text;

                        gestorUsuario.Modificar(usuarioOperacion);
                        MessageBox.Show("Operación Modificar Exitosa.");
                        break;

                    case TiposOperacion.Desbloqueo:
                        usuarioOperacion = ArmarUsuarioDesdeGrilla();
                        usuarioOperacion.Bloqueado = false;
                        usuarioOperacion.IntentosFallidos = 0;

                        gestorUsuario.Modificar(usuarioOperacion);
                        MessageBox.Show("Usuario Desbloqueado con éxito.");
                        break;

                    case TiposOperacion.ActivarDesactivar:
                        usuarioOperacion = ArmarUsuarioDesdeGrilla();
                        usuarioOperacion.Activo = !usuarioOperacion.Activo;

                        gestorUsuario.Modificar(usuarioOperacion);
                        MessageBox.Show(usuarioOperacion.Activo ? "Usuario Activado." : "Usuario Desactivado.");
                        break;
                }

                ActualizarGrilla();
                ModoConsulta();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Aplicar: " + ex.Message);
            }
        }

        private void ActualizarGrilla()
        {
            try
            {
                List<Usuario> listaCompleta = gestorUsuario.Listar();

                dataGridView1.DataSource = rdbActivos.Checked
                    ? listaCompleta.Where(u => u.Activo == true).ToList()
                    : listaCompleta;

                if (dataGridView1.Columns.Count > 0)
                {
                    dataGridView1.Columns["ID_Usuario"].Visible = false;
                    dataGridView1.Columns["Clave"].Visible = false;
                    dataGridView1.Columns["IntentosFallidos"].Visible = false;
                    dataGridView1.Columns["Bloqueado"].Visible = false;
                    dataGridView1.Columns["Activo"].Visible = false;
                    dataGridView1.Columns["Email"].Visible = false;

                    dataGridView1.Columns["Apellido"].HeaderText = "Apellidos";
                    dataGridView1.Columns["Nombre"].HeaderText = "Nombres";
                    dataGridView1.Columns["NombreUsuario"].HeaderText = "Login";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de BD: " + ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (TipoOperacion == TiposOperacion.Consulta)
            {
                CargarDatosEnCajas();
            }
        }

        private void CargarDatosEnCajas()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                txtNombre.Text = dataGridView1.SelectedRows[0].Cells["Nombre"].Value?.ToString();
                txtApellido.Text = dataGridView1.SelectedRows[0].Cells["Apellido"].Value?.ToString();
                txtDNI.Text = dataGridView1.SelectedRows[0].Cells["DNI"].Value?.ToString();
                txtEmail.Text = dataGridView1.SelectedRows[0].Cells["Email"].Value?.ToString();
                cbRol.Text = dataGridView1.SelectedRows[0].Cells["Rol"].Value?.ToString();
                txtLogin.Text = dataGridView1.SelectedRows[0].Cells["NombreUsuario"].Value?.ToString();
            }
        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells["Activo"].Value != null)
            {
                bool activo = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells["Activo"].Value);
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = activo ? Color.White : Color.LightCoral;
            }
        }

        private void rdbActivos_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbActivos.Checked) { ActualizarGrilla(); ModoConsulta(); }
        }

        private void rdbTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbTodos.Checked) { ActualizarGrilla(); ModoConsulta(); }
        }

        private Usuario ArmarUsuarioDesdeGrilla()
        {
            Usuario usuario = new Usuario();
            usuario.ID_Usuario = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID_Usuario"].Value);
            usuario.DNI = dataGridView1.SelectedRows[0].Cells["DNI"].Value?.ToString();
            usuario.Nombre = dataGridView1.SelectedRows[0].Cells["Nombre"].Value?.ToString();
            usuario.Apellido = dataGridView1.SelectedRows[0].Cells["Apellido"].Value?.ToString();
            usuario.NombreUsuario = dataGridView1.SelectedRows[0].Cells["NombreUsuario"].Value?.ToString();
            usuario.Email = dataGridView1.SelectedRows[0].Cells["Email"].Value?.ToString();
            usuario.Rol = dataGridView1.SelectedRows[0].Cells["Rol"].Value?.ToString();
            usuario.Activo = Convert.ToBoolean(dataGridView1.SelectedRows[0].Cells["Activo"].Value);
            usuario.Bloqueado = Convert.ToBoolean(dataGridView1.SelectedRows[0].Cells["Bloqueado"].Value);
            return usuario;
        }

        private void rdbActivos_CheckedChanged_1(object sender, EventArgs e)
        {
            if (rdbActivos.Checked)
            {
                ActualizarGrilla();
                ModoConsulta();
            }
        }

        private void rdbTodos_CheckedChanged_1(object sender, EventArgs e)
        {
            if (rdbTodos.Checked)
            {
                ActualizarGrilla();
                ModoConsulta();
            }
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            ModoConsulta();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Logout salir = new Logout();
            salir.Show();
            this.Hide();
        }

        private void btnCambiarClave_Click(object sender, EventArgs e)
        {
            FormCambiarClave CambiarClave = new FormCambiarClave();
            CambiarClave.Show();
        }
    }
}