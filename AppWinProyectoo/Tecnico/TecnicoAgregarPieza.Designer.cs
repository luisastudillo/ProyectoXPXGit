namespace AppWinProyectoo.Tecnico
{
    partial class TecnicoAgregarPieza
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
            this.dgvTrabajos = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.btnPequenio = new System.Windows.Forms.Button();
            this.btnGrande = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrabajos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTrabajos
            // 
            this.dgvTrabajos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTrabajos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Nombre});
            this.dgvTrabajos.Location = new System.Drawing.Point(24, 49);
            this.dgvTrabajos.Name = "dgvTrabajos";
            this.dgvTrabajos.Size = new System.Drawing.Size(362, 270);
            this.dgvTrabajos.TabIndex = 24;
            // 
            // Codigo
            // 
            this.Codigo.Frozen = true;
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            // 
            // Nombre
            // 
            this.Nombre.Frozen = true;
            this.Nombre.HeaderText = "Descripcion";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 230;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Image = global::AppWinProyectoo.Properties.Resources.aceptar;
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.Location = new System.Drawing.Point(50, 324);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(130, 38);
            this.btnAgregar.TabIndex = 23;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnRegresar
            // 
            this.btnRegresar.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegresar.Image = global::AppWinProyectoo.Properties.Resources.regresar;
            this.btnRegresar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRegresar.Location = new System.Drawing.Point(221, 325);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(130, 38);
            this.btnRegresar.TabIndex = 22;
            this.btnRegresar.Text = "Regresar";
            this.btnRegresar.UseVisualStyleBackColor = true;
            // 
            // btnPequenio
            // 
            this.btnPequenio.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPequenio.Location = new System.Drawing.Point(329, 12);
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
            this.btnGrande.Location = new System.Drawing.Point(247, 12);
            this.btnGrande.Name = "btnGrande";
            this.btnGrande.Size = new System.Drawing.Size(76, 23);
            this.btnGrande.TabIndex = 66;
            this.btnGrande.Text = "+";
            this.btnGrande.UseVisualStyleBackColor = true;
            this.btnGrande.Click += new System.EventHandler(this.btnGrande_Click);
            // 
            // TecnicoAgregarPieza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(410, 374);
            this.Controls.Add(this.btnPequenio);
            this.Controls.Add(this.btnGrande);
            this.Controls.Add(this.dgvTrabajos);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnRegresar);
            this.Name = "TecnicoAgregarPieza";
            this.Text = "TecnicoAgregarPieza";
            this.Load += new System.EventHandler(this.TecnicoAgregarPieza_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrabajos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTrabajos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.Button btnPequenio;
        private System.Windows.Forms.Button btnGrande;
    }
}