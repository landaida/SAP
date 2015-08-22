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
            ComboUtil.populateComboBox(this.cmbCliente, "cardCode", "cardName", "ocrd");

            this.cmbCliente.SelectedIndex = -1;
            // assume you bind a list of persons to the ComboBox with 'Name' as DisplayMember:
            this.cmbCliente.DataSource = this.cmbCliente.Items.Cast<string>().Select(i => new Cliente { CardName = i }).ToList();
            this.cmbCliente.DisplayMember = "CardName";
            // then you have to set the PropertySelector like this:
            this.cmbCliente.PropertySelector = collection => collection.Cast<Cliente>().Select(p => p.CardName);
            // filter rule can be customized: e.g. a StartsWith search:            
            //suggestComboBox1.FilterRule = (item, text) => item.StartsWith(text.Trim(), StringComparison.CurrentCultureIgnoreCase);

            // ordering rule can also be customized: e.g. order by the surname:
            //this.cmbCliente.SuggestListOrderRule = s => s.Split(' ')[0];

            
        }
        #endregion
        
        #region FunctionsC#
        
        public frmCotizacion()
        {
            InitializeComponent();
            Task task = new Task(() => this.instanciarOjectosSAP());
            task.Start();            

            this.StartPosition = FormStartPosition.Manual;
            this.Top = (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2;
            this.Left = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2;

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
        #endregion



    }
}
