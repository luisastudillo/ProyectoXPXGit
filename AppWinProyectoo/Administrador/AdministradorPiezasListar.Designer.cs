namespace AppWinProyectoo
{
    partial class AdministradorPiezasListar
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rbtTipo = new System.Windows.Forms.RadioButton();
            this.rbtModelo = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnListar = new System.Windows.Forms.Button();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.dgvPiezas = new System.Windows.Forms.DataGridView();
            this.Cedula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apellidos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Domicilio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnPequenio = new System.Windows.Forms.Button();
            this.btnGrande = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPiezas)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnBuscar);
            this.panel2.Controls.Add(this.txtBuscar);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.rbtTipo);
            this.panel2.Controls.Add(this.rbtModelo);
            this.panel2.Location = new System.Drawing.Point(360, 377);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(310, 122);
            this.panel2.TabIndex = 25;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.btnBuscar.Location = new System.Drawing.Point(112, 90);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 8;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(40, 60);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(219, 20);
            this.txtBuscar.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.label1.Location = new System.Drawing.Point(109, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Buscar por:";
            // 
            // rbtTipo
            // 
            this.rbtTipo.AutoSize = true;
            this.rbtTipo.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtTipo.Location = new System.Drawing.Point(182, 33);
            this.rbtTipo.Name = "rbtTipo";
            this.rbtTipo.Size = new System.Drawing.Size(55, 21);
            this.rbtTipo.TabIndex = 4;
            this.rbtTipo.TabStop = true;
            this.rbtTipo.Text = "Tipo";
            this.rbtTipo.UseVisualStyleBackColor = true;
            // 
            // rbtModelo
            // 
            this.rbtModelo.AutoSize = true;
            this.rbtModelo.Checked = true;
            this.rbtModelo.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtModelo.Location = new System.Drawing.Point(40, 33);
            this.rbtModelo.Name = "rbtModelo";
            this.rbtModelo.Size = new System.Drawing.Size(73, 21);
            this.rbtModelo.TabIndex = 0;
            this.rbtModelo.TabStop = true;
            this.rbtModelo.Text = "Modelo";
            this.rbtModelo.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SkyBlue;
            this.panel1.Controls.Add(this.btnImprimir);
            this.panel1.Controls.Add(this.btnListar);
            this.panel1.Controls.Add(this.btnRegresar);
            this.panel1.Location = new System.Drawing.Point(32, 377);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(290, 122);
            this.panel1.TabIndex = 24;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.Image = global::AppWinProyectoo.Properties.Resources.imprimir;
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimir.Location = new System.Drawing.Point(149, 13);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(130, 38);
            this.btnImprimir.TabIndex = 18;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            // 
            // btnListar
            // 
            this.btnListar.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListar.Image = global::AppWinProyectoo.Properties.Resources.ordenar;
            this.btnListar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnListar.Location = new System.Drawing.Point(13, 12);
            this.btnListar.Name = "btnListar";
            this.btnListar.Size = new System.Drawing.Size(130, 38);
            this.btnListar.TabIndex = 12;
            this.btnListar.Text = "Listar";
            this.btnListar.UseVisualStyleBackColor = true;
            this.btnListar.Click += new System.EventHandler(this.btnListar_Click);
            // 
            // btnRegresar
            // 
            this.btnRegresar.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegresar.Image = global::AppWinProyectoo.Properties.Resources.regresar;
            this.btnRegresar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRegresar.Location = new System.Drawing.Point(74, 60);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(130, 38);
            this.btnRegresar.TabIndex = 11;
            this.btnRegresar.Text = "Regresar";
            this.btnRegresar.UseVisualStyleBackColor = true;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // dgvPiezas
            // 
            this.dgvPiezas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPiezas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Cedula,
            this.Nombres,
            this.Apellidos,
            this.Domicilio,
            this.Telefono,
            this.Tipo});
            this.dgvPiezas.Location = new System.Drawing.Point(10, 40);
            this.dgvPiezas.Name = "dgvPiezas";
            this.dgvPiezas.Size = new System.Drawing.Size(676, 314);
            this.dgvPiezas.TabIndex = 23;
            // 
            // Cedula
            // 
            this.Cedula.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Cedula.Frozen = true;
            this.Cedula.HeaderText = "Codigo";
            this.Cedula.Name = "Cedula";
            this.Cedula.ReadOnly = true;
            this.Cedula.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Cedula.Width = 80;
            // 
            // Nombres
            // 
            this.Nombres.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Nombres.Frozen = true;
            this.Nombres.HeaderText = "Modelo";
            this.Nombres.Name = "Nombres";
            this.Nombres.ReadOnly = true;
            this.Nombres.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Nombres.Width = 120;
            // 
            // Apellidos
            // 
            this.Apellidos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Apellidos.Frozen = true;
            this.Apellidos.HeaderText = "Tipo";
            this.Apellidos.Name = "Apellidos";
            this.Apellidos.ReadOnly = true;
            this.Apellidos.Width = 130;
            // 
            // Domicilio
            // 
            this.Domicilio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Domicilio.Frozen = true;
            this.Domicilio.HeaderText = "Costo";
            this.Domicilio.Name = "Domicilio";
            this.Domicilio.ReadOnly = true;
            // 
            // Telefono
            // 
            this.Telefono.Frozen = true;
            this.Telefono.HeaderText = "Cantidad";
            this.Telefono.Name = "Telefono";
            this.Telefono.ReadOnly = true;
            // 
            // Tipo
            // 
            this.Tipo.Frozen = true;
            this.Tipo.HeaderText = "Baja";
            this.Tipo.Name = "Tipo";
            this.Tipo.ReadOnly = true;
            // 
            // btnPequenio
            // 
            this.btnPequenio.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPequenio.Location = new System.Drawing.Point(613, 11);
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
            this.btnGrande.Location = new System.Drawing.Point(531, 11);
            this.btnGrande.Name = "btnGrande";
            this.btnGrande.Size = new System.Drawing.Size(76, 23);
            this.btnGrande.TabIndex = 66;
            this.btnGrande.Text = "+";
            this.btnGrande.UseVisualStyleBackColor = true;
            this.btnGrande.Click += new System.EventHandler(this.btnGrande_Click);
            // 
            // AdministradorPiezasListar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(701, 508);
            this.Controls.Add(this.btnPequenio);
            this.Controls.Add(this.btnGrande);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvPiezas);
            this.Name = "AdministradorPiezasListar";
            this.Text = "Lista de Piezas";
            this.Load += new System.EventHandler(this.AdministradorPiezasListar_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPiezas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbtTipo;
        private System.Windows.Forms.RadioButton rbtModelo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnListar;
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.DataGridView dgvPiezas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cedula;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombres;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apellidos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Domicilio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.Button btnPequenio;
        private System.Windows.Forms.Button btnGrande;
    }
}