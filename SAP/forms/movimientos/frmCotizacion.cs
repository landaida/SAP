﻿using System;
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
    public partial class frmCotizacion : Form
    {
        #region Declare
        Documents ofertaVentaDoc;
        BusinessPartners cliente;
        List<Producto> productos;        
        OfertaVenta ofertaVenta;


        
        int response = 0;
        #endregion

        #region Functions
        private void bindingControls()
        {
            this.txtId.DataBindings.Add("Text", ofertaVenta, "Comments");            
        }

        private void instanciarOjectosSAP()
        {
            Util.cursorShow();            
            if (GlobalVar.Empresa.Connected == true)
            {
                ofertaVenta = GlobalVar.Empresa.GetBusinessObject(BoObjectTypes.oQuotations);
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
            this.Top = (this.ParentForm.ClientRectangle.Size.Height - this.Height) / 2;
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

        private void addLine()
        {
           this.lines().Add(new OfertaVentaLine());
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
            
            this.ofertaVenta.Lines = this.lines().Where(p => p.Producto != null && p.Cantidad > 0 && p.PrecioUnitario > 0).ToList();

            if (this.lines().Count > 0)
                retorno = true;

            return retorno;
        }

        private bool isValidForm()
        {
            bool retorno = false;

            if (this.cmbCliente.EditValue.ToString().Trim().Length <= 0)
                Util.AutoClosingMessageBox.Show("Seleccione un cliente por favor.", "Aviso", 3000);
            else if (this.isValidLines())
                Util.AutoClosingMessageBox.Show("Debe agregar por lo menos un producto.", "Aviso", 3000);
            else
                retorno = true;

            return retorno;
        }

        private void guardar()
        {

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

        private void cmbCliente_EditValueChanged(object sender, EventArgs e)
        {
            this.getBusinessPartnersInfo();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            this.guardar();
        }

        #endregion
    }
}
