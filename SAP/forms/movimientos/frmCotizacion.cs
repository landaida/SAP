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
namespace SAP.forms.movimientos
{
    public partial class frmCotizacion : Form
    {
        #region Declare
        Documents cotizacion;
        List<CotizacionLine> lines = new List<CotizacionLine>();
        Company empresa;
        BusinessPartners cliente;
        List<Producto> productos;
        
        int response = 0;
        #endregion

        #region Functions
        private void bindingControls()
        {
            this.txtId.DataBindings.Add("Text", cotizacion, "Comments");            
        }
        private void instanciarOjectosSAP()
        {
            Cursor.Current = Cursors.WaitCursor;
            empresa = GlobalVar.Empresa;
            if (empresa.Connected == true)
            {
                cotizacion = empresa.GetBusinessObject(BoObjectTypes.oQuotations);
                cliente = empresa.GetBusinessObject(BoObjectTypes.oBusinessPartners);
                cliente.CardCode = "C0003144";
                cotizacion.CardCode = cliente.CardCode;
                cotizacion.Lines.ItemCode = "101100";
                cotizacion.Lines.Quantity = 1;
                cotizacion.Lines.PriceAfterVAT = 60000;
                cotizacion.Lines.TaxCode = "IVA_10";
                this.bindingControls();
            }
            else
            {
                Console.WriteLine(empresa.GetLastErrorDescription());
            }
        }
        private void inicializarObjetos()
        {
            this.StartPosition = FormStartPosition.Manual;
            this.Top = (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2;
            this.Left = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2;

            ComboUtil.populateComboBox(this.cmbCliente, "cardCode", "cardName", "ocrd", typeof(Cliente));

            //Cria uma lista de productos, isso facilitara na hora de carregar o combo de produtos en cada line do quotation
            productos = Util.getGenericList<Producto>("itemCode", "itemName", "oitm").ToList<Producto>();
            this.colItemNro.DataPropertyName = "Id";
            this.colDescripcion.DataPropertyName = "Producto.ItemName";
            this.colCantidad.DataPropertyName = "Cantidad";
            this.colPrecioUnitario.DataPropertyName = "PrecioUnitario";
            this.colPorcentajeDescuento.DataPropertyName = "Descuento";
            this.colIndicadorImpuesto.DataPropertyName = "IndicadorImpuesto";


            this.addLine();
            this.dgvLines.AutoGenerateColumns = false;
            this.dgvLines.DataSource = lines;


            if (colDescripcion.Items.Count == 0)
            {
                ComboUtil.confgComboBox(colDescripcion, "ItemCode", "ItemName", productos);
            }
        }
        private bool lineIsValid(int index)
        {
            bool retorno = false;
            DataGridViewCellCollection cells = this.dgvLines.Rows[index].Cells;
            if (cells[colItemNro.Name].Value != null && 
                cells[colDescripcion.Name].Value != null && 
                cells[colCantidad.Name].Value != null && (Double)cells[colCantidad.Name].Value > 0 &&
                cells[colPrecioUnitario.Name].Value != null && (Double)cells[colPrecioUnitario.Name].Value > 0)
            {                
                retorno = true;
            }
            return retorno;
        }

        private void addLine()
        {
            this.dgvLines.EndEdit();        
            //resuelve error de no poder add line
            this.dgvLines.DataSource = null;

            this.lines.Add(new CotizacionLine());
            this.dgvLines.AutoGenerateColumns = false;
            this.dgvLines.DataSource = lines;
            this.dgvLines.CurrentCell = this.dgvLines[lines.Count - 1, 0];
            //this.dgvLines.Rows[lines.Count - 1].Selected = true;

            this.dgvLines.Refresh();
        }
        #endregion
        
        #region FunctionsC#
        
        public frmCotizacion()
        {
            InitializeComponent();
            Task task = new Task(() => this.instanciarOjectosSAP());
            task.Start();
        }

        private void frmCotizacion_Load(object sender, EventArgs e)
        {
            this.inicializarObjetos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine(this.cotizacion.Comments);
            response = cotizacion.Add();
            if(response == 0)
            {
                    
            }
            else
            {
                Console.WriteLine(this.empresa.GetLastErrorDescription());
            }
        }

        private void dgvLines_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == colDescripcion.Index)
            {
                this.lines[e.RowIndex].Producto = productos.Find(x => x.ItemCode.Equals(dgvLines.Rows[e.RowIndex].Cells[colDescripcion.Name].Value));
                this.lines[e.RowIndex].Id = Int32.Parse(this.lines[e.RowIndex].Producto.ItemCode);
                this.lines[e.RowIndex].Cantidad = 1;
                this.dgvLines.Refresh();
            }
        }

        #endregion

        private void dgvLines_KeyUp(object sender, KeyEventArgs e)
        {
            bool addLine = false;
            switch (e.KeyCode){
                case Keys.Enter:
                    addLine = true;
                    break;
                case Keys.Down:
                    addLine = true;
                    break;
            }
                
            if (addLine && this.lines.Count - 1 == this.dgvLines.CurrentRow.Index && 
                this.lineIsValid(this.dgvLines.CurrentRow.Index))
            {
                this.addLine();
            }
        }

        private void btnAddLine_Click(object sender, EventArgs e)
        {
            
        }

        private void dgvLines_RowValidated(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
