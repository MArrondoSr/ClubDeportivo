namespace ClubDeportivo
{
    partial class FormRegistroCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRegistroCliente));
            pictureBox1 = new PictureBox();
            label1 = new Label();
            txtNroDocumento = new TextBox();
            txtNombre = new TextBox();
            labelNombre = new Label();
            txtApellido = new TextBox();
            labelApellido = new Label();
            txtDomicilio = new TextBox();
            labelDomicilio = new Label();
            txtTelefono = new TextBox();
            labelTelefono = new Label();
            labelMail = new Label();
            txtMail = new TextBox();
            chkAptoFisico = new CheckBox();
            btnRegistrar = new Button();
            btnLimpiar = new Button();
            btnVolver = new Button();
            cmbTipoDocumento = new ComboBox();
            lblTipo = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(41, 23);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(125, 105);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(265, 48);
            label1.Name = "label1";
            label1.Size = new Size(337, 46);
            label1.TabIndex = 1;
            label1.Text = "Registro de Clientes";
            // 
            // txtNroDocumento
            // 
            txtNroDocumento.Location = new Point(364, 169);
            txtNroDocumento.Name = "txtNroDocumento";
            txtNroDocumento.Size = new Size(278, 27);
            txtNroDocumento.TabIndex = 3;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(364, 218);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(278, 27);
            txtNombre.TabIndex = 5;
            // 
            // labelNombre
            // 
            labelNombre.AutoSize = true;
            labelNombre.Font = new Font("Segoe UI", 12F);
            labelNombre.Location = new Point(98, 218);
            labelNombre.Name = "labelNombre";
            labelNombre.Size = new Size(85, 28);
            labelNombre.TabIndex = 4;
            labelNombre.Text = "Nombre";
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(364, 272);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(278, 27);
            txtApellido.TabIndex = 7;
            // 
            // labelApellido
            // 
            labelApellido.AutoSize = true;
            labelApellido.Font = new Font("Segoe UI", 12F);
            labelApellido.Location = new Point(97, 268);
            labelApellido.Name = "labelApellido";
            labelApellido.Size = new Size(86, 28);
            labelApellido.TabIndex = 6;
            labelApellido.Text = "Apellido";
            // 
            // txtDomicilio
            // 
            txtDomicilio.Location = new Point(364, 327);
            txtDomicilio.Name = "txtDomicilio";
            txtDomicilio.Size = new Size(278, 27);
            txtDomicilio.TabIndex = 9;
            // 
            // labelDomicilio
            // 
            labelDomicilio.AutoSize = true;
            labelDomicilio.Font = new Font("Segoe UI", 12F);
            labelDomicilio.Location = new Point(97, 323);
            labelDomicilio.Name = "labelDomicilio";
            labelDomicilio.Size = new Size(96, 28);
            labelDomicilio.TabIndex = 8;
            labelDomicilio.Text = "Domicilio";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(364, 386);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(278, 27);
            txtTelefono.TabIndex = 13;
            // 
            // labelTelefono
            // 
            labelTelefono.AutoSize = true;
            labelTelefono.Font = new Font("Segoe UI", 12F);
            labelTelefono.Location = new Point(97, 382);
            labelTelefono.Name = "labelTelefono";
            labelTelefono.Size = new Size(86, 28);
            labelTelefono.TabIndex = 12;
            labelTelefono.Text = "Teléfono";
            // 
            // labelMail
            // 
            labelMail.AutoSize = true;
            labelMail.Font = new Font("Segoe UI", 12F);
            labelMail.Location = new Point(97, 446);
            labelMail.Name = "labelMail";
            labelMail.Size = new Size(50, 28);
            labelMail.TabIndex = 10;
            labelMail.Text = "Mail";
            // 
            // txtMail
            // 
            txtMail.Location = new Point(364, 450);
            txtMail.Name = "txtMail";
            txtMail.Size = new Size(278, 27);
            txtMail.TabIndex = 11;
            // 
            // chkAptoFisico
            // 
            chkAptoFisico.AutoSize = true;
            chkAptoFisico.Font = new Font("Segoe UI", 12F);
            chkAptoFisico.Location = new Point(97, 539);
            chkAptoFisico.Name = "chkAptoFisico";
            chkAptoFisico.Size = new Size(213, 32);
            chkAptoFisico.TabIndex = 16;
            chkAptoFisico.Text = "Presentó Apto Físico";
            chkAptoFisico.UseVisualStyleBackColor = true;
            // 
            // btnRegistrar
            // 
            btnRegistrar.BackColor = SystemColors.ActiveCaption;
            btnRegistrar.FlatAppearance.BorderColor = Color.FromArgb(0, 0, 192);
            btnRegistrar.Font = new Font("Segoe UI", 12F);
            btnRegistrar.Location = new Point(480, 539);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(162, 49);
            btnRegistrar.TabIndex = 17;
            btnRegistrar.Text = "Registrar";
            btnRegistrar.UseVisualStyleBackColor = false;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = SystemColors.ActiveCaption;
            btnLimpiar.Font = new Font("Segoe UI", 12F);
            btnLimpiar.Location = new Point(275, 645);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(162, 49);
            btnLimpiar.TabIndex = 19;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnVolver
            // 
            btnVolver.BackColor = SystemColors.ActiveCaption;
            btnVolver.Font = new Font("Segoe UI", 12F);
            btnVolver.Location = new Point(480, 645);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(162, 49);
            btnVolver.TabIndex = 20;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += btnVolver_Click;
            // 
            // cmbTipoDocumento
            // 
            cmbTipoDocumento.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoDocumento.FormattingEnabled = true;
            cmbTipoDocumento.Items.AddRange(new object[] { "DNI", "CUIL", "LC", "LE", "Pasaporte" });
            cmbTipoDocumento.Location = new Point(216, 169);
            cmbTipoDocumento.Name = "cmbTipoDocumento";
            cmbTipoDocumento.Size = new Size(121, 28);
            cmbTipoDocumento.TabIndex = 21;
            // 
            // lblTipo
            // 
            lblTipo.AutoSize = true;
            lblTipo.Font = new Font("Segoe UI", 12F);
            lblTipo.Location = new Point(97, 169);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(100, 28);
            lblTipo.TabIndex = 22;
            lblTipo.Text = "Tipo Doc. ";
            // 
            // FormRegistroCliente
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 753);
            Controls.Add(lblTipo);
            Controls.Add(cmbTipoDocumento);
            Controls.Add(btnVolver);
            Controls.Add(btnLimpiar);
            Controls.Add(btnRegistrar);
            Controls.Add(chkAptoFisico);
            Controls.Add(txtTelefono);
            Controls.Add(labelTelefono);
            Controls.Add(txtMail);
            Controls.Add(labelMail);
            Controls.Add(txtDomicilio);
            Controls.Add(labelDomicilio);
            Controls.Add(txtApellido);
            Controls.Add(labelApellido);
            Controls.Add(txtNombre);
            Controls.Add(labelNombre);
            Controls.Add(txtNroDocumento);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormRegistroCliente";
            Text = "  Registro de Clientes";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private TextBox txtNroDocumento;
        private TextBox txtNombre;
        private Label labelNombre;
        private TextBox txtApellido;
        private Label labelApellido;
        private TextBox txtDomicilio;
        private Label labelDomicilio;
        private TextBox txtTelefono;
        private Label labelTelefono;
        private Label labelMail;
        private TextBox txtMail;
        private CheckBox chkAptoFisico;
        private Button btnRegistrar;
        private Button btnLimpiar;
        private Button btnVolver;
        private ComboBox cmbTipoDocumento;
        private Label lblTipo;
    }
}