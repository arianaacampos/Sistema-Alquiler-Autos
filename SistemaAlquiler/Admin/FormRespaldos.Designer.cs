namespace SistemaAlquiler.Admin
{
    partial class FormRespaldos
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
            this.txtRutaRestore = new System.Windows.Forms.TextBox();
            this.txtRutaBackup = new System.Windows.Forms.TextBox();
            this.btnExaminarRestore = new System.Windows.Forms.Button();
            this.btnEjecutarRestore = new System.Windows.Forms.Button();
            this.btnExaminarBackup = new System.Windows.Forms.Button();
            this.btnGenerarBackup = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtRutaRestore
            // 
            this.txtRutaRestore.Location = new System.Drawing.Point(52, 92);
            this.txtRutaRestore.Multiline = true;
            this.txtRutaRestore.Name = "txtRutaRestore";
            this.txtRutaRestore.Size = new System.Drawing.Size(240, 61);
            this.txtRutaRestore.TabIndex = 1;
            // 
            // txtRutaBackup
            // 
            this.txtRutaBackup.Location = new System.Drawing.Point(52, 266);
            this.txtRutaBackup.Multiline = true;
            this.txtRutaBackup.Name = "txtRutaBackup";
            this.txtRutaBackup.Size = new System.Drawing.Size(240, 61);
            this.txtRutaBackup.TabIndex = 2;
            // 
            // btnExaminarRestore
            // 
            this.btnExaminarRestore.Location = new System.Drawing.Point(52, 160);
            this.btnExaminarRestore.Name = "btnExaminarRestore";
            this.btnExaminarRestore.Size = new System.Drawing.Size(105, 43);
            this.btnExaminarRestore.TabIndex = 3;
            this.btnExaminarRestore.Text = "EXAMINAR";
            this.btnExaminarRestore.UseVisualStyleBackColor = true;
            this.btnExaminarRestore.Click += new System.EventHandler(this.btnExaminarRestore_Click);
            // 
            // btnEjecutarRestore
            // 
            this.btnEjecutarRestore.Location = new System.Drawing.Point(187, 160);
            this.btnEjecutarRestore.Name = "btnEjecutarRestore";
            this.btnEjecutarRestore.Size = new System.Drawing.Size(105, 43);
            this.btnEjecutarRestore.TabIndex = 4;
            this.btnEjecutarRestore.Text = "RESTORE";
            this.btnEjecutarRestore.UseVisualStyleBackColor = true;
            this.btnEjecutarRestore.Click += new System.EventHandler(this.btnEjecutarRestore_Click);
            // 
            // btnExaminarBackup
            // 
            this.btnExaminarBackup.Location = new System.Drawing.Point(52, 334);
            this.btnExaminarBackup.Name = "btnExaminarBackup";
            this.btnExaminarBackup.Size = new System.Drawing.Size(105, 43);
            this.btnExaminarBackup.TabIndex = 5;
            this.btnExaminarBackup.Text = "EXAMINAR";
            this.btnExaminarBackup.UseVisualStyleBackColor = true;
            this.btnExaminarBackup.Click += new System.EventHandler(this.btnExaminarBackup_Click);
            // 
            // btnGenerarBackup
            // 
            this.btnGenerarBackup.Location = new System.Drawing.Point(187, 334);
            this.btnGenerarBackup.Name = "btnGenerarBackup";
            this.btnGenerarBackup.Size = new System.Drawing.Size(105, 43);
            this.btnGenerarBackup.TabIndex = 6;
            this.btnGenerarBackup.Text = "BACKUP";
            this.btnGenerarBackup.UseVisualStyleBackColor = true;
            this.btnGenerarBackup.Click += new System.EventHandler(this.btnGenerarBackup_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "RESTORE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 243);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "BACKUP";
            // 
            // FormRespaldos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 431);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGenerarBackup);
            this.Controls.Add(this.btnExaminarBackup);
            this.Controls.Add(this.btnEjecutarRestore);
            this.Controls.Add(this.btnExaminarRestore);
            this.Controls.Add(this.txtRutaBackup);
            this.Controls.Add(this.txtRutaRestore);
            this.Name = "FormRespaldos";
            this.Text = "FormRespaldos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRutaRestore;
        private System.Windows.Forms.TextBox txtRutaBackup;
        private System.Windows.Forms.Button btnExaminarRestore;
        private System.Windows.Forms.Button btnEjecutarRestore;
        private System.Windows.Forms.Button btnExaminarBackup;
        private System.Windows.Forms.Button btnGenerarBackup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}