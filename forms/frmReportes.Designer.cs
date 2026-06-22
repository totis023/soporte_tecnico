namespace soporte_tecnico.forms
{
    partial class frmReportes
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
            btnPendientes = new Button();
            btnEnProceso = new Button();
            btnResueltos = new Button();
            btnTodos = new Button();
            dgvSeguimiento = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvSeguimiento).BeginInit();
            SuspendLayout();
            // 
            // btnPendientes
            // 
            btnPendientes.BackColor = Color.LightCyan;
            btnPendientes.Cursor = Cursors.Hand;
            btnPendientes.FlatAppearance.BorderSize = 0;
            btnPendientes.FlatStyle = FlatStyle.Flat;
            btnPendientes.Location = new Point(290, 16);
            btnPendientes.Margin = new Padding(2, 1, 2, 1);
            btnPendientes.Name = "btnPendientes";
            btnPendientes.Size = new Size(81, 22);
            btnPendientes.TabIndex = 0;
            btnPendientes.Text = "Pendientes";
            btnPendientes.UseVisualStyleBackColor = false;
            btnPendientes.Click += btnPendientes_Click;
            btnPendientes.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            // 
            // btnEnProceso
            // 
            btnEnProceso.BackColor = Color.LightCyan;
            btnEnProceso.Cursor = Cursors.Hand;
            btnEnProceso.FlatAppearance.BorderSize = 0;
            btnEnProceso.FlatStyle = FlatStyle.Flat;
            btnEnProceso.Location = new Point(120, 16);
            btnEnProceso.Margin = new Padding(2, 1, 2, 1);
            btnEnProceso.Name = "btnEnProceso";
            btnEnProceso.Size = new Size(81, 22);
            btnEnProceso.TabIndex = 1;
            btnEnProceso.Text = "En Proceso";
            btnEnProceso.UseVisualStyleBackColor = false;
            btnEnProceso.Click += btnEnProceso_Click;
            btnEnProceso.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            // 
            // btnResueltos
            // 
            btnResueltos.BackColor = Color.LightCyan;
            btnResueltos.Cursor = Cursors.Hand;
            btnResueltos.FlatAppearance.BorderSize = 0;
            btnResueltos.FlatStyle = FlatStyle.Flat;
            btnResueltos.Location = new Point(205, 16);
            btnResueltos.Margin = new Padding(2, 1, 2, 1);
            btnResueltos.Name = "btnResueltos";
            btnResueltos.Size = new Size(81, 22);
            btnResueltos.TabIndex = 2;
            btnResueltos.Text = "Resueltos";
            btnResueltos.UseVisualStyleBackColor = false;
            btnResueltos.Click += btnResueltos_Click;
            btnResueltos.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            // 
            // btnTodos
            // 
            btnTodos.BackColor = Color.LightCyan;
            btnTodos.Cursor = Cursors.Hand;
            btnTodos.FlatAppearance.BorderSize = 0;
            btnTodos.FlatStyle = FlatStyle.Flat;
            btnTodos.Location = new Point(35, 16);
            btnTodos.Margin = new Padding(2, 1, 2, 1);
            btnTodos.Name = "btnTodos";
            btnTodos.Size = new Size(81, 22);
            btnTodos.TabIndex = 3;
            btnTodos.Text = "Todos";
            btnTodos.UseVisualStyleBackColor = false;
            btnTodos.Click += btnTodos_Click;
            btnTodos.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            // 
            // dgvSeguimiento
            // 
            dgvSeguimiento.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSeguimiento.Location = new Point(35, 40);
            dgvSeguimiento.Margin = new Padding(2, 1, 2, 1);
            dgvSeguimiento.Name = "dgvSeguimiento";
            dgvSeguimiento.RowHeadersWidth = 82;
            dgvSeguimiento.Size = new Size(725, 270);
            dgvSeguimiento.TabIndex = 4;
            dgvSeguimiento.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            // 
            // frmReportes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(803, 359);
            Controls.Add(dgvSeguimiento);
            Controls.Add(btnTodos);
            Controls.Add(btnResueltos);
            Controls.Add(btnEnProceso);
            Controls.Add(btnPendientes);
            Margin = new Padding(2, 1, 2, 1);
            Name = "frmReportes";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmReportes";
            ((System.ComponentModel.ISupportInitialize)dgvSeguimiento).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnPendientes;
        private Button btnEnProceso;
        private Button btnResueltos;
        private Button btnTodos;
        private DataGridView dgvSeguimiento;
    }
}