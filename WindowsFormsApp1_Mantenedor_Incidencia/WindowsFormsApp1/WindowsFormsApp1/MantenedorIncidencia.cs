using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using CapaIdentidad;
using CapaLogica;

namespace WindowsFormsApp1
{
    // Capa de Presentacion: solo muestra datos y llama a la capa logica (nunca a la base de datos)
    public partial class MantenedorIncidencia : Form
    {
        public MantenedorIncidencia()
        {
            InitializeComponent();
            cboNivelGravedad.Items.AddRange(logIncidencia.NivelesGravedad);
            listarIncidencia();
            grupBoxDatos.Enabled = false;
        }

        #region metodos auxiliares

        public void listarIncidencia()
        {
            try
            {
                dgvIncidencia.DataSource = logIncidencia.Instancia.ListarIncidencia();
                PonerEncabezado("incidenciaID", "ID");
                PonerEncabezado("codigo", "Código");
                PonerEncabezado("valor_observado", "Valor observado");
                PonerEncabezado("nivel_gravedad", "Nivel de gravedad");
                PonerEncabezado("fecha_hora", "Fecha y hora");
                PonerEncabezado("observacion", "Observación");
                PonerEncabezado("estIncidencia", "Habilitada");
                if (dgvIncidencia.Columns.Contains("fecha_hora"))
                    dgvIncidencia.Columns["fecha_hora"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo listar las incidencias. Revise la conexión a la base de datos.\n\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PonerEncabezado(string columna, string texto)
        {
            if (dgvIncidencia.Columns.Contains(columna))
                dgvIncidencia.Columns[columna].HeaderText = texto;
        }

        private void LimpiarVariables()
        {
            txtIncidenciaID.Text = "";
            txtCodigo.Text = "";
            txtValorObservado.Text = "";
            cboNivelGravedad.SelectedIndex = -1;
            txtObservacion.Text = "";
            dtpFechaHora.Value = DateTime.Now;
            chkEstado.Checked = true;
        }

        // Lee el formulario y arma la entidad. Devuelve null si falta algun dato obligatorio.
        private entIncidencia LeerFormulario()
        {
            decimal valor;
            if (string.IsNullOrWhiteSpace(txtValorObservado.Text) || cboNivelGravedad.SelectedIndex < 0)
            {
                MessageBox.Show("Debe completar los datos obligatorios.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            if (!decimal.TryParse(txtValorObservado.Text.Trim(), NumberStyles.Number, CultureInfo.CurrentCulture, out valor))
            {
                MessageBox.Show("El valor observado debe ser un número.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            entIncidencia inc = new entIncidencia();
            int id;
            if (int.TryParse(txtIncidenciaID.Text.Trim(), out id)) inc.incidenciaID = id;
            inc.valor_observado = valor;
            inc.nivel_gravedad = cboNivelGravedad.SelectedItem.ToString();
            inc.observacion = txtObservacion.Text.Trim();
            inc.estIncidencia = chkEstado.Checked;
            return inc;
        }

        private bool HayIncidenciaSeleccionada()
        {
            if (string.IsNullOrWhiteSpace(txtIncidenciaID.Text))
            {
                MessageBox.Show("Seleccione una incidencia de la lista (doble clic sobre la fila).", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private void Terminar()
        {
            LimpiarVariables();
            grupBoxDatos.Enabled = false;
            btnAgregar.Visible = false;
            btnModificar.Visible = false;
            listarIncidencia();
        }

        #endregion

        #region eventos

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarVariables();
            grupBoxDatos.Enabled = true;
            txtCodigo.Text = "(automático)";
            btnAgregar.Visible = true;
            btnModificar.Visible = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            entIncidencia inc = LeerFormulario();
            if (inc == null) return;
            try
            {
                logIncidencia.Instancia.InsertaIncidencia(inc);
                MessageBox.Show("Incidencia registrada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Terminar();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvIncidencia_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            entIncidencia inc = dgvIncidencia.Rows[e.RowIndex].DataBoundItem as entIncidencia;
            if (inc == null) return;
            txtIncidenciaID.Text = inc.incidenciaID.ToString();
            txtCodigo.Text = inc.codigo;
            txtValorObservado.Text = inc.valor_observado.ToString(CultureInfo.CurrentCulture);
            cboNivelGravedad.SelectedItem = inc.nivel_gravedad;
            dtpFechaHora.Value = inc.fecha_hora;
            txtObservacion.Text = inc.observacion;
            chkEstado.Checked = inc.estIncidencia;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!HayIncidenciaSeleccionada()) return;
            grupBoxDatos.Enabled = true;
            btnModificar.Visible = true;
            btnAgregar.Visible = false;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            entIncidencia inc = LeerFormulario();
            if (inc == null) return;
            try
            {
                logIncidencia.Instancia.EditaIncidencia(inc);
                MessageBox.Show("Incidencia modificada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Terminar();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeshabilitar_Click(object sender, EventArgs e)
        {
            if (!HayIncidenciaSeleccionada()) return;
            DialogResult r = MessageBox.Show("¿Desea deshabilitar la incidencia " + txtCodigo.Text + "?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r != DialogResult.Yes) return;
            try
            {
                entIncidencia inc = new entIncidencia();
                inc.incidenciaID = int.Parse(txtIncidenciaID.Text.Trim());
                logIncidencia.Instancia.DeshabilitarIncidencia(inc);
                MessageBox.Show("Incidencia deshabilitada.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Terminar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al deshabilitar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        #endregion
    }
}
