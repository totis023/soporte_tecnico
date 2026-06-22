using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using soporte_tecnico.controllers;

namespace soporte_tecnico.forms
{
    public partial class frmCliente : Form
    {
        private nCliente controladorCliente = new nCliente();
        private int idSeleccionado = -1; //para saber si hay fila seleccionada a la cual vamos a eliminar o midificar 
        public frmCliente()
        {
            InitializeComponent();
            // configurar comportamiento del DataGridView para seleccionar filas completas
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;

            ActualizarGrid(); //para que mustre si hay datos para arrancar
            // centrar botones cuando se redimensiona la ventana
            this.Resize += FrmCliente_Resize;
            CenterButtons();
        }

        private void FrmCliente_Resize(object? sender, EventArgs e)
        {
            CenterButtons();
        }

        private void CenterButtons()
        {
            try
            {
                int spacing = 20; // espacio entre botones
                int w1 = button1.Width;
                int w2 = button2.Width;
                int w3 = button3.Width;
                int total = w1 + w2 + w3 + spacing * 2;
                int startX = Math.Max(10, (this.ClientSize.Width - total) / 2);
                int y = Math.Max( (this.ClientSize.Height - 40), button1.Top);
                // mantener la distancia vertical original si es posible
                int top = button1.Top;
                button1.Left = startX;
                button1.Top = top;
                button2.Left = startX + w1 + spacing;
                button2.Top = top;
                button3.Left = startX + w1 + spacing + w2 + spacing;
                button3.Top = top;
            }
            catch
            {
                // ignorar errores de posicionamiento
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) //el boton de agregar 
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("El nombre es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(txtTelefono.Text))
            {
                MessageBox.Show("El Telefono es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("El Email es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            controladorCliente.Agregar(txtNombre.Text, txtTelefono.Text, txtEmail.Text);
            ActualizarGrid();
            LimpiarFormulario();

        }

        private void button3_Click(object sender, EventArgs e) //el boton de eliminar 
        {
            if (idSeleccionado == -1)
            {
                MessageBox.Show("Por favor, seleccione un cliente de la lista para eliminar.");
                return;
            }

            controladorCliente.Eliminar(idSeleccionado);
            ActualizarGrid();
            LimpiarFormulario();
        }

        private void button2_Click(object sender, EventArgs e) //el boton de modificar 
        {
            if (idSeleccionado == -1)
            {
                MessageBox.Show("Por favor, seleccione un cliente de la lista para modificar.");
                return;
            }

            controladorCliente.Modificar(idSeleccionado, txtNombre.Text, txtTelefono.Text, txtEmail.Text);
            ActualizarGrid();
            LimpiarFormulario();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)

        {

            // Valida que el clic sea en una fila válida y no en el encabezado

            if (e.RowIndex >= 0)

            {

                DataGridViewRow fila = dataGridView1.Rows[e.RowIndex];



                // Cambiado: Leemos el objeto Cliente directamente de la fila de forma segura

                if (fila.DataBoundItem is soporte_tecnico.models.Cliente cliente)

                {

                    idSeleccionado = cliente.Id;

                    txtNombre.Text = cliente.Nombre ?? string.Empty;

                    txtTelefono.Text = cliente.Telefono ?? string.Empty;

                    txtEmail.Text = cliente.Email ?? string.Empty;

                }

                else

                {

                    // Alternativa por si las columnas se crearon manualmente sin DataBoundItem

                    idSeleccionado = Convert.ToInt32(fila.Cells[0].Value);

                    txtNombre.Text = fila.Cells[1].Value?.ToString() ?? string.Empty;

                    txtTelefono.Text = fila.Cells[2].Value?.ToString() ?? string.Empty;

                    txtEmail.Text = fila.Cells[3].Value?.ToString() ?? string.Empty;

                }

            }

        }
        private void LimpiarFormulario()
        {
            txtNombre.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            idSeleccionado = -1; // rastremos por el id seleccionardo 
        }

        private void ActualizarGrid()
        {
            // asegurar que el DataGridView genera columnas desde las propiedades del modelo
            dataGridView1.AutoGenerateColumns = true;

            var lista = controladorCliente.ObtenerTodos();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = new System.ComponentModel.BindingList<soporte_tecnico.models.Cliente>(lista);

            // Ajustar tamaños de columnas: id y columnas de la izquierda más pequeñas, email ocupa el espacio restante
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            if (dataGridView1.Columns.Count > 0)
            {
                // establecer anchos por nombre de columna cuando existan (más espacio para Email)
                if (dataGridView1.Columns.Contains("Id"))
                {
                    dataGridView1.Columns["Id"].Width = 40;
                    dataGridView1.Columns["Id"].Resizable = DataGridViewTriState.False;
                }
                if (dataGridView1.Columns.Contains("Nombre"))
                    dataGridView1.Columns["Nombre"].Width = 120; // achicar un poco
                if (dataGridView1.Columns.Contains("Telefono"))
                    dataGridView1.Columns["Telefono"].Width = 100;
                // dejar que Email ocupe el resto (agrandada al reducir otras columnas)
                if (dataGridView1.Columns.Contains("Email"))
                    dataGridView1.Columns["Email"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                // columnas adicionales: si quedan, permitirles ajustar mínimo
                foreach (DataGridViewColumn c in dataGridView1.Columns)
                {
                    if (c.Name != "Email" && c.Name != "Id" && c.Name != "Nombre" && c.Name != "Telefono")
                        c.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                }
            }

            dataGridView1.ClearSelection();
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
