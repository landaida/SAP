using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using SAP.model;
using SAPbobsCOM;
using SAP.util;

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
        List<Aprobador> aprobadores;
        List<Almacen> almacenes;
        List<Sucursal> sucursales;
        Documents vDrafts;
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
            almacenes = Util.getGenericList<Almacen>("whsCode", "whsName", "owhs").ToList<Almacen>();
            sucursales = Util.getGenericList<Sucursal>("ocrCode", "prcCode", "ocr1").ToList<Sucursal>();

            ComboUtil.populateSearchLookUpEdit<Cliente>(this.cmbCliente, "CardCode", "CardName", "ocrd");
            ComboUtil.populateSearchLookUpEdit<Vendedor>(this.cmbVendedor, "SlpCode", "SlpName", "oslp", " and active = 'Y' and locked = 'N'");
            ComboUtil.populateSearchLookUpEdit(this.cmbProduto, "ItemCode", "ItemName", productos);
            ComboUtil.populateSearchLookUpEdit<Condicion>(this.cmbCondicion, "GroupNum", "PymntGroup", "octg");
            ComboUtil.populateSearchLookUpEdit(this.cmbAlmacen, "WhsCode", "WhsName", almacenes);
            ComboUtil.populateSearchLookUpEdit(this.cmbSucursal, "OcrCode", "PrcCode", sucursales);

            this.ofertaVentaDoc = GlobalVar.Empresa.GetBusinessObject(BoObjectTypes.oQuotations);
            this.usuario = GlobalVar.Empresa.GetBusinessObject(BoObjectTypes.oUsers);
            this.usuario.GetByKey(11);


            this.ofertaVenta = new OfertaVenta();            
            BindingList<OfertaVentaLine> listCotizacion = new BindingList<OfertaVentaLine>(this.ofertaVenta.Lines);
            
            listCotizacion.AllowNew = true;
            this.gridControl1.DataSource = listCotizacion;
            gridView2.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            //bindingListProductAddingNew += this.OnAddingNew;
            listCotizacion.AddingNew += this.OnAddingNew;
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

        private void OnAddingNew(object sender, AddingNewEventArgs e)
        {
            if(e.NewObject == null)
            {
                OfertaVentaLine line = new OfertaVentaLine();                
                line.Almacen = (from d in this.almacenes where d.WhsCode.ToUpper().Contains("CDE") select d).First();
                line.Sucursal = (from d in this.sucursales where d.OcrCode.ToUpper().Contains("CDE") select d).First();
                e.NewObject = line;
            }
        }

        private void addLine()
        {
            OfertaVentaLine line = new OfertaVentaLine();
            line.Almacen = this.almacenes.First();
            line.Sucursal = this.sucursales.First();
            this.ofertaVenta.Lines.Add(line);
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
                    GlobalVar.cardCode = cliente.CardCode;
                    this.gridView2.OptionsBehavior.Editable = true;
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
                        Util.showMessage("Oferta de venta nr: " + docNum + " generada con éxito");
                        this.enableCopyToSalesOrder(true);
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

        private void enableCopyToSalesOrder(bool v)
        {
            this.btnCopyToSalesOrders.Enabled = v;
            this.btnGuardar.Enabled = !v;
            this.colAlmacen.Visible = v;
            this.colSucursal.Visible = v;
        }

        private void copyToSalesOrders()
        {
            if((this.vDrafts != null && this.vDrafts.CardCode != null) || this.verificarEtapasAutorizacion() && GlobalVar.Empresa.Connected == true)
            {
                Documents doc = vDrafts ?? ofertaVentaDoc;

                Documents Orden = GlobalVar.Empresa.GetBusinessObject(BoObjectTypes.oOrders);
                Orden.CardCode = doc.CardCode;
                Orden.DocDate = doc.DocDate;
                Orden.DocDueDate = doc.DocDueDate;
                Orden.Comments = doc.Comments;
                Orden.DocCurrency = doc.DocCurrency;
                Orden.GroupNumber = doc.GroupNumber;
                for (int i = 0; i <= this.lines().Count - 1; i++)
                {
                    OfertaVentaLine item = this.lines()[i];

                    Orden.Lines.ItemCode = item.ProductoId;
                    Orden.Lines.Quantity = item.Cantidad;
                    Orden.Lines.TaxCode = item.IndicadorImpuesto;
                    Orden.Lines.PriceAfterVAT = item.PrecioUnitarioGravada;
                    Orden.Lines.WarehouseCode = item.Almacen.WhsCode;
                    Orden.Lines.CostingCode = item.Sucursal.PrcCode;

                    if (i < this.lines().Count - 1)
                        Orden.Lines.Add();
                }

                int res = Orden.Add();

                if (res == 0)
                {
                    String docNum = "";
                    GlobalVar.Empresa.GetNewObjectCode(out docNum);
                    this.txtId.Text = docNum;
                    this.enableCopyToSalesOrder(true);
                    Util.showMessage("Orden de venta nr: " + docNum + " generada con éxito");
                    this.limpiar();
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
            bool retorno = false, existeDescuento = false, superaLimiteCredito = false, titulosVencidos = false;

            if (this.etapaExisteDescuento())
                existeDescuento = true;
            if (this.etapaSuperaLimiteCredito())
                superaLimiteCredito = true;
            if (this.etapaTitulosVencidos())
                titulosVencidos = true;

            if(existeDescuento || superaLimiteCredito || titulosVencidos)
            {
                string wstCodes = "0";//el cero no hara nada solo me sirve para no tratar la coma(,) mas abajo
                if (existeDescuento) wstCodes += ",1";
                if (superaLimiteCredito) wstCodes += ",2";
                if (titulosVencidos) wstCodes += ",3";
                
                //trae los aprobadores, si se repite en wst1 ya hace un distinct
                string sql = "select distinct userid from wst1 where WstCode in ("+wstCodes+")";
                this.aprobadores = Util.getGenericList<Aprobador>(null, null, null, null, null, sql).ToList<Aprobador>();

                AprovalComments dialog = new AprovalComments();
                dialog.setComponentes(!existeDescuento, !superaLimiteCredito, true);
                // Show testDialog as a modal dialog and determine if DialogResult = OK.
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {

                    List<AuthorizationTemplate> listAuth = new List<AuthorizationTemplate>();

                    if (existeDescuento)
                        listAuth.Add(AuthorizationTemplate.Porcentagem_Desc_02);                        
                    if (superaLimiteCredito)
                        listAuth.Add(AuthorizationTemplate.Limite_de_Credito_03);
                    if (titulosVencidos)
                        listAuth.Add(AuthorizationTemplate.Titulos_Vencidos_03);
                    if(listAuth.Count > 0)
                    this.saveDocumentDrafts(listAuth, dialog.getComentarioTituloVencido);

                    sql = "update onnm set AutoKey = (select max(wddcode) from OWDD) where ObjectCode = '122'";
                    Util.createUpdateFromQuery(sql, null);
                    sql = "update onnm set AutoKey = (select max(code) from OALR) where ObjectCode = '81'";
                    Util.createUpdateFromQuery(sql, null);
                    Util.showMessage("Documentos generados exitosamente, aguarde las autorizaciones correspondientes.");
                    this.limpiar();

                }
                dialog.Dispose();               
            }

            return retorno;
        }

        private bool etapaSuperaLimiteCredito()
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
                totalDocPreliminares = Util.getValueFromQuery<Double>(sql);
            }
            catch(Exception e)
            {
                Util.showMessage(e.Message);
            }
            

            //Saldo de linea de credito
            Double saldo = balance + ordersBal + totalDocPreliminares + Convert.ToDouble(this.txtTotal.EditValue);

            if (saldo > limiteCredito)                
                retorno = true;
                

            return retorno;
        }

        private void saveDocumentDrafts(List<AuthorizationTemplate> listAuthTemplate, String remarks)
        {
            //Create the Documents object
            vDrafts = GlobalVar.Empresa.GetBusinessObject(BoObjectTypes.oDrafts);

            //Set values to the fields
            vDrafts.DocObjectCode = BoObjectTypes.oOrders;
            vDrafts.CardCode = ofertaVentaDoc.CardCode;
            vDrafts.HandWritten = BoYesNoEnum.tNO;
            vDrafts.DocDate = this.txtFechaDocumento.Value;
            vDrafts.DocDueDate = this.txtFechaLanzamiento.Value;
            vDrafts.DocTotal = Convert.ToDouble(this.txtTotal.EditValue);
            vDrafts.GroupNumber = ofertaVentaDoc.GroupNumber;
            vDrafts.OpeningRemarks = remarks;
            if(this.cmbVendedor.EditValue != null)
                vDrafts.SalesPersonCode = (int)this.cmbVendedor.EditValue;
            if (this.txtObservacion.Text.Trim().Length == 0)
                vDrafts.Comments = "Basado en la oferta de venta " + this.txtId.Text;
            else
                vDrafts.Comments = this.txtObservacion.Text;

            for (int i = 0; i <= this.lines().Count - 1; i++)
            {
                OfertaVentaLine item = this.lines()[i];

                vDrafts.Lines.ItemCode = item.ProductoId;
                vDrafts.Lines.Quantity = item.Cantidad;
                vDrafts.Lines.TaxCode = item.IndicadorImpuesto;
                vDrafts.Lines.PriceAfterVAT = item.PrecioUnitarioGravada;
                vDrafts.Lines.WarehouseCode = item.Almacen.WhsCode;
                vDrafts.Lines.CostingCode = item.Sucursal.OcrCode;
                if (i < this.lines().Count - 1)
                    vDrafts.Lines.Add();
            }

            int retVal = vDrafts.Add();


            if(retVal == 0){
                String docNum = "";
                GlobalVar.Empresa.GetNewObjectCode(out docNum);
                ReportUtils.reportLoad("Separacion.rpt");
                Util.showMessage("Preliminar de venta nr: " + docNum + " generada con éxito");
                this.createApprovalRequest(vDrafts, listAuthTemplate, Convert.ToInt32(docNum));
            }
            else
            {
                System.Console.WriteLine(GlobalVar.Empresa.GetLastErrorDescription());
                Util.showMessage(GlobalVar.Empresa.GetLastErrorDescription());
            }
        }

        private void createApprovalRequest(Documents vDrafts, List<AuthorizationTemplate> listAuthTemplate, int idDraft)
        {
            String sql = "insert into OWDD (WddCode, WtmCode, OwnerID, DocEntry, ObjType, DocDate, CurrStep, Remarks, UserSign, CreateDate, CreateTime, MaxRejReqr, MaxReqr)"
                + "values(@WddCode, @WtmCode, @OwnerID, @DocEntry, @ObjType, @DocDate, @CurrStep, @Remarks, @UserSign, @CreateDate, @CreateTime, @MaxRejReqr, @MaxReqr)";
            
            foreach(AuthorizationTemplate authTemplate in listAuthTemplate)
            {
                int wddCode = Util.getValueFromQuery<int>("select max(WddCode) + 1 value from owdd");
                List<SqlParameter> sp = new List<SqlParameter>()
                {
                    new SqlParameter() {ParameterName = "@WddCode", SqlDbType = SqlDbType.Int, Value= wddCode},
                    new SqlParameter() {ParameterName = "@WtmCode", SqlDbType = SqlDbType.Int, Value= (int)authTemplate},
                    new SqlParameter() {ParameterName = "@OwnerID", SqlDbType = SqlDbType.NVarChar, Value = GlobalVar.usuarioId},
                    new SqlParameter() {ParameterName = "@DocEntry", SqlDbType = SqlDbType.Int, Value = idDraft},
                    new SqlParameter() {ParameterName = "@ObjType", SqlDbType = SqlDbType.NVarChar, Value = 17},
                    new SqlParameter() {ParameterName = "@DocDate", SqlDbType = SqlDbType.DateTime, Value = vDrafts.DocDate},
                    new SqlParameter() {ParameterName = "@CurrStep", SqlDbType = SqlDbType.Int, Value = 1},
                    new SqlParameter() {ParameterName = "@Remarks", SqlDbType = SqlDbType.NVarChar, Value = vDrafts.OpeningRemarks},
                    new SqlParameter() {ParameterName = "@UserSign", SqlDbType = SqlDbType.NVarChar, Value = GlobalVar.usuarioId},
                    new SqlParameter() {ParameterName = "@CreateDate", SqlDbType = SqlDbType.DateTime, Value = DateTime.Today},
                    new SqlParameter() {ParameterName = "@CreateTime", SqlDbType = SqlDbType.SmallInt, Value = Util.getNowTime()},
                    new SqlParameter() {ParameterName = "@MaxRejReqr", SqlDbType = SqlDbType.Int, Value = 1},
                    new SqlParameter() {ParameterName = "@MaxReqr", SqlDbType = SqlDbType.Int, Value = 1}
                };

                Util.createUpdateFromQuery(sql, sp);

                this.createApprovalAlerts(vDrafts, authTemplate, idDraft, wddCode);
            }
        }

        private void createApprovalAlerts(Documents vDrafts, AuthorizationTemplate authTemplate, int idDraft, int wddCode)
        {            
            List<int> aproUsers = new List<int>();
            foreach(Aprobador apro in this.aprobadores)
            {   
                aproUsers.Add(apro.UserId);
            }

            //inserta un alerta para cada usuario que autoriza dicha regla
            String sql = "insert into OALR (Code, Type, Priority, Subject, UserText, DataCols, DataParams, MsgData, UserSign, DataSource)"
                + "values(@Code, @Type, @Priority, @Subject, @UserText, @DataCols, @DataParams, @MsgData, @UserSign, @DataSource)";
            foreach (int aproUserId in aproUsers)
            {                
                int code = Util.getValueFromQuery<int>("select max(Code) + 1 value from OALR");

                string msg = "Pedido de cliente basado en núm.documento preliminar " + idDraft + "	122	" + wddCode + "      "+aproUserId+"          "+ GlobalVar.usuarioId + "         ";
                List<SqlParameter> sp = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName = "@Code", SqlDbType = SqlDbType.Int, Value= code},
                new SqlParameter() {ParameterName = "@Type", SqlDbType = SqlDbType.NVarChar, Value= "M"},
                new SqlParameter() {ParameterName = "@Priority", SqlDbType = SqlDbType.NVarChar, Value= 1},
                new SqlParameter() {ParameterName = "@Subject", SqlDbType = SqlDbType.NVarChar, Value= "Petición de autorización documento"},
                new SqlParameter() {ParameterName = "@UserText", SqlDbType = SqlDbType.NVarChar, Value= vDrafts.OpeningRemarks},
                new SqlParameter() {ParameterName = "@DataCols", SqlDbType = SqlDbType.Int, Value= 1},
                new SqlParameter() {ParameterName = "@DataParams", SqlDbType = SqlDbType.NVarChar, Value= "Petición de autorización documY"},
                new SqlParameter() {ParameterName = "@MsgData", SqlDbType = SqlDbType.NVarChar, Value= msg},
                new SqlParameter() {ParameterName = "@UserSign", SqlDbType = SqlDbType.Int, Value= GlobalVar.usuarioId},
                new SqlParameter() {ParameterName = "@DataSource", SqlDbType = SqlDbType.NVarChar, Value= "N"}

            };

                Util.createUpdateFromQuery(sql, sp);

                this.createApprovalRequestLine(aproUserId, wddCode);
            }
        }

        private void createApprovalRequestLine(int aproUserId, int wddCode)
        {
            String sql = "insert into WDD1 (WddCode, StepCode, UserID, Status, UserSign, CreateDate, CreateTime)"
                + "values(@WddCode, @StepCode, @UserID, @Status, @UserSign, @CreateDate, @CreateTime)";
            //int code = Util.getValueFromQuery<int>("select max(Code) + 1 value from OALR");

            //int docNumDraft = Util.getValueFromQuery<int>("select DocNum from ODRF where DocEntry = " + wddCode);


           // string msg = "Pedido de cliente basado en núm.documento preliminar " + idDraft + "	122	" + wddCode + "      " + aproUserId + "          " + GlobalVar.usuarioId + "         ";
            List<SqlParameter> sp = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName = "@WddCode", SqlDbType = SqlDbType.Int, Value= wddCode},
                new SqlParameter() {ParameterName = "@StepCode", SqlDbType = SqlDbType.Int, Value= 1},
                new SqlParameter() {ParameterName = "@UserID", SqlDbType = SqlDbType.Int, Value= aproUserId},
                new SqlParameter() {ParameterName = "@Status", SqlDbType = SqlDbType.NVarChar, Value= "W"},
                new SqlParameter() {ParameterName = "@UserSign", SqlDbType = SqlDbType.Int, Value= GlobalVar.usuarioId},
                new SqlParameter() {ParameterName = "@CreateDate", SqlDbType = SqlDbType.DateTime, Value= DateTime.Today},
                new SqlParameter() {ParameterName = "@CreateTime", SqlDbType = SqlDbType.SmallInt, Value= Util.getNowTime()}
            };

            Util.createUpdateFromQuery(sql, sp);


            this.createApprovalAlertsHeader(aproUserId);
        }

        private void createApprovalAlertsHeader(int aproUserId)
        {
            String sql = "insert into OAIB (AlertCode, UserSign, Opened, RecDate, RecTime, WasRead, Deleted)"
            + "values(@AlertCode,@UserSign,@Opened,@RecDate, @RecTime,  @WasRead,@Deleted)";
            int code = Util.getValueFromQuery<int>("select max(AlertCode) + 1 value from OAIB");            
            
            List<SqlParameter> sp = new List<SqlParameter>()
            {
            new SqlParameter() {ParameterName = "@AlertCode", SqlDbType = SqlDbType.Int, Value= code},
            new SqlParameter() {ParameterName = "@UserSign", SqlDbType = SqlDbType.Int, Value= aproUserId},
            new SqlParameter() {ParameterName = "@Opened", SqlDbType = SqlDbType.NVarChar, Value= "N"},
            new SqlParameter() {ParameterName = "@RecDate", SqlDbType = SqlDbType.DateTime, Value= DateTime.Today},
            new SqlParameter() {ParameterName = "@RecTime", SqlDbType = SqlDbType.SmallInt, Value= Util.getNowTime()},
            new SqlParameter() {ParameterName = "@WasRead", SqlDbType = SqlDbType.NVarChar, Value= "N"},
            new SqlParameter() {ParameterName = "@Deleted", SqlDbType = SqlDbType.NVarChar, Value= "N"}

            };

            Util.createUpdateFromQuery(sql, sp);
        }

        private bool etapaExisteDescuento()
        {
            bool retorno = false;

            this.ofertaVenta.Lines = this.ofertaVenta.Lines.Where(p => Util.getItemPrice(GlobalVar.cardCode, p.ProductoId, this.txtFechaDocumento.Value) > p.PrecioUnitario).ToList<OfertaVentaLine>();

            if (this.ofertaVenta.Lines.Count > 0)
                retorno = true;

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
                    this.setOfertaVentaFromOtherDocs(0);
                }
            }
        }

        private void setOfertaVentaFromOtherDocs(int tipo)
        {
            Documents doc = tipo == 1 ? vDrafts : ofertaVentaDoc;

            this.cmbCliente.EditValue = doc.CardCode; 
            this.txtFechaDocumento.Value = doc.DocDate;
            this.txtFechaLanzamiento.Value = doc.DocDueDate;
            this.txtObservacion.Text = doc.Comments;
            this.cmbVendedor.EditValue = doc.SalesPersonCode;

            this.ofertaVenta.Lines.Clear();
            for (int i = 0; i <= doc.Lines.Count - 1; i++)
            {

                OfertaVentaLine line = new OfertaVentaLine();
                doc.Lines.SetCurrentLine(i);
                line.ProductoId = doc.Lines.ItemCode;
                line.Cantidad = doc.Lines.Quantity;
                line.PrecioUnitario = doc.Lines.PriceAfterVAT;
                line.IndicadorImpuesto = doc.Lines.TaxCode;
                line.Almacen = (from d in this.almacenes where d.WhsCode.ToUpper().Contains(doc.Lines.WarehouseCode) select d).First();
                line.Sucursal = (from d in this.sucursales where d.OcrCode.ToUpper().Contains(doc.Lines.CostingCode) select d).First();
                this.ofertaVenta.Lines.Add(line);
            }

            this.gridView2.RefreshData();
            this.actualizaTotales();
            this.enableCopyToSalesOrder(true);

            this.gridView2.OptionsBehavior.Editable = true;
            this.cmbCliente.Enabled = false;
            this.txtId.Enabled = false;
        }

        public void getDocumentDraftByKey(int docEntry)
        {
            vDrafts = GlobalVar.Empresa.GetBusinessObject(BoObjectTypes.oDrafts);
            bool res = vDrafts.GetByKey(docEntry);
            if (res)
            {
                this.setOfertaVentaFromOtherDocs(1);
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
            this.enableCopyToSalesOrder(false);

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

            this.gridView2.OptionsBehavior.Editable = false;
            this.cmbCliente.Enabled = true;
            this.txtId.Enabled = true;

            this.ofertaVentaDoc = GlobalVar.Empresa.GetBusinessObject(BoObjectTypes.oOrders);
            this.vDrafts = GlobalVar.Empresa.GetBusinessObject(BoObjectTypes.oDrafts);
        }
        
        private bool etapaTitulosVencidos()
        {   
            string sql = " select  max(DATEDIFF(day, b.duedate, getdate())) as DiasVencidos "
                        + " from oinv a, inv6 b where a.docentry = b.docentry  and a.GroupNum not in (-1) "
                        + " and(b.InsTotal - b.PaidToDate) > 0 and a.cardcode = '"+cliente.CardCode+"'";
            int diasAtrasados = Util.getValueFromQuery<int>(sql);
            return diasAtrasados > 0;
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
        
        private void txtFechaDocumento_ValueChanged(object sender, EventArgs e)
        {
            GlobalVar.datetime = this.txtFechaDocumento.Value;
        }
        #endregion
    }
}
