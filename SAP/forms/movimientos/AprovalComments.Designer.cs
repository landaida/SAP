namespace SAP.forms.movimientos
{
    partial class AprovalComments
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGuardar = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.txtComentarioDescuento = new DevExpress.XtraEditors.TextEdit();
            this.txtComentarioLimiteCredito = new DevExpress.XtraEditors.TextEdit();
            this.txtComentarioTituloVencido = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtComentarioDescuento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtComentarioLimiteCredito.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtComentarioTituloVencido.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Porcentaje desc.";
            this.label1.UseWaitCursor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Limite de credito";
            this.label2.UseWaitCursor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Titulo vencido";
            this.label3.UseWaitCursor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(164, 129);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 3;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseWaitCursor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(245, 129);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseWaitCursor = true;
            // 
            // txtComentarioDescuento
            // 
            this.txtComentarioDescuento.Location = new System.Drawing.Point(116, 39);
            this.txtComentarioDescuento.Name = "txtComentarioDescuento";
            this.txtComentarioDescuento.Size = new System.Drawing.Size(204, 20);
            this.txtComentarioDescuento.TabIndex = 5;
            this.txtComentarioDescuento.UseWaitCursor = true;
            // 
            // txtComentarioLimiteCredito
            // 
            this.txtComentarioLimiteCredito.Location = new System.Drawing.Point(116, 65);
            this.txtComentarioLimiteCredito.Name = "txtComentarioLimiteCredito";
            this.txtComentarioLimiteCredito.Size = new System.Drawing.Size(204, 20);
            this.txtComentarioLimiteCredito.TabIndex = 6;
            this.txtComentarioLimiteCredito.UseWaitCursor = true;
            // 
            // txtComentarioTituloVencido
            // 
            this.txtComentarioTituloVencido.Location = new System.Drawing.Point(116, 95);
            this.txtComentarioTituloVencido.Name = "txtComentarioTituloVencido";
            this.txtComentarioTituloVencido.Size = new System.Drawing.Size(204, 20);
            this.txtComentarioTituloVencido.TabIndex = 7;
            this.txtComentarioTituloVencido.UseWaitCursor = true;
            // 
            // AprovalComments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 170);
            this.Controls.Add(this.txtComentarioTituloVencido);
            this.Controls.Add(this.txtComentarioLimiteCredito);
            this.Controls.Add(this.txtComentarioDescuento);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AprovalComments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Autorización requerida";
            this.UseWaitCursor = true;
            ((System.ComponentModel.ISupportInitialize)(this.txtComentarioDescuento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtComentarioLimiteCredito.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtComentarioTituloVencido.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.SimpleButton btnGuardar;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.TextEdit txtComentarioDescuento;
        private DevExpress.XtraEditors.TextEdit txtComentarioLimiteCredito;
        private DevExpress.XtraEditors.TextEdit txtComentarioTituloVencido;
    }
}