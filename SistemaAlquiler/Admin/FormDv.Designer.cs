namespace SistemaAlquiler.Admin
{
    partial class FormDv
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
            this.lstDetalles = new System.Windows.Forms.ListBox();
            this.btnRecalcular = new System.Windows.Forms.Button();
            this.btnRestore = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstDetalles
            // 
            this.lstDetalles.FormattingEnabled = true;
            this.lstDetalles.Location = new System.Drawing.Point(25, 36);
            this.lstDetalles.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lstDetalles.Name = "lstDetalles";
            this.lstDetalles.Size = new System.Drawing.Size(146, 212);
            this.lstDetalles.TabIndex = 0;
            // 
            // btnRecalcular
            // 
            this.btnRecalcular.Location = new System.Drawing.Point(181, 117);
            this.btnRecalcular.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRecalcular.Name = "btnRecalcular";
            this.btnRecalcular.Size = new System.Drawing.Size(107, 41);
            this.btnRecalcular.TabIndex = 1;
            this.btnRecalcular.Text = "RECALCULAR";
            this.btnRecalcular.UseVisualStyleBackColor = true;
            this.btnRecalcular.Click += new System.EventHandler(this.btnRecalcular_Click);
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(181, 162);
            this.btnRestore.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(107, 41);
            this.btnRestore.TabIndex = 2;
            this.btnRestore.Text = "RESTORE";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(181, 207);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(107, 41);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "CANCELAR";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.ForeColorChanged += new System.EventHandler(this.btnSalir_Click);
            // 
            // FormDv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 292);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.btnRecalcular);
            this.Controls.Add(this.lstDetalles);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormDv";
            this.Text = "FormDv";
            this.Load += new System.EventHandler(this.FormDv_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstDetalles;
        private System.Windows.Forms.Button btnRecalcular;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Button btnSalir;
    }
}