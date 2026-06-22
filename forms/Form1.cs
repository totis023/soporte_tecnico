using System;
using System.Windows.Forms;
using soporte_tecnico.forms;
using soporte_tecnico.controllers;

namespace soporte_tecnico
{
    public partial class Form1 : Form
    {
        private nCliente controladorCliente = new nCliente();
        private nTecnico controladorTecnico = new nTecnico();
        private nPedido controladorPedido = new nPedido();
        private frmCliente? clienteForm;
        private frmTecnico? tecnicoForm;
        private frmPedidos? pedidosForm;
        private frmSeguimiento? seguimientoForm;
        private frmReportes? reportesForm;

        public Form1()
        {
            InitializeComponent();
            // centrar controles inicialmente y al redimensionar
            CenterMainControls();
            this.Resize += (s, e) => CenterMainControls();
        }

        private void CenterMainControls()
        {
            try
            {
                // controles a centrar
                var ctrls = new Control[] { label1, btnClientes, btnTecnicos, btnPedidos, btnSeguimiento, btnReportes };
                // calcular limites actuales del grupo
                int minTop = ctrls.Min(c => c.Top);
                int maxBottom = ctrls.Max(c => c.Bottom);
                int groupHeight = maxBottom - minTop;

                int startTop = Math.Max(10, (this.ClientSize.Height - groupHeight) / 2);

                foreach (var c in ctrls)
                {
                    int offset = c.Top - minTop;
                    c.Top = startTop + offset;
                    c.Left = Math.Max(10, (this.ClientSize.Width - c.Width) / 2);
                }
            }
            catch
            {
                // ignorar errores de centrado
            }
        }


        private void btnClientes_Click(object sender, EventArgs e)
        {
            if (clienteForm == null || clienteForm.IsDisposed)
            {
                clienteForm = new frmCliente();
                clienteForm.FormClosed += ClienteForm_FormClosed;
            }

            if (!clienteForm.Visible)
                clienteForm.Show();

            clienteForm.BringToFront();
        }

        private void btnTecnicos_Click(object sender, EventArgs e)
        {
            if (tecnicoForm == null || tecnicoForm.IsDisposed)
            {
                tecnicoForm = new frmTecnico();
                tecnicoForm.FormClosed += TecnicoForm_FormClosed;
            }

            if (!tecnicoForm.Visible)
                tecnicoForm.Show();

            tecnicoForm.BringToFront();
        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            if (pedidosForm == null || pedidosForm.IsDisposed)
            {
                pedidosForm = new frmPedidos(controladorCliente, controladorTecnico, controladorPedido);
                pedidosForm.FormClosed += PedidosForm_FormClosed;
            }

            if (!pedidosForm.Visible)
                pedidosForm.Show();

            pedidosForm.BringToFront();
        }

        private void btnSeguimiento_Click(object sender, EventArgs e)
        {
            if (seguimientoForm == null || seguimientoForm.IsDisposed)
            {
                seguimientoForm = new frmSeguimiento(controladorPedido);
                seguimientoForm.FormClosed += SeguimientoForm_FormClosed;
            }
            if (!seguimientoForm.Visible)
                seguimientoForm.Show();
            seguimientoForm.BringToFront();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            if (reportesForm == null || reportesForm.IsDisposed)
            {
                reportesForm = new frmReportes(controladorPedido);
                reportesForm.FormClosed += ReportesForm_FormClosed;
            }
            if (!reportesForm.Visible)
                reportesForm.Show();
            reportesForm.BringToFront();
        }

        private void ClienteForm_FormClosed(object? sender, FormClosedEventArgs e)
        {
            clienteForm = null;
        }

        private void TecnicoForm_FormClosed(object? sender, FormClosedEventArgs e)
        {
            tecnicoForm = null;
        }

        private void PedidosForm_FormClosed(object? sender, FormClosedEventArgs e)
        {
            pedidosForm = null;
        }

        private void SeguimientoForm_FormClosed(object? sender, FormClosedEventArgs e)
        {
            seguimientoForm = null;
        }

        private void ReportesForm_FormClosed(object? sender, FormClosedEventArgs e)
        {
            reportesForm = null;
        }


    }


}

