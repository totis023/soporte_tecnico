namespace soporte_tecnico
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private Button btnClientes;
        private Button btnTecnicos;
        private Button btnSeguimiento;
        private Button btnReportes;
        private Label label1;

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
            btnClientes = new Button();
            btnTecnicos = new Button();
            btnSeguimiento = new Button();
            btnReportes = new Button();
            label1 = new Label();
            btnPedidos = new Button();
            SuspendLayout();
            // 
            // btnClientes
            // 
            btnClientes.Location = new Point(289, 75);
            btnClientes.Margin = new Padding(3, 2, 3, 2);
            btnClientes.Name = "btnClientes";
            btnClientes.Size = new Size(122, 38);
            btnClientes.TabIndex = 0;
            btnClientes.Text = "Clientes";
            btnClientes.UseVisualStyleBackColor = false;
            btnClientes.BackColor = Color.LightBlue;
            btnClientes.FlatStyle = FlatStyle.Flat;
            btnClientes.FlatAppearance.BorderSize = 0;
            btnClientes.Anchor = AnchorStyles.Top;
            btnClientes.Cursor = Cursors.Hand;
            btnClientes.Click += btnClientes_Click;
            // 
            // btnTecnicos
            // 
            btnTecnicos.Location = new Point(289, 117);
            btnTecnicos.Margin = new Padding(3, 2, 3, 2);
            btnTecnicos.Name = "btnTecnicos";
            btnTecnicos.Size = new Size(122, 38);
            btnTecnicos.TabIndex = 1;
            btnTecnicos.Text = "Técnicos";
            btnTecnicos.UseVisualStyleBackColor = false;
            btnTecnicos.BackColor = Color.LightBlue;
            btnTecnicos.FlatStyle = FlatStyle.Flat;
            btnTecnicos.FlatAppearance.BorderSize = 0;
            btnTecnicos.Anchor = AnchorStyles.Top;
            btnTecnicos.Cursor = Cursors.Hand;
            btnTecnicos.Click += btnTecnicos_Click;
            // 
            // btnSeguimiento
            // 
            btnSeguimiento.Location = new Point(289, 203);
            btnSeguimiento.Margin = new Padding(3, 2, 3, 2);
            btnSeguimiento.Name = "btnSeguimiento";
            btnSeguimiento.Size = new Size(122, 38);
            btnSeguimiento.TabIndex = 2;
            btnSeguimiento.Text = "Seguimiento";
            btnSeguimiento.UseVisualStyleBackColor = false;
            btnSeguimiento.BackColor = Color.LightBlue;
            btnSeguimiento.FlatStyle = FlatStyle.Flat;
            btnSeguimiento.FlatAppearance.BorderSize = 0;
            btnSeguimiento.Anchor = AnchorStyles.Top;
            btnSeguimiento.Cursor = Cursors.Hand;
            btnSeguimiento.Click += btnSeguimiento_Click;
            // 
            // btnReportes
            // 
            btnReportes.Location = new Point(289, 245);
            btnReportes.Margin = new Padding(3, 2, 3, 2);
            btnReportes.Name = "btnReportes";
            btnReportes.Size = new Size(122, 38);
            btnReportes.TabIndex = 3;
            btnReportes.Text = "Reportes";
            btnReportes.UseVisualStyleBackColor = false;
            btnReportes.BackColor = Color.LightBlue;
            btnReportes.FlatStyle = FlatStyle.Flat;
            btnReportes.FlatAppearance.BorderSize = 0;
            btnReportes.Anchor = AnchorStyles.Top;
            btnReportes.Cursor = Cursors.Hand;
            btnReportes.Click += btnReportes_Click;
            // 
            // label1
            // 
            label1.AutoSize = false;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label1.Location = new Point(0, 22);
            label1.Name = "label1";
            label1.Size = new Size(700, 40);
            label1.TabIndex = 4;
            label1.Text = "Soporte Técnico";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            // 
            // btnPedidos
            // 
            btnPedidos.Location = new Point(289, 159);
            btnPedidos.Margin = new Padding(3, 2, 3, 2);
            btnPedidos.Name = "btnPedidos";
            btnPedidos.Size = new Size(122, 38);
            btnPedidos.TabIndex = 5;
            btnPedidos.Text = "Pedidos";
            btnPedidos.UseVisualStyleBackColor = false;
            btnPedidos.BackColor = Color.LightBlue;
            btnPedidos.FlatStyle = FlatStyle.Flat;
            btnPedidos.FlatAppearance.BorderSize = 0;
            btnPedidos.Cursor = Cursors.Hand;
            btnPedidos.Click += btnPedidos_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(btnPedidos);
            Controls.Add(label1);
            Controls.Add(btnReportes);
            Controls.Add(btnSeguimiento);
            Controls.Add(btnTecnicos);
            Controls.Add(btnClientes);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Sistema de Soporte Técnico";
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.WhiteSmoke;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnPedidos;
    }
}