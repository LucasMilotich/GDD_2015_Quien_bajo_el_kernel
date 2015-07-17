namespace PagoElectronico.Login
{
    partial class CambiarPassword
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
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtPasswordNueva2 = new System.Windows.Forms.TextBox();
            this.txtPasswordActual = new System.Windows.Forms.TextBox();
            this.lblPwNuevaRepetir = new System.Windows.Forms.Label();
            this.lblPwVieja = new System.Windows.Forms.Label();
            this.txtPasswordNueva1 = new System.Windows.Forms.TextBox();
            this.lblPwNueva = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(94, 172);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 9;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtPasswordNueva2
            // 
            this.txtPasswordNueva2.Location = new System.Drawing.Point(63, 135);
            this.txtPasswordNueva2.Name = "txtPasswordNueva2";
            this.txtPasswordNueva2.PasswordChar = '*';
            this.txtPasswordNueva2.Size = new System.Drawing.Size(147, 20);
            this.txtPasswordNueva2.TabIndex = 3;
            // 
            // txtPasswordActual
            // 
            this.txtPasswordActual.Location = new System.Drawing.Point(63, 51);
            this.txtPasswordActual.Name = "txtPasswordActual";
            this.txtPasswordActual.Size = new System.Drawing.Size(147, 20);
            this.txtPasswordActual.TabIndex = 1;
            // 
            // lblPwNuevaRepetir
            // 
            this.lblPwNuevaRepetir.AutoSize = true;
            this.lblPwNuevaRepetir.Location = new System.Drawing.Point(60, 119);
            this.lblPwNuevaRepetir.Name = "lblPwNuevaRepetir";
            this.lblPwNuevaRepetir.Size = new System.Drawing.Size(97, 13);
            this.lblPwNuevaRepetir.TabIndex = 6;
            this.lblPwNuevaRepetir.Text = "Repetir contraseña";
            // 
            // lblPwVieja
            // 
            this.lblPwVieja.AutoSize = true;
            this.lblPwVieja.Location = new System.Drawing.Point(60, 35);
            this.lblPwVieja.Name = "lblPwVieja";
            this.lblPwVieja.Size = new System.Drawing.Size(93, 13);
            this.lblPwVieja.TabIndex = 5;
            this.lblPwVieja.Text = "Contraseña actual";
            // 
            // txtPasswordNueva1
            // 
            this.txtPasswordNueva1.Location = new System.Drawing.Point(63, 96);
            this.txtPasswordNueva1.Name = "txtPasswordNueva1";
            this.txtPasswordNueva1.Size = new System.Drawing.Size(147, 20);
            this.txtPasswordNueva1.TabIndex = 2;
            // 
            // lblPwNueva
            // 
            this.lblPwNueva.AutoSize = true;
            this.lblPwNueva.Location = new System.Drawing.Point(60, 80);
            this.lblPwNueva.Name = "lblPwNueva";
            this.lblPwNueva.Size = new System.Drawing.Size(95, 13);
            this.lblPwNueva.TabIndex = 10;
            this.lblPwNueva.Text = "Nueva contraseña";
            // 
            // CambiarPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.txtPasswordNueva1);
            this.Controls.Add(this.lblPwNueva);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtPasswordNueva2);
            this.Controls.Add(this.txtPasswordActual);
            this.Controls.Add(this.lblPwNuevaRepetir);
            this.Controls.Add(this.lblPwVieja);
            this.Name = "CambiarPassword";
            this.Text = "CambiarPassword";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox txtPasswordNueva2;
        private System.Windows.Forms.TextBox txtPasswordActual;
        private System.Windows.Forms.Label lblPwNuevaRepetir;
        private System.Windows.Forms.Label lblPwVieja;
        private System.Windows.Forms.TextBox txtPasswordNueva1;
        private System.Windows.Forms.Label lblPwNueva;
    }
}