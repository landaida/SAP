using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SAPbobsCOM;
using SAP.util;
namespace SAP.forms
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            this.login();
        }

        private void login()
        {
            if (this.isValidForm())
            {
                if (GlobalVar.Empresa.AuthenticateUser(this.txtUsuario.Text, this.txtContrasena.Text) == AuthenticateUserResultsEnum.aturUsernamePasswordMatch)
                {
                    Int16 code = Util.getValueFromQuery<Int16>("select o.USERID from OUSR o where o.USER_CODE = '"+this.txtUsuario.Text+"'");
                    GlobalVar.usuarioId = code;
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    Util.showMessage("Por favor ingrese otra credencial, usuario o contraseña inválida.");
                }
            }
        }

        private bool isValidForm()
        {
            bool retorno = false;
            if(this.txtUsuario.Text.Trim().Length <= 0)
            {
                Util.showMessage("Por favor ingrese el nombre del usuario.");
            }
            else if (this.txtContrasena.Text.Trim().Length <= 0)
            {
                Util.showMessage("Por favor ingrese una contraseña.");
            }
            else
            {
                retorno = true;
            }
            return retorno;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();            
        }
    }
}