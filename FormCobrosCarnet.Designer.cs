namespace ClubDeportivo
{
    partial class FormCobrosCarnet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCobrosCarnet));
            pictureBox1 = new PictureBox();
            lblCobroscarnet = new Label();
            lblDni = new Label();
            txtNroDocumento = new TextBox();
            btnBuscar = new Button();
            lblNombre = new Label();
            lblApellido = new Label();
            lblEstado = new Label();
            btnEmitirCarnet = new Button();
            lblImporte = new Label();
            txtImporte = new TextBox();
            lblMedioPago = new Label();
            cmbMedioPago = new ComboBox();
            lblCuotas = new Label();
            cmbCuotas = new ComboBox();
            btnRegistrarPago = new Button();
            btnLimpiar = new Button();
            btnVolver = new Button();
            cmbTipoDocumento = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(53, 45);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(125, 118);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // lblCobroscarnet
            // 
            lblCobroscarnet.AutoSize = true;
            lblCobroscarnet.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblCobroscarnet.Location = new Point(296, 73);
            lblCobroscarnet.Name = "lblCobroscarnet";
            lblCobroscarnet.Size = new Size(274, 46);
            lblCobroscarnet.TabIndex = 1;
            lblCobroscarnet.Text = "Cobros y Carnet";
            // 
            // lblDni
            // 
            lblDni.AutoSize = true;
            lblDni.Font = new Font("Segoe UI", 12F);
            lblDni.Location = new Point(53, 233);
            lblDni.Name = "lblDni";
            lblDni.Size = new Size(95, 28);
            lblDni.TabIndex = 2;
            lblDni.Text = "Tipo Doc.";
            // 
            // txtNroDocumento
            // 
            txtNroDocumento.Location = new Point(274, 233);
            txtNroDocumento.Name = "txtNroDocumento";
            txtNroDocumento.Size = new Size(226, 27);
            txtNroDocumento.TabIndex = 3;
            txtNroDocumento.TextChanged += txtNroDocumento_TextChanged;
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = SystemColors.ActiveCaption;
            btnBuscar.Font = new Font("Segoe UI", 12F);
            btnBuscar.Location = new Point(522, 216);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(162, 49);
            btnBuscar.TabIndex = 4;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNombre.ForeColor = SystemColors.Highlight;
            lblNombre.Location = new Point(80, 296);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(0, 28);
            lblNombre.TabIndex = 5;
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblApellido.ForeColor = SystemColors.Highlight;
            lblApellido.Location = new Point(276, 296);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(0, 28);
            lblApellido.TabIndex = 6;
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEstado.ForeColor = SystemColors.Highlight;
            lblEstado.Location = new Point(457, 296);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(0, 28);
            lblEstado.TabIndex = 7;
            // 
            // btnEmitirCarnet
            // 
            btnEmitirCarnet.BackColor = SystemColors.ActiveCaption;
            btnEmitirCarnet.Font = new Font("Segoe UI", 12F);
            btnEmitirCarnet.Location = new Point(526, 356);
            btnEmitirCarnet.Name = "btnEmitirCarnet";
            btnEmitirCarnet.Size = new Size(162, 49);
            btnEmitirCarnet.TabIndex = 8;
            btnEmitirCarnet.Text = "Emitir Carnet";
            btnEmitirCarnet.UseVisualStyleBackColor = false;
            btnEmitirCarnet.Click += btnEmitirCarnet_Click;
            // 
            // lblImporte
            // 
            lblImporte.AutoSize = true;
            lblImporte.Font = new Font("Segoe UI", 12F);
            lblImporte.Location = new Point(53, 441);
            lblImporte.Name = "lblImporte";
            lblImporte.Size = new Size(82, 28);
            lblImporte.TabIndex = 9;
            lblImporte.Text = "Importe";
            // 
            // txtImporte
            // 
            txtImporte.Location = new Point(274, 441);
            txtImporte.Name = "txtImporte";
            txtImporte.Size = new Size(231, 27);
            txtImporte.TabIndex = 10;
            // 
            // lblMedioPago
            // 
            lblMedioPago.AutoSize = true;
            lblMedioPago.Font = new Font("Segoe UI", 12F);
            lblMedioPago.Location = new Point(53, 498);
            lblMedioPago.Name = "lblMedioPago";
            lblMedioPago.Size = new Size(145, 28);
            lblMedioPago.TabIndex = 11;
            lblMedioPago.Text = "Medio de Pago";
            // 
            // cmbMedioPago
            // 
            cmbMedioPago.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMedioPago.FormattingEnabled = true;
            cmbMedioPago.Items.AddRange(new object[] { "Efectivo", "Tarjeta" });
            cmbMedioPago.Location = new Point(276, 502);
            cmbMedioPago.Name = "cmbMedioPago";
            cmbMedioPago.Size = new Size(229, 28);
            cmbMedioPago.TabIndex = 12;
            cmbMedioPago.SelectedIndexChanged += cmbMedioPago_SelectedIndexChanged;
            // 
            // lblCuotas
            // 
            lblCuotas.AutoSize = true;
            lblCuotas.Font = new Font("Segoe UI", 12F);
            lblCuotas.Location = new Point(53, 557);
            lblCuotas.Name = "lblCuotas";
            lblCuotas.Size = new Size(72, 28);
            lblCuotas.TabIndex = 13;
            lblCuotas.Text = "Cuotas";
            // 
            // cmbCuotas
            // 
            cmbCuotas.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCuotas.FormattingEnabled = true;
            cmbCuotas.Items.AddRange(new object[] { "3", "6" });
            cmbCuotas.Location = new Point(274, 557);
            cmbCuotas.Name = "cmbCuotas";
            cmbCuotas.Size = new Size(61, 28);
            cmbCuotas.TabIndex = 14;
            // 
            // btnRegistrarPago
            // 
            btnRegistrarPago.BackColor = SystemColors.ActiveCaption;
            btnRegistrarPago.Font = new Font("Segoe UI", 12F);
            btnRegistrarPago.Location = new Point(526, 547);
            btnRegistrarPago.Name = "btnRegistrarPago";
            btnRegistrarPago.Size = new Size(162, 49);
            btnRegistrarPago.TabIndex = 15;
            btnRegistrarPago.Text = "Registrar Pago";
            btnRegistrarPago.UseVisualStyleBackColor = false;
            btnRegistrarPago.Click += btnRegistrarPago_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = SystemColors.ActiveCaption;
            btnLimpiar.Font = new Font("Segoe UI", 12F);
            btnLimpiar.Location = new Point(53, 633);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(162, 49);
            btnLimpiar.TabIndex = 16;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnVolver
            // 
            btnVolver.BackColor = SystemColors.ActiveCaption;
            btnVolver.Font = new Font("Segoe UI", 12F);
            btnVolver.Location = new Point(526, 637);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(162, 49);
            btnVolver.TabIndex = 17;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += btnVolver_Click;
            // 
            // cmbTipoDocumento
            // 
            cmbTipoDocumento.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoDocumento.FormattingEnabled = true;
            cmbTipoDocumento.Items.AddRange(new object[] { "DNI", "CUIL", "LC", "LE", "Pasaporte" });
            cmbTipoDocumento.Location = new Point(154, 232);
            cmbTipoDocumento.Name = "cmbTipoDocumento";
            cmbTipoDocumento.Size = new Size(114, 28);
            cmbTipoDocumento.TabIndex = 18;
            cmbTipoDocumento.SelectedIndexChanged += cmbTipoDocumento_SelectedIndexChanged;
            // 
            // FormCobrosCarnet
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 703);
            Controls.Add(cmbTipoDocumento);
            Controls.Add(btnVolver);
            Controls.Add(btnLimpiar);
            Controls.Add(btnRegistrarPago);
            Controls.Add(cmbCuotas);
            Controls.Add(lblCuotas);
            Controls.Add(cmbMedioPago);
            Controls.Add(lblMedioPago);
            Controls.Add(txtImporte);
            Controls.Add(lblImporte);
            Controls.Add(btnEmitirCarnet);
            Controls.Add(lblEstado);
            Controls.Add(lblApellido);
            Controls.Add(lblNombre);
            Controls.Add(btnBuscar);
            Controls.Add(txtNroDocumento);
            Controls.Add(lblDni);
            Controls.Add(lblCobroscarnet);
            Controls.Add(pictureBox1);
            Name = "FormCobrosCarnet";
            Text = "Cobros y Carnet";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label lblCobroscarnet;
        private Label lblDni;
        private TextBox txtNroDocumento;
        private Button btnBuscar;
        private Label lblNombre;
        private Label lblApellido;
        private Label lblEstado;
        private Button btnEmitirCarnet;
        private Label lblImporte;
        private TextBox txtImporte;
        private Label lblMedioPago;
        private ComboBox cmbMedioPago;
        private Label lblCuotas;
        private ComboBox cmbCuotas;
        private Button btnRegistrarPago;
        private Button btnLimpiar;
        private Button btnVolver;
        private ComboBox cmbTipoDocumento;
    }
}