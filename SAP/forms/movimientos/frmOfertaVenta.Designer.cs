namespace SAP.forms.movimientos
{
    partial class frmOfertaVenta
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbStatus = new DevExpress.XtraEditors.LookUpEdit();
            this.cmbCliente = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtFechaDocumento = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.txtFechaLanzamiento = new System.Windows.Forms.DateTimePicker();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtTotal = new DevExpress.XtraEditors.TextEdit();
            this.txtImpuesto = new DevExpress.XtraEditors.TextEdit();
            this.txtDescuento = new DevExpress.XtraEditors.TextEdit();
            this.txtTotalGravada = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cmbVendedor = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.label6 = new System.Windows.Forms.Label();
            this.txtObservacion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageContenido = new System.Windows.Forms.TabPage();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescripcion1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cmbProduto = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repositoryItemSearchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCantidad1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrecioUnitario1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPorcentajeDescuento1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIndicadorImpuesto1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrecioUnitarioGravada = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalGravada = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabPageLogistica = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCliente.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtImpuesto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescuento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalGravada.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbVendedor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.panel3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProduto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31.27148F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 68.72852F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(731, 544);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbStatus);
            this.panel1.Controls.Add(this.cmbCliente);
            this.panel1.Controls.Add(this.txtFechaDocumento);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtFechaLanzamiento);
            this.panel1.Controls.Add(this.txtId);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(725, 114);
            this.panel1.TabIndex = 1;
            // 
            // cmbStatus
            // 
            this.cmbStatus.Enabled = false;
            this.cmbStatus.Location = new System.Drawing.Point(366, 61);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbStatus.Size = new System.Drawing.Size(105, 20);
            this.cmbStatus.TabIndex = 13;
            // 
            // cmbCliente
            // 
            this.cmbCliente.EditValue = " ";
            this.cmbCliente.Location = new System.Drawing.Point(59, 38);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbCliente.Properties.View = this.searchLookUpEdit1View;
            this.cmbCliente.Size = new System.Drawing.Size(121, 20);
            this.cmbCliente.TabIndex = 12;
            this.cmbCliente.EditValueChanged += new System.EventHandler(this.cmbCliente_EditValueChanged);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
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
            this.panel2.Controls.Add(this.txtTotal);
            this.panel2.Controls.Add(this.txtImpuesto);
            this.panel2.Controls.Add(this.txtDescuento);
            this.panel2.Controls.Add(this.txtTotalGravada);
            this.panel2.Controls.Add(this.labelControl4);
            this.panel2.Controls.Add(this.labelControl3);
            this.panel2.Controls.Add(this.labelControl2);
            this.panel2.Controls.Add(this.labelControl1);
            this.panel2.Controls.Add(this.cmbVendedor);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtObservacion);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.btnCancelar);
            this.panel2.Controls.Add(this.btnGuardar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 386);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(725, 155);
            this.panel2.TabIndex = 2;
            // 
            // txtTotal
            // 
            this.txtTotal.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtTotal.Enabled = false;
            this.txtTotal.Location = new System.Drawing.Point(616, 88);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Properties.DisplayFormat.FormatString = "n2";
            this.txtTotal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTotal.Properties.Mask.EditMask = "n2";
            this.txtTotal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTotal.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtTotal.Size = new System.Drawing.Size(100, 20);
            this.txtTotal.TabIndex = 25;
            // 
            // txtImpuesto
            // 
            this.txtImpuesto.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtImpuesto.Enabled = false;
            this.txtImpuesto.Location = new System.Drawing.Point(616, 62);
            this.txtImpuesto.Name = "txtImpuesto";
            this.txtImpuesto.Properties.DisplayFormat.FormatString = "n2";
            this.txtImpuesto.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtImpuesto.Properties.Mask.EditMask = "n2";
            this.txtImpuesto.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtImpuesto.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtImpuesto.Size = new System.Drawing.Size(100, 20);
            this.txtImpuesto.TabIndex = 24;
            // 
            // txtDescuento
            // 
            this.txtDescuento.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtDescuento.Enabled = false;
            this.txtDescuento.Location = new System.Drawing.Point(616, 34);
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.Properties.DisplayFormat.FormatString = "n2";
            this.txtDescuento.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtDescuento.Properties.Mask.EditMask = "n2";
            this.txtDescuento.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtDescuento.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtDescuento.Size = new System.Drawing.Size(100, 20);
            this.txtDescuento.TabIndex = 23;
            // 
            // txtTotalGravada
            // 
            this.txtTotalGravada.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtTotalGravada.Enabled = false;
            this.txtTotalGravada.Location = new System.Drawing.Point(616, 8);
            this.txtTotalGravada.Name = "txtTotalGravada";
            this.txtTotalGravada.Properties.DisplayFormat.FormatString = "n2";
            this.txtTotalGravada.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTotalGravada.Properties.EditFormat.FormatString = "n2";
            this.txtTotalGravada.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTotalGravada.Properties.Mask.EditMask = "n2";
            this.txtTotalGravada.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTotalGravada.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtTotalGravada.Size = new System.Drawing.Size(100, 20);
            this.txtTotalGravada.TabIndex = 22;
            // 
            // labelControl4
            // 
            this.labelControl4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelControl4.Location = new System.Drawing.Point(488, 91);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(97, 13);
            this.labelControl4.TabIndex = 20;
            this.labelControl4.Text = "Total del documento";
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelControl3.Location = new System.Drawing.Point(488, 65);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(45, 13);
            this.labelControl3.TabIndex = 18;
            this.labelControl3.Text = "Impuesto";
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelControl2.Location = new System.Drawing.Point(488, 34);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(51, 13);
            this.labelControl2.TabIndex = 16;
            this.labelControl2.Text = "Descuento";
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelControl1.Location = new System.Drawing.Point(488, 11);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(124, 13);
            this.labelControl1.TabIndex = 14;
            this.labelControl1.Text = "Total antes del descuento";
            // 
            // cmbVendedor
            // 
            this.cmbVendedor.EditValue = " ";
            this.cmbVendedor.Location = new System.Drawing.Point(72, 8);
            this.cmbVendedor.Name = "cmbVendedor";
            this.cmbVendedor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbVendedor.Properties.View = this.gridView1;
            this.cmbVendedor.Size = new System.Drawing.Size(121, 20);
            this.cmbVendedor.TabIndex = 13;
            // 
            // gridView1
            // 
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(10, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Observación";
            // 
            // txtObservacion
            // 
            this.txtObservacion.Location = new System.Drawing.Point(13, 78);
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
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnCancelar.Location = new System.Drawing.Point(641, 123);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnGuardar.Location = new System.Drawing.Point(560, 123);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tabControl1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 123);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(725, 257);
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
            this.tabControl1.Size = new System.Drawing.Size(725, 257);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageContenido
            // 
            this.tabPageContenido.Controls.Add(this.gridControl1);
            this.tabPageContenido.Location = new System.Drawing.Point(4, 22);
            this.tabPageContenido.Name = "tabPageContenido";
            this.tabPageContenido.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageContenido.Size = new System.Drawing.Size(717, 231);
            this.tabPageContenido.TabIndex = 0;
            this.tabPageContenido.Text = "Conenido";
            this.tabPageContenido.UseVisualStyleBackColor = true;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Top;
            gridLevelNode1.RelationName = "Level1";
            this.gridControl1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControl1.Location = new System.Drawing.Point(3, 3);
            this.gridControl1.MainView = this.gridView2;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cmbProduto});
            this.gridControl1.Size = new System.Drawing.Size(711, 185);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCodigo,
            this.colDescripcion1,
            this.colCantidad1,
            this.colPrecioUnitario1,
            this.colPorcentajeDescuento1,
            this.colIndicadorImpuesto1,
            this.colPrecioUnitarioGravada,
            this.colTotalGravada});
            this.gridView2.GridControl = this.gridControl1;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsCustomization.AllowColumnMoving = false;
            this.gridView2.OptionsCustomization.AllowFilter = false;
            this.gridView2.OptionsCustomization.AllowGroup = false;
            this.gridView2.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView2.OptionsDetail.EnableMasterViewMode = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView2_CellValueChanged);
            // 
            // colCodigo
            // 
            this.colCodigo.Caption = "Código";
            this.colCodigo.FieldName = "ProductoId";
            this.colCodigo.Name = "colCodigo";
            this.colCodigo.Visible = true;
            this.colCodigo.VisibleIndex = 0;
            // 
            // colDescripcion1
            // 
            this.colDescripcion1.Caption = "Descripción";
            this.colDescripcion1.ColumnEdit = this.cmbProduto;
            this.colDescripcion1.FieldName = "Producto";
            this.colDescripcion1.Name = "colDescripcion1";
            this.colDescripcion1.Visible = true;
            this.colDescripcion1.VisibleIndex = 1;
            // 
            // cmbProduto
            // 
            this.cmbProduto.AutoHeight = false;
            this.cmbProduto.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbProduto.Name = "cmbProduto";
            this.cmbProduto.NullText = "";
            this.cmbProduto.View = this.repositoryItemSearchLookUpEdit1View;
            // 
            // repositoryItemSearchLookUpEdit1View
            // 
            this.repositoryItemSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemSearchLookUpEdit1View.Name = "repositoryItemSearchLookUpEdit1View";
            this.repositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // colCantidad1
            // 
            this.colCantidad1.Caption = "Cantidad";
            this.colCantidad1.FieldName = "Cantidad";
            this.colCantidad1.Name = "colCantidad1";
            this.colCantidad1.Visible = true;
            this.colCantidad1.VisibleIndex = 4;
            // 
            // colPrecioUnitario1
            // 
            this.colPrecioUnitario1.Caption = "Precio unitario";
            this.colPrecioUnitario1.FieldName = "PrecioUnitario";
            this.colPrecioUnitario1.Name = "colPrecioUnitario1";
            this.colPrecioUnitario1.Visible = true;
            this.colPrecioUnitario1.VisibleIndex = 2;
            // 
            // colPorcentajeDescuento1
            // 
            this.colPorcentajeDescuento1.Caption = "% de descuento";
            this.colPorcentajeDescuento1.FieldName = "Descuento";
            this.colPorcentajeDescuento1.Name = "colPorcentajeDescuento1";
            this.colPorcentajeDescuento1.OptionsColumn.AllowEdit = false;
            this.colPorcentajeDescuento1.OptionsColumn.ReadOnly = true;
            this.colPorcentajeDescuento1.Visible = true;
            this.colPorcentajeDescuento1.VisibleIndex = 5;
            // 
            // colIndicadorImpuesto1
            // 
            this.colIndicadorImpuesto1.Caption = "Indicador de impuestos";
            this.colIndicadorImpuesto1.FieldName = "IndicadorImpuesto";
            this.colIndicadorImpuesto1.Name = "colIndicadorImpuesto1";
            this.colIndicadorImpuesto1.OptionsColumn.AllowEdit = false;
            this.colIndicadorImpuesto1.OptionsColumn.ReadOnly = true;
            this.colIndicadorImpuesto1.Visible = true;
            this.colIndicadorImpuesto1.VisibleIndex = 6;
            // 
            // colPrecioUnitarioGravada
            // 
            this.colPrecioUnitarioGravada.Caption = "Sin IVA";
            this.colPrecioUnitarioGravada.DisplayFormat.FormatString = "n2";
            this.colPrecioUnitarioGravada.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPrecioUnitarioGravada.FieldName = "PrecioUnitarioGravada";
            this.colPrecioUnitarioGravada.Name = "colPrecioUnitarioGravada";
            this.colPrecioUnitarioGravada.OptionsColumn.AllowEdit = false;
            this.colPrecioUnitarioGravada.OptionsColumn.ReadOnly = true;
            this.colPrecioUnitarioGravada.Visible = true;
            this.colPrecioUnitarioGravada.VisibleIndex = 3;
            // 
            // colTotalGravada
            // 
            this.colTotalGravada.Caption = "Total";
            this.colTotalGravada.DisplayFormat.FormatString = "n2";
            this.colTotalGravada.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalGravada.FieldName = "TotalGravada";
            this.colTotalGravada.Name = "colTotalGravada";
            this.colTotalGravada.OptionsColumn.AllowEdit = false;
            this.colTotalGravada.OptionsColumn.ReadOnly = true;
            this.colTotalGravada.Visible = true;
            this.colTotalGravada.VisibleIndex = 7;
            // 
            // tabPageLogistica
            // 
            this.tabPageLogistica.Location = new System.Drawing.Point(4, 22);
            this.tabPageLogistica.Name = "tabPageLogistica";
            this.tabPageLogistica.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLogistica.Size = new System.Drawing.Size(717, 231);
            this.tabPageLogistica.TabIndex = 1;
            this.tabPageLogistica.Text = "Logística";
            this.tabPageLogistica.UseVisualStyleBackColor = true;
            // 
            // frmOfertaVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 544);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmOfertaVenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Oferta de ventas";
            this.Load += new System.EventHandler(this.frmCotizacion_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCliente.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtImpuesto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescuento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalGravada.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbVendedor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPageContenido.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProduto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker txtFechaLanzamiento;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageContenido;
        private System.Windows.Forms.TabPage tabPageLogistica;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtObservacion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DateTimePicker txtFechaDocumento;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraEditors.SearchLookUpEdit cmbCliente;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraEditors.SearchLookUpEdit cmbVendedor;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.LookUpEdit cmbStatus;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn colCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn colDescripcion1;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit cmbProduto;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemSearchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn colCantidad1;
        private DevExpress.XtraGrid.Columns.GridColumn colPrecioUnitario1;
        private DevExpress.XtraGrid.Columns.GridColumn colPorcentajeDescuento1;
        private DevExpress.XtraGrid.Columns.GridColumn colIndicadorImpuesto1;
        private DevExpress.XtraGrid.Columns.GridColumn colPrecioUnitarioGravada;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalGravada;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtTotal;
        private DevExpress.XtraEditors.TextEdit txtImpuesto;
        private DevExpress.XtraEditors.TextEdit txtDescuento;
        private DevExpress.XtraEditors.TextEdit txtTotalGravada;
    }
}