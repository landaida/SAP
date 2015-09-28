using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SAP.util;
using SAP.forms.movimientos;
namespace SAP.forms
{
    public partial class MDIParent : Form
    {
        public MDIParent()
        {
            InitializeComponent();            
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Util.showForm(new frmOfertaVenta(), this);
        }

        private void timerVerificaConexao_Tick(object sender, EventArgs e)
        {
            if (GlobalVar.isReady)
            {
                Util.hideSplashScreen(this);
                this.timerVerificaConexao.Enabled = false;
                toolStripStatusLabel.Image = imageList1.Images[0];
                frmLogin dialog = new frmLogin();
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {

                }
                else
                {
                    this.Close();
                }
            }
        }

        private void MDIParent_FormClosed(object sender, FormClosedEventArgs e)
        {
            GlobalVar.Empresa.Disconnect();
            Application.Exit();
        }

        private void MDIParent_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel.Image = imageList1.Images[1];
            Util.showSplashScreen(this);
        }
    }
}
