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
        private List<Componente> TraducirComponentes(List<Componente> lista)
        {
            var idioma = Services.Observer.IdiomaManager.Instancia;
            foreach (var comp in lista)
            {
                comp.Nombre = idioma.Traducir(comp.Nombre);
            }
            return lista;
        }
        public void ActualizarIdioma()
        {
            var idioma = Services.Observer.IdiomaManager.Instancia;
            this.Text = idioma.Traducir("tituloPerfilesABMC");

            btnCrearFamilia.Text = idioma.Traducir("btnCrearFamilia");
            btnEliminarFamilia.Text = idioma.Traducir("btnEliminarFamilia");

            btnCrearPerfil.Text = idioma.Traducir("btnCrearPerfil");
            btnEliminarPerfil.Text = idioma.Traducir("btnEliminarPerfil");

            label5.Text = idioma.Traducir("lblPermisosDisponibles");
            label10.Text = idioma.Traducir("lblPermisosDisponibles");
            label7.Text = idioma.Traducir("lblPermisosAsignados");
            label8.Text = idioma.Traducir("lblPermisosAsignados");

            label4.Text = idioma.Traducir("lblFamiliasDisponibles");
            label11.Text = idioma.Traducir("lblFamiliasDisponibles");
            label6.Text = idioma.Traducir("lblFamiliasAsignadas");
            label9.Text = idioma.Traducir("lblFamiliasAsignadas");

            button7.Text = idioma.Traducir("btnAsignar");
            btnAgregarUnPermiso.Text = idioma.Traducir("btnAsignar");
            button14.Text = idioma.Traducir("btnAsignar");
            button12.Text = idioma.Traducir("btnAsignar");
            button8.Text = idioma.Traducir("btnQuitar");
            button10.Text = idioma.Traducir("btnQuitar");
            button13.Text = idioma.Traducir("btnQuitar");
            button11.Text = idioma.Traducir("btnQuitar");

            groupBox2.Text = idioma.Traducir("gbFamilias");
            groupBox1.Text = idioma.Traducir("gbPerfiles");

            int indexFiltro = cbFiltroArbol.SelectedIndex;
            cbFiltroArbol.Items.Clear();
            cbFiltroArbol.Items.Add(idioma.Traducir("filtroPerfiles"));
            cbFiltroArbol.Items.Add(idioma.Traducir("filtroFamilias"));
            cbFiltroArbol.Items.Add(idioma.Traducir("filtroPermisos"));
            if (indexFiltro >= 0) cbFiltroArbol.SelectedIndex = indexFiltro;

            if (dgvFamilias.Columns["Nombre"] != null)
                dgvFamilias.Columns["Nombre"].HeaderText = idioma.Traducir("colFamilia");

            if (dgvPerfiles.Columns["Nombre"] != null)
                dgvPerfiles.Columns["Nombre"].HeaderText = idioma.Traducir("colPerfil");

            ActualizarGrillaPerfiles();
            ActualizarGrillaFamilias();
            MostrarArbol();
        }

        private void FormPerfiles_Load(object sender, EventArgs e)
        {

            dgvPerfiles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPerfiles.MultiSelect = false;
            dgvPerfiles.ReadOnly = true;

            ActualizarGrillaPerfiles();
            Services.Observer.IdiomaManager.Instancia.Suscribir(this);
            ActualizarIdioma();
        }

        private bool YaTieneElComponente(int idPadre, int idComponenteBuscado, bool padreEsRol, bool buscadoEsPatente)
        {
            var hijos = padreEsRol ? _rolBLL.ObtenerHijos(idPadre) : _familiaBLL.ObtenerHijos(idPadre);

            foreach (var hijo in hijos)
            {
                bool hijoEsPatente = hijo.GetType().Name == "Patente";
                if (hijo.Id == idComponenteBuscado && hijoEsPatente == buscadoEsPatente)
                {
                    return true; 
                }

                if (!hijoEsPatente)
                {
                    if (YaTieneElComponente(hijo.Id, idComponenteBuscado, false, buscadoEsPatente))
                    {
                        return true; 
                    }
                }
            }
            return false; 
        }

        private void ActualizarGrillaPerfiles()
        {
            try
            {
                dgvPerfiles.DataSource = null;
                var perfiles = TraducirComponentes(_rolBLL.ObtenerTodos());
                dgvPerfiles.DataSource = perfiles;

                if (dgvPerfiles.Columns.Count > 0)
                {
                    dgvPerfiles.Columns["Id"].Visible = false;
                    dgvPerfiles.Columns["Nombre"].HeaderText = "Rol (Perfil)";
                    dgvPerfiles.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                dgvPerfiles.ClearSelection();
                CargarListasPerfil();
                CargarListasFamilia();
            }
            catch { }
        }
        private void btnCrearPerfil_Click(object sender, EventArgs e)
        {
            var idioma = Services.Observer.IdiomaManager.Instancia;
            try
            {
                if (string.IsNullOrWhiteSpace(txtPerfilNombre.Text)) return;

                Componente nuevoRol = new Rol();
                nuevoRol.Nombre = txtPerfilNombre.Text.Trim();
                int idNuevoRol = _rolBLL.Crear(nuevoRol);

                var todasLasPatentes = _patenteBLL.ObtenerTodos();
                if (todasLasPatentes.Count > 0)
                {
                    Random rnd = new Random();
                    int indiceAlAzar = rnd.Next(todasLasPatentes.Count);
                    Componente patenteRandom = todasLasPatentes[indiceAlAzar];
                    _rolBLL.AsignarComponente(idNuevoRol, patenteRandom, true);
                }

                MessageBox.Show(idioma.Traducir("msg_RolCreadoExito"));
                new BitacoraBLL().Registrar(Sesion.Instancia.UsuarioActual, "Admin", $"Se creó el Rol '{nuevoRol.Nombre}'", "Alta");

                txtPerfilNombre.Text = "";
                dgvFamilias.ClearSelection();
                ActualizarGrillaPerfiles();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnEliminarPerfil_Click(object sender, EventArgs e)
        {
            var idioma = Services.Observer.IdiomaManager.Instancia;
            try
            {
                if (dgvPerfiles.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show(idioma.Traducir("msg_ConfirmarEliminarRol"), idioma.Traducir("tit_Confirmar"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        int id = Convert.ToInt32(dgvPerfiles.SelectedRows[0].Cells["Id"].Value);
                        _rolBLL.Eliminar(id);
                        MessageBox.Show(idioma.Traducir("msg_RolEliminadoExito"));
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
                var familias = TraducirComponentes(_familiaBLL.ObtenerTodos());
                dgvFamilias.DataSource = familias;

                if (dgvFamilias.Columns.Count > 0)
                {
                    dgvFamilias.Columns["Id"].Visible = false;
                    dgvFamilias.Columns["Nombre"].HeaderText = "Familia";
                    dgvFamilias.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                dgvFamilias.ClearSelection();
                CargarListasPerfil();
                CargarListasFamilia();
            }
            catch { }
        } 
    
        private void btnCrearFamilia_Click(object sender, EventArgs e)
        {
            var idioma = Services.Observer.IdiomaManager.Instancia;
            try
            {
                if (string.IsNullOrWhiteSpace(txtFamiliaNombre.Text)) return;

                Componente nuevaFamilia = new Familia();
                nuevaFamilia.Nombre = txtFamiliaNombre.Text.Trim();
                int idNuevaFamilia = _familiaBLL.Crear(nuevaFamilia);

                var todasLasPatentes = _patenteBLL.ObtenerTodos();
                if (todasLasPatentes.Count > 0)
                {
                    Random rnd = new Random();
                    int indiceAlAzar = rnd.Next(todasLasPatentes.Count);
                    Componente patenteRandom = todasLasPatentes[indiceAlAzar];
                    _familiaBLL.AsignarComponente(idNuevaFamilia, patenteRandom, true);
                }

                MessageBox.Show(idioma.Traducir("msg_FamiliaCreadaExito"));
                new BitacoraBLL().Registrar(Sesion.Instancia.UsuarioActual, "Admin", $"Se creó la Familia '{nuevaFamilia.Nombre}'", "Media");

                txtFamiliaNombre.Text = "";
                dgvFamilias.ClearSelection();
                ActualizarGrillaFamilias();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnEliminarFamilia_Click(object sender, EventArgs e)
        {
            var idioma = Services.Observer.IdiomaManager.Instancia;
            try
            {
                if (dgvFamilias.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show(idioma.Traducir("msg_ConfirmarEliminarFamilia"), idioma.Traducir("tit_Confirmar"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        int id = Convert.ToInt32(dgvFamilias.SelectedRows[0].Cells["Id"].Value);
                        _familiaBLL.Eliminar(id);
                        MessageBox.Show(idioma.Traducir("msg_FamiliaEliminadaExito"));
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

                var familiasAsignadas = TraducirComponentes(asignadosAlRol.Where(c => c.GetType().Name == "Familia").ToList());
                var familiasDisponibles = TraducirComponentes(todasLasFamilias.Where(f => !asignadosAlRol.Any(fa => fa.Id == f.Id)).ToList());

                LstPermisosDisponiblesPerfil.DataSource = null;
                LstPermisosDisponiblesPerfil.DataSource = familiasDisponibles;
                LstPermisosDisponiblesPerfil.DisplayMember = "Nombre";

                LstFamiliasAsignadasPerfil.DataSource = null;
                LstFamiliasAsignadasPerfil.DataSource = familiasAsignadas;
                LstFamiliasAsignadasPerfil.DisplayMember = "Nombre";

                var patentesAsignadas = TraducirComponentes(asignadosAlRol.Where(c => c.GetType().Name == "Patente").ToList());
                var patentesDisponibles = TraducirComponentes(todasLasPatentes.Where(p => !asignadosAlRol.Any(pa => pa.Id == p.Id)).ToList());

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
            var idioma = Services.Observer.IdiomaManager.Instancia;
            if (dgvPerfiles.SelectedRows.Count == 0 || listaOrigen.SelectedItem == null) return;

            int idRol = Convert.ToInt32(dgvPerfiles.SelectedRows[0].Cells["Id"].Value);
            string nombreRol = dgvPerfiles.SelectedRows[0].Cells["Nombre"].Value.ToString();
            Componente hijoSeleccionado = (Componente)listaOrigen.SelectedItem;

            try
            {
                if (esAsignar)
                {
                    if (YaTieneElComponente(idRol, hijoSeleccionado.Id, true, esPatente))
                    {
                        MessageBox.Show(string.Format(idioma.Traducir("msg_RolYaContiene"), nombreRol), idioma.Traducir("tit_Duplicado"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    _rolBLL.AsignarComponente(idRol, hijoSeleccionado, esPatente);
                }
                else
                {
                    _rolBLL.QuitarComponente(idRol, hijoSeleccionado, esPatente);
                }

                string accion = esAsignar ? "Asignó" : "Quitó";
                string tipo = esPatente ? "Patente" : "Familia";
                string detalle = $"Se {accion} la {tipo} '{hijoSeleccionado.Nombre}' en el Rol '{nombreRol}'";
                new BitacoraBLL().Registrar(Sesion.Instancia.UsuarioActual, "Admin", detalle, "Media");

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

                var familiasAsignadas = TraducirComponentes(asignadosALaFamilia.Where(c => c.GetType().Name == "Familia").ToList());
                var familiasDisponibles = TraducirComponentes(todasLasFamilias.Where(f => f.Id != idFamiliaSeleccionada && !asignadosALaFamilia.Any(fa => fa.Id == f.Id)).ToList());

                lstFamiliasDisponibles.DataSource = null;
                lstFamiliasDisponibles.DataSource = familiasDisponibles;
                lstFamiliasDisponibles.DisplayMember = "Nombre";

                LstFamiliasAsignadas.DataSource = null;
                LstFamiliasAsignadas.DataSource = familiasAsignadas;
                LstFamiliasAsignadas.DisplayMember = "Nombre";

                var patentesAsignadas = TraducirComponentes(asignadosALaFamilia.Where(c => c.GetType().Name == "Patente").ToList());
                var patentesDisponibles = TraducirComponentes(todasLasPatentes.Where(p => !asignadosALaFamilia.Any(pa => pa.Id == p.Id)).ToList());

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
            var idioma = Services.Observer.IdiomaManager.Instancia;
            if (dgvFamilias.SelectedRows.Count == 0 || listaOrigen.SelectedItem == null) return;

            int idPadre = Convert.ToInt32(dgvFamilias.SelectedRows[0].Cells["Id"].Value);
            string nombrePadre = dgvFamilias.SelectedRows[0].Cells["Nombre"].Value.ToString();
            Componente hijoSeleccionado = (Componente)listaOrigen.SelectedItem;

            try
            {
                if (esAsignar)
                {
                    if (!esPatente && idPadre == hijoSeleccionado.Id)
                    {
                        MessageBox.Show(idioma.Traducir("msg_ErrorRecursividad"), idioma.Traducir("tit_ErrorRecursividad"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (!esPatente && YaTieneElComponente(hijoSeleccionado.Id, idPadre, false, false))
                    {
                        MessageBox.Show(idioma.Traducir("msg_BucleInfinito"), idioma.Traducir("tit_BucleInfinito"), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    if (YaTieneElComponente(idPadre, hijoSeleccionado.Id, false, esPatente))
                    {
                        MessageBox.Show(string.Format(idioma.Traducir("msg_FamiliaYaContiene"), nombrePadre), idioma.Traducir("tit_Duplicado"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    _familiaBLL.AsignarComponente(idPadre, hijoSeleccionado, esPatente);
                }
                else
                {
                    _familiaBLL.QuitarComponente(idPadre, hijoSeleccionado, esPatente);
                }

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
            var idioma = Services.Observer.IdiomaManager.Instancia;
            try
            {
                tvArbol.Nodes.Clear();
                if (cbFiltroArbol.SelectedIndex == -1) return;

                int filtroIndex = cbFiltroArbol.SelectedIndex;
                var raices = new System.Collections.Generic.List<Componente>();

                if (filtroIndex == 0)
                    raices = TraducirComponentes(_rolBLL.ObtenerTodos());
                else if (filtroIndex == 1)
                    raices = TraducirComponentes(_familiaBLL.ObtenerTodos());
                else if (filtroIndex == 2)
                    raices = TraducirComponentes(_patenteBLL.ObtenerTodos());

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
                MessageBox.Show(idioma.Traducir("msg_ErrorCargarArbol") + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ArmarArbolRecursivo(TreeNode nodoPadre, int idPadre, bool padreEsRol)
        {
            var hijos = padreEsRol ? TraducirComponentes(_rolBLL.ObtenerHijos(idPadre)) : TraducirComponentes(_familiaBLL.ObtenerHijos(idPadre));

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

        private void dgvFamilias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvPerfiles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}

