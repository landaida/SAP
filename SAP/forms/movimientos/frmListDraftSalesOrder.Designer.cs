namespace SAP.forms.movimientos
{
    partial class frmListDraftSalesOrder
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDocNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnGoToDocDraft = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colDocDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCardCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDocTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGoToDocDraft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageEdit1,
            this.btnGoToDocDraft});
            this.gridControl1.Size = new System.Drawing.Size(725, 406);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDocNum,
            this.colDocDate,
            this.colCardCode,
            this.colDocTotal});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsCustomization.AllowColumnMoving = false;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsDetail.EnableMasterViewMode = false;
            this.gridView1.OptionsDetail.ShowDetailTabs = false;
            this.gridView1.OptionsDetail.SmartDetailExpand = false;
            this.gridView1.OptionsFind.AllowFindPanel = false;
            this.gridView1.OptionsMenu.EnableColumnMenu = false;
            this.gridView1.OptionsMenu.EnableFooterMenu = false;
            this.gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView1.OptionsMenu.ShowGroupSortSummaryItems = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colDocNum
            // 
            this.colDocNum.Caption = "Doc. Nro.";
            this.colDocNum.ColumnEdit = this.btnGoToDocDraft;
            this.colDocNum.FieldName = "DocNum";
            this.colDocNum.Name = "colDocNum";
            this.colDocNum.Visible = true;
            this.colDocNum.VisibleIndex = 0;
            this.colDocNum.Width = 88;
            // 
            // btnGoToDocDraft
            // 
            this.btnGoToDocDraft.AutoHeight = false;
            this.btnGoToDocDraft.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnGoToDocDraft.ContextImage = global::SAP.Properties.Resources.next16x16;
            this.btnGoToDocDraft.Name = "btnGoToDocDraft";
            this.btnGoToDocDraft.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnGoToDocDraft_ButtonClick);
            // 
            // colDocDate
            // 
            this.colDocDate.Caption = "Fecha";
            this.colDocDate.FieldName = "DocDate";
            this.colDocDate.Name = "colDocDate";
            this.colDocDate.Visible = true;
            this.colDocDate.VisibleIndex = 1;
            // 
            // colCardCode
            // 
            this.colCardCode.Caption = "Cliente";
            this.colCardCode.FieldName = "CardCode";
            this.colCardCode.Name = "colCardCode";
            this.colCardCode.Visible = true;
            this.colCardCode.VisibleIndex = 2;
            // 
            // colDocTotal
            // 
            this.colDocTotal.Caption = "Total";
            this.colDocTotal.DisplayFormat.FormatString = "n2";
            this.colDocTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDocTotal.FieldName = "DocTotal";
            this.colDocTotal.Name = "colDocTotal";
            this.colDocTotal.Visible = true;
            this.colDocTotal.VisibleIndex = 3;
            // 
            // repositoryItemImageEdit1
            // 
            this.repositoryItemImageEdit1.AutoHeight = false;
            this.repositoryItemImageEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageEdit1.Name = "repositoryItemImageEdit1";
            // 
            // frmListDraftSalesOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 406);
            this.Controls.Add(this.gridControl1);
            this.Name = "frmListDraftSalesOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Documentos Preliminares";
            this.Load += new System.EventHandler(this.frmListDraftSalesOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGoToDocDraft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colDocNum;
        private DevExpress.XtraGrid.Columns.GridColumn colDocDate;
        private DevExpress.XtraGrid.Columns.GridColumn colCardCode;
        private DevExpress.XtraGrid.Columns.GridColumn colDocTotal;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnGoToDocDraft;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageEdit repositoryItemImageEdit1;
    }
}