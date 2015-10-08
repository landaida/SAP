using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using SAP.model;
using SAPLibraryParaguay;
namespace SAP.forms.movimientos
{
    public partial class frmListDraftSalesOrder : DevExpress.XtraEditors.XtraForm
    {
        private List<Draft> listDraft;
        private int index;

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
            moreColumns.Add("DocStatus");
            moreColumns.Add("WddStatus");
            this.listDraft = Util.getGenericList<Draft>("DocNum", "DocDate", "odrf", " and DocStatus = 'O' and WddStatus in ('W', '-', 'Y') and UserSign = "+GlobalVar.usuarioId+" order by DocNum desc", moreColumns).ToList<Draft>();

            BindingList<Draft> lista = new BindingList<Draft>(this.listDraft);
            this.gridControl1.DataSource = lista;
        }

        private void btnGoToDocDraft_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if(this.listDraft[this.index].WddStatus != "Y")
            {
                Util.showMessage("Pendiente de aprobación");
                return;
            }
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
            
            formOV.getDocumentDraftByKey(this.listDraft[this.index].DocEntry);

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            this.index = e.FocusedRowHandle;
        }
    }
}