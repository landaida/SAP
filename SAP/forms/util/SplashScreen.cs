using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAP.forms.util
{
    public partial class SplashScreen : Form
    {
        public bool close = false;
        public SplashScreen()
        {
            InitializeComponent();
        }

        public void setLabel(string label)
        {
            this.labelControl1.Text = label;
        }

        private void SplashScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!close)
                e.Cancel = true;
        }
    }
}
