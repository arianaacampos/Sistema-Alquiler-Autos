namespace SistemaAlquiler.Admin
{
    partial class FormPerfiles
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvPermisos = new System.Windows.Forms.DataGridView();
            this.txtPermisoNombre = new System.Windows.Forms.TextBox();
            this.btnCrearPermiso = new System.Windows.Forms.Button();
            this.btnEliminarPermiso = new System.Windows.Forms.Button();
            this.tvArbol = new System.Windows.Forms.TreeView();
            this.cbFiltroArbol = new System.Windows.Forms.ComboBox();
            this.btnEliminarPerfil = new System.Windows.Forms.Button();
            this.btnCrearPerfil = new System.Windows.Forms.Button();
            this.txtPerfilNombre = new System.Windows.Forms.TextBox();
            this.btnEliminarFamilia = new System.Windows.Forms.Button();
            this.btnCrearFamilia = new System.Windows.Forms.Button();
            this.txtFamiliaNombre = new System.Windows.Forms.TextBox();
            this.LstPermisosDisponiblesPerfil = new System.Windows.Forms.ListBox();
            this.lstPermisosPerfil = new System.Windows.Forms.ListBox();
            this.LstFamiliasAsignadasPerfil = new System.Windows.Forms.ListBox();
            this.LstPermisosAsignadosPerfil = new System.Windows.Forms.ListBox();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.btnAgregarUnPermiso = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.lstPermisosAsignados = new System.Windows.Forms.ListBox();
            this.LstFamiliasAsignadas = new System.Windows.Forms.ListBox();
            this.lstPermisosDisponibles = new System.Windows.Forms.ListBox();
            this.lstFamiliasDisponibles = new System.Windows.Forms.ListBox();
            this.dgvPerfiles = new System.Windows.Forms.DataGridView();
            this.dgvFamilias = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPermisos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPerfiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFamilias)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPermisos
            // 
            this.dgvPermisos.AllowUserToAddRows = false;
            this.dgvPermisos.AllowUserToDeleteRows = false;
            this.dgvPermisos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPermisos.Location = new System.Drawing.Point(5, 18);
            this.dgvPermisos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvPermisos.Name = "dgvPermisos";
            this.dgvPermisos.ReadOnly = true;
            this.dgvPermisos.RowHeadersWidth = 62;
            this.dgvPermisos.RowTemplate.Height = 28;
            this.dgvPermisos.Size = new System.Drawing.Size(281, 98);
            this.dgvPermisos.TabIndex = 0;
            // 
            // txtPermisoNombre
            // 
            this.txtPermisoNombre.Location = new System.Drawing.Point(5, 120);
            this.txtPermisoNombre.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPermisoNombre.Name = "txtPermisoNombre";
            this.txtPermisoNombre.Size = new System.Drawing.Size(281, 20);
            this.txtPermisoNombre.TabIndex = 1;
            // 
            // btnCrearPermiso
            // 
            this.btnCrearPermiso.Location = new System.Drawing.Point(5, 144);
            this.btnCrearPermiso.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCrearPermiso.Name = "btnCrearPermiso";
            this.btnCrearPermiso.Size = new System.Drawing.Size(138, 37);
            this.btnCrearPermiso.TabIndex = 2;
            this.btnCrearPermiso.Text = "CREAR";
            this.btnCrearPermiso.UseVisualStyleBackColor = true;
            this.btnCrearPermiso.Click += new System.EventHandler(this.btnCrearPermiso_Click);
            // 
            // btnEliminarPermiso
            // 
            this.btnEliminarPermiso.Location = new System.Drawing.Point(148, 144);
            this.btnEliminarPermiso.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnEliminarPermiso.Name = "btnEliminarPermiso";
            this.btnEliminarPermiso.Size = new System.Drawing.Size(138, 37);
            this.btnEliminarPermiso.TabIndex = 3;
            this.btnEliminarPermiso.Text = "BORRAR";
            this.btnEliminarPermiso.UseVisualStyleBackColor = true;
            this.btnEliminarPermiso.Click += new System.EventHandler(this.btnEliminarPermiso_Click);
            // 
            // tvArbol
            // 
            this.tvArbol.Location = new System.Drawing.Point(11, 35);
            this.tvArbol.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tvArbol.Name = "tvArbol";
            this.tvArbol.Size = new System.Drawing.Size(292, 181);
            this.tvArbol.TabIndex = 4;
            // 
            // cbFiltroArbol
            // 
            this.cbFiltroArbol.FormattingEnabled = true;
            this.cbFiltroArbol.Items.AddRange(new object[] {
            "Permisos",
            "Familias",
            "Perfiles"});
            this.cbFiltroArbol.Location = new System.Drawing.Point(11, 7);
            this.cbFiltroArbol.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbFiltroArbol.Name = "cbFiltroArbol";
            this.cbFiltroArbol.Size = new System.Drawing.Size(292, 21);
            this.cbFiltroArbol.TabIndex = 5;
            this.cbFiltroArbol.SelectedIndexChanged += new System.EventHandler(this.cbFiltroArbol_SelectedIndexChanged);
            // 
            // btnEliminarPerfil
            // 
            this.btnEliminarPerfil.Location = new System.Drawing.Point(148, 144);
            this.btnEliminarPerfil.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnEliminarPerfil.Name = "btnEliminarPerfil";
            this.btnEliminarPerfil.Size = new System.Drawing.Size(138, 37);
            this.btnEliminarPerfil.TabIndex = 10;
            this.btnEliminarPerfil.Text = "BORRAR";
            this.btnEliminarPerfil.UseVisualStyleBackColor = true;
            this.btnEliminarPerfil.Click += new System.EventHandler(this.btnEliminarPerfil_Click);
            // 
            // btnCrearPerfil
            // 
            this.btnCrearPerfil.Location = new System.Drawing.Point(6, 144);
            this.btnCrearPerfil.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCrearPerfil.Name = "btnCrearPerfil";
            this.btnCrearPerfil.Size = new System.Drawing.Size(138, 37);
            this.btnCrearPerfil.TabIndex = 9;
            this.btnCrearPerfil.Text = "CREAR";
            this.btnCrearPerfil.UseVisualStyleBackColor = true;
            this.btnCrearPerfil.Click += new System.EventHandler(this.btnCrearPerfil_Click);
            // 
            // txtPerfilNombre
            // 
            this.txtPerfilNombre.Location = new System.Drawing.Point(5, 120);
            this.txtPerfilNombre.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPerfilNombre.Name = "txtPerfilNombre";
            this.txtPerfilNombre.Size = new System.Drawing.Size(281, 20);
            this.txtPerfilNombre.TabIndex = 8;
            // 
            // btnEliminarFamilia
            // 
            this.btnEliminarFamilia.Location = new System.Drawing.Point(148, 144);
            this.btnEliminarFamilia.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnEliminarFamilia.Name = "btnEliminarFamilia";
            this.btnEliminarFamilia.Size = new System.Drawing.Size(138, 37);
            this.btnEliminarFamilia.TabIndex = 15;
            this.btnEliminarFamilia.Text = "BORRAR";
            this.btnEliminarFamilia.UseVisualStyleBackColor = true;
            this.btnEliminarFamilia.Click += new System.EventHandler(this.btnEliminarFamilia_Click);
            // 
            // btnCrearFamilia
            // 
            this.btnCrearFamilia.Location = new System.Drawing.Point(5, 144);
            this.btnCrearFamilia.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCrearFamilia.Name = "btnCrearFamilia";
            this.btnCrearFamilia.Size = new System.Drawing.Size(138, 37);
            this.btnCrearFamilia.TabIndex = 14;
            this.btnCrearFamilia.Text = "CREAR";
            this.btnCrearFamilia.UseVisualStyleBackColor = true;
            this.btnCrearFamilia.Click += new System.EventHandler(this.btnCrearFamilia_Click);
            // 
            // txtFamiliaNombre
            // 
            this.txtFamiliaNombre.Location = new System.Drawing.Point(5, 120);
            this.txtFamiliaNombre.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtFamiliaNombre.Name = "txtFamiliaNombre";
            this.txtFamiliaNombre.Size = new System.Drawing.Size(281, 20);
            this.txtFamiliaNombre.TabIndex = 13;
            // 
            // LstPermisosDisponiblesPerfil
            // 
            this.LstPermisosDisponiblesPerfil.FormattingEnabled = true;
            this.LstPermisosDisponiblesPerfil.Location = new System.Drawing.Point(651, 43);
            this.LstPermisosDisponiblesPerfil.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.LstPermisosDisponiblesPerfil.Name = "LstPermisosDisponiblesPerfil";
            this.LstPermisosDisponiblesPerfil.Size = new System.Drawing.Size(138, 82);
            this.LstPermisosDisponiblesPerfil.TabIndex = 17;
            // 
            // lstPermisosPerfil
            // 
            this.lstPermisosPerfil.FormattingEnabled = true;
            this.lstPermisosPerfil.Location = new System.Drawing.Point(309, 43);
            this.lstPermisosPerfil.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lstPermisosPerfil.Name = "lstPermisosPerfil";
            this.lstPermisosPerfil.Size = new System.Drawing.Size(138, 82);
            this.lstPermisosPerfil.TabIndex = 18;
            // 
            // LstFamiliasAsignadasPerfil
            // 
            this.LstFamiliasAsignadasPerfil.FormattingEnabled = true;
            this.LstFamiliasAsignadasPerfil.Location = new System.Drawing.Point(819, 43);
            this.LstFamiliasAsignadasPerfil.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.LstFamiliasAsignadasPerfil.Name = "LstFamiliasAsignadasPerfil";
            this.LstFamiliasAsignadasPerfil.Size = new System.Drawing.Size(138, 82);
            this.LstFamiliasAsignadasPerfil.TabIndex = 19;
            // 
            // LstPermisosAsignadosPerfil
            // 
            this.LstPermisosAsignadosPerfil.FormattingEnabled = true;
            this.LstPermisosAsignadosPerfil.Location = new System.Drawing.Point(475, 43);
            this.LstPermisosAsignadosPerfil.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.LstPermisosAsignadosPerfil.Name = "LstPermisosAsignadosPerfil";
            this.LstPermisosAsignadosPerfil.Size = new System.Drawing.Size(138, 82);
            this.LstPermisosAsignadosPerfil.TabIndex = 20;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(651, 129);
            this.button7.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(138, 37);
            this.button7.TabIndex = 21;
            this.button7.Text = "ASIGNAR";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(819, 129);
            this.button8.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(138, 37);
            this.button8.TabIndex = 22;
            this.button8.Text = "QUITAR";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // btnAgregarUnPermiso
            // 
            this.btnAgregarUnPermiso.Location = new System.Drawing.Point(309, 129);
            this.btnAgregarUnPermiso.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAgregarUnPermiso.Name = "btnAgregarUnPermiso";
            this.btnAgregarUnPermiso.Size = new System.Drawing.Size(138, 37);
            this.btnAgregarUnPermiso.TabIndex = 23;
            this.btnAgregarUnPermiso.Text = "ASIGNAR";
            this.btnAgregarUnPermiso.UseVisualStyleBackColor = true;
            this.btnAgregarUnPermiso.Click += new System.EventHandler(this.btnAgregarUnPermiso_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(475, 129);
            this.button10.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(138, 37);
            this.button10.TabIndex = 24;
            this.button10.Text = "QUITAR";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(660, 28);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "FAMILIAS DISPONIBLES";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(306, 28);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "PERMISOS DISPONIBLES";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(828, 25);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "FAMILIAS ASIGNADAS";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(481, 28);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(132, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "PERMISOS  ASIGNADOS";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(481, 18);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(132, 13);
            this.label8.TabIndex = 40;
            this.label8.Text = "PERMISOS  ASIGNADOS";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(487, 25);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(120, 13);
            this.label9.TabIndex = 39;
            this.label9.Text = "FAMILIAS ASIGNADAS";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(306, 18);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(137, 13);
            this.label10.TabIndex = 38;
            this.label10.Text = "PERMISOS DISPONIBLES";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(321, 27);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(129, 13);
            this.label11.TabIndex = 37;
            this.label11.Text = "FAMILIAS DISPONIBLES";
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(475, 120);
            this.button11.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(138, 37);
            this.button11.TabIndex = 36;
            this.button11.Text = "QUITAR";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(309, 120);
            this.button12.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(138, 37);
            this.button12.TabIndex = 35;
            this.button12.Text = "ASIGNAR";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(480, 129);
            this.button13.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(138, 37);
            this.button13.TabIndex = 34;
            this.button13.Text = "QUITAR";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(314, 129);
            this.button14.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(138, 37);
            this.button14.TabIndex = 33;
            this.button14.Text = "ASIGNAR";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // lstPermisosAsignados
            // 
            this.lstPermisosAsignados.FormattingEnabled = true;
            this.lstPermisosAsignados.Location = new System.Drawing.Point(475, 34);
            this.lstPermisosAsignados.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lstPermisosAsignados.Name = "lstPermisosAsignados";
            this.lstPermisosAsignados.Size = new System.Drawing.Size(138, 82);
            this.lstPermisosAsignados.TabIndex = 32;
            // 
            // LstFamiliasAsignadas
            // 
            this.LstFamiliasAsignadas.FormattingEnabled = true;
            this.LstFamiliasAsignadas.Location = new System.Drawing.Point(480, 43);
            this.LstFamiliasAsignadas.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.LstFamiliasAsignadas.Name = "LstFamiliasAsignadas";
            this.LstFamiliasAsignadas.Size = new System.Drawing.Size(138, 82);
            this.LstFamiliasAsignadas.TabIndex = 31;
            // 
            // lstPermisosDisponibles
            // 
            this.lstPermisosDisponibles.FormattingEnabled = true;
            this.lstPermisosDisponibles.Location = new System.Drawing.Point(309, 34);
            this.lstPermisosDisponibles.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lstPermisosDisponibles.Name = "lstPermisosDisponibles";
            this.lstPermisosDisponibles.Size = new System.Drawing.Size(138, 82);
            this.lstPermisosDisponibles.TabIndex = 30;
            // 
            // lstFamiliasDisponibles
            // 
            this.lstFamiliasDisponibles.FormattingEnabled = true;
            this.lstFamiliasDisponibles.Location = new System.Drawing.Point(314, 43);
            this.lstFamiliasDisponibles.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lstFamiliasDisponibles.Name = "lstFamiliasDisponibles";
            this.lstFamiliasDisponibles.Size = new System.Drawing.Size(138, 82);
            this.lstFamiliasDisponibles.TabIndex = 29;
            // 
            // dgvPerfiles
            // 
            this.dgvPerfiles.AllowUserToAddRows = false;
            this.dgvPerfiles.AllowUserToDeleteRows = false;
            this.dgvPerfiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPerfiles.Location = new System.Drawing.Point(5, 18);
            this.dgvPerfiles.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvPerfiles.Name = "dgvPerfiles";
            this.dgvPerfiles.ReadOnly = true;
            this.dgvPerfiles.RowHeadersWidth = 62;
            this.dgvPerfiles.RowTemplate.Height = 28;
            this.dgvPerfiles.Size = new System.Drawing.Size(281, 98);
            this.dgvPerfiles.TabIndex = 41;
            this.dgvPerfiles.SelectionChanged += new System.EventHandler(this.dgvPerfiles_SelectionChanged);
            // 
            // dgvFamilias
            // 
            this.dgvFamilias.AllowUserToAddRows = false;
            this.dgvFamilias.AllowUserToDeleteRows = false;
            this.dgvFamilias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFamilias.Location = new System.Drawing.Point(5, 18);
            this.dgvFamilias.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvFamilias.Name = "dgvFamilias";
            this.dgvFamilias.ReadOnly = true;
            this.dgvFamilias.RowHeadersWidth = 62;
            this.dgvFamilias.RowTemplate.Height = 28;
            this.dgvFamilias.Size = new System.Drawing.Size(281, 98);
            this.dgvFamilias.TabIndex = 42;
            this.dgvFamilias.SelectionChanged += new System.EventHandler(this.dgvFamilias_SelectionChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvPermisos);
            this.groupBox1.Controls.Add(this.btnAgregarUnPermiso);
            this.groupBox1.Controls.Add(this.txtPerfilNombre);
            this.groupBox1.Controls.Add(this.lstPermisosPerfil);
            this.groupBox1.Controls.Add(this.btnEliminarPerfil);
            this.groupBox1.Controls.Add(this.btnCrearPerfil);
            this.groupBox1.Controls.Add(this.LstPermisosAsignadosPerfil);
            this.groupBox1.Controls.Add(this.button10);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(326, 220);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(629, 193);
            this.groupBox1.TabIndex = 43;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Perfiles";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvFamilias);
            this.groupBox2.Controls.Add(this.LstPermisosDisponiblesPerfil);
            this.groupBox2.Controls.Add(this.button7);
            this.groupBox2.Controls.Add(this.txtFamiliaNombre);
            this.groupBox2.Controls.Add(this.button8);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.btnCrearFamilia);
            this.groupBox2.Controls.Add(this.btnEliminarFamilia);
            this.groupBox2.Controls.Add(this.LstFamiliasAsignadasPerfil);
            this.groupBox2.Controls.Add(this.LstFamiliasAsignadas);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.lstFamiliasDisponibles);
            this.groupBox2.Controls.Add(this.button14);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.button13);
            this.groupBox2.Location = new System.Drawing.Point(326, 437);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(984, 193);
            this.groupBox2.TabIndex = 44;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Familias";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtPermisoNombre);
            this.groupBox3.Controls.Add(this.button11);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.lstPermisosAsignados);
            this.groupBox3.Controls.Add(this.btnCrearPermiso);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.button12);
            this.groupBox3.Controls.Add(this.dgvPerfiles);
            this.groupBox3.Controls.Add(this.btnEliminarPermiso);
            this.groupBox3.Controls.Add(this.lstPermisosDisponibles);
            this.groupBox3.Location = new System.Drawing.Point(326, 7);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(629, 193);
            this.groupBox3.TabIndex = 45;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Permisos";
            // 
            // FormPerfiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1498, 772);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cbFiltroArbol);
            this.Controls.Add(this.tvArbol);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormPerfiles";
            this.Text = "FormPerfiles";
            this.Load += new System.EventHandler(this.FormPerfiles_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPermisos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPerfiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFamilias)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPermisos;
        private System.Windows.Forms.TextBox txtPermisoNombre;
        private System.Windows.Forms.Button btnCrearPermiso;
        private System.Windows.Forms.Button btnEliminarPermiso;
        private System.Windows.Forms.TreeView tvArbol;
        private System.Windows.Forms.ComboBox cbFiltroArbol;
        private System.Windows.Forms.Button btnEliminarPerfil;
        private System.Windows.Forms.Button btnCrearPerfil;
        private System.Windows.Forms.TextBox txtPerfilNombre;
        private System.Windows.Forms.Button btnEliminarFamilia;
        private System.Windows.Forms.Button btnCrearFamilia;
        private System.Windows.Forms.TextBox txtFamiliaNombre;
        private System.Windows.Forms.ListBox LstPermisosDisponiblesPerfil;
        private System.Windows.Forms.ListBox lstPermisosPerfil;
        private System.Windows.Forms.ListBox LstFamiliasAsignadasPerfil;
        private System.Windows.Forms.ListBox LstPermisosAsignadosPerfil;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button btnAgregarUnPermiso;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.ListBox lstPermisosAsignados;
        private System.Windows.Forms.ListBox LstFamiliasAsignadas;
        private System.Windows.Forms.ListBox lstPermisosDisponibles;
        private System.Windows.Forms.ListBox lstFamiliasDisponibles;
        private System.Windows.Forms.DataGridView dgvPerfiles;
        private System.Windows.Forms.DataGridView dgvFamilias;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}