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

            CargarRolesComboBox();

            rdbActivos.Checked = true;

            Services.Observer.IdiomaManager.Instancia.Suscribir(this);
            ActualizarIdioma();

            ActualizarGrilla();
            ModoConsulta();
        }
        private void CargarRolesComboBox()
        {
            RolBLL gestorRol = new RolBLL();
            var listaPerfiles = gestorRol.ObtenerTodos();

            var idioma = Services.Observer.IdiomaManager.Instancia;
            foreach (var perfil in listaPerfiles)
            {
                perfil.Nombre = idioma.Traducir(perfil.Nombre);
            }

            cbRol.DataSource = null;
            cbRol.DataSource = listaPerfiles;
            cbRol.DisplayMember = "Nombre";
            cbRol.ValueMember = "Id";
            cbRol.DropDownStyle = ComboBoxStyle.DropDownList;
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

        private void PrepararOperacion(TiposOperacion tipoOp, string claveMensaje, bool habilitarCajas)
        {
            TipoOperacion = tipoOp;
            txtMensaje.Text = Services.Observer.IdiomaManager.Instancia.Traducir(claveMensaje);

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
            PrepararOperacion(TiposOperacion.Alta, "modoAnadir", true);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                PrepararOperacion(TiposOperacion.Modificacion, "modoModificar", true);
                CargarDatosEnCajas();
            }
            else
            {
                MessageBox.Show(Services.Observer.IdiomaManager.Instancia.Traducir("msg_SeleccioneRegistro"));
            }
        }

        private void btnDesbloquear_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                PrepararOperacion(TiposOperacion.Desbloqueo, "modoDesbloquear", false);
                CargarDatosEnCajas();
            }
            else
            {
                MessageBox.Show(Services.Observer.IdiomaManager.Instancia.Traducir("msg_SeleccioneRegistro"));
            }
        }

        private void btnActDesact_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                PrepararOperacion(TiposOperacion.ActivarDesactivar, "modoEliminar", false);
                CargarDatosEnCajas();
            }
            else
            {
                MessageBox.Show(Services.Observer.IdiomaManager.Instancia.Traducir("msg_SeleccioneRegistro"));
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ModoConsulta();
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            var idioma = Services.Observer.IdiomaManager.Instancia;
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
                            MessageBox.Show(idioma.Traducir("msg_DNIDuplicado"), idioma.Traducir("tit_DNIDuplicado"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        new BitacoraBLL().Registrar(Sesion.Instancia.UsuarioActual, "Admin", $"Se creó el nuevo usuario: '{loginDinamico}'", "Alta");

                        MessageBox.Show(string.Format(idioma.Traducir("msg_AnadirExito"), loginDinamico));
                        break;

                    case TiposOperacion.Modificacion:
                        usuario = ArmarUsuarioDesdeGrilla();
                        usuario.DNI = txtDNI.Text;
                        usuario.Nombre = txtNombre.Text;
                        usuario.Apellido = txtApellido.Text;
                        usuario.Email = txtEmail.Text;
                        usuario.Rol = cbRol.Text;

                        gestorUsuario.Modificar(usuario);
                        MessageBox.Show(idioma.Traducir("msg_ModificarExito"));
                        new BitacoraBLL().Registrar(Sesion.Instancia.UsuarioActual, "Admin", $"Se modificaron los datos del usuario: '{usuario.NombreUsuario}'", "Media");
                        break;

                    case TiposOperacion.Desbloqueo:
                        usuario = ArmarUsuarioDesdeGrilla();
                        usuario.Bloqueado = false;
                        usuario.IntentosFallidos = 0;

                        gestorUsuario.Modificar(usuario);
                        MessageBox.Show(idioma.Traducir("msg_DesbloqueoExito"));
                        new BitacoraBLL().Registrar(Sesion.Instancia.UsuarioActual, "Admin", $"Se desbloqueó manualmente al usuario: '{usuario.NombreUsuario}'", "Alta");
                        break;

                    case TiposOperacion.ActivarDesactivar:
                        usuario = ArmarUsuarioDesdeGrilla();
                        if (usuario.Activo == true)
                        {
                            usuario.Activo = false;
                            MessageBox.Show(idioma.Traducir("msg_UsuarioDesactivado"));
                        }
                        else
                        {
                            usuario.Activo = true;
                            MessageBox.Show(idioma.Traducir("msg_UsuarioActivado"));
                        }

                        gestorUsuario.Modificar(usuario);
                        break;
                }

                Usuario usuGuardado = gestorUsuario.ObtenerPorNombre(usuario.NombreUsuario);
                int idPerfilSeleccionado = Convert.ToInt32(cbRol.SelectedValue);
                string nombreRolSeleccionado = cbRol.Text;

                new RolBLL().AsignarPerfilAUsuario(usuGuardado.ID_Usuario, idPerfilSeleccionado);

                string msjAuditoria = $"Se asignó el Rol '{nombreRolSeleccionado}' al usuario '{usuario.NombreUsuario}'";
                new BitacoraBLL().Registrar(Sesion.Instancia.UsuarioActual, "Admin", msjAuditoria, "Alta");

                ActualizarGrilla();
                ModoConsulta();
            }
            catch (Exception ex) { MessageBox.Show(idioma.Traducir("msg_ErrorAplicar") + ex.Message); }
        }

        private void ActualizarGrilla()
        {
            var idioma = Services.Observer.IdiomaManager.Instancia;
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
                    if (dataGridView1.Columns.Contains("IdiomaPreferencia"))
                        dataGridView1.Columns["IdiomaPreferencia"].Visible = false;

                    dataGridView1.Columns["Apellido"].HeaderText = idioma.Traducir("col_Apellidos");
                    dataGridView1.Columns["Nombre"].HeaderText = idioma.Traducir("col_Nombres");
                    dataGridView1.Columns["NombreUsuario"].HeaderText = idioma.Traducir("col_Login");
                }
            }
            catch (Exception ex) { MessageBox.Show(idioma.Traducir("msg_ErrorBD") + ex.Message); }
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
            var idioma = Services.Observer.IdiomaManager.Instancia;

            this.Text = idioma.Traducir("tituloUsuariosABMC");

            label6.Text = idioma.Traducir("lblDNI");
            label2.Text = idioma.Traducir("lblApellido");
            label1.Text = idioma.Traducir("lblNombre");
            label3.Text = idioma.Traducir("lblEmail");
            label5.Text = idioma.Traducir("lblRol");

            btnCrear.Text = idioma.Traducir("btnAnadir");
            btnModificar.Text = idioma.Traducir("btnModificar");
            btnDesbloquear.Text = idioma.Traducir("btnDesbloquear");
            btnActDesact.Text = idioma.Traducir("btnActDesact");

            btnAceptar.Text = idioma.Traducir("btnAceptar");
            btnCancelar.Text = idioma.Traducir("buttonCancelar");
            btnSalir.Text = idioma.Traducir("btnSalir");

            rdbActivos.Text = idioma.Traducir("rdbActivos");
            rdbTodos.Text = idioma.Traducir("rdbTodos");

            int indexSeleccionado = cbRol.SelectedIndex;
            CargarRolesComboBox();
            cbRol.SelectedIndex = indexSeleccionado;

            ActualizarGrilla();

            switch (TipoOperacion)
            {
                case TiposOperacion.Consulta:
                    txtMensaje.Text = idioma.Traducir("modoConsulta");
                    break;
                case TiposOperacion.Alta:
                    txtMensaje.Text = idioma.Traducir("modoAnadir");
                    break;
                case TiposOperacion.Modificacion:
                    txtMensaje.Text = idioma.Traducir("modoModificar");
                    break;
                case TiposOperacion.Desbloqueo:
                    txtMensaje.Text = idioma.Traducir("modoDesbloquear");
                    break;
                case TiposOperacion.ActivarDesactivar:
                    txtMensaje.Text = idioma.Traducir("modoEliminar");
                    break;
            }
        }

        private void FormUsuarios_FormClosing(object sender, FormClosingEventArgs e)
        {
            Services.Observer.IdiomaManager.Instancia.Desuscribir(this);
        }
    }
}