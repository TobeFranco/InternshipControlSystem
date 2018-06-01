namespace InternshipControlSystem.Front_End
{
    partial class Principal_Administrator
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCatalogosAlumnos = new System.Windows.Forms.Button();
            this.btnSolicitud = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnCatalogosAlumnos);
            this.panel1.Controls.Add(this.btnSolicitud);
            this.panel1.Location = new System.Drawing.Point(-2, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(156, 661);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(18, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 31);
            this.label1.TabIndex = 5;
            this.label1.Text = "Menu";
            // 
            // btnCatalogosAlumnos
            // 
            this.btnCatalogosAlumnos.FlatAppearance.BorderSize = 0;
            this.btnCatalogosAlumnos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCatalogosAlumnos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnCatalogosAlumnos.ForeColor = System.Drawing.Color.White;
            this.btnCatalogosAlumnos.Location = new System.Drawing.Point(14, 206);
            this.btnCatalogosAlumnos.Name = "btnCatalogosAlumnos";
            this.btnCatalogosAlumnos.Size = new System.Drawing.Size(173, 87);
            this.btnCatalogosAlumnos.TabIndex = 2;
            this.btnCatalogosAlumnos.Text = "CATALOGO DE ALUMNOS";
            this.btnCatalogosAlumnos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCatalogosAlumnos.UseVisualStyleBackColor = true;
            this.btnCatalogosAlumnos.Click += new System.EventHandler(this.btnCatalogosAlumnos_Click);
            // 
            // btnSolicitud
            // 
            this.btnSolicitud.FlatAppearance.BorderSize = 0;
            this.btnSolicitud.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSolicitud.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnSolicitud.ForeColor = System.Drawing.Color.White;
            this.btnSolicitud.Location = new System.Drawing.Point(14, 91);
            this.btnSolicitud.Name = "btnSolicitud";
            this.btnSolicitud.Size = new System.Drawing.Size(173, 77);
            this.btnSolicitud.TabIndex = 0;
            this.btnSolicitud.Text = "SOLICITUD";
            this.btnSolicitud.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSolicitud.UseVisualStyleBackColor = true;
            this.btnSolicitud.Click += new System.EventHandler(this.btnSolicitud_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::InternshipControlSystem.Properties.Resources.cerrar;
            this.pictureBox2.Location = new System.Drawing.Point(1074, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(23, 21);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 19;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::InternshipControlSystem.Properties.Resources.minimizar;
            this.pictureBox1.Location = new System.Drawing.Point(1045, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(23, 21);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Principal_Administrator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1109, 464);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Name = "Principal_Administrator";
            this.Text = "PrincipalAssessor";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCatalogosAlumnos;
        private System.Windows.Forms.Button btnSolicitud;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}