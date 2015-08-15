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
namespace SAP.forms.movimientos
{
    public partial class frmCotizacion : Form
    {
        public frmCotizacion()
        {
            InitializeComponent();

            //Method 1. center at initilization
            //this.StartPosition = FormStartPosition.CenterScreen;

            //Method 2. The manual way
            this.StartPosition = FormStartPosition.Manual;
            this.Top = (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2;
            this.Left = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2;

            Cotizacion cotizacion = new Cotizacion();
            cotizacion.Id = 01;
            cotizacion.Fecha = new DateTime();

            ICollection<CotizacionLine> lines = new List<CotizacionLine>();

            CotizacionLine line = new CotizacionLine();
            line.Id = 1;
            line.Producto = new Producto();
            line.Producto.Id = 60;
            line.Producto.Nombre = "NB ACER ASPIRE";
            line.Cantidad = 50;
            line.Descuento = 0;
            lines.Add(line);

            this.cotizacionBindingSource.Add(cotizacion);
            this.linesBindingSource.Add(cotizacion.Lines);

        }
    }
}
