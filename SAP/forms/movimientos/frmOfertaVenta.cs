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

namespace SAP.forms.movimientos
{
    public partial class frmOfertaVenta : Form
    {
        #region Declare
        Documents ofertaVentaDoc;
        BusinessPartners cliente;
        List<Producto> productos;        
        OfertaVenta ofertaVenta;
        BindingSource bindingSource = new BindingSource();


        
        #endregion

        #region Functions
        private void bindingControls()
        {
            bindingSource.DataSource = this.ofertaVenta;
            this.txtTotalGravada.DataBindings.Add("Text", bindingSource, "TotalGravada", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void centerFormInContainer()
        {
            this.StartPosition = FormStartPosition.Manual;
            this.Top = (this.ParentForm.ClientRectangle.Size.Height - this.Height) / 2;
            this.Left = (this.ParentForm.ClientRectangle.Size.Width - this.Width) / 2;
        }

        private void inicializarObjetos()
        {

            //centerFormInContainer();

            //Cria uma lista de productos, isso facilitara na hora de carregar o combo de produtos en cada line do quotation
            productos = Util.getGenericList<Producto>("itemCode", "itemName", "oitm").ToList<Producto>();


            ComboUtil.populateSearchLookUpEdit(this.cmbCliente, "CardCode", "CardName", "ocrd", typeof(Cliente));
            ComboUtil.populateSearchLookUpEdit(this.cmbVendedor, "SlpCode", "SlpName", "oslp", typeof(Vendedor), " and active = 'Y' and locked = 'N'");
            ComboUtil.populateSearchLookUpEdit(this.cmbProduto, "ItemCode", "ItemName", productos);
            

            
            this.ofertaVenta = new OfertaVenta();            
            BindingList<OfertaVentaLine> listCotizacion = new BindingList<OfertaVentaLine>(this.ofertaVenta.Lines);
            
            listCotizacion.AllowNew = true;
            this.gridControl1.DataSource = listCotizacion;
            gridView2.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            //bindingListProducto.AddingNew += this.OnAddingNew;

            //this.addLine();
            

            // this.txtCliente.TextChanged += new EventHandler(generics_TextChanged);
            //this.txtCliente.AutoCompleteMode = AutoCompleteMode.Suggest;
            //this.txtCliente.AutoCompleteSource = AutoCompleteSource.ListItems;
            //List<Cliente> results = (from d in this.clientes where d.CardName.ToLower().Contains(filter.ToLower()) select d).ToList();                

            //clientes = Util.getGenericList<Cliente>("cardCode", "cardName", "ocrd").ToList<Cliente>();

            ComboUtil.populateLookUpEditWhitEnums(cmbStatus, typeof(DocumentStatus));
            this.cmbStatus.EditValue = DocumentStatus.Abierto;

            //this.bindingControls();
            
        }

        private void addLine()
        {
            this.ofertaVenta.Lines.Add(new OfertaVentaLine());
        }
        
        private void getBusinessPartnersInfo()
        {            
            String key = this.cmbCliente.EditValue.ToString();
            if (key.Trim().Length > 0)
            {
                cliente = GlobalVar.Empresa.GetBusinessObject(BoObjectTypes.oBusinessPartners);
                bool retVal = cliente.GetByKey(key);
                if (retVal)
                {
                    this.cmbVendedor.EditValue = cliente.SalesPersonCode;
                    foreach(OfertaVentaLine item in this.lines())
                    {
                        item.Descuento = cliente.DiscountPercent;
                    }
                }else
                {
                    Util.AutoClosingMessageBox.Show(GlobalVar.Empresa.GetLastErrorDescription(), "Aviso", 3000);
                }
            }
        }
        
        private void changePriceForLine()
        {
            if (this.lines().Count == 0) return;

            foreach(OfertaVentaLine line in this.lines())
            {
                
                
            }
        }

        private List<OfertaVentaLine> lines()
        {
            return this.ofertaVenta.Lines;
        }

        private bool isValidLines()
        {
            bool retorno = false;
            
            this.ofertaVenta.Lines = this.ofertaVenta.Lines.Where(p => p.Producto != null && p.Cantidad > 0 && p.PrecioUnitario > 0).ToList<OfertaVentaLine>();

            if (this.ofertaVenta.Lines.Count > 0)
                retorno = true;

            return retorno;
        }

        private bool isValidForm()
        {
            bool retorno = false;

            if (this.cmbCliente.EditValue.ToString().Trim().Length <= 0)
                Util.AutoClosingMessageBox.Show("Seleccione un cliente por favor.", "Aviso", 3000);
            else if (!this.isValidLines())
                Util.AutoClosingMessageBox.Show("Debe agregar por lo menos un producto.", "Aviso", 3000);
            else
                retorno = true;

            return retorno;
        }

        private void guardar()
        {
            if (this.isValidForm())
            {
                //Util.showSplashScreen(this.MdiParent);
                if (GlobalVar.Empresa.Connected == true)
                {
                    this.ofertaVentaDoc = GlobalVar.Empresa.GetBusinessObject(BoObjectTypes.oQuotations);
                    
                    this.ofertaVentaDoc.CardCode = cliente.CardCode;
                    this.ofertaVentaDoc.CardName = cliente.CardName;
                    this.ofertaVentaDoc.DocDate = this.txtFechaDocumento.Value;
                    this.ofertaVentaDoc.Comments = this.txtObservacion.Text;

                    if(this.cmbVendedor.EditValue.ToString().Trim().Length > 0)
                        this.ofertaVentaDoc.SalesPersonCode = Convert.ToInt32(this.cmbVendedor.EditValue);

                    for(int i = 0; i<= this.lines().Count-1; i++)
                    {
                        OfertaVentaLine item = this.lines()[i];
                        this.ofertaVentaDoc.Lines.ItemCode = item.ProductoId;
                        this.ofertaVentaDoc.Lines.Quantity = item.Cantidad;
                        this.ofertaVentaDoc.Lines.PriceAfterVAT = item.PrecioUnitario;
                        this.ofertaVentaDoc.Lines.TaxCode = item.IndicadorImpuesto; 

                        if (i < this.lines().Count-1)
                            this.ofertaVentaDoc.Lines.Add();
                    }
                    int response = this.ofertaVentaDoc.Add();
                    if (response == 0)
                    {
                        String docNum = "";
                        GlobalVar.Empresa.GetNewObjectCode(out docNum);
                        this.txtId.Text = docNum;
                        MessageBox.Show("Oferta de venta nro.: " + docNum + " generada con éxito.", "Aviso");
                    }
                    else
                    {
                        Util.AutoClosingMessageBox.Show(GlobalVar.Empresa.GetLastErrorDescription(), "Aviso", 3000);
                    }
                }
                else
                {
                    Util.AutoClosingMessageBox.Show(GlobalVar.Empresa.GetLastErrorDescription(), "Aviso", 3000);
                }
                //Util.hideSplashScreen(this.MdiParent);
            }
        }

        #endregion

        #region FunctionsC#

        public frmOfertaVenta()
        {
            InitializeComponent();
        }

        private void frmCotizacion_Load(object sender, EventArgs e)
        {
            this.inicializarObjetos();            
        }

        private void cmbCliente_EditValueChanged(object sender, EventArgs e)
        {
            this.getBusinessPartnersInfo();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {            
            this.guardar();
        }
                
        private void gridView2_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            
            Double total = 0;
            Double totalGravada = 0;
            Double descuento = 0;
            Double impuesto = 0;
            foreach (OfertaVentaLine item in this.ofertaVenta.Lines)
            {
                totalGravada += item.PrecioUnitarioGravada * item.Cantidad;
                total += item.PrecioUnitario * item.Cantidad;
                descuento += item.DescuentoValor * item.Cantidad;
                impuesto += item.PrecioUnitarioImpuesto * item.Cantidad;
            }
            this.txtImpuesto.Text = Convert.ToString(impuesto);
            this.txtTotal.Text = Convert.ToString(total);
            this.txtTotalGravada.Text = Convert.ToString(totalGravada);
            this.txtDescuento.Text = Convert.ToString(descuento);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}
