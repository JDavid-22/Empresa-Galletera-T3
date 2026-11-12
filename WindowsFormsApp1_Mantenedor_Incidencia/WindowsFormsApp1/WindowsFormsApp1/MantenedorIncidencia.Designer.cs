namespace WindowsFormsApp1
{
    partial class MantenedorIncidencia
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.dgvIncidencia = new System.Windows.Forms.DataGridView();
            this.grupBoxDatos = new System.Windows.Forms.GroupBox();
            this.lblId = new System.Windows.Forms.Label();
            this.txtIncidenciaID = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFechaHora = new System.Windows.Forms.DateTimePicker();
            this.lblValor = new System.Windows.Forms.Label();
            this.txtValorObservado = new System.Windows.Forms.TextBox();
            this.lblNivel = new System.Windows.Forms.Label();
            this.cboNivelGravedad = new System.Windows.Forms.ComboBox();
            this.lblObservacion = new System.Windows.Forms.Label();
            this.txtObservacion = new System.Windows.Forms.TextBox();
            this.chkEstado = new System.Windows.Forms.CheckBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnDeshabilitar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIncidencia)).BeginInit();
            this.grupBoxDatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(12, 12);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(260, 24);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Mantenedor de Incidencias";
            // 
            // dgvIncidencia
            // 
            this.dgvIncidencia.AllowUserToAddRows = false;
            this.dgvIncidencia.AllowUserToDeleteRows = false;
            this.dgvIncidencia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvIncidencia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIncidencia.Location = new System.Drawing.Point(12, 45);
            this.dgvIncidencia.MultiSelect = false;
            this.dgvIncidencia.Name = "dgvIncidencia";
            this.dgvIncidencia.ReadOnly = true;
            this.dgvIncidencia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvIncidencia.Size = new System.Drawing.Size(860, 215);
            this.dgvIncidencia.TabIndex = 1;
            this.dgvIncidencia.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIncidencia_CellDoubleClick);
            // 
            // grupBoxDatos
            // 
            this.grupBoxDatos.Controls.Add(this.lblId);
            this.grupBoxDatos.Controls.Add(this.txtIncidenciaID);
            this.grupBoxDatos.Controls.Add(this.lblCodigo);
            this.grupBoxDatos.Controls.Add(this.txtCodigo);
            this.grupBoxDatos.Controls.Add(this.lblFecha);
            this.grupBoxDatos.Controls.Add(this.dtpFechaHora);
            this.grupBoxDatos.Controls.Add(this.lblValor);
            this.grupBoxDatos.Controls.Add(this.txtValorObservado);
            this.grupBoxDatos.Controls.Add(this.lblNivel);
            this.grupBoxDatos.Controls.Add(this.cboNivelGravedad);
            this.grupBoxDatos.Controls.Add(this.lblObservacion);
            this.grupBoxDatos.Controls.Add(this.txtObservacion);
            this.grupBoxDatos.Controls.Add(this.chkEstado);
            this.grupBoxDatos.Controls.Add(this.btnAgregar);
            this.grupBoxDatos.Controls.Add(this.btnModificar);
            this.grupBoxDatos.Controls.Add(this.btnCancelar);
            this.grupBoxDatos.Location = new System.Drawing.Point(12, 270);
            this.grupBoxDatos.Name = "grupBoxDatos";
            this.grupBoxDatos.Size = new System.Drawing.Size(860, 205);
            this.grupBoxDatos.TabIndex = 2;
            this.grupBoxDatos.TabStop = false;
            this.grupBoxDatos.Text = "Datos de la incidencia";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(15, 30);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(21, 13);
            this.lblId.Text = "ID:";
            // 
            // txtIncidenciaID
            // 
            this.txtIncidenciaID.Enabled = false;
            this.txtIncidenciaID.Location = new System.Drawing.Point(130, 27);
            this.txtIncidenciaID.Name = "txtIncidenciaID";
            this.txtIncidenciaID.Size = new System.Drawing.Size(90, 20);
            this.txtIncidenciaID.TabIndex = 0;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(15, 60);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(43, 13);
            this.lblCodigo.Text = "Código:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Location = new System.Drawing.Point(130, 57);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(120, 20);
            this.txtCodigo.TabIndex = 1;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(15, 90);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(81, 13);
            this.lblFecha.Text = "Fecha y hora:";
            // 
            // dtpFechaHora
            // 
            this.dtpFechaHora.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpFechaHora.Enabled = false;
            this.dtpFechaHora.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaHora.Location = new System.Drawing.Point(130, 87);
            this.dtpFechaHora.Name = "dtpFechaHora";
            this.dtpFechaHora.Size = new System.Drawing.Size(150, 20);
            this.dtpFechaHora.TabIndex = 2;
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Location = new System.Drawing.Point(330, 30);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(92, 13);
            this.lblValor.Text = "Valor observado *";
            // 
            // txtValorObservado
            // 
            this.txtValorObservado.Location = new System.Drawing.Point(450, 27);
            this.txtValorObservado.Name = "txtValorObservado";
            this.txtValorObservado.Size = new System.Drawing.Size(120, 20);
            this.txtValorObservado.TabIndex = 3;
            // 
            // lblNivel
            // 
            this.lblNivel.AutoSize = true;
            this.lblNivel.Location = new System.Drawing.Point(330, 60);
            this.lblNivel.Name = "lblNivel";
            this.lblNivel.Size = new System.Drawing.Size(105, 13);
            this.lblNivel.Text = "Nivel de gravedad *";
            // 
            // cboNivelGravedad
            // 
            this.cboNivelGravedad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNivelGravedad.FormattingEnabled = true;
            this.cboNivelGravedad.Location = new System.Drawing.Point(450, 57);
            this.cboNivelGravedad.Name = "cboNivelGravedad";
            this.cboNivelGravedad.Size = new System.Drawing.Size(120, 21);
            this.cboNivelGravedad.TabIndex = 4;
            // 
            // lblObservacion
            // 
            this.lblObservacion.AutoSize = true;
            this.lblObservacion.Location = new System.Drawing.Point(330, 90);
            this.lblObservacion.Name = "lblObservacion";
            this.lblObservacion.Size = new System.Drawing.Size(70, 13);
            this.lblObservacion.Text = "Observación:";
            // 
            // txtObservacion
            // 
            this.txtObservacion.Location = new System.Drawing.Point(450, 87);
            this.txtObservacion.MaxLength = 100;
            this.txtObservacion.Multiline = true;
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.Size = new System.Drawing.Size(390, 45);
            this.txtObservacion.TabIndex = 5;
            // 
            // chkEstado
            // 
            this.chkEstado.AutoSize = true;
            this.chkEstado.Checked = true;
            this.chkEstado.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEstado.Enabled = false;
            this.chkEstado.Location = new System.Drawing.Point(18, 120);
            this.chkEstado.Name = "chkEstado";
            this.chkEstado.Size = new System.Drawing.Size(76, 17);
            this.chkEstado.TabIndex = 6;
            this.chkEstado.Text = "Habilitada";
            this.chkEstado.UseVisualStyleBackColor = true;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(520, 155);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(150, 32);
            this.btnAgregar.TabIndex = 7;
            this.btnAgregar.Text = "Grabar incidencia";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Visible = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(520, 155);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(150, 32);
            this.btnModificar.TabIndex = 8;
            this.btnModificar.Text = "Guardar cambios";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Visible = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(690, 155);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(150, 32);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(12, 490);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(150, 34);
            this.btnNuevo.TabIndex = 3;
            this.btnNuevo.Text = "Nueva incidencia";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(180, 490);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(150, 34);
            this.btnEditar.TabIndex = 4;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnDeshabilitar
            // 
            this.btnDeshabilitar.Location = new System.Drawing.Point(348, 490);
            this.btnDeshabilitar.Name = "btnDeshabilitar";
            this.btnDeshabilitar.Size = new System.Drawing.Size(150, 34);
            this.btnDeshabilitar.TabIndex = 5;
            this.btnDeshabilitar.Text = "Deshabilitar";
            this.btnDeshabilitar.UseVisualStyleBackColor = true;
            this.btnDeshabilitar.Click += new System.EventHandler(this.btnDeshabilitar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(722, 490);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(150, 34);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // MantenedorIncidencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 541);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.dgvIncidencia);
            this.Controls.Add(this.grupBoxDatos);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnDeshabilitar);
            this.Controls.Add(this.btnSalir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MantenedorIncidencia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detección automática de incidencias - Mantenedor de Incidencias";
            ((System.ComponentModel.ISupportInitialize)(this.dgvIncidencia)).EndInit();
            this.grupBoxDatos.ResumeLayout(false);
            this.grupBoxDatos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.DataGridView dgvIncidencia;
        private System.Windows.Forms.GroupBox grupBoxDatos;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtIncidenciaID;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFechaHora;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.TextBox txtValorObservado;
        private System.Windows.Forms.Label lblNivel;
        private System.Windows.Forms.ComboBox cboNivelGravedad;
        private System.Windows.Forms.Label lblObservacion;
        private System.Windows.Forms.TextBox txtObservacion;
        private System.Windows.Forms.CheckBox chkEstado;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnDeshabilitar;
        private System.Windows.Forms.Button btnSalir;
    }
}
