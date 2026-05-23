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
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonSeguridad = new System.Windows.Forms.Button();
            this.buttonOperaciones = new System.Windows.Forms.Button();
            this.buttonEntidades = new System.Windows.Forms.Button();
            this.buttonReportes = new System.Windows.Forms.Button();
            this.buttonSalir = new System.Windows.Forms.Button();
            this.buttonAyuda = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkRed;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonAyuda);
            this.panel1.Controls.Add(this.buttonSalir);
            this.panel1.Controls.Add(this.buttonReportes);
            this.panel1.Controls.Add(this.buttonEntidades);
            this.panel1.Controls.Add(this.buttonOperaciones);
            this.panel1.Controls.Add(this.buttonSeguridad);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(341, 814);
            this.panel1.TabIndex = 1;
            // 
            // buttonSeguridad
            // 
            this.buttonSeguridad.Location = new System.Drawing.Point(71, 307);
            this.buttonSeguridad.Name = "buttonSeguridad";
            this.buttonSeguridad.Size = new System.Drawing.Size(202, 68);
            this.buttonSeguridad.TabIndex = 0;
            this.buttonSeguridad.Text = "Seguridad";
            this.buttonSeguridad.UseVisualStyleBackColor = true;
            // 
            // buttonOperaciones
            // 
            this.buttonOperaciones.Location = new System.Drawing.Point(71, 136);
            this.buttonOperaciones.Name = "buttonOperaciones";
            this.buttonOperaciones.Size = new System.Drawing.Size(202, 68);
            this.buttonOperaciones.TabIndex = 1;
            this.buttonOperaciones.Text = "Operaciones";
            this.buttonOperaciones.UseVisualStyleBackColor = true;
            // 
            // buttonEntidades
            // 
            this.buttonEntidades.Location = new System.Drawing.Point(71, 222);
            this.buttonEntidades.Name = "buttonEntidades";
            this.buttonEntidades.Size = new System.Drawing.Size(202, 68);
            this.buttonEntidades.TabIndex = 2;
            this.buttonEntidades.Text = "Entidades";
            this.buttonEntidades.UseVisualStyleBackColor = true;
            // 
            // buttonReportes
            // 
            this.buttonReportes.Location = new System.Drawing.Point(71, 390);
            this.buttonReportes.Name = "buttonReportes";
            this.buttonReportes.Size = new System.Drawing.Size(202, 68);
            this.buttonReportes.TabIndex = 4;
            this.buttonReportes.Text = "Reportes";
            this.buttonReportes.UseVisualStyleBackColor = true;
            // 
            // buttonSalir
            // 
            this.buttonSalir.Location = new System.Drawing.Point(71, 688);
            this.buttonSalir.Name = "buttonSalir";
            this.buttonSalir.Size = new System.Drawing.Size(202, 68);
            this.buttonSalir.TabIndex = 5;
            this.buttonSalir.Text = "Salir";
            this.buttonSalir.UseVisualStyleBackColor = true;
            // 
            // buttonAyuda
            // 
            this.buttonAyuda.Location = new System.Drawing.Point(71, 479);
            this.buttonAyuda.Name = "buttonAyuda";
            this.buttonAyuda.Size = new System.Drawing.Size(202, 68);
            this.buttonAyuda.TabIndex = 6;
            this.buttonAyuda.Text = "Ayuda";
            this.buttonAyuda.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(116, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Bienvenido!";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1212, 525);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(361, 289);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1573, 814);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.IsMdiContainer = true;
            this.Name = "FormMain";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonSalir;
        private System.Windows.Forms.Button buttonReportes;
        private System.Windows.Forms.Button buttonEntidades;
        private System.Windows.Forms.Button buttonOperaciones;
        private System.Windows.Forms.Button buttonSeguridad;
        private System.Windows.Forms.Button buttonAyuda;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

