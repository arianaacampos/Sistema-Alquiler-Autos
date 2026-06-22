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
    public partial class FormPerfiles : Form
    {
        private PermisosBLL _permisosBLL = new PermisosBLL();
        public FormPerfiles()
        {
            InitializeComponent();
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
        }
        private void ActualizarGrillaPermisos()
        {
            try
            {
                var todos = _permisosBLL.ObtenerTodos();
                var soloPermisos = todos.Where(c => c.GetType().Name == "Permiso").ToList();

                dgvPermisos.DataSource = null;
                dgvPermisos.DataSource = soloPermisos;

                if (dgvPermisos.Columns.Count > 0)
                {
                    dgvPermisos.Columns["Id"].Visible = false;
                    dgvPermisos.Columns["Permiso"].Visible = false; // Ocultamos el codigo del sistema

                    dgvPermisos.Columns["Nombre"].HeaderText = "Permiso";
                    dgvPermisos.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                // Magia para que se actualicen los ListBox
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
                // Validamos el único TextBox que tenés
                if (string.IsNullOrWhiteSpace(txtPermisoNombre.Text))
                {
                    MessageBox.Show("Por favor, ingrese el nombre del permiso (Ej: Ver Bitácora).", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Creamos el Permiso
                Componente nuevoPermiso = new Permiso();
                nuevoPermiso.Nombre = txtPermisoNombre.Text.Trim();
                // Al interno no le ponemos nada, ya que usamos solo 1 campo.

                // Guardamos en BD
                _permisosBLL.CrearComponente(nuevoPermiso, "Permiso");

                MessageBox.Show("Permiso creado con éxito.", "Creación", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiamos y actualizamos
                txtPermisoNombre.Text = "";
                ActualizarGrillaPermisos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarPermiso_Click(object sender, EventArgs e)
        {
            try
            {

                if (dgvPermisos.SelectedRows.Count > 0)
                {
                    DialogResult respuesta = MessageBox.Show("¿Está seguro que desea eliminar este permiso?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (respuesta == DialogResult.Yes)
                    {

                        int id = Convert.ToInt32(dgvPermisos.SelectedRows[0].Cells["Id"].Value);
                        string nombre = dgvPermisos.SelectedRows[0].Cells["Nombre"].Value.ToString();


                        _permisosBLL.EliminarComponente(id, nombre, "Permiso");

                        MessageBox.Show("Permiso eliminado con éxito.", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ActualizarGrillaPermisos();
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un permiso de la grilla para eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ActualizarGrillaPerfiles()
        {
            try
            {
                var todos = _permisosBLL.ObtenerTodos();
                var soloPerfiles = todos.Where(c => c.GetType().Name == "Perfil").ToList();

                dgvPerfiles.DataSource = null;
                dgvPerfiles.DataSource = soloPerfiles;

                if (dgvPerfiles.Columns.Count > 0)
                {
                    dgvPerfiles.Columns["Id"].Visible = false;
                    dgvPerfiles.Columns["Permiso"].Visible = false; // Ocultamos el codigo del sistema

                    dgvPerfiles.Columns["Nombre"].HeaderText = "Perfil";
                    dgvPerfiles.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                CargarListasPerfil();
                CargarListasFamilia();
            }
            catch { }
        }
        private void btnCrearPerfil_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtPerfilNombre.Text))
                {
                    MessageBox.Show("Por favor, ingrese el nombre del Perfil (Ej: Director).", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Creamos el Perfil (Patrón Composite: creamos un Compuesto)
                Componente nuevoPerfil = new Perfil();
                nuevoPerfil.Nombre = txtPerfilNombre.Text.Trim();

                // Guardamos en BD
                _permisosBLL.CrearComponente(nuevoPerfil, "Perfil");

                MessageBox.Show("Perfil creado con éxito.", "Creación", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiamos y actualizamos
                txtPerfilNombre.Text = "";
                ActualizarGrillaPerfiles();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarPerfil_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPerfiles.SelectedRows.Count > 0)
                {
                    DialogResult respuesta = MessageBox.Show("¿Está seguro que desea eliminar este perfil?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (respuesta == DialogResult.Yes)
                    {
                        int id = Convert.ToInt32(dgvPerfiles.SelectedRows[0].Cells["Id"].Value);
                        string nombre = dgvPerfiles.SelectedRows[0].Cells["Nombre"].Value.ToString();

                        _permisosBLL.EliminarComponente(id, nombre, "Perfil");

                        MessageBox.Show("Perfil eliminado con éxito.", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ActualizarGrillaPerfiles();
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un perfil de la grilla para eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ActualizarGrillaFamilias()
        {
            try
            {
                var todos = _permisosBLL.ObtenerTodos();
                var soloFamilias = todos.Where(c => c.GetType().Name == "Familia").ToList();

                dgvFamilias.DataSource = null;
                dgvFamilias.DataSource = soloFamilias;

                if (dgvFamilias.Columns.Count > 0)
                {
                    dgvFamilias.Columns["Id"].Visible = false;
                    dgvFamilias.Columns["Permiso"].Visible = false; // Ocultamos el codigo del sistema

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
                if (string.IsNullOrWhiteSpace(txtFamiliaNombre.Text))
                {
                    MessageBox.Show("Por favor, ingrese el nombre de la Familia (Ej: Gerencia).", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Creamos la Familia (Patrón Composite: creamos un Compuesto)
                Componente nuevaFamilia = new Familia();
                nuevaFamilia.Nombre = txtFamiliaNombre.Text.Trim();

                // Guardamos en BD
                _permisosBLL.CrearComponente(nuevaFamilia, "Familia");

                MessageBox.Show("Familia creada con éxito.", "Creación", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiamos y actualizamos
                txtFamiliaNombre.Text = "";
                ActualizarGrillaFamilias();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarFamilia_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvFamilias.SelectedRows.Count > 0)
                {
                    DialogResult respuesta = MessageBox.Show("¿Está seguro que desea eliminar esta familia?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (respuesta == DialogResult.Yes)
                    {
                        int id = Convert.ToInt32(dgvFamilias.SelectedRows[0].Cells["Id"].Value);
                        string nombre = dgvFamilias.SelectedRows[0].Cells["Nombre"].Value.ToString();

                        _permisosBLL.EliminarComponente(id, nombre, "Familia");

                        MessageBox.Show("Familia eliminada con éxito.", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ActualizarGrillaFamilias();
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione una familia de la grilla para eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

                int idPerfilSeleccionado = Convert.ToInt32(dgvPerfiles.SelectedRows[0].Cells["Id"].Value);

                var todosLosComponentes = _permisosBLL.ObtenerTodos();
                var asignadosAlPerfil = _permisosBLL.ObtenerHijos(idPerfilSeleccionado);

                // --- SECCIÓN FAMILIAS ---
                var todasLasFamilias = todosLosComponentes.Where(c => c.GetType().Name == "Familia").ToList();
                var familiasAsignadas = asignadosAlPerfil.Where(c => c.GetType().Name == "Familia").ToList();
                var familiasDisponibles = todasLasFamilias.Where(f => !familiasAsignadas.Any(fa => fa.Id == f.Id)).ToList();

                // Usando TUS nombres exactos de la foto
                LstPermisosDisponiblesPerfil.DataSource = null;
                LstPermisosDisponiblesPerfil.DataSource = familiasDisponibles;
                LstPermisosDisponiblesPerfil.DisplayMember = "Nombre";

                LstFamiliasAsignadasPerfil.DataSource = null;
                LstFamiliasAsignadasPerfil.DataSource = familiasAsignadas;
                LstFamiliasAsignadasPerfil.DisplayMember = "Nombre";

                // --- SECCIÓN PERMISOS ---
                var todosLosPermisos = todosLosComponentes.Where(c => c.GetType().Name == "Permiso").ToList();
                var permisosAsignados = asignadosAlPerfil.Where(c => c.GetType().Name == "Permiso").ToList();
                var permisosDisponibles = todosLosPermisos.Where(p => !permisosAsignados.Any(pa => pa.Id == p.Id)).ToList();

                // Usando TUS nombres exactos de la foto
                lstPermisosPerfil.DataSource = null;
                lstPermisosPerfil.DataSource = permisosDisponibles;
                lstPermisosPerfil.DisplayMember = "Nombre";

                LstPermisosAsignadosPerfil.DataSource = null;
                LstPermisosAsignadosPerfil.DataSource = permisosAsignados;
                LstPermisosAsignadosPerfil.DisplayMember = "Nombre";
            }
            catch (Exception ex)
            {
                // Si falla al inicio, no mostramos error para que no moleste al abrir el form
            }
        }
        private void MoverComponente(ListBox listaOrigen, bool esAsignar)
        {
            if (dgvPerfiles.SelectedRows.Count == 0) return;
            if (listaOrigen.SelectedItem == null) return;

            int idPadre = Convert.ToInt32(dgvPerfiles.SelectedRows[0].Cells["Id"].Value);
            Componente hijoSeleccionado = (Componente)listaOrigen.SelectedItem;

            try
            {
                if (esAsignar)
                {
                    _permisosBLL.AsignarComponente(idPadre, hijoSeleccionado.Id);
                }
                else
                {
                    _permisosBLL.QuitarComponente(idPadre, hijoSeleccionado.Id);
                }

                CargarListasPerfil(); // Recargamos para ver los cambios
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MoverComponente(LstPermisosDisponiblesPerfil, true);
        }

        private void btnAgregarUnPermiso_Click(object sender, EventArgs e)
        {

            MoverComponente(lstPermisosPerfil, true);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MoverComponente(LstFamiliasAsignadasPerfil, false);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            MoverComponente(LstPermisosAsignadosPerfil, false);
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

                var todosLosComponentes = _permisosBLL.ObtenerTodos();
                var asignadosALaFamilia = _permisosBLL.ObtenerHijos(idFamiliaSeleccionada);

                // --- SECCIÓN SUB-FAMILIAS ---
                // (Para asignar una familia adentro de otra familia)
                var todasLasFamilias = todosLosComponentes.Where(c => c.GetType().Name == "Familia" && c.Id != idFamiliaSeleccionada).ToList();
                var familiasAsignadas = asignadosALaFamilia.Where(c => c.GetType().Name == "Familia").ToList();
                var familiasDisponibles = todasLasFamilias.Where(f => !familiasAsignadas.Any(fa => fa.Id == f.Id)).ToList();

                lstFamiliasDisponibles.DataSource = null;
                lstFamiliasDisponibles.DataSource = familiasDisponibles;
                lstFamiliasDisponibles.DisplayMember = "Nombre";

                LstFamiliasAsignadas.DataSource = null;
                LstFamiliasAsignadas.DataSource = familiasAsignadas;
                LstFamiliasAsignadas.DisplayMember = "Nombre";

                // --- SECCIÓN PERMISOS ---
                var todosLosPermisos = todosLosComponentes.Where(c => c.GetType().Name == "Permiso").ToList();
                var permisosAsignados = asignadosALaFamilia.Where(c => c.GetType().Name == "Permiso").ToList();
                var permisosDisponibles = todosLosPermisos.Where(p => !permisosAsignados.Any(pa => pa.Id == p.Id)).ToList();

                lstPermisosDisponibles.DataSource = null;
                lstPermisosDisponibles.DataSource = permisosDisponibles;
                lstPermisosDisponibles.DisplayMember = "Nombre";

                lstPermisosAsignados.DataSource = null;
                lstPermisosAsignados.DataSource = permisosAsignados;
                lstPermisosAsignados.DisplayMember = "Nombre";
            }
            catch (Exception ex)
            {
                // Ignoramos errores de carga inicial
            }
        }
            private void MoverComponenteFamilia(ListBox listaOrigen, bool esAsignar)
        {
            if (dgvFamilias.SelectedRows.Count == 0) return;
            if (listaOrigen.SelectedItem == null) return;

            int idPadre = Convert.ToInt32(dgvFamilias.SelectedRows[0].Cells["Id"].Value);
            Componente hijoSeleccionado = (Componente)listaOrigen.SelectedItem;

            try
            {
                if (esAsignar)
                {
                    _permisosBLL.AsignarComponente(idPadre, hijoSeleccionado.Id);
                }
                else
                {
                    _permisosBLL.QuitarComponente(idPadre, hijoSeleccionado.Id);
                }

                CargarListasFamilia(); // Recargamos para ver los cambios
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la asignación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            MoverComponenteFamilia(lstFamiliasDisponibles, true);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            MoverComponenteFamilia(LstFamiliasAsignadas, false);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            MoverComponenteFamilia(lstPermisosDisponibles, true);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            MoverComponenteFamilia(lstPermisosAsignados, false);
        }
        private void MostrarArbol()
        {
            try
            {
                tvArbol.Nodes.Clear();
                if (cbFiltroArbol.SelectedItem == null) return;

                string filtro = cbFiltroArbol.SelectedItem.ToString();
                var todos = _permisosBLL.ObtenerTodos();

                // 1. Definimos cuáles son las raíces (nodos principales) según lo que eligió en el combo
                var raices = new System.Collections.Generic.List<Componente>();

                if (filtro == "Perfiles")
                    raices = todos.Where(c => c.GetType().Name == "Perfil").ToList();
                else if (filtro == "Familias")
                    raices = todos.Where(c => c.GetType().Name == "Familia").ToList();
                else if (filtro == "Permisos")
                    raices = todos.Where(c => c.GetType().Name == "Permiso").ToList();

                // 2. Dibujamos las raíces en el arbolito
                foreach (var raiz in raices)
                {
                    TreeNode nodoRaiz = new TreeNode(raiz.Nombre);
                    tvArbol.Nodes.Add(nodoRaiz);

                    // Si es un Perfil o Familia, escarbamos adentro a ver si tiene hijos
                    if (filtro != "Permisos")
                    {
                        ArmarArbolRecursivo(nodoRaiz, raiz.Id);
                    }
                }

                // Expandimos todo para que el profe lo vea desplegado de una
                tvArbol.ExpandAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el árbol: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // FUNCIÓN RECURSIVA PARA LLENAR LOS HIJOS (COMPOSITE PURA SANGRE)
        private void ArmarArbolRecursivo(TreeNode nodoPadre, int idPadre)
        {
            // Buscamos qué hijos tiene este padre en la base de datos
            var hijos = _permisosBLL.ObtenerHijos(idPadre);

            foreach (var hijo in hijos)
            {
                // Creamos la ramita
                TreeNode nodoHijo = new TreeNode(hijo.Nombre);
                nodoPadre.Nodes.Add(nodoHijo);

                // Si este hijo también es una Familia, volvemos a llamar a esta misma función 
                // para ver qué tiene adentro (RECURSIVIDAD)
                if (hijo.GetType().Name == "Familia")
                {
                    ArmarArbolRecursivo(nodoHijo, hijo.Id);
                }
            }
        }

        private void cbFiltroArbol_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarArbol();
        }
    }
}

