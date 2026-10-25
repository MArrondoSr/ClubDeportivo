namespace ClubDeportivo
{
    partial class FormListarClientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormListarClientes));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            pictureBox1 = new PictureBox();
            listarClientes = new Label();
            dataGridView1 = new DataGridView();
            tipoDocumento = new DataGridViewTextBoxColumn();
            NroDocumento = new DataGridViewTextBoxColumn();
            nombre = new DataGridViewTextBoxColumn();
            apellido = new DataGridViewTextBoxColumn();
            domicilio = new DataGridViewTextBoxColumn();
            telefono = new DataGridViewTextBoxColumn();
            mail = new DataGridViewTextBoxColumn();
            aptoFisico = new DataGridViewTextBoxColumn();
            btnVolver = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(125, 105);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // listarClientes
            // 
            listarClientes.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            listarClientes.Location = new Point(270, 58);
            listarClientes.Name = "listarClientes";
            listarClientes.Size = new Size(331, 46);
            listarClientes.TabIndex = 2;
            listarClientes.Text = "Listado de Clientes";
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.FromArgb(120, 125, 179);
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { tipoDocumento, NroDocumento, nombre, apellido, domicilio, telefono, mail, aptoFisico });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.Location = new Point(12, 163);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(776, 350);
            dataGridView1.TabIndex = 3;
            // 
            // tipoDocumento
            // 
            tipoDocumento.DataPropertyName = "tipoDocumento";
            tipoDocumento.HeaderText = "Tipo Doc.";
            tipoDocumento.MinimumWidth = 6;
            tipoDocumento.Name = "tipoDocumento";
            // 
            // NroDocumento
            // 
            NroDocumento.DataPropertyName = "nroDocumento";
            NroDocumento.HeaderText = "Nro. Documento";
            NroDocumento.MinimumWidth = 6;
            NroDocumento.Name = "NroDocumento";
            // 
            // nombre
            // 
            nombre.HeaderText = "Nombre";
            nombre.MinimumWidth = 6;
            nombre.Name = "nombre";
            // 
            // apellido
            // 
            apellido.HeaderText = "Apellido";
            apellido.MinimumWidth = 6;
            apellido.Name = "apellido";
            // 
            // domicilio
            // 
            domicilio.HeaderText = "Domicilio";
            domicilio.MinimumWidth = 6;
            domicilio.Name = "domicilio";
            // 
            // telefono
            // 
            telefono.HeaderText = "Telefono";
            telefono.MinimumWidth = 6;
            telefono.Name = "telefono";
            // 
            // mail
            // 
            mail.HeaderText = "Correo";
            mail.MinimumWidth = 6;
            mail.Name = "mail";
            // 
            // aptoFisico
            // 
            aptoFisico.HeaderText = "AptoFisico";
            aptoFisico.MinimumWidth = 6;
            aptoFisico.Name = "aptoFisico";
            // 
            // btnVolver
            // 
            btnVolver.BackColor = SystemColors.ActiveCaption;
            btnVolver.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnVolver.Location = new Point(614, 558);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(135, 60);
            btnVolver.TabIndex = 7;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += btnVolver_Click;
            // 
            // FormListarClientes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 653);
            Controls.Add(btnVolver);
            Controls.Add(dataGridView1);
            Controls.Add(listarClientes);
            Controls.Add(pictureBox1);
            Name = "FormListarClientes";
            Text = "FormListarClientes";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Label listarClientes;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn tipoDocumento;
        private DataGridViewTextBoxColumn NroDocumento;
        private DataGridViewTextBoxColumn nombre;
        private DataGridViewTextBoxColumn apellido;
        private DataGridViewTextBoxColumn domicilio;
        private DataGridViewTextBoxColumn telefono;
        private DataGridViewTextBoxColumn mail;
        private DataGridViewTextBoxColumn aptoFisico;
        private Button btnVolver;
    }
}