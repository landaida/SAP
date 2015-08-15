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
    }
}
