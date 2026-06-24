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
    public partial class FormUsuarios : Form, Services.Observer.IObserverIdioma
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


            RolBLL gestorRol = new RolBLL(); 
            var listaPerfiles = gestorRol.ObtenerTodos();

            cbRol.DataSource = listaPerfiles;
            cbRol.DisplayMember = "Nombre";
            cbRol.ValueMember = "Id";
            cbRol.DropDownStyle = ComboBoxStyle.DropDownList;

            rdbActivos.Checked = true;

            Services.Observer.IdiomaManager.Instancia.Suscribir(this);
            ActualizarIdioma();

            ActualizarGrilla();
            ModoConsulta();
        }

        private void ModoConsulta()
        {
            TipoOperacion = TiposOperacion.Consulta;
            txtMensaje.Text = Services.Observer.IdiomaManager.Instancia.Traducir("modoConsulta");
            

            txtDNI.Enabled = true;
            txtApellido.Enabled = true;
            txtNombre.Enabled = true;
            txtEmail.Enabled = true;
            cbRol.Enabled = true;

            btnAceptar.Enabled = true;
            btnCancelar.Enabled = false;

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
            txtMensaje.Text = mensaje;

            txtDNI.Enabled = habilitarCajas;
            txtApellido.Enabled = habilitarCajas;
            txtNombre.Enabled = habilitarCajas;
            txtEmail.Enabled = habilitarCajas;
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
            txtDNI.Text = "";
            txtApellido.Text = "";
            txtNombre.Text = "";
            txtEmail.Text = "";
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
                PrepararOperacion(TiposOperacion.ActivarDesactivar, "Modo Eliminar", false);
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
                Usuario usuario = new Usuario();

                switch (TipoOperacion)
                {
                    case TiposOperacion.Consulta:
                        ActualizarGrilla();
                        return;

                    case TiposOperacion.Alta:

                        var listaUsuarios = gestorUsuario.Listar();

                        bool dniRepetido = listaUsuarios.Any(u => u.DNI == txtDNI.Text.Trim());

                        if (dniRepetido)
                        {
                            MessageBox.Show("Error: El DNI ya se encuentra registrado en el sistema.", "DNI Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return; 
                        }

                        usuario.DNI = txtDNI.Text.Trim();
                        usuario.Nombre = txtNombre.Text.Trim();
                        usuario.Apellido = txtApellido.Text.Trim();
                        usuario.Email = txtEmail.Text.Trim();
                        usuario.Rol = cbRol.Text;

                        string loginDinamico = (txtNombre.Text.Trim() + txtApellido.Text.Trim()).ToLower().Replace(" ", "");
                        usuario.NombreUsuario = loginDinamico;

                        usuario.Clave = Criptografia.EncriptarHash(txtDNI.Text.Trim());
                        usuario.Activo = true;
                        usuario.Bloqueado = false;

                        gestorUsuario.Alta(usuario);
                        MessageBox.Show($"Operación Añadir Exitosa. El usuario creado es: {loginDinamico}");
                        break;

                    case TiposOperacion.Modificacion:
                        usuario = ArmarUsuarioDesdeGrilla();
                        usuario.DNI = txtDNI.Text;
                        usuario.Nombre = txtNombre.Text;
                        usuario.Apellido = txtApellido.Text;
                        usuario.Email = txtEmail.Text;
                        usuario.Rol = cbRol.Text;

                        gestorUsuario.Modificar(usuario);
                        MessageBox.Show("Operación Modificar Exitosa.");
                        break;

                    case TiposOperacion.Desbloqueo:
                        usuario = ArmarUsuarioDesdeGrilla();
                        usuario.Bloqueado = false;
                        usuario.IntentosFallidos = 0;

                        gestorUsuario.Modificar(usuario);
                        MessageBox.Show("Usuario Desbloqueado con éxito.");
                        break;

                    case TiposOperacion.ActivarDesactivar:
                        usuario = ArmarUsuarioDesdeGrilla();
                        if (usuario.Activo == true)
                        {
                            usuario.Activo = false;
                            MessageBox.Show("Usuario Desactivado.");
                        }
                        else
                        {
                            usuario.Activo = true;
                            MessageBox.Show("Usuario Activado.");
                        }

                        gestorUsuario.Modificar(usuario);
                        break;
                }
                Usuario usuGuardado = gestorUsuario.ObtenerPorNombre(usuario.NombreUsuario);
                int idPerfilSeleccionado = Convert.ToInt32(cbRol.SelectedValue);
                new RolBLL().AsignarPerfilAUsuario(usuGuardado.ID_Usuario, idPerfilSeleccionado);

                ActualizarGrilla();
                ModoConsulta();
            }
            catch (Exception ex) { MessageBox.Show("Error al Aplicar: " + ex.Message);}
        }

        private void ActualizarGrilla()
        {
            try
            {
                List<Usuario> listaCompleta = gestorUsuario.Listar();

                if (rdbActivos.Checked == true)
                {
                    dataGridView1.DataSource = listaCompleta.Where(u => u.Activo == true).ToList();
                }
                else
                {
                    dataGridView1.DataSource = listaCompleta;
                }

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
            catch (Exception ex) { MessageBox.Show("Error de BD: " + ex.Message); }
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
                txtNombre.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells["Nombre"].Value);
                txtApellido.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells["Apellido"].Value);
                txtDNI.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells["DNI"].Value);
                txtEmail.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells["Email"].Value);
                cbRol.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells["Rol"].Value);
            }
        }

        private void rdbActivos_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbActivos.Checked)
            {
                ActualizarGrilla();
                ModoConsulta();
            }
        }

        private void rdbTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbTodos.Checked)
            {
                ActualizarGrilla();
                ModoConsulta();
            }
        }

        private Usuario ArmarUsuarioDesdeGrilla()
        {
            Usuario usuario = new Usuario();
            usuario.ID_Usuario = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID_Usuario"].Value);
            usuario.DNI = Convert.ToString(dataGridView1.SelectedRows[0].Cells["DNI"].Value);
            usuario.Nombre = Convert.ToString(dataGridView1.SelectedRows[0].Cells["Nombre"].Value);
            usuario.Apellido = Convert.ToString(dataGridView1.SelectedRows[0].Cells["Apellido"].Value);
            usuario.NombreUsuario = Convert.ToString(dataGridView1.SelectedRows[0].Cells["NombreUsuario"].Value);
            usuario.Email = Convert.ToString(dataGridView1.SelectedRows[0].Cells["Email"].Value);
            usuario.Rol = Convert.ToString(dataGridView1.SelectedRows[0].Cells["Rol"].Value);
            usuario.Activo = Convert.ToBoolean(dataGridView1.SelectedRows[0].Cells["Activo"].Value);
            usuario.Bloqueado = Convert.ToBoolean(dataGridView1.SelectedRows[0].Cells["Bloqueado"].Value);
            return usuario;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ActualizarIdioma()
        {
            this.Text = Services.Observer.IdiomaManager.Instancia.Traducir("tituloUsuariosABMC");

            label3.Text = Services.Observer.IdiomaManager.Instancia.Traducir("lblDNI");
            label2.Text = Services.Observer.IdiomaManager.Instancia.Traducir("lblApellido");
            label1.Text = Services.Observer.IdiomaManager.Instancia.Traducir("lblNombre");
            label6.Text = Services.Observer.IdiomaManager.Instancia.Traducir("lblEmail");
            label5.Text = Services.Observer.IdiomaManager.Instancia.Traducir("lblRol");

            btnCrear.Text = Services.Observer.IdiomaManager.Instancia.Traducir("btnAnadir");
            btnModificar.Text = Services.Observer.IdiomaManager.Instancia.Traducir("btnModificar");
            btnDesbloquear.Text = Services.Observer.IdiomaManager.Instancia.Traducir("btnDesbloquear");
            btnActDesact.Text = Services.Observer.IdiomaManager.Instancia.Traducir("btnActDesact");

            btnAceptar.Text = Services.Observer.IdiomaManager.Instancia.Traducir("btnAceptar"); 
            btnCancelar.Text = Services.Observer.IdiomaManager.Instancia.Traducir("buttonCancelar"); 
            btnSalir.Text = Services.Observer.IdiomaManager.Instancia.Traducir("btnSalir");

            rdbActivos.Text = Services.Observer.IdiomaManager.Instancia.Traducir("rdbActivos");
            rdbTodos.Text = Services.Observer.IdiomaManager.Instancia.Traducir("rdbTodos");
            int indexSeleccionado = cbRol.SelectedIndex;


            ActualizarGrilla();

            switch (TipoOperacion)
            {
                case TiposOperacion.Consulta:
                    txtMensaje.Text = Services.Observer.IdiomaManager.Instancia.Traducir("modoConsulta");
                    break;
                case TiposOperacion.Alta:
                    txtMensaje.Text = Services.Observer.IdiomaManager.Instancia.Traducir("modoAnadir");
                    break;
                case TiposOperacion.Modificacion:
                    txtMensaje.Text = Services.Observer.IdiomaManager.Instancia.Traducir("modoModificar");
                    break;
                case TiposOperacion.Desbloqueo:
                    txtMensaje.Text = Services.Observer.IdiomaManager.Instancia.Traducir("modoDesbloquear");
                    break;
                case TiposOperacion.ActivarDesactivar:
                    txtMensaje.Text = Services.Observer.IdiomaManager.Instancia.Traducir("modoEliminar");
                    break;
            }
        }

        private void FormUsuarios_FormClosing(object sender, FormClosingEventArgs e)
        {
            Services.Observer.IdiomaManager.Instancia.Desuscribir(this);
        }
    }
}