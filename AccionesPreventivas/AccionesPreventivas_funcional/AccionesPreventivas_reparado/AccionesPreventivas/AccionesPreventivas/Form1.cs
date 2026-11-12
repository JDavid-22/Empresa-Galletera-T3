using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using CapaEntidad;
using CapaLogica;

namespace AccionesPreventivas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cboPrioridad.SelectedIndex = 0;
            CargarLista();
            PrepararNuevo();
        }

        private void CargarLista()
        {
            try
            {
                List<entPlanDeMantenimiento> lista =
                    logPlanDeMantenimiento.Instancia.ListarPlanDeMantenimiento();

                dgvPlanes.DataSource = lista;

                foreach (DataGridViewRow fila in dgvPlanes.Rows)
                {
                    entPlanDeMantenimiento p = fila.DataBoundItem as entPlanDeMantenimiento;
                    if (p != null && !p.Estado)
                        fila.DefaultCellStyle.ForeColor = Color.Gray;
                }

                dgvPlanes.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar la lista",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PrepararNuevo()
        {
            txtPlanID.Clear();
            txtEquipoID.Clear();
            txtTiempoParada.Clear();
            cboPrioridad.SelectedIndex = 0;
            dtpFechaInicio.Value = DateTime.Today;
            dtpFechaFin.Value = DateTime.Today;
            chkEstado.Checked = true;
            txtPlanID.ReadOnly = false;
            dgvPlanes.ClearSelection();

            int siguiente = 1;
            List<entPlanDeMantenimiento> lista = dgvPlanes.DataSource as List<entPlanDeMantenimiento>;
            if (lista != null)
            {
                foreach (entPlanDeMantenimiento p in lista)
                    if (p.PlanDeMantenimientoID >= siguiente)
                        siguiente = p.PlanDeMantenimientoID + 1;
            }
            txtPlanID.Text = siguiente.ToString();
            txtEquipoID.Focus();
        }

        private entPlanDeMantenimiento LeerFormulario()
        {
            int planID;
            if (!int.TryParse(txtPlanID.Text.Trim(), out planID))
            {
                MessageBox.Show("El ID del plan debe ser un numero entero.", "Dato incorrecto",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPlanID.Focus();
                return null;
            }

            int equipoID;
            if (!int.TryParse(txtEquipoID.Text.Trim(), out equipoID))
            {
                MessageBox.Show("El ID del equipo debe ser un numero entero.", "Dato incorrecto",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEquipoID.Focus();
                return null;
            }

            if (cboPrioridad.SelectedItem == null)
            {
                MessageBox.Show("Seleccione una prioridad.", "Dato incorrecto",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboPrioridad.Focus();
                return null;
            }

            decimal? tiempo = null;
            if (txtTiempoParada.Text.Trim().Length > 0)
            {
                decimal valor;
                string texto = txtTiempoParada.Text.Trim().Replace(',', '.');
                if (!decimal.TryParse(texto, NumberStyles.Number, CultureInfo.InvariantCulture, out valor))
                {
                    MessageBox.Show("El tiempo de parada debe ser un numero (ejemplo: 8.5).", "Dato incorrecto",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTiempoParada.Focus();
                    return null;
                }
                tiempo = valor;
            }

            entPlanDeMantenimiento plan = new entPlanDeMantenimiento();
            plan.PlanDeMantenimientoID = planID;
            plan.EquipoID = equipoID;
            plan.Prioridad = cboPrioridad.SelectedItem.ToString();
            plan.FechaInicio = dtpFechaInicio.Value.Date;
            plan.FechaFin = dtpFechaFin.Value.Date;
            plan.TiempoParada = tiempo;
            plan.Estado = chkEstado.Checked;
            return plan;
        }
        private void dgvPlanes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            entPlanDeMantenimiento p = dgvPlanes.Rows[e.RowIndex].DataBoundItem as entPlanDeMantenimiento;
            if (p == null) return;

            txtPlanID.Text = p.PlanDeMantenimientoID.ToString();
            txtEquipoID.Text = p.EquipoID.ToString();
            cboPrioridad.SelectedItem = p.Prioridad;
            dtpFechaInicio.Value = p.FechaInicio;
            dtpFechaFin.Value = p.FechaFin;
            txtTiempoParada.Text = p.TiempoParada.HasValue
                ? p.TiempoParada.Value.ToString("0.##", CultureInfo.InvariantCulture)
                : "";
            chkEstado.Checked = p.Estado;

            txtPlanID.ReadOnly = true;
        }


        private void btnNuevo_Click(object sender, EventArgs e)
        {
            PrepararNuevo();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtPlanID.ReadOnly)
            {
                MessageBox.Show("Ese plan ya existe. Use el boton Editar para modificarlo, o pulse Nuevo para registrar otro.",
                    "Plan existente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            entPlanDeMantenimiento plan = LeerFormulario();
            if (plan == null) return;

            try
            {
                if (logPlanDeMantenimiento.Instancia.InsertarPlanDeMantenimiento(plan))
                {
                    MessageBox.Show("Plan registrado correctamente.", "Listo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarLista();
                    PrepararNuevo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "No se pudo guardar",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!txtPlanID.ReadOnly)
            {
                MessageBox.Show("Primero seleccione un plan de la tabla.", "Editar",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            entPlanDeMantenimiento plan = LeerFormulario();
            if (plan == null) return;

            try
            {
                if (logPlanDeMantenimiento.Instancia.EditarPlanDeMantenimiento(plan))
                {
                    MessageBox.Show("Plan actualizado correctamente.", "Listo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarLista();
                    PrepararNuevo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "No se pudo editar",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeshabilitar_Click(object sender, EventArgs e)
        {
            if (!txtPlanID.ReadOnly)
            {
                MessageBox.Show("Primero seleccione un plan de la tabla.", "Deshabilitar",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult r = MessageBox.Show(
                "Desea deshabilitar el plan " + txtPlanID.Text + "?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r != DialogResult.Yes) return;

            try
            {
                entPlanDeMantenimiento plan = new entPlanDeMantenimiento();
                plan.PlanDeMantenimientoID = int.Parse(txtPlanID.Text);

                if (logPlanDeMantenimiento.Instancia.DeshabilitarPlanDeMantenimiento(plan))
                {
                    MessageBox.Show("Plan deshabilitado.", "Listo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarLista();
                    PrepararNuevo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "No se pudo deshabilitar",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            PrepararNuevo();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
