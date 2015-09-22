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
            this.ofertaVentaDoc = GlobalVar.Empresa.GetBusinessObject(BoObjectTypes.oQuotations);
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

            this.addLine();
            

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
            this.gridView2.RefreshData();
        }
        
        private void getBusinessPartnersInfo()
        {
            if (this.cmbCliente.EditValue == null) return;

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
                    this.ofertaVentaDoc.CardCode = cliente.CardCode;
                    this.ofertaVentaDoc.CardName = cliente.CardName;
                    this.ofertaVentaDoc.DocDate = this.txtFechaDocumento.Value;
                    this.ofertaVentaDoc.DocDueDate = this.txtFechaLanzamiento.Value;
                    this.ofertaVentaDoc.Comments = this.txtObservacion.Text;

                    if(this.cmbVendedor.EditValue.ToString().Trim().Length > 0)
                        this.ofertaVentaDoc.SalesPersonCode = Convert.ToInt32(this.cmbVendedor.EditValue);

                    for(int i = 0; i<= this.lines().Count-1; i++)
                    {
                        OfertaVentaLine item = this.lines()[i];
                        this.ofertaVentaDoc.Lines.ItemCode = item.ProductoId;
                        this.ofertaVentaDoc.Lines.Quantity = item.Cantidad;
                        this.ofertaVentaDoc.Lines.PriceAfterVAT = item.PrecioUnitarioGravada;
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
                        this.btnCopyToSalesOrders.Enabled = true;
                        this.btnGuardar.Enabled = false;
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

        

        private void copyToSalesOrders()
        {
            if(this.verificarEtapasAutorizacion() && GlobalVar.Empresa.Connected == true)
            {
                Documents Orden = GlobalVar.Empresa.GetBusinessObject(BoObjectTypes.oOrders);
                Orden.CardCode = ofertaVentaDoc.CardCode;
                Orden.DocDate = ofertaVentaDoc.DocDate;
                Orden.DocDueDate = ofertaVentaDoc.DocDueDate;
                Orden.Comments = ofertaVentaDoc.Comments;
                Orden.DocCurrency = ofertaVentaDoc.DocCurrency;

                for (int i = 0; i <= this.lines().Count - 1; i++)
                {
                    OfertaVentaLine item = this.lines()[i];

                    Orden.Lines.ItemCode = item.ProductoId;
                    Orden.Lines.Quantity = item.Cantidad;
                    Orden.Lines.TaxCode = item.IndicadorImpuesto;
                    Orden.Lines.PriceAfterVAT = item.PrecioUnitarioGravada;

                    if (i < this.lines().Count - 1)
                        Orden.Lines.Add();
                }

                int res = Orden.Add();

                if (res == 0)
                {
                    String docNum = "";
                    GlobalVar.Empresa.GetNewObjectCode(out docNum);
                    this.txtId.Text = docNum;
                    this.btnCopyToSalesOrders.Enabled = true;                    
                    MessageBox.Show("Orden de venta nro.: " + docNum + " generada con éxito.", "Aviso");
                }
                else
                {
                    System.Console.WriteLine(GlobalVar.Empresa.GetLastErrorDescription());
                    Util.AutoClosingMessageBox.Show(GlobalVar.Empresa.GetLastErrorDescription(), "Aviso", 3000);
                }
            }
        }

        private bool verificarEtapasAutorizacion()
        {
            bool retorno = false;

            if (!this.superaLimiteCredito() || !this.existeDescuento())
                retorno = true;

            return retorno;
        }

        private bool superaLimiteCredito()
        {
            bool retorno = false;

            Double valorDoc = ofertaVenta.Valor;
            int condicion = ofertaVentaDoc.GroupNumber;

            //Si la condicion es al contado retorna falso, no verifica limite de credito
            if (condicion == 0) return false;

            Double limiteCredito = cliente.CreditLimit;
            Double balance = cliente.CurrentAccountBalance;
            Double ordersBal = cliente.OpenOrdersBalance;

            String sql = "  SELECT isnull(sum(T0.[DocTotal]), 0) value " +
                         "   FROM ODRF T0 " +
                         "   WHERE T0.[DocStatus] = 'O' " +
                         "   and T0.[ObjType] = '17'  " +
                         "   and T0.[CardCode] = '"+cliente.CardCode+"' ";
            Double totalDocPreliminares = Util.getValueFromQuery<Double>(sql, "value");

            //Saldo de linea de credito
            Double saldo = balance + ordersBal + totalDocPreliminares + ofertaVenta.Valor;

            if (saldo > limiteCredito)
            {
                this.saveDocumentDrafts();
                retorno = true;
            }
                

            return retorno;
        }

        private void saveDocumentDrafts()
        {
            //Create the Documents object
            Documents vDrafts = GlobalVar.Empresa.GetBusinessObject(BoObjectTypes.oDrafts);

            //Set values to the fields
            vDrafts.DocObjectCode = BoObjectTypes.oOrders;
            vDrafts.CardCode = ofertaVentaDoc.CardCode;
            vDrafts.HandWritten = BoYesNoEnum.tNO;
            vDrafts.DocDate = ofertaVentaDoc.DocDate;
            vDrafts.DocTotal = ofertaVenta.Valor;

            for (int i = 0; i <= this.lines().Count - 1; i++)
            {
                OfertaVentaLine item = this.lines()[i];

                vDrafts.Lines.ItemCode = item.ProductoId;
                vDrafts.Lines.Quantity = item.Cantidad;
                vDrafts.Lines.TaxCode = item.IndicadorImpuesto;
                vDrafts.Lines.PriceAfterVAT = item.PrecioUnitarioGravada;

                if (i < this.lines().Count - 1)
                    vDrafts.Lines.Add();
            }

            int retVal = vDrafts.Add();


            if(retVal == 0){
                String docNum = "";
                GlobalVar.Empresa.GetNewObjectCode(out docNum);
                MessageBox.Show("Preliminar de venta nro.: " + docNum + " generada con éxito.", "Aviso");
            }
            else
            {
                System.Console.WriteLine(GlobalVar.Empresa.GetLastErrorDescription());
                Util.AutoClosingMessageBox.Show(GlobalVar.Empresa.GetLastErrorDescription(), "Aviso", 3000);
            }
        }

        private bool existeDescuento()
        {
            bool retorno = false;
            foreach(OfertaVentaLine line in ofertaVenta.Lines)
            {
                if(line.PrecioUnitarioGravada < line.PrecioUnitario)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }

        private void getQuotationByKey()
        {
            if(this.txtId.Text.Trim().Length > 0)
            {
                bool res;
                res = ofertaVentaDoc.GetByKey(Convert.ToInt32(this.txtId.Text));
                if (res)
                {
                    this.cmbCliente.EditValue = ofertaVentaDoc.CardCode;
                    this.txtFechaDocumento.Value = this.ofertaVentaDoc.DocDate;
                    this.txtFechaLanzamiento.Value = this.ofertaVentaDoc.DocDueDate;
                    this.txtObservacion.Text = this.ofertaVentaDoc.Comments;                    
                    this.cmbVendedor.EditValue = this.ofertaVentaDoc.SalesPersonCode;

                    this.ofertaVenta.Lines.Clear();
                    for (int i = 0; i <= this.ofertaVentaDoc.Lines.Count - 1; i++)
                    {
                        
                        OfertaVentaLine line = new OfertaVentaLine();
                        this.ofertaVentaDoc.Lines.SetCurrentLine(i);
                        line.ProductoId = this.ofertaVentaDoc.Lines.ItemCode;
                        line.Cantidad = this.ofertaVentaDoc.Lines.Quantity;
                        line.PrecioUnitario = this.ofertaVentaDoc.Lines.PriceAfterVAT;
                        line.IndicadorImpuesto = this.ofertaVentaDoc.Lines.TaxCode;
                        
                        this.ofertaVenta.Lines.Add(line);
                    }

                    this.gridView2.RefreshData();
                    this.actualizaTotales();
                    this.btnCopyToSalesOrders.Enabled = true;
                    this.btnGuardar.Enabled = false;
                }
            }
        }

        private void actualizaTotales()
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

        private void limpiar()
        {
            this.btnCopyToSalesOrders.Enabled = false;
            this.btnGuardar.Enabled = true;

            this.txtId.Text = null;
            this.cmbCliente.EditValue = null;
            this.cmbStatus.EditValue = DocumentStatus.Abierto;
            this.txtFechaDocumento.Value = DateTime.Now;
            this.txtFechaLanzamiento.Value = DateTime.Now;
            this.cmbVendedor.EditValue = null;
            this.txtObservacion.Text = null;

            this.ofertaVenta = new OfertaVenta();
            BindingList<OfertaVentaLine> listCotizacion = new BindingList<OfertaVentaLine>(this.ofertaVenta.Lines);

            listCotizacion.AllowNew = true;
            this.gridControl1.DataSource = listCotizacion;

            this.addLine();
            this.actualizaTotales();

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

            this.actualizaTotales();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.limpiar();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.copyToSalesOrders();
        }

        private void btnSearchQuotation_Click(object sender, EventArgs e)
        {
            this.getQuotationByKey();
        }
        #endregion


    }
}
