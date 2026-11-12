using CapaEntidad;
using CapaLogica;
using System.ComponentModel;

namespace T3_EmpresaGalletera
{
    public partial class frmOrdenPedido : Form
    {
        private readonly BindingList<entDetalleOrdenPedido> _detalle = new BindingList<entDetalleOrdenPedido>();
        private entOrdenPedido _actual;

        public frmOrdenPedido()
        {
            InitializeComponent();
            ConfigurarControles();
        }

        private void ConfigurarControles()
        {
            cboEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEstado.Items.AddRange(logOrdenPedido.Estados);
            cboComponente.DropDownStyle = ComboBoxStyle.DropDownList;

            dgvDetalle.AutoGenerateColumns = false;
            dgvDetalle.AllowUserToAddRows = false;
            dgvDetalle.AllowUserToDeleteRows = false;
            dgvDetalle.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetalle.Columns.Clear();
            dgvDetalle.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Componente", DataPropertyName = "nomComponente", ReadOnly = true, FillWeight = 75 });
            dgvDetalle.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Cantidad", DataPropertyName = "cantidad", FillWeight = 25 });
            dgvDetalle.DataSource = _detalle;

            dgvPedidos.AutoGenerateColumns = false;
            dgvPedidos.ReadOnly = true;
            dgvPedidos.AllowUserToAddRows = false;
            dgvPedidos.MultiSelect = false;
            dgvPedidos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPedidos.Columns.Clear();
            dgvPedidos.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Código", DataPropertyName = "codOrdenPedido", FillWeight = 15 });
            dgvPedidos.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Fecha", DataPropertyName = "fecOrdenPedido", FillWeight = 20, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm" } });
            dgvPedidos.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Estado", DataPropertyName = "estadoPedido", FillWeight = 15 });
            dgvPedidos.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Observación", DataPropertyName = "observacion", FillWeight = 40 });
            dgvPedidos.Columns.Add(new DataGridViewCheckBoxColumn { HeaderText = "Habilitada", DataPropertyName = "estOrdenPedido", FillWeight = 10 });

            Load += FrmOrdenPedido_Load;
            btnAgregar.Click += BtnAgregar_Click;
            btnQuitar.Click += BtnQuitar_Click;
            btnNuevo.Click += (s, e) => Nuevo();
            btnGuardar.Click += BtnGuardar_Click;
            btnInhabilitar.Click += BtnInhabilitar_Click;
            chkInhabilitados.CheckedChanged += (s, e) => CargarLista();
            dgvPedidos.CellClick += DgvPedidos_CellClick;
            dgvPedidos.CellFormatting += DgvPedidos_CellFormatting;
        }

        private void FrmOrdenPedido_Load(object sender, EventArgs e)
        {
            try
            {
                cboComponente.DataSource = logComponente.Instancia.ListarComponente();
                CargarLista();
                Nuevo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarLista()
        {
            try
            {
                var lista = logOrdenPedido.Instancia.ListarOrdenPedido();
                if (!chkInhabilitados.Checked)
                    lista = lista.Where(x => x.estOrdenPedido).ToList();
                dgvPedidos.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Nuevo()
        {
            _actual = null;
            txtCodigo.Text = logOrdenPedido.Instancia.SiguienteCodigoOrdenPedido();
            dtpFecha.Value = DateTime.Now;
            cboEstado.SelectedItem = logOrdenPedido.Estados[0];
            cboEstado.Enabled = false;        
            txtObservacion.Clear();
            _detalle.Clear();
            HabilitarEdicion(true);
            btnGuardar.Enabled = true;
            btnInhabilitar.Enabled = false;
        }

        private void HabilitarEdicion(bool editable)
        {
            txtObservacion.Enabled = editable;
            cboComponente.Enabled = editable;
            nudCantidad.Enabled = editable;
            btnAgregar.Enabled = editable;
            btnQuitar.Enabled = editable;
            dgvDetalle.ReadOnly = !editable;
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            var comp = cboComponente.SelectedItem as entComponente;
            if (comp == null) return;

            int cantidad = (int)nudCantidad.Value;

            if (cantidad <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a 0.");
                return;
            }

            var existente = _detalle.FirstOrDefault(
                d => d.idComponente == comp.idComponente);

            if (existente != null)
            {
                existente.cantidad += cantidad;
                _detalle.ResetBindings();
            }
            else
            {
                _detalle.Add(new entDetalleOrdenPedido
                {
                    idComponente = comp.idComponente,
                    nomComponente = comp.nomComponente,
                    cantidad = cantidad
                });
            }

            nudCantidad.Value = 1;
        }

        private void BtnQuitar_Click(object sender, EventArgs e)
        {
            if (dgvDetalle.CurrentRow == null) return;
            var d = dgvDetalle.CurrentRow.DataBoundItem as entDetalleOrdenPedido;
            if (d != null) _detalle.Remove(d);
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                dgvDetalle.EndEdit();

                var o = new entOrdenPedido
                {
                    codOrdenPedido = txtCodigo.Text.Trim(),
                    fecOrdenPedido = dtpFecha.Value,
                    estadoPedido = cboEstado.SelectedItem as string,
                    observacion = string.IsNullOrWhiteSpace(txtObservacion.Text) ? null : txtObservacion.Text.Trim(),
                    detalle = _detalle.ToList()
                };

                if (_actual == null)
                {
                    logOrdenPedido.Instancia.InsertaOrdenPedido(o);
                    MessageBox.Show("Orden de pedido registrada.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    o.idOrdenPedido = _actual.idOrdenPedido;
                    logOrdenPedido.Instancia.EditaOrdenPedido(o);
                    MessageBox.Show("Orden de pedido actualizada.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                CargarLista();
                Nuevo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "No se pudo guardar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnInhabilitar_Click(object sender, EventArgs e)
        {
            if (_actual == null) return;

            var r = MessageBox.Show("¿Inhabilitar la orden " + _actual.codOrdenPedido + "?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r != DialogResult.Yes) return;

            try
            {
                logOrdenPedido.Instancia.DeshabilitarOrdenPedido(_actual);
                CargarLista();
                Nuevo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "No se pudo inhabilitar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DgvPedidos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var o = dgvPedidos.Rows[e.RowIndex].DataBoundItem as entOrdenPedido;
            if (o == null) return;

            try
            {
                _actual = o;
                txtCodigo.Text = o.codOrdenPedido;
                dtpFecha.Value = o.fecOrdenPedido;
                cboEstado.SelectedItem = o.estadoPedido;
                txtObservacion.Text = o.observacion;

                _detalle.Clear();
                foreach (var d in logOrdenPedido.Instancia.ListarDetalleOrdenPedido(o.idOrdenPedido))
                    _detalle.Add(d);

                bool editable = o.estOrdenPedido && o.estadoPedido == logOrdenPedido.Estados[0];
                HabilitarEdicion(editable);
                cboEstado.Enabled = o.estOrdenPedido;
                btnGuardar.Enabled = o.estOrdenPedido;
                btnInhabilitar.Enabled = o.estOrdenPedido;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvPedidos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var o = dgvPedidos.Rows[e.RowIndex].DataBoundItem as entOrdenPedido;
            if (o != null && !o.estOrdenPedido) e.CellStyle.ForeColor = Color.Gray;
        }
    }
}
