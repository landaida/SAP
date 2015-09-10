using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SAP.model;
using SAPbobsCOM;
using SAP.util;
using System.Threading;
using System.ComponentModel;
namespace SAP.forms.movimientos
{
    public partial class frmCotizacion : Form
    {
        #region Declare
        Documents cotizacion;
        List<CotizacionLine> lines = new List<CotizacionLine>();
        BusinessPartners cliente;
        List<Producto> productos;
        BindingList<CotizacionLine> listCotizacion;


        
        int response = 0;
        #endregion

        #region Functions
        private void bindingControls()
        {
            this.txtId.DataBindings.Add("Text", cotizacion, "Comments");            
        }

        private void instanciarOjectosSAP()
        {
            Util.cursorShow();            
            if (GlobalVar.Empresa.Connected == true)
            {
                cotizacion = GlobalVar.Empresa.GetBusinessObject(BoObjectTypes.oQuotations);
                cliente = GlobalVar.Empresa.GetBusinessObject(BoObjectTypes.oBusinessPartners);
                //cliente.CardCode = "C0003144";
                //cotizacion.CardCode = cliente.CardCode;
                //cotizacion.Lines.ItemCode = "101100";
                //cotizacion.Lines.Quantity = 1;
                //cotizacion.Lines.PriceAfterVAT = 60000;
                //cotizacion.Lines.TaxCode = "IVA_10";     
                this.bindingControls();
            }
            else
            {
                Console.WriteLine(GlobalVar.Empresa.GetLastErrorDescription());
            }
            Util.cursorHidden();
        }

        private void centerFormInContainer()
        {
            this.StartPosition = FormStartPosition.Manual;
            //this.Top = (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2;
            this.Top = (this.ParentForm.ClientRectangle.Size.Height - this.Height) / 2;
            //this.Left = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2;
            this.Left = (this.ParentForm.ClientRectangle.Size.Width - this.Width) / 2;
        }

        private void inicializarObjetos()
        {
            centerFormInContainer();

            //Cria uma lista de productos, isso facilitara na hora de carregar o combo de produtos en cada line do quotation
            productos = Util.getGenericList<Producto>("itemCode", "itemName", "oitm").ToList<Producto>();


            ComboUtil.populateSearchLookUpEdit(this.cmbCliente, "CardCode", "CardName", "ocrd", typeof(Cliente));
            ComboUtil.populateSearchLookUpEdit(this.cmbVendedor, "SlpCode", "SlpName", "oslp", typeof(Vendedor));
            ComboUtil.populateSearchLookUpEdit(this.cmbProduto, "ItemCode", "ItemName", productos);
            

            this.setGridColumnsFieldName();

            listCotizacion = new BindingList<CotizacionLine>();
            listCotizacion.AllowNew = true;
            this.gridControl1.DataSource = listCotizacion;
            gridView2.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            //bindingListProducto.AddingNew += this.OnAddingNew;

            this.addLine();
            

            // this.txtCliente.TextChanged += new EventHandler(generics_TextChanged);
            //this.txtCliente.AutoCompleteMode = AutoCompleteMode.Suggest;
            //this.txtCliente.AutoCompleteSource = AutoCompleteSource.ListItems;
            //List<Cliente> results = (from d in this.clientes where d.CardName.ToLower().Contains(filter.ToLower()) select d).ToList();                

            //clientes = Util.getGenericList<Cliente>("cardCode", "cardName", "ocrd").ToList<Cliente>();

            ComboUtil.populateLookUpEditWhitEnums(cmbStatus, typeof(DocumentStatus));
            this.cmbStatus.EditValue = DocumentStatus.Abierto;
        }
        private void OnAddingNew(Object o, AddingNewEventArgs e)
        {
            
        }
        private void setGridColumnsFieldName()
        {
            this.colItemNro1.FieldName = "Id";
            this.colDescripcion1.FieldName = "Producto";
            this.colCantidad1.FieldName = "Cantidad";
            this.colPrecioUnitario1.FieldName = "PrecioUnitario";
            this.colPorcentajeDescuento1.FieldName = "Descuento";
            this.colIndicadorImpuesto1.FieldName = "IndicadorImpuesto";
        }

        //private bool lineIsValid(int index)
        //{
        //    bool retorno = false;
        //    DataGridViewCellCollection cells = this.dgvLines.Rows[index].Cells;
        //    if (cells[colItemNro1.Name].Value != null && 
        //        cells[colDescripcion1.Name].Value != null && 
        //        cells[colCantidad1.Name].Value != null && (Double)cells[colCantidad1.Name].Value > 0 &&
        //        cells[colPrecioUnitario1.Name].Value != null && (Double)cells[colPrecioUnitario1.Name].Value > 0)
        //    {                
        //        retorno = true;
        //    }
        //    return retorno;
        //}

        private void addLine()
        {
            this.listCotizacion.Add(new CotizacionLine(600000, 700000));
        }
        
        private void getBusinessPartnersInfo()
        {            
            String key = this.cmbCliente.EditValue.ToString();
            if (key.Trim().Length > 0)
            {
                cliente = GlobalVar.Empresa.GetBusinessObject(BoObjectTypes.oBusinessPartners);
                bool retVal = cliente.GetByKey(key);
                if (!retVal)
                {
                    Util.AutoClosingMessageBox.Show(GlobalVar.Empresa.GetLastErrorDescription(), "Aviso", 3000);
                }
            }
        }
        
        private void changePriceForLine()
        {
            if (this.lines.Count == 0) return;

            foreach(CotizacionLine line in this.lines)
            {
                
                
            }
        }



        #endregion

        #region FunctionsC#

        public frmCotizacion()
        {
            InitializeComponent();
        }

        private void frmCotizacion_Load(object sender, EventArgs e)
        {
            this.inicializarObjetos();            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine(this.cotizacion.Comments);
            this.instanciarOjectosSAP();
            response = cotizacion.Add();
            if(response == 0)
            {
                    
            }
            else
            {
                Console.WriteLine(GlobalVar.Empresa.GetLastErrorDescription());
            }
        }        

        #endregion

        private void txtCliente_KeyDown(object sender, KeyEventArgs e)
        {            
            
        }

        private void cmbCliente_EditValueChanged(object sender, EventArgs e)
        {
            //this.getBusinessPartnersInfo();
        }
    }
}
