namespace ClubDeportivo
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btnRegistrarCliente = new Button();
            pictureBox1 = new PictureBox();
            menuPrincipal = new Label();
            btnCobrosCarnet = new Button();
            btnVtos = new Button();
            btnCerrar = new Button();
            btnListarClientes = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnRegistrarCliente
            // 
            btnRegistrarCliente.BackColor = SystemColors.ActiveCaption;
            btnRegistrarCliente.Font = new Font("Segoe UI", 12F);
            btnRegistrarCliente.Location = new Point(254, 193);
            btnRegistrarCliente.Name = "btnRegistrarCliente";
            btnRegistrarCliente.Size = new Size(182, 65);
            btnRegistrarCliente.TabIndex = 1;
            btnRegistrarCliente.Text = "Registrar Cliente";
            btnRegistrarCliente.UseVisualStyleBackColor = false;
            btnRegistrarCliente.Click += btnRegistrarCliente_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(56, 40);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(131, 121);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // menuPrincipal
            // 
            menuPrincipal.AutoSize = true;
            menuPrincipal.Font = new Font("Segoe UI", 25.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            menuPrincipal.Location = new Point(294, 74);
            menuPrincipal.Name = "menuPrincipal";
            menuPrincipal.Size = new Size(322, 57);
            menuPrincipal.TabIndex = 3;
            menuPrincipal.Text = "Menú Principal";
            // 
            // btnCobrosCarnet
            // 
            btnCobrosCarnet.BackColor = SystemColors.ActiveCaption;
            btnCobrosCarnet.Font = new Font("Segoe UI", 12F);
            btnCobrosCarnet.Location = new Point(254, 353);
            btnCobrosCarnet.Name = "btnCobrosCarnet";
            btnCobrosCarnet.Size = new Size(182, 65);
            btnCobrosCarnet.TabIndex = 4;
            btnCobrosCarnet.Text = "Cobros y Carnet";
            btnCobrosCarnet.UseVisualStyleBackColor = false;
            btnCobrosCarnet.Click += btnCobrosCarnet_Click;
            // 
            // btnVtos
            // 
            btnVtos.BackColor = SystemColors.ActiveCaption;
            btnVtos.Font = new Font("Segoe UI", 12F);
            btnVtos.Location = new Point(254, 437);
            btnVtos.Name = "btnVtos";
            btnVtos.Size = new Size(182, 65);
            btnVtos.TabIndex = 6;
            btnVtos.Text = "Vencimientos";
            btnVtos.UseVisualStyleBackColor = false;
            // 
            // btnCerrar
            // 
            btnCerrar.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCerrar.Location = new Point(521, 517);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(136, 56);
            btnCerrar.TabIndex = 7;
            btnCerrar.Text = "Cerrar Sesión";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrarSesion_Click;
            // 
            // btnListarClientes
            // 
            btnListarClientes.BackColor = SystemColors.ActiveCaption;
            btnListarClientes.Font = new Font("Segoe UI", 12F);
            btnListarClientes.Location = new Point(254, 273);
            btnListarClientes.Name = "btnListarClientes";
            btnListarClientes.Size = new Size(182, 65);
            btnListarClientes.TabIndex = 5;
            btnListarClientes.Text = "Listar Clientes";
            btnListarClientes.UseVisualStyleBackColor = false;
            btnListarClientes.Click += btnListarClientes_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(694, 608);
            Controls.Add(btnListarClientes);
            Controls.Add(btnCerrar);
            Controls.Add(btnVtos);
            Controls.Add(btnCobrosCarnet);
            Controls.Add(menuPrincipal);
            Controls.Add(pictureBox1);
            Controls.Add(btnRegistrarCliente);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnRegistrarCliente;
        private PictureBox pictureBox1;
        private Label menuPrincipal;
        private Button btnCobrosCarnet;
        private Button btnListarClientes;
        private Button btnVtos;
        private Button btnCerrar;
        
    }
}
