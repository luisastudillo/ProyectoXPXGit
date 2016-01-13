namespace AppWinProyectoo
{
    partial class RecepcionMenu
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
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.btnClientes = new System.Windows.Forms.Button();
            this.btnEquipos = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(119, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Menú Recepción";
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Image = global::AppWinProyectoo.Properties.Resources.factura;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(89, 205);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(234, 48);
            this.button3.TabIndex = 7;
            this.button3.Text = "Facturas";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnClientes
            // 
            this.btnClientes.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClientes.Image = global::AppWinProyectoo.Properties.Resources.cliente;
            this.btnClientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClientes.Location = new System.Drawing.Point(89, 137);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(234, 47);
            this.btnClientes.TabIndex = 6;
            this.btnClientes.Text = "Clientes";
            this.btnClientes.UseVisualStyleBackColor = true;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // btnEquipos
            // 
            this.btnEquipos.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEquipos.Image = global::AppWinProyectoo.Properties.Resources.ingreso;
            this.btnEquipos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEquipos.Location = new System.Drawing.Point(89, 71);
            this.btnEquipos.Name = "btnEquipos";
            this.btnEquipos.Size = new System.Drawing.Size(234, 42);
            this.btnEquipos.TabIndex = 5;
            this.btnEquipos.Text = "Equipos";
            this.btnEquipos.UseVisualStyleBackColor = true;
            this.btnEquipos.Click += new System.EventHandler(this.btnEquipos_Click);
            // 
            // RecepcionMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(418, 297);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnClientes);
            this.Controls.Add(this.btnEquipos);
            this.Controls.Add(this.label1);
            this.Name = "RecepcionMenu";
            this.Text = "MenuRecepcion";
            this.Load += new System.EventHandler(this.MenuRecepcion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Button btnEquipos;
        private System.Windows.Forms.Label label1;
    }
}