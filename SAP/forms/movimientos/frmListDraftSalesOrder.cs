using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SAP.model;
using SAP.util;
namespace SAP.forms.movimientos
{
    public partial class frmListDraftSalesOrder : DevExpress.XtraEditors.XtraForm
    {
        private List<Draft> listDraft;

        public frmListDraftSalesOrder()
        {
            InitializeComponent();
        }

        private void frmListDraftSalesOrder_Load(object sender, EventArgs e)
        {
            this.inicializar();
        }

        private void inicializar()
        {
            List<string> moreColumns = new List<string>();
            moreColumns.Add("CardCode");
            moreColumns.Add("DocTotal");
            moreColumns.Add("Comments");
            moreColumns.Add("DocEntry");
            this.listDraft = Util.getGenericList<Draft>("DocNum", "DocDate", "odrf", " and DocStatus = 'O' and WddStatus = 'W' order by DocNum desc", moreColumns).ToList<Draft>();

            BindingList<Draft> lista = new BindingList<Draft>(this.listDraft);
            this.gridControl1.DataSource = lista;
        }

        private void btnGoToDocDraft_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Form frm = null;
            foreach(Form form in this.Parent.Controls)
            {
                if(form.GetType() == typeof(frmOfertaVenta))
                {
                    frm = form;
                    break;
                }
            }
            frmOfertaVenta formOV;
            if (frm == null)
            {
                formOV = new frmOfertaVenta();                
                Util.showForm(formOV, GlobalVar.mdiParent);
            }
            else
            {
                formOV = (frmOfertaVenta)frm;
                formOV.BringToFront();
            }
            formOV.getDocumentDraftByKey((int)((ButtonEdit)sender).EditValue);

        }
    }
}