namespace ClubDeportivo
{
    partial class FormCarnet
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCarnet));
            lblTitulo = new Label();
            lblTipoDoc = new Label();
            cmbTipoDocumento = new ComboBox();
            txtNroDocumento = new TextBox();
            btnBuscar = new Button();
            btnEmitirCarnet = new Button();
            lblNombre = new Label();
            lblApellido = new Label();
            lblEstado = new Label();
            panelCarnet = new Panel();
            panelVencimiento = new Panel();
            lblCarnetVencimiento = new Label();
            lblSubtituloCarnet = new Label();
            pictureBox1 = new PictureBox();
            lblCarnetTitulo = new Label();
            lblCarnetNombre = new Label();
            lblCarnetApellido = new Label();
            lblCarnetNroSocio = new Label();
            picLogoClub = new PictureBox();
            btnImprimir = new Button();
            printDocument1 = new System.Drawing.Printing.PrintDocument();
            printDialog1 = new PrintDialog();
            pictureBox2 = new PictureBox();
            panelCarnet.SuspendLayout();
            panelVencimiento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picLogoClub).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold | FontStyle.Italic);
            lblTitulo.Location = new Point(232, 57);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(268, 41);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "Gestión de Carnet";
            // 
            // lblTipoDoc
            // 
            lblTipoDoc.AutoSize = true;
            lblTipoDoc.Font = new Font("Segoe UI", 12F);
            lblTipoDoc.Location = new Point(36, 152);
            lblTipoDoc.Name = "lblTipoDoc";
            lblTipoDoc.Size = new Size(95, 28);
            lblTipoDoc.TabIndex = 2;
            lblTipoDoc.Text = "Tipo Doc.";
            // 
            // cmbTipoDocumento
            // 
            cmbTipoDocumento.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoDocumento.FormattingEnabled = true;
            cmbTipoDocumento.Items.AddRange(new object[] { "DNI", "CUIL", "LC", "LE", "Pasaporte" });
            cmbTipoDocumento.Location = new Point(135, 152);
            cmbTipoDocumento.Name = "cmbTipoDocumento";
            cmbTipoDocumento.Size = new Size(107, 28);
            cmbTipoDocumento.TabIndex = 3;
            cmbTipoDocumento.SelectedIndexChanged += cmbTipoDocumento_SelectedIndexChanged;
            // 
            // txtNroDocumento
            // 
            txtNroDocumento.Location = new Point(279, 152);
            txtNroDocumento.Name = "txtNroDocumento";
            txtNroDocumento.Size = new Size(160, 27);
            txtNroDocumento.TabIndex = 4;
            txtNroDocumento.TextChanged += txtNroDocumento_TextChanged;
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = SystemColors.ActiveCaption;
            btnBuscar.Font = new Font("Segoe UI", 12F);
            btnBuscar.Location = new Point(468, 148);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(107, 38);
            btnBuscar.TabIndex = 5;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btnEmitirCarnet
            // 
            btnEmitirCarnet.BackColor = SystemColors.ActiveCaption;
            btnEmitirCarnet.Font = new Font("Segoe UI", 12F);
            btnEmitirCarnet.Location = new Point(589, 517);
            btnEmitirCarnet.Name = "btnEmitirCarnet";
            btnEmitirCarnet.Size = new Size(107, 38);
            btnEmitirCarnet.TabIndex = 6;
            btnEmitirCarnet.Text = "Generar Carnet";
            btnEmitirCarnet.UseVisualStyleBackColor = false;
            btnEmitirCarnet.Visible = false;
            btnEmitirCarnet.Click += btnEmitirCarnet_Click;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblNombre.ForeColor = SystemColors.Highlight;
            lblNombre.Location = new Point(44, 210);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(0, 28);
            lblNombre.TabIndex = 7;
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblApellido.ForeColor = SystemColors.Highlight;
            lblApellido.Location = new Point(178, 210);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(0, 28);
            lblApellido.TabIndex = 8;
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblEstado.ForeColor = SystemColors.Highlight;
            lblEstado.Location = new Point(356, 210);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(0, 28);
            lblEstado.TabIndex = 9;
            // 
            // panelCarnet
            // 
            panelCarnet.BackColor = Color.White;
            panelCarnet.BorderStyle = BorderStyle.FixedSingle;
            panelCarnet.Controls.Add(panelVencimiento);
            panelCarnet.Controls.Add(lblSubtituloCarnet);
            panelCarnet.Controls.Add(pictureBox1);
            panelCarnet.Controls.Add(lblCarnetTitulo);
            panelCarnet.Controls.Add(lblCarnetNombre);
            panelCarnet.Controls.Add(lblCarnetApellido);
            panelCarnet.Controls.Add(lblCarnetNroSocio);
            panelCarnet.Controls.Add(picLogoClub);
            panelCarnet.Location = new Point(53, 257);
            panelCarnet.Name = "panelCarnet";
            panelCarnet.Size = new Size(500, 314);
            panelCarnet.TabIndex = 10;
            panelCarnet.Visible = false;
            // 
            // panelVencimiento
            // 
            panelVencimiento.BackColor = Color.Lavender;
            panelVencimiento.Controls.Add(lblCarnetVencimiento);
            panelVencimiento.Location = new Point(10, 245);
            panelVencimiento.Name = "panelVencimiento";
            panelVencimiento.Size = new Size(478, 55);
            panelVencimiento.TabIndex = 15;
            // 
            // lblCarnetVencimiento
            // 
            lblCarnetVencimiento.AutoSize = true;
            lblCarnetVencimiento.BackColor = Color.Transparent;
            lblCarnetVencimiento.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCarnetVencimiento.ForeColor = Color.MidnightBlue;
            lblCarnetVencimiento.Location = new Point(15, 15);
            lblCarnetVencimiento.Name = "lblCarnetVencimiento";
            lblCarnetVencimiento.Size = new Size(169, 25);
            lblCarnetVencimiento.TabIndex = 5;
            lblCarnetVencimiento.Text = "Vence: 22/02/2027";
            // 
            // lblSubtituloCarnet
            // 
            lblSubtituloCarnet.AutoSize = true;
            lblSubtituloCarnet.BackColor = Color.Transparent;
            lblSubtituloCarnet.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSubtituloCarnet.ForeColor = SystemColors.GrayText;
            lblSubtituloCarnet.Location = new Point(115, 48);
            lblSubtituloCarnet.Name = "lblSubtituloCarnet";
            lblSubtituloCarnet.Size = new Size(134, 20);
            lblSubtituloCarnet.TabIndex = 14;
            lblSubtituloCarnet.Text = "CARNET DE SOCIO";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(15, 10);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(85, 68);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 13;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // lblCarnetTitulo
            // 
            lblCarnetTitulo.AutoSize = true;
            lblCarnetTitulo.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCarnetTitulo.ForeColor = SystemColors.HotTrack;
            lblCarnetTitulo.Location = new Point(115, 20);
            lblCarnetTitulo.Name = "lblCarnetTitulo";
            lblCarnetTitulo.Size = new Size(179, 28);
            lblCarnetTitulo.TabIndex = 0;
            lblCarnetTitulo.Text = "CLUB DEPORTIVO";
            lblCarnetTitulo.Click += lblCarnetTitulo_Click;
            // 
            // lblCarnetNombre
            // 
            lblCarnetNombre.AutoSize = true;
            lblCarnetNombre.Font = new Font("Segoe UI", 11F);
            lblCarnetNombre.Location = new Point(140, 98);
            lblCarnetNombre.Name = "lblCarnetNombre";
            lblCarnetNombre.Size = new Size(170, 25);
            lblCarnetNombre.TabIndex = 1;
            lblCarnetNombre.Text = "Nombre y Apellido";
            // 
            // lblCarnetApellido
            // 
            lblCarnetApellido.AutoSize = true;
            lblCarnetApellido.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblCarnetApellido.Location = new Point(140, 135);
            lblCarnetApellido.Name = "lblCarnetApellido";
            lblCarnetApellido.Size = new Size(239, 35);
            lblCarnetApellido.TabIndex = 2;
            lblCarnetApellido.Text = "Nombre y Apellido";
            lblCarnetApellido.Click += lblCarnetApellido_Click;
            // 
            // lblCarnetNroSocio
            // 
            lblCarnetNroSocio.AutoSize = true;
            lblCarnetNroSocio.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCarnetNroSocio.ForeColor = Color.DarkRed;
            lblCarnetNroSocio.Location = new Point(151, 177);
            lblCarnetNroSocio.Name = "lblCarnetNroSocio";
            lblCarnetNroSocio.Size = new Size(105, 23);
            lblCarnetNroSocio.TabIndex = 3;
            lblCarnetNroSocio.Text = "Nro Socio: -";
            lblCarnetNroSocio.Click += lblCarnetNroSocio_Click;
            // 
            // picLogoClub
            // 
            picLogoClub.Image = (Image)resources.GetObject("picLogoClub.Image");
            picLogoClub.Location = new Point(13, 98);
            picLogoClub.Name = "picLogoClub";
            picLogoClub.Size = new Size(107, 114);
            picLogoClub.SizeMode = PictureBoxSizeMode.Zoom;
            picLogoClub.TabIndex = 5;
            picLogoClub.TabStop = false;
            // 
            // btnImprimir
            // 
            btnImprimir.BackColor = Color.LightGreen;
            btnImprimir.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnImprimir.Location = new Point(589, 460);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(107, 38);
            btnImprimir.TabIndex = 11;
            btnImprimir.Text = "Imprimir / PDF";
            btnImprimir.UseVisualStyleBackColor = false;
            btnImprimir.Visible = false;
            btnImprimir.Click += btnImprimir_Click;
            // 
            // printDocument1
            // 
            printDocument1.PrintPage += printDocument1_PrintPage;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(15, 10);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(125, 118);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 12;
            pictureBox2.TabStop = false;
            // 
            // FormCarnet
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(739, 589);
            Controls.Add(pictureBox2);
            Controls.Add(btnImprimir);
            Controls.Add(panelCarnet);
            Controls.Add(lblEstado);
            Controls.Add(lblApellido);
            Controls.Add(lblNombre);
            Controls.Add(btnEmitirCarnet);
            Controls.Add(btnBuscar);
            Controls.Add(txtNroDocumento);
            Controls.Add(cmbTipoDocumento);
            Controls.Add(lblTipoDoc);
            Controls.Add(lblTitulo);
            Name = "FormCarnet";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Carnet";
            Load += FormCarnet_Load;
            panelCarnet.ResumeLayout(false);
            panelCarnet.PerformLayout();
            panelVencimiento.ResumeLayout(false);
            panelVencimiento.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)picLogoClub).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblTitulo;
        private Label lblTipoDoc;
        private ComboBox cmbTipoDocumento;
        private TextBox txtNroDocumento;
        private Button btnBuscar;
        private Button btnEmitirCarnet;
        private Label lblNombre;
        private Label lblApellido;
        private Label lblEstado;
        private Panel panelCarnet;
        private Label lblCarnetTitulo;
        private Label lblCarnetNombre;
        private Label lblCarnetApellido;
        private Label lblCarnetNroSocio;
        private PictureBox picLogoClub;
        private Button btnImprimir;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private PrintDialog printDialog1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Label lblSubtituloCarnet;
        private Panel panelVencimiento;
        private Label lblCarnetVencimiento;
    }
}