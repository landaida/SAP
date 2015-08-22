namespace SAP.forms.movimientos
{
    partial class frmCotizacion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbCliente = new System.Windows.Forms.ComboBox();
            this.txtFechaDocumento = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.txtFechaLanzamiento = new System.Windows.Forms.DateTimePicker();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.txtObservacion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbVendedor = new System.Windows.Forms.ComboBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageContenido = new System.Windows.Forms.TabPage();
            this.dgvLines = new System.Windows.Forms.DataGridView();
            this.colItemNro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescripcion = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecioUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPorcentajeDescuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIndicadorImpuesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPageLogistica = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLines)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31.27148F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 68.72852F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(731, 417);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbCliente);
            this.panel1.Controls.Add(this.txtFechaDocumento);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtFechaLanzamiento);
            this.panel1.Controls.Add(this.txtStatus);
            this.panel1.Controls.Add(this.txtId);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(725, 85);
            this.panel1.TabIndex = 1;
            // 
            // cmbCliente
            // 
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.Location = new System.Drawing.Point(59, 33);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(176, 21);
            this.cmbCliente.TabIndex = 10;
            // 
            // txtFechaDocumento
            // 
            this.txtFechaDocumento.Location = new System.Drawing.Point(436, 35);
            this.txtFechaDocumento.Name = "txtFechaDocumento";
            this.txtFechaDocumento.Size = new System.Drawing.Size(149, 20);
            this.txtFechaDocumento.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(323, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Fecha del Documento";
            // 
            // txtFechaLanzamiento
            // 
            this.txtFechaLanzamiento.Location = new System.Drawing.Point(436, 1);
            this.txtFechaLanzamiento.Name = "txtFechaLanzamiento";
            this.txtFechaLanzamiento.Size = new System.Drawing.Size(149, 20);
            this.txtFechaLanzamiento.TabIndex = 7;
            // 
            // txtStatus
            // 
            this.txtStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtStatus.Location = new System.Drawing.Point(366, 61);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(149, 20);
            this.txtStatus.TabIndex = 5;
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(59, 4);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(121, 20);
            this.txtId.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Cliente";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(323, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Fecha del lanzamiento";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(323, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Status";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "N°";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtObservacion);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.cmbVendedor);
            this.panel2.Controls.Add(this.btnCancelar);
            this.panel2.Controls.Add(this.btnAdicionar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 294);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(725, 120);
            this.panel2.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(519, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Observación";
            // 
            // txtObservacion
            // 
            this.txtObservacion.Location = new System.Drawing.Point(522, 43);
            this.txtObservacion.Multiline = true;
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.Size = new System.Drawing.Size(194, 68);
            this.txtObservacion.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Vendedor";
            // 
            // cmbVendedor
            // 
            this.cmbVendedor.FormattingEnabled = true;
            this.cmbVendedor.Location = new System.Drawing.Point(72, 8);
            this.cmbVendedor.Name = "cmbVendedor";
            this.cmbVendedor.Size = new System.Drawing.Size(121, 21);
            this.cmbVendedor.TabIndex = 2;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(94, 88);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Location = new System.Drawing.Point(13, 88);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(75, 23);
            this.btnAdicionar.TabIndex = 0;
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tabControl1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 94);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(725, 194);
            this.panel3.TabIndex = 3;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageContenido);
            this.tabControl1.Controls.Add(this.tabPageLogistica);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(725, 194);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageContenido
            // 
            this.tabPageContenido.Controls.Add(this.dgvLines);
            this.tabPageContenido.Location = new System.Drawing.Point(4, 22);
            this.tabPageContenido.Name = "tabPageContenido";
            this.tabPageContenido.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageContenido.Size = new System.Drawing.Size(717, 168);
            this.tabPageContenido.TabIndex = 0;
            this.tabPageContenido.Text = "Conenido";
            this.tabPageContenido.UseVisualStyleBackColor = true;
            // 
            // dgvLines
            // 
            this.dgvLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLines.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colItemNro,
            this.colDescripcion,
            this.colCantidad,
            this.colPrecioUnitario,
            this.colPorcentajeDescuento,
            this.colIndicadorImpuesto});
            this.dgvLines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLines.Location = new System.Drawing.Point(3, 3);
            this.dgvLines.MultiSelect = false;
            this.dgvLines.Name = "dgvLines";
            this.dgvLines.Size = new System.Drawing.Size(711, 162);
            this.dgvLines.TabIndex = 0;
            this.dgvLines.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLines_CellEndEdit);
            this.dgvLines.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLines_RowValidated);
            this.dgvLines.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvLines_KeyUp);
            // 
            // colItemNro
            // 
            this.colItemNro.HeaderText = "N° Item";
            this.colItemNro.Name = "colItemNro";
            this.colItemNro.Width = 50;
            // 
            // colDescripcion
            // 
            this.colDescripcion.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colDescripcion.HeaderText = "Descripción";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colDescripcion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colDescripcion.Width = 130;
            // 
            // colCantidad
            // 
            this.colCantidad.HeaderText = "Cantidad";
            this.colCantidad.Name = "colCantidad";
            // 
            // colPrecioUnitario
            // 
            this.colPrecioUnitario.HeaderText = "Precio unitario";
            this.colPrecioUnitario.Name = "colPrecioUnitario";
            // 
            // colPorcentajeDescuento
            // 
            this.colPorcentajeDescuento.HeaderText = "% de descuento";
            this.colPorcentajeDescuento.Name = "colPorcentajeDescuento";
            // 
            // colIndicadorImpuesto
            // 
            this.colIndicadorImpuesto.HeaderText = "Indicador de impuestos";
            this.colIndicadorImpuesto.Name = "colIndicadorImpuesto";
            // 
            // tabPageLogistica
            // 
            this.tabPageLogistica.Location = new System.Drawing.Point(4, 22);
            this.tabPageLogistica.Name = "tabPageLogistica";
            this.tabPageLogistica.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLogistica.Size = new System.Drawing.Size(717, 168);
            this.tabPageLogistica.TabIndex = 1;
            this.tabPageLogistica.Text = "Logística";
            this.tabPageLogistica.UseVisualStyleBackColor = true;
            // 
            // frmCotizacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 417);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmCotizacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Presupuesto";
            this.Load += new System.EventHandler(this.frmCotizacion_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPageContenido.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLines)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker txtFechaLanzamiento;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageContenido;
        private System.Windows.Forms.TabPage tabPageLogistica;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtObservacion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbVendedor;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DateTimePicker txtFechaDocumento;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgvLines;
        private System.Windows.Forms.ComboBox cmbCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemNro;
        private System.Windows.Forms.DataGridViewComboBoxColumn colDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecioUnitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPorcentajeDescuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIndicadorImpuesto;
    }
}