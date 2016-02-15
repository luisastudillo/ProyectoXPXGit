namespace AppWinProyectoo.Tecnico
{
    partial class TecnicoMenu
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
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btrEntregar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Image = global::AppWinProyectoo.Properties.Resources.ingreso1;
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.Location = new System.Drawing.Point(30, 39);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(234, 38);
            this.btnAceptar.TabIndex = 7;
            this.btnAceptar.Text = "Aceptar Equipo";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnIngreso_Click);
            // 
            // btrEntregar
            // 
            this.btrEntregar.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btrEntregar.Image = global::AppWinProyectoo.Properties.Resources.retiro;
            this.btrEntregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btrEntregar.Location = new System.Drawing.Point(30, 109);
            this.btrEntregar.Name = "btrEntregar";
            this.btrEntregar.Size = new System.Drawing.Size(234, 44);
            this.btrEntregar.TabIndex = 8;
            this.btrEntregar.Text = "Entregar Equipo";
            this.btrEntregar.UseVisualStyleBackColor = true;
            this.btrEntregar.Click += new System.EventHandler(this.btrEntregar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.Image = global::AppWinProyectoo.Properties.Resources.trabajo;
            this.btnModificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModificar.Location = new System.Drawing.Point(30, 187);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(234, 48);
            this.btnModificar.TabIndex = 13;
            this.btnModificar.Text = "Modificar Diagnóstico";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // TecnicoMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(301, 276);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btrEntregar);
            this.Controls.Add(this.btnAceptar);
            this.Name = "TecnicoMenu";
            this.Text = "TecnicoMenu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btrEntregar;
        private System.Windows.Forms.Button btnModificar;
    }
}