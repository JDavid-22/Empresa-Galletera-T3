namespace T3_EmpresaGalletera
{
    partial class frmOrdenPedido
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtCodigo = new TextBox();
            dtpFecha = new DateTimePicker();
            cboEstado = new ComboBox();
            txtObservacion = new TextBox();
            cboComponente = new ComboBox();
            nudCantidad = new NumericUpDown();
            btnAgregar = new Button();
            btnQuitar = new Button();
            dgvDetalle = new DataGridView();
            btnNuevo = new Button();
            btnGuardar = new Button();
            btnInhabilitar = new Button();
            chkInhabilitados = new CheckBox();
            dgvPedidos = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetalle).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPedidos).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 17);
            label1.Name = "label1";
            label1.Size = new Size(61, 20);
            label1.TabIndex = 0;
            label1.Text = "Código:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(333, 18);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 1;
            label2.Text = "Fecha:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(721, 18);
            label3.Name = "label3";
            label3.Size = new Size(57, 20);
            label3.TabIndex = 2;
            label3.Text = "Estado:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(24, 72);
            label4.Name = "label4";
            label4.Size = new Size(94, 20);
            label4.TabIndex = 3;
            label4.Text = "Observación:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(24, 125);
            label5.Name = "label5";
            label5.Size = new Size(98, 20);
            label5.TabIndex = 4;
            label5.Text = "Componente:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(609, 125);
            label6.Name = "label6";
            label6.Size = new Size(42, 20);
            label6.TabIndex = 5;
            label6.Text = "Cant:";
            // 
            // txtCodigo
            // 
            txtCodigo.Location = new Point(128, 15);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(153, 27);
            txtCodigo.TabIndex = 6;
            // 
            // dtpFecha
            // 
            dtpFecha.Location = new Point(389, 17);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(299, 27);
            dtpFecha.TabIndex = 7;
            // 
            // cboEstado
            // 
            cboEstado.FormattingEnabled = true;
            cboEstado.Location = new Point(784, 14);
            cboEstado.Name = "cboEstado";
            cboEstado.Size = new Size(178, 28);
            cboEstado.TabIndex = 8;
            // 
            // txtObservacion
            // 
            txtObservacion.Location = new Point(128, 69);
            txtObservacion.Name = "txtObservacion";
            txtObservacion.Size = new Size(834, 27);
            txtObservacion.TabIndex = 9;
            // 
            // cboComponente
            // 
            cboComponente.FormattingEnabled = true;
            cboComponente.Location = new Point(128, 121);
            cboComponente.Name = "cboComponente";
            cboComponente.Size = new Size(412, 28);
            cboComponente.TabIndex = 10;
            // 
            // nudCantidad
            // 
            nudCantidad.Location = new Point(657, 122);
            nudCantidad.Name = "nudCantidad";
            nudCantidad.Size = new Size(66, 27);
            nudCantidad.TabIndex = 11;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(756, 120);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(94, 29);
            btnAgregar.TabIndex = 12;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            // 
            // btnQuitar
            // 
            btnQuitar.Location = new Point(868, 121);
            btnQuitar.Name = "btnQuitar";
            btnQuitar.Size = new Size(94, 29);
            btnQuitar.TabIndex = 13;
            btnQuitar.Text = "Quitar";
            btnQuitar.UseVisualStyleBackColor = true;
            // 
            // dgvDetalle
            // 
            dgvDetalle.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalle.Location = new Point(24, 178);
            dgvDetalle.Name = "dgvDetalle";
            dgvDetalle.RowHeadersWidth = 51;
            dgvDetalle.Size = new Size(938, 147);
            dgvDetalle.TabIndex = 14;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(24, 347);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(94, 29);
            btnNuevo.TabIndex = 15;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(152, 347);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(94, 29);
            btnGuardar.TabIndex = 16;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btnInhabilitar
            // 
            btnInhabilitar.Location = new Point(279, 347);
            btnInhabilitar.Name = "btnInhabilitar";
            btnInhabilitar.Size = new Size(94, 29);
            btnInhabilitar.TabIndex = 17;
            btnInhabilitar.Text = "Inhabilitar";
            btnInhabilitar.UseVisualStyleBackColor = true;
            // 
            // chkInhabilitados
            // 
            chkInhabilitados.AutoSize = true;
            chkInhabilitados.Location = new Point(791, 350);
            chkInhabilitados.Name = "chkInhabilitados";
            chkInhabilitados.Size = new Size(171, 24);
            chkInhabilitados.TabIndex = 18;
            chkInhabilitados.Text = "Mostrar inhabilitadas";
            chkInhabilitados.UseVisualStyleBackColor = true;
            // 
            // dgvPedidos
            // 
            dgvPedidos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPedidos.Location = new Point(24, 402);
            dgvPedidos.Name = "dgvPedidos";
            dgvPedidos.RowHeadersWidth = 51;
            dgvPedidos.Size = new Size(938, 262);
            dgvPedidos.TabIndex = 19;
            // 
            // frmOrdenPedido
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(998, 694);
            Controls.Add(dgvPedidos);
            Controls.Add(chkInhabilitados);
            Controls.Add(btnInhabilitar);
            Controls.Add(btnGuardar);
            Controls.Add(btnNuevo);
            Controls.Add(dgvDetalle);
            Controls.Add(btnQuitar);
            Controls.Add(btnAgregar);
            Controls.Add(nudCantidad);
            Controls.Add(cboComponente);
            Controls.Add(txtObservacion);
            Controls.Add(cboEstado);
            Controls.Add(dtpFecha);
            Controls.Add(txtCodigo);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmOrdenPedido";
            Text = "Orden de Pedido";
            ((System.ComponentModel.ISupportInitialize)nudCantidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetalle).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPedidos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox txtCodigo;
        private DateTimePicker dtpFecha;
        private ComboBox cboEstado;
        private TextBox txtObservacion;
        private ComboBox cboComponente;
        private NumericUpDown nudCantidad;
        private Button btnAgregar;
        private Button btnQuitar;
        private DataGridView dgvDetalle;
        private Button btnNuevo;
        private Button btnGuardar;
        private Button btnInhabilitar;
        private CheckBox chkInhabilitados;
        private DataGridView dgvPedidos;
    }
}
