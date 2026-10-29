namespace ClubDeportivo
{
    partial class FormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            pictureBox1 = new PictureBox();
            labelUsuario = new Label();
            labelPassword = new Label();
            textUsuario = new TextBox();
            textPassword = new TextBox();
            btnIngresar = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(35, 41);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(236, 158);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // labelUsuario
            // 
            labelUsuario.AutoSize = true;
            labelUsuario.Font = new Font("Segoe UI", 12F);
            labelUsuario.Location = new Point(326, 41);
            labelUsuario.Name = "labelUsuario";
            labelUsuario.Size = new Size(79, 28);
            labelUsuario.TabIndex = 1;
            labelUsuario.Text = "Usuario";
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Font = new Font("Segoe UI", 12F);
            labelPassword.Location = new Point(327, 112);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(110, 28);
            labelPassword.TabIndex = 2;
            labelPassword.Text = "Contraseña";
            // 
            // textUsuario
            // 
            textUsuario.Location = new Point(464, 45);
            textUsuario.Name = "textUsuario";
            textUsuario.Size = new Size(226, 27);
            textUsuario.TabIndex = 3;
            // 
            // textPassword
            // 
            textPassword.Location = new Point(464, 116);
            textPassword.Name = "textPassword";
            textPassword.Size = new Size(226, 27);
            textPassword.TabIndex = 4;
            textPassword.UseSystemPasswordChar = true;
            // 
            // btnIngresar
            // 
            btnIngresar.BackColor = SystemColors.ButtonShadow;
            btnIngresar.Font = new Font("Segoe UI", 12F);
            btnIngresar.Location = new Point(489, 177);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(167, 42);
            btnIngresar.TabIndex = 5;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = false;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(732, 253);
            Controls.Add(btnIngresar);
            Controls.Add(textPassword);
            Controls.Add(textUsuario);
            Controls.Add(labelPassword);
            Controls.Add(labelUsuario);
            Controls.Add(pictureBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Club Deportivo - Ingreso";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label labelUsuario;
        private Label labelPassword;
        private TextBox textUsuario;
        private TextBox textPassword;
        private Button btnIngresar;
    }
}