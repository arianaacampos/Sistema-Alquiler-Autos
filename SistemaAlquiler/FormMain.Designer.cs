namespace SistemaAlquiler
{
    partial class FormMain
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bitacoraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.perfilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.digitoVerificarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maestrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vehiculoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tallerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reLoginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cambiarClaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cambiarIdiomaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarAlquilerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarDevolucionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelarReservaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarDisponibilidadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mantenimientoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enviarAlTallerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarServicioMecanicoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rentabilidadPorVehiculoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historialDeGastosPorUnidadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estadisticaDeAlquileresMasSolicitadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manualDeUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(783, 326);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(241, 188);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.DarkRed;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminToolStripMenuItem,
            this.maestrosToolStripMenuItem,
            this.usuarioToolStripMenuItem,
            this.operacionesToolStripMenuItem,
            this.mantenimientoToolStripMenuItem,
            this.reporteToolStripMenuItem,
            this.ayudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(159, 529);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuariosToolStripMenuItem,
            this.bitacoraToolStripMenuItem,
            this.backupToolStripMenuItem,
            this.restoreToolStripMenuItem,
            this.perfilesToolStripMenuItem,
            this.digitoVerificarToolStripMenuItem});
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(154, 29);
            this.adminToolStripMenuItem.Text = "Admin";
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(216, 30);
            this.usuariosToolStripMenuItem.Text = "Usuarios";
            this.usuariosToolStripMenuItem.Click += new System.EventHandler(this.usuariosToolStripMenuItem_Click);
            // 
            // bitacoraToolStripMenuItem
            // 
            this.bitacoraToolStripMenuItem.Name = "bitacoraToolStripMenuItem";
            this.bitacoraToolStripMenuItem.Size = new System.Drawing.Size(216, 30);
            this.bitacoraToolStripMenuItem.Text = "Bitacora";
            this.bitacoraToolStripMenuItem.Click += new System.EventHandler(this.bitacoraToolStripMenuItem_Click);
            // 
            // backupToolStripMenuItem
            // 
            this.backupToolStripMenuItem.Name = "backupToolStripMenuItem";
            this.backupToolStripMenuItem.Size = new System.Drawing.Size(216, 30);
            this.backupToolStripMenuItem.Text = "Backup";
            // 
            // restoreToolStripMenuItem
            // 
            this.restoreToolStripMenuItem.Name = "restoreToolStripMenuItem";
            this.restoreToolStripMenuItem.Size = new System.Drawing.Size(216, 30);
            this.restoreToolStripMenuItem.Text = "Restore";
            // 
            // perfilesToolStripMenuItem
            // 
            this.perfilesToolStripMenuItem.Name = "perfilesToolStripMenuItem";
            this.perfilesToolStripMenuItem.Size = new System.Drawing.Size(216, 30);
            this.perfilesToolStripMenuItem.Text = "Perfiles";
            // 
            // digitoVerificarToolStripMenuItem
            // 
            this.digitoVerificarToolStripMenuItem.Name = "digitoVerificarToolStripMenuItem";
            this.digitoVerificarToolStripMenuItem.Size = new System.Drawing.Size(216, 30);
            this.digitoVerificarToolStripMenuItem.Text = "Digito verificar";
            // 
            // maestrosToolStripMenuItem
            // 
            this.maestrosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vehiculoToolStripMenuItem,
            this.clienteToolStripMenuItem,
            this.tallerToolStripMenuItem});
            this.maestrosToolStripMenuItem.Name = "maestrosToolStripMenuItem";
            this.maestrosToolStripMenuItem.Size = new System.Drawing.Size(154, 29);
            this.maestrosToolStripMenuItem.Text = "Maestros";
            // 
            // vehiculoToolStripMenuItem
            // 
            this.vehiculoToolStripMenuItem.Name = "vehiculoToolStripMenuItem";
            this.vehiculoToolStripMenuItem.Size = new System.Drawing.Size(160, 30);
            this.vehiculoToolStripMenuItem.Text = "Vehiculo";
            // 
            // clienteToolStripMenuItem
            // 
            this.clienteToolStripMenuItem.Name = "clienteToolStripMenuItem";
            this.clienteToolStripMenuItem.Size = new System.Drawing.Size(160, 30);
            this.clienteToolStripMenuItem.Text = "Cliente";
            // 
            // tallerToolStripMenuItem
            // 
            this.tallerToolStripMenuItem.Name = "tallerToolStripMenuItem";
            this.tallerToolStripMenuItem.Size = new System.Drawing.Size(160, 30);
            this.tallerToolStripMenuItem.Text = "Taller";
            // 
            // usuarioToolStripMenuItem
            // 
            this.usuarioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reLoginToolStripMenuItem,
            this.cambiarClaveToolStripMenuItem,
            this.logoutToolStripMenuItem,
            this.cambiarIdiomaToolStripMenuItem});
            this.usuarioToolStripMenuItem.Name = "usuarioToolStripMenuItem";
            this.usuarioToolStripMenuItem.Size = new System.Drawing.Size(154, 29);
            this.usuarioToolStripMenuItem.Text = "Usuario";
            // 
            // reLoginToolStripMenuItem
            // 
            this.reLoginToolStripMenuItem.Name = "reLoginToolStripMenuItem";
            this.reLoginToolStripMenuItem.Size = new System.Drawing.Size(224, 30);
            this.reLoginToolStripMenuItem.Text = "Re login";
            this.reLoginToolStripMenuItem.Click += new System.EventHandler(this.reLoginToolStripMenuItem_Click);
            // 
            // cambiarClaveToolStripMenuItem
            // 
            this.cambiarClaveToolStripMenuItem.Name = "cambiarClaveToolStripMenuItem";
            this.cambiarClaveToolStripMenuItem.Size = new System.Drawing.Size(224, 30);
            this.cambiarClaveToolStripMenuItem.Text = "Cambiar clave";
            this.cambiarClaveToolStripMenuItem.Click += new System.EventHandler(this.cambiarClaveToolStripMenuItem_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(224, 30);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // cambiarIdiomaToolStripMenuItem
            // 
            this.cambiarIdiomaToolStripMenuItem.Name = "cambiarIdiomaToolStripMenuItem";
            this.cambiarIdiomaToolStripMenuItem.Size = new System.Drawing.Size(224, 30);
            this.cambiarIdiomaToolStripMenuItem.Text = "Cambiar idioma";
            // 
            // operacionesToolStripMenuItem
            // 
            this.operacionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registrarAlquilerToolStripMenuItem,
            this.registrarDevolucionToolStripMenuItem,
            this.cancelarReservaToolStripMenuItem,
            this.consultarDisponibilidadToolStripMenuItem});
            this.operacionesToolStripMenuItem.Name = "operacionesToolStripMenuItem";
            this.operacionesToolStripMenuItem.Size = new System.Drawing.Size(154, 29);
            this.operacionesToolStripMenuItem.Text = "Operaciones";
            // 
            // registrarAlquilerToolStripMenuItem
            // 
            this.registrarAlquilerToolStripMenuItem.Name = "registrarAlquilerToolStripMenuItem";
            this.registrarAlquilerToolStripMenuItem.Size = new System.Drawing.Size(302, 30);
            this.registrarAlquilerToolStripMenuItem.Text = "Registrar alquiler";
            // 
            // registrarDevolucionToolStripMenuItem
            // 
            this.registrarDevolucionToolStripMenuItem.Name = "registrarDevolucionToolStripMenuItem";
            this.registrarDevolucionToolStripMenuItem.Size = new System.Drawing.Size(302, 30);
            this.registrarDevolucionToolStripMenuItem.Text = "Registrar devolucion";
            // 
            // cancelarReservaToolStripMenuItem
            // 
            this.cancelarReservaToolStripMenuItem.Name = "cancelarReservaToolStripMenuItem";
            this.cancelarReservaToolStripMenuItem.Size = new System.Drawing.Size(302, 30);
            this.cancelarReservaToolStripMenuItem.Text = "Cancelar reserva";
            // 
            // consultarDisponibilidadToolStripMenuItem
            // 
            this.consultarDisponibilidadToolStripMenuItem.Name = "consultarDisponibilidadToolStripMenuItem";
            this.consultarDisponibilidadToolStripMenuItem.Size = new System.Drawing.Size(302, 30);
            this.consultarDisponibilidadToolStripMenuItem.Text = "Consultar disponibilidad";
            // 
            // mantenimientoToolStripMenuItem
            // 
            this.mantenimientoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enviarAlTallerToolStripMenuItem,
            this.registrarServicioMecanicoToolStripMenuItem});
            this.mantenimientoToolStripMenuItem.Name = "mantenimientoToolStripMenuItem";
            this.mantenimientoToolStripMenuItem.Size = new System.Drawing.Size(154, 29);
            this.mantenimientoToolStripMenuItem.Text = "Mantenimiento";
            // 
            // enviarAlTallerToolStripMenuItem
            // 
            this.enviarAlTallerToolStripMenuItem.Name = "enviarAlTallerToolStripMenuItem";
            this.enviarAlTallerToolStripMenuItem.Size = new System.Drawing.Size(326, 30);
            this.enviarAlTallerToolStripMenuItem.Text = "Enviar al taller";
            // 
            // registrarServicioMecanicoToolStripMenuItem
            // 
            this.registrarServicioMecanicoToolStripMenuItem.Name = "registrarServicioMecanicoToolStripMenuItem";
            this.registrarServicioMecanicoToolStripMenuItem.Size = new System.Drawing.Size(326, 30);
            this.registrarServicioMecanicoToolStripMenuItem.Text = "Registrar servicio mecanico";
            // 
            // reporteToolStripMenuItem
            // 
            this.reporteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rentabilidadPorVehiculoToolStripMenuItem,
            this.historialDeGastosPorUnidadToolStripMenuItem,
            this.estadisticaDeAlquileresMasSolicitadosToolStripMenuItem});
            this.reporteToolStripMenuItem.Name = "reporteToolStripMenuItem";
            this.reporteToolStripMenuItem.Size = new System.Drawing.Size(154, 29);
            this.reporteToolStripMenuItem.Text = "Reporte";
            // 
            // rentabilidadPorVehiculoToolStripMenuItem
            // 
            this.rentabilidadPorVehiculoToolStripMenuItem.Name = "rentabilidadPorVehiculoToolStripMenuItem";
            this.rentabilidadPorVehiculoToolStripMenuItem.Size = new System.Drawing.Size(430, 30);
            this.rentabilidadPorVehiculoToolStripMenuItem.Text = "Rentabilidad por vehiculo";
            // 
            // historialDeGastosPorUnidadToolStripMenuItem
            // 
            this.historialDeGastosPorUnidadToolStripMenuItem.Name = "historialDeGastosPorUnidadToolStripMenuItem";
            this.historialDeGastosPorUnidadToolStripMenuItem.Size = new System.Drawing.Size(430, 30);
            this.historialDeGastosPorUnidadToolStripMenuItem.Text = "Historial de gastos por unidad";
            // 
            // estadisticaDeAlquileresMasSolicitadosToolStripMenuItem
            // 
            this.estadisticaDeAlquileresMasSolicitadosToolStripMenuItem.Name = "estadisticaDeAlquileresMasSolicitadosToolStripMenuItem";
            this.estadisticaDeAlquileresMasSolicitadosToolStripMenuItem.Size = new System.Drawing.Size(430, 30);
            this.estadisticaDeAlquileresMasSolicitadosToolStripMenuItem.Text = "Estadistica de alquileres mas solicitados";
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manualDeUsuarioToolStripMenuItem});
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(154, 29);
            this.ayudaToolStripMenuItem.Text = "Ayuda";
            // 
            // manualDeUsuarioToolStripMenuItem
            // 
            this.manualDeUsuarioToolStripMenuItem.Name = "manualDeUsuarioToolStripMenuItem";
            this.manualDeUsuarioToolStripMenuItem.Size = new System.Drawing.Size(250, 30);
            this.manualDeUsuarioToolStripMenuItem.Text = "Manual de usuario";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1049, 529);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormMain";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bitacoraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem perfilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem digitoVerificarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maestrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vehiculoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tallerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reLoginToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cambiarClaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cambiarIdiomaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem operacionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrarAlquilerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrarDevolucionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelarReservaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarDisponibilidadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mantenimientoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enviarAlTallerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrarServicioMecanicoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rentabilidadPorVehiculoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem historialDeGastosPorUnidadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem estadisticaDeAlquileresMasSolicitadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manualDeUsuarioToolStripMenuItem;
    }
}

