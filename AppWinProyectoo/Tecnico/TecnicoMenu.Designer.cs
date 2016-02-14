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
            this.btnIngreso = new System.Windows.Forms.Button();
            this.btnRetiro = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnIngreso
            // 
            this.btnIngreso.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngreso.Image = global::AppWinProyectoo.Properties.Resources.ingreso1;
            this.btnIngreso.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIngreso.Location = new System.Drawing.Point(30, 39);
            this.btnIngreso.Name = "btnIngreso";
            this.btnIngreso.Size = new System.Drawing.Size(234, 38);
            this.btnIngreso.TabIndex = 7;
            this.btnIngreso.Text = "Aceptar Equipo";
            this.btnIngreso.UseVisualStyleBackColor = true;
            // 
            // btnRetiro
            // 
            this.btnRetiro.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetiro.Image = global::AppWinProyectoo.Properties.Resources.retiro;
            this.btnRetiro.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRetiro.Location = new System.Drawing.Point(30, 109);
            this.btnRetiro.Name = "btnRetiro";
            this.btnRetiro.Size = new System.Drawing.Size(234, 44);
            this.btnRetiro.TabIndex = 8;
            this.btnRetiro.Text = "Entregar Equipo";
            this.btnRetiro.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::AppWinProyectoo.Properties.Resources.trabajo;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(30, 187);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(234, 48);
            this.button1.TabIndex = 13;
            this.button1.Text = "Modificar Diagnóstico";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // TecnicoMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(301, 276);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnRetiro);
            this.Controls.Add(this.btnIngreso);
            this.Name = "TecnicoMenu";
            this.Text = "TecnicoMenu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnIngreso;
        private System.Windows.Forms.Button btnRetiro;
        private System.Windows.Forms.Button button1;
    }
}