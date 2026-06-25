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
    public partial class FormPerfiles : Form, Services.Observer.IObserverIdioma
    {
        private PatenteBLL _patenteBLL = new PatenteBLL();
        private FamiliaBLL _familiaBLL = new FamiliaBLL();
        private RolBLL _rolBLL = new RolBLL();
        public FormPerfiles()
        {
            InitializeComponent();
        }
        public void ActualizarIdioma()
        {
            this.Text = Services.Observer.IdiomaManager.Instancia.Traducir("tituloPerfilesABMC");

            btnCrearPermiso.Text = Services.Observer.IdiomaManager.Instancia.Traducir("btnCrearPatente");
            btnEliminarPermiso.Text = Services.Observer.IdiomaManager.Instancia.Traducir("btnEliminarPatente");


            btnCrearFamilia.Text = Services.Observer.IdiomaManager.Instancia.Traducir("btnCrearFamilia");
            btnEliminarFamilia.Text = Services.Observer.IdiomaManager.Instancia.Traducir("btnEliminarFamilia");

            btnCrearPerfil.Text = Services.Observer.IdiomaManager.Instancia.Traducir("btnCrearPerfil");
            btnEliminarPerfil.Text = Services.Observer.IdiomaManager.Instancia.Traducir("btnEliminarPerfil");

            label5.Text = Services.Observer.IdiomaManager.Instancia.Traducir("lblPermisosDisponibles");
            label10.Text = Services.Observer.IdiomaManager.Instancia.Traducir("lblPermisosDisponibles");
            label7.Text = Services.Observer.IdiomaManager.Instancia.Traducir("lblPermisosAsignados");
            label8.Text = Services.Observer.IdiomaManager.Instancia.Traducir("lblPermisosAsignados");

            label4.Text = Services.Observer.IdiomaManager.Instancia.Traducir("lblFamiliasDisponibles");
            label11.Text = Services.Observer.IdiomaManager.Instancia.Traducir("lblFamiliasDisponibles");
            label6.Text = Services.Observer.IdiomaManager.Instancia.Traducir("lblFamiliasAsignadas");
            label9.Text = Services.Observer.IdiomaManager.Instancia.Traducir("lblFamiliasAsignadas");
            button7.Text = Services.Observer.IdiomaManager.Instancia.Traducir("btnAsignar");
            btnAgregarUnPermiso.Text = Services.Observer.IdiomaManager.Instancia.Traducir("btnAsignar");
            button14.Text = Services.Observer.IdiomaManager.Instancia.Traducir("btnAsignar");
            button12.Text = Services.Observer.IdiomaManager.Instancia.Traducir("btnAsignar");
            button8.Text = Services.Observer.IdiomaManager.Instancia.Traducir("btnQuitar");
            button10.Text = Services.Observer.IdiomaManager.Instancia.Traducir("btnQuitar");
            button13.Text = Services.Observer.IdiomaManager.Instancia.Traducir("btnQuitar");
            button11.Text = Services.Observer.IdiomaManager.Instancia.Traducir("btnQuitar");
            groupBox3.Text = Services.Observer.IdiomaManager.Instancia.Traducir("gbPatentes");
            groupBox2.Text = Services.Observer.IdiomaManager.Instancia.Traducir("gbFamilias");
            groupBox1.Text = Services.Observer.IdiomaManager.Instancia.Traducir("gbPerfiles");

            int indexFiltro = cbFiltroArbol.SelectedIndex;
            cbFiltroArbol.Items.Clear();
            cbFiltroArbol.Items.Add(Services.Observer.IdiomaManager.Instancia.Traducir("filtroPerfiles"));
            cbFiltroArbol.Items.Add(Services.Observer.IdiomaManager.Instancia.Traducir("filtroFamilias"));
            cbFiltroArbol.Items.Add(Services.Observer.IdiomaManager.Instancia.Traducir("filtroPermisos"));
            if (indexFiltro >= 0) cbFiltroArbol.SelectedIndex = indexFiltro;

            if (dgvPermisos.Columns["Nombre"] != null)
                dgvPermisos.Columns["Nombre"].HeaderText = Services.Observer.IdiomaManager.Instancia.Traducir("colPatente");

            if (dgvFamilias.Columns["Nombre"] != null)
                dgvFamilias.Columns["Nombre"].HeaderText = Services.Observer.IdiomaManager.Instancia.Traducir("colFamilia");

            if (dgvPerfiles.Columns["Nombre"] != null)
                dgvPerfiles.Columns["Nombre"].HeaderText = Services.Observer.IdiomaManager.Instancia.Traducir("colPerfil");
        }
        private void FormPerfiles_Load(object sender, EventArgs e)
        {
            dgvPermisos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPermisos.MultiSelect = false;
            dgvPermisos.ReadOnly = true;

            dgvPerfiles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPerfiles.MultiSelect = false;
            dgvPerfiles.ReadOnly = true;

            ActualizarGrillaPermisos();
            ActualizarGrillaPerfiles();
            Services.Observer.IdiomaManager.Instancia.Suscribir(this);
            ActualizarIdioma();
        }
        private void ActualizarGrillaPermisos()
        {
            try
            {
                dgvPermisos.DataSource = null;
                dgvPermisos.DataSource = _patenteBLL.ObtenerTodos();

                if (dgvPermisos.Columns.Count > 0)
                {
                    dgvPermisos.Columns["Id"].Visible = false;
                    dgvPermisos.Columns["Nombre"].HeaderText = "Patente (Permiso)";
                    dgvPermisos.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                CargarListasPerfil();
                CargarListasFamilia();
                ActualizarGrillaFamilias();
            }
            catch { }
        }

        private void btnCrearPermiso_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtPermisoNombre.Text)) return;

                Componente nuevaPatente = new Patente();
                nuevaPatente.Nombre = txtPermisoNombre.Text.Trim();

                _patenteBLL.Crear(nuevaPatente); 
                MessageBox.Show("Patente creada.");
                new BitacoraBLL().Registrar(Sesion.Instancia.UsuarioActual, "Admin", $"Se creó el Rol '{nuevaPatente.Nombre}'", "Media");
                txtPermisoNombre.Text = "";
                ActualizarGrillaPermisos();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnEliminarPermiso_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPermisos.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show("¿Seguro que desea eliminar esta Patente?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        int id = Convert.ToInt32(dgvPermisos.SelectedRows[0].Cells["Id"].Value);
                        _patenteBLL.Eliminar(id);
                        MessageBox.Show("Patente eliminada con éxito.");
                        ActualizarGrillaPermisos();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }
        private void ActualizarGrillaPerfiles()
        {
            try
            {
                dgvPerfiles.DataSource = null;
                dgvPerfiles.DataSource = _rolBLL.ObtenerTodos();

                if (dgvPerfiles.Columns.Count > 0)
                {
                    dgvPerfiles.Columns["Id"].Visible = false;
                    dgvPerfiles.Columns["Nombre"].HeaderText = "Rol (Perfil)";
                    dgvPerfiles.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                CargarListasPerfil();
                CargarListasFamilia();

                CargarListasPerfil();
                CargarListasFamilia();
            }
            catch { }
        }
        private void btnCrearPerfil_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtPerfilNombre.Text)) return;
                if (dgvFamilias.SelectedRows.Count == 0 && dgvPermisos.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Seleccione al menos una familia o patente inicial para el Rol.");
                    return;
                }

                Componente nuevoRol = new Rol();
                nuevoRol.Nombre = txtPerfilNombre.Text.Trim();
                int idNuevoRol = _rolBLL.Crear(nuevoRol);           
                MessageBox.Show("Rol creado con éxito.");
                new BitacoraBLL().Registrar(Sesion.Instancia.UsuarioActual, "Admin", $"Se creó el Rol '{nuevoRol.Nombre}'", "Media");
                txtPerfilNombre.Text = "";
                ActualizarGrillaPerfiles();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnEliminarPerfil_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPerfiles.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show("¿Seguro que desea eliminar este Rol?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        int id = Convert.ToInt32(dgvPerfiles.SelectedRows[0].Cells["Id"].Value);
                        _rolBLL.Eliminar(id);
                        MessageBox.Show("Rol eliminado con éxito.");
                        ActualizarGrillaPerfiles();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }
        private void ActualizarGrillaFamilias()
        {
          
                try
                {
                    dgvFamilias.DataSource = null;
                    dgvFamilias.DataSource = _familiaBLL.ObtenerTodos();

                    if (dgvFamilias.Columns.Count > 0)
                    {
                        dgvFamilias.Columns["Id"].Visible = false;
                        dgvFamilias.Columns["Nombre"].HeaderText = "Familia";
                        dgvFamilias.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                    CargarListasPerfil();
                    CargarListasFamilia();
                }
                catch { }

            
        }
          
    
        private void btnCrearFamilia_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtFamiliaNombre.Text)) return;

                Componente nuevaFamilia = new Familia();
                nuevaFamilia.Nombre = txtFamiliaNombre.Text.Trim();
                int idNuevaFamilia = _familiaBLL.Crear(nuevaFamilia); 

                MessageBox.Show("Familia creada con éxito.");
                new BitacoraBLL().Registrar(Sesion.Instancia.UsuarioActual, "Admin", $"Se creó el Rol '{nuevaFamilia.Nombre}'", "Media");
                txtFamiliaNombre.Text = "";
                ActualizarGrillaFamilias();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnEliminarFamilia_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvFamilias.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show("¿Seguro que desea eliminar esta Familia?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        int id = Convert.ToInt32(dgvFamilias.SelectedRows[0].Cells["Id"].Value);
                        _familiaBLL.Eliminar(id);
                        MessageBox.Show("Familia eliminada con éxito.");
                        ActualizarGrillaFamilias();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void dgvPerfiles_SelectionChanged(object sender, EventArgs e)
        {
            CargarListasPerfil();

        }
        private void CargarListasPerfil()
        {
            try
            {
                if (dgvPerfiles.SelectedRows.Count == 0) return;

                int idRolSeleccionado = Convert.ToInt32(dgvPerfiles.SelectedRows[0].Cells["Id"].Value);


                var asignadosAlRol = _rolBLL.ObtenerHijos(idRolSeleccionado);
                var todasLasFamilias = _familiaBLL.ObtenerTodos();
                var todasLasPatentes = _patenteBLL.ObtenerTodos();


                var familiasAsignadas = asignadosAlRol.Where(c => c.GetType().Name == "Familia").ToList();
                var familiasDisponibles = todasLasFamilias.Where(f => !familiasAsignadas.Any(fa => fa.Id == f.Id)).ToList();

                LstPermisosDisponiblesPerfil.DataSource = null;
                LstPermisosDisponiblesPerfil.DataSource = familiasDisponibles;
                LstPermisosDisponiblesPerfil.DisplayMember = "Nombre";

                LstFamiliasAsignadasPerfil.DataSource = null;
                LstFamiliasAsignadasPerfil.DataSource = familiasAsignadas;
                LstFamiliasAsignadasPerfil.DisplayMember = "Nombre";


                var patentesAsignadas = asignadosAlRol.Where(c => c.GetType().Name == "Patente").ToList();
                var patentesDisponibles = todasLasPatentes.Where(p => !patentesAsignadas.Any(pa => pa.Id == p.Id)).ToList();

                lstPermisosPerfil.DataSource = null;
                lstPermisosPerfil.DataSource = patentesDisponibles;
                lstPermisosPerfil.DisplayMember = "Nombre";

                LstPermisosAsignadosPerfil.DataSource = null;
                LstPermisosAsignadosPerfil.DataSource = patentesAsignadas;
                LstPermisosAsignadosPerfil.DisplayMember = "Nombre";
            }
            catch (Exception ex) { }
        }
        private void MoverComponente(ListBox listaOrigen, bool esAsignar, bool esPatente)
        {
            if (dgvPerfiles.SelectedRows.Count == 0 || listaOrigen.SelectedItem == null) return;
            int idRol = Convert.ToInt32(dgvPerfiles.SelectedRows[0].Cells["Id"].Value);
            string nombreRol = dgvPerfiles.SelectedRows[0].Cells["Nombre"].Value.ToString(); 
            Componente hijoSeleccionado = (Componente)listaOrigen.SelectedItem;

            try
            {
                if (esAsignar) _rolBLL.AsignarComponente(idRol, hijoSeleccionado, esPatente);
                else _rolBLL.QuitarComponente(idRol, hijoSeleccionado, esPatente);

                string accion = esAsignar ? "Asignó" : "Quitó";
                string tipo = esPatente ? "Patente" : "Familia";
                string detalle = $"Se {accion} la {tipo} '{hijoSeleccionado.Nombre}' en el Rol '{nombreRol}'";
                new BitacoraBLL().Registrar(Sesion.Instancia.UsuarioActual, "Seguridad", detalle, "Media");

                CargarListasPerfil();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MoverComponente(LstPermisosDisponiblesPerfil, true, false);
        }

        private void btnAgregarUnPermiso_Click(object sender, EventArgs e)
        {

            MoverComponente(lstPermisosPerfil, true, true);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MoverComponente(LstFamiliasAsignadasPerfil, false, false);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            MoverComponente(LstPermisosAsignadosPerfil, false, true);
        }

        private void dgvFamilias_SelectionChanged(object sender, EventArgs e)
        {
            CargarListasFamilia();
        }
        private void CargarListasFamilia()
        {
            try
            {
                if (dgvFamilias.SelectedRows.Count == 0) return;

                int idFamiliaSeleccionada = Convert.ToInt32(dgvFamilias.SelectedRows[0].Cells["Id"].Value);

                var asignadosALaFamilia = _familiaBLL.ObtenerHijos(idFamiliaSeleccionada);
                var todasLasFamilias = _familiaBLL.ObtenerTodos();
                var todasLasPatentes = _patenteBLL.ObtenerTodos();

                var familiasAsignadas = asignadosALaFamilia.Where(c => c.GetType().Name == "Familia").ToList();
                var familiasDisponibles = todasLasFamilias.Where(f => f.Id != idFamiliaSeleccionada && !familiasAsignadas.Any(fa => fa.Id == f.Id)).ToList();

                lstFamiliasDisponibles.DataSource = null;
                lstFamiliasDisponibles.DataSource = familiasDisponibles;
                lstFamiliasDisponibles.DisplayMember = "Nombre";

                LstFamiliasAsignadas.DataSource = null;
                LstFamiliasAsignadas.DataSource = familiasAsignadas;
                LstFamiliasAsignadas.DisplayMember = "Nombre";

  
                var patentesAsignadas = asignadosALaFamilia.Where(c => c.GetType().Name == "Patente").ToList();
                var patentesDisponibles = todasLasPatentes.Where(p => !patentesAsignadas.Any(pa => pa.Id == p.Id)).ToList();

                lstPermisosDisponibles.DataSource = null;
                lstPermisosDisponibles.DataSource = patentesDisponibles;
                lstPermisosDisponibles.DisplayMember = "Nombre";

                lstPermisosAsignados.DataSource = null;
                lstPermisosAsignados.DataSource = patentesAsignadas;
                lstPermisosAsignados.DisplayMember = "Nombre";
            }
            catch (Exception ex) { }
        }
        private void MoverComponenteFamilia(ListBox listaOrigen, bool esAsignar, bool esPatente)
        {
            if (dgvFamilias.SelectedRows.Count == 0 || listaOrigen.SelectedItem == null) return;
            int idPadre = Convert.ToInt32(dgvFamilias.SelectedRows[0].Cells["Id"].Value);
            string nombrePadre = dgvFamilias.SelectedRows[0].Cells["Nombre"].Value.ToString(); 
            Componente hijoSeleccionado = (Componente)listaOrigen.SelectedItem;

            try
            {
                if (esAsignar) _familiaBLL.AsignarComponente(idPadre, hijoSeleccionado, esPatente);
                else _familiaBLL.QuitarComponente(idPadre, hijoSeleccionado, esPatente);

                string accion = esAsignar ? "Asignó" : "Quitó";
                string tipo = esPatente ? "Patente" : "Sub-Familia";
                string detalle = $"Se {accion} la {tipo} '{hijoSeleccionado.Nombre}' en la Familia '{nombrePadre}'";
                new BitacoraBLL().Registrar(Sesion.Instancia.UsuarioActual, "Admin", detalle, "Media");

                CargarListasFamilia();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            MoverComponenteFamilia(lstFamiliasDisponibles, true, false);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            MoverComponenteFamilia(LstFamiliasAsignadas, false, false);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            MoverComponenteFamilia(lstPermisosDisponibles, true, true);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            MoverComponenteFamilia(lstPermisosAsignados, false, true);
        }
        private void MostrarArbol()
        {
            try
            {
                tvArbol.Nodes.Clear();
                if (cbFiltroArbol.SelectedIndex == -1) return;


                int filtroIndex = cbFiltroArbol.SelectedIndex;
                var raices = new System.Collections.Generic.List<Componente>();

                if (filtroIndex == 0)
                    raices = _rolBLL.ObtenerTodos();
                else if (filtroIndex == 1)
                    raices = _familiaBLL.ObtenerTodos();
                else if (filtroIndex == 2)
                    raices = _patenteBLL.ObtenerTodos();

                foreach (var raiz in raices)
                {
                    TreeNode nodoRaiz = new TreeNode(raiz.Nombre);
                    tvArbol.Nodes.Add(nodoRaiz);

                    if (filtroIndex == 0)
                    {
                        ArmarArbolRecursivo(nodoRaiz, raiz.Id, true);
                    }
                    else if (filtroIndex == 1)
                    {
                        ArmarArbolRecursivo(nodoRaiz, raiz.Id, false);
                    }
                }

                tvArbol.ExpandAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el árbol: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ArmarArbolRecursivo(TreeNode nodoPadre, int idPadre, bool padreEsRol)
        {
            var hijos = padreEsRol ? _rolBLL.ObtenerHijos(idPadre) : _familiaBLL.ObtenerHijos(idPadre);

            foreach (var hijo in hijos)
            {
                TreeNode nodoHijo = new TreeNode(hijo.Nombre);
                nodoPadre.Nodes.Add(nodoHijo);

  
                if (hijo.GetType().Name == "Familia")
                {
                    ArmarArbolRecursivo(nodoHijo, hijo.Id, false);
                }
            }
        }

        private void cbFiltroArbol_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarArbol();
        }

        private void FormPerfiles_FormClosing(object sender, FormClosingEventArgs e)
        {
            Services.Observer.IdiomaManager.Instancia.Desuscribir(this);
        }
    }
}

