using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
        Users usuario;
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


            ComboUtil.populateSearchLookUpEdit<Cliente>(this.cmbCliente, "CardCode", "CardName", "ocrd");
            ComboUtil.populateSearchLookUpEdit<Vendedor>(this.cmbVendedor, "SlpCode", "SlpName", "oslp", " and active = 'Y' and locked = 'N'");
            ComboUtil.populateSearchLookUpEdit(this.cmbProduto, "ItemCode", "ItemName", productos);
            ComboUtil.populateSearchLookUpEdit<Condicion>(this.cmbCondicion, "GroupNum", "PymntGroup", "octg");

            this.ofertaVentaDoc = GlobalVar.Empresa.GetBusinessObject(BoObjectTypes.oQuotations);
            this.usuario = GlobalVar.Empresa.GetBusinessObject(BoObjectTypes.oUsers);
            this.usuario.GetByKey(11);


            this.ofertaVenta = new OfertaVenta();            
            BindingList<OfertaVentaLine> listCotizacion = new BindingList<OfertaVentaLine>(this.ofertaVenta.Lines);
            
            listCotizacion.AllowNew = true;
            this.gridControl1.DataSource = listCotizacion;
            gridView2.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            //bindingListProductAddingNew += this.OnAddingNew;

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
                    this.cmbCondicion.EditValue = cliente.PayTermsGrpCode;
                    this.cmbVendedor.EditValue = cliente.SalesPersonCode;
                    foreach(OfertaVentaLine item in this.lines())
                    {
                        item.Descuento = cliente.DiscountPercent;
                    }
                }else
                {
                    Util.showMessage(GlobalVar.Empresa.GetLastErrorDescription());
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
                Util.showMessage("Seleccione un cliente por favor.");
            else if (!this.isValidLines())
                Util.showMessage("Debe agregar por lo menos un product");
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
                    this.ofertaVentaDoc.GroupNumber = Convert.ToInt32(this.cmbCondicion.EditValue);
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
                        Util.showMessage("Oferta de venta nr: " + docNum + " generada con éxit");

                    }
                    else
                    {
                        Util.showMessage(GlobalVar.Empresa.GetLastErrorDescription());
                    }
                }
                else
                {
                    Util.showMessage(GlobalVar.Empresa.GetLastErrorDescription());
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
                Orden.GroupNumber = ofertaVentaDoc.GroupNumber;
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
                    Util.showMessage("Orden de venta nr: " + docNum + " generada con éxit");
                }
                else
                {
                    System.Console.WriteLine(GlobalVar.Empresa.GetLastErrorDescription());
                    Util.showMessage(GlobalVar.Empresa.GetLastErrorDescription());
                }
            }
        }

        private bool verificarEtapasAutorizacion()
        {   
            bool retorno = false, existeDescuento = false, superaLimiteCredito = false;

            if (!this.existeDescuento())
                existeDescuento = true;
            if (!this.superaLimiteCredito())
                superaLimiteCredito = true;

            if(existeDescuento || superaLimiteCredito)
            {
                AprovalComments testDialog = new AprovalComments();
                
                // Show testDialog as a modal dialog and determine if DialogResult = OK.
                if (testDialog.ShowDialog(this) == DialogResult.OK)
                {
                    // Read the contents of testDialog's TextBox.
                    if (existeDescuento)
                        this.saveDocumentDrafts(AuthorizationTemplate.Porcentagem_Desc_02, testDialog.comentarioDescuento);
                    if (superaLimiteCredito)
                        this.saveDocumentDrafts(AuthorizationTemplate.Limite_de_Credito_03, testDialog.comentarioLimiteCredito);
                }
                testDialog.Dispose();               
            }

            return retorno;
        }

        private bool superaLimiteCredito()
        {
            bool retorno = false;

            
            int condicion = ofertaVentaDoc.GroupNumber;

            //Si la condicion es al contado retorna falso, no verifica limite de credito
            if (condicion == -1) return false;

            Double limiteCredito = cliente.CreditLimit;
            Double balance = cliente.CurrentAccountBalance;

            //If a business transaction is not a Pay-Immediately transaction, the amount of money 
            //must be recorded to Account - Payable account or Account - Receivable account, and the open 
            //balance for the business partner will then be adjusted accordingly.
            Double ordersBal = cliente.OpenOrdersBalance;

            String sql = "  SELECT isnull(sum(T0.[DocTotal]), 0) value " +
                         "   FROM ODRF T0 " +
                         "   WHERE T0.[DocStatus] = 'O' " +
                         "   and T0.[ObjType] = '17'  " +
                         "   and T0.[CardCode] = '"+cliente.CardCode+"' ";
            Double totalDocPreliminares = 0;
            try
            {
                totalDocPreliminares = Util.getValueFromQuery<Double>(sql, "value");
            }
            catch(Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
            

            //Saldo de linea de credito
            Double saldo = balance + ordersBal + totalDocPreliminares + Convert.ToDouble(this.txtTotal.EditValue);

            if (saldo > limiteCredito)                
                retorno = true;
                

            return retorno;
        }

        private void saveDocumentDrafts(AuthorizationTemplate authTemplate, String remarks)
        {
            //Create the Documents object
            Documents vDrafts = GlobalVar.Empresa.GetBusinessObject(BoObjectTypes.oDrafts);

            //Set values to the fields
            vDrafts.DocObjectCode = BoObjectTypes.oOrders;
            vDrafts.CardCode = ofertaVentaDoc.CardCode;
            vDrafts.HandWritten = BoYesNoEnum.tNO;
            vDrafts.DocDate = ofertaVentaDoc.DocDate;
            vDrafts.DocTotal = ofertaVentaDoc.DocTotal;
            vDrafts.GroupNumber = ofertaVentaDoc.GroupNumber;
            vDrafts.OpeningRemarks = remarks;

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
                Util.showMessage("Preliminar de venta nr: " + docNum + " generada con éxit");
                this.createAlertsForApprovals(vDrafts, authTemplate);
            }
            else
            {
                System.Console.WriteLine(GlobalVar.Empresa.GetLastErrorDescription());
                Util.showMessage(GlobalVar.Empresa.GetLastErrorDescription());
            }
        }

        private void createAlertsForApprovals(Documents vDrafts, AuthorizationTemplate authTemplate)
        {
            String sql = "insert into OWDD (WtmCode, OwnerID, DocEntry, ObjType, DocDate, CurrStep, Remarks, UserSign, CreateDate, MaxRejReqr, MaxReqr)"
                +"values(@WtmCode, @OwnerID, @DocEntry, @ObjType, @DocDate, @CurrStep, @Remarks, @UserSign, @CreateDate, @MaxRejReqr, @MaxReqr)";

            ApprovalRequestsService oApprovalRequestsService = GlobalVar.Empresa.GetCompanyService().GetBusinessService(ServiceTypes.ApprovalRequestsService);
            ApprovalRequest oApprovalRequest = oApprovalRequestsService.GetDataInterface(ApprovalRequestsServiceDataInterfaces.arsApprovalRequest);
            
            List<SqlParameter> sp = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName = "@WtmCode", SqlDbType = SqlDbType.NVarChar, Value= (int)authTemplate},
                new SqlParameter() {ParameterName = "@OwnerID", SqlDbType = SqlDbType.NVarChar, Value = this.usuario.UserCode},
                new SqlParameter() {ParameterName = "@DocEntry", SqlDbType = SqlDbType.NVarChar, Value = vDrafts.DocEntry},
                new SqlParameter() {ParameterName = "@ObjType", SqlDbType = SqlDbType.Int, Value = oApprovalRequest.ObjectType},
                new SqlParameter() {ParameterName = "@DocDate", SqlDbType = SqlDbType.Int, Value = vDrafts.DocDate},
                new SqlParameter() {ParameterName = "@CurrStep", SqlDbType = SqlDbType.Int, Value = oApprovalRequest.CurrentStage},
                new SqlParameter() {ParameterName = "@Remarks", SqlDbType = SqlDbType.Int, Value = vDrafts.OpeningRemarks},
                new SqlParameter() {ParameterName = "@UserSign", SqlDbType = SqlDbType.Int, Value = this.usuario.UserCode},
                new SqlParameter() {ParameterName = "@CreateDate", SqlDbType = SqlDbType.Int, Value = DateTime.Now},
                new SqlParameter() {ParameterName = "@MaxRejReqr", SqlDbType = SqlDbType.Int, Value = 1},
                new SqlParameter() {ParameterName = "@MaxReqr", SqlDbType = SqlDbType.Int, Value = 1}
            };

            Util.createUpdateFromQuery(sql, sp);
            /*
            ApprovalRequestsService oApprovalRequestsService = GlobalVar.Empresa.GetCompanyService().GetBusinessService(ServiceTypes.ApprovalRequestsService);
            ApprovalRequestsParams oApprovalRequestsParams = oApprovalRequestsService.GetDataInterface(ApprovalRequestsServiceDataInterfaces.arsApprovalRequestsParams);
            ApprovalRequest oApprovalRequest = oApprovalRequestsService.GetDataInterface(ApprovalRequestsServiceDataInterfaces.arsApprovalRequest);
            ApprovalRequestParams oApprovalRequestParams = oApprovalRequestsService.GetDataInterface(ApprovalRequestsServiceDataInterfaces.arsApprovalRequestParams);

            //Get request list 
            oApprovalRequestsParams = oApprovalRequestsService.GetAllApprovalRequestsList();
            oApprovalRequestParams = oApprovalRequestsParams.Item(oApprovalRequestsParams.Count - 1);

            //Approve request  
            oApprovalRequest = oApprovalRequestsService.GetApprovalRequest(oApprovalRequestParams);
            oApprovalRequest.ApprovalRequestDecisions.Add();
            oApprovalRequest.ApprovalRequestDecisions.Item(0).Remarks = "Approved";
            oApprovalRequest.ApprovalRequestDecisions.Item(0).Status = BoApprovalRequestDecisionEnum.ardApproved;

            //Incase we want to approve with another user, uncomment the following 2 lines 
            //oApprovalRequest.ApprovalRequestDecisions.Item(0).ApproverUserName = B1User 
            //oApprovalRequest.ApprovalRequestDecisions.Item(0).ApproverPassword = B1Password 
            
            try {
                oApprovalRequestsService.UpdateRequest(oApprovalRequest);
            } catch (Exception e) {
                Util.showMessage(e.Message);
            }
            */
            /*

            Dim oCmpSrv As SAPbobsCOM.CompanyService
            Dim oMessageService As MessagesService
            Dim oMessage As Message
            Dim pMessageDataColumns As MessageDataColumns
            Dim pMessageDataColumn As MessageDataColumn
            Dim oLines As MessageDataLines
            Dim oLine As MessageDataLine
            Dim oRecipientCollection As RecipientCollection

            'get company service
            oCmpSrv = oCompany.GetCompanyService

            'get msg service
            oMessageService = oCmpSrv.GetBusinessService(ServiceTypes.MessagesService)

            'get the data interface for the new message
            oMessage=oMessageService.GetDataInterface(MessagesServiceDataInterface.msdiMessage)

            'fill subject
            oMessage.Subject = "My Subject"

            'fill text
            oMessage.Text = "My Text"

            'Add Recipient
            oRecipientCollection = oMessage.RecipientCollection

            'Add new a recipient
            oRecipientCollection.Add()

            'send internal message
            oRecipientCollection.Item(0).SendInternal = BoYesNoEnum.tYES

            'add existing user code
            oRecipientCollection.Item(0).UserCode = "manager"

            'get columns data
            pMessageDataColumns = oMessage.MessageDataColumns

            'get column
            pMessageDataColumn = pMessageDataColumns.Add()

            'set column name
            pMessageDataColumn.ColumnName = "My Column Name"

            'get lines
            oLines = pMessageDataColumn.MessageDataLines()

            'add new line
            oLine = oLines.Add()

            'set the line value
            oLine.Value = "My Value"

            'send the message
            oMessageService.SendMessage(oMessage)

            */
        }

        private bool existeDescuento()
        {
            bool retorno = false;
            PriceLists priceList = GlobalVar.Empresa.GetBusinessObject(BoObjectTypes.oPriceLists);
            foreach(OfertaVentaLine line in ofertaVenta.Lines)
            {
                cliente.PriceListNum
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
