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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            this.comentarioDescuento = this.txtComentarioDescuento.Text;
            this.comentarioLimiteCredito = this.txtComentarioLimiteCredito.Text;
            this.comentarioTituloVencido = this.txtComentarioTituloVencido.Text;
        }
    }
}
