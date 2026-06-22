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
            this.label1 = new System.Windows.Forms.Label();
            this.btnEliminarPerfil = new System.Windows.Forms.Button();
            this.btnCrearPerfil = new System.Windows.Forms.Button();
            this.txtPerfilNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvPermisos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPerfiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFamilias)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPermisos
            // 
            this.dgvPermisos.AllowUserToAddRows = false;
            this.dgvPermisos.AllowUserToDeleteRows = false;
            this.dgvPermisos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPermisos.Location = new System.Drawing.Point(12, 63);
            this.dgvPermisos.Name = "dgvPermisos";
            this.dgvPermisos.ReadOnly = true;
            this.dgvPermisos.RowHeadersWidth = 62;
            this.dgvPermisos.RowTemplate.Height = 28;
            this.dgvPermisos.Size = new System.Drawing.Size(240, 150);
            this.dgvPermisos.TabIndex = 0;
            // 
            // txtPermisoNombre
            // 
            this.txtPermisoNombre.Location = new System.Drawing.Point(258, 87);
            this.txtPermisoNombre.Name = "txtPermisoNombre";
            this.txtPermisoNombre.Size = new System.Drawing.Size(100, 26);
            this.txtPermisoNombre.TabIndex = 1;
            // 
            // btnCrearPermiso
            // 
            this.btnCrearPermiso.Location = new System.Drawing.Point(258, 135);
            this.btnCrearPermiso.Name = "btnCrearPermiso";
            this.btnCrearPermiso.Size = new System.Drawing.Size(75, 23);
            this.btnCrearPermiso.TabIndex = 2;
            this.btnCrearPermiso.Text = "CREAR";
            this.btnCrearPermiso.UseVisualStyleBackColor = true;
            this.btnCrearPermiso.Click += new System.EventHandler(this.btnCrearPermiso_Click);
            // 
            // btnEliminarPermiso
            // 
            this.btnEliminarPermiso.Location = new System.Drawing.Point(258, 164);
            this.btnEliminarPermiso.Name = "btnEliminarPermiso";
            this.btnEliminarPermiso.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarPermiso.TabIndex = 3;
            this.btnEliminarPermiso.Text = "BORRAR";
            this.btnEliminarPermiso.UseVisualStyleBackColor = true;
            this.btnEliminarPermiso.Click += new System.EventHandler(this.btnEliminarPermiso_Click);
            // 
            // tvArbol
            // 
            this.tvArbol.Location = new System.Drawing.Point(-4, 255);
            this.tvArbol.Name = "tvArbol";
            this.tvArbol.Size = new System.Drawing.Size(436, 277);
            this.tvArbol.TabIndex = 4;
            // 
            // cbFiltroArbol
            // 
            this.cbFiltroArbol.FormattingEnabled = true;
            this.cbFiltroArbol.Items.AddRange(new object[] {
            "Permisos",
            "Familias",
            "Perfiles"});
            this.cbFiltroArbol.Location = new System.Drawing.Point(151, 550);
            this.cbFiltroArbol.Name = "cbFiltroArbol";
            this.cbFiltroArbol.Size = new System.Drawing.Size(121, 28);
            this.cbFiltroArbol.TabIndex = 5;
            this.cbFiltroArbol.SelectedIndexChanged += new System.EventHandler(this.cbFiltroArbol_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(80, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "PERMISO";
            // 
            // btnEliminarPerfil
            // 
            this.btnEliminarPerfil.Location = new System.Drawing.Point(915, 150);
            this.btnEliminarPerfil.Name = "btnEliminarPerfil";
            this.btnEliminarPerfil.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarPerfil.TabIndex = 10;
            this.btnEliminarPerfil.Text = "BORRAR";
            this.btnEliminarPerfil.UseVisualStyleBackColor = true;
            this.btnEliminarPerfil.Click += new System.EventHandler(this.btnEliminarPerfil_Click);
            // 
            // btnCrearPerfil
            // 
            this.btnCrearPerfil.Location = new System.Drawing.Point(915, 121);
            this.btnCrearPerfil.Name = "btnCrearPerfil";
            this.btnCrearPerfil.Size = new System.Drawing.Size(75, 23);
            this.btnCrearPerfil.TabIndex = 9;
            this.btnCrearPerfil.Text = "CREAR";
            this.btnCrearPerfil.UseVisualStyleBackColor = true;
            this.btnCrearPerfil.Click += new System.EventHandler(this.btnCrearPerfil_Click);
            // 
            // txtPerfilNombre
            // 
            this.txtPerfilNombre.Location = new System.Drawing.Point(915, 73);
            this.txtPerfilNombre.Name = "txtPerfilNombre";
            this.txtPerfilNombre.Size = new System.Drawing.Size(100, 26);
            this.txtPerfilNombre.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(700, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "PERFIL";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1266, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 20);
            this.label3.TabIndex = 16;
            this.label3.Text = "FAMILIAS";
            // 
            // btnEliminarFamilia
            // 
            this.btnEliminarFamilia.Location = new System.Drawing.Point(1518, 160);
            this.btnEliminarFamilia.Name = "btnEliminarFamilia";
            this.btnEliminarFamilia.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarFamilia.TabIndex = 15;
            this.btnEliminarFamilia.Text = "BORRAR";
            this.btnEliminarFamilia.UseVisualStyleBackColor = true;
            this.btnEliminarFamilia.Click += new System.EventHandler(this.btnEliminarFamilia_Click);
            // 
            // btnCrearFamilia
            // 
            this.btnCrearFamilia.Location = new System.Drawing.Point(1518, 131);
            this.btnCrearFamilia.Name = "btnCrearFamilia";
            this.btnCrearFamilia.Size = new System.Drawing.Size(75, 23);
            this.btnCrearFamilia.TabIndex = 14;
            this.btnCrearFamilia.Text = "CREAR";
            this.btnCrearFamilia.UseVisualStyleBackColor = true;
            this.btnCrearFamilia.Click += new System.EventHandler(this.btnCrearFamilia_Click);
            // 
            // txtFamiliaNombre
            // 
            this.txtFamiliaNombre.Location = new System.Drawing.Point(1518, 83);
            this.txtFamiliaNombre.Name = "txtFamiliaNombre";
            this.txtFamiliaNombre.Size = new System.Drawing.Size(100, 26);
            this.txtFamiliaNombre.TabIndex = 13;
            // 
            // LstPermisosDisponiblesPerfil
            // 
            this.LstPermisosDisponiblesPerfil.FormattingEnabled = true;
            this.LstPermisosDisponiblesPerfil.ItemHeight = 20;
            this.LstPermisosDisponiblesPerfil.Location = new System.Drawing.Point(499, 269);
            this.LstPermisosDisponiblesPerfil.Name = "LstPermisosDisponiblesPerfil";
            this.LstPermisosDisponiblesPerfil.Size = new System.Drawing.Size(248, 124);
            this.LstPermisosDisponiblesPerfil.TabIndex = 17;
            // 
            // lstPermisosPerfil
            // 
            this.lstPermisosPerfil.FormattingEnabled = true;
            this.lstPermisosPerfil.ItemHeight = 20;
            this.lstPermisosPerfil.Location = new System.Drawing.Point(489, 476);
            this.lstPermisosPerfil.Name = "lstPermisosPerfil";
            this.lstPermisosPerfil.Size = new System.Drawing.Size(248, 124);
            this.lstPermisosPerfil.TabIndex = 18;
            // 
            // LstFamiliasAsignadasPerfil
            // 
            this.LstFamiliasAsignadasPerfil.FormattingEnabled = true;
            this.LstFamiliasAsignadasPerfil.ItemHeight = 20;
            this.LstFamiliasAsignadasPerfil.Location = new System.Drawing.Point(791, 269);
            this.LstFamiliasAsignadasPerfil.Name = "LstFamiliasAsignadasPerfil";
            this.LstFamiliasAsignadasPerfil.Size = new System.Drawing.Size(248, 124);
            this.LstFamiliasAsignadasPerfil.TabIndex = 19;
            // 
            // LstPermisosAsignadosPerfil
            // 
            this.LstPermisosAsignadosPerfil.FormattingEnabled = true;
            this.LstPermisosAsignadosPerfil.ItemHeight = 20;
            this.LstPermisosAsignadosPerfil.Location = new System.Drawing.Point(792, 476);
            this.LstPermisosAsignadosPerfil.Name = "LstPermisosAsignadosPerfil";
            this.LstPermisosAsignadosPerfil.Size = new System.Drawing.Size(248, 124);
            this.LstPermisosAsignadosPerfil.TabIndex = 20;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(580, 399);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(107, 32);
            this.button7.TabIndex = 21;
            this.button7.Text = "ASIGNAR";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(886, 399);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(106, 32);
            this.button8.TabIndex = 22;
            this.button8.Text = "BORRAR";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // btnAgregarUnPermiso
            // 
            this.btnAgregarUnPermiso.Location = new System.Drawing.Point(570, 606);
            this.btnAgregarUnPermiso.Name = "btnAgregarUnPermiso";
            this.btnAgregarUnPermiso.Size = new System.Drawing.Size(100, 35);
            this.btnAgregarUnPermiso.TabIndex = 23;
            this.btnAgregarUnPermiso.Text = "ASIGNAR";
            this.btnAgregarUnPermiso.UseVisualStyleBackColor = true;
            this.btnAgregarUnPermiso.Click += new System.EventHandler(this.btnAgregarUnPermiso_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(876, 621);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(101, 29);
            this.button10.TabIndex = 24;
            this.button10.Text = "BORRAR";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(522, 246);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(196, 20);
            this.label4.TabIndex = 25;
            this.label4.Text = "FAMILIAS DISPONIBLES";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(512, 456);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(206, 20);
            this.label5.TabIndex = 26;
            this.label5.Text = "PERMISOS DISPONIBLES";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(823, 246);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(184, 20);
            this.label6.TabIndex = 27;
            this.label6.Text = "FAMILIAS ASIGNADAS";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(813, 456);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(199, 20);
            this.label7.TabIndex = 28;
            this.label7.Text = "PERMISOS  ASIGNADOS";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1426, 456);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(199, 20);
            this.label8.TabIndex = 40;
            this.label8.Text = "PERMISOS  ASIGNADOS";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1436, 246);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(184, 20);
            this.label9.TabIndex = 39;
            this.label9.Text = "FAMILIAS ASIGNADAS";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1125, 456);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(206, 20);
            this.label10.TabIndex = 38;
            this.label10.Text = "PERMISOS DISPONIBLES";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1135, 246);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(196, 20);
            this.label11.TabIndex = 37;
            this.label11.Text = "FAMILIAS DISPONIBLES";
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(1489, 621);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(101, 29);
            this.button11.TabIndex = 36;
            this.button11.Text = "BORRAR";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(1183, 606);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(100, 35);
            this.button12.TabIndex = 35;
            this.button12.Text = "ASIGNAR";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(1499, 399);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(106, 32);
            this.button13.TabIndex = 34;
            this.button13.Text = "BORRAR";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(1193, 399);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(107, 32);
            this.button14.TabIndex = 33;
            this.button14.Text = "ASIGNAR";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // lstPermisosAsignados
            // 
            this.lstPermisosAsignados.FormattingEnabled = true;
            this.lstPermisosAsignados.ItemHeight = 20;
            this.lstPermisosAsignados.Location = new System.Drawing.Point(1405, 476);
            this.lstPermisosAsignados.Name = "lstPermisosAsignados";
            this.lstPermisosAsignados.Size = new System.Drawing.Size(248, 124);
            this.lstPermisosAsignados.TabIndex = 32;
            // 
            // LstFamiliasAsignadas
            // 
            this.LstFamiliasAsignadas.FormattingEnabled = true;
            this.LstFamiliasAsignadas.ItemHeight = 20;
            this.LstFamiliasAsignadas.Location = new System.Drawing.Point(1404, 269);
            this.LstFamiliasAsignadas.Name = "LstFamiliasAsignadas";
            this.LstFamiliasAsignadas.Size = new System.Drawing.Size(248, 124);
            this.LstFamiliasAsignadas.TabIndex = 31;
            // 
            // lstPermisosDisponibles
            // 
            this.lstPermisosDisponibles.FormattingEnabled = true;
            this.lstPermisosDisponibles.ItemHeight = 20;
            this.lstPermisosDisponibles.Location = new System.Drawing.Point(1102, 476);
            this.lstPermisosDisponibles.Name = "lstPermisosDisponibles";
            this.lstPermisosDisponibles.Size = new System.Drawing.Size(248, 124);
            this.lstPermisosDisponibles.TabIndex = 30;
            // 
            // lstFamiliasDisponibles
            // 
            this.lstFamiliasDisponibles.FormattingEnabled = true;
            this.lstFamiliasDisponibles.ItemHeight = 20;
            this.lstFamiliasDisponibles.Location = new System.Drawing.Point(1112, 269);
            this.lstFamiliasDisponibles.Name = "lstFamiliasDisponibles";
            this.lstFamiliasDisponibles.Size = new System.Drawing.Size(248, 124);
            this.lstFamiliasDisponibles.TabIndex = 29;
            // 
            // dgvPerfiles
            // 
            this.dgvPerfiles.AllowUserToAddRows = false;
            this.dgvPerfiles.AllowUserToDeleteRows = false;
            this.dgvPerfiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPerfiles.Location = new System.Drawing.Point(617, 63);
            this.dgvPerfiles.Name = "dgvPerfiles";
            this.dgvPerfiles.ReadOnly = true;
            this.dgvPerfiles.RowHeadersWidth = 62;
            this.dgvPerfiles.RowTemplate.Height = 28;
            this.dgvPerfiles.Size = new System.Drawing.Size(240, 150);
            this.dgvPerfiles.TabIndex = 41;
            this.dgvPerfiles.SelectionChanged += new System.EventHandler(this.dgvPerfiles_SelectionChanged);
            // 
            // dgvFamilias
            // 
            this.dgvFamilias.AllowUserToAddRows = false;
            this.dgvFamilias.AllowUserToDeleteRows = false;
            this.dgvFamilias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFamilias.Location = new System.Drawing.Point(1183, 73);
            this.dgvFamilias.Name = "dgvFamilias";
            this.dgvFamilias.ReadOnly = true;
            this.dgvFamilias.RowHeadersWidth = 62;
            this.dgvFamilias.RowTemplate.Height = 28;
            this.dgvFamilias.Size = new System.Drawing.Size(240, 150);
            this.dgvFamilias.TabIndex = 42;
            this.dgvFamilias.SelectionChanged += new System.EventHandler(this.dgvFamilias_SelectionChanged);
            // 
            // FormPerfiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1686, 906);
            this.Controls.Add(this.dgvFamilias);
            this.Controls.Add(this.dgvPerfiles);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.button14);
            this.Controls.Add(this.lstPermisosAsignados);
            this.Controls.Add(this.LstFamiliasAsignadas);
            this.Controls.Add(this.lstPermisosDisponibles);
            this.Controls.Add(this.lstFamiliasDisponibles);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.btnAgregarUnPermiso);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.LstPermisosAsignadosPerfil);
            this.Controls.Add(this.LstFamiliasAsignadasPerfil);
            this.Controls.Add(this.lstPermisosPerfil);
            this.Controls.Add(this.LstPermisosDisponiblesPerfil);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnEliminarFamilia);
            this.Controls.Add(this.btnCrearFamilia);
            this.Controls.Add(this.txtFamiliaNombre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnEliminarPerfil);
            this.Controls.Add(this.btnCrearPerfil);
            this.Controls.Add(this.txtPerfilNombre);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbFiltroArbol);
            this.Controls.Add(this.tvArbol);
            this.Controls.Add(this.btnEliminarPermiso);
            this.Controls.Add(this.btnCrearPermiso);
            this.Controls.Add(this.txtPermisoNombre);
            this.Controls.Add(this.dgvPermisos);
            this.Name = "FormPerfiles";
            this.Text = "FormPerfiles";
            this.Load += new System.EventHandler(this.FormPerfiles_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPermisos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPerfiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFamilias)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPermisos;
        private System.Windows.Forms.TextBox txtPermisoNombre;
        private System.Windows.Forms.Button btnCrearPermiso;
        private System.Windows.Forms.Button btnEliminarPermiso;
        private System.Windows.Forms.TreeView tvArbol;
        private System.Windows.Forms.ComboBox cbFiltroArbol;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEliminarPerfil;
        private System.Windows.Forms.Button btnCrearPerfil;
        private System.Windows.Forms.TextBox txtPerfilNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
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
    }
}