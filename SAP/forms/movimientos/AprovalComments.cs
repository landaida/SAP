using System;
using System.Windows.Forms;
namespace SAP.forms.movimientos
{   
    public partial class AprovalComments : Form
    {
        public String comentarioDescuento;
        public String comentarioLimiteCredito;
        public String comentarioTituloVencido;

        public AprovalComments()
        {
            InitializeComponent();
            this.btnGuardar.DialogResult = DialogResult.OK;
            this.btnCancelar.DialogResult = DialogResult.Cancel;
        }

        public void setComponentes(bool disableDescuento, bool disableLimiteCredito, bool disableTituloVencido)
        {
            this.txtComentarioDescuento.Enabled = !disableDescuento;
            this.txtComentarioLimiteCredito.Enabled = !disableLimiteCredito;
            this.txtComentarioTituloVencido.Enabled = !disableTituloVencido;
        }

        public string getComentarioDescuento { get { return this.txtComentarioDescuento.Text; } }
        public string getComentarioLimiteCredito { get { return this.txtComentarioLimiteCredito.Text; } }
        public string getComentarioTituloVencido { get { return this.txtComentarioTituloVencido.Text; } }

    }
}
