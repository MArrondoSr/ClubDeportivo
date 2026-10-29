namespace ClubDeportivo
{
    partial class FormVencimientos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormVencimientos));
            pictureBox1 = new PictureBox();
            label1 = new Label();
            dtpFechaConsulta = new DateTimePicker();
            label2 = new Label();
            btnConsultar = new Button();
            dgvVencimientos = new DataGridView();
            btnVolver = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvVencimientos).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(45, 30);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(137, 137);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(188, 121);
            label1.Name = "label1";
            label1.Size = new Size(582, 46);
            label1.TabIndex = 1;
            label1.Text = "Formulario de Vencimientos Diario";
            // 
            // dtpFechaConsulta
            // 
            dtpFechaConsulta.Format = DateTimePickerFormat.Short;
            dtpFechaConsulta.Location = new Point(235, 208);
            dtpFechaConsulta.Name = "dtpFechaConsulta";
            dtpFechaConsulta.Size = new Size(174, 27);
            dtpFechaConsulta.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(45, 208);
            label2.Name = "label2";
            label2.Size = new Size(174, 28);
            label2.TabIndex = 3;
            label2.Text = "Fecha de Consulta:\r\n";
            // 
            // btnConsultar
            // 
            btnConsultar.BackColor = SystemColors.ActiveCaption;
            btnConsultar.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnConsultar.Location = new Point(464, 201);
            btnConsultar.Name = "btnConsultar";
            btnConsultar.Size = new Size(149, 38);
            btnConsultar.TabIndex = 4;
            btnConsultar.Text = "Consultar";
            btnConsultar.UseVisualStyleBackColor = false;
            btnConsultar.Click += btnConsultar_Click;
            // 
            // dgvVencimientos
            // 
            dgvVencimientos.AllowUserToAddRows = false;
            dgvVencimientos.AllowUserToDeleteRows = false;
            dgvVencimientos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVencimientos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVencimientos.Location = new Point(45, 277);
            dgvVencimientos.MultiSelect = false;
            dgvVencimientos.Name = "dgvVencimientos";
            dgvVencimientos.ReadOnly = true;
            dgvVencimientos.RowHeadersWidth = 51;
            dgvVencimientos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVencimientos.Size = new Size(711, 273);
            dgvVencimientos.TabIndex = 5;
            // 
            // btnVolver
            // 
            btnVolver.BackColor = SystemColors.ActiveCaption;
            btnVolver.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnVolver.Location = new Point(621, 581);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(135, 60);
            btnVolver.TabIndex = 6;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += btnVolver_Click;
            // 
            // FormVencimientos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 653);
            Controls.Add(btnVolver);
            Controls.Add(dgvVencimientos);
            Controls.Add(btnConsultar);
            Controls.Add(label2);
            Controls.Add(dtpFechaConsulta);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FormVencimientos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Vencimientos de Cuotas";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvVencimientos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private DateTimePicker dtpFechaConsulta;
        private Label label2;
        private Button btnConsultar;
        private DataGridView dgvVencimientos;
        private Button btnVolver;
    }
}