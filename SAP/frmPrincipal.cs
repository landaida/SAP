using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SAP.forms.movimientos;
using SAP.util;

namespace SAP
{
    public partial class frmPrincipal : Form
    {
        #region FunctionsC#

            public frmPrincipal()
            {
                InitializeComponent();
            }

            private void ordemDeVentaToolStripMenuItem_Click(object sender, EventArgs e)
            {
                frmCotizacion form = new frmCotizacion();
                form.MdiParent = this;
                form.Parent = this.panelBottom;
                //this.panelBottom.Controls.Clear();
                this.panelBottom.Controls.Add(form);
                form.Show();
            }

        #endregion

        private void timerVerificaConexao_Tick(object sender, EventArgs e)
        {
            if (GlobalVar.Empresa != null)
            {
                this.btnConexao.ImageIndex = 0;
                this.timerVerificaConexao.Enabled = false;
                this.btnConexao.ToolTip = "Conectado a SAP";
            }
            
        }
    }
}
