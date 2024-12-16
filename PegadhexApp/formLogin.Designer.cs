namespace PegadhexApp
{
    partial class formLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formLogin));
            this.UsuarioLabel = new System.Windows.Forms.Label();
            this.ContrasenaLabel = new System.Windows.Forms.Label();
            this.Usuario = new System.Windows.Forms.TextBox();
            this.Contrasena = new System.Windows.Forms.TextBox();
            this.sesion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UsuarioLabel
            // 
            this.UsuarioLabel.AutoSize = true;
            this.UsuarioLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsuarioLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.UsuarioLabel.Location = new System.Drawing.Point(600, 89);
            this.UsuarioLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.UsuarioLabel.MaximumSize = new System.Drawing.Size(120, 120);
            this.UsuarioLabel.Name = "UsuarioLabel";
            this.UsuarioLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.UsuarioLabel.Size = new System.Drawing.Size(86, 27);
            this.UsuarioLabel.TabIndex = 4;
            this.UsuarioLabel.Text = "Usuario";
            // 
            // ContrasenaLabel
            // 
            this.ContrasenaLabel.AutoSize = true;
            this.ContrasenaLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContrasenaLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ContrasenaLabel.Location = new System.Drawing.Point(576, 157);
            this.ContrasenaLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ContrasenaLabel.Name = "ContrasenaLabel";
            this.ContrasenaLabel.Size = new System.Drawing.Size(121, 27);
            this.ContrasenaLabel.TabIndex = 1;
            this.ContrasenaLabel.Text = "Contraseña";
            // 
            // Usuario
            // 
            this.Usuario.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Usuario.Location = new System.Drawing.Point(546, 119);
            this.Usuario.Name = "Usuario";
            this.Usuario.Size = new System.Drawing.Size(178, 35);
            this.Usuario.TabIndex = 2;
            // 
            // Contrasena
            // 
            this.Contrasena.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Contrasena.Location = new System.Drawing.Point(546, 187);
            this.Contrasena.Name = "Contrasena";
            this.Contrasena.PasswordChar = '*';
            this.Contrasena.Size = new System.Drawing.Size(178, 35);
            this.Contrasena.TabIndex = 3;
            // 
            // sesion
            // 
            this.sesion.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.sesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sesion.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sesion.Location = new System.Drawing.Point(546, 230);
            this.sesion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.sesion.Name = "sesion";
            this.sesion.Size = new System.Drawing.Size(180, 48);
            this.sesion.TabIndex = 4;
            this.sesion.Text = "Sesión";
            this.sesion.UseVisualStyleBackColor = false;
            this.sesion.Click += new System.EventHandler(this.sesion_Click);
            // 
            // formLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.sesion);
            this.Controls.Add(this.Contrasena);
            this.Controls.Add(this.Usuario);
            this.Controls.Add(this.ContrasenaLabel);
            this.Controls.Add(this.UsuarioLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "formLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formulario Login";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.formLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label UsuarioLabel;
        private System.Windows.Forms.Label ContrasenaLabel;
        private System.Windows.Forms.TextBox Usuario;
        private System.Windows.Forms.TextBox Contrasena;
        private System.Windows.Forms.Button sesion;
    }
}