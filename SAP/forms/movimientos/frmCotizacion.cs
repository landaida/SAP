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

                Cursor.Current = Cursors.WaitCursor;
                empresa = GlobalVar.Empresa;            

                if (empresa.Connected == true)
                {                
                    cotizacion = empresa.GetBusinessObject(BoObjectTypes.oQuotations);
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
    }
}
