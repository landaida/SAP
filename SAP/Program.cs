using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SAP.util;
using SAP.forms;
namespace SAP
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            //inicializa a conexao da empresa por primera y unica vez
            Task task = new Task(() => GlobalVar.inicializarEmpresa());
            task.Start();
            //inicializa conexao banco
            Task task1 = new Task(() => ConexaoFactory.initSQLConection());
            task1.Start();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MDIParent());
            
        }
    }
}
