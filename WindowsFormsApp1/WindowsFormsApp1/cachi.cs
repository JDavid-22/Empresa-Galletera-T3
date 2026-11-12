using Capa_entidad;
using CapaLogica;
using System;
using System.Windows.Forms;

namespace Propuestas_de_accion_preventiva
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            listarPropuesta();
            grupBoxDatos.Enabled = false;
            txtID.Enabled = false;
            btnAgregar.Visible = false;
            btnModificar.Visible = false;
        }

        public void listarPropuesta()
        {
            dgvPropuesta.DataSource = null;
            dgvPropuesta.DataSource = logPropuesta.Instancia.ListarPropuesta();

            if (dgvPropuesta.Columns["estPropuesta"] != null)
                dgvPropuesta.Columns["estPropuesta"].Visible = false;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarVariables();
            grupBoxDatos.Enabled = true;
            btnAgregar.Visible = true;
            btnModificar.Visible = false;
            txtInsumos.Focus();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtInsumos.Text) ||
                string.IsNullOrWhiteSpace(txtEncargado.Text) ||
                string.IsNullOrWhiteSpace(txtAcciones.Text))
            {
                MessageBox.Show("Completa todos los campos.");
                return;
            }

            try
            {
                entPropuesta p = new entPropuesta();
                p.insumos_para_reparacion = txtInsumos.Text.Trim();
                p.Encargado_reparacion = txtEncargado.Text.Trim();
                p.Acciones_a_realizar = txtAcciones.Text.Trim();
                p.Hora_ejecucion = dtpHora.Value.ToString("HH:mm");
                logPropuesta.Instancia.InsertaPropuesta(p);

                MessageBox.Show("Propuesta registrada correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error.. " + ex.Message);
                return;
            }

            LimpiarVariables();
            grupBoxDatos.Enabled = false;
            btnAgregar.Visible = false;
            listarPropuesta();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarVariables();
            grupBoxDatos.Enabled = false;
            btnAgregar.Visible = false;
            btnModificar.Visible = false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LimpiarVariables()
        {
            txtID.Text = "";
            txtInsumos.Text = "";
            txtEncargado.Text = "";
            txtAcciones.Text = "";
            dtpHora.Value = DateTime.Now;
        }

        private void dgvPropuesta_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow fila = dgvPropuesta.Rows[e.RowIndex];
            txtID.Text = fila.Cells[0].Value.ToString();
            txtInsumos.Text = fila.Cells[1].Value.ToString();
            txtEncargado.Text = fila.Cells[2].Value.ToString();
            txtAcciones.Text = fila.Cells[3].Value.ToString();

            TimeSpan hora;
            if (TimeSpan.TryParse(fila.Cells[4].Value.ToString(), out hora))
                dtpHora.Value = DateTime.Today.Add(hora);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                MessageBox.Show("Primero haz doble clic en una fila de la tabla.");
                return;
            }
            grupBoxDatos.Enabled = true;
            btnModificar.Visible = true;
            btnAgregar.Visible = false;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtInsumos.Text) ||
                string.IsNullOrWhiteSpace(txtEncargado.Text) ||
                string.IsNullOrWhiteSpace(txtAcciones.Text))
            {
                MessageBox.Show("Completa todos los campos.");
                return;
            }

            try
            {
                entPropuesta p = new entPropuesta();
                p.PropuestasDeAccionesPreventivasID = int.Parse(txtID.Text.Trim());
                p.insumos_para_reparacion = txtInsumos.Text.Trim();
                p.Encargado_reparacion = txtEncargado.Text.Trim();
                p.Acciones_a_realizar = txtAcciones.Text.Trim();
                p.Hora_ejecucion = dtpHora.Value.ToString("HH:mm");
                logPropuesta.Instancia.EditaPropuesta(p);

                MessageBox.Show("Propuesta modificada correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error.. " + ex.Message);
                return;
            }

            LimpiarVariables();
            grupBoxDatos.Enabled = false;
            btnModificar.Visible = false;
            listarPropuesta();
        }

        private void btnDeshabilitar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                MessageBox.Show("Primero haz doble clic en una fila de la tabla.");
                return;
            }

            if (MessageBox.Show("¿Deshabilitar esta propuesta?", "Confirmar",
                MessageBoxButtons.YesNo) != DialogResult.Yes) return;

            try
            {
                entPropuesta p = new entPropuesta();
                p.PropuestasDeAccionesPreventivasID = int.Parse(txtID.Text.Trim());
                logPropuesta.Instancia.DeshabilitarPropuesta(p);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error.. " + ex.Message);
                return;
            }

            LimpiarVariables();
            grupBoxDatos.Enabled = false;
            btnModificar.Visible = false;
            listarPropuesta();
        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtInsumos.Text) ||
       string.IsNullOrWhiteSpace(txtEncargado.Text) ||
       string.IsNullOrWhiteSpace(txtAcciones.Text))
            {
                MessageBox.Show("Completa todos los campos.");
                return;
            }

            try
            {
                entPropuesta p = new entPropuesta();
                p.insumos_para_reparacion = txtInsumos.Text.Trim();
                p.Encargado_reparacion = txtEncargado.Text.Trim();
                p.Acciones_a_realizar = txtAcciones.Text.Trim();
                p.Hora_ejecucion = dtpHora.Value.ToString("HH:mm");
                logPropuesta.Instancia.InsertaPropuesta(p);

                MessageBox.Show("Propuesta registrada correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error.. " + ex.Message);
                return;
            }

            LimpiarVariables();
            grupBoxDatos.Enabled = false;
            btnAgregar.Visible = false;
            listarPropuesta();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click_1(object sender, EventArgs e)
        {
            LimpiarVariables();
            grupBoxDatos.Enabled = true;
            btnAgregar.Visible = true;
            btnModificar.Visible = false;
            txtInsumos.Focus();
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            LimpiarVariables();
            grupBoxDatos.Enabled = false;
            btnAgregar.Visible = false;
            btnModificar.Visible = false;

        }

        private void btnAgregar2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}