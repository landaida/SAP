using System;
using System.Windows.Forms;
using SAPLibraryParaguay;
using SAP.forms.movimientos;
using SAP.forms.util;
namespace SAP.forms
{
    public partial class MDIParent : Form
    {
        private SplashScreen splashScreen = new SplashScreen();
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
                this.hideSplashScreen(this);
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
            GlobalVar.mdiParent = this;
            toolStripStatusLabel.Image = imageList1.Images[1];
            this.showSplashScreen(this);
        }

        private void documentosPreliminaresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.abriDocumentosPreliminares();
        }

        private void abriDocumentosPreliminares()
        {
            Util.showForm(new frmListDraftSalesOrder(), this);
        }

        private void showSplashScreen(Form parentForm, String label = "")
        {
            if (label.Trim().Length > 0)
                this.splashScreen.setLabel(label);
            parentForm.BeginInvoke(new Action(() => this.splashScreen.ShowDialog()));
        }

        private void hideSplashScreen(Form parentForm)
        {
            parentForm.Invoke(new Action(this.splashScreen.Hide));
        }
    }
}
