namespace AccionesPreventivas
{
    partial class Form1
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTitulo = new System.Windows.Forms.Panel();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.grpDatos = new System.Windows.Forms.GroupBox();
            this.chkEstado = new System.Windows.Forms.CheckBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.txtTiempoParada = new System.Windows.Forms.TextBox();
            this.lblTiempoParada = new System.Windows.Forms.Label();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.lblFechaFin = new System.Windows.Forms.Label();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.cboPrioridad = new System.Windows.Forms.ComboBox();
            this.lblPrioridad = new System.Windows.Forms.Label();
            this.txtEquipoID = new System.Windows.Forms.TextBox();
            this.lblEquipoID = new System.Windows.Forms.Label();
            this.txtPlanID = new System.Windows.Forms.TextBox();
            this.lblPlanID = new System.Windows.Forms.Label();
            this.grpLista = new System.Windows.Forms.GroupBox();
            this.dgvPlanes = new System.Windows.Forms.DataGridView();
            this.colPlanID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEquipoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrioridad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFechaInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFechaFin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTiempoParada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pnlBotones = new System.Windows.Forms.Panel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnDeshabilitar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.pnlTitulo.SuspendLayout();
            this.grpDatos.SuspendLayout();
            this.grpLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanes)).BeginInit();
            this.pnlBotones.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlTitulo
            //
            this.pnlTitulo.BackColor = System.Drawing.Color.FromArgb(31, 78, 121);
            this.pnlTitulo.Controls.Add(this.lblSubtitulo);
            this.pnlTitulo.Controls.Add(this.lblTitulo);
            this.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitulo.Location = new System.Drawing.Point(0, 0);
            this.pnlTitulo.Name = "pnlTitulo";
            this.pnlTitulo.Size = new System.Drawing.Size(960, 70);
            this.pnlTitulo.TabIndex = 0;
            //
            // lblSubtitulo
            //
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(200, 220, 240);
            this.lblSubtitulo.Location = new System.Drawing.Point(24, 42);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(250, 15);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Sistema de Acciones Preventivas - Equipos";
            //
            // lblTitulo
            //
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(20, 8);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(310, 30);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Plan de Mantenimiento";
            //
            // grpDatos
            //
            this.grpDatos.Controls.Add(this.chkEstado);
            this.grpDatos.Controls.Add(this.lblEstado);
            this.grpDatos.Controls.Add(this.txtTiempoParada);
            this.grpDatos.Controls.Add(this.lblTiempoParada);
            this.grpDatos.Controls.Add(this.dtpFechaFin);
            this.grpDatos.Controls.Add(this.lblFechaFin);
            this.grpDatos.Controls.Add(this.dtpFechaInicio);
            this.grpDatos.Controls.Add(this.lblFechaInicio);
            this.grpDatos.Controls.Add(this.cboPrioridad);
            this.grpDatos.Controls.Add(this.lblPrioridad);
            this.grpDatos.Controls.Add(this.txtEquipoID);
            this.grpDatos.Controls.Add(this.lblEquipoID);
            this.grpDatos.Controls.Add(this.txtPlanID);
            this.grpDatos.Controls.Add(this.lblPlanID);
            this.grpDatos.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpDatos.ForeColor = System.Drawing.Color.FromArgb(31, 78, 121);
            this.grpDatos.Location = new System.Drawing.Point(20, 85);
            this.grpDatos.Name = "grpDatos";
            this.grpDatos.Size = new System.Drawing.Size(300, 390);
            this.grpDatos.TabIndex = 1;
            this.grpDatos.TabStop = false;
            this.grpDatos.Text = "Datos del plan";
            //
            // lblPlanID
            //
            this.lblPlanID.AutoSize = true;
            this.lblPlanID.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPlanID.ForeColor = System.Drawing.Color.Black;
            this.lblPlanID.Location = new System.Drawing.Point(15, 40);
            this.lblPlanID.Name = "lblPlanID";
            this.lblPlanID.Size = new System.Drawing.Size(55, 15);
            this.lblPlanID.TabIndex = 0;
            this.lblPlanID.Text = "ID del plan";
            //
            // txtPlanID
            //
            this.txtPlanID.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPlanID.Location = new System.Drawing.Point(125, 37);
            this.txtPlanID.Name = "txtPlanID";
            this.txtPlanID.Size = new System.Drawing.Size(155, 23);
            this.txtPlanID.TabIndex = 1;
            //
            // lblEquipoID
            //
            this.lblEquipoID.AutoSize = true;
            this.lblEquipoID.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEquipoID.ForeColor = System.Drawing.Color.Black;
            this.lblEquipoID.Location = new System.Drawing.Point(15, 85);
            this.lblEquipoID.Name = "lblEquipoID";
            this.lblEquipoID.Size = new System.Drawing.Size(60, 15);
            this.lblEquipoID.TabIndex = 2;
            this.lblEquipoID.Text = "ID del equipo";
            //
            // txtEquipoID
            //
            this.txtEquipoID.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtEquipoID.Location = new System.Drawing.Point(125, 82);
            this.txtEquipoID.Name = "txtEquipoID";
            this.txtEquipoID.Size = new System.Drawing.Size(155, 23);
            this.txtEquipoID.TabIndex = 3;
            //
            // lblPrioridad
            //
            this.lblPrioridad.AutoSize = true;
            this.lblPrioridad.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPrioridad.ForeColor = System.Drawing.Color.Black;
            this.lblPrioridad.Location = new System.Drawing.Point(15, 130);
            this.lblPrioridad.Name = "lblPrioridad";
            this.lblPrioridad.Size = new System.Drawing.Size(52, 15);
            this.lblPrioridad.TabIndex = 4;
            this.lblPrioridad.Text = "Prioridad";
            //
            // cboPrioridad
            //
            this.cboPrioridad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPrioridad.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboPrioridad.FormattingEnabled = true;
            this.cboPrioridad.Items.AddRange(new object[] {
            "Alta",
            "Media",
            "Baja"});
            this.cboPrioridad.Location = new System.Drawing.Point(125, 127);
            this.cboPrioridad.Name = "cboPrioridad";
            this.cboPrioridad.Size = new System.Drawing.Size(155, 23);
            this.cboPrioridad.TabIndex = 5;
            //
            // lblFechaInicio
            //
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFechaInicio.ForeColor = System.Drawing.Color.Black;
            this.lblFechaInicio.Location = new System.Drawing.Point(15, 175);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(65, 15);
            this.lblFechaInicio.TabIndex = 6;
            this.lblFechaInicio.Text = "Fecha inicio";
            //
            // dtpFechaInicio
            //
            this.dtpFechaInicio.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(125, 172);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(155, 23);
            this.dtpFechaInicio.TabIndex = 7;
            //
            // lblFechaFin
            //
            this.lblFechaFin.AutoSize = true;
            this.lblFechaFin.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFechaFin.ForeColor = System.Drawing.Color.Black;
            this.lblFechaFin.Location = new System.Drawing.Point(15, 220);
            this.lblFechaFin.Name = "lblFechaFin";
            this.lblFechaFin.Size = new System.Drawing.Size(55, 15);
            this.lblFechaFin.TabIndex = 8;
            this.lblFechaFin.Text = "Fecha fin";
            //
            // dtpFechaFin
            //
            this.dtpFechaFin.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(125, 217);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(155, 23);
            this.dtpFechaFin.TabIndex = 9;
            //
            // lblTiempoParada
            //
            this.lblTiempoParada.AutoSize = true;
            this.lblTiempoParada.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTiempoParada.ForeColor = System.Drawing.Color.Black;
            this.lblTiempoParada.Location = new System.Drawing.Point(15, 265);
            this.lblTiempoParada.Name = "lblTiempoParada";
            this.lblTiempoParada.Size = new System.Drawing.Size(95, 15);
            this.lblTiempoParada.TabIndex = 10;
            this.lblTiempoParada.Text = "Tiempo parada";
            //
            // txtTiempoParada
            //
            this.txtTiempoParada.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTiempoParada.Location = new System.Drawing.Point(125, 262);
            this.txtTiempoParada.Name = "txtTiempoParada";
            this.txtTiempoParada.Size = new System.Drawing.Size(155, 23);
            this.txtTiempoParada.TabIndex = 11;
            //
            // lblEstado
            //
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEstado.ForeColor = System.Drawing.Color.Black;
            this.lblEstado.Location = new System.Drawing.Point(15, 310);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(42, 15);
            this.lblEstado.TabIndex = 12;
            this.lblEstado.Text = "Estado";
            //
            // chkEstado
            //
            this.chkEstado.AutoSize = true;
            this.chkEstado.Checked = true;
            this.chkEstado.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEstado.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkEstado.ForeColor = System.Drawing.Color.Black;
            this.chkEstado.Location = new System.Drawing.Point(125, 309);
            this.chkEstado.Name = "chkEstado";
            this.chkEstado.Size = new System.Drawing.Size(60, 19);
            this.chkEstado.TabIndex = 13;
            this.chkEstado.Text = "Activo";
            this.chkEstado.UseVisualStyleBackColor = true;
            //
            // grpLista
            //
            this.grpLista.Controls.Add(this.dgvPlanes);
            this.grpLista.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpLista.ForeColor = System.Drawing.Color.FromArgb(31, 78, 121);
            this.grpLista.Location = new System.Drawing.Point(335, 85);
            this.grpLista.Name = "grpLista";
            this.grpLista.Size = new System.Drawing.Size(605, 390);
            this.grpLista.TabIndex = 2;
            this.grpLista.TabStop = false;
            this.grpLista.Text = "Lista de planes de mantenimiento";
            //
            // dgvPlanes
            //
            this.dgvPlanes.AllowUserToAddRows = false;
            this.dgvPlanes.AllowUserToDeleteRows = false;
            this.dgvPlanes.AutoGenerateColumns = false;
            this.dgvPlanes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPlanes.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(31, 78, 121);
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(31, 78, 121);
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgvPlanes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPlanes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlanes.EnableHeadersVisualStyles = false;
            this.dgvPlanes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPlanID,
            this.colEquipoID,
            this.colPrioridad,
            this.colFechaInicio,
            this.colFechaFin,
            this.colTiempoParada,
            this.colEstado});
            this.dgvPlanes.Location = new System.Drawing.Point(12, 25);
            this.dgvPlanes.MultiSelect = false;
            this.dgvPlanes.Name = "dgvPlanes";
            this.dgvPlanes.ReadOnly = true;
            this.dgvPlanes.RowHeadersVisible = false;
            this.dgvPlanes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPlanes.Size = new System.Drawing.Size(581, 353);
            this.dgvPlanes.TabIndex = 0;
            this.dgvPlanes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPlanes_CellClick);
            //
            // colPlanID
            //
            this.colPlanID.DataPropertyName = "PlanDeMantenimientoID";
            this.colPlanID.FillWeight = 50F;
            this.colPlanID.HeaderText = "ID";
            this.colPlanID.Name = "colPlanID";
            this.colPlanID.ReadOnly = true;
            //
            // colEquipoID
            //
            this.colEquipoID.DataPropertyName = "EquipoID";
            this.colEquipoID.FillWeight = 60F;
            this.colEquipoID.HeaderText = "Equipo";
            this.colEquipoID.Name = "colEquipoID";
            this.colEquipoID.ReadOnly = true;
            //
            // colPrioridad
            //
            this.colPrioridad.DataPropertyName = "Prioridad";
            this.colPrioridad.HeaderText = "Prioridad";
            this.colPrioridad.Name = "colPrioridad";
            this.colPrioridad.ReadOnly = true;
            //
            // colFechaInicio
            //
            this.colFechaInicio.DataPropertyName = "FechaInicio";
            dataGridViewCellStyle2.Format = "dd/MM/yyyy";
            this.colFechaInicio.DefaultCellStyle = dataGridViewCellStyle2;
            this.colFechaInicio.HeaderText = "Fecha inicio";
            this.colFechaInicio.Name = "colFechaInicio";
            this.colFechaInicio.ReadOnly = true;
            //
            // colFechaFin
            //
            this.colFechaFin.DataPropertyName = "FechaFin";
            dataGridViewCellStyle3.Format = "dd/MM/yyyy";
            this.colFechaFin.DefaultCellStyle = dataGridViewCellStyle3;
            this.colFechaFin.HeaderText = "Fecha fin";
            this.colFechaFin.Name = "colFechaFin";
            this.colFechaFin.ReadOnly = true;
            //
            // colTiempoParada
            //
            this.colTiempoParada.DataPropertyName = "TiempoParada";
            this.colTiempoParada.HeaderText = "Parada (h)";
            this.colTiempoParada.Name = "colTiempoParada";
            this.colTiempoParada.ReadOnly = true;
            //
            // colEstado
            //
            this.colEstado.DataPropertyName = "Estado";
            this.colEstado.FillWeight = 60F;
            this.colEstado.HeaderText = "Activo";
            this.colEstado.Name = "colEstado";
            this.colEstado.ReadOnly = true;
            //
            // pnlBotones
            //
            this.pnlBotones.Controls.Add(this.btnSalir);
            this.pnlBotones.Controls.Add(this.btnLimpiar);
            this.pnlBotones.Controls.Add(this.btnDeshabilitar);
            this.pnlBotones.Controls.Add(this.btnEditar);
            this.pnlBotones.Controls.Add(this.btnGuardar);
            this.pnlBotones.Controls.Add(this.btnNuevo);
            this.pnlBotones.Location = new System.Drawing.Point(20, 490);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Size = new System.Drawing.Size(920, 50);
            this.pnlBotones.TabIndex = 3;
            //
            // btnNuevo
            //
            this.btnNuevo.BackColor = System.Drawing.Color.FromArgb(46, 125, 50);
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.FlatAppearance.BorderSize = 0;
            this.btnNuevo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnNuevo.ForeColor = System.Drawing.Color.White;
            this.btnNuevo.Location = new System.Drawing.Point(0, 7);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(140, 36);
            this.btnNuevo.TabIndex = 0;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            this.btnNuevo.UseVisualStyleBackColor = false;
            //
            // btnGuardar
            //
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(31, 78, 121);
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(150, 7);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(140, 36);
            this.btnGuardar.TabIndex = 1;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            this.btnGuardar.UseVisualStyleBackColor = false;
            //
            // btnEditar
            //
            this.btnEditar.BackColor = System.Drawing.Color.FromArgb(239, 108, 0);
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.FlatAppearance.BorderSize = 0;
            this.btnEditar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.Location = new System.Drawing.Point(300, 7);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(140, 36);
            this.btnEditar.TabIndex = 2;
            this.btnEditar.Text = "Editar";
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            this.btnEditar.UseVisualStyleBackColor = false;
            //
            // btnDeshabilitar
            //
            this.btnDeshabilitar.BackColor = System.Drawing.Color.FromArgb(198, 40, 40);
            this.btnDeshabilitar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeshabilitar.FlatAppearance.BorderSize = 0;
            this.btnDeshabilitar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnDeshabilitar.ForeColor = System.Drawing.Color.White;
            this.btnDeshabilitar.Location = new System.Drawing.Point(450, 7);
            this.btnDeshabilitar.Name = "btnDeshabilitar";
            this.btnDeshabilitar.Size = new System.Drawing.Size(140, 36);
            this.btnDeshabilitar.TabIndex = 3;
            this.btnDeshabilitar.Text = "Deshabilitar";
            this.btnDeshabilitar.Click += new System.EventHandler(this.btnDeshabilitar_Click);
            this.btnDeshabilitar.UseVisualStyleBackColor = false;
            //
            // btnLimpiar
            //
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(96, 125, 139);
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Location = new System.Drawing.Point(600, 7);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(140, 36);
            this.btnLimpiar.TabIndex = 4;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            this.btnLimpiar.UseVisualStyleBackColor = false;
            //
            // btnSalir
            //
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(66, 66, 66);
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Location = new System.Drawing.Point(780, 7);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(140, 36);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "Salir";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            this.btnSalir.UseVisualStyleBackColor = false;
            //
            // Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.ClientSize = new System.Drawing.Size(960, 560);
            this.Controls.Add(this.pnlBotones);
            this.Controls.Add(this.grpLista);
            this.Controls.Add(this.grpDatos);
            this.Controls.Add(this.pnlTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Acciones Preventivas - Plan de Mantenimiento";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlTitulo.ResumeLayout(false);
            this.pnlTitulo.PerformLayout();
            this.grpDatos.ResumeLayout(false);
            this.grpDatos.PerformLayout();
            this.grpLista.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanes)).EndInit();
            this.pnlBotones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.GroupBox grpDatos;
        private System.Windows.Forms.CheckBox chkEstado;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.TextBox txtTiempoParada;
        private System.Windows.Forms.Label lblTiempoParada;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.Label lblFechaFin;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.ComboBox cboPrioridad;
        private System.Windows.Forms.Label lblPrioridad;
        private System.Windows.Forms.TextBox txtEquipoID;
        private System.Windows.Forms.Label lblEquipoID;
        private System.Windows.Forms.TextBox txtPlanID;
        private System.Windows.Forms.Label lblPlanID;
        private System.Windows.Forms.GroupBox grpLista;
        private System.Windows.Forms.DataGridView dgvPlanes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPlanID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEquipoID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrioridad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaFin;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTiempoParada;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colEstado;
        private System.Windows.Forms.Panel pnlBotones;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnDeshabilitar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnNuevo;
    }
}
