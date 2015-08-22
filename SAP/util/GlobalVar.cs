using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAPbobsCOM;
using System.Threading;

namespace SAP.util
{
    public static class GlobalVar
    {

        public static Company empresa;

        public static void inicializarEmpresa()
        {
            int res = 0;
            if (empresa == null)
            {
                empresa = new Company();
                empresa.DbServerType = DBConfig.DBServerType;
                empresa.Server = DBConfig.Server;
                empresa.CompanyDB = DBConfig.DBName;
                empresa.UserName = DBConfig.BOUser;
                empresa.Password = DBConfig.BOPassword;
                empresa.DbUserName = DBConfig.DBUser;
                empresa.DbPassword = DBConfig.DBPassword;
                res = empresa.Connect();
                Console.WriteLine("ok createConexion");
            }

            if (res != 0)
            {
                Console.WriteLine(empresa.GetLastErrorDescription());
            }
        }

        public static Company Empresa
        {
            get
            {                
                return empresa;                
            }
            set
            {
                empresa = value;
            }
        }

    }
}
