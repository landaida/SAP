namespace SAP
{
    partial class frmPrincipal
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.panelStatusBar = new System.Windows.Forms.Panel();
            this.btnConexao = new DevExpress.XtraEditors.SimpleButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.menuSuperior = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pedidosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ordemDeVentaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.processToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.datasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modulesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelSecondMenu = new System.Windows.Forms.Panel();
            this.btnMenuPrint = new System.Windows.Forms.Button();
            this.btonMenuVis = new System.Windows.Forms.Button();
            this.timerVerificaConexao = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel.SuspendLayout();
            this.panelStatusBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelMenu.SuspendLayout();
            this.menuSuperior.SuspendLayout();
            this.panelSecondMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.panelStatusBar, 0, 3);
            this.tableLayoutPanel.Controls.Add(this.panelBottom, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.panelMenu, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.panelSecondMenu, 0, 1);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 4;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(895, 341);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // panelStatusBar
            // 
            this.panelStatusBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelStatusBar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelStatusBar.Controls.Add(this.btnConexao);
            this.panelStatusBar.Controls.Add(this.pictureBox1);
            this.panelStatusBar.Controls.Add(this.statusStrip1);
            this.panelStatusBar.Location = new System.Drawing.Point(3, 304);
            this.panelStatusBar.Name = "panelStatusBar";
            this.panelStatusBar.Size = new System.Drawing.Size(889, 34);
            this.panelStatusBar.TabIndex = 6;
            // 
            // btnConexao
            // 
            this.btnConexao.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnConexao.ImageIndex = 1;
            this.btnConexao.ImageList = this.imageList1;
            this.btnConexao.Location = new System.Drawing.Point(-2, -2);
            this.btnConexao.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnConexao.Name = "btnConexao";
            this.btnConexao.Size = new System.Drawing.Size(28, 34);
            this.btnConexao.TabIndex = 0;
            this.btnConexao.ToolTip = "No conectado a SAP";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "trafficlight_green-128.png");
            this.imageList1.Images.SetKeyName(1, "trafficlight_red-128.png");
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.DarkCyan;
            this.pictureBox1.Location = new System.Drawing.Point(785, -6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 43);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.Location = new System.Drawing.Point(0, 8);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(782, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // panelBottom
            // 
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBottom.Location = new System.Drawing.Point(3, 78);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(889, 220);
            this.panelBottom.TabIndex = 0;
            // 
            // panelMenu
            // 
            this.panelMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMenu.Controls.Add(this.menuSuperior);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMenu.Location = new System.Drawing.Point(3, 3);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(889, 24);
            this.panelMenu.TabIndex = 1;
            // 
            // menuSuperior
            // 
            this.menuSuperior.BackColor = System.Drawing.Color.Gray;
            this.menuSuperior.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuSuperior.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.processToolStripMenuItem,
            this.visionToolStripMenuItem,
            this.datasToolStripMenuItem,
            this.modulesToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.sobreToolStripMenuItem});
            this.menuSuperior.Location = new System.Drawing.Point(0, 0);
            this.menuSuperior.Name = "menuSuperior";
            this.menuSuperior.Padding = new System.Windows.Forms.Padding(6, 0, 0, 2);
            this.menuSuperior.Size = new System.Drawing.Size(887, 22);
            this.menuSuperior.TabIndex = 2;
            this.menuSuperior.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pedidosToolStripMenuItem});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.fileToolStripMenuItem.Text = "Ventas";
            // 
            // pedidosToolStripMenuItem
            // 
            this.pedidosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ordemDeVentaToolStripMenuItem});
            this.pedidosToolStripMenuItem.Name = "pedidosToolStripMenuItem";
            this.pedidosToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.pedidosToolStripMenuItem.Text = "Ventas";
            // 
            // ordemDeVentaToolStripMenuItem
            // 
            this.ordemDeVentaToolStripMenuItem.Name = "ordemDeVentaToolStripMenuItem";
            this.ordemDeVentaToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.ordemDeVentaToolStripMenuItem.Text = "Oferta de ventas";
            this.ordemDeVentaToolStripMenuItem.Click += new System.EventHandler(this.ordemDeVentaToolStripMenuItem_Click);
            // 
            // processToolStripMenuItem
            // 
            this.processToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.processToolStripMenuItem.Name = "processToolStripMenuItem";
            this.processToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.processToolStripMenuItem.Text = "Process";
            // 
            // visionToolStripMenuItem
            // 
            this.visionToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.visionToolStripMenuItem.Name = "visionToolStripMenuItem";
            this.visionToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.visionToolStripMenuItem.Text = "Vision";
            // 
            // datasToolStripMenuItem
            // 
            this.datasToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.datasToolStripMenuItem.Name = "datasToolStripMenuItem";
            this.datasToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.datasToolStripMenuItem.Text = "Datas";
            // 
            // modulesToolStripMenuItem
            // 
            this.modulesToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.modulesToolStripMenuItem.Name = "modulesToolStripMenuItem";
            this.modulesToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.modulesToolStripMenuItem.Text = "Modules";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // sobreToolStripMenuItem
            // 
            this.sobreToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.sobreToolStripMenuItem.Name = "sobreToolStripMenuItem";
            this.sobreToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.sobreToolStripMenuItem.Text = "About";
            // 
            // panelSecondMenu
            // 
            this.panelSecondMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSecondMenu.Controls.Add(this.btnMenuPrint);
            this.panelSecondMenu.Controls.Add(this.btonMenuVis);
            this.panelSecondMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSecondMenu.Location = new System.Drawing.Point(3, 33);
            this.panelSecondMenu.Name = "panelSecondMenu";
            this.panelSecondMenu.Size = new System.Drawing.Size(889, 39);
            this.panelSecondMenu.TabIndex = 2;
            // 
            // btnMenuPrint
            // 
            this.btnMenuPrint.FlatAppearance.BorderSize = 0;
            this.btnMenuPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuPrint.Location = new System.Drawing.Point(80, 3);
            this.btnMenuPrint.Name = "btnMenuPrint";
            this.btnMenuPrint.Size = new System.Drawing.Size(26, 32);
            this.btnMenuPrint.TabIndex = 3;
            this.btnMenuPrint.UseVisualStyleBackColor = true;
            // 
            // btonMenuVis
            // 
            this.btonMenuVis.FlatAppearance.BorderSize = 0;
            this.btonMenuVis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btonMenuVis.Image = ((System.Drawing.Image)(resources.GetObject("btonMenuVis.Image")));
            this.btonMenuVis.Location = new System.Drawing.Point(18, 5);
            this.btonMenuVis.Name = "btonMenuVis";
            this.btonMenuVis.Size = new System.Drawing.Size(36, 29);
            this.btonMenuVis.TabIndex = 2;
            this.btonMenuVis.UseVisualStyleBackColor = true;
            // 
            // timerVerificaConexao
            // 
            this.timerVerificaConexao.Enabled = true;
            this.timerVerificaConexao.Interval = 1000;
            this.timerVerificaConexao.Tick += new System.EventHandler(this.timerVerificaConexao_Tick);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 341);
            this.Controls.Add(this.tableLayoutPanel);
            this.IsMdiContainer = true;
            this.Name = "frmPrincipal";
            this.Text = "iCommerce";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tableLayoutPanel.ResumeLayout(false);
            this.panelStatusBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            this.menuSuperior.ResumeLayout(false);
            this.menuSuperior.PerformLayout();
            this.panelSecondMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelSecondMenu;
        private System.Windows.Forms.Button btnMenuPrint;
        private System.Windows.Forms.Button btonMenuVis;
        private System.Windows.Forms.Panel panelStatusBar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuSuperior;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pedidosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ordemDeVentaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem processToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem datasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modulesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobreToolStripMenuItem;
        private DevExpress.XtraEditors.SimpleButton btnConexao;
        private System.Windows.Forms.Timer timerVerificaConexao;
        private System.Windows.Forms.ImageList imageList1;
    }
}

