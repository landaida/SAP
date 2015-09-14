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
                if (GlobalVar.isReady)
                {
                    frmOfertaVenta form = new frmOfertaVenta();
                    form.MdiParent = this;
                    form.Parent = this.panelBottom;
                    //this.panelBottom.Controls.Clear();
                    this.panelBottom.Controls.Add(form);
                    form.Show();
                }
                else
                {
                    Util.AutoClosingMessageBox.Show("Pendiente de conexión con el sistema SAP, aguarde.", "Aviso", 3000);
                }
                
            }

        #endregion

        private void timerVerificaConexao_Tick(object sender, EventArgs e)
        {
            if (GlobalVar.isReady)
            {
                this.btnConexao.ImageIndex = 0;
                this.timerVerificaConexao.Enabled = false;
                this.btnConexao.ToolTip = "Conectado a SAP";
            }
            
        }

        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            GlobalVar.Empresa.Disconnect();
        }
    }
}
