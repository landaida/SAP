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
        Company empresa;
        BusinessPartners cliente;
        
        int response = 0;
        #endregion

        #region Functions
        private void bindingControls()
        {
            this.txtId.DataBindings.Add("Text", cotizacion, "Comments");
                 
        }
        #endregion
        
        #region FunctionsC#
        
        public frmCotizacion()
        {
            InitializeComponent();
            
            this.StartPosition = FormStartPosition.Manual;
            this.Top = (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2;
            this.Left = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2;

            List<String> list = ComboUtil.populateComboBox(this.cmbCliente, "cardCode", "cardName", "ocrd");

            AutoCompleteStringCollection data = new AutoCompleteStringCollection();
            data.AddRange(list.ToArray());
            this.txtStatus.AutoCompleteCustomSource = data;
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
        #endregion

        private void frmCotizacion_Load(object sender, EventArgs e)
        {

        }

        private void txtStatus_KeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}
