namespace AppWinProyectoo.Recepcion
{
    partial class RecepcionAgregarEquipo
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
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtModelo = new System.Windows.Forms.TextBox();
            this.txtSerie = new System.Windows.Forms.TextBox();
            this.txtEquipo = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnCancelarEquipo = new System.Windows.Forms.Button();
            this.btnAgregarEquipo = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCancelarFactura = new System.Windows.Forms.Button();
            this.btnAgregarFactura = new System.Windows.Forms.Button();
            this.txtCedFactura = new System.Windows.Forms.TextBox();
            this.dtpFechaFactura = new System.Windows.Forms.DateTimePicker();
            this.txtNFactura = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPequenio = new System.Windows.Forms.Button();
            this.btnGrande = new System.Windows.Forms.Button();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.txtModelo);
            this.panel4.Controls.Add(this.txtSerie);
            this.panel4.Controls.Add(this.txtEquipo);
            this.panel4.Controls.Add(this.label15);
            this.panel4.Controls.Add(this.label14);
            this.panel4.Controls.Add(this.label13);
            this.panel4.Controls.Add(this.label12);
            this.panel4.Location = new System.Drawing.Point(12, 38);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(288, 190);
            this.panel4.TabIndex = 23;
            // 
            // txtModelo
            // 
            this.txtModelo.Location = new System.Drawing.Point(105, 117);
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.Size = new System.Drawing.Size(100, 20);
            this.txtModelo.TabIndex = 18;
            this.txtModelo.TextChanged += new System.EventHandler(this.txtModelo_TextChanged);
            // 
            // txtSerie
            // 
            this.txtSerie.Location = new System.Drawing.Point(105, 72);
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.Size = new System.Drawing.Size(100, 20);
            this.txtSerie.TabIndex = 17;
            // 
            // txtEquipo
            // 
            this.txtEquipo.Location = new System.Drawing.Point(104, 28);
            this.txtEquipo.Name = "txtEquipo";
            this.txtEquipo.Size = new System.Drawing.Size(100, 20);
            this.txtEquipo.TabIndex = 16;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(2, 120);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(59, 17);
            this.label15.TabIndex = 15;
            this.label15.Text = "Modelo:";
            this.label15.Click += new System.EventHandler(this.label15_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(3, 75);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(43, 17);
            this.label14.TabIndex = 14;
            this.label14.Text = "Serie:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(3, 31);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(57, 17);
            this.label13.TabIndex = 13;
            this.label13.Text = "Equipo:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(23, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(92, 17);
            this.label12.TabIndex = 12;
            this.label12.Text = "Datos Equipo";
            // 
            // btnCancelarEquipo
            // 
            this.btnCancelarEquipo.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarEquipo.Location = new System.Drawing.Point(170, 242);
            this.btnCancelarEquipo.Name = "btnCancelarEquipo";
            this.btnCancelarEquipo.Size = new System.Drawing.Size(84, 28);
            this.btnCancelarEquipo.TabIndex = 28;
            this.btnCancelarEquipo.Text = "Cancelar";
            this.btnCancelarEquipo.UseVisualStyleBackColor = true;
            this.btnCancelarEquipo.Click += new System.EventHandler(this.btnCancelarEquipo_Click);
            // 
            // btnAgregarEquipo
            // 
            this.btnAgregarEquipo.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarEquipo.Location = new System.Drawing.Point(348, 243);
            this.btnAgregarEquipo.Name = "btnAgregarEquipo";
            this.btnAgregarEquipo.Size = new System.Drawing.Size(84, 28);
            this.btnAgregarEquipo.TabIndex = 27;
            this.btnAgregarEquipo.Text = "Agregar";
            this.btnAgregarEquipo.UseVisualStyleBackColor = true;
            this.btnAgregarEquipo.Click += new System.EventHandler(this.btnAgregarEquipo_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnCancelarFactura);
            this.panel2.Controls.Add(this.btnAgregarFactura);
            this.panel2.Controls.Add(this.txtCedFactura);
            this.panel2.Controls.Add(this.dtpFechaFactura);
            this.panel2.Controls.Add(this.txtNFactura);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(317, 38);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(311, 190);
            this.panel2.TabIndex = 29;
            // 
            // btnCancelarFactura
            // 
            this.btnCancelarFactura.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarFactura.Location = new System.Drawing.Point(30, 153);
            this.btnCancelarFactura.Name = "btnCancelarFactura";
            this.btnCancelarFactura.Size = new System.Drawing.Size(84, 28);
            this.btnCancelarFactura.TabIndex = 28;
            this.btnCancelarFactura.Text = "Cancelar";
            this.btnCancelarFactura.UseVisualStyleBackColor = true;
            this.btnCancelarFactura.Click += new System.EventHandler(this.btnCancelarFactura_Click);
            // 
            // btnAgregarFactura
            // 
            this.btnAgregarFactura.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarFactura.Location = new System.Drawing.Point(159, 153);
            this.btnAgregarFactura.Name = "btnAgregarFactura";
            this.btnAgregarFactura.Size = new System.Drawing.Size(84, 28);
            this.btnAgregarFactura.TabIndex = 27;
            this.btnAgregarFactura.Text = "Agregar";
            this.btnAgregarFactura.UseVisualStyleBackColor = true;
            this.btnAgregarFactura.Click += new System.EventHandler(this.btnAgregarFactura_Click);
            // 
            // txtCedFactura
            // 
            this.txtCedFactura.Enabled = false;
            this.txtCedFactura.Location = new System.Drawing.Point(105, 120);
            this.txtCedFactura.Name = "txtCedFactura";
            this.txtCedFactura.Size = new System.Drawing.Size(168, 20);
            this.txtCedFactura.TabIndex = 17;
            // 
            // dtpFechaFactura
            // 
            this.dtpFechaFactura.Enabled = false;
            this.dtpFechaFactura.Location = new System.Drawing.Point(105, 75);
            this.dtpFechaFactura.Name = "dtpFechaFactura";
            this.dtpFechaFactura.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaFactura.TabIndex = 16;
            // 
            // txtNFactura
            // 
            this.txtNFactura.Location = new System.Drawing.Point(105, 25);
            this.txtNFactura.Name = "txtNFactura";
            this.txtNFactura.Size = new System.Drawing.Size(168, 20);
            this.txtNFactura.TabIndex = 15;
            this.txtNFactura.TextChanged += new System.EventHandler(this.txtNFactura_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 17);
            this.label6.TabIndex = 14;
            this.label6.Text = "Cédula:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "Fecha:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "N° Factura:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, -4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Datos Factura";
            // 
            // btnPequenio
            // 
            this.btnPequenio.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPequenio.Location = new System.Drawing.Point(559, 9);
            this.btnPequenio.Name = "btnPequenio";
            this.btnPequenio.Size = new System.Drawing.Size(76, 23);
            this.btnPequenio.TabIndex = 67;
            this.btnPequenio.Text = "-";
            this.btnPequenio.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPequenio.UseVisualStyleBackColor = true;
            this.btnPequenio.Click += new System.EventHandler(this.btnPequenio_Click);
            // 
            // btnGrande
            // 
            this.btnGrande.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGrande.Location = new System.Drawing.Point(477, 9);
            this.btnGrande.Name = "btnGrande";
            this.btnGrande.Size = new System.Drawing.Size(76, 23);
            this.btnGrande.TabIndex = 66;
            this.btnGrande.Text = "+";
            this.btnGrande.UseVisualStyleBackColor = true;
            this.btnGrande.Click += new System.EventHandler(this.btnGrande_Click);
            // 
            // RecepcionAgregarEquipo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(642, 286);
            this.Controls.Add(this.btnPequenio);
            this.Controls.Add(this.btnGrande);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnAgregarEquipo);
            this.Controls.Add(this.btnCancelarEquipo);
            this.Controls.Add(this.panel4);
            this.Name = "RecepcionAgregarEquipo";
            this.Text = "RecepcionAgregarEquipo";
            this.Load += new System.EventHandler(this.RecepcionAgregarEquipo_Load);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtModelo;
        private System.Windows.Forms.TextBox txtSerie;
        private System.Windows.Forms.TextBox txtEquipo;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnCancelarEquipo;
        private System.Windows.Forms.Button btnAgregarEquipo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCancelarFactura;
        private System.Windows.Forms.Button btnAgregarFactura;
        private System.Windows.Forms.TextBox txtCedFactura;
        private System.Windows.Forms.DateTimePicker dtpFechaFactura;
        private System.Windows.Forms.TextBox txtNFactura;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPequenio;
        private System.Windows.Forms.Button btnGrande;
    }
}